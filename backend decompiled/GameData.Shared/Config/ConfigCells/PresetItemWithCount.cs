using System;
using GameData.Domains.Item;

namespace Config.ConfigCells;

[Serializable]
public class PresetItemWithCount
{
	public sbyte ItemType;

	public short TemplateId;

	public int Count;

	public bool IsValid
	{
		get
		{
			if (ItemType != -1 && TemplateId != -1)
			{
				return Count != -1;
			}
			return false;
		}
	}

	public PresetItemWithCount(string type, short templateId, int count)
	{
		ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[type];
		TemplateId = templateId;
		Count = count;
	}

	public PresetItemWithCount()
	{
		ItemType = -1;
		TemplateId = -1;
		Count = -1;
	}
}
