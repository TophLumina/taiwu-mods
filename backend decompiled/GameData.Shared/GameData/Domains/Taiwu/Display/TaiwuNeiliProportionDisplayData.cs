using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, AllowFixedSize = false)]
public class TaiwuNeiliProportionDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportion;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportionPreview;

	[SerializableGameDataField]
	public sbyte DestType = -1;

	[SerializableGameDataField]
	public sbyte TransferType;

	[SerializableGameDataField]
	public sbyte Amount;

	public int this[int neiliType] => NeiliProportionPreview[neiliType] - NeiliProportion[neiliType];

	public TaiwuNeiliProportionDisplayData()
	{
	}

	public TaiwuNeiliProportionDisplayData(NeiliProportionOfFiveElements neiliProportion, sbyte destType, sbyte transferType, sbyte amount)
	{
		NeiliProportion = neiliProportion;
		NeiliProportionPreview = neiliProportion;
		if (amount > 0 && destType != -1 && transferType != -1)
		{
			NeiliProportionPreview.Transfer(destType, transferType, amount);
		}
		DestType = destType;
		TransferType = transferType;
		Amount = amount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += NeiliProportion.Serialize(pCurrData);
		pCurrData += NeiliProportionPreview.Serialize(pCurrData);
		*pCurrData = (byte)DestType;
		pCurrData++;
		*pCurrData = (byte)TransferType;
		pCurrData++;
		*pCurrData = (byte)Amount;
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
		pCurrData += NeiliProportion.Deserialize(pCurrData);
		pCurrData += NeiliProportionPreview.Deserialize(pCurrData);
		DestType = (sbyte)(*pCurrData);
		pCurrData++;
		TransferType = (sbyte)(*pCurrData);
		pCurrData++;
		Amount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
