using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class LingMaoZhuYing : AnimalEffectBase
{
	private int FightBackPower => base.IsElite ? 250 : 150;

	public LingMaoZhuYing()
	{
	}

	public LingMaoZhuYing(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 112, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 250, -1), EDataModifyType.Custom);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 112 || !DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			return 0;
		}
		return FightBackPower;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 250 || !DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return true;
	}
}
