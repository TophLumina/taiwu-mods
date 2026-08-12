using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridTypeItem : ConfigItem<SkillBreakGridTypeItem, sbyte>
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
	/// 类型
	/// </summary>
	public readonly ESkillBreakGridTypeType Type;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 字体颜色
	/// - 引用GameColors表中的PresetColors
	/// </summary>
	public readonly string FontColor;

	/// <summary>
	/// 连接后随机揭示格数
	/// </summary>
	public readonly int ShowInvisibleCount;

	/// <summary>
	/// 消耗突破次数
	/// </summary>
	public readonly byte CostBreakCount;

	/// <summary>
	/// 额外获得天资数
	/// </summary>
	public readonly byte AddStepNormal;

	/// <summary>
	/// 固定成功率
	/// - 该格成功率固定为指定值
	/// </summary>
	public readonly sbyte FixedSuccessRate;

	/// <summary>
	/// 自身成功率加成
	/// - 百分比加成
	/// </summary>
	public readonly sbyte SuccessRateBonus;

	/// <summary>
	/// 周围成功率加成
	/// </summary>
	public readonly sbyte NeighborSuccessRateBonus;

	/// <summary>
	/// 连接成功周围成功率加成
	/// </summary>
	public readonly sbyte NeighborSuccessRateBonusWhenActive;

	/// <summary>
	/// 周围成功格加自身成功率
	/// </summary>
	public readonly sbyte SucceedNeighborSuccessRateBonus;

	/// <summary>
	/// 突破次数越多加成功率
	/// - 每超过天资上限的一半（向上取整）1次，自己和周围的成功率提高5%
	/// </summary>
	public readonly sbyte BreakCountAboveHalfBonus;

	/// <summary>
	/// 突破次数越少加成功率
	/// - 每低天资上限的一半（向下取整）1次，自己和周围的成功率提高5%
	/// </summary>
	public readonly sbyte BreakCountBelowHalfBonus;

	/// <summary>
	/// 下次成功率加成
	/// - 固定加值
	/// </summary>
	public readonly sbyte NextSuccessRateBonus;

	/// <summary>
	/// 下次突破距离
	/// </summary>
	public readonly sbyte NextStepOffset;

	/// <summary>
	/// 下次可连接到任意同类型突破格
	/// </summary>
	public readonly bool NextStepCanJumpToSame;

	/// <summary>
	/// 连接成功使周边格在失败时重新变成可连接状态
	/// </summary>
	public readonly bool NeighborFailedToCanSelect;

	/// <summary>
	/// 将周边随机如常格变化为当前格类型
	/// </summary>
	public readonly bool RandomNeighborNormalConvertToSameGrid;

	/// <summary>
	/// 将周边所有如常格变化为随机特殊格
	/// </summary>
	public readonly bool AllNeighborNormalConvertToSpecialGrid;

	/// <summary>
	/// 将周边所有特殊格变化为如常格
	/// </summary>
	public readonly bool AllNeighborSpecialConvertToNormalGrid;

	/// <summary>
	/// 消除周边格威力上限值
	/// </summary>
	public readonly bool ClearNeighborMaxPower;

	/// <summary>
	/// 忽略效果威力加值
	/// </summary>
	public readonly bool IgnoreEffectAddMaxPower;

	/// <summary>
	/// 连接成功周围威力上限加值
	/// - 固定加值
	/// </summary>
	public readonly int NeighborAddMaxPowerWhenActive;

	/// <summary>
	/// 周围成功格加自身威力上限
	/// </summary>
	public readonly int SucceedNeighborAddMaxPower;

	/// <summary>
	/// 转移威力并变为连接失败的周边格数量
	/// </summary>
	public readonly int TransferPowerAndConvertToFailedNeighborCount;

	/// <summary>
	/// 健康损失
	/// - 走在该格上健康损失量
	/// </summary>
	public readonly sbyte HealthCost;

	/// <summary>
	/// 生成突破盘时出现权重
	/// </summary>
	public readonly short WeightOnGenerate;

	/// <summary>
	/// 变化突破格时出现权重
	/// </summary>
	public readonly short WeightOnConvert;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">类型</param>
	/// <param name="desc">说明</param>
	/// <param name="fontColor">字体颜色 - 引用GameColors表中的PresetColors</param>
	/// <param name="showInvisibleCount">连接后随机揭示格数</param>
	/// <param name="costBreakCount">消耗突破次数</param>
	/// <param name="addStepNormal">额外获得天资数</param>
	/// <param name="fixedSuccessRate">固定成功率 - 该格成功率固定为指定值</param>
	/// <param name="successRateBonus">自身成功率加成 - 百分比加成</param>
	/// <param name="neighborSuccessRateBonus">周围成功率加成</param>
	/// <param name="neighborSuccessRateBonusWhenActive">连接成功周围成功率加成</param>
	/// <param name="succeedNeighborSuccessRateBonus">周围成功格加自身成功率</param>
	/// <param name="breakCountAboveHalfBonus">突破次数越多加成功率 - 每超过天资上限的一半（向上取整）1次，自己和周围的成功率提高5%</param>
	/// <param name="breakCountBelowHalfBonus">突破次数越少加成功率 - 每低天资上限的一半（向下取整）1次，自己和周围的成功率提高5%</param>
	/// <param name="nextSuccessRateBonus">下次成功率加成 - 固定加值</param>
	/// <param name="nextStepOffset">下次突破距离</param>
	/// <param name="nextStepCanJumpToSame">下次可连接到任意同类型突破格</param>
	/// <param name="neighborFailedToCanSelect">连接成功使周边格在失败时重新变成可连接状态</param>
	/// <param name="randomNeighborNormalConvertToSameGrid">将周边随机如常格变化为当前格类型</param>
	/// <param name="allNeighborNormalConvertToSpecialGrid">将周边所有如常格变化为随机特殊格</param>
	/// <param name="allNeighborSpecialConvertToNormalGrid">将周边所有特殊格变化为如常格</param>
	/// <param name="clearNeighborMaxPower">消除周边格威力上限值</param>
	/// <param name="ignoreEffectAddMaxPower">忽略效果威力加值</param>
	/// <param name="neighborAddMaxPowerWhenActive">连接成功周围威力上限加值 - 固定加值</param>
	/// <param name="succeedNeighborAddMaxPower">周围成功格加自身威力上限</param>
	/// <param name="transferPowerAndConvertToFailedNeighborCount">转移威力并变为连接失败的周边格数量</param>
	/// <param name="healthCost">健康损失 - 走在该格上健康损失量</param>
	/// <param name="weightOnGenerate">生成突破盘时出现权重</param>
	/// <param name="weightOnConvert">变化突破格时出现权重</param>
	public SkillBreakGridTypeItem(sbyte templateId, string name, ESkillBreakGridTypeType type, string desc, string fontColor, int showInvisibleCount, byte costBreakCount, byte addStepNormal, sbyte fixedSuccessRate, sbyte successRateBonus, sbyte neighborSuccessRateBonus, sbyte neighborSuccessRateBonusWhenActive, sbyte succeedNeighborSuccessRateBonus, sbyte breakCountAboveHalfBonus, sbyte breakCountBelowHalfBonus, sbyte nextSuccessRateBonus, sbyte nextStepOffset, bool nextStepCanJumpToSame, bool neighborFailedToCanSelect, bool randomNeighborNormalConvertToSameGrid, bool allNeighborNormalConvertToSpecialGrid, bool allNeighborSpecialConvertToNormalGrid, bool clearNeighborMaxPower, bool ignoreEffectAddMaxPower, int neighborAddMaxPowerWhenActive, int succeedNeighborAddMaxPower, int transferPowerAndConvertToFailedNeighborCount, sbyte healthCost, short weightOnGenerate, short weightOnConvert)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Desc = desc;
		FontColor = fontColor;
		ShowInvisibleCount = showInvisibleCount;
		CostBreakCount = costBreakCount;
		AddStepNormal = addStepNormal;
		FixedSuccessRate = fixedSuccessRate;
		SuccessRateBonus = successRateBonus;
		NeighborSuccessRateBonus = neighborSuccessRateBonus;
		NeighborSuccessRateBonusWhenActive = neighborSuccessRateBonusWhenActive;
		SucceedNeighborSuccessRateBonus = succeedNeighborSuccessRateBonus;
		BreakCountAboveHalfBonus = breakCountAboveHalfBonus;
		BreakCountBelowHalfBonus = breakCountBelowHalfBonus;
		NextSuccessRateBonus = nextSuccessRateBonus;
		NextStepOffset = nextStepOffset;
		NextStepCanJumpToSame = nextStepCanJumpToSame;
		NeighborFailedToCanSelect = neighborFailedToCanSelect;
		RandomNeighborNormalConvertToSameGrid = randomNeighborNormalConvertToSameGrid;
		AllNeighborNormalConvertToSpecialGrid = allNeighborNormalConvertToSpecialGrid;
		AllNeighborSpecialConvertToNormalGrid = allNeighborSpecialConvertToNormalGrid;
		ClearNeighborMaxPower = clearNeighborMaxPower;
		IgnoreEffectAddMaxPower = ignoreEffectAddMaxPower;
		NeighborAddMaxPowerWhenActive = neighborAddMaxPowerWhenActive;
		SucceedNeighborAddMaxPower = succeedNeighborAddMaxPower;
		TransferPowerAndConvertToFailedNeighborCount = transferPowerAndConvertToFailedNeighborCount;
		HealthCost = healthCost;
		WeightOnGenerate = weightOnGenerate;
		WeightOnConvert = weightOnConvert;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakGridTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Type = ESkillBreakGridTypeType.StartPoint;
		Desc = null;
		FontColor = null;
		ShowInvisibleCount = 0;
		CostBreakCount = 1;
		AddStepNormal = 0;
		FixedSuccessRate = -1;
		SuccessRateBonus = 0;
		NeighborSuccessRateBonus = 0;
		NeighborSuccessRateBonusWhenActive = 0;
		SucceedNeighborSuccessRateBonus = 0;
		BreakCountAboveHalfBonus = 0;
		BreakCountBelowHalfBonus = 0;
		NextSuccessRateBonus = 0;
		NextStepOffset = 1;
		NextStepCanJumpToSame = false;
		NeighborFailedToCanSelect = false;
		RandomNeighborNormalConvertToSameGrid = false;
		AllNeighborNormalConvertToSpecialGrid = false;
		AllNeighborSpecialConvertToNormalGrid = false;
		ClearNeighborMaxPower = false;
		IgnoreEffectAddMaxPower = false;
		NeighborAddMaxPowerWhenActive = 0;
		SucceedNeighborAddMaxPower = 0;
		TransferPowerAndConvertToFailedNeighborCount = 0;
		HealthCost = 0;
		WeightOnGenerate = 0;
		WeightOnConvert = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakGridTypeItem(sbyte templateId, SkillBreakGridTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Desc = other.Desc;
		FontColor = other.FontColor;
		ShowInvisibleCount = other.ShowInvisibleCount;
		CostBreakCount = other.CostBreakCount;
		AddStepNormal = other.AddStepNormal;
		FixedSuccessRate = other.FixedSuccessRate;
		SuccessRateBonus = other.SuccessRateBonus;
		NeighborSuccessRateBonus = other.NeighborSuccessRateBonus;
		NeighborSuccessRateBonusWhenActive = other.NeighborSuccessRateBonusWhenActive;
		SucceedNeighborSuccessRateBonus = other.SucceedNeighborSuccessRateBonus;
		BreakCountAboveHalfBonus = other.BreakCountAboveHalfBonus;
		BreakCountBelowHalfBonus = other.BreakCountBelowHalfBonus;
		NextSuccessRateBonus = other.NextSuccessRateBonus;
		NextStepOffset = other.NextStepOffset;
		NextStepCanJumpToSame = other.NextStepCanJumpToSame;
		NeighborFailedToCanSelect = other.NeighborFailedToCanSelect;
		RandomNeighborNormalConvertToSameGrid = other.RandomNeighborNormalConvertToSameGrid;
		AllNeighborNormalConvertToSpecialGrid = other.AllNeighborNormalConvertToSpecialGrid;
		AllNeighborSpecialConvertToNormalGrid = other.AllNeighborSpecialConvertToNormalGrid;
		ClearNeighborMaxPower = other.ClearNeighborMaxPower;
		IgnoreEffectAddMaxPower = other.IgnoreEffectAddMaxPower;
		NeighborAddMaxPowerWhenActive = other.NeighborAddMaxPowerWhenActive;
		SucceedNeighborAddMaxPower = other.SucceedNeighborAddMaxPower;
		TransferPowerAndConvertToFailedNeighborCount = other.TransferPowerAndConvertToFailedNeighborCount;
		HealthCost = other.HealthCost;
		WeightOnGenerate = other.WeightOnGenerate;
		WeightOnConvert = other.WeightOnConvert;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakGridTypeItem Duplicate(int templateId)
	{
		return new SkillBreakGridTypeItem((sbyte)templateId, this);
	}
}
