using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;

public class ChaiShanYiXianTian : AgileSkillBase
{
	private const sbyte ReduceDamagePercent = -60;

	private short _castingLegSkill;

	private bool _affected;

	public ChaiShanYiXianTian()
	{
	}

	public ChaiShanYiXianTian(CombatSkillKey skillKey)
		: base(skillKey, 10503)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnCastLegSkillWithAgile(DataContext context, CombatCharacter combatChar, short legSkillId)
	{
		if (combatChar == base.CombatChar && !combatChar.GetAutoCastingSkill())
		{
			AutoRemove = false;
			_castingLegSkill = legSkillId;
			AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.AddPercent, -1);
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && base.CombatChar == defender)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && base.CombatChar == context.Defender)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _castingLegSkill)
		{
			ClearAffectedData(context);
			Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
			if (AgileSkillChanged)
			{
				RemoveSelf(context);
			}
			else
			{
				AutoRemove = true;
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			_affected = true;
			return -60;
		}
		return 0;
	}
}
