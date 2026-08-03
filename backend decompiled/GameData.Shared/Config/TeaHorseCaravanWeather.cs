using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanWeather : ConfigData<TeaHorseCaravanWeatherItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TeaHorseCaravanWeather Instance = new TeaHorseCaravanWeather();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Icon" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new TeaHorseCaravanWeatherItem(0, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_0"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_0"), "ui9_icon_weather_5", new List<sbyte>
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11
		}, new List<sbyte> { 0, 1, 2, 3, 4, 5 }, 0, 0, 100));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(1, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_1"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_1"), "ui9_icon_weather_2", new List<sbyte> { 0, 1, 11 }, new List<sbyte> { 1, 2, 3 }, 5, 0, 10));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(2, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_2"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_2"), "ui9_icon_weather_6", new List<sbyte> { 8, 9, 10 }, new List<sbyte> { 3 }, 5, 15, 10));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(3, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_3"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_3"), "ui9_icon_weather_4", new List<sbyte> { 5, 6, 7 }, new List<sbyte> { 0, 1, 3, 5 }, 10, 0, 20));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(4, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_4"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_4"), "ui9_icon_weather_3", new List<sbyte> { 2, 3, 4, 5, 6, 7 }, new List<sbyte> { 1, 2, 3, 4, 5 }, 10, 10, 10));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(5, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_5"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_5"), "ui9_icon_weather_9", new List<sbyte>
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11
		}, new List<sbyte> { 0, 1, 2, 3, 4, 5 }, 0, 0, 20));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(6, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_6"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_6"), "ui9_icon_weather_8", new List<sbyte> { 0, 1, 11 }, new List<sbyte> { 0, 1, 2, 3, 4, 5 }, 5, 0, 20));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(7, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_7"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_7"), "ui9_icon_weather_0", new List<sbyte> { 0, 1, 11 }, new List<sbyte> { 0, 1, 2, 3, 4, 5 }, 10, 20, 10));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(8, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_8"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_8"), "ui9_icon_weather_1", new List<sbyte> { 0, 1, 8, 9, 10, 11 }, new List<sbyte> { 0, 3, 5 }, 0, 5, 20));
		_dataArray.Add(new TeaHorseCaravanWeatherItem(9, LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Name_9"), LocalStringManager.GetConfig("TeaHorseCaravanWeather_language", "Desc_9"), "ui9_icon_weather_7", new List<sbyte> { 2, 3, 4 }, new List<sbyte> { 3, 4 }, 0, 5, 10));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TeaHorseCaravanWeatherItem>(10);
		CreateItems0();
	}
}
