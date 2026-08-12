using System;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class JoinSectAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SettlementId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "SettlementId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short SettlementId;

	public int PhaseCount => 1;

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(argGroup.OrgTemplateId);
		SettlementId = settlement.GetId();
		actionData.TargetLocation = settlement.GetLocation();
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void OnStart(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			int selfCharId = selfChar.GetId();
			Location currLocation = selfChar.GetLocation();
			lifeRecordCollection.AddDecideToJoinSect(selfCharId, currDate, currLocation, SettlementId);
			if (DomainManager.Character.IsTaiwuPeople(selfCharId))
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddGoToJoinOrganization(selfCharId, SettlementId);
			}
		}
	}

	public void OnInterrupt(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int selfCharId = selfChar.GetId();
		lifeRecordCollection.AddJoinSectFail(selfCharId, currDate, SettlementId);
	}

	public bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		if (Organization.Instance[selfOrgInfo.OrgTemplateId].IsSect)
		{
			return true;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(SettlementId);
		OrganizationInfo targetOrgInfo = new OrganizationInfo(settlement.GetOrgTemplateId(), 0, principal: true, SettlementId);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(targetOrgInfo);
		sbyte selfGender = selfChar.GetGender();
		if (!OrganizationDomain.MeetGenderRestriction(targetOrgInfo.OrgTemplateId, selfGender))
		{
			return false;
		}
		if (orgMemberCfg.Gender >= 0 && orgMemberCfg.Gender != selfGender)
		{
			return false;
		}
		if (orgMemberCfg != null)
		{
			sbyte[] childGrade = orgMemberCfg.ChildGrade;
			if (childGrade != null && childGrade.Length > 0)
			{
				goto IL_00b9;
			}
		}
		if (DomainManager.Character.GetAliveSpouse(selfChar.GetId()) >= 0 || DomainManager.Character.GetAliveChild(selfChar.GetId()) >= 0)
		{
			return false;
		}
		goto IL_00b9;
		IL_00b9:
		int successRate = GetJoinOrgSuccessRate(context.Random, selfChar, targetOrgInfo);
		if (!context.Random.CheckPercentProb(successRate))
		{
			return false;
		}
		DomainManager.Organization.JoinSect(context, selfChar, targetOrgInfo);
		int selfCharId = selfChar.GetId();
		if (DomainManager.Character.IsTaiwuPeople(selfCharId))
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddJoinOrganization(selfCharId, SettlementId);
		}
		return true;
	}

	private unsafe int GetJoinOrgSuccessRate(IRandomSource random, GameData.Domains.Character.Character selfChar, OrganizationInfo targetOrgInfo)
	{
		int score = 0;
		OrganizationItem orgCfg = Organization.Instance[targetOrgInfo.OrgTemplateId];
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(targetOrgInfo);
		int combatSkillScore = 0;
		int scoredCombatSkillTypeCount = 0;
		CombatSkillShorts combatSkillQualifications = selfChar.GetCombatSkillQualifications();
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			short adjust = orgMemberCfg.CombatSkillsAdjust[combatSkillType];
			if (adjust >= 6)
			{
				combatSkillScore += combatSkillQualifications.Items[combatSkillType] * adjust / 12;
				scoredCombatSkillTypeCount++;
			}
		}
		if (scoredCombatSkillTypeCount > 0)
		{
			score += combatSkillScore / scoredCombatSkillTypeCount;
		}
		int lifeSkillScore = 0;
		int scoredLifeSkillTypeCount = 0;
		LifeSkillShorts lifeSkillQualifications = selfChar.GetLifeSkillQualifications();
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			short adjust2 = orgMemberCfg.LifeSkillsAdjust[lifeSkillType];
			if (adjust2 >= 6)
			{
				lifeSkillScore += lifeSkillQualifications.Items[lifeSkillType] * adjust2 / 12;
				scoredLifeSkillTypeCount++;
			}
		}
		if (scoredLifeSkillTypeCount > 0)
		{
			score += lifeSkillScore / scoredLifeSkillTypeCount;
		}
		int mainAttrScore = 0;
		int scoredMainAttributeTypeCount = 0;
		MainAttributes mainAttributes = selfChar.GetMaxMainAttributes();
		for (sbyte mainAttrType = 0; mainAttrType < 6; mainAttrType++)
		{
			short adjust3 = orgMemberCfg.MainAttributesAdjust[mainAttrType];
			if (adjust3 >= 6)
			{
				mainAttrScore += mainAttributes.Items[mainAttrType] * adjust3 / 12;
				scoredMainAttributeTypeCount++;
			}
		}
		if (scoredMainAttributeTypeCount > 0)
		{
			score += mainAttrScore / scoredMainAttributeTypeCount;
		}
		sbyte charFameType = selfChar.GetFameType();
		if (charFameType == -2)
		{
			charFameType = (sbyte)(random.NextBool() ? 4 : 2);
		}
		int num = score;
		score = num + orgCfg.Goodness switch
		{
			1 => 25 * (charFameType - 3), 
			0 => 75 - 25 * Math.Abs(charFameType - 3), 
			-1 => 25 * (3 - charFameType), 
			_ => 0, 
		};
		sbyte charBehaviorType = selfChar.GetBehaviorType();
		sbyte orgBehaviorType = GameData.Domains.Character.BehaviorType.GetBehaviorType(orgCfg.Goodness);
		if (charBehaviorType == orgBehaviorType)
		{
			score += 50;
		}
		else if (GameData.Domains.Character.BehaviorType.IsContradictory(charBehaviorType, orgBehaviorType))
		{
			score -= 50;
		}
		return score / 5;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(short*)num = SettlementId;
		int totalSize = (int)(num + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			SettlementId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
