using System;
using System.Collections.Generic;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Filters;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

public static class CallCharacterHelper
{
	public class SearchCharacterRule
	{
		public bool AllowTemporaryCharacter;

		public sbyte SearchRange;

		public List<SearchCharacterSubRule> SubRules;
	}

	public class SearchCharacterSubRule
	{
		public readonly int MinAmount;

		public readonly int MaxAmount;

		public readonly Predicate<GameData.Domains.Character.Character> Predicate;

		public readonly Predicate<GameData.Domains.Character.Character> ConfirmPredicate;

		public readonly Func<DataContext, int> CreateTemporaryCharacterFunc;

		public readonly Action<GameData.Domains.Character.Character> OnCharacterCalled;

		public SearchCharacterSubRule(int minAmount, int maxAmount, Predicate<GameData.Domains.Character.Character> predicate, Predicate<GameData.Domains.Character.Character> confirmPredicate = null, Func<DataContext, int> createTempCharFunc = null, Action<GameData.Domains.Character.Character> onCharacterCalled = null)
		{
			MinAmount = minAmount;
			MaxAmount = maxAmount;
			Predicate = predicate;
			ConfirmPredicate = confirmPredicate;
			CreateTemporaryCharacterFunc = createTempCharFunc;
			OnCharacterCalled = onCharacterCalled;
		}
	}

	private static readonly List<List<Predicate<GameData.Domains.Character.Character>>> PredicatesList = new List<List<Predicate<GameData.Domains.Character.Character>>>();

	public static bool CallCharacters(Location location, sbyte searchRange, CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets, bool allowTemporaryCharacters, bool modifyExternalState, bool hideCharacters = false)
	{
		return CallCharacters(location, searchRange, filterRequirements, characterSets, allowTemporaryCharacters, modifyExternalState, hideCharacters, null);
	}

	public static bool CallCharacters(Location location, SearchCharacterRule searchCharacterRule, List<CharacterSet> characterSets, bool modifyExternalState)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		sbyte curStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		sbyte curStateId = (sbyte)(curStateTemplateId - 1);
		DomainManager.Map.GetAllAreaInState(curStateId, areaList);
		List<GameData.Domains.Character.Character> targetList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		targetList.Clear();
		for (int i = 0; i < searchCharacterRule.SubRules.Count; i++)
		{
			SearchCharacterSubRule subRule = searchCharacterRule.SubRules[i];
			switch (searchCharacterRule.SearchRange)
			{
			case 0:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(subRule.Predicate, Math.Max(subRule.MinAmount, subRule.MaxAmount), targetList, location.AreaId, location.AreaId, curStateTemplateId);
				break;
			case 1:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(subRule.Predicate, Math.Max(subRule.MinAmount, subRule.MaxAmount), targetList, areaList, curStateTemplateId);
				break;
			case 2:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(subRule.Predicate, Math.Max(subRule.MinAmount, subRule.MaxAmount), targetList, 0, 135, curStateTemplateId);
				break;
			}
			if (subRule.ConfirmPredicate != null)
			{
				for (int j = targetList.Count - 1; j >= 0; j--)
				{
					if (!subRule.ConfirmPredicate(targetList[j]))
					{
						CollectionUtils.SwapAndRemove(targetList, j);
					}
				}
			}
			if (characterSets.Count > i)
			{
				CharacterSet charSet = characterSets[i];
				charSet.AddRange(targetList.ConvertAll((GameData.Domains.Character.Character character) => character.GetId()));
				characterSets[i] = charSet;
			}
			else
			{
				CharacterSet charSet2 = default(CharacterSet);
				charSet2.AddRange(targetList.ConvertAll((GameData.Domains.Character.Character character) => character.GetId()));
				characterSets.Add(charSet2);
			}
			foreach (GameData.Domains.Character.Character participant in targetList)
			{
				DomainManager.Character.GroupMove(context, participant, location);
				if (modifyExternalState)
				{
					DomainManager.Character.HideCharacterOnMap(context, participant, 4uL);
				}
			}
			if (characterSets[i].GetCount() < subRule.MinAmount && !searchCharacterRule.AllowTemporaryCharacter)
			{
				ObjectPool<List<short>>.Instance.Return(areaList);
				ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
				return false;
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaList);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
		return true;
	}

	public static bool CallCharacters(Location location, sbyte searchRange, CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets, bool allowTemporaryCharacters, bool modifyExternalState, bool hideCharacters, Action<DataContext, GameData.Domains.Character.Character> onCharacterCalled)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		sbyte curStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		sbyte curStateId = (sbyte)(curStateTemplateId - 1);
		DomainManager.Map.GetAllAreaInState(curStateId, areaList);
		List<GameData.Domains.Character.Character> targetList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		targetList.Clear();
		for (int i = 0; i < filterRequirements.Length; i++)
		{
			CharacterFilterRequirement filterReq = filterRequirements[i];
			switch (searchRange)
			{
			case 0:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(filterReq.CharacterFilterRuleIds, Math.Max(filterReq.MinCharactersRequired, filterReq.MaxCharactersRequired), targetList, location.AreaId, location.AreaId, location);
				break;
			case 1:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(filterReq.CharacterFilterRuleIds, Math.Max(filterReq.MinCharactersRequired, filterReq.MaxCharactersRequired), targetList, areaList, location);
				break;
			case 2:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FindCharacters(filterReq.CharacterFilterRuleIds, Math.Max(filterReq.MinCharactersRequired, filterReq.MaxCharactersRequired), targetList, 0, 135, location);
				break;
			}
			if (characterSets.Count > i)
			{
				CharacterSet charSet = characterSets[i];
				if (filterReq.MaxCharactersRequired > 0 && charSet.GetCount() >= filterReq.MaxCharactersRequired * 3 / 2)
				{
					continue;
				}
				charSet.AddRange(targetList.ConvertAll((GameData.Domains.Character.Character character) => character.GetId()));
				characterSets[i] = charSet;
			}
			else
			{
				CharacterSet charSet2 = default(CharacterSet);
				charSet2.AddRange(targetList.ConvertAll((GameData.Domains.Character.Character character) => character.GetId()));
				characterSets.Add(charSet2);
			}
			foreach (GameData.Domains.Character.Character participant in targetList)
			{
				DomainManager.Character.GroupMove(context, participant, location);
				if (modifyExternalState)
				{
					DomainManager.Character.HideCharacterOnMap(context, participant, 4uL);
				}
				onCharacterCalled?.Invoke(context, participant);
			}
			if (characterSets[i].GetCount() < filterReq.MinCharactersRequired && !allowTemporaryCharacters)
			{
				ObjectPool<List<short>>.Instance.Return(areaList);
				ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
				return false;
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaList);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
		return true;
	}

	public static void ClearCalledCharacters(List<CharacterSet> characterSets, bool unHideCharacters, bool removeExternalState)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		characterSets.ForEach(delegate(CharacterSet charSet)
		{
			HashSet<int> collection = charSet.GetCollection();
			foreach (int current in collection)
			{
				if (DomainManager.Character.TryGetElement_Objects(current, out var element))
				{
					if (unHideCharacters && element.GetLeaderId() != DomainManager.Taiwu.GetTaiwuCharId())
					{
						if (element.IsCompletelyInfected())
						{
							Events.RaiseInfectedCharacterLocationChanged(context, current, Location.Invalid, element.GetLocation());
						}
						else
						{
							Events.RaiseCharacterLocationChanged(context, current, Location.Invalid, element.GetLocation());
						}
					}
					if (removeExternalState)
					{
						element.DeactivateExternalRelationState(context, 4uL);
					}
					short settlementId = element.GetOrganizationInfo().SettlementId;
					if (settlementId >= 0)
					{
						Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
						List<NpcTravelTarget> npcTravelTargets = element.GetNpcTravelTargets();
						npcTravelTargets.Clear();
						npcTravelTargets.Add(new NpcTravelTarget(settlement.GetLocation(), 127));
						element.SetNpcTravelTargets(npcTravelTargets, context);
					}
				}
			}
			charSet.Clear();
		});
		characterSets.Clear();
	}

	public static bool CheckCalledCharactersStillValid(CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets, Location location)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		for (int i = 0; i < filterRequirements.Length; i++)
		{
			if (characterSets.Count <= 0)
			{
				continue;
			}
			CharacterFilterRequirement filterReq = filterRequirements[i];
			CharacterSet characterSet = characterSets[i];
			if (characterSet.GetCount() == 0)
			{
				continue;
			}
			PredicatesList.Clear();
			short[] characterFilterRuleIds = filterReq.CharacterFilterRuleIds;
			foreach (short filterRuleId in characterFilterRuleIds)
			{
				List<Predicate<GameData.Domains.Character.Character>> predicates = ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Get();
				CharacterFilterRules.ToPredicates(filterRuleId, predicates, location);
				predicates.RemoveAt(0);
				PredicatesList.Add(predicates);
			}
			CharacterSet toRemove = default(CharacterSet);
			foreach (int charId in characterSet.GetCollection())
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || character.GetLeaderId() == taiwuCharId)
				{
					toRemove.Add(charId);
					continue;
				}
				bool isValid = false;
				foreach (List<Predicate<GameData.Domains.Character.Character>> predicates2 in PredicatesList)
				{
					isValid = CharacterMatchers.MatchAll(character, predicates2);
					if (isValid)
					{
						break;
					}
				}
				if (isValid)
				{
					continue;
				}
				return false;
			}
		}
		return true;
	}

	[Obsolete]
	public static int RemoveInvalidCharacters(CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets, sbyte curStateTemplateId)
	{
		return 0;
	}

	public static int RemoveInvalidCharacters(CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets, Location location)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int totalInvalidCount = 0;
		for (int i = 0; i < filterRequirements.Length; i++)
		{
			if (characterSets.Count <= 0)
			{
				continue;
			}
			CharacterFilterRequirement filterReq = filterRequirements[i];
			CharacterSet characterSet = characterSets[i];
			if (characterSet.GetCount() == 0)
			{
				continue;
			}
			PredicatesList.Clear();
			short[] characterFilterRuleIds = filterReq.CharacterFilterRuleIds;
			foreach (short filterRuleId in characterFilterRuleIds)
			{
				List<Predicate<GameData.Domains.Character.Character>> predicates = ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Get();
				CharacterFilterRules.ToPredicates(filterRuleId, predicates, location);
				predicates.RemoveAt(0);
				PredicatesList.Add(predicates);
			}
			CharacterSet toRemove = default(CharacterSet);
			foreach (int charId in characterSet.GetCollection())
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || character.GetLeaderId() == taiwuCharId)
				{
					toRemove.Add(charId);
					continue;
				}
				bool isValid = character.GetLocation().Equals(location);
				if (isValid)
				{
					foreach (List<Predicate<GameData.Domains.Character.Character>> predicates2 in PredicatesList)
					{
						isValid = CharacterMatchers.MatchAll(character, predicates2);
						if (isValid)
						{
							break;
						}
					}
				}
				if (!isValid)
				{
					if (character.IsCompletelyInfected())
					{
						Events.RaiseInfectedCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
					}
					else
					{
						Events.RaiseCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
					}
					character.DeactivateExternalRelationState(context, 4uL);
					toRemove.Add(charId);
				}
			}
			HashSet<int> toRemoveCollection = toRemove.GetCollection();
			if (toRemoveCollection.Count == 0)
			{
				continue;
			}
			foreach (int toRemoveCharId in toRemoveCollection)
			{
				characterSet.Remove(toRemoveCharId);
			}
			totalInvalidCount += toRemoveCollection.Count;
			characterSets[i] = characterSet;
		}
		return totalInvalidCount;
	}

	public static int RemoveInvalidCharacters(SearchCharacterRule searchRule, List<CharacterSet> characterSets)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		int totalInvalidCount = 0;
		for (int i = 0; i < searchRule.SubRules.Count; i++)
		{
			if (characterSets.Count <= i)
			{
				continue;
			}
			CharacterSet characterSet = characterSets[i];
			SearchCharacterSubRule subRule = searchRule.SubRules[i];
			CharacterSet toRemove = default(CharacterSet);
			foreach (int charId in characterSet.GetCollection())
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
				{
					toRemove.Add(charId);
				}
				else if (subRule.Predicate != null && !subRule.Predicate(character))
				{
					if (character.IsCompletelyInfected())
					{
						Events.RaiseInfectedCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
					}
					else
					{
						Events.RaiseCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
					}
					character.DeactivateExternalRelationState(context, 4uL);
					toRemove.Add(charId);
				}
			}
			HashSet<int> toRemoveCollection = toRemove.GetCollection();
			if (toRemoveCollection.Count == 0)
			{
				continue;
			}
			foreach (int toRemoveCharId in toRemoveCollection)
			{
				characterSet.Remove(toRemoveCharId);
			}
			totalInvalidCount += toRemoveCollection.Count;
			characterSets[i] = characterSet;
		}
		return totalInvalidCount;
	}

	public static bool IsAllCharactersAtLocation(Location location, CharacterFilterRequirement[] filterRequirements, List<CharacterSet> characterSets)
	{
		for (int i = 0; i < filterRequirements.Length; i++)
		{
			CharacterFilterRequirement filterReq = filterRequirements[i];
			if (characterSets.Count <= i)
			{
				return false;
			}
			CharacterSet characterSet = characterSets[i];
			int readyCount = 0;
			foreach (int charId in characterSet.GetCollection())
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetLocation().Equals(location))
				{
					readyCount++;
				}
			}
			if (readyCount < filterReq.MinCharactersRequired)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsAllCharactersAtLocation(Location location, SearchCharacterRule searchRule, List<CharacterSet> characterSets)
	{
		for (int i = 0; i < searchRule.SubRules.Count; i++)
		{
			if (characterSets.Count <= i)
			{
				return false;
			}
			CharacterSet characterSet = characterSets[i];
			int readyCount = 0;
			foreach (int charId in characterSet.GetCollection())
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetLocation().Equals(location))
				{
					readyCount++;
				}
			}
			if (readyCount < searchRule.SubRules[i].MinAmount)
			{
				return false;
			}
		}
		return true;
	}
}
