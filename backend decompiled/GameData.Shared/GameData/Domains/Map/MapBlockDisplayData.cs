using GameData.Domains.Extra;
using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 地格显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct MapBlockDisplayData : ISerializableGameData
{
	/// <summary>
	/// 挖掘信息
	/// </summary>
	[SerializableGameDataField]
	public TreasureExpectResult TreasureExpect;

	/// <summary>
	/// 请求时志向
	/// </summary>
	[SerializableGameDataField]
	public int ProfessionId;

	/// <summary>
	/// 志向数据一
	/// 山人：0=完好 1=毁坏
	/// 猎户：野兽数量
	/// 道长：入邪数量
	/// 平民：仇恨太吾数量
	/// 云游僧：叛逆立场数量
	/// 大夫：受伤数量
	/// 王公：赋予官职数量
	/// </summary>
	[SerializableGameDataField]
	public int Count0;

	/// <summary>
	/// 志向数据二
	/// 道长：入魔数量
	/// 云游僧：唯我立场数量
	/// 大夫：中毒数量
	/// </summary>
	[SerializableGameDataField]
	public int Count1;

	/// <summary>
	/// 志向数据三
	/// 大夫：内息紊乱数量
	/// </summary>
	[SerializableGameDataField]
	public int Count2;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 28;
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
		pCurrData += TreasureExpect.Serialize(pCurrData);
		*(int*)pCurrData = ProfessionId;
		pCurrData += 4;
		*(int*)pCurrData = Count0;
		pCurrData += 4;
		*(int*)pCurrData = Count1;
		pCurrData += 4;
		*(int*)pCurrData = Count2;
		pCurrData += 4;
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
		pCurrData += TreasureExpect.Deserialize(pCurrData);
		ProfessionId = *(int*)pCurrData;
		pCurrData += 4;
		Count0 = *(int*)pCurrData;
		pCurrData += 4;
		Count1 = *(int*)pCurrData;
		pCurrData += 4;
		Count2 = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
