using System;
using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Memory;

public class RecordCollection
{
	private const int DistanceCount = 11;

	public const int BlockMemoryCount = 6;

	public readonly HitOrAvoidInts[] MaxHits;

	public HitOrAvoidInts MaxAvoid;

	public readonly OuterAndInnerInts[] MaxPenetrates;

	public OuterAndInnerInts MaxPenetrateResist;

	public readonly OuterAndInnerInts[] MaxDamages;

	public readonly int[] MaxMindDamages;

	public readonly Dictionary<short, (int score, int zeroScoreCount)> SkillRecord;

	public readonly Dictionary<int, (int score, int zeroScoreCount)> WeaponRecord;

	public RecordCollection()
	{
		MaxHits = new HitOrAvoidInts[11];
		MaxAvoid = new HitOrAvoidInts(default(int), default(int), default(int), default(int));
		MaxPenetrates = new OuterAndInnerInts[11];
		MaxPenetrateResist = new OuterAndInnerInts(0, 0);
		MaxDamages = new OuterAndInnerInts[11];
		MaxMindDamages = new int[11];
		SkillRecord = new Dictionary<short, (int, int)>();
		WeaponRecord = new Dictionary<int, (int, int)>();
	}

	public static int GetIndexByDistance(short distance)
	{
		return distance / 10 - 2;
	}

	public void ClearAll()
	{
		for (int i = 0; i < 11; i++)
		{
			MaxHits[i].Initialize();
			MaxPenetrates[i] = new OuterAndInnerInts(0, 0);
			MaxDamages[i] = new OuterAndInnerInts(0, 0);
			MaxMindDamages[i] = 0;
		}
		MaxAvoid.Initialize();
		MaxPenetrateResist = new OuterAndInnerInts(0, 0);
		SkillRecord.Clear();
		WeaponRecord.Clear();
	}

	public int GetSkillRecordMaxScore()
	{
		int maxScore = 0;
		foreach (var value in SkillRecord.Values)
		{
			maxScore = Math.Max(maxScore, value.score);
		}
		return maxScore;
	}
}
