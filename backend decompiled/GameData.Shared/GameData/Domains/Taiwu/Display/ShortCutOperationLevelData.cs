using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true, AllowFixedSize = false)]
public class ShortCutOperationLevelData : ISerializableGameData
{
	[SerializableGameDataField]
	public OperationLevel ChickenAssign;

	[SerializableGameDataField]
	public OperationLevel JiaoPool;

	[SerializableGameDataField]
	public OperationLevel Wuxian;

	[SerializableGameDataField]
	public OperationLevel Fulong;

	[SerializableGameDataField]
	public OperationLevel Jieqing;

	[SerializableGameDataField]
	public OperationLevel Yuanshan;

	[SerializableGameDataField]
	public OperationLevel Xuannv;

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
		*pData = (byte)ChickenAssign;
		byte* num = pData + 1;
		*num = (byte)JiaoPool;
		byte* num2 = num + 1;
		*num2 = (byte)Wuxian;
		byte* num3 = num2 + 1;
		*num3 = (byte)Fulong;
		byte* num4 = num3 + 1;
		*num4 = (byte)Jieqing;
		byte* num5 = num4 + 1;
		*num5 = (byte)Yuanshan;
		byte* num6 = num5 + 1;
		*num6 = (byte)Xuannv;
		int totalSize = (int)(num6 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ChickenAssign = (OperationLevel)(*pCurrData);
		pCurrData++;
		JiaoPool = (OperationLevel)(*pCurrData);
		pCurrData++;
		Wuxian = (OperationLevel)(*pCurrData);
		pCurrData++;
		Fulong = (OperationLevel)(*pCurrData);
		pCurrData++;
		Jieqing = (OperationLevel)(*pCurrData);
		pCurrData++;
		Yuanshan = (OperationLevel)(*pCurrData);
		pCurrData++;
		Xuannv = (OperationLevel)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
