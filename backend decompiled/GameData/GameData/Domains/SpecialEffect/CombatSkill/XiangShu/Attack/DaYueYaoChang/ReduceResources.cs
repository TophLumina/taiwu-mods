using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class ReduceResources : CombatSkillEffectBase
{
	private const sbyte ReducePercent = 20;

	protected short AffectFrameCount;

	private int _frameCounter;

	protected ReduceResources()
	{
	}

	protected ReduceResources(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
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
		if (base.CombatChar == combatChar && !DomainManager.Combat.Pause)
		{
			_frameCounter++;
			if (_frameCounter >= AffectFrameCount && DomainManager.Combat.InAttackRange(base.CombatChar))
			{
				_frameCounter = 0;
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				ChangeBreathValue(context, enemyChar, -6000);
				ChangeStanceValue(context, enemyChar, -800);
				ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility * 20 / 100);
				ShowSpecialEffectTips(0);
			}
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
