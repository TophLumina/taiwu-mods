using GameData.Serializer;

namespace GameData.Domains.Global;

public interface IGameStatRecord : ISerializableGameData
{
	int GetStat();

	bool SetStat<T>(T value, EStatInfoSetType setType);

	bool Contains(int value);

	bool Overlaps<T>(T other);
}
