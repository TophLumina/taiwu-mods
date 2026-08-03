using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 悬赏人物显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class CharacterDisplayDataForSettlementBounty : ISerializableGameData
{
	[SerializableGameDataField]
	public SettlementBounty SettlementBounty;

	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	[SerializableGameDataField]
	public short RandomNameId = -1;

	[SerializableGameDataField]
	public sbyte HunterState = -1;

	[SerializableGameDataField]
	public short Happiness = -1;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu = -1;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList CharacterDisplayDataForGeneralScrollList;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 58;
		totalSize = ((SettlementBounty == null) ? (totalSize + 2) : (totalSize + (2 + SettlementBounty.GetSerializedSize())));
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize += FullBlockName.GetSerializedSize();
		totalSize = ((CharacterDisplayDataForGeneralScrollList == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayDataForGeneralScrollList.GetSerializedSize())));
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
		if (SettlementBounty != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SettlementBounty.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += NameRelatedData.Serialize(pCurrData);
		if (AvatarRelatedData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		pCurrData += OrgInfo.Serialize(pCurrData);
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		int fieldSize3 = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		*(short*)pCurrData = RandomNameId;
		pCurrData += 2;
		*pCurrData = (byte)HunterState;
		pCurrData++;
		*(short*)pCurrData = Happiness;
		pCurrData += 2;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		if (CharacterDisplayDataForGeneralScrollList != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = CharacterDisplayDataForGeneralScrollList.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize4;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SettlementBounty == null)
			{
				SettlementBounty = new SettlementBounty();
			}
			pCurrData += SettlementBounty.Deserialize(pCurrData);
		}
		else
		{
			SettlementBounty = null;
		}
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += OrgInfo.Deserialize(pCurrData);
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += FullBlockName.Deserialize(pCurrData);
		RandomNameId = *(short*)pCurrData;
		pCurrData += 2;
		HunterState = (sbyte)(*pCurrData);
		pCurrData++;
		Happiness = *(short*)pCurrData;
		pCurrData += 2;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += Location.Deserialize(pCurrData);
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (CharacterDisplayDataForGeneralScrollList == null)
			{
				CharacterDisplayDataForGeneralScrollList = new CharacterDisplayDataForGeneralScrollList();
			}
			pCurrData += CharacterDisplayDataForGeneralScrollList.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayDataForGeneralScrollList = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
