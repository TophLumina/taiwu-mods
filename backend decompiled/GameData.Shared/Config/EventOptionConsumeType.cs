using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionConsumeType : ConfigData<EventOptionConsumeTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 食材
		/// </summary>
		public const sbyte Food = 0;

		/// <summary>
		/// 木材
		/// </summary>
		public const sbyte Wood = 1;

		/// <summary>
		/// 金铁
		/// </summary>
		public const sbyte Metal = 2;

		/// <summary>
		/// 玉石
		/// </summary>
		public const sbyte Jade = 3;

		/// <summary>
		/// 织物
		/// </summary>
		public const sbyte Fabric = 4;

		/// <summary>
		/// 药材
		/// </summary>
		public const sbyte Herb = 5;

		/// <summary>
		/// 银钱
		/// </summary>
		public const sbyte Money = 6;

		/// <summary>
		/// 威望
		/// </summary>
		public const sbyte Authority = 7;

		/// <summary>
		/// 行动力
		/// </summary>
		public const sbyte ActionPoint = 8;

		/// <summary>
		/// 目标人物所属地区恩义
		/// </summary>
		public const sbyte SpiritualDebt = 9;

		/// <summary>
		/// 太吾当前所在地区恩义
		/// </summary>
		public const sbyte SpiritualDebtInCurrentArea = 10;

		/// <summary>
		/// 历练
		/// </summary>
		public const sbyte Exp = 11;

		/// <summary>
		/// 膂力
		/// </summary>
		public const sbyte Strength = 12;

		/// <summary>
		/// 灵敏
		/// </summary>
		public const sbyte Dexterity = 13;

		/// <summary>
		/// 定力
		/// </summary>
		public const sbyte Concentration = 14;

		/// <summary>
		/// 体质
		/// </summary>
		public const sbyte Vitality = 15;

		/// <summary>
		/// 根骨
		/// </summary>
		public const sbyte Energy = 16;

		/// <summary>
		/// 悟性
		/// </summary>
		public const sbyte Intelligence = 17;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 食材
		/// </summary>
		public static EventOptionConsumeTypeItem Food => Instance[(sbyte)0];

		/// <summary>
		/// 木材
		/// </summary>
		public static EventOptionConsumeTypeItem Wood => Instance[(sbyte)1];

		/// <summary>
		/// 金铁
		/// </summary>
		public static EventOptionConsumeTypeItem Metal => Instance[(sbyte)2];

		/// <summary>
		/// 玉石
		/// </summary>
		public static EventOptionConsumeTypeItem Jade => Instance[(sbyte)3];

		/// <summary>
		/// 织物
		/// </summary>
		public static EventOptionConsumeTypeItem Fabric => Instance[(sbyte)4];

		/// <summary>
		/// 药材
		/// </summary>
		public static EventOptionConsumeTypeItem Herb => Instance[(sbyte)5];

		/// <summary>
		/// 银钱
		/// </summary>
		public static EventOptionConsumeTypeItem Money => Instance[(sbyte)6];

		/// <summary>
		/// 威望
		/// </summary>
		public static EventOptionConsumeTypeItem Authority => Instance[(sbyte)7];

		/// <summary>
		/// 行动力
		/// </summary>
		public static EventOptionConsumeTypeItem ActionPoint => Instance[(sbyte)8];

		/// <summary>
		/// 目标人物所属地区恩义
		/// </summary>
		public static EventOptionConsumeTypeItem SpiritualDebt => Instance[(sbyte)9];

		/// <summary>
		/// 太吾当前所在地区恩义
		/// </summary>
		public static EventOptionConsumeTypeItem SpiritualDebtInCurrentArea => Instance[(sbyte)10];

		/// <summary>
		/// 历练
		/// </summary>
		public static EventOptionConsumeTypeItem Exp => Instance[(sbyte)11];

		/// <summary>
		/// 膂力
		/// </summary>
		public static EventOptionConsumeTypeItem Strength => Instance[(sbyte)12];

		/// <summary>
		/// 灵敏
		/// </summary>
		public static EventOptionConsumeTypeItem Dexterity => Instance[(sbyte)13];

		/// <summary>
		/// 定力
		/// </summary>
		public static EventOptionConsumeTypeItem Concentration => Instance[(sbyte)14];

		/// <summary>
		/// 体质
		/// </summary>
		public static EventOptionConsumeTypeItem Vitality => Instance[(sbyte)15];

		/// <summary>
		/// 根骨
		/// </summary>
		public static EventOptionConsumeTypeItem Energy => Instance[(sbyte)16];

		/// <summary>
		/// 悟性
		/// </summary>
		public static EventOptionConsumeTypeItem Intelligence => Instance[(sbyte)17];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventOptionConsumeType Instance = new EventOptionConsumeType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new EventOptionConsumeTypeItem(0));
		_dataArray.Add(new EventOptionConsumeTypeItem(1));
		_dataArray.Add(new EventOptionConsumeTypeItem(2));
		_dataArray.Add(new EventOptionConsumeTypeItem(3));
		_dataArray.Add(new EventOptionConsumeTypeItem(4));
		_dataArray.Add(new EventOptionConsumeTypeItem(5));
		_dataArray.Add(new EventOptionConsumeTypeItem(6));
		_dataArray.Add(new EventOptionConsumeTypeItem(7));
		_dataArray.Add(new EventOptionConsumeTypeItem(8));
		_dataArray.Add(new EventOptionConsumeTypeItem(9));
		_dataArray.Add(new EventOptionConsumeTypeItem(10));
		_dataArray.Add(new EventOptionConsumeTypeItem(11));
		_dataArray.Add(new EventOptionConsumeTypeItem(12));
		_dataArray.Add(new EventOptionConsumeTypeItem(13));
		_dataArray.Add(new EventOptionConsumeTypeItem(14));
		_dataArray.Add(new EventOptionConsumeTypeItem(15));
		_dataArray.Add(new EventOptionConsumeTypeItem(16));
		_dataArray.Add(new EventOptionConsumeTypeItem(17));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventOptionConsumeTypeItem>(18);
		CreateItems0();
	}
}
