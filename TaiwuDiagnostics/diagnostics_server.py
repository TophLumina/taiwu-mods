#!/usr/bin/env python3
import argparse
import ctypes
import json
import os
import sqlite3
import sys
import threading
import time
import webbrowser
from datetime import datetime, timezone
from http import HTTPStatus
from http.server import ThreadingHTTPServer, SimpleHTTPRequestHandler
from pathlib import Path
from urllib.parse import parse_qs, urlparse


ROOT_DIR = Path(sys.executable).resolve().parent if getattr(sys, "frozen", False) else Path(__file__).resolve().parent
WEB_DIR = ROOT_DIR / "web"
DEFAULT_DATA_DIR = ROOT_DIR / "data"
DEFAULT_GAME_LOG_LIMIT = 400


def utc_now_iso():
    return datetime.now(timezone.utc).isoformat(timespec="milliseconds").replace("+00:00", "Z")


class EventStore:
    def __init__(self, db_path):
        self.db_path = Path(db_path)
        self.db_path.parent.mkdir(parents=True, exist_ok=True)
        self._lock = threading.Lock()
        self._init_db()

    def _connect(self):
        conn = sqlite3.connect(str(self.db_path), timeout=10)
        conn.row_factory = sqlite3.Row
        return conn

    def _init_db(self):
        with self._connect() as conn:
            conn.execute(
                """
                create table if not exists events (
                    id integer primary key autoincrement,
                    received_at_utc text not null,
                    schema_version integer not null,
                    event_id text,
                    mod text not null,
                    event_type text not null,
                    event_timestamp_utc text not null,
                    session_id text,
                    payload_json text not null,
                    raw_json text not null
                )
                """
            )
            columns = {row["name"] for row in conn.execute("pragma table_info(events)").fetchall()}
            if "event_id" not in columns:
                conn.execute("alter table events add column event_id text")
            conn.execute("create index if not exists idx_events_type on events(event_type, id desc)")
            conn.execute("create index if not exists idx_events_mod on events(mod, id desc)")
            conn.execute(
                "create unique index if not exists idx_events_event_id on events(event_id) where event_id is not null"
            )

    def add_event(self, event):
        if not isinstance(event, dict):
            raise ValueError("event must be a JSON object")

        schema_version = int(event.get("schemaVersion") or 1)
        event_id = event.get("eventId")
        if event_id is not None:
            event_id = str(event_id)
        mod = str(event.get("mod") or "unknown")
        event_type = str(event.get("eventType") or "unknown")
        event_ts = str(event.get("timestampUtc") or utc_now_iso())
        session_id = event.get("sessionId")
        if session_id is not None:
            session_id = str(session_id)
        payload = event.get("payload")
        payload_json = json.dumps(payload if payload is not None else {}, ensure_ascii=False, separators=(",", ":"))
        raw_json = json.dumps(event, ensure_ascii=False, separators=(",", ":"))

        with self._lock:
            with self._connect() as conn:
                if event_id:
                    existing = conn.execute("select id from events where event_id = ?", (event_id,)).fetchone()
                    if existing:
                        return existing["id"]
                try:
                    cur = conn.execute(
                        """
                        insert into events (
                            received_at_utc, schema_version, event_id, mod, event_type,
                            event_timestamp_utc, session_id, payload_json, raw_json
                        )
                        values (?, ?, ?, ?, ?, ?, ?, ?, ?)
                        """,
                        (utc_now_iso(), schema_version, event_id, mod, event_type, event_ts, session_id, payload_json, raw_json),
                    )
                    return cur.lastrowid
                except sqlite3.IntegrityError:
                    if event_id:
                        existing = conn.execute("select id from events where event_id = ?", (event_id,)).fetchone()
                        if existing:
                            return existing["id"]
                    raise

    def import_spooled_events(self, spool_dir, limit=500):
        spool_dir = Path(spool_dir)
        spool_dir.mkdir(parents=True, exist_ok=True)
        imported = 0
        for path in sorted(spool_dir.glob("*.json"))[:limit]:
            importing_path = path.with_suffix(path.suffix + ".importing")
            try:
                path.rename(importing_path)
            except FileNotFoundError:
                continue
            except OSError:
                continue

            try:
                text = importing_path.read_text(encoding="utf-8-sig")
                data = json.loads(text)
                events = data if isinstance(data, list) else [data]
                for event in events:
                    self.add_event(event)
                    imported += 1
                importing_path.unlink(missing_ok=True)
            except Exception as exc:
                bad_path = importing_path.with_suffix(importing_path.suffix + ".bad")
                try:
                    importing_path.replace(bad_path)
                    bad_path.with_suffix(bad_path.suffix + ".txt").write_text(str(exc), encoding="utf-8")
                except Exception:
                    pass

        return imported

    def query_events(self, limit=200, mod=None, event_type=None):
        limit = max(1, min(int(limit), 2000))
        clauses = []
        args = []
        if mod:
            clauses.append("mod = ?")
            args.append(mod)
        if event_type:
            clauses.append("event_type = ?")
            args.append(event_type)
        where = " where " + " and ".join(clauses) if clauses else ""
        args.append(limit)

        with self._connect() as conn:
            rows = conn.execute(
                f"""
                select id, received_at_utc, schema_version, mod, event_type,
                       event_id, event_timestamp_utc, session_id, payload_json
                from events
                {where}
                order by id desc
                limit ?
                """,
                args,
            ).fetchall()

        return [self._row_to_event(row) for row in rows]

    def summary(self):
        with self._connect() as conn:
            total = conn.execute("select count(*) from events").fetchone()[0]
            latest = conn.execute(
                """
                select id, received_at_utc, mod, event_type, event_timestamp_utc, payload_json
                from events
                order by id desc
                limit 1
                """
            ).fetchone()
            by_type = conn.execute(
                """
                select event_type, count(*) as count, max(id) as latest_id
                from events
                group by event_type
                order by latest_id desc
                """
            ).fetchall()
            by_mod = conn.execute(
                """
                select mod, count(*) as count, max(id) as latest_id
                from events
                group by mod
                order by latest_id desc
                """
            ).fetchall()

        return {
            "totalEvents": total,
            "latestEvent": self._row_to_event(latest) if latest else None,
            "byType": [dict(row) for row in by_type],
            "byMod": [dict(row) for row in by_mod],
        }

    def timeline(self, limit=500):
        events = self.query_events(limit=limit)
        timeline = []
        for event in reversed(events):
            payload = event.get("payload") or {}
            elapsed = payload.get("elapsedMs")
            if elapsed is None and isinstance(payload.get("total"), dict):
                elapsed = payload["total"].get("elapsedMs")
            timeline.append(
                {
                    "id": event["id"],
                    "timestampUtc": event["eventTimestampUtc"],
                    "mod": event["mod"],
                    "eventType": event["eventType"],
                    "elapsedMs": elapsed,
                }
            )
        return timeline

    def _row_to_event(self, row):
        if row is None:
            return None
        payload_json = row["payload_json"] if "payload_json" in row.keys() else "{}"
        try:
            payload = json.loads(payload_json)
        except json.JSONDecodeError:
            payload = {}
        return {
            "id": row["id"],
            "receivedAtUtc": row["received_at_utc"],
            "schemaVersion": row["schema_version"] if "schema_version" in row.keys() else 1,
            "eventId": row["event_id"] if "event_id" in row.keys() else None,
            "mod": row["mod"],
            "eventType": row["event_type"],
            "eventTimestampUtc": row["event_timestamp_utc"],
            "sessionId": row["session_id"] if "session_id" in row.keys() else None,
            "payload": payload,
        }


class DiagnosticsHandler(SimpleHTTPRequestHandler):
    server_version = "TaiwuDiagnostics/0.1"

    def translate_path(self, path):
        parsed = urlparse(path)
        rel = parsed.path.lstrip("/")
        if not rel:
            rel = "index.html"
        return str((WEB_DIR / rel).resolve())

    def log_message(self, fmt, *args):
        if self.server.verbose:
            super().log_message(fmt, *args)

    def do_GET(self):
        parsed = urlparse(self.path)
        if parsed.path == "/api/health":
            self._json_response({"ok": True, "timeUtc": utc_now_iso()})
            return
        if parsed.path == "/api/summary":
            self.server.import_spooled_events()
            self._json_response(self.server.store.summary())
            return
        if parsed.path == "/api/events":
            self.server.import_spooled_events()
            qs = parse_qs(parsed.query)
            limit = int(qs.get("limit", ["200"])[0])
            mod = qs.get("mod", [None])[0]
            event_type = qs.get("eventType", [None])[0]
            self._json_response(self.server.store.query_events(limit=limit, mod=mod, event_type=event_type))
            return
        if parsed.path == "/api/timeline":
            self.server.import_spooled_events()
            qs = parse_qs(parsed.query)
            limit = int(qs.get("limit", ["500"])[0])
            self._json_response(self.server.store.timeline(limit=limit))
            return
        if parsed.path == "/api/snapshots":
            self.server.import_spooled_events()
            self._json_response(list_snapshots(self.server.snapshots_dir))
            return
        if parsed.path == "/api/game-log":
            qs = parse_qs(parsed.query)
            limit = int(qs.get("limit", [str(DEFAULT_GAME_LOG_LIMIT)])[0])
            pattern = qs.get("pattern", [""])[0]
            self._json_response(read_game_log_tail(limit=limit, pattern=pattern))
            return
        return super().do_GET()

    def do_POST(self):
        parsed = urlparse(self.path)
        if parsed.path == "/api/shutdown":
            self._json_response({"ok": True})
            threading.Thread(target=self.server.shutdown, daemon=True).start()
            return
        if parsed.path != "/api/events":
            self.send_error(HTTPStatus.NOT_FOUND)
            return

        try:
            length = int(self.headers.get("Content-Length") or "0")
            if length <= 0 or length > 16 * 1024 * 1024:
                raise ValueError("invalid content length")
            body = self.rfile.read(length)
            data = json.loads(body.decode("utf-8"))
            events = data if isinstance(data, list) else [data]
            ids = [self.server.store.add_event(event) for event in events]
            self._json_response({"ok": True, "ids": ids})
        except Exception as exc:
            self._json_response({"ok": False, "error": str(exc)}, status=HTTPStatus.BAD_REQUEST)

    def _json_response(self, value, status=HTTPStatus.OK):
        body = json.dumps(value, ensure_ascii=False).encode("utf-8")
        self.send_response(status)
        self.send_header("Content-Type", "application/json; charset=utf-8")
        self.send_header("Content-Length", str(len(body)))
        self.send_header("Cache-Control", "no-store")
        self.end_headers()
        self.wfile.write(body)


class DiagnosticsServer(ThreadingHTTPServer):
    def __init__(self, address, handler, store, data_dir, verbose=False):
        super().__init__(address, handler)
        self.store = store
        self.data_dir = Path(data_dir)
        self.snapshots_dir = self.data_dir / "snapshots"
        self.spool_dir = self.data_dir / "spool"
        self.spool_dir.mkdir(parents=True, exist_ok=True)
        self._spool_lock = threading.Lock()
        self.verbose = verbose

    def import_spooled_events(self):
        with self._spool_lock:
            return self.store.import_spooled_events(self.spool_dir)


def list_snapshots(snapshots_dir):
    snapshots_dir = Path(snapshots_dir)
    if not snapshots_dir.exists():
        return []
    result = []
    for path in sorted(snapshots_dir.iterdir(), reverse=True):
        if not path.is_dir():
            continue
        metadata_path = path / "metadata.json"
        metadata = {"id": path.name, "path": str(path)}
        if metadata_path.exists():
            try:
                metadata.update(json.loads(metadata_path.read_text(encoding="utf-8")))
            except Exception as exc:
                metadata["metadataError"] = str(exc)
        result.append(metadata)
    return result


def read_game_log_tail(limit=DEFAULT_GAME_LOG_LIMIT, pattern=""):
    limit = max(20, min(int(limit), 2000))
    pattern = (pattern or "").strip()
    logs_dir = find_game_logs_dir()
    if logs_dir is None:
        return {
            "available": False,
            "logsDir": None,
            "latestLog": None,
            "pattern": pattern,
            "returnedLines": 0,
            "lines": [],
        }

    files = sorted(logs_dir.glob("GameData_*.log"), key=lambda path: path.stat().st_mtime, reverse=True)
    if not files:
        return {
            "available": False,
            "logsDir": str(logs_dir),
            "latestLog": None,
            "pattern": pattern,
            "returnedLines": 0,
            "lines": [],
        }

    latest = files[0]
    lines, first_line_number = read_tail_lines(latest, limit * 4)
    if pattern:
        lowered = pattern.lower()
        indexed_lines = [
            (first_line_number + index, text)
            for index, text in enumerate(lines)
            if lowered in text.lower()
        ][-limit:]
    else:
        indexed_lines = [
            (first_line_number + index, text)
            for index, text in enumerate(lines[-limit:])
        ]

    return {
        "available": True,
        "logsDir": str(logs_dir),
        "latestLog": latest.name,
        "latestLogPath": str(latest),
        "lastWriteTime": datetime.fromtimestamp(latest.stat().st_mtime, timezone.utc)
            .isoformat(timespec="milliseconds")
            .replace("+00:00", "Z"),
        "pattern": pattern,
        "returnedLines": len(indexed_lines),
        "files": [path.name for path in files[:8]],
        "lines": [
            {"lineNumber": line_number, "text": text}
            for line_number, text in indexed_lines
        ],
    }


def find_game_logs_dir():
    candidates = []
    if ROOT_DIR.parent.name.lower() == "mod":
        candidates.append(ROOT_DIR.parent.parent / "Logs")
    candidates.extend(
        [
            ROOT_DIR / "Logs",
            ROOT_DIR.parent / "Logs",
            Path.cwd() / "Logs",
            Path(r"D:\SteamLibrary\steamapps\common\The Scroll Of Taiwu\Logs"),
        ]
    )

    seen = set()
    for candidate in candidates:
        try:
            resolved = candidate.resolve()
        except OSError:
            resolved = candidate
        key = str(resolved).lower()
        if key in seen:
            continue
        seen.add(key)
        if resolved.exists() and resolved.is_dir():
            return resolved
    return None


def read_tail_lines(path, line_budget):
    path = Path(path)
    block_size = 64 * 1024
    data = bytearray()
    with path.open("rb") as handle:
        handle.seek(0, os.SEEK_END)
        position = handle.tell()
        while position > 0 and data.count(b"\n") <= line_budget:
            read_size = min(block_size, position)
            position -= read_size
            handle.seek(position)
            data[:0] = handle.read(read_size)

    text = decode_log_bytes(bytes(data))
    lines = text.splitlines()
    if data and not data.startswith((b"\n", b"\r")) and len(lines) > line_budget:
        lines = lines[1:]
    selected = lines[-line_budget:]
    first_line_number = max(1, len(lines) - len(selected) + 1)
    return selected, first_line_number


def decode_log_bytes(data):
    for encoding in ("utf-8-sig", "gb18030", "utf-16"):
        try:
            return data.decode(encoding)
        except UnicodeDecodeError:
            continue
    return data.decode("utf-8", errors="replace")


def parent_process_exists(pid):
    if not pid or pid <= 0:
        return True
    if os.name == "nt":
        synchronize = 0x00100000
        handle = ctypes.windll.kernel32.OpenProcess(synchronize, False, int(pid))
        if not handle:
            return False
        try:
            wait_timeout = 0x00000102
            result = ctypes.windll.kernel32.WaitForSingleObject(handle, 0)
            return result == wait_timeout
        finally:
            ctypes.windll.kernel32.CloseHandle(handle)
    try:
        os.kill(pid, 0)
        return True
    except OSError:
        return False


def monitor_parent(server, pid):
    while parent_process_exists(pid):
        time.sleep(2.0)
    server.shutdown()


def parse_args(argv):
    parser = argparse.ArgumentParser(description="Taiwu local diagnostics server")
    parser.add_argument("--host", default="127.0.0.1")
    parser.add_argument("--port", type=int, default=18580)
    parser.add_argument("--data-dir", default=str(DEFAULT_DATA_DIR))
    parser.add_argument("--parent-pid", type=int, default=0)
    parser.add_argument("--open", action="store_true")
    parser.add_argument("--verbose", action="store_true")
    return parser.parse_args(argv)


def main(argv=None):
    args = parse_args(argv or sys.argv[1:])
    data_dir = Path(args.data_dir).resolve()
    data_dir.mkdir(parents=True, exist_ok=True)
    WEB_DIR.mkdir(parents=True, exist_ok=True)

    store = EventStore(data_dir / "diagnostics.sqlite3")
    server = DiagnosticsServer((args.host, args.port), DiagnosticsHandler, store, data_dir, verbose=args.verbose)

    if args.parent_pid:
        threading.Thread(target=monitor_parent, args=(server, args.parent_pid), daemon=True).start()

    url = f"http://{args.host}:{args.port}/"
    if args.open:
        threading.Timer(0.5, lambda: webbrowser.open(url)).start()

    print(f"TaiwuDiagnostics listening on {url}")
    print(f"Data directory: {data_dir}")
    try:
        server.serve_forever()
    except KeyboardInterrupt:
        pass
    finally:
        server.server_close()


if __name__ == "__main__":
    main()
