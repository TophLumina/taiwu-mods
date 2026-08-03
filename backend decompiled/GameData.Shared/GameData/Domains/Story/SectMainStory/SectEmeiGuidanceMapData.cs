using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SectEmeiGuidanceMapData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Data = 0;

		public const ushort Location = 1;

		public const ushort NameData = 2;

		public const ushort CombatSkillType = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "Data", "Location", "NameData", "CombatSkillType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public SectEmeiGuidanceData Data;

	[SerializableGameDataField(FieldIndex = 1)]
	public Location Location;

	[SerializableGameDataField(FieldIndex = 2)]
	public NameRelatedData NameData;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte CombatSkillType;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((Data == null) ? (totalSize + 2) : (totalSize + (2 + Data.GetSerializedSize())));
		totalSize += Location.GetSerializedSize();
		totalSize += NameData.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (Data != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Data.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Location.Serialize(pCurrData);
		pCurrData += NameData.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillType;
		pCurrData++;
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
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				Data = new SectEmeiGuidanceData();
				pCurrData += Data.Deserialize(pCurrData);
			}
			else
			{
				Data = null;
			}
		}
		if (num > 1)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			pCurrData += NameData.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			CombatSkillType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
