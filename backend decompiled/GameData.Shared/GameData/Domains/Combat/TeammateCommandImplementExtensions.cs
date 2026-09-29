namespace GameData.Domains.Combat;

public static class TeammateCommandImplementExtensions
{
	public static bool IsMove(this ETeammateCommandImplement implement)
	{
		if ((uint)(implement - 2) <= 1u || implement == ETeammateCommandImplement.PushOrPullIntoDanger || implement == ETeammateCommandImplement.GotoTargetDistance)
		{
			return true;
		}
		return false;
	}

	public static bool IsAttack(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Attack || implement == ETeammateCommandImplement.GearMateA || implement == ETeammateCommandImplement.AttackSpecialPoison)
		{
			return true;
		}
		return false;
	}

	public static bool IsDefend(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Defend || implement == ETeammateCommandImplement.GearMateB)
		{
			return true;
		}
		return false;
	}

	public static bool IsFight(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Fight || implement == ETeammateCommandImplement.FightSpecialGrow)
		{
			return true;
		}
		return false;
	}
}
