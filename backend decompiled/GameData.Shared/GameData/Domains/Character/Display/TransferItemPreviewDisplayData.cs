using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 批量转赠物品的预览显示数据
/// </summary>
[AutoGenerateSerializableGameData]
public class TransferItemPreviewDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public short OriginalFavor;

	[SerializableGameDataField]
	public sbyte OriginalHappiness;

	[SerializableGameDataField]
	public int OriginalAlertness;

	[SerializableGameDataField]
	public short FinalFavor;

	[SerializableGameDataField]
	public sbyte FinalHappiness;

	[SerializableGameDataField]
	public int FinalAlertness;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TransferItemPreviewDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TransferItemPreviewDisplayData(TransferItemPreviewDisplayData other)
	{
		OriginalFavor = other.OriginalFavor;
		OriginalHappiness = other.OriginalHappiness;
		OriginalAlertness = other.OriginalAlertness;
		FinalFavor = other.FinalFavor;
		FinalHappiness = other.FinalHappiness;
		FinalAlertness = other.FinalAlertness;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TransferItemPreviewDisplayData other)
	{
		OriginalFavor = other.OriginalFavor;
		OriginalHappiness = other.OriginalHappiness;
		OriginalAlertness = other.OriginalAlertness;
		FinalFavor = other.FinalFavor;
		FinalHappiness = other.FinalHappiness;
		FinalAlertness = other.FinalAlertness;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = OriginalFavor;
		byte* num = pData + 2;
		*num = (byte)OriginalHappiness;
		byte* num2 = num + 1;
		*(int*)num2 = OriginalAlertness;
		byte* num3 = num2 + 4;
		*(short*)num3 = FinalFavor;
		byte* num4 = num3 + 2;
		*num4 = (byte)FinalHappiness;
		byte* num5 = num4 + 1;
		*(int*)num5 = FinalAlertness;
		int totalSize = (int)(num5 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		OriginalFavor = *(short*)pCurrData;
		pCurrData += 2;
		OriginalHappiness = (sbyte)(*pCurrData);
		pCurrData++;
		OriginalAlertness = *(int*)pCurrData;
		pCurrData += 4;
		FinalFavor = *(short*)pCurrData;
		pCurrData += 2;
		FinalHappiness = (sbyte)(*pCurrData);
		pCurrData++;
		FinalAlertness = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
