using System;
using Config.Common;

namespace Config;

[Serializable]
public class PoisonItem : ConfigItem<PoisonItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 短名称
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 衍生毒素类型
	/// - 对应此表中的模板ID
	/// </summary>
	public readonly sbyte ProduceType;

	/// <summary>
	/// 衍生毒素百分比
	/// </summary>
	public readonly byte ProducePercent;

	/// <summary>
	/// 毒发消耗毒素百分比
	/// </summary>
	public readonly byte[] AffectCostPercent;

	/// <summary>
	/// 字体颜色
	/// - 引用GameColors表中的PresetColors
	/// </summary>
	public readonly string FontColor;

	/// <summary>
	/// 图标
	/// - 毒素图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 用于Tips的小图标
	/// </summary>
	public readonly string TipsIcon;

	/// <summary>
	/// 发作阈值
	/// - 每种毒素发作所需的战斗数值，每种类型意义不同：
	/// - 烈-攻击多少次后发作
	/// - 郁-移动多少距离后发作
	/// - 寒-消耗多少百分比的提气后发作
	/// - 赤-消耗多少百分比的架势后发作
	/// - 腐-每隔多少帧发作
	/// - 幻-每隔多少帧发作
	/// </summary>
	public readonly short AffectNeedValue;

	/// <summary>
	/// 降低御体
	/// - 每有一个腐毒标记对方御体降低的百分比，御体最低降到0，且不会降低公式中的保底御体
	/// </summary>
	public readonly short ReduceOuterResist;

	/// <summary>
	/// 降低御气
	/// - 每有一个幻毒标记对方御气降低的百分比，御气最低降到0，且不会降低公式中的保底御气
	/// </summary>
	public readonly short ReduceInnerResist;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="shortName">短名称</param>
	/// <param name="desc">说明</param>
	/// <param name="produceType">衍生毒素类型 - 对应此表中的模板ID</param>
	/// <param name="producePercent">衍生毒素百分比</param>
	/// <param name="affectCostPercent">毒发消耗毒素百分比</param>
	/// <param name="fontColor">字体颜色 - 引用GameColors表中的PresetColors</param>
	/// <param name="icon">图标 - 毒素图标</param>
	/// <param name="tipsIcon">用于Tips的小图标</param>
	/// <param name="affectNeedValue">发作阈值 - 每种毒素发作所需的战斗数值，每种类型意义不同： 烈-攻击多少次后发作 郁-移动多少距离后发作 寒-消耗多少百分比的提气后发作 赤-消耗多少百分比的架势后发作 腐-每隔多少帧发作 幻-每隔多少帧发作</param>
	/// <param name="reduceOuterResist">降低御体 - 每有一个腐毒标记对方御体降低的百分比，御体最低降到0，且不会降低公式中的保底御体</param>
	/// <param name="reduceInnerResist">降低御气 - 每有一个幻毒标记对方御气降低的百分比，御气最低降到0，且不会降低公式中的保底御气</param>
	public PoisonItem(sbyte templateId, string name, string shortName, string desc, sbyte produceType, byte producePercent, byte[] affectCostPercent, string fontColor, string icon, string tipsIcon, short affectNeedValue, short reduceOuterResist, short reduceInnerResist)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		Desc = desc;
		ProduceType = produceType;
		ProducePercent = producePercent;
		AffectCostPercent = affectCostPercent;
		FontColor = fontColor;
		Icon = icon;
		TipsIcon = tipsIcon;
		AffectNeedValue = affectNeedValue;
		ReduceOuterResist = reduceOuterResist;
		ReduceInnerResist = reduceInnerResist;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PoisonItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		Desc = null;
		ProduceType = 0;
		ProducePercent = 0;
		AffectCostPercent = new byte[3];
		FontColor = null;
		Icon = null;
		TipsIcon = null;
		AffectNeedValue = -1;
		ReduceOuterResist = -1;
		ReduceInnerResist = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PoisonItem(sbyte templateId, PoisonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		Desc = other.Desc;
		ProduceType = other.ProduceType;
		ProducePercent = other.ProducePercent;
		AffectCostPercent = other.AffectCostPercent;
		FontColor = other.FontColor;
		Icon = other.Icon;
		TipsIcon = other.TipsIcon;
		AffectNeedValue = other.AffectNeedValue;
		ReduceOuterResist = other.ReduceOuterResist;
		ReduceInnerResist = other.ReduceInnerResist;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PoisonItem Duplicate(int templateId)
	{
		return new PoisonItem((sbyte)templateId, this);
	}
}
