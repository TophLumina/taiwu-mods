using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongMetalImplementMindMark : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const int AddMindMarkRequireDistance = 10;

	private int _distanceOnJumpBegin;

	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		Events.RegisterHandler_MoveBegin(OnMoveBegin);
		Events.RegisterHandler_MoveEnd(OnMoveEnd);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_MoveBegin(OnMoveBegin);
		Events.UnRegisterHandler_MoveEnd(OnMoveEnd);
	}

	private void OnMoveBegin(DataContext context, CombatCharacter mover, int distance, bool isJump)
	{
		if (mover.GetId() == EffectBase.CharacterId && isJump)
		{
			_distanceOnJumpBegin = DomainManager.Combat.GetCurrentDistance();
		}
	}

	private void OnMoveEnd(DataContext context, CombatCharacter mover, int distance, bool isJump)
	{
		if (mover.GetId() == EffectBase.CharacterId && isJump)
		{
			int distanceDelta = Math.Abs(DomainManager.Combat.GetCurrentDistance() - _distanceOnJumpBegin);
			if (distanceDelta >= 10)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!mover.IsAlly);
				int mindMarkCount = distanceDelta / 10;
				EffectBase.AddPowerDamageMind(context, enemyChar, mindMarkCount);
				EffectBase.ShowSpecialEffectTips(1);
			}
		}
	}
}
