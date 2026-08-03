using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Yazi : CombatStateEffectBase
{
	private static readonly CValuePercent AddDamagePercent = 33;

	private OuterAndInnerInts _addingDamageValue;

	protected override short CombatStateId => 200;

	public Yazi(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(89, EDataModifyType.Custom, -1);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (defenderId == base.CharacterId && damageValue > 0)
		{
			if (isInner)
			{
				_addingDamageValue.Inner += damageValue * AddDamagePercent;
			}
			else
			{
				_addingDamageValue.Outer += damageValue * AddDamagePercent;
			}
		}
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.FieldId == 89 && dataKey.CharId == base.CharacterId)
		{
			ref int value = ref dataKey.CustomParam1 == 1 ? ref _addingDamageValue.Inner : ref _addingDamageValue.Outer;
			if (value > 0)
			{
				dataValue += value;
				value = 0;
			}
			return dataValue;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
