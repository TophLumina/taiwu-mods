using System.Collections.Generic;
using GameData.DLC.FiveLoong;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class CharacterMenuInfoDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharacterDisplayData = 0;

		public const ushort TaiwuDisplayData = 1;

		public const ushort InscriptionStatus = 2;

		public const ushort TeammateCommandList = 3;

		public const ushort IsFollowingNpcListMax = 4;

		public const ushort IsTemporaryIntelligentCharacter = 5;

		public const ushort AdoredCoolDown = 6;

		public const ushort EnemyCoolDown = 7;

		public const ushort OneWayRelationResultCode = 8;

		public const ushort DebtsOfTaiwu = 9;

		public const ushort ChangedTeammateCharIds = 10;

		public const ushort FiveLoongLocation = 11;

		public const ushort IsInteractedCharacter = 12;

		public const ushort IsReclusiveChar = 13;

		public const ushort FameActionRecords = 14;

		public const ushort LoveAndHateItemInfo = 15;

		public const ushort IsTaiwu = 16;

		public const ushort TemporaryFeatureLeftTimes = 17;

		public const ushort Alertness = 18;

		public const ushort Count = 19;

		public static readonly string[] FieldId2FieldName = new string[19]
		{
			"CharacterDisplayData", "TaiwuDisplayData", "InscriptionStatus", "TeammateCommandList", "IsFollowingNpcListMax", "IsTemporaryIntelligentCharacter", "AdoredCoolDown", "EnemyCoolDown", "OneWayRelationResultCode", "DebtsOfTaiwu",
			"ChangedTeammateCharIds", "FiveLoongLocation", "IsInteractedCharacter", "IsReclusiveChar", "FameActionRecords", "LoveAndHateItemInfo", "IsTaiwu", "TemporaryFeatureLeftTimes", "Alertness"
		};
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public CharacterDisplayData CharacterDisplayData;

	[SerializableGameDataField(FieldIndex = 1)]
	public CharacterDisplayData TaiwuDisplayData;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte InscriptionStatus;

	[SerializableGameDataField(FieldIndex = 3)]
	public List<sbyte> TeammateCommandList;

	[SerializableGameDataField(FieldIndex = 4)]
	public bool IsFollowingNpcListMax;

	[SerializableGameDataField(FieldIndex = 5)]
	public bool IsTemporaryIntelligentCharacter;

	[SerializableGameDataField(FieldIndex = 6)]
	public int AdoredCoolDown;

	[SerializableGameDataField(FieldIndex = 7)]
	public int EnemyCoolDown;

	[SerializableGameDataField(FieldIndex = 8)]
	public int OneWayRelationResultCode;

	[SerializableGameDataField(FieldIndex = 9)]
	public Debts DebtsOfTaiwu;

	[SerializableGameDataField(FieldIndex = 10)]
	public List<int> ChangedTeammateCharIds;

	[SerializableGameDataField(FieldIndex = 11)]
	public List<LoongInfo> FiveLoongLocation;

	[SerializableGameDataField(FieldIndex = 12)]
	public bool IsInteractedCharacter;

	[SerializableGameDataField(FieldIndex = 13)]
	public bool IsReclusiveChar;

	[SerializableGameDataField(FieldIndex = 14)]
	public List<FameActionRecord> FameActionRecords;

	[SerializableGameDataField(FieldIndex = 15)]
	public CharacterLoveAndHateItemInfo LoveAndHateItemInfo;

	[SerializableGameDataField(FieldIndex = 16)]
	public bool IsTaiwu;

	[SerializableGameDataField(FieldIndex = 17)]
	public Dictionary<short, int> TemporaryFeatureLeftTimes;

	[SerializableGameDataField(FieldIndex = 18)]
	public int Alertness;

	public bool HasDebtToTaiwu()
	{
		if (DebtsOfTaiwu != null)
		{
			if (DebtsOfTaiwu.Equivalent == 0L)
			{
				return DebtsOfTaiwu.Nonequivalents.Count > 0;
			}
			return true;
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 44;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuDisplayData.GetSerializedSize())));
		totalSize = ((TeammateCommandList == null) ? (totalSize + 2) : (totalSize + (2 + TeammateCommandList.Count)));
		totalSize = ((DebtsOfTaiwu == null) ? (totalSize + 2) : (totalSize + (2 + DebtsOfTaiwu.GetSerializedSize())));
		totalSize = ((ChangedTeammateCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ChangedTeammateCharIds.Count)));
		if (FiveLoongLocation != null)
		{
			totalSize += 2;
			for (int i = 0; i < FiveLoongLocation.Count; i++)
			{
				totalSize = ((FiveLoongLocation[i] == null) ? (totalSize + 2) : (totalSize + (2 + FiveLoongLocation[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((FameActionRecords == null) ? (totalSize + 2) : (totalSize + (2 + 8 * FameActionRecords.Count)));
		totalSize += 4;
		if (TemporaryFeatureLeftTimes != null)
		{
			foreach (KeyValuePair<short, int> temporaryFeatureLeftTime in TemporaryFeatureLeftTimes)
			{
				_ = temporaryFeatureLeftTime;
				totalSize += 2;
				totalSize += 4;
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
		*(short*)pCurrData = 19;
		pCurrData += 2;
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = TaiwuDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)InscriptionStatus;
		pCurrData++;
		if (TeammateCommandList != null)
		{
			int elementsCount = TeammateCommandList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)TeammateCommandList[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsFollowingNpcListMax ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTemporaryIntelligentCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = AdoredCoolDown;
		pCurrData += 4;
		*(int*)pCurrData = EnemyCoolDown;
		pCurrData += 4;
		*(int*)pCurrData = OneWayRelationResultCode;
		pCurrData += 4;
		if (DebtsOfTaiwu != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = DebtsOfTaiwu.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ChangedTeammateCharIds != null)
		{
			int elementsCount2 = ChangedTeammateCharIds.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = ChangedTeammateCharIds[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FiveLoongLocation != null)
		{
			int elementsCount3 = FiveLoongLocation.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (FiveLoongLocation[k] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = FiveLoongLocation[k].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
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
		*pCurrData = (IsInteractedCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsReclusiveChar ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (FameActionRecords != null)
		{
			int elementsCount4 = FameActionRecords.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += FameActionRecords[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += LoveAndHateItemInfo.Serialize(pCurrData);
		*pCurrData = (IsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (TemporaryFeatureLeftTimes != null)
		{
			*(int*)pCurrData = TemporaryFeatureLeftTimes.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in TemporaryFeatureLeftTimes)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = Alertness;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				CharacterDisplayData = new CharacterDisplayData();
				pCurrData += CharacterDisplayData.Deserialize(pCurrData);
			}
			else
			{
				CharacterDisplayData = null;
			}
		}
		if (fieldCount > 1)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				TaiwuDisplayData = new CharacterDisplayData();
				pCurrData += TaiwuDisplayData.Deserialize(pCurrData);
			}
			else
			{
				TaiwuDisplayData = null;
			}
		}
		if (fieldCount > 2)
		{
			InscriptionStatus = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TeammateCommandList == null)
				{
					TeammateCommandList = new List<sbyte>();
				}
				else
				{
					TeammateCommandList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					sbyte element = (sbyte)(*pCurrData);
					pCurrData++;
					TeammateCommandList.Add(element);
				}
			}
			else
			{
				TeammateCommandList?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			IsFollowingNpcListMax = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			IsTemporaryIntelligentCharacter = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			AdoredCoolDown = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			EnemyCoolDown = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 8)
		{
			OneWayRelationResultCode = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				DebtsOfTaiwu = new Debts();
				pCurrData += DebtsOfTaiwu.Deserialize(pCurrData);
			}
			else
			{
				DebtsOfTaiwu = null;
			}
		}
		if (fieldCount > 10)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ChangedTeammateCharIds == null)
				{
					ChangedTeammateCharIds = new List<int>();
				}
				else
				{
					ChangedTeammateCharIds.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					int element2 = *(int*)pCurrData;
					pCurrData += 4;
					ChangedTeammateCharIds.Add(element2);
				}
			}
			else
			{
				ChangedTeammateCharIds?.Clear();
			}
		}
		if (fieldCount > 11)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (FiveLoongLocation == null)
				{
					FiveLoongLocation = new List<LoongInfo>();
				}
				else
				{
					FiveLoongLocation.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort num4 = *(ushort*)pCurrData;
					pCurrData += 2;
					LoongInfo element3;
					if (num4 > 0)
					{
						element3 = new LoongInfo();
						pCurrData += element3.Deserialize(pCurrData);
					}
					else
					{
						element3 = null;
					}
					FiveLoongLocation.Add(element3);
				}
			}
			else
			{
				FiveLoongLocation?.Clear();
			}
		}
		if (fieldCount > 12)
		{
			IsInteractedCharacter = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 13)
		{
			IsReclusiveChar = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 14)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (FameActionRecords == null)
				{
					FameActionRecords = new List<FameActionRecord>();
				}
				else
				{
					FameActionRecords.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					FameActionRecord element4 = default(FameActionRecord);
					pCurrData += element4.Deserialize(pCurrData);
					FameActionRecords.Add(element4);
				}
			}
			else
			{
				FameActionRecords?.Clear();
			}
		}
		if (fieldCount > 15)
		{
			LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
			pCurrData += LoveAndHateItemInfo.Deserialize(pCurrData);
		}
		if (fieldCount > 16)
		{
			IsTaiwu = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 17)
		{
			int TemporaryFeatureLeftTimesElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (TemporaryFeatureLeftTimesElementsCount > 0)
			{
				if (TemporaryFeatureLeftTimes == null)
				{
					TemporaryFeatureLeftTimes = new Dictionary<short, int>();
				}
				else
				{
					TemporaryFeatureLeftTimes.Clear();
				}
				for (int m = 0; m < TemporaryFeatureLeftTimesElementsCount; m++)
				{
					short key = *(short*)pCurrData;
					pCurrData += 2;
					int value = *(int*)pCurrData;
					pCurrData += 4;
					TemporaryFeatureLeftTimes.Add(key, value);
				}
			}
			else
			{
				TemporaryFeatureLeftTimes?.Clear();
			}
		}
		if (fieldCount > 18)
		{
			Alertness = *(int*)pCurrData;
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
