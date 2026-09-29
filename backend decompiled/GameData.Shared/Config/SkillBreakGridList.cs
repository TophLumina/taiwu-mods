using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridList : ConfigData<SkillBreakGridListItem, short>
{
	public static SkillBreakGridList Instance = new SkillBreakGridList();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "BreakGridListJust", "BreakGridListKind", "BreakGridListEven", "BreakGridListRebel", "BreakGridListEgoistic", "TemplateId" };

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
		_dataArray.Add(new SkillBreakGridListItem(0, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(1, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(2, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(3, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(4, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(5, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(6, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(7, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(8, new List<BreakGrid>
		{
			new BreakGrid(12, 4),
			new BreakGrid(13, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 4),
			new BreakGrid(17, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 4),
			new BreakGrid(21, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 4),
			new BreakGrid(15, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 4),
			new BreakGrid(19, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(9, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(10, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(11, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(12, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(13, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(14, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(15, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(16, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(17, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(18, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(19, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(20, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(21, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(22, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(23, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(24, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(25, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(26, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(27, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(28, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(29, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(30, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(31, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(32, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(33, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(34, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(35, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(36, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(37, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(38, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(39, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(40, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(41, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(42, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(43, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(44, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(45, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(46, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(47, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(48, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(49, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(50, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(51, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(52, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(53, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(54, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(55, new List<BreakGrid>
		{
			new BreakGrid(12, 4),
			new BreakGrid(13, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 4),
			new BreakGrid(17, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 4),
			new BreakGrid(21, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 4),
			new BreakGrid(15, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 4),
			new BreakGrid(19, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(56, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(57, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(58, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(59, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SkillBreakGridListItem(60, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(61, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(62, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(63, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(64, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(65, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(66, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(67, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(68, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(69, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(70, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(71, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(72, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(73, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(74, new List<BreakGrid>
		{
			new BreakGrid(12, 4),
			new BreakGrid(13, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 4),
			new BreakGrid(17, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 4),
			new BreakGrid(21, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 4),
			new BreakGrid(15, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 4),
			new BreakGrid(19, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(75, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(76, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(77, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(78, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(79, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(80, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(81, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(82, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(83, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(84, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(85, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(86, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(87, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(88, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(89, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(90, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(91, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(92, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(93, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(94, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(95, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(96, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(97, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 1),
			new BreakGrid(37, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(98, new List<BreakGrid>
		{
			new BreakGrid(12, 1),
			new BreakGrid(13, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 1),
			new BreakGrid(17, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 1),
			new BreakGrid(21, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 1),
			new BreakGrid(15, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 1),
			new BreakGrid(19, 1),
			new BreakGrid(36, 2),
			new BreakGrid(37, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(99, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(100, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 4),
			new BreakGrid(37, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(101, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(102, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(103, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 7),
			new BreakGrid(37, 7),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(104, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 8),
			new BreakGrid(37, 8),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(105, new List<BreakGrid>
		{
			new BreakGrid(12, 4),
			new BreakGrid(13, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 4),
			new BreakGrid(17, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 4),
			new BreakGrid(21, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 4),
			new BreakGrid(15, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 4),
			new BreakGrid(19, 4),
			new BreakGrid(36, 9),
			new BreakGrid(37, 9),
			new BreakGrid(39, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(106, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(107, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(108, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(109, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(110, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(111, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(112, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(113, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(114, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(115, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(116, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(117, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(118, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(119, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SkillBreakGridListItem(120, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(121, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(122, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(123, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(124, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(125, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(126, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(127, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(128, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(129, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(130, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(131, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(132, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(133, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(134, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(135, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(136, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(137, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(138, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(139, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(140, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(141, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(142, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(143, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(144, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(145, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(146, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(147, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(148, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(149, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(150, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(151, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(152, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(153, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(154, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(155, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(156, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(157, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(158, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(159, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(160, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(161, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(162, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(163, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(164, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(165, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(166, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(167, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(168, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(169, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(170, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(171, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(172, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(173, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(174, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(175, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(176, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(177, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(178, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(179, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SkillBreakGridListItem(180, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(181, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(182, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(183, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(184, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(185, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(186, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(187, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(188, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(189, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(190, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(191, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(192, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(193, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(194, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(195, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(196, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(197, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(198, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(199, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(200, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(201, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(202, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(203, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(204, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(205, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(206, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(207, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(208, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(209, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(210, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(211, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(212, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(213, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(214, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(215, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(216, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(217, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(218, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(219, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(220, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(221, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(222, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(223, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(224, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(225, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(226, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(227, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(228, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(229, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(230, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(231, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(232, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(233, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(234, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(235, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(236, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(237, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(238, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(239, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SkillBreakGridListItem(240, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(241, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(242, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(243, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(244, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(245, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(246, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(247, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(248, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(249, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(250, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(251, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(252, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(253, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(254, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(255, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(256, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(257, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(258, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(259, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(260, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(261, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(262, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(263, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(264, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(265, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(266, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(267, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(268, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(269, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(270, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(271, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(272, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(273, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(274, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(275, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(276, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(277, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(278, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(279, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(280, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(281, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(282, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(283, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(284, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(285, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(286, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(287, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(288, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(289, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(290, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(291, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(292, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(293, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(294, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(295, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(296, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(297, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(298, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(299, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new SkillBreakGridListItem(300, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(301, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(302, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(303, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(304, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(305, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(306, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(307, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(308, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(309, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(310, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(311, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(312, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(313, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 1),
			new BreakGrid(7, 1),
			new BreakGrid(8, 1),
			new BreakGrid(9, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1),
			new BreakGrid(10, 1),
			new BreakGrid(11, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 1),
			new BreakGrid(1, 1),
			new BreakGrid(2, 1),
			new BreakGrid(3, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 1),
			new BreakGrid(5, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(314, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(6, 2),
			new BreakGrid(7, 2),
			new BreakGrid(8, 2),
			new BreakGrid(9, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(0, 2),
			new BreakGrid(1, 2),
			new BreakGrid(2, 2),
			new BreakGrid(3, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(315, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(316, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 3),
			new BreakGrid(7, 3),
			new BreakGrid(8, 3),
			new BreakGrid(9, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 2),
			new BreakGrid(5, 2),
			new BreakGrid(10, 2),
			new BreakGrid(11, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 3),
			new BreakGrid(1, 3),
			new BreakGrid(2, 3),
			new BreakGrid(3, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(317, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(6, 4),
			new BreakGrid(7, 4),
			new BreakGrid(8, 4),
			new BreakGrid(9, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(0, 4),
			new BreakGrid(1, 4),
			new BreakGrid(2, 4),
			new BreakGrid(3, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4)
		}));
		_dataArray.Add(new SkillBreakGridListItem(318, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(319, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 5),
			new BreakGrid(11, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 5),
			new BreakGrid(7, 5),
			new BreakGrid(8, 5),
			new BreakGrid(9, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 3),
			new BreakGrid(5, 3),
			new BreakGrid(10, 3),
			new BreakGrid(11, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 5),
			new BreakGrid(1, 5),
			new BreakGrid(2, 5),
			new BreakGrid(3, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 5),
			new BreakGrid(5, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(320, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(10, 6),
			new BreakGrid(11, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(6, 6),
			new BreakGrid(7, 6),
			new BreakGrid(8, 6),
			new BreakGrid(9, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(4, 4),
			new BreakGrid(5, 4),
			new BreakGrid(10, 4),
			new BreakGrid(11, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(0, 6),
			new BreakGrid(1, 6),
			new BreakGrid(2, 6),
			new BreakGrid(3, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(4, 6),
			new BreakGrid(5, 6)
		}));
		_dataArray.Add(new SkillBreakGridListItem(321, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(322, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(323, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(324, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(325, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(326, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(327, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(328, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(329, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(330, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(331, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(332, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(333, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(334, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(335, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(336, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(337, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(338, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(339, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(340, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(341, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(342, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(343, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(344, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(345, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(346, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(347, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(348, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(349, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(350, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(351, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(352, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(353, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(354, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(355, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(356, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(357, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(358, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(359, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new SkillBreakGridListItem(360, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(361, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(362, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(363, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(364, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(365, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(366, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(367, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(368, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(369, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(370, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(371, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(372, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(373, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(374, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(375, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(376, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(377, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(378, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(379, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(380, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(381, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(382, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(383, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(384, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(385, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(386, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(387, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(388, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(389, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(390, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(391, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(392, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(393, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(394, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(395, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(396, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(397, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(398, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(399, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(400, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(401, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(402, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(403, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(404, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(405, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(406, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(407, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(408, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(409, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(410, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(411, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(412, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(413, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(414, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(415, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(416, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(417, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(418, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(419, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new SkillBreakGridListItem(420, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(421, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(422, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(423, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(424, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(425, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(426, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(427, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(428, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(429, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(430, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(431, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(432, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(433, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(434, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(435, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(436, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(437, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(438, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(439, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(440, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(441, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(442, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(443, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(444, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(445, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(446, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(447, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(448, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(449, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(450, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(451, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(452, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(453, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(454, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(455, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(456, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(457, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(458, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(459, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(460, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(461, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(462, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(463, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(464, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(465, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(466, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(467, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(468, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(469, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(470, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(471, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(472, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(473, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(474, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(475, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(476, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(477, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(478, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(479, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new SkillBreakGridListItem(480, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(481, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(482, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(483, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(484, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(485, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(486, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(487, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(488, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1),
			new BreakGrid(40, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(40, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(489, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(490, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(491, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2),
			new BreakGrid(40, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(40, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(492, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(493, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3),
			new BreakGrid(40, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(40, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(494, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(495, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(496, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(497, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(498, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(499, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(500, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(501, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(502, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(503, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(504, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(505, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(506, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(507, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(508, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(509, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(510, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(511, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(512, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(513, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(514, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(515, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(516, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(517, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(518, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(519, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(520, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(521, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(522, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(523, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(524, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(525, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(526, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(527, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(528, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(529, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(530, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(531, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(532, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(533, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(534, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(535, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(536, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(537, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(538, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(539, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new SkillBreakGridListItem(540, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(541, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(542, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(543, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(544, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(545, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(546, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(547, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(548, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(549, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(550, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(551, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(552, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(553, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(554, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(555, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(556, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(557, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(558, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(559, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(560, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(561, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(562, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(563, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(564, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(565, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(566, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(567, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(568, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(569, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(570, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(571, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(572, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(573, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(574, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(575, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(576, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(577, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(578, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(579, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(580, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(581, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(582, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(583, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(584, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(585, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(586, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(587, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(588, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(589, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(590, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(591, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(592, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(593, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(594, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(595, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(596, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(597, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(598, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(599, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new SkillBreakGridListItem(600, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(601, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(602, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(603, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(604, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(605, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(606, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(607, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(608, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(609, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(610, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(611, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(612, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(613, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(614, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(615, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(616, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(617, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(618, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(619, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(620, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(621, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(622, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(623, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(624, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(625, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(626, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(627, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(628, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(629, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(630, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(631, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(632, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(633, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(634, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(635, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(636, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(637, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(638, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(639, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(640, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(641, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(642, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(643, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(644, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(645, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(646, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(647, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(648, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(649, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(650, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(651, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(652, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(653, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(654, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(655, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(656, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(657, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(658, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(659, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
	}

	private void CreateItems11()
	{
		_dataArray.Add(new SkillBreakGridListItem(660, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(661, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(662, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(663, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(664, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(665, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(666, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(667, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(668, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(669, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(670, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(671, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(672, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(673, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(674, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(675, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(676, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(677, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(678, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(679, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(680, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(681, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(682, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(683, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(684, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(685, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(686, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(687, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(688, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(689, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(690, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(691, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(692, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(693, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(694, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(695, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(696, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(697, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(698, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(699, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(700, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(701, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(702, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(703, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(704, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(705, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(706, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(707, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(708, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(709, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(710, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(711, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(712, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(713, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(714, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(715, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 2),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(716, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 3),
			new BreakGrid(60, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 1),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(33, 1),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 1),
			new BreakGrid(59, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(717, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(718, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 3),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(719, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 4),
			new BreakGrid(60, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(32, 2),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 2),
			new BreakGrid(31, 2),
			new BreakGrid(33, 2),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 2),
			new BreakGrid(59, 2)
		}));
	}

	private void CreateItems12()
	{
		_dataArray.Add(new SkillBreakGridListItem(720, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(721, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 4),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 4),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(722, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(723, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 2),
			new BreakGrid(33, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 2),
			new BreakGrid(33, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 2),
			new BreakGrid(33, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 2),
			new BreakGrid(33, 2)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 1),
			new BreakGrid(31, 1),
			new BreakGrid(32, 2),
			new BreakGrid(33, 2)
		}));
		_dataArray.Add(new SkillBreakGridListItem(724, new List<BreakGrid>
		{
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(36, 3),
			new BreakGrid(37, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(725, new List<BreakGrid>
		{
			new BreakGrid(46, 1),
			new BreakGrid(47, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(46, 1),
			new BreakGrid(47, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(46, 1),
			new BreakGrid(47, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(46, 1),
			new BreakGrid(47, 1)
		}, new List<BreakGrid>
		{
			new BreakGrid(46, 1),
			new BreakGrid(47, 1)
		}));
		_dataArray.Add(new SkillBreakGridListItem(726, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(727, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(728, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(729, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(730, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(731, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(732, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(733, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(734, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(735, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(736, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(737, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(738, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(739, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(740, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(741, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(742, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(743, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(744, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(745, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(746, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(747, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(748, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(749, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(750, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(751, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(752, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(753, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(754, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(755, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(756, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(757, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(758, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(759, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(760, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(761, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(762, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(763, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(764, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(765, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(766, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(767, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(768, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(769, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(770, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(771, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(772, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(773, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(774, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(775, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(776, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(777, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(778, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(779, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
	}

	private void CreateItems13()
	{
		_dataArray.Add(new SkillBreakGridListItem(780, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(781, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(782, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(783, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(784, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(785, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(786, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(787, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(788, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(789, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(790, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(791, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(792, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(793, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(794, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(795, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(796, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(797, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(798, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(799, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(800, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(801, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(802, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(803, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(804, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(805, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(806, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(807, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(808, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(809, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(810, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(811, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(812, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(813, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(814, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(815, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(816, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(817, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(818, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(819, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(820, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(821, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(822, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(823, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(824, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(825, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(826, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(827, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(828, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(829, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(830, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(831, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(832, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(833, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(834, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(835, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(836, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(837, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(838, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(839, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
	}

	private void CreateItems14()
	{
		_dataArray.Add(new SkillBreakGridListItem(840, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(841, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(842, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(843, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(844, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(845, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(846, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(847, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(848, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(849, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(850, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(851, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(852, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(853, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(854, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(855, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(856, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(857, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(858, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(859, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(860, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(861, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(862, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(863, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(864, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(865, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(866, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(867, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(868, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(869, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(870, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(871, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(872, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(873, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(874, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(875, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(876, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(877, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(878, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(879, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(880, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(881, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(882, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(883, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(884, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(885, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(886, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(887, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(888, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(889, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(890, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(891, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(892, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(893, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(894, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(895, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(896, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(897, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(898, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(899, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
	}

	private void CreateItems15()
	{
		_dataArray.Add(new SkillBreakGridListItem(900, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(901, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(902, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(903, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(904, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(905, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(906, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(907, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(908, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(909, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(910, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(911, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(912, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(913, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(914, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(915, new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>(), new List<BreakGrid>()));
		_dataArray.Add(new SkillBreakGridListItem(916, new List<BreakGrid>
		{
			new BreakGrid(12, 2),
			new BreakGrid(13, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 2),
			new BreakGrid(17, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 2),
			new BreakGrid(21, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 2),
			new BreakGrid(15, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 2),
			new BreakGrid(19, 2),
			new BreakGrid(36, 5),
			new BreakGrid(37, 5)
		}));
		_dataArray.Add(new SkillBreakGridListItem(917, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 5),
			new BreakGrid(60, 3)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(32, 3),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(59, 4),
			new BreakGrid(60, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 3),
			new BreakGrid(31, 3),
			new BreakGrid(33, 3),
			new BreakGrid(59, 4)
		}, new List<BreakGrid>
		{
			new BreakGrid(30, 5),
			new BreakGrid(31, 3),
			new BreakGrid(59, 3)
		}));
		_dataArray.Add(new SkillBreakGridListItem(918, new List<BreakGrid>
		{
			new BreakGrid(12, 3),
			new BreakGrid(13, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(16, 3),
			new BreakGrid(17, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(20, 3),
			new BreakGrid(21, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(14, 3),
			new BreakGrid(15, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}, new List<BreakGrid>
		{
			new BreakGrid(18, 3),
			new BreakGrid(19, 3),
			new BreakGrid(36, 6),
			new BreakGrid(37, 6)
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakGridListItem>(919);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
		CreateItems10();
		CreateItems11();
		CreateItems12();
		CreateItems13();
		CreateItems14();
		CreateItems15();
	}
}
