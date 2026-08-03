using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.Merchant;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class CraftManDisplayData : ISerializableGameData
{
	/// <summary>
	/// 产物数据
	/// </summary>
	[SerializableGameDataField]
	public ProductionPool ProductionPool;

	/// <summary>
	/// 订单数据
	/// </summary>
	[SerializableGameDataField]
	public ArtisanOrder ArtisanOrder;

	/// <summary>
	/// 有可选物品子类型，茶酒、食物不可选子类型
	/// </summary>
	[SerializableGameDataField]
	public List<short> CanProduceItemSubType;

	/// <summary>
	/// 可以工作的成年人
	/// </summary>
	[SerializableGameDataField]
	public List<int> AvailableWorker;

	/// <summary>
	/// 可以当学徒的未成年人
	/// </summary>
	[SerializableGameDataField]
	public List<int> AvailableChildren;

	/// <summary>
	/// 村民身份显示数据，主事+学徒
	/// </summary>
	[SerializableGameDataField]
	public List<VillagerRoleCharacterDisplayData> VillagerRoleDataList;

	/// <summary>
	/// 人物显示数据，主事+学徒
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterDisplayData> CharacterDataList;

	/// <summary>
	/// 工作效率，主事+学徒
	/// </summary>
	[SerializableGameDataField]
	public List<int> VillagerEfficiencyList;

	/// <summary>
	/// 学徒研习数据
	/// </summary>
	[SerializableGameDataField]
	public List<ShopBuildingTeachBookData> TeachBookDataList;

	/// <summary>
	/// 解锁的村民列表
	/// </summary>
	[SerializableGameDataField]
	public List<int> UnlockedWorkingVillagerList;

	/// <summary>
	/// 过月时学徒研习增加的资质
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> ShopManagerUpgradeQualificationDict;

	/// <summary>
	/// 经营者列表
	/// </summary>
	[SerializableGameDataField]
	public List<int> ShopManagerList;

	/// <summary>
	/// 产业地图的所有数据
	/// </summary>
	[SerializableGameDataField]
	public List<BuildingBlockData> BlockList;

	/// <summary>
	/// 行囊道具，不含身上装备，含资源
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItemList;

	/// <summary>
	/// 仓库道具
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> WarehouseItemList;

	/// <summary>
	/// 公库道具，含资源
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> TreasuryItemList;

	/// <summary>
	/// 太吾能否使用仓库
	/// </summary>
	[SerializableGameDataField]
	public bool CanTransferItemToWarehouse;

	/// <summary>
	/// 匠人人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData ArtisanCharData;

	/// <summary>
	/// 匠人技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts ArtisanLifeSkillAttainments;

	/// <summary>
	/// 匠人技艺资质
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts ArtisanLifeSkillQualifications;

	/// <summary>
	/// 匠人的进度
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillInts ArtisanOrderProgressDeltas;

	/// <summary>
	/// 订购者人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData SubscriberCharData;

	/// <summary>
	/// 匠人的消耗银钱的立场影响
	/// </summary>
	[SerializableGameDataField]
	public int ArtisanCostMoneyBehaviorEffect;

	/// <summary>
	/// 获取匠人代制的基础价格
	/// </summary>
	/// <param name="isIntercept"></param>
	/// <returns></returns>
	public int GetBasePrice(bool isIntercept)
	{
		bool isDebateWon = ArtisanOrder?.IsDebateWon ?? false;
		if (ProductionPool != null)
		{
			int favor;
			if (!isIntercept)
			{
				return ProductionPool.GetCreateOrderPrice(out favor);
			}
			return ProductionPool.GetInterceptOrderPrice(isDebateWon, out favor);
		}
		return 0;
	}

	/// <summary>
	/// 获取匠人代制的最终价格
	/// </summary>
	/// <param name="isIntercept"></param>
	/// <returns></returns>
	public int GetFinalPrice(bool isIntercept)
	{
		int basePrice = GetBasePrice(isIntercept);
		if (basePrice == 0)
		{
			return 0;
		}
		int behaviorEffect = ArtisanCostMoneyBehaviorEffect;
		int favorabilityEffect = MerchantData.GetCharFavorabilityEffect(isBuy: true, ArtisanCharData?.FavorabilityToTaiwu ?? 0);
		return basePrice * (100 + behaviorEffect + favorabilityEffect) / 100;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((ProductionPool == null) ? (totalSize + 2) : (totalSize + (2 + ProductionPool.GetSerializedSize())));
		totalSize = ((ArtisanOrder == null) ? (totalSize + 2) : (totalSize + (2 + ArtisanOrder.GetSerializedSize())));
		totalSize = ((CanProduceItemSubType == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanProduceItemSubType.Count)));
		totalSize = ((AvailableWorker == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AvailableWorker.Count)));
		totalSize = ((AvailableChildren == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AvailableChildren.Count)));
		if (VillagerRoleDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < VillagerRoleDataList.Count; i++)
			{
				totalSize = ((VillagerRoleDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + VillagerRoleDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CharacterDataList != null)
		{
			totalSize += 2;
			for (int j = 0; j < CharacterDataList.Count; j++)
			{
				totalSize = ((CharacterDataList[j] == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDataList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((VillagerEfficiencyList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * VillagerEfficiencyList.Count)));
		if (TeachBookDataList != null)
		{
			totalSize += 2;
			for (int k = 0; k < TeachBookDataList.Count; k++)
			{
				totalSize = ((TeachBookDataList[k] == null) ? (totalSize + 2) : (totalSize + (2 + TeachBookDataList[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((UnlockedWorkingVillagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * UnlockedWorkingVillagerList.Count)));
		totalSize += 4;
		if (ShopManagerUpgradeQualificationDict != null)
		{
			foreach (KeyValuePair<int, int> item in ShopManagerUpgradeQualificationDict)
			{
				_ = item;
				totalSize += 4;
				totalSize += 4;
			}
		}
		totalSize = ((ShopManagerList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ShopManagerList.Count)));
		if (BlockList != null)
		{
			totalSize += 2;
			for (int l = 0; l < BlockList.Count; l++)
			{
				totalSize = ((BlockList[l] == null) ? (totalSize + 2) : (totalSize + (2 + BlockList[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (InventoryItemList != null)
		{
			totalSize += 2;
			for (int m = 0; m < InventoryItemList.Count; m++)
			{
				totalSize = ((InventoryItemList[m] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItemList[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (WarehouseItemList != null)
		{
			totalSize += 2;
			for (int n = 0; n < WarehouseItemList.Count; n++)
			{
				totalSize = ((WarehouseItemList[n] == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseItemList[n].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TreasuryItemList != null)
		{
			totalSize += 2;
			for (int num = 0; num < TreasuryItemList.Count; num++)
			{
				totalSize = ((TreasuryItemList[num] == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryItemList[num].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ArtisanCharData == null) ? (totalSize + 2) : (totalSize + (2 + ArtisanCharData.GetSerializedSize())));
		totalSize += ArtisanLifeSkillAttainments.GetSerializedSize();
		totalSize += ArtisanLifeSkillQualifications.GetSerializedSize();
		totalSize += ArtisanOrderProgressDeltas.GetSerializedSize();
		totalSize = ((SubscriberCharData == null) ? (totalSize + 2) : (totalSize + (2 + SubscriberCharData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ProductionPool != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ProductionPool.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ArtisanOrder != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ArtisanOrder.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CanProduceItemSubType != null)
		{
			int elementsCount = CanProduceItemSubType.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = CanProduceItemSubType[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AvailableWorker != null)
		{
			int elementsCount2 = AvailableWorker.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = AvailableWorker[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AvailableChildren != null)
		{
			int elementsCount3 = AvailableChildren.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(int*)pCurrData = AvailableChildren[k];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VillagerRoleDataList != null)
		{
			int elementsCount4 = VillagerRoleDataList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (VillagerRoleDataList[l] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = VillagerRoleDataList[l].Serialize(pCurrData);
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
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CharacterDataList != null)
		{
			int elementsCount5 = CharacterDataList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (CharacterDataList[m] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = CharacterDataList[m].Serialize(pCurrData);
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
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VillagerEfficiencyList != null)
		{
			int elementsCount6 = VillagerEfficiencyList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				*(int*)pCurrData = VillagerEfficiencyList[n];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TeachBookDataList != null)
		{
			int elementsCount7 = TeachBookDataList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (TeachBookDataList[num] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = TeachBookDataList[num].Serialize(pCurrData);
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
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (UnlockedWorkingVillagerList != null)
		{
			int elementsCount8 = UnlockedWorkingVillagerList.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				*(int*)pCurrData = UnlockedWorkingVillagerList[num2];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShopManagerUpgradeQualificationDict != null)
		{
			*(int*)pCurrData = ShopManagerUpgradeQualificationDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair in ShopManagerUpgradeQualificationDict)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ShopManagerList != null)
		{
			int elementsCount9 = ShopManagerList.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				*(int*)pCurrData = ShopManagerList[num3];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BlockList != null)
		{
			int elementsCount10 = BlockList.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				if (BlockList[num4] != null)
				{
					byte* intPtr6 = pCurrData;
					pCurrData += 2;
					int fieldSize6 = BlockList[num4].Serialize(pCurrData);
					pCurrData += fieldSize6;
					Tester.Assert(fieldSize6 <= 65535);
					*(ushort*)intPtr6 = (ushort)fieldSize6;
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
		if (InventoryItemList != null)
		{
			int elementsCount11 = InventoryItemList.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				if (InventoryItemList[num5] != null)
				{
					byte* intPtr7 = pCurrData;
					pCurrData += 2;
					int fieldSize7 = InventoryItemList[num5].Serialize(pCurrData);
					pCurrData += fieldSize7;
					Tester.Assert(fieldSize7 <= 65535);
					*(ushort*)intPtr7 = (ushort)fieldSize7;
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
		if (WarehouseItemList != null)
		{
			int elementsCount12 = WarehouseItemList.Count;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				if (WarehouseItemList[num6] != null)
				{
					byte* intPtr8 = pCurrData;
					pCurrData += 2;
					int fieldSize8 = WarehouseItemList[num6].Serialize(pCurrData);
					pCurrData += fieldSize8;
					Tester.Assert(fieldSize8 <= 65535);
					*(ushort*)intPtr8 = (ushort)fieldSize8;
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
		if (TreasuryItemList != null)
		{
			int elementsCount13 = TreasuryItemList.Count;
			Tester.Assert(elementsCount13 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount13;
			pCurrData += 2;
			for (int num7 = 0; num7 < elementsCount13; num7++)
			{
				if (TreasuryItemList[num7] != null)
				{
					byte* intPtr9 = pCurrData;
					pCurrData += 2;
					int fieldSize9 = TreasuryItemList[num7].Serialize(pCurrData);
					pCurrData += fieldSize9;
					Tester.Assert(fieldSize9 <= 65535);
					*(ushort*)intPtr9 = (ushort)fieldSize9;
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
		*pCurrData = (CanTransferItemToWarehouse ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ArtisanCharData != null)
		{
			byte* intPtr10 = pCurrData;
			pCurrData += 2;
			int fieldSize10 = ArtisanCharData.Serialize(pCurrData);
			pCurrData += fieldSize10;
			Tester.Assert(fieldSize10 <= 65535);
			*(ushort*)intPtr10 = (ushort)fieldSize10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += ArtisanLifeSkillAttainments.Serialize(pCurrData);
		pCurrData += ArtisanLifeSkillQualifications.Serialize(pCurrData);
		pCurrData += ArtisanOrderProgressDeltas.Serialize(pCurrData);
		if (SubscriberCharData != null)
		{
			byte* intPtr11 = pCurrData;
			pCurrData += 2;
			int fieldSize11 = SubscriberCharData.Serialize(pCurrData);
			pCurrData += fieldSize11;
			Tester.Assert(fieldSize11 <= 65535);
			*(ushort*)intPtr11 = (ushort)fieldSize11;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = ArtisanCostMoneyBehaviorEffect;
		pCurrData += 4;
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
			ProductionPool = new ProductionPool();
			pCurrData += ProductionPool.Deserialize(pCurrData);
		}
		else
		{
			ProductionPool = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			ArtisanOrder = new ArtisanOrder();
			pCurrData += ArtisanOrder.Deserialize(pCurrData);
		}
		else
		{
			ArtisanOrder = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CanProduceItemSubType == null)
			{
				CanProduceItemSubType = new List<short>();
			}
			else
			{
				CanProduceItemSubType.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				CanProduceItemSubType.Add(element);
			}
		}
		else
		{
			CanProduceItemSubType?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (AvailableWorker == null)
			{
				AvailableWorker = new List<int>();
			}
			else
			{
				AvailableWorker.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int element2 = *(int*)pCurrData;
				pCurrData += 4;
				AvailableWorker.Add(element2);
			}
		}
		else
		{
			AvailableWorker?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (AvailableChildren == null)
			{
				AvailableChildren = new List<int>();
			}
			else
			{
				AvailableChildren.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int element3 = *(int*)pCurrData;
				pCurrData += 4;
				AvailableChildren.Add(element3);
			}
		}
		else
		{
			AvailableChildren?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (VillagerRoleDataList == null)
			{
				VillagerRoleDataList = new List<VillagerRoleCharacterDisplayData>();
			}
			else
			{
				VillagerRoleDataList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				VillagerRoleCharacterDisplayData element4;
				if (num3 > 0)
				{
					element4 = new VillagerRoleCharacterDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				VillagerRoleDataList.Add(element4);
			}
		}
		else
		{
			VillagerRoleDataList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (CharacterDataList == null)
			{
				CharacterDataList = new List<CharacterDisplayData>();
			}
			else
			{
				CharacterDataList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element5;
				if (num4 > 0)
				{
					element5 = new CharacterDisplayData();
					pCurrData += element5.Deserialize(pCurrData);
				}
				else
				{
					element5 = null;
				}
				CharacterDataList.Add(element5);
			}
		}
		else
		{
			CharacterDataList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (VillagerEfficiencyList == null)
			{
				VillagerEfficiencyList = new List<int>();
			}
			else
			{
				VillagerEfficiencyList.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				int element6 = *(int*)pCurrData;
				pCurrData += 4;
				VillagerEfficiencyList.Add(element6);
			}
		}
		else
		{
			VillagerEfficiencyList?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (TeachBookDataList == null)
			{
				TeachBookDataList = new List<ShopBuildingTeachBookData>();
			}
			else
			{
				TeachBookDataList.Clear();
			}
			for (int num5 = 0; num5 < elementsCount7; num5++)
			{
				ushort num6 = *(ushort*)pCurrData;
				pCurrData += 2;
				ShopBuildingTeachBookData element7;
				if (num6 > 0)
				{
					element7 = new ShopBuildingTeachBookData();
					pCurrData += element7.Deserialize(pCurrData);
				}
				else
				{
					element7 = null;
				}
				TeachBookDataList.Add(element7);
			}
		}
		else
		{
			TeachBookDataList?.Clear();
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (UnlockedWorkingVillagerList == null)
			{
				UnlockedWorkingVillagerList = new List<int>();
			}
			else
			{
				UnlockedWorkingVillagerList.Clear();
			}
			for (int num7 = 0; num7 < elementsCount8; num7++)
			{
				int element8 = *(int*)pCurrData;
				pCurrData += 4;
				UnlockedWorkingVillagerList.Add(element8);
			}
		}
		else
		{
			UnlockedWorkingVillagerList?.Clear();
		}
		int ShopManagerUpgradeQualificationDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ShopManagerUpgradeQualificationDictElementsCount > 0)
		{
			if (ShopManagerUpgradeQualificationDict == null)
			{
				ShopManagerUpgradeQualificationDict = new Dictionary<int, int>();
			}
			else
			{
				ShopManagerUpgradeQualificationDict.Clear();
			}
			for (int num8 = 0; num8 < ShopManagerUpgradeQualificationDictElementsCount; num8++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				ShopManagerUpgradeQualificationDict.Add(key, value);
			}
		}
		else
		{
			ShopManagerUpgradeQualificationDict?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (ShopManagerList == null)
			{
				ShopManagerList = new List<int>();
			}
			else
			{
				ShopManagerList.Clear();
			}
			for (int num9 = 0; num9 < elementsCount9; num9++)
			{
				int element9 = *(int*)pCurrData;
				pCurrData += 4;
				ShopManagerList.Add(element9);
			}
		}
		else
		{
			ShopManagerList?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (BlockList == null)
			{
				BlockList = new List<BuildingBlockData>();
			}
			else
			{
				BlockList.Clear();
			}
			for (int num10 = 0; num10 < elementsCount10; num10++)
			{
				ushort num11 = *(ushort*)pCurrData;
				pCurrData += 2;
				BuildingBlockData element10;
				if (num11 > 0)
				{
					element10 = new BuildingBlockData();
					pCurrData += element10.Deserialize(pCurrData);
				}
				else
				{
					element10 = null;
				}
				BlockList.Add(element10);
			}
		}
		else
		{
			BlockList?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (InventoryItemList == null)
			{
				InventoryItemList = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItemList.Clear();
			}
			for (int num12 = 0; num12 < elementsCount11; num12++)
			{
				ushort num13 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element11;
				if (num13 > 0)
				{
					element11 = new ItemDisplayData();
					pCurrData += element11.Deserialize(pCurrData);
				}
				else
				{
					element11 = null;
				}
				InventoryItemList.Add(element11);
			}
		}
		else
		{
			InventoryItemList?.Clear();
		}
		ushort elementsCount12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount12 > 0)
		{
			if (WarehouseItemList == null)
			{
				WarehouseItemList = new List<ItemDisplayData>();
			}
			else
			{
				WarehouseItemList.Clear();
			}
			for (int num14 = 0; num14 < elementsCount12; num14++)
			{
				ushort num15 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element12;
				if (num15 > 0)
				{
					element12 = new ItemDisplayData();
					pCurrData += element12.Deserialize(pCurrData);
				}
				else
				{
					element12 = null;
				}
				WarehouseItemList.Add(element12);
			}
		}
		else
		{
			WarehouseItemList?.Clear();
		}
		ushort elementsCount13 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount13 > 0)
		{
			if (TreasuryItemList == null)
			{
				TreasuryItemList = new List<ItemDisplayData>();
			}
			else
			{
				TreasuryItemList.Clear();
			}
			for (int num16 = 0; num16 < elementsCount13; num16++)
			{
				ushort num17 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element13;
				if (num17 > 0)
				{
					element13 = new ItemDisplayData();
					pCurrData += element13.Deserialize(pCurrData);
				}
				else
				{
					element13 = null;
				}
				TreasuryItemList.Add(element13);
			}
		}
		else
		{
			TreasuryItemList?.Clear();
		}
		CanTransferItemToWarehouse = *pCurrData != 0;
		pCurrData++;
		ushort num18 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num18 > 0)
		{
			ArtisanCharData = new CharacterDisplayData();
			pCurrData += ArtisanCharData.Deserialize(pCurrData);
		}
		else
		{
			ArtisanCharData = null;
		}
		pCurrData += ArtisanLifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += ArtisanLifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += ArtisanOrderProgressDeltas.Deserialize(pCurrData);
		ushort num19 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num19 > 0)
		{
			SubscriberCharData = new CharacterDisplayData();
			pCurrData += SubscriberCharData.Deserialize(pCurrData);
		}
		else
		{
			SubscriberCharData = null;
		}
		ArtisanCostMoneyBehaviorEffect = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
