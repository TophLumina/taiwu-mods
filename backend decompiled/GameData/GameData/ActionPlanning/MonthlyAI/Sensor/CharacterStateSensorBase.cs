using GameData.ActionPlanning.Interface;
using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public abstract class CharacterStateSensorBase : ISensor<IStateMemory<Character, StateKey>, Character, StateKey>
{
	public int Sense(IStateMemory<Character, StateKey> currMemory, Character selfChar, StateKey stateKey)
	{
		CharacterStateMemory memory = (CharacterStateMemory)currMemory;
		ContextArgGroupHandle args = memory.Args;
		return Sense(args, selfChar, stateKey);
	}

	public abstract int Sense(ContextArgGroupHandle args, Character selfChar, StateKey stateKey);
}
