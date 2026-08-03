using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;

namespace GameData.Domains.Character;

public static class CharacterFeatureHelper
{
	public static IComparer<short> FeatureComparer = Comparer<short>.Create(CompareFeature);

	public static bool IsGood(this CharacterFeatureItem config)
	{
		return config.Level > 0;
	}

	public static bool IsBad(this CharacterFeatureItem config)
	{
		return config.Level < 0;
	}

	public static bool IsNeutral(this CharacterFeatureItem config)
	{
		return config.Level == 0;
	}

	public static bool IsNormal(this CharacterFeatureItem config)
	{
		ECharacterFeatureType type = config.Type;
		if ((uint)(type - 1) <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool IsLowest(this CharacterFeatureItem config)
	{
		return Math.Abs(config.Level) == 1;
	}

	public static bool IsHighest(this CharacterFeatureItem config)
	{
		return Math.Abs(config.Level) == 3;
	}

	public static bool IsAllowedForOrganization(this CharacterFeatureItem config, sbyte orgTemplateId)
	{
		return config.RequiredOrganization < 0 || config.RequiredOrganization == orgTemplateId;
	}

	public static CharacterFeatureItem Upgrade(this CharacterFeatureItem config)
	{
		if (config.IsNeutral() || config.IsHighest())
		{
			return null;
		}
		int delta = (config.IsGood() ? 1 : (-1));
		foreach (CharacterFeatureItem featureConfig in CharacterFeature.Instance.Where((CharacterFeatureItem x) => x != null))
		{
			if (featureConfig.MutexGroupId == config.MutexGroupId && featureConfig.Level == config.Level + delta)
			{
				return featureConfig;
			}
		}
		return null;
	}

	public static CharacterFeatureItem Degrade(this CharacterFeatureItem config)
	{
		if (config.IsNeutral() || config.IsLowest())
		{
			return null;
		}
		int delta = ((!config.IsGood()) ? 1 : (-1));
		foreach (CharacterFeatureItem featureConfig in CharacterFeature.Instance.Where((CharacterFeatureItem x) => x != null))
		{
			if (featureConfig.MutexGroupId == config.MutexGroupId && featureConfig.Level == config.Level + delta)
			{
				return featureConfig;
			}
		}
		return null;
	}

	public static int CompareFeature(short featureIdA, short featureIdB)
	{
		return CharacterFeature.Instance[featureIdA].DisplayPriority.CompareTo(CharacterFeature.Instance[featureIdB].DisplayPriority);
	}

	public static int CalcFeatureMedalValue(IEnumerable<short> featureIds, sbyte medalType)
	{
		int baseValue = 0;
		int bonus = 0;
		foreach (short featureId in featureIds)
		{
			FeatureMedals[] allMedals = CharacterFeature.Instance[featureId].FeatureMedals;
			List<sbyte> currValues = allMedals[medalType].Values;
			for (int i = 0; i < currValues.Count; i++)
			{
				switch (currValues[i])
				{
				case 0:
					baseValue++;
					break;
				case 1:
					baseValue--;
					break;
				case 2:
					bonus++;
					break;
				case 3:
					bonus -= 3;
					break;
				}
			}
		}
		if (baseValue == 0)
		{
			return 0;
		}
		bool positive = baseValue > 0;
		int finalValue = baseValue + (positive ? bonus : (-bonus));
		if (finalValue > 0 != positive)
		{
			return 0;
		}
		return positive ? Math.Min(finalValue, 8) : Math.Max(finalValue, -8);
	}
}
