using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 开关滑块值
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public struct ToggleSliderValue(bool isOn, int value) : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort IsOn = 0;

		public const ushort Value = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "IsOn", "Value" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool IsOn = isOn;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Value = value;

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
		*num = (IsOn ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = Value;
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
			IsOn = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			Value = *(int*)pCurrData;
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
