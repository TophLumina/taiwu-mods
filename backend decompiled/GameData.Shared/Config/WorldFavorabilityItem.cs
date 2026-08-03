using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldFavorabilityItem : ConfigItem<WorldFavorabilityItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 影响因子
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] InfluenceFactors;

	/// <summary>
	/// 使用倒数计算负数好感变化量
	/// - 为TRUE时，如果好感变化为负数，使用10000/表中数值，而非表中数值，计算好感度变化
	/// - 
	/// - 以初见好感度 - 选项一影响因子为例，表中变化值为200
	/// - 此处为TRUE，于是好感增加时按200%增加好感，好感减少时按10000/200 = 50%减少好感
	/// - 如果此处为FALSE，则好感增加时按200%增加好感，好感减少时按200%减少好感
	/// </summary>
	public readonly bool NegativeUsingReciprocal;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="influenceFactors">影响因子 - 该列由公式生成，禁止手动填写</param>
	/// <param name="negativeUsingReciprocal">使用倒数计算负数好感变化量 - 为TRUE时，如果好感变化为负数，使用10000/表中数值，而非表中数值，计算好感度变化  以初见好感度 - 选项一影响因子为例，表中变化值为200 此处为TRUE，于是好感增加时按200%增加好感，好感减少时按10000/200 = 50%减少好感 如果此处为FALSE，则好感增加时按200%增加好感，好感减少时按200%减少好感</param>
	public WorldFavorabilityItem(short templateId, short[] influenceFactors, bool negativeUsingReciprocal)
	{
		TemplateId = templateId;
		InfluenceFactors = influenceFactors;
		NegativeUsingReciprocal = negativeUsingReciprocal;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WorldFavorabilityItem()
	{
		TemplateId = 0;
		InfluenceFactors = new short[0];
		NegativeUsingReciprocal = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WorldFavorabilityItem(short templateId, WorldFavorabilityItem other)
	{
		TemplateId = templateId;
		InfluenceFactors = other.InfluenceFactors;
		NegativeUsingReciprocal = other.NegativeUsingReciprocal;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WorldFavorabilityItem Duplicate(int templateId)
	{
		return new WorldFavorabilityItem((short)templateId, this);
	}
}
