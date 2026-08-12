using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai;

public static class AiNodeFactory
{
	private static readonly Dictionary<EAiNodeType, Type> Mapping = new Dictionary<EAiNodeType, Type>();

	public static void Register(Assembly assembly)
	{
		int count = assembly.GetTypes().Sum((Type type) => TryRegister(type) ? 1 : 0);
		AdaptableLog.Info($"AiNodeFactory.Register on {assembly.FullName} added {count} types");
	}

	public static bool TryRegister(Type type)
	{
		if (type.GetInterfaces().All((Type x) => x != typeof(IAiNode)))
		{
			return false;
		}
		Attribute customAttribute = type.GetCustomAttribute(typeof(AiNodeAttribute));
		return customAttribute is AiNodeAttribute attribute && Mapping.TryAdd(attribute.Type, type);
	}

	public static IAiNode Create(EAiNodeType type, int runtimeId, IReadOnlyList<int> nodeOrActionIds)
	{
		IAiNode result = null;
		if (Mapping.TryGetValue(type, out var conditionType))
		{
			result = (IAiNode)Activator.CreateInstance(conditionType, nodeOrActionIds);
		}
		if (result != null)
		{
			result.RuntimeId = runtimeId;
		}
		else
		{
			PredefinedLog.Show(8, $"Cannot analysis node {type} {runtimeId}");
		}
		return result;
	}
}
