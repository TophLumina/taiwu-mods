using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Yazi : AnimalEffectBase
{
	private OuterAndInnerInts _addingDamageValue;

	private bool _affecting;

	public Yazi()
	{
	}

	public Yazi(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
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
				_addingDamageValue.Inner += damageValue;
			}
			else
			{
				_addingDamageValue.Outer += damageValue;
			}
			ShowSpecialEffectTipsOnceInFrame(0);
			UpdateAffecting();
		}
	}

	private void UpdateAffecting()
	{
		bool affecting = _addingDamageValue.IsNonZero;
		if (affecting != _affecting)
		{
			_affecting = affecting;
			if (!_affecting)
			{
				DomainManager.Combat.AddToCheckFallenSet(base.CharacterId);
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
				UpdateAffecting();
			}
			return dataValue;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 281)
		{
			return dataValue;
		}
		return dataValue || _affecting;
	}
}
