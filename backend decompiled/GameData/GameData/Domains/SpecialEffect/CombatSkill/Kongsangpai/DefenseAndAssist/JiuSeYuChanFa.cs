using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class JiuSeYuChanFa : AssistSkillBase
{
	private enum EMarkType : sbyte
	{
		Flaw,
		Acupoint,
		Mind,
		Fatal,
		OuterInjury,
		InnerInjury
	}

	private const sbyte CostNeiliAllocationUnit = 9;

	private const int DirectRemoveMarkCount = 9;

	private const int ReverseRemoveMarkCount = int.MaxValue;

	private const int ReverseCostNeiliAllocationUnitMaxCount = 11;

	private List<(EMarkType, sbyte)> _markTypeRandomPool;

	private List<(EMarkType, sbyte)> _tempMarkTypeRandomPool;

	private Injuries _tempInjuries;

	private BoolArray8 _markTypeChanged;

	private int _affectCount = 0;

	private int RemoveMarkCount => base.IsDirect ? 9 : int.MaxValue;

	private int CostNeiliAllocation => base.IsDirect ? 9 : (9 * Math.Min(_affectCount + 1, 11));

	public JiuSeYuChanFa()
	{
	}

	public JiuSeYuChanFa(CombatSkillKey skillKey)
		: base(skillKey, 10708)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	private unsafe void OnCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (!base.CanAffect || combatChar != base.CombatChar || type != ECombatCharAboutToFallType.JiuSeYuChanFa || !DomainManager.Combat.DefeatMarkReachFailCount(base.CombatChar))
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
		if (neiliAllocation.Items[3] >= CostNeiliAllocation)
		{
			GenerateMarkRandomPool();
			if (base.IsDirect)
			{
				RemoveByMarkRandomPool(context.Random);
			}
			else
			{
				RemoveByTempRandomPool(context.Random, IsInjuryMark);
				RemoveByTempRandomPool(context.Random, IsNotInjuryMark);
				RemoveByTempRandomPool(context.Random, IsFatalMark);
			}
			SetAllChangedFields(context);
			base.CombatChar.ChangeNeiliAllocation(context, 3, -CostNeiliAllocation, applySpecialEffect: false);
			_affectCount++;
			ShowSpecialEffectTips(0);
			ShowEffectTips(context);
		}
	}

	private void GenerateMarkRandomPool()
	{
		if (_markTypeRandomPool == null)
		{
			_markTypeRandomPool = new List<(EMarkType, sbyte)>();
		}
		_markTypeRandomPool.Clear();
		_markTypeChanged.Reset();
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		byte[] flawCounts = base.CombatChar.GetFlawCount();
		byte[] acupointCounts = base.CombatChar.GetAcupointCount();
		MindMarkList mindMarks = base.CombatChar.GetMindMarkTime();
		_tempInjuries = base.CombatChar.GetInjuries();
		Injuries newInjuries = _tempInjuries.Subtract(base.CombatChar.GetOldInjuries());
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			for (int i = 0; i < flawCounts[bodyPart]; i++)
			{
				_markTypeRandomPool.Add((EMarkType.Flaw, bodyPart));
			}
			for (int j = 0; j < acupointCounts[bodyPart]; j++)
			{
				_markTypeRandomPool.Add((EMarkType.Acupoint, bodyPart));
			}
		}
		if (mindMarks.MarkList != null)
		{
			for (int k = 0; k < mindMarks.MarkList.Count; k++)
			{
				_markTypeRandomPool.Add((EMarkType.Mind, -1));
			}
		}
		for (int l = 0; l < markCollection.FatalDamageMarkCount; l++)
		{
			_markTypeRandomPool.Add((EMarkType.Fatal, -1));
		}
		if (!newInjuries.HasAnyInjury())
		{
			return;
		}
		for (sbyte bodyPart2 = 0; bodyPart2 < 7; bodyPart2++)
		{
			(sbyte, sbyte) injury = newInjuries.Get(bodyPart2);
			for (int m = 0; m < injury.Item1; m++)
			{
				_markTypeRandomPool.Add((EMarkType.OuterInjury, bodyPart2));
			}
			for (int n = 0; n < injury.Item2; n++)
			{
				_markTypeRandomPool.Add((EMarkType.InnerInjury, bodyPart2));
			}
		}
	}

	private static bool IsInjuryMark((EMarkType markType, sbyte bodyPart) tup)
	{
		var (eMarkType, _) = tup;
		if ((uint)(eMarkType - 4) <= 1u)
		{
			return true;
		}
		return false;
	}

	private static bool IsNotInjuryMark((EMarkType markType, sbyte bodyPart) tup)
	{
		var (eMarkType, _) = tup;
		if ((uint)eMarkType <= 2u)
		{
			return true;
		}
		return false;
	}

	private static bool IsFatalMark((EMarkType markType, sbyte bodyPart) tup)
	{
		return tup.markType == EMarkType.Fatal;
	}

	private int RemoveByMarkRandomPool(IRandomSource random)
	{
		int removedCount = Math.Min(RemoveMarkCount, _markTypeRandomPool.Count);
		for (int i = 0; i < removedCount; i++)
		{
			(EMarkType, sbyte) tuple = _markTypeRandomPool.GetRandom(random);
			var (type, bodyPart) = tuple;
			ErasureDefeatMark(random, type, bodyPart);
			_markTypeRandomPool.Remove(tuple);
		}
		return removedCount;
	}

	private int RemoveByTempRandomPool(IRandomSource random, Func<(EMarkType, sbyte), bool> predicate)
	{
		if (_tempMarkTypeRandomPool == null)
		{
			_tempMarkTypeRandomPool = new List<(EMarkType, sbyte)>();
		}
		_tempMarkTypeRandomPool.Clear();
		_tempMarkTypeRandomPool.AddRange(_markTypeRandomPool.Where(predicate));
		int removedCount = Math.Min(RemoveMarkCount, _tempMarkTypeRandomPool.Count);
		for (int i = 0; i < removedCount; i++)
		{
			(EMarkType, sbyte) tuple = _tempMarkTypeRandomPool.GetRandom(random);
			var (type, bodyPart) = tuple;
			ErasureDefeatMark(random, type, bodyPart);
			_tempMarkTypeRandomPool.Remove(tuple);
		}
		return removedCount;
	}

	private void ErasureFlawOrAcupoint(sbyte bodyPart, bool isFlaw, IRandomSource random)
	{
		FlawOrAcupointCollection flawOrAcupointCollection = (isFlaw ? base.CombatChar.GetFlawCollection() : base.CombatChar.GetAcupointCollection());
		byte[] flawOrAcupointCounts = (isFlaw ? base.CombatChar.GetFlawCount() : base.CombatChar.GetAcupointCount());
		List<FlawOrAcupointEntry> flawOrAcupointList = flawOrAcupointCollection.BodyPartDict[bodyPart];
		int removeIndex = random.Next(0, flawOrAcupointList.Count);
		flawOrAcupointCounts[bodyPart]--;
		flawOrAcupointList.RemoveAt(removeIndex);
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		ByteList[] markList = (isFlaw ? markCollection.FlawMarkList : markCollection.AcupointMarkList);
		markList[bodyPart].RemoveAt(removeIndex);
	}

	private void ErasureMind(IRandomSource random)
	{
		MindMarkList mindMarks = base.CombatChar.GetMindMarkTime();
		int mindMarkIndex = random.Next(0, mindMarks.MarkList.Count);
		mindMarks.MarkList.RemoveAt(mindMarkIndex);
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		markCollection.MindMarkList.RemoveAt(mindMarkIndex);
	}

	private void ErasureFatal()
	{
		base.CombatChar.RemoveFatalMark(base.CombatChar.GetDataContext(), 1);
	}

	private void ErasureInjury(sbyte bodyPart, bool isInner)
	{
		_tempInjuries.Change(bodyPart, isInner, -1);
	}

	private void ErasureDefeatMark(IRandomSource random, EMarkType type, sbyte bodyPart)
	{
		_markTypeChanged[(int)type] = true;
		switch (type)
		{
		case EMarkType.Flaw:
		case EMarkType.Acupoint:
			ErasureFlawOrAcupoint(bodyPart, type == EMarkType.Flaw, random);
			break;
		case EMarkType.Mind:
			ErasureMind(random);
			break;
		case EMarkType.Fatal:
			ErasureFatal();
			break;
		case EMarkType.OuterInjury:
		case EMarkType.InnerInjury:
			ErasureInjury(bodyPart, type == EMarkType.InnerInjury);
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	private void SetAllChangedFields(DataContext context)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		byte[] flawCounts = base.CombatChar.GetFlawCount();
		FlawOrAcupointCollection flawCollection = base.CombatChar.GetFlawCollection();
		byte[] acupointCounts = base.CombatChar.GetAcupointCount();
		FlawOrAcupointCollection acupointCollection = base.CombatChar.GetAcupointCollection();
		MindMarkList mindMarks = base.CombatChar.GetMindMarkTime();
		if (_markTypeChanged[0])
		{
			base.CombatChar.SetFlawCount(flawCounts, context);
			base.CombatChar.SetFlawCollection(flawCollection, context);
		}
		if (_markTypeChanged[1])
		{
			base.CombatChar.SetAcupointCount(acupointCounts, context);
			base.CombatChar.SetAcupointCollection(acupointCollection, context);
		}
		if (_markTypeChanged[2])
		{
			base.CombatChar.SetMindMarkTime(mindMarks, context);
		}
		if (_markTypeChanged[4] || _markTypeChanged[5])
		{
			base.CombatChar.SetInjuries(context, _tempInjuries);
		}
		if (_markTypeChanged.Any())
		{
			base.CombatChar.SetDefeatMarkCollection(markCollection, context);
		}
	}
}
