using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class PuppetItem : ConfigItem<PuppetItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly EPuppetType Type;

	public readonly string Avatar;

	public readonly sbyte SectId;

	public readonly short CharacterId;

	public readonly short CombatConfig;

	public readonly List<sbyte> Difficulties;

	public OrganizationItem Sect
	{
		[return: MaybeNull]
		get
		{
			return Organization.Instance.GetItemOrDefault(SectId);
		}
	}

	public CharacterItem Character
	{
		[return: MaybeNull]
		get
		{
			return Config.Character.Instance.GetItemOrDefault(CharacterId);
		}
	}

	public PuppetItem(short templateId, string name, string desc, EPuppetType type, string avatar, sbyte sectId, short characterId, short combatConfig, List<sbyte> difficulties)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Type = type;
		Avatar = avatar;
		SectId = sectId;
		CharacterId = characterId;
		CombatConfig = combatConfig;
		Difficulties = difficulties;
	}

	public PuppetItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Type = EPuppetType.Invalid;
		Avatar = null;
		SectId = 0;
		CharacterId = 0;
		CombatConfig = 2;
		Difficulties = null;
	}

	public PuppetItem(short templateId, PuppetItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Type = other.Type;
		Avatar = other.Avatar;
		SectId = other.SectId;
		CharacterId = other.CharacterId;
		CombatConfig = other.CombatConfig;
		Difficulties = other.Difficulties;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PuppetItem Duplicate(int templateId)
	{
		return new PuppetItem((short)templateId, this);
	}
}
