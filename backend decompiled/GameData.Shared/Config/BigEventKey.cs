using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BigEventKey : ConfigData<BigEventKeyItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 莫女衣被拔除
		/// </summary>
		public const short MonvRemoved = 0;

		/// <summary>
		/// 伏邪铁被拔除
		/// </summary>
		public const short DayueYaochangRemoved = 1;

		/// <summary>
		/// 大玄凝被拔除
		/// </summary>
		public const short JiuhanRemoved = 2;

		/// <summary>
		/// 凤凰茧被拔除
		/// </summary>
		public const short JinHuangerRemoved = 3;

		/// <summary>
		/// 焚神炼被拔除
		/// </summary>
		public const short YiYihouRemoved = 4;

		/// <summary>
		/// 解龙魄被拔除
		/// </summary>
		public const short WeiQiRemoved = 5;

		/// <summary>
		/// 溶尘隐被拔除
		/// </summary>
		public const short YixiangRemoved = 6;

		/// <summary>
		/// 囚魔木被拔除
		/// </summary>
		public const short XuefengRemoved = 7;

		/// <summary>
		/// 鬼神霞被拔除
		/// </summary>
		public const short ShuFangRemoved = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 莫女衣被拔除
		/// </summary>
		public static BigEventKeyItem MonvRemoved => Instance[(short)0];

		/// <summary>
		/// 伏邪铁被拔除
		/// </summary>
		public static BigEventKeyItem DayueYaochangRemoved => Instance[(short)1];

		/// <summary>
		/// 大玄凝被拔除
		/// </summary>
		public static BigEventKeyItem JiuhanRemoved => Instance[(short)2];

		/// <summary>
		/// 凤凰茧被拔除
		/// </summary>
		public static BigEventKeyItem JinHuangerRemoved => Instance[(short)3];

		/// <summary>
		/// 焚神炼被拔除
		/// </summary>
		public static BigEventKeyItem YiYihouRemoved => Instance[(short)4];

		/// <summary>
		/// 解龙魄被拔除
		/// </summary>
		public static BigEventKeyItem WeiQiRemoved => Instance[(short)5];

		/// <summary>
		/// 溶尘隐被拔除
		/// </summary>
		public static BigEventKeyItem YixiangRemoved => Instance[(short)6];

		/// <summary>
		/// 囚魔木被拔除
		/// </summary>
		public static BigEventKeyItem XuefengRemoved => Instance[(short)7];

		/// <summary>
		/// 鬼神霞被拔除
		/// </summary>
		public static BigEventKeyItem ShuFangRemoved => Instance[(short)8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
