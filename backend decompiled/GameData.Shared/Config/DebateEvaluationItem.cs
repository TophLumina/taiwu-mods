using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class DebateEvaluationItem : ConfigItem<DebateEvaluationItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string ResultTip;

	public readonly int ExpA;

	public readonly int ExpB;

	public readonly int ExpC;

	public readonly int AuthorityA;

	public readonly int AuthorityB;

	public readonly int AuthorityC;

	public readonly short Favor;

	public readonly int FavorIncreaseB;

	public readonly int FavorIncreaseC;

	public readonly int FavorDecreaseB;

	public readonly int FavorDecreaseC;

	public readonly int ReadRate;

	public readonly int LoopRate;

	public readonly short FameAction;

	public readonly List<LegacyPointReference> AddLegacyPoint;

	public readonly int HappinessDelta;

	public DebateEvaluationItem(short templateId, string name, string resultTip, int expA, int expB, int expC, int authorityA, int authorityB, int authorityC, short favor, int favorIncreaseB, int favorIncreaseC, int favorDecreaseB, int favorDecreaseC, int readRate, int loopRate, short fameAction, List<LegacyPointReference> addLegacyPoint, int happinessDelta)
	{
		TemplateId = templateId;
		Name = name;
		ResultTip = resultTip;
		ExpA = expA;
		ExpB = expB;
		ExpC = expC;
		AuthorityA = authorityA;
		AuthorityB = authorityB;
		AuthorityC = authorityC;
		Favor = favor;
		FavorIncreaseB = favorIncreaseB;
		FavorIncreaseC = favorIncreaseC;
		FavorDecreaseB = favorDecreaseB;
		FavorDecreaseC = favorDecreaseC;
		ReadRate = readRate;
		LoopRate = loopRate;
		FameAction = fameAction;
		AddLegacyPoint = addLegacyPoint;
		HappinessDelta = happinessDelta;
	}

	public DebateEvaluationItem()
	{
		TemplateId = 0;
		Name = null;
		ResultTip = null;
		ExpA = 0;
		ExpB = 0;
		ExpC = 0;
		AuthorityA = 0;
		AuthorityB = 0;
		AuthorityC = 0;
		Favor = 0;
		FavorIncreaseB = 0;
		FavorIncreaseC = 0;
		FavorDecreaseB = 0;
		FavorDecreaseC = 0;
		ReadRate = 0;
		LoopRate = 0;
		FameAction = 0;
		AddLegacyPoint = null;
		HappinessDelta = 0;
	}

	public DebateEvaluationItem(short templateId, DebateEvaluationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ResultTip = other.ResultTip;
		ExpA = other.ExpA;
		ExpB = other.ExpB;
		ExpC = other.ExpC;
		AuthorityA = other.AuthorityA;
		AuthorityB = other.AuthorityB;
		AuthorityC = other.AuthorityC;
		Favor = other.Favor;
		FavorIncreaseB = other.FavorIncreaseB;
		FavorIncreaseC = other.FavorIncreaseC;
		FavorDecreaseB = other.FavorDecreaseB;
		FavorDecreaseC = other.FavorDecreaseC;
		ReadRate = other.ReadRate;
		LoopRate = other.LoopRate;
		FameAction = other.FameAction;
		AddLegacyPoint = other.AddLegacyPoint;
		HappinessDelta = other.HappinessDelta;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DebateEvaluationItem Duplicate(int templateId)
	{
		return new DebateEvaluationItem((short)templateId, this);
	}
}
