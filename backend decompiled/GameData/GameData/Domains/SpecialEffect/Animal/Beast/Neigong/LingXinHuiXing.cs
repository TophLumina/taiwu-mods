using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class LingXinHuiXing : AnimalEffectBase
{
	private int ReducePower => base.IsElite ? (-20) : (-10);

	public LingXinHuiXing()
	{
	}

	public LingXinHuiXing(CombatSkillKey skillKey)
		: base(skillKey)
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
		CombatCharacter caster = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		if (!(caster.IsAlly == base.CombatChar.IsAlly || !base.IsCurrent || interrupted) && CombatSkillEquipType.IsAttack(skillId))
		{
			DomainManager.Combat.ReduceSkillPowerInCombat(context, (charId: charId, skillId: skillId), base.EffectKey, ReducePower);
			ShowSpecialEffectTips(0);
		}
	}
}
