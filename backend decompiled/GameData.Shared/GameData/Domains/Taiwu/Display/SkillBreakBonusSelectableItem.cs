using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData]
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class SkillBreakBonusSelectableItem : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte BonusItemType;

	[SerializableGameDataField]
	public SkillBreakPlateBonus BonusData;

	/// <summary>
	/// 如果是道具类的玄机，存储对应来源物品
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	/// <summary>
	/// 如果是人物类的玄机
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	public EBonusItemType Type => (EBonusItemType)BonusItemType;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize += BonusData.GetSerializedSize();
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)BonusItemType;
		pCurrData++;
		int fieldSize = BonusData.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		BonusItemType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += BonusData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ItemDisplayData = new ItemDisplayData();
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
