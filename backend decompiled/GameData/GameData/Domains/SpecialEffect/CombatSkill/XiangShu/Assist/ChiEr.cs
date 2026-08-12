using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class ChiEr : RanChenZiAssistSkillBase
{
	public ChiEr()
	{
	}

	public ChiEr(CombatSkillKey skillKey)
		: base(skillKey, 16414)
	{
		RequireBossPhase = 4;
	}

	protected override void ActivateEffect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 287, EDataModifyType.Custom, -1);
	}

	protected override void DeactivateEffect(DataContext context)
	{
		ClearAffectedData(context);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 287)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
