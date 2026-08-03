using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionShixiangFightMember1 : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		DomainManager.LifeRecord.GetLifeRecordCollection();
		character.GetId();
		DomainManager.World.GetCurrDate();
		character.GetLocation();
		Character targetChar = actionData.TargetChar;
		AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, character, targetChar, CombatType.Beat, isGroupCombat: false);
		if ((uint)(combatResultType - 2) <= 1u)
		{
			DomainManager.Character.SimulateCharacterCombatResult(context, character, targetChar, -40, -20, 0);
		}
		else
		{
			DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, character, -40, -20, 0);
		}
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
