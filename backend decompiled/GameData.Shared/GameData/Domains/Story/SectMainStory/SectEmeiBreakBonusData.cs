using GameData.Serializer;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 峨眉突破格累积进度数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public struct SectEmeiBreakBonusData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort BonusCount = 1;

		public const ushort BonusProgress = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "TemplateId", "BonusCount", "BonusProgress" };
	}

	/// <summary>
	/// 突破格模板 ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 可用次数
	/// </summary>
	[SerializableGameDataField]
	public int BonusCount;

	/// <summary>
	/// 累积进度
	/// </summary>
	[SerializableGameDataField]
	public int BonusProgress;

	/// <summary>
	/// 离线增加进度
	/// </summary>
	/// <param name="progress"></param>
	public void OfflineAddProgress(int progress)
	{
		BonusProgress += progress;
		BonusCount += BonusProgress / GlobalConfig.Instance.SectStoryEmeiBonusProgressPerCount;
		BonusProgress %= GlobalConfig.Instance.SectStoryEmeiBonusProgressPerCount;
	}

	/// <summary>
	/// 离线合并数据
	/// </summary>
	public void OfflineMerge(SectEmeiBreakBonusData data)
	{
		BonusCount += data.BonusCount;
		OfflineAddProgress(data.BonusProgress);
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
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*(short*)num = TemplateId;
		byte* num2 = num + 2;
		*(int*)num2 = BonusCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = BonusProgress;
		int totalSize = (int)(num3 + 4 - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			BonusCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			BonusProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
