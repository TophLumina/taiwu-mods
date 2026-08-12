using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LandFormType : ConfigData<LandFormTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 平原
		/// </summary>
		public const sbyte Flatlands = 0;

		/// <summary>
		/// 山岳
		/// </summary>
		public const sbyte Mountain = 1;

		/// <summary>
		/// 森林
		/// </summary>
		public const sbyte Forest = 2;

		/// <summary>
		/// 湖泽
		/// </summary>
		public const sbyte Lake = 3;

		/// <summary>
		/// 海滨
		/// </summary>
		public const sbyte Coast = 4;

		/// <summary>
		/// 雪山
		/// </summary>
		public const sbyte SnowMountain = 5;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 平原
		/// </summary>
		public static LandFormTypeItem Flatlands => Instance[(sbyte)0];

		/// <summary>
		/// 山岳
		/// </summary>
		public static LandFormTypeItem Mountain => Instance[(sbyte)1];

		/// <summary>
		/// 森林
		/// </summary>
		public static LandFormTypeItem Forest => Instance[(sbyte)2];

		/// <summary>
		/// 湖泽
		/// </summary>
		public static LandFormTypeItem Lake => Instance[(sbyte)3];

		/// <summary>
		/// 海滨
		/// </summary>
		public static LandFormTypeItem Coast => Instance[(sbyte)4];

		/// <summary>
		/// 雪山
		/// </summary>
		public static LandFormTypeItem SnowMountain => Instance[(sbyte)5];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LandFormType Instance = new LandFormType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId" };

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
		_dataArray.Add(new LandFormTypeItem(0, LocalStringManager.GetConfig("LandFormType_language", "Name_0"), LocalStringManager.GetConfig("LandFormType_language", "Desc_0"), new byte[10] { 2, 0, 2, 0, 2, 1, 5, 1, 7, 2 }, new byte[10] { 0, 0, 2, 2, 2, 0, 3, 0, 1, 0 }));
		_dataArray.Add(new LandFormTypeItem(1, LocalStringManager.GetConfig("LandFormType_language", "Name_1"), LocalStringManager.GetConfig("LandFormType_language", "Desc_1"), new byte[10] { 1, 7, 2, 5, 2, 0, 1, 2, 0, 2 }, new byte[10] { 2, 3, 1, 0, 0, 1, 0, 2, 1, 0 }));
		_dataArray.Add(new LandFormTypeItem(2, LocalStringManager.GetConfig("LandFormType_language", "Name_2"), LocalStringManager.GetConfig("LandFormType_language", "Desc_2"), new byte[10] { 1, 0, 7, 0, 4, 2, 3, 0, 3, 3 }, new byte[10] { 0, 0, 3, 3, 1, 2, 1, 0, 0, 0 }));
		_dataArray.Add(new LandFormTypeItem(3, LocalStringManager.GetConfig("LandFormType_language", "Name_3"), LocalStringManager.GetConfig("LandFormType_language", "Desc_3"), new byte[10] { 7, 0, 2, 0, 3, 3, 2, 0, 4, 2 }, new byte[10] { 0, 0, 2, 1, 3, 3, 1, 0, 0, 0 }));
		_dataArray.Add(new LandFormTypeItem(4, LocalStringManager.GetConfig("LandFormType_language", "Name_4"), LocalStringManager.GetConfig("LandFormType_language", "Desc_4"), new byte[10] { 7, 4, 1, 4, 1, 1, 0, 3, 0, 1 }, new byte[10] { 3, 2, 0, 0, 1, 1, 0, 1, 2, 0 }));
		_dataArray.Add(new LandFormTypeItem(5, LocalStringManager.GetConfig("LandFormType_language", "Name_5"), LocalStringManager.GetConfig("LandFormType_language", "Desc_5"), new byte[10] { 0, 5, 1, 7, 5, 0, 0, 5, 0, 1 }, new byte[10] { 0, 1, 0, 1, 0, 0, 1, 1, 3, 3 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LandFormTypeItem>(6);
		CreateItems0();
	}
}
