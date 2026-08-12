using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class TouGuQiePouFa : AssistSkillBase
{
	private const sbyte AddDamagePercent = 45;

	private bool _canAffect;

	private bool _affected;

	public TouGuQiePouFa()
	{
	}

	public TouGuQiePouFa(CombatSkillKey skillKey)
		: base(skillKey, 10702)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_canAffect = base.CanAffect && base.IsCurrent && IsBodyPartCanAffect(base.CombatChar.NormalAttackBodyPart);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_canAffect = false;
			if (_affected)
			{
				_affected = false;
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId)
		{
			_canAffect = base.CanAffect && base.IsCurrent && IsBodyPartCanAffect(base.CombatChar.SkillAttackBodyPart);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.AttackerId == base.CharacterId && _affected)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId)
		{
			_canAffect = false;
		}
	}

	private bool IsBodyPartCanAffect(sbyte bodyPart)
	{
		if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
		{
			return false;
		}
		(sbyte, sbyte) injuries = base.CurrEnemyChar.GetInjuries().Get(bodyPart);
		return injuries.Item1 <= 0 && injuries.Item2 <= 0;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_canAffect || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0) || dataKey.FieldId != 69)
		{
			return 0;
		}
		_affected = true;
		return 45;
	}
}
