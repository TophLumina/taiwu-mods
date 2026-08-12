using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionTeachCivilians : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private const int MaxReadPageCount = 5;

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		PlanningActionItem actionTemplate = actionData.Template;
		lifeRecordCollection.AddIdentityActionCommonSelf(charId, location, actionTemplate);
		int[] targetCharIds = actionData.TargetCharIds;
		foreach (int targetCharId in targetCharIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(targetCharId, out var target))
			{
				continue;
			}
			var (bestCombatSkillBook, bestLifeSkillBook) = Equipping.SelectSectSkillBookToRead(character);
			if (bestCombatSkillBook != null)
			{
				int actualCount = 0;
				for (int j = 0; j < 5; j++)
				{
					(int, byte) readingInfo = target.GetCombatSkillBookCurrReadingInfo(bestCombatSkillBook);
					if (readingInfo.Item2 >= 6)
					{
						break;
					}
					character.ReadBookPage(context, bestCombatSkillBook, readingInfo.Item2);
					actualCount++;
				}
				if (actualCount > 0)
				{
					lifeRecordCollection.AddIdentityActionShaolin5Target(targetCharId, currDate, charId, location, actualCount, 10, bestCombatSkillBook.GetTemplateId());
				}
			}
			if (bestLifeSkillBook == null)
			{
				continue;
			}
			int actualCount2 = 0;
			for (int k = 0; k < 5; k++)
			{
				(int, byte) readingInfo2 = target.GetLifeSkillBookCurrReadingInfo(bestLifeSkillBook);
				if (readingInfo2.Item2 >= 5)
				{
					break;
				}
				character.ReadBookPage(context, bestLifeSkillBook, readingInfo2.Item2);
				actualCount2++;
			}
			if (actualCount2 > 0)
			{
				lifeRecordCollection.AddIdentityActionHelpLearnSkillTarget(targetCharId, charId, location, actualCount2, 10, bestLifeSkillBook.GetTemplateId(), actionTemplate);
			}
		}
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0 || config.ExecuteTargetLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem selfLifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		LifeRecordItem targetLifeRecordCfg = LifeRecord.Instance[config.ExecuteTargetLifeRecord];
		if (selfLifeRecordCfg.CheckParameterCount(1) && selfLifeRecordCfg.Parameters[0] == "Location" && targetLifeRecordCfg.CheckParameterCount(4) && targetLifeRecordCfg.Parameters[0] == "Character" && targetLifeRecordCfg.Parameters[1] == "Location" && targetLifeRecordCfg.Parameters[2] == "Integer")
		{
			return targetLifeRecordCfg.Parameters[3] == "Item";
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 0;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_ = *(ushort*)pData;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
