using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using HarmonyLib;

if (args.Length < 3)
{
    Console.Error.WriteLine("Usage: BackendCompatibility <game-backend-directory> <zlib-ng-dll> <mod-dll> [<mod-dll> ...]");
    return 2;
}

string backendDirectory = Path.GetFullPath(args[0]);
AssemblyLoadContext.Default.Resolving += (context, name) =>
{
    string path = Path.Combine(backendDirectory, name.Name + ".dll");
    return File.Exists(path) ? context.LoadFromAssemblyPath(path) : null;
};
return Audit(args.Skip(2).Select(Path.GetFullPath).ToArray(), Path.GetFullPath(args[1]));

[MethodImpl(MethodImplOptions.NoInlining)]
static int Audit(string[] paths, string nativeLibrary)
{
    int failures = 0;
    List<Harmony> installed = new();
    try
    {
        foreach (string path in paths)
        {
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            string name = assembly.GetName().Name!;
            Console.WriteLine($"ASSEMBLY {name}: {path}");
            // Enable optional patch groups without initializing plugins, servers, or a game world.
            foreach (Type settings in assembly.GetTypes().Where(t => t.Name.EndsWith("Settings")))
            {
                foreach (FieldInfo field in settings.GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if (field.FieldType == typeof(bool))
                        field.SetValue(null, !field.Name.Contains("Server") && !field.Name.Contains("Snapshot") &&
                            !field.Name.Contains("LogToGameLog") && !field.Name.StartsWith("AutoOpen"));
                }
            }

            int patched = 0;
            int bindings = 0;
            Harmony harmony = new("BackendCompatibility." + name);
            installed.Add(harmony);
            foreach (Type type in assembly.GetTypes().Where(t => !t.ContainsGenericParameters &&
                         (t.Namespace?.EndsWith(".Patches") == true || t.Namespace?.EndsWith(".Runtime") == true)))
            {
                try
                {
                    RuntimeHelpers.RunClassConstructor(type.TypeHandle);
                    foreach (FieldInfo field in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        if (!typeof(MemberInfo).IsAssignableFrom(field.FieldType)) continue;
                        if (field.GetValue(null) == null)
                            throw new InvalidOperationException($"Unresolved reflection binding: {field.Name}");
                        bindings++;
                    }
                    if (type.GetCustomAttribute<HarmonyPatch>() == null) continue;
                    var replacements = harmony.CreateClassProcessor(type).Patch();
                    if (replacements == null || replacements.Count == 0)
                        throw new InvalidOperationException("Patch installed no targets (including Prepare skip)");
                    patched++;
                    Console.WriteLine($"PASS {type.Name}: {replacements.Count} target(s)");
                }
                catch (Exception exception)
                {
                    failures++;
                    Console.WriteLine($"FAIL {type.FullName}: {exception}");
                }
            }
            Console.WriteLine($"SUMMARY {name}: {patched} patch classes, {bindings} reflection bindings, " +
                $"{harmony.GetPatchedMethods().Count()} distinct targets");
            if (name == "TaiwuOptimization")
            {
                try { failures += FunctionalChecks.CheckRelationPrefilter(assembly); }
                catch (Exception exception) { failures++; Console.WriteLine($"FAIL relation regression: {exception}"); }
                try { failures += FunctionalChecks.CheckTargetGroup(assembly, harmony); }
                catch (Exception exception) { failures++; Console.WriteLine($"FAIL target group regression: {exception}"); }
                try { failures += FunctionalChecks.CheckItemActions(assembly); }
                catch (Exception exception) { failures++; Console.WriteLine($"FAIL item action regression: {exception}"); }
                try { FunctionalChecks.CheckTranspilersAndCompression(assembly, nativeLibrary); }
                catch (Exception exception) { failures++; Console.WriteLine($"FAIL IL/compression regression: {exception}"); }
                try { FunctionalChecks.CheckDisabledGraphCache(assembly); }
                catch (Exception exception) { failures++; Console.WriteLine($"FAIL graph settings regression: {exception}"); }
            }
        }
    }
    finally
    {
        foreach (Harmony harmony in installed.AsEnumerable().Reverse()) harmony.UnpatchSelf();
    }
    Console.WriteLine($"RESULT: {failures} failure(s)");
    return failures == 0 ? 0 : 1;
}
