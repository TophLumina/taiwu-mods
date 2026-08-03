using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 定居点人口显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class SettlementPopulationDisplayData : ISerializableGameData
{
	/// <summary>
	/// 成年男性数量
	/// </summary>
	[SerializableGameDataField]
	public int ManCount;

	/// <summary>
	/// 成年女性数量
	/// </summary>
	[SerializableGameDataField]
	public int WomanCount;

	/// <summary>
	/// 孩童(男)数量
	/// </summary>
	[SerializableGameDataField]
	public int BoyCount;

	/// <summary>
	///  孩童(女)数量
	/// </summary>
	[SerializableGameDataField]
	public int GirlCount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = ManCount;
		byte* num = pData + 4;
		*(int*)num = WomanCount;
		byte* num2 = num + 4;
		*(int*)num2 = BoyCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = GirlCount;
		int totalSize = (int)(num3 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ManCount = *(int*)pCurrData;
		pCurrData += 4;
		WomanCount = *(int*)pCurrData;
		pCurrData += 4;
		BoyCount = *(int*)pCurrData;
		pCurrData += 4;
		GirlCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
