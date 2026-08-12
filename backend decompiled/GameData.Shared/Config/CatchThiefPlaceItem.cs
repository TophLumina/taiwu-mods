using System;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefPlaceItem : ConfigItem<CatchThiefPlaceItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 出现概率
	/// </summary>
	public readonly sbyte Rate;

	/// <summary>
	/// 捕捉等级权重
	/// - 第一次索引对应捕捉次数，第二次索引对应贼人(货物)等级，值为权重
	/// </summary>
	public readonly int[][] LevelWeights;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 捕捉动画底图
	/// </summary>
	public readonly string CatchAniBack;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="rate">出现概率</param>
	/// <param name="levelWeights">捕捉等级权重 - 第一次索引对应捕捉次数，第二次索引对应贼人(货物)等级，值为权重</param>
	/// <param name="icon">图标</param>
	/// <param name="catchAniBack">捕捉动画底图</param>
	public CatchThiefPlaceItem(sbyte templateId, sbyte rate, int[][] levelWeights, string icon, string catchAniBack)
	{
		TemplateId = templateId;
		Rate = rate;
		LevelWeights = levelWeights;
		Icon = icon;
		CatchAniBack = catchAniBack;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CatchThiefPlaceItem()
	{
		TemplateId = 0;
		Rate = 0;
		LevelWeights = null;
		Icon = null;
		CatchAniBack = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CatchThiefPlaceItem(sbyte templateId, CatchThiefPlaceItem other)
	{
		TemplateId = templateId;
		Rate = other.Rate;
		LevelWeights = other.LevelWeights;
		Icon = other.Icon;
		CatchAniBack = other.CatchAniBack;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CatchThiefPlaceItem Duplicate(int templateId)
	{
		return new CatchThiefPlaceItem((sbyte)templateId, this);
	}
}
