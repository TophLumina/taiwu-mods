using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameData.Domains.Combat.Ai;

public static class AiFactory
{
	public static T CreateInstance<T>(Type type, IReadOnlyList<string> strings, IReadOnlyList<int> ints) where T : class
	{
		ConstructorInfo[] constructors = type.GetConstructors();
		if (constructors.Any(IsStandard))
		{
			return (T)Activator.CreateInstance(type, strings, ints);
		}
		if (constructors.Any(IsOnlyStrings))
		{
			return (T)Activator.CreateInstance(type, strings);
		}
		if (constructors.Any(IsOnlyInts))
		{
			return (T)Activator.CreateInstance(type, ints);
		}
		if (constructors.Any(IsEmpty))
		{
			return (T)Activator.CreateInstance(type);
		}
		return null;
	}

	public static bool IsStandard(ConstructorInfo constructor)
	{
		ParameterInfo[] parameters = constructor.GetParameters();
		if (parameters == null || parameters.Length != 2)
		{
			return false;
		}
		return parameters[0].ParameterType == typeof(IReadOnlyList<string>) && parameters[1].ParameterType == typeof(IReadOnlyList<int>);
	}

	public static bool IsOnlyStrings(ConstructorInfo constructor)
	{
		ParameterInfo[] parameters = constructor.GetParameters();
		if (parameters == null || parameters.Length != 1)
		{
			return false;
		}
		return parameters[0].ParameterType == typeof(IReadOnlyList<string>);
	}

	public static bool IsOnlyInts(ConstructorInfo constructor)
	{
		ParameterInfo[] parameters = constructor.GetParameters();
		if (parameters == null || parameters.Length != 1)
		{
			return false;
		}
		return parameters[0].ParameterType == typeof(IReadOnlyList<int>);
	}

	public static bool IsEmpty(ConstructorInfo constructor)
	{
		ParameterInfo[] parameters = constructor.GetParameters();
		return parameters == null || parameters.Length <= 0;
	}
}
