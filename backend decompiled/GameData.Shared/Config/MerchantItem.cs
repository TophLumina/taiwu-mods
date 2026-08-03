using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class MerchantItem : ConfigItem<MerchantItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 分组
	/// </summary>
	public readonly sbyte GroupId;

	/// <summary>
	/// 类型
	/// - 对应MerchantType表中的模板ID
	/// </summary>
	public readonly sbyte MerchantType;

	/// <summary>
	/// 等级
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string UiName;

	/// <summary>
	/// 购买好感需求
	/// </summary>
	public readonly int FavorRequirement;

	/// <summary>
	/// 刷新间隔
	/// </summary>
	public readonly sbyte RefreshInterval;

	/// <summary>
	/// 生成间隔
	/// - 为-1时必须保证商队资金小于等于0
	/// </summary>
	public readonly short GenerateInterval;

	/// <summary>
	/// 移动间隔
	/// - 为-1时必须保证商队资金小于等于0
	/// </summary>
	public readonly sbyte MoveInterval;

	/// <summary>
	/// 商队资金
	/// </summary>
	public readonly int Money;

	/// <summary>
	/// 一组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods0;

	/// <summary>
	/// 二组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods1;

	/// <summary>
	/// 三组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods2;

	/// <summary>
	/// 四组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods3;

	/// <summary>
	/// 五组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods4;

	/// <summary>
	/// 六组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods5;

	/// <summary>
	/// 七组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods6;

	/// <summary>
	/// 八组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods7;

	/// <summary>
	/// 九组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods8;

	/// <summary>
	/// 十组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods9;

	/// <summary>
	/// 十一组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods10;

	/// <summary>
	/// 十二组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods11;

	/// <summary>
	/// 十三组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods12;

	/// <summary>
	/// 十四组
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> Goods13;

	/// <summary>
	/// 额外高级商品
	/// - 从高一级商店的0~13对应的组中随机抽取1个商品作为额外商品
	/// </summary>
	public readonly sbyte[] ExtraGoodsIndexGroup;

	/// <summary>
	/// 诸会宝号额外高级商品
	/// - 从高一级商店的0~13对应的组中随机抽取1个商品作为额外商品
	/// </summary>
	public readonly sbyte[] CapitalistSkillExtraGoodsIndexGroup;

	/// <summary>
	/// 生成项
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] GoodsRate;

	/// <summary>
	/// 诸会宝号生成项
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] CapitalistSkillExtraGoodsRate;

	/// <summary>
	/// 季节生成项春
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] SeasonsGoodsRate0;

	/// <summary>
	/// 季节生成项夏
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] SeasonsGoodsRate1;

	/// <summary>
	/// 季节生成项秋
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] SeasonsGoodsRate2;

	/// <summary>
	/// 季节生成项冬
	/// - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项
	/// </summary>
	public readonly short[] SeasonsGoodsRate3;

	/// <summary>
	/// 护卫列表
	/// </summary>
	public readonly List<short> Guards;

	/// <summary>
	/// 外道劫匪
	/// </summary>
	public readonly short Enemy;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="groupId">分组</param>
	/// <param name="merchantType">类型 - 对应MerchantType表中的模板ID</param>
	/// <param name="level">等级</param>
	/// <param name="uiName">名称</param>
	/// <param name="favorRequirement">购买好感需求</param>
	/// <param name="refreshInterval">刷新间隔</param>
	/// <param name="generateInterval">生成间隔 - 为-1时必须保证商队资金小于等于0</param>
	/// <param name="moveInterval">移动间隔 - 为-1时必须保证商队资金小于等于0</param>
	/// <param name="money">商队资金</param>
	/// <param name="goods0">一组</param>
	/// <param name="goods1">二组</param>
	/// <param name="goods2">三组</param>
	/// <param name="goods3">四组</param>
	/// <param name="goods4">五组</param>
	/// <param name="goods5">六组</param>
	/// <param name="goods6">七组</param>
	/// <param name="goods7">八组</param>
	/// <param name="goods8">九组</param>
	/// <param name="goods9">十组</param>
	/// <param name="goods10">十一组</param>
	/// <param name="goods11">十二组</param>
	/// <param name="goods12">十三组</param>
	/// <param name="goods13">十四组</param>
	/// <param name="extraGoodsIndexGroup">额外高级商品 - 从高一级商店的0~13对应的组中随机抽取1个商品作为额外商品</param>
	/// <param name="capitalistSkillExtraGoodsIndexGroup">诸会宝号额外高级商品 - 从高一级商店的0~13对应的组中随机抽取1个商品作为额外商品</param>
	/// <param name="goodsRate">生成项 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="capitalistSkillExtraGoodsRate">诸会宝号生成项 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="seasonsGoodsRate0">季节生成项春 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="seasonsGoodsRate1">季节生成项夏 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="seasonsGoodsRate2">季节生成项秋 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="seasonsGoodsRate3">季节生成项冬 - 每组会出现在商店列表中的最少项数，决定要生成多少项道具时，将此值随机增加0%~50%，如果项数为负数，代表N%几率出现1项</param>
	/// <param name="guards">护卫列表</param>
	/// <param name="enemy">外道劫匪</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MerchantItem Duplicate(int templateId)
	{
		return new MerchantItem((sbyte)templateId, this);
	}
}
