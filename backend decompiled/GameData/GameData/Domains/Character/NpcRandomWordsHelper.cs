using System;
using System.Collections.Generic;
using Config;
using GameData.DLC;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.FunctionDefinition;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

public static class NpcRandomWordsHelper
{
	private static bool HasRelation(int charId, int relatedCharId, ushort targetRelationType)
	{
		return DomainManager.Character.HasRelation(charId, relatedCharId, targetRelationType);
	}

	private static bool HasBloodGrandParentRelations(int charId, int relatedCharId)
	{
		return DomainManager.Character.HasBloodGrandParentRelations(charId, relatedCharId);
	}

	public static string RandomContent(this ENpcRandomWordsType type, IRandomSource random, Character npcChar, ENpcRandomWordsType subType = ENpcRandomWordsType.Count)
	{
		List<short> range = ObjectPool<List<short>>.Instance.Get();
		List<short> weight = ObjectPool<List<short>>.Instance.Get();
		range.Clear();
		weight.Clear();
		foreach (NpcRandomWordsItem word in (IEnumerable<NpcRandomWordsItem>)NpcRandomWords.Instance)
		{
			if (word.IsMatch(type, subType) && word.IsMatch(npcChar))
			{
				range.Add(word.TemplateId);
				weight.Add(word.Weight);
			}
		}
		string content = string.Empty;
		if (range.Count > 0)
		{
			int index = RandomUtils.GetRandomIndex(weight, random);
			short templateId = range[index];
			NpcRandomWordsItem word2 = NpcRandomWords.Instance[templateId];
			content = word2.RandomContent(random);
		}
		ObjectPool<List<short>>.Instance.Return(range);
		ObjectPool<List<short>>.Instance.Return(weight);
		return content;
	}

	public static string RandomContent(this NpcRandomWordsItem word, IRandomSource random)
	{
		switch (word.FormatRule)
		{
		case ENpcRandomWordsFormatRule.LegendaryBook:
		{
			short selectedTaiwuTitle = word.RandomMatchTitle(random);
			Tester.Assert(selectedTaiwuTitle >= 0, "Illegal selectedTaiwuTitle");
			CharacterTitleItem titleItem = CharacterTitle.Instance[selectedTaiwuTitle];
			MiscItem miscItem = Misc.Instance[titleItem.Misc];
			return word.Words.GetFormat(miscItem.Name);
		}
		case ENpcRandomWordsFormatRule.CombatTitle:
		{
			short selectedTaiwuTitle2 = word.RandomMatchTitle(random);
			Tester.Assert(selectedTaiwuTitle2 >= 0, "Illegal selectedTaiwuTitle");
			CharacterTitleItem titleItem2 = CharacterTitle.Instance[selectedTaiwuTitle2];
			return word.Words.GetFormat(titleItem2.Name);
		}
		case ENpcRandomWordsFormatRule.Item:
		{
			MiscItem template = word.HolderMisc;
			return word.Words.GetFormat($"<color=#GradeColor_{template?.Grade ?? 0}>{template?.Name ?? "Decode Error"}</color>");
		}
		case ENpcRandomWordsFormatRule.None:
			return word.Words;
		default:
			throw new Exception($"unknown format rule: {word.FormatRule}");
		}
	}

	private static short RandomMatchTitle(this NpcRandomWordsItem word, IRandomSource random = null)
	{
		List<short> taiwuTitleLimit = word.TaiwuTitleLimit;
		if (taiwuTitleLimit == null || taiwuTitleLimit.Count <= 0)
		{
			return -1;
		}
		Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<short> titles = ObjectPool<List<short>>.Instance.Get();
		titles.Clear();
		taiwuChar.GetTitles(titles);
		titles.RemoveAll((short x) => !word.TaiwuTitleLimit.Contains(x));
		short titleId = (short)((titles.Count == 0) ? (-1) : ((random != null) ? titles.GetRandom(random) : titles[0]));
		ObjectPool<List<short>>.Instance.Return(titles);
		return titleId;
	}

	private static bool IsMatch(this NpcRandomWordsItem word, ENpcRandomWordsType type, ENpcRandomWordsType subType)
	{
		return word.Type == type || word.Type == subType;
	}

	private static bool IsMatch(this NpcRandomWordsItem word, Character npcChar)
	{
		List<sbyte> limit = word.MonthLimit;
		if (limit != null && limit.Count > 0 && !limit.Contains((sbyte)(DomainManager.World.GetCurrDate() % 12)))
		{
			return false;
		}
		Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (word.SelfGender != -1 && !taiwuChar.CheckGenderMeetsRequirement(word.SelfGender))
		{
			return false;
		}
		if (word.TargetGender != -1 && !npcChar.CheckGenderMeetsRequirement(word.TargetGender))
		{
			return false;
		}
		if (word.SexualOrientation != -1 && (npcChar.GetCurrAge() < 16 || npcChar.GetGender() != word.TargetGender || !npcChar.CheckSexualOrientationMeetsRequirement(word.SexualOrientation)))
		{
			return false;
		}
		if (!word.CheckAge(taiwuChar, npcChar))
		{
			return false;
		}
		short morality = npcChar.GetMorality();
		if (morality < word.BehaviorLimit[0] || morality > word.BehaviorLimit[1])
		{
			return false;
		}
		if (!word.CheckFeature(npcChar))
		{
			return false;
		}
		if (!word.CheckProperty(npcChar))
		{
			return false;
		}
		short favorToTaiwu = DomainManager.Character.GetFavorability(npcChar.GetId(), taiwuChar.GetId());
		if (favorToTaiwu < word.FavorLimit[0] || favorToTaiwu > word.FavorLimit[1])
		{
			return false;
		}
		if (!word.CheckOrganization(npcChar))
		{
			return false;
		}
		if (!word.CheckRelation(taiwuChar, npcChar))
		{
			return false;
		}
		if (!word.CheckSectStoryTaskStatus())
		{
			return false;
		}
		if (!word.CheckDlc())
		{
			return false;
		}
		if (!word.CheckTitle())
		{
			return false;
		}
		if (!word.CheckTaiwuMapState(taiwuChar) || !word.CheckTaiwuLocation(taiwuChar))
		{
			return false;
		}
		if (!word.CheckCharacterMapArea(npcChar) || !word.CheckCharacterSettlement(taiwuChar))
		{
			return false;
		}
		if (!word.CheckTaskInfos())
		{
			return false;
		}
		sbyte progress = DomainManager.World.GetXiangshuProgress();
		if (progress < word.XiangshuProgressLimit[0] || progress > word.XiangshuProgressLimit[1])
		{
			return false;
		}
		return true;
	}

	private static bool CheckFeature(this NpcRandomWordsItem word, Character npcChar)
	{
		if (word.FeatureLimit.Count > 0)
		{
			bool featureMatch = false;
			foreach (short featureId in word.FeatureLimit)
			{
				if (npcChar.GetFeatureIds().Contains(featureId))
				{
					featureMatch = true;
				}
			}
			return featureMatch;
		}
		return true;
	}

	private static bool CheckProperty(this NpcRandomWordsItem word, Character npcChar)
	{
		short[] propertyLimit = word.PropertyLimit;
		if (propertyLimit != null && propertyLimit.Length > 0)
		{
			int value = npcChar.GetPropertyValue((ECharacterPropertyReferencedType)word.PropertyLimit[0]);
			return EventConditions.PerformOperation(word.PropertyLimit[1], value, word.PropertyLimit[2]);
		}
		return true;
	}

	private static bool CheckAge(this NpcRandomWordsItem word, Character taiwuChar, Character npcChar)
	{
		if (word.AgeLimit < 0)
		{
			return true;
		}
		short taiwuAge = taiwuChar.GetActualAge();
		short npcAge = npcChar.GetActualAge();
		short ageLimit = word.AgeLimit;
		if (1 == 0)
		{
		}
		bool result = ageLimit switch
		{
			0 => npcAge > taiwuAge, 
			1 => npcAge <= taiwuAge, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static bool CheckOrganization(this NpcRandomWordsItem word, Character npcChar)
	{
		List<short> organizationGradeLimit = word.OrganizationGradeLimit;
		if (organizationGradeLimit == null || organizationGradeLimit.Count <= 0)
		{
			return true;
		}
		OrganizationMemberItem orgMember = OrganizationDomain.GetOrgMemberConfig(npcChar.GetOrganizationInfo());
		return word.OrganizationGradeLimit.Contains(orgMember.TemplateId);
	}

	private static bool CheckRelation(this NpcRandomWordsItem word, Character taiwuChar, Character npcChar)
	{
		sbyte relation = word.RelationLimit;
		if (relation < 0)
		{
			return true;
		}
		int taiwuCharId = taiwuChar.GetId();
		int npcCharId = npcChar.GetId();
		bool adoredAToB = HasRelation(npcCharId, taiwuCharId, 16384);
		bool adoredBToA = HasRelation(taiwuCharId, npcCharId, 16384);
		if (1 == 0)
		{
		}
		bool result = relation switch
		{
			0 => HasRelation(npcCharId, taiwuCharId, 32768), 
			1 => HasRelation(npcCharId, taiwuCharId, 8192), 
			2 => HasBloodGrandParentRelations(npcCharId, taiwuCharId), 
			3 => HasBloodGrandParentRelations(taiwuCharId, npcCharId), 
			4 => HasRelation(npcCharId, taiwuCharId, 128) || HasRelation(npcCharId, taiwuCharId, 16), 
			5 => HasRelation(npcCharId, taiwuCharId, 2), 
			6 => HasRelation(npcCharId, taiwuCharId, 1024), 
			7 => HasRelation(npcCharId, taiwuCharId, 1), 
			8 => HasRelation(npcCharId, taiwuCharId, 64), 
			9 => HasRelation(npcCharId, taiwuCharId, 8), 
			10 => HasRelation(npcCharId, taiwuCharId, 4) || HasRelation(npcCharId, taiwuCharId, 256) || HasRelation(npcCharId, taiwuCharId, 32), 
			11 => HasRelation(npcCharId, taiwuCharId, 512), 
			12 => adoredAToB != adoredBToA, 
			13 => adoredAToB && adoredBToA, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static bool CheckSectStoryTaskStatus(this NpcRandomWordsItem word)
	{
		if (word.SectStoryTaskStatus < 0)
		{
			return true;
		}
		sbyte sectStoryOrganizationTemplateId = word.SectStoryOrganizationTemplateId;
		if ((sectStoryOrganizationTemplateId < 1 || sectStoryOrganizationTemplateId >= 16) ? true : false)
		{
			return true;
		}
		return DomainManager.Story.GetSectMainStoryTaskStatus(word.SectStoryOrganizationTemplateId) == word.SectStoryTaskStatus;
	}

	private static bool CheckDlc(this NpcRandomWordsItem word)
	{
		if (word.DlcAppId == 0)
		{
			return true;
		}
		if (!DlcManager.IsDlcInstalled(word.DlcAppId))
		{
			return false;
		}
		if (word.DlcAppId == 2764950)
		{
			return DomainManager.Extra.GetFiveLoongDictCount(null) > 0;
		}
		return false;
	}

	private static bool CheckTitle(this NpcRandomWordsItem word)
	{
		List<short> taiwuTitleLimit = word.TaiwuTitleLimit;
		if (taiwuTitleLimit == null || taiwuTitleLimit.Count <= 0)
		{
			return true;
		}
		return word.RandomMatchTitle() >= 0;
	}

	private static bool CheckTaiwuMapState(this NpcRandomWordsItem word, Character taiwuChar)
	{
		if (word.MapState < 0)
		{
			return true;
		}
		Location location = taiwuChar.GetLocation();
		if (location.AreaId < 0)
		{
			return false;
		}
		return word.MapState == DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
	}

	private static bool CheckTaiwuLocation(this NpcRandomWordsItem word, Character taiwuChar)
	{
		if (word.Location == ENpcRandomWordsLocation.None)
		{
			return true;
		}
		Location location = taiwuChar.GetLocation();
		ENpcRandomWordsLocation type = ENpcRandomWordsLocation.Other;
		if (MapAreaData.IsBrokenArea(location.AreaId))
		{
			type = ENpcRandomWordsLocation.Broken;
		}
		else if (location == DomainManager.Taiwu.GetTaiwuVillageLocation())
		{
			type = ENpcRandomWordsLocation.TaiwuVillage;
		}
		else if (location.IsValid())
		{
			MapBlockData data = DomainManager.Map.GetBlock(location);
			if (data.BelongBlockId >= 0)
			{
				data = DomainManager.Map.GetBlock(location.AreaId, data.BelongBlockId);
			}
			EMapBlockType blockType = data.BlockType;
			if (1 == 0)
			{
			}
			ENpcRandomWordsLocation eNpcRandomWordsLocation = blockType switch
			{
				EMapBlockType.Sect => ENpcRandomWordsLocation.None, 
				EMapBlockType.City => ENpcRandomWordsLocation.City, 
				EMapBlockType.Town => ENpcRandomWordsLocation.Town, 
				_ => ENpcRandomWordsLocation.Other, 
			};
			if (1 == 0)
			{
			}
			type = eNpcRandomWordsLocation;
		}
		return type == word.Location;
	}

	private static bool CheckCharacterMapArea(this NpcRandomWordsItem word, Character character)
	{
		if (word.MapAreaTemplateId < 0)
		{
			return true;
		}
		Location location = character.GetLocation();
		if (location.AreaId < 0)
		{
			return false;
		}
		return DomainManager.Map.GetAreaIdByAreaTemplateId(word.MapAreaTemplateId) == location.AreaId;
	}

	private static bool CheckCharacterSettlement(this NpcRandomWordsItem word, Character character)
	{
		if (word.MapAreaTemplateId < 0)
		{
			return true;
		}
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(word.MapAreaTemplateId);
		OrganizationInfo organizationInfo = character.GetOrganizationInfo();
		Settlement settlement = DomainManager.Organization.GetSettlement(organizationInfo.SettlementId);
		if (settlement.GetLocation().AreaId != areaId)
		{
			return false;
		}
		OrganizationItem orgConfig = Config.Organization.Instance[organizationInfo.OrgTemplateId];
		if (orgConfig.IsSect != word.IsSectSettlement)
		{
			return false;
		}
		return DomainManager.Map.IsLocationInSettlementInfluenceRange(character.GetLocation(), organizationInfo.SettlementId);
	}

	private static bool CheckTaskInfos(this NpcRandomWordsItem word)
	{
		if (word.NeedTaskInfos.Count == 0)
		{
			return true;
		}
		for (int i = 0; i < word.NeedTaskInfos.Count; i++)
		{
			if (DomainManager.World.IsExtraTaskInProgress(word.NeedTaskInfos[i]))
			{
				return true;
			}
		}
		return false;
	}
}
