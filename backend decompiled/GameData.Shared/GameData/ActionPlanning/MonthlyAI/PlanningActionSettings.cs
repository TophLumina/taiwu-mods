using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.MonthlyAI;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class PlanningActionSettings : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Disabled = 0;

		public const ushort WeightAdjust = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Disabled", "WeightAdjust" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Disabled;

	[SerializableGameDataField(FieldIndex = 1)]
	public int WeightAdjust;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
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
		*num = (Disabled ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = WeightAdjust;
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
			Disabled = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			WeightAdjust = *(int*)pCurrData;
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
