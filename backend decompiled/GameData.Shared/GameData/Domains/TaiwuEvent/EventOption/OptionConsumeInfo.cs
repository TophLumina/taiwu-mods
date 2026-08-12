using System;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.EventOption;

/// <summary>
/// 事件选项消耗信息
/// </summary>
[Serializable]
[SerializableGameData(NotForDisplayModule = true)]
public struct OptionConsumeInfo : ISerializableGameData
{
	/// <summary>
	/// 消耗类型 <see cref="T:Config.EventOptionConsumeType.DefKey" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ConsumeType;

	/// <summary>
	/// 消耗数量
	/// </summary>
	[SerializableGameDataField]
	public int ConsumeCount;

	/// <summary>
	/// 持有数量
	/// </summary>
	[SerializableGameDataField]
	public int HoldCount;

	/// <summary>
	/// 是否足够
	/// </summary>
	[SerializableGameDataField]
	public bool HasEnough;

	/// <summary>
	/// 是否自动扣除
	/// </summary>
	public bool AutoConsume;

	/// <summary>
	/// Ctor
	/// </summary>
	/// <param name="type"></param>
	/// <param name="count"></param>
	/// <param name="auto"></param>
	public OptionConsumeInfo(sbyte type, int count, bool auto)
	{
		ConsumeType = type;
		ConsumeCount = count;
		AutoConsume = auto;
		HoldCount = 0;
		HasEnough = false;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ConsumeType;
		byte* num = pData + 1;
		*(int*)num = ConsumeCount;
		byte* num2 = num + 4;
		*(int*)num2 = HoldCount;
		byte* num3 = num2 + 4;
		*num3 = (HasEnough ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ConsumeType = (sbyte)(*pCurrData);
		pCurrData++;
		ConsumeCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldCount = *(int*)pCurrData;
		pCurrData += 4;
		HasEnough = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
