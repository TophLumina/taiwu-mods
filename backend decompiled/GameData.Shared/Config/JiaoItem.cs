using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoItem : ConfigItem<JiaoItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 属性
	/// - 属性即为原名，是玩家看到的具体的蛟的名字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 体长
	/// - 取值范围[1,18]
	/// </summary>
	public readonly int Length;

	/// <summary>
	/// 体重
	/// - 取值范围[100,900]
	/// </summary>
	public readonly int Weight;

	/// <summary>
	/// 寿命
	/// - 取值范围[0,9000]
	/// </summary>
	public readonly int Life;

	/// <summary>
	/// 基础旅行时间减少
	/// - 旅行时间减少百分比
	/// </summary>
	public readonly sbyte TravelTimeReduction;

	/// <summary>
	/// 基础最大行囊负重加成
	/// - 取值范围[2000,4000]
	/// </summary>
	public readonly short MaxInventoryLoadBonus;

	/// <summary>
	/// 基础最大劫持软上限加成
	/// - 关押栏位数量上限加成
	/// </summary>
	public readonly short BaseMaxKidnapSlotAbilityBonus;

	/// <summary>
	/// 基础掉落率加成
	/// - 装备后对其他物品的掉落率加成的影响
	/// </summary>
	public readonly short BaseDropRateBonus;

	/// <summary>
	/// 基础降伏机率加成
	/// - 绳索捕捉成功概率加成
	/// </summary>
	public readonly short BaseCaptureRateBonus;

	/// <summary>
	/// 探索的奖励
	/// - 地图上拾取物获取奖励升级的概率
	/// </summary>
	public readonly short ExploreBonusRate;

	/// <summary>
	/// 价格
	/// </summary>
	public readonly int BasePrice;

	/// <summary>
	/// 价值
	/// </summary>
	public readonly int BaseValue;

	/// <summary>
	/// 心情
	/// </summary>
	public readonly sbyte BaseHappinessChange;

	/// <summary>
	/// 好感
	/// </summary>
	public readonly int BaseFavorabilityChange;

	/// <summary>
	/// 礼物级别
	/// </summary>
	public readonly sbyte GiftLevel;

	/// <summary>
	/// 优势属性
	/// </summary>
	public readonly short AdvantageProperty;

	/// <summary>
	/// 优势属性值
	/// </summary>
	public readonly int AdvantagePropertyValue;

	/// <summary>
	/// 过月事件消耗
	/// - 过月事件消耗的概率点数
	/// </summary>
	public readonly int MonthlyEventCost;

	/// <summary>
	/// 蛟的颜色
	/// - 参考Color页签里的对应关系
	/// </summary>
	public readonly List<string> ColorList;

	/// <summary>
	/// 角色表的引用
	/// </summary>
	public readonly short IndexOfCharacterTemplate;

	/// <summary>
	/// 代步表的引用
	/// </summary>
	public readonly short IndexOfCarrierTemplate;

	/// <summary>
	/// 动物表的引用
	/// </summary>
	public readonly short IndexOfAnimalTemplate;

	/// <summary>
	/// 材料表的蛟卵引用
	/// - 用于行囊显示和拆解
	/// </summary>
	public readonly short EggMaterial;

	/// <summary>
	/// 材料表的未成年蛟引用
	/// - 用于行囊显示和拆解
	/// </summary>
	public readonly short TeenagerMaterial;

	/// <summary>
	/// 对应的黑影资源名
	/// </summary>
	public readonly string ShadowImage;

	/// <summary>
	/// 对应的吼声音效
	/// </summary>
	public readonly string BellowSound;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">属性 - 属性即为原名，是玩家看到的具体的蛟的名字</param>
	/// <param name="length">体长 - 取值范围[1,18]</param>
	/// <param name="weight">体重 - 取值范围[100,900]</param>
	/// <param name="life">寿命 - 取值范围[0,9000]</param>
	/// <param name="travelTimeReduction">基础旅行时间减少 - 旅行时间减少百分比</param>
	/// <param name="maxInventoryLoadBonus">基础最大行囊负重加成 - 取值范围[2000,4000]</param>
	/// <param name="baseMaxKidnapSlotAbilityBonus">基础最大劫持软上限加成 - 关押栏位数量上限加成</param>
	/// <param name="baseDropRateBonus">基础掉落率加成 - 装备后对其他物品的掉落率加成的影响</param>
	/// <param name="baseCaptureRateBonus">基础降伏机率加成 - 绳索捕捉成功概率加成</param>
	/// <param name="exploreBonusRate">探索的奖励 - 地图上拾取物获取奖励升级的概率</param>
	/// <param name="basePrice">价格</param>
	/// <param name="baseValue">价值</param>
	/// <param name="baseHappinessChange">心情</param>
	/// <param name="baseFavorabilityChange">好感</param>
	/// <param name="giftLevel">礼物级别</param>
	/// <param name="advantageProperty">优势属性</param>
	/// <param name="advantagePropertyValue">优势属性值</param>
	/// <param name="monthlyEventCost">过月事件消耗 - 过月事件消耗的概率点数</param>
	/// <param name="colorList">蛟的颜色 - 参考Color页签里的对应关系</param>
	/// <param name="indexOfCharacterTemplate">角色表的引用</param>
	/// <param name="indexOfCarrierTemplate">代步表的引用</param>
	/// <param name="indexOfAnimalTemplate">动物表的引用</param>
	/// <param name="eggMaterial">材料表的蛟卵引用 - 用于行囊显示和拆解</param>
	/// <param name="teenagerMaterial">材料表的未成年蛟引用 - 用于行囊显示和拆解</param>
	/// <param name="shadowImage">对应的黑影资源名</param>
	/// <param name="bellowSound">对应的吼声音效</param>
	public JiaoItem(short templateId, string name, int length, int weight, int life, sbyte travelTimeReduction, short maxInventoryLoadBonus, short baseMaxKidnapSlotAbilityBonus, short baseDropRateBonus, short baseCaptureRateBonus, short exploreBonusRate, int basePrice, int baseValue, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, short advantageProperty, int advantagePropertyValue, int monthlyEventCost, List<string> colorList, short indexOfCharacterTemplate, short indexOfCarrierTemplate, short indexOfAnimalTemplate, short eggMaterial, short teenagerMaterial, string shadowImage, string bellowSound)
	{
		TemplateId = templateId;
		Name = name;
		Length = length;
		Weight = weight;
		Life = life;
		TravelTimeReduction = travelTimeReduction;
		MaxInventoryLoadBonus = maxInventoryLoadBonus;
		BaseMaxKidnapSlotAbilityBonus = baseMaxKidnapSlotAbilityBonus;
		BaseDropRateBonus = baseDropRateBonus;
		BaseCaptureRateBonus = baseCaptureRateBonus;
		ExploreBonusRate = exploreBonusRate;
		BasePrice = basePrice;
		BaseValue = baseValue;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		AdvantageProperty = advantageProperty;
		AdvantagePropertyValue = advantagePropertyValue;
		MonthlyEventCost = monthlyEventCost;
		ColorList = colorList;
		IndexOfCharacterTemplate = indexOfCharacterTemplate;
		IndexOfCarrierTemplate = indexOfCarrierTemplate;
		IndexOfAnimalTemplate = indexOfAnimalTemplate;
		EggMaterial = eggMaterial;
		TeenagerMaterial = teenagerMaterial;
		ShadowImage = shadowImage;
		BellowSound = bellowSound;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JiaoItem()
	{
		TemplateId = 0;
		Name = null;
		Length = -1;
		Weight = -1;
		Life = -1;
		TravelTimeReduction = -1;
		MaxInventoryLoadBonus = -1;
		BaseMaxKidnapSlotAbilityBonus = 0;
		BaseDropRateBonus = -1;
		BaseCaptureRateBonus = -1;
		ExploreBonusRate = 0;
		BasePrice = 0;
		BaseValue = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 0;
		GiftLevel = 8;
		AdvantageProperty = 0;
		AdvantagePropertyValue = 0;
		MonthlyEventCost = 0;
		ColorList = new List<string> { "" };
		IndexOfCharacterTemplate = 0;
		IndexOfCarrierTemplate = 0;
		IndexOfAnimalTemplate = 0;
		EggMaterial = 0;
		TeenagerMaterial = 0;
		ShadowImage = null;
		BellowSound = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JiaoItem(short templateId, JiaoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Length = other.Length;
		Weight = other.Weight;
		Life = other.Life;
		TravelTimeReduction = other.TravelTimeReduction;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		BaseMaxKidnapSlotAbilityBonus = other.BaseMaxKidnapSlotAbilityBonus;
		BaseDropRateBonus = other.BaseDropRateBonus;
		BaseCaptureRateBonus = other.BaseCaptureRateBonus;
		ExploreBonusRate = other.ExploreBonusRate;
		BasePrice = other.BasePrice;
		BaseValue = other.BaseValue;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		AdvantageProperty = other.AdvantageProperty;
		AdvantagePropertyValue = other.AdvantagePropertyValue;
		MonthlyEventCost = other.MonthlyEventCost;
		ColorList = other.ColorList;
		IndexOfCharacterTemplate = other.IndexOfCharacterTemplate;
		IndexOfCarrierTemplate = other.IndexOfCarrierTemplate;
		IndexOfAnimalTemplate = other.IndexOfAnimalTemplate;
		EggMaterial = other.EggMaterial;
		TeenagerMaterial = other.TeenagerMaterial;
		ShadowImage = other.ShadowImage;
		BellowSound = other.BellowSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JiaoItem Duplicate(int templateId)
	{
		return new JiaoItem((short)templateId, this);
	}
}
