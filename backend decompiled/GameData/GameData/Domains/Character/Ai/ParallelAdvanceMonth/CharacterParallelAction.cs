namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth;

public class CharacterParallelAction<T> where T : CharacterParallelAction<T>, ICharacterParallelAction, new()
{
	public static readonly T Instance = new T();
}
