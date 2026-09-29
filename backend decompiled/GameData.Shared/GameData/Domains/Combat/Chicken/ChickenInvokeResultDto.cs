using GameData.Combat.Chicken;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat.Chicken;

[SerializeFrom(typeof(ChickenPointInvokeResult))]
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct ChickenInvokeResultDto : ISerializableGameData
{
	private const int SuccessCount = 8;

	private const int TypeGroupCount = 8;

	private const int ValueGroupCount = 8;

	private const int SuccessPos = 0;

	private const int TypeGroupPos = 8;

	private const int ValueGroupPos = 16;

	[SerializableGameDataField]
	private uint _transferValue;

	public static explicit operator ChickenInvokeResultDto(ChickenPointInvokeResult result)
	{
		uint transferValue = 0u;
		transferValue = BitOperation.SetSubUint(transferValue, 0, 8, result.Success ? 1u : 0u);
		transferValue = BitOperation.SetSubUint(transferValue, 8, 8, (byte)result.TypeGroup);
		transferValue = BitOperation.SetSubUint(transferValue, 16, 8, (byte)result.ValueGroup);
		return new ChickenInvokeResultDto
		{
			_transferValue = transferValue
		};
	}

	public static explicit operator ChickenPointInvokeResult(ChickenInvokeResultDto dto)
	{
		uint transferValue = dto._transferValue;
		bool success = BitOperation.GetSubUint(transferValue, 0, 8) != 0;
		EChickenTypeGroup typeGroup = (EChickenTypeGroup)BitOperation.GetSubUint(transferValue, 8, 8);
		EChickenValueGroup valueGroup = (EChickenValueGroup)BitOperation.GetSubUint(transferValue, 16, 8);
		return new ChickenPointInvokeResult(success, typeGroup, valueGroup);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 32;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(uint*)pData = _transferValue;
		return GetSerializedSize();
	}

	public unsafe int Deserialize(byte* pData)
	{
		_transferValue = *(uint*)pData;
		return GetSerializedSize();
	}
}
