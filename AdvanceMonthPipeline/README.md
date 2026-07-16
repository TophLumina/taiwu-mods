# Taiwu.AdvanceMonthPipeline

这是一个面向过月逻辑迁移的 .NET 10 阶段快照演进原型。项目不依赖游戏程序集，先用独立类型验证并行计算与串行提交的边界，之后再由游戏侧适配器连接 `Character`、`DomainManager` 和事件系统。

现有工作窃取线程池仍作为内部调度组件使用；项目的主要抽象已经从“提交任意任务”提升为：

```text
只读 Snapshot
  → 并行计算
  → 类型化 Delta / Command / Event Outbox
  → 屏障
  → 冲突检测与确定性合并
  → 提交候选状态
  → 下一版本 Snapshot
```

## 主要类型

- `WorkStealingThreadPool`：固定工作线程、工作窃取和异常传播。
- `IVersionedSnapshot`：标识已经提交的只读世界投影。
- `SnapshotStage`：定义工作项、阶段 Scratch、并行计算和下一快照投影。
- `StageWorkerContext`：只暴露 Snapshot、Scratch 和类型化输出，不暴露可变世界。
- `IStageDelta<TState>`：字段或组件修改；相同 `StageMutationKey` 必须合并或报告冲突。
- `IStageCommand<TState>`：关系、移动、创建实体、行动执行等语义操作。
- `IStageEvent`：提交成功后由调用方发布的事件和通知。
- `SnapshotPipeline`：执行屏障、合并、提交和版本推进。
- `DeterministicRandom`：按世界种子、月份、阶段和实体派生随机流，避免结果依赖 Worker 调度。

`ThreadPool.h/.cpp` 仅作为目录内保留的参考资料，不参与 C# 项目编译。

## 最小阶段示例

```csharp
var stage = new SnapshotStage<WorldState, MonthSnapshot, NpcView, PlanningScratch>(
    name: "NPC 行动规划",
    selectWorkItems: snapshot => snapshot.Characters,
    createScratch: _ => new PlanningScratch(),
    execute: (context, npc) =>
    {
        NpcPlanningDelta delta = Plan(context.Snapshot, context.Scratch, npc);
        context.EmitDelta(
            new StageOrderKey(npc.Id, 0),
            delta);
    },
    projectSnapshot: ProjectMonthSnapshot,
    prepareCommit: state => state.CreateCommitDraft());

StageRunResult<MonthSnapshot> result = pipeline.RunStage(stage);
Publish(result.Events);
```

阶段工作函数只能通过 `context.Snapshot` 读取状态。同阶段产生的 Delta 对其他任务不可见；它们只会在屏障后被应用，并出现在下一版本快照中。

## 提交语义

### 字段和组件 Delta

每个 Delta 提供 `StageMutationKey`。同一阶段中的相同键：

- 加法、集合并集等操作可由 `TryMerge` 合并。
- 两个不相容的 Set 操作会抛出 `StageWriteConflictException`。
- 合并后的 Delta 按 `StageOrderKey` 和修改键稳定排序。

### 领域 Command

Delta 全部应用后才执行 Command。Command 用于无法安全表示为字段赋值的操作，例如 NPC 行动执行、关系变化和实体创建。Command 的 `StageOrderKey` 在阶段内必须唯一，防止提交顺序重新依赖任务调度。

### 事件 Outbox

并行计算和提交命令都可以产生事件。事件在阶段状态和新快照构造成功后通过 `StageRunResult.Events` 返回，项目本身不会直接调用游戏事件系统。

### 提交候选状态

`prepareCommit` 决定提交写入哪里：

- 原型测试通过克隆状态建立 Commit Draft；提交失败不会污染当前状态。
- 实际迁移初期可以传入原状态以调用旧 Domain API，但必须保证提交过程不会失败。
- 后续可将角色规划组件、关系表等逐步改为写时复制或双缓冲。

## 当前原型验证内容

测试程序验证：

- 工作窃取、嵌套提交、异常传播和安全释放。
- 旧快照不会被阶段提交反向修改。
- 下一阶段能读取上一阶段提交后的新快照。
- 可交换 Delta 会被合并，不相容字段写入会阻止提交。
- Delta 先于领域 Command 应用。
- 计算阶段和提交阶段事件统一进入 Outbox。
- 并行计算异常不会推进世界版本。
- 使用 1 个或 4 个 Worker 得到完全相同的状态、命令顺序和事件顺序。

## 构建与运行

```powershell
dotnet build .\Taiwu.AdvanceMonthPipeline.csproj -c Release
dotnet run --project .\tests\Taiwu.AdvanceMonthPipeline.SmokeTests\Taiwu.AdvanceMonthPipeline.SmokeTests.csproj -c Release
```

## 与实际过月迁移的建议边界

第一批适配可以保留原版串行提交逻辑，只替换并行计算侧：

1. 将 `CharacterPlanningAgent`、目标列表等移入 `PlanningScratch`。
2. 将 NPC 状态和规划所需字段投影为阶段 Snapshot。
3. 将角色私有字段修改转换为类型化 Delta。
4. 将 `Complement...` 暂时封装成 Command，在提交阶段串行调用。
5. 当某一阶段不再访问 `ParallelModificationsRecorder` 后，删除该阶段的 Recorder 适配。

实际接入时应首先保持原版每次 `WorkerThreadManager.Run/ApplyAll` 的阶段边界，完成阶段状态哈希对比后再考虑合并相邻阶段。
