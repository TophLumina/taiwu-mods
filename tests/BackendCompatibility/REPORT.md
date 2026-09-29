# 后端同步后的功能与注入点验证

验证日期：2026-09-30。反编译基线：`904721e`（`decompile updates`）。

## 结论

当前后端的注入点仍然有效，但优化逻辑存在需要修复的问题。本次已修复关系方向、物品行动识别、群体目标随机流，以及目标选择/规划图缓存的设置开关行为。

验证覆盖 `TaiwuOptimzation` 和 `TaiwuDiagnostics`。`AdvanceMonthPipeline` 是独立原型，当前 mod 项目未引用它，不能把其测试通过理解为已经接管游戏过月流程。

## 已修复的问题

| 问题 | 影响及证据 | 修复 |
| --- | --- | --- |
| 关系预过滤方向反了 | 原版 `CharacterPlanningAgent.MatchTargetCharacterByConditions` 调用 `TargetStateSensor.Sense(args, targetChar, selfChar, key)`。候选人是 sensor 的 self，行动者是 target。旧表直接套用 sensor 内部方向，导致 S302、S303、S305–S311、S313 丢失合法候选。408 次原版对照出现 19 次漏选。 | 反转这些单向关系的查表方向；对称关系 S304/S312 保留。修复后 408 次对照零漏选。 |
| 把 A27 当作索取解毒药 | 当前 `PlanningAction` 的 A27 是 `WealthDemandAddPoisonToItemAction`，A166 才是 `RequestDetoxPoisonItemAction`。两者均使用 RequestTarget 和毒素参数，旧过滤器可能误排除不持有解毒药的淬毒目标，同时没有加速真正的索取解毒药。 | 根据实现名称及对应 selector 识别，财富类四种物品行动也同步加上实现检查；不再仅凭数字编号判断。11 组识别回归通过。 |
| 群体目标选择提前消耗随机数 | 原版 iterator 在 MoveNext 时逐个抽取；旧 Prefix 在返回 IEnumerable 前生成全部目标。未遍历、部分遍历、穿插其他随机调用的完整遍历都出现随机流/目标偏差。 | 每个枚举器独占池化列表并逐个 yield；finally 处理提前结束或异常时的归还。三个对照场景全部一致。 |
| 部分优化没有正确响应设置 | 目标选择用 Prepare 只在安装时判断开关，初始关闭后不能直接开启，初始开启后关闭仍替换原版。规划图缓存未检查总开关。 | 目标选择始终挂载，在 Prefix 中读取当前设置；图缓存预热及查找同时检查总开关和分项开关。已验证关闭状态安装与回退。 |

这些是此次审查确认的现存问题，不能仅凭同步提交断定它们全部由本次游戏更新引入。

## 注入点检查结果

测试在独立 .NET 8 x64 进程中加载本机当前游戏 DLL，开启可选采样补丁后逐类执行 Harmony 安装；两个 mod 保持同时挂载。默认关闭的采样组也纳入覆盖，以下数量不等于默认设置下必定启用的数量。

| 模块 | 补丁类 | 独立目标方法 | 额外反射成员检查 | 结果 |
| --- | ---: | ---: | ---: | --- |
| TaiwuOptimization | 102 | 112 | 13 | 全部通过 |
| TaiwuDiagnostics | 39 | 102 | 1 | 全部通过 |

字段引用委托的静态初始化也通过。三个 transpiler 的实际指令替换均验证命中一次：

- `ArchiveFileBase.CopyFrom`：4096 字节常量替换为配置缓冲区 getter。
- `ArchiveFileBase.CopyTo`：同上。
- `PlanningActionNode.MatchTargetCharacter`：目标 matcher 调用替换为缓存入口。

## 功能与调用链核对

| 功能 | 当前后端结论 | 验证程度 |
| --- | --- | --- |
| NPC 主/副目标阶段缓存 | `ParallelActionManager.Execute` 仍调用 `WorkerThreadManager.Run`，后者等待 worker 后执行 `ApplyAll`，生命周期补丁仍包围正确边界。 | 源码链路核对、实际安装通过。 |
| 新增移动限制 | 新版高层 `SelectActionTarget(..., bool allowMovement)` 在调用底层选择方法前限制 range；现有补丁挂在仍兼容的底层重载上并原样传递 range。 | 源码链路核对、实际安装通过。 |
| 新版条件比较修复 | 非常量条件的 `!StateConditionHelper.Check(...)` 修正仍由原版执行；预过滤只针对受支持、要求真值的常量布尔条件。 | 源码核对，关系条件另有原版对照回归。 |
| 物品候选预过滤 | A36–A39 对应财富物品行动仍存在；A27/A166 错配已修复。 | 配置与实现核对、11 组回归。 |
| 秘闻持有人计数 | 当前原版已有 secret→holders 索引，并按 occurrence 求去重并集；mod 的传播阶段聚合缓存注入点仍有效。 | 源码与安装检查；不能据此声称有确定性能收益。 |
| 并行存档压缩 | `Save → WriteContent → StartCompression/EndCompression` 链路及 Deflate 算法标记仍兼容。 | 空输入、多块、Flush 后续写入三种情况通过当前游戏解压器，字节一致。 |
| 主菜单读档 VACUUM | `LoadWorld` 仍延迟到下一帧调用 `LocalArchiveFile.Load`；Archive Load 的 finalizer 在正文读取、数据库重新连接及校验结束后执行。 | 源码与安装检查；未实际压缩玩家数据库。 |
| 事件程序集预加载 | `_loadMethod`、`LoadEventPackageAssembly(string)`、`InitConchShipEvents` 均可解析；LoadBuffer 仍为 2，原版仍按 byte[] 加载 DLL/PDB。 | 源码与安装检查；未运行完整游戏冷启动。 |
| 远区行动点削减 | 原版仍经 `OfflineUpdateCurrentGoalActions → UpdateActionPoints` 增加行动点；当前 GlobalConfig 默认增量 40、上限 60 与现有算法一致。 | 源码与安装检查；这是默认关闭的非等价实验功能。 |
| 独立阶段快照原型 | 与两个 mod 的程序集引用分离。 | 现有全部线程池/阶段快照 smoke tests 通过。 |

## 复现与边界

执行 `tests/BackendCompatibility/Run.ps1`，详见同目录 README；完整输出在 `.validation/patch-audit.log`。两个 Release 构建均为 0 警告、0 错误，最终审计为 `RESULT: 0 failure(s)`。

本次未启动游戏、加载玩家存档、执行完整过月，也未做真实存档的存读档及耗时 A/B。实际世界中的缓存命中率、跨阶段增量一致性和性能收益仍需游戏内验证。此报告区分“挂载成功”“局部行为回归通过”和“完整游戏验证”，不将它们视作同一结论。

当前实测二进制 SHA-256：

```text
GameData.dll
B5DBD118929B58A97D709FF8E93E0A6A700675B62590DDDE88FDEEF0FD5800B6
GameData.Shared.dll
150DB620E9256AF4F3981588181D7EE9E6F2B90558B530ACF0973232E1C38663
```
