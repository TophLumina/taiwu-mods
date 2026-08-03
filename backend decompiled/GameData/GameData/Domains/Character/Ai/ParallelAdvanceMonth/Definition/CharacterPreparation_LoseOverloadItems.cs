using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class CharacterPreparation_LoseOverloadItems : CharacterParallelAction<CharacterPreparation_LoseOverloadItems>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_LoseOverLoadedItems(context);
	}

	public void TaiwuExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	public void KidnappedExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	public void PrisonerExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	public void InfectedExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	public void GearMateExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_GearMateLoseOverLoadedItems(context);
	}
}
