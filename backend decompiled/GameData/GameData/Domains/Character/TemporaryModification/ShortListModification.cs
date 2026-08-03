using GameData.Serializer;

namespace GameData.Domains.Character.TemporaryModification;

[SerializableGameData(NotForDisplayModule = true)]
public struct ShortListModification(sbyte modificationType, short index, short element) : ISerializableGameData
{
	public sbyte ModificationType = modificationType;

	public short Index = index;

	public short Element = element;

	public static int GetFixedSerializedSize()
	{
		return 5;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 5;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ModificationType;
		*(short*)(pData + 1) = Index;
		((short*)(pData + 1))[1] = Element;
		return 5;
	}

	public unsafe int Deserialize(byte* pData)
	{
		ModificationType = (sbyte)(*pData);
		Index = *(short*)(pData + 1);
		Element = ((short*)(pData + 1))[1];
		return 5;
	}
}
