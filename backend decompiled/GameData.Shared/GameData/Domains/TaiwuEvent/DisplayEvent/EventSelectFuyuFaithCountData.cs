using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class EventSelectFuyuFaithCountData : ISerializableGameData
{
	[SerializableGameDataField]
	public DarkAshCounter Counter;

	[SerializableGameDataField]
	public int Curr;

	[SerializableGameDataField]
	public int Max;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize += Counter.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int fieldSize = Counter.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Curr;
		pCurrData += 4;
		*(int*)pCurrData = Max;
		pCurrData += 4;
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
		pCurrData += Counter.Deserialize(pCurrData);
		Curr = *(int*)pCurrData;
		pCurrData += 4;
		Max = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
