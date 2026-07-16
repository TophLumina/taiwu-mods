using Taiwu.AdvanceMonthPipeline;
using WorkStealingThreadPool =
    Taiwu.AdvanceMonthPipeline.Threading.WorkStealingThreadPool;

await VerifyThreadPoolResultsAndExceptions();
await VerifyNestedSubmissionsCanBeStolen();
VerifyGracefulThreadPoolDisposal();
VerifySnapshotEvolution();
VerifyWriteConflictStopsCommit();
VerifyComputeFailureStopsCommit();
VerifyWorkerCountDoesNotChangeResult();

Console.WriteLine("所有线程池与阶段快照原型测试均已通过。");

static async Task VerifyThreadPoolResultsAndExceptions()
{
    using var pool = new WorkStealingThreadPool(workerCount: 4);

    Task<int>[] tasks = Enumerable
        .Range(0, 1_000)
        .Select(value => pool.Submit(() => value * value))
        .ToArray();

    int[] results = await Task.WhenAll(tasks);
    Require(results[123] == 123 * 123, "线程池返回结果损坏。");

    Task failedTask = pool.Submit(
        () => throw new ExpectedTestException("expected"));

    try
    {
        await failedTask;
        throw new InvalidOperationException("线程池丢失了委托异常。");
    }
    catch (ExpectedTestException)
    {
    }

    int resultAfterFailure = await pool.Submit(() => 42);
    Require(resultAfterFailure == 42, "一个委托异常终止了工作线程。");
}

static async Task VerifyNestedSubmissionsCanBeStolen()
{
    using var pool = new WorkStealingThreadPool(workerCount: 4);

    Task<Task<int>[]> producer = pool.Submit(
        () => Enumerable
            .Range(0, 200)
            .Select(_ => pool.Submit(
                () =>
                {
                    Thread.SpinWait(100_000);
                    return Environment.CurrentManagedThreadId;
                }))
            .ToArray());

    int[] workerIds = await Task.WhenAll(await producer);
    Require(
        workerIds.Distinct().Count() > 1,
        "嵌套提交的任务没有被其他工作线程窃取。");
}

static void VerifyGracefulThreadPoolDisposal()
{
    var pool = new WorkStealingThreadPool(workerCount: 2);
    int completedCount = 0;

    Task[] tasks = Enumerable
        .Range(0, 500)
        .Select(_ => pool.Submit(() => Interlocked.Increment(ref completedCount)))
        .ToArray();

    pool.Dispose();

    Require(completedCount == tasks.Length, "释放线程池时遗弃了已排队任务。");
    Require(
        tasks.All(task => task.IsCompletedSuccessfully),
        "线程池释放完成后仍有任务未完成。");

    try
    {
        pool.Submit(() => { });
        throw new InvalidOperationException("已释放的线程池仍接受了新任务。");
    }
    catch (ObjectDisposedException)
    {
    }
}

static void VerifySnapshotEvolution()
{
    const int characterCount = 128;
    PrototypeWorld initialState = CreateWorld(characterCount);
    PrototypeSnapshot initialSnapshot = Project(initialState, version: 0);

    using var pool = new WorkStealingThreadPool(workerCount: 4);
    using var pipeline = new SnapshotPipeline<PrototypeWorld, PrototypeSnapshot>(
        initialState,
        initialSnapshot,
        pool);

    StageRunResult<PrototypeSnapshot> statusResult = pipeline.RunStage(
        CreateStatusStage(worldSeed: 0x12345678UL, month: 37));

    Require(statusResult.SourceVersion == 0, "状态阶段读取了错误版本。");
    Require(statusResult.Snapshot.Version == 1, "状态阶段没有推进快照版本。");
    Require(
        statusResult.EmittedDeltaCount == characterCount * 2,
        "状态阶段产生了错误数量的 Delta。");
    Require(
        statusResult.AppliedDeltaCount == characterCount + 1,
        "可交换的共享资源 Delta 没有被合并。");
    Require(
        statusResult.Snapshot.SharedResource == characterCount,
        "合并后的共享资源 Delta 结果错误。");

    foreach (CharacterProjection original in initialSnapshot.Characters)
    {
        Require(
            original.Happiness == original.Id,
            "阶段提交反向修改了旧快照。");
    }

    StageRunResult<PrototypeSnapshot> planningResult = pipeline.RunStage(
        CreatePlanningStage());

    Require(planningResult.SourceVersion == 1, "规划阶段没有读取状态阶段的结果。");
    Require(planningResult.Snapshot.Version == 2, "规划阶段没有推进快照版本。");
    Require(
        planningResult.ExecutedCommandCount == characterCount,
        "规划阶段没有执行全部领域命令。");

    for (int id = 0; id < characterCount; id++)
    {
        CharacterProjection afterStatus = statusResult.Snapshot.GetCharacter(id);
        CharacterProjection afterPlanning = planningResult.Snapshot.GetCharacter(id);
        Require(
            afterPlanning.Plan == $"行动-{afterStatus.Happiness}",
            "规划阶段没有使用上一阶段的新快照。");
        Require(
            afterPlanning.Health == afterStatus.Health + 1,
            "领域命令没有在字段 Delta 之后执行。");
    }

    Require(
        pipeline.CurrentState.ExecutedCharacterIds.SequenceEqual(
            Enumerable.Range(0, characterCount)),
        "领域命令没有按稳定实体键提交。");

    Require(
        planningResult.Events.Count == characterCount * 2,
        "计算阶段或提交阶段产生的事件没有进入发件箱。");
    for (int id = 0; id < characterCount; id++)
    {
        Require(
            planningResult.Events[id * 2] is ActionExecutedEvent executed &&
            executed.CharacterId == id,
            "提交阶段事件顺序不稳定。");
        Require(
            planningResult.Events[id * 2 + 1] is PlanCreatedEvent planned &&
            planned.CharacterId == id,
            "计算阶段事件顺序不稳定。");
    }
}

static void VerifyWriteConflictStopsCommit()
{
    PrototypeWorld initialState = CreateWorld(characterCount: 1);
    PrototypeSnapshot initialSnapshot = Project(initialState, version: 0);

    using var pool = new WorkStealingThreadPool(workerCount: 2);
    using var pipeline = new SnapshotPipeline<PrototypeWorld, PrototypeSnapshot>(
        initialState,
        initialSnapshot,
        pool);

    var conflictingStage = new SnapshotStage<
        PrototypeWorld,
        PrototypeSnapshot,
        int,
        EmptyScratch>(
        "冲突检测",
        _ => [10, 20],
        _ => new EmptyScratch(),
        (context, value) => context.EmitDelta(
            new StageOrderKey(EntityId: 0, Sequence: value),
            new SetHappinessDelta(CharacterId: 0, Value: value)),
        Project,
        state => state.Clone());

    try
    {
        pipeline.RunStage(conflictingStage);
        throw new InvalidOperationException("阶段没有报告不可合并的字段写冲突。");
    }
    catch (StageWriteConflictException exception)
    {
        Require(
            exception.MutationKey == CharacterMutationKeys.Happiness(0),
            "写冲突报告了错误的字段键。");
    }

    Require(pipeline.CurrentSnapshot.Version == 0, "冲突阶段错误地推进了版本。");
    Require(
        pipeline.CurrentState.Characters[0].Happiness == 0,
        "冲突阶段修改了当前世界状态。");
}

static void VerifyComputeFailureStopsCommit()
{
    PrototypeWorld initialState = CreateWorld(characterCount: 8);
    PrototypeSnapshot initialSnapshot = Project(initialState, version: 0);

    using var pool = new WorkStealingThreadPool(workerCount: 4);
    using var pipeline = new SnapshotPipeline<PrototypeWorld, PrototypeSnapshot>(
        initialState,
        initialSnapshot,
        pool);

    var failedStage = new SnapshotStage<
        PrototypeWorld,
        PrototypeSnapshot,
        CharacterProjection,
        EmptyScratch>(
        "计算失败",
        snapshot => snapshot.Characters,
        _ => new EmptyScratch(),
        (context, character) =>
        {
            if (character.Id == 3)
            {
                throw new ExpectedTestException("阶段计算失败");
            }

            context.EmitDelta(
                new StageOrderKey(character.Id, 0),
                new SetHappinessDelta(character.Id, 999));
        },
        Project,
        state => state.Clone());

    try
    {
        pipeline.RunStage(failedStage);
        throw new InvalidOperationException("阶段计算异常被吞掉了。");
    }
    catch (ExpectedTestException)
    {
    }

    Require(pipeline.CurrentSnapshot.Version == 0, "失败阶段错误地推进了版本。");
    Require(
        pipeline.CurrentState.Characters.Values.All(
            character => character.Happiness == character.Id),
        "失败阶段在提交之前修改了世界状态。");
}

static void VerifyWorkerCountDoesNotChangeResult()
{
    string singleWorker = RunPrototypeAndCreateSignature(workerCount: 1);
    string fourWorkers = RunPrototypeAndCreateSignature(workerCount: 4);
    Require(
        singleWorker == fourWorkers,
        "工作线程数量改变了快照、命令或事件的最终结果。");
}

static string RunPrototypeAndCreateSignature(int workerCount)
{
    PrototypeWorld state = CreateWorld(characterCount: 64);
    PrototypeSnapshot snapshot = Project(state, version: 0);

    using var pool = new WorkStealingThreadPool(workerCount);
    using var pipeline = new SnapshotPipeline<PrototypeWorld, PrototypeSnapshot>(
        state,
        snapshot,
        pool);

    pipeline.RunStage(CreateStatusStage(worldSeed: 987654321UL, month: 12));
    StageRunResult<PrototypeSnapshot> planning = pipeline.RunStage(CreatePlanningStage());

    string characters = string.Join(
        ';',
        planning.Snapshot.Characters.Select(
            character =>
                $"{character.Id},{character.Happiness},{character.Health},{character.Plan}"));
    string commands = string.Join(',', pipeline.CurrentState.ExecutedCharacterIds);
    string events = string.Join(
        ',',
        planning.Events.Select(stageEvent => stageEvent switch
        {
            ActionExecutedEvent action => $"E{action.CharacterId}",
            PlanCreatedEvent plan => $"P{plan.CharacterId}",
            _ => throw new InvalidOperationException("出现了未知测试事件。")
        }));

    return $"{planning.Snapshot.Version}|{planning.Snapshot.SharedResource}|" +
        $"{characters}|{commands}|{events}";
}

static SnapshotStage<
    PrototypeWorld,
    PrototypeSnapshot,
    CharacterProjection,
    StatusScratch> CreateStatusStage(ulong worldSeed, long month)
{
    return new SnapshotStage<
        PrototypeWorld,
        PrototypeSnapshot,
        CharacterProjection,
        StatusScratch>(
        "角色状态更新",
        snapshot => snapshot.Characters,
        _ => new StatusScratch(),
        (context, character) =>
        {
            context.Scratch.VisitedCharacterIds.Add(character.Id);
            var random = new DeterministicRandom(
                DeterministicRandom.DeriveSeed(
                    worldSeed,
                    month,
                    stageId: 1,
                    entityId: character.Id));
            int happiness = character.Happiness + random.NextInt32(1, 11);

            context.EmitDelta(
                new StageOrderKey(character.Id, 0),
                new SetHappinessDelta(character.Id, happiness));
            context.EmitDelta(
                new StageOrderKey(character.Id, 1),
                new AddSharedResourceDelta(1));
        },
        Project,
        state => state.Clone());
}

static SnapshotStage<
    PrototypeWorld,
    PrototypeSnapshot,
    CharacterProjection,
    PlanningScratch> CreatePlanningStage()
{
    return new SnapshotStage<
        PrototypeWorld,
        PrototypeSnapshot,
        CharacterProjection,
        PlanningScratch>(
        "NPC 行动规划与执行",
        snapshot => snapshot.Characters,
        _ => new PlanningScratch(),
        (context, character) =>
        {
            string plan = $"行动-{character.Happiness}";
            context.Scratch.TargetIds.Add(character.Id);

            context.EmitDelta(
                new StageOrderKey(character.Id, 0),
                new SetPlanDelta(character.Id, plan));
            context.EmitCommand(
                new StageOrderKey(character.Id, 1),
                new ExecutePlanCommand(character.Id, plan));
            context.EmitEvent(
                new StageOrderKey(character.Id, 3),
                new PlanCreatedEvent(character.Id, context.Snapshot.Version));
        },
        Project,
        state => state.Clone());
}

static PrototypeWorld CreateWorld(int characterCount)
{
    var world = new PrototypeWorld();
    for (int id = 0; id < characterCount; id++)
    {
        world.Characters.Add(
            id,
            new PrototypeCharacter
            {
                Id = id,
                Happiness = id,
                Health = 100
            });
    }

    return world;
}

static PrototypeSnapshot Project(PrototypeWorld state, long version)
{
    CharacterProjection[] characters = state.Characters.Values
        .Select(character => new CharacterProjection(
            character.Id,
            character.Happiness,
            character.Health,
            character.Plan))
        .ToArray();
    return new PrototypeSnapshot(version, state.SharedResource, characters);
}

static void Require(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

file sealed class PrototypeWorld
{
    public SortedDictionary<int, PrototypeCharacter> Characters { get; } = [];

    public int SharedResource { get; set; }

    public List<int> ExecutedCharacterIds { get; } = [];

    public PrototypeWorld Clone()
    {
        var clone = new PrototypeWorld
        {
            SharedResource = SharedResource
        };

        foreach ((int id, PrototypeCharacter character) in Characters)
        {
            clone.Characters.Add(id, character.Clone());
        }

        clone.ExecutedCharacterIds.AddRange(ExecutedCharacterIds);
        return clone;
    }
}

file sealed class PrototypeCharacter
{
    public required int Id { get; init; }

    public int Happiness { get; set; }

    public int Health { get; set; }

    public string? Plan { get; set; }

    public PrototypeCharacter Clone()
    {
        return new PrototypeCharacter
        {
            Id = Id,
            Happiness = Happiness,
            Health = Health,
            Plan = Plan
        };
    }
}

file sealed record CharacterProjection(
    int Id,
    int Happiness,
    int Health,
    string? Plan);

file sealed record PrototypeSnapshot(
    long Version,
    int SharedResource,
    IReadOnlyList<CharacterProjection> Characters) : IVersionedSnapshot
{
    public CharacterProjection GetCharacter(int id)
    {
        CharacterProjection character = Characters[id];
        if (character.Id != id)
        {
            throw new InvalidOperationException("测试快照的角色索引不连续。");
        }

        return character;
    }
}

file static class CharacterMutationKeys
{
    public static StageMutationKey Happiness(int characterId) =>
        new("Character", characterId, "Happiness");

    public static StageMutationKey Plan(int characterId) =>
        new("Character", characterId, "Plan");

    public static StageMutationKey SharedResource { get; } =
        new("World", 0, "SharedResource");
}

file sealed record SetHappinessDelta(
    int CharacterId,
    int Value) : IStageDelta<PrototypeWorld>
{
    public StageMutationKey MutationKey =>
        CharacterMutationKeys.Happiness(CharacterId);

    public bool TryMerge(
        IStageDelta<PrototypeWorld> later,
        out IStageDelta<PrototypeWorld>? merged)
    {
        if (later is SetHappinessDelta other && other.Value == Value)
        {
            merged = this;
            return true;
        }

        merged = null;
        return false;
    }

    public PrototypeWorld Apply(
        PrototypeWorld state,
        StageCommitContext context)
    {
        state.Characters[CharacterId].Happiness = Value;
        return state;
    }
}

file sealed record AddSharedResourceDelta(
    int Amount) : IStageDelta<PrototypeWorld>
{
    public StageMutationKey MutationKey => CharacterMutationKeys.SharedResource;

    public bool TryMerge(
        IStageDelta<PrototypeWorld> later,
        out IStageDelta<PrototypeWorld>? merged)
    {
        if (later is AddSharedResourceDelta other)
        {
            merged = new AddSharedResourceDelta(checked(Amount + other.Amount));
            return true;
        }

        merged = null;
        return false;
    }

    public PrototypeWorld Apply(
        PrototypeWorld state,
        StageCommitContext context)
    {
        state.SharedResource = checked(state.SharedResource + Amount);
        return state;
    }
}

file sealed record SetPlanDelta(
    int CharacterId,
    string Plan) : IStageDelta<PrototypeWorld>
{
    public StageMutationKey MutationKey => CharacterMutationKeys.Plan(CharacterId);

    public bool TryMerge(
        IStageDelta<PrototypeWorld> later,
        out IStageDelta<PrototypeWorld>? merged)
    {
        if (later is SetPlanDelta other && other.Plan == Plan)
        {
            merged = this;
            return true;
        }

        merged = null;
        return false;
    }

    public PrototypeWorld Apply(
        PrototypeWorld state,
        StageCommitContext context)
    {
        state.Characters[CharacterId].Plan = Plan;
        return state;
    }
}

file sealed record ExecutePlanCommand(
    int CharacterId,
    string ExpectedPlan) : IStageCommand<PrototypeWorld>
{
    public PrototypeWorld Execute(
        PrototypeWorld state,
        StageCommitContext context)
    {
        PrototypeCharacter character = state.Characters[CharacterId];
        if (character.Plan != ExpectedPlan)
        {
            throw new InvalidOperationException("行动命令没有看到先前提交的规划 Delta。");
        }

        character.Health++;
        state.ExecutedCharacterIds.Add(CharacterId);
        context.EmitEvent(
            new StageOrderKey(CharacterId, 2),
            new ActionExecutedEvent(CharacterId, context.TargetVersion));
        return state;
    }
}

file sealed record PlanCreatedEvent(
    int CharacterId,
    long SourceVersion) : IStageEvent;

file sealed record ActionExecutedEvent(
    int CharacterId,
    long TargetVersion) : IStageEvent;

file sealed class StatusScratch : IDisposable
{
    public List<int> VisitedCharacterIds { get; } = [];

    public void Dispose()
    {
        VisitedCharacterIds.Clear();
    }
}

file sealed class PlanningScratch : IDisposable
{
    public List<int> TargetIds { get; } = [];

    public void Dispose()
    {
        TargetIds.Clear();
    }
}

file sealed class EmptyScratch;

file sealed class ExpectedTestException(string message) : Exception(message);
