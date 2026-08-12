using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai;

public static class AiConditionFactory
{
	private static readonly Dictionary<EAiConditionType, Type> Mapping = new Dictionary<EAiConditionType, Type>();

	public static void Register(Assembly assembly)
	{
		int count = assembly.GetTypes().Sum((Type type) => TryRegister(type) ? 1 : 0);
		AdaptableLog.Info($"AiConditionFactory.Register on {assembly.FullName} added {count} types");
	}

	public static bool TryRegister(Type type)
	{
		if (type.GetInterfaces().All((Type x) => x != typeof(IAiCondition)))
		{
			return false;
		}
		Attribute customAttribute = type.GetCustomAttribute(typeof(AiConditionAttribute));
		return customAttribute is AiConditionAttribute attribute && Mapping.TryAdd(attribute.Type, type);
	}

	public static IAiCondition Create(EAiConditionType type, int runtimeId, IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		IAiCondition result = null;
		if (Mapping.TryGetValue(type, out var conditionType))
		{
			result = AiFactory.CreateInstance<IAiCondition>(conditionType, strings, ints);
		}
		if (result != null)
		{
			result.RuntimeId = runtimeId;
		}
		else
		{
			PredefinedLog.Show(8, $"Cannot analysis condition {type} {runtimeId}");
		}
		return result;
	}
}
