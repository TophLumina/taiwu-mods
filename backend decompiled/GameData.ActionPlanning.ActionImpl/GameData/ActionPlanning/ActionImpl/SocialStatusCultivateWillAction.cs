using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusCultivateWillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		if (targetChar.GetId() != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return false;
		}
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (!character.GetLocation().Equals(taiwu.GetLocation()))
		{
			return false;
		}
		if (taiwu.GetResource(6) < 10000)
		{
			return false;
		}
		return true;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddAdviseWinPeopleSupport(selfCharId, location, actionData.TargetCharId);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		throw new Exception($"targetChar {actionData.TargetChar.GetId()} has to be Taiwu {DomainManager.Taiwu.GetTaiwuCharId()}.");
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
