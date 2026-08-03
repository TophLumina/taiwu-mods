using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterClass : ConfigData<GuidingChapterClassItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾
		/// </summary>
		public const short Taiwu = 0;

		/// <summary>
		/// 世界
		/// </summary>
		public const short World = 1;

		/// <summary>
		/// 势力
		/// </summary>
		public const short InfluencePower = 2;

		/// <summary>
		/// 门派
		/// </summary>
		public const short Sect = 3;

		/// <summary>
		/// 人物
		/// </summary>
		public const short Character = 4;

		/// <summary>
		/// 交互
		/// </summary>
		public const short Interact = 5;

		/// <summary>
		/// 修习
		/// </summary>
		public const short Practice = 6;

		/// <summary>
		/// 战斗
		/// </summary>
		public const short Combat = 7;

		/// <summary>
		/// 产业
		/// </summary>
		public const short Building = 8;

		/// <summary>
		/// 物品
		/// </summary>
		public const short Item = 9;

		/// <summary>
		/// 游历
		/// </summary>
		public const short Travel = 10;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾
		/// </summary>
		public static GuidingChapterClassItem Taiwu => Instance[(short)0];

		/// <summary>
		/// 世界
		/// </summary>
		public static GuidingChapterClassItem World => Instance[(short)1];

		/// <summary>
		/// 势力
		/// </summary>
		public static GuidingChapterClassItem InfluencePower => Instance[(short)2];

		/// <summary>
		/// 门派
		/// </summary>
		public static GuidingChapterClassItem Sect => Instance[(short)3];

		/// <summary>
		/// 人物
		/// </summary>
		public static GuidingChapterClassItem Character => Instance[(short)4];

		/// <summary>
		/// 交互
		/// </summary>
		public static GuidingChapterClassItem Interact => Instance[(short)5];

		/// <summary>
		/// 修习
		/// </summary>
		public static GuidingChapterClassItem Practice => Instance[(short)6];

		/// <summary>
		/// 战斗
		/// </summary>
		public static GuidingChapterClassItem Combat => Instance[(short)7];

		/// <summary>
		/// 产业
		/// </summary>
		public static GuidingChapterClassItem Building => Instance[(short)8];

		/// <summary>
		/// 物品
		/// </summary>
		public static GuidingChapterClassItem Item => Instance[(short)9];

		/// <summary>
		/// 游历
		/// </summary>
		public static GuidingChapterClassItem Travel => Instance[(short)10];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static GuidingChapterClass Instance = new GuidingChapterClass();

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
		_dataArray.Add(new GuidingChapterClassItem(0, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_0")));
		_dataArray.Add(new GuidingChapterClassItem(1, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_1")));
		_dataArray.Add(new GuidingChapterClassItem(2, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_2")));
		_dataArray.Add(new GuidingChapterClassItem(3, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_3")));
		_dataArray.Add(new GuidingChapterClassItem(4, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_4")));
		_dataArray.Add(new GuidingChapterClassItem(5, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_5")));
		_dataArray.Add(new GuidingChapterClassItem(6, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_6")));
		_dataArray.Add(new GuidingChapterClassItem(7, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_7")));
		_dataArray.Add(new GuidingChapterClassItem(8, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_8")));
		_dataArray.Add(new GuidingChapterClassItem(9, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_9")));
		_dataArray.Add(new GuidingChapterClassItem(10, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_10")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<GuidingChapterClassItem>(11);
		CreateItems0();
	}
}
