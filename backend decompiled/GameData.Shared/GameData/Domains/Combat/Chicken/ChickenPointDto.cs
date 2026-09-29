using GameData.Combat.Chicken;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat.Chicken;

[SerializeFrom(typeof(ChickenPointRuntime))]
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct ChickenPointDto : ISerializableGameData
{
	private const int TypeCount = 8;

	private const int ValueCount = 8;

	private const int IdCount = 32;

	private const int TypePos = 0;

	private const int ValuePos = 8;

	private const int IdPos = 16;

	private ulong _transferValue;

	public static explicit operator ChickenPointDto(ChickenPointRuntime runtime)
	{
		ulong transferValue = 0uL;
		byte type = ((runtime.Type == -1) ? byte.MaxValue : ((byte)runtime.Type));
		transferValue = BitOperation.SetSubUlong(transferValue, 0, 8, type);
		byte value = (byte)runtime.Value;
		transferValue = BitOperation.SetSubUlong(transferValue, 8, 8, value);
		transferValue = BitOperation.SetSubUlong(transferValue, 16, 32, (uint)runtime.Id);
		return new ChickenPointDto
		{
			_transferValue = transferValue
		};
	}

	public static explicit operator ChickenPointRuntime(ChickenPointDto dto)
	{
		ulong transferValue = dto._transferValue;
		byte typeDto = (byte)BitOperation.GetSubUlong(transferValue, 0, 8);
		sbyte type = (sbyte)((typeDto == byte.MaxValue) ? (-1) : ((sbyte)typeDto));
		return new ChickenPointRuntime(point: new ChickenPoint(type, (int)BitOperation.GetSubUlong(transferValue, 8, 8)), id: (int)BitOperation.GetSubUlong(transferValue, 16, 32));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 64;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = _transferValue;
		return GetSerializedSize();
	}

	public unsafe int Deserialize(byte* pData)
	{
		_transferValue = *(ulong*)pData;
		return GetSerializedSize();
	}
}
