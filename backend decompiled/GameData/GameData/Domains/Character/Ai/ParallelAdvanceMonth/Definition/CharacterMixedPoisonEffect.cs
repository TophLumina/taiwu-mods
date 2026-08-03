using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterMixedPoisonEffect : CharacterParallelAction<CharacterMixedPoisonEffect>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_MixedPoisonEffect(context);
	}

	public void KidnappedExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_MixedPoisonEffect(context);
	}

	public void PrisonerExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_MixedPoisonEffect(context);
	}

	public void TaiwuExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_MixedPoisonEffect(context);
	}
}
