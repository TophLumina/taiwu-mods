using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPlace : ConfigData<CricketPlaceItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CricketPlace Instance = new CricketPlace();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "UselessItemList", "TemplateId", "Icon", "CatchAniBack", "CatchAni" };

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
		_dataArray.Add(new CricketPlaceItem(0, 1, 2, 3, 6, 12, 96, 12, 32, new string[3][]
		{
			new string[3] { "North_cricket_grass_1", "North_cricket_grass_2", "North_cricket_grass_3" },
			new string[3] { "South_cricket_grass_1", "South_cricket_grass_2", "South_cricket_grass_3" },
			new string[3] { "West_cricket_grass_1", "West_cricket_grass_2", "West_cricket_grass_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_0", "cricket_grass_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(1, 2, 3, 4, 8, 16, 88, 11, 28, new string[3][]
		{
			new string[3] { "North_cricket_Deadwood_1", "North_cricket_Deadwood_2", "North_cricket_Deadwood_3" },
			new string[3] { "South_cricket_Deadwood_1", "South_cricket_Deadwood_2", "South_cricket_Deadwood_3" },
			new string[3] { "West_cricket_Deadwood_1", "West_cricket_Deadwood_2", "West_cricket_Deadwood_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_0", "cricket_wood_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(2, 3, 4, 5, 10, 20, 80, 10, 24, new string[3][]
		{
			new string[3] { "North_cricket_mound_1", "North_cricket_mound_2", "North_cricket_mound_3" },
			new string[3] { "South_cricket_mound_1", "South_cricket_mound_2", "South_cricket_mound_3" },
			new string[3] { "West_cricket_mound_1", "West_cricket_mound_2", "West_cricket_mound_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_3", "cricket_hill_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(3, 4, 5, 6, 12, 24, 72, 9, 20, new string[3][]
		{
			new string[3] { "North_cricket_field_1", "North_cricket_field_2", "North_cricket_field_3" },
			new string[3] { "South_cricket_field_1", "South_cricket_field_2", "South_cricket_field_3" },
			new string[3] { "West_cricket_field_1", "West_cricket_field_2", "West_cricket_field_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_2", "cricket_farm_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(4, 5, 6, 7, 14, 28, 64, 8, 16, new string[3][]
		{
			new string[3] { "North_cricket_cairn_1", "North_cricket_cairn_2", "North_cricket_cairn_3" },
			new string[3] { "South_cricket_cairn_1", "South_cricket_cairn_2", "South_cricket_cairn_3" },
			new string[3] { "West_cricket_cairn_1", "West_cricket_cairn_2", "West_cricket_cairn_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_0", "cricket_stone_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(5, 6, 7, 8, 16, 32, 56, 7, 12, new string[3][]
		{
			new string[3] { "North_cricket_earthenjar_1", "North_cricket_earthenjar_2", "North_cricket_earthenjar_3" },
			new string[3] { "South_cricket_earthenjar_1", "South_cricket_earthenjar_2", "South_cricket_earthenjar_3" },
			new string[3] { "West_cricket_earthenjar_1", "West_cricket_earthenjar_2", "West_cricket_earthenjar_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_1", "cricket_crock_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(6, 7, 8, 9, 18, 36, 48, 6, 6, new string[3][]
		{
			new string[3] { "North_cricket_woodpile_1", "North_cricket_woodpile_2", "North_cricket_woodpile_3" },
			new string[3] { "South_cricket_woodpile_1", "South_cricket_woodpile_2", "South_cricket_woodpile_3" },
			new string[3] { "West_cricket_woodpile_1", "West_cricket_woodpile_2", "West_cricket_woodpile_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_0", "cricket_rick_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(7, 8, 9, 10, 20, 40, 40, 5, 3, new string[3][]
		{
			new string[3] { "North_cricket_cave_1", "North_cricket_cave_2", "North_cricket_cave_3" },
			new string[3] { "South_cricket_cave_1", "South_cricket_cave_2", "South_cricket_cave_3" },
			new string[3] { "West_cricket_cave_1", "West_cricket_cave_2", "West_cricket_cave_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_2", "cricket_cave_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(8, 9, 10, 11, 22, 44, 32, 4, 2, new string[3][]
		{
			new string[3] { "North_cricket_bluebrick_1", "North_cricket_bluebrick_2", "North_cricket_bluebrick_3" },
			new string[3] { "South_cricket_bluebrick_1", "South_cricket_bluebrick_2", "South_cricket_bluebrick_3" },
			new string[3] { "West_cricket_bluebrick_1", "West_cricket_bluebrick_2", "West_cricket_bluebrick_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_1", "cricket_bull_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
		_dataArray.Add(new CricketPlaceItem(9, 10, 11, 12, 24, 48, 24, 3, 1, new string[3][]
		{
			new string[3] { "North_cricket_grave_1", "North_cricket_grave_2", "North_cricket_grave_3" },
			new string[3] { "South_cricket_grave_1", "South_cricket_grave_2", "South_cricket_grave_3" },
			new string[3] { "West_cricket_grave_1", "West_cricket_grave_2", "West_cricket_grave_3" }
		}, "ui9_tex_catchcricket_catch_circle_bg_1", "cricket_tomb_SkeletonData", new short[18]
		{
			19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
			29, 30, 31, 32, 33, 34, 35, 36
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketPlaceItem>(10);
		CreateItems0();
	}
}
