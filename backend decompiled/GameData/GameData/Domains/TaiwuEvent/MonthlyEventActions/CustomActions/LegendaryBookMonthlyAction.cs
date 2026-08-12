using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventManager;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class LegendaryBookMonthlyAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public sbyte BookType;

	[SerializableGameDataField]
	public sbyte BookAppearType;

	[SerializableGameDataField]
	public int PrevOwnerId;

	[SerializableGameDataField]
	public sbyte ActivateDelay;

	[SerializableGameDataField]
	public List<CharacterSet> ParticipatingCharacterSets;

	private static List<CharacterSet> _tempCalledCharSets = new List<CharacterSet>();

	private const int ActivateDelayMin = 3;

	private const int ActivateDelayMax = 9;

	private static readonly CallCharacterHelper.SearchCharacterRule SearchRule = new CallCharacterHelper.SearchCharacterRule
	{
		AllowTemporaryCharacter = false,
		SearchRange = 2,
		SubRules = new List<CallCharacterHelper.SearchCharacterSubRule>
		{
			new CallCharacterHelper.SearchCharacterSubRule(0, 4, CheckCharacterAvailable, CheckSectLeaderAvailable)
		}
	};

	public short DynamicActionType => 1;

	public LegendaryBookMonthlyAction()
	{
		Key = MonthlyActionKey.Invalid;
		ParticipatingCharacterSets = new List<CharacterSet>();
		Location = Location.Invalid;
		BookType = -1;
		BookAppearType = -1;
		PrevOwnerId = -1;
	}

	public override void TriggerAction()
	{
		if (Location.IsValid() && BookType >= 0 && DomainManager.LegendaryBook.GetLegendaryBookItem(BookType).IsValid() && DomainManager.LegendaryBook.GetOwner(BookType) < 0)
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			int adventureId = AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures[BookType];
			if (DomainManager.Adventure.GenerateMajorEvent(context, adventureId, Location))
			{
				sbyte firstMonthDelay = DomainManager.LegendaryBook.GetFirstLegendaryBookDelay();
				bool isFirst = firstMonthDelay == 0;
				DomainManager.LegendaryBook.SetFirstLegendaryBookDelay(-1, context);
				MonthlyEventActionsManager.NewlyTriggered++;
				State = 1;
				ActivateDelay = (sbyte)((!isFirst) ? ((sbyte)context.Random.Next(3, 10)) : 0);
				AdaptableLog.TagInfo("LegendaryBookMonthlyAction", "Legendary book adventure " + AdventureDomain.Core.GetAdventureMajorEventData(adventureId).Name + " created at " + Location.ToString());
			}
			else
			{
				Location = Location.Invalid;
			}
		}
	}

	public override void MonthlyHandler()
	{
		if (State == 0)
		{
			if (!Location.IsValid())
			{
				DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
				short areaId = (short)context.Random.Next(45);
				MapBlockData blockData = DomainManager.Map.GetRandomMapBlockDataInAreaByFilters(context.Random, areaId, null, includeBlocksWithAdventure: false);
				Location = blockData.GetLocation();
			}
			TriggerAction();
		}
		if (State == 5 && Month > ActivateDelay)
		{
			CallParticipateCharacters();
		}
		if (State == 1 && Month >= ActivateDelay)
		{
			Activate();
			State = 5;
		}
		if (State != 0)
		{
			Month++;
		}
	}

	public override void Activate()
	{
		int adventureId = AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures[BookType];
		AdaptableLog.TagInfo("LegendaryBookMonthlyAction", "Legendary book adventure " + AdventureDomain.Core.GetAdventureMajorEventData(adventureId).Name + " activated at " + Location.ToString());
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		MonthlyEventActionsManager.NewlyActivated++;
		DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
		DomainManager.Map.EnsureBlockVisible(context, Location);
		ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(BookType);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		switch (BookAppearType)
		{
		case 0:
			monthlyEventCollection.AddFightForNewLegendaryBook(Location, (ulong)itemKey);
			monthlyNotifications.AddFightForNewLegendaryBook(Location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 1:
			monthlyEventCollection.AddFightForLegendaryBookOwnerConsumed(PrevOwnerId, Location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookOwnerConsumed(PrevOwnerId, Location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 2:
			monthlyEventCollection.AddFightForLegendaryBookOwnerDie(PrevOwnerId, Location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookOwnerDie(PrevOwnerId, Location, itemKey.ItemType, itemKey.TemplateId);
			break;
		case 3:
			monthlyEventCollection.AddFightForLegendaryBookAbandoned(PrevOwnerId, Location, (ulong)itemKey);
			monthlyNotifications.AddFightForLegendaryBookAbandoned(PrevOwnerId, Location, itemKey.ItemType, itemKey.TemplateId);
			break;
		}
	}

	public override void Deactivate(bool isComplete)
	{
		int adventureId = AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures[BookType];
		AdaptableLog.TagInfo("LegendaryBookMonthlyAction", "Legendary book adventure " + AdventureDomain.Core.GetAdventureMajorEventData(adventureId).Name + " removed at " + Location.ToString());
		if (DomainManager.LegendaryBook.GetOwner(BookType) < 0 && !AssignRandomOwner())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			MapBlockData blockData = DomainManager.Map.GetRandomMapBlockDataInAreaByFilters(context.Random, Location.AreaId, null, includeBlocksWithAdventure: false);
			if (blockData?.BlockId == Location.BlockId)
			{
				blockData = null;
			}
			LegendaryBookMonthlyAction action = new LegendaryBookMonthlyAction
			{
				BookType = BookType,
				BookAppearType = BookAppearType,
				PrevOwnerId = PrevOwnerId,
				Location = (blockData?.GetLocation() ?? Location.Invalid)
			};
			DomainManager.TaiwuEvent.AddTempDynamicAction(context, action);
		}
		ClearCalledCharacters();
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		Location = Location.Invalid;
	}

	private bool AssignRandomOwner()
	{
		List<GameData.Domains.Character.Character> charList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		charList.Clear();
		foreach (CharacterSet participatingCharacterSet in ParticipatingCharacterSets)
		{
			foreach (int participateCharId in participatingCharacterSet.GetCollection())
			{
				if (DomainManager.Character.TryGetElement_Objects(participateCharId, out var character) && character.GetLocation().Equals(Location) && !character.IsCompletelyInfected() && character.GetLegendaryBookOwnerState() < 3 && character.GetKidnapperId() < 0)
				{
					charList.Add(character);
				}
			}
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (charList.Count == 0)
		{
			ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(charList);
			AdaptableLog.TagInfo("LegendaryBookMonthlyAction", "Failed to assign random owner.");
			return false;
		}
		GameData.Domains.Character.Character randomOwner = charList.GetRandom(context.Random);
		ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(BookType);
		randomOwner.AddInventoryItem(context, itemKey, 1);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(charList);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotifications.AddLegendaryBookAppeared(randomOwner.GetId(), Location, itemKey.ItemType, itemKey.TemplateId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddGainLegendaryBook(randomOwner.GetId(), currDate, Location, itemKey.ItemType, itemKey.TemplateId);
		return true;
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		foreach (CharacterSet participatingCharacterSet in ParticipatingCharacterSets)
		{
			calledCharacters.UnionWith(participatingCharacterSet.GetCollection());
		}
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		AdaptableLog.Info("Adding participating characters to adventure.");
		CharacterSet participateCharSet = ((ParticipatingCharacterSets.Count > 0) ? ParticipatingCharacterSets[0] : default(CharacterSet));
		FillIntelligentCharactersToArgBox(eventArgBox, "ParticipateCharacter_0", participateCharSet);
		AdventureCharacterSortUtils.Sort(eventArgBox, isMajorChar: false, 0, CharacterSortType.CombatPower, ascendingOrder: false);
	}

	private void FillIntelligentCharactersToArgBox(EventArgBox eventArgBox, string keyPrefix, CharacterSet charSet)
	{
		int amountAdded = 0;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		foreach (int charId in charSet.GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				if (character.IsCrossAreaTraveling())
				{
					DomainManager.Character.GroupMove(context, character, Location);
				}
				if (character.GetLocation().Equals(Location))
				{
					eventArgBox.Set($"{keyPrefix}_{amountAdded}", charId);
					amountAdded++;
				}
			}
		}
		AdaptableLog.Info($"Adding {amountAdded} real characters to adventure.");
		eventArgBox.Set(keyPrefix + "_Count", amountAdded);
	}

	private void ClearCalledCharacters()
	{
		CallCharacterHelper.ClearCalledCharacters(ParticipatingCharacterSets, unHideCharacters: true, removeExternalState: true);
	}

	private void CallParticipateCharacters()
	{
		foreach (CharacterSet tempCalledCharSet in _tempCalledCharSets)
		{
			tempCalledCharSet.Clear();
		}
		_tempCalledCharSets.Clear();
		CallCharacterHelper.CallCharacters(Location, SearchRule, _tempCalledCharSets, modifyExternalState: true);
		for (int index = 0; index < _tempCalledCharSets.Count; index++)
		{
			CharacterSet tempCalledSet = _tempCalledCharSets[index];
			if (ParticipatingCharacterSets.Count <= index)
			{
				ParticipatingCharacterSets.Add(default(CharacterSet));
			}
			CharacterSet charSet = ParticipatingCharacterSets[index];
			charSet.AddRange(tempCalledSet.GetCollection());
			ParticipatingCharacterSets[index] = charSet;
		}
	}

	private static bool CheckCharacterAvailable(GameData.Domains.Character.Character character)
	{
		return CharacterMatcher.DefValue.AvailableForLegendaryBookAdventure.Match(character);
	}

	private static bool CheckSectLeaderAvailable(GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		return orgInfo.Grade != 8 || !orgInfo.Principal || !Config.Organization.Instance[orgInfo.OrgTemplateId].IsSect || DomainManager.TaiwuEvent.MainThreadDataContext.Random.CheckPercentProb(20);
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 25;
		if (ParticipatingCharacterSets != null)
		{
			totalSize += 2;
			int elementsCount = ParticipatingCharacterSets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += ParticipatingCharacterSets[i].GetSerializedSize();
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
		*(short*)pCurrData = DynamicActionType;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (byte)BookType;
		pCurrData++;
		*pCurrData = (byte)BookAppearType;
		pCurrData++;
		*(int*)pCurrData = PrevOwnerId;
		pCurrData += 4;
		*pCurrData = (byte)ActivateDelay;
		pCurrData++;
		if (ParticipatingCharacterSets != null)
		{
			int elementsCount = ParticipatingCharacterSets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = ParticipatingCharacterSets[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
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
		pCurrData += 2;
		pCurrData += Location.Deserialize(pCurrData);
		BookType = (sbyte)(*pCurrData);
		pCurrData++;
		BookAppearType = (sbyte)(*pCurrData);
		pCurrData++;
		PrevOwnerId = *(int*)pCurrData;
		pCurrData += 4;
		ActivateDelay = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ParticipatingCharacterSets == null)
			{
				ParticipatingCharacterSets = new List<CharacterSet>(elementsCount);
			}
			else
			{
				ParticipatingCharacterSets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterSet element = default(CharacterSet);
				pCurrData += element.Deserialize(pCurrData);
				ParticipatingCharacterSets.Add(element);
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
