using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefPlace : ConfigData<CatchThiefPlaceItem, sbyte>
{
	public static CatchThiefPlace Instance = new CatchThiefPlace();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Rate", "LevelWeights", "Icon", "CatchAniBack" };

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
		_dataArray.Add(new CatchThiefPlaceItem(0, 15, new int[3][]
		{
			new int[7] { 30, 25, 20, 15, 10, 0, 0 },
			new int[7] { 0, 30, 25, 20, 15, 10, 0 },
			new int[7] { 0, 0, 30, 25, 20, 15, 10 }
		}, "ThiefPlaceImage3", "catchcricket_01_mh_mubu_0"));
		_dataArray.Add(new CatchThiefPlaceItem(1, 14, new int[3][]
		{
			new int[7] { 28, 24, 20, 16, 12, 0, 0 },
			new int[7] { 0, 28, 24, 20, 16, 12, 0 },
			new int[7] { 0, 0, 28, 24, 20, 16, 12 }
		}, "ThiefPlaceImage8", "catchcricket_01_mh_mubu_0"));
		_dataArray.Add(new CatchThiefPlaceItem(2, 13, new int[3][]
		{
			new int[7] { 26, 23, 20, 17, 14, 0, 0 },
			new int[7] { 0, 26, 23, 20, 17, 14, 0 },
			new int[7] { 0, 0, 26, 23, 20, 17, 14 }
		}, "ThiefPlaceImage5", "catchcricket_01_mh_mubu_3"));
		_dataArray.Add(new CatchThiefPlaceItem(3, 12, new int[3][]
		{
			new int[7] { 24, 22, 20, 18, 16, 0, 0 },
			new int[7] { 0, 24, 22, 20, 18, 16, 0 },
			new int[7] { 0, 0, 24, 22, 20, 18, 16 }
		}, "ThiefPlaceImage9", "catchcricket_01_mh_mubu_2"));
		_dataArray.Add(new CatchThiefPlaceItem(4, 11, new int[3][]
		{
			new int[7] { 22, 21, 20, 19, 18, 0, 0 },
			new int[7] { 0, 22, 21, 20, 19, 18, 0 },
			new int[7] { 0, 0, 22, 21, 20, 19, 18 }
		}, "ThiefPlaceImage7", "catchcricket_01_mh_mubu_0"));
		_dataArray.Add(new CatchThiefPlaceItem(5, 9, new int[3][]
		{
			new int[7] { 20, 20, 20, 20, 20, 0, 0 },
			new int[7] { 0, 20, 20, 20, 20, 20, 0 },
			new int[7] { 0, 0, 20, 20, 20, 20, 20 }
		}, "ThiefPlaceImage4", "catchcricket_01_mh_mubu_1"));
		_dataArray.Add(new CatchThiefPlaceItem(6, 8, new int[3][]
		{
			new int[7] { 18, 19, 20, 21, 22, 0, 0 },
			new int[7] { 0, 18, 19, 20, 21, 22, 0 },
			new int[7] { 0, 0, 18, 19, 20, 21, 22 }
		}, "ThiefPlaceImage2", "catchcricket_01_mh_mubu_0"));
		_dataArray.Add(new CatchThiefPlaceItem(7, 7, new int[3][]
		{
			new int[7] { 16, 18, 20, 22, 24, 0, 0 },
			new int[7] { 0, 16, 18, 20, 22, 24, 0 },
			new int[7] { 0, 0, 16, 18, 20, 22, 24 }
		}, "ThiefPlaceImage6", "catchcricket_01_mh_mubu_2"));
		_dataArray.Add(new CatchThiefPlaceItem(8, 6, new int[3][]
		{
			new int[7] { 14, 17, 20, 23, 26, 0, 0 },
			new int[7] { 0, 14, 17, 20, 23, 26, 0 },
			new int[7] { 0, 0, 14, 17, 20, 23, 26 }
		}, "ThiefPlaceImage1", "catchcricket_01_mh_mubu_1"));
		_dataArray.Add(new CatchThiefPlaceItem(9, 5, new int[3][]
		{
			new int[7] { 12, 16, 20, 24, 28, 0, 0 },
			new int[7] { 0, 12, 16, 20, 24, 28, 0 },
			new int[7] { 0, 0, 12, 16, 20, 24, 28 }
		}, "ThiefPlaceImage0", "catchcricket_01_mh_mubu_1"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CatchThiefPlaceItem>(10);
		CreateItems0();
	}
}
