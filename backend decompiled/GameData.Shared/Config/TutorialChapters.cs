using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class TutorialChapters : ConfigData<TutorialChaptersItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 演武第一章
		/// </summary>
		public const short Chapter1 = 0;

		/// <summary>
		/// 演武第二章
		/// </summary>
		public const short Chapter2 = 1;

		/// <summary>
		/// 演武第三章
		/// </summary>
		public const short Chapter3 = 2;

		/// <summary>
		/// 演武第四章
		/// </summary>
		public const short Chapter4 = 3;

		/// <summary>
		/// 演武第五章
		/// </summary>
		public const short Chapter5 = 4;

		/// <summary>
		/// 演武第六章
		/// </summary>
		public const short Chapter6 = 5;

		/// <summary>
		/// 演武第七章
		/// </summary>
		public const short Chapter7 = 6;

		/// <summary>
		/// 演武第八章
		/// </summary>
		public const short Chapter8 = 7;

		/// <summary>
		/// 演武第九章
		/// </summary>
		public const short Chapter9 = 8;

		/// <summary>
		/// 演武第十章
		/// </summary>
		public const short Chapter10 = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 演武第一章
		/// </summary>
		public static TutorialChaptersItem Chapter1 => Instance[(short)0];

		/// <summary>
		/// 演武第二章
		/// </summary>
		public static TutorialChaptersItem Chapter2 => Instance[(short)1];

		/// <summary>
		/// 演武第三章
		/// </summary>
		public static TutorialChaptersItem Chapter3 => Instance[(short)2];

		/// <summary>
		/// 演武第四章
		/// </summary>
		public static TutorialChaptersItem Chapter4 => Instance[(short)3];

		/// <summary>
		/// 演武第五章
		/// </summary>
		public static TutorialChaptersItem Chapter5 => Instance[(short)4];

		/// <summary>
		/// 演武第六章
		/// </summary>
		public static TutorialChaptersItem Chapter6 => Instance[(short)5];

		/// <summary>
		/// 演武第七章
		/// </summary>
		public static TutorialChaptersItem Chapter7 => Instance[(short)6];

		/// <summary>
		/// 演武第八章
		/// </summary>
		public static TutorialChaptersItem Chapter8 => Instance[(short)7];

		/// <summary>
		/// 演武第九章
		/// </summary>
		public static TutorialChaptersItem Chapter9 => Instance[(short)8];

		/// <summary>
		/// 演武第十章
		/// </summary>
		public static TutorialChaptersItem Chapter10 => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TutorialChapters Instance = new TutorialChapters();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ToggleName", "Desc", "MainCharacter", "Head", "Tail", "OpenedFunctionTypes", "PresetInventory", "TemplateId", "MapAreaPresetKey",
		"StartBlockCoordinate"
	};

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
		_dataArray.Add(new TutorialChaptersItem(0, LocalStringManager.GetConfig("TutorialChapters_language", "Name_0"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_0"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_0"), 908, "Born2", new ByteCoordinate(13, 8), new ByteCoordinate[5]
		{
			new ByteCoordinate(12, 8),
			new ByteCoordinate(11, 8),
			new ByteCoordinate(11, 9),
			new ByteCoordinate(10, 9),
			new ByteCoordinate(9, 9)
		}, 1, LocalStringManager.GetConfig("TutorialChapters_language", "Head_0"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_0"), new short[0], new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 268, 1, 100)
		}));
		_dataArray.Add(new TutorialChaptersItem(1, LocalStringManager.GetConfig("TutorialChapters_language", "Name_1"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_1"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_1"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 11, LocalStringManager.GetConfig("TutorialChapters_language", "Head_1"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_1"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(2, LocalStringManager.GetConfig("TutorialChapters_language", "Name_2"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_2"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_2"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 11, LocalStringManager.GetConfig("TutorialChapters_language", "Head_2"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_2"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(3, LocalStringManager.GetConfig("TutorialChapters_language", "Name_3"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_3"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_3"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[6]
		{
			new ByteCoordinate(8, 9),
			new ByteCoordinate(8, 10),
			new ByteCoordinate(8, 11),
			new ByteCoordinate(8, 10),
			new ByteCoordinate(8, 9),
			new ByteCoordinate(9, 9)
		}, 5, LocalStringManager.GetConfig("TutorialChapters_language", "Head_3"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_3"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(4, LocalStringManager.GetConfig("TutorialChapters_language", "Name_4"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_4"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_4"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 5, LocalStringManager.GetConfig("TutorialChapters_language", "Head_4"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_4"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(5, LocalStringManager.GetConfig("TutorialChapters_language", "Name_5"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_5"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_5"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 5, LocalStringManager.GetConfig("TutorialChapters_language", "Head_5"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_5"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(6, LocalStringManager.GetConfig("TutorialChapters_language", "Name_6"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_6"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_6"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 5, LocalStringManager.GetConfig("TutorialChapters_language", "Head_6"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_6"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(7, LocalStringManager.GetConfig("TutorialChapters_language", "Name_7"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_7"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_7"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 6, LocalStringManager.GetConfig("TutorialChapters_language", "Head_7"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_7"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(8, LocalStringManager.GetConfig("TutorialChapters_language", "Name_8"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_8"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_8"), 908, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[0], 6, LocalStringManager.GetConfig("TutorialChapters_language", "Head_8"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_8"), new short[0], new List<PresetInventoryItem>()));
		_dataArray.Add(new TutorialChaptersItem(9, LocalStringManager.GetConfig("TutorialChapters_language", "Name_9"), LocalStringManager.GetConfig("TutorialChapters_language", "ToggleName_9"), LocalStringManager.GetConfig("TutorialChapters_language", "Desc_9"), 880, "Born2", new ByteCoordinate(9, 9), new ByteCoordinate[5]
		{
			new ByteCoordinate(10, 9),
			new ByteCoordinate(11, 9),
			new ByteCoordinate(11, 8),
			new ByteCoordinate(12, 8),
			new ByteCoordinate(13, 8)
		}, 6, LocalStringManager.GetConfig("TutorialChapters_language", "Head_9"), LocalStringManager.GetConfig("TutorialChapters_language", "Tail_9"), new short[0], new List<PresetInventoryItem>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TutorialChaptersItem>(10);
		CreateItems0();
	}
}
