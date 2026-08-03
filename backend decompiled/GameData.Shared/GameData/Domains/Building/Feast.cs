using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 宴堂数据
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class Feast : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BuildingBlockKey = 0;

		public const ushort Dish = 1;

		public const ushort DishDurability = 2;

		public const ushort Gift = 3;

		public const ushort GiftCount = 4;

		public const ushort AutoRefill = 5;

		public const ushort TargetType = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "BuildingBlockKey", "Dish", "DishDurability", "Gift", "GiftCount", "AutoRefill", "TargetType" };
	}

	/// <summary>
	/// 产业建筑Key
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public BuildingBlockKey BuildingBlockKey;

	/// <summary>
	/// 菜肴
	/// index -&gt; itemKey
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<int, ItemKey> Dish;

	/// <summary>
	/// 菜肴剩余可用次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public Dictionary<int, int> DishDurability;

	/// <summary>
	/// 回礼
	/// index -&gt; itemKey
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public Dictionary<int, ItemKey> Gift;

	/// <summary>
	/// 礼物数量
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public Dictionary<int, int> GiftCount;

	/// <summary>
	/// 自动上菜
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public bool AutoRefill;

	/// <summary>
	/// 目标主题
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public short TargetType;

	/// <summary>
	/// 菜肴已满
	/// </summary>
	public bool IsFull => GetInUseDishSlotCount() >= GlobalConfig.Instance.FeastCount;

	public Feast()
	{
		BuildingBlockKey = BuildingBlockKey.Invalid;
		Dish = new Dictionary<int, ItemKey>();
		DishDurability = new Dictionary<int, int>();
		Gift = new Dictionary<int, ItemKey>();
		GiftCount = new Dictionary<int, int>();
		AutoRefill = false;
		TargetType = -1;
	}

	public Feast(BuildingBlockKey key)
	{
		BuildingBlockKey = key;
		Dish = new Dictionary<int, ItemKey>();
		DishDurability = new Dictionary<int, int>();
		Gift = new Dictionary<int, ItemKey>();
		GiftCount = new Dictionary<int, int>();
		AutoRefill = false;
		TargetType = -1;
	}

	/// <summary>
	/// 获取菜肴
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public ItemKey GetDish(int index)
	{
		if (!Dish.TryGetValue(index, out var dish))
		{
			return ItemKey.Invalid;
		}
		return dish;
	}

	/// <summary>
	/// 获取礼物
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public ItemKey GetGift(int index)
	{
		if (!Gift.TryGetValue(index, out var gift))
		{
			return ItemKey.Invalid;
		}
		return gift;
	}

	/// <summary>
	/// 获取可食用的菜肴数
	/// </summary>
	/// <returns></returns>
	public int GetInUseDishSlotCount()
	{
		int res = 0;
		foreach (ItemKey value in Dish.Values)
		{
			if (value.IsValid())
			{
				res++;
			}
		}
		return res;
	}

	/// <summary>
	/// 获取可放置菜肴的位置
	/// </summary>
	/// <returns></returns>
	public int GetAvailableDishSlot()
	{
		for (int i = 0; i < GlobalConfig.Instance.FeastCount; i++)
		{
			if (!GetDish(i).IsValid())
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 菜肴是否已经被吃过
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public bool IsDishEaten(int index)
	{
		return DishDurability[index] != GlobalConfig.Instance.FeastDurability;
	}

	/// <summary>
	/// 获取未领取的礼物占的格子数
	/// </summary>
	/// <returns></returns>
	public int GetInUseGiftSlotCount()
	{
		int res = 0;
		foreach (ItemKey value in Gift.Values)
		{
			if (value != ItemKey.Invalid)
			{
				res++;
			}
		}
		return res;
	}

	/// <summary>
	/// 未领取的礼物已满
	/// </summary>
	/// <returns></returns>
	public bool InUseGiftMax()
	{
		bool res = Gift.Values.Count != 0;
		foreach (ItemKey value in Gift.Values)
		{
			if (value == ItemKey.Invalid)
			{
				res = false;
			}
		}
		return res;
	}

	/// <summary>
	/// 是否应该停止自动入住并且驱逐所有已有角色
	/// </summary>
	/// <returns></returns>
	public bool CheckAvoidAutoCheckIn()
	{
		if (AutoRefill)
		{
			return GetInUseDishSlotCount() <= 0;
		}
		return false;
	}

	/// <summary>
	/// 获取宴会类型
	/// </summary>
	/// <returns>宴会模版Id</returns>
	public short GetFeastType()
	{
		int count = GlobalConfig.Instance.FeastCount;
		FeastItem res = Config.Feast.DefValue.None;
		if (Dish.Count < count)
		{
			return res.TemplateId;
		}
		Dictionary<EFoodFoodType, int> countByFoodType = new Dictionary<EFoodFoodType, int>();
		Dictionary<short, int> countBySubType = new Dictionary<short, int>
		{
			{ 701, 0 },
			{ 700, 0 },
			{ 900, 0 },
			{ 901, 0 }
		};
		sbyte lowestGrade = sbyte.MaxValue;
		foreach (object foodType in Enum.GetValues(typeof(EFoodFoodType)))
		{
			countByFoodType.Add((EFoodFoodType)foodType, 0);
		}
		foreach (ItemKey itemKey in Dish.Values)
		{
			if (!itemKey.IsValid())
			{
				return res.TemplateId;
			}
			lowestGrade = Math.Min(lowestGrade, ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId));
			switch (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId))
			{
			case 900:
				countByFoodType[EFoodFoodType.Tea]++;
				countBySubType[900]++;
				continue;
			case 901:
				countByFoodType[EFoodFoodType.Wine]++;
				countBySubType[901]++;
				continue;
			}
			FoodItem config = Food.Instance[itemKey.TemplateId];
			if (config.FoodType == null)
			{
				continue;
			}
			foreach (EFoodFoodType item in config.FoodType)
			{
				countByFoodType[item]++;
				countBySubType[config.ItemSubType]++;
			}
		}
		foreach (FeastItem config2 in (IEnumerable<FeastItem>)Config.Feast.Instance)
		{
			if (Check(countByFoodType, countBySubType, config2, res.Priority, lowestGrade))
			{
				res = config2;
			}
		}
		return res.TemplateId;
	}

	private bool Check(Dictionary<EFoodFoodType, int> countByFoodType, Dictionary<short, int> countBySubType, FeastItem config, int currPriority, int lowestGrade)
	{
		if (currPriority >= config.Priority)
		{
			return false;
		}
		if (config.RequirementType == null || config.RequirementType.Count == 0)
		{
			return false;
		}
		for (int index = 0; index < config.RequirementType.Count; index++)
		{
			EFeastRequirementType type = config.RequirementType[index];
			int[] data = config.RequirementData[index];
			switch (type)
			{
			case EFeastRequirementType.FoodTypeBird:
				if (countByFoodType[EFoodFoodType.Bird] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.FoodTypeBeast:
				if (countByFoodType[EFoodFoodType.Beast] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.FoodTypeFish:
				if (countByFoodType[EFoodFoodType.Fish] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.FoodTypeVegetable:
				if (countByFoodType[EFoodFoodType.Vegetable] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.FoodTypeFruit:
				if (countByFoodType[EFoodFoodType.Fruit] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.FoodTypeVegetarian:
				if (countByFoodType[EFoodFoodType.Vegetarian] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.SubTypeTea:
				if (countBySubType[900] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.SubTypeWine:
				if (countBySubType[901] < data[0])
				{
					return false;
				}
				break;
			case EFeastRequirementType.SubTypeDiff:
			{
				int subTypeCount = 0;
				foreach (KeyValuePair<short, int> item in countBySubType)
				{
					item.Deconstruct(out var _, out var value);
					if (value > 0)
					{
						subTypeCount++;
					}
				}
				if (subTypeCount < data[0])
				{
					return false;
				}
				break;
			}
			}
			if (lowestGrade < data[1])
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 获取一个物品对应的食物类型
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="typeList"></param>
	/// <returns></returns>
	public static List<EFoodFoodType> GetFoodTypeList(ItemKey itemKey, List<EFoodFoodType> typeList = null)
	{
		if (typeList == null)
		{
			typeList = new List<EFoodFoodType>();
		}
		typeList.Clear();
		switch (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId))
		{
		case 900:
			typeList.Add(EFoodFoodType.Tea);
			break;
		case 901:
			typeList.Add(EFoodFoodType.Wine);
			break;
		default:
		{
			FoodItem config = Food.Instance[itemKey.TemplateId];
			typeList.AddRange(config.FoodType);
			break;
		}
		}
		return typeList;
	}

	/// <summary>
	/// 根据需求类型获取食物类型
	/// </summary>
	public static EFoodFoodType GetFoodType(EFeastRequirementType requirementType)
	{
		return requirementType switch
		{
			EFeastRequirementType.Invalid => EFoodFoodType.Invalid, 
			EFeastRequirementType.FoodTypeBird => EFoodFoodType.Bird, 
			EFeastRequirementType.FoodTypeBeast => EFoodFoodType.Beast, 
			EFeastRequirementType.FoodTypeFish => EFoodFoodType.Fish, 
			EFeastRequirementType.FoodTypeVegetable => EFoodFoodType.Vegetable, 
			EFeastRequirementType.FoodTypeFruit => EFoodFoodType.Fruit, 
			EFeastRequirementType.FoodTypeVegetarian => EFoodFoodType.Vegetarian, 
			EFeastRequirementType.SubTypeTea => EFoodFoodType.Tea, 
			EFeastRequirementType.SubTypeWine => EFoodFoodType.Wine, 
			EFeastRequirementType.SubTypeDiff => EFoodFoodType.Invalid, 
			EFeastRequirementType.Count => EFoodFoodType.Invalid, 
			_ => throw new ArgumentOutOfRangeException("requirementType", requirementType, null), 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize += BuildingBlockKey.GetSerializedSize();
		totalSize += 4;
		if (Dish != null)
		{
			foreach (KeyValuePair<int, ItemKey> pair in Dish)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (DishDurability != null)
		{
			foreach (KeyValuePair<int, int> item in DishDurability)
			{
				_ = item;
				totalSize += 4;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (Gift != null)
		{
			foreach (KeyValuePair<int, ItemKey> pair2 in Gift)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (GiftCount != null)
		{
			foreach (KeyValuePair<int, int> item2 in GiftCount)
			{
				_ = item2;
				totalSize += 4;
				totalSize += 4;
			}
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
		*(short*)pCurrData = 7;
		pCurrData += 2;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		if (Dish != null)
		{
			*(int*)pCurrData = Dish.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, ItemKey> pair in Dish)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (DishDurability != null)
		{
			*(int*)pCurrData = DishDurability.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair2 in DishDurability)
			{
				*(int*)pCurrData = pair2.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair2.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Gift != null)
		{
			*(int*)pCurrData = Gift.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, ItemKey> pair3 in Gift)
			{
				*(int*)pCurrData = pair3.Key;
				pCurrData += 4;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (GiftCount != null)
		{
			*(int*)pCurrData = GiftCount.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair4 in GiftCount)
			{
				*(int*)pCurrData = pair4.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair4.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (AutoRefill ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = TargetType;
		pCurrData += 2;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			int DishElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (DishElementsCount > 0)
			{
				if (Dish == null)
				{
					Dish = new Dictionary<int, ItemKey>();
				}
				else
				{
					Dish.Clear();
				}
				for (int i = 0; i < DishElementsCount; i++)
				{
					int key = *(int*)pCurrData;
					pCurrData += 4;
					ItemKey value = default(ItemKey);
					pCurrData += value.Deserialize(pCurrData);
					Dish.Add(key, value);
				}
			}
			else
			{
				Dish?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			int DishDurabilityElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (DishDurabilityElementsCount > 0)
			{
				if (DishDurability == null)
				{
					DishDurability = new Dictionary<int, int>();
				}
				else
				{
					DishDurability.Clear();
				}
				for (int j = 0; j < DishDurabilityElementsCount; j++)
				{
					int key2 = *(int*)pCurrData;
					pCurrData += 4;
					int value2 = *(int*)pCurrData;
					pCurrData += 4;
					DishDurability.Add(key2, value2);
				}
			}
			else
			{
				DishDurability?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			int GiftElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (GiftElementsCount > 0)
			{
				if (Gift == null)
				{
					Gift = new Dictionary<int, ItemKey>();
				}
				else
				{
					Gift.Clear();
				}
				for (int k = 0; k < GiftElementsCount; k++)
				{
					int key3 = *(int*)pCurrData;
					pCurrData += 4;
					ItemKey value3 = default(ItemKey);
					pCurrData += value3.Deserialize(pCurrData);
					Gift.Add(key3, value3);
				}
			}
			else
			{
				Gift?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			int GiftCountElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (GiftCountElementsCount > 0)
			{
				if (GiftCount == null)
				{
					GiftCount = new Dictionary<int, int>();
				}
				else
				{
					GiftCount.Clear();
				}
				for (int l = 0; l < GiftCountElementsCount; l++)
				{
					int key4 = *(int*)pCurrData;
					pCurrData += 4;
					int value4 = *(int*)pCurrData;
					pCurrData += 4;
					GiftCount.Add(key4, value4);
				}
			}
			else
			{
				GiftCount?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			AutoRefill = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			TargetType = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
