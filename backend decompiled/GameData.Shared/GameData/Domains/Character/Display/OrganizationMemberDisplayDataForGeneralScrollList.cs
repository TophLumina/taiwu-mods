using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class OrganizationMemberDisplayDataForGeneralScrollList : ISerializableGameData, ISelectCharacterData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList CharacterDisplayDataForGeneralScrollList;

	[SerializableGameDataField]
	public int ApprovingRate;

	[SerializableGameDataField]
	public int InfluencePower;

	[SerializableGameDataField]
	public EApprovingState ApprovingState;

	int ISelectCharacterData.CharacterId => CharacterDisplayDataForGeneralScrollList.CharacterId;

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return CharacterDisplayDataForGeneralScrollList;
	}

	public OrganizationMemberDisplayDataForGeneralScrollList()
	{
	}

	public OrganizationMemberDisplayDataForGeneralScrollList(OrganizationMemberDisplayDataForGeneralScrollList other)
	{
		CharacterDisplayDataForGeneralScrollList = new CharacterDisplayDataForGeneralScrollList(other.CharacterDisplayDataForGeneralScrollList);
		ApprovingRate = other.ApprovingRate;
		InfluencePower = other.InfluencePower;
		ApprovingState = other.ApprovingState;
	}

	public void Assign(OrganizationMemberDisplayDataForGeneralScrollList other)
	{
		CharacterDisplayDataForGeneralScrollList = new CharacterDisplayDataForGeneralScrollList(other.CharacterDisplayDataForGeneralScrollList);
		ApprovingRate = other.ApprovingRate;
		InfluencePower = other.InfluencePower;
		ApprovingState = other.ApprovingState;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		totalSize = ((CharacterDisplayDataForGeneralScrollList == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayDataForGeneralScrollList.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterDisplayDataForGeneralScrollList != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayDataForGeneralScrollList.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = ApprovingRate;
		pCurrData += 4;
		*(int*)pCurrData = InfluencePower;
		pCurrData += 4;
		*pCurrData = (byte)ApprovingState;
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
			CharacterDisplayDataForGeneralScrollList = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += CharacterDisplayDataForGeneralScrollList.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayDataForGeneralScrollList = null;
		}
		ApprovingRate = *(int*)pCurrData;
		pCurrData += 4;
		InfluencePower = *(int*)pCurrData;
		pCurrData += 4;
		ApprovingState = (EApprovingState)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
