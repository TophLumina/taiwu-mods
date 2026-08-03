using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class YiZiHunYuanZhuang : CombatSkillEffectBase
{
	public YiZiHunYuanZhuang()
	{
	}

	public YiZiHunYuanZhuang(CombatSkillKey skillKey)
		: base(skillKey, 4002, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (base.CharacterId == charId && (base.IsDirect ? costStance : costBreath) <= 0)
		{
			if (base.IsDirect && costBreath > 0 && base.CombatChar.GetStanceValue() < base.CombatChar.GetMaxStanceValue())
			{
				int percent = costBreath * 100 / base.CombatChar.GetMaxBreathValue();
				ChangeStanceValue(context, base.CombatChar, base.CombatChar.GetMaxStanceValue() * percent / 100);
				ShowSpecialEffectTips(0);
			}
			else if (!base.IsDirect && costStance > 0 && base.CombatChar.GetBreathValue() < base.CombatChar.GetMaxBreathValue())
			{
				int percent2 = costStance * 100 / base.CombatChar.GetMaxStanceValue();
				ChangeBreathValue(context, base.CombatChar, base.CombatChar.GetMaxBreathValue() * percent2 / 100);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
