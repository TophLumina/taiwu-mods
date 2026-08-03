using System;
using System.Collections.Generic;

namespace Config;

[Serializable]
public struct LifeSkillPageUnlockItem
{
	/// <summary>
	/// 通过解锁名称索引到解锁类型
	/// </summary>
	private static readonly Dictionary<string, LifeSkillPageUnlockType> Name2UnlockType;

	public LifeSkillPageUnlockType Type;

	public int[] IdList;

	public LifeSkillPageUnlockItem(sbyte type, int[] idList)
	{
		Type = (LifeSkillPageUnlockType)type;
		IdList = idList;
	}

	public LifeSkillPageUnlockItem(string type, int[] idList)
	{
		Type = Name2UnlockType[type];
		IdList = idList;
	}

	static LifeSkillPageUnlockItem()
	{
		Name2UnlockType = new Dictionary<string, LifeSkillPageUnlockType>
		{
			{
				"BuildingBlock",
				LifeSkillPageUnlockType.Building
			},
			{
				"Knowledge",
				LifeSkillPageUnlockType.Knowledge
			},
			{
				"Card",
				LifeSkillPageUnlockType.Card
			}
		};
	}
}
