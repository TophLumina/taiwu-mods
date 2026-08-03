using System;
using System.Collections.Generic;
using System.Text;
using Config;
using GameData.Adventure;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.SpecialEffect;

namespace GameData.Utilities;

public static class ObjectPoolManager
{
	public static void Initialize()
	{
		int initialCount = Environment.ProcessorCount;
		int maxCount = initialCount * 2;
		ObjectPool<List<bool>>.Instance = new CollectionObjectPool<List<bool>, bool>(initialCount, maxCount);
		ObjectPool<List<sbyte>>.Instance = new CollectionObjectPool<List<sbyte>, sbyte>(initialCount, maxCount);
		ObjectPool<List<byte>>.Instance = new CollectionObjectPool<List<byte>, byte>(initialCount, maxCount);
		ObjectPool<List<short>>.Instance = new CollectionObjectPool<List<short>, short>(initialCount, maxCount);
		ObjectPool<List<short[]>>.Instance = new CollectionObjectPool<List<short[]>, short[]>(initialCount, maxCount);
		ObjectPool<List<ushort>>.Instance = new CollectionObjectPool<List<ushort>, ushort>(initialCount, maxCount);
		ObjectPool<List<ushort[]>>.Instance = new CollectionObjectPool<List<ushort[]>, ushort[]>(initialCount, maxCount);
		ObjectPool<List<int>>.Instance = new CollectionObjectPool<List<int>, int>(initialCount, maxCount);
		ObjectPool<List<uint>>.Instance = new CollectionObjectPool<List<uint>, uint>(initialCount, maxCount);
		ObjectPool<List<int[]>>.Instance = new CollectionObjectPool<List<int[]>, int[]>(initialCount, maxCount);
		ObjectPool<HashSet<int>>.Instance = new CollectionObjectPool<HashSet<int>, int>(initialCount, maxCount);
		ObjectPool<HashSet<short>>.Instance = new CollectionObjectPool<HashSet<short>, short>(initialCount, maxCount);
		ObjectPool<List<long>>.Instance = new CollectionObjectPool<List<long>, long>(initialCount, maxCount);
		ObjectPool<List<(int, int)>>.Instance = new CollectionObjectPool<List<(int, int)>, (int, int)>(initialCount, maxCount);
		ObjectPool<List<(byte, byte)>>.Instance = new CollectionObjectPool<List<(byte, byte)>, (byte, byte)>(initialCount, maxCount);
		ObjectPool<List<(long, int)>>.Instance = new CollectionObjectPool<List<(long, int)>, (long, int)>(initialCount, maxCount);
		ObjectPool<List<(sbyte, bool)>>.Instance = new CollectionObjectPool<List<(sbyte, bool)>, (sbyte, bool)>(initialCount, maxCount);
		ObjectPool<Dictionary<int, int>>.Instance = new CollectionObjectPool<Dictionary<int, int>, KeyValuePair<int, int>>(initialCount, maxCount);
		ObjectPool<Dictionary<short, int>>.Instance = new CollectionObjectPool<Dictionary<short, int>, KeyValuePair<short, int>>(initialCount, maxCount);
		ObjectPool<Dictionary<short, short>>.Instance = new CollectionObjectPool<Dictionary<short, short>, KeyValuePair<short, short>>(initialCount, maxCount);
		ObjectPool<Dictionary<byte, int>>.Instance = new CollectionObjectPool<Dictionary<byte, int>, KeyValuePair<byte, int>>(initialCount, maxCount);
		ObjectPool<Dictionary<int, sbyte>>.Instance = new CollectionObjectPool<Dictionary<int, sbyte>, KeyValuePair<int, sbyte>>(initialCount, maxCount);
		ObjectPool<Dictionary<sbyte, byte>>.Instance = new CollectionObjectPool<Dictionary<sbyte, byte>, KeyValuePair<sbyte, byte>>(initialCount, maxCount);
		ObjectPool<Dictionary<sbyte, sbyte>>.Instance = new CollectionObjectPool<Dictionary<sbyte, sbyte>, KeyValuePair<sbyte, sbyte>>(initialCount, maxCount);
		ObjectPool<Dictionary<int, IntPair>>.Instance = new CollectionObjectPool<Dictionary<int, IntPair>, KeyValuePair<int, IntPair>>(initialCount, maxCount);
		ObjectPool<Dictionary<ItemKey, int>>.Instance = new CollectionObjectPool<Dictionary<ItemKey, int>, KeyValuePair<ItemKey, int>>(initialCount, maxCount);
		ObjectPool<Dictionary<sbyte, OuterAndInnerInts>>.Instance = new CollectionObjectPool<Dictionary<sbyte, OuterAndInnerInts>, KeyValuePair<sbyte, OuterAndInnerInts>>(initialCount, maxCount);
		ObjectPool<List<string>>.Instance = new CollectionObjectPool<List<string>, string>(initialCount, maxCount);
		ObjectPool<HashSet<string>>.Instance = new CollectionObjectPool<HashSet<string>, string>(2, 4);
		ObjectPool<HashSet<sbyte>>.Instance = new CollectionObjectPool<HashSet<sbyte>, sbyte>(2, 4);
		ObjectPool<List<ByteCoordinate>>.Instance = new CollectionObjectPool<List<ByteCoordinate>, ByteCoordinate>(initialCount * 2, maxCount * 2);
		ObjectPool<List<List<ByteCoordinate>>>.Instance = new CollectionObjectPool<List<List<ByteCoordinate>>, List<ByteCoordinate>>(initialCount * 2, maxCount * 2);
		ObjectPool<List<AdventureBlockIndex>>.Instance = new CollectionObjectPool<List<AdventureBlockIndex>, AdventureBlockIndex>(initialCount * 2, maxCount * 2);
		ObjectPool<List<IAdventureRuntime>>.Instance = new CollectionObjectPool<List<IAdventureRuntime>, IAdventureRuntime>(initialCount, maxCount);
		ObjectPool<List<IAdventureParticipant>>.Instance = new CollectionObjectPool<List<IAdventureParticipant>, IAdventureParticipant>(initialCount * 2, maxCount * 2);
		ObjectPool<List<AdventureElement>>.Instance = new CollectionObjectPool<List<AdventureElement>, AdventureElement>(initialCount * 2, maxCount * 2);
		ObjectPool<List<MapBlockData>>.Instance = new CollectionObjectPool<List<MapBlockData>, MapBlockData>(4, 8);
		ObjectPool<List<Location>>.Instance = new CollectionObjectPool<List<Location>, Location>(initialCount * 2, maxCount * 2);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance = new CollectionObjectPool<List<GameData.Domains.Character.Character>, GameData.Domains.Character.Character>(2, 4);
		ObjectPool<List<GameData.Domains.Character.CombatSkillHelper.AttainmentSectInfo>>.Instance = new CollectionObjectPool<List<GameData.Domains.Character.CombatSkillHelper.AttainmentSectInfo>, GameData.Domains.Character.CombatSkillHelper.AttainmentSectInfo>(initialCount, maxCount);
		ObjectPool<List<ItemKey>>.Instance = new CollectionObjectPool<List<ItemKey>, ItemKey>(2, 4);
		ObjectPool<List<ItemKeyAndDate>>.Instance = new CollectionObjectPool<List<ItemKeyAndDate>, ItemKeyAndDate>(2, 4);
		ObjectPool<List<Wager>>.Instance = new CollectionObjectPool<List<Wager>, Wager>(2, 4);
		ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance = new CollectionObjectPool<List<Predicate<GameData.Domains.Character.Character>>, Predicate<GameData.Domains.Character.Character>>(initialCount, maxCount);
		ObjectPool<List<CombatSkillKey>>.Instance = new CollectionObjectPool<List<CombatSkillKey>, CombatSkillKey>(initialCount, maxCount);
		ObjectPool<List<GameData.Domains.CombatSkill.CombatSkill>>.Instance = new CollectionObjectPool<List<GameData.Domains.CombatSkill.CombatSkill>, GameData.Domains.CombatSkill.CombatSkill>(2, 4);
		ObjectPool<List<MapTemplateEnemyInfo>>.Instance = new CollectionObjectPool<List<MapTemplateEnemyInfo>, MapTemplateEnemyInfo>(initialCount, maxCount);
		ObjectPool<List<NeedTrick>>.Instance = new CollectionObjectPool<List<NeedTrick>, NeedTrick>(initialCount, maxCount);
		ObjectPool<List<SpecialEffectBase>>.Instance = new CollectionObjectPool<List<SpecialEffectBase>, SpecialEffectBase>(initialCount, maxCount);
		ObjectPool<List<SkillEffectKey>>.Instance = new CollectionObjectPool<List<SkillEffectKey>, SkillEffectKey>(initialCount, maxCount);
		ObjectPool<List<Settlement>>.Instance = new CollectionObjectPool<List<Settlement>, Settlement>(4, 8);
		ObjectPool<List<SecretInformationMetaData>>.Instance = new CollectionObjectPool<List<SecretInformationMetaData>, SecretInformationMetaData>(initialCount * 2, maxCount * 2);
		ObjectPool<HashSet<ItemKey>>.Instance = new CollectionObjectPool<HashSet<ItemKey>, ItemKey>(initialCount, maxCount);
		ObjectPool<HashSet<SecretInformationRelationshipType>>.Instance = new CollectionObjectPool<HashSet<SecretInformationRelationshipType>, SecretInformationRelationshipType>(initialCount, maxCount);
		ObjectPool<HashSet<BuildingBlockKey>>.Instance = new CollectionObjectPool<HashSet<BuildingBlockKey>, BuildingBlockKey>(initialCount, maxCount);
		ObjectPool<List<BuildingBlockKey>>.Instance = new CollectionObjectPool<List<BuildingBlockKey>, BuildingBlockKey>(initialCount, maxCount);
		ObjectPool<List<DefeatMarkKey>>.Instance = new CollectionObjectPool<List<DefeatMarkKey>, DefeatMarkKey>(initialCount, maxCount);
		ObjectPool<List<(ItemKey, int)>>.Instance = new CollectionObjectPool<List<(ItemKey, int)>, (ItemKey, int)>(initialCount, maxCount);
		ObjectPool<StringBuilder>.Instance = new ObjectPool<StringBuilder>(initialCount, maxCount);
		ObjectPool<List<TemplateKey>>.Instance = new ObjectPool<List<TemplateKey>>(initialCount, maxCount);
	}
}
