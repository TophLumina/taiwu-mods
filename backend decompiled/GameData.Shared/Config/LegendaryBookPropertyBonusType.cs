using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class LegendaryBookPropertyBonusType : ConfigData<LegendaryBookPropertyBonusTypeItem, short>
{
	public static LegendaryBookPropertyBonusType Instance = new LegendaryBookPropertyBonusType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "PropertyBonusList", "TemplateId" };

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
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(0, new PropertyAndValue[2]
		{
			new PropertyAndValue(10, 5),
			new PropertyAndValue(11, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(1, new PropertyAndValue[2]
		{
			new PropertyAndValue(10, 3),
			new PropertyAndValue(11, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(2, new PropertyAndValue[2]
		{
			new PropertyAndValue(16, 5),
			new PropertyAndValue(17, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(3, new PropertyAndValue[2]
		{
			new PropertyAndValue(16, 3),
			new PropertyAndValue(17, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(4, new PropertyAndValue[4]
		{
			new PropertyAndValue(6, 3),
			new PropertyAndValue(7, 3),
			new PropertyAndValue(8, 3),
			new PropertyAndValue(9, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(5, new PropertyAndValue[1]
		{
			new PropertyAndValue(6, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(6, new PropertyAndValue[1]
		{
			new PropertyAndValue(7, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(7, new PropertyAndValue[1]
		{
			new PropertyAndValue(8, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(8, new PropertyAndValue[3]
		{
			new PropertyAndValue(6, 3),
			new PropertyAndValue(7, 3),
			new PropertyAndValue(8, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(9, new PropertyAndValue[4]
		{
			new PropertyAndValue(12, 3),
			new PropertyAndValue(13, 3),
			new PropertyAndValue(14, 3),
			new PropertyAndValue(15, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(10, new PropertyAndValue[1]
		{
			new PropertyAndValue(12, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(11, new PropertyAndValue[1]
		{
			new PropertyAndValue(13, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(12, new PropertyAndValue[1]
		{
			new PropertyAndValue(14, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(13, new PropertyAndValue[3]
		{
			new PropertyAndValue(12, 3),
			new PropertyAndValue(13, 3),
			new PropertyAndValue(14, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(14, new PropertyAndValue[2]
		{
			new PropertyAndValue(9, 10),
			new PropertyAndValue(15, 10)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(15, new PropertyAndValue[4]
		{
			new PropertyAndValue(26, 10),
			new PropertyAndValue(27, 10),
			new PropertyAndValue(18, 10),
			new PropertyAndValue(19, 10)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(16, new PropertyAndValue[4]
		{
			new PropertyAndValue(21, 10),
			new PropertyAndValue(20, 10),
			new PropertyAndValue(25, 10),
			new PropertyAndValue(24, 10)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(17, new PropertyAndValue[4]
		{
			new PropertyAndValue(18, 10),
			new PropertyAndValue(19, 10),
			new PropertyAndValue(22, 10),
			new PropertyAndValue(23, 10)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(18, new PropertyAndValue[2]
		{
			new PropertyAndValue(18, 15),
			new PropertyAndValue(19, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(19, new PropertyAndValue[2]
		{
			new PropertyAndValue(23, 15),
			new PropertyAndValue(22, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(20, new PropertyAndValue[2]
		{
			new PropertyAndValue(21, 15),
			new PropertyAndValue(20, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(21, new PropertyAndValue[2]
		{
			new PropertyAndValue(25, 15),
			new PropertyAndValue(20, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(22, new PropertyAndValue[2]
		{
			new PropertyAndValue(26, 15),
			new PropertyAndValue(22, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(23, new PropertyAndValue[2]
		{
			new PropertyAndValue(24, 15),
			new PropertyAndValue(25, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(24, new PropertyAndValue[2]
		{
			new PropertyAndValue(21, 15),
			new PropertyAndValue(24, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(25, new PropertyAndValue[2]
		{
			new PropertyAndValue(24, 15),
			new PropertyAndValue(22, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(26, new PropertyAndValue[2]
		{
			new PropertyAndValue(20, 15),
			new PropertyAndValue(23, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(27, new PropertyAndValue[2]
		{
			new PropertyAndValue(25, 15),
			new PropertyAndValue(27, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(28, new PropertyAndValue[2]
		{
			new PropertyAndValue(26, 15),
			new PropertyAndValue(27, 15)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(29, new PropertyAndValue[1]
		{
			new PropertyAndValue(66, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(30, new PropertyAndValue[1]
		{
			new PropertyAndValue(67, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(31, new PropertyAndValue[1]
		{
			new PropertyAndValue(68, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(32, new PropertyAndValue[1]
		{
			new PropertyAndValue(69, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(33, new PropertyAndValue[1]
		{
			new PropertyAndValue(70, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(34, new PropertyAndValue[1]
		{
			new PropertyAndValue(71, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(35, new PropertyAndValue[1]
		{
			new PropertyAndValue(72, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(36, new PropertyAndValue[1]
		{
			new PropertyAndValue(73, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(37, new PropertyAndValue[1]
		{
			new PropertyAndValue(74, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(38, new PropertyAndValue[1]
		{
			new PropertyAndValue(75, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(39, new PropertyAndValue[1]
		{
			new PropertyAndValue(76, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(40, new PropertyAndValue[1]
		{
			new PropertyAndValue(77, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(41, new PropertyAndValue[1]
		{
			new PropertyAndValue(78, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(42, new PropertyAndValue[1]
		{
			new PropertyAndValue(79, 5)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(43, new PropertyAndValue[1]
		{
			new PropertyAndValue(66, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(44, new PropertyAndValue[1]
		{
			new PropertyAndValue(67, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(45, new PropertyAndValue[1]
		{
			new PropertyAndValue(68, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(46, new PropertyAndValue[1]
		{
			new PropertyAndValue(69, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(47, new PropertyAndValue[1]
		{
			new PropertyAndValue(70, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(48, new PropertyAndValue[1]
		{
			new PropertyAndValue(71, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(49, new PropertyAndValue[1]
		{
			new PropertyAndValue(72, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(50, new PropertyAndValue[1]
		{
			new PropertyAndValue(73, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(51, new PropertyAndValue[1]
		{
			new PropertyAndValue(74, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(52, new PropertyAndValue[1]
		{
			new PropertyAndValue(75, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(53, new PropertyAndValue[1]
		{
			new PropertyAndValue(76, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(54, new PropertyAndValue[1]
		{
			new PropertyAndValue(77, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(55, new PropertyAndValue[1]
		{
			new PropertyAndValue(78, 3)
		}));
		_dataArray.Add(new LegendaryBookPropertyBonusTypeItem(56, new PropertyAndValue[1]
		{
			new PropertyAndValue(79, 3)
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LegendaryBookPropertyBonusTypeItem>(57);
		CreateItems0();
	}
}
