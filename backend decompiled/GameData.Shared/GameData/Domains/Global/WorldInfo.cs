using System;
using System.Collections.Generic;
using System.Text;
using GameData.DLC;
using GameData.Domains.Character.Display;
using GameData.Domains.Mod;
using GameData.Domains.Taiwu;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class WorldInfo : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrDate = 0;

		public const ushort TaiwuGenerationsCount = 1;

		public const ushort SavingTimestamp = 2;

		public const ushort TaiwuSurname = 3;

		public const ushort TaiwuGivenName = 4;

		public const ushort Gender = 5;

		public const ushort AvatarRelatedData = 6;

		public const ushort MapStateName = 7;

		public const ushort MapAreaName = 8;

		public const ushort CharacterLifespanType = 9;

		public const ushort CombatDifficulty = 10;

		public const ushort ReadingDifficulty = 11;

		public const ushort BreakoutDifficulty = 12;

		public const ushort LoopingDifficulty = 13;

		public const ushort HereticsAmountType = 14;

		public const ushort BossInvasionSpeedType = 15;

		public const ushort WorldResourceAmountType = 16;

		public const ushort AllowRandomTaiwuHeir = 17;

		public const ushort RestrictOptionsBehaviorType = 18;

		public const ushort StateTaskStatuses = 19;

		public const ushort XiangshuAvatarTaskStatuses = 20;

		public const ushort MainStoryLineProgress = 21;

		public const ushort BeatRanChenZi = 22;

		public const ushort ModIds = 23;

		public const ushort WorldPopulationType = 24;

		public const ushort EnemyPracticeLevel = 25;

		public const ushort GameVersionInfo = 26;

		public const ushort FavorabilityChange = 27;

		public const ushort DlcIds = 28;

		public const ushort ProfessionUpgrade = 29;

		public const ushort LootYield = 30;

		public const ushort TotalTaiwuLifeSummaryInfo = 31;

		public const ushort WorldFunctionStatuses = 32;

		public const ushort MapStateTemplateId = 33;

		public const ushort MapAreaTemplateId = 34;

		public const ushort TotalTaiwuLifeSummaryInfoEx = 35;

		public const ushort DreamBackCount = 36;

		public const ushort Count = 37;

		public static readonly string[] FieldId2FieldName = new string[37]
		{
			"CurrDate", "TaiwuGenerationsCount", "SavingTimestamp", "TaiwuSurname", "TaiwuGivenName", "Gender", "AvatarRelatedData", "MapStateName", "MapAreaName", "CharacterLifespanType",
			"CombatDifficulty", "ReadingDifficulty", "BreakoutDifficulty", "LoopingDifficulty", "HereticsAmountType", "BossInvasionSpeedType", "WorldResourceAmountType", "AllowRandomTaiwuHeir", "RestrictOptionsBehaviorType", "StateTaskStatuses",
			"XiangshuAvatarTaskStatuses", "MainStoryLineProgress", "BeatRanChenZi", "ModIds", "WorldPopulationType", "EnemyPracticeLevel", "GameVersionInfo", "FavorabilityChange", "DlcIds", "ProfessionUpgrade",
			"LootYield", "TotalTaiwuLifeSummaryInfo", "WorldFunctionStatuses", "MapStateTemplateId", "MapAreaTemplateId", "TotalTaiwuLifeSummaryInfoEx", "DreamBackCount"
		};
	}

	[SerializableGameDataField]
	public int CurrDate;

	[SerializableGameDataField]
	public int TaiwuGenerationsCount;

	[SerializableGameDataField]
	public int DreamBackCount;

	[SerializableGameDataField]
	public long SavingTimestamp;

	[SerializableGameDataField]
	public string TaiwuSurname;

	[SerializableGameDataField]
	public string TaiwuGivenName;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[Obsolete]
	[SerializableGameDataField]
	public string MapStateName;

	[Obsolete]
	[SerializableGameDataField]
	public string MapAreaName;

	[SerializableGameDataField]
	public byte CharacterLifespanType;

	[SerializableGameDataField]
	public byte CombatDifficulty;

	[SerializableGameDataField]
	public byte ReadingDifficulty;

	[SerializableGameDataField]
	public byte BreakoutDifficulty;

	[SerializableGameDataField]
	public byte LoopingDifficulty;

	[SerializableGameDataField]
	public byte EnemyPracticeLevel;

	[SerializableGameDataField]
	public byte FavorabilityChange;

	[SerializableGameDataField]
	public byte ProfessionUpgrade;

	[SerializableGameDataField]
	public short LootYield;

	[SerializableGameDataField]
	public byte HereticsAmountType;

	[SerializableGameDataField]
	public byte BossInvasionSpeedType;

	[SerializableGameDataField]
	public byte WorldResourceAmountType;

	[SerializableGameDataField]
	public byte WorldPopulationType;

	[SerializableGameDataField]
	public bool AllowRandomTaiwuHeir;

	[SerializableGameDataField]
	public bool RestrictOptionsBehaviorType;

	[SerializableGameDataField]
	public sbyte[] StateTaskStatuses;

	[SerializableGameDataField]
	public XiangshuAvatarTaskStatus[] XiangshuAvatarTaskStatuses;

	[SerializableGameDataField]
	public short MainStoryLineProgress;

	[SerializableGameDataField]
	public bool BeatRanChenZi;

	[SerializableGameDataField]
	public List<ModId> ModIds;

	[SerializableGameDataField]
	public List<DlcId> DlcIds;

	[SerializableGameDataField]
	public GameVersionInfo GameVersionInfo;

	[Obsolete("已废弃, 请使用 TotalTaiwuLifeSummaryInfoEx")]
	[SerializableGameDataField]
	public TotalTaiwuLifeSummaryInfo TotalTaiwuLifeSummaryInfo;

	[SerializableGameDataField]
	public ulong WorldFunctionStatuses;

	[SerializableGameDataField]
	public sbyte MapStateTemplateId;

	[SerializableGameDataField]
	public short MapAreaTemplateId;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public TotalTaiwuLifeSummaryInfo TotalTaiwuLifeSummaryInfoEx;

	public WorldInfo()
	{
		ReadingDifficulty = 1;
		BreakoutDifficulty = 1;
		LoopingDifficulty = 1;
		EnemyPracticeLevel = 1;
		FavorabilityChange = 1;
		ProfessionUpgrade = 1;
		LootYield = 1;
		WorldPopulationType = 1;
		GameVersionInfo = null;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 53;
		totalSize = ((TaiwuSurname == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TaiwuSurname.Length)));
		totalSize = ((TaiwuGivenName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TaiwuGivenName.Length)));
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((MapStateName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * MapStateName.Length)));
		totalSize = ((MapAreaName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * MapAreaName.Length)));
		totalSize = ((StateTaskStatuses == null) ? (totalSize + 2) : (totalSize + (2 + StateTaskStatuses.Length)));
		totalSize = ((XiangshuAvatarTaskStatuses == null) ? (totalSize + 2) : (totalSize + (2 + 8 * XiangshuAvatarTaskStatuses.Length)));
		totalSize = ((ModIds == null) ? (totalSize + 2) : (totalSize + (2 + 20 * ModIds.Count)));
		totalSize = ((GameVersionInfo == null) ? (totalSize + 2) : (totalSize + (2 + GameVersionInfo.GetSerializedSize())));
		totalSize = ((DlcIds == null) ? (totalSize + 2) : (totalSize + (2 + 16 * DlcIds.Count)));
		totalSize = ((TotalTaiwuLifeSummaryInfo == null) ? (totalSize + 2) : (totalSize + (2 + TotalTaiwuLifeSummaryInfo.GetSerializedSize())));
		totalSize = ((TotalTaiwuLifeSummaryInfoEx == null) ? (totalSize + 4) : (totalSize + (4 + TotalTaiwuLifeSummaryInfoEx.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 37;
		pCurrData += 2;
		*(int*)pCurrData = CurrDate;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuGenerationsCount;
		pCurrData += 4;
		*(long*)pCurrData = SavingTimestamp;
		pCurrData += 8;
		if (TaiwuSurname != null)
		{
			int elementsCount = TaiwuSurname.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = TaiwuSurname)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuGivenName != null)
		{
			int elementsCount2 = TaiwuGivenName.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = TaiwuGivenName)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)Gender;
		pCurrData++;
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MapStateName != null)
		{
			int elementsCount3 = MapStateName.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			fixed (char* pChar3 = MapStateName)
			{
				for (int k = 0; k < elementsCount3; k++)
				{
					((short*)pCurrData)[k] = (short)pChar3[k];
				}
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MapAreaName != null)
		{
			int elementsCount4 = MapAreaName.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			fixed (char* pChar4 = MapAreaName)
			{
				for (int l = 0; l < elementsCount4; l++)
				{
					((short*)pCurrData)[l] = (short)pChar4[l];
				}
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = CharacterLifespanType;
		pCurrData++;
		*pCurrData = CombatDifficulty;
		pCurrData++;
		*pCurrData = ReadingDifficulty;
		pCurrData++;
		*pCurrData = BreakoutDifficulty;
		pCurrData++;
		*pCurrData = LoopingDifficulty;
		pCurrData++;
		*pCurrData = HereticsAmountType;
		pCurrData++;
		*pCurrData = BossInvasionSpeedType;
		pCurrData++;
		*pCurrData = WorldResourceAmountType;
		pCurrData++;
		*pCurrData = (AllowRandomTaiwuHeir ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RestrictOptionsBehaviorType ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (StateTaskStatuses != null)
		{
			int elementsCount5 = StateTaskStatuses.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData[m] = (byte)StateTaskStatuses[m];
			}
			pCurrData += elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (XiangshuAvatarTaskStatuses != null)
		{
			int elementsCount6 = XiangshuAvatarTaskStatuses.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData += XiangshuAvatarTaskStatuses[n].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = MainStoryLineProgress;
		pCurrData += 2;
		*pCurrData = (BeatRanChenZi ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ModIds != null)
		{
			int elementsCount7 = ModIds.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				pCurrData += ModIds[num].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = WorldPopulationType;
		pCurrData++;
		*pCurrData = EnemyPracticeLevel;
		pCurrData++;
		if (GameVersionInfo != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GameVersionInfo.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = FavorabilityChange;
		pCurrData++;
		if (DlcIds != null)
		{
			int elementsCount8 = DlcIds.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				pCurrData += DlcIds[num2].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = ProfessionUpgrade;
		pCurrData++;
		*(short*)pCurrData = LootYield;
		pCurrData += 2;
		if (TotalTaiwuLifeSummaryInfo != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = TotalTaiwuLifeSummaryInfo.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(ulong*)pCurrData = WorldFunctionStatuses;
		pCurrData += 8;
		*pCurrData = (byte)MapStateTemplateId;
		pCurrData++;
		*(short*)pCurrData = MapAreaTemplateId;
		pCurrData += 2;
		if (TotalTaiwuLifeSummaryInfoEx != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 4;
			int fieldSize4 = TotalTaiwuLifeSummaryInfoEx.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= int.MaxValue);
			*(int*)intPtr4 = fieldSize4;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = DreamBackCount;
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
			CurrDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			TaiwuGenerationsCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			SavingTimestamp = *(long*)pCurrData;
			pCurrData += 8;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				TaiwuSurname = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				TaiwuSurname = null;
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				int fieldSize2 = 2 * elementsCount2;
				TaiwuGivenName = Encoding.Unicode.GetString(pCurrData, fieldSize2);
				pCurrData += fieldSize2;
			}
			else
			{
				TaiwuGivenName = null;
			}
		}
		if (fieldCount > 5)
		{
			Gender = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
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
		}
		if (fieldCount > 7)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				int fieldSize3 = 2 * elementsCount3;
				MapStateName = Encoding.Unicode.GetString(pCurrData, fieldSize3);
				pCurrData += fieldSize3;
			}
			else
			{
				MapStateName = null;
			}
		}
		if (fieldCount > 8)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				int fieldSize4 = 2 * elementsCount4;
				MapAreaName = Encoding.Unicode.GetString(pCurrData, fieldSize4);
				pCurrData += fieldSize4;
			}
			else
			{
				MapAreaName = null;
			}
		}
		if (fieldCount > 9)
		{
			CharacterLifespanType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			CombatDifficulty = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 11)
		{
			ReadingDifficulty = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			BreakoutDifficulty = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 13)
		{
			LoopingDifficulty = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 14)
		{
			HereticsAmountType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 15)
		{
			BossInvasionSpeedType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 16)
		{
			WorldResourceAmountType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 17)
		{
			AllowRandomTaiwuHeir = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 18)
		{
			RestrictOptionsBehaviorType = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 19)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (StateTaskStatuses == null || StateTaskStatuses.Length != elementsCount5)
				{
					StateTaskStatuses = new sbyte[elementsCount5];
				}
				for (int i = 0; i < elementsCount5; i++)
				{
					StateTaskStatuses[i] = (sbyte)pCurrData[i];
				}
				pCurrData += (int)elementsCount5;
			}
			else
			{
				StateTaskStatuses = null;
			}
		}
		if (fieldCount > 20)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (XiangshuAvatarTaskStatuses == null || XiangshuAvatarTaskStatuses.Length != elementsCount6)
				{
					XiangshuAvatarTaskStatuses = new XiangshuAvatarTaskStatus[elementsCount6];
				}
				for (int j = 0; j < elementsCount6; j++)
				{
					XiangshuAvatarTaskStatus element = default(XiangshuAvatarTaskStatus);
					pCurrData += element.Deserialize(pCurrData);
					XiangshuAvatarTaskStatuses[j] = element;
				}
			}
			else
			{
				XiangshuAvatarTaskStatuses = null;
			}
		}
		if (fieldCount > 21)
		{
			MainStoryLineProgress = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 22)
		{
			BeatRanChenZi = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 23)
		{
			ushort elementsCount7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount7 > 0)
			{
				if (ModIds == null)
				{
					ModIds = new List<ModId>(elementsCount7);
				}
				else
				{
					ModIds.Clear();
				}
				for (int k = 0; k < elementsCount7; k++)
				{
					ModId element2 = default(ModId);
					pCurrData += element2.Deserialize(pCurrData);
					ModIds.Add(element2);
				}
			}
			else
			{
				ModIds?.Clear();
			}
		}
		if (fieldCount > 24)
		{
			WorldPopulationType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 25)
		{
			EnemyPracticeLevel = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 26)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (GameVersionInfo == null)
				{
					GameVersionInfo = new GameVersionInfo();
				}
				pCurrData += GameVersionInfo.Deserialize(pCurrData);
			}
			else
			{
				GameVersionInfo = null;
			}
		}
		if (fieldCount > 27)
		{
			FavorabilityChange = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 28)
		{
			ushort elementsCount8 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount8 > 0)
			{
				if (DlcIds == null)
				{
					DlcIds = new List<DlcId>(elementsCount8);
				}
				else
				{
					DlcIds.Clear();
				}
				for (int l = 0; l < elementsCount8; l++)
				{
					DlcId element3 = default(DlcId);
					pCurrData += element3.Deserialize(pCurrData);
					DlcIds.Add(element3);
				}
			}
			else
			{
				DlcIds?.Clear();
			}
		}
		if (fieldCount > 29)
		{
			ProfessionUpgrade = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 30)
		{
			LootYield = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 31)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				if (TotalTaiwuLifeSummaryInfo == null)
				{
					TotalTaiwuLifeSummaryInfo = new TotalTaiwuLifeSummaryInfo();
				}
				pCurrData += TotalTaiwuLifeSummaryInfo.Deserialize(pCurrData);
			}
			else
			{
				TotalTaiwuLifeSummaryInfo = null;
			}
		}
		if (fieldCount > 32)
		{
			WorldFunctionStatuses = *(ulong*)pCurrData;
			pCurrData += 8;
		}
		if (fieldCount > 33)
		{
			MapStateTemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 34)
		{
			MapAreaTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 35)
		{
			int num4 = *(int*)pCurrData;
			pCurrData += 4;
			if (num4 > 0)
			{
				if (TotalTaiwuLifeSummaryInfoEx == null)
				{
					TotalTaiwuLifeSummaryInfoEx = new TotalTaiwuLifeSummaryInfo();
				}
				pCurrData += TotalTaiwuLifeSummaryInfoEx.Deserialize(pCurrData);
			}
			else
			{
				TotalTaiwuLifeSummaryInfoEx = null;
			}
		}
		if (fieldCount > 36)
		{
			DreamBackCount = *(int*)pCurrData;
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
