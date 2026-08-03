using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class UpdateCharacterStatus : CharacterParallelAction<UpdateCharacterStatus>, ICharacterParallelAction
{
	public int BeginAreaId => -2;

	public int EndAreaId => 141;

	public void Execute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateStatus(context);
	}

	public void KidnappedExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateStatus(context);
	}

	public void PrisonerExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateStatus(context);
	}

	public void TaiwuExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_UpdateStatus(context);
	}

	public void GearMateExecute(DataContext context, Character character)
	{
		character.PeriAdvanceMonth_GearMateUpdateStatus(context);
	}
}
