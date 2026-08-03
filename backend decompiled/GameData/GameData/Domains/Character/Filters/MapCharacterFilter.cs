using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.Character.Filters;

public static class MapCharacterFilter
{
	public static void ParallelFind(Predicate<Character> predicate, List<Character> results, short areaIdBegin = 0, short areaIdEnd = 135, bool includeInfected = false)
	{
		Parallel.For(areaIdBegin, areaIdEnd, () => new List<Character>(), delegate(int areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			Find(predicate, localResults, (short)areaId, includeInfected);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFindInfected(Predicate<Character> predicate, List<Character> results, short areaIdBegin = 0, short areaIdEnd = 135)
	{
		Parallel.For(areaIdBegin, areaIdEnd, () => new List<Character>(), delegate(int areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			FindInfected(predicate, localResults, (short)areaId);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFind(List<Predicate<Character>> predicates, List<Character> results, short areaIdBegin = 0, short areaIdEnd = 135, bool includeInfected = false)
	{
		Parallel.For(areaIdBegin, areaIdEnd, () => new List<Character>(), delegate(int areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			Find(predicates, localResults, (short)areaId, includeInfected);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFindInfected(List<Predicate<Character>> predicates, List<Character> results, short areaIdBegin = 0, short areaIdEnd = 135)
	{
		Parallel.For(areaIdBegin, areaIdEnd, () => new List<Character>(), delegate(int areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			FindInfected(predicates, localResults, (short)areaId);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFind(List<Predicate<Character>> predicates, List<Character> results, List<short> areaIdList, bool includeInfected = false)
	{
		Parallel.ForEach(areaIdList, () => new List<Character>(), delegate(short areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			Find(predicates, localResults, areaId, includeInfected);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFind(Predicate<Character> predicate, List<Character> results, List<short> areaIdList, bool includeInfected = false)
	{
		Parallel.ForEach(areaIdList, () => new List<Character>(), delegate(short areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			Find(predicate, localResults, areaId, includeInfected);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void ParallelFindInfected(List<Predicate<Character>> predicates, List<Character> results, List<short> areaIdList)
	{
		Parallel.ForEach(areaIdList, () => new List<Character>(), delegate(short areaId, ParallelLoopState loopState, List<Character> localResults)
		{
			FindInfected(predicates, localResults, areaId);
			return localResults;
		}, delegate(List<Character> localResults)
		{
			lock (results)
			{
				results.AddRange(localResults);
			}
		});
	}

	public static void Find(Predicate<Character> predicate, List<Character> results, short areaId, bool includeInfected = false)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].CharacterSet;
			if (charIds != null)
			{
				foreach (int charId in charIds)
				{
					Character character = DomainManager.Character.GetElement_Objects(charId);
					if (predicate(character))
					{
						results.Add(character);
					}
				}
			}
			if (!includeInfected)
			{
				continue;
			}
			charIds = blocks[i].InfectedCharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId2 in charIds)
			{
				Character character2 = DomainManager.Character.GetElement_Objects(charId2);
				if (predicate(character2))
				{
					results.Add(character2);
				}
			}
		}
	}

	public static void FindInfected(Predicate<Character> predicate, List<Character> results, short areaId)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].InfectedCharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				Character character = DomainManager.Character.GetElement_Objects(charId);
				if (predicate(character))
				{
					results.Add(character);
				}
			}
		}
	}

	public static void FindStateInfected(Predicate<Character> predicate, List<Character> results, sbyte stateId)
	{
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetAllAreaInState(stateId, areaList);
		for (int i = 0; i < areaList.Count; i++)
		{
			Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaList[i]);
			int j = 0;
			for (int blocksCount = blocks.Length; j < blocksCount; j++)
			{
				HashSet<int> charIds = blocks[j].InfectedCharacterSet;
				if (charIds == null)
				{
					continue;
				}
				foreach (int charId in charIds)
				{
					Character character = DomainManager.Character.GetElement_Objects(charId);
					if (predicate(character))
					{
						results.Add(character);
					}
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(areaList);
	}

	public static void Find(List<Predicate<Character>> predicates, List<Character> results, short areaId, bool includeInfected = false)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].CharacterSet;
			if (charIds != null)
			{
				foreach (int charId in charIds)
				{
					Character character = DomainManager.Character.GetElement_Objects(charId);
					if (CharacterMatchers.MatchAll(character, predicates))
					{
						results.Add(character);
					}
				}
			}
			if (!includeInfected)
			{
				continue;
			}
			charIds = blocks[i].InfectedCharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId2 in charIds)
			{
				Character character2 = DomainManager.Character.GetElement_Objects(charId2);
				if (CharacterMatchers.MatchAll(character2, predicates))
				{
					results.Add(character2);
				}
			}
		}
	}

	public static void FindTraveling(List<Predicate<Character>> predicates, List<Character> results, bool includeInfected = false)
	{
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Character.GetCrossAreaTravelingCharacterIds(charIds);
		foreach (int charId in charIds)
		{
			Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.IsCompletelyInfected() && !includeInfected)
			{
				continue;
			}
			if (character.GetLeaderId() == charId)
			{
				HashSet<int> collection = DomainManager.Character.GetGroup(charId).GetCollection();
				foreach (int groupCharId in collection)
				{
					Character groupChar = DomainManager.Character.GetElement_Objects(groupCharId);
					if (CharacterMatchers.MatchAll(groupChar, predicates))
					{
						results.Add(groupChar);
					}
				}
			}
			else if (CharacterMatchers.MatchAll(character, predicates))
			{
				results.Add(character);
			}
		}
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	public static void FindTraveling(Predicate<Character> predicate, List<Character> results, bool includeInfected = false)
	{
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Character.GetCrossAreaTravelingCharacterIds(charIds);
		foreach (int charId in charIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || (character.IsCompletelyInfected() && !includeInfected))
			{
				continue;
			}
			if (character.GetLeaderId() == charId)
			{
				HashSet<int> collection = DomainManager.Character.GetGroup(charId).GetCollection();
				foreach (int groupCharId in collection)
				{
					Character groupChar = DomainManager.Character.GetElement_Objects(groupCharId);
					if (predicate(groupChar))
					{
						results.Add(groupChar);
					}
				}
			}
			else if (predicate(character))
			{
				results.Add(character);
			}
		}
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	public static void FindHiddenCharacters(Predicate<Character> predicate, List<Character> results, bool includeInfected = false)
	{
		HashSet<int> charIds = ObjectPool<HashSet<int>>.Instance.Get();
		DomainManager.Adventure.CollectAllCharactersInAdventure(charIds);
		foreach (int charId in charIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || (character.IsCompletelyInfected() && !includeInfected) || !character.IsActiveExternalRelationState(188uL) || character.GetKidnapperId() >= 0)
			{
				continue;
			}
			Location location = character.GetLocation();
			if (location.IsValid())
			{
				MapBlockData block = DomainManager.Map.GetBlock(location);
				if ((block.CharacterSet != null && block.CharacterSet.Contains(charId)) || (block.InfectedCharacterSet != null && block.InfectedCharacterSet.Contains(charId)))
				{
					continue;
				}
			}
			if (predicate(character))
			{
				results.Add(character);
			}
		}
		ObjectPool<HashSet<int>>.Instance.Return(charIds);
	}

	public static void FindKidnappedCharacters(Predicate<Character> predicate, List<Character> results, bool includeInfected = false)
	{
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Character.GetAllKidnappedCharacterIds(charIds);
		foreach (int charId in charIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && (!character.IsCompletelyInfected() || includeInfected) && predicate(character))
			{
				results.Add(character);
			}
		}
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	public static void FindInfected(List<Predicate<Character>> predicates, List<Character> results, short areaId)
	{
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
		int i = 0;
		for (int blocksCount = blocks.Length; i < blocksCount; i++)
		{
			HashSet<int> charIds = blocks[i].InfectedCharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				Character character = DomainManager.Character.GetElement_Objects(charId);
				if (CharacterMatchers.MatchAll(character, predicates))
				{
					results.Add(character);
				}
			}
		}
	}
}
