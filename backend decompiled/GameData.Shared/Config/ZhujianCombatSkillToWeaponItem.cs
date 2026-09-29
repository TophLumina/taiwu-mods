using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class ZhujianCombatSkillToWeaponItem : ConfigItem<ZhujianCombatSkillToWeaponItem, int>
{
	public readonly int TemplateId;

	public readonly short CombatSkillId;

	public readonly short WeaponId;

	public readonly short EffectId;

	public CombatSkillItem CombatSkill
	{
		[return: MaybeNull]
		get
		{
			return Config.CombatSkill.Instance.GetItemOrDefault(CombatSkillId);
		}
	}

	public WeaponItem Weapon
	{
		[return: MaybeNull]
		get
		{
			return Config.Weapon.Instance.GetItemOrDefault(WeaponId);
		}
	}

	public EquipmentEffectItem Effect
	{
		[return: MaybeNull]
		get
		{
			return EquipmentEffect.Instance.GetItemOrDefault(EffectId);
		}
	}

	public ZhujianCombatSkillToWeaponItem(int templateId, short combatSkillId, short weaponId, short effectId)
	{
		TemplateId = templateId;
		CombatSkillId = combatSkillId;
		WeaponId = weaponId;
		EffectId = effectId;
	}

	public ZhujianCombatSkillToWeaponItem()
	{
		TemplateId = 0;
		CombatSkillId = 0;
		WeaponId = 0;
		EffectId = 55;
	}

	public ZhujianCombatSkillToWeaponItem(int templateId, ZhujianCombatSkillToWeaponItem other)
	{
		TemplateId = templateId;
		CombatSkillId = other.CombatSkillId;
		WeaponId = other.WeaponId;
		EffectId = other.EffectId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ZhujianCombatSkillToWeaponItem Duplicate(int templateId)
	{
		return new ZhujianCombatSkillToWeaponItem(templateId, this);
	}
}
