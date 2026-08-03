using GameData.Serializer;

namespace GameData.Utilities;

public interface IVariant : ISerializableGameData
{
	IVariant Duplicate();
}
