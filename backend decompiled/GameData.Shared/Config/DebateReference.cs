using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateReference : ConfigData<DebateReferenceItem, short>
{
	public static DebateReference Instance = new DebateReference();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "LifeSkillType", "SectType", "CombatSkillType", "TemplateId" };

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
		_dataArray.Add(new DebateReferenceItem(0, 0, 0, -1, new short[16]
		{
			20, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(1, 1, 0, -1, new short[16]
		{
			0, 20, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(2, 2, 0, -1, new short[16]
		{
			0, 0, 20, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(3, 3, 0, -1, new short[16]
		{
			0, 0, 0, 20, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(4, 4, 0, -1, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(5, 5, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 20, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(6, 6, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 20, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(7, 7, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 20, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(8, 8, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(9, 9, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(10, 10, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			20, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(11, 11, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 20, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(12, 12, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(13, 13, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(14, 14, 0, -1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 20, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(15, 15, 0, -1, new short[16]
		{
			10, 10, 10, 10, 10, 10, 10, 10, 10, 10,
			10, 10, 10, 10, 10, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(16, -1, 1, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(17, -1, 1, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(18, -1, 1, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(19, -1, 1, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(20, -1, 1, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(21, -1, 1, 9, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(22, -1, 2, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(23, -1, 2, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(24, -1, 2, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(25, -1, 2, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(26, -1, 2, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(27, -1, 2, 7, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(28, -1, 2, 10, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(29, -1, 3, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(30, -1, 3, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(31, -1, 3, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(32, -1, 3, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(33, -1, 3, 12, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 20, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(34, -1, 3, 13, new short[16]
		{
			20, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(35, -1, 4, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(36, -1, 4, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(37, -1, 4, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(38, -1, 4, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(39, -1, 4, 7, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(40, -1, 4, 11, new short[16]
		{
			0, 0, 10, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(41, -1, 5, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(42, -1, 5, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(43, -1, 5, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(44, -1, 5, 5, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 10, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(45, -1, 5, 7, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(46, -1, 5, 8, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 20, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(47, -1, 6, 0, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(48, -1, 6, 1, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(49, -1, 6, 2, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(50, -1, 6, 3, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(51, -1, 6, 8, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(52, -1, 6, 9, new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}, new short[16]));
		_dataArray.Add(new DebateReferenceItem(53, -1, 7, 0, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(54, -1, 7, 1, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(55, -1, 7, 2, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(56, -1, 7, 4, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(57, -1, 7, 7, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(58, -1, 7, 10, new short[16], new short[16], new short[16]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1
		}));
		_dataArray.Add(new DebateReferenceItem(59, -1, 8, 0, new short[16]
		{
			0, 0, 0, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new DebateReferenceItem(60, -1, 8, 1, new short[16]
		{
			0, 0, 0, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(61, -1, 8, 2, new short[16]
		{
			0, 0, 0, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(62, -1, 8, 3, new short[16]
		{
			0, 0, 0, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(63, -1, 8, 4, new short[16]
		{
			0, 0, 0, 10, 0, 0, 0, 0, 0, 0,
			0, 0, 10, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(64, -1, 8, 13, new short[16]
		{
			20, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(65, -1, 9, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(66, -1, 9, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(67, -1, 9, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(68, -1, 9, 7, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(69, -1, 9, 8, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(70, -1, 9, 9, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(71, -1, 9, 12, new short[16]
		{
			0, 0, 0, 0, 0, 0, 10, 10, 0, 0,
			10, 10, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(72, -1, 10, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(73, -1, 10, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(74, -1, 10, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(75, -1, 10, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(76, -1, 10, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(77, -1, 10, 5, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(78, -1, 10, 6, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 10, 10,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(79, -1, 11, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(80, -1, 11, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(81, -1, 11, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(82, -1, 11, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(83, -1, 11, 8, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(84, -1, 11, 10, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 20, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(85, -1, 12, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(86, -1, 12, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(87, -1, 12, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(88, -1, 12, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(89, -1, 12, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(90, -1, 12, 7, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(91, -1, 12, 11, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 20,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(92, -1, 13, 0, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(93, -1, 13, 1, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(94, -1, 13, 2, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(95, -1, 13, 4, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(96, -1, 13, 6, new short[16]
		{
			0, 10, 0, 0, 10, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(97, -1, 13, 7, new short[16]
		{
			0, 0, 0, 0, 20, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(98, -1, 14, 0, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(99, -1, 14, 1, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(100, -1, 14, 2, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(101, -1, 14, 3, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(102, -1, 14, 6, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(103, -1, 14, 8, new short[16]
		{
			0, 0, 0, 0, 0, 10, 0, 0, 0, 0,
			0, 0, 0, 0, 10, 10
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(104, -1, 15, 0, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(105, -1, 15, 1, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(106, -1, 15, 2, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(107, -1, 15, 3, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(108, -1, 15, 4, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(109, -1, 15, 5, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
		_dataArray.Add(new DebateReferenceItem(110, -1, 15, 6, new short[16]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 10,
			0, 0, 0, 0, 0, 20
		}, new short[16], new short[16]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateReferenceItem>(111);
		CreateItems0();
		CreateItems1();
	}
}
