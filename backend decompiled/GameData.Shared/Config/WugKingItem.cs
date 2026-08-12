using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WugKingItem : ConfigItem<WugKingItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 未识主的若蛊
	/// - 多个
	/// </summary>
	public readonly List<short> GrowingBadWugs;

	/// <summary>
	/// 有未识主的若蛊时的效果描述
	/// </summary>
	public readonly string GrowingBadEffectDesc;

	/// <summary>
	/// 识主的若蛊
	/// - 多个
	/// </summary>
	public readonly List<short> GrowingGoodWugs;

	/// <summary>
	/// 有识主的若蛊时的效果描述
	/// </summary>
	public readonly string GrowingGoodEffectDesc;

	/// <summary>
	/// 对应成蛊
	/// </summary>
	public readonly short GrownWug;

	/// <summary>
	/// 有成蛊时的效果描述
	/// </summary>
	public readonly string GrownEffectDesc;

	/// <summary>
	/// 制造方法提示
	/// </summary>
	public readonly string MakeTip;

	/// <summary>
	/// 蛊指功法
	/// </summary>
	public readonly short WugFinger;

	/// <summary>
	/// 王蛊道具
	/// </summary>
	public readonly short WugMedicine;

	/// <summary>
	/// 炼制权重
	/// </summary>
	public readonly short RefiningWeight;

	/// <summary>
	/// 炼制毒素
	/// </summary>
	public readonly List<sbyte> RefiningPoisons;

	/// <summary>
	/// 毒素最小百分比
	/// - 需求炼制毒素均处于的区间百分比（含），取值范围 [0,100]
	/// </summary>
	public readonly byte PoisonMinPercent;

	/// <summary>
	/// 毒素最大百分比
	/// </summary>
	public readonly byte PoisonMaxPercent;

	/// <summary>
	/// 毒素区间唯一性
	/// - 是否仅允许给定毒素处于对应区间
	/// </summary>
	public readonly bool PoisonUnique;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="growingBadWugs">未识主的若蛊 - 多个</param>
	/// <param name="growingBadEffectDesc">有未识主的若蛊时的效果描述</param>
	/// <param name="growingGoodWugs">识主的若蛊 - 多个</param>
	/// <param name="growingGoodEffectDesc">有识主的若蛊时的效果描述</param>
	/// <param name="grownWug">对应成蛊</param>
	/// <param name="grownEffectDesc">有成蛊时的效果描述</param>
	/// <param name="makeTip">制造方法提示</param>
	/// <param name="wugFinger">蛊指功法</param>
	/// <param name="wugMedicine">王蛊道具</param>
	/// <param name="refiningWeight">炼制权重</param>
	/// <param name="refiningPoisons">炼制毒素</param>
	/// <param name="poisonMinPercent">毒素最小百分比 - 需求炼制毒素均处于的区间百分比（含），取值范围 [0,100]</param>
	/// <param name="poisonMaxPercent">毒素最大百分比</param>
	/// <param name="poisonUnique">毒素区间唯一性 - 是否仅允许给定毒素处于对应区间</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WugKingItem Duplicate(int templateId)
	{
		return new WugKingItem((sbyte)templateId, this);
	}
}
