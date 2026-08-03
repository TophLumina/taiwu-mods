using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class XuanTianYiShe : AnimalEffectBase
{
	private const sbyte AutoHealSpeed = 1;

	public XuanTianYiShe()
	{
	}

	public XuanTianYiShe(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatBegin(DataContext context)
	{
		base.CombatChar.OuterInjuryAutoHealSpeeds.Add(1);
		base.CombatChar.InnerInjuryAutoHealSpeeds.Add(1);
	}
}
