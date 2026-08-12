using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class RuWangMingXiang : CombatSkillEffectBase
{
	private const sbyte AffectFrameCount = 60;

	private int _frameCounter;

	public RuWangMingXiang()
	{
	}

	public RuWangMingXiang(CombatSkillKey skillKey)
		: base(skillKey, 17092, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
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
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (enemyChar.GetCharacter().GetXiangshuInfection() < 200)
			{
				enemyChar.GetCharacter().ChangeXiangshuInfection(context, 1 + enemyChar.OriginXiangshuInfection * 10 / 100);
			}
			ShowSpecialEffectTips(0);
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
