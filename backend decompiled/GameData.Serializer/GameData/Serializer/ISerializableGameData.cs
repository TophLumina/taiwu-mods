namespace GameData.Serializer;

public interface ISerializableGameData
{
	bool IsSerializedSizeFixed();

	int GetSerializedSize();

	unsafe int Serialize(byte* pData);

	unsafe int Deserialize(byte* pData);
}
