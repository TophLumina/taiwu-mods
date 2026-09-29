using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public interface ICombatCharacterBridge
{
	int GetId();

	int GetStanceValue();

	int GetBreathValue();

	int GetMobilityValue();

	byte GetTrickCount(sbyte trickType);

	short GetWugCount();

	NeiliAllocation GetNeiliAllocation();

	NeiliAllocation GetOriginNeiliAllocation();

	short GetDisorderOfQi();

	short GetOldDisorderOfQi();

	ref PoisonInts GetOldPoison();

	Injuries GetOldInjuries();

	EHealthType GetHealthType();
}
