using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Organization;

[SerializableGameData(NotForDisplayModule = true)]
public class CivilianSettlement : Settlement, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 2;

		public const uint OrgTemplateId_Offset = 2u;

		public const int OrgTemplateId_Size = 1;

		public const uint Location_Offset = 3u;

		public const int Location_Size = 4;

		public const uint Culture_Offset = 7u;

		public const int Culture_Size = 2;

		public const uint MaxCulture_Offset = 9u;

		public const int MaxCulture_Size = 2;

		public const uint Safety_Offset = 11u;

		public const int Safety_Size = 2;

		public const uint MaxSafety_Offset = 13u;

		public const int MaxSafety_Size = 2;

		public const uint Population_Offset = 15u;

		public const int Population_Size = 4;

		public const uint MaxPopulation_Offset = 19u;

		public const int MaxPopulation_Size = 4;

		public const uint StandardOnStagePopulation_Offset = 23u;

		public const int StandardOnStagePopulation_Size = 4;

		public const uint ApprovingRateUpperLimitBonus_Offset = 27u;

		public const int ApprovingRateUpperLimitBonus_Size = 2;

		public const uint InfluencePowerUpdateDate_Offset = 29u;

		public const int InfluencePowerUpdateDate_Size = 4;

		public const uint RandomNameId_Offset = 33u;

		public const int RandomNameId_Size = 2;

		public const uint MainMorality_Offset = 35u;

		public const int MainMorality_Size = 2;
	}

	[CollectionObjectField(false, true, false, true, false)]
	private short _randomNameId;

	[CollectionObjectField(false, true, false, false, false)]
	private short _mainMorality;

	public const int FixedSize = 37;

	public const int DynamicCount = 2;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[16]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		12, 13, 14, 15, 10, 11
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[14]
	{
		2, 1, 4, 2, 2, 2, 2, 4, 4, 4,
		2, 4, 2, 2
	};

	public CivilianSettlement(short id, Location location, sbyte orgTemplateId, SettlementCreatingInfo settlementCreatingInfo, IRandomSource random)
		: base(id, location, orgTemplateId, random)
	{
		_randomNameId = settlementCreatingInfo.GenerateRandomName(orgTemplateId);
	}

	public short UpdateMainMorality(DataContext context)
	{
		GameData.Domains.Character.Character leader = GetLeader();
		if (leader == null)
		{
			return _mainMorality;
		}
		short morality = leader.GetMorality();
		SetMainMorality(morality, context);
		return morality;
	}

	protected override void RecruitOrCreateLackingMembers(DataContext context)
	{
		if (Location.AreaId >= 45)
		{
			return;
		}
		List<short> blockIds = ObjectPool<List<short>>.Instance.Get();
		blockIds.Clear();
		DomainManager.Map.GetSettlementBlocks(Location.AreaId, Location.BlockId, blockIds);
		List<short> nearbyBlockIds = ObjectPool<List<short>>.Instance.Get();
		nearbyBlockIds.Clear();
		DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(Location.AreaId, Location.BlockId, nearbyBlockIds);
		sbyte mapStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(Location.AreaId);
		OrganizationItem organizationCfg = Config.Organization.Instance[OrgTemplateId];
		for (sbyte grade = 8; grade >= 0; grade--)
		{
			OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[organizationCfg.Members[grade]];
			int principalAmount = GetPrincipalAmount(grade);
			int expectedAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
			int recruitCount = expectedAmount - principalAmount;
			for (int i = 0; i < recruitCount; i++)
			{
				SettlementMembersCreationInfo info = new SettlementMembersCreationInfo(OrgTemplateId, Id, mapStateTemplateId, Location.AreaId, blockIds, nearbyBlockIds);
				info.CoreMemberConfig = orgMemberCfg;
				OrganizationDomain.CreateCoreCharacter(context, info);
				info.CompleteCreatingCharacters();
			}
			if (recruitCount > 0)
			{
				AdaptableLog.TagInfo("RecruitOrCreateLackingMembers", $"Recruited Count for {organizationCfg.Name}, grade {grade}: {recruitCount}");
			}
		}
		ObjectPool<List<short>>.Instance.Return(blockIds);
		ObjectPool<List<short>>.Instance.Return(nearbyBlockIds);
	}

	protected override void OfflineUpdateTreasuryGuards(DataContext context, SettlementLayeredTreasuries treasuries)
	{
		foreach (SettlementTreasury treasury in Enumerable.Reverse(treasuries.SettlementTreasuries))
		{
			SettlementTreasury settlementTreasury = treasury;
			if (settlementTreasury.TemplateGuardIds == null)
			{
				settlementTreasury.TemplateGuardIds = new List<short>();
			}
			treasury.TemplateGuardIds.Clear();
			bool isSect = Config.Organization.Instance[OrgTemplateId].IsSect;
			int count = GlobalConfig.Instance.TreasuryGuardCount;
			sbyte grade = GlobalConfig.Instance.TreasuryGuardMaxGrade[treasury.LayerIndex];
			for (int i = 0; i < count; i++)
			{
				short templateId = (isSect ? GameData.Domains.Character.Character.GetSectRandomEnemyTemplateIdByGrade(OrgTemplateId, grade) : GetTreasuryGuardTemplateId(grade));
				treasury.TemplateGuardIds.Add(templateId);
			}
		}
	}

	public static short GetTreasuryGuardTemplateId(sbyte guardGrade)
	{
		return (short)(375 + guardGrade);
	}

	public override SettlementNameRelatedData GetNameRelatedData()
	{
		MapBlockData block = DomainManager.Map.GetBlock(Location).GetRootBlock();
		return new SettlementNameRelatedData(_randomNameId, block.TemplateId);
	}

	public override void SetCulture(short culture, DataContext context)
	{
		Culture = culture;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public override void SetMaxCulture(short maxCulture, DataContext context)
	{
		MaxCulture = maxCulture;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public override void SetSafety(short safety, DataContext context)
	{
		Safety = safety;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public override void SetMaxSafety(short maxSafety, DataContext context)
	{
		MaxSafety = maxSafety;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public override void SetPopulation(int population, DataContext context)
	{
		Population = population;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public override void SetMaxPopulation(int maxPopulation, DataContext context)
	{
		MaxPopulation = maxPopulation;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public override void SetStandardOnStagePopulation(int standardOnStagePopulation, DataContext context)
	{
		StandardOnStagePopulation = standardOnStagePopulation;
		SetModifiedAndInvalidateInfluencedCache(9, context);
	}

	public override void SetMembers(OrgMemberCollection members, DataContext context)
	{
		Members = members;
		SetModifiedAndInvalidateInfluencedCache(10, context);
	}

	public override void SetLackingCoreMembers(OrgMemberCollection lackingCoreMembers, DataContext context)
	{
		LackingCoreMembers = lackingCoreMembers;
		SetModifiedAndInvalidateInfluencedCache(11, context);
	}

	public override void SetApprovingRateUpperLimitBonus(short approvingRateUpperLimitBonus, DataContext context)
	{
		ApprovingRateUpperLimitBonus = approvingRateUpperLimitBonus;
		SetModifiedAndInvalidateInfluencedCache(12, context);
	}

	public override void SetInfluencePowerUpdateDate(int influencePowerUpdateDate, DataContext context)
	{
		InfluencePowerUpdateDate = influencePowerUpdateDate;
		SetModifiedAndInvalidateInfluencedCache(13, context);
	}

	public short GetRandomNameId()
	{
		return _randomNameId;
	}

	public short GetMainMorality()
	{
		return _mainMorality;
	}

	public void SetMainMorality(short mainMorality, DataContext context)
	{
		_mainMorality = mainMorality;
		SetModifiedAndInvalidateInfluencedCache(15, context);
	}

	public override short GetApprovingRateUpperLimitTempBonus()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 16))
		{
			return ApprovingRateUpperLimitTempBonus;
		}
		short value = CalcApprovingRateUpperLimitTempBonus();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			ApprovingRateUpperLimitTempBonus = value;
			dataStates.SetCached(DataStatesOffset, 16);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ApprovingRateUpperLimitTempBonus;
	}

	public CivilianSettlement()
	{
		Members = new OrgMemberCollection();
		LackingCoreMembers = new OrgMemberCollection();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		int totalSize = 45;
		int dataSize = Members.GetSerializedSize();
		totalSize += dataSize;
		int dataSize2 = LackingCoreMembers.GetSerializedSize();
		return totalSize + dataSize2;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = Id;
		pCurrData += 2;
		*pCurrData = (byte)OrgTemplateId;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		*(short*)pCurrData = Culture;
		pCurrData += 2;
		*(short*)pCurrData = MaxCulture;
		pCurrData += 2;
		*(short*)pCurrData = Safety;
		pCurrData += 2;
		*(short*)pCurrData = MaxSafety;
		pCurrData += 2;
		*(int*)pCurrData = Population;
		pCurrData += 4;
		*(int*)pCurrData = MaxPopulation;
		pCurrData += 4;
		*(int*)pCurrData = StandardOnStagePopulation;
		pCurrData += 4;
		*(short*)pCurrData = ApprovingRateUpperLimitBonus;
		pCurrData += 2;
		*(int*)pCurrData = InfluencePowerUpdateDate;
		pCurrData += 4;
		*(short*)pCurrData = _randomNameId;
		pCurrData += 2;
		*(short*)pCurrData = _mainMorality;
		pCurrData += 2;
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += Members.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"Members"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		byte* pBegin2 = pCurrData;
		pCurrData += 4;
		pCurrData += LackingCoreMembers.Serialize(pCurrData);
		int fieldSize2 = (int)(pCurrData - pBegin2 - 4);
		if (fieldSize2 > 4194304)
		{
			throw new Exception($"Size of field {"LackingCoreMembers"} must be less than {4096}KB");
		}
		*(int*)pBegin2 = fieldSize2;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				Id = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 1:
				OrgTemplateId = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 2:
				pCurrData += Location.Deserialize(pCurrData);
				continue;
			case 3:
				Culture = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 4:
				MaxCulture = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 5:
				Safety = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 6:
				MaxSafety = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 7:
				Population = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 8:
				MaxPopulation = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 9:
				StandardOnStagePopulation = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 12:
				ApprovingRateUpperLimitBonus = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 13:
				InfluencePowerUpdateDate = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 14:
				_randomNameId = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 15:
				_mainMorality = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 10:
				pCurrData += 4;
				pCurrData += Members.Deserialize(pCurrData);
				continue;
			case 11:
				pCurrData += 4;
				pCurrData += LackingCoreMembers.Deserialize(pCurrData);
				continue;
			}
			if (fieldIndex < fixedFieldSizes.Length)
			{
				int fieldSize = fixedFieldSizes[fieldIndex];
				pCurrData += fieldSize;
			}
			else
			{
				int fieldSize2 = *(int*)pCurrData;
				pCurrData += 4;
				pCurrData += fieldSize2;
			}
		}
		return (int)(pCurrData - pData);
	}
}
