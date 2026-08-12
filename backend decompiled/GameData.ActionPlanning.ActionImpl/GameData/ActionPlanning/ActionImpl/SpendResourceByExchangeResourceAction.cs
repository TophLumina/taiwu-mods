using System;
using System.Collections.Generic;
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
public class SpendResourceByExchangeResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SpentResourceType = 0;

		public const ushort SpentResourceAmount = 1;

		public const ushort GainResourceType = 2;

		public const ushort GainResourceAmount = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "SpentResourceType", "SpentResourceAmount", "GainResourceType", "GainResourceAmount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte SpentResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int SpentResourceAmount;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte GainResourceType;

	[SerializableGameDataField(FieldIndex = 3)]
	public int GainResourceAmount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte spentResourceType = argGroup.ResourceType;
		int amount = character.GetResource(spentResourceType) - argGroup.Amount;
		if (amount <= 0)
		{
			return false;
		}
		Span<int> neededResources = stackalloc int[8];
		neededResources.Fill(0);
		bool hasNeededResourceType = false;
		IReadOnlyList<CharacterGoalData> goals = character.GetGoals();
		for (int index = goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = goals[index];
			if (goal.Match(236))
			{
				sbyte needResourceType = goal.Args.ResourceType;
				int needAmount = goal.Args.Amount;
				if (needResourceType != spentResourceType)
				{
					neededResources[needResourceType] = Math.Max(0, needAmount - character.GetResource(needResourceType));
					if (neededResources[needResourceType] > 0)
					{
						hasNeededResourceType = true;
					}
				}
			}
		}
		sbyte gainResourceType = (sbyte)(hasNeededResourceType ? ((sbyte)RandomUtils.GetRandomIndex(neededResources, context.Random)) : 6);
		if (spentResourceType == gainResourceType)
		{
			return false;
		}
		int gainAmount = neededResources[gainResourceType];
		int spentAmount = gainAmount * GlobalConfig.ResourcesWorth[gainResourceType] * 2 / GlobalConfig.ResourcesWorth[spentResourceType];
		if (spentAmount > amount || !hasNeededResourceType)
		{
			spentAmount = amount;
			gainAmount = spentAmount * GlobalConfig.ResourcesWorth[spentResourceType] / (2 * GlobalConfig.ResourcesWorth[gainResourceType]);
		}
		SpentResourceType = spentResourceType;
		SpentResourceAmount = spentAmount;
		GainResourceType = gainResourceType;
		GainResourceAmount = gainAmount;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (character.IsInRegularSettlementRange())
		{
			return character.GetResource(SpentResourceType) >= SpentResourceAmount;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		character.ChangeResource(context, SpentResourceType, -SpentResourceAmount);
		character.ChangeResource(context, GainResourceType, GainResourceAmount);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetValidLocation();
		lifeRecordCollection.AddExchangeResource(location: DomainManager.Map.GetBelongSettlementBlock(location).GetLocation(), selfCharId: character.GetId(), date: currDate, charId: -1, resourceType: SpentResourceType, value: SpentResourceAmount, resourceType1: GainResourceType, value1: GainResourceAmount);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*num = (byte)SpentResourceType;
		byte* num2 = num + 1;
		*(int*)num2 = SpentResourceAmount;
		byte* num3 = num2 + 4;
		*num3 = (byte)GainResourceType;
		byte* num4 = num3 + 1;
		*(int*)num4 = GainResourceAmount;
		int totalSize = (int)(num4 + 4 - pData);
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
			SpentResourceType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			SpentResourceAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			GainResourceType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			GainResourceAmount = *(int*)pCurrData;
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
