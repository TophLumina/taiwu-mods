using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 兵器期望内外比例数据（仅用于同道等临时设置场景）
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class WeaponExpectInnerRatioData : ISerializableGameData
{
	/// <summary>
	/// 用于序列化的数据
	/// (同道角色 ID、武器栏位索引) -&gt; 期望的内外比例
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<IntPair, sbyte> _internalValue = new Dictionary<IntPair, sbyte>();

	/// <summary>
	/// 设置某武器栏位期望内外比例
	/// </summary>
	/// <param name="charId">角色 ID</param>
	/// <param name="weaponIndex"></param>
	/// <param name="expectInnerRatio"></param>
	public void SetValue(int charId, int weaponIndex, sbyte expectInnerRatio)
	{
		_internalValue[new IntPair(charId, weaponIndex)] = expectInnerRatio;
	}

	/// <summary>
	/// 获取某武器栏位期望内外比例
	/// </summary>
	/// <param name="charId"></param>
	/// <param name="weaponIndex"></param>
	/// <returns></returns>
	public sbyte GetValue(int charId, int weaponIndex)
	{
		return _internalValue.GetOrDefault<IntPair, sbyte>(new IntPair(charId, weaponIndex), -1);
	}

	/// <summary>
	/// 清空所有已设置的数据
	/// </summary>
	public void Clear()
	{
		_internalValue.Clear();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public WeaponExpectInnerRatioData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public WeaponExpectInnerRatioData(WeaponExpectInnerRatioData other)
	{
		_internalValue = ((other._internalValue == null) ? null : new Dictionary<IntPair, sbyte>(other._internalValue));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(WeaponExpectInnerRatioData other)
	{
		_internalValue = ((other._internalValue == null) ? null : new Dictionary<IntPair, sbyte>(other._internalValue));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref _internalValue) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
