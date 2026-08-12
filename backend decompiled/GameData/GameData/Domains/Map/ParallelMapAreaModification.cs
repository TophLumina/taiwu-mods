using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.Item;
using GameData.Domains.Organization.ParallelModifications;

namespace GameData.Domains.Map;

public class ParallelMapAreaModification
{
	public short AreaId;

	public readonly Dictionary<short, ParallelSettlementModification> SettlementDict = new Dictionary<short, ParallelSettlementModification>();

	public readonly List<(GameData.Domains.Character.Character character, AddOrIncreaseInjuryParams param)> CharInjuries = new List<(GameData.Domains.Character.Character, AddOrIncreaseInjuryParams)>();

	public readonly List<short> DisasterBlocks = new List<short>();

	public readonly List<int> DeadCharList = new List<int>();

	public readonly List<int> DamageGraveList = new List<int>();

	public readonly Dictionary<short, int> DisasterAdventureId = new Dictionary<short, int>();

	public readonly List<ItemKey> DestroyedUniqueItems = new List<ItemKey>();
}
