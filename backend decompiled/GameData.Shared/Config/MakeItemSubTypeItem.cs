using System;
using Config.Common;
using Config.ConfigCells;
using GameData.Domains.Map;

namespace Config;

[Serializable]
public class MakeItemSubTypeItem : ConfigItem<MakeItemSubTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// - 以单字的形式，显示在制造大类内，供玩家选择
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 筛选中的名称
	/// - 详细筛选里中使用此列的名称去显示
	/// </summary>
	public readonly string FilterName;

	/// <summary>
	/// 是否为偏方
	/// - 仅制药使用
	/// </summary>
	public readonly bool IsOdd;

	/// <summary>
	/// 精制效果
	/// - 对应RefiningEffect表的TemplateId。用于查找拆解时获得的精制材料。
	/// </summary>
	public readonly sbyte RefiningEffect;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 额外造诣需求
	/// - 手动选择二级分类时，制造需要的造诣上升的幅度，公式为该配置值* (引子的级别[0,8] + 1)
	/// </summary>
	public readonly short ExtraLifeSkill;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 制作时间
	/// - 需要多少个月才能制造完成，时间为0的点下制作即可完成
	/// </summary>
	public readonly short Time;

	/// <summary>
	/// 总份数
	/// - 需要投入各类材料总计多少份可以开始制作
	/// </summary>
	public readonly short ResourceTotalCount;

	/// <summary>
	/// 最大材料投入
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly MaterialResources MaxMaterialResources;

	/// <summary>
	/// 产物
	/// </summary>
	public readonly MakeItemResult Result;

	/// <summary>
	/// 木材
	/// - 根据前四列生成，值在 GameData.Domains.Item.EquipmentBonusType 中定义，不要手动填写
	/// </summary>
	public readonly sbyte WoodEffect;

	/// <summary>
	/// 金铁
	/// </summary>
	public readonly sbyte MetalEffect;

	/// <summary>
	/// 玉石
	/// </summary>
	public readonly sbyte JadeEffect;

	/// <summary>
	/// 织物
	/// </summary>
	public readonly sbyte FabricEffect;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称 - 以单字的形式，显示在制造大类内，供玩家选择</param>
	/// <param name="filterName">筛选中的名称 - 详细筛选里中使用此列的名称去显示</param>
	/// <param name="isOdd">是否为偏方 - 仅制药使用</param>
	/// <param name="refiningEffect">精制效果 - 对应RefiningEffect表的TemplateId。用于查找拆解时获得的精制材料。</param>
	/// <param name="desc">描述</param>
	/// <param name="extraLifeSkill">额外造诣需求 - 手动选择二级分类时，制造需要的造诣上升的幅度，公式为该配置值* (引子的级别[0,8] + 1)</param>
	/// <param name="icon">图标</param>
	/// <param name="time">制作时间 - 需要多少个月才能制造完成，时间为0的点下制作即可完成</param>
	/// <param name="resourceTotalCount">总份数 - 需要投入各类材料总计多少份可以开始制作</param>
	/// <param name="maxMaterialResources">最大材料投入 - 该列由公式生成，禁止手动填写</param>
	/// <param name="result">产物</param>
	/// <param name="woodEffect">木材 - 根据前四列生成，值在 GameData.Domains.Item.EquipmentBonusType 中定义，不要手动填写</param>
	/// <param name="metalEffect">金铁</param>
	/// <param name="jadeEffect">玉石</param>
	/// <param name="fabricEffect">织物</param>
	public MakeItemSubTypeItem(short templateId, string name, string filterName, bool isOdd, sbyte refiningEffect, string desc, short extraLifeSkill, string icon, short time, short resourceTotalCount, MaterialResources maxMaterialResources, MakeItemResult result, sbyte woodEffect, sbyte metalEffect, sbyte jadeEffect, sbyte fabricEffect)
	{
		TemplateId = templateId;
		Name = name;
		FilterName = filterName;
		IsOdd = isOdd;
		RefiningEffect = refiningEffect;
		Desc = desc;
		ExtraLifeSkill = extraLifeSkill;
		Icon = icon;
		Time = time;
		ResourceTotalCount = resourceTotalCount;
		MaxMaterialResources = maxMaterialResources;
		Result = result;
		WoodEffect = woodEffect;
		MetalEffect = metalEffect;
		JadeEffect = jadeEffect;
		FabricEffect = fabricEffect;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MakeItemSubTypeItem()
	{
		TemplateId = 0;
		Name = null;
		FilterName = null;
		IsOdd = false;
		RefiningEffect = 0;
		Desc = null;
		ExtraLifeSkill = 15;
		Icon = null;
		Time = 0;
		ResourceTotalCount = 50;
		MaxMaterialResources = new MaterialResources(default(short), default(short), default(short), default(short), default(short), default(short));
		Result = default(MakeItemResult);
		WoodEffect = -1;
		MetalEffect = -1;
		JadeEffect = -1;
		FabricEffect = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MakeItemSubTypeItem(short templateId, MakeItemSubTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		FilterName = other.FilterName;
		IsOdd = other.IsOdd;
		RefiningEffect = other.RefiningEffect;
		Desc = other.Desc;
		ExtraLifeSkill = other.ExtraLifeSkill;
		Icon = other.Icon;
		Time = other.Time;
		ResourceTotalCount = other.ResourceTotalCount;
		MaxMaterialResources = other.MaxMaterialResources;
		Result = other.Result;
		WoodEffect = other.WoodEffect;
		MetalEffect = other.MetalEffect;
		JadeEffect = other.JadeEffect;
		FabricEffect = other.FabricEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MakeItemSubTypeItem Duplicate(int templateId)
	{
		return new MakeItemSubTypeItem((short)templateId, this);
	}
}
