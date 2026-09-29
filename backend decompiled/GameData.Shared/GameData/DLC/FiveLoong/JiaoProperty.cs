using System;
using Config;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

[SerializableGameData]
public class JiaoProperty : ISerializableGameData
{
	[SerializableGameDataField]
	public (int Inherited, int Fostered) TravelTimeReduction;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) MaxInventoryLoadBonus;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) DropRateBonus;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) CaptureRateBonus;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) MaxKidnapSlotAbilityBonus;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) Value;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) ExploreBonusRate;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) HappinessChange;

	[SerializableGameDataField]
	public (int Inherited, int Fostered) FavorabilityChange;

	public JiaoProperty()
	{
		TravelTimeReduction = (Inherited: 0, Fostered: 0);
		MaxInventoryLoadBonus = (Inherited: 0, Fostered: 0);
		DropRateBonus = (Inherited: 0, Fostered: 0);
		CaptureRateBonus = (Inherited: 0, Fostered: 0);
		MaxKidnapSlotAbilityBonus = (Inherited: 0, Fostered: 0);
		Value = (Inherited: 0, Fostered: 0);
		ExploreBonusRate = (Inherited: 0, Fostered: 0);
		HappinessChange = (Inherited: 0, Fostered: 0);
		FavorabilityChange = (Inherited: 0, Fostered: 0);
	}

	public JiaoProperty(int percent)
	{
		TravelTimeReduction = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)0].MaxValue * percent);
		MaxInventoryLoadBonus = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)1].MaxValue * percent);
		DropRateBonus = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)2].MaxValue * percent);
		CaptureRateBonus = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)3].MaxValue * percent);
		MaxKidnapSlotAbilityBonus = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)4].MaxValue * percent);
		ExploreBonusRate = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)5].MaxValue * percent);
		Value = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)6].MaxValue * percent);
		HappinessChange = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)7].MaxValue * percent);
		FavorabilityChange = (Inherited: 0, Fostered: Config.JiaoProperty.Instance[(short)8].MaxValue * percent);
	}

	public JiaoProperty(int travelTimeReduction, int maxInventoryLoadBonus, int dropRateBonus, int captureRateBonus, int maxKidnapSlotAbilityBonus, int value, int exploreBonusRate, int happinessChange, int favorabilityChange)
	{
		TravelTimeReduction = (Inherited: travelTimeReduction, Fostered: 0);
		MaxInventoryLoadBonus = (Inherited: maxInventoryLoadBonus, Fostered: 0);
		DropRateBonus = (Inherited: dropRateBonus, Fostered: 0);
		CaptureRateBonus = (Inherited: captureRateBonus, Fostered: 0);
		MaxKidnapSlotAbilityBonus = (Inherited: maxKidnapSlotAbilityBonus, Fostered: 0);
		Value = (Inherited: value, Fostered: 0);
		ExploreBonusRate = (Inherited: exploreBonusRate, Fostered: 0);
		HappinessChange = (Inherited: happinessChange, Fostered: 0);
		FavorabilityChange = (Inherited: favorabilityChange, Fostered: 0);
	}

	public void ResetGrowth()
	{
		TravelTimeReduction = (Inherited: TravelTimeReduction.Inherited, Fostered: 0);
		MaxInventoryLoadBonus = (Inherited: MaxInventoryLoadBonus.Inherited, Fostered: 0);
		DropRateBonus = (Inherited: DropRateBonus.Inherited, Fostered: 0);
		CaptureRateBonus = (Inherited: CaptureRateBonus.Inherited, Fostered: 0);
		MaxKidnapSlotAbilityBonus = (Inherited: MaxKidnapSlotAbilityBonus.Inherited, Fostered: 0);
		Value = (Inherited: Value.Inherited, Fostered: 0);
		ExploreBonusRate = (Inherited: ExploreBonusRate.Inherited, Fostered: 0);
		HappinessChange = (Inherited: HappinessChange.Inherited, Fostered: 0);
		FavorabilityChange = (Inherited: FavorabilityChange.Inherited, Fostered: 0);
	}

	public void Add(short templateId, int value)
	{
		switch (templateId)
		{
		case 0:
			TravelTimeReduction = (Inherited: TravelTimeReduction.Inherited, Fostered: TravelTimeReduction.Fostered + value);
			break;
		case 1:
			MaxInventoryLoadBonus = (Inherited: MaxInventoryLoadBonus.Inherited, Fostered: MaxInventoryLoadBonus.Fostered + value);
			break;
		case 2:
			DropRateBonus = (Inherited: DropRateBonus.Inherited, Fostered: DropRateBonus.Fostered + value);
			break;
		case 3:
			CaptureRateBonus = (Inherited: CaptureRateBonus.Inherited, Fostered: CaptureRateBonus.Fostered + value);
			break;
		case 4:
			MaxKidnapSlotAbilityBonus = (Inherited: MaxKidnapSlotAbilityBonus.Inherited, Fostered: MaxKidnapSlotAbilityBonus.Fostered + value);
			break;
		case 5:
			ExploreBonusRate = (Inherited: ExploreBonusRate.Inherited, Fostered: ExploreBonusRate.Fostered + value);
			break;
		case 6:
			Value = (Inherited: Value.Inherited, Fostered: Value.Fostered + value);
			break;
		case 7:
			HappinessChange = (Inherited: HappinessChange.Inherited, Fostered: HappinessChange.Fostered + value);
			break;
		case 8:
			FavorabilityChange = (Inherited: FavorabilityChange.Inherited, Fostered: FavorabilityChange.Fostered + value);
			break;
		}
	}

	public void Set(short templateId, int value)
	{
		switch (templateId)
		{
		case 0:
			TravelTimeReduction = (Inherited: TravelTimeReduction.Inherited, Fostered: value);
			break;
		case 1:
			MaxInventoryLoadBonus = (Inherited: MaxInventoryLoadBonus.Inherited, Fostered: value);
			break;
		case 2:
			DropRateBonus = (Inherited: DropRateBonus.Inherited, Fostered: value);
			break;
		case 3:
			CaptureRateBonus = (Inherited: CaptureRateBonus.Inherited, Fostered: value);
			break;
		case 4:
			MaxKidnapSlotAbilityBonus = (Inherited: MaxKidnapSlotAbilityBonus.Inherited, Fostered: value);
			break;
		case 5:
			ExploreBonusRate = (Inherited: ExploreBonusRate.Inherited, Fostered: value);
			break;
		case 6:
			Value = (Inherited: Value.Inherited, Fostered: value);
			break;
		case 7:
			HappinessChange = (Inherited: HappinessChange.Inherited, Fostered: value);
			break;
		case 8:
			FavorabilityChange = (Inherited: FavorabilityChange.Inherited, Fostered: value);
			break;
		}
	}

	public int Get(short jiaoTemplateId, short propertyTemplateId)
	{
		JiaoItem config = Config.Jiao.Instance[jiaoTemplateId];
		int value = propertyTemplateId switch
		{
			0 => config.TravelTimeReduction + TravelTimeReduction.Inherited + TravelTimeReduction.Fostered / 100, 
			1 => config.MaxInventoryLoadBonus + MaxInventoryLoadBonus.Inherited + MaxInventoryLoadBonus.Fostered / 100, 
			2 => config.BaseDropRateBonus + DropRateBonus.Inherited + DropRateBonus.Fostered / 100, 
			3 => config.BaseCaptureRateBonus + CaptureRateBonus.Inherited + CaptureRateBonus.Fostered / 100, 
			4 => config.BaseMaxKidnapSlotAbilityBonus + MaxKidnapSlotAbilityBonus.Inherited + MaxKidnapSlotAbilityBonus.Fostered / 100, 
			5 => config.ExploreBonusRate + ExploreBonusRate.Inherited + ExploreBonusRate.Fostered / 100, 
			6 => config.BaseValue + Value.Inherited + Value.Fostered / 100, 
			7 => config.BaseHappinessChange + HappinessChange.Inherited + HappinessChange.Fostered / 100, 
			8 => config.BaseFavorabilityChange + FavorabilityChange.Inherited + FavorabilityChange.Fostered / 100, 
			_ => throw new Exception($"wrong property id: {propertyTemplateId}"), 
		};
		return Math.Min(Config.JiaoProperty.Instance[propertyTemplateId].MaxValue, value);
	}

	public int Get(short jiaoTemplateId, short loongTemplateId, short propertyTemplateId)
	{
		if (loongTemplateId >= 31 && loongTemplateId <= 39 && propertyTemplateId == Config.Jiao.Instance[loongTemplateId].AdvantageProperty)
		{
			return Config.Jiao.Instance[loongTemplateId].AdvantagePropertyValue;
		}
		JiaoItem config = Config.Jiao.Instance[jiaoTemplateId];
		int value = propertyTemplateId switch
		{
			0 => config.TravelTimeReduction + TravelTimeReduction.Inherited + TravelTimeReduction.Fostered / 100, 
			1 => config.MaxInventoryLoadBonus + MaxInventoryLoadBonus.Inherited + MaxInventoryLoadBonus.Fostered / 100, 
			2 => config.BaseDropRateBonus + DropRateBonus.Inherited + DropRateBonus.Fostered / 100, 
			3 => config.BaseCaptureRateBonus + CaptureRateBonus.Inherited + CaptureRateBonus.Fostered / 100, 
			4 => config.BaseMaxKidnapSlotAbilityBonus + MaxKidnapSlotAbilityBonus.Inherited + MaxKidnapSlotAbilityBonus.Fostered / 100, 
			5 => config.ExploreBonusRate + ExploreBonusRate.Inherited + ExploreBonusRate.Fostered / 100, 
			6 => config.BaseValue + Value.Inherited + Value.Fostered / 100, 
			7 => config.BaseHappinessChange + HappinessChange.Inherited + HappinessChange.Fostered / 100, 
			8 => config.BaseFavorabilityChange + FavorabilityChange.Inherited + FavorabilityChange.Fostered / 100, 
			_ => throw new Exception($"wrong property id: {propertyTemplateId}"), 
		};
		return Math.Min(Config.JiaoProperty.Instance[propertyTemplateId].MaxValue, value);
	}

	public (int Inherited, int Fostered) SeparateGet(short propertyTemplateId)
	{
		return propertyTemplateId switch
		{
			0 => (Inherited: TravelTimeReduction.Inherited, Fostered: TravelTimeReduction.Fostered), 
			1 => (Inherited: MaxInventoryLoadBonus.Inherited, Fostered: MaxInventoryLoadBonus.Fostered), 
			2 => (Inherited: DropRateBonus.Inherited, Fostered: DropRateBonus.Fostered), 
			3 => (Inherited: CaptureRateBonus.Inherited, Fostered: CaptureRateBonus.Fostered), 
			4 => (Inherited: MaxKidnapSlotAbilityBonus.Inherited, Fostered: MaxKidnapSlotAbilityBonus.Fostered), 
			5 => (Inherited: ExploreBonusRate.Inherited, Fostered: ExploreBonusRate.Fostered), 
			6 => (Inherited: Value.Inherited, Fostered: Value.Fostered), 
			7 => (Inherited: HappinessChange.Inherited, Fostered: HappinessChange.Fostered), 
			8 => (Inherited: FavorabilityChange.Inherited, Fostered: FavorabilityChange.Fostered), 
			_ => throw new Exception("wrong property id"), 
		};
	}

	public void DeepCopy(JiaoProperty other)
	{
		TravelTimeReduction = other.TravelTimeReduction;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		DropRateBonus = other.DropRateBonus;
		CaptureRateBonus = other.CaptureRateBonus;
		MaxKidnapSlotAbilityBonus = other.MaxKidnapSlotAbilityBonus;
		Value = other.Value;
		ExploreBonusRate = other.ExploreBonusRate;
		HappinessChange = other.HappinessChange;
		FavorabilityChange = other.FavorabilityChange;
	}

	public JiaoProperty(JiaoProperty other)
	{
		TravelTimeReduction = other.TravelTimeReduction;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		DropRateBonus = other.DropRateBonus;
		CaptureRateBonus = other.CaptureRateBonus;
		MaxKidnapSlotAbilityBonus = other.MaxKidnapSlotAbilityBonus;
		Value = other.Value;
		ExploreBonusRate = other.ExploreBonusRate;
		HappinessChange = other.HappinessChange;
		FavorabilityChange = other.FavorabilityChange;
	}

	public void Assign(JiaoProperty other)
	{
		TravelTimeReduction = other.TravelTimeReduction;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		DropRateBonus = other.DropRateBonus;
		CaptureRateBonus = other.CaptureRateBonus;
		MaxKidnapSlotAbilityBonus = other.MaxKidnapSlotAbilityBonus;
		Value = other.Value;
		ExploreBonusRate = other.ExploreBonusRate;
		HappinessChange = other.HappinessChange;
		FavorabilityChange = other.FavorabilityChange;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 72;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.Serialize(pData, TravelTimeReduction);
		byte* num2 = num + SerializationHelper.Serialize(num, MaxInventoryLoadBonus);
		byte* num3 = num2 + SerializationHelper.Serialize(num2, DropRateBonus);
		byte* num4 = num3 + SerializationHelper.Serialize(num3, CaptureRateBonus);
		byte* num5 = num4 + SerializationHelper.Serialize(num4, MaxKidnapSlotAbilityBonus);
		byte* num6 = num5 + SerializationHelper.Serialize(num5, Value);
		byte* num7 = num6 + SerializationHelper.Serialize(num6, ExploreBonusRate);
		byte* num8 = num7 + SerializationHelper.Serialize(num7, HappinessChange);
		int totalSize = (int)(num8 + SerializationHelper.Serialize(num8, FavorabilityChange) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.Deserialize(pData, out TravelTimeReduction);
		byte* num2 = num + SerializationHelper.Deserialize(num, out MaxInventoryLoadBonus);
		byte* num3 = num2 + SerializationHelper.Deserialize(num2, out DropRateBonus);
		byte* num4 = num3 + SerializationHelper.Deserialize(num3, out CaptureRateBonus);
		byte* num5 = num4 + SerializationHelper.Deserialize(num4, out MaxKidnapSlotAbilityBonus);
		byte* num6 = num5 + SerializationHelper.Deserialize(num5, out Value);
		byte* num7 = num6 + SerializationHelper.Deserialize(num6, out ExploreBonusRate);
		byte* num8 = num7 + SerializationHelper.Deserialize(num7, out HappinessChange);
		int totalSize = (int)(num8 + SerializationHelper.Deserialize(num8, out FavorabilityChange) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
