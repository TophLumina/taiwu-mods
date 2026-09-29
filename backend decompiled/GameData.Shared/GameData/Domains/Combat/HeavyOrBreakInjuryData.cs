using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct HeavyOrBreakInjuryData : ISerializableGameData
{
	private const int Capacity = 8;

	[SerializableGameDataField]
	private unsafe fixed sbyte _types[8];

	public unsafe EHeavyOrBreakType this[int bodyPart]
	{
		get
		{
			if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
			{
				throw new ArgumentOutOfRangeException("bodyPart", bodyPart, "out of range");
			}
			return (EHeavyOrBreakType)_types[bodyPart];
		}
		set
		{
			if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
			{
				throw new ArgumentOutOfRangeException("bodyPart", bodyPart, "out of range");
			}
			_types[bodyPart] = (sbyte)value;
		}
	}

	public unsafe void Initialize()
	{
		fixed (sbyte* types = _types)
		{
			*(long*)types = 0L;
		}
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
		fixed (sbyte* pItems = _types)
		{
			*(long*)pData = *(long*)pItems;
		}
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* types = _types)
		{
			*(long*)types = *(long*)pData;
		}
		return 8;
	}
}
