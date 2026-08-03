using GameData.Domains.Information;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 贿赂数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class BriberyData : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	[SerializableGameDataField]
	public SecretInformationDisplayPackage SecretInformationDisplayPackage;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		totalSize = ((SecretInformationDisplayPackage == null) ? (totalSize + 2) : (totalSize + (2 + SecretInformationDisplayPackage.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SecretInformationDisplayPackage != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = SecretInformationDisplayPackage.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ItemDisplayData = new ItemDisplayData();
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			SecretInformationDisplayPackage = new SecretInformationDisplayPackage();
			pCurrData += SecretInformationDisplayPackage.Deserialize(pCurrData);
		}
		else
		{
			SecretInformationDisplayPackage = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
