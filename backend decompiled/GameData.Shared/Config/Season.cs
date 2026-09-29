using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Season : ConfigData<SeasonItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Spring = 0;

		public const sbyte Summer = 1;

		public const sbyte Autumn = 2;

		public const sbyte Winter = 3;
	}

	public static class DefValue
	{
		public static SeasonItem Spring => Instance[(sbyte)0];

		public static SeasonItem Summer => Instance[(sbyte)1];

		public static SeasonItem Autumn => Instance[(sbyte)2];

		public static SeasonItem Winter => Instance[(sbyte)3];
	}

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
