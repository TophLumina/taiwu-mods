using System.Collections.Generic;
using System.Linq;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇变量提供者拓展方法集
/// </summary>
public static class AdventureParameterProviderExtensions
{
	/// <summary>
	/// 获取变量值
	/// </summary>
	public static AdventureParameterValue? GetParameterOrNull(this IAdventureParameterProvider provider, string key)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			return provider.GetParameterOrNull(mappingKey.Value);
		}
		return null;
	}

	/// <summary>
	/// 设置变量值
	/// </summary>
	public static void SetParameter(this IAdventureParameterProvider provider, string key, AdventureParameterValue value)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			provider.SetParameter(mappingKey.Value, value);
		}
	}

	/// <summary>
	/// 移除变量值
	/// </summary>
	public static void RemoveParameter(this IAdventureParameterProvider provider, string key)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			provider.RemoveParameter(mappingKey.Value);
		}
	}

	/// <summary>
	/// 是否存在指定变量值
	/// </summary>
	public static bool ContainsParameter(this IAdventureParameterProvider provider, string key)
	{
		return provider.GetParameterOrNull(key).HasValue;
	}

	/// <summary>
	/// 尝试获取变量值
	/// </summary>
	public static bool TryGetParameter(this IAdventureParameterProvider provider, string key, out AdventureParameterValue value)
	{
		AdventureParameterValue? valueOrNull = provider.GetParameterOrNull(key);
		value = valueOrNull ?? ((AdventureParameterValue)0);
		return valueOrNull.HasValue;
	}

	/// <summary>
	/// 获取变量值
	/// </summary>
	public static AdventureParameterValue GetParameterOrDefault(this IAdventureParameterProvider provider, string key, AdventureParameterValue defaultValue)
	{
		return provider.GetParameterOrNull(key) ?? defaultValue;
	}

	/// <summary>
	/// 获取变量值
	/// </summary>
	public static AdventureParameterValue GetParameter(this IAdventureParameterProvider provider, string key)
	{
		return provider.GetParameterOrDefault(key, 0);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	public static void InitializeParameters(this IAdventureParameterProvider provider)
	{
		IReadOnlyList<AdventureParameterData> parameters = provider.Parameters;
		if (parameters == null || parameters.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < parameters.Count; i++)
		{
			AdventureParameterData parameter = parameters[i];
			if (!string.IsNullOrEmpty(parameter.Key))
			{
				int key = i + 1;
				provider.SetParameter(key, new AdventureParameterValue(parameter.Type, parameter.InitialValue));
			}
		}
	}

	/// <summary>
	/// 映射变量键
	/// </summary>
	public static AdventureParameterKey? MappingParameterKey(this IAdventureParameterProvider provider, string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		IReadOnlyList<AdventureParameterData> parameters = provider.Parameters;
		if (parameters == null || parameters.Count <= 0)
		{
			return new AdventureParameterKey(key);
		}
		for (int i = 0; i < parameters.Count; i++)
		{
			if (parameters[i].Key == key)
			{
				return i + 1;
			}
		}
		return new AdventureParameterKey(key);
	}

	/// <summary>
	/// 获取变量数据
	/// </summary>
	public static AdventureParameterData GetParameterData(this IAdventureParameterProvider provider, string key)
	{
		IReadOnlyList<AdventureParameterData> parameters = provider.Parameters;
		if (parameters == null || parameters.Count <= 0 || string.IsNullOrEmpty(key))
		{
			return null;
		}
		foreach (AdventureParameterData data in parameters)
		{
			if (data.Key == key)
			{
				return data;
			}
		}
		return null;
	}

	/// <summary>
	/// 获取指定类型的所有变量数据
	/// </summary>
	public static IEnumerable<AdventureParameterData> GetParameterData(this IAdventureParameterProvider provider, EAdventureParameterType type)
	{
		IReadOnlyList<AdventureParameterData> parameters = provider.Parameters;
		if (parameters == null || parameters.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureParameterData data in parameters)
		{
			if (data.Type == type)
			{
				yield return data;
			}
		}
	}

	/// <summary>
	/// 获取指定类型的所有变量值
	/// </summary>
	public static IEnumerable<AdventureParameterValue> GetParameterValues(this IAdventureParameterProvider provider, EAdventureParameterType type)
	{
		return from data in provider.GetParameterData(type)
			select provider.GetParameter(data.Key);
	}

	/// <summary>
	/// 改变变量值
	/// </summary>
	public static void ChangeParameter(this IAdventureParameterProvider participant, string key, int delta)
	{
		AdventureParameterValue value = participant.GetParameter(key);
		value.Change(delta);
		participant.SetParameter(key, value);
	}
}
