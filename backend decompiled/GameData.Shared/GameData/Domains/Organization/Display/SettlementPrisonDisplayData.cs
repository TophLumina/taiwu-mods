using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 定居点监牢显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class SettlementPrisonDisplayData : ISerializableGameData
{
	/// <summary>
	/// 定居点模板ID
	/// </summary>
	[SerializableGameDataField]
	public int OrgTemplateId;

	/// <summary>
	/// 地区恩义（定居点）或对太吾的支持度（门派），用以判定监牢准入条件是否满足
	/// </summary>
	[SerializableGameDataField]
	public int DebtOrSupport;

	/// <summary>
	/// 额外护卫的角色数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataLow;

	/// <summary>
	/// 额外护卫的角色数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataMid;

	/// <summary>
	/// 额外护卫的角色数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataHigh;

	/// <summary>
	/// 人物数据，Key为charId
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayDataForSettlementPrisoner> PrisonerCharacterDisplayDataDict;

	/// <summary>
	/// 太吾石牢是否已满
	/// </summary>
	[SerializableGameDataField]
	public bool IsStoneRoomFull;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (GuardianCharacterDisplayDataLow != null)
		{
			totalSize += 2;
			for (int i = 0; i < GuardianCharacterDisplayDataLow.Length; i++)
			{
				totalSize = ((GuardianCharacterDisplayDataLow[i] == null) ? (totalSize + 2) : (totalSize + (2 + GuardianCharacterDisplayDataLow[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (GuardianCharacterDisplayDataMid != null)
		{
			totalSize += 2;
			for (int j = 0; j < GuardianCharacterDisplayDataMid.Length; j++)
			{
				totalSize = ((GuardianCharacterDisplayDataMid[j] == null) ? (totalSize + 2) : (totalSize + (2 + GuardianCharacterDisplayDataMid[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (GuardianCharacterDisplayDataHigh != null)
		{
			totalSize += 2;
			for (int k = 0; k < GuardianCharacterDisplayDataHigh.Length; k++)
			{
				totalSize = ((GuardianCharacterDisplayDataHigh[k] == null) ? (totalSize + 2) : (totalSize + (2 + GuardianCharacterDisplayDataHigh[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (PrisonerCharacterDisplayDataDict != null)
		{
			foreach (KeyValuePair<int, CharacterDisplayDataForSettlementPrisoner> pair in PrisonerCharacterDisplayDataDict)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = OrgTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = DebtOrSupport;
		pCurrData += 4;
		if (GuardianCharacterDisplayDataLow != null)
		{
			int elementsCount = GuardianCharacterDisplayDataLow.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (GuardianCharacterDisplayDataLow[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = GuardianCharacterDisplayDataLow[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GuardianCharacterDisplayDataMid != null)
		{
			int elementsCount2 = GuardianCharacterDisplayDataMid.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (GuardianCharacterDisplayDataMid[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = GuardianCharacterDisplayDataMid[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GuardianCharacterDisplayDataHigh != null)
		{
			int elementsCount3 = GuardianCharacterDisplayDataHigh.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (GuardianCharacterDisplayDataHigh[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = GuardianCharacterDisplayDataHigh[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PrisonerCharacterDisplayDataDict != null)
		{
			*(int*)pCurrData = PrisonerCharacterDisplayDataDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterDisplayDataForSettlementPrisoner> pair in PrisonerCharacterDisplayDataDict)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (IsStoneRoomFull ? ((byte)1) : ((byte)0));
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
		OrgTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		DebtOrSupport = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (GuardianCharacterDisplayDataLow == null || GuardianCharacterDisplayDataLow.Length != elementsCount)
			{
				GuardianCharacterDisplayDataLow = new CharacterDisplayData[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					GuardianCharacterDisplayDataLow[i] = new CharacterDisplayData();
					pCurrData += GuardianCharacterDisplayDataLow[i].Deserialize(pCurrData);
				}
				else
				{
					GuardianCharacterDisplayDataLow[i] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataLow = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (GuardianCharacterDisplayDataMid == null || GuardianCharacterDisplayDataMid.Length != elementsCount2)
			{
				GuardianCharacterDisplayDataMid = new CharacterDisplayData[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					GuardianCharacterDisplayDataMid[j] = new CharacterDisplayData();
					pCurrData += GuardianCharacterDisplayDataMid[j].Deserialize(pCurrData);
				}
				else
				{
					GuardianCharacterDisplayDataMid[j] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataMid = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (GuardianCharacterDisplayDataHigh == null || GuardianCharacterDisplayDataHigh.Length != elementsCount3)
			{
				GuardianCharacterDisplayDataHigh = new CharacterDisplayData[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					GuardianCharacterDisplayDataHigh[k] = new CharacterDisplayData();
					pCurrData += GuardianCharacterDisplayDataHigh[k].Deserialize(pCurrData);
				}
				else
				{
					GuardianCharacterDisplayDataHigh[k] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataHigh = null;
		}
		int PrisonerCharacterDisplayDataDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (PrisonerCharacterDisplayDataDictElementsCount > 0)
		{
			if (PrisonerCharacterDisplayDataDict == null)
			{
				PrisonerCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayDataForSettlementPrisoner>();
			}
			else
			{
				PrisonerCharacterDisplayDataDict.Clear();
			}
			for (int l = 0; l < PrisonerCharacterDisplayDataDictElementsCount; l++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				CharacterDisplayDataForSettlementPrisoner value = new CharacterDisplayDataForSettlementPrisoner();
				pCurrData += value.Deserialize(pCurrData);
				PrisonerCharacterDisplayDataDict.Add(key, value);
			}
		}
		else
		{
			PrisonerCharacterDisplayDataDict?.Clear();
		}
		IsStoneRoomFull = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
