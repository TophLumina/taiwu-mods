using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Config;
using GameData.Adventure;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.World;

namespace GameData.Domains.TaiwuEvent;

internal class TaiwuEventTagHandler
{
	private static readonly Regex TagRegex = new Regex("<(?!(/)?color|(/)?size|(/)?link).*?/>");

	private static readonly Regex TagNameRegex = new Regex("<(?<TagName>(?!(/)?color|(/)?size|(/)?link)[a-z|A-Z]+)( +)?");

	private static readonly Regex PairRegex = new Regex("(?<Name>(?!(/)?color|(/)?size|(/)?link)[a-z|A-Z]+)( +)?=( +)?(?<Value>\"[^\"]*\"|[\\w]+)");

	private static Dictionary<string, string> _pairInfos = new Dictionary<string, string>();

	private static EventArgBox _argBox;

	private static TaiwuEvent _handlingEvent;

	private static Dictionary<string, string[]> _basicSingleGenderMap = new Dictionary<string, string[]>
	{
		{
			"Gender",
			new string[2] { "LK_Common_She", "LK_Common_He" }
		},
		{
			"GenderSubject",
			new string[2] { "LK_Common_She", "LK_Common_He" }
		},
		{
			"GenderObject",
			new string[2] { "LK_Common_Her", "LK_Common_Him" }
		},
		{
			"GenderPossessive",
			new string[2] { "LK_Common_Hers", "LK_Common_His" }
		},
		{
			"UpperGenderSubject",
			new string[2] { "LK_Common_UpperShe", "LK_Common_UpperHe" }
		},
		{
			"UpperGenderObject",
			new string[2] { "LK_Common_UpperHer", "LK_Common_UpperHim" }
		},
		{
			"UpperGenderPossessive",
			new string[2] { "LK_Common_UpperHers", "LK_Common_UpperHis" }
		},
		{
			"ChildGender",
			new string[2] { "LK_Gender_Child_She", "LK_Gender_Child_He" }
		},
		{
			"AgedGender",
			new string[2] { "LK_Gender_Aged_She", "LK_Gender_Aged_He" }
		},
		{
			"AdultGender",
			new string[2] { "LK_Common_Woman", "LK_Common_Man" }
		},
		{
			"AdoptiveParent",
			new string[2] { "LK_Relation_StepParent_Mother", "LK_Relation_StepParent_Father" }
		},
		{
			"AdoptiveChild",
			new string[2] { "LK_Relation_StepChild_Daughter", "LK_Relation_StepChild_Son" }
		},
		{
			"HusbandOrWife",
			new string[2] { "LK_Relation_Bride", "LK_Relation_Groom" }
		},
		{
			"GenderRanXinduSpecial",
			new string[2] { "LK_Gender_RanXinduSpecial_She", "LK_Gender_RanXinduSpecial_He" }
		}
	};

	private static List<string[]> _autoAgeGender = new List<string[]>
	{
		new string[2] { "LK_Gender_Young_She", "LK_Gender_Young_He" },
		new string[2] { "LK_Gender_Adult_She", "LK_Gender_Adult_He" },
		new string[2] { "LK_Gender_Old_She", "LK_Gender_Old_He" }
	};

	public static List<string[]> _taiwuCrossArchiveAgeGender = new List<string[]>
	{
		new string[2] { "LK_Gender_Child_She", "LK_Gender_Child_He" },
		new string[2] { "LK_Common_Woman", "LK_Common_Man" },
		new string[2] { "LK_Gender_Old_She", "LK_Gender_Old_He" }
	};

	private static Dictionary<ushort, string[]> _relationGenderMap = new Dictionary<ushort, string[]>
	{
		{
			1,
			new string[2] { "LK_Relation_BloodParent_Mother", "LK_Relation_BloodParent_Father" }
		},
		{
			2,
			new string[2] { "LK_Relation_BloodChild_Daughter", "LK_Relation_BloodChild_Son" }
		},
		{
			8,
			new string[2] { "LK_Relation_StepParent_Mother", "LK_Relation_StepParent_Father" }
		},
		{
			16,
			new string[2] { "LK_Relation_StepChild_Daughter", "LK_Relation_StepChild_Son" }
		}
	};

	public static string[] FiveElementTypeName = new string[6] { "LK_FiveElements_Type_0", "LK_FiveElements_Type_1", "LK_FiveElements_Type_2", "LK_FiveElements_Type_3", "LK_FiveElements_Type_4", "LK_FiveElements_Type_5" };

	public static string[] PersonalityTypeName = new string[7] { "LK_Personality_Calm_Name", "LK_Personality_Clever_Name", "LK_Personality_Enthusiastic_Name", "LK_Personality_Brave_Name", "LK_Personality_Firm_Name", "LK_Personality_Lucky_Name", "LK_Personality_Perceptive_Name" };

	private const string BabyLanguageKey = "LK_Baby";

	private const string YoungMaleLanguageKey = "LK_Boy";

	private const string YoungFemaleLanguageKey = "LK_Girl";

	public static string DecodeTag(string targetString, EventArgBox box, TaiwuEvent handlingEvent)
	{
		if (string.IsNullOrEmpty(targetString))
		{
			return targetString;
		}
		_argBox = box;
		_handlingEvent = handlingEvent;
		string result = TagRegex.Replace(targetString, delegate(Match tagMatch)
		{
			_pairInfos.Clear();
			string value = tagMatch.Value;
			MatchCollection matchCollection = PairRegex.Matches(value);
			foreach (Match match in matchCollection)
			{
				if (match.Groups.Count >= 3)
				{
					_pairInfos.Add(match.Groups["Name"].Value, TrimQuotationMarks(match.Groups["Value"].Value));
				}
			}
			MatchCollection matchCollection2 = TagNameRegex.Matches(value);
			string text = string.Empty;
			for (int i = 0; i < matchCollection2.Count; i++)
			{
				Match match2 = matchCollection2[i];
				string value2 = match2.Groups["TagName"].Value;
				if (value2 != "color")
				{
					text = value2;
					break;
				}
			}
			return (string)(string.IsNullOrEmpty(text) ? value : ((text switch
			{
				"Character" => DecodeCharacter(), 
				"TemplateCharacter" => DecodeTemplateCharacter(), 
				"CharacterOrActor" => DecodeCharacterOrActor(), 
				"Item" => DecodeItem(), 
				"CombatSkillType" => DecodeCombatSkillType(), 
				"CombatSkill" => DecodeCombatSkill(), 
				"LifeSkillType" => DecodeLifeSkillType(), 
				"LifeSkill" => DecodeLifeSkill(), 
				"ArgBox" => DecodeArgBox(), 
				"Actor" => DecodeActor(), 
				"Resource" => DecodeResource(), 
				"NormalInfo" => DecodeNormalInformation(), 
				"SecretInfo" => DecodeSecretInformation(), 
				"Settlement" => DecodeSettlement(), 
				"MapArea" => DecodeMapArea(), 
				"MapState" => DecodeMapState(), 
				"MapBlockName" => DecodeMapBlockName(), 
				"General" => DecodeGeneral(), 
				"Gender" => DecodeGender(), 
				"JiaoLoong" => DecodeJiaoLoong(), 
				"JiaoNurturance" => DecodeJiaoNurturance(), 
				"SkillBook" => DecodeSkillBook(), 
				"CricketName" => DecodeCricketName(), 
				"FiveElement" => DecodeFiveElementName(), 
				"PersonalityType" => DecodePersonalityTypeName(), 
				"Chicken" => DecodeChickenName(), 
				"Organization" => DecodeOrganizationName(), 
				"OrganizationMember" => DecodeOrganizationMemberName(), 
				"Profession" => DecodeProfession(), 
				"Merchant" => DecodeMerchant(), 
				"SwordGrave" => DecodeSwordGrave(), 
				"AdventureAtLocation" => DecodeAdventureAtLocation(), 
				"CharacterTitle" => DecodeCharacterTitle(), 
				"AdventureRemake" => DecodeAdventureRemake(), 
				"SpecialName" => DecodeSpecialName(), 
				_ => value, 
			}) ?? Error("DecodeTag", text)));
		});
		_argBox = null;
		_handlingEvent = null;
		_pairInfos.Clear();
		return result;
	}

	private static string TrimQuotationMarks(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		return value.Trim('"');
	}

	private static string DecodeCricketName()
	{
		if (_pairInfos.TryGetValue("key", out var itemKeyString))
		{
			short colorId = 0;
			short partId = 0;
			if (_argBox.Get(itemKeyString + "_colorId", ref colorId) && _argBox.Get(itemKeyString + "_partId", ref partId))
			{
				sbyte grade = ItemTemplateHelper.GetCricketGrade(colorId, partId);
				return $"<color=#GradeColor_{grade}><Cricket part={partId} color={colorId}/></color>";
			}
			return ErrorNoFieldName("DecodeCricketName");
		}
		return ErrorNoKey("DecodeCricketName");
	}

	private static string DecodeGender()
	{
		string languageKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeGender", out languageKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		sbyte gender = 1;
		if (!_argBox.Get(languageKey, ref gender))
		{
			return Error("DecodeGender", languageKey);
		}
		string text = strKey;
		string text2 = text;
		if (text2 == "Gender")
		{
			return "<Language Key=" + _basicSingleGenderMap[strKey][gender] + "/>";
		}
		return Error("DecodeGender", strKey);
	}

	private static string DecodeArgBox()
	{
		if (!_pairInfos.TryGetValue("key", out var argKey))
		{
			return ErrorNoKey("DecodeArgBox");
		}
		if (!_pairInfos.TryGetValue("type", out var argType))
		{
			return ErrorNoFieldName("DecodeArgBox");
		}
		switch (argType)
		{
		case "int":
		{
			int arg2 = 0;
			if (_argBox.Get(argKey, ref arg2))
			{
				return arg2.ToString();
			}
			break;
		}
		case "float":
		{
			float arg3 = 0f;
			if (_argBox.Get(argKey, ref arg3))
			{
				return arg3.ToString(CultureInfo.CurrentCulture);
			}
			break;
		}
		case "string":
		{
			string arg = string.Empty;
			if (_argBox.Get(argKey, ref arg))
			{
				return arg.Replace("<NL>", "\n");
			}
			break;
		}
		}
		return Error("DecodeArgBox", argType);
	}

	private static string DecodeTemplateCharacter()
	{
		string characterKey = _pairInfos["key"];
		short templateId = -1;
		if (!_argBox.Get(characterKey, ref templateId))
		{
			return Error("DecodeTemplateCharacter", characterKey);
		}
		CharacterItem config = Config.Character.Instance[templateId];
		if (config == null)
		{
			return Error("DecodeTemplateCharacter", characterKey);
		}
		string attrKey = _pairInfos["str"];
		string text = attrKey;
		string text2 = text;
		if (text2 == "Name")
		{
			if (GameData.Domains.World.SharedMethods.SmallVillageXiangshu(config.OrganizationInfo.OrgTemplateId, includeXiangshuInfected: false))
			{
				return config.AnonymousTitle;
			}
			return config.Surname + config.GivenName;
		}
		return Error("DecodeTemplateCharacter", attrKey);
	}

	private static string DecodeCharacter()
	{
		string characterKey;
		string attrKey;
		string error = TryGetTagKeyAndValueStr("DecodeCharacter", out characterKey, out attrKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		GameData.Domains.Character.Character character = _argBox.GetCharacter(characterKey);
		DeadCharacter deadCharacter = null;
		int charId = -1;
		if (character == null)
		{
			if (_argBox.Get(characterKey, ref charId))
			{
				deadCharacter = DomainManager.Character.GetDeadCharacter(charId);
			}
		}
		else
		{
			charId = character.GetId();
		}
		if (character == null && deadCharacter == null)
		{
			return Error("DecodeCharacter", characterKey);
		}
		sbyte gender = character?.GetGender() ?? deadCharacter.Gender;
		AvatarData avatarData = ((character != null) ? character.GetAvatar() : deadCharacter.Avatar);
		switch (attrKey)
		{
		case "Name":
			return DomainManager.Character.GetName(charId);
		case "Gender":
		case "ChildGender":
		case "AgedGender":
		case "AdultGender":
		case "AdoptiveParent":
		case "AdoptiveChild":
		case "HusbandOrWife":
		case "GenderSubject":
		case "GenderObject":
		case "GenderPossessive":
		case "UpperGenderSubject":
		case "UpperGenderObject":
		case "UpperGenderPossessive":
		case "GenderRanXinduSpecial":
			return "<Language Key=" + _basicSingleGenderMap[attrKey][gender] + "/>";
		case "AutoAgeGender":
		{
			short age2 = character?.GetPhysiologicalAge() ?? deadCharacter.GetActualAge();
			sbyte ageLevel = 0;
			if (age2 >= 16)
			{
				ageLevel = 1;
			}
			if (age2 >= GlobalConfig.Instance.AgeShowWrinkle2)
			{
				ageLevel = 2;
			}
			return "<Language Key=" + _autoAgeGender[ageLevel][gender] + "/>";
		}
		case "Relation":
		{
			if (_pairInfos.TryGetValue("relationKey", out var relationKey))
			{
				GameData.Domains.Character.Character targetChar = _argBox.GetCharacter(relationKey);
				if (targetChar != null && character != null && DomainManager.Character.TryGetRelation(character.GetId(), targetChar.GetId(), out var relatedChar) && _relationGenderMap.TryGetValue(relatedChar.RelationType, out var relationValueArray))
				{
					return "<Language Key=" + relationValueArray[targetChar.GetGender()] + "/>";
				}
			}
			break;
		}
		case "OrgName":
		{
			OrganizationInfo orgInfo2 = character?.GetOrganizationInfo() ?? deadCharacter.OrganizationInfo;
			OrganizationItem configItem = Config.Organization.Instance.GetItem(orgInfo2.OrgTemplateId);
			if (configItem != null)
			{
				return configItem.Name;
			}
			break;
		}
		case "AreaName":
		{
			OrganizationInfo orgInfo3 = character?.GetOrganizationInfo() ?? deadCharacter.OrganizationInfo;
			Location location = DomainManager.Organization.GetSettlement(orgInfo3.SettlementId).GetLocation();
			return DomainManager.Map.GetStateAndAreaNameByAreaId(location.AreaId).areaName;
		}
		case "CurAreaName":
			if (character != null)
			{
				Location locationCurrent = character.GetLocation();
				if (character.IsTaiwu() && !locationCurrent.IsValid())
				{
					locationCurrent = character.GetValidLocation();
				}
				return DomainManager.Map.GetStateAndAreaNameByAreaId(locationCurrent.AreaId).areaName;
			}
			break;
		case "SettlementName":
		{
			OrganizationInfo orgInfo4 = character?.GetOrganizationInfo() ?? deadCharacter.OrganizationInfo;
			if (orgInfo4.SettlementId < 0)
			{
				return Config.Organization.Instance[(sbyte)0].Name;
			}
			Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo4.SettlementId);
			short randomNameId = (short)((settlement is CivilianSettlement cs) ? cs.GetRandomNameId() : (-1));
			MapBlockData block = DomainManager.Map.GetBlock(settlement.GetLocation()).GetRootBlock();
			return (randomNameId != -1) ? LocalTownNames.Instance.TownNameCore[randomNameId].Name : ((block.TemplateId != -1) ? MapBlock.Instance[block.TemplateId].Name : Config.Organization.Instance[(sbyte)0].Name);
		}
		case "Identity":
		{
			short age = character?.GetCurrAge() ?? deadCharacter.GetActualAge();
			OrganizationInfo orgInfo = character?.GetOrganizationInfo() ?? deadCharacter.OrganizationInfo;
			OrganizationMemberItem memberConfig = OrganizationDomain.GetOrgMemberConfig(orgInfo);
			if (memberConfig != null)
			{
				if (age >= memberConfig.IdentityActiveAge)
				{
					string identityString = (orgInfo.Principal ? memberConfig.GradeName : memberConfig.SpouseAnonymousTitles[gender]);
					return $"<color=#GradeColor_{orgInfo.Grade}>{identityString}</color>";
				}
				if (AgeGroup.GetAgeGroup(age) == 0)
				{
					return "<Language Key=LK_Baby/>";
				}
				if (gender == 1)
				{
					return "<Language Key=LK_Boy/>";
				}
				return "<Language Key=LK_Girl/>";
			}
			break;
		}
		case "CurBlock":
			if (character != null)
			{
				Location location2 = character.GetLocation();
				if (!location2.IsValid())
				{
					location2 = character.GetValidLocation();
				}
				MapBlockItem config6 = DomainManager.Map.GetBlock(location2).GetConfig();
				return config6.Name;
			}
			break;
		case "BodyType":
		{
			AvatarHeadItem headItem = AvatarManager.Instance.GetAsset(avatarData.AvatarId, EAvatarElementsType.Head, avatarData.HeadId).HeadConfig;
			if (headItem != null)
			{
				return headItem.DisplayDesc;
			}
			break;
		}
		case "ClothColor":
		{
			AvatarClothColorsItem clothColorItem = AvatarClothColors.Instance.GetItem(avatarData.ColorClothId);
			if (clothColorItem != null)
			{
				return clothColorItem.DisplayDesc;
			}
			break;
		}
		case "ClothName":
			if (character != null)
			{
				short templateId = character.GetTemplateId();
				CharacterItem config5 = Config.Character.Instance[templateId];
				return Config.Clothing.Instance[config5.PresetEquipment[4].TemplateId].Name;
			}
			break;
		case "SkinColor":
		{
			AvatarSkinColorsItem colorItem3 = AvatarSkinColors.Instance.GetItem(avatarData.ColorSkinId);
			if (colorItem3 != null)
			{
				return colorItem3.DisplayDesc;
			}
			break;
		}
		case "LipColor":
		{
			AvatarLipColorsItem colorItem2 = AvatarLipColors.Instance.GetItem(avatarData.ColorMouthId);
			if (colorItem2 != null)
			{
				return colorItem2.DisplayDesc;
			}
			break;
		}
		case "FrontHairColor":
		{
			AvatarHairColorsItem colorItem = AvatarHairColors.Instance.GetItem(avatarData.ColorFrontHairId);
			if (colorItem != null)
			{
				return colorItem.DisplayDesc;
			}
			break;
		}
		case "BackHairColor":
		{
			AvatarHairColorsItem colorItem10 = AvatarHairColors.Instance.GetItem(avatarData.ColorBackHairId);
			if (colorItem10 != null)
			{
				return colorItem10.DisplayDesc;
			}
			break;
		}
		case "Beard1Color":
		{
			AvatarHairColorsItem colorItem9 = AvatarHairColors.Instance.GetItem(avatarData.ColorBeard1Id);
			if (colorItem9 != null)
			{
				return colorItem9.DisplayDesc;
			}
			break;
		}
		case "Beard2Color":
		{
			AvatarHairColorsItem colorItem8 = AvatarHairColors.Instance.GetItem(avatarData.ColorBeard2Id);
			if (colorItem8 != null)
			{
				return colorItem8.DisplayDesc;
			}
			break;
		}
		case "EyeBrowColor":
		{
			AvatarHairColorsItem colorItem7 = AvatarHairColors.Instance.GetItem(avatarData.ColorEyebrowId);
			if (colorItem7 != null)
			{
				return colorItem7.DisplayDesc;
			}
			break;
		}
		case "EyeballColor":
		{
			AvatarEyeballColorsItem colorItem6 = AvatarEyeballColors.Instance.GetItem(avatarData.ColorEyeballId);
			if (colorItem6 != null)
			{
				return colorItem6.DisplayDesc;
			}
			break;
		}
		case "Feature1Color":
		{
			AvatarFeatureColorsItem colorItem5 = AvatarFeatureColors.Instance.GetItem(avatarData.ColorFeature1Id);
			if (colorItem5 != null)
			{
				return colorItem5.DisplayDesc;
			}
			break;
		}
		case "Feature2Color":
		{
			AvatarFeatureColorsItem colorItem4 = AvatarFeatureColors.Instance.GetItem(avatarData.ColorFeature2Id);
			if (colorItem4 != null)
			{
				return colorItem4.DisplayDesc;
			}
			break;
		}
		case "NicknameOfTaiwu":
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			_handlingEvent.NeedNameRelatedDataCharacterIdList.Add(taiwuCharId);
			return $"<CharNickname Id={taiwuCharId} />";
		}
		case "Profession":
		{
			ProfessionData currProfession = DomainManager.Character.GetCharacterCurrentProfession(charId);
			if (currProfession != null)
			{
				return currProfession.GetConfig().Name;
			}
			break;
		}
		case "TwelveImmortalsTreasureDesc":
		{
			if (character == null)
			{
				return string.Empty;
			}
			short characterTemplateId4 = character.GetTemplateId();
			foreach (TwelveImmortalsItem config4 in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
			{
				if (config4.Character == characterTemplateId4)
				{
					return config4.TreasureDesc;
				}
			}
			break;
		}
		case "TwelveImmortalsTreasureName":
		{
			if (character == null)
			{
				return string.Empty;
			}
			short characterTemplateId3 = character.GetTemplateId();
			foreach (TwelveImmortalsItem config3 in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
			{
				if (config3.Character == characterTemplateId3)
				{
					return config3.TreasureName;
				}
			}
			break;
		}
		case "TwelveImmortalsTreasureState0":
		{
			if (character == null)
			{
				return string.Empty;
			}
			short characterTemplateId2 = character.GetTemplateId();
			foreach (TwelveImmortalsItem config2 in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
			{
				if (config2.Character == characterTemplateId2)
				{
					return config2.TreasureState0;
				}
			}
			break;
		}
		case "TwelveImmortalsTreasureState1":
		{
			if (character == null)
			{
				return string.Empty;
			}
			short characterTemplateId = character.GetTemplateId();
			foreach (TwelveImmortalsItem config in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
			{
				if (config.Character == characterTemplateId)
				{
					return config.TreasureState1;
				}
			}
			break;
		}
		}
		return Error("DecodeCharacter", attrKey);
	}

	private static string DecodeItem()
	{
		sbyte itemType = 0;
		short templateId = 0;
		if (_pairInfos.TryGetValue("key", out var itemKeyString))
		{
			if (!_argBox.Get(itemKeyString, out ItemKey itemKey))
			{
				return Error("DecodeItem", itemKeyString);
			}
			itemType = itemKey.ItemType;
			templateId = itemKey.TemplateId;
		}
		else
		{
			if (!_pairInfos.TryGetValue("type", out var itemTypeString) || !_pairInfos.TryGetValue("id", out var itemId))
			{
				return ErrorNoKey("DecodeItem");
			}
			if (!ItemType.TypeName2TypeId.TryGetValue(itemTypeString, out itemType))
			{
				return Error("DecodeItem", itemTypeString);
			}
			if (!short.TryParse(itemId, out templateId))
			{
				return Error("DecodeItem", itemId);
			}
		}
		string result = string.Empty;
		if (_pairInfos.TryGetValue("str", out var strKey))
		{
			if (itemType == 11 && !string.IsNullOrEmpty(itemKeyString) && _argBox.Get(itemKeyString, out ItemKey itemKey2))
			{
				if (!(DomainManager.Item.GetBaseItem(itemKey2) is GameData.Domains.Item.Cricket cricket))
				{
					return "{Cricket decode error}";
				}
				string text = strKey;
				string text2 = text;
				if (!(text2 == "Name"))
				{
					if (text2 == "ColorName")
					{
						sbyte grade = ItemTemplateHelper.GetGrade(itemType, templateId);
						result = $"<color=#GradeColor_{grade}><Cricket part={cricket.GetPartId()} color={cricket.GetColorId()}/></color>";
					}
				}
				else
				{
					result = $"<Cricket part={cricket.GetPartId()} color={cricket.GetColorId()}/>";
				}
			}
			else
			{
				string text3 = strKey;
				string text4 = text3;
				if (!(text4 == "Name"))
				{
					if (text4 == "ColorName")
					{
						sbyte grade2 = ItemTemplateHelper.GetGrade(itemType, templateId);
						string name = ItemTemplateHelper.GetName(itemType, templateId);
						result = $"<color=#GradeColor_{grade2}>{name}</color>";
					}
				}
				else
				{
					result = ItemTemplateHelper.GetName(itemType, templateId);
				}
			}
		}
		if (_pairInfos.TryGetValue("sp", out var itemSprite))
		{
			string text5 = itemSprite;
			string text6 = text5;
			if (text6 == "Icon")
			{
				result = result + "<SpName=\"" + ItemTemplateHelper.GetIcon(itemType, templateId) + "\"";
			}
		}
		return result;
	}

	private static string DecodeCombatSkill()
	{
		string skillIdKey = _pairInfos["key"];
		short combatSKillId = -1;
		if (!_argBox.Get(skillIdKey, ref combatSKillId))
		{
			return Error("DecodeCombatSkill", skillIdKey);
		}
		CombatSkillItem configItem = Config.CombatSkill.Instance.GetItem(combatSKillId);
		string attrKey = _pairInfos["str"];
		switch (attrKey)
		{
		case "SkillName":
			if (configItem != null)
			{
				return $"《<color=#GradeColor_{configItem.Grade}>{configItem.Name}</color>》";
			}
			break;
		case "SkillDesc":
			if (configItem != null)
			{
				return configItem.Desc;
			}
			break;
		case "TypeName":
		{
			CombatSkillTypeItem typeConfigItem = CombatSkillType.Instance.GetItem(configItem.Type);
			if (typeConfigItem != null)
			{
				return typeConfigItem.Name;
			}
			break;
		}
		case "SkillBookName":
		{
			SkillBookItem bookConfig = Config.SkillBook.Instance[configItem.BookId];
			if (bookConfig != null)
			{
				return $"<color=#GradeColor_{bookConfig.Grade}>{bookConfig.Name}</color>";
			}
			break;
		}
		}
		return Error("DecodeCombatSkill", attrKey);
	}

	private static string DecodeCombatSkillType()
	{
		if (!_pairInfos.TryGetValue("key", out var skillTypeKey))
		{
			return "{CombatSKillType key not find}";
		}
		sbyte combatSKillTypeId = -1;
		if (!_argBox.Get(skillTypeKey, ref combatSKillTypeId))
		{
			return Error("DecodeCombatSkillType", skillTypeKey);
		}
		CombatSkillTypeItem config = CombatSkillType.Instance.GetItem(combatSKillTypeId);
		string displayType = _pairInfos["str"];
		string text = displayType;
		string text2 = text;
		if (text2 == "Name" && config != null)
		{
			return config.Name;
		}
		return Error("DecodeCombatSkillType", displayType);
	}

	private static string DecodeLifeSkill()
	{
		string skillIdKey = _pairInfos["key"];
		short lifeSKillId = -1;
		if (!_argBox.Get(skillIdKey, ref lifeSKillId))
		{
			return Error("DecodeLifeSkill", skillIdKey);
		}
		Config.LifeSkillItem configItem = LifeSkill.Instance.GetItem(lifeSKillId);
		string strKey = _pairInfos["str"];
		switch (strKey)
		{
		case "SkillName":
			if (configItem != null)
			{
				return $"《<color=#GradeColor_{configItem.Grade}>{configItem.Name}</color>》";
			}
			break;
		case "SkillDesc":
			if (configItem != null)
			{
				return configItem.Desc;
			}
			break;
		case "TypeName":
		{
			LifeSkillTypeItem typeConfigItem = Config.LifeSkillType.Instance.GetItem(configItem.Type);
			if (typeConfigItem != null)
			{
				return typeConfigItem.Name;
			}
			break;
		}
		}
		return Error("DecodeLifeSkill", strKey);
	}

	private static string DecodeLifeSkillType()
	{
		if (!_pairInfos.TryGetValue("key", out var skillTypeKey))
		{
			return "{LifeSkillType key not find}";
		}
		sbyte lifeSkillTypeId = -1;
		if (!_argBox.Get(skillTypeKey, ref lifeSkillTypeId))
		{
			return Error("DecodeLifeSkillType", skillTypeKey);
		}
		LifeSkillTypeItem config = Config.LifeSkillType.Instance.GetItem(lifeSkillTypeId);
		string displayType = _pairInfos["str"];
		string text = displayType;
		string text2 = text;
		if (text2 == "Name" && config != null)
		{
			return config.Name;
		}
		return Error("DecodeLifeSkillType", displayType);
	}

	private static string DecodeCharacterOrActor()
	{
		string characterKey = _pairInfos["key"];
		if (_argBox.Contains<int>(characterKey))
		{
			return DecodeCharacter();
		}
		if (_argBox.Contains<EventActorData>(characterKey))
		{
			return DecodeActor();
		}
		return "{Unable to decode character or actor with key " + characterKey;
	}

	private static string DecodeActor()
	{
		string actorKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeActor", out actorKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		if (!_argBox.Get(actorKey, out EventActorData actor))
		{
			return Error("DecodeActor", actorKey);
		}
		switch (strKey)
		{
		case "Name":
			return actor.DisplayName;
		case "Age":
			return actor.Age.ToString();
		case "ChildGender":
		case "AdultGender":
			return "<Language Key=" + _basicSingleGenderMap[strKey][actor.Gender] + "/>";
		default:
			return Error("DecodeActor", strKey);
		}
	}

	private static string DecodeResource()
	{
		string resKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeResource", out resKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		int arg = 0;
		if (!_argBox.Get(resKey, ref arg))
		{
			return Error("DecodeResource", resKey);
		}
		ResourceTypeItem config = Config.ResourceType.Instance.GetItem((sbyte)arg);
		if (config == null)
		{
			return Error("DecodeResource", resKey);
		}
		string text = strKey;
		string text2 = text;
		if (text2 == "Name")
		{
			return config.Name;
		}
		return Error("DecodeResource", strKey);
	}

	private static string DecodeNormalInformation()
	{
		string resKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeNormalInformation", out resKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		if (!_argBox.Get(resKey, out NormalInformation normalInformation))
		{
			return Error("DecodeNormalInformation", resKey);
		}
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		InformationInfoItem infoConfig = InformationInfo.Instance.GetItem(config.InfoIds[normalInformation.Level]);
		switch (strKey)
		{
		case "Belong":
			if (config.Type == 0 || config.Type == 1)
			{
				OrganizationItem orgConfig = Config.Organization.Instance.GetItem(infoConfig.Oraganization);
				return orgConfig.Name;
			}
			if (config.Type == 2)
			{
				LifeSkillTypeItem lifeSkillTypeConfig = Config.LifeSkillType.Instance.GetItem(infoConfig.LifeSkillType);
				return lifeSkillTypeConfig.Name;
			}
			return "<Language Key=LK_InformationType_West/>";
		case "Desc":
			return infoConfig.Desc;
		case "AnsEffective":
			return infoConfig.EffectiveAnswer;
		case "AnsNormal":
			return infoConfig.NormalAnswer;
		case "AnsInvalid":
			return infoConfig.InvalidAnswer;
		default:
			return Error("DecodeNormalInformation", strKey);
		}
	}

	private static string DecodeSecretInformation()
	{
		return "{secret information decode error}";
	}

	private static string DecodeSettlement()
	{
		string settlementIdKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeSettlement", out settlementIdKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short settlementId = -1;
		if (!_argBox.Get(settlementIdKey, ref settlementId))
		{
			return Error("DecodeSettlement", settlementIdKey);
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		switch (strKey)
		{
		case "Name":
		{
			short randomNameId = (short)((settlement is CivilianSettlement cs) ? cs.GetRandomNameId() : (-1));
			MapBlockData block = DomainManager.Map.GetBlock(settlement.GetLocation()).GetRootBlock();
			string settlementName = ((randomNameId != -1) ? LocalTownNames.Instance.TownNameCore[randomNameId].Name : ((block.TemplateId != -1) ? MapBlock.Instance[block.TemplateId].Name : Config.Organization.Instance[(sbyte)0].Name));
			return $"<color=#GradeColor_{7}>{settlementName}</color>";
		}
		case "PrisonName":
		{
			OrganizationItem config = Config.Organization.Instance[settlement.GetOrgTemplateId()];
			return BuildingBlock.Instance[config.PrisonBuilding].Name;
		}
		case "TreasuryName":
		{
			sbyte orgTemplateId = settlement.GetOrgTemplateId();
			if (1 == 0)
			{
			}
			short num;
			switch (orgTemplateId)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
				num = (short)(settlement.GetOrgTemplateId() - 1 + 288);
				break;
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
				num = 284;
				break;
			case 36:
				num = 286;
				break;
			case 37:
				num = 285;
				break;
			case 38:
				num = 287;
				break;
			default:
				num = -1;
				break;
			}
			if (1 == 0)
			{
			}
			short buildingTemplateId = num;
			return BuildingBlock.Instance[buildingTemplateId].Name;
		}
		case "MapAreaName":
		{
			Location location2 = settlement.GetLocation();
			MapAreaData areaData = DomainManager.Map.GetElement_Areas(location2.AreaId);
			return areaData.GetConfig().Name;
		}
		case "MapStateName":
		{
			Location location = settlement.GetLocation();
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
			return MapState.Instance[stateTemplateId].Name;
		}
		default:
			return Error("DecodeSettlement", strKey);
		}
	}

	private static string DecodeMapArea()
	{
		string areaIdKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeMapArea", out areaIdKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short areaId = -1;
		if (_argBox.Get(areaIdKey, out MapAreaData mapAreaData))
		{
			areaId = mapAreaData.GetAreaId();
		}
		else if (!_argBox.Get(areaIdKey, ref areaId))
		{
			return Error("DecodeMapArea", areaIdKey);
		}
		string text = strKey;
		string text2 = text;
		if (!(text2 == "Name"))
		{
			if (text2 == "StateName")
			{
				return DomainManager.Map.GetStateAndAreaNameByAreaId(areaId).stateName;
			}
			return Error("DecodeMapArea", strKey);
		}
		string areaName = DomainManager.Map.GetStateAndAreaNameByAreaId(areaId).areaName;
		return $"<color=#GradeColor_{7}>{areaName}</color>";
	}

	private static string DecodeMapState()
	{
		string areaIdKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeMapState", out areaIdKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		sbyte areaId = -1;
		if (!_argBox.Get(areaIdKey, ref areaId))
		{
			return Error("DecodeMapState", areaIdKey);
		}
		string text = strKey;
		string text2 = text;
		if (text2 == "Name")
		{
			sbyte stateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
			return MapState.Instance[stateId].Name;
		}
		return Error("DecodeMapState", strKey);
	}

	public static string DecodeMapBlockName()
	{
		string locationKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeMapBlockName", out locationKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		Location location = Location.Invalid;
		if (!_argBox.Get(locationKey, out location))
		{
			return Error("DecodeMapBlockName", locationKey);
		}
		string text = strKey;
		string text2 = text;
		if (text2 == "Name")
		{
			if (!location.IsValid())
			{
				return MapBlock.Instance[117].Name;
			}
			return DomainManager.Map.GetBlock(location).GetConfig().Name;
		}
		return Error("DecodeMapBlockName", strKey);
	}

	private static string DecodeGeneral()
	{
		string languageKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeGeneral", out languageKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		switch (strKey)
		{
		case "ItemSubType":
			return "<Language Key=LK_ItemSubType_" + languageKey + "/>";
		case "BehaviorType":
			return "<Language Key=LK_Goodness_" + languageKey + "/>";
		case "UpperNum":
		{
			int grade = 1;
			_argBox.Get("Grade", ref grade);
			return $"<Language Key=LK_Num_{grade}/>";
		}
		case "CombatSkillOutlineType":
		{
			sbyte type = 0;
			_argBox.Get("CombatSkillOutlineType", ref type);
			return $"<Language Key=LK_CombatSkill_First_Page_Type_{type}/>";
		}
		default:
			return Error("DecodeGeneral", strKey);
		}
	}

	private static string DecodeJiaoLoong()
	{
		string jiaoLoongKey;
		string strKey;
		string error = TryGetTagKeyAndValueStr("DecodeJiaoLoong", out jiaoLoongKey, out strKey);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		int jiaoLoongId = -1;
		if (!_argBox.Get(jiaoLoongKey, ref jiaoLoongId))
		{
			return Error("DecodeJiaoLoong", jiaoLoongKey);
		}
		string text = strKey;
		string text2 = text;
		if (!(text2 == "JiaoLoongName"))
		{
			if (text2 == "ChildrenOfLoongLoongName")
			{
				string jiaoLoongName = string.Empty;
				if (DomainManager.Extra.TryGetElement_ChildrenOfLoong(jiaoLoongId, out var childrenOfLoong))
				{
					if (childrenOfLoong.NameId < 0)
					{
						jiaoLoongName = ItemTemplateHelper.GetName(childrenOfLoong.Key.ItemType, childrenOfLoong.Key.TemplateId);
					}
					else
					{
						IReadOnlyDictionary<int, string> customTexts = DomainManager.World.GetCustomTexts();
						if (customTexts.TryGetValue(childrenOfLoong.NameId, out var text3))
						{
							jiaoLoongName = text3;
						}
					}
				}
				return jiaoLoongName;
			}
			return Error("DecodeJiaoLoong", strKey);
		}
		string jiaoLoongName2 = string.Empty;
		if (DomainManager.Extra.TryGetElement_Jiaos(jiaoLoongId, out var jiao))
		{
			if (jiao.NameId < 0)
			{
				jiaoLoongName2 = ItemTemplateHelper.GetName(jiao.Key.ItemType, jiao.Key.TemplateId);
			}
			else
			{
				IReadOnlyDictionary<int, string> customTexts2 = DomainManager.World.GetCustomTexts();
				if (customTexts2.TryGetValue(jiao.NameId, out var text4))
				{
					jiaoLoongName2 = text4;
				}
			}
		}
		return jiaoLoongName2;
	}

	private static string DecodeJiaoNurturance()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeJiaoNurturance", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short configId = -1;
		if (!_argBox.Get(key, ref configId))
		{
			return Error("DecodeJiaoNurturance", key);
		}
		JiaoNurturanceItem config = JiaoNurturance.Instance[configId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeJiaoNurturance", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeSkillBook()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeCharacterTitle", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short configId = -1;
		if (!_argBox.Get(key, ref configId))
		{
			return Error("DecodeSkillBook", key);
		}
		SkillBookItem config = Config.SkillBook.Instance[configId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeSkillBook", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeFiveElementName()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeFiveElementName", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short fiveElementType = -1;
		if (!_argBox.Get(key, ref fiveElementType))
		{
			return Error("DecodeFiveElementName", key);
		}
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeFiveElementName", str) : ("<Language Key=" + FiveElementTypeName[fiveElementType] + "/>"));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodePersonalityTypeName()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodePersonalityTypeName", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short personalityType = -1;
		if (!_argBox.Get(key, ref personalityType))
		{
			return Error("DecodePersonalityTypeName", key);
		}
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodePersonalityTypeName", str) : ("<Language Key=" + PersonalityTypeName[personalityType] + "/>"));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeChickenName()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeChickenName", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short chickenTemplateId = -1;
		if (!_argBox.Get(key, ref chickenTemplateId))
		{
			return Error("DecodeChickenName", key);
		}
		ChickenItem config = Chicken.Instance[chickenTemplateId];
		if (1 == 0)
		{
		}
		string result = ((str == "Name") ? config.Name : ((!(str == "EventDesc")) ? Error("DecodeChickenName", str) : config.EventDesc));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeProfession()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeProfession", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short professionTemplateId = -1;
		if (!_argBox.Get(key, ref professionTemplateId))
		{
			return Error("DecodeProfession", key);
		}
		ProfessionItem config = Profession.Instance[professionTemplateId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeProfession", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeOrganizationName()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeOrganizationName", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short organizationTemplateId = -1;
		if (!_argBox.Get(key, ref organizationTemplateId))
		{
			return Error("DecodeOrganizationName", key);
		}
		OrganizationItem config = Config.Organization.Instance[organizationTemplateId];
		string text = str;
		string text2 = text;
		if (text2 == "Name" && config != null)
		{
			return config.Name;
		}
		return Error("DecodeOrganizationName", str);
	}

	private static string DecodeOrganizationMemberName()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeOrganizationMemberName", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short organizationMemberTemplateId = -1;
		if (!_argBox.Get(key, ref organizationMemberTemplateId))
		{
			return Error("DecodeOrganizationMemberName", key);
		}
		OrganizationMemberItem memberConfig = OrganizationMember.Instance[organizationMemberTemplateId];
		string text = str;
		string text2 = text;
		if (text2 == "Name" && memberConfig != null)
		{
			string identityString = memberConfig.GradeName;
			return $"<color=#GradeColor_{memberConfig.Grade}>{identityString}</color>";
		}
		return Error("DecodeOrganizationMemberName", str);
	}

	private static string DecodeMerchant()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeMerchant", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short merchantTypeTemplateId = -1;
		if (!_argBox.Get(key, ref merchantTypeTemplateId))
		{
			return Error("DecodeMerchant", key);
		}
		MerchantTypeItem config = MerchantType.Instance[merchantTypeTemplateId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "MerchantTypeName")) ? Error("DecodeMerchant", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeSwordGrave()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeSwordGrave", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		int adventureTemplateId = -1;
		if (!_argBox.Get(key, ref adventureTemplateId))
		{
			return Error("DecodeSwordGrave", key);
		}
		Config.AdventureItem config = Config.Adventure.Instance[adventureTemplateId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "SwordGraveName")) ? Error("DecodeSwordGrave", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeAdventureAtLocation()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeAdventureAtLocation", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		if (!_argBox.Get(key, out Location location))
		{
			return Error("DecodeAdventureAtLocation", key);
		}
		AdventureCacheData cache = DomainManager.Adventure.GetAdventureCache();
		AdventureBlockCacheData locationCache = cache.GetCacheData(location);
		if (locationCache == null || !locationCache.AnyAdventureOrMajorEvent)
		{
			return location.ToString();
		}
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeAdventureAtLocation", str) : (locationCache.AnyAdventure ? DomainManager.Adventure.GetElement_Adventures(locationCache.AdventureId).Core.Name : DomainManager.Adventure.GetElement_AdventureMajorEvents(locationCache.MajorEventId).Core.Name));
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeCharacterTitle()
	{
		string key;
		string str;
		string error = TryGetTagKeyAndValueStr("DecodeCharacterTitle", out key, out str);
		if (!string.IsNullOrEmpty(error))
		{
			return error;
		}
		short characterTitleTemplateId = -1;
		if (!_argBox.Get(key, ref characterTitleTemplateId))
		{
			return Error("DecodeCharacterTitle", key);
		}
		CharacterTitleItem config = CharacterTitle.Instance[characterTitleTemplateId];
		if (1 == 0)
		{
		}
		string result = ((!(str == "Name")) ? Error("DecodeCharacterTitle", str) : config.Name);
		if (1 == 0)
		{
		}
		return result;
	}

	private static string DecodeSpecialName()
	{
		if (!_pairInfos.TryGetValue("key", out var key))
		{
			return ErrorNoKey("DecodeSpecialName");
		}
		string text = key;
		string text2 = text;
		if (text2 == "AdoptiveFather")
		{
			List<int> previousTaiwuIds = DomainManager.Taiwu.GetPreviousTaiwuIds();
			return ((previousTaiwuIds != null && previousTaiwuIds.Count == 0) || DomainManager.Taiwu.GetPreviousTaiwuIds()[0] == DomainManager.Taiwu.GetTaiwuCharId()) ? LocalStringManager.Get(LanguageKey.Event_MainStory_FosterFather_DeepValleyTaiwu) : LocalStringManager.Get(LanguageKey.Event_MainStory_FosterFather_PassedLegacyTaiwu);
		}
		return Error("DecodeSpecialName", key);
	}

	private static string TryGetTagKeyAndValueStr(string methodName, out string key, out string str)
	{
		key = string.Empty;
		str = string.Empty;
		if (!_pairInfos.TryGetValue("key", out key))
		{
			return ErrorNoKey(methodName);
		}
		if (!_pairInfos.TryGetValue("str", out str))
		{
			return ErrorNoFieldName(methodName);
		}
		return string.Empty;
	}

	private static string ErrorNoFieldName(string methodName)
	{
		return "{ErrorNoFieldName: " + methodName + "}";
	}

	private static string ErrorNoKey(string methodName)
	{
		return "{ErrorNoKey: " + methodName + "}";
	}

	private static string Error(string methodName, string fieldName)
	{
		return (fieldName == null) ? ("{Error: " + methodName + "}") : $"{{Error: {methodName}, Field: {fieldName}}}";
	}

	private static string DecodeAdventureRemake()
	{
		string key = _pairInfos["key"];
		string strKey = _pairInfos["str"];
		int elementId = -1;
		if (_argBox.Get(key, ref elementId))
		{
			string text = strKey;
			string text2 = text;
			if (text2 == "ElementName")
			{
				int adventureId = -1;
				if (_argBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRemake))
				{
					AdventureElement element = adventureRemake.GetElement(elementId);
					AdventureElementData elementData = AdventureDomain.Core.GetAdventureElementData(element.CoreId);
					return elementData.Name;
				}
			}
		}
		return Error("DecodeAdventureRemake", strKey);
	}
}
