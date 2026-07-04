# [天幕心帷]实时分析工具

随游戏后端启动的本地诊断工具，用于查看 SaveWorld、AdvanceMonth、缓存命中、探针事件和 GameData 日志。

## 本地运行

```powershell
python .\TaiwuDiagnostics\diagnostics_server.py --port 18580 --open
```

打开 `http://127.0.0.1:18580/`。

若已通过 `TaiwuDiagnostics/Build-DiagnosticsServerExe.ps1` 打包出 `TaiwuDiagnostics.exe`，后端桥接层会优先启动该可执行文件；未打包时才回退到 Python 源码启动。

后端 mod 会向本地服务发送结构化事件：

```text
POST http://127.0.0.1:18580/api/events
```

数据保存到 `TaiwuDiagnostics/data/diagnostics.sqlite3`。

## 主要事件

- `diagnostics.server_ready`：诊断服务已启动。
- `diagnostics.patch_ready`：诊断补丁已安装。
- `diagnostics.save_world`：存档写入详细拆解。
- `diagnostics.advance_month`：过月总耗时。
- `diagnostics.update_information`：见闻更新耗时。
- `diagnostics.character_action_planning`：NPC 行动规划、目标过滤、条件匹配与诊断缓存命中统计。
