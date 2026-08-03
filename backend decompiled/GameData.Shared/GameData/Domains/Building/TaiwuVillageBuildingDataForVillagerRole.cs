using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑管理界面的显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class TaiwuVillageBuildingDataForVillagerRole : ISerializableGameData
{
	/// <summary>
	/// 太吾已学功法
	/// </summary>
	[SerializableGameDataField]
	public List<short> LearnedCombatSkillItems;

	/// <summary>
	/// 太吾已学技艺
	/// </summary>
	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkillItems;

	/// <summary>
	/// 可以使用的建筑心材
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> CanUseBuildingCore;

	/// <summary>
	/// 太吾在野外时行囊里的建筑心材
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> CannotUseInventoryBuildingCore;

	[SerializableGameDataField]
	public int BuildingSpaceCurr;

	[SerializableGameDataField]
	public int BuildingSpaceLimit;

	[SerializableGameDataField]
	public BuildingAreaData AreaData;

	[SerializableGameDataField]
	public List<BuildingBlockData> BlockList;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TaiwuVillageBuildingDataForVillagerRole()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize = ((LearnedCombatSkillItems == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkillItems.Count)));
		totalSize = ((LearnedLifeSkillItems == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LearnedLifeSkillItems.Count)));
		if (CanUseBuildingCore != null)
		{
			totalSize += 2;
			int elementsCount = CanUseBuildingCore.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = CanUseBuildingCore[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CannotUseInventoryBuildingCore != null)
		{
			totalSize += 2;
			int elementsCount2 = CannotUseInventoryBuildingCore.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				ItemDisplayData element2 = CannotUseInventoryBuildingCore[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BlockList != null)
		{
			totalSize += 2;
			int elementsCount3 = BlockList.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				BuildingBlockData element3 = BlockList[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (LearnedCombatSkillItems != null)
		{
			int elementsCount = LearnedCombatSkillItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = LearnedCombatSkillItems[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedLifeSkillItems != null)
		{
			int elementsCount2 = LearnedLifeSkillItems.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += LearnedLifeSkillItems[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CanUseBuildingCore != null)
		{
			int elementsCount3 = CanUseBuildingCore.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				ItemDisplayData element = CanUseBuildingCore[k];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CannotUseInventoryBuildingCore != null)
		{
			int elementsCount4 = CannotUseInventoryBuildingCore.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				ItemDisplayData element2 = CannotUseInventoryBuildingCore[l];
				if (element2 != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = BuildingSpaceCurr;
		pCurrData += 4;
		*(int*)pCurrData = BuildingSpaceLimit;
		pCurrData += 4;
		pCurrData += AreaData.Serialize(pCurrData);
		if (BlockList != null)
		{
			int elementsCount5 = BlockList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				BuildingBlockData element3 = BlockList[m];
				if (element3 != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)subDataSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedCombatSkillItems == null)
			{
				LearnedCombatSkillItems = new List<short>(elementsCount);
			}
			else
			{
				LearnedCombatSkillItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				LearnedCombatSkillItems.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			LearnedCombatSkillItems?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (LearnedLifeSkillItems == null)
			{
				LearnedLifeSkillItems = new List<LifeSkillItem>(elementsCount2);
			}
			else
			{
				LearnedLifeSkillItems.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				LifeSkillItem element = default(LifeSkillItem);
				pCurrData += element.Deserialize(pCurrData);
				LearnedLifeSkillItems.Add(element);
			}
		}
		else
		{
			LearnedLifeSkillItems?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (CanUseBuildingCore == null)
			{
				CanUseBuildingCore = new List<ItemDisplayData>(elementsCount3);
			}
			else
			{
				CanUseBuildingCore.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					ItemDisplayData element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					CanUseBuildingCore.Add(element2);
				}
				else
				{
					CanUseBuildingCore.Add(null);
				}
			}
		}
		else
		{
			CanUseBuildingCore?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (CannotUseInventoryBuildingCore == null)
			{
				CannotUseInventoryBuildingCore = new List<ItemDisplayData>(elementsCount4);
			}
			else
			{
				CannotUseInventoryBuildingCore.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					ItemDisplayData element3 = new ItemDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
					CannotUseInventoryBuildingCore.Add(element3);
				}
				else
				{
					CannotUseInventoryBuildingCore.Add(null);
				}
			}
		}
		else
		{
			CannotUseInventoryBuildingCore?.Clear();
		}
		BuildingSpaceCurr = *(int*)pCurrData;
		pCurrData += 4;
		BuildingSpaceLimit = *(int*)pCurrData;
		pCurrData += 4;
		if (AreaData == null)
		{
			AreaData = new BuildingAreaData();
		}
		pCurrData += AreaData.Deserialize(pCurrData);
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (BlockList == null)
			{
				BlockList = new List<BuildingBlockData>(elementsCount5);
			}
			else
			{
				BlockList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					BuildingBlockData element4 = new BuildingBlockData();
					pCurrData += element4.Deserialize(pCurrData);
					BlockList.Add(element4);
				}
				else
				{
					BlockList.Add(null);
				}
			}
		}
		else
		{
			BlockList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
