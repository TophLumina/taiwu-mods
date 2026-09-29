using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Config;
using Config.Common;
using GameData.Utilities.Reflection;
using TaiwuModdingLib.Core.Utils;

namespace GameData.Utilities.Mod;

public static class ConfigDataModificationUtils
{
	private static readonly RawDataPool DataPool = new RawDataPool(1024);

	public static void ReplaceConfig<TConfig, TItem>(this TConfig config, int templateId, TItem item) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId] = item;
	}

	[Obsolete]
	public static void AppendConfig<TConfig, TItem>(this TConfig config, TItem item) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).Add(item);
	}

	[Obsolete]
	public static void AppendConfig<TConfig>(this TConfig config, object item) where TConfig : IConfigData
	{
		((IList)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).Add(item);
	}

	public static void AppendConfigRange<TConfig, TItem>(this TConfig config, IEnumerable<TItem> items) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).AddRange(items);
	}

	public static TItem GetConfigItem<TConfig, TItem>(this TConfig config, string refName) where TConfig : IEnumerable<TItem>, IConfigData
	{
		int templateId = config.GetItemId(refName);
		return config.GetConfigItem<TConfig, TItem>(templateId);
	}

	public static object GetConfigItem<TConfig>(this TConfig config, string refName) where TConfig : IConfigData
	{
		int templateId = config.GetItemId(refName);
		return config.GetConfigItem(templateId);
	}

	public static TItem GetConfigItem<TConfig, TItem>(this TConfig config, int templateId) where TConfig : IEnumerable<TItem>, IConfigData
	{
		return ((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId];
	}

	public static object GetConfigItem<TConfig>(this TConfig config, int templateId) where TConfig : IConfigData
	{
		return ((IList)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId];
	}

	public static int GetConfigCount<TConfig>(this TConfig config) where TConfig : IConfigData
	{
		return ((IList)config.GetFieldValue("_dataArray")).Count;
	}

	public static object GetConfigPropertyValue(string typeName, int templateId, string propertyName)
	{
		return ConfigCollection.NameMap[typeName].GetConfigItem(templateId).GetFieldValue(propertyName);
	}

	public static void ModifyConfigObjectPropertyValue<TItem>(TItem config, string propertyName, string propertyTypeName, object[] parameters)
	{
		Type type = Assembly.GetExecutingAssembly().GetType(propertyTypeName);
		if (!(type == null))
		{
			object propertyVal = Activator.CreateInstance(type, parameters);
			config.ModifyField(propertyName, propertyVal);
		}
	}

	[Obsolete("Use Config.ConfigCollection.NameMap[string] instead.")]
	public static IConfigData GetConfigData(string configTypeName)
	{
		return ConfigCollection.NameMap[configTypeName];
	}

	public static object CreateDeepCopy(this object obj)
	{
		return ReflectionHelper.DeepClone(obj);
	}
}
