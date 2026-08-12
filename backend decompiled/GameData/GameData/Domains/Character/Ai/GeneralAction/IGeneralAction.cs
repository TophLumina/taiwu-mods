using GameData.Common;

namespace GameData.Domains.Character.Ai.GeneralAction;

public interface IGeneralAction
{
	sbyte ActionEnergyType { get; }

	bool CheckValid(Character selfChar, Character targetChar);

	void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar);

	void ApplyChanges(DataContext context, Character selfChar, Character targetChar);
}
