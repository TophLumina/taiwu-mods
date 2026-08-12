using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface ISensor<in TMemory, in TObject, in TStateKey> where TMemory : IStateMemory<TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	int Sense(TMemory currMemory, TObject obj, TStateKey key);
}
