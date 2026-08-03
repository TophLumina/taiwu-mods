using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Season : ConfigData<SeasonItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 春
		/// </summary>
		public const sbyte Spring = 0;

		/// <summary>
		/// 夏
		/// </summary>
		public const sbyte Summer = 1;

		/// <summary>
		/// 秋
		/// </summary>
		public const sbyte Autumn = 2;

		/// <summary>
		/// 冬
		/// </summary>
		public const sbyte Winter = 3;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 春
		/// </summary>
		public static SeasonItem Spring => Instance[(sbyte)0];

		/// <summary>
		/// 夏
		/// </summary>
		public static SeasonItem Summer => Instance[(sbyte)1];

		/// <summary>
		/// 秋
		/// </summary>
		public static SeasonItem Autumn => Instance[(sbyte)2];

		/// <summary>
		/// 冬
		/// </summary>
		public static SeasonItem Winter => Instance[(sbyte)3];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Season Instance = new Season();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Months", "TemplateId" };

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
		_dataArray.Add(new SeasonItem(0, new List<sbyte> { 1, 2, 3 }));
		_dataArray.Add(new SeasonItem(1, new List<sbyte> { 4, 5, 6 }));
		_dataArray.Add(new SeasonItem(2, new List<sbyte> { 7, 8, 9 }));
		_dataArray.Add(new SeasonItem(3, new List<sbyte> { 10, 11, 0 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SeasonItem>(4);
		CreateItems0();
	}
}
