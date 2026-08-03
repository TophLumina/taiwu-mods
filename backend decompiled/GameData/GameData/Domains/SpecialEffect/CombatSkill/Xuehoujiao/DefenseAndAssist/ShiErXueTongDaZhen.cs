using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class ShiErXueTongDaZhen : AssistSkillBase
{
	public ShiErXueTongDaZhen()
	{
	}

	public ShiErXueTongDaZhen(CombatSkillKey skillKey)
		: base(skillKey, 15806)
	{
		SetConstAffectingOnCombatBegin = DomainManager.Combat.IsMainCharacter(base.CombatChar);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (DomainManager.Combat.IsMainCharacter(base.CombatChar))
		{
			base.CombatChar.TransferInjuryCommandIsInner = !base.IsDirect;
			base.CombatChar.SetShowTransferInjuryCommand(showTransferInjuryCommand: true, context);
		}
		else
		{
			Events.RegisterHandler_CombatBegin(OnCombatBegin);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		RemoveSelf(context);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		base.CombatChar.SetShowTransferInjuryCommand(base.CanAffect, context);
		SetConstAffecting(context, base.CanAffect);
	}
}
