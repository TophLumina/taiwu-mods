using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Weather : ConfigData<WeatherItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte DreamBack = 18;

		public const sbyte DarkAshLow = 19;

		public const sbyte DarkAshMid = 20;

		public const sbyte DarkAshHigh = 21;
	}

	public static class DefValue
	{
		public static WeatherItem DreamBack => Instance[(sbyte)18];

		public static WeatherItem DarkAshLow => Instance[(sbyte)19];

		public static WeatherItem DarkAshMid => Instance[(sbyte)20];

		public static WeatherItem DarkAshHigh => Instance[(sbyte)21];
	}

	public static Weather Instance = new Weather();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Season", "TemplateId", "Particle", "CloudLayers" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new WeatherItem(0, new List<sbyte> { 0, 1, 2, 3 }, 4, null, null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(1, new List<sbyte> { 0 }, 5, null, new float[6] { 2f, 2.07f, 2.14f, 2.65f, 2.72f, 2.8f }, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(2, new List<sbyte> { 0 }, 1, "eff_siji_chuntian_xiaoxue", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(3, new List<sbyte> { 0 }, 3, "eff_siji_chuntian_xiaoyu", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(4, new List<sbyte> { 0 }, 2, "eff_siji_chuntian_zhongwu", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(5, new List<sbyte> { 1 }, 1, "eff_siji_xiatian_wuyunleiyu", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(6, new List<sbyte> { 1 }, 3, "eff_siji_xiatian_caihong", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(7, new List<sbyte> { 1 }, 2, "eff_siji_xiatian_guangxian", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(8, new List<sbyte> { 2 }, 3, "eff_siji_qiutian_feng", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(9, new List<sbyte> { 2 }, 1, "eff_siji_qiutian_huichen", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(10, new List<sbyte> { 2 }, 2, "eff_siji_qiutian_luoye", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(11, new List<sbyte> { 3 }, 1, "eff_siji_dongtian_daxue", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(12, new List<sbyte> { 3 }, 3, "eff_siji_dongtian_xiaoxue", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(13, new List<sbyte> { 3 }, 2, "eff_siji_dongtian_xiaowu", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(14, new List<sbyte> { 1 }, 5, null, new float[6] { 0.5f, 0.58f, 0.65f, 0.72f, 0.8f, 0.9f }, 200, 50, EWeatherCloudType.Summer, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(15, new List<sbyte> { 2 }, 5, null, new float[12]
		{
			1f, 1.07f, 1.14f, 1.21f, 1.29f, 1.36f, 1.43f, 1.5f, 1.58f, 1.65f,
			1.72f, 1.8f
		}, 200, 200, EWeatherCloudType.Autumn, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(16, new List<sbyte> { 3 }, 5, null, new float[3] { 0.5f, 0.6f, 1f }, 50, 50, EWeatherCloudType.Winter, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(17, new List<sbyte>(), 0, "eff_tianqi_shengu", new float[12]
		{
			1f, 1.07f, 1.14f, 1.21f, 1.29f, 1.36f, 1.43f, 1.5f, 1.58f, 1.65f,
			1.72f, 1.8f
		}, 200, 200, EWeatherCloudType.Autumn, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(18, new List<sbyte>(), 0, "eff_tianqi_menghui", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Screen));
		_dataArray.Add(new WeatherItem(19, new List<sbyte>(), 0, "eff_tianqi_xuanhui1", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(20, new List<sbyte>(), 0, "eff_tianqi_xuanhui2", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(21, new List<sbyte>(), 0, "eff_tianqi_xuanhui3", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
		_dataArray.Add(new WeatherItem(22, new List<sbyte>(), 0, "eff_siji_xiatian_shandianheise", null, 100, 100, EWeatherCloudType.Spring, EWeatherType.Normal));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WeatherItem>(23);
		CreateItems0();
	}
}
