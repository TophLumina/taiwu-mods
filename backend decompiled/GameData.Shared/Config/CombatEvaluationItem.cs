using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class CombatEvaluationItem : ConfigItem<CombatEvaluationItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string SmallVillageDesc;

	public readonly List<short> RequireCombatConfigs;

	public readonly sbyte[] CombatTypes;

	public readonly bool NeedWin;

	public readonly bool RequireNotBoss;

	public readonly bool AvailableInPlayground;

	public readonly ECombatEvaluationExtraCheck ExtraCheck;

	public readonly short ExpAddPercent;

	public readonly short ExpTotalPercent;

	public readonly short AuthorityAddPercent;

	public readonly short AuthorityTotalPercent;

	public readonly bool AllowProficiency;

	public readonly short AreaSpiritualDebt;

	public readonly short FameAction;

	public readonly int ReadInCombatRate;

	public readonly int QiArtCombatRate;

	public readonly List<LegacyPointReference> AddLegacyPoint;

	public CombatEvaluationItem(sbyte templateId, string name, string desc, string smallVillageDesc, List<short> requireCombatConfigs, sbyte[] combatTypes, bool needWin, bool requireNotBoss, bool availableInPlayground, ECombatEvaluationExtraCheck extraCheck, short expAddPercent, short expTotalPercent, short authorityAddPercent, short authorityTotalPercent, bool allowProficiency, short areaSpiritualDebt, short fameAction, int readInCombatRate, int qiArtCombatRate, List<LegacyPointReference> addLegacyPoint)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		SmallVillageDesc = smallVillageDesc;
		RequireCombatConfigs = requireCombatConfigs;
		CombatTypes = combatTypes;
		NeedWin = needWin;
		RequireNotBoss = requireNotBoss;
		AvailableInPlayground = availableInPlayground;
		ExtraCheck = extraCheck;
		ExpAddPercent = expAddPercent;
		ExpTotalPercent = expTotalPercent;
		AuthorityAddPercent = authorityAddPercent;
		AuthorityTotalPercent = authorityTotalPercent;
		AllowProficiency = allowProficiency;
		AreaSpiritualDebt = areaSpiritualDebt;
		FameAction = fameAction;
		ReadInCombatRate = readInCombatRate;
		QiArtCombatRate = qiArtCombatRate;
		AddLegacyPoint = addLegacyPoint;
	}

	public CombatEvaluationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		SmallVillageDesc = null;
		RequireCombatConfigs = new List<short>();
		CombatTypes = new sbyte[4] { 0, 1, 2, 3 };
		NeedWin = false;
		RequireNotBoss = false;
		AvailableInPlayground = false;
		ExtraCheck = ECombatEvaluationExtraCheck.Invalid;
		ExpAddPercent = 0;
		ExpTotalPercent = 0;
		AuthorityAddPercent = 0;
		AuthorityTotalPercent = 0;
		AllowProficiency = true;
		AreaSpiritualDebt = 0;
		FameAction = 0;
		ReadInCombatRate = 0;
		QiArtCombatRate = 0;
		AddLegacyPoint = new List<LegacyPointReference>();
	}

	public CombatEvaluationItem(sbyte templateId, CombatEvaluationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		SmallVillageDesc = other.SmallVillageDesc;
		RequireCombatConfigs = other.RequireCombatConfigs;
		CombatTypes = other.CombatTypes;
		NeedWin = other.NeedWin;
		RequireNotBoss = other.RequireNotBoss;
		AvailableInPlayground = other.AvailableInPlayground;
		ExtraCheck = other.ExtraCheck;
		ExpAddPercent = other.ExpAddPercent;
		ExpTotalPercent = other.ExpTotalPercent;
		AuthorityAddPercent = other.AuthorityAddPercent;
		AuthorityTotalPercent = other.AuthorityTotalPercent;
		AllowProficiency = other.AllowProficiency;
		AreaSpiritualDebt = other.AreaSpiritualDebt;
		FameAction = other.FameAction;
		ReadInCombatRate = other.ReadInCombatRate;
		QiArtCombatRate = other.QiArtCombatRate;
		AddLegacyPoint = other.AddLegacyPoint;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatEvaluationItem Duplicate(int templateId)
	{
		return new CombatEvaluationItem((sbyte)templateId, this);
	}
}
