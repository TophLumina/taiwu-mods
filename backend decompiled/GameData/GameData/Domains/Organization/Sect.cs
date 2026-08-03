using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Config;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Ai.GeneralAction.TeachRandom;
using GameData.Domains.Character.Filters;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Domains.Organization.SettlementPrisonRecord;
using GameData.Domains.SpecialEffect;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Organization;

[SerializableGameData(NotForDisplayModule = true)]
public class Sect : Settlement, ISerializableGameData
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

		public const uint MinSeniorityId_Offset = 33u;

		public const int MinSeniorityId_Size = 2;

		public const uint TaiwuExploreStatus_Offset = 35u;

		public const int TaiwuExploreStatus_Size = 1;

		public const uint SpiritualDebtInteractionOccurred_Offset = 36u;

		public const int SpiritualDebtInteractionOccurred_Size = 1;

		public const uint TaiwuInvestmentForMartialArtTournament_Offset = 37u;

		public const int TaiwuInvestmentForMartialArtTournament_Size = 12;

		public const uint FunctionStatuses_Offset = 49u;

		public const int FunctionStatuses_Size = 8;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private short _minSeniorityId;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _availableMonasticTitleSuffixIds;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _taiwuExploreStatus;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _spiritualDebtInteractionOccurred;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 3)]
	private int[] _taiwuInvestmentForMartialArtTournament;

	[CollectionObjectField(false, true, false, false, false)]
	private SectFunctionStatuses _functionStatuses;

	[CollectionObjectField(false, false, true, false, false, ArrayElementsCount = 3)]
	private int[] _martialArtTournamentPreparations;

	public TreasuryOrPrisonVisitStatusType PrisonEnteredStatus;

	private SortedList<long, int> _membersSortedByAuthority = new SortedList<long, int>();

	private SettlementPrison _prison;

	public const int FixedSize = 57;

	public const int DynamicCount = 3;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[20]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		12, 13, 14, 16, 17, 18, 19, 10, 11, 15
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[17]
	{
		2, 1, 4, 2, 2, 2, 2, 4, 4, 4,
		2, 4, 2, 1, 1, 12, 8
	};

	public sbyte TaskStatus => DomainManager.Story.GetSectMainStoryTaskStatus(OrgTemplateId);

	private bool IsPreviousMartialArtTournamentWinner => OrgTemplateId == DomainManager.Organization.GetLastMartialArtTournamentWinner();

	public SettlementPrison Prison
	{
		get
		{
			if (_prison != null)
			{
				return _prison;
			}
			if (!DomainManager.Organization.TryGetElement_SettlementPrisons(Id, out _prison))
			{
				_prison = new SettlementPrison();
			}
			return _prison;
		}
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 112, 76 }, Scope = InfluenceScope.SectOfTheChar)]
	[SingleValueCollectionDependency(19, new ushort[] { 194 })]
	private void CalcMartialArtTournamentPreparations(int[] value)
	{
		SortMembersByCombatPower();
		UpdateMartialArtTournamentPreparations();
		int i = _martialArtTournamentPreparations.Length;
		while (i-- > 0)
		{
			value[i] = _martialArtTournamentPreparations[i];
		}
	}

	public Sect(short id, Location location, sbyte orgTemplateId, IRandomSource random)
		: base(id, location, orgTemplateId, random)
	{
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		if (orgConfig.SeniorityGroupId >= 0)
		{
			(short first, short last) seniorityRange = OrganizationDomain.GetSeniorityRange(orgConfig.SeniorityGroupId);
			short seniorityFirst = seniorityRange.first;
			short seniorityLast = seniorityRange.last;
			_minSeniorityId = (short)random.Next(seniorityFirst, seniorityLast + 1);
			(short first, short last) monasticTitleSuffixRange = OrganizationDomain.GetMonasticTitleSuffixRange(orgConfig.SeniorityGroupId);
			short suffixFirst = monasticTitleSuffixRange.first;
			short suffixLast = monasticTitleSuffixRange.last;
			int suffixesCount = suffixLast - suffixFirst + 1;
			_availableMonasticTitleSuffixIds = new List<short>(suffixesCount);
			for (short i = suffixFirst; i <= suffixLast; i++)
			{
				_availableMonasticTitleSuffixIds.Add(i);
			}
		}
		else
		{
			_minSeniorityId = -1;
			_availableMonasticTitleSuffixIds = new List<short>();
		}
		sbyte largeSectIndex = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		if (largeSectIndex >= 0)
		{
			DomainManager.Organization.OfflineInitializeLargeSectFavorabilities(largeSectIndex, orgConfig.LargeSectFavorabilities);
		}
		_taiwuExploreStatus = 0;
		Members = new OrgMemberCollection();
		LackingCoreMembers = new OrgMemberCollection();
		_taiwuInvestmentForMartialArtTournament = new int[3];
		_martialArtTournamentPreparations = new int[3];
	}

	public void SetFunctionStatus(DataContext context, SectFunctionStatuses.SectFunctionStatusType type, bool value)
	{
		_functionStatuses.Set(type, value);
		SetFunctionStatuses(_functionStatuses, context);
	}

	public bool GetFunctionStatus(SectFunctionStatuses.SectFunctionStatusType type)
	{
		return _functionStatuses.Get(type);
	}

	public static bool CanBeGuard(int charId)
	{
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetElement_Objects(charId, out character) && character.IsInteractableAsIntelligentCharacter() && character.GetAgeGroup() == 2 && !DomainManager.LegendaryBook.IsCharacterLegendaryBookOwnerOrContest(charId);
	}

	public void UpdateMartialArtTournamentPreparations()
	{
		UpdateCombatPowerValue();
		UpdateFameValue();
		UpdateTotalWorthValue();
	}

	public void UpdateCombatPowerValue()
	{
		int topTenCombatPower = 0;
		for (int rankingIndex = 0; rankingIndex < 10 && rankingIndex < _membersSortedByCombatPower.Count; rankingIndex++)
		{
			int index = _membersSortedByCombatPower.Count - rankingIndex - 1;
			int combatPower = (int)(_membersSortedByCombatPower.Keys[index] >> 32);
			topTenCombatPower += combatPower;
		}
		_martialArtTournamentPreparations[0] = topTenCombatPower / GlobalConfig.Instance.MartialArtTournamentCombatPowerValueDivider;
	}

	public void UpdateFameValue()
	{
		int count = 0;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> members = Members.GetMembers(grade);
			foreach (int memberCharId in members)
			{
				if (DomainManager.Character.TryGetElement_Objects(memberCharId, out var character) && character.GetOrganizationInfo().Grade > 2)
				{
					switch (OrgTemplateId)
					{
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						if (character.GetFame() >= GlobalConfig.Instance.MartialArtTournamentGoodFameRange.Item1 && character.GetFame() <= GlobalConfig.Instance.MartialArtTournamentGoodFameRange.Item2)
						{
							count++;
						}
						break;
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
						if (character.GetFame() >= GlobalConfig.Instance.MartialArtTournamentNeutralFameRange.Item1 && character.GetFame() <= GlobalConfig.Instance.MartialArtTournamentNeutralFameRange.Item2)
						{
							count++;
						}
						break;
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
						if (character.GetFame() >= GlobalConfig.Instance.MartialArtTournamentBadFameRange.Item1 && character.GetFame() <= GlobalConfig.Instance.MartialArtTournamentBadFameRange.Item2)
						{
							count++;
						}
						break;
					}
				}
				else if (character == null)
				{
					AdaptableLog.TagWarning("UpdateFameValue", $"memberCharId {memberCharId} does not exist, skipping", appendWarningMessage: true);
				}
			}
		}
		_martialArtTournamentPreparations[1] = count;
	}

	public void UpdateTotalWorthValue()
	{
		SettlementLayeredTreasuries treasuries = base.Treasuries;
		_martialArtTournamentPreparations[2] = 0;
		SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			long value = (long)_martialArtTournamentPreparations[2] + (long)((treasury.Inventory.GetTotalValue() + treasury.Resources.GetTotalWorth()) / GlobalConfig.Instance.MartialArtTournamentPreparationValueDivider);
			_martialArtTournamentPreparations[2] = (int)Math.Clamp(value, 0L, 999999999L);
		}
	}

	public void UpdateApprovalOfTaiwu(DataContext context)
	{
		short approvingRate = CalcApprovingRate();
		if (approvingRate < 900)
		{
			return;
		}
		List<int> potentialApprovingCharIds = ObjectPool<List<int>>.Instance.Get();
		potentialApprovingCharIds.Clear();
		for (sbyte grade = 0; grade < 9; grade++)
		{
			IEnumerable<int> gradeMembers = DomainManager.Character.ExcludeInfant(Members.GetMembers(grade));
			foreach (int memberCharId in gradeMembers)
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(memberCharId);
				if (!settlementCharacter.GetApprovedTaiwu())
				{
					potentialApprovingCharIds.Add(memberCharId);
				}
			}
		}
		if (potentialApprovingCharIds.Count <= 0)
		{
			ObjectPool<List<int>>.Instance.Return(potentialApprovingCharIds);
			return;
		}
		int newApprovingCharId = potentialApprovingCharIds.GetRandom(context.Random);
		SectCharacter sectChar = DomainManager.Organization.GetElement_SectCharacters(newApprovingCharId);
		sectChar.SetApprovedTaiwu(context, approve: true);
		DomainManager.Character.TryCreateRelation(context, newApprovingCharId, DomainManager.Taiwu.GetTaiwuCharId());
		ObjectPool<List<int>>.Instance.Return(potentialApprovingCharIds);
	}

	protected override void RecruitOrCreateLackingMembers(DataContext context)
	{
		List<(int, short)> weightTable = new List<(int, short)>();
		List<short> blockIds = ObjectPool<List<short>>.Instance.Get();
		blockIds.Clear();
		DomainManager.Map.GetSettlementBlocks(Location.AreaId, Location.BlockId, blockIds);
		List<short> nearbyBlockIds = ObjectPool<List<short>>.Instance.Get();
		nearbyBlockIds.Clear();
		DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(Location.AreaId, Location.BlockId, nearbyBlockIds);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		sbyte mapStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(Location.AreaId);
		OrganizationItem organizationCfg = Config.Organization.Instance[OrgTemplateId];
		int worldPopulationFactor = DomainManager.World.GetWorldPopulationFactor();
		for (sbyte grade = 8; grade >= 0; grade--)
		{
			OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[organizationCfg.Members[grade]];
			OrganizationInfo orgInfo = new OrganizationInfo(OrgTemplateId, grade, principal: true, Id);
			int principalAmount = GetPrincipalAmount(grade);
			int expectedAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
			if (!orgMemberCfg.RestrictPrincipalAmount)
			{
				expectedAmount = expectedAmount * worldPopulationFactor / 100;
			}
			int recruitCount = expectedAmount - principalAmount;
			if (recruitCount > 0)
			{
				GetRecruitableCharacters(weightTable, grade);
				for (int i = 0; i < recruitCount; i++)
				{
					if (weightTable.Count > 0)
					{
						int index = RandomUtils.GetRandomIndex(weightTable, context.Random);
						int charId = weightTable[index].Item1;
						GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
						DomainManager.Organization.JoinSect(context, character, orgInfo);
						CollectionUtils.SwapAndRemove(weightTable, index);
					}
					else
					{
						SettlementMembersCreationInfo info = new SettlementMembersCreationInfo(OrgTemplateId, Id, mapStateTemplateId, Location.AreaId, blockIds, nearbyBlockIds);
						info.CoreMemberConfig = orgMemberCfg;
						OrganizationDomain.CreateCoreCharacter(context, info);
						info.CompleteCreatingCharacters();
					}
				}
				if (recruitCount > 0)
				{
					AdaptableLog.TagInfo("RecruitOrCreateLackingMembers", $"Recruited Count for {organizationCfg.Name}, grade {grade}: {recruitCount}");
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(blockIds);
		ObjectPool<List<short>>.Instance.Return(nearbyBlockIds);
	}

	private void GetRecruitableCharacters(List<(int, short)> weightTable, sbyte grade = 0)
	{
		weightTable.Clear();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(Location.AreaId);
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId < 0 || settlementInfo.SettlementId == Id)
			{
				continue;
			}
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
			OrganizationItem organizationCfg = Config.Organization.Instance[OrgTemplateId];
			OrgMemberCollection members = settlement.GetMembers();
			int weight = 100 + AiHelper.PrioritizedActionConstants.CivilianGradeJoinSectChance[grade];
			if (weight <= 0)
			{
				continue;
			}
			HashSet<int> gradeMembers = members.GetMembers(grade);
			OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[organizationCfg.Members[grade]];
			if (orgMemberCfg.Gender == -1)
			{
				foreach (int member in gradeMembers)
				{
					weightTable.Add((member, (short)weight));
				}
				continue;
			}
			foreach (int member2 in gradeMembers)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(member2);
				if (character.GetGender() != orgMemberCfg.Gender)
				{
					continue;
				}
				if (orgMemberCfg.ChildGrade < 0)
				{
					RelatedCharacters relatedChars = DomainManager.Character.GetRelatedCharacters(member2);
					if (relatedChars.HusbandsAndWives.GetCount() > 0 || relatedChars.AdoptiveChildren.GetCount() > 0 || relatedChars.BloodChildren.GetCount() > 0 || relatedChars.StepChildren.GetCount() > 0)
					{
						continue;
					}
				}
				weightTable.Add((member2, (short)weight));
			}
		}
	}

	protected override void OfflineUpdateTreasuryGuards(DataContext context, SettlementLayeredTreasuries treasuries)
	{
		int count = GlobalConfig.Instance.TreasuryGuardCount;
		Span<(int, int)> span = stackalloc(int, int)[count];
		SpanList<(int, int)> topK = span;
		HashSet<int> picked = ObjectPool<HashSet<int>>.Instance.Get();
		picked.Clear();
		SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			foreach (int prevGuardId in treasury.GuardIds.GetCollection())
			{
				if (DomainManager.Character.TryGetElement_Objects(prevGuardId, out var character))
				{
					character.RemoveFeatureGroup(context, 691);
					character.AddFeature(context, 698);
				}
			}
		}
		SettlementTreasury[] settlementTreasuries2 = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury2 in settlementTreasuries2)
		{
			sbyte currGrade = GlobalConfig.Instance.SectTreasuryGuardMaxGrade[treasury2.LayerIndex];
			topK.Clear();
			HashSet<int> gradeMembers = Members.GetMembers(currGrade);
			foreach (int charId in gradeMembers)
			{
				if (!picked.Contains(charId) && CanBeGuard(charId))
				{
					GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(charId);
					int combatPower = character2.GetCombatPower();
					if (character2.GetFeatureIds().Contains(698))
					{
						combatPower = combatPower * 2 / 3;
					}
					topK.TryInsertTopK<int>(count, charId, combatPower);
				}
			}
			treasury2.GuardIds.Clear();
			for (int k = 0; k < topK.Count; k++)
			{
				int charId2 = topK[k].Item1;
				treasury2.GuardIds.Add(charId2);
				GameData.Domains.Character.Character character3 = DomainManager.Character.GetElement_Objects(charId2);
				character3.RemoveFeature(context, 698);
				short guardFeatureId = GetTreasuryGuardFeatureId(treasury2.LayerIndex);
				character3.AddFeature(context, guardFeatureId);
				picked.Add(charId2);
			}
		}
		ObjectPool<HashSet<int>>.Instance.Return(picked);
	}

	public override int GetSupplyLevel()
	{
		if (DomainManager.Organization.IsCreatingSettlements())
		{
			return 2;
		}
		sbyte taskStatus = TaskStatus;
		bool isPrevWinner = IsPreviousMartialArtTournamentWinner;
		if (1 == 0)
		{
		}
		int num = taskStatus switch
		{
			0 => (!isPrevWinner) ? 1 : 2, 
			1 => isPrevWinner ? 3 : 2, 
			2 => isPrevWinner ? 1 : 0, 
			_ => 1, 
		};
		if (1 == 0)
		{
		}
		return num + base.Treasuries.SupplyLevelAddOn;
	}

	public override SettlementNameRelatedData GetNameRelatedData()
	{
		MapBlockData block = DomainManager.Map.GetBlock(Location).GetRootBlock();
		return new SettlementNameRelatedData(-1, block.TemplateId);
	}

	public override void ResetLocalCache()
	{
		base.ResetLocalCache();
		_prison = null;
	}

	public int CalcBountyAmount(sbyte grade)
	{
		sbyte goodness = Config.Organization.Instance[OrgTemplateId].Goodness;
		if (1 == 0)
		{
		}
		int result = goodness switch
		{
			-1 => (grade + 1) * (grade + 1) * 1200, 
			1 => (grade + 1) * (grade + 1) * 120, 
			0 => (grade + 1) * (grade + 1) * 600, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public void GetXiangshuInfectedBounties(List<SettlementBounty> bounties)
	{
		List<Predicate<GameData.Domains.Character.Character>> predicates = ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Get();
		List<GameData.Domains.Character.Character> charList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		predicates.Clear();
		charList.Clear();
		areaList.Clear();
		sbyte curStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(Location.AreaId);
		sbyte curStateId = (sbyte)(curStateTemplateId - 1);
		DomainManager.Map.GetAllAreaInState(curStateId, areaList);
		MapCharacterFilter.ParallelFindInfected(predicates, charList, areaList);
		short punishmentType = 40;
		PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentType];
		sbyte punishmentSeverity = GetPunishmentTypeSeverity(punishmentTypeCfg, includeDefault: true);
		PunishmentSeverityItem punishmentSeverityCfg = PunishmentSeverity.Instance[punishmentSeverity];
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (taiwu.IsActiveExternalRelationState(2uL) && taiwu.GetLocation().AreaId == Location.AreaId)
		{
			KidnappedCharacterList kidnappedCharacters = DomainManager.Character.GetKidnappedCharacters(taiwu.GetId());
			foreach (KidnappedCharacter kidnappedChar in kidnappedCharacters.GetCollection())
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(kidnappedChar.CharId);
				if (character.IsCompletelyInfected())
				{
					bounties.Add(new SettlementBounty
					{
						CharId = kidnappedChar.CharId,
						PunishmentSeverity = punishmentSeverity,
						PunishmentType = punishmentType,
						ExpireDate = DomainManager.World.GetCurrDate() + punishmentSeverityCfg.BountyDuration,
						BountyAmount = CalcBountyAmount(character.GetOrganizationInfo().Grade)
					});
				}
			}
		}
		foreach (GameData.Domains.Character.Character character2 in charList)
		{
			int charId = character2.GetId();
			if (DomainManager.Organization.GetPrisonerSect(charId) < 0)
			{
				bounties.Add(new SettlementBounty
				{
					CharId = charId,
					PunishmentSeverity = punishmentSeverity,
					PunishmentType = punishmentType,
					ExpireDate = DomainManager.World.GetCurrDate() + punishmentSeverityCfg.BountyDuration,
					BountyAmount = CalcBountyAmount(character2.GetOrganizationInfo().Grade)
				});
			}
		}
		ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Return(predicates);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(charList);
		ObjectPool<List<short>>.Instance.Return(areaList);
	}

	public bool HasCriminalBounty(int charId)
	{
		return Prison.GetBounty(charId) != null;
	}

	public bool HasEnemySectBounty(int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (!CanHaveBounty(character))
		{
			return false;
		}
		sbyte charOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		if (!OrganizationDomain.IsLargeSect(charOrgTemplateId))
		{
			return false;
		}
		return DomainManager.Organization.GetSectFavorability(OrgTemplateId, charOrgTemplateId) == -1;
	}

	public bool HasEnemyRelationBounty(int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (!CanHaveBounty(character))
		{
			return false;
		}
		if (character.GetOrganizationInfo().SettlementId == Id)
		{
			return false;
		}
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(Location.AreaId);
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetStateSettlementIds(stateId, settlementIds, containsMainCity: true, containsSect: true);
		for (int i = 0; i < settlementIds.Count; i++)
		{
			short settlementId = settlementIds[i];
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			OrgMemberCollection members = settlement.GetMembers();
			for (sbyte grade = 3; grade < 9; grade++)
			{
				HashSet<int> gradeMembers = members.GetMembers(grade);
				foreach (int gradeMemberId in gradeMembers)
				{
					if (DomainManager.Organization.GetPrisonerSect(gradeMemberId) != OrgTemplateId)
					{
						RelatedCharacters relatedCharacters = DomainManager.Character.GetRelatedCharacters(gradeMemberId);
						HashSet<int> enemies = relatedCharacters.Enemies.GetCollection();
						if (enemies.Contains(charId))
						{
							ObjectPool<List<short>>.Instance.Return(settlementIds);
							return true;
						}
					}
				}
			}
		}
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return false;
	}

	public void GetEnemySectBounties(List<SettlementBounty> bounties)
	{
		short punishmentType = 42;
		PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentType];
		sbyte punishmentSeverity = GetPunishmentTypeSeverity(punishmentTypeCfg, includeDefault: true);
		int duration = PunishmentSeverity.Instance[punishmentSeverity].BountyDuration;
		Span<sbyte> span = stackalloc sbyte[15];
		SpanList<sbyte> hostileSects = span;
		DomainManager.Organization.GetSectTemplateIdsByFavorability(OrgTemplateId, -1, ref hostileSects);
		SpanList<sbyte>.Enumerator enumerator = hostileSects.GetEnumerator();
		while (enumerator.MoveNext())
		{
			sbyte hostileSectTemplateId = enumerator.Current;
			Sect hostileSect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(hostileSectTemplateId);
			for (sbyte grade = 0; grade < 9; grade++)
			{
				HashSet<int> gradeMembers = hostileSect.Members.GetMembers(grade);
				foreach (int enemySectMemberId in gradeMembers)
				{
					if (DomainManager.Character.TryGetElement_Objects(enemySectMemberId, out var enemy) && CanHaveBounty(enemy))
					{
						bounties.Add(new SettlementBounty
						{
							CharId = enemySectMemberId,
							PunishmentSeverity = punishmentSeverity,
							PunishmentType = punishmentType,
							ExpireDate = DomainManager.World.GetCurrDate() + duration,
							BountyAmount = CalcBountyAmount(grade)
						});
					}
				}
			}
		}
	}

	public void GetEnemyRelationBounties(List<SettlementBounty> bounties)
	{
		short punishmentType = 43;
		PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentType];
		sbyte punishmentSeverity = GetPunishmentTypeSeverity(punishmentTypeCfg, includeDefault: true);
		int duration = PunishmentSeverity.Instance[punishmentSeverity].BountyDuration;
		for (sbyte grade = 3; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			foreach (int gradeMemberId in gradeMembers)
			{
				if (DomainManager.Organization.GetPrisonerSect(gradeMemberId) == OrgTemplateId)
				{
					continue;
				}
				RelatedCharacters relatedCharacters = DomainManager.Character.GetRelatedCharacters(gradeMemberId);
				HashSet<int> enemies = relatedCharacters.Enemies.GetCollection();
				foreach (int enemyId in enemies)
				{
					if (DomainManager.Character.TryGetElement_Objects(enemyId, out var enemy) && CanHaveBounty(enemy) && enemy.GetOrganizationInfo().SettlementId != Id)
					{
						bounties.Add(new SettlementBounty
						{
							CharId = enemyId,
							PunishmentSeverity = punishmentSeverity,
							PunishmentType = punishmentType,
							ExpireDate = DomainManager.World.GetCurrDate() + duration,
							BountyAmount = CalcBountyAmount(enemy.GetOrganizationInfo().Grade)
						});
					}
				}
			}
		}
	}

	private bool CanHaveBounty(GameData.Domains.Character.Character character)
	{
		return CharacterMatcher.DefValue.CanHaveBounty.Match(character);
	}

	public void AddBounty(DataContext context, GameData.Domains.Character.Character character, sbyte punishmentSeverity, short punishmentType, int duration = -1)
	{
		if (duration < 0)
		{
			duration = PunishmentSeverity.Instance[punishmentSeverity].BountyDuration;
		}
		AdaptableLog.TagInfo(ToString(), $"add bounty on {character} for {duration} months.");
		if (punishmentType < 0)
		{
			PredefinedLog.Show(33, character, PunishmentSeverity.Instance.GetItem(punishmentSeverity)?.Name);
		}
		int charId = character.GetId();
		SettlementPrison prison = Prison;
		sbyte grade = character.GetInteractionGrade();
		SettlementBounty bounty = prison.GetBounty(charId);
		if (bounty != null)
		{
			if (bounty.PunishmentSeverity >= punishmentSeverity)
			{
				return;
			}
			bounty.PunishmentSeverity = punishmentSeverity;
			bounty.PunishmentType = punishmentType;
			bounty.ExpireDate = DomainManager.World.GetCurrDate() + duration;
		}
		else
		{
			DomainManager.Organization.RegisterSectFugitive(charId, OrgTemplateId);
			prison.Bounties.Add(new SettlementBounty
			{
				CharId = charId,
				PunishmentSeverity = punishmentSeverity,
				PunishmentType = punishmentType,
				ExpireDate = DomainManager.World.GetCurrDate() + duration,
				BountyAmount = CalcBountyAmount(grade)
			});
		}
		if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			Events.RaiseBountyAddedOnTaiwu(context, OrgTemplateId);
		}
		DomainManager.Organization.SetSettlementPrison(context, Id, prison);
	}

	public bool RemoveBounty(DataContext context, int charId)
	{
		SettlementPrison prison = Prison;
		SettlementBounty bounty = prison.OfflineRemoveBounty(charId);
		if (bounty == null)
		{
			return false;
		}
		OnSettlementBountyRemoved(context, bounty);
		DomainManager.Organization.SetSettlementPrison(context, Id, prison);
		return true;
	}

	public void AddPrisoner(DataContext context, GameData.Domains.Character.Character character, short punishmentType)
	{
		PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentType];
		sbyte punishmentSeverity = GetPunishmentTypeSeverity(punishmentTypeCfg, includeDefault: true);
		PunishmentSeverityItem punishmentSeverityCfg = PunishmentSeverity.Instance[punishmentSeverity];
		AddPrisoner(context, character, punishmentSeverity, punishmentType, punishmentSeverityCfg.PrisonTime);
	}

	public void AddPrisoner(DataContext context, GameData.Domains.Character.Character character, sbyte punishmentSeverity, short punishmentType, int duration = -1)
	{
		Tester.Assert(character.GetKidnapperId() < 0);
		Tester.Assert(character.GetId() != DomainManager.Taiwu.GetTaiwuCharId());
		int charId = character.GetId();
		SettlementPrison prison = Prison;
		if (duration < 0)
		{
			PunishmentSeverityItem punishmentSeverityCfg = PunishmentSeverity.Instance[punishmentSeverity];
			duration = punishmentSeverityCfg.PrisonTime;
		}
		AdaptableLog.TagInfo(ToString(), $"add prisoner {character} for {duration} months.");
		SettlementPrisoner prisoner = prison.GetPrisoner(charId);
		if (prisoner != null)
		{
			prisoner.PunishmentSeverity = punishmentSeverity;
			prisoner.PunishmentType = punishmentType;
			prisoner.Duration = duration;
			prisoner.KidnapBeginDate = DomainManager.World.GetCurrDate();
			prisoner.RopeItemKey = new ItemKey(12, 0, GetPrisonRopeTemplateId(punishmentSeverity), -1);
			prisoner.InitialMorality = character.GetBaseMorality();
			DomainManager.Organization.SetSettlementPrison(context, Id, prison);
			return;
		}
		prison.Prisoners.Add(new SettlementPrisoner
		{
			CharId = charId,
			PunishmentType = punishmentType,
			PunishmentSeverity = punishmentSeverity,
			Duration = duration,
			KidnapBeginDate = DomainManager.World.GetCurrDate(),
			RopeItemKey = new ItemKey(12, 0, GetPrisonRopeTemplateId(punishmentSeverity), -1),
			InitialMorality = character.GetBaseMorality(),
			SpouseCharId = DomainManager.Character.GetAliveSpouse(charId)
		});
		DomainManager.Character.LeaveGroup(context, character, bringWards: false);
		DomainManager.Character.GroupMove(context, character, Location);
		DomainManager.Character.RemoveAllKidnappedChars(context, character, isEscaped: true);
		DomainManager.Character.HideCharacterOnMap(context, character, 32uL, bringWards: false);
		character.SetLocation(Location.Invalid, context);
		DomainManager.Organization.RegisterSectPrisoner(charId, OrgTemplateId);
		AdaptableLog.Info($"Prisoner {character} added to {ToString()}");
		if (!RemoveBounty(context, charId))
		{
			DomainManager.Organization.SetSettlementPrison(context, Id, prison);
		}
	}

	public bool RemovePrisoner(DataContext context, int charId)
	{
		SettlementPrison prison = Prison;
		SettlementPrisoner prisoner = prison.OfflineRemovePrisoner(charId);
		if (prisoner == null)
		{
			return false;
		}
		OnSettlementPrisonerRemoved(context, prisoner);
		DomainManager.Organization.SetSettlementPrison(context, Id, prison);
		return true;
	}

	private void OnSettlementPrisonerRemoved(DataContext context, SettlementPrisoner prisoner)
	{
		if (!DomainManager.Character.TryGetElement_Objects(prisoner.CharId, out var character))
		{
			DomainManager.Organization.UnregisterSectPrisoner(prisoner.CharId);
			return;
		}
		Location location = character.GetValidLocation();
		character.SetLocation(location, context);
		DomainManager.Character.UnhideCharacterOnMap(context, character, 32uL);
		DomainManager.Organization.UnregisterSectPrisoner(prisoner.CharId);
		AdaptableLog.Info($"Prisoner {character} removed from {ToString()}.");
	}

	private void OnSettlementBountyRemoved(DataContext context, SettlementBounty bounty)
	{
		DomainManager.Organization.UnregisterSectFugitive(bounty.CharId, OrgTemplateId);
		if (bounty.CharId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Extra.TaiwuWantedResetSectInteracted(context, OrgTemplateId);
		}
	}

	public short GetPrisonRopeTemplateId(sbyte punishmentSeverity)
	{
		int grade = Math.Clamp((punishmentSeverity - 1) * 2, 0, 8);
		return (short)(82 + grade);
	}

	public void UpdatePrisonOnAdvanceMonth(DataContext context)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SettlementPrisonRecordCollection settlementPrisonRecordCollection = DomainManager.Organization.GetSettlementPrisonRecordCollection(context, Id);
		int currDate = DomainManager.World.GetCurrDate();
		SettlementPrison prison = Prison;
		bool isChanged = prison.Prisoners.Count > 0;
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		KidnappedTravelData kidnappedData = DomainManager.Extra.GetKidnappedTravelData();
		for (int i = prison.Bounties.Count - 1; i >= 0; i--)
		{
			SettlementBounty bounty = prison.Bounties[i];
			if (bounty.CharId != taiwuId || !kidnappedData.Valid)
			{
				GameData.Domains.Character.Character hunter;
				if (bounty.ExpireDate <= currDate)
				{
					prison.Bounties.RemoveAt(i);
					OnSettlementBountyRemoved(context, bounty);
					isChanged = true;
				}
				else if (bounty.CurrentHunterId >= 0 && (!DomainManager.Character.TryGetElement_Objects(bounty.CurrentHunterId, out hunter) || hunter.IsActiveExternalRelationState(32uL) || DomainManager.Organization.GetFugitiveBountySect(bounty.CurrentHunterId) >= 0))
				{
					bounty.CurrentHunterId = -1;
					isChanged = true;
				}
			}
		}
		for (int i2 = prison.Prisoners.Count - 1; i2 >= 0; i2--)
		{
			SettlementPrisoner prisoner = prison.Prisoners[i2];
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(prisoner.CharId);
			if (!character.IsCompletelyInfected())
			{
				ApplyPrisonerPunishmentOnAdvanceMonth(context, prisoner);
				if (prisoner.KidnapBeginDate + prisoner.Duration <= currDate)
				{
					short punishmentType = prisoner.PunishmentType;
					if ((uint)(punishmentType - 42) <= 1u)
					{
						MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
						monthlyEventCollection.AddSentenceCompleted(prisoner.CharId, Id);
						continue;
					}
					prison.Prisoners.RemoveAt(i2);
					OnSettlementPrisonerRemoved(context, prisoner);
					PunishmentSeverityItem punishmentSeverity = PunishmentSeverity.Instance[prisoner.PunishmentSeverity];
					if (punishmentSeverity.Expel)
					{
						ExpelSectMember(context, this, character, prisoner.PunishmentType, prisoner.SpouseCharId);
					}
					else
					{
						lifeRecordCollection.AddBeReleasedUponCompletionOfASentence(prisoner.CharId, currDate, Id);
						settlementPrisonRecordCollection.AddBeReleasedUponCompletionOfASentence(currDate, Id, prisoner.CharId);
						if (character.GetOrganizationInfo().OrgTemplateId == 0)
						{
							AdjustPunishedSectMemberOrganization(context, character);
						}
					}
					SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
					int secretInfoOffset = secretInformationCollection.AddReleasedPrison(prisoner.CharId, DomainManager.Organization.GetSettlementByOrgTemplateId(OrgTemplateId).GetLocation());
					SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
					continue;
				}
			}
			int resistance = CalcKidnappedCharacterResistance(prisoner);
			int escapeRate = prisoner.CalcEscapeRate(resistance, 0, character.IsEscapeCertainly());
			bool isEscaped = context.Random.CheckPercentProb(escapeRate);
			string escapeText = (isEscaped ? "√成功" : "×失败");
			AdaptableLog.Info("逃跑" + escapeText);
			AdaptableLog.Info("");
			if (isEscaped)
			{
				prison.Prisoners.RemoveAt(i2);
				OnSettlementPrisonerRemoved(context, prisoner);
				lifeRecordCollection.AddPrisonBreak(prisoner.CharId, currDate, Id);
				settlementPrisonRecordCollection.AddPrisonBreak(currDate, Id, prisoner.CharId);
				SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset2 = secretInformationCollection2.AddPrisonBreak(prisoner.CharId, Location);
				SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
			}
		}
		if (isChanged)
		{
			DomainManager.Organization.SetSettlementPrison(context, Id, prison);
		}
		DomainManager.Organization.SetSettlementPrisonRecordCollection(context, Id, settlementPrisonRecordCollection);
	}

	public int CalcKidnappedCharacterResistance(SettlementPrisoner prisoner)
	{
		GameData.Domains.Character.Character kidnapped = DomainManager.Character.GetElement_Objects(prisoner.CharId);
		if (kidnapped.IsEscapeCertainly())
		{
			return 999;
		}
		int behaviorFactor = kidnapped.GetBehaviorType() + 1;
		int severity = prisoner.PunishmentSeverity + 1;
		sbyte grade = kidnapped.GetOrganizationInfo().Grade;
		int baseValue = behaviorFactor * (severity * 5 - grade);
		int consummateLevel = GetPrisonerRelatedGuards(prisoner).Select((Func<int, int>)((int id) => DomainManager.Character.GetElement_Objects(id).GetConsummateLevel())).Prepend(-1).Max();
		if (consummateLevel == -1)
		{
			consummateLevel = GlobalConfig.Instance.GuardConsummateLevel[Math.Clamp((int)prisoner.GetPrisonType(), 0, 2)];
		}
		int levelEffect = GlobalConfig.Instance.MaxConsummateLevel + kidnapped.GetConsummateLevel() - consummateLevel;
		int currDate = DomainManager.World.GetCurrDate();
		int passTime = currDate - prisoner.KidnapBeginDate;
		int durationEffect = prisoner.Duration - 2 * passTime;
		int value = baseValue + levelEffect + durationEffect;
		AdaptableLog.Info("");
		AdaptableLog.Info($"{base.OrganizationConfig.Name}关押{kidnapped}，初始值：立场{behaviorFactor} * (罪行{severity} * 5 - 身份{grade}) = {baseValue}，精纯影响：精纯上限{GlobalConfig.Instance.MaxConsummateLevel} + 囚犯精纯{kidnapped.GetConsummateLevel()} - 守卫平均精纯{consummateLevel} = {levelEffect}，时长影响：总时长{prisoner.Duration} - 2 * 已关押时长{passTime} = {durationEffect}，共计：{value}");
		return value;
	}

	public void ExpelSectMember(DataContext context, Sect sect, GameData.Domains.Character.Character character, short punishmentType, int spouseCharId)
	{
		int charId = character.GetId();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		sbyte sectTemplateId = sect.GetOrgTemplateId();
		short sectSettlementId = sect.GetId();
		if (orgInfo.OrgTemplateId == sectTemplateId)
		{
			HashSet<int> mentorSet = DomainManager.Character.GetRelatedCharIds(charId, 2048);
			HashSet<int> menteeSet = DomainManager.Character.GetRelatedCharIds(charId, 4096);
			HashSet<int> hashSet = ObjectPool<HashSet<int>>.Instance.Get();
			hashSet.Clear();
			hashSet.UnionWith(mentorSet);
			foreach (int relatedCharId in hashSet)
			{
				DomainManager.Character.ChangeRelationType(context, charId, relatedCharId, 2048, 0);
				DomainManager.Character.ChangeRelationType(context, relatedCharId, charId, 4096, 0);
			}
			hashSet.Clear();
			hashSet.UnionWith(menteeSet);
			foreach (int relatedCharId2 in hashSet)
			{
				DomainManager.Character.ChangeRelationType(context, charId, relatedCharId2, 4096, 0);
				DomainManager.Character.ChangeRelationType(context, relatedCharId2, charId, 2048, 0);
			}
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int date = DomainManager.World.GetCurrDate();
		if (punishmentType == 21 && spouseCharId >= 0)
		{
			lifeRecordCollection.AddBeImplicatedSectPunishLevel5Expel(character.GetId(), date, spouseCharId, sectSettlementId);
		}
		else
		{
			lifeRecordCollection.AddSectPunishLevel5Expel(character.GetId(), date, punishmentType, sectSettlementId);
		}
		DomainManager.Organization.JoinNearbyVillageTownAsBeggar(context, character, -1);
	}

	public void AdjustPunishedSectMemberOrganization(DataContext context, GameData.Domains.Character.Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.OrgTemplateId == 0)
		{
			sbyte stateId = DomainManager.Map.GetStateIdByAreaId(GetLocation().AreaId);
			short targetSettlementId = DomainManager.Map.GetRandomStateSettlementId(context.Random, stateId, containsMainCity: true);
			if (targetSettlementId < 0)
			{
				targetSettlementId = GetId();
			}
			Settlement targetSettlement = DomainManager.Organization.GetSettlement(targetSettlementId);
			OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(targetSettlement.GetOrgTemplateId(), orgInfo.Grade);
			sbyte rejoinGrade = orgMemberCfg.GetRejoinGrade();
			if (targetSettlementId == DomainManager.Taiwu.GetTaiwuVillageSettlementId())
			{
				rejoinGrade = 0;
			}
			OrganizationInfo newOrgInfo = new OrganizationInfo(targetSettlement.GetOrgTemplateId(), rejoinGrade, principal: true, targetSettlementId);
			DomainManager.Organization.ChangeOrganization(context, character, newOrgInfo);
		}
	}

	private unsafe void ApplyPrisonerPunishmentOnAdvanceMonth(DataContext context, SettlementPrisoner prisoner)
	{
		int charId = prisoner.CharId;
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || character.GetAgeGroup() != 2)
		{
			return;
		}
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddImprisoned(charId, DomainManager.Organization.GetSettlementByOrgTemplateId(OrgTemplateId).GetLocation());
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		switch (OrgTemplateId)
		{
		case 1:
		{
			HashSet<int> relatedCharIds = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
			DomainManager.Character.GetAllRelatedCharIds(charId, relatedCharIds);
			foreach (int relatedCharId in relatedCharIds)
			{
				if (DomainManager.Character.TryGetElement_Objects(relatedCharId, out var relatedChar))
				{
					if (DomainManager.Character.TryGetRelation(relatedCharId, charId, out var targetToSelf) && targetToSelf.Favorability > 0)
					{
						DomainManager.Character.ChangeFavorabilityOptional(context, relatedChar, character, -1000, 5);
					}
					if (DomainManager.Character.TryGetRelation(charId, relatedCharId, out var selfToTarget) && selfToTarget.Favorability > 0)
					{
						DomainManager.Character.ChangeFavorabilityOptional(context, character, relatedChar, -1000, 5);
					}
				}
			}
			context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref relatedCharIds);
			lifeRecordCollection.AddImprisonedShaoLin(charId, currDate, Id);
			break;
		}
		case 2:
		{
			List<int> targetCharIds = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
			for (sbyte grade = 0; grade < 9; grade++)
			{
				HashSet<int> gradeMembers = Members.GetMembers(grade);
				foreach (int gradeMemberId in gradeMembers)
				{
					if (DomainManager.Character.TryGetElement_Objects(gradeMemberId, out var gradeMember) && character.CanTeachCombatSkill(gradeMember))
					{
						targetCharIds.Add(gradeMemberId);
					}
				}
			}
			int targetCharId = targetCharIds.GetRandomOrDefault(context.Random, -1);
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref targetCharIds);
			if (targetCharId >= 0)
			{
				GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
				List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
				character.GetTeachableCombatSkillBookIds(targetChar, weightTable);
				short skillBookTemplateId = RandomUtils.GetRandomResult(weightTable, context.Random);
				context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
				SkillBookItem bookCfg = Config.SkillBook.Instance[skillBookTemplateId];
				Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
				ushort readingState = selfCombatSkills[bookCfg.CombatSkillTemplateId].GetReadingState();
				byte currInternalIndex = 0;
				while (currInternalIndex < 15 && !CombatSkillStateHelper.IsPageRead(readingState, currInternalIndex))
				{
					currInternalIndex++;
				}
				CombatSkillShorts combatSkillAttainments = targetChar.GetCombatSkillAttainments();
				CombatSkillShorts combatSkillQualifications = targetChar.GetCombatSkillQualifications();
				Personalities personalities = targetChar.GetPersonalities();
				int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(bookCfg.Grade, combatSkillQualifications[bookCfg.CombatSkillType], combatSkillAttainments[bookCfg.CombatSkillType], personalities[1]);
				byte pageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(context.Random, readingState);
				TeachCombatSkillAction action = new TeachCombatSkillAction
				{
					GeneratedPageTypes = pageTypes,
					InternalIndex = currInternalIndex,
					SkillTemplateId = bookCfg.CombatSkillTemplateId,
					Succeed = context.Random.CheckPercentProb(successRate)
				};
				action.ApplyChanges(context, character, targetChar);
				if (action.Succeed)
				{
					prisoner.Duration = Math.Max(0, prisoner.Duration - 1);
					lifeRecordCollection.AddImprisonedEmei1(charId, currDate, Id);
				}
				else
				{
					prisoner.Duration++;
					lifeRecordCollection.AddImprisonedEmei2(charId, currDate, Id);
				}
			}
			break;
		}
		case 3:
			if (character.GetCurrNeili() > 0)
			{
				character.ChangeCurrNeiliWithoutChecking(context, -character.GetMaxNeili() * 3 / 10);
			}
			else
			{
				NeiliAllocation baseNeiliAllocation = character.GetBaseNeiliAllocation();
				for (int k = 0; k < 30; k++)
				{
					byte maxType = baseNeiliAllocation.GetMaxType();
					if (baseNeiliAllocation[maxType] == 0)
					{
						break;
					}
					baseNeiliAllocation[maxType]--;
				}
				character.SetBaseNeiliAllocation(baseNeiliAllocation, context);
			}
			lifeRecordCollection.AddImprisonedBaihua(charId, currDate, Id);
			break;
		case 4:
			character.ChangeDisorderOfQi(context, 500);
			lifeRecordCollection.AddImprisonedWudang(charId, currDate, Id);
			break;
		case 5:
			character.ChangeXiangshuInfection(context, 10);
			lifeRecordCollection.AddImprisonedYuanshan(charId, currDate, Id);
			break;
		case 6:
		{
			List<int> availableSkillIndices = context.AdvanceMonthRelatedData.IntList.Occupy();
			List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = character.GetLearnedLifeSkills();
			for (int i2 = learnedLifeSkills.Count - 1; i2 >= 0; i2--)
			{
				if (learnedLifeSkills[i2].ReadingState != 0)
				{
					availableSkillIndices.Add(i2);
				}
			}
			Span<byte> span2 = stackalloc byte[5];
			SpanList<byte> pages = span2;
			for (int j = 0; j < 3; j++)
			{
				if (availableSkillIndices.Count <= 0)
				{
					break;
				}
				int index = availableSkillIndices.GetRandom(context.Random);
				GameData.Domains.Character.LifeSkillItem skill = learnedLifeSkills[index];
				bool isAllPagedRead = skill.IsAllPagesRead();
				pages.Clear();
				for (byte page = 0; page < 5; page++)
				{
					if (skill.IsPageRead(page))
					{
						pages.Add(page);
					}
				}
				byte selectedPage = pages.GetRandom(context.Random);
				skill.SetPageUnread(selectedPage);
				learnedLifeSkills[index] = skill;
				if (skill.GetReadPagesCount() == 0)
				{
					availableSkillIndices.Remove(index);
				}
				if (skill.IsAllPagesRead() != isAllPagedRead && isAllPagedRead)
				{
					Config.LifeSkillItem cfg = LifeSkill.Instance.GetItem(skill.SkillTemplateId);
					short templateId = Config.LifeSkillType.Instance[cfg.Type].InformationTemplateId;
					DomainManager.Information.DiscardNormalInformation(context, charId, new NormalInformation(templateId, cfg.Grade));
				}
			}
			character.SetLearnedLifeSkills(learnedLifeSkills, context);
			context.AdvanceMonthRelatedData.IntList.Release(ref availableSkillIndices);
			lifeRecordCollection.AddImprisonedShingXiang(charId, currDate, Id);
			break;
		}
		case 7:
		{
			if (prisoner.InitialMorality == 0 || character.GetFixedMorality() != short.MaxValue)
			{
				break;
			}
			sbyte initBehaviorType = GameData.Domains.Character.BehaviorType.GetBehaviorType(prisoner.InitialMorality);
			sbyte currBehaviorType = character.GetBehaviorType();
			switch (initBehaviorType)
			{
			case 0:
				if (currBehaviorType >= 4)
				{
					return;
				}
				character.ChangeBaseMorality(context, -25);
				break;
			case 1:
				if (currBehaviorType >= 3)
				{
					return;
				}
				character.ChangeBaseMorality(context, -25);
				break;
			case 2:
				if (prisoner.InitialMorality > 0)
				{
					character.ChangeBaseMorality(context, -25);
				}
				else
				{
					character.ChangeBaseMorality(context, 25);
				}
				break;
			case 3:
				if (currBehaviorType <= 1)
				{
					return;
				}
				character.ChangeBaseMorality(context, 25);
				break;
			case 4:
				if (currBehaviorType <= 0)
				{
					return;
				}
				character.ChangeBaseMorality(context, 25);
				break;
			}
			lifeRecordCollection.AddImprisonedRanShan(charId, currDate, Id);
			break;
		}
		case 8:
		{
			if (!DomainManager.World.CheckDateInterval(prisoner.KidnapBeginDate, 6))
			{
				break;
			}
			List<short> featureIds = character.GetFeatureIds();
			List<short> downgradeFeatures = ObjectPool<List<short>>.Instance.Get();
			foreach (short featureId2 in featureIds)
			{
				CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId2];
				if (featureCfg.Degrade() != null)
				{
					downgradeFeatures.Add(featureId2);
				}
			}
			if (downgradeFeatures.Count > 0)
			{
				short selectedFeatureId = downgradeFeatures.GetRandom(context.Random);
				CharacterFeatureItem newFeatureCfg = CharacterFeature.Instance[selectedFeatureId].Degrade();
				character.AddFeature(context, newFeatureCfg.TemplateId, removeMutexFeature: true);
				lifeRecordCollection.AddImprisonedXuanNv(charId, currDate, Id);
			}
			ObjectPool<List<short>>.Instance.Return(downgradeFeatures);
			break;
		}
		case 9:
			if (DomainManager.World.CheckDateInterval(prisoner.KidnapBeginDate, 3))
			{
				character.ChangeCurrAge(context, 1);
				lifeRecordCollection.AddImprisonedZhuJian(charId, currDate, Id);
			}
			break;
		case 10:
		{
			Span<short> poisons = stackalloc short[6] { 8, 17, 26, 35, 44, 53 };
			sbyte poisonType = (sbyte)context.Random.Next(6);
			short templateId2 = poisons[poisonType];
			character.ApplyEatingItemInstantEffects(context, 8, templateId2);
			lifeRecordCollection.AddImprisonedKongSang(charId, currDate, Id, 8, templateId2);
			break;
		}
		case 11:
		{
			NeiliAllocation extraNeiliAllocation = character.GetExtraNeiliAllocation();
			byte maxType2 = extraNeiliAllocation.GetMaxType();
			int maxValue = extraNeiliAllocation[maxType2];
			if (maxValue > 0)
			{
				short delta = (short)(-Math.Min(maxValue, 5));
				character.ChangeExtraNeiliAllocation(context, maxType2, delta);
				lifeRecordCollection.AddImprisonedJinGang(charId, currDate, Id);
			}
			break;
		}
		case 12:
		{
			int beginDate = prisoner.KidnapBeginDate;
			if ((currDate - beginDate) % 6 != 0)
			{
				break;
			}
			EatingItems eatingItems = character.GetEatingItems();
			Span<sbyte> span = stackalloc sbyte[8];
			SpanList<sbyte> wugs = span;
			for (sbyte wugType = 0; wugType < 8; wugType++)
			{
				wugs.Add(wugType);
			}
			for (int i = 0; i < 9; i++)
			{
				ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
				if (EatingItems.IsWug(itemKey))
				{
					wugs.Remove(Config.Medicine.Instance[itemKey.TemplateId].WugType);
				}
			}
			if (wugs.Count != 0)
			{
				sbyte randWug = wugs.GetRandom(context.Random);
				short wugTemplateId = ItemDomain.GetWugTemplateId(randWug, 4);
				character.AddWug(context, wugTemplateId, -1);
				lifeRecordCollection.AddImprisonedWuXian(charId, currDate, Id, 8, wugTemplateId);
			}
			break;
		}
		case 13:
		{
			OrgMemberCollection members = GetMembers();
			List<int> targets = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
			HashSet<int> gradeMembers2 = members.GetMembers(character.GetInteractionGrade());
			foreach (int memberId in gradeMembers2)
			{
				GameData.Domains.Character.Character member = DomainManager.Character.GetElement_Objects(memberId);
				if (member.IsInteractableAsIntelligentCharacter())
				{
					targets.Add(memberId);
				}
			}
			if (targets.Count > 0)
			{
				int targetCharId2 = targets.GetRandom(context.Random);
				GameData.Domains.Character.Character targetChar2 = DomainManager.Character.GetElement_Objects(targetCharId2);
				AiHelper.NpcCombatResultType resultType = DomainManager.Character.SimulateCharacterCombat(context, character, targetChar2, CombatType.Beat, isGroupCombat: false);
				if ((uint)resultType <= 1u)
				{
					prisoner.Duration = Math.Max(0, prisoner.Duration - 1);
					lifeRecordCollection.AddImprisonedJieQing1(charId, currDate, Id);
				}
				else
				{
					prisoner.Duration++;
					lifeRecordCollection.AddImprisonedJieQing2(charId, currDate, Id);
				}
			}
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref targets);
			break;
		}
		case 14:
			character.ChangeHealth(context, -24);
			lifeRecordCollection.AddImprisonedFuLong(charId, currDate, Id);
			break;
		case 15:
		{
			sbyte bodyPart = (sbyte)context.Random.Next(7);
			bool isInner = context.Random.NextBool();
			character.ChangeInjury(context, bodyPart, isInner, 1);
			if (context.Random.NextBool())
			{
				short featureId = (isInner ? BreakFeatureHelper.BodyPart2HurtFeature[bodyPart] : BreakFeatureHelper.BodyPart2CrashFeature[bodyPart]);
				if (!character.GetFeatureIds().Contains(featureId))
				{
					character.AddFeature(context, featureId);
					DomainManager.SpecialEffect.Add(context, charId, SpecialEffectDomain.BreakBodyFeatureEffectClassName[featureId]);
				}
			}
			lifeRecordCollection.AddImprisonedXueHou(charId, currDate, Id, bodyPart);
			break;
		}
		}
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

	public short GetMinSeniorityId()
	{
		return _minSeniorityId;
	}

	public void SetMinSeniorityId(short minSeniorityId, DataContext context)
	{
		_minSeniorityId = minSeniorityId;
		SetModifiedAndInvalidateInfluencedCache(14, context);
	}

	public List<short> GetAvailableMonasticTitleSuffixIds()
	{
		return _availableMonasticTitleSuffixIds;
	}

	public void SetAvailableMonasticTitleSuffixIds(List<short> availableMonasticTitleSuffixIds, DataContext context)
	{
		_availableMonasticTitleSuffixIds = availableMonasticTitleSuffixIds;
		SetModifiedAndInvalidateInfluencedCache(15, context);
	}

	public byte GetTaiwuExploreStatus()
	{
		return _taiwuExploreStatus;
	}

	public void SetTaiwuExploreStatus(byte taiwuExploreStatus, DataContext context)
	{
		_taiwuExploreStatus = taiwuExploreStatus;
		SetModifiedAndInvalidateInfluencedCache(16, context);
	}

	public bool GetSpiritualDebtInteractionOccurred()
	{
		return _spiritualDebtInteractionOccurred;
	}

	public void SetSpiritualDebtInteractionOccurred(bool spiritualDebtInteractionOccurred, DataContext context)
	{
		_spiritualDebtInteractionOccurred = spiritualDebtInteractionOccurred;
		SetModifiedAndInvalidateInfluencedCache(17, context);
	}

	public int[] GetTaiwuInvestmentForMartialArtTournament()
	{
		return _taiwuInvestmentForMartialArtTournament;
	}

	public void SetTaiwuInvestmentForMartialArtTournament(int[] taiwuInvestmentForMartialArtTournament, DataContext context)
	{
		_taiwuInvestmentForMartialArtTournament = taiwuInvestmentForMartialArtTournament;
		SetModifiedAndInvalidateInfluencedCache(18, context);
	}

	public SectFunctionStatuses GetFunctionStatuses()
	{
		return _functionStatuses;
	}

	public void SetFunctionStatuses(SectFunctionStatuses functionStatuses, DataContext context)
	{
		_functionStatuses = functionStatuses;
		SetModifiedAndInvalidateInfluencedCache(19, context);
	}

	public override short GetApprovingRateUpperLimitTempBonus()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 20))
		{
			return ApprovingRateUpperLimitTempBonus;
		}
		short value = CalcApprovingRateUpperLimitTempBonus();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			ApprovingRateUpperLimitTempBonus = value;
			dataStates.SetCached(DataStatesOffset, 20);
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

	public int[] GetMartialArtTournamentPreparations()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 21))
		{
			return _martialArtTournamentPreparations;
		}
		int[] value = new int[3];
		CalcMartialArtTournamentPreparations(value);
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			for (int i = 0; i < 3; i++)
			{
				_martialArtTournamentPreparations[i] = value[i];
			}
			dataStates.SetCached(DataStatesOffset, 21);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _martialArtTournamentPreparations;
	}

	public Sect()
	{
		Members = new OrgMemberCollection();
		LackingCoreMembers = new OrgMemberCollection();
		_availableMonasticTitleSuffixIds = new List<short>();
		_taiwuInvestmentForMartialArtTournament = new int[3];
		_martialArtTournamentPreparations = new int[3];
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
		int totalSize = 69;
		int dataSize = Members.GetSerializedSize();
		totalSize += dataSize;
		int dataSize2 = LackingCoreMembers.GetSerializedSize();
		totalSize += dataSize2;
		int elementsCount = _availableMonasticTitleSuffixIds.Count;
		int contentSize = 2 * elementsCount;
		int dataSize3 = 2 + contentSize;
		return totalSize + dataSize3;
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
		*(short*)pCurrData = _minSeniorityId;
		pCurrData += 2;
		*pCurrData = _taiwuExploreStatus;
		pCurrData++;
		*pCurrData = (_spiritualDebtInteractionOccurred ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (_taiwuInvestmentForMartialArtTournament.Length != 3)
		{
			throw new Exception("Elements count of field _taiwuInvestmentForMartialArtTournament is not equal to declaration");
		}
		for (int i = 0; i < 3; i++)
		{
			((int*)pCurrData)[i] = _taiwuInvestmentForMartialArtTournament[i];
		}
		pCurrData += 12;
		pCurrData += _functionStatuses.Serialize(pCurrData);
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
		int elementsCount = _availableMonasticTitleSuffixIds.Count;
		int contentSize = 2 * elementsCount;
		if (contentSize > 4194300)
		{
			throw new Exception($"Size of field {"_availableMonasticTitleSuffixIds"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int j = 0; j < elementsCount; j++)
		{
			((short*)pCurrData)[j] = _availableMonasticTitleSuffixIds[j];
		}
		pCurrData += contentSize;
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
				break;
			case 1:
				OrgTemplateId = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 2:
				pCurrData += Location.Deserialize(pCurrData);
				break;
			case 3:
				Culture = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 4:
				MaxCulture = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 5:
				Safety = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 6:
				MaxSafety = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 7:
				Population = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 8:
				MaxPopulation = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 9:
				StandardOnStagePopulation = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 12:
				ApprovingRateUpperLimitBonus = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 13:
				InfluencePowerUpdateDate = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 14:
				_minSeniorityId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 16:
				_taiwuExploreStatus = *pCurrData;
				pCurrData++;
				break;
			case 17:
				_spiritualDebtInteractionOccurred = *pCurrData != 0;
				pCurrData++;
				break;
			case 18:
			{
				if (_taiwuInvestmentForMartialArtTournament.Length != 3)
				{
					throw new Exception("Elements count of field _taiwuInvestmentForMartialArtTournament is not equal to declaration");
				}
				for (int j = 0; j < 3; j++)
				{
					_taiwuInvestmentForMartialArtTournament[j] = ((int*)pCurrData)[j];
				}
				pCurrData += 12;
				break;
			}
			case 19:
				pCurrData += _functionStatuses.Deserialize(pCurrData);
				break;
			case 10:
				pCurrData += 4;
				pCurrData += Members.Deserialize(pCurrData);
				break;
			case 11:
				pCurrData += 4;
				pCurrData += LackingCoreMembers.Deserialize(pCurrData);
				break;
			case 15:
			{
				pCurrData += 4;
				ushort elementsCount = *(ushort*)pCurrData;
				pCurrData += 2;
				_availableMonasticTitleSuffixIds.Clear();
				for (int i = 0; i < elementsCount; i++)
				{
					_availableMonasticTitleSuffixIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
				break;
			}
			default:
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
				break;
			}
		}
		return (int)(pCurrData - pData);
	}
}
