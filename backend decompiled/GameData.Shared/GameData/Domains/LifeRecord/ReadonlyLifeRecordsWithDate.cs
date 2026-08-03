using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord;

/// <summary>
/// 只读的人物的经历的集合 + 调用获取接口时传入的人物和日期相关信息
/// </summary>
public class ReadonlyLifeRecordsWithDate : ISerializableGameData
{
	/// <summary>
	/// 经历所属角色
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 开始日期
	/// </summary>
	[SerializableGameDataField]
	public int StartDate;

	/// <summary>
	/// 月份数
	/// </summary>
	[SerializableGameDataField]
	public int MonthCount;

	/// <summary>
	/// 目前获取到的经历条数
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public ReadonlyLifeRecords Records;

	/// <summary>
	/// 只读的人物的经历的集合 + 人物经历总条数
	/// </summary>
	public ReadonlyLifeRecordsWithDate()
	{
		Records = new ReadonlyLifeRecords();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((Records == null) ? (totalSize + 4) : (totalSize + (4 + Records.GetSerializedSize())));
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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		*(int*)pCurrData = MonthCount;
		pCurrData += 4;
		if (Records != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize = Records.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)intPtr = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		StartDate = *(int*)pCurrData;
		pCurrData += 4;
		MonthCount = *(int*)pCurrData;
		pCurrData += 4;
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num > 0)
		{
			if (Records == null)
			{
				Records = new ReadonlyLifeRecords();
			}
			pCurrData += Records.Deserialize(pCurrData);
		}
		else
		{
			Records = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
