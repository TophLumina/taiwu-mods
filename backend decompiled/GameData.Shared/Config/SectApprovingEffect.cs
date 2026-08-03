using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectApprovingEffect : ConfigData<SectApprovingEffectItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 以禅入武
		/// </summary>
		public const sbyte Shaolin = 0;

		/// <summary>
		/// 真传正法
		/// </summary>
		public const sbyte Emei = 1;

		/// <summary>
		/// 医武同源
		/// </summary>
		public const sbyte Baihua = 2;

		/// <summary>
		/// 道法自然
		/// </summary>
		public const sbyte Wudang = 3;

		/// <summary>
		/// 正大光明
		/// </summary>
		public const sbyte Yuanshan = 4;

		/// <summary>
		/// 蛮修横练
		/// </summary>
		public const sbyte Shixiang = 5;

		/// <summary>
		/// 字字玄玄
		/// </summary>
		public const sbyte Ranshan = 6;

		/// <summary>
		/// 仙姿玉色
		/// </summary>
		public const sbyte Xuannv = 7;

		/// <summary>
		/// 巧夺天工
		/// </summary>
		public const sbyte Zhujian = 8;

		/// <summary>
		/// 厚积薄发
		/// </summary>
		public const sbyte Kongsang = 9;

		/// <summary>
		/// 明王秘咒
		/// </summary>
		public const sbyte Jingang = 10;

		/// <summary>
		/// 毒蛊通魂
		/// </summary>
		public const sbyte Wuxian = 11;

		/// <summary>
		/// 另辟蹊径
		/// </summary>
		public const sbyte Jieqing = 12;

		/// <summary>
		/// 易学难精
		/// </summary>
		public const sbyte Fulong = 13;

		/// <summary>
		/// 邪诡恶毒
		/// </summary>
		public const sbyte Xuehou = 14;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 以禅入武
		/// </summary>
		public static SectApprovingEffectItem Shaolin => Instance[(sbyte)0];

		/// <summary>
		/// 真传正法
		/// </summary>
		public static SectApprovingEffectItem Emei => Instance[(sbyte)1];

		/// <summary>
		/// 医武同源
		/// </summary>
		public static SectApprovingEffectItem Baihua => Instance[(sbyte)2];

		/// <summary>
		/// 道法自然
		/// </summary>
		public static SectApprovingEffectItem Wudang => Instance[(sbyte)3];

		/// <summary>
		/// 正大光明
		/// </summary>
		public static SectApprovingEffectItem Yuanshan => Instance[(sbyte)4];

		/// <summary>
		/// 蛮修横练
		/// </summary>
		public static SectApprovingEffectItem Shixiang => Instance[(sbyte)5];

		/// <summary>
		/// 字字玄玄
		/// </summary>
		public static SectApprovingEffectItem Ranshan => Instance[(sbyte)6];

		/// <summary>
		/// 仙姿玉色
		/// </summary>
		public static SectApprovingEffectItem Xuannv => Instance[(sbyte)7];

		/// <summary>
		/// 巧夺天工
		/// </summary>
		public static SectApprovingEffectItem Zhujian => Instance[(sbyte)8];

		/// <summary>
		/// 厚积薄发
		/// </summary>
		public static SectApprovingEffectItem Kongsang => Instance[(sbyte)9];

		/// <summary>
		/// 明王秘咒
		/// </summary>
		public static SectApprovingEffectItem Jingang => Instance[(sbyte)10];

		/// <summary>
		/// 毒蛊通魂
		/// </summary>
		public static SectApprovingEffectItem Wuxian => Instance[(sbyte)11];

		/// <summary>
		/// 另辟蹊径
		/// </summary>
		public static SectApprovingEffectItem Jieqing => Instance[(sbyte)12];

		/// <summary>
		/// 易学难精
		/// </summary>
		public static SectApprovingEffectItem Fulong => Instance[(sbyte)13];

		/// <summary>
		/// 邪诡恶毒
		/// </summary>
		public static SectApprovingEffectItem Xuehou => Instance[(sbyte)14];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SectApprovingEffect Instance = new SectApprovingEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "RequirementSubstitutions", "TemplateId", "Icon" };

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
		_dataArray.Add(new SectApprovingEffectItem(0, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_0"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_0"), "combatskilltree_icon_0_1", new List<sbyte> { 13 }, new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(1, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_1"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_1"), "combatskilltree_icon_0_2", new List<sbyte>(), new short[2] { 150, 50 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(2, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_2"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_2"), "combatskilltree_icon_0_3", new List<sbyte> { 8 }, new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(3, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_3"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_3"), "combatskilltree_icon_0_4", new List<sbyte> { 12 }, new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(4, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_4"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_4"), "combatskilltree_icon_0_5", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 150, 150, 100, 50, 50 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(5, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_5"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_5"), "combatskilltree_icon_0_6", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 50, 50, 50, 50, 50 }, new short[5] { 50, 50, 50, 50, 50 }, 500, 500));
		_dataArray.Add(new SectApprovingEffectItem(6, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_6"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_6"), "combatskilltree_icon_0_7", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 200, 200, 200, 200, 200 }, new short[5] { 200, 200, 200, 200, 200 }, 20, 20));
		_dataArray.Add(new SectApprovingEffectItem(7, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_7"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_7"), "combatskilltree_icon_0_8", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 50, 50, 50, 50, 50 }, new short[5] { 150, 150, 150, 150, 150 }, 20, 200));
		_dataArray.Add(new SectApprovingEffectItem(8, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_8"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_8"), "combatskilltree_icon_0_9", new List<sbyte> { 6, 7, 10, 11 }, new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(9, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_9"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_9"), "combatskilltree_icon_0_10", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 50, 75, 100, 125, 150 }, new short[5] { 50, 75, 100, 125, 150 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(10, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_10"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_10"), "combatskilltree_icon_0_11", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 150, 150, 150, 150, 150 }, new short[5] { 50, 50, 50, 50, 50 }, 200, 20));
		_dataArray.Add(new SectApprovingEffectItem(11, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_11"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_11"), "combatskilltree_icon_0_12", new List<sbyte> { 9 }, new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(12, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_12"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_12"), "combatskilltree_icon_0_13", new List<sbyte>(), new short[2] { 50, 150 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(13, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_13"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_13"), "combatskilltree_icon_0_14", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 150, 125, 100, 75, 50 }, new short[5] { 150, 125, 100, 75, 50 }, 100, 100));
		_dataArray.Add(new SectApprovingEffectItem(14, LocalStringManager.GetConfig("SectApprovingEffect_language", "Name_14"), LocalStringManager.GetConfig("SectApprovingEffect_language", "Desc_14"), "combatskilltree_icon_0_15", new List<sbyte>(), new short[2] { 100, 100 }, new short[5] { 50, 50, 100, 150, 150 }, new short[5] { 100, 100, 100, 100, 100 }, new short[5] { 100, 100, 100, 100, 100 }, 100, 100));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SectApprovingEffectItem>(15);
		CreateItems0();
	}
}
