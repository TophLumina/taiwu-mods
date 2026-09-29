using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true, IsExtensible = true, NoCopyConstructors = true)]
public struct DarkAshCounterData(int currDate, int consummateLevel, int faith = 0) : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ExpiredDate2 = 0;

		public const ushort ExpiredDate3 = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ExpiredDate2", "ExpiredDate3" };
	}

	[SerializableGameDataField]
	public int ExpiredDate2 = (ExpiredDate3 = currDate + faith) + consummateLevel;

	[SerializableGameDataField]
	public int ExpiredDate3;

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
