using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GainExpByPlayCombatAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		int charId = character.GetId();
		int relatedCharId = targetChar.GetId();
		if (DomainManager.Character.TryGetRelation(charId, relatedCharId, out var _) && !character.NeedToAvoidCombat(CombatType.Play))
		{
			return !targetChar.NeedToAvoidCombat(CombatType.Play);
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (!character.NeedToAvoidCombat(CombatType.Play))
		{
			return !actionData.TargetChar.NeedToAvoidCombat(CombatType.Play);
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddRequestPlayCombat(selfCharId, location, targetCharId);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		if (actionData.TargetCharId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Character.SimulateCharacterCombat(context, character, actionData.TargetChar, CombatType.Play, isGroupCombat: false);
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
