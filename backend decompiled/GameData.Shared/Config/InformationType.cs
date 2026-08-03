using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InformationType : ConfigData<InformationTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 地方
		/// </summary>
		public const sbyte Area = 0;

		/// <summary>
		/// 门派
		/// </summary>
		public const sbyte Sect = 1;

		/// <summary>
		/// 技艺
		/// </summary>
		public const sbyte LifeSkill = 2;

		/// <summary>
		/// 西域
		/// </summary>
		public const sbyte Western = 3;

		/// <summary>
		/// 名胜
		/// </summary>
		public const sbyte Scenic = 4;

		/// <summary>
		/// 剑冢
		/// </summary>
		public const sbyte SwordTomb = 5;

		/// <summary>
		/// 志向
		/// </summary>
		public const sbyte Profession = 6;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 地方
		/// </summary>
		public static InformationTypeItem Area => Instance[(sbyte)0];

		/// <summary>
		/// 门派
		/// </summary>
		public static InformationTypeItem Sect => Instance[(sbyte)1];

		/// <summary>
		/// 技艺
		/// </summary>
		public static InformationTypeItem LifeSkill => Instance[(sbyte)2];

		/// <summary>
		/// 西域
		/// </summary>
		public static InformationTypeItem Western => Instance[(sbyte)3];

		/// <summary>
		/// 名胜
		/// </summary>
		public static InformationTypeItem Scenic => Instance[(sbyte)4];

		/// <summary>
		/// 剑冢
		/// </summary>
		public static InformationTypeItem SwordTomb => Instance[(sbyte)5];

		/// <summary>
		/// 志向
		/// </summary>
		public static InformationTypeItem Profession => Instance[(sbyte)6];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static InformationType Instance = new InformationType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "DescGain", "DescEffect", "DescEffectWay", "Title", "TemplateId" };

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
		_dataArray.Add(new InformationTypeItem(0, LocalStringManager.GetConfig("InformationType_language", "Name_0"), LocalStringManager.GetConfig("InformationType_language", "Desc_0"), LocalStringManager.GetConfig("InformationType_language", "DescGain_0"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_0"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_0"), LocalStringManager.GetConfig("InformationType_language", "Title_0"), inUse: true));
		_dataArray.Add(new InformationTypeItem(1, LocalStringManager.GetConfig("InformationType_language", "Name_1"), LocalStringManager.GetConfig("InformationType_language", "Desc_1"), LocalStringManager.GetConfig("InformationType_language", "DescGain_1"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_1"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_1"), LocalStringManager.GetConfig("InformationType_language", "Title_1"), inUse: true));
		_dataArray.Add(new InformationTypeItem(2, LocalStringManager.GetConfig("InformationType_language", "Name_2"), LocalStringManager.GetConfig("InformationType_language", "Desc_2"), LocalStringManager.GetConfig("InformationType_language", "DescGain_2"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_2"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_2"), LocalStringManager.GetConfig("InformationType_language", "Title_2"), inUse: true));
		_dataArray.Add(new InformationTypeItem(3, LocalStringManager.GetConfig("InformationType_language", "Name_3"), LocalStringManager.GetConfig("InformationType_language", "Desc_3"), LocalStringManager.GetConfig("InformationType_language", "DescGain_3"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_3"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_3"), LocalStringManager.GetConfig("InformationType_language", "Title_3"), inUse: true));
		_dataArray.Add(new InformationTypeItem(4, LocalStringManager.GetConfig("InformationType_language", "Name_4"), LocalStringManager.GetConfig("InformationType_language", "Desc_4"), LocalStringManager.GetConfig("InformationType_language", "DescGain_4"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_4"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_4"), LocalStringManager.GetConfig("InformationType_language", "Title_4"), inUse: false));
		_dataArray.Add(new InformationTypeItem(5, LocalStringManager.GetConfig("InformationType_language", "Name_5"), LocalStringManager.GetConfig("InformationType_language", "Desc_5"), LocalStringManager.GetConfig("InformationType_language", "DescGain_5"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_5"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_5"), LocalStringManager.GetConfig("InformationType_language", "Title_5"), inUse: true));
		_dataArray.Add(new InformationTypeItem(6, LocalStringManager.GetConfig("InformationType_language", "Name_6"), LocalStringManager.GetConfig("InformationType_language", "Desc_6"), LocalStringManager.GetConfig("InformationType_language", "DescGain_6"), LocalStringManager.GetConfig("InformationType_language", "DescEffect_6"), LocalStringManager.GetConfig("InformationType_language", "DescEffectWay_6"), LocalStringManager.GetConfig("InformationType_language", "Title_6"), inUse: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InformationTypeItem>(7);
		CreateItems0();
	}
}
