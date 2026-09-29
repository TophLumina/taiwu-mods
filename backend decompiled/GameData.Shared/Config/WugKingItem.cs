using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WugKingItem : ConfigItem<WugKingItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly List<short> GrowingBadWugs;

	public readonly string GrowingBadEffectDesc;

	public readonly List<short> GrowingGoodWugs;

	public readonly string GrowingGoodEffectDesc;

	public readonly short GrownWug;

	public readonly string GrownEffectDesc;

	public readonly string MakeTip;

	public readonly short WugFinger;

	public readonly short WugMedicine;

	public readonly short RefiningWeight;

	public readonly List<sbyte> RefiningPoisons;

	public readonly byte PoisonMinPercent;

	public readonly byte PoisonMaxPercent;

	public readonly bool PoisonUnique;

	public WugKingItem(sbyte templateId, List<short> growingBadWugs, string growingBadEffectDesc, List<short> growingGoodWugs, string growingGoodEffectDesc, short grownWug, string grownEffectDesc, string makeTip, short wugFinger, short wugMedicine, short refiningWeight, List<sbyte> refiningPoisons, byte poisonMinPercent, byte poisonMaxPercent, bool poisonUnique)
	{
		TemplateId = templateId;
		GrowingBadWugs = growingBadWugs;
		GrowingBadEffectDesc = growingBadEffectDesc;
		GrowingGoodWugs = growingGoodWugs;
		GrowingGoodEffectDesc = growingGoodEffectDesc;
		GrownWug = grownWug;
		GrownEffectDesc = grownEffectDesc;
		MakeTip = makeTip;
		WugFinger = wugFinger;
		WugMedicine = wugMedicine;
		RefiningWeight = refiningWeight;
		RefiningPoisons = refiningPoisons;
		PoisonMinPercent = poisonMinPercent;
		PoisonMaxPercent = poisonMaxPercent;
		PoisonUnique = poisonUnique;
	}

	public WugKingItem()
	{
		TemplateId = 0;
		GrowingBadWugs = null;
		GrowingBadEffectDesc = null;
		GrowingGoodWugs = null;
		GrowingGoodEffectDesc = null;
		GrownWug = 0;
		GrownEffectDesc = null;
		MakeTip = null;
		WugFinger = 0;
		WugMedicine = 0;
		RefiningWeight = 0;
		RefiningPoisons = null;
		PoisonMinPercent = 0;
		PoisonMaxPercent = 0;
		PoisonUnique = false;
	}

	public WugKingItem(sbyte templateId, WugKingItem other)
	{
		TemplateId = templateId;
		GrowingBadWugs = other.GrowingBadWugs;
		GrowingBadEffectDesc = other.GrowingBadEffectDesc;
		GrowingGoodWugs = other.GrowingGoodWugs;
		GrowingGoodEffectDesc = other.GrowingGoodEffectDesc;
		GrownWug = other.GrownWug;
		GrownEffectDesc = other.GrownEffectDesc;
		MakeTip = other.MakeTip;
		WugFinger = other.WugFinger;
		WugMedicine = other.WugMedicine;
		RefiningWeight = other.RefiningWeight;
		RefiningPoisons = other.RefiningPoisons;
		PoisonMinPercent = other.PoisonMinPercent;
		PoisonMaxPercent = other.PoisonMaxPercent;
		PoisonUnique = other.PoisonUnique;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WugKingItem Duplicate(int templateId)
	{
		return new WugKingItem((sbyte)templateId, this);
	}
}
