namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth;

public class CharacterParallelActionWithTarget<T> where T : CharacterParallelActionWithTarget<T>, ICharacterParallelActionWithTarget, new()
{
	public static readonly T Instance = new T();
}
