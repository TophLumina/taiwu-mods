using Config;

namespace GameData.DLC;

public static class PolymorphRuntimeHelper
{
	public static bool IsAlive(this IPolymorphRuntime runtime)
	{
		return (runtime.State & EPolymorphState.Alive) != 0;
	}

	public static int GetCurrentCharacterId(this IPolymorphRuntime runtime)
	{
		if (runtime.IsAlive())
		{
			if (!runtime.ContainsState(EPolymorphState.Male))
			{
				return runtime.FemaleCharacterId;
			}
			return runtime.MaleCharacterId;
		}
		return -1;
	}

	public static bool ContainsCharacter(this IPolymorphRuntime runtime, int characterId)
	{
		if (characterId != runtime.MaleCharacterId)
		{
			return characterId == runtime.FemaleCharacterId;
		}
		return true;
	}

	public static bool MatchCharacter(this IPolymorphRuntime runtime, int characterId)
	{
		if (characterId != runtime.MaleCharacterId || !runtime.ContainsState(EPolymorphState.Male))
		{
			if (characterId == runtime.FemaleCharacterId)
			{
				return runtime.ContainsState(EPolymorphState.Female);
			}
			return false;
		}
		return true;
	}

	public static bool ContainsState(this IPolymorphRuntime runtime, EPolymorphState state)
	{
		if (state == EPolymorphState.None)
		{
			if (runtime.State == EPolymorphState.None)
			{
				if (runtime.MaleCharacterId >= 0)
				{
					return runtime.FemaleCharacterId < 0;
				}
				return true;
			}
			return false;
		}
		return (runtime.State & state) == state;
	}

	public static void ChangeState(this IPolymorphRuntime runtime, EPolymorphState newState)
	{
		if (!runtime.ChangeStateWithoutAssert(newState))
		{
			PredefinedLog.DefValue.PolymorphStateChangeFailed.Log(runtime.State, newState);
		}
	}

	private static bool ChangeStateWithoutAssert(this IPolymorphRuntime runtime, EPolymorphState newState)
	{
		EPolymorphState state = runtime.State;
		if (newState == state)
		{
			return false;
		}
		if (state == EPolymorphState.None)
		{
			runtime.State = newState;
		}
		else if ((newState == EPolymorphState.Returned || newState == EPolymorphState.Dead) ? true : false)
		{
			runtime.State = newState;
		}
		else
		{
			bool flag = (uint)(newState - 1) <= 1u;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = ((state == EPolymorphState.Returned || state == EPolymorphState.Dead) ? true : false);
				flag2 = flag3;
			}
			if (flag2)
			{
				runtime.State = newState;
			}
			else
			{
				if (newState != EPolymorphState.WaitForReturn || !runtime.IsAlive())
				{
					return false;
				}
				runtime.State |= newState;
			}
		}
		return true;
	}
}
