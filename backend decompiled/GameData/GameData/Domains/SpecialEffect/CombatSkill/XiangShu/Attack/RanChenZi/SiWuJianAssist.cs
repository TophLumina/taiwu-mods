using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class SiWuJianAssist : CombatSkillEffectBase
{
	private const sbyte ChangePower = 50;

	private readonly bool _goodEnding;

	public SiWuJianAssist()
	{
	}

	public SiWuJianAssist(CombatSkillKey skillKey, bool goodEnding)
		: base(skillKey, 17136, -1)
	{
		_goodEnding = goodEnding;
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.TotalPercent, base.SkillTemplateId);
	}

	public override void OnDisable(DataContext context)
	{
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _goodEnding ? (-50) : 50;
		}
		return 0;
	}
}
