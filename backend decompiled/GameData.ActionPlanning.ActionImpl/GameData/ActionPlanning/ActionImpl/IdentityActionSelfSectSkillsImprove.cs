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
public class IdentityActionSelfSectSkillsImprove : ICharacterActionImpl, ISerializableGameData
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
		character.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		var (combatSkillBook, lifeSkillBook) = Equipping.SelectSectSkillBookToRead(character);
		if (combatSkillBook != null)
		{
			int actualCount = 0;
			for (int i = 0; i < 5; i++)
			{
				(int, byte) readingInfo = character.GetCombatSkillBookCurrReadingInfo(combatSkillBook);
				if (readingInfo.Item2 >= 6)
				{
					break;
				}
				character.ReadBookPage(context, combatSkillBook, readingInfo.Item2);
				actualCount++;
			}
			if (actualCount > 0)
			{
				lifeRecordCollection.AddIdentityActionLearnSkill(charId, location, actualCount, 10, combatSkillBook.GetTemplateId(), actionData.Template);
			}
		}
		if (lifeSkillBook == null)
		{
			return;
		}
		int actualCount2 = 0;
		for (int j = 0; j < 5; j++)
		{
			(int, byte) readingInfo2 = character.GetLifeSkillBookCurrReadingInfo(lifeSkillBook);
			if (readingInfo2.Item2 >= 5)
			{
				break;
			}
			character.ReadBookPage(context, lifeSkillBook, readingInfo2.Item2);
			actualCount2++;
		}
		if (actualCount2 > 0)
		{
			lifeRecordCollection.AddIdentityActionLearnSkill(charId, location, actualCount2, 10, lifeSkillBook.GetTemplateId(), actionData.Template);
		}
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem selfLifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		if (selfLifeRecordCfg.CheckParameterCount(3) && selfLifeRecordCfg.Parameters[0] == "Location" && selfLifeRecordCfg.Parameters[1] == "Integer")
		{
			return selfLifeRecordCfg.Parameters[2] == "Item";
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
