using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class HengXingWuJi : AnimalEffectBase
{
	private int BouncePower => base.IsElite ? 160 : 80;

	public HengXingWuJi()
	{
	}

	public HengXingWuJi(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 111, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 177, -1), EDataModifyType.Custom);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 111)
		{
			return 0;
		}
		if (!DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			return 0;
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return BouncePower;
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 177)
		{
			return dataValue;
		}
		CombatConfigItem combatConfig = DomainManager.Combat.CombatConfig;
		return new OuterAndInnerInts(combatConfig.MinDistance, combatConfig.MaxDistance);
	}
}
