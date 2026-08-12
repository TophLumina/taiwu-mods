using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WesternRegion : ConfigData<WesternRegionItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 吐蕃
		/// </summary>
		public const short Tibetan = 0;

		/// <summary>
		/// 天竺
		/// </summary>
		public const short Tintu = 1;

		/// <summary>
		/// 波斯
		/// </summary>
		public const short Persian = 2;

		/// <summary>
		/// 罗马
		/// </summary>
		public const short Rome = 3;

		/// <summary>
		/// 希腊
		/// </summary>
		public const short Greece = 4;

		/// <summary>
		/// 突厥
		/// </summary>
		public const short Turkic = 5;

		/// <summary>
		/// 阿拉伯
		/// </summary>
		public const short Arab = 6;

		/// <summary>
		/// 日耳曼
		/// </summary>
		public const short Germanic = 7;

		/// <summary>
		/// 维京
		/// </summary>
		public const short Viking = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 吐蕃
		/// </summary>
		public static WesternRegionItem Tibetan => Instance[(short)0];

		/// <summary>
		/// 天竺
		/// </summary>
		public static WesternRegionItem Tintu => Instance[(short)1];

		/// <summary>
		/// 波斯
		/// </summary>
		public static WesternRegionItem Persian => Instance[(short)2];

		/// <summary>
		/// 罗马
		/// </summary>
		public static WesternRegionItem Rome => Instance[(short)3];

		/// <summary>
		/// 希腊
		/// </summary>
		public static WesternRegionItem Greece => Instance[(short)4];

		/// <summary>
		/// 突厥
		/// </summary>
		public static WesternRegionItem Turkic => Instance[(short)5];

		/// <summary>
		/// 阿拉伯
		/// </summary>
		public static WesternRegionItem Arab => Instance[(short)6];

		/// <summary>
		/// 日耳曼
		/// </summary>
		public static WesternRegionItem Germanic => Instance[(short)7];

		/// <summary>
		/// 维京
		/// </summary>
		public static WesternRegionItem Viking => Instance[(short)8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static WesternRegion Instance = new WesternRegion();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new WesternRegionItem(0, LocalStringManager.GetConfig("WesternRegion_language", "Name_0")));
		_dataArray.Add(new WesternRegionItem(1, LocalStringManager.GetConfig("WesternRegion_language", "Name_1")));
		_dataArray.Add(new WesternRegionItem(2, LocalStringManager.GetConfig("WesternRegion_language", "Name_2")));
		_dataArray.Add(new WesternRegionItem(3, LocalStringManager.GetConfig("WesternRegion_language", "Name_3")));
		_dataArray.Add(new WesternRegionItem(4, LocalStringManager.GetConfig("WesternRegion_language", "Name_4")));
		_dataArray.Add(new WesternRegionItem(5, LocalStringManager.GetConfig("WesternRegion_language", "Name_5")));
		_dataArray.Add(new WesternRegionItem(6, LocalStringManager.GetConfig("WesternRegion_language", "Name_6")));
		_dataArray.Add(new WesternRegionItem(7, LocalStringManager.GetConfig("WesternRegion_language", "Name_7")));
		_dataArray.Add(new WesternRegionItem(8, LocalStringManager.GetConfig("WesternRegion_language", "Name_8")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WesternRegionItem>(9);
		CreateItems0();
	}
}
