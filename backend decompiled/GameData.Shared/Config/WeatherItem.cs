using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WeatherItem : ConfigItem<WeatherItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 季节
	/// </summary>
	public readonly List<sbyte> Season;

	/// <summary>
	/// 权重
	/// </summary>
	public readonly short Weight;

	/// <summary>
	/// 特效名
	/// </summary>
	public readonly string Particle;

	/// <summary>
	/// 云彩层级
	/// - 参考坐标系：相机最近到最远，分别对应 1~4
	/// </summary>
	public readonly float[] CloudLayers;

	/// <summary>
	/// 云彩数量
	/// - 100 为标准数量
	/// </summary>
	public readonly int CloudCount;

	/// <summary>
	/// 云彩速度
	/// - 100 为标准速度
	/// </summary>
	public readonly int CloudSpeed;

	/// <summary>
	/// 云彩类型
	/// - 决定所用的素材
	/// </summary>
	public readonly EWeatherCloudType CloudType;

	/// <summary>
	/// 显示类型
	/// </summary>
	public readonly EWeatherType Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="season">季节</param>
	/// <param name="weight">权重</param>
	/// <param name="particle">特效名</param>
	/// <param name="cloudLayers">云彩层级 - 参考坐标系：相机最近到最远，分别对应 1~4</param>
	/// <param name="cloudCount">云彩数量 - 100 为标准数量</param>
	/// <param name="cloudSpeed">云彩速度 - 100 为标准速度</param>
	/// <param name="cloudType">云彩类型 - 决定所用的素材</param>
	/// <param name="type">显示类型</param>
	public WeatherItem(sbyte templateId, List<sbyte> season, short weight, string particle, float[] cloudLayers, int cloudCount, int cloudSpeed, EWeatherCloudType cloudType, EWeatherType type)
	{
		TemplateId = templateId;
		Season = season;
		Weight = weight;
		Particle = particle;
		CloudLayers = cloudLayers;
		CloudCount = cloudCount;
		CloudSpeed = cloudSpeed;
		CloudType = cloudType;
		Type = type;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WeatherItem()
	{
		TemplateId = 0;
		Season = new List<sbyte>();
		Weight = 0;
		Particle = null;
		CloudLayers = null;
		CloudCount = 100;
		CloudSpeed = 100;
		CloudType = EWeatherCloudType.Spring;
		Type = EWeatherType.Normal;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WeatherItem(sbyte templateId, WeatherItem other)
	{
		TemplateId = templateId;
		Season = other.Season;
		Weight = other.Weight;
		Particle = other.Particle;
		CloudLayers = other.CloudLayers;
		CloudCount = other.CloudCount;
		CloudSpeed = other.CloudSpeed;
		CloudType = other.CloudType;
		Type = other.Type;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WeatherItem Duplicate(int templateId)
	{
		return new WeatherItem((sbyte)templateId, this);
	}
}
