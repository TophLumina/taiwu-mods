using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Dependencies;
using GameData.Domains.TaiwuEvent;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using TaiwuModdingLib.Core.Plugin;

namespace GameData.Domains.Mod;

[GameDataDomain(16)]
public class ModDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private static readonly List<ModId> LoadedMods = new List<ModId>();

	private static readonly Dictionary<string, ModInfo> ModInfoDict = new Dictionary<string, ModInfo>();

	private static readonly Dictionary<ModId, List<TaiwuRemakePlugin>> LoadedPlugins = new Dictionary<ModId, List<TaiwuRemakePlugin>>();

	private static readonly ModConfigDataManager _modConfigDataManager = new ModConfigDataManager();

	private static HashSet<string> _requiredAssemblies;

	private static readonly Dictionary<string, Action<int>> IntDataHandlers = new Dictionary<string, Action<int>>();

	private static readonly Dictionary<string, Action<bool>> BoolDataHandlers = new Dictionary<string, Action<bool>>();

	private static readonly Dictionary<string, Action<float>> FloatDataHandlers = new Dictionary<string, Action<float>>();

	private static readonly Dictionary<string, Action<string>> StringDataHandlers = new Dictionary<string, Action<string>>();

	private static readonly Dictionary<string, Action<SerializableModData>> SerializableModDataHandlers = new Dictionary<string, Action<SerializableModData>>();

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<ModId, SerializableModData> _archiveModDataDict;

	[DomainData(DomainDataType.SingleValueCollection, false, false, false, false)]
	private readonly Dictionary<ModId, SerializableModData> _nonArchiveModDataDict;

	private static readonly Dictionary<string, Action<DataContext>> ModMethods = new Dictionary<string, Action<DataContext>>();

	private static readonly Dictionary<string, Action<DataContext, SerializableModData>> ModMethodsWithParam = new Dictionary<string, Action<DataContext, SerializableModData>>();

	private static readonly Dictionary<string, Func<DataContext, SerializableModData>> ModMethodsWithRet = new Dictionary<string, Func<DataContext, SerializableModData>>();

	private static readonly Dictionary<string, Func<DataContext, SerializableModData, SerializableModData>> ModMethodsWithParamAndRet = new Dictionary<string, Func<DataContext, SerializableModData, SerializableModData>>();

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[2][];

	private Queue<uint> _pendingLoadingOperationIds;

	public void LoadAllMods(ModInfoList modInfoList)
	{
		UnloadAllMods();
		ModInfoDict.Clear();
		if (modInfoList.Items == null)
		{
			return;
		}
		foreach (ModInfo modInfo in modInfoList.Items)
		{
			ModInfoDict.Add(modInfo.ModId.ToString(), modInfo);
			try
			{
				LoadMod(modInfo);
			}
			catch (Exception ex)
			{
				string path = Path.Combine(GameData.ArchiveData.Common.ArchiveBaseDir, "ModSettings.Lua");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				throw new Exception("Loading - " + modInfo.Title + "\n" + ex);
			}
		}
	}

	private void UnloadAllMods()
	{
		for (int i = LoadedMods.Count - 1; i >= 0; i--)
		{
			UnloadMod(i);
		}
		LoadedPlugins.Clear();
		LoadedMods.Clear();
		ClearDataHandlers();
		ClearModMethods();
	}

	public void LoadAllEventPackages()
	{
		foreach (ModId modId in LoadedMods)
		{
			ModInfo modInfo = ModInfoDict[modId.ToString()];
			string eventsDir = Path.Combine(modInfo.DirectoryName, "Events");
			EventPackagePathInfo pathInfo = new EventPackagePathInfo(eventsDir);
			foreach (string eventPackageName in modInfo.EventPackages)
			{
				Logger.Info(" - Loading events from " + eventPackageName);
				string packageName = Path.GetFileNameWithoutExtension(eventPackageName);
				string dllPath = Path.Combine(pathInfo.DllDirPath, eventPackageName);
				DomainManager.TaiwuEvent.LoadEventPackageFromAssembly(packageName, pathInfo, modId.ToString(), dllPath);
			}
		}
	}

	private void LoadMod(ModInfo modInfo)
	{
		Logger.Info("Start loading mod " + modInfo.Title + " for GameData ...");
		if (LoadedPlugins.ContainsKey(modInfo.ModId))
		{
			throw new Exception($"Mod with FileId {modInfo.ModId} is already loaded.");
		}
		string pluginDir = Path.Combine(modInfo.DirectoryName, "Plugins");
		List<TaiwuRemakePlugin> plugins = new List<TaiwuRemakePlugin>();
		LoadedPlugins.Add(modInfo.ModId, plugins);
		foreach (string pluginPath in modInfo.BackendPlugins)
		{
			Logger.Info(" - Loading plugin from " + pluginPath);
			TaiwuRemakePlugin pluginInstance = PluginHelper.LoadPlugin(pluginDir, pluginPath, modInfo.ModId.ToString());
			pluginInstance.OnModSettingUpdate();
			plugins.Add(pluginInstance);
		}
		_modConfigDataManager.LoadModConfig(modInfo);
		LoadedMods.Add(modInfo.ModId);
	}

	private void UnloadMod(int index)
	{
		ModInfo modInfo = ModInfoDict[LoadedMods[index].ToString()];
		Logger.Info("Start unloading mod " + modInfo.Title + " for GameData ...");
		List<TaiwuRemakePlugin> plugins = LoadedPlugins[modInfo.ModId];
		for (int i = plugins.Count - 1; i >= 0; i--)
		{
			Logger.Info(" - Unloading plugin from " + modInfo.BackendPlugins[i]);
			plugins[i].Dispose();
			plugins.RemoveAt(i);
		}
		LoadedPlugins.Remove(modInfo.ModId);
		LoadedMods.RemoveAt(index);
	}

	public static List<ModId> GetLoadedModIds()
	{
		return LoadedMods.ToList();
	}

	public string GetModDirectory(string modIdStr)
	{
		if (!ModInfoDict.TryGetValue(modIdStr, out var modInfo))
		{
			return string.Empty;
		}
		return modInfo.DirectoryName;
	}

	public string GetModTitle(string modIdStr)
	{
		if (!ModInfoDict.TryGetValue(modIdStr, out var modInfo))
		{
			return string.Empty;
		}
		return modInfo.Title;
	}

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		_archiveModDataDict.Clear();
		_nonArchiveModDataDict.Clear();
		foreach (ModId modId in LoadedMods)
		{
			_archiveModDataDict.Add(modId, new SerializableModData());
			_nonArchiveModDataDict.Add(modId, new SerializableModData());
			List<TaiwuRemakePlugin> plugins = LoadedPlugins[modId];
			foreach (TaiwuRemakePlugin plugin in plugins)
			{
				plugin.OnEnterNewWorld();
			}
		}
	}

	private void OnLoadedArchiveData()
	{
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		foreach (ModId modId in LoadedMods)
		{
			if (!_archiveModDataDict.ContainsKey(modId))
			{
				AddElement_ArchiveModDataDict(modId, new SerializableModData(), context);
			}
			if (!_nonArchiveModDataDict.ContainsKey(modId))
			{
				AddElement_NonArchiveModDataDict(modId, new SerializableModData(), context);
			}
			List<TaiwuRemakePlugin> plugins = LoadedPlugins[modId];
			foreach (TaiwuRemakePlugin plugin in plugins)
			{
				plugin.OnLoadedArchiveData();
			}
		}
	}

	public static Assembly ResolveTaiwuModdingLibPath(object sender, ResolveEventArgs args)
	{
		AssemblyName assemblyName = new AssemblyName(args.Name);
		Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly loadedAssembly = loadedAssemblies.FirstOrDefault((Assembly assembly2) => assemblyName.FullName == assembly2.FullName);
		if (loadedAssembly != null)
		{
			return loadedAssembly;
		}
		if (_requiredAssemblies == null)
		{
			_requiredAssemblies = new HashSet<string> { "Mono.Cecil", "Mono.Cecil.Mdb", "Mono.Cecil.Pdb", "Mono.Cecil.Rocks", "MonoMod.RuntimeDetour", "MonoMod.Utils", "Newtonsoft.Json", "Steamworks.NET" };
		}
		if (!_requiredAssemblies.Contains(assemblyName.Name))
		{
			return null;
		}
		string path = Path.Combine(Program.BaseDataDir, "The Scroll of Taiwu_Data\\Managed\\" + assemblyName.Name + ".dll");
		if (!File.Exists(path))
		{
			Logger.Warn("Failed to resolve assembly because no such file can be found: " + path + ".");
			return null;
		}
		Assembly assembly = Assembly.LoadFile(path);
		AssemblyName loadedAssemblyName = assembly.GetName();
		if (loadedAssemblyName.Name != assemblyName.Name)
		{
			throw new Exception($"Unexpected assembly name info: looking for {assemblyName.Name} => {loadedAssemblyName.Name} loaded.");
		}
		if (loadedAssemblyName.FullName != assemblyName.FullName)
		{
			Logger.Warn($"Unexpected assembly Fullname info: looking for {assemblyName.FullName} => {loadedAssemblyName.FullName} loaded.");
		}
		return assembly;
	}

	private void ClearDataHandlers()
	{
		IntDataHandlers.Clear();
		BoolDataHandlers.Clear();
		FloatDataHandlers.Clear();
		StringDataHandlers.Clear();
		SerializableModDataHandlers.Clear();
	}

	public void AddOnReceiveDataHandler(string modIdStr, string dataName, Action<int> handler)
	{
		IntDataHandlers.Add(modIdStr + "." + dataName, handler);
	}

	public void AddOnReceiveDataHandler(string modIdStr, string dataName, Action<bool> handler)
	{
		BoolDataHandlers.Add(modIdStr + "." + dataName, handler);
	}

	public void AddOnReceiveDataHandler(string modIdStr, string dataName, Action<float> handler)
	{
		FloatDataHandlers.Add(modIdStr + "." + dataName, handler);
	}

	public void AddOnReceiveDataHandler(string modIdStr, string dataName, Action<string> handler)
	{
		StringDataHandlers.Add(modIdStr + "." + dataName, handler);
	}

	public void AddOnReceiveDataHandler(string modIdStr, string dataName, Action<SerializableModData> handler)
	{
		SerializableModDataHandlers.Add(modIdStr + "." + dataName, handler);
	}

	private SerializableModData GetModData(string modIdStr, bool isArchive)
	{
		return isArchive ? _archiveModDataDict[ModInfoDict[modIdStr].ModId] : _nonArchiveModDataDict[ModInfoDict[modIdStr].ModId];
	}

	public void OfflineSetInt(string modIdStr, string dataName, bool isArchive, int val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
	}

	public void OfflineSetFloat(string modIdStr, string dataName, bool isArchive, float val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
	}

	public void OfflineSetBool(string modIdStr, string dataName, bool isArchive, bool val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
	}

	public void OfflineSetString(string modIdStr, string dataName, bool isArchive, string val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
	}

	public void OfflineSetSerializableModData(string modIdStr, string dataName, bool isArchive, SerializableModData val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
	}

	public void SetModData(DataContext context, string modIdStr, bool isArchive)
	{
		ModId modId = ModInfoDict[modIdStr].ModId;
		if (isArchive)
		{
			SerializableModData archiveModData = _archiveModDataDict[modId];
			SetElement_ArchiveModDataDict(modId, archiveModData, context);
		}
		else
		{
			SerializableModData nonArchiveModData = _nonArchiveModDataDict[modId];
			SetElement_NonArchiveModDataDict(modId, nonArchiveModData, context);
		}
	}

	[DomainMethod]
	public bool SetInt(DataContext context, string modIdStr, string dataName, bool isArchive, int val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		if (IntDataHandlers.TryGetValue(modIdStr + "." + dataName, out var handler))
		{
			handler(val);
			return true;
		}
		return false;
	}

	[DomainMethod]
	public bool SetBool(DataContext context, string modIdStr, string dataName, bool isArchive, bool val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		if (BoolDataHandlers.TryGetValue(modIdStr + "." + dataName, out var handler))
		{
			handler(val);
			return true;
		}
		return false;
	}

	public bool SetFloat(DataContext context, string modIdStr, string dataName, bool isArchive, float val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		if (FloatDataHandlers.TryGetValue(modIdStr + "." + dataName, out var handler))
		{
			handler(val);
			return true;
		}
		return false;
	}

	[DomainMethod]
	public bool SetString(DataContext context, string modIdStr, string dataName, bool isArchive, string val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		if (StringDataHandlers.TryGetValue(modIdStr + "." + dataName, out var handler))
		{
			handler(val);
			return true;
		}
		return false;
	}

	[DomainMethod]
	public bool SetSerializableModData(DataContext context, string modIdStr, string dataName, bool isArchive, SerializableModData val)
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		if (SerializableModDataHandlers.TryGetValue(modIdStr + "." + dataName, out var handler))
		{
			handler(val);
			return true;
		}
		return false;
	}

	public bool SetISerializableGameData<T>(DataContext context, string modIdStr, string dataName, bool isArchive, T val) where T : ISerializableGameData
	{
		GetModData(modIdStr, isArchive).Set(dataName, val);
		SetModData(context, modIdStr, isArchive);
		return false;
	}

	[DomainMethod]
	public int GetInt(string modIdStr, string dataName, bool isArchive)
	{
		if (GetModData(modIdStr, isArchive).Get(dataName, out int val))
		{
			return val;
		}
		throw new ArgumentOutOfRangeException("dataName", "Failed to find mod data " + dataName + " of type int");
	}

	[DomainMethod]
	public bool GetBool(string modIdStr, string dataName, bool isArchive)
	{
		if (GetModData(modIdStr, isArchive).Get(dataName, out bool val))
		{
			return val;
		}
		throw new ArgumentOutOfRangeException("dataName", "Failed to find mod data " + dataName + " of type bool");
	}

	[DomainMethod]
	public string GetString(string modIdStr, string dataName, bool isArchive)
	{
		if (GetModData(modIdStr, isArchive).Get(dataName, out string val))
		{
			return val;
		}
		throw new ArgumentOutOfRangeException("dataName", "Failed to find mod data " + dataName + " of type string");
	}

	[DomainMethod]
	public SerializableModData GetSerializableModData(string modIdStr, string dataName, bool isArchive)
	{
		if (GetModData(modIdStr, isArchive).Get(dataName, out SerializableModData val))
		{
			return val;
		}
		throw new ArgumentOutOfRangeException("dataName", "Failed to find SerializableModData with name " + dataName);
	}

	public bool TryGet(string modIdStr, string dataName, bool isArchive, out int val)
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool TryGet(string modIdStr, string dataName, bool isArchive, out bool val)
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool TryGet(string modIdStr, string dataName, bool isArchive, out float val)
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool TryGet(string modIdStr, string dataName, bool isArchive, out string val)
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool TryGet(string modIdStr, string dataName, bool isArchive, out SerializableModData val)
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool TryGet<T>(string modIdStr, string dataName, bool isArchive, out T val) where T : ISerializableGameData
	{
		return GetModData(modIdStr, isArchive).Get(dataName, out val);
	}

	public bool RemoveInt(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveInt(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public bool RemoveBool(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveBool(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public bool RemoveFloat(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveFloat(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public bool RemoveString(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveString(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public bool RemoveSerializableModData(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveObject(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public bool RemoveISerializableGameData(DataContext context, string modIdStr, string dataName, bool isArchive)
	{
		bool succeed = GetModData(modIdStr, isArchive).RemoveObject(dataName);
		SetModData(context, modIdStr, isArchive);
		return succeed;
	}

	public void RemoveData(DataContext context, string modIdStr, string dataName)
	{
		GetModData(modIdStr, isArchive: true).Remove(dataName);
		SetModData(context, modIdStr, isArchive: true);
		GetModData(modIdStr, isArchive: false).Remove(dataName);
		SetModData(context, modIdStr, isArchive: false);
	}

	private void ClearModMethods()
	{
		ModMethods.Clear();
		ModMethodsWithParam.Clear();
		ModMethodsWithRet.Clear();
		ModMethodsWithParamAndRet.Clear();
	}

	[DomainMethod]
	public void CallModMethod(DataContext context, string modIdStr, string methodName)
	{
		if (ModMethods.TryGetValue(modIdStr + ".Method." + methodName, out var method))
		{
			method(context);
			return;
		}
		string modName = GetModTitle(modIdStr);
		Logger.AppendWarning($"Unable to call method {methodName} of mod {modName}({modIdStr}).");
	}

	[DomainMethod]
	public void CallModMethodWithParam(DataContext context, string modIdStr, string methodName, SerializableModData parameter)
	{
		if (ModMethodsWithParam.TryGetValue(modIdStr + ".Method." + methodName, out var method))
		{
			method(context, parameter);
			return;
		}
		string modName = GetModTitle(modIdStr);
		Logger.AppendWarning($"Unable to call method {methodName} of mod {modName}({modIdStr}) with parameter.");
	}

	[DomainMethod]
	public SerializableModData CallModMethodWithRet(DataContext context, string modIdStr, string methodName)
	{
		if (ModMethodsWithRet.TryGetValue(modIdStr + ".Method." + methodName, out var method))
		{
			return method(context);
		}
		string modName = GetModTitle(modIdStr);
		Logger.AppendWarning($"Unable to call method {methodName} of mod {modName}({modIdStr}) with return value.");
		return new SerializableModData();
	}

	[DomainMethod]
	public SerializableModData CallModMethodWithParamAndRet(DataContext context, string modIdStr, string methodName, SerializableModData parameter)
	{
		if (ModMethodsWithParamAndRet.TryGetValue(modIdStr + ".Method." + methodName, out var method))
		{
			return method(context, parameter);
		}
		string modName = GetModTitle(modIdStr);
		Logger.AppendWarning($"Unable to call method {methodName} of mod {modName}({modIdStr}) with parameter and return value.");
		return new SerializableModData();
	}

	public void AddModMethod(string modIdStr, string methodName, Func<DataContext, SerializableModData, SerializableModData> method)
	{
		ModMethodsWithParamAndRet.Add(modIdStr + ".Method." + methodName, method);
	}

	public void AddModMethod(string modIdStr, string methodName, Func<DataContext, SerializableModData> method)
	{
		ModMethodsWithRet.Add(modIdStr + ".Method." + methodName, method);
	}

	public void AddModMethod(string modIdStr, string methodName, Action<DataContext, SerializableModData> method)
	{
		ModMethodsWithParam.Add(modIdStr + ".Method." + methodName, method);
	}

	public void AddModMethod(string modIdStr, string methodName, Action<DataContext> method)
	{
		ModMethods.Add(modIdStr + ".Method." + methodName, method);
	}

	public void AddModDisplayEvent(string modIdStr, string customData)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ModDisplayEvent, modIdStr, customData);
	}

	[DomainMethod]
	public void UpdateModSettings(DataContext context, ModId modId, SerializableModData modData)
	{
		ModInfoDict[modId.ToString()].ModSettings = modData;
		foreach (TaiwuRemakePlugin plugin in LoadedPlugins[modId])
		{
			plugin.OnModSettingUpdate();
		}
	}

	public bool GetSetting(string modIdStr, string settingName, ref int val)
	{
		ModInfo modInfo;
		return ModInfoDict.TryGetValue(modIdStr, out modInfo) && modInfo.ModSettings.Get(settingName, out val);
	}

	public bool GetSetting(string modIdStr, string settingName, ref float val)
	{
		ModInfo modInfo;
		return ModInfoDict.TryGetValue(modIdStr, out modInfo) && modInfo.ModSettings.Get(settingName, out val);
	}

	public bool GetSetting(string modIdStr, string settingName, ref bool val)
	{
		ModInfo modInfo;
		return ModInfoDict.TryGetValue(modIdStr, out modInfo) && modInfo.ModSettings.Get(settingName, out val);
	}

	public bool GetSetting(string modIdStr, string settingName, ref string val)
	{
		ModInfo modInfo;
		return ModInfoDict.TryGetValue(modIdStr, out modInfo) && modInfo.ModSettings.Get(settingName, out val);
	}

	public ModDomain()
		: base(2)
	{
		_archiveModDataDict = new Dictionary<ModId, SerializableModData>(0);
		_nonArchiveModDataDict = new Dictionary<ModId, SerializableModData>(0);
		OnInitializedDomainData();
	}

	private SerializableModData GetElement_ArchiveModDataDict(ModId elementId)
	{
		return _archiveModDataDict[elementId];
	}

	private bool TryGetElement_ArchiveModDataDict(ModId elementId, out SerializableModData value)
	{
		return _archiveModDataDict.TryGetValue(elementId, out value);
	}

	private void AddElement_ArchiveModDataDict(ModId elementId, SerializableModData value, DataContext context)
	{
		_archiveModDataDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void SetElement_ArchiveModDataDict(ModId elementId, SerializableModData value, DataContext context)
	{
		_archiveModDataDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_ArchiveModDataDict(ModId elementId, DataContext context)
	{
		_archiveModDataDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void ClearArchiveModDataDict(DataContext context)
	{
		_archiveModDataDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private SerializableModData GetElement_NonArchiveModDataDict(ModId elementId)
	{
		return _nonArchiveModDataDict[elementId];
	}

	private bool TryGetElement_NonArchiveModDataDict(ModId elementId, out SerializableModData value)
	{
		return _nonArchiveModDataDict.TryGetValue(elementId, out value);
	}

	private void AddElement_NonArchiveModDataDict(ModId elementId, SerializableModData value, DataContext context)
	{
		_nonArchiveModDataDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void SetElement_NonArchiveModDataDict(ModId elementId, SerializableModData value, DataContext context)
	{
		_nonArchiveModDataDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_NonArchiveModDataDict(ModId elementId, DataContext context)
	{
		_nonArchiveModDataDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void ClearNonArchiveModDataDict(DataContext context)
	{
		_nonArchiveModDataDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)1);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCollectionCustomKeyValue(_archiveModDataDict);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			if (domainDataMeta.DataId == 0)
			{
				archive.ReadSingleValueCollectionCustomKeyValue(_archiveModDataDict);
				RecordLoadedDomainData(domainDataMeta.DataId);
				continue;
			}
			throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(16);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 1:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 4)
			{
				string modIdStr11 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr11);
				string dataName7 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName7);
				bool isArchive7 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive7);
				int val3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref val3);
				bool returnValue9 = SetInt(context, modIdStr11, dataName7, isArchive7, val3);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 4)
			{
				string modIdStr6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr6);
				string dataName4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName4);
				bool isArchive4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive4);
				bool val2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref val2);
				bool returnValue6 = SetBool(context, modIdStr6, dataName4, isArchive4, val2);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 4)
			{
				string modIdStr12 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr12);
				string dataName8 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName8);
				bool isArchive8 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive8);
				string val4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref val4);
				bool returnValue10 = SetString(context, modIdStr12, dataName8, isArchive8, val4);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 4)
			{
				string modIdStr3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr3);
				string dataName2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName2);
				bool isArchive2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive2);
				SerializableModData val = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref val);
				bool returnValue3 = SetSerializableModData(context, modIdStr3, dataName2, isArchive2, val);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 3)
			{
				string modIdStr8 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr8);
				string dataName5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName5);
				bool isArchive5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive5);
				int returnValue7 = GetInt(modIdStr8, dataName5, isArchive5);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 3)
			{
				string modIdStr2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr2);
				string dataName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName);
				bool isArchive = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive);
				bool returnValue2 = GetBool(modIdStr2, dataName, isArchive);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 3)
			{
				string modIdStr9 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr9);
				string dataName6 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName6);
				bool isArchive6 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive6);
				string returnValue8 = GetString(modIdStr9, dataName6, isArchive6);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 3)
			{
				string modIdStr5 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr5);
				string dataName3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref dataName3);
				bool isArchive3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isArchive3);
				SerializableModData returnValue5 = GetSerializableModData(modIdStr5, dataName3, isArchive3);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				ModId modId = default(ModId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modId);
				SerializableModData modData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modData);
				UpdateModSettings(context, modId, modData);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 2)
			{
				string modIdStr10 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr10);
				string methodName4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref methodName4);
				CallModMethod(context, modIdStr10, methodName4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 3)
			{
				string modIdStr7 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr7);
				string methodName3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref methodName3);
				SerializableModData parameter2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref parameter2);
				CallModMethodWithParam(context, modIdStr7, methodName3, parameter2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 11:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				string modIdStr4 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr4);
				string methodName2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref methodName2);
				SerializableModData returnValue4 = CallModMethodWithRet(context, modIdStr4, methodName2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 3)
			{
				string modIdStr = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref modIdStr);
				string methodName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref methodName);
				SerializableModData parameter = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref parameter);
				SerializableModData returnValue = CallModMethodWithParamAndRet(context, modIdStr, methodName, parameter);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		ushort num = dataId;
		ushort num2 = num;
		if (num2 == 0 || num2 == 1)
		{
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		ushort dataId = influence.TargetIndicator.DataId;
		ushort num = dataId;
		if (num != 0 && num != 1)
		{
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		}
		throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}
