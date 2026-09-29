using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WugKing : ConfigData<WugKingItem, sbyte>
{
	public static WugKing Instance = new WugKing();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"GrowingBadWugs", "GrowingBadEffectDesc", "GrowingGoodWugs", "GrowingGoodEffectDesc", "GrownWug", "GrownEffectDesc", "MakeTip", "WugFinger", "WugMedicine", "RefiningPoisons",
		"TemplateId", "RefiningWeight", "PoisonMinPercent", "PoisonMaxPercent"
	};

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
		_dataArray.Add(new WugKingItem(0, new List<short> { 349, 350 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_0"), new List<short> { 347, 348 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_0"), 351, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_0"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_0"), 454, 424, 12, new List<sbyte> { 3 }, 40, 100, poisonUnique: true));
		_dataArray.Add(new WugKingItem(1, new List<short> { 354, 355 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_1"), new List<short> { 352, 353 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_1"), 356, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_1"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_1"), 455, 425, 12, new List<sbyte> { 1 }, 40, 100, poisonUnique: true));
		_dataArray.Add(new WugKingItem(2, new List<short> { 359, 360 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_2"), new List<short> { 357, 358 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_2"), 361, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_2"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_2"), 456, 426, 12, new List<sbyte> { 4 }, 40, 100, poisonUnique: true));
		_dataArray.Add(new WugKingItem(3, new List<short> { 364, 365 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_3"), new List<short> { 362, 363 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_3"), 366, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_3"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_3"), 457, 427, 6, new List<sbyte> { 0, 1, 2, 3, 4, 5 }, 12, 20, poisonUnique: false));
		_dataArray.Add(new WugKingItem(4, new List<short> { 369, 370 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_4"), new List<short> { 367, 368 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_4"), 371, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_4"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_4"), 458, 428, 3, new List<sbyte> { 0, 3, 4 }, 30, 100, poisonUnique: false));
		_dataArray.Add(new WugKingItem(5, new List<short> { 374, 375 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_5"), new List<short> { 372, 373 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_5"), 376, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_5"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_5"), 459, 429, 9, new List<sbyte> { 2 }, 40, 100, poisonUnique: true));
		_dataArray.Add(new WugKingItem(6, new List<short> { 379, 380 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_6"), new List<short> { 377, 378 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_6"), 381, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_6"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_6"), 460, 430, 9, new List<sbyte> { 0 }, 40, 100, poisonUnique: true));
		_dataArray.Add(new WugKingItem(7, new List<short> { 384, 385 }, LocalStringManager.GetConfig("WugKing_language", "GrowingBadEffectDesc_7"), new List<short> { 382, 383 }, LocalStringManager.GetConfig("WugKing_language", "GrowingGoodEffectDesc_7"), 386, LocalStringManager.GetConfig("WugKing_language", "GrownEffectDesc_7"), LocalStringManager.GetConfig("WugKing_language", "MakeTip_7"), 461, 431, 1, new List<sbyte> { 1, 2, 5 }, 30, 100, poisonUnique: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WugKingItem>(8);
		CreateItems0();
	}
}
