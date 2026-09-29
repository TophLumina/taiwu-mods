using System;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetCombatSkill
{
	public readonly short SkillTemplateId;

	public readonly sbyte OutlinePagesReadCount;

	public readonly bool[] OutlinePagesReadStates;

	public readonly sbyte DirectPagesReadCount;

	public readonly bool[] DirectPagesReadStates;

	public readonly sbyte ReversePagesReadCount;

	public readonly bool[] ReversePagesReadStates;

	public PresetCombatSkill(short skillTemplateId, sbyte outlinePagesReadCount = 0, sbyte directPagesReadCount = 0, sbyte reversePagesReadCount = 0)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = outlinePagesReadCount;
		OutlinePagesReadStates = null;
		DirectPagesReadCount = directPagesReadCount;
		DirectPagesReadStates = null;
		ReversePagesReadCount = reversePagesReadCount;
		ReversePagesReadStates = null;
	}

	public PresetCombatSkill(short skillTemplateId, sbyte outlinePagesReadCount, int[] directPagesReadStates, int[] reversePagesReadStates)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = outlinePagesReadCount;
		OutlinePagesReadStates = null;
		DirectPagesReadCount = -1;
		DirectPagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			DirectPagesReadStates[i] = directPagesReadStates[i] != 0;
		}
		ReversePagesReadCount = -1;
		ReversePagesReadStates = new bool[5];
		for (int j = 0; j < 5; j++)
		{
			ReversePagesReadStates[j] = reversePagesReadStates[j] != 0;
		}
	}

	public PresetCombatSkill(short skillTemplateId, int[] outlinePagesReadStates, sbyte directPagesReadCount, sbyte reversePagesReadCount)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = -1;
		OutlinePagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			OutlinePagesReadStates[i] = outlinePagesReadStates[i] != 0;
		}
		DirectPagesReadCount = directPagesReadCount;
		DirectPagesReadStates = null;
		ReversePagesReadCount = reversePagesReadCount;
		ReversePagesReadStates = null;
	}

	public PresetCombatSkill(short skillTemplateId, int[] outlinePagesReadStates, int[] directPagesReadStates, int[] reversePagesReadStates)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = -1;
		OutlinePagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			OutlinePagesReadStates[i] = outlinePagesReadStates[i] != 0;
		}
		DirectPagesReadCount = -1;
		DirectPagesReadStates = new bool[5];
		for (int j = 0; j < 5; j++)
		{
			DirectPagesReadStates[j] = directPagesReadStates[j] != 0;
		}
		ReversePagesReadCount = -1;
		ReversePagesReadStates = new bool[5];
		for (int k = 0; k < 5; k++)
		{
			ReversePagesReadStates[k] = reversePagesReadStates[k] != 0;
		}
	}
}
