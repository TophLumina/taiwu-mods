using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Selector;

public class ItemSelector
{
	private readonly ItemSelectorPredicate _predicate;

	private readonly ItemSelectorComparisonIsPrefer _comparison;

	private CombatCharacter _checkingCharacter;

	private static bool IsEat(ItemKey itemKey)
	{
		return itemKey.GetConfig().IsEat();
	}

	private static bool CharacterCheck(CombatCharacter combatChar)
	{
		if (combatChar.IsAlly)
		{
			return false;
		}
		return combatChar.GetCanUseItem();
	}

	public ItemSelector(ItemSelectorPredicate predicate)
		: this(predicate, null)
	{
	}

	public ItemSelector(ItemSelectorPredicate predicate, ItemSelectorComparisonIsPrefer comparison)
	{
		_predicate = predicate;
		_comparison = comparison;
	}

	public bool AnyMatch(CombatCharacter combatChar)
	{
		if (!CharacterCheck(combatChar))
		{
			return false;
		}
		_checkingCharacter = combatChar;
		bool pass = combatChar.GetValidItems().Where(PredicateCheck).Any(CommonCheck);
		_checkingCharacter = null;
		return pass;
	}

	public ItemKey Select(IRandomSource random, CombatCharacter combatChar)
	{
		if (!CharacterCheck(combatChar))
		{
			return ItemKey.Invalid;
		}
		bool anyPrefer = false;
		List<ItemKey> pool = ObjectPool<List<ItemKey>>.Instance.Get();
		_checkingCharacter = combatChar;
		foreach (ItemKey itemKey in combatChar.GetValidItems())
		{
			if (PredicateCheck(itemKey) && CommonCheck(itemKey))
			{
				bool prefer = _comparison?.Invoke(combatChar, itemKey) ?? false;
				if (prefer && !anyPrefer)
				{
					anyPrefer = true;
					pool.Clear();
				}
				if (prefer == anyPrefer)
				{
					pool.Add(itemKey);
				}
			}
		}
		_checkingCharacter = null;
		ItemKey result = ((pool.Count > 0) ? ItemSelectorHelper.SelectBestGradeItem(random, pool) : ItemKey.Invalid);
		ObjectPool<List<ItemKey>>.Instance.Return(pool);
		return result;
	}

	private bool CommonCheck(ItemKey itemKey)
	{
		CombatType combatType = (CombatType)DomainManager.Combat.GetCombatType();
		bool flag = ((combatType == CombatType.Play || combatType == CombatType.Test) ? true : false);
		if (flag && !itemKey.GetConfigAs<ICombatItemConfig>().AllowUseInPlayAndTest)
		{
			return false;
		}
		int costWisdom = itemKey.GetConsumedFeatureMedals();
		short wisdom = (_checkingCharacter.IsAlly ? DomainManager.Combat.GetSelfTeamWisdomCount() : DomainManager.Combat.GetEnemyTeamWisdomCount());
		if (costWisdom > wisdom)
		{
			return false;
		}
		GameData.Domains.Character.Character character = _checkingCharacter.GetCharacter();
		if (itemKey.ItemType == 8)
		{
			MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
			if (config.RequiredMainAttributeType >= 0)
			{
				short cur = character.GetCurrMainAttribute(config.RequiredMainAttributeType);
				sbyte need = config.RequiredMainAttributeValue;
				if (cur < need)
				{
					return false;
				}
			}
		}
		if (!IsEat(itemKey))
		{
			return true;
		}
		sbyte maxSlotCount = character.GetCurrMaxEatingSlotsCount();
		return character.GetEatingItems().GetAvailableEatingSlot(maxSlotCount) >= 0;
	}

	private bool PredicateCheck(ItemKey itemKey)
	{
		return _predicate?.Invoke(_checkingCharacter, itemKey) ?? true;
	}
}
