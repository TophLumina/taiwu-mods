using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class ErJianMoNvYi : CombatSkillEffectBase
{
	private DataUid _defeatMarkUid;

	private DefeatMarkCollection _lastMarks;

	private readonly List<(sbyte part, bool inner)> _injuryMarkRandomPool = new List<(sbyte, bool)>();

	private readonly List<(sbyte type, sbyte part)> _notInjuryMarkRandomPool = new List<(sbyte, sbyte)>();

	public ErJianMoNvYi()
	{
	}

	public ErJianMoNvYi(CombatSkillKey skillKey)
		: base(skillKey, 17131, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_lastMarks = new DefeatMarkCollection(base.CombatChar.GetDefeatMarkCollection());
		_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			IsSrcSkillPerformed = true;
			AddMaxEffectCount();
			sbyte taskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(0).JuniorXiangshuTaskStatus;
			if (taskStatus <= 4)
			{
				return;
			}
			bool goodEnding = taskStatus == 6;
			Injuries injuries = base.CurrEnemyChar.GetInjuries();
			if (goodEnding)
			{
				Injuries oldInjuries = base.CurrEnemyChar.GetOldInjuries();
				List<(sbyte, bool)> injuryRandomPool = ObjectPool<List<(sbyte, bool)>>.Instance.Get();
				injuryRandomPool.Clear();
				for (sbyte part = 0; part < 7; part++)
				{
					for (int i = 0; i < injuries.Get(part, isInnerInjury: false); i++)
					{
						injuryRandomPool.Add((part, false));
					}
					for (int j = 0; j < injuries.Get(part, isInnerInjury: true); j++)
					{
						injuryRandomPool.Add((part, true));
					}
				}
				if (injuryRandomPool.Count > 0)
				{
					(sbyte, bool) injuryInfo = injuryRandomPool[context.Random.Next(injuryRandomPool.Count)];
					base.CurrEnemyChar.RemoveInjury(context, injuryInfo.Item1, injuryInfo.Item2, 1, updateDefeatMark: true, oldInjuries.Get(injuryInfo.Item1, injuryInfo.Item2) > 0);
				}
				ObjectPool<List<(sbyte, bool)>>.Instance.Return(injuryRandomPool);
			}
			else
			{
				bool outerFull = true;
				bool innerFull = true;
				for (sbyte part2 = 0; part2 < 7; part2++)
				{
					if (injuries.Get(part2, isInnerInjury: false) < 6)
					{
						outerFull = false;
					}
					if (injuries.Get(part2, isInnerInjury: true) < 6)
					{
						innerFull = false;
					}
					if (!outerFull && !innerFull)
					{
						break;
					}
				}
				bool canAddOuter = !base.CurrEnemyChar.GetOuterInjuryImmunity() && !outerFull;
				bool canAddInner = !base.CurrEnemyChar.GetInnerInjuryImmunity() && !innerFull;
				if (canAddOuter || canAddInner)
				{
					bool addInner = canAddInner && (!canAddOuter || context.Random.CheckPercentProb(50));
					base.CurrEnemyChar.AddRandomInjury(context, addInner, 1, changeToOld: true);
				}
			}
			ShowSpecialEffectTips(goodEnding, 1, 2);
		}
		else
		{
			RemoveSelf(context);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		int removeNotInjuryMarkCount = 0;
		int removeInjuryMarkCount = 0;
		_injuryMarkRandomPool.Clear();
		_notInjuryMarkRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			byte outerInjury = markCollection.OuterInjuryMarkList[part];
			byte innerInjury = markCollection.InnerInjuryMarkList[part];
			int flawCount = markCollection.FlawMarkList[part].Count;
			int acupointCount = markCollection.AcupointMarkList[part].Count;
			byte lastOuterInjury = _lastMarks.OuterInjuryMarkList[part];
			byte lastInnerInjury = _lastMarks.InnerInjuryMarkList[part];
			int lastFlawCount = _lastMarks.FlawMarkList[part].Count;
			int lastAcupointCount = _lastMarks.AcupointMarkList[part].Count;
			if (outerInjury > lastOuterInjury)
			{
				removeNotInjuryMarkCount += outerInjury - lastOuterInjury;
			}
			if (innerInjury > lastInnerInjury)
			{
				removeNotInjuryMarkCount += innerInjury - lastInnerInjury;
			}
			if (flawCount > lastFlawCount)
			{
				removeInjuryMarkCount += flawCount - lastFlawCount;
			}
			if (acupointCount > lastAcupointCount)
			{
				removeInjuryMarkCount += acupointCount - lastAcupointCount;
			}
			for (int i = 0; i < outerInjury; i++)
			{
				_injuryMarkRandomPool.Add((part, false));
			}
			for (int j = 0; j < innerInjury; j++)
			{
				_injuryMarkRandomPool.Add((part, true));
			}
			for (int k = 0; k < flawCount; k++)
			{
				_notInjuryMarkRandomPool.Add((0, part));
			}
			for (int l = 0; l < acupointCount; l++)
			{
				_notInjuryMarkRandomPool.Add((1, part));
			}
		}
		int mindCount = markCollection.MindMarkList.Count;
		int lastMindCount = _lastMarks.MindMarkList.Count;
		if (mindCount > lastMindCount)
		{
			removeInjuryMarkCount += mindCount - lastMindCount;
		}
		for (int m = 0; m < mindCount; m++)
		{
			_notInjuryMarkRandomPool.Add((2, -1));
		}
		removeNotInjuryMarkCount = Math.Min(removeNotInjuryMarkCount, _notInjuryMarkRandomPool.Count);
		removeInjuryMarkCount = Math.Min(removeInjuryMarkCount, _injuryMarkRandomPool.Count);
		int removeCount = Math.Min(removeNotInjuryMarkCount + removeInjuryMarkCount, base.EffectCount);
		if (removeCount <= 0)
		{
			return;
		}
		while (removeNotInjuryMarkCount + removeInjuryMarkCount > removeCount)
		{
			if (removeNotInjuryMarkCount > 0 && (removeInjuryMarkCount == 0 || context.Random.CheckPercentProb(50)))
			{
				removeNotInjuryMarkCount--;
			}
			else
			{
				removeInjuryMarkCount--;
			}
		}
		for (int n = 0; n < removeInjuryMarkCount; n++)
		{
			int index = context.Random.Next(_injuryMarkRandomPool.Count);
			(sbyte, bool) injuryInfo = _injuryMarkRandomPool[index];
			base.CombatChar.RemoveInjury(context, injuryInfo.Item1, injuryInfo.Item2);
			_injuryMarkRandomPool.RemoveAt(index);
		}
		for (int num = 0; num < removeNotInjuryMarkCount; num++)
		{
			int index2 = context.Random.Next(_notInjuryMarkRandomPool.Count);
			(sbyte, sbyte) markInfo = _notInjuryMarkRandomPool[index2];
			if (markInfo.Item1 == 0)
			{
				int flawIndex = context.Random.Next(markCollection.FlawMarkList[markInfo.Item2].Count);
				markCollection.FlawMarkList[markInfo.Item2].RemoveAt(flawIndex);
				DomainManager.Combat.RemoveFlaw(context, base.CombatChar, markInfo.Item2, flawIndex, raiseEvent: false, updateMark: false);
			}
			else if (markInfo.Item1 == 1)
			{
				int acupointIndex = context.Random.Next(markCollection.AcupointMarkList[markInfo.Item2].Count);
				markCollection.AcupointMarkList[markInfo.Item2].RemoveAt(acupointIndex);
				DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, markInfo.Item2, acupointIndex, raiseEvent: false, updateMark: false);
			}
			else if (markInfo.Item1 == 2)
			{
				base.CombatChar.RemoveMindMark(context, 1, random: true);
			}
			_notInjuryMarkRandomPool.RemoveAt(index2);
		}
		_lastMarks = new DefeatMarkCollection(base.CombatChar.GetDefeatMarkCollection());
		ReduceEffectCount(removeCount);
		DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
		ShowSpecialEffectTips(0);
	}
}
