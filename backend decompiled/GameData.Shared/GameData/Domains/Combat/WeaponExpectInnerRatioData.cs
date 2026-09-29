using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class WeaponExpectInnerRatioData : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<IntPair, sbyte> _internalValue = new Dictionary<IntPair, sbyte>();

	public void SetValue(int charId, int weaponIndex, sbyte expectInnerRatio)
	{
		_internalValue[new IntPair(charId, weaponIndex)] = expectInnerRatio;
	}

	public sbyte GetValue(int charId, int weaponIndex)
	{
		return _internalValue.GetOrDefault<IntPair, sbyte>(new IntPair(charId, weaponIndex), -1);
	}

	public void Clear()
	{
		_internalValue.Clear();
	}

	public WeaponExpectInnerRatioData()
	{
	}

	public WeaponExpectInnerRatioData(WeaponExpectInnerRatioData other)
	{
		_internalValue = ((other._internalValue == null) ? null : new Dictionary<IntPair, sbyte>(other._internalValue));
	}

	public void Assign(WeaponExpectInnerRatioData other)
	{
		_internalValue = ((other._internalValue == null) ? null : new Dictionary<IntPair, sbyte>(other._internalValue));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(_internalValue);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref _internalValue) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pData, ref _internalValue) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
