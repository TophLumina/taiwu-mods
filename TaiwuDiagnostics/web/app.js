const state = {
  summary: null,
  events: [],
  snapshots: [],
  gameLog: null
};

const saveTypes = new Set(["diagnostics.save_world", "save_world"]);
const advanceMonthTypes = new Set([
  "diagnostics.advance_month",
  "diagnostics.update_information",
  "diagnostics.character_action_planning",
  "advance_month.scope_begin",
  "advance_month.scope_end",
  "advance_month.update_information",
  "advance_month.character_action_planning"
]);

const eventNames = {
  "diagnostics.server_ready": "诊断服务就绪",
  "diagnostics.patch_ready": "探针补丁就绪",
  "diagnostics.patch_error": "探针补丁失败",
  "diagnostics.save_world": "存档写入诊断",
  "diagnostics.advance_month": "过月总耗时",
  "diagnostics.update_information": "见闻更新耗时",
  "diagnostics.character_action_planning": "diagnostics.character_action_planning",
  "save_world": "存档写入诊断",
  "advance_month.update_information": "见闻更新细节",
  "advance_month.character_action_planning": "advance_month.character_action_planning",
  "advance_month.scope_begin": "过月开始",
  "advance_month.scope_end": "过月结束"
};

function $(id) {
  return document.getElementById(id);
}

async function fetchJson(url, options) {
  const response = await fetch(url, options);
  if (!response.ok) {
    throw new Error(`${response.status} ${response.statusText}`);
  }
  return response.json();
}

async function refresh() {
  $("status").textContent = "正在刷新...";
  const eventType = $("eventTypeFilter")?.value?.trim();
  const limit = Math.max(1, Math.min(Number($("eventLimit")?.value || 500), 2000));
  const eventQuery = new URLSearchParams({ limit: String(limit) });
  if (eventType) {
    eventQuery.set("eventType", eventType);
  }

  const gameLogPattern = $("gameLogPattern")?.value?.trim();
  const gameLogLimit = Math.max(20, Math.min(Number($("gameLogLimit")?.value || 400), 2000));
  const gameLogQuery = new URLSearchParams({ limit: String(gameLogLimit) });
  if (gameLogPattern) {
    gameLogQuery.set("pattern", gameLogPattern);
  }

  const [summary, events, snapshots, gameLog] = await Promise.all([
    fetchJson("/api/summary"),
    fetchJson(`/api/events?${eventQuery}`),
    fetchJson("/api/snapshots"),
    fetchJson(`/api/game-log?${gameLogQuery}`)
  ]);

  state.summary = summary;
  state.events = events;
  state.snapshots = snapshots;
  state.gameLog = gameLog;

  renderSaveDiagnostics();
  renderAdvanceMonth();
  renderProbeEvents();
  renderSnapshots();
  renderGameLog();
  renderOutline();
  $("status").textContent = `已连接，最后刷新 ${new Date().toLocaleTimeString()}`;
}

function renderSaveDiagnostics() {
  const saves = state.events.filter(event => saveTypes.has(event.eventType));
  const latest = saves[0];
  const payload = latest?.payload || null;

  if (!latest || !payload) {
    $("latestSaveElapsed").textContent = "-";
    $("latestSaveSize").textContent = "-";
    $("slowestDomain").textContent = "尚未捕获存档写入事件";
    $("databaseCopy").textContent = "-";
    $("latestSaveTime").textContent = "-";
    $("saveStageBreakdown").textContent = "等待下一次保存世界。";
    $("domainBreakdown").textContent = "暂无 Domain 数据。";
    renderEventCards($("saveEventList"), [], { compact: true });
    return;
  }

  $("latestSaveElapsed").textContent = formatMs(getElapsedMs(payload));
  $("latestSaveSize").textContent = formatBytes(payload.total?.fileSizeBytes);
  $("latestSaveTime").textContent = `${formatEventName(latest.eventType)} / ${formatTime(latest.eventTimestampUtc)}`;

  const domains = Array.isArray(payload.domains) ? payload.domains : [];
  const slowest = domains[0];
  $("slowestDomain").innerHTML = slowest
    ? `${escapeHtml(slowest.name)}<br><strong>${formatMs(slowest.elapsedMs)}</strong> / ${formatInt(slowest.calls || 1)} 次`
    : "未记录到 Domain 分段";

  const db = payload.database || {};
  $("databaseCopy").innerHTML = [
    `复制 ${formatMs(db.copyWorkingDbMs)}`,
    `${formatBytes(db.copyWorkingDbBytes)}`,
    `${formatInt(db.copyWorkingDbCalls || 0)} 次`
  ].join("<br>");

  renderSaveStages(payload);
  renderDomains(domains);
  renderEventCards($("saveEventList"), saves.slice(0, 20), { compact: true, emphasizeSave: true });
}

function renderSaveStages(payload) {
  const archive = payload.archiveFile || {};
  const db = payload.database || {};
  const compression = payload.compression || {};
  const domainTotal = sum((payload.domains || []).map(domain => domain.elapsedMs));
  const stages = [
    ["总耗时", payload.total?.elapsedMs ?? payload.elapsedMs],
    ["Header 写入", archive.writeHeaderMs],
    ["正文写入", archive.writeContentMs],
    ["Domain 保存合计", domainTotal],
    ["数据库断连", db.disconnectMs],
    ["working.db 复制", db.copyWorkingDbMs],
    ["数据库重连", db.connectMs],
    ["压缩收尾", compression.endCompressionMs],
    ["CRC 写入", compression.writeCrcMs],
    ["正文未拆分部分", archive.contentOtherMs],
    ["总未拆分部分", payload.total?.otherMs]
  ].filter(row => typeof row[1] === "number" && row[1] >= 0);

  renderBars($("saveStageBreakdown"), stages);
}

function renderBars(container, rows) {
  container.innerHTML = "";
  if (!rows.length) {
    container.textContent = "暂无可展示的阶段耗时。";
    return;
  }

  const max = Math.max(...rows.map(row => row[1]), 1);
  for (const [name, value] of rows) {
    const row = document.createElement("div");
    row.className = "bar-row";
    const width = Math.max(2, (value / max) * 100);
    row.innerHTML = `
      <div class="bar-label">
        <span>${escapeHtml(name)}</span>
        <strong>${formatMs(value)}</strong>
      </div>
      <div class="bar-track"><div class="bar-fill" style="width:${width}%"></div></div>
    `;
    container.appendChild(row);
  }
}

function renderDomains(domains) {
  const container = $("domainBreakdown");
  container.innerHTML = "";
  $("domainCount").textContent = domains.length ? `${domains.length} 个 Domain` : "-";
  if (!domains.length) {
    container.textContent = "暂无 Domain 保存耗时。";
    return;
  }

  const max = Math.max(...domains.map(domain => domain.elapsedMs || 0), 1);
  for (const domain of domains.slice(0, 40)) {
    const row = document.createElement("div");
    row.className = "table-row";
    row.innerHTML = `
      <span class="mono">${escapeHtml(domain.name)}</span>
      <span>${formatInt(domain.calls || 1)} 次</span>
      <span>${formatMs(domain.elapsedMs)}</span>
      <span class="mini-track"><i style="width:${Math.max(2, ((domain.elapsedMs || 0) / max) * 100)}%"></i></span>
    `;
    container.appendChild(row);
  }
}

function renderAdvanceMonth() {
  renderPlanningDiagnostics();
  const events = state.events.filter(event => advanceMonthTypes.has(event.eventType));
  renderEventCards($("advanceMonthEvents"), events.slice(0, 80), { compact: true });
}

function renderPlanningDiagnostics() {
  const optimizationEvent = state.events.find(item => item.eventType === "advance_month.character_action_planning");
  const diagnosticEvent = state.events.find(item => item.eventType === "diagnostics.character_action_planning");
  const optimizationPayload = optimizationEvent?.payload || null;
  const diagnosticPayload = diagnosticEvent?.payload || null;

  if (!optimizationPayload && !diagnosticPayload) {
    $("planningElapsed").textContent = "-";
    $("planningHotStep").textContent = "尚未捕获 NPC 行动规划事件";
    $("planningCacheHitRate").textContent = "-";
    $("planningCacheKeys").textContent = "-";
    $("planningEventTime").textContent = "-";
    $("planningStepBreakdown").textContent = "等待下一次过月。";
    $("optimizationCacheOverview").textContent = "尚未收到优化 mod 缓存事件。";
    $("planningParallelActions").textContent = "暂无并行 action 数据。";
    $("planningParallelInvocations").textContent = "暂无每角色 action 调用。";
    $("planningMonthlyMethods").textContent = "暂无 NPC 月结方法数据。";
    $("planningCacheBreakdown").textContent = "暂无缓存统计。";
    $("planningActionHotspots").textContent = "暂无行动热点。";
    $("targetLookupCacheRows").textContent = "暂无 TargetLookupCache 数据。";
    $("planningGraphCacheRows").textContent = "暂无 GraphCache 数据。";
    return;
  }

  const stage = diagnosticPayload?.characterActionPlanningStage;
  $("planningElapsed").textContent = stage?.captured
    ? formatMs(stage.elapsedMs)
    : formatMs(getElapsedMs(diagnosticPayload || optimizationPayload));
  $("planningEventTime").innerHTML = [
    diagnosticEvent
      ? `WorldDomain.AdvanceMonth_Execute: ${formatEventName(diagnosticEvent.eventType)} / ${formatTime(diagnosticEvent.eventTimestampUtc)}`
      : "WorldDomain.AdvanceMonth_Execute: no TaiwuDiagnostics event",
    optimizationEvent
      ? `CharacterActionPlanningDiagnostics.EndAdvanceMonth: ${formatEventName(optimizationEvent.eventType)} / ${formatTime(optimizationEvent.eventTimestampUtc)}`
      : "CharacterActionPlanningDiagnostics.EndAdvanceMonth: no TaiwuOptimization event"
  ].map(escapeHtml).join("<br>");

  const optimizationActivity = getOptimizationPlanningActivity(optimizationPayload);
  const cacheStats = collectOptimizationCacheStats(optimizationPayload);
  $("planningCacheHitRate").textContent = !optimizationPayload
    ? "-"
    : optimizationActivity.hasGoalPlanning
      ? (cacheStats.calls ? formatPercent(cacheStats.hits / cacheStats.calls) : "0 calls")
      : "未执行";
  $("planningCacheKeys").innerHTML = !optimizationPayload
    ? "-"
    : optimizationActivity.hasGoalPlanning
      ? `${formatInt(cacheStats.keys)}<br><span class="muted">TargetMatcherCache key</span>`
      : `0<br><span class="muted">UpdatePrimaryGoalAndActions not entered</span>`;

  const stepPayload = optimizationPayload || diagnosticPayload;
  const steps = mergeNamedMetrics(
    stepPayload?.primaryGoalActions?.steps || [],
    stepPayload?.secondaryGoalActions?.steps || [],
    "主",
    "副");
  const hotStep = steps[0];
  $("planningHotStep").innerHTML = hotStep
    ? `${escapeHtml(translatePlanningName(hotStep.name))}<br><strong>${formatMs(hotStep.elapsedMs)}</strong> / ${formatInt(hotStep.calls || 0)} calls`
    : "UpdatePrimaryGoalAndActions / UpdateSecondaryGoalAndActions not entered";
  renderBars(
    $("planningStepBreakdown"),
    steps.slice(0, 18).map(item => [translatePlanningName(item.name), item.elapsedMs || 0]));

  renderOptimizationCacheOverview(optimizationPayload, optimizationEvent);
  renderPlanningParallelActions(diagnosticPayload?.parallelActionTypes || optimizationPayload?.parallelStages || []);
  renderPlanningParallelInvocations(diagnosticPayload?.parallelActionInvocations || []);
  renderPlanningMonthlyMethods(diagnosticPayload?.characterMonthlyMethods || []);
  renderPlanningCacheRows(
    collectTargetMatcherCaches(optimizationPayload),
    Boolean(optimizationPayload),
    optimizationActivity.hasGoalPlanning);
  renderTargetLookupCacheRows(optimizationPayload);
  renderPlanningGraphCacheRows(optimizationPayload);

  const actionCacheRows = collectPlanningActionCacheRows(optimizationPayload || diagnosticPayload);
  renderPlanningActionCacheRows(actionCacheRows, Boolean(optimizationPayload || diagnosticPayload));
}

function renderOptimizationCacheOverview(payload, event) {
  const container = $("optimizationCacheOverview");
  container.innerHTML = "";
  if (!payload) {
    container.textContent = "未收到 TaiwuOptimization 的 advance_month.character_action_planning。请确认优化 mod 已启用、DLL 已更新，并且诊断服务端口与 TaiwuDiagnostics 一致。";
    return;
  }

  const activity = getOptimizationPlanningActivity(payload);
  const targetLookup = aggregateRows(payload.targetLookupCalls || []);
  const graphLookup = aggregateRows(payload.planningGraphCache?.lookups || []);
  const matcher = collectOptimizationCacheStats(payload);
  const build = payload.targetLookupBuild || {};
  const targetSnapshot = build.snapshot || {};
  const locationEpochCount = sum((build.locationEpochIncrements || []).map(row => row.count || 0));

  const rows = [
    ["优化事件", event ? `#${event.id}` : "-", event ? formatTime(event.eventTimestampUtc) : "-", formatMs(getElapsedMs(payload))],
    ["UpdatePrimaryGoalAndActions / UpdateSecondaryGoalAndActions", activity.hasGoalPlanning ? "entered" : "not entered", `Primary ${formatInt(activity.primaryStageCalls)} / Secondary ${formatInt(activity.secondaryStageCalls)}`, `Step calls ${formatInt(activity.goalStepCalls)}`],
    ["OfflineUpdateCurrentGoalActionsMatcherCache", `${formatInt(matcher.calls)} calls`, `${formatInt(matcher.hits)} hits / ${formatInt(matcher.fallbacks)} fallback`, matcher.calls ? formatPercent(matcher.hits / matcher.calls) : "-"],
    ["OfflineUpdateCurrentGoalActionsTargetLookupCache", `${formatInt(build.calls || 0)} builds / ${formatInt(targetLookup.calls)} lookups`, `full ${formatInt(build.fullBuilds || 0)} / locationEpoch ${formatInt(locationEpochCount)}`, `characters ${formatInt(targetSnapshot.characterIds)} / blocks ${formatInt(targetSnapshot.blocks)}`],
    ["CharacterActionPlannerGraphCache", `${formatInt(graphLookup.calls)} lookups`, `${formatInt(graphLookup.hits)} hits / ${formatInt(graphLookup.misses)} misses`, graphLookup.calls ? formatPercent(graphLookup.hits / graphLookup.calls) : "-"]
  ];

  if (!activity.hasGoalPlanning) {
    rows.push([
      "State",
      "No cache fault",
      "UpdatePrimaryGoalAndActions / UpdateSecondaryGoalAndActions not entered",
      "zero metrics are expected"
    ]);
  }

  for (const row of rows) {
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row[0])}</span>
      <span>${escapeHtml(row[1])}</span>
      <span>${escapeHtml(row[2])}</span>
      <span>${escapeHtml(row[3])}</span>
    `;
    container.appendChild(item);
  }

  if (payload.legacyText) {
    const details = document.createElement("details");
    details.className = "log-details";
    details.open = true;
    details.innerHTML = `
      <summary>GameLog 同源诊断文本</summary>
      <pre class="log-text">${escapeHtml(payload.legacyText)}</pre>
    `;
    container.appendChild(details);
  }
}

function getOptimizationPlanningActivity(payload) {
  if (!payload) {
    return {
      hasGoalPlanning: false,
      primaryStageCalls: 0,
      secondaryStageCalls: 0,
      goalStepCalls: 0
    };
  }

  const primaryStage = findNamedMetric(payload.parallelStages || [], "UpdatePrimaryGoalAndActions");
  const secondaryStage = findNamedMetric(payload.parallelStages || [], "UpdateSecondaryGoalAndActions");
  const primarySteps = payload.primaryGoalActions?.steps || [];
  const secondarySteps = payload.secondaryGoalActions?.steps || [];
  const goalStepCalls = sum([...primarySteps, ...secondarySteps].map(row => row.calls || 0));
  const primaryStageCalls = primaryStage?.calls || 0;
  const secondaryStageCalls = secondaryStage?.calls || 0;
  return {
    hasGoalPlanning: primaryStageCalls > 0 || secondaryStageCalls > 0 || goalStepCalls > 0,
    primaryStageCalls,
    secondaryStageCalls,
    goalStepCalls
  };
}

function findNamedMetric(rows, name) {
  return rows.find(row => row?.name === name) || null;
}

function collectOptimizationCacheStats(payload) {
  if (!payload) {
    return { calls: 0, hits: 0, misses: 0, fallbacks: 0, keys: 0 };
  }

  const matcherRows = collectTargetMatcherCaches(payload);
  const lookupRows = payload.targetLookupCalls || [];
  const graphRows = payload.planningGraphCache?.lookups || [];
  const rows = [...matcherRows, ...lookupRows, ...graphRows];
  const primaryCounts = payload.primaryGoalActions?.topCounts || {};
  const secondaryCounts = payload.secondaryGoalActions?.topCounts || {};
  return {
    calls: sum(rows.map(row => row.calls || 0)),
    hits: sum(rows.map(row => row.hits || 0)),
    misses: sum(rows.map(row => row.misses || 0)),
    fallbacks: sum(rows.map(row => row.fallbacks || 0)),
    keys: (primaryCounts.targetMatcherCacheByAction || 0) + (secondaryCounts.targetMatcherCacheByAction || 0),
  };
}

function aggregateRows(rows) {
  return {
    calls: sum(rows.map(row => row.calls || 0)),
    hits: sum(rows.map(row => row.hits || 0)),
    misses: sum(rows.map(row => row.misses || 0)),
    fallbacks: sum(rows.map(row => row.fallbacks || 0)),
    candidateIds: sum(rows.map(row => row.candidateIds || 0)),
    charactersAdded: sum(rows.map(row => row.charactersAdded || 0)),
    returnedNodes: sum(rows.map(row => row.returnedNodes || 0))
  };
}

function collectTargetMatcherCaches(payload) {
  if (!payload) {
    return [];
  }

  return [
    ...(payload.primaryGoalActions?.top?.targetMatcherCacheByAction || []).map(item => ({ ...item, goal: "主" })),
    ...(payload.secondaryGoalActions?.top?.targetMatcherCacheByAction || []).map(item => ({ ...item, goal: "副" }))
  ].sort((left, right) => (right.savedCalls || 0) - (left.savedCalls || 0));
}

function collectPlanningActionCacheRows(payload) {
  if (!payload) {
    return [];
  }

  const map = new Map();
  collectGoalActionCacheRows(map, payload.primaryGoalActions, "Primary");
  collectGoalActionCacheRows(map, payload.secondaryGoalActions, "Secondary");
  return [...map.values()].sort((left, right) => {
    const leftScore =
      (left.targetMatcherCacheByAction?.savedCalls || 0) +
      (left.relationTargetPrefilterByAction?.dropped || 0) +
      (left.relationPrefilterByAction?.dropped || 0) +
      (left.filterTargetsByAction?.elapsedMs || 0);
    const rightScore =
      (right.targetMatcherCacheByAction?.savedCalls || 0) +
      (right.relationTargetPrefilterByAction?.dropped || 0) +
      (right.relationPrefilterByAction?.dropped || 0) +
      (right.filterTargetsByAction?.elapsedMs || 0);
    return rightScore - leftScore;
  });
}

function collectGoalActionCacheRows(map, goalPayload, goal) {
  const top = goalPayload?.top || {};
  addActionCacheRows(map, goal, top.prepareContextByAction, "prepareContextByAction");
  addActionCacheRows(map, goal, top.filterTargetsByAction, "filterTargetsByAction");
  addActionCacheRows(map, goal, top.relationTargetPrefilterByAction, "relationTargetPrefilterByAction");
  addActionCacheRows(map, goal, top.relationPrefilterByAction, "relationPrefilterByAction");
  addActionCacheRows(map, goal, top.targetMatcherCacheByAction, "targetMatcherCacheByAction");
  addActionCacheRows(map, goal, top.targetConditionsByAction, "targetConditionsByAction");
  addActionCacheRows(map, goal, top.actionTargetMatchByAction, "actionTargetMatchByAction");
  addActionCacheRows(map, goal, top.relationConditionsByAction, "relationConditionsByAction");
}

function addActionCacheRows(map, goal, rows, fieldName) {
  if (!Array.isArray(rows)) {
    return;
  }

  for (const row of rows) {
    if (typeof row.actionTemplateId !== "number") {
      continue;
    }

    const key = `${goal}:${row.actionTemplateId}`;
    const current = map.get(key) || {
      goal,
      actionTemplateId: row.actionTemplateId,
      actionName: row.actionName || ""
    };
    current.actionName = current.actionName || row.actionName || "";
    current[fieldName] = row;
    map.set(key, current);
  }
}

function renderPlanningParallelActions(rows) {
  const container = $("planningParallelActions");
  container.innerHTML = "";
  if (!rows.length) {
    container.textContent = "暂无并行 action 数据。";
    return;
  }

  for (const row of rows.slice(0, 32)) {
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row.name)}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatMs(row.elapsedMs)}</span>
      <span>${formatMs(row.maxMs)}</span>
    `;
    container.appendChild(item);
  }
}

function renderPlanningParallelInvocations(rows) {
  const container = $("planningParallelInvocations");
  container.innerHTML = "";
  if (!rows.length) {
    container.textContent = "暂无每角色 action 调用。";
    return;
  }

  for (const row of rows.slice(0, 40)) {
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(shortTypeName(row.name))}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatMs(row.elapsedMs)}</span>
      <span>${formatMs(row.maxMs)}</span>
    `;
    container.appendChild(item);
  }
}

function renderPlanningMonthlyMethods(rows) {
  const container = $("planningMonthlyMethods");
  container.innerHTML = "";
  if (!rows.length) {
    container.textContent = "暂无 NPC 月结方法数据。";
    return;
  }

  for (const row of rows.slice(0, 48)) {
    const action = row.actionType ? shortTypeName(row.actionType) : "未归因";
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(action)} / ${escapeHtml(row.name)}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatMs(row.elapsedMs)}</span>
      <span>${formatMs(row.maxMs)}</span>
    `;
    container.appendChild(item);
  }
}

function mergeNamedMetrics(primary, secondary, primaryLabel, secondaryLabel) {
  const map = new Map();
  for (const row of [...primary, ...secondary]) {
    const name = row.name;
    if (!name) {
      continue;
    }
    const current = map.get(name) || {
      name,
      elapsedMs: 0,
      calls: 0,
      maxMs: 0,
      inputCount: 0,
      outputCount: 0,
      sources: []
    };
    current.elapsedMs += row.elapsedMs || 0;
    current.calls += row.calls || 0;
    current.maxMs = Math.max(current.maxMs, row.maxMs || 0);
    current.inputCount += row.inputCount || 0;
    current.outputCount += row.outputCount || 0;
    current.sources.push(primary.includes(row) ? primaryLabel : secondaryLabel);
    map.set(name, current);
  }
  return [...map.values()]
    .filter(item => (item.calls || 0) > 0 || (item.elapsedMs || 0) > 0)
    .sort((left, right) => right.elapsedMs - left.elapsedMs);
}

function renderPlanningCacheRows(rows, hasOptimizationEvent, hasGoalPlanning) {
  const container = $("planningCacheBreakdown");
  container.innerHTML = "";
  if (!hasOptimizationEvent) {
    container.textContent = "未收到优化 mod 的 matcher 缓存事件；这里需要 TaiwuOptimization 发出 advance_month.character_action_planning。";
    return;
  }

  if (!hasGoalPlanning) {
    container.textContent = "UpdatePrimaryGoalAndActions / UpdateSecondaryGoalAndActions not entered; matcher cache was not called.";
    return;
  }

  if (!rows.length) {
    container.textContent = "本次优化事件未记录到 matcher 缓存命中或 fallback。";
    return;
  }

  for (const row of rows.slice(0, 30)) {
    const fallbackReasons = Array.isArray(row.fallbackReasons) && row.fallbackReasons.length
      ? ` / ${row.fallbackReasons.slice(0, 2).map(reason => `${reason.reason}${reason.detailName ? `(${reason.detailName})` : ""}:${reason.count}`).join(", ")}`
      : "";
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row.goal)} / A${row.actionTemplateId} ${escapeHtml(row.actionName || "")}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatInt(row.hits || 0)} hits / ${formatInt(row.fallbacks || 0)} fallback${escapeHtml(fallbackReasons)}</span>
      <span>${formatPercent(row.hitRate || 0)}</span>
    `;
    container.appendChild(item);
  }
}

function renderPlanningActionCacheRows(rows, hasPlanningPayload) {
  const container = $("planningActionHotspots");
  container.innerHTML = "";
  if (!hasPlanningPayload) {
    container.textContent = "未收到 CharacterActionPlanning payload。";
    return;
  }

  if (!rows.length) {
    container.textContent = "本次 payload 未记录到可按 actionTemplateId 归因的 cache / prefilter 数据。";
    return;
  }

  for (const row of rows.slice(0, 40)) {
    const filterTargets = row.filterTargetsByAction;
    const relationTarget = row.relationTargetPrefilterByAction;
    const relationPrefilter = row.relationPrefilterByAction;
    const matcher = row.targetMatcherCacheByAction;
    const conditions = row.targetConditionsByAction;
    const relationConditions = row.relationConditionsByAction;
    const fallbackReasons = Array.isArray(matcher?.fallbackReasons) && matcher.fallbackReasons.length
      ? `<br><small>${matcher.fallbackReasons.slice(0, 2).map(reason => `${escapeHtml(reason.reason)}:${formatInt(reason.count || 0)}`).join(" / ")}</small>`
      : "";
    const item = document.createElement("div");
    item.className = "table-row action-cache-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row.goal)} / A${row.actionTemplateId} ${escapeHtml(row.actionName || "")}</span>
      <span>
        <strong>filterTargetsByAction</strong><br>
        calls ${formatInt(filterTargets?.calls || 0)} / input ${formatInt(filterTargets?.inputCount || 0)} / output ${formatInt(filterTargets?.outputCount || 0)}<br>
        <small>${formatMs(filterTargets?.elapsedMs)}</small>
      </span>
      <span>
        <strong>relationTargetPrefilterByAction</strong><br>
        calls ${formatInt(relationTarget?.calls || 0)} / input ${formatInt(relationTarget?.inputCount || 0)} / output ${formatInt(relationTarget?.outputCount || 0)}<br>
        <small>dropped ${formatInt(relationTarget?.dropped || 0)} / zeroOutput ${formatInt(relationTarget?.zeroOutputCount || 0)}</small>
      </span>
      <span>
        <strong>relationPrefilterByAction</strong><br>
        calls ${formatInt(relationPrefilter?.calls || 0)} / selectable ${formatInt(relationPrefilter?.selectableCount || 0)}<br>
        <small>relationCandidate ${formatInt(relationPrefilter?.relationCandidateCount || 0)} / dropped ${formatInt(relationPrefilter?.dropped || 0)}</small>
      </span>
      <span>
        <strong>targetMatcherCacheByAction</strong><br>
        hits ${formatInt(matcher?.hits || 0)} / calls ${formatInt(matcher?.calls || 0)} / fallbacks ${formatInt(matcher?.fallbacks || 0)}<br>
        <small>hitRate ${matcher ? formatPercent(matcher.hitRate || 0) : "-"} / savedCalls ${formatInt(matcher?.savedCalls || 0)}</small>${fallbackReasons}
      </span>
      <span>
        <strong>targetConditionsByAction</strong><br>
        calls ${formatInt(conditions?.calls || 0)} / success ${formatInt(conditions?.successCount || 0)} / failure ${formatInt(conditions?.failureCount || 0)}<br>
        <small>relationPass ${formatInt(relationConditions?.relationPassCount || 0)} / relationFail ${formatInt(relationConditions?.relationFailCount || 0)}</small>
      </span>
    `;
    container.appendChild(item);
  }
}

function renderTargetLookupCacheRows(payload) {
  const container = $("targetLookupCacheRows");
  container.innerHTML = "";
  if (!payload) {
    container.textContent = "未收到 TaiwuOptimization 的 TargetLookupCache 数据。";
    return;
  }

  const rows = payload.targetLookupCalls || [];
  if (!rows.length) {
    container.textContent = "本次 payload 未包含 targetLookupCalls。";
    return;
  }

  for (const row of rows) {
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row.name || "-")}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatInt(row.hits || 0)} hits / ${formatInt(row.fallbacks || 0)} fallback</span>
      <span>candidateIds ${formatInt(row.candidateIds || 0)} / charactersAdded ${formatInt(row.charactersAdded || 0)}</span>
    `;
    container.appendChild(item);
  }
}

function renderPlanningGraphCacheRows(payload) {
  const container = $("planningGraphCacheRows");
  container.innerHTML = "";
  if (!payload) {
    container.textContent = "未收到 TaiwuOptimization 的 GraphCache 数据。";
    return;
  }

  const rows = payload.planningGraphCache?.lookups || [];
  if (!rows.length) {
    container.textContent = "本次 payload 未包含 planningGraphCache.lookups。";
    return;
  }

  const build = payload.planningGraphCache?.build || {};
  const snapshot = payload.planningGraphCache?.snapshot || {};
  const summary = document.createElement("div");
  summary.className = "table-row";
  summary.innerHTML = `
    <span class="mono">build</span>
    <span>${formatInt(build.calls || 0)} calls</span>
    <span>${formatInt(build.successes || 0)} successes / ${formatInt(build.failures || 0)} failures</span>
    <span>${formatMs(build.elapsedMs)} / conditions ${formatInt(snapshot.conditions || 0)} / effects ${formatInt(snapshot.effects || 0)}</span>
  `;
  container.appendChild(summary);

  for (const row of rows) {
    const item = document.createElement("div");
    item.className = "table-row";
    item.innerHTML = `
      <span class="mono">${escapeHtml(row.name || "-")}</span>
      <span>${formatInt(row.calls || 0)} calls</span>
      <span>${formatInt(row.hits || 0)} hits / ${formatInt(row.misses || 0)} misses</span>
      <span>${formatInt(row.fallbacks || 0)} fallback / returnedNodes ${formatInt(row.returnedNodes || 0)}</span>
    `;
    container.appendChild(item);
  }
}

function renderProbeEvents() {
  $("totalEvents").textContent = state.summary?.totalEvents ?? 0;
  const latest = state.summary?.latestEvent;
  $("latestEvent").textContent = latest
    ? `#${latest.id} ${formatEventName(latest.eventType)} / ${latest.mod} / ${formatTime(latest.eventTimestampUtc)}`
    : "暂无事件";

  renderCountList($("eventTypeList"), state.summary?.byType || [], "event_type", formatEventName);
  renderCountList($("modList"), state.summary?.byMod || [], "mod", value => value);
  renderEventCards($("rawEvents"), state.events, { compact: false });
}

function renderCountList(container, rows, nameKey, formatter) {
  container.innerHTML = "";
  if (!rows.length) {
    container.textContent = "暂无数据";
    return;
  }
  for (const row of rows.slice(0, 8)) {
    const item = document.createElement("div");
    item.className = "list-row";
    item.innerHTML = `<span>${escapeHtml(formatter(row[nameKey]))}</span><strong>${row.count}</strong>`;
    container.appendChild(item);
  }
}

function renderSnapshots() {
  const container = $("snapshotList");
  container.innerHTML = "";
  if (!state.snapshots.length) {
    container.textContent = "尚未生成存档快照。";
    return;
  }
  for (const snapshot of state.snapshots) {
    const card = document.createElement("article");
    card.className = "event-card";
    card.innerHTML = `
      <header>
        <span class="event-title">${escapeHtml(snapshot.id || snapshot.timestampUtc || "snapshot")}</span>
        <span>${escapeHtml(translateStatus(snapshot.status))}</span>
      </header>
      <dl class="detail-grid">
        <div><dt>来源</dt><dd>${escapeHtml(snapshot.source || "-")}</dd></div>
        <div><dt>复制大小</dt><dd>${formatBytes(snapshot.copiedBytes)}</dd></div>
        <div><dt>原始路径</dt><dd>${escapeHtml(snapshot.originalPath || "-")}</dd></div>
        <div><dt>副本路径</dt><dd>${escapeHtml(snapshot.archiveCopyPath || "-")}</dd></div>
      </dl>
      <details>
        <summary>查看完整元数据</summary>
        <pre>${escapeHtml(JSON.stringify(snapshot, null, 2))}</pre>
      </details>
    `;
    container.appendChild(card);
  }
}

function renderGameLog() {
  const payload = state.gameLog || {};
  const status = $("gameLogStatus");
  const container = $("gameLogLines");
  container.innerHTML = "";

  if (!payload.available) {
    status.textContent = payload.logsDir ? `未找到日志：${payload.logsDir}` : "未找到 Logs 目录";
    container.textContent = "等待游戏生成 Logs/GameData_*.log。";
    return;
  }

  status.textContent = `${payload.latestLog || "-"} / ${formatInt(payload.returnedLines || 0)} lines`;
  const lines = payload.lines || [];
  if (!lines.length) {
    container.textContent = payload.pattern ? "最新日志中没有匹配关键字的行。" : "最新日志为空。";
    return;
  }

  for (const line of lines) {
    const item = document.createElement("div");
    item.className = "log-line";
    item.innerHTML = `
      <span class="log-line-number">${line.lineNumber ? formatInt(line.lineNumber) : "-"}</span>
      <span class="mono">${escapeHtml(line.text || "")}</span>
    `;
    container.appendChild(item);
  }
}

function renderEventCards(container, events, options) {
  const compact = options?.compact ?? false;
  container.innerHTML = "";
  if (!events.length) {
    container.textContent = "暂无匹配事件。";
    return;
  }
  for (const event of events) {
    const payload = compact ? compactPayload(event.payload) : event.payload;
    const card = document.createElement("article");
    card.className = "event-card";
    const summary = summarizeEvent(event);
    card.innerHTML = `
      <header>
        <span><span class="event-title">#${event.id}</span> ${escapeHtml(formatEventName(event.eventType))}</span>
        <span>${escapeHtml(event.mod)} / ${formatTime(event.eventTimestampUtc)}</span>
      </header>
      ${summary ? `<div class="event-summary">${summary}</div>` : ""}
      <details ${compact ? "" : "open"}>
        <summary>查看 JSON 负载</summary>
        <pre>${escapeHtml(JSON.stringify(payload, null, 2))}</pre>
      </details>
    `;
    container.appendChild(card);
  }
}

function summarizeEvent(event) {
  const payload = event.payload || {};
  if (saveTypes.has(event.eventType)) {
    const db = payload.database || {};
    const domains = Array.isArray(payload.domains) ? payload.domains : [];
    const slowest = domains[0];
    return `
      <span>总耗时 <strong>${formatMs(getElapsedMs(payload))}</strong></span>
      <span>大小 <strong>${formatBytes(payload.total?.fileSizeBytes)}</strong></span>
      <span>DB 复制 <strong>${formatMs(db.copyWorkingDbMs)}</strong></span>
      <span>最慢 Domain <strong>${escapeHtml(slowest?.name || "-")}</strong></span>
    `;
  }

  if (event.eventType === "diagnostics.character_action_planning") {
    const stage = payload.characterActionPlanningStage || {};
    return `
      <span>CharacterActionPlanning <strong>${formatMs(stage.elapsedMs)}</strong></span>
      <span>WorldDomain.AdvanceMonth <strong>${formatMs(getElapsedMs(payload))}</strong></span>
    `;
  }

  if (event.eventType === "advance_month.character_action_planning") {
    const cacheStats = collectOptimizationCacheStats(payload);
    return `
      <span>Optimization cache hitRate <strong>${cacheStats.calls ? formatPercent(cacheStats.hits / cacheStats.calls) : "-"}</strong></span>
      <span>targetMatcherCacheByAction count <strong>${formatInt(cacheStats.keys)}</strong></span>
    `;
  }

  const elapsed = getElapsedMs(payload);
  if (typeof elapsed === "number") {
    return `<span>耗时 <strong>${formatMs(elapsed)}</strong></span>`;
  }

  if (payload?.exception?.hasException || payload?.total?.exception) {
    return `<span class="danger">包含异常信息</span>`;
  }

  return "";
}

function compactPayload(payload) {
  if (!payload || typeof payload !== "object") {
    return payload;
  }
  const copy = { ...payload };
  if (copy.legacyText && copy.legacyText.length > 1000) {
    copy.legacyText = `${copy.legacyText.slice(0, 1000)}\n...`;
  }
  return copy;
}

function getElapsedMs(payload) {
  if (!payload || typeof payload !== "object") {
    return null;
  }
  if (typeof payload.elapsedMs === "number") {
    return payload.elapsedMs;
  }
  if (typeof payload.total?.elapsedMs === "number") {
    return payload.total.elapsedMs;
  }
  return null;
}

function formatEventName(value) {
  return eventNames[value] || value || "-";
}

function formatTime(value) {
  if (!value) {
    return "-";
  }
  const date = new Date(value);
  return Number.isNaN(date.getTime()) ? value : date.toLocaleString();
}

function formatMs(value) {
  if (typeof value !== "number" || Number.isNaN(value)) {
    return "-";
  }
  if (value >= 1000) {
    return `${(value / 1000).toFixed(2)} s`;
  }
  if (value >= 10) {
    return `${value.toFixed(1)} ms`;
  }
  return `${value.toFixed(3)} ms`;
}

function formatBytes(value) {
  if (typeof value !== "number" || value < 0 || Number.isNaN(value)) {
    return "-";
  }
  const units = ["B", "KB", "MB", "GB"];
  let size = value;
  let unit = 0;
  while (size >= 1024 && unit < units.length - 1) {
    size /= 1024;
    unit++;
  }
  return `${size.toFixed(unit === 0 ? 0 : 2)} ${units[unit]}`;
}

function formatPercent(value) {
  if (typeof value !== "number" || Number.isNaN(value)) {
    return "-";
  }
  return `${(value * 100).toFixed(1)}%`;
}

function formatInt(value) {
  if (typeof value !== "number" || Number.isNaN(value)) {
    return "-";
  }
  return String(Math.trunc(value));
}

function translatePlanningName(value) {
  return value || "-";
}

function shortTypeName(value) {
  if (!value) {
    return "-";
  }
  const text = String(value);
  const parts = text.split(".");
  if (parts.length <= 1) {
    return text;
  }
  const last = parts.at(-1);
  const prev = parts.at(-2);
  return prev && last ? `${prev}.${last}` : last || text;
}

function translateStatus(value) {
  if (value === "queued") return "排队中";
  if (value === "complete") return "已完成";
  if (value === "failed") return "失败";
  return value || "未知";
}

function sum(values) {
  return values.reduce((total, value) => total + (typeof value === "number" ? value : 0), 0);
}

function escapeHtml(value) {
  return String(value)
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#039;");
}

function renderOutline() {
  const outline = $("pageOutline");
  if (!outline) {
    return;
  }

  const activeView = document.querySelector(".view.active");
  if (!activeView) {
    outline.innerHTML = "";
    return;
  }

  const headings = [...activeView.querySelectorAll("h2")];
  if (!headings.length) {
    outline.innerHTML = "";
    return;
  }

  outline.innerHTML = `<strong>当前页面</strong>${headings.map((heading, index) => {
    if (!heading.id) {
      heading.id = `${activeView.id}-heading-${index}`;
    }

    return `<a href="#${heading.id}">${escapeHtml(heading.textContent || "-")}</a>`;
  }).join("")}`;
}

function setTheme(theme) {
  const normalized = theme === "light" ? "light" : "dark";
  document.body.dataset.theme = normalized;
  localStorage.setItem("taiwuDiagnosticsTheme", normalized);
  $("themeToggle").textContent = normalized === "light" ? "暗色" : "亮色";
}

document.querySelectorAll(".tab").forEach(button => {
  button.addEventListener("click", () => {
    document.querySelectorAll(".tab").forEach(tab => tab.classList.remove("active"));
    document.querySelectorAll(".view").forEach(view => view.classList.remove("active"));
    button.classList.add("active");
    $(button.dataset.view).classList.add("active");
    renderOutline();
  });
});

$("themeToggle").addEventListener("click", () => {
  setTheme(document.body.dataset.theme === "light" ? "dark" : "light");
});

$("refreshButton").addEventListener("click", () => {
  refresh().catch(showError);
});

$("eventTypeFilter").addEventListener("change", () => {
  refresh().catch(showError);
});

$("eventLimit").addEventListener("change", () => {
  refresh().catch(showError);
});

$("gameLogPattern").addEventListener("change", () => {
  refresh().catch(showError);
});

$("gameLogLimit").addEventListener("change", () => {
  refresh().catch(showError);
});

function showError(error) {
  $("status").textContent = `错误：${error.message}`;
}

setTheme(localStorage.getItem("taiwuDiagnosticsTheme") || "dark");
refresh().catch(showError);
setInterval(() => refresh().catch(showError), 5000);
