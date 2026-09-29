using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class SuccessorCandidates : ISerializableGameData, ISelectCharacterData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList TeammateData;

	[SerializableGameDataField]
	public CharacterMenuInfoDisplayData DisplayData = new CharacterMenuInfoDisplayData
	{
		LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo()
	};

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	public CombatSkillShorts CombatSkillQualifications => TeammateData.CombatSkillQualifications;

	public LifeSkillShorts LifeSkillQualifications => TeammateData.LifeSkillQualifications;

	int ISelectCharacterData.CharacterId => TeammateData.CharacterId;

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return TeammateData;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 60;
		totalSize = ((TeammateData == null) ? (totalSize + 2) : (totalSize + (2 + TeammateData.GetSerializedSize())));
		totalSize = ((DisplayData == null) ? (totalSize + 2) : (totalSize + (2 + DisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (TeammateData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = TeammateData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = DisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
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
			TeammateData = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += TeammateData.Deserialize(pCurrData);
		}
		else
		{
			TeammateData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			DisplayData = new CharacterMenuInfoDisplayData();
			pCurrData += DisplayData.Deserialize(pCurrData);
		}
		else
		{
			DisplayData = null;
		}
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
