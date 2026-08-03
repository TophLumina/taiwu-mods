using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RanshanGiveupLegendaryBook : ConfigData<RanshanGiveupLegendaryBookItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 华居等级一
		/// </summary>
		public const byte HuajuLevel1 = 0;

		/// <summary>
		/// 华居等级二
		/// </summary>
		public const byte HuajuLevel2 = 1;

		/// <summary>
		/// 华居等级三
		/// </summary>
		public const byte HuajuLevel3 = 2;

		/// <summary>
		/// 玄质等级一
		/// </summary>
		public const byte XuanzhiLevel1 = 3;

		/// <summary>
		/// 玄质等级二
		/// </summary>
		public const byte XuanzhiLevel2 = 4;

		/// <summary>
		/// 玄质等级三
		/// </summary>
		public const byte XuanzhiLevel3 = 5;

		/// <summary>
		/// 迎娇等级一
		/// </summary>
		public const byte YingjiaoLevel1 = 6;

		/// <summary>
		/// 迎娇等级二
		/// </summary>
		public const byte YingjiaoLevel2 = 7;

		/// <summary>
		/// 迎娇等级三
		/// </summary>
		public const byte YingjiaoLevel3 = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 华居等级一
		/// </summary>
		public static RanshanGiveupLegendaryBookItem HuajuLevel1 => Instance[(byte)0];

		/// <summary>
		/// 华居等级二
		/// </summary>
		public static RanshanGiveupLegendaryBookItem HuajuLevel2 => Instance[(byte)1];

		/// <summary>
		/// 华居等级三
		/// </summary>
		public static RanshanGiveupLegendaryBookItem HuajuLevel3 => Instance[(byte)2];

		/// <summary>
		/// 玄质等级一
		/// </summary>
		public static RanshanGiveupLegendaryBookItem XuanzhiLevel1 => Instance[(byte)3];

		/// <summary>
		/// 玄质等级二
		/// </summary>
		public static RanshanGiveupLegendaryBookItem XuanzhiLevel2 => Instance[(byte)4];

		/// <summary>
		/// 玄质等级三
		/// </summary>
		public static RanshanGiveupLegendaryBookItem XuanzhiLevel3 => Instance[(byte)5];

		/// <summary>
		/// 迎娇等级一
		/// </summary>
		public static RanshanGiveupLegendaryBookItem YingjiaoLevel1 => Instance[(byte)6];

		/// <summary>
		/// 迎娇等级二
		/// </summary>
		public static RanshanGiveupLegendaryBookItem YingjiaoLevel2 => Instance[(byte)7];

		/// <summary>
		/// 迎娇等级三
		/// </summary>
		public static RanshanGiveupLegendaryBookItem YingjiaoLevel3 => Instance[(byte)8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static RanshanGiveupLegendaryBook Instance = new RanshanGiveupLegendaryBook();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ResourceType", "TemplateId", "FollowDuration", "ResponseCycle", "MoodChange", "JudgeAttribute" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(0, 6, 0, 12500, 12, 3, 5, new List<sbyte> { 0, 3 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(1, 6, 0, 25000, 18, 3, 10, new List<sbyte> { 0, 3 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(2, 6, 0, 50000, 24, 3, 15, new List<sbyte> { 0, 3 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(3, 7, 0, 1250, 12, 3, 5, new List<sbyte> { 1, 5 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(4, 7, 0, 2500, 18, 3, 10, new List<sbyte> { 1, 5 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(5, 7, 0, 5000, 24, 3, 15, new List<sbyte> { 1, 5 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(6, -1, 6250, 0, 12, 3, 5, new List<sbyte> { 2, 4 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(7, -1, 12500, 0, 18, 3, 10, new List<sbyte> { 2, 4 }));
		_dataArray.Add(new RanshanGiveupLegendaryBookItem(8, -1, 25000, 0, 24, 3, 15, new List<sbyte> { 2, 4 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<RanshanGiveupLegendaryBookItem>(9);
		CreateItems0();
	}
}
