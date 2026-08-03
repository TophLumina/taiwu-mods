using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 伏虞心念选取数据
/// GameData.Domains.TaiwuEvent.DisplayEvent.EventSelectFuyuFaithCountData
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class EventSelectFuyuFaithCountData : ISerializableGameData
{
	/// <summary>
	/// 玄灰显示数据
	/// </summary>
	[SerializableGameDataField]
	public DarkAshCounter Counter;

	/// <summary>
	/// 当前心念点数
	/// </summary>
	[SerializableGameDataField]
	public int Curr;

	/// <summary>
	/// 人物寿命
	/// </summary>
	[SerializableGameDataField]
	public int Max;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
