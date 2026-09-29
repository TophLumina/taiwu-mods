using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WeatherItem : ConfigItem<WeatherItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly List<sbyte> Season;

	public readonly short Weight;

	public readonly string Particle;

	public readonly float[] CloudLayers;

	public readonly int CloudCount;

	public readonly int CloudSpeed;

	public readonly EWeatherCloudType CloudType;

	public readonly EWeatherType Type;

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

	public override WeatherItem Duplicate(int templateId)
	{
		return new WeatherItem((sbyte)templateId, this);
	}
}
