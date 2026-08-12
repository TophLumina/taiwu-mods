using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 促织决斗结算结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CricketSettlementResult : ISerializableGameData
{
	/// <summary>
	/// 太吾获胜
	/// </summary>
	[SerializableGameDataField]
	public bool TaiwuWin;

	/// <summary>
	/// 额外赌注
	/// </summary>
	[SerializableGameDataField]
	public Wager ExtraWager = Wager.Invalid;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketSettlementResult()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketSettlementResult(CricketSettlementResult other)
	{
		TaiwuWin = other.TaiwuWin;
		ExtraWager = other.ExtraWager;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketSettlementResult other)
	{
		TaiwuWin = other.TaiwuWin;
		ExtraWager = other.ExtraWager;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 21;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (TaiwuWin ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += ExtraWager.Serialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
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
		TaiwuWin = *pCurrData != 0;
		pCurrData++;
		pCurrData += ExtraWager.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
