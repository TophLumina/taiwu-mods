using System;

namespace Config;

[Serializable]
public abstract class AdventureBranch
{
	/// 分支长度
	public short Length;

	/// 该分支上的全局事件
	public string GlobalEvent;

	/// 技艺权重 (LifeSkillId, Weight)
	public (byte, short)[] SkillWeights;

	/// 地形及对应七元的权重 (TerrainId, TerrainWeight, [CalmWeight, Clever, Enthusiastic, Brave, Firm])
	public (byte, short, short[])[] TerrainPersonalityWeights;

	/// 七元对应的奖励和事件类型及其权重
	public AdventurePersonalityContentWeights[] PersonalityContentWeights;

	protected AdventureBranch(short len, string globalEvent, int[] skillCfg, int[] terrainPersonalityCfg, int[] emptyBlockCfg, string[] eventCfg, int[] resRewardCfg, int[] itemRewardCfg, string[] bonusRewardCfg)
	{
		Length = len;
		GlobalEvent = globalEvent;
		SkillWeights = new(byte, short)[skillCfg.Length / 2];
		for (int i = 0; i < skillCfg.Length; i += 2)
		{
			SkillWeights[i / 2] = ((byte)skillCfg[i], (short)skillCfg[i + 1]);
		}
		TerrainPersonalityWeights = new(byte, short, short[])[terrainPersonalityCfg[0]];
		int index = 2;
		for (int j = 0; j < TerrainPersonalityWeights.Length; j++)
		{
			int size = terrainPersonalityCfg[index - 1];
			short[] personalityWeights = null;
			if (size == 7)
			{
				personalityWeights = new short[5];
				for (int k = 0; k < personalityWeights.Length; k++)
				{
					personalityWeights[k] = (short)terrainPersonalityCfg[index + k + 2];
				}
			}
			TerrainPersonalityWeights[j] = ((byte)terrainPersonalityCfg[index], (short)terrainPersonalityCfg[index + 1], personalityWeights);
			index += size + 1;
		}
		PersonalityContentWeights = new AdventurePersonalityContentWeights[5];
		int eventIndex = 1;
		int resIndex = 1;
		int itemIndex = 1;
		int bonusIndex = 1;
		for (int l = 0; l < PersonalityContentWeights.Length; l++)
		{
			(string, short)[] eventWeights = new(string, short)[int.Parse(eventCfg[eventIndex - 1])];
			(byte, short, short)[] resRewardWeights = new(byte, short, short)[resRewardCfg[resIndex - 1]];
			(byte, short, short, short)[] itemRewardWeights = new(byte, short, short, short)[itemRewardCfg[itemIndex - 1]];
			(string, short)[] bonusRewardWeights = new(string, short)[int.Parse(bonusRewardCfg[bonusIndex - 1])];
			for (int m = 0; m < eventWeights.Length; m++)
			{
				index = eventIndex + m * 2;
				eventWeights[m] = (eventCfg[index], short.Parse(eventCfg[index + 1]));
			}
			for (int n = 0; n < resRewardWeights.Length; n++)
			{
				index = resIndex + n * 3;
				resRewardWeights[n] = ((byte)resRewardCfg[index], (short)resRewardCfg[index + 1], (short)resRewardCfg[index + 2]);
			}
			for (int num = 0; num < itemRewardWeights.Length; num++)
			{
				index = itemIndex + num * 4;
				itemRewardWeights[num] = ((byte)itemRewardCfg[index], (short)itemRewardCfg[index + 1], (short)itemRewardCfg[index + 2], (short)itemRewardCfg[index + 3]);
			}
			for (int num2 = 0; num2 < bonusRewardWeights.Length; num2++)
			{
				index = bonusIndex + num2 * 2;
				bonusRewardWeights[num2] = (bonusRewardCfg[index], short.Parse(bonusRewardCfg[index + 1]));
			}
			eventIndex += eventWeights.Length * 2 + 1;
			resIndex += resRewardWeights.Length * 3 + 1;
			itemIndex += itemRewardWeights.Length * 4 + 1;
			bonusIndex += bonusRewardWeights.Length * 2 + 1;
			PersonalityContentWeights[l] = new AdventurePersonalityContentWeights((short)emptyBlockCfg[l], eventWeights, resRewardWeights, itemRewardWeights, bonusRewardWeights);
		}
	}

	protected AdventureBranch()
	{
	}
}
