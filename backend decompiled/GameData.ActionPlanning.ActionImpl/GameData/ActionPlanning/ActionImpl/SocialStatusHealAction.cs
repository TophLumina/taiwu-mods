using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusHealAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Type = 0;

		public const ushort HerbAmount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Type", "HerbAmount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int Type;

	[SerializableGameDataField(FieldIndex = 1)]
	public int HerbAmount;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		CombatResources usableCombatResources = DomainManager.Character.GetUsableCombatResources(character.GetId());
		int herbAmount = character.GetResource(5);
		foreach (EHealActionType type in Character.AllHealActions)
		{
			if (character.CalcHealAttainment(type) >= 200 && usableCombatResources.Get(type) > 0 && targetChar.NeedHealAction(type) && targetChar.CalcHealCostHerb(type) <= herbAmount)
			{
				return true;
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		int herbAmount = character.GetResource(5);
		if (character.GetResource(5) < GlobalConfig.Instance.HealInjuryBaseHerb)
		{
			return false;
		}
		CombatResources usableCombatResources = DomainManager.Character.GetUsableCombatResources(character.GetId());
		SpanList<EHealActionType> actionTypes = stackalloc EHealActionType[4];
		foreach (EHealActionType type in Character.AllHealActions)
		{
			if (character.CalcHealAttainment(type) >= 200 && usableCombatResources.Get(type) > 0)
			{
				actionTypes.Add(type);
			}
		}
		if (actionTypes.Count == 0)
		{
			return false;
		}
		CollectionUtils.Shuffle(context.Random, actionTypes);
		Character selectedChar = actionData.TargetChar;
		SpanList<EHealActionType>.Enumerator enumerator2 = actionTypes.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			EHealActionType type2 = enumerator2.Current;
			if (selectedChar.NeedHealAction(type2) && selectedChar.CalcHealCostHerb(type2) <= herbAmount)
			{
				Type = (int)type2;
				HerbAmount = selectedChar.CalcHealCostHerb(type2);
				return true;
			}
		}
		return false;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return character.GetResource(5) >= HerbAmount;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		switch ((EHealActionType)Type)
		{
		case EHealActionType.Healing:
			monthlyEventCollection.AddAdviseHealInjury(selfCharId, location, targetCharId, HerbAmount);
			break;
		case EHealActionType.Detox:
			monthlyEventCollection.AddAdviseHealPoison(selfCharId, location, targetCharId, HerbAmount);
			break;
		case EHealActionType.Breathing:
			monthlyEventCollection.AddAdviseHealDisorderOfQi(selfCharId, location, targetCharId, HerbAmount);
			break;
		case EHealActionType.Recover:
			monthlyEventCollection.AddAdviseHealHealth(selfCharId, location, targetCharId, HerbAmount);
			break;
		}
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		character.ChangeResource(context, 5, HerbAmount);
		DomainManager.Character.UseCombatResources(context, selfCharId, (EHealActionType)Type, 1);
		if (character.DoHealAction(context, (EHealActionType)Type, targetChar))
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, 3000);
		}
		lifeRecordCollection.AddCureSucceed(selfCharId, currDate, targetCharId, location);
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddCure(selfCharId, targetCharId);
		DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(int*)num = Type;
		byte* num2 = num + 4;
		*(int*)num2 = HerbAmount;
		int totalSize = (int)(num2 + 4 - pData);
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
			Type = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			HerbAmount = *(int*)pCurrData;
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
