using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[SerializableGameData(NotForDisplayModule = true)]
[Obsolete]
public class CallCharacterMonthlyAction : MonthlyActionBase, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public List<CharacterSet> MajorCharacterSets;

	[SerializableGameDataField]
	public List<CharacterSet> ParticipatingCharacterSets;

	public CallCharacterHelper.SearchCharacterRule MajorCharacterSearchRule;

	public CallCharacterHelper.SearchCharacterRule ParticipateCharacterSearchRule;

	public PreparationRule PreparationRule;

	public short AdventureTemplateId;

	public Action<CallCharacterMonthlyAction> OnWaitTrigger;

	public Action<CallCharacterMonthlyAction> OnTrigger;

	public override void TriggerAction()
	{
		if (State == 0 && Location.IsValid())
		{
			State = 1;
			if (AdventureTemplateId >= 0 && !DomainManager.Adventure.TryCreateAdventureSite(DomainManager.TaiwuEvent.MainThreadDataContext, Location.AreaId, Location.BlockId, AdventureTemplateId, Key))
			{
				State = 0;
				Location = Location.Invalid;
			}
			else
			{
				OnTrigger?.Invoke(this);
			}
		}
	}

	public override void MonthlyHandler()
	{
		if (State == 0)
		{
			OnWaitTrigger?.Invoke(this);
			return;
		}
		bool timeIsUp = PreparationRule.PreparationDuration > 0 && Month >= PreparationRule.PreparationDuration;
		if (State == 1)
		{
			CallMajorCharacters();
			if (MajorCharacterSearchRule.AllowTemporaryCharacter || CallCharacterHelper.IsAllCharactersAtLocation(Location, MajorCharacterSearchRule, MajorCharacterSets))
			{
				CallParticipateCharacters();
			}
		}
		if (State == 2)
		{
			CallParticipateCharacters();
		}
		if (State == 3 && (timeIsUp || PreparationRule.CanStartEarly))
		{
			if (ParticipateCharacterSearchRule.AllowTemporaryCharacter || CallCharacterHelper.IsAllCharactersAtLocation(Location, ParticipateCharacterSearchRule, ParticipatingCharacterSets))
			{
				Activate();
			}
			else if (timeIsUp)
			{
				Deactivate(isComplete: false);
			}
		}
		if (State != 0)
		{
			Month++;
		}
	}

	public override void Activate()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (AdventureTemplateId >= 0)
		{
			MonthlyEventActionsManager.NewlyActivated++;
			DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
		}
		State = 5;
	}

	public override void InheritNonArchiveData(MonthlyActionBase action)
	{
		if (!(action is CallCharacterMonthlyAction callCharacterMonthlyAction))
		{
			AdaptableLog.TagWarning("CallCharacterMonthlyAction", $"fail to inherit action {action} with key {action.Key} due to invalid type.", appendWarningMessage: true);
		}
		else
		{
			PreparationRule = callCharacterMonthlyAction.PreparationRule;
			MajorCharacterSearchRule = callCharacterMonthlyAction.MajorCharacterSearchRule;
			ParticipateCharacterSearchRule = callCharacterMonthlyAction.ParticipateCharacterSearchRule;
			AdventureTemplateId = callCharacterMonthlyAction.AdventureTemplateId;
		}
	}

	public override void EnsurePrerequisites()
	{
		int removedMajorCharCount = CallCharacterHelper.RemoveInvalidCharacters(MajorCharacterSearchRule, MajorCharacterSets);
		if (removedMajorCharCount > 0)
		{
			AdaptableLog.TagWarning("ConfigMonthlyAction", $"{Key} removed {removedMajorCharCount} major characters that are invalid");
		}
		int removedParticipateCharCount = CallCharacterHelper.RemoveInvalidCharacters(ParticipateCharacterSearchRule, ParticipatingCharacterSets);
		if (removedParticipateCharCount > 0)
		{
			AdaptableLog.TagWarning("ConfigMonthlyAction", $"{Key} removed {removedParticipateCharCount} participate characters that are invalid");
		}
		if (!MajorCharacterSearchRule.AllowTemporaryCharacter && !CallCharacterHelper.IsAllCharactersAtLocation(Location, MajorCharacterSearchRule, MajorCharacterSets))
		{
			CallMajorCharacters();
		}
		if (!ParticipateCharacterSearchRule.AllowTemporaryCharacter && !CallCharacterHelper.IsAllCharactersAtLocation(Location, ParticipateCharacterSearchRule, ParticipatingCharacterSets))
		{
			CallParticipateCharacters();
		}
		State = 5;
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public void ClearCalledCharacters()
	{
		CallCharacterHelper.ClearCalledCharacters(MajorCharacterSets, unHideCharacters: false, removeExternalState: true);
		CallCharacterHelper.ClearCalledCharacters(ParticipatingCharacterSets, unHideCharacters: false, removeExternalState: true);
	}

	private void CallMajorCharacters()
	{
		if (Location.IsValid() && CallCharacterHelper.CallCharacters(Location, MajorCharacterSearchRule, MajorCharacterSets, modifyExternalState: true))
		{
			State = 2;
		}
	}

	private void CallParticipateCharacters()
	{
		if (Location.IsValid() && CallCharacterHelper.CallCharacters(Location, ParticipateCharacterSearchRule, ParticipatingCharacterSets, modifyExternalState: true))
		{
			State = 3;
		}
	}

	private void FillIntelligentCharactersToArgBox(EventArgBox eventArgBox, string keyPrefix, CharacterSet charSet, CallCharacterHelper.SearchCharacterSubRule searchSubRule, bool allowTempChars)
	{
		int amountAdded = 0;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		foreach (int charId in charSet.GetCollection())
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			if (character.IsCrossAreaTraveling())
			{
				DomainManager.Character.GroupMove(context, character, Location);
			}
			if (character.GetLocation().Equals(Location))
			{
				if (searchSubRule.MaxAmount > 0 && amountAdded >= searchSubRule.MaxAmount)
				{
					Events.RaiseCharacterLocationChanged(context, charId, character.GetLocation(), Location);
					character.SetLocation(Location, context);
					continue;
				}
				eventArgBox.Set($"{keyPrefix}_{amountAdded}", charId);
				amountAdded++;
			}
		}
		AdaptableLog.Info($"Adding {amountAdded} real characters to adventure.");
		if (allowTempChars && searchSubRule.CreateTemporaryCharacterFunc != null)
		{
			AdaptableLog.Info($"creating {Math.Max(0, searchSubRule.MinAmount - amountAdded)} temporary characters.");
			for (; amountAdded < searchSubRule.MinAmount; amountAdded++)
			{
				int charId2 = searchSubRule.CreateTemporaryCharacterFunc(context);
				eventArgBox.Set($"{keyPrefix}_{amountAdded}", charId2);
			}
		}
		eventArgBox.Set(keyPrefix + "_Count", amountAdded);
	}

	public CallCharacterMonthlyAction()
	{
		MajorCharacterSets = new List<CharacterSet>();
		ParticipatingCharacterSets = new List<CharacterSet>();
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 16;
		if (MajorCharacterSets != null)
		{
			totalSize += 2;
			int elementsCount = MajorCharacterSets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += MajorCharacterSets[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ParticipatingCharacterSets != null)
		{
			totalSize += 2;
			int elementsCount2 = ParticipatingCharacterSets.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				totalSize += ParticipatingCharacterSets[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Serialize(pCurrData);
		if (MajorCharacterSets != null)
		{
			int elementsCount = MajorCharacterSets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = MajorCharacterSets[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ParticipatingCharacterSets != null)
		{
			int elementsCount2 = ParticipatingCharacterSets.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int subDataSize2 = ParticipatingCharacterSets[j].Serialize(pCurrData);
				pCurrData += subDataSize2;
				Tester.Assert(subDataSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Key.Serialize(pCurrData);
		*pCurrData = (byte)State;
		pCurrData++;
		*(int*)pCurrData = Month;
		pCurrData += 4;
		*(int*)pCurrData = LastFinishDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (MajorCharacterSets == null)
			{
				MajorCharacterSets = new List<CharacterSet>(elementsCount);
			}
			else
			{
				MajorCharacterSets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterSet element = default(CharacterSet);
				pCurrData += element.Deserialize(pCurrData);
				MajorCharacterSets.Add(element);
			}
		}
		else
		{
			MajorCharacterSets?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ParticipatingCharacterSets == null)
			{
				ParticipatingCharacterSets = new List<CharacterSet>(elementsCount2);
			}
			else
			{
				ParticipatingCharacterSets.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterSet element2 = default(CharacterSet);
				pCurrData += element2.Deserialize(pCurrData);
				ParticipatingCharacterSets.Add(element2);
			}
		}
		else
		{
			ParticipatingCharacterSets?.Clear();
		}
		pCurrData += Key.Deserialize(pCurrData);
		State = (sbyte)(*pCurrData);
		pCurrData++;
		Month = *(int*)pCurrData;
		pCurrData += 4;
		LastFinishDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
