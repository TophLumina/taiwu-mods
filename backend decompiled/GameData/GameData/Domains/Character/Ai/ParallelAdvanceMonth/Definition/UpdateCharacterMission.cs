using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;

public class UpdateCharacterMission : CharacterParallelAction<UpdateCharacterMission>, ICharacterParallelAction
{
	public int BeginAreaId => -1;

	public int EndAreaId => 141;

	public bool IsEnabled => DomainManager.World.GetWorldFunctionsStatus(30);

	public void Execute(DataContext context, Character character)
	{
		character.PostAdvanceMonth_UpdateMissions(context);
	}
}
