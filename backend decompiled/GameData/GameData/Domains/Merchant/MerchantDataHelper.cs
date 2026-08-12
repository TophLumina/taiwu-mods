using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

public static class MerchantDataHelper
{
	public static void GenerateGoods(this MerchantData data, DataContext context, int caravanId = -1, MerchantExtraGoodsData extraGoodsData = null)
	{
		data.GenerateGoods(context, data.MerchantConfig.Level, caravanId, extraGoodsData);
	}

	public static void GenerateGoods(this MerchantData data, DataContext context, sbyte level, int caravanId = -1, MerchantExtraGoodsData extraGoodsData = null)
	{
		GameData.Domains.Character.Character character = ((data.CharId >= 0) ? DomainManager.Character.GetElement_Objects(data.CharId) : null);
		int id = character?.GetId() ?? caravanId;
		bool isSpecialExtraGoodsData = extraGoodsData != null;
		if (!isSpecialExtraGoodsData)
		{
			DomainManager.Extra.ClearAllMerchantExtraGoods(context, id);
			if (!DomainManager.Extra.TryGetMerchantExtraGoods(id, out extraGoodsData))
			{
				extraGoodsData = new MerchantExtraGoodsData();
			}
		}
		extraGoodsData.Clear();
		sbyte seasonTemplateId = (false ? ((sbyte)context.Random.Next(Season.Instance.Count)) : EventHelper.GetCurrSeason());
		extraGoodsData.SeasonTemplateId = seasonTemplateId;
		sbyte maxGoodsLevel = Math.Min(level, 6);
		sbyte minGoodsLevel = data.GroupConfig.Level;
		for (sbyte goodsLevel = minGoodsLevel; goodsLevel <= maxGoodsLevel; goodsLevel++)
		{
			data.GenerateGoodsLevelList(context, extraGoodsData, goodsLevel, character, caravanId);
		}
		if (!isSpecialExtraGoodsData)
		{
			DomainManager.Extra.SetMerchantExtraGoods(context, id, extraGoodsData);
		}
	}

	public static void RefreshSeasonExtraGoods(this MerchantData data, DataContext context, int caravanId = -1, MerchantExtraGoodsData extraGoodsData = null)
	{
		GameData.Domains.Character.Character character = ((data.CharId >= 0) ? DomainManager.Character.GetElement_Objects(data.CharId) : null);
		int id = character?.GetId() ?? caravanId;
		bool isSpecialExtraGoodsData = extraGoodsData != null;
		if (!isSpecialExtraGoodsData && !DomainManager.Extra.TryGetMerchantExtraGoods(id, out extraGoodsData))
		{
			return;
		}
		foreach (MerchantExtraGoodsItem merchantExtraGoodsItem in extraGoodsData.SeasonExtraGoods)
		{
			Inventory goodsList = data.GetGoodsList(merchantExtraGoodsItem.Index);
			foreach (var (itemKey2, amount) in goodsList.Items)
			{
				if (itemKey2.Id == merchantExtraGoodsItem.Id)
				{
					DomainManager.Item.RemoveItem(context, itemKey2);
					goodsList.OfflineRemove(itemKey2, amount);
					data.PriceChangeData.Remove(itemKey2);
				}
			}
		}
		extraGoodsData.SeasonExtraGoods.Clear();
		extraGoodsData.SeasonTemplateId = EventHelper.GetCurrSeason();
		sbyte maxGoodsLevel = Math.Min(data.MerchantConfig.Level, 6);
		sbyte minGoodsLevel = data.GroupConfig.Level;
		for (sbyte goodsLevel = minGoodsLevel; goodsLevel <= maxGoodsLevel; goodsLevel++)
		{
			data.GenerateGoodsLevelList(context, extraGoodsData, goodsLevel, character, caravanId, onlySeason: true);
		}
		if (!isSpecialExtraGoodsData)
		{
			DomainManager.Extra.SetMerchantExtraGoods(context, id, extraGoodsData);
		}
	}

	public static void GenerateGoodsLevelList(this MerchantData data, DataContext ctx, MerchantExtraGoodsData merchantExtraGoods, sbyte level, GameData.Domains.Character.Character character, int caravanId = -1, bool onlySeason = false)
	{
		Inventory goods = data.GetGoodsList(level);
		ItemOwnerType itemOwnerType = ((character != null) ? ItemOwnerType.Merchant : ((caravanId >= 0 || (caravanId == -1 && data == DomainManager.Merchant.GetCaravanMerchantData(ctx, caravanId))) ? ItemOwnerType.Caravan : ItemOwnerType.BuildingMerchant));
		int ownerId = character?.GetId() ?? caravanId;
		MerchantItem createConfig = MerchantType.GetMerchantLevelData(data.MerchantConfig.GroupId, level);
		if (createConfig == null)
		{
			return;
		}
		sbyte seasonTemplateId = merchantExtraGoods.SeasonTemplateId;
		if (1 == 0)
		{
		}
		short[] array = seasonTemplateId switch
		{
			0 => createConfig.SeasonsGoodsRate0, 
			1 => createConfig.SeasonsGoodsRate1, 
			2 => createConfig.SeasonsGoodsRate2, 
			3 => createConfig.SeasonsGoodsRate3, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		if (1 == 0)
		{
		}
		short[] seasonGoodsRate = array;
		CreateRateGoods(seasonGoodsRate, merchantExtraGoods.SeasonExtraGoods);
		if (onlySeason)
		{
			return;
		}
		CreateRateGoods(createConfig.GoodsRate, null);
		CreateRateGoods(createConfig.CapitalistSkillExtraGoodsRate, merchantExtraGoods.CapitalistSkillExtraGoods);
		if (level >= 6)
		{
			return;
		}
		sbyte targetLevel = Convert.ToSByte(level + 1);
		MerchantItem merchantConfig = MerchantType.GetMerchantLevelData(createConfig.GroupId, targetLevel);
		sbyte[] extraGoodsIndexGroup = createConfig.ExtraGoodsIndexGroup;
		if (extraGoodsIndexGroup != null && extraGoodsIndexGroup.Length > 0)
		{
			sbyte normalIndex = createConfig.ExtraGoodsIndexGroup.GetRandom(ctx.Random);
			List<PresetItemTemplateIdGroup> normalPool = MerchantData.GetGoodsPreset(merchantConfig, normalIndex).ToList();
			int normalCount = Math.Min(1, normalPool.Count);
			List<ItemKey> normalKeyList = CreateItem(normalPool, normalCount, priceEffectByBehaviour: false, unique: true);
			foreach (ItemKey key in normalKeyList)
			{
				merchantExtraGoods.NormalExtraGoods.Add(new MerchantExtraGoodsItem
				{
					Id = key.Id,
					Index = level
				});
			}
			ObjectPool<List<ItemKey>>.Instance.Return(normalKeyList);
		}
		extraGoodsIndexGroup = createConfig.CapitalistSkillExtraGoodsIndexGroup;
		if (extraGoodsIndexGroup == null || extraGoodsIndexGroup.Length <= 0)
		{
			return;
		}
		sbyte professionIndex = createConfig.CapitalistSkillExtraGoodsIndexGroup.GetRandom(ctx.Random);
		List<PresetItemTemplateIdGroup> professionPool = MerchantData.GetGoodsPreset(merchantConfig, professionIndex).ToList();
		int professionCount = Math.Min(1, professionPool.Count);
		List<ItemKey> professionKeyList = CreateItem(professionPool, professionCount, priceEffectByBehaviour: true, unique: true);
		foreach (ItemKey key2 in professionKeyList)
		{
			merchantExtraGoods.CapitalistSkillExtraGoods.Add(new MerchantExtraGoodsItem
			{
				Id = key2.Id,
				Index = level
			});
		}
		ObjectPool<List<ItemKey>>.Instance.Return(professionKeyList);
		List<ItemKey> CreateItem(IList<PresetItemTemplateIdGroup> pool, int count, bool priceEffectByBehaviour = true, bool unique = false)
		{
			List<ItemKey> keyList = ObjectPool<List<ItemKey>>.Instance.Get();
			for (int i = 0; i < count; i++)
			{
				int presetId = ctx.Random.Next(0, pool.Count);
				PresetItemTemplateIdGroup preset = pool[presetId];
				if (ItemTemplateHelper.IsStackable(preset.ItemType, preset.StartId) && !unique)
				{
					ItemKey itemKey = DomainManager.Item.CreateItem(ctx, preset.ItemType, preset.StartId);
					DomainManager.Item.SetOwner(itemKey, itemOwnerType, ownerId);
					goods.OfflineAdd(itemKey, preset.GroupLength);
					if (priceEffectByBehaviour)
					{
						data.PriceChangeData[itemKey] = MerchantData.CalculateCharacterBehaviourDiscount(ctx.Random, character?.GetBehaviorType() ?? 0);
					}
					for (int j = 0; j < preset.GroupLength; j++)
					{
						keyList.Add(itemKey);
					}
				}
				else
				{
					ItemKey firstUniqueKey = ItemKey.Invalid;
					for (int k = 0; k < preset.GroupLength; k++)
					{
						ItemKey itemKey2;
						if (unique)
						{
							ItemBase itemBase = DomainManager.Item.CreateUniqueStackableItem(ctx, preset.ItemType, preset.StartId);
							byte newState = ModificationStateHelper.Activate(0, 8);
							itemBase.SetModificationState(newState, ctx);
							itemKey2 = itemBase.GetItemKey();
							if (priceEffectByBehaviour)
							{
								if (data.PriceChangeData.TryGetValue(firstUniqueKey, out var price))
								{
									data.PriceChangeData[itemKey2] = price;
								}
								else if (!firstUniqueKey.IsValid())
								{
									data.PriceChangeData[itemKey2] = MerchantData.CalculateCharacterBehaviourDiscount(ctx.Random, character?.GetBehaviorType() ?? 0);
									if (!firstUniqueKey.IsValid())
									{
										firstUniqueKey = itemKey2;
									}
								}
							}
						}
						else
						{
							itemKey2 = DomainManager.Item.CreateItem(ctx, preset.ItemType, preset.StartId);
							if (priceEffectByBehaviour)
							{
								data.PriceChangeData[itemKey2] = MerchantData.CalculateCharacterBehaviourDiscount(ctx.Random, character?.GetBehaviorType() ?? 0);
							}
						}
						DomainManager.Item.SetOwner(itemKey2, itemOwnerType, ownerId);
						goods.OfflineAdd(itemKey2, 1);
						keyList.Add(itemKey2);
					}
				}
				pool.RemoveAt(presetId);
			}
			return keyList;
		}
		void CreateRateGoods(short[] goodsRate, List<MerchantExtraGoodsItem> extraItems)
		{
			bool isExtra = extraItems != null;
			for (int index = 0; index < goodsRate.Length; index++)
			{
				List<PresetItemTemplateIdGroup> pool = MerchantData.GetGoodsPreset(createConfig, index).ToList();
				ChallengeModeData challengeModeData = DomainManager.World.GetChallengeModeData();
				challengeModeData.ApplyMerchantItemsCreateRate(pool, ctx.Random);
				short rate = goodsRate[index];
				int count = ((rate >= 0) ? (rate * ctx.Random.Next(100, 150) / 100) : ((ctx.Random.Next(100) < -rate) ? 1 : 0));
				count = Math.Min(count, pool.Count);
				List<ItemKey> keyList = CreateItem(pool, count, priceEffectByBehaviour: true, isExtra);
				if (isExtra)
				{
					foreach (ItemKey key3 in keyList)
					{
						extraItems.Add(new MerchantExtraGoodsItem
						{
							Id = key3.Id,
							Index = level
						});
					}
				}
				ObjectPool<List<ItemKey>>.Instance.Return(keyList);
			}
		}
	}

	public static void RemoveAllGoods(this MerchantData data, DataContext context)
	{
		for (int i = 0; i <= 6; i++)
		{
			Inventory goods = data.GetGoodsList(i);
			DomainManager.Item.RemoveItems(context, goods.Items);
			goods.Items.Clear();
		}
		data.PriceChangeData.Clear();
		DomainManager.Extra.ClearAllMerchantExtraGoods(context, data.CharId);
	}

	public static MerchantExtraGoodsData OfflineRefreshGoods(this MerchantData data, DataContext context, sbyte level, GameData.Domains.Character.Character character, int caravanId = -1)
	{
		MerchantExtraGoodsData newExtraGoodsData = new MerchantExtraGoodsData();
		newExtraGoodsData.SeasonTemplateId = EventHelper.GetCurrSeason();
		Dictionary<ItemKey, int> items = data.GetGoodsList(level).Items;
		if (items != null)
		{
			foreach (ItemKey item in items.Keys)
			{
				data.PriceChangeData.Remove(item);
			}
			items.Clear();
		}
		data.GenerateGoodsLevelList(context, newExtraGoodsData, level, character, caravanId);
		if (DomainManager.Extra.TryGetMerchantExtraGoods(character?.GetId() ?? caravanId, out var extraGoodsData))
		{
			AssignOrAddRange(ref extraGoodsData.NormalExtraGoods, newExtraGoodsData.NormalExtraGoods);
			AssignOrAddRange(ref extraGoodsData.SeasonExtraGoods, newExtraGoodsData.SeasonExtraGoods);
			AssignOrAddRange(ref extraGoodsData.CapitalistSkillExtraGoods, newExtraGoodsData.CapitalistSkillExtraGoods);
		}
		return extraGoodsData ?? newExtraGoodsData;
		void AssignOrAddRange(ref List<MerchantExtraGoodsItem> extraGoodsList, List<MerchantExtraGoodsItem> newGoodsList)
		{
			if (extraGoodsList == null)
			{
				extraGoodsList = newGoodsList;
			}
			else
			{
				extraGoodsList.RemoveAll((MerchantExtraGoodsItem x) => x.Index == level);
				extraGoodsList.AddRange(newGoodsList);
			}
		}
	}
}
