using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class PoisonAddInjury : CombatSkillEffectBase
{
	private const int AddDamagePercentUnit = 15;

	protected sbyte RequirePoisonType;

	private int _addDamagePercent;

	protected virtual bool AutoRemove => true;

	public PoisonAddInjury()
	{
	}

	public PoisonAddInjury(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			_addDamagePercent = 15 * (base.IsDirect ? defender : attacker).GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
			if (_addDamagePercent > 0)
			{
				ShowSpecialEffectTips(0);
			}
		}
		OnCastOwnBegin(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				OnCastMaxPower(context);
			}
			if (AutoRemove)
			{
				RemoveSelf(context);
			}
			else
			{
				_addDamagePercent = 0;
			}
		}
	}

	protected virtual void OnCastOwnBegin(DataContext context)
	{
	}

	protected virtual void OnCastMaxPower(DataContext context)
	{
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return _addDamagePercent;
		}
		return GetModifyValueInternal(dataKey, currModifyValue);
	}

	protected virtual int GetModifyValueInternal(AffectedDataKey dataKey, int currModifyValue)
	{
		return 0;
	}
}
