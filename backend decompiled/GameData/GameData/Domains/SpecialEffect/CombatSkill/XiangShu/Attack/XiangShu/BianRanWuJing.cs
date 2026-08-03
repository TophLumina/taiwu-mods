using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class BianRanWuJing : CombatSkillEffectBase
{
	private const sbyte AffectFrameCount = 60;

	private int _frameCounter;

	public BianRanWuJing()
	{
	}

	public BianRanWuJing(CombatSkillKey skillKey)
		: base(skillKey, 17095, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= 60 && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			_frameCounter = 0;
			CombatCharacter enemyChar = base.CurrEnemyChar;
			if (enemyChar.GetCharacter().GetXiangshuInfection() < 200)
			{
				enemyChar.GetCharacter().ChangeXiangshuInfection(context, 1 + enemyChar.OriginXiangshuInfection * 10 / 100);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && index == 2 && CombatCharPowerMatchAffectRequire() && context.Defender.GetCharacter().GetXiangshuInfection() >= 200 && !context.Defender.Immortal)
		{
			context.Defender.ForceDefeat = true;
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
