namespace GameData.Domains.Combat;

/// <summary>
/// 同道指令实现相关拓展方法
/// </summary>
public static class TeammateCommandImplementExtensions
{
	/// <summary>
	/// 是否为推拉指令
	/// </summary>
	/// <param name="implement"></param>
	/// <returns></returns>
	public static bool IsPushOrPull(this ETeammateCommandImplement implement)
	{
		if ((uint)(implement - 2) <= 1u || implement == ETeammateCommandImplement.PushOrPullIntoDanger)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否为攻击或同款指令
	/// </summary>
	/// <param name="implement"></param>
	/// <returns></returns>
	public static bool IsAttack(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Attack || implement == ETeammateCommandImplement.GearMateA || implement == ETeammateCommandImplement.AttackSpecialPoison)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否为防御或同款指令
	/// </summary>
	/// <param name="implement"></param>
	/// <returns></returns>
	public static bool IsDefend(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Defend || implement == ETeammateCommandImplement.GearMateB)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否为出战或同款指令
	/// </summary>
	/// <param name="implement"></param>
	/// <returns></returns>
	public static bool IsFight(this ETeammateCommandImplement implement)
	{
		if (implement == ETeammateCommandImplement.Fight || implement == ETeammateCommandImplement.FightSpecialGrow)
		{
			return true;
		}
		return false;
	}
}
