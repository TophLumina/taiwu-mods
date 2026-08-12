using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SamsaraPlatformRecord : ConfigData<SamsaraPlatformRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 轮回成功
		/// </summary>
		public const short SamsaraSuccess = 0;

		/// <summary>
		/// 轮回失败
		/// </summary>
		public const short SamsaraFailed = 1;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 轮回成功
		/// </summary>
		public static SamsaraPlatformRecordItem SamsaraSuccess => Instance[(short)0];

		/// <summary>
		/// 轮回失败
		/// </summary>
		public static SamsaraPlatformRecordItem SamsaraFailed => Instance[(short)1];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
