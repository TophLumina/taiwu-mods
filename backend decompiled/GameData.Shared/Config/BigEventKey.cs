using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BigEventKey : ConfigData<BigEventKeyItem, short>
{
	public static class DefKey
	{
		public const short MonvRemoved = 0;

		public const short DayueYaochangRemoved = 1;

		public const short JiuhanRemoved = 2;

		public const short JinHuangerRemoved = 3;

		public const short YiYihouRemoved = 4;

		public const short WeiQiRemoved = 5;

		public const short YixiangRemoved = 6;

		public const short XuefengRemoved = 7;

		public const short ShuFangRemoved = 8;
	}

	public static class DefValue
	{
		public static BigEventKeyItem MonvRemoved => Instance[(short)0];

		public static BigEventKeyItem DayueYaochangRemoved => Instance[(short)1];

		public static BigEventKeyItem JiuhanRemoved => Instance[(short)2];

		public static BigEventKeyItem JinHuangerRemoved => Instance[(short)3];

		public static BigEventKeyItem YiYihouRemoved => Instance[(short)4];

		public static BigEventKeyItem WeiQiRemoved => Instance[(short)5];

		public static BigEventKeyItem YixiangRemoved => Instance[(short)6];

		public static BigEventKeyItem XuefengRemoved => Instance[(short)7];

		public static BigEventKeyItem ShuFangRemoved => Instance[(short)8];
	}

	public static BigEventKey Instance = new BigEventKey();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new BigEventKeyItem(0));
		_dataArray.Add(new BigEventKeyItem(1));
		_dataArray.Add(new BigEventKeyItem(2));
		_dataArray.Add(new BigEventKeyItem(3));
		_dataArray.Add(new BigEventKeyItem(4));
		_dataArray.Add(new BigEventKeyItem(5));
		_dataArray.Add(new BigEventKeyItem(6));
		_dataArray.Add(new BigEventKeyItem(7));
		_dataArray.Add(new BigEventKeyItem(8));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BigEventKeyItem>(9);
		CreateItems0();
	}
}
