using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class MysteryEffect : ConfigData<MysteryEffectItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MysteryEffect Instance = new MysteryEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "BonusValues", "BonusEffects", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new MysteryEffectItem(0, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(139, 20, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(141, 80, percent: false)
			}
		}, new List<short> { 1753, 1768 }));
		_dataArray.Add(new MysteryEffectItem(1, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(1, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(144, 100, percent: false)
			}
		}, new List<short> { 1754, 1769 }));
		_dataArray.Add(new MysteryEffectItem(2, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(4, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(146, 80, percent: false)
			}
		}, new List<short> { 1755, 1770 }));
		_dataArray.Add(new MysteryEffectItem(3, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(136, 20, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(147, 100, percent: false)
			}
		}, new List<short> { 1756, 1771 }));
		_dataArray.Add(new MysteryEffectItem(4, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(2, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(145, 90, percent: false)
			}
		}, new List<short> { 1757, 1772 }));
		_dataArray.Add(new MysteryEffectItem(5, 600, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(0, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(151, 100, percent: false)
			}
		}, new List<short> { 1758, 1773 }));
		_dataArray.Add(new MysteryEffectItem(6, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(5, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(149, 100, percent: false)
			}
		}, new List<short> { 1759, 1774 }));
		_dataArray.Add(new MysteryEffectItem(7, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(138, 20, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(152, 80, percent: false)
			}
		}, new List<short> { 1760, 1775 }));
		_dataArray.Add(new MysteryEffectItem(8, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(3, 30, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(142, 100, percent: false)
			}
		}, new List<short> { 1761, 1776 }));
		_dataArray.Add(new MysteryEffectItem(9, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(140, 20, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(154, 33, percent: true),
				new PropertyAndValueAndModifyType(155, -33, percent: true)
			}
		}, new List<short> { 1762, 1777 }));
		_dataArray.Add(new MysteryEffectItem(10, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(16, 300, percent: false),
				new PropertyAndValueAndModifyType(17, 300, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(148, 90, percent: false)
			}
		}, new List<short> { 1763, 1778 }));
		_dataArray.Add(new MysteryEffectItem(11, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(12, 300, percent: false),
				new PropertyAndValueAndModifyType(13, 300, percent: false),
				new PropertyAndValueAndModifyType(14, 300, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(28, 100, percent: false),
				new PropertyAndValueAndModifyType(29, 100, percent: false),
				new PropertyAndValueAndModifyType(30, 100, percent: false),
				new PropertyAndValueAndModifyType(31, 100, percent: false),
				new PropertyAndValueAndModifyType(32, 100, percent: false),
				new PropertyAndValueAndModifyType(33, 100, percent: false)
			}
		}, new List<short> { 1764, 1779 }));
		_dataArray.Add(new MysteryEffectItem(12, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(6, 300, percent: false),
				new PropertyAndValueAndModifyType(7, 300, percent: false),
				new PropertyAndValueAndModifyType(8, 300, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(153, 50, percent: true)
			}
		}, new List<short> { 1765, 1780 }));
		_dataArray.Add(new MysteryEffectItem(13, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(137, 20, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(143, 90, percent: false)
			}
		}, new List<short> { 1766, 1781 }));
		_dataArray.Add(new MysteryEffectItem(14, 300, new List<int> { 100, 120, 140, 180 }, new List<List<PropertyAndValueAndModifyType>>
		{
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(10, 300, percent: false),
				new PropertyAndValueAndModifyType(11, 300, percent: false)
			},
			new List<PropertyAndValueAndModifyType>
			{
				new PropertyAndValueAndModifyType(150, 90, percent: false)
			}
		}, new List<short> { 1767, 1782 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MysteryEffectItem>(15);
		CreateItems0();
	}
}
