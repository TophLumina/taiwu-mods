using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.EquipmentMastery;

public abstract class EquipmentMasteryBase : AutoCollectEffectBase
{
	protected readonly int ItemId;

	private readonly short _specialEffectId;

	private List<byte> _affectingIndexes;

	protected bool IsValid => (DomainManager.Item.GetEquipmentById(ItemId)?.GetCurrDurability() ?? 0) > 0;

	protected abstract EEquipmentMasteryType MasteryType { get; }

	protected bool CheckAffect(IRandomSource random, int baseAffectOdds = 25)
	{
		int affectOdds = CalcAffectOdds(baseAffectOdds);
		return random.CheckPercentProb(affectOdds);
	}

	protected int CalcAffectOdds(int baseAffectOdds = 25)
	{
		short equipmentMastery = CharObj.GetWeaponSwitchSpeed();
		int affectOdds = CFormula.CalcEquipmentMasteryAffectOdds(baseAffectOdds, equipmentMastery);
		return DomainManager.SpecialEffect.ModifyValue(base.CharacterId, 338, affectOdds, (int)MasteryType);
	}

	protected EquipmentMasteryBase()
	{
	}

	protected EquipmentMasteryBase(int charId, int itemId, short specialEffectId)
		: base(charId)
	{
		ItemId = itemId;
		_specialEffectId = specialEffectId;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_ChangeDurabilityToZero(OnChangeDurabilityToZero);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeDurabilityToZero(OnChangeDurabilityToZero);
		base.OnDisable(context);
	}

	private void OnChangeDurabilityToZero(DataContext context, CombatCharacter character, ItemKey itemKey)
	{
		if (character.GetId() == base.CharacterId && itemKey.Id == ItemId)
		{
			DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1798, itemKey, 0);
		}
	}

	protected void ShowSpecialEffectTips(byte index = 0)
	{
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, _specialEffectId, index);
	}

	public void ShowSpecialEffectTipsOnceInFrame(byte index = 0)
	{
		if (_affectingIndexes == null)
		{
			_affectingIndexes = new List<byte>();
		}
		if (!_affectingIndexes.Contains(index))
		{
			_affectingIndexes.Add(index);
			if (_affectingIndexes.Count <= 1)
			{
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
			}
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		foreach (byte index in _affectingIndexes)
		{
			ShowSpecialEffectTips(index);
		}
		_affectingIndexes.Clear();
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}
}
