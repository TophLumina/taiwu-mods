using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

public struct SectFunctionStatuses : ISerializableGameData
{
	[SerializeTo(typeof(byte))]
	public enum SectFunctionStatusType : byte
	{
		SpecialInteractionUnlocked,
		UpgradedInteractionUnlocked
	}

	private ulong _bits;

	public bool this[SectFunctionStatusType type]
	{
		get
		{
			return Get(type);
		}
		set
		{
			Set(type, value);
		}
	}

	public void Set(SectFunctionStatusType functionStatusType, bool isOn)
	{
		_bits = BitOperation.SetBit(_bits, (int)functionStatusType, isOn);
	}

	public bool Get(SectFunctionStatusType functionStatusType)
	{
		return BitOperation.GetBit(_bits, (int)functionStatusType);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = _bits;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_bits = *(ulong*)pData;
		return 8;
	}
}
