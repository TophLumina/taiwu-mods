using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AttackBodyPart : CombatSkillEffectBase
{
	protected sbyte[] BodyParts;

	protected sbyte ReverseAddDamagePercent;

	private bool _affected;

	protected AttackBodyPart()
	{
	}

	protected AttackBodyPart(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 77, base.SkillTemplateId), EDataModifyType.Custom);
		}
		if (!base.IsDirect)
		{
			Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId)
		{
			AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (!interrupted && !base.IsDirect && PowerMatchAffectRequire(power))
			{
				OnCastAffectPower(context);
			}
			if (_affected)
			{
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 77)
		{
			return dataValue;
		}
		sbyte bodyPart = (sbyte)dataKey.CustomParam1;
		if (!BodyParts.Exist(bodyPart))
		{
			return dataValue;
		}
		_affected = true;
		return true;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 69 && dataKey.CombatSkillId == base.SkillTemplateId && BodyParts.Exist((sbyte)dataKey.CustomParam1))
		{
			_affected = true;
			return ReverseAddDamagePercent;
		}
		return 0;
	}

	protected virtual void OnCastAffectPower(DataContext context)
	{
	}
}
