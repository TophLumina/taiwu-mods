using GameData.Serializer;

namespace GameData.Domains.Organization;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SettlementMemberFeature : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort FeatureId = 0;

		public const ushort MinGrade = 1;

		public const ushort MaxGrade = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "FeatureId", "MinGrade", "MaxGrade" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short FeatureId;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte MinGrade;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte MaxGrade;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(short*)pCurrData = FeatureId;
		pCurrData += 2;
		*pCurrData = (byte)MinGrade;
		pCurrData++;
		*pCurrData = (byte)MaxGrade;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			FeatureId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 1)
		{
			MinGrade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			MaxGrade = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
