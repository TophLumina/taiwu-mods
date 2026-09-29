using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffect : ConfigData<AdventureRemakePerformanceEffectItem, short>
{
	public static class DefKey
	{
		public const short Test = 0;

		public const short BigFog = 1;

		public const short HuanhaiBack = 2;

		public const short GodDemonBack = 3;
	}

	public static class DefValue
	{
		public static AdventureRemakePerformanceEffectItem Test => Instance[(short)0];

		public static AdventureRemakePerformanceEffectItem BigFog => Instance[(short)1];

		public static AdventureRemakePerformanceEffectItem HuanhaiBack => Instance[(short)2];

		public static AdventureRemakePerformanceEffectItem GodDemonBack => Instance[(short)3];
	}

	public static AdventureRemakePerformanceEffect Instance = new AdventureRemakePerformanceEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "Effects", "TemplateId" };

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
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(0, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_0"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_0"), new List<short> { 0, 1, 2, 3, 4 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(1, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_1"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_1"), new List<short> { 5 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(2, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_2"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_2"), new List<short> { 6 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(3, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_3"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_3"), new List<short> { 7 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(4, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_4"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_4"), new List<short> { 8 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(5, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_5"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_5"), new List<short> { 9 }));
		_dataArray.Add(new AdventureRemakePerformanceEffectItem(6, LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Name_6"), LocalStringManager.GetConfig("AdventureRemakePerformanceEffect_language", "Desc_6"), new List<short> { 10 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureRemakePerformanceEffectItem>(7);
		CreateItems0();
	}
}
