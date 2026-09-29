using System.Collections.Generic;
using System.Linq;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

public static class AdventureParameterProviderExtensions
{
	public static AdventureParameterValue? GetParameterOrNull(this IAdventureParameterProvider provider, string key)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			return provider.GetParameterOrNull(mappingKey.Value);
		}
		return null;
	}

	public static void SetParameter(this IAdventureParameterProvider provider, string key, AdventureParameterValue value)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			provider.SetParameter(mappingKey.Value, value);
		}
	}

	public static void RemoveParameter(this IAdventureParameterProvider provider, string key)
	{
		AdventureParameterKey? mappingKey = provider.MappingParameterKey(key);
		if (mappingKey.HasValue)
		{
			provider.RemoveParameter(mappingKey.Value);
		}
	}

	public static bool ContainsParameter(this IAdventureParameterProvider provider, string key)
	{
		return provider.GetParameterOrNull(key).HasValue;
	}

	public static bool TryGetParameter(this IAdventureParameterProvider provider, string key, out AdventureParameterValue value)
	{
		AdventureParameterValue? valueOrNull = provider.GetParameterOrNull(key);
		value = valueOrNull ?? ((AdventureParameterValue)0);
		return valueOrNull.HasValue;
	}

	public static AdventureParameterValue GetParameterOrDefault(this IAdventureParameterProvider provider, string key, AdventureParameterValue defaultValue)
	{
		return provider.GetParameterOrNull(key) ?? defaultValue;
	}

	public static AdventureParameterValue GetParameter(this IAdventureParameterProvider provider, string key)
	{
		return provider.GetParameterOrDefault(key, 0);
	}

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

	public static IEnumerable<AdventureParameterValue> GetParameterValues(this IAdventureParameterProvider provider, EAdventureParameterType type)
	{
		return from data in provider.GetParameterData(type)
			select provider.GetParameter(data.Key);
	}

	public static void ChangeParameter(this IAdventureParameterProvider participant, string key, int delta)
	{
		AdventureParameterValue value = participant.GetParameter(key);
		value.Change(delta);
		participant.SetParameter(key, value);
	}
}
