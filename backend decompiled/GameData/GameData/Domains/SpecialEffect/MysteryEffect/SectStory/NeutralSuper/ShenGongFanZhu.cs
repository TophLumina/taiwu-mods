using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

public class ShenGongFanZhu : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	private List<int> _repairedItems;

	protected override short SpecialEffectId => 1776;

	public ShenGongFanZhu()
	{
	}

	public ShenGongFanZhu(int charId, int itemId)
		: base(charId, itemId, 50108)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_ChangeDurabilityToZero(OnChangeDurabilityToZero);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeDurabilityToZero(OnChangeDurabilityToZero);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		_repairedItems?.Clear();
	}

	private void OnChangeDurabilityToZero(DataContext context, CombatCharacter character, ItemKey itemKey)
	{
		if (character.GetId() != base.CharacterId || (_repairedItems != null && _repairedItems.Contains(itemKey.Id)))
		{
			return;
		}
		sbyte itemType = itemKey.ItemType;
		bool flag = (uint)itemType <= 2u;
		if (!flag || !DomainManager.Combat.EquipmentOldDurability.TryGetValue(itemKey, out var initDurability))
		{
			return;
		}
		sbyte lifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
		short attainment = CharObj.GetLifeSkillAttainment(lifeSkillType);
		if (attainment >= 500)
		{
			if (_repairedItems == null)
			{
				_repairedItems = new List<int>();
			}
			_repairedItems.Add(itemKey.Id);
			ChangeDurability(context, character, itemKey, initDurability);
			ShowSpecialEffect(0);
		}
	}
}
