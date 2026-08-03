using GameData.ActionPlanning.Interface;
using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public class TriggerStateSensor : ISensor<IStateMemory<Character, StateKey>, Character, StateKey>
{
	public int Sense(IStateMemory<Character, StateKey> currMemory, Character selfChar, StateKey stateKey)
	{
		return 0;
	}
}
