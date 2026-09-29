using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InformationType : ConfigData<InformationTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Area = 0;

		public const sbyte Sect = 1;

		public const sbyte LifeSkill = 2;

		public const sbyte Western = 3;

		public const sbyte Scenic = 4;

		public const sbyte SwordTomb = 5;

		public const sbyte Profession = 6;
	}

	public static class DefValue
	{
		public static InformationTypeItem Area => Instance[(sbyte)0];

		public static InformationTypeItem Sect => Instance[(sbyte)1];

		public static InformationTypeItem LifeSkill => Instance[(sbyte)2];

		public static InformationTypeItem Western => Instance[(sbyte)3];

		public static InformationTypeItem Scenic => Instance[(sbyte)4];

		public static InformationTypeItem SwordTomb => Instance[(sbyte)5];

		public static InformationTypeItem Profession => Instance[(sbyte)6];
	}

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
