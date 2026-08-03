using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Config;
using Config.Common;
using GameData.Utilities.Reflection;
using TaiwuModdingLib.Core.Utils;

namespace GameData.Utilities.Mod;

/// <summary>
/// 包含一些修改配置数据的方法的静态 Extension 类
/// </summary>
public static class ConfigDataModificationUtils
{
	private static readonly RawDataPool DataPool = new RawDataPool(1024);

	/// <summary>
	/// 替换一项在配置集合中的配置数据。
	/// 注意需要调用者自行确保新的配置数据的 TemplateId 字段是正确的值。
	/// </summary>
	/// <example>
	/// <code>
	/// short templateId = 10;
	/// AdventureItem newAdventure = new AdventureItem(templateId, ...此处省略参数...);
	/// Config.Adventure.Instance.ReplaceConfig(templateId, newAdventure);
	/// </code>
	/// </example>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="templateId">需要替换的位置，也就是被替换数据的TemplateId。</param>
	/// <param name="item"> 需要替换原本数据的新配置数据，也就是 [ConfigDataName]Item 对象</param>
	/// <typeparam name="TConfig">config 的类型，通常来说不需要手动填写，会根据参数的类型自动识别</typeparam>
	/// <typeparam name="TItem">item 的类型，通常来说不需要手动填写描，会根据参数的类型自动识别</typeparam>
	public static void ReplaceConfig<TConfig, TItem>(this TConfig config, int templateId, TItem item) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId] = item;
	}

	/// <summary>
	/// 添加一项配置数据。
	/// 注意需要调用者自行确保新的配置数据的 TemplateId 字段是正确的值。
	/// </summary>
	/// <example>
	/// <code>
	/// AdventureItem newAdventure = new AdventureItem(...此处省略参数...);
	/// Config.Adventure.Instance.AppendConfig(newAdventure);
	/// </code>
	/// </example>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="item"> 需要添加到配置数据集合中的新数据，也就是 [ConfigDataName]Item 对象</param>
	/// <typeparam name="TConfig">config 的类型，通常来说不需要手动填写，会根据参数的类型自动识别</typeparam>
	/// <typeparam name="TItem">item 的类型，通常来说不需要手动填写描，会根据参数的类型自动识别</typeparam>
	[Obsolete]
	public static void AppendConfig<TConfig, TItem>(this TConfig config, TItem item) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).Add(item);
	}

	/// <summary>
	/// 添加一项配置数据。
	/// 注意需要调用者自行确保新的配置数据的 TemplateId 字段是正确的值。
	/// </summary>
	/// <example>
	/// <code>
	/// AdventureItem newAdventure = new AdventureItem(...此处省略参数...);
	/// Config.Adventure.Instance.AppendConfig(newAdventure);
	/// </code>
	/// </example>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="item"> 需要添加到配置数据集合中的新数据，也就是 [ConfigDataName]Item 对象</param>
	/// <typeparam name="TConfig">config 的类型，通常来说不需要手动填写，会根据参数的类型自动识别</typeparam>
	[Obsolete]
	public static void AppendConfig<TConfig>(this TConfig config, object item) where TConfig : IConfigData
	{
		((IList)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).Add(item);
	}

	/// <summary>
	/// 批量添加元素到配置数据集合
	/// 注意需要调用者自行确保新的配置数据的 TemplateId 字段是正确的值
	/// </summary>
	/// <example>
	/// <code>
	/// List&lt;AdventureItem&gt; newAdventures = new List&lt;AdventureItem&gt;();
	/// // 此处省略填充元素到 newAdventures 中的步骤
	/// Config.Adventure.Instance.AppendConfigRange(newAdventures);
	/// </code>
	/// </example>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="items"> 需要批量添加到配置数据集合的元素集合，也就是 [ConfigDataName]Item 对象的集合</param>
	/// <typeparam name="TConfig">Config 的类型，通常来说不需要手动填写，会根据参数的类型自动识别</typeparam>
	/// <typeparam name="TItem">items 中元素的类型，通常来说不需要手动填写描，会根据参数的类型自动识别</typeparam>
	public static void AppendConfigRange<TConfig, TItem>(this TConfig config, IEnumerable<TItem> items) where TConfig : IEnumerable<TItem>, IConfigData
	{
		((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config))).AddRange(items);
	}

	/// <summary>
	/// 获取指定配置数据
	/// </summary>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="refName">配置数据引用名</param>
	/// <returns>模板数据</returns>
	public static TItem GetConfigItem<TConfig, TItem>(this TConfig config, string refName) where TConfig : IEnumerable<TItem>, IConfigData
	{
		int templateId = config.GetItemId(refName);
		return config.GetConfigItem<TConfig, TItem>(templateId);
	}

	/// <summary>
	/// 获取指定配置数据
	/// </summary>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="refName">配置数据引用名</param>
	/// <returns>模板数据</returns>
	public static object GetConfigItem<TConfig>(this TConfig config, string refName) where TConfig : IConfigData
	{
		int templateId = config.GetItemId(refName);
		return config.GetConfigItem(templateId);
	}

	/// <summary>
	/// 获取指定配置数据
	/// </summary>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="templateId">模板ID</param>
	/// <returns>模板数据</returns>
	public static TItem GetConfigItem<TConfig, TItem>(this TConfig config, int templateId) where TConfig : IEnumerable<TItem>, IConfigData
	{
		return ((List<TItem>)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId];
	}

	/// <summary>
	/// 获取指定配置数据
	/// </summary>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <param name="templateId">模板ID</param>
	/// <returns>模板数据</returns>
	public static object GetConfigItem<TConfig>(this TConfig config, int templateId) where TConfig : IConfigData
	{
		return ((IList)(config.GetType().GetField("_dataArray", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(config)))[templateId];
	}

	/// <summary>
	/// 获取指定配置表的长度
	/// </summary>
	/// <param name="config">配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</param>
	/// <typeparam name="TConfig"></typeparam>
	/// <returns></returns>
	public static int GetConfigCount<TConfig>(this TConfig config) where TConfig : IConfigData
	{
		return ((IList)config.GetFieldValue("_dataArray")).Count;
	}

	/// <summary>
	/// 获取配置表指定字段的值
	/// </summary>
	/// <param name="typeName">配置表名</param>
	/// <param name="templateId">模板ID</param>
	/// <param name="propertyName">字段名</param>
	/// <returns></returns>
	public static object GetConfigPropertyValue(string typeName, int templateId, string propertyName)
	{
		return ConfigCollection.NameMap[typeName].GetConfigItem(templateId).GetFieldValue(propertyName);
	}

	/// <summary>
	/// 修改指定配置数据的值
	/// </summary>
	/// <param name="config"></param>
	/// <param name="propertyName"></param>
	/// <param name="propertyTypeName"></param>
	/// <param name="parameters"></param>
	/// <typeparam name="TItem"></typeparam>
	public static void ModifyConfigObjectPropertyValue<TItem>(TItem config, string propertyName, string propertyTypeName, object[] parameters)
	{
		Type type = Assembly.GetExecutingAssembly().GetType(propertyTypeName);
		if (!(type == null))
		{
			object propertyVal = Activator.CreateInstance(type, parameters);
			config.ModifyField(propertyName, propertyVal);
		}
	}

	/// <summary>
	/// 获取指定配置数据
	/// </summary>
	/// <param name="configTypeName">配置数据类型，也是配置表的名称</param>
	/// <returns>名称对应的配置数据集合的实例，也就是 Config.[ConfigDataName].Instance</returns>
	[Obsolete("Use Config.ConfigCollection.NameMap[string] instead.")]
	public static IConfigData GetConfigData(string configTypeName)
	{
		return ConfigCollection.NameMap[configTypeName];
	}

	/// <summary>
	/// 通过默认序列化方法和反序列化方法深度复制指定对象
	/// </summary>
	/// <param name="obj">需要被复制的对象</param>
	/// <returns>传入对象的深度复制</returns>
	public static object CreateDeepCopy(this object obj)
	{
		return ReflectionHelper.DeepClone(obj);
	}
}
