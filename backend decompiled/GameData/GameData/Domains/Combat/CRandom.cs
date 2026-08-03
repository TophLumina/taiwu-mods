using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Domains.Character;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

public static class CRandom
{
	public enum EOuterAndInnerType
	{
		None,
		Both,
		Inner,
		Outer
	}

	public static void GenerateEmptyInjuryPool(Injuries injuries, IList<sbyte> pool, bool inner)
	{
		pool.Clear();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (injuries.Get(bodyPart, inner) == 0)
			{
				pool.Add(bodyPart);
			}
		}
	}

	public static void GenerateToMaxInjuryPool(Injuries injuries, IList<sbyte> pool, bool inner)
	{
		pool.Clear();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryValue = injuries.Get(bodyPart, inner);
			if (injuryValue < 6)
			{
				pool.Add(bodyPart);
			}
		}
	}

	public static void GenerateValueInjuryPool(Injuries injuries, ICollection<sbyte> pool, bool inner)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryValue = injuries.Get(bodyPart, inner);
			for (int i = 0; i < injuryValue; i++)
			{
				pool.Add(bodyPart);
			}
		}
	}

	public static void GenerateValueInjuryPool(Injuries injuries, ICollection<sbyte> inner, ICollection<sbyte> outer)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte outer, sbyte inner) tuple = injuries.Get(bodyPart);
			sbyte outerValue = tuple.outer;
			sbyte innerValue = tuple.inner;
			for (int i = 0; i < outerValue; i++)
			{
				outer?.Add(bodyPart);
			}
			for (int j = 0; j < innerValue; j++)
			{
				inner?.Add(bodyPart);
			}
		}
	}

	public static IEnumerable<InjuryKey> RandomInjuryByValue(IRandomSource random, Injuries injuries, int count)
	{
		List<sbyte> innerPool = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> outerPool = ObjectPool<List<sbyte>>.Instance.Get();
		GenerateValueInjuryPool(injuries, innerPool, outerPool);
		count = Math.Min(innerPool.Count + outerPool.Count, count);
		for (int i = 0; i < count; i++)
		{
			yield return RandomInjuryAndRemove(random, innerPool, outerPool);
		}
		ObjectPool<List<sbyte>>.Instance.Return(innerPool);
		ObjectPool<List<sbyte>>.Instance.Return(outerPool);
	}

	public static InjuryKey RandomInjuryAndRemove(IRandomSource random, IList<sbyte> innerPool, IList<sbyte> outerPool)
	{
		if ((innerPool == null || innerPool.Count <= 0) && (outerPool == null || outerPool.Count <= 0))
		{
			throw new InvalidOperationException("Unreachable state: both random pools are empty.");
		}
		bool inner = random.RandomIsInner(innerPool.Count > 0, outerPool.Count > 0);
		IList<sbyte> pool = (inner ? innerPool : outerPool);
		int index = random.Next(pool.Count);
		sbyte bodyPart = pool[index];
		CollectionUtils.SwapAndRemove(pool, index);
		return new InjuryKey(bodyPart, inner);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool RandomIsInner(this IRandomSource random, bool anyInner, bool anyOuter)
	{
		return !anyOuter || (anyInner && random.CheckPercentProb(50));
	}

	public static IEnumerable<sbyte> IterBodyPart(sbyte bodyPartType)
	{
		return IterAnyType(bodyPartType, 7);
	}

	public static IEnumerable<sbyte> IterPoisonType(sbyte poisonType)
	{
		return IterAnyType(poisonType, 6);
	}

	private static IEnumerable<sbyte> IterAnyType(sbyte typeValue, sbyte typeCount)
	{
		int begin = ((typeValue >= 0 && typeValue < typeCount) ? typeValue : 0);
		int end = ((typeValue < 0 || typeValue >= typeCount) ? typeCount : (typeValue + 1));
		for (int i = begin; i < end; i++)
		{
			yield return (sbyte)i;
		}
	}
}
