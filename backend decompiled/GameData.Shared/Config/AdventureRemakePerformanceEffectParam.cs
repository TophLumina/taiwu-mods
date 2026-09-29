using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffectParam : ConfigData<AdventureRemakePerformanceEffectParamItem, short>
{
	public static class DefKey
	{
		public const short BlockFire = 0;

		public const short FrontVerticalSmoke = 1;

		public const short BackVerticalSmoke = 2;

		public const short Lightning = 3;

		public const short Rain = 4;

		public const short Fog = 5;

		public const short HuanhaiBack = 6;

		public const short GodDemonBack = 7;
	}

	public static class DefValue
	{
		public static AdventureRemakePerformanceEffectParamItem BlockFire => Instance[(short)0];

		public static AdventureRemakePerformanceEffectParamItem FrontVerticalSmoke => Instance[(short)1];

		public static AdventureRemakePerformanceEffectParamItem BackVerticalSmoke => Instance[(short)2];

		public static AdventureRemakePerformanceEffectParamItem Lightning => Instance[(short)3];

		public static AdventureRemakePerformanceEffectParamItem Rain => Instance[(short)4];

		public static AdventureRemakePerformanceEffectParamItem Fog => Instance[(short)5];

		public static AdventureRemakePerformanceEffectParamItem HuanhaiBack => Instance[(short)6];

		public static AdventureRemakePerformanceEffectParamItem GodDemonBack => Instance[(short)7];
	}

	public static AdventureRemakePerformanceEffectParam Instance = new AdventureRemakePerformanceEffectParam();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Type", "LoadName", "CountRange", "ParticleStartDelayRandom", "ParticleStartSpeedRandom" };

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
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(0, EAdventureRemakePerformanceEffectParamType.OuterBlock, "qiyu_huo_ceshi2", 30, null, 1, -1f, -1f, new float[2] { 0f, 0.5f }, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(1, EAdventureRemakePerformanceEffectParamType.FrontVerticalStripe, "qiyu_yan_ceshi1", -1, new sbyte[2] { 4, 6 }, 10, -1f, -1f, new float[2] { 0f, 1f }, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(2, EAdventureRemakePerformanceEffectParamType.BackVerticalStripe, "qiyu_yan_ceshi1", -1, new sbyte[2] { 4, 6 }, 8, -1f, -1f, new float[2] { 0f, 1f }, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(3, EAdventureRemakePerformanceEffectParamType.FullscreenRandomLocation, "qiyu_shandian_ceshi4", -1, new sbyte[2] { 4, 6 }, 1, 2f, 1f, new float[2] { 0f, 1f }, new float[2] { -1f, 1f }));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(4, EAdventureRemakePerformanceEffectParamType.FullscreenRandomLocation, "qiyu_yu_ceshi3", -1, new sbyte[2] { 3, 4 }, 10, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(5, EAdventureRemakePerformanceEffectParamType.FrontVerticalStripe, "eff_adventure_lzg_dawu_1", -1, new sbyte[2] { 1, 2 }, 1000, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(6, EAdventureRemakePerformanceEffectParamType.FullscreenCenterLocation, "eff_adventure_huanhai_beijing", -1, null, 1, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(7, EAdventureRemakePerformanceEffectParamType.FullscreenCenterLocation, "eff_adventure_shenmo_beijing2", -1, null, 1, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(8, EAdventureRemakePerformanceEffectParamType.FullscreenCenterLocation, "eff_adventure_hundunwuji_pangu_beijing", -1, null, 1, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(9, EAdventureRemakePerformanceEffectParamType.FullscreenCenterLocation, "eff_adventure_hundunwuji_xianmo_beijing1", -1, null, 1, -1f, -1f, null, null));
		_dataArray.Add(new AdventureRemakePerformanceEffectParamItem(10, EAdventureRemakePerformanceEffectParamType.FullscreenCenterLocation, "eff_adventure_hundunwuji_xianmo_beijing2", -1, null, 1, -1f, -1f, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureRemakePerformanceEffectParamItem>(11);
		CreateItems0();
	}
}
