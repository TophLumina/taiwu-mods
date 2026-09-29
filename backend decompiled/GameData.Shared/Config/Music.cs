using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Music : ConfigData<MusicItem, short>
{
	public static Music Instance = new Music();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "MapBlock", "MapState", "TemporaryFeature", "Desc", "Evaluation", "TemplateId", "Icon" };

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
		_dataArray.Add(new MusicItem(0, LocalStringManager.GetConfig("Music_language", "Name_0"), 0, -1, "ui9_sectpopup_7_texture_music_0", 30, 30, 262, LocalStringManager.GetConfig("Music_language", "Desc_0"), LocalStringManager.GetConfig("Music_language", "Evaluation_0")));
		_dataArray.Add(new MusicItem(1, LocalStringManager.GetConfig("Music_language", "Name_1"), -1, 0, "ui9_sectpopup_7_texture_music_1", 30, 30, 263, LocalStringManager.GetConfig("Music_language", "Desc_1"), LocalStringManager.GetConfig("Music_language", "Evaluation_1")));
		_dataArray.Add(new MusicItem(2, LocalStringManager.GetConfig("Music_language", "Name_2"), 19, -1, "ui9_sectpopup_7_texture_music_2", 20, 0, 264, LocalStringManager.GetConfig("Music_language", "Desc_2"), LocalStringManager.GetConfig("Music_language", "Evaluation_2")));
		_dataArray.Add(new MusicItem(3, LocalStringManager.GetConfig("Music_language", "Name_3"), 20, -1, "ui9_sectpopup_7_texture_music_3", 20, 0, 265, LocalStringManager.GetConfig("Music_language", "Desc_3"), LocalStringManager.GetConfig("Music_language", "Evaluation_3")));
		_dataArray.Add(new MusicItem(4, LocalStringManager.GetConfig("Music_language", "Name_4"), 21, -1, "ui9_sectpopup_7_texture_music_4", 20, 0, 266, LocalStringManager.GetConfig("Music_language", "Desc_4"), LocalStringManager.GetConfig("Music_language", "Evaluation_4")));
		_dataArray.Add(new MusicItem(5, LocalStringManager.GetConfig("Music_language", "Name_5"), 22, -1, "ui9_sectpopup_7_texture_music_5", 20, 0, 267, LocalStringManager.GetConfig("Music_language", "Desc_5"), LocalStringManager.GetConfig("Music_language", "Evaluation_5")));
		_dataArray.Add(new MusicItem(6, LocalStringManager.GetConfig("Music_language", "Name_6"), 23, -1, "ui9_sectpopup_7_texture_music_6", 20, 0, 268, LocalStringManager.GetConfig("Music_language", "Desc_6"), LocalStringManager.GetConfig("Music_language", "Evaluation_6")));
		_dataArray.Add(new MusicItem(7, LocalStringManager.GetConfig("Music_language", "Name_7"), 24, -1, "ui9_sectpopup_7_texture_music_7", 20, 0, 269, LocalStringManager.GetConfig("Music_language", "Desc_7"), LocalStringManager.GetConfig("Music_language", "Evaluation_7")));
		_dataArray.Add(new MusicItem(8, LocalStringManager.GetConfig("Music_language", "Name_8"), 25, -1, "ui9_sectpopup_7_texture_music_8", 20, 0, 270, LocalStringManager.GetConfig("Music_language", "Desc_8"), LocalStringManager.GetConfig("Music_language", "Evaluation_8")));
		_dataArray.Add(new MusicItem(9, LocalStringManager.GetConfig("Music_language", "Name_9"), 26, -1, "ui9_sectpopup_7_texture_music_9", 20, 0, 271, LocalStringManager.GetConfig("Music_language", "Desc_9"), LocalStringManager.GetConfig("Music_language", "Evaluation_9")));
		_dataArray.Add(new MusicItem(10, LocalStringManager.GetConfig("Music_language", "Name_10"), 27, -1, "ui9_sectpopup_7_texture_music_10", 20, 0, 272, LocalStringManager.GetConfig("Music_language", "Desc_10"), LocalStringManager.GetConfig("Music_language", "Evaluation_10")));
		_dataArray.Add(new MusicItem(11, LocalStringManager.GetConfig("Music_language", "Name_11"), 28, -1, "ui9_sectpopup_7_texture_music_11", 20, 0, 273, LocalStringManager.GetConfig("Music_language", "Desc_11"), LocalStringManager.GetConfig("Music_language", "Evaluation_11")));
		_dataArray.Add(new MusicItem(12, LocalStringManager.GetConfig("Music_language", "Name_12"), 29, -1, "ui9_sectpopup_7_texture_music_12", 20, 0, 274, LocalStringManager.GetConfig("Music_language", "Desc_12"), LocalStringManager.GetConfig("Music_language", "Evaluation_12")));
		_dataArray.Add(new MusicItem(13, LocalStringManager.GetConfig("Music_language", "Name_13"), 30, -1, "ui9_sectpopup_7_texture_music_13", 20, 0, 275, LocalStringManager.GetConfig("Music_language", "Desc_13"), LocalStringManager.GetConfig("Music_language", "Evaluation_13")));
		_dataArray.Add(new MusicItem(14, LocalStringManager.GetConfig("Music_language", "Name_14"), 31, -1, "ui9_sectpopup_7_texture_music_14", 20, 0, 276, LocalStringManager.GetConfig("Music_language", "Desc_14"), LocalStringManager.GetConfig("Music_language", "Evaluation_14")));
		_dataArray.Add(new MusicItem(15, LocalStringManager.GetConfig("Music_language", "Name_15"), 32, -1, "ui9_sectpopup_7_texture_music_15", 20, 0, 277, LocalStringManager.GetConfig("Music_language", "Desc_15"), LocalStringManager.GetConfig("Music_language", "Evaluation_15")));
		_dataArray.Add(new MusicItem(16, LocalStringManager.GetConfig("Music_language", "Name_16"), 33, -1, "ui9_sectpopup_7_texture_music_16", 20, 0, 278, LocalStringManager.GetConfig("Music_language", "Desc_16"), LocalStringManager.GetConfig("Music_language", "Evaluation_16")));
		_dataArray.Add(new MusicItem(17, LocalStringManager.GetConfig("Music_language", "Name_17"), 1, -1, "ui9_sectpopup_7_texture_music_17", 0, 20, 279, LocalStringManager.GetConfig("Music_language", "Desc_17"), LocalStringManager.GetConfig("Music_language", "Evaluation_17")));
		_dataArray.Add(new MusicItem(18, LocalStringManager.GetConfig("Music_language", "Name_18"), 2, -1, "ui9_sectpopup_7_texture_music_18", 0, 20, 280, LocalStringManager.GetConfig("Music_language", "Desc_18"), LocalStringManager.GetConfig("Music_language", "Evaluation_18")));
		_dataArray.Add(new MusicItem(19, LocalStringManager.GetConfig("Music_language", "Name_19"), 3, -1, "ui9_sectpopup_7_texture_music_19", 0, 20, 281, LocalStringManager.GetConfig("Music_language", "Desc_19"), LocalStringManager.GetConfig("Music_language", "Evaluation_19")));
		_dataArray.Add(new MusicItem(20, LocalStringManager.GetConfig("Music_language", "Name_20"), 4, -1, "ui9_sectpopup_7_texture_music_20", 0, 20, 282, LocalStringManager.GetConfig("Music_language", "Desc_20"), LocalStringManager.GetConfig("Music_language", "Evaluation_20")));
		_dataArray.Add(new MusicItem(21, LocalStringManager.GetConfig("Music_language", "Name_21"), 5, -1, "ui9_sectpopup_7_texture_music_21", 0, 20, 283, LocalStringManager.GetConfig("Music_language", "Desc_21"), LocalStringManager.GetConfig("Music_language", "Evaluation_21")));
		_dataArray.Add(new MusicItem(22, LocalStringManager.GetConfig("Music_language", "Name_22"), 6, -1, "ui9_sectpopup_7_texture_music_22", 0, 20, 284, LocalStringManager.GetConfig("Music_language", "Desc_22"), LocalStringManager.GetConfig("Music_language", "Evaluation_22")));
		_dataArray.Add(new MusicItem(23, LocalStringManager.GetConfig("Music_language", "Name_23"), 7, -1, "ui9_sectpopup_7_texture_music_23", 0, 20, 285, LocalStringManager.GetConfig("Music_language", "Desc_23"), LocalStringManager.GetConfig("Music_language", "Evaluation_23")));
		_dataArray.Add(new MusicItem(24, LocalStringManager.GetConfig("Music_language", "Name_24"), 8, -1, "ui9_sectpopup_7_texture_music_24", 0, 20, 286, LocalStringManager.GetConfig("Music_language", "Desc_24"), LocalStringManager.GetConfig("Music_language", "Evaluation_24")));
		_dataArray.Add(new MusicItem(25, LocalStringManager.GetConfig("Music_language", "Name_25"), 9, -1, "ui9_sectpopup_7_texture_music_25", 0, 20, 287, LocalStringManager.GetConfig("Music_language", "Desc_25"), LocalStringManager.GetConfig("Music_language", "Evaluation_25")));
		_dataArray.Add(new MusicItem(26, LocalStringManager.GetConfig("Music_language", "Name_26"), 10, -1, "ui9_sectpopup_7_texture_music_26", 0, 20, 288, LocalStringManager.GetConfig("Music_language", "Desc_26"), LocalStringManager.GetConfig("Music_language", "Evaluation_26")));
		_dataArray.Add(new MusicItem(27, LocalStringManager.GetConfig("Music_language", "Name_27"), 11, -1, "ui9_sectpopup_7_texture_music_27", 0, 20, 289, LocalStringManager.GetConfig("Music_language", "Desc_27"), LocalStringManager.GetConfig("Music_language", "Evaluation_27")));
		_dataArray.Add(new MusicItem(28, LocalStringManager.GetConfig("Music_language", "Name_28"), 12, -1, "ui9_sectpopup_7_texture_music_28", 0, 20, 290, LocalStringManager.GetConfig("Music_language", "Desc_28"), LocalStringManager.GetConfig("Music_language", "Evaluation_28")));
		_dataArray.Add(new MusicItem(29, LocalStringManager.GetConfig("Music_language", "Name_29"), 13, -1, "ui9_sectpopup_7_texture_music_29", 0, 20, 291, LocalStringManager.GetConfig("Music_language", "Desc_29"), LocalStringManager.GetConfig("Music_language", "Evaluation_29")));
		_dataArray.Add(new MusicItem(30, LocalStringManager.GetConfig("Music_language", "Name_30"), 14, -1, "ui9_sectpopup_7_texture_music_30", 0, 20, 292, LocalStringManager.GetConfig("Music_language", "Desc_30"), LocalStringManager.GetConfig("Music_language", "Evaluation_30")));
		_dataArray.Add(new MusicItem(31, LocalStringManager.GetConfig("Music_language", "Name_31"), 15, -1, "ui9_sectpopup_7_texture_music_31", 0, 20, 293, LocalStringManager.GetConfig("Music_language", "Desc_31"), LocalStringManager.GetConfig("Music_language", "Evaluation_31")));
		_dataArray.Add(new MusicItem(32, LocalStringManager.GetConfig("Music_language", "Name_32"), -1, 1, "ui9_sectpopup_7_texture_music_32", 10, 10, 294, LocalStringManager.GetConfig("Music_language", "Desc_32"), LocalStringManager.GetConfig("Music_language", "Evaluation_32")));
		_dataArray.Add(new MusicItem(33, LocalStringManager.GetConfig("Music_language", "Name_33"), -1, 2, "ui9_sectpopup_7_texture_music_33", 10, 10, 295, LocalStringManager.GetConfig("Music_language", "Desc_33"), LocalStringManager.GetConfig("Music_language", "Evaluation_33")));
		_dataArray.Add(new MusicItem(34, LocalStringManager.GetConfig("Music_language", "Name_34"), -1, 3, "ui9_sectpopup_7_texture_music_34", 10, 10, 296, LocalStringManager.GetConfig("Music_language", "Desc_34"), LocalStringManager.GetConfig("Music_language", "Evaluation_34")));
		_dataArray.Add(new MusicItem(35, LocalStringManager.GetConfig("Music_language", "Name_35"), -1, 4, "ui9_sectpopup_7_texture_music_35", 10, 10, 297, LocalStringManager.GetConfig("Music_language", "Desc_35"), LocalStringManager.GetConfig("Music_language", "Evaluation_35")));
		_dataArray.Add(new MusicItem(36, LocalStringManager.GetConfig("Music_language", "Name_36"), -1, 5, "ui9_sectpopup_7_texture_music_36", 10, 10, 298, LocalStringManager.GetConfig("Music_language", "Desc_36"), LocalStringManager.GetConfig("Music_language", "Evaluation_36")));
		_dataArray.Add(new MusicItem(37, LocalStringManager.GetConfig("Music_language", "Name_37"), -1, 6, "ui9_sectpopup_7_texture_music_37", 10, 10, 299, LocalStringManager.GetConfig("Music_language", "Desc_37"), LocalStringManager.GetConfig("Music_language", "Evaluation_37")));
		_dataArray.Add(new MusicItem(38, LocalStringManager.GetConfig("Music_language", "Name_38"), -1, 7, "ui9_sectpopup_7_texture_music_38", 10, 10, 300, LocalStringManager.GetConfig("Music_language", "Desc_38"), LocalStringManager.GetConfig("Music_language", "Evaluation_38")));
		_dataArray.Add(new MusicItem(39, LocalStringManager.GetConfig("Music_language", "Name_39"), -1, 8, "ui9_sectpopup_7_texture_music_39", 10, 10, 301, LocalStringManager.GetConfig("Music_language", "Desc_39"), LocalStringManager.GetConfig("Music_language", "Evaluation_39")));
		_dataArray.Add(new MusicItem(40, LocalStringManager.GetConfig("Music_language", "Name_40"), -1, 9, "ui9_sectpopup_7_texture_music_40", 10, 10, 302, LocalStringManager.GetConfig("Music_language", "Desc_40"), LocalStringManager.GetConfig("Music_language", "Evaluation_40")));
		_dataArray.Add(new MusicItem(41, LocalStringManager.GetConfig("Music_language", "Name_41"), -1, 10, "ui9_sectpopup_7_texture_music_41", 10, 10, 303, LocalStringManager.GetConfig("Music_language", "Desc_41"), LocalStringManager.GetConfig("Music_language", "Evaluation_41")));
		_dataArray.Add(new MusicItem(42, LocalStringManager.GetConfig("Music_language", "Name_42"), -1, 11, "ui9_sectpopup_7_texture_music_42", 10, 10, 304, LocalStringManager.GetConfig("Music_language", "Desc_42"), LocalStringManager.GetConfig("Music_language", "Evaluation_42")));
		_dataArray.Add(new MusicItem(43, LocalStringManager.GetConfig("Music_language", "Name_43"), -1, 12, "ui9_sectpopup_7_texture_music_43", 10, 10, 305, LocalStringManager.GetConfig("Music_language", "Desc_43"), LocalStringManager.GetConfig("Music_language", "Evaluation_43")));
		_dataArray.Add(new MusicItem(44, LocalStringManager.GetConfig("Music_language", "Name_44"), -1, 13, "ui9_sectpopup_7_texture_music_44", 10, 10, 306, LocalStringManager.GetConfig("Music_language", "Desc_44"), LocalStringManager.GetConfig("Music_language", "Evaluation_44")));
		_dataArray.Add(new MusicItem(45, LocalStringManager.GetConfig("Music_language", "Name_45"), -1, 14, "ui9_sectpopup_7_texture_music_45", 10, 10, 307, LocalStringManager.GetConfig("Music_language", "Desc_45"), LocalStringManager.GetConfig("Music_language", "Evaluation_45")));
		_dataArray.Add(new MusicItem(46, LocalStringManager.GetConfig("Music_language", "Name_46"), -1, 15, "ui9_sectpopup_7_texture_music_46", 10, 10, 308, LocalStringManager.GetConfig("Music_language", "Desc_46"), LocalStringManager.GetConfig("Music_language", "Evaluation_46")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MusicItem>(47);
		CreateItems0();
	}

	public static int GetCharacterPropertyBonus(int key, ECharacterPropertyReferencedType property)
	{
		return Instance[key]?.GetCharacterPropertyBonusInt(property) ?? 0;
	}

	public static int GetCharacterPropertyBonus(short[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<short> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(int[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<int> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}
}
