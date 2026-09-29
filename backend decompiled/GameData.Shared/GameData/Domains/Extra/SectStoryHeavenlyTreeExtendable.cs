using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(IsExtensible = true)]
public class SectStoryHeavenlyTreeExtendable : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort Location = 2;

		public const ushort GrowPoint = 3;

		public const ushort TriggerRandomEnemyCount = 4;

		public const ushort MetInDream = 5;

		public const ushort FindFairyland = 6;

		public const ushort FightWithSnake = 7;

		public const ushort SnakeTemplateId = 8;

		public const ushort ReadBookList = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "Id", "TemplateId", "Location", "GrowPoint", "TriggerRandomEnemyCount", "MetInDream", "FindFairyland", "FightWithSnake", "SnakeTemplateId", "ReadBookList" };
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public ushort GrowPoint;

	[SerializableGameDataField]
	public ushort TriggerRandomEnemyCount;

	[SerializableGameDataField]
	public bool MetInDream;

	[SerializableGameDataField]
	public bool FindFairyland;

	[SerializableGameDataField]
	public bool FightWithSnake;

	[SerializableGameDataField]
	public short SnakeTemplateId;

	[SerializableGameDataField]
	public List<short> ReadBookList;

	public bool IsGrowPointMax => GrowPoint >= 900;

	public int GrowTemplateId => GameData.Domains.World.SharedMethods.GetHeavenlyTreeTemplateIdByGrowValue(GrowPoint);

	public SectStoryHeavenlyTreeExtendable(int id, short templateId, Location location)
	{
		Id = id;
		TemplateId = templateId;
		Location = location;
		GrowPoint = 0;
		TriggerRandomEnemyCount = 0;
	}

	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, ushort growPoint)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
		TriggerRandomEnemyCount = tree.TriggerRandomEnemyCount;
	}

	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, ushort growPoint, ushort triggerRandomEnemyCount)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
		TriggerRandomEnemyCount = triggerRandomEnemyCount;
	}

	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, int id)
	{
		Id = id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = tree.GrowPoint;
		TriggerRandomEnemyCount = tree.TriggerRandomEnemyCount;
	}

	public SectStoryHeavenlyTreeExtendable()
	{
	}

	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		Location = other.Location;
		GrowPoint = other.GrowPoint;
		TriggerRandomEnemyCount = other.TriggerRandomEnemyCount;
		MetInDream = other.MetInDream;
		FindFairyland = other.FindFairyland;
		FightWithSnake = other.FightWithSnake;
		SnakeTemplateId = other.SnakeTemplateId;
		ReadBookList = ((other.ReadBookList == null) ? null : new List<short>(other.ReadBookList));
	}

	public void Assign(SectStoryHeavenlyTreeExtendable other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		Location = other.Location;
		GrowPoint = other.GrowPoint;
		TriggerRandomEnemyCount = other.TriggerRandomEnemyCount;
		MetInDream = other.MetInDream;
		FindFairyland = other.FindFairyland;
		FightWithSnake = other.FightWithSnake;
		SnakeTemplateId = other.SnakeTemplateId;
		ReadBookList = ((other.ReadBookList == null) ? null : new List<short>(other.ReadBookList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		totalSize = ((ReadBookList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReadBookList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 10;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(ushort*)pCurrData = GrowPoint;
		pCurrData += 2;
		*(ushort*)pCurrData = TriggerRandomEnemyCount;
		pCurrData += 2;
		*pCurrData = (MetInDream ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (FindFairyland ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (FightWithSnake ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = SnakeTemplateId;
		pCurrData += 2;
		if (ReadBookList != null)
		{
			int elementsCount = ReadBookList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ReadBookList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			GrowPoint = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			TriggerRandomEnemyCount = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			MetInDream = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 6)
		{
			FindFairyland = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 7)
		{
			FightWithSnake = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 8)
		{
			SnakeTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 9)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ReadBookList == null)
				{
					ReadBookList = new List<short>(elementsCount);
				}
				else
				{
					ReadBookList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ReadBookList.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				ReadBookList?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
