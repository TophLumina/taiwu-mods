using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PunishmentSeverity : ConfigData<PunishmentSeverityItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static PunishmentSeverity Instance = new PunishmentSeverity();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "EscapeActions", "Name", "PunishmentDesc", "NormalRecord", "ArrestedRecord", "TemplateId", "FameActionFactorInPunish", "NameColor" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new PunishmentSeverityItem(0, 1, 1, 0, 0, expel: false, 6, 1, new sbyte[5], new short[1] { 18 }, 500, 50, 2000, new List<int> { -10, 10 }, 1, 1, 1, 1, LocalStringManager.GetConfig("PunishmentSeverity_language", "Name_0"), "ffffff", LocalStringManager.GetConfig("PunishmentSeverity_language", "PunishmentDesc_0"), 908, 914));
		_dataArray.Add(new PunishmentSeverityItem(1, 1, 1, 0, 6, expel: false, 12, 2, new sbyte[5] { 4, 8, 12, 20, 16 }, new short[1] { 18 }, 1000, 100, 4000, new List<int> { -20, 20 }, 2, 2, 2, 2, LocalStringManager.GetConfig("PunishmentSeverity_language", "Name_1"), "9fe0dc", LocalStringManager.GetConfig("PunishmentSeverity_language", "PunishmentDesc_1"), 909, 915));
		_dataArray.Add(new PunishmentSeverityItem(2, 1, 1, 1, 12, expel: false, 18, 3, new sbyte[5] { 6, 12, 18, 30, 24 }, new short[1] { 18 }, 2000, 200, 8000, new List<int> { -40, 40 }, 4, 3, 3, 3, LocalStringManager.GetConfig("PunishmentSeverity_language", "Name_2"), "b975ff", LocalStringManager.GetConfig("PunishmentSeverity_language", "PunishmentDesc_2"), 910, 916));
		_dataArray.Add(new PunishmentSeverityItem(3, 2, 2, 2, 24, expel: false, 24, 4, new sbyte[5] { 8, 16, 24, 40, 32 }, new short[2] { 18, 19 }, 3500, 350, 14000, new List<int> { -70, 70 }, 8, 4, 4, 4, LocalStringManager.GetConfig("PunishmentSeverity_language", "Name_3"), "ffe78f", LocalStringManager.GetConfig("PunishmentSeverity_language", "PunishmentDesc_3"), 911, 917));
		_dataArray.Add(new PunishmentSeverityItem(4, 2, 2, 2, 60, expel: true, 48, 5, new sbyte[5] { 10, 20, 30, 50, 40 }, new short[2] { 18, 19 }, 5500, 550, 22000, new List<int> { -110, 110 }, 16, 5, 5, 5, LocalStringManager.GetConfig("PunishmentSeverity_language", "Name_4"), "ff5331", LocalStringManager.GetConfig("PunishmentSeverity_language", "PunishmentDesc_4"), 911, 917));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PunishmentSeverityItem>(5);
		CreateItems0();
	}
}
