using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class WuXingXiaoQinNa : CombatSkillEffectBase
{
	private const sbyte ReduceBreathStanceUnit = 3;

	public WuXingXiaoQinNa()
	{
	}

	public WuXingXiaoQinNa(CombatSkillKey skillKey)
		: base(skillKey, 13100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (power > 0)
		{
			if (base.IsDirect)
			{
				ChangeStanceValue(context, base.CurrEnemyChar, -12000 * power / 1000);
			}
			else
			{
				ChangeBreathValue(context, base.CurrEnemyChar, -90000 * power / 1000);
			}
			ShowSpecialEffectTips(0);
		}
		RemoveSelf(context);
	}
}
