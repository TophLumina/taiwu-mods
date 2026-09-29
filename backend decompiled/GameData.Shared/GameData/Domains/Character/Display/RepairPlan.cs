using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Config;
using GameData.Domains.Building;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true, NotForArchive = true)]
public class RepairPlan : ISerializableGameData
{
	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ItemDisplayData[] CostDurabilityPage1 = new ItemDisplayData[17];

	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ItemDisplayData[] CostDurabilityPage2 = new ItemDisplayData[17];

	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ItemDisplayData[] CostDurabilityPageAll = new ItemDisplayData[17];

	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ItemDisplayData[] CostDurabilityDetail = new ItemDisplayData[17];

	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ResourceInts[] CostResources = new ResourceInts[17];

	[SerializableGameDataField]
	public ResourceInts CostResourcesPage1;

	[SerializableGameDataField]
	public ResourceInts CostResourcesPage2;

	[SerializableGameDataField]
	public ResourceInts CostResourcesPageAll;

	[SerializableGameDataField(ArrayElementsCount = 17)]
	public ItemDisplayData[] EquipItems = new ItemDisplayData[17];

	private static readonly sbyte[] NormalSlots = new sbyte[10] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10 };

	private static readonly sbyte[] AuxSlots = new sbyte[4] { 11, 14, 15, 16 };

	private static readonly sbyte[] AllRepairableSlots = new sbyte[14]
	{
		0, 1, 2, 3, 5, 6, 7, 8, 9, 10,
		11, 14, 15, 16
	};

	public RepairPlan()
	{
	}

	public RepairPlan(IEnumerable<ItemDisplayData> equipments, IReadOnlyList<ItemDisplayData> tools, LifeSkillShorts attainments, ResourceInts haveResources)
	{
		EquipItems = equipments.ToArray();
		if (EquipItems.Length != 17)
		{
			AdaptableLog.Warning($"Invalid RepairPlan got: Expected Length = {17}, got {EquipItems.Length}.\n{new StackTrace(fNeedFileInfo: true)}", appendWarningMessage: true);
			EquipItems = new ItemDisplayData[17];
			return;
		}
		CostResources = EquipItems.Select(GameData.Domains.Building.SharedMethods.GetRepairResource).ToArray();
		CostDurabilityDetail = EquipItems.Select(delegate(ItemDisplayData itemDisplayData2)
		{
			ItemDisplayData itemDisplayData = GameData.Domains.Building.SharedMethods.BestTool(tools, attainments, itemDisplayData2.RealKey, itemDisplayData2.Durability);
			if (itemDisplayData.RealKey.ItemType != 6)
			{
				return itemDisplayData;
			}
			ItemDisplayData itemDisplayData3 = itemDisplayData.Clone();
			itemDisplayData3.SpecialArg = CraftTool.Instance[itemDisplayData3.Key.TemplateId].DurabilityCost[ItemTemplateHelper.GetGrade(itemDisplayData2.RealKey.ItemType, itemDisplayData2.RealKey.TemplateId)];
			return itemDisplayData3;
		}).ToArray();
		HashSet<ItemKey> runOut = new HashSet<ItemKey>();
		Dictionary<ItemKey, int> usedDurability = new Dictionary<ItemKey, int>();
		for (int page = 0; page < 3; page++)
		{
			ItemDisplayData[] costDurability = page switch
			{
				0 => CostDurabilityPage1, 
				1 => CostDurabilityPage2, 
				_ => CostDurabilityPageAll, 
			};
			Array.Fill(costDurability, new ItemDisplayData());
			ResourceInts costResource = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
			sbyte[] array = page switch
			{
				0 => NormalSlots, 
				1 => AuxSlots, 
				_ => AllRepairableSlots, 
			};
			foreach (sbyte index in array)
			{
				ItemDisplayData equip = EquipItems[index];
				ItemDisplayData tool = GameData.Domains.Building.SharedMethods.BestTool(tools, attainments, equip.RealKey, equip.Durability, runOut).Clone();
				if (tool.RealKey.ItemType != 6)
				{
					(costDurability[index] = tool).SpecialArg = -2;
					continue;
				}
				ResourceInts totalNeed = GameData.Domains.Building.SharedMethods.GetRepairResource(equip);
				totalNeed.Add(ref costResource);
				if (haveResources.CheckIsMeet(ref totalNeed))
				{
					costResource = totalNeed;
					short durability = tool.Durability;
					int num2 = (usedDurability[tool.RealKey] = ((costDurability[index] = tool).SpecialArg = CraftTool.Instance[tool.RealKey.TemplateId].DurabilityCost[ItemTemplateHelper.GetGrade(equip.RealKey.ItemType, equip.RealKey.TemplateId)]) + usedDurability.GetValueOrDefault(tool.RealKey));
					if (durability <= num2 && tool.MaxDurability > 0)
					{
						runOut.Add(tool.RealKey);
					}
				}
				else
				{
					(costDurability[index] = tool).SpecialArg = -1;
				}
			}
			runOut.Clear();
			usedDurability.Clear();
			switch (page)
			{
			case 0:
				CostResourcesPage1 = costResource;
				break;
			case 1:
				CostResourcesPage2 = costResource;
				break;
			default:
				CostResourcesPageAll = costResource;
				break;
			}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 640;
		for (int i = 0; i < 17; i++)
		{
			totalSize = ((CostDurabilityPage1[i] == null) ? (totalSize + 2) : (totalSize + (2 + CostDurabilityPage1[i].GetSerializedSize())));
		}
		for (int j = 0; j < 17; j++)
		{
			totalSize = ((CostDurabilityPage2[j] == null) ? (totalSize + 2) : (totalSize + (2 + CostDurabilityPage2[j].GetSerializedSize())));
		}
		for (int k = 0; k < 17; k++)
		{
			totalSize = ((CostDurabilityPageAll[k] == null) ? (totalSize + 2) : (totalSize + (2 + CostDurabilityPageAll[k].GetSerializedSize())));
		}
		for (int l = 0; l < 17; l++)
		{
			totalSize = ((CostDurabilityDetail[l] == null) ? (totalSize + 2) : (totalSize + (2 + CostDurabilityDetail[l].GetSerializedSize())));
		}
		for (int m = 0; m < 17; m++)
		{
			totalSize = ((EquipItems[m] == null) ? (totalSize + 2) : (totalSize + (2 + EquipItems[m].GetSerializedSize())));
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		Tester.Assert(CostDurabilityPage1.Length == 17);
		for (int i = 0; i < 17; i++)
		{
			if (CostDurabilityPage1[i] != null)
			{
				byte* intPtr = pCurrData;
				pCurrData += 2;
				int fieldSize = CostDurabilityPage1[i].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
				*(ushort*)intPtr = (ushort)fieldSize;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
		}
		Tester.Assert(CostDurabilityPage2.Length == 17);
		for (int j = 0; j < 17; j++)
		{
			if (CostDurabilityPage2[j] != null)
			{
				byte* intPtr2 = pCurrData;
				pCurrData += 2;
				int fieldSize2 = CostDurabilityPage2[j].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
				*(ushort*)intPtr2 = (ushort)fieldSize2;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
		}
		Tester.Assert(CostDurabilityPageAll.Length == 17);
		for (int k = 0; k < 17; k++)
		{
			if (CostDurabilityPageAll[k] != null)
			{
				byte* intPtr3 = pCurrData;
				pCurrData += 2;
				int fieldSize3 = CostDurabilityPageAll[k].Serialize(pCurrData);
				pCurrData += fieldSize3;
				Tester.Assert(fieldSize3 <= 65535);
				*(ushort*)intPtr3 = (ushort)fieldSize3;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
		}
		Tester.Assert(CostDurabilityDetail.Length == 17);
		for (int l = 0; l < 17; l++)
		{
			if (CostDurabilityDetail[l] != null)
			{
				byte* intPtr4 = pCurrData;
				pCurrData += 2;
				int fieldSize4 = CostDurabilityDetail[l].Serialize(pCurrData);
				pCurrData += fieldSize4;
				Tester.Assert(fieldSize4 <= 65535);
				*(ushort*)intPtr4 = (ushort)fieldSize4;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
		}
		Tester.Assert(CostResources.Length == 17);
		for (int m = 0; m < 17; m++)
		{
			pCurrData += CostResources[m].Serialize(pCurrData);
		}
		pCurrData += CostResourcesPage1.Serialize(pCurrData);
		pCurrData += CostResourcesPage2.Serialize(pCurrData);
		pCurrData += CostResourcesPageAll.Serialize(pCurrData);
		Tester.Assert(EquipItems.Length == 17);
		for (int n = 0; n < 17; n++)
		{
			if (EquipItems[n] != null)
			{
				byte* intPtr5 = pCurrData;
				pCurrData += 2;
				int fieldSize5 = EquipItems[n].Serialize(pCurrData);
				pCurrData += fieldSize5;
				Tester.Assert(fieldSize5 <= 65535);
				*(ushort*)intPtr5 = (ushort)fieldSize5;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
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
		if (CostDurabilityPage1 == null || CostDurabilityPage1.Length != 17)
		{
			CostDurabilityPage1 = new ItemDisplayData[17];
		}
		for (int i = 0; i < 17; i++)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				CostDurabilityPage1[i] = new ItemDisplayData();
				pCurrData += CostDurabilityPage1[i].Deserialize(pCurrData);
			}
			else
			{
				CostDurabilityPage1[i] = null;
			}
		}
		if (CostDurabilityPage2 == null || CostDurabilityPage2.Length != 17)
		{
			CostDurabilityPage2 = new ItemDisplayData[17];
		}
		for (int j = 0; j < 17; j++)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				CostDurabilityPage2[j] = new ItemDisplayData();
				pCurrData += CostDurabilityPage2[j].Deserialize(pCurrData);
			}
			else
			{
				CostDurabilityPage2[j] = null;
			}
		}
		if (CostDurabilityPageAll == null || CostDurabilityPageAll.Length != 17)
		{
			CostDurabilityPageAll = new ItemDisplayData[17];
		}
		for (int k = 0; k < 17; k++)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				CostDurabilityPageAll[k] = new ItemDisplayData();
				pCurrData += CostDurabilityPageAll[k].Deserialize(pCurrData);
			}
			else
			{
				CostDurabilityPageAll[k] = null;
			}
		}
		if (CostDurabilityDetail == null || CostDurabilityDetail.Length != 17)
		{
			CostDurabilityDetail = new ItemDisplayData[17];
		}
		for (int l = 0; l < 17; l++)
		{
			ushort num4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num4 > 0)
			{
				CostDurabilityDetail[l] = new ItemDisplayData();
				pCurrData += CostDurabilityDetail[l].Deserialize(pCurrData);
			}
			else
			{
				CostDurabilityDetail[l] = null;
			}
		}
		if (CostResources == null || CostResources.Length != 17)
		{
			CostResources = new ResourceInts[17];
		}
		for (int m = 0; m < 17; m++)
		{
			CostResources[m] = default(ResourceInts);
			pCurrData += CostResources[m].Deserialize(pCurrData);
		}
		pCurrData += CostResourcesPage1.Deserialize(pCurrData);
		pCurrData += CostResourcesPage2.Deserialize(pCurrData);
		pCurrData += CostResourcesPageAll.Deserialize(pCurrData);
		if (EquipItems == null || EquipItems.Length != 17)
		{
			EquipItems = new ItemDisplayData[17];
		}
		for (int n = 0; n < 17; n++)
		{
			ushort num5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num5 > 0)
			{
				EquipItems[n] = new ItemDisplayData();
				pCurrData += EquipItems[n].Deserialize(pCurrData);
			}
			else
			{
				EquipItems[n] = null;
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
