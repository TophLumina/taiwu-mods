using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class PunishmentTypeItem : ConfigItem<PunishmentTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// - 展示在经历中的内容
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 罪名简述
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 显示分类
	/// </summary>
	public readonly EPunishmentTypeDisplayType DisplayType;

	/// <summary>
	/// 惩罚力度
	/// </summary>
	public readonly sbyte Severity;

	/// <summary>
	/// 罪名详述
	/// - 此罪名的具体情况描述
	/// </summary>
	public readonly string PunishmentDesc;

	/// <summary>
	/// 法规界面的插画
	/// </summary>
	public readonly string Image;

	/// <summary>
	/// 门派惩罚力度
	/// - 填写15个门派对应的惩罚等级（门派以所属州域的形式填写）。若当前罪行下，此门派存在惩罚等级配置；那么此门派有此法规；没有填写，则此门派不存在此法规;
	/// </summary>
	public readonly List<ShortPair> SectPunishmentSeverities;

	/// <summary>
	/// 城镇惩罚力度
	/// - 填写15个州域的非门派定居点对应的惩罚等级。若当前罪行下，此城镇存在惩罚等级配置；那么有此法规；没有填写，则不存在此法规;
	/// </summary>
	public readonly List<ShortPair> CivilianPunishmentSeverities;

	/// <summary>
	/// 修改消耗威望
	/// </summary>
	public readonly int ModifySeverityAuthorityCost;

	/// <summary>
	/// 所属DLC
	/// - 当玩家开启此DLC时才会显示对应内容
	/// </summary>
	public readonly uint DlcAppId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称 - 展示在经历中的内容</param>
	/// <param name="shortName">罪名简述</param>
	/// <param name="displayType">显示分类</param>
	/// <param name="severity">惩罚力度</param>
	/// <param name="punishmentDesc">罪名详述 - 此罪名的具体情况描述</param>
	/// <param name="image">法规界面的插画</param>
	/// <param name="sectPunishmentSeverities">门派惩罚力度 - 填写15个门派对应的惩罚等级（门派以所属州域的形式填写）。若当前罪行下，此门派存在惩罚等级配置；那么此门派有此法规；没有填写，则此门派不存在此法规;</param>
	/// <param name="civilianPunishmentSeverities">城镇惩罚力度 - 填写15个州域的非门派定居点对应的惩罚等级。若当前罪行下，此城镇存在惩罚等级配置；那么有此法规；没有填写，则不存在此法规;</param>
	/// <param name="modifySeverityAuthorityCost">修改消耗威望</param>
	/// <param name="dlcAppId">所属DLC - 当玩家开启此DLC时才会显示对应内容</param>
	public PunishmentTypeItem(short templateId, string name, string shortName, EPunishmentTypeDisplayType displayType, sbyte severity, string punishmentDesc, string image, List<ShortPair> sectPunishmentSeverities, List<ShortPair> civilianPunishmentSeverities, int modifySeverityAuthorityCost, uint dlcAppId)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		DisplayType = displayType;
		Severity = severity;
		PunishmentDesc = punishmentDesc;
		Image = image;
		SectPunishmentSeverities = sectPunishmentSeverities;
		CivilianPunishmentSeverities = civilianPunishmentSeverities;
		ModifySeverityAuthorityCost = modifySeverityAuthorityCost;
		DlcAppId = dlcAppId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PunishmentTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		DisplayType = EPunishmentTypeDisplayType.Criminal;
		Severity = 0;
		PunishmentDesc = null;
		Image = null;
		SectPunishmentSeverities = new List<ShortPair>();
		CivilianPunishmentSeverities = new List<ShortPair>();
		ModifySeverityAuthorityCost = 0;
		DlcAppId = 0u;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PunishmentTypeItem(short templateId, PunishmentTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		DisplayType = other.DisplayType;
		Severity = other.Severity;
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PunishmentTypeItem Duplicate(int templateId)
	{
		return new PunishmentTypeItem((short)templateId, this);
	}

	/// <summary>
	/// 获取当前惩罚在指定州域的
	/// </summary>
	/// <param name="stateTemplateId">州域模板ID</param>
	/// <param name="isSect">是否为门派戒律</param>
	/// <param name="includeDefault">是否包含默认值</param>
	/// <returns></returns>
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
