using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class SheMingShi : CombatSkillEffectBase
{
	private const sbyte MaxReduceMark = 3;

	private Dictionary<int, (int mind, int die)> _enemyLastMarkCount;

	private readonly List<DataUid> _defeatMarkUids = new List<DataUid>();

	public SheMingShi()
	{
	}

	public SheMingShi(CombatSkillKey skillKey)
		: base(skillKey, 17054, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		foreach (DataUid dataUid in _defeatMarkUids)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(dataUid, base.DataHandlerKey);
		}
		_defeatMarkUids.Clear();
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		List<(sbyte, sbyte)> markRandomPool = new List<(sbyte, sbyte)>();
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		markRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			int flawCount = markCollection.FlawMarkList[part].Count;
			int acupointCount = markCollection.AcupointMarkList[part].Count;
			for (int i = 0; i < flawCount; i++)
			{
				markRandomPool.Add((0, part));
			}
			for (int j = 0; j < acupointCount; j++)
			{
				markRandomPool.Add((1, part));
			}
		}
		int mindCount = markCollection.MindMarkList.Count;
		for (int k = 0; k < mindCount; k++)
		{
			markRandomPool.Add((2, -1));
		}
		if (!IsSrcSkillPerformed)
		{
			if (markRandomPool.Count > 0 && !interrupted)
			{
				while (markRandomPool.Count > 3)
				{
					markRandomPool.RemoveAt(context.Random.Next(markRandomPool.Count));
				}
				for (int l = 0; l < markRandomPool.Count; l++)
				{
					(sbyte, sbyte) markInfo = markRandomPool[l];
					if (markInfo.Item1 == 0)
					{
						int flawCount2 = markCollection.FlawMarkList[markInfo.Item2].Count;
						int flawIndex = context.Random.Next(flawCount2);
						markCollection.FlawMarkList[markInfo.Item2].RemoveAt(flawIndex);
						DomainManager.Combat.RemoveFlaw(context, base.CombatChar, markInfo.Item2, flawIndex, raiseEvent: false, updateMark: false);
					}
					else if (markInfo.Item1 == 1)
					{
						int acupointCount2 = markCollection.AcupointMarkList[markInfo.Item2].Count;
						int acupointIndex = context.Random.Next(acupointCount2);
						markCollection.AcupointMarkList[markInfo.Item2].RemoveAt(acupointIndex);
						DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, markInfo.Item2, acupointIndex, raiseEvent: false, updateMark: false);
					}
					else if (markInfo.Item1 == 2)
					{
						base.CombatChar.RemoveMindMark(context, 1, random: false);
					}
				}
				base.CombatChar.SetDefeatMarkCollection(markCollection, context);
				IsSrcSkillPerformed = true;
				short effectCount = (short)(markRandomPool.Count * 2);
				DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), effectCount, effectCount, autoRemoveOnNoCount: true);
				AppendAffectedAllEnemyData(context, 129, EDataModifyType.Add, -1);
				AppendAffectedAllEnemyData(context, 134, EDataModifyType.Add, -1);
				_enemyLastMarkCount = new Dictionary<int, (int, int)>();
				int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
				foreach (int enemyId in enemyList)
				{
					if (enemyId >= 0)
					{
						DataUid defeatMarkUid = new DataUid(8, 10, (ulong)enemyId, 50u);
						DefeatMarkCollection enemyMarks = DomainManager.Combat.GetElement_CombatCharacterDict(enemyId).GetDefeatMarkCollection();
						_enemyLastMarkCount[enemyId] = (enemyMarks.MindMarkList?.Count ?? 0, enemyMarks.DieMarkList?.Count ?? 0);
						GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
						_defeatMarkUids.Add(defeatMarkUid);
					}
				}
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (markRandomPool.Count > 0 && !interrupted)
		{
			RemoveSelf(context);
		}
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		int enemyId = (int)dataUid.SubId0;
		CombatCharacter enemyChar = DomainManager.Combat.GetElement_CombatCharacterDict(enemyId);
		DefeatMarkCollection markCollection = enemyChar.GetDefeatMarkCollection();
		bool hasNewMindMark = (markCollection.MindMarkList?.Count ?? 0) > _enemyLastMarkCount[enemyId].mind;
		if (hasNewMindMark && (base.EffectCount > 1 || context.Random.CheckPercentProb(50)))
		{
			enemyChar.AddMindMark(context, 1, -1);
			ReduceEffectCount();
		}
		if (hasNewMindMark)
		{
			DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
			ShowSpecialEffectTips(0);
		}
		_enemyLastMarkCount[enemyId] = (markCollection.MindMarkList?.Count ?? 0, markCollection.DieMarkList?.Count ?? 0);
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 134 || dataKey.FieldId == 129)
		{
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
			return 1;
		}
		return 0;
	}
}
