using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuBeHuntedEventItem : ConfigItem<TaiwuBeHuntedEventItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string HeadEvent;

	public readonly string ResistEvent;

	public readonly string ResistWinEvent;

	public readonly string ResistLoseEvent;

	public readonly string PersuadeEvent;

	public readonly List<sbyte> LifeSkillCombatTypes;

	public readonly string PersuadeWinEvent;

	public readonly string PersuadeLoseEvent;

	public readonly string BribeEvent;

	public readonly string BribeConfirmEvent;

	public readonly string SurrenderEvent;

	public readonly string PunishEvent1;

	public readonly string PunishEvent2;

	public readonly string PunishEvent3;

	public readonly string PunishEvent4;

	public TaiwuBeHuntedEventItem(short templateId, string name, string headEvent, string resistEvent, string resistWinEvent, string resistLoseEvent, string persuadeEvent, List<sbyte> lifeSkillCombatTypes, string persuadeWinEvent, string persuadeLoseEvent, string bribeEvent, string bribeConfirmEvent, string surrenderEvent, string punishEvent1, string punishEvent2, string punishEvent3, string punishEvent4)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		ResistEvent = resistEvent;
		ResistWinEvent = resistWinEvent;
		ResistLoseEvent = resistLoseEvent;
		PersuadeEvent = persuadeEvent;
		LifeSkillCombatTypes = lifeSkillCombatTypes;
		PersuadeWinEvent = persuadeWinEvent;
		PersuadeLoseEvent = persuadeLoseEvent;
		BribeEvent = bribeEvent;
		BribeConfirmEvent = bribeConfirmEvent;
		SurrenderEvent = surrenderEvent;
		PunishEvent1 = punishEvent1;
		PunishEvent2 = punishEvent2;
		PunishEvent3 = punishEvent3;
		PunishEvent4 = punishEvent4;
	}

	public TaiwuBeHuntedEventItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		ResistEvent = null;
		ResistWinEvent = null;
		ResistLoseEvent = null;
		PersuadeEvent = null;
		LifeSkillCombatTypes = null;
		PersuadeWinEvent = null;
		PersuadeLoseEvent = null;
		BribeEvent = null;
		BribeConfirmEvent = null;
		SurrenderEvent = null;
		PunishEvent1 = null;
		PunishEvent2 = null;
		PunishEvent3 = null;
		PunishEvent4 = null;
	}

	public TaiwuBeHuntedEventItem(short templateId, TaiwuBeHuntedEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		ResistEvent = other.ResistEvent;
		ResistWinEvent = other.ResistWinEvent;
		ResistLoseEvent = other.ResistLoseEvent;
		PersuadeEvent = other.PersuadeEvent;
		LifeSkillCombatTypes = other.LifeSkillCombatTypes;
		PersuadeWinEvent = other.PersuadeWinEvent;
		PersuadeLoseEvent = other.PersuadeLoseEvent;
		BribeEvent = other.BribeEvent;
		BribeConfirmEvent = other.BribeConfirmEvent;
		SurrenderEvent = other.SurrenderEvent;
		PunishEvent1 = other.PunishEvent1;
		PunishEvent2 = other.PunishEvent2;
		PunishEvent3 = other.PunishEvent3;
		PunishEvent4 = other.PunishEvent4;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaiwuBeHuntedEventItem Duplicate(int templateId)
	{
		return new TaiwuBeHuntedEventItem((short)templateId, this);
	}
}
