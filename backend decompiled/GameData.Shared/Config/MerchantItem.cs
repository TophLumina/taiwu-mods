using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class MerchantItem : ConfigItem<MerchantItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte GroupId;

	public readonly sbyte MerchantType;

	public readonly sbyte Level;

	public readonly string UiName;

	public readonly int FavorRequirement;

	public readonly sbyte RefreshInterval;

	public readonly short GenerateInterval;

	public readonly sbyte MoveInterval;

	public readonly int Money;

	public readonly List<PresetItemTemplateIdGroup> Goods0;

	public readonly List<PresetItemTemplateIdGroup> Goods1;

	public readonly List<PresetItemTemplateIdGroup> Goods2;

	public readonly List<PresetItemTemplateIdGroup> Goods3;

	public readonly List<PresetItemTemplateIdGroup> Goods4;

	public readonly List<PresetItemTemplateIdGroup> Goods5;

	public readonly List<PresetItemTemplateIdGroup> Goods6;

	public readonly List<PresetItemTemplateIdGroup> Goods7;

	public readonly List<PresetItemTemplateIdGroup> Goods8;

	public readonly List<PresetItemTemplateIdGroup> Goods9;

	public readonly List<PresetItemTemplateIdGroup> Goods10;

	public readonly List<PresetItemTemplateIdGroup> Goods11;

	public readonly List<PresetItemTemplateIdGroup> Goods12;

	public readonly List<PresetItemTemplateIdGroup> Goods13;

	public readonly sbyte[] ExtraGoodsIndexGroup;

	public readonly sbyte[] CapitalistSkillExtraGoodsIndexGroup;

	public readonly short[] GoodsRate;

	public readonly short[] CapitalistSkillExtraGoodsRate;

	public readonly short[] SeasonsGoodsRate0;

	public readonly short[] SeasonsGoodsRate1;

	public readonly short[] SeasonsGoodsRate2;

	public readonly short[] SeasonsGoodsRate3;

	public readonly List<short> Guards;

	public readonly short Enemy;

	public MerchantItem Group
	{
		[return: MaybeNull]
		get
		{
			return Merchant.Instance.GetItemOrDefault(GroupId);
		}
	}

	public MerchantItem(sbyte templateId, sbyte groupId, sbyte merchantType, sbyte level, string uiName, int favorRequirement, sbyte refreshInterval, short generateInterval, sbyte moveInterval, int money, List<PresetItemTemplateIdGroup> goods0, List<PresetItemTemplateIdGroup> goods1, List<PresetItemTemplateIdGroup> goods2, List<PresetItemTemplateIdGroup> goods3, List<PresetItemTemplateIdGroup> goods4, List<PresetItemTemplateIdGroup> goods5, List<PresetItemTemplateIdGroup> goods6, List<PresetItemTemplateIdGroup> goods7, List<PresetItemTemplateIdGroup> goods8, List<PresetItemTemplateIdGroup> goods9, List<PresetItemTemplateIdGroup> goods10, List<PresetItemTemplateIdGroup> goods11, List<PresetItemTemplateIdGroup> goods12, List<PresetItemTemplateIdGroup> goods13, sbyte[] extraGoodsIndexGroup, sbyte[] capitalistSkillExtraGoodsIndexGroup, short[] goodsRate, short[] capitalistSkillExtraGoodsRate, short[] seasonsGoodsRate0, short[] seasonsGoodsRate1, short[] seasonsGoodsRate2, short[] seasonsGoodsRate3, List<short> guards, short enemy)
	{
		TemplateId = templateId;
		GroupId = groupId;
		MerchantType = merchantType;
		Level = level;
		UiName = uiName;
		FavorRequirement = favorRequirement;
		RefreshInterval = refreshInterval;
		GenerateInterval = generateInterval;
		MoveInterval = moveInterval;
		Money = money;
		Goods0 = goods0;
		Goods1 = goods1;
		Goods2 = goods2;
		Goods3 = goods3;
		Goods4 = goods4;
		Goods5 = goods5;
		Goods6 = goods6;
		Goods7 = goods7;
		Goods8 = goods8;
		Goods9 = goods9;
		Goods10 = goods10;
		Goods11 = goods11;
		Goods12 = goods12;
		Goods13 = goods13;
		ExtraGoodsIndexGroup = extraGoodsIndexGroup;
		CapitalistSkillExtraGoodsIndexGroup = capitalistSkillExtraGoodsIndexGroup;
		GoodsRate = goodsRate;
		CapitalistSkillExtraGoodsRate = capitalistSkillExtraGoodsRate;
		SeasonsGoodsRate0 = seasonsGoodsRate0;
		SeasonsGoodsRate1 = seasonsGoodsRate1;
		SeasonsGoodsRate2 = seasonsGoodsRate2;
		SeasonsGoodsRate3 = seasonsGoodsRate3;
		Guards = guards;
		Enemy = enemy;
	}

	public MerchantItem()
	{
		TemplateId = 0;
		GroupId = 0;
		MerchantType = 0;
		Level = 0;
		UiName = null;
		FavorRequirement = 0;
		RefreshInterval = 1;
		GenerateInterval = 0;
		MoveInterval = 0;
		Money = 0;
		Goods0 = new List<PresetItemTemplateIdGroup>();
		Goods1 = new List<PresetItemTemplateIdGroup>();
		Goods2 = new List<PresetItemTemplateIdGroup>();
		Goods3 = new List<PresetItemTemplateIdGroup>();
		Goods4 = new List<PresetItemTemplateIdGroup>();
		Goods5 = new List<PresetItemTemplateIdGroup>();
		Goods6 = new List<PresetItemTemplateIdGroup>();
		Goods7 = new List<PresetItemTemplateIdGroup>();
		Goods8 = new List<PresetItemTemplateIdGroup>();
		Goods9 = new List<PresetItemTemplateIdGroup>();
		Goods10 = new List<PresetItemTemplateIdGroup>();
		Goods11 = new List<PresetItemTemplateIdGroup>();
		Goods12 = new List<PresetItemTemplateIdGroup>();
		Goods13 = new List<PresetItemTemplateIdGroup>();
		ExtraGoodsIndexGroup = new sbyte[0];
		CapitalistSkillExtraGoodsIndexGroup = new sbyte[0];
		GoodsRate = new short[14];
		CapitalistSkillExtraGoodsRate = new short[14];
		SeasonsGoodsRate0 = new short[14];
		SeasonsGoodsRate1 = new short[14];
		SeasonsGoodsRate2 = new short[14];
		SeasonsGoodsRate3 = new short[14];
		Guards = new List<short>();
		Enemy = 0;
	}

	public MerchantItem(sbyte templateId, MerchantItem other)
	{
		TemplateId = templateId;
		GroupId = other.GroupId;
		MerchantType = other.MerchantType;
		Level = other.Level;
		UiName = other.UiName;
		FavorRequirement = other.FavorRequirement;
		RefreshInterval = other.RefreshInterval;
		GenerateInterval = other.GenerateInterval;
		MoveInterval = other.MoveInterval;
		Money = other.Money;
		Goods0 = other.Goods0;
		Goods1 = other.Goods1;
		Goods2 = other.Goods2;
		Goods3 = other.Goods3;
		Goods4 = other.Goods4;
		Goods5 = other.Goods5;
		Goods6 = other.Goods6;
		Goods7 = other.Goods7;
		Goods8 = other.Goods8;
		Goods9 = other.Goods9;
		Goods10 = other.Goods10;
		Goods11 = other.Goods11;
		Goods12 = other.Goods12;
		Goods13 = other.Goods13;
		ExtraGoodsIndexGroup = other.ExtraGoodsIndexGroup;
		CapitalistSkillExtraGoodsIndexGroup = other.CapitalistSkillExtraGoodsIndexGroup;
		GoodsRate = other.GoodsRate;
		CapitalistSkillExtraGoodsRate = other.CapitalistSkillExtraGoodsRate;
		SeasonsGoodsRate0 = other.SeasonsGoodsRate0;
		SeasonsGoodsRate1 = other.SeasonsGoodsRate1;
		SeasonsGoodsRate2 = other.SeasonsGoodsRate2;
		SeasonsGoodsRate3 = other.SeasonsGoodsRate3;
		Guards = other.Guards;
		Enemy = other.Enemy;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MerchantItem Duplicate(int templateId)
	{
		return new MerchantItem((sbyte)templateId, this);
	}
}
