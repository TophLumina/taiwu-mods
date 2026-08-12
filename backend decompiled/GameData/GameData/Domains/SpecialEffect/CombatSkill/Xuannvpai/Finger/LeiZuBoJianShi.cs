using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class LeiZuBoJianShi : CombatSkillEffectBase
{
	private const sbyte AffectOdds = 50;

	private const sbyte RemoveClothOdds = 50;

	private const sbyte CombatStatePowerUnit = 20;

	private static readonly sbyte[] CanRemoveSlots = new sbyte[7] { 3, 5, 6, 7, 8, 9, 10 };

	private IReadOnlyList<ItemKey> CurrEnemyEquipments => base.CurrEnemyChar.GetCharacter().GetEquipment();

	private short CombatStateId => (short)(base.IsDirect ? 39 : 40);

	private static bool IsDetachable(ItemKey itemKey)
	{
		return itemKey.IsValid() && DomainManager.Item.GetBaseEquipment(itemKey).GetDetachable();
	}

	private bool IsGodArmor(int itemId)
	{
		return DomainManager.SpecialEffect.ModifyData(base.CurrEnemyChar.GetId(), -1, 182, dataValue: false, itemId);
	}

	private bool IsDetachable(sbyte slot)
	{
		ItemKey itemKey = CurrEnemyEquipments[slot];
		if (!IsDetachable(itemKey))
		{
			return false;
		}
		return itemKey.ItemType != 1 || !IsGodArmor(itemKey.Id);
	}

	public LeiZuBoJianShi()
	{
	}

	public LeiZuBoJianShi(CombatSkillKey skillKey)
		: base(skillKey, 8203, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			if (PowerMatchAffectRequire(power) && context.Random.CheckPercentProb(50))
			{
				DoAffect(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		sbyte slot = RandomTargetSlot(context.Random);
		int itemGrade = DoChangeEquipment(context, slot);
		if (itemGrade >= 0)
		{
			int power = 20 * (itemGrade + 1);
			DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, CombatStateId, power);
			ShowSpecialEffectTips(0);
		}
	}

	private sbyte RandomTargetSlot(IRandomSource random)
	{
		ItemKey clothKey = CurrEnemyEquipments[4];
		List<sbyte> slotPool = ObjectPool<List<sbyte>>.Instance.Get();
		slotPool.Clear();
		if (IsDetachable(clothKey) && random.CheckPercentProb(50))
		{
			slotPool.Add(4);
		}
		else
		{
			slotPool.AddRange(CanRemoveSlots.Where(IsDetachable));
		}
		if (slotPool.Count == 0 && IsDetachable(clothKey))
		{
			slotPool.Add(4);
		}
		sbyte slot = (sbyte)((slotPool.Count > 0) ? slotPool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(slotPool);
		return slot;
	}

	private int DoChangeEquipment(DataContext context, sbyte slot)
	{
		if (slot < 0)
		{
			return -1;
		}
		ItemKey itemKey = CurrEnemyEquipments[slot];
		if (base.CurrEnemyChar.GetRawCreateCollection().Contains(itemKey))
		{
			base.CurrEnemyChar.RevertRawCreate(context, itemKey);
			itemKey = CurrEnemyEquipments[slot];
		}
		base.CurrEnemyChar.GetCharacter().ChangeEquipment(context, slot, -1, ItemKey.Invalid);
		for (sbyte i = 0; i < 7; i++)
		{
			if (EquipmentSlotHelper.GetSlotByBodyPartType(i) == slot)
			{
				base.CurrEnemyChar.Armors[i] = ItemKey.Invalid;
			}
		}
		return ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
	}
}
