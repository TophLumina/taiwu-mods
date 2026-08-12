using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongWoodImplementRange : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const int MinRangeSpace = 2;

	private readonly int _markToReduceRange;

	private readonly int _markToAddRange;

	private DataUid _defeatMarkUid;

	private int _injuryMarkCount;

	public CombatSkillEffectBase EffectBase { get; set; }

	public LoongWoodImplementRange(int markToReduceRange, int markToAddRange)
	{
		_markToReduceRange = markToReduceRange;
		_markToAddRange = markToAddRange;
	}

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedData(145, EDataModifyType.Add, -1);
		EffectBase.CreateAffectedData(146, EDataModifyType.Add, -1);
		EffectBase.CreateAffectedAllEnemyData(272, EDataModifyType.Add, -1);
		_defeatMarkUid = new DataUid(8, 10, (ulong)EffectBase.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, EffectBase.DataHandlerKey, OnDefeatMarkChanged);
	}

	public void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, EffectBase.DataHandlerKey);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid _)
	{
		DefeatMarkCollection defeatMarkCollection = EffectBase.CombatChar.GetDefeatMarkCollection();
		int injuryMarkCount = defeatMarkCollection.GetTotalInjuryCount();
		if (injuryMarkCount == _injuryMarkCount)
		{
			return;
		}
		_injuryMarkCount = injuryMarkCount;
		DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 145);
		DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 146);
		int[] enemyTeam = DomainManager.Combat.GetCharacterList(!EffectBase.CombatChar.IsAlly);
		int[] array = enemyTeam;
		foreach (int enemyCharId in array)
		{
			if (enemyCharId >= 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 272);
			}
		}
	}

	public int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 145) <= 1u;
		if (flag && dataKey.CharId == EffectBase.CharacterId)
		{
			return _injuryMarkCount * _markToAddRange;
		}
		if (dataKey.FieldId == 272 && dataKey.CharId != EffectBase.CharacterId)
		{
			int minDist = dataKey.CustomParam0;
			int maxDist = dataKey.CustomParam1;
			int remainDist = maxDist - minDist;
			return Math.Min((remainDist - 2) / 2, _injuryMarkCount * _markToReduceRange);
		}
		return 0;
	}
}
