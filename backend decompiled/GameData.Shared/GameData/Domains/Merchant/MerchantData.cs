using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

/// <summary>
/// 注意此处的回购数据已经废弃清空，新的在 <see cref="T:GameData.Domains.Merchant.MerchantBuyBackData" />
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true, IsExtensible = true)]
public class MerchantData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharId = 0;

		public const ushort MerchantTemplateId = 1;

		public const ushort Money = 2;

		public const ushort GoodsList0 = 3;

		public const ushort GoodsList1 = 4;

		public const ushort GoodsList2 = 5;

		public const ushort GoodsList3 = 6;

		public const ushort GoodsList4 = 7;

		public const ushort GoodsList5 = 8;

		public const ushort GoodsList6 = 9;

		public const ushort PriceChangeData = 10;

		public const ushort Count = 11;

		public static readonly string[] FieldId2FieldName = new string[11]
		{
			"CharId", "MerchantTemplateId", "Money", "GoodsList0", "GoodsList1", "GoodsList2", "GoodsList3", "GoodsList4", "GoodsList5", "GoodsList6",
			"PriceChangeData"
		};
	}

	/// <summary>
	/// 商人NPC角色ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int CharId;

	/// <summary>
	/// 商人类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte MerchantTemplateId;

	/// <summary>
	/// 资金。交换藏书时为威望
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int Money;

	/// <summary>
	/// 货物列表0
	/// 交换藏书时为技艺书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public Inventory GoodsList0;

	/// <summary>
	/// 货物列表1
	/// 交换藏书时为好感功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public Inventory GoodsList1;

	/// <summary>
	/// 货物列表2
	/// 交换藏书时为门派功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public Inventory GoodsList2;

	/// <summary>
	/// 货物列表3
	/// 交换藏书时为门派功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public Inventory GoodsList3;

	/// <summary>
	/// 货物列表4
	/// 交换藏书时为门派功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	public Inventory GoodsList4;

	/// <summary>
	/// 货物列表5
	/// 交换藏书时为门派功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public Inventory GoodsList5;

	/// <summary>
	/// 货物列表6
	/// 交换藏书时为门派功法书列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	public Inventory GoodsList6;

	/// <summary>
	/// 价格变化数据。道具 -&gt; 价格增加百分比（负数表示折扣）
	/// </summary>
	[SerializableGameDataField(FieldIndex = 10)]
	public Dictionary<ItemKey, int> PriceChangeData = new Dictionary<ItemKey, int>();

	public const int MaxGoodsListCount = 7;

	/// <summary>
	/// 立场涨价幅度
	/// </summary>
	public const int BehaviorAddDiscount = 25;

	/// <summary>
	/// 立场降价幅度
	/// </summary>
	public const int BehaviorReduceDiscount = -25;

	/// <summary>
	/// 商人的最大等级
	/// </summary>
	public const sbyte MaxLevel = 6;

	/// <summary>
	/// 商店配置
	/// </summary>
	public MerchantItem MerchantConfig => Config.Merchant.Instance[MerchantTemplateId];

	/// <summary>
	/// 商会类型
	/// </summary>
	public sbyte MerchantType => MerchantConfig.MerchantType;

	/// <summary>
	/// 商店等级
	/// </summary>
	public sbyte MerchantLevel => MerchantConfig.Level;

	/// <summary>
	/// 商店分组配置
	/// </summary>
	public MerchantItem GroupConfig => Config.Merchant.Instance[MerchantConfig.GroupId];

	public MerchantData(int charId, sbyte merchantTemplateId)
	{
		CharId = charId;
		MerchantTemplateId = merchantTemplateId;
	}

	public MerchantData()
	{
	}

	/// <summary>
	/// 获取货物预设
	/// </summary>
	public static IList<PresetItemTemplateIdGroup> GetGoodsPreset(MerchantItem template, int index)
	{
		return index switch
		{
			0 => template.Goods0, 
			1 => template.Goods1, 
			2 => template.Goods2, 
			3 => template.Goods3, 
			4 => template.Goods4, 
			5 => template.Goods5, 
			6 => template.Goods6, 
			7 => template.Goods7, 
			8 => template.Goods8, 
			9 => template.Goods9, 
			10 => template.Goods10, 
			11 => template.Goods11, 
			12 => template.Goods12, 
			13 => template.Goods13, 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	/// <summary>
	/// 获取指定商品价格变化百分比
	/// </summary>
	public int GetPriceChangePercent(ItemKey itemKey)
	{
		if (!PriceChangeData.TryGetValue(itemKey, out var value))
		{
			return 0;
		}
		return value;
	}

	/// <summary>
	/// 获取指定类型和等级的商人模板ID
	/// </summary>
	public static sbyte FindMerchantTemplateId(sbyte type, sbyte level)
	{
		for (int i = 0; i < Config.Merchant.Instance.Count; i++)
		{
			MerchantItem config = Config.Merchant.Instance[i];
			if (config.MerchantType == type && config.Level == level)
			{
				return config.TemplateId;
			}
		}
		return -1;
	}

	/// <summary>
	/// 获取卖出物品价格
	/// </summary>
	public static int GetItemSoldPrice(int srcPrice, int favorChangeRate, short itemSubType, short merchantLoveItemType, short merchantHateItemType, sbyte merchantBehaviorType, int durabilityRate)
	{
		int biddingInfo = 0;
		if (itemSubType == merchantLoveItemType)
		{
			biddingInfo = merchantBehaviorType switch
			{
				0 => 10, 
				1 => 5, 
				2 => 0, 
				3 => 5, 
				4 => 10, 
				_ => biddingInfo, 
			};
		}
		else if (itemSubType == merchantHateItemType)
		{
			biddingInfo = merchantBehaviorType switch
			{
				0 => -20, 
				1 => -10, 
				2 => 0, 
				3 => -10, 
				4 => -20, 
				_ => biddingInfo, 
			};
		}
		int durabilityBidding = 50 + durabilityRate / 2;
		return Math.Max(0, srcPrice * (20 + 20 * favorChangeRate / 100 + biddingInfo) / 100 * durabilityBidding / 100);
	}

	/// <summary>
	/// 根据索引来获取商品列表
	/// </summary>
	public Inventory GetGoodsList(int index)
	{
		switch (index)
		{
		case 0:
			if (GoodsList0 == null)
			{
				return GoodsList0 = new Inventory();
			}
			return GoodsList0;
		case 1:
			if (GoodsList1 == null)
			{
				return GoodsList1 = new Inventory();
			}
			return GoodsList1;
		case 2:
			if (GoodsList2 == null)
			{
				return GoodsList2 = new Inventory();
			}
			return GoodsList2;
		case 3:
			if (GoodsList3 == null)
			{
				return GoodsList3 = new Inventory();
			}
			return GoodsList3;
		case 4:
			if (GoodsList4 == null)
			{
				return GoodsList4 = new Inventory();
			}
			return GoodsList4;
		case 5:
			if (GoodsList5 == null)
			{
				return GoodsList5 = new Inventory();
			}
			return GoodsList5;
		case 6:
			if (GoodsList6 == null)
			{
				return GoodsList6 = new Inventory();
			}
			return GoodsList6;
		default:
			throw new IndexOutOfRangeException();
		}
	}

	/// <summary>
	/// 随机获得进货时，人物立场对价格的影响
	/// </summary>
	public static int CalculateCharacterBehaviourDiscount(IRandomSource source, sbyte behaviorType)
	{
		int random = source.Next(0, 100);
		if ((random -= GlobalConfig.IncreasePriceProb[behaviorType]) < 0)
		{
			return 25;
		}
		if (random < GlobalConfig.DecreasePriceProb[behaviorType])
		{
			return -25;
		}
		return 0;
	}

	/// <summary>
	/// 获取人物好感对购买或出售的价格的影响，百分值
	/// </summary>
	/// <param name="isBuy"></param>
	/// <param name="favorability"></param>
	/// <returns></returns>
	public static int GetCharFavorabilityEffect(bool isBuy, short favorability)
	{
		sbyte favorabilityIndex = FavorabilityType.ToIndex(FavorabilityType.GetFavorabilityType(favorability));
		if (!isBuy)
		{
			return GlobalConfig.Instance.MerchantCharFavorabilitySellEffect[favorabilityIndex];
		}
		return GlobalConfig.Instance.MerchantCharFavorabilityBuyEffect[favorabilityIndex];
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((GoodsList0 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList0.GetSerializedSize())));
		totalSize = ((GoodsList1 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList1.GetSerializedSize())));
		totalSize = ((GoodsList2 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList2.GetSerializedSize())));
		totalSize = ((GoodsList3 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList3.GetSerializedSize())));
		totalSize = ((GoodsList4 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList4.GetSerializedSize())));
		totalSize = ((GoodsList5 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList5.GetSerializedSize())));
		totalSize = ((GoodsList6 == null) ? (totalSize + 2) : (totalSize + (2 + GoodsList6.GetSerializedSize())));
		totalSize += 4;
		if (PriceChangeData != null)
		{
			foreach (KeyValuePair<ItemKey, int> priceChangeDatum in PriceChangeData)
			{
				totalSize += priceChangeDatum.Key.GetSerializedSize();
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
		*(short*)pCurrData = 11;
		pCurrData += 2;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*pCurrData = (byte)MerchantTemplateId;
		pCurrData++;
		*(int*)pCurrData = Money;
		pCurrData += 4;
		if (GoodsList0 != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = GoodsList0.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList1 != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GoodsList1.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList2 != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = GoodsList2.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList3 != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = GoodsList3.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList4 != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = GoodsList4.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList5 != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = GoodsList5.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GoodsList6 != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = GoodsList6.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)intPtr7 = (ushort)fieldSize7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PriceChangeData != null)
		{
			*(int*)pCurrData = PriceChangeData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ItemKey, int> pair in PriceChangeData)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			MerchantTemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			Money = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				GoodsList0 = new Inventory();
				pCurrData += GoodsList0.Deserialize(pCurrData);
			}
			else
			{
				GoodsList0 = null;
			}
		}
		if (num > 4)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				GoodsList1 = new Inventory();
				pCurrData += GoodsList1.Deserialize(pCurrData);
			}
			else
			{
				GoodsList1 = null;
			}
		}
		if (num > 5)
		{
			ushort num4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num4 > 0)
			{
				GoodsList2 = new Inventory();
				pCurrData += GoodsList2.Deserialize(pCurrData);
			}
			else
			{
				GoodsList2 = null;
			}
		}
		if (num > 6)
		{
			ushort num5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num5 > 0)
			{
				GoodsList3 = new Inventory();
				pCurrData += GoodsList3.Deserialize(pCurrData);
			}
			else
			{
				GoodsList3 = null;
			}
		}
		if (num > 7)
		{
			ushort num6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num6 > 0)
			{
				GoodsList4 = new Inventory();
				pCurrData += GoodsList4.Deserialize(pCurrData);
			}
			else
			{
				GoodsList4 = null;
			}
		}
		if (num > 8)
		{
			ushort num7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num7 > 0)
			{
				GoodsList5 = new Inventory();
				pCurrData += GoodsList5.Deserialize(pCurrData);
			}
			else
			{
				GoodsList5 = null;
			}
		}
		if (num > 9)
		{
			ushort num8 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num8 > 0)
			{
				GoodsList6 = new Inventory();
				pCurrData += GoodsList6.Deserialize(pCurrData);
			}
			else
			{
				GoodsList6 = null;
			}
		}
		if (num > 10)
		{
			int PriceChangeDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (PriceChangeDataElementsCount > 0)
			{
				if (PriceChangeData == null)
				{
					PriceChangeData = new Dictionary<ItemKey, int>();
				}
				else
				{
					PriceChangeData.Clear();
				}
				for (int i = 0; i < PriceChangeDataElementsCount; i++)
				{
					ItemKey key = default(ItemKey);
					pCurrData += key.Deserialize(pCurrData);
					int value = *(int*)pCurrData;
					pCurrData += 4;
					PriceChangeData.Add(key, value);
				}
			}
			else
			{
				PriceChangeData?.Clear();
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
