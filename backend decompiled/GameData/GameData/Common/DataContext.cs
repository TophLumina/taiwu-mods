using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Adventure;
using GameData.Domains;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Filters;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Common;

public class DataContext : IAdventureContextBridge
{
	public readonly int ThreadId;

	public readonly ParallelModificationsRecorder ParallelModificationsRecorder;

	public IRandomSource Random;

	public readonly Equipping Equipping;

	public readonly AdvanceMonthRelatedData AdvanceMonthRelatedData;

	private IRandomSource _randomSourceBackup;

	public readonly CharacterPlanningAgent PlanningAgent = new CharacterPlanningAgent(CharacterActionPlanner.Instance);

	private static readonly List<Predicate<GameData.Domains.Character.Character>> Predicates = new List<Predicate<GameData.Domains.Character.Character>>();

	private static readonly List<GameData.Domains.Character.Character> FoundCharacters = new List<GameData.Domains.Character.Character>();

	IRandomSource IAdventureContextBridge.Random => Random;

	public DataContext(int threadId)
	{
		ThreadId = threadId;
		ParallelModificationsRecorder = new ParallelModificationsRecorder();
		Random = RandomDefaults.CreateRandomSource();
		Equipping = new Equipping();
		AdvanceMonthRelatedData = new AdvanceMonthRelatedData();
	}

	public IRandomSource SwitchRandomSource(string purposeText)
	{
		ulong seed = Random.NextULong();
		AdaptableLog.Info($"Random seed switched to {seed} for {purposeText}");
		return SwitchRandomSource(seed);
	}

	public IRandomSource SwitchRandomSource(IRandomSource random)
	{
		if (_randomSourceBackup == null)
		{
			_randomSourceBackup = Random;
		}
		else
		{
			AdaptableLog.TagWarning("Random", "Switching to a new random source before the previous one was restored.");
		}
		IRandomSource oriRandom = Random;
		Random = random;
		return oriRandom;
	}

	public IRandomSource SwitchRandomSource(ulong seed)
	{
		if (_randomSourceBackup == null)
		{
			_randomSourceBackup = Random;
		}
		else
		{
			AdaptableLog.TagWarning("Random", "Switching to a new random source before the previous one was restored.");
		}
		IRandomSource oriRandom = Random;
		Random = RandomDefaults.CreateRandomSource(seed);
		return oriRandom;
	}

	public void RestoreRandomSource()
	{
		if (_randomSourceBackup == null)
		{
			AdaptableLog.TagWarning("Random", "Restoring random source when backup doesn't exist.");
		}
		else
		{
			Random = _randomSourceBackup;
		}
		_randomSourceBackup = null;
	}

	public void CallCharacterByAdventure(Location location, GameData.Domains.Character.Character character)
	{
		if (character.GetAgeGroup() != 0)
		{
			DomainManager.Character.LeaveGroup(this, character);
		}
		DomainManager.Character.GroupMove(this, character, location);
		DomainManager.Character.HideCharacterOnMap(this, character, 4uL);
	}

	void IAdventureContextBridge.ReleaseCalledCharacters(IEnumerable<int> calledCharacters)
	{
		foreach (int charId in calledCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				DomainManager.Character.UnhideCharacterOnMap(this, character, 4uL);
			}
		}
	}

	void IAdventureContextBridge.ReleaseTemporaryCharacters(IEnumerable<int> temporaryCharacters)
	{
		foreach (int charId in temporaryCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				bool flag;
				switch (character.GetCreatingType())
				{
				case 1:
					DomainManager.Character.RemoveTemporaryIntelligentCharacter(this, character);
					continue;
				case 2:
				case 3:
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (flag)
				{
					DomainManager.Character.RemoveNonIntelligentCharacter(this, character);
				}
			}
		}
	}

	void IAdventureContextBridge.ReleaseTemporaryItem(ItemKey itemKey)
	{
		DomainManager.Item.RemoveItem(this, itemKey);
	}

	void IAdventureContextBridge.ReleaseTemporaryItems(IReadOnlyList<GameData.Domains.Adventure.AdventureItem> temporaryItems)
	{
		foreach (GameData.Domains.Adventure.AdventureItem temporaryItem in temporaryItems)
		{
			DomainManager.Item.RemoveItem(this, temporaryItem.ItemKey);
		}
	}

	void IAdventureContextBridge.OwnedByAdventure(ItemKey itemKey)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Adventure, taiwuCharId);
	}

	void IAdventureContextBridge.CallCharacters(IList<int> calledCharacters, CharacterFilterKey filterKey, Location location, int maxCount)
	{
		calledCharacters.Clear();
		GameData.Domains.Character.Filters.CharacterFilterRules.ToPredicates(filterKey.FilterRuleTemplateId, Predicates, location);
		switch (filterKey.SearchRangeType)
		{
		case 0:
			MapCharacterFilter.Find(Predicates, FoundCharacters, location.AreaId);
			break;
		case 1:
		{
			List<short> areaList = ObjectPool<List<short>>.Instance.Get();
			sbyte curStateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
			DomainManager.Map.GetAllAreaInState(curStateId, areaList);
			MapCharacterFilter.ParallelFind(Predicates, FoundCharacters, areaList);
			ObjectPool<List<short>>.Instance.Return(areaList);
			break;
		}
		case 2:
			MapCharacterFilter.ParallelFind(Predicates, FoundCharacters, 0, 135);
			break;
		}
		int foundedCount = Math.Min(FoundCharacters.Count, maxCount);
		for (int i = 0; i < foundedCount; i++)
		{
			GameData.Domains.Character.Character character = FoundCharacters[i];
			int charId = character.GetId();
			calledCharacters.Add(charId);
			CallCharacterByAdventure(location, character);
		}
		Predicates.Clear();
		FoundCharacters.Clear();
	}

	int IAdventureContextBridge.GenerateTemporaryCharacter(short templateId)
	{
		CharacterItem config = Config.Character.Instance[templateId];
		byte creatingType = config.CreatingType;
		if (1 == 0)
		{
		}
		GameData.Domains.Character.Character character = creatingType switch
		{
			3 => DomainManager.Character.CreateFixedEnemy(this, templateId, isTemporary: false), 
			2 => DomainManager.Character.CreateRandomEnemy(this, templateId, isTemporary: false), 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		GameData.Domains.Character.Character character2 = character;
		if (character2 != null)
		{
			DomainManager.Character.CompleteCreatingCharacter(character2.GetId());
		}
		return character2?.GetId() ?? (-1);
	}

	int IAdventureContextBridge.GenerateTemporaryCharacter(CharacterFilterKey filterKey, Location location)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.CreateTemporaryIntelligentCharacter(this, filterKey.FilterRuleTemplateId, location);
		character.ActiveExternalRelationState(this, 4uL);
		return character.GetId();
	}

	void IAdventureContextBridge.Execute(InstructionCompiled ins, IAdventureRuntime runtime)
	{
		if (runtime is AdventureRuntime adventure)
		{
			ins.Execute(adventure.Id);
		}
		else if (runtime is AdventureMajorEvent majorEvent)
		{
			ins.Execute(majorEvent);
		}
	}
}
