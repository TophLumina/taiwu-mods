using System;
using Config.Common;

namespace Config;

[Serializable]
public class ZhujianCombatSkillToWeaponItem : ConfigItem<ZhujianCombatSkillToWeaponItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 功法id
	/// </summary>
	public readonly short CombatSkillId;

	/// <summary>
	/// 对应武器id
	/// </summary>
	public readonly short WeaponId;

	/// <summary>
	/// 特效id
	/// </summary>
	public readonly short EffectId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="combatSkillId">功法id</param>
	/// <param name="weaponId">对应武器id</param>
	/// <param name="effectId">特效id</param>
	public ZhujianCombatSkillToWeaponItem(int templateId, short combatSkillId, short weaponId, short effectId)
	{
		TemplateId = templateId;
		CombatSkillId = combatSkillId;
		WeaponId = weaponId;
		EffectId = effectId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ZhujianCombatSkillToWeaponItem()
	{
		TemplateId = 0;
		CombatSkillId = 0;
		WeaponId = 0;
		EffectId = 55;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ZhujianCombatSkillToWeaponItem Duplicate(int templateId)
	{
		return new ZhujianCombatSkillToWeaponItem(templateId, this);
	}
}
