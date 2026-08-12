using System;

namespace Config;

[Serializable]
public class AdventureAdvancedBranch : AdventureBranch
{
	public int ParentBranchId;

	public sbyte EnterSkillType;

	public short EnterSkillRequire;

	public AdventureAdvancedBranch(byte length, string globalEvent, int parentBranchId, sbyte enterSkillType, short enterSkillRequire, int[] skillCfg, int[] terrainPersonalityCfg, int[] emptyBlockCfg, string[] eventCfg, int[] resRewardCfg, int[] itemRewardCfg, string[] bonusRewardCfg)
		: base(length, globalEvent, skillCfg, terrainPersonalityCfg, emptyBlockCfg, eventCfg, resRewardCfg, itemRewardCfg, bonusRewardCfg)
	{
		ParentBranchId = parentBranchId;
		EnterSkillType = enterSkillType;
		EnterSkillRequire = enterSkillRequire;
	}

	public AdventureAdvancedBranch()
	{
	}
}
