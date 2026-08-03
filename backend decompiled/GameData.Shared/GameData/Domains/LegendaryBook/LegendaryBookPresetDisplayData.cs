using GameData.Serializer;

namespace GameData.Domains.LegendaryBook;

/// <summary>
/// 奇书-预设组件展示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class LegendaryBookPresetDisplayData : ISerializableGameData
{
	/// <summary>
	/// 最多拥有的预设方案数量
	/// </summary>
	[SerializableGameDataField]
	public int MaxPresetAmount;

	/// <summary>
	/// 当前已解锁的预设方案数量
	/// </summary>
	[SerializableGameDataField]
	public int CurrentUnlockedAmount;

	/// <summary>
	/// 当前使用的预设方案索引, 从0开始
	/// </summary>
	[SerializableGameDataField]
	public int CurrentUsingPresetIndex;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = MaxPresetAmount;
		byte* num = pData + 4;
		*(int*)num = CurrentUnlockedAmount;
		byte* num2 = num + 4;
		*(int*)num2 = CurrentUsingPresetIndex;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		MaxPresetAmount = *(int*)pCurrData;
		pCurrData += 4;
		CurrentUnlockedAmount = *(int*)pCurrData;
		pCurrData += 4;
		CurrentUsingPresetIndex = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
