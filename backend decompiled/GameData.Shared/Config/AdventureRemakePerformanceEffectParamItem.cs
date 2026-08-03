using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffectParamItem : ConfigItem<AdventureRemakePerformanceEffectParamItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EAdventureRemakePerformanceEffectParamType Type;

	/// <summary>
	/// 加载路径
	/// </summary>
	public readonly string LoadName;

	/// <summary>
	/// 数量比例
	/// - 总数量指定比例的随机地格显示特效，外层地格特效专属参数
	/// </summary>
	public readonly sbyte PercentageCount;

	/// <summary>
	/// 数量范围
	/// </summary>
	public readonly sbyte[] CountRange;

	/// <summary>
	/// 尺寸
	/// </summary>
	public readonly int Scale;

	/// <summary>
	/// 模拟速度
	/// - 默认-1表示不使用配置表参数赋值
	/// </summary>
	public readonly float ParticleSimulationSpeed;

	/// <summary>
	/// 延迟播放参数
	/// - 默认-1表示不使用配置表参数赋值
	/// </summary>
	public readonly float ParticleStartDelay;

	/// <summary>
	/// 延迟播放参数-随机
	/// - 如果配置了此列，将覆盖ParticleStartDelay列
	/// </summary>
	public readonly float[] ParticleStartDelayRandom;

	/// <summary>
	/// 速度参数-随机
	/// </summary>
	public readonly float[] ParticleStartSpeedRandom;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类型</param>
	/// <param name="loadName">加载路径</param>
	/// <param name="percentageCount">数量比例 - 总数量指定比例的随机地格显示特效，外层地格特效专属参数</param>
	/// <param name="countRange">数量范围</param>
	/// <param name="scale">尺寸</param>
	/// <param name="particleSimulationSpeed">模拟速度 - 默认-1表示不使用配置表参数赋值</param>
	/// <param name="particleStartDelay">延迟播放参数 - 默认-1表示不使用配置表参数赋值</param>
	/// <param name="particleStartDelayRandom">延迟播放参数-随机 - 如果配置了此列，将覆盖ParticleStartDelay列</param>
	/// <param name="particleStartSpeedRandom">速度参数-随机</param>
	public AdventureRemakePerformanceEffectParamItem(short templateId, EAdventureRemakePerformanceEffectParamType type, string loadName, sbyte percentageCount, sbyte[] countRange, int scale, float particleSimulationSpeed, float particleStartDelay, float[] particleStartDelayRandom, float[] particleStartSpeedRandom)
	{
		TemplateId = templateId;
		Type = type;
		LoadName = loadName;
		PercentageCount = percentageCount;
		CountRange = countRange;
		Scale = scale;
		ParticleSimulationSpeed = particleSimulationSpeed;
		ParticleStartDelay = particleStartDelay;
		ParticleStartDelayRandom = particleStartDelayRandom;
		ParticleStartSpeedRandom = particleStartSpeedRandom;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureRemakePerformanceEffectParamItem()
	{
		TemplateId = 0;
		Type = EAdventureRemakePerformanceEffectParamType.OuterBlock;
		LoadName = null;
		PercentageCount = -1;
		CountRange = null;
		Scale = 1;
		ParticleSimulationSpeed = -1f;
		ParticleStartDelay = -1f;
		ParticleStartDelayRandom = null;
		ParticleStartSpeedRandom = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureRemakePerformanceEffectParamItem(short templateId, AdventureRemakePerformanceEffectParamItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		LoadName = other.LoadName;
		PercentageCount = other.PercentageCount;
		CountRange = other.CountRange;
		Scale = other.Scale;
		ParticleSimulationSpeed = other.ParticleSimulationSpeed;
		ParticleStartDelay = other.ParticleStartDelay;
		ParticleStartDelayRandom = other.ParticleStartDelayRandom;
		ParticleStartSpeedRandom = other.ParticleStartSpeedRandom;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureRemakePerformanceEffectParamItem Duplicate(int templateId)
	{
		return new AdventureRemakePerformanceEffectParamItem((short)templateId, this);
	}
}
