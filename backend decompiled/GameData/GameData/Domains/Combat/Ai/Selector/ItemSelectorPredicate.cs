using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Selector;

public delegate bool ItemSelectorPredicate(CombatCharacter combatChar, ItemKey itemKey);
