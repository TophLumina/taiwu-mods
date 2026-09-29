using System;

namespace Config;

[Serializable]
public class AdventureBaseBranch : AdventureBranch
{
	public string BranchKey;

	public short LuckStoreCount;

	public byte PortA;

	public byte PortB;

	public AdventureBaseBranch(byte portA, byte portB, string branchKey, short luckStoreCount, short len, string globalEvent, int[] skillCfg, int[] terrainPersonalityCfg, int[] emptyBlockCfg, string[] eventCfg, int[] resRewardCfg, int[] itemRewardCfg, string[] bonusRewardCfg)
		: base(len, globalEvent, skillCfg, terrainPersonalityCfg, emptyBlockCfg, eventCfg, resRewardCfg, itemRewardCfg, bonusRewardCfg)
	{
		BranchKey = branchKey;
		LuckStoreCount = luckStoreCount;
		PortA = portA;
		PortB = portB;
	}

	public AdventureBaseBranch()
	{
	}
}
