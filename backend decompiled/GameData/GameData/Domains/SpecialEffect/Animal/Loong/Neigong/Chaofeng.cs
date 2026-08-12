using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Chaofeng : AnimalEffectBase
{
	private const int AddInjuryRequireDistance = 5;

	private int _forwardMovedDistance;

	private int _backwardMovedDistance;

	public Chaofeng()
	{
	}

	public Chaofeng(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		base.OnDisable(context);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover.IsAlly == base.CombatChar.IsAlly || isForced) && isMove && base.IsCurrent)
		{
			if (distance < 0)
			{
				_forwardMovedDistance += -distance;
			}
			else if (distance > 0)
			{
				_backwardMovedDistance += distance;
			}
			if (_forwardMovedDistance > 5)
			{
				_forwardMovedDistance = DoAddInjury(context, mover, _forwardMovedDistance, isInner: false);
			}
			if (_backwardMovedDistance > 5)
			{
				_backwardMovedDistance = DoAddInjury(context, mover, _backwardMovedDistance, isInner: true);
			}
		}
	}

	private int DoAddInjury(DataContext context, CombatCharacter combatChar, int movedDistance, bool isInner)
	{
		int count = movedDistance / 5;
		AddPowerDamageInjury(context, combatChar, isInner, count);
		ShowSpecialEffectTips(isInner, 1, 0);
		return movedDistance % 5;
	}
}
