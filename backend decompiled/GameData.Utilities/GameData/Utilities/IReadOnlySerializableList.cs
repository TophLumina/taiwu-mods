using GameData.Serializer;

namespace GameData.Utilities;

public interface IReadOnlySerializableList
{
	int GetCount();

	ISerializableGameData GetElementAt(int index);
}
