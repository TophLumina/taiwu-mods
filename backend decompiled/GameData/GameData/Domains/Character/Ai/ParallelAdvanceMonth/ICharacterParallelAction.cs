using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth;

public interface ICharacterParallelAction
{
	int BeginAreaId { get; }

	int EndAreaId { get; }

	bool IsEnabled => true;

	void Execute(DataContext context, Character character);

	void HiddenExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	void TaiwuGroupExecute(DataContext context, Character character)
	{
		Execute(context, character);
	}

	void TaiwuExecute(DataContext context, Character character)
	{
	}

	void KidnappedExecute(DataContext context, Character character)
	{
	}

	void PrisonerExecute(DataContext context, Character character)
	{
	}

	void InfectedExecute(DataContext context, Character character)
	{
	}

	void GearMateExecute(DataContext context, Character character)
	{
	}

	void AnimalCharExecute(DataContext context, Character character)
	{
	}
}
