using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PunishmentSeverityItem : ConfigItem<PunishmentSeverityItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte ResourceConfiscation;

	public readonly sbyte ItemConfiscation;

	public readonly sbyte CombatSkillRevoke;

	public readonly int PrisonTime;

	public readonly bool Expel;

	public readonly int BountyDuration;

	public readonly int FameActionFactorInPunish;

	public readonly sbyte[] EscapePunishmentChance;

	public readonly short[] EscapeActions;

	public readonly int CommonAuthorityDelta;

	public readonly int CommonSpiritualDebtDelta;

	public readonly short ShaolinDelta;

	public readonly List<int> YuanshanDelta;

	public readonly short ZhujianDelta;

	public readonly int KongsangDelta;

	public readonly int WuxianDelta;

	public readonly int XuehouDelta;

	public readonly string Name;

	public readonly string NameColor;

	public readonly string PunishmentDesc;

	public readonly short NormalRecord;

	public readonly short ArrestedRecord;

	public PunishmentSeverityItem(sbyte templateId, sbyte resourceConfiscation, sbyte itemConfiscation, sbyte combatSkillRevoke, int prisonTime, bool expel, int bountyDuration, int fameActionFactorInPunish, sbyte[] escapePunishmentChance, short[] escapeActions, int commonAuthorityDelta, int commonSpiritualDebtDelta, short shaolinDelta, List<int> yuanshanDelta, short zhujianDelta, int kongsangDelta, int wuxianDelta, int xuehouDelta, string name, string nameColor, string punishmentDesc, short normalRecord, short arrestedRecord)
	{
		TemplateId = templateId;
		ResourceConfiscation = resourceConfiscation;
		ItemConfiscation = itemConfiscation;
		CombatSkillRevoke = combatSkillRevoke;
		PrisonTime = prisonTime;
		Expel = expel;
		BountyDuration = bountyDuration;
		FameActionFactorInPunish = fameActionFactorInPunish;
		EscapePunishmentChance = escapePunishmentChance;
		EscapeActions = escapeActions;
		CommonAuthorityDelta = commonAuthorityDelta;
		CommonSpiritualDebtDelta = commonSpiritualDebtDelta;
		ShaolinDelta = shaolinDelta;
		YuanshanDelta = yuanshanDelta;
		ZhujianDelta = zhujianDelta;
		KongsangDelta = kongsangDelta;
		WuxianDelta = wuxianDelta;
		XuehouDelta = xuehouDelta;
		Name = name;
		NameColor = nameColor;
		PunishmentDesc = punishmentDesc;
		NormalRecord = normalRecord;
		ArrestedRecord = arrestedRecord;
	}

	public PunishmentSeverityItem()
	{
		TemplateId = 0;
		ResourceConfiscation = 0;
		ItemConfiscation = 0;
		CombatSkillRevoke = 0;
		PrisonTime = 0;
		Expel = false;
		BountyDuration = 6;
		FameActionFactorInPunish = 0;
		EscapePunishmentChance = new sbyte[5] { 50, 50, 50, 50, 50 };
		EscapeActions = new short[0];
		CommonAuthorityDelta = 0;
		CommonSpiritualDebtDelta = 0;
		ShaolinDelta = 0;
		YuanshanDelta = new List<int>();
		ZhujianDelta = 0;
		KongsangDelta = 0;
		WuxianDelta = 0;
		XuehouDelta = 0;
		Name = null;
		NameColor = null;
		PunishmentDesc = null;
		NormalRecord = 0;
		ArrestedRecord = 0;
	}

	public PunishmentSeverityItem(sbyte templateId, PunishmentSeverityItem other)
	{
		TemplateId = templateId;
		ResourceConfiscation = other.ResourceConfiscation;
		ItemConfiscation = other.ItemConfiscation;
		CombatSkillRevoke = other.CombatSkillRevoke;
		PrisonTime = other.PrisonTime;
		Expel = other.Expel;
		BountyDuration = other.BountyDuration;
		FameActionFactorInPunish = other.FameActionFactorInPunish;
		EscapePunishmentChance = other.EscapePunishmentChance;
		EscapeActions = other.EscapeActions;
		CommonAuthorityDelta = other.CommonAuthorityDelta;
		CommonSpiritualDebtDelta = other.CommonSpiritualDebtDelta;
		ShaolinDelta = other.ShaolinDelta;
		YuanshanDelta = other.YuanshanDelta;
		ZhujianDelta = other.ZhujianDelta;
		KongsangDelta = other.KongsangDelta;
		WuxianDelta = other.WuxianDelta;
		XuehouDelta = other.XuehouDelta;
		Name = other.Name;
		NameColor = other.NameColor;
		PunishmentDesc = other.PunishmentDesc;
		NormalRecord = other.NormalRecord;
		ArrestedRecord = other.ArrestedRecord;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PunishmentSeverityItem Duplicate(int templateId)
	{
		return new PunishmentSeverityItem((sbyte)templateId, this);
	}
}
