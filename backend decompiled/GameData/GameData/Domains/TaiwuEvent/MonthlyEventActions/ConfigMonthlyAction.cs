using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Domains.TaiwuEvent.EventManager;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public class ConfigMonthlyAction : MonthlyActionBase, ISerializableGameData, IRecordArgumentSource
{
	[SerializableGameDataField]
	public short ConfigTemplateId;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public List<CharacterSet> MajorCharacterSets;

	[SerializableGameDataField]
	public List<CharacterSet> ParticipatingCharacterSets;

	[SerializableGameDataField]
	private sbyte _announceMonth;

	[SerializableGameDataField]
	private short _assignedAreaId;

	public MonthlyActionsItem ConfigData => MonthlyActions.Instance[ConfigTemplateId];

	public ConfigMonthlyAction(short templateId, short assignedAreaId = -1)
	{
		Key = new MonthlyActionKey(0, templateId);
		ConfigTemplateId = templateId;
		State = 0;
		MajorCharacterSets = new List<CharacterSet>();
		ParticipatingCharacterSets = new List<CharacterSet>();
		Location = Location.Invalid;
		_assignedAreaId = assignedAreaId;
	}

	public ConfigMonthlyAction(MonthlyActionKey key, short templateId, short assignedAreaId = -1)
	{
		Key = key;
		ConfigTemplateId = templateId;
		State = 0;
		MajorCharacterSets = new List<CharacterSet>();
		ParticipatingCharacterSets = new List<CharacterSet>();
		Location = Location.Invalid;
		_assignedAreaId = assignedAreaId;
	}

	public override bool IsMonthMatch()
	{
		return ConfigData.EnterMonthList.Count == 0 || ConfigData.EnterMonthList.Contains(DomainManager.World.GetCurrMonthInYear());
	}

	public override void TriggerAction()
	{
		Month = 0;
		ClearCalledCharacters();
		if (Location.IsValid())
		{
			if (DomainManager.Adventure.TryCreateAdventureSite(DomainManager.TaiwuEvent.MainThreadDataContext, Location.AreaId, Location.BlockId, ConfigData.AdventureId, Key))
			{
				MonthlyEventActionsManager.NewlyTriggered++;
				State = 1;
			}
			else
			{
				Location = Location.Invalid;
			}
		}
	}

	public override void MonthlyHandler()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (ConfigData.MinInterval <= 0 && State == 0)
		{
			return;
		}
		if (State == 0 && IsMonthMatch() && MonthlyEventActionsManager.ConfigItemTriggerCheck(ConfigTemplateId, this))
		{
			if (LastFinishDate + ConfigData.MinInterval >= DomainManager.World.GetCurrDate())
			{
				return;
			}
			SelectLocation();
			TriggerAction();
		}
		bool timeIsUp = ConfigData.PreparationDuration > 0 && Month >= ConfigData.PreparationDuration - ConfigData.PreannouncingTime;
		if (State == 1)
		{
			CallMajorCharacters();
			CallParticipateCharacters();
		}
		if (State == 2)
		{
			CallParticipateCharacters();
		}
		sbyte state = State;
		bool flag = (uint)(state - 2) <= 2u;
		if (flag && (timeIsUp || ConfigData.CanActionBeforehand) && (ConfigData.AllowTemporaryMajorCharacter || CallCharacterHelper.IsAllCharactersAtLocation(Location, ConfigData.MajorTargetFilterList, MajorCharacterSets)) && (ConfigData.AllowTemporaryParticipateCharacter || CallCharacterHelper.IsAllCharactersAtLocation(Location, ConfigData.ParticipateTargetFilterList, ParticipatingCharacterSets)))
		{
			if (State != 4)
			{
				if (ConfigData.PreannouncingTime <= 0)
				{
					State = 5;
					Activate();
				}
				else
				{
					State = 4;
					_announceMonth = 0;
					MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
					monthlyNotificationCollection.AddConfigMonthlyActionAnnouncementNotification(ConfigData, this, ConfigData.PreannouncingTime);
				}
			}
			else
			{
				_announceMonth++;
				if (_announceMonth >= ConfigData.PreannouncingTime)
				{
					State = 5;
					Activate();
				}
				else
				{
					MonthlyNotificationCollection monthlyNotificationCollection2 = DomainManager.World.GetMonthlyNotificationCollection();
					monthlyNotificationCollection2.AddConfigMonthlyActionAnnouncementNotification(ConfigData, this, ConfigData.PreannouncingTime - _announceMonth);
				}
			}
		}
		if (State > 0 && State <= 3 && timeIsUp)
		{
			if (ConfigData.AdventureId >= 0 && Location.IsValid())
			{
				DomainManager.Adventure.RemoveAdventureSite(context, Location.AreaId, Location.BlockId, isTimeout: true, isComplete: false);
			}
			else
			{
				Deactivate(isComplete: false);
			}
		}
		ValidationHandler();
		if (State != 0)
		{
			Month++;
		}
	}

	public override void Activate()
	{
		if (ConfigData.AdventureId >= 0)
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			MonthlyEventActionsManager.NewlyActivated++;
			DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
		}
		MonthlyEventActionsManager.ConfigItemOnActivate(ConfigTemplateId, this);
	}

	public override void Deactivate(bool isComplete)
	{
		MonthlyEventActionsManager.ConfigItemOnDeactivate(this, isComplete);
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		Location = Location.Invalid;
		ClearCalledCharacters();
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public void ClearCalledCharacters()
	{
		CallCharacterHelper.ClearCalledCharacters(MajorCharacterSets, !ConfigData.MajorTargetMoveVisible, removeExternalState: true);
		CallCharacterHelper.ClearCalledCharacters(ParticipatingCharacterSets, unHideCharacters: false, removeExternalState: true);
	}

	public override void EnsurePrerequisites()
	{
		int removedMajorCharCount = CallCharacterHelper.RemoveInvalidCharacters(ConfigData.MajorTargetFilterList, MajorCharacterSets, Location);
		if (removedMajorCharCount > 0)
		{
			AdaptableLog.TagWarning("ConfigMonthlyAction", $"{ConfigData.Name}{Key} at {Location} removed {removedMajorCharCount} major characters that are invalid");
		}
		int removedParticipateCharCount = CallCharacterHelper.RemoveInvalidCharacters(ConfigData.ParticipateTargetFilterList, ParticipatingCharacterSets, Location);
		if (removedParticipateCharCount > 0)
		{
			AdaptableLog.TagWarning("ConfigMonthlyAction", $"{ConfigData.Name}{Key} at {Location} removed {removedParticipateCharCount} participate characters that are invalid");
		}
		if (!ConfigData.AllowTemporaryMajorCharacter && !CallCharacterHelper.IsAllCharactersAtLocation(Location, ConfigData.MajorTargetFilterList, MajorCharacterSets))
		{
			CallMajorCharacters();
		}
		if (!ConfigData.AllowTemporaryParticipateCharacter && !CallCharacterHelper.IsAllCharactersAtLocation(Location, ConfigData.ParticipateTargetFilterList, ParticipatingCharacterSets))
		{
			CallParticipateCharacters();
		}
		State = 5;
	}

	public override void ValidationHandler()
	{
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		AdaptableLog.Info("Adding major characters to adventure.");
		for (int majorCharSetIndex = 0; majorCharSetIndex < ConfigData.MajorTargetFilterList.Length; majorCharSetIndex++)
		{
			CharacterFilterRequirement filterReq = ConfigData.MajorTargetFilterList[majorCharSetIndex];
			CharacterSet majorCharSet = ((majorCharSetIndex < MajorCharacterSets.Count) ? MajorCharacterSets[majorCharSetIndex] : default(CharacterSet));
			FillIntelligentCharactersToArgBox(eventArgBox, $"MajorCharacter_{majorCharSetIndex}", majorCharSet, filterReq, ConfigData.AllowTemporaryMajorCharacter);
			AdventureCharacterSortUtils.Sort(eventArgBox, isMajorChar: true, majorCharSetIndex, CharacterSortType.CombatPower, ascendingOrder: false);
		}
		AdaptableLog.Info("Adding participating characters to adventure.");
		for (int participateCharSetIndex = 0; participateCharSetIndex < ConfigData.ParticipateTargetFilterList.Length; participateCharSetIndex++)
		{
			CharacterFilterRequirement filterReq2 = ConfigData.ParticipateTargetFilterList[participateCharSetIndex];
			CharacterSet participateCharSet = ((participateCharSetIndex < ParticipatingCharacterSets.Count) ? ParticipatingCharacterSets[participateCharSetIndex] : default(CharacterSet));
			FillIntelligentCharactersToArgBox(eventArgBox, $"ParticipateCharacter_{participateCharSetIndex}", participateCharSet, filterReq2, ConfigData.AllowTemporaryParticipateCharacter);
			AdventureCharacterSortUtils.Sort(eventArgBox, isMajorChar: false, participateCharSetIndex, CharacterSortType.CombatPower, ascendingOrder: false);
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		if (ConfigData.MinInterval <= 0 && Key.ActionType == 0)
		{
			MajorCharacterSets.ForEach(delegate(CharacterSet charSet)
			{
				charSet.Clear();
			});
			ParticipatingCharacterSets.ForEach(delegate(CharacterSet charSet)
			{
				charSet.Clear();
			});
			MajorCharacterSets.Clear();
			ParticipatingCharacterSets.Clear();
			return;
		}
		foreach (CharacterSet majorCharacterSet in MajorCharacterSets)
		{
			calledCharacters.UnionWith(majorCharacterSet.GetCollection());
		}
		foreach (CharacterSet participatingCharacterSet in ParticipatingCharacterSets)
		{
			calledCharacters.UnionWith(participatingCharacterSet.GetCollection());
		}
	}

	private void FillIntelligentCharactersToArgBox(EventArgBox eventArgBox, string keyPrefix, CharacterSet charSet, CharacterFilterRequirement filterReq, bool allowTempChars)
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
				if (filterReq.HasMaximum() && amountAdded >= filterReq.MaxCharactersRequired)
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
		if (allowTempChars)
		{
			AdaptableLog.Info($"creating {Math.Max(0, filterReq.MinCharactersRequired - amountAdded)} temporary characters.");
			for (; amountAdded < filterReq.MinCharactersRequired; amountAdded++)
			{
				short ruleId = filterReq.CharacterFilterRuleIds[context.Random.Next(0, filterReq.CharacterFilterRuleIds.Length)];
				GameData.Domains.Character.Character character2 = DomainManager.Character.CreateTemporaryIntelligentCharacter(context, ruleId, Location);
				int charId2 = character2.GetId();
				eventArgBox.Set($"{keyPrefix}_{amountAdded}", charId2);
			}
		}
		eventArgBox.Set(keyPrefix + "_Count", amountAdded);
	}

	private void CallMajorCharacters()
	{
		if (Location.IsValid() && CallCharacterHelper.CallCharacters(Location, ConfigData.CharacterSearchRange, ConfigData.MajorTargetFilterList, MajorCharacterSets, ConfigData.AllowTemporaryMajorCharacter, modifyExternalState: true, !ConfigData.MajorTargetMoveVisible, OnMajorCharacterCalled))
		{
			State = 2;
		}
	}

	private void CallParticipateCharacters()
	{
		if (Location.IsValid() && CallCharacterHelper.CallCharacters(Location, ConfigData.CharacterSearchRange, ConfigData.ParticipateTargetFilterList, ParticipatingCharacterSets, ConfigData.AllowTemporaryParticipateCharacter, modifyExternalState: true))
		{
			State = 3;
		}
	}

	private void OnMajorCharacterCalled(DataContext context, GameData.Domains.Character.Character character)
	{
		if (ConfigData.IsEnemyNest)
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int charId = character.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			lifeRecordCollection.AddEnterEnemyNest(charId, currDate, Location, ConfigData.AdventureId);
		}
	}

	public void SelectLocation()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		MapBlockData blockData = ((_assignedAreaId < 0) ? DomainManager.Map.GetRandomMapBlockDataByFilters(context.Random, ConfigData.MapState, ConfigData.MapArea, ConfigData.MapBlockSubType, includeBlockWithAdventure: false) : DomainManager.Map.GetRandomMapBlockDataInAreaByFilters(context.Random, _assignedAreaId, ConfigData.MapBlockSubType, includeBlocksWithAdventure: false));
		if (blockData != null)
		{
			Location.AreaId = blockData.AreaId;
			Location.BlockId = blockData.BlockId;
		}
		else
		{
			Location.AreaId = -1;
			Location.BlockId = -1;
		}
	}

	public short GetSettlementArg()
	{
		MapBlockData belongSettlementBlock = DomainManager.Map.GetBelongSettlementBlock(Location);
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(belongSettlementBlock.GetLocation());
		return settlement.GetId();
	}

	public Location GetLocationArg()
	{
		return Location;
	}

	public int GetCharacterArg()
	{
		if (MajorCharacterSets.Count < 1)
		{
			return -1;
		}
		HashSet<int> collection = MajorCharacterSets[0].GetCollection();
		if (collection.Count < 1)
		{
			return -1;
		}
		return collection.First();
	}

	public short GetAdventureArg()
	{
		return ConfigData.AdventureId;
	}

	public sbyte GetLifeSkillTypeArg()
	{
		return ConfigMonthlyActionDefines.MonthlyActionToLifeSkillType[ConfigTemplateId];
	}

	public ConfigMonthlyAction()
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
		int totalSize = 21;
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
		*(short*)pCurrData = ConfigTemplateId;
		pCurrData += 2;
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
		*pCurrData = (byte)_announceMonth;
		pCurrData++;
		*(short*)pCurrData = _assignedAreaId;
		pCurrData += 2;
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
		ConfigTemplateId = *(short*)pCurrData;
		pCurrData += 2;
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
		_announceMonth = (sbyte)(*pCurrData);
		pCurrData++;
		_assignedAreaId = *(short*)pCurrData;
		pCurrData += 2;
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
