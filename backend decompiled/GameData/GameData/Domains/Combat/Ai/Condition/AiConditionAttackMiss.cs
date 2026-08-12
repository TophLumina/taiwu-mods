using System;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AttackMiss)]
public class AiConditionAttackMiss : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter enemy = DomainManager.Combat.GetCombatCharacter(!combatChar.IsAlly);
		short moveCd = enemy.GetMoveCd();
		int frameCount = combatChar.CalcNormalAttackStartupFrames();
		short targetDistance = DomainManager.Combat.GetNearlyOutDistance(combatChar.GetAttackRange());
		short currentDistance = DomainManager.Combat.GetCurrentDistance();
		bool moveForward = targetDistance < currentDistance;
		short maxJumpDist = (moveForward ? enemy.MoveData.MaxJumpForwardDist : enemy.MoveData.MaxJumpBackwardDist);
		if (maxJumpDist > 0)
		{
			int skillMobility = enemy.GetMobilityValue();
			short moveSkillId = enemy.GetAffectingMoveSkillId();
			int frameCostMobility = DomainManager.Combat.GetSkillCostMobilityPerFrame(enemy, moveSkillId);
			int moveCostMobility = DomainManager.Combat.GetSkillMoveCostMobility(enemy, moveSkillId);
			int maxMoveCount = skillMobility / Math.Max(frameCostMobility * moveCd + moveCostMobility, 1);
			int maxMoveFrame = Math.Min(frameCount, maxMoveCount * moveCd);
			int unitDistance = (enemy.MoveData.CanPartlyJump ? 10 : maxJumpDist);
			int unitFrame = (enemy.MoveData.CanPartlyJump ? enemy.MoveData.PrepareProgressUnit : (enemy.MoveData.PrepareProgressUnit * maxJumpDist / 10));
			int unit = maxMoveFrame / Math.Max(unitFrame, 1);
			int maxMoveDistance = unit * unitDistance;
			int distanceDelta = (moveForward ? (-maxMoveDistance) : maxMoveDistance);
			int simulateDistance = currentDistance + distanceDelta;
			bool isSameDirection = simulateDistance < targetDistance == targetDistance < currentDistance;
			if (simulateDistance == targetDistance || isSameDirection)
			{
				return true;
			}
			int remainFrame = frameCount - maxMoveFrame;
			return remainFrame > 0 && CanReachInTimeByMobility(targetDistance, remainFrame, simulateDistance);
		}
		int canMoveDistance = frameCount / Math.Max(moveCd, (short)1);
		return CanReachInTimeByMobility(targetDistance, canMoveDistance, currentDistance);
	}

	private bool CanReachInTimeByMobility(int targetDistance, int canMoveDistance, int currDistance)
	{
		return canMoveDistance >= Math.Abs(targetDistance - currDistance);
	}
}
