using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingShopData : ISerializableGameData
{
	/// <summary>
	/// 太吾产业的资源格效果
	/// </summary>
	[SerializableGameDataField]
	public int ResourceBlockEffect;

	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public int Attainment;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = ResourceBlockEffect;
		byte* num = pData + 4;
		*(int*)num = Attainment;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ResourceBlockEffect = *(int*)pCurrData;
		pCurrData += 4;
		Attainment = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
