using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 需要显示的化解信息
/// </summary>
public struct ShowAvoidData : ISerializableGameData
{
	public sbyte HitType;

	public short Value;

	public ShowAvoidData(sbyte hitType, short value)
	{
		HitType = hitType;
		Value = value;
	}

	public ShowAvoidData(ShowAvoidData other)
	{
		HitType = other.HitType;
		Value = other.Value;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)HitType;
		*(short*)(pData + 1) = Value;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		HitType = (sbyte)(*pData);
		Value = *(short*)(pData + 1);
		return 4;
	}
}
