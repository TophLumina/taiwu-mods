using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionAwakening : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ImproveLifeSkillType = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ImproveLifeSkillType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private sbyte _improveLifeSkillType;

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		SpanList<sbyte> canImproveLifeSkillTypes = stackalloc sbyte[16];
		character.GetCanImproveLifeSkillTypes(ref canImproveLifeSkillTypes);
		if (canImproveLifeSkillTypes.Count == 0)
		{
			return false;
		}
		_improveLifeSkillType = canImproveLifeSkillTypes.GetRandom(context.Random);
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		character.ChangeBaseLifeSkillQualification(context, _improveLifeSkillType, 1);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		lifeRecordCollection.AddIdentityActionAwakeningLifeSkill(charId, location, _improveLifeSkillType, actionData.Template);
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem lifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		if (lifeRecordCfg.CheckParameterCount(2) && lifeRecordCfg.Parameters[0] == "Location")
		{
			return lifeRecordCfg.Parameters[1] == "LifeSkillType";
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
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
		*num = (byte)_improveLifeSkillType;
		int totalSize = (int)(num + 1 - pData);
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
			_improveLifeSkillType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
