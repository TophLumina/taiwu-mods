using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 产物池
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ProductionPool : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<Production, ProductionData> Productions;

	[SerializableGameDataField]
	public int CookAddOn;

	public ProductionPool()
	{
		Productions = new Dictionary<Production, ProductionData>();
		CookAddOn = 0;
	}

	public ProductionPool(int cookAddOn)
	{
		Productions = new Dictionary<Production, ProductionData>();
		CookAddOn = cookAddOn;
	}

	/// <summary>
	/// 获取创建订单的价格
	/// </summary>
	public int GetCreateOrderPrice(out int favor)
	{
		int price = 0;
		favor = 0;
		foreach (KeyValuePair<Production, ProductionData> production2 in Productions)
		{
			production2.Deconstruct(out var key, out var value);
			Production production = key;
			if (value.CanProduce)
			{
				int currPrice = ItemTemplateHelper.GetBaseValue(production.ItemType, production.TemplateId);
				if (currPrice > price)
				{
					price = currPrice;
					favor = ItemTemplateHelper.GetBaseFavorabilityChange(production.ItemType, production.TemplateId);
				}
			}
		}
		return price * GameData.Domains.Extra.SharedConstValue.ArtisanOrderPricePercent / 100;
	}

	/// <summary>
	/// 获取截取订单的价格
	/// </summary>
	public int GetInterceptOrderPrice(bool isDebateWon, out int favor)
	{
		int createOrderPrice = GetCreateOrderPrice(out favor);
		int percent = (isDebateWon ? GameData.Domains.Extra.SharedConstValue.ArtisanOrderInterceptDebatePricePercent : GameData.Domains.Extra.SharedConstValue.ArtisanOrderInterceptPricePercent);
		return createOrderPrice * percent / 100;
	}

	/// <summary>
	/// 获取产物权重
	/// </summary>
	/// <param name="production"></param>
	/// <returns></returns>
	public int GetProductionWeight(Production production)
	{
		if (!Productions.TryGetValue(production, out var data))
		{
			return 0;
		}
		return data.Weight;
	}

	/// <summary>
	/// 一个引子能否被投入
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool CanMaterialBeAdded(ItemKey key)
	{
		if (key.ItemType != 5)
		{
			return false;
		}
		MaterialItem materialConfig = Material.Instance[key.TemplateId];
		if (materialConfig.IsSpecial)
		{
			return false;
		}
		sbyte baseGrade = materialConfig.Grade;
		if (materialConfig.RequiredLifeSkillType == 14)
		{
			baseGrade = Math.Min(8, (sbyte)(baseGrade + CookAddOn));
		}
		for (int index = 0; index < materialConfig.CraftableItemTypes.Count; index++)
		{
			short makeItemType = materialConfig.CraftableItemTypes[index];
			foreach (short makeItemSubType in MakeItemType.Instance[makeItemType].MakeItemSubTypes)
			{
				MakeItemSubTypeItem typeConfig = MakeItemSubType.Instance[makeItemSubType];
				MakeItemResult result = typeConfig.Result;
				if (materialConfig.RequiredLifeSkillType == 8 && index == 0)
				{
					baseGrade = SharedMethods.GetHerbMaterialTempGrade(baseGrade, isManual: true, !typeConfig.IsOdd);
				}
				for (int i = -1; i < 2; i++)
				{
					if (TryGetProductionTemplateId((sbyte)(baseGrade + i), result.ItemType, result.TemplateId, out var templateId) && Productions.TryGetValue(new Production(result.ItemType, templateId), out var data) && data.CanProduce)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="targetGrade"></param>
	/// <param name="itemType"></param>
	/// <param name="baseTemplateId"></param>
	/// <param name="finalTemplateId"></param>
	/// <returns></returns>
	public static bool TryGetProductionTemplateId(sbyte targetGrade, sbyte itemType, short baseTemplateId, out short finalTemplateId)
	{
		short baseGroupId = ItemTemplateHelper.GetGroupId(itemType, baseTemplateId);
		if (baseGroupId < 0)
		{
			finalTemplateId = baseTemplateId;
			return true;
		}
		targetGrade = Math.Clamp(targetGrade, 0, 8);
		sbyte baseGrade = ItemTemplateHelper.GetGrade(itemType, baseTemplateId);
		int gradeOffset = Math.Max(targetGrade - baseGrade, -2);
		short resultTemplateId = Convert.ToInt16(baseTemplateId + gradeOffset);
		bool result = (ItemTemplateHelper.CheckTemplateValid(itemType, resultTemplateId) ? ItemTemplateHelper.GetGroupId(itemType, resultTemplateId) : (-1)) == baseGroupId;
		finalTemplateId = resultTemplateId;
		return result;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += 4;
		if (Productions != null)
		{
			foreach (KeyValuePair<Production, ProductionData> pair in Productions)
			{
				totalSize += pair.Key.GetSerializedSize();
				totalSize += pair.Value.GetSerializedSize();
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
		if (Productions != null)
		{
			*(int*)pCurrData = Productions.Count;
			pCurrData += 4;
			foreach (KeyValuePair<Production, ProductionData> pair in Productions)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = CookAddOn;
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
		int ProductionsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ProductionsElementsCount > 0)
		{
			if (Productions == null)
			{
				Productions = new Dictionary<Production, ProductionData>();
			}
			else
			{
				Productions.Clear();
			}
			for (int i = 0; i < ProductionsElementsCount; i++)
			{
				Production key = default(Production);
				pCurrData += key.Deserialize(pCurrData);
				ProductionData value = default(ProductionData);
				pCurrData += value.Deserialize(pCurrData);
				Productions.Add(key, value);
			}
		}
		else
		{
			Productions?.Clear();
		}
		CookAddOn = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
