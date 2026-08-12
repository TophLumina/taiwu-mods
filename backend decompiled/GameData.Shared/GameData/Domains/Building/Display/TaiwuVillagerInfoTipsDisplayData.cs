using GameData.Serializer;

namespace GameData.Domains.Building.Display;

[SerializableGameData(NoCopyConstructors = true)]
public class TaiwuVillagerInfoTipsDisplayData : ISerializableGameData
{
	/// <summary>
	/// 总人数
	/// </summary>
	[SerializableGameDataField]
	public int TotalCount;

	/// <summary>
	/// 空闲人数
	/// </summary>
	[SerializableGameDataField]
	public int IdleCount;

	/// <summary>
	/// 经营中人数
	/// </summary>
	[SerializableGameDataField]
	public int ShopManageCount;

	/// <summary>
	/// 派遣中人数
	/// </summary>
	[SerializableGameDataField]
	public int DispatchCount;

	/// <summary>
	/// 未成年人数
	/// </summary>
	[SerializableGameDataField]
	public int MinorsCount;

	/// <summary>
	/// 成年人数
	/// </summary>
	[SerializableGameDataField]
	public int AdultsCount;

	/// <summary>
	/// 研习中人数
	/// </summary>
	[SerializableGameDataField]
	public int LearningCount;

	/// <summary>
	/// 在石屋中人数
	/// </summary>
	[SerializableGameDataField]
	public int InStoneRoomCount;

	public static TaiwuVillagerInfoTipsDisplayData CreateInvalid()
	{
		return new TaiwuVillagerInfoTipsDisplayData
		{
			TotalCount = -1,
			IdleCount = -1,
			ShopManageCount = -1,
			DispatchCount = -1,
			MinorsCount = -1,
			AdultsCount = -1,
			LearningCount = -1,
			InStoneRoomCount = -1
		};
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 32;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = TotalCount;
		byte* num = pData + 4;
		*(int*)num = IdleCount;
		byte* num2 = num + 4;
		*(int*)num2 = ShopManageCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = DispatchCount;
		byte* num4 = num3 + 4;
		*(int*)num4 = MinorsCount;
		byte* num5 = num4 + 4;
		*(int*)num5 = AdultsCount;
		byte* num6 = num5 + 4;
		*(int*)num6 = LearningCount;
		byte* num7 = num6 + 4;
		*(int*)num7 = InStoneRoomCount;
		int totalSize = (int)(num7 + 4 - pData);
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
		TotalCount = *(int*)pCurrData;
		pCurrData += 4;
		IdleCount = *(int*)pCurrData;
		pCurrData += 4;
		ShopManageCount = *(int*)pCurrData;
		pCurrData += 4;
		DispatchCount = *(int*)pCurrData;
		pCurrData += 4;
		MinorsCount = *(int*)pCurrData;
		pCurrData += 4;
		AdultsCount = *(int*)pCurrData;
		pCurrData += 4;
		LearningCount = *(int*)pCurrData;
		pCurrData += 4;
		InStoneRoomCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
