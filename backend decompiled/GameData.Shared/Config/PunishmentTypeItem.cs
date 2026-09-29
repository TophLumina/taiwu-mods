using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class PunishmentTypeItem : ConfigItem<PunishmentTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string ShortName;

	public readonly EPunishmentTypeDisplayType DisplayType;

	public readonly sbyte Severity;

	public readonly bool IsPermanent;

	public readonly string PunishmentDesc;

	public readonly string Image;

	public readonly List<ShortPair> SectPunishmentSeverities;

	public readonly List<ShortPair> CivilianPunishmentSeverities;

	public readonly int ModifySeverityAuthorityCost;

	public readonly uint DlcAppId;

	public PunishmentTypeItem(short templateId, string name, string shortName, EPunishmentTypeDisplayType displayType, sbyte severity, bool isPermanent, string punishmentDesc, string image, List<ShortPair> sectPunishmentSeverities, List<ShortPair> civilianPunishmentSeverities, int modifySeverityAuthorityCost, uint dlcAppId)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		DisplayType = displayType;
		Severity = severity;
		IsPermanent = isPermanent;
		PunishmentDesc = punishmentDesc;
		Image = image;
		SectPunishmentSeverities = sectPunishmentSeverities;
		CivilianPunishmentSeverities = civilianPunishmentSeverities;
		ModifySeverityAuthorityCost = modifySeverityAuthorityCost;
		DlcAppId = dlcAppId;
	}

	public PunishmentTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		DisplayType = EPunishmentTypeDisplayType.Criminal;
		Severity = 0;
		IsPermanent = false;
		PunishmentDesc = null;
		Image = null;
		SectPunishmentSeverities = new List<ShortPair>();
		CivilianPunishmentSeverities = new List<ShortPair>();
		ModifySeverityAuthorityCost = 0;
		DlcAppId = 0u;
	}

	public PunishmentTypeItem(short templateId, PunishmentTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		DisplayType = other.DisplayType;
		Severity = other.Severity;
		IsPermanent = other.IsPermanent;
		PunishmentDesc = other.PunishmentDesc;
		Image = other.Image;
		SectPunishmentSeverities = other.SectPunishmentSeverities;
		CivilianPunishmentSeverities = other.CivilianPunishmentSeverities;
		ModifySeverityAuthorityCost = other.ModifySeverityAuthorityCost;
		DlcAppId = other.DlcAppId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PunishmentTypeItem Duplicate(int templateId)
	{
		return new PunishmentTypeItem((short)templateId, this);
	}

	public sbyte GetSeverity(sbyte stateTemplateId, bool isSect, bool includeDefault = false)
	{
		sbyte defaultSeverity = (sbyte)(includeDefault ? Severity : (-1));
		if (isSect)
		{
			List<ShortPair> sectPunishmentSeverities = SectPunishmentSeverities;
			if (sectPunishmentSeverities == null || sectPunishmentSeverities.Count <= 0)
			{
				return defaultSeverity;
			}
			foreach (ShortPair severity in SectPunishmentSeverities)
			{
				if (severity.First == stateTemplateId)
				{
					return (sbyte)severity.Second;
				}
			}
		}
		else
		{
			List<ShortPair> sectPunishmentSeverities = CivilianPunishmentSeverities;
			if (sectPunishmentSeverities == null || sectPunishmentSeverities.Count <= 0)
			{
				return defaultSeverity;
			}
			foreach (ShortPair severity2 in CivilianPunishmentSeverities)
			{
				if (severity2.First == stateTemplateId)
				{
					return (sbyte)severity2.Second;
				}
			}
		}
		return defaultSeverity;
	}
}
