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

/// <summary>
/// (载入界面用到的) 世界信息
/// </summary>
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

		public const ushort Count = 35;

		public static readonly string[] FieldId2FieldName = new string[35]
		{
			"CurrDate", "TaiwuGenerationsCount", "SavingTimestamp", "TaiwuSurname", "TaiwuGivenName", "Gender", "AvatarRelatedData", "MapStateName", "MapAreaName", "CharacterLifespanType",
			"CombatDifficulty", "ReadingDifficulty", "BreakoutDifficulty", "LoopingDifficulty", "HereticsAmountType", "BossInvasionSpeedType", "WorldResourceAmountType", "AllowRandomTaiwuHeir", "RestrictOptionsBehaviorType", "StateTaskStatuses",
			"XiangshuAvatarTaskStatuses", "MainStoryLineProgress", "BeatRanChenZi", "ModIds", "WorldPopulationType", "EnemyPracticeLevel", "GameVersionInfo", "FavorabilityChange", "DlcIds", "ProfessionUpgrade",
			"LootYield", "TotalTaiwuLifeSummaryInfo", "WorldFunctionStatuses", "MapStateTemplateId", "MapAreaTemplateId"
		};
	}

	/// <summary>
	/// 当前游戏日期 (从第一年一月开始经过的月份数)
	/// </summary>
	[SerializableGameDataField]
	public int CurrDate;

	/// <summary>
	/// 太吾世代
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuGenerationsCount;

	/// <summary>
	/// 存档时间 (UTC)
	/// </summary>
	[SerializableGameDataField]
	public long SavingTimestamp;

	/// <summary>
	/// 太吾姓氏
	/// </summary>
	[SerializableGameDataField]
	public string TaiwuSurname;

	/// <summary>
	/// 太吾名字
	/// </summary>
	[SerializableGameDataField]
	public string TaiwuGivenName;

	/// <summary>
	/// 太吾性别
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 太吾外貌
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	/// <summary>
	/// 太吾所在地 - 洲
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public string MapStateName;

	/// <summary>
	/// 太吾所在地 - 地区
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public string MapAreaName;

	/// <summary>
	/// 角色寿命类型.
	/// <see cref="T:GameData.Domains.World.CharacterLifespanType" />
	/// </summary>
	[SerializableGameDataField]
	public byte CharacterLifespanType;

	/// <summary>
	/// 战斗难度.
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte CombatDifficulty;

	/// <summary>
	/// 研读难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte ReadingDifficulty;

	/// <summary>
	/// 突破难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte BreakoutDifficulty;

	/// <summary>
	/// 周天难度
	/// <see cref="T:GameData.Domains.World.Difficulty" />
	/// </summary>
	[SerializableGameDataField]
	public byte LoopingDifficulty;

	/// <summary>
	/// 敌人的修习
	/// <see cref="F:Config.WorldCreation.DefKey.EnemyPracticeLevel" />
	/// </summary>
	[SerializableGameDataField]
	public byte EnemyPracticeLevel;

	/// <summary>
	/// 人情的变化
	/// <see cref="F:Config.WorldCreation.DefKey.FavorabilityChange" />
	/// </summary>
	[SerializableGameDataField]
	public byte FavorabilityChange;

	/// <summary>
	/// 志向的成长
	/// <see cref="F:Config.WorldCreation.DefKey.ProfessionUpgrade" />
	/// </summary>
	[SerializableGameDataField]
	public byte ProfessionUpgrade;

	/// <summary>
	/// 战利品产出
	/// <see cref="F:Config.WorldCreation.DefKey.LootYield" />
	/// </summary>
	[SerializableGameDataField]
	public short LootYield;

	/// <summary>
	/// 地图上的外道数量的类型.
	/// <see cref="T:GameData.Domains.World.HereticsAmountType" />
	/// </summary>
	[SerializableGameDataField]
	public byte HereticsAmountType;

	/// <summary>
	/// 侵袭的速度类型.
	/// <see cref="T:GameData.Domains.World.BossInvasionSpeedType" />
	/// </summary>
	[SerializableGameDataField]
	public byte BossInvasionSpeedType;

	/// <summary>
	/// 世界的资源数量类型.
	/// <see cref="T:GameData.Domains.World.WorldResourceAmountType" />
	/// </summary>
	[SerializableGameDataField]
	public byte WorldResourceAmountType;

	/// <summary>
	/// 世界的人口数量类型.
	/// <see cref="T:GameData.Domains.World.WorldPopulationType" />
	/// </summary>
	[SerializableGameDataField]
	public byte WorldPopulationType;

	/// <summary>
	/// 是否允许随机太吾继承人
	/// </summary>
	[SerializableGameDataField]
	public bool AllowRandomTaiwuHeir;

	/// <summary>
	/// 是否只允许选择符合立场的选项
	/// </summary>
	[SerializableGameDataField]
	public bool RestrictOptionsBehaviorType;

	/// <summary>
	/// 十五个州的任务状态.
	/// stateId -&gt; StateTaskStatus.
	/// <see cref="T:GameData.Domains.World.StateTaskStatus" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] StateTaskStatuses;

	/// <summary>
	/// 相枢化身的任务状态.
	/// xiangshuAvatarId -&gt; XiangshuAvatarTaskStatus.
	/// </summary>
	[SerializableGameDataField]
	public XiangshuAvatarTaskStatus[] XiangshuAvatarTaskStatuses;

	/// <summary>
	/// 主线进度.
	/// <see cref="T:GameData.Domains.World.MainStoryLineProgress" />
	/// </summary>
	[SerializableGameDataField]
	public short MainStoryLineProgress;

	/// <summary>
	/// 是否打败了染尘子
	/// </summary>
	[SerializableGameDataField]
	public bool BeatRanChenZi;

	/// <summary>
	/// 当前生效的 mod 列表
	/// </summary>
	[SerializableGameDataField]
	public List<ModId> ModIds;

	/// <summary>
	/// 当前生效的 dlc 列表
	/// </summary>
	[SerializableGameDataField]
	public List<DlcId> DlcIds;

	/// <summary>
	/// 游戏版本信息
	/// </summary>
	[SerializableGameDataField]
	public GameVersionInfo GameVersionInfo;

	/// <summary>
	/// 各代太吾数据统计相关信息
	/// </summary>
	[SerializableGameDataField]
	public TotalTaiwuLifeSummaryInfo TotalTaiwuLifeSummaryInfo;

	/// <summary>
	/// 功能状态
	/// </summary>
	[SerializableGameDataField]
	public ulong WorldFunctionStatuses;

	/// <summary>
	/// 太吾所在地 - 洲模版Id
	/// </summary>
	[SerializableGameDataField]
	public sbyte MapStateTemplateId;

	/// <summary>
	/// 太吾所在地 - 地区模版Id
	/// </summary>
	[SerializableGameDataField]
	public short MapAreaTemplateId;

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
		TotalTaiwuLifeSummaryInfo = null;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 49;
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
		*(short*)pCurrData = 35;
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
