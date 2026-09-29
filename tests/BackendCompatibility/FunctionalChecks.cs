using System.Reflection;
using System.Runtime.CompilerServices;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Common;
using Redzen.Random;
using GameData.ArchiveData;
using GameData.ActionPlanning.MonthlyAI.Node;
using HarmonyLib;
using Character = GameData.Domains.Character.Character;

internal static class FunctionalChecks
{
    private static readonly List<Character> TargetCharacters = new();

    public static int CheckTargetGroup(Assembly mod, Harmony modHarmony)
    {
        Type patch = mod.GetType("TaiwuOptimization.Patches.CharacterPlanningAgentSelectActionTargetGroupPatch", true)!;
        MethodInfo prefix = AccessTools.Method(patch, "Prefix");
        MethodBase target = (MethodBase)AccessTools.Method(patch, "TargetMethod").Invoke(null, null)!;
        var objects = (Dictionary<int, Character>)AccessTools.Field(typeof(CharacterDomain), "_objects")
            .GetValue(DomainManager.Character)!;
        var previousObjects = objects.ToArray();
        var fixture = new Harmony("BackendCompatibility.TargetGroupFixture");
        int failures = 0;
        try
        {
            objects.Clear();
            TargetCharacters.Clear();
            foreach (int id in new[] { 10, 20, 30 })
            {
                var character = CharacterWithId(id);
                TargetCharacters.Add(character);
                objects.Add(id, character);
            }
            fixture.Patch(AccessTools.Method(typeof(CharacterPlanningAgent), "GetCharactersInSelectRange"),
                prefix: new HarmonyMethod(typeof(FunctionalChecks), nameof(GetRangeFixture)));
            fixture.Patch(AccessTools.Method(typeof(CharacterPlanningAgent), "FilterActionTargets"),
                prefix: new HarmonyMethod(typeof(FunctionalChecks), nameof(FilterFixture)));

            foreach (int take in new[] { 0, 1, 3 })
            {
                modHarmony.Unpatch(target, prefix);
                string vanilla = GroupTrace(take);
                modHarmony.CreateClassProcessor(patch).Patch();
                string optimized = GroupTrace(take);
                if (vanilla != optimized)
                {
                    failures++;
                    Console.WriteLine($"FAIL target group take={take}: vanilla={vanilla}; optimized={optimized}");
                }
            }
            Type settings = mod.GetType("TaiwuOptimization.Runtime.TaiwuOptimizationSettings", true)!;
            foreach (string setting in new[] { "AdvanceMonthOptimizationEnabled", "EnableCharacterActionPlanningOptimization" })
            {
                FieldInfo flag = AccessTools.Field(settings, setting);
                flag.SetValue(null, false);
                try
                {
                    foreach (string typeName in new[] { "CharacterPlanningAgentSelectActionTargetPatch", "CharacterPlanningAgentSelectActionTargetGroupPatch" })
                    {
                        Type selectionPatch = mod.GetType("TaiwuOptimization.Patches." + typeName, true)!;
                        MethodInfo selectionPrefix = AccessTools.Method(selectionPatch, "Prefix");
                        MethodBase selectionTarget = (MethodBase)AccessTools.Method(selectionPatch, "TargetMethod").Invoke(null, null)!;
                        modHarmony.Unpatch(selectionTarget, selectionPrefix);
                        if (modHarmony.CreateClassProcessor(selectionPatch).Patch()?.Count != 1)
                            throw new Exception($"{typeName} cannot be installed while {setting} is off");
                        DataContext context = new(0);
                        var parameters = new List<object?> { context.PlanningAgent, context, (Predicate<Character>)(_ => true),
                            EPlanningActionCharacterSelector.RandomTarget };
                        if (typeName.EndsWith("GroupPatch")) parameters.Add(3);
                        parameters.Add(EPlanningActionCharacterSelectRange.SameBlock);
                        parameters.Add(0);
                        parameters.Add(null);
                        if (!(bool)selectionPrefix.Invoke(null, parameters.ToArray())!)
                            throw new Exception($"{typeName} did not fall back while {setting} is off");
                    }
                }
                finally { flag.SetValue(null, true); }
            }
            Console.WriteLine($"CHECK target group: deferred/partial/full enumeration, {failures} differences");
            Console.WriteLine("CHECK selection settings: patches install when disabled and both switches fall back immediately");
        }
        finally
        {
            fixture.UnpatchSelf();
            objects.Clear();
            foreach (var pair in previousObjects) objects.Add(pair.Key, pair.Value);
            TargetCharacters.Clear();
        }
        return failures;
    }

    public static int CheckItemActions(Assembly mod)
    {
        Type prefilter = mod.GetType("TaiwuOptimization.Runtime.OfflineUpdateCurrentGoalActionsItemHolderPrefilter", true)!;
        MethodInfo detox = AccessTools.Method(prefilter, "IsSupportedDetoxMedicineDemandAction");
        MethodInfo items = AccessTools.Method(prefilter, "IsSupportedItemDemandAction");
        var cases = new[]
        {
            (27, "WealthDemandAddPoisonToItemAction", EPlanningActionCharacterSelector.RequestTarget, false, false),
            (166, "RequestDetoxPoisonItemAction", EPlanningActionCharacterSelector.RequestTarget, true, false),
            (900, "RequestDetoxPoisonItemAction", EPlanningActionCharacterSelector.RequestTarget, true, false),
            (166, "RequestDetoxPoisonAction", EPlanningActionCharacterSelector.RequestTarget, false, false),
            (36, "WealthDemandRequestItemAction", EPlanningActionCharacterSelector.RequestTarget, false, true),
            (37, "WealthDemandStealItemAction", EPlanningActionCharacterSelector.StealTarget, false, true),
            (38, "WealthDemandScamItemAction", EPlanningActionCharacterSelector.ScamTarget, false, true),
            (39, "WealthDemandRobItemAction", EPlanningActionCharacterSelector.RobTarget, false, true),
            (36, "UnrelatedAction", EPlanningActionCharacterSelector.RequestTarget, false, false),
            (900, "WealthDemandRequestItemAction", EPlanningActionCharacterSelector.RequestTarget, false, true),
            (36, "WealthDemandRequestItemAction", EPlanningActionCharacterSelector.RobTarget, false, false),
        };
        int failures = 0;
        foreach (var (id, implementation, selector, expectedDetox, expectedItem) in cases)
        {
            var template = new PlanningActionItem();
            AccessTools.Field(typeof(PlanningActionItem), "TemplateId").SetValue(template, id);
            AccessTools.Field(typeof(PlanningActionItem), "ImplementationPath").SetValue(template, implementation);
            AccessTools.Field(typeof(PlanningActionItem), "CharacterSelector").SetValue(template, selector);
            if ((bool)detox.Invoke(null, new object[] { template })! != expectedDetox ||
                (bool)items.Invoke(null, new object[] { template })! != expectedItem)
            {
                failures++;
                Console.WriteLine($"FAIL item action A{id} {implementation}/{selector}");
            }
        }
        Console.WriteLine($"CHECK item action identity: {cases.Length} cases, {failures} differences");
        return failures;
    }

    public static void CheckTranspilersAndCompression(Assembly mod, string nativeLibrary)
    {
        MethodInfo copyBuffer = AccessTools.Method(mod.GetType("TaiwuOptimization.Runtime.SaveWorldParallelCompression", true),
            "GetDatabaseCopyBufferBytes");
        foreach (string method in new[] { "CopyFrom", "CopyTo" })
        {
            var instructions = PatchProcessor.GetCurrentInstructions(AccessTools.Method(typeof(ArchiveFileBase), method));
            if (instructions.Count(i => i.Calls(copyBuffer)) != 1)
                throw new Exception($"{method}: expected exactly one copy-buffer replacement");
        }
        MethodInfo matcher = AccessTools.Method(mod.GetType("TaiwuOptimization.Runtime.OfflineUpdateCurrentGoalActionsMatcherCache", true), "Match");
        var matcherInstructions = PatchProcessor.GetCurrentInstructions(AccessTools.Method(typeof(PlanningActionNode), "MatchTargetCharacter"));
        if (matcherInstructions.Count(i => i.Calls(matcher)) != 1)
            throw new Exception("Expected exactly one matcher-cache replacement");
        Console.WriteLine("CHECK transpilers: CopyFrom/CopyTo/matcher replacement sites = 1/1/1");
        AccessTools.Method(mod.GetType("TaiwuOptimization.Runtime.NativeZlibNg", true), "InitializeLibrary")
            .Invoke(null, new object[] { nativeLibrary });
        Console.WriteLine("CHECK parallel DEFLATE: empty/multiple blocks/flush pass current game decompressor");
    }

    public static void CheckDisabledGraphCache(Assembly mod)
    {
        Type settings = mod.GetType("TaiwuOptimization.Runtime.TaiwuOptimizationSettings", true)!;
        Type graph = mod.GetType("TaiwuOptimization.Runtime.CharacterActionPlannerGraphCache", true)!;
        FieldInfo enabled = AccessTools.Field(settings, "AdvanceMonthOptimizationEnabled");
        enabled.SetValue(null, false);
        try
        {
            AccessTools.Method(graph, "Reset").Invoke(null, null);
            AccessTools.Method(graph, "WarmUp").Invoke(null, new object[] { CharacterActionPlanner.Instance });
            object stats = AccessTools.Method(graph, "GetBuildStats").Invoke(null, null)!;
            if ((int)AccessTools.Field(stats.GetType(), "BuildCalls").GetValue(stats)! != 0)
                throw new Exception("Graph warm-up ran while master switch was off");
            object?[] lookupArgs = { CharacterActionPlanner.Instance, new StateCondition<StateKey>(new StateKey(302), 1), null };
            if ((bool)AccessTools.Method(graph, "TryGetConditionConnectedActions").Invoke(null, lookupArgs)!)
                throw new Exception("Graph lookup did not fall back while master switch was off");
            Console.WriteLine("CHECK graph settings: master switch disables warm-up and cache lookup");
        }
        finally { enabled.SetValue(null, true); }
    }

    private static string GroupTrace(int take)
    {
        DataContext context = new(0) { Random = RandomDefaults.CreateRandomSource(12345) };
        CharacterPlanningAgent agent = context.PlanningAgent;
        IEnumerable<Character> selected = agent.SelectActionTargetGroup(context, _ => true,
            EPlanningActionCharacterSelector.RandomTarget, 3, EPlanningActionCharacterSelectRange.SameBlock, 0);
        var trace = new List<string> { context.Random.NextULong().ToString() };
        using IEnumerator<Character> enumerator = selected.GetEnumerator();
        for (int i = 0; i < take && enumerator.MoveNext(); i++)
        {
            trace.Add(enumerator.Current.GetId().ToString());
            trace.Add(context.Random.NextULong().ToString());
        }
        return string.Join(",", trace);
    }

    private static bool GetRangeFixture(ref IReadOnlyList<Character> __result)
    {
        __result = TargetCharacters;
        return false;
    }

    private static bool FilterFixture(ICollection<int> result)
    {
        foreach (Character character in TargetCharacters) result.Add(character.GetId());
        return false;
    }

    public static int CheckRelationPrefilter(Assembly mod)
    {
        // In-memory fixtures only. No world, save, database, or plugin initialization.
        const int actorId = 1;
        Type prefilter = mod.GetType("TaiwuOptimization.Runtime.OfflineUpdateCurrentGoalActionsTargetPrefilter", true)!;
        Type builderType = prefilter.GetNestedType("ActorRelationCandidateBuilder", BindingFlags.NonPublic)!;
        object builder = Activator.CreateInstance(builderType, actorId)!;
        var direct = (HashSet<int>?[])AccessTools.Field(builderType, "_directRelationSets").GetValue(builder)!;
        var reversed = (HashSet<int>?[])AccessTools.Field(builderType, "_reversedRelationSets").GetValue(builder)!;
        var relations = (Dictionary<RelationKey, RelatedCharacter>)AccessTools.Field(typeof(CharacterDomain), "_relations")
            .GetValue(DomainManager.Character)!;
        FieldInfo dataField = AccessTools.Field(typeof(PlanningState), "_dataArray");
        object? previousData = dataField.GetValue(PlanningState.Instance);
        var previousRelations = relations.ToArray();
        int[] states = { 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313 };
        int failures = 0;
        try
        {
            relations.Clear();
            var stateData = Enumerable.Range(0, 314).Select(id => new PlanningStateItem(
                id, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0)).ToList();
            dataField.SetValue(PlanningState.Instance, stateData);
            for (int bit = 0; bit < 16; bit++)
            {
                ushort mask = (ushort)(1 << bit);
                direct[bit] = new HashSet<int> { 100 + bit };
                reversed[bit] = new HashSet<int> { 200 + bit };
                relations[new RelationKey(actorId, 100 + bit)] = new RelatedCharacter(mask, 0, 0);
                relations[new RelationKey(200 + bit, actorId)] = new RelatedCharacter(mask, 0, 0);
            }
            direct[14]!.Add(300);
            reversed[14]!.Add(300);
            relations[new RelationKey(actorId, 300)] = new RelatedCharacter(16384, 0, 0);
            relations[new RelationKey(300, actorId)] = new RelatedCharacter(16384, 0, 0);
            Character actor = CharacterWithId(actorId);
            CharacterPlanningAgent agent = new(CharacterActionPlanner.Instance);
            MethodInfo build = AccessTools.Method(prefilter, "BuildRelationCandidateSet");
            foreach (int state in states)
            {
                var candidates = (HashSet<int>)build.Invoke(null, new[] { builder, (object)state })!;
                var conditions = new[] { new StateConditionAndValue<StateKey>(new StateKey(state), 1) };
                foreach (int id in Enumerable.Range(100, 16).Concat(Enumerable.Range(200, 16)).Append(300).Append(400))
                {
                    bool vanilla = agent.MatchTargetCharacterByConditions(actor, CharacterWithId(id), default, conditions);
                    if (vanilla && !candidates.Contains(id))
                    {
                        failures++;
                        Console.WriteLine($"FAIL relation prefilter S{state}: vanilla accepts candidate {id}, cache excludes it");
                    }
                }
            }
            Console.WriteLine($"CHECK relation prefilter: {states.Length * 34} vanilla comparisons, {failures} false negatives");
        }
        finally
        {
            dataField.SetValue(PlanningState.Instance, previousData);
            relations.Clear();
            foreach (var pair in previousRelations) relations.Add(pair.Key, pair.Value);
        }
        return failures;
    }

    private static Character CharacterWithId(int id)
    {
        var character = (Character)RuntimeHelpers.GetUninitializedObject(typeof(Character));
        AccessTools.Field(typeof(Character), "_id").SetValue(character, id);
        return character;
    }
}
