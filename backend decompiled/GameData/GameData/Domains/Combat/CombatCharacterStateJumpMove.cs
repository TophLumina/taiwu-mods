using System;
using Config;
using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateJumpMove : CombatCharacterStateBase
{
	private short _aniFrame;

	private short _changeDistanceFrame;

	public CombatCharacterStateJumpMove(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.JumpMove)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[CombatChar.PauseJumpMoveSkillId];
		string moveAni = skillConfig.JumpAni[(!CombatChar.MoveForward) ? 1u : 0u];
		string moveParticle = skillConfig.JumpParticle[(!CombatChar.MoveForward) ? 1u : 0u];
		float jumpMoveDuration = ((skillConfig.JumpChangeDistanceDuration > 0) ? ((float)skillConfig.JumpChangeDistanceDuration / 60f) : AnimDataCollection.Data[moveAni].Duration);
		CombatChar.NeedPauseJumpMove = false;
		CombatChar.SetAnimationToPlayOnce(moveAni, context);
		CombatChar.SetParticleToPlay(moveParticle, context);
		CombatChar.SetJumpChangeDistanceDuration(jumpMoveDuration, context);
		CurrentCombatDomain.UpdateAllTeammateCommandUsable(context, CombatChar.IsAlly, -1);
		_aniFrame = (short)AnimDataCollection.GetDurationFrame(moveAni);
		_changeDistanceFrame = Math.Max(skillConfig.JumpChangeDistanceFrame, (short)1);
	}

	public override void OnExit()
	{
		CombatChar.SetJumpChangeDistanceDuration(-1f, CombatChar.GetDataContext());
		if (CombatChar.MoveData.JumpMoveSkillId < 0)
		{
			CombatChar.PauseJumpMoveSkillId = -1;
		}
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_changeDistanceFrame > 0)
		{
			_changeDistanceFrame--;
			if (_changeDistanceFrame == 0)
			{
				DomainManager.Combat.ChangeDistance(CombatChar.GetDataContext(), CombatChar, CombatChar.PauseJumpMoveDistance);
			}
		}
		if (_aniFrame > 0)
		{
			_aniFrame--;
			if (_aniFrame == 0)
			{
				CombatChar.StateMachine.TranslateState();
			}
		}
		return false;
	}
}
