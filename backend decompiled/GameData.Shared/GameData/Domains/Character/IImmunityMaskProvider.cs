using System.Collections.Generic;

namespace GameData.Domains.Character;

public interface IImmunityMaskProvider
{
	bool InnerInjuryImmunity => false;

	bool OuterInjuryImmunity => false;

	bool MindImmunity => false;

	bool FlawImmunity => false;

	bool AcupointImmunity => false;

	bool FatalImmunity => false;

	bool DieImmunity => false;

	bool HealthImmunity => false;

	IReadOnlyList<bool> PoisonImmunities => null;
}
