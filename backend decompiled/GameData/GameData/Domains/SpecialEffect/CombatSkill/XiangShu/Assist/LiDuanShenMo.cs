using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class LiDuanShenMo : RanChenZiAssistSkillBase
{
	public LiDuanShenMo()
	{
	}

	public LiDuanShenMo(CombatSkillKey skillKey)
		: base(skillKey, 16412)
	{
		RequireBossPhase = 2;
	}

	protected override void ActivateEffect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 148, EDataModifyType.Custom, -1);
		AppendAffectedData(context, base.CharacterId, 215, EDataModifyType.Custom, -1);
		AppendAffectedData(context, base.CharacterId, 126, EDataModifyType.Custom, -1);
		AppendAffectedData(context, base.CharacterId, 131, EDataModifyType.Custom, -1);
	}

	protected override void DeactivateEffect(DataContext context)
	{
		ClearAffectedData(context);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		if (dataKey.CombatSkillId != base.SkillTemplateId && base.CombatChar.GetBossPhase() != RequireBossPhase)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return false;
	}
}
