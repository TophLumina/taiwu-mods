using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionCivilianConflict : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		character.GetId();
		DomainManager.LifeRecord.GetLifeRecordCollection();
		character.GetId();
		DomainManager.World.GetCurrDate();
		character.GetLocation();
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
