using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 太吾村商人派遣显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PeddlingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 可交互的目标品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte InteractTargetGrade;

	/// <summary>
	/// 购入价格比例
	/// </summary>
	[SerializableGameDataField]
	public int BuyPriceRate;

	/// <summary>
	/// 售出价格比例
	/// </summary>
	[SerializableGameDataField]
	public int SellPriceRate;

	/// <summary>
	/// 总部好感加成
	/// </summary>
	[SerializableGameDataField]
	public int AddFavorA;

	/// <summary>
	/// 支部好感加成
	/// </summary>
	[SerializableGameDataField]
	public int AddFavorB;

	/// <summary>
	/// 是否在买，反之就在卖。目前没有第3种状态。
	/// </summary>
	[SerializableGameDataField]
	public bool IsBuy;

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)InteractTargetGrade;
		byte* num = pData + 1;
		*(int*)num = BuyPriceRate;
		byte* num2 = num + 4;
		*(int*)num2 = SellPriceRate;
		byte* num3 = num2 + 4;
		*(int*)num3 = AddFavorA;
		byte* num4 = num3 + 4;
		*(int*)num4 = AddFavorB;
		byte* num5 = num4 + 4;
		*num5 = (IsBuy ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
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
		InteractTargetGrade = (sbyte)(*pCurrData);
		pCurrData++;
		BuyPriceRate = *(int*)pCurrData;
		pCurrData += 4;
		SellPriceRate = *(int*)pCurrData;
		pCurrData += 4;
		AddFavorA = *(int*)pCurrData;
		pCurrData += 4;
		AddFavorB = *(int*)pCurrData;
		pCurrData += 4;
		IsBuy = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
