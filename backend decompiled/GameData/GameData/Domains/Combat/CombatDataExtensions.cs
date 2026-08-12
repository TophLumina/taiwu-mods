using Config;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat;

public static class CombatDataExtensions
{
	public static WeaponEffectDisplayData GetWeaponEffectDisplayData(this SkillEffectKey effectKey, int charId)
	{
		WeaponEffectDisplayData result = new WeaponEffectDisplayData
		{
			EffectKey = effectKey
		};
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: effectKey.SkillId), out var skill))
		{
			result.EffectDescription = DomainManager.CombatSkill.GetEffectDisplayData(skill);
		}
		else if (effectKey.SkillId >= 0)
		{
			result.EffectDescription = new CombatSkillEffectDescriptionDisplayData
			{
				EffectId = (effectKey.IsDirect ? Config.CombatSkill.Instance[effectKey.SkillId].DirectEffectID : Config.CombatSkill.Instance[effectKey.SkillId].ReverseEffectID)
			};
		}
		else
		{
			result.EffectDescription = CombatSkillEffectDescriptionDisplayData.Invalid;
		}
		return result;
	}

	public static CombatProperty GetProperty(this DamageCompareData data, int index = 0)
	{
		return new CombatProperty
		{
			HitValue = data.HitValue[index],
			AvoidValue = data.AvoidValue[index],
			AttackValue = new OuterAndInnerInts(data.OuterAttackValue, data.InnerAttackValue),
			DefendValue = new OuterAndInnerInts(data.OuterDefendValue, data.InnerDefendValue),
			WeaponAttack = data.WeaponAttack,
			WeaponDefend = data.WeaponDefend,
			ArmorAttack = data.ArmorAttack,
			ArmorDefend = data.ArmorDefend
		};
	}

	public static int GetNeiliAllocationPowerAddPercent(this CombatSkillKey skillKey)
	{
		if (!DomainManager.Combat.IsInCombat() || skillKey.SkillTemplateId < 0)
		{
			return 0;
		}
		if (!DomainManager.Combat.TryGetElement_CombatCharacterDict(skillKey.CharId, out var combatChar))
		{
			return 0;
		}
		CombatSkillItem configData = Config.CombatSkill.Instance[skillKey.SkillTemplateId];
		ENeiliAllocationStatusType status = combatChar.GetRelatedNeiliAllocationStatus(configData);
		return status.GetConfig().PowerAddPercent;
	}
}
