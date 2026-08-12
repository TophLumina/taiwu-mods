using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class ChangePoisonLevelVariant1 : ChangePoisonLevel
{
	private const int AddGoneMadFactor = -50;

	protected ChangePoisonLevelVariant1()
	{
	}

	protected ChangePoisonLevelVariant1(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(217, EDataModifyType.Custom, -1);
			CreateAffectedData(215, EDataModifyType.Custom, -1);
		}
		else
		{
			Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (defender == base.CombatChar && AffectingSkillKey.IsMatch(attacker.GetId(), skillId))
		{
			DomainManager.Combat.AddGoneMadInjury(context, attacker, skillId, -50);
			ShowSpecialEffectTips(1);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.CombatSkillId != AffectingSkillKey.SkillTemplateId)
		{
			if (!(base.EffectCount > 0 && dataValue) || !IsMatchPoison(dataKey.CombatSkillId))
			{
				return dataValue;
			}
			ReduceEffectCount();
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 215 || fieldId == 217) ? true : false)
		{
			ShowSpecialEffectTips(1);
		}
		ushort fieldId2 = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId2 != 215 && fieldId2 != 217 && dataValue;
		if (1 == 0)
		{
		}
		return result;
	}
}
