using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 后端玄灰数据
/// 数据约束：ExpiredDate2 - ExpiredDate3 &gt;= 0
/// </summary>
/// <summary>
/// 序列化
/// GameData.Domains.Character.DarkAshCounterData
/// </summary>
[SerializableGameData(NotForDisplayModule = true, IsExtensible = true, NoCopyConstructors = true)]
public struct DarkAshCounterData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ExpiredDate2 = 0;

		public const ushort ExpiredDate3 = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ExpiredDate2", "ExpiredDate3" };
	}

	/// <summary>
	/// 倒计时 - 精纯特性
	/// </summary>
	[SerializableGameDataField]
	public int ExpiredDate2;

	/// <summary>
	/// 倒计时 - 心念特性
	/// </summary>
	[SerializableGameDataField]
	public int ExpiredDate3;

	/// <summary>
	/// 新建后端数据
	/// </summary>
	/// <param name="currDate">当前时间，也可以作为伏虞心念过期时间传递</param>
	/// <param name="consummateLevel">人物精纯，必须非负</param>
	public DarkAshCounterData(int currDate, int consummateLevel, int faith = 0)
	{
		ExpiredDate2 = (ExpiredDate3 = currDate + faith) + consummateLevel;
	}

	/// <summary>
	/// 延长心念持续时间，不会修改特性作用时间，也不会存档。返回的DarkAshCounterData可送去存档
	/// </summary>
	/// <param name="currDate">当前日期</param>
	/// <param name="delta">增加的心念值</param>
	/// <returns></returns>
	public DarkAshCounterData OfflineApplyFaithChangeToExtraData(int currDate, int delta)
	{
		if (ExpiredDate2 - currDate < 0)
		{
			ExpiredDate2 = (ExpiredDate3 = currDate + delta);
		}
		else
		{
			ExpiredDate2 += delta;
			if (ExpiredDate3 - currDate < 0)
			{
				ExpiredDate3 = currDate + delta;
			}
			else
			{
				ExpiredDate3 += delta;
			}
		}
		return this;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(int*)num = ExpiredDate2;
		byte* num2 = num + 4;
		*(int*)num2 = ExpiredDate3;
		int totalSize = (int)(num2 + 4 - pData);
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
			ExpiredDate2 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ExpiredDate3 = *(int*)pCurrData;
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
