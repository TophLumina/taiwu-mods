using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SamsaraPlatformRecord : ConfigData<SamsaraPlatformRecordItem, short>
{
	public static class DefKey
	{
		public const short SamsaraSuccess = 0;

		public const short SamsaraFailed = 1;
	}

	public static class DefValue
	{
		public static SamsaraPlatformRecordItem SamsaraSuccess => Instance[(short)0];

		public static SamsaraPlatformRecordItem SamsaraFailed => Instance[(short)1];
	}

	public static SamsaraPlatformRecord Instance = new SamsaraPlatformRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SamsaraPlatformRecordItem(0, LocalStringManager.GetConfig("SamsaraPlatformRecord_language", "Desc_0"), new string[5] { "Character", "DestinyType", "Settlement", "OrgGrade", "Character" }));
		_dataArray.Add(new SamsaraPlatformRecordItem(1, LocalStringManager.GetConfig("SamsaraPlatformRecord_language", "Desc_1"), new string[5] { "Character", "DestinyType", "", "", "" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SamsaraPlatformRecordItem>(2);
		CreateItems0();
	}
}
