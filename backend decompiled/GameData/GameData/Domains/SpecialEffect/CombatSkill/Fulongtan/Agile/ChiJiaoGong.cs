using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Agile;

public class ChiJiaoGong : AgileSkillBase
{
	private const int ChangeMoveCostMobilityPercent = 50;

	public ChiJiaoGong()
	{
	}

	public ChiJiaoGong(CombatSkillKey skillKey)
		: base(skillKey, 14400)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 148, -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
	}

	public override void OnDataAdded(DataContext context)
	{
		base.OnDataAdded(context);
		AppendAffectedAllEnemyData(context, 175, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 175)
		{
			CombatCharacter moveChar = DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId);
			if (base.IsDirect ? moveChar.MoveForward : (!moveChar.MoveForward))
			{
				return 0;
			}
			return 50;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 148)
		{
			CValueDistanceDelta addDistance = dataKey.CustomParam0;
			if (base.IsDirect ? addDistance.IsForward : addDistance.IsBackward)
			{
				return dataValue;
			}
			return false;
		}
		return dataValue;
	}
}
