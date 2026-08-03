using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GainExpByStrollAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ExpGain = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ExpGain" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int ExpGain;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		ExpGain = DomainManager.Character.CalcExpGain(character.GetInteractionGrade(), 100);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		character.ChangeExp(context, ExpGain);
		DomainManager.LifeRecord.GetLifeRecordCollection().AddGainExpByStroll(selfCharId, currDate, location);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*(int*)num = ExpGain;
		int totalSize = (int)(num + 4 - pData);
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
			ExpGain = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
