using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Selector;

public delegate bool ItemSelectorComparisonIsPrefer(CombatCharacter combatChar, ItemKey itemKey);
