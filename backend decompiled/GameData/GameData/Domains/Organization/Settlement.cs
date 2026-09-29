using System;
using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using Config;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.Display;
using GameData.Domains.Organization.SettlementTreasuryRecord;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Organization;

public abstract class Settlement : BaseGameDataObject, IValueSelector
{
	[CollectionObjectField(false, true, false, true, false)]
	protected short Id;

	[CollectionObjectField(false, true, false, true, false)]
	protected sbyte OrgTemplateId;

	[CollectionObjectField(false, true, false, true, false)]
	protected Location Location;

	[CollectionObjectField(false, true, false, false, false)]
	protected short Culture;

	[CollectionObjectField(false, true, false, false, false)]
	protected short MaxCulture;

	[CollectionObjectField(false, true, false, false, false)]
	protected short Safety;

	[CollectionObjectField(false, true, false, false, false)]
	protected short MaxSafety;

	[CollectionObjectField(false, true, false, false, false)]
	protected int Population;

	[CollectionObjectField(false, true, false, false, false)]
	protected int MaxPopulation;

	[CollectionObjectField(false, true, false, false, false)]
	protected int StandardOnStagePopulation;

	[CollectionObjectField(false, true, false, false, false)]
	protected OrgMemberCollection Members;

	[CollectionObjectField(false, true, false, false, false)]
	protected OrgMemberCollection LackingCoreMembers;

	[CollectionObjectField(false, true, false, false, false)]
	protected short ApprovingRateUpperLimitBonus;

	[CollectionObjectField(false, true, false, false, false)]
	protected int InfluencePowerUpdateDate;

	[CollectionObjectField(false, false, true, false, false)]
	protected short ApprovingRateUpperLimitTempBonus;

	protected SortedList<long, int> _membersSortedByCombatPower = new SortedList<long, int>();

	private const int NewGradeRatio = 3;

	private const int OldGradeRatio = 4;

	private SettlementLayeredTreasuries _treasuries;

	private readonly Dictionary<ShortPair, List<short>> _supplyItems = new Dictionary<ShortPair, List<short>>();

	private readonly Dictionary<sbyte, List<short>> _supplyBooks = new Dictionary<sbyte, List<short>>();

	public readonly bool[] HasTriggeredAllowEntryEvent = new bool[Enum.GetValues(typeof(SettlementTreasuryLayers)).Length];

	public OrganizationItem OrganizationConfig => Config.Organization.Instance[OrgTemplateId];

	public SettlementLayeredTreasuries Treasuries
	{
		get
		{
			if (_treasuries == null)
			{
				_treasuries = (DomainManager.Extra.TryGetElement_SettlementLayeredTreasuries(Id, out var treasuries) ? treasuries : new SettlementLayeredTreasuries());
			}
			return _treasuries;
		}
	}

	[SingleValueDependency(3, new ushort[] { 9 })]
	protected short CalcApprovingRateUpperLimitTempBonus()
	{
		return DomainManager.Organization.GetMaxApprovingRateTempBonus(Id);
	}

	protected Settlement()
	{
	}

	protected Settlement(short id, Location location, sbyte orgTemplateId, IRandomSource random)
	{
		Id = id;
		OrgTemplateId = orgTemplateId;
		Location = location;
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		(short, short) tuple = CalcCultureAndSafety(orgConfig.Culture, random);
		Culture = tuple.Item1;
		MaxCulture = tuple.Item2;
		tuple = CalcCultureAndSafety(orgConfig.Safety, random);
		Safety = tuple.Item1;
		MaxSafety = tuple.Item2;
		Population = orgConfig.Population;
		MaxPopulation = orgConfig.Population;
		Members = new OrgMemberCollection();
		LackingCoreMembers = new OrgMemberCollection();
	}

	public Location GetRandomSubLocation(IRandomSource random)
	{
		short blockId = DomainManager.Map.GetRandomSettlementBlock(random, Location.AreaId, Location.BlockId);
		return new Location(Location.AreaId, blockId);
	}

	public void ChangeSafety(DataContext context, int delta)
	{
		Safety = (short)Math.Clamp(Safety + delta, 0, MaxSafety);
		SetSafety(Safety, context);
		Events.RaiseSettlementInfoChanged(context, this);
	}

	public void ChangeCulture(DataContext context, int delta)
	{
		Culture = (short)Math.Clamp(Culture + delta, 0, MaxCulture);
		SetCulture(Culture, context);
		Events.RaiseSettlementInfoChanged(context, this);
	}

	public GameData.Domains.Character.Character GetLeader()
	{
		HashSet<int> maxGradeMembers = Members.GetMembers(8);
		foreach (int charId in maxGradeMembers)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetOrganizationInfo().Principal)
			{
				return character;
			}
		}
		return null;
	}

	public int GetMaxSupportingBlockCount()
	{
		return (1 + Culture / 50 + Culture % 50 > 0) ? 1 : 0;
	}

	public sbyte GetPunishmentTypeSeverity(PunishmentTypeItem punishmentTypeCfg, bool includeDefault = false)
	{
		sbyte severity = -1;
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(Location.AreaId);
		return DomainManager.Organization.TryGetCustomizedCityPunishmentSeverity(stateTemplateId, this is Sect, punishmentTypeCfg.TemplateId, ref severity) ? severity : punishmentTypeCfg.GetSeverity(stateTemplateId, this is Sect, includeDefault);
	}

	public GameData.Domains.Character.Character GetAvailableHighMember(sbyte startHighGrade, sbyte endLowGrade, bool needAdult = true)
	{
		for (sbyte i = startHighGrade; i >= endLowGrade; i--)
		{
			HashSet<int> maxGradeMembers = Members.GetMembers(i);
			foreach (int charId in maxGradeMembers)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || (needAdult && character.GetAgeGroup() < 2) || character.IsActiveExternalRelationState(188uL) || character.GetKidnapperId() >= 0)
				{
					continue;
				}
				return character;
			}
		}
		return null;
	}

	public void SortMembersByCombatPower()
	{
		_membersSortedByCombatPower.Clear();
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> members = Members.GetMembers(grade);
			foreach (int memberCharId in members)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(memberCharId);
				int combatPower = character.GetCombatPower();
				long key = ((long)combatPower << 32) + memberCharId;
				_membersSortedByCombatPower.Add(key, memberCharId);
			}
		}
	}

	public long GetRankingInfo(int ranking)
	{
		if (_membersSortedByCombatPower.Count <= ranking)
		{
			return 0L;
		}
		int index = _membersSortedByCombatPower.Count - ranking;
		return _membersSortedByCombatPower.Keys[index];
	}

	public int GetRankingCombatPower(int ranking)
	{
		if (_membersSortedByCombatPower.Count <= ranking)
		{
			return 0;
		}
		int index = _membersSortedByCombatPower.Count - ranking;
		long key = _membersSortedByCombatPower.Keys[index];
		return (int)(key >> 32);
	}

	public int GetCharacterRanking(int charId)
	{
		int index = _membersSortedByCombatPower.IndexOfValue(charId);
		return _membersSortedByCombatPower.Count - index;
	}

	public abstract SettlementNameRelatedData GetNameRelatedData();

	public override string ToString()
	{
		return GetNameRelatedData().GetName();
	}

	public int CalcInfluencePower()
	{
		int value = 0;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			foreach (int memberCharId in gradeMembers)
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(memberCharId);
				value += settlementCharacter.GetInfluencePower();
			}
		}
		return value;
	}

	public short CalcApprovingRate()
	{
		int value = 0;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			foreach (int memberCharId in gradeMembers)
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(memberCharId);
				value += settlementCharacter.GetApprovingRate();
			}
		}
		int upperLimit = GetApprovingRateUpperLimit();
		return (short)((upperLimit >= 0) ? ((short)Math.Clamp(value, 0, upperLimit)) : 0);
	}

	public int GetApprovingRateUpperLimit()
	{
		int upperLimit = OrganizationDomain.GetApprovingRateUpperLimit() + ApprovingRateUpperLimitBonus + GetApprovingRateUpperLimitTempBonus();
		return Math.Min(upperLimit, 1000);
	}

	public short CalcApprovingRateTotal()
	{
		int value = 0;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			foreach (int memberCharId in gradeMembers)
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(memberCharId);
				value += settlementCharacter.GetApprovingRate();
			}
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	public void UpdateMemberGrades(DataContext context)
	{
		if (OrgTemplateId == 16)
		{
			return;
		}
		if (OrgTemplateId == 12)
		{
			UpdateWuxianMemberGrades(context);
			return;
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(8);
		AristocratSkillsData skillsData = professionData.GetSkillsData<AristocratSkillsData>();
		OrganizationItem orgConfig = Config.Organization.Instance[OrgTemplateId];
		List<int> potentialSuccessors = ObjectPool<List<int>>.Instance.Get();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (orgConfig.Hereditary)
		{
			HashSet<int> handled = ObjectPool<HashSet<int>>.Instance.Get();
			for (sbyte grade = 8; grade > 0; grade--)
			{
				HashSet<int> lackingMembers = LackingCoreMembers.GetMembers(grade);
				handled.Clear();
				OrganizationInfo orgInfo = new OrganizationInfo(OrgTemplateId, grade, principal: true, Id);
				OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
				HashSet<int> gradeMembers = Members.GetMembers(grade);
				int currAmount = ((orgMemberCfg.DeputySpouseDowngrade >= 0) ? GetPrincipalAmount(grade) : gradeMembers.Count);
				int requiredAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
				foreach (int charId in lackingMembers)
				{
					if (orgMemberCfg.Amount > 0 && currAmount >= requiredAmount)
					{
						handled.UnionWith(lackingMembers);
						break;
					}
					GetOrganizationMemberPotentialSuccessors(charId, orgInfo, potentialSuccessors);
					if (potentialSuccessors.Count > 0)
					{
						int successorId = skillsData.GetRecommendedCharIdInList(potentialSuccessors);
						if (successorId >= 0)
						{
							skillsData.OfflineRemoveRecommendedCharId(successorId);
							DomainManager.Extra.SetProfessionData(context, professionData);
						}
						else
						{
							successorId = potentialSuccessors.GetRandom(context.Random);
						}
						GameData.Domains.Character.Character successor = DomainManager.Character.GetElement_Objects(successorId);
						DomainManager.Organization.ChangeGrade(context, successor, grade, destPrincipal: true);
						int successorSpouseId = DomainManager.Character.GetAliveSpouse(successorId);
						if (successorSpouseId >= 0)
						{
							GameData.Domains.Character.Character spouse = DomainManager.Character.GetElement_Objects(successorSpouseId);
							DomainManager.Organization.UpdateGradeAccordingToSpouse(context, spouse, successor);
						}
						handled.Add(charId);
						if (grade == 8)
						{
							OnOrganizationLeaderChange(context, successorId, successor.GetGender());
						}
						currAmount++;
					}
				}
				lackingMembers.ExceptWith(handled);
				SetLackingCoreMembers(LackingCoreMembers, context);
			}
			ObjectPool<HashSet<int>>.Instance.Return(handled);
		}
		else
		{
			for (sbyte grade2 = 8; grade2 > 0; grade2--)
			{
				OrganizationMemberItem orgMemberCfg2 = OrganizationDomain.GetOrgMemberConfig(OrgTemplateId, grade2);
				OrganizationInfo targetOrgInfo = new OrganizationInfo(OrgTemplateId, grade2, principal: true, Id);
				HashSet<int> gradeMembers2 = Members.GetMembers(grade2);
				int currAmount2 = ((orgMemberCfg2.DeputySpouseDowngrade >= 0) ? GetPrincipalAmount(grade2) : gradeMembers2.Count);
				int requiredAmount2 = GetExpectedCoreMemberAmount(orgMemberCfg2);
				if (currAmount2 < requiredAmount2)
				{
					int upgradeAmount = requiredAmount2 - currAmount2;
					potentialSuccessors.Clear();
					for (int i = 0; i < upgradeAmount; i++)
					{
						if (potentialSuccessors.Count <= 0)
						{
							GetNonHereditaryPotentialSuccessors(targetOrgInfo, potentialSuccessors);
						}
						if (potentialSuccessors.Count <= 0)
						{
							break;
						}
						int successorId2 = skillsData.GetRecommendedCharIdInList(potentialSuccessors);
						if (successorId2 >= 0)
						{
							skillsData.OfflineRemoveRecommendedCharId(successorId2);
							DomainManager.Extra.SetProfessionData(context, professionData);
							potentialSuccessors.Remove(successorId2);
						}
						else
						{
							int index = context.Random.Next(potentialSuccessors.Count);
							successorId2 = potentialSuccessors[index];
							potentialSuccessors.RemoveAt(index);
						}
						GameData.Domains.Character.Character successor2 = DomainManager.Character.GetElement_Objects(successorId2);
						DomainManager.Organization.ChangeGrade(context, successor2, grade2, destPrincipal: true);
						int successorSpouseId2 = DomainManager.Character.GetAliveSpouse(successorId2);
						if (successorSpouseId2 >= 0)
						{
							GameData.Domains.Character.Character spouse2 = DomainManager.Character.GetElement_Objects(successorSpouseId2);
							DomainManager.Organization.UpdateGradeAccordingToSpouse(context, spouse2, successor2);
						}
						if (grade2 == 8)
						{
							OnOrganizationLeaderChange(context, successorId2, successor2.GetGender());
						}
					}
				}
			}
		}
		RecruitOrCreateLackingMembers(context);
		ObjectPool<List<int>>.Instance.Return(potentialSuccessors);
	}

	private void UpdateWuxianMemberGrades(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(8);
		AristocratSkillsData skillsData = professionData.GetSkillsData<AristocratSkillsData>();
		List<int> potentialSuccessors = ObjectPool<List<int>>.Instance.Get();
		List<int> potentialSaintesses = ObjectPool<List<int>>.Instance.Get();
		HashSet<int> handled = ObjectPool<HashSet<int>>.Instance.Get();
		potentialSuccessors.Clear();
		potentialSaintesses.Clear();
		handled.Clear();
		GetWuxianPotentialSaintessesByHereditary(potentialSaintesses);
		HashSet<int> lackingMembers = LackingCoreMembers.GetMembers(8);
		OrganizationInfo orgInfo = new OrganizationInfo(OrgTemplateId, 8, principal: true, Id);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		HashSet<int> gradeMembers = Members.GetMembers(8);
		HashSet<int> saintesses = Members.GetMembers(7);
		int expectedAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
		if (gradeMembers.Count < expectedAmount)
		{
			foreach (int charId in lackingMembers)
			{
				if (potentialSuccessors.Count <= 0)
				{
					GetWuxianLeaderPotentialSuccessors(orgInfo, potentialSaintesses, potentialSuccessors);
				}
				if (potentialSuccessors.Count <= 0)
				{
					break;
				}
				int successorId = skillsData.GetRecommendedCharIdInList(potentialSuccessors);
				if (successorId >= 0)
				{
					skillsData.OfflineRemoveRecommendedCharId(successorId);
					DomainManager.Extra.SetProfessionData(context, professionData);
					potentialSuccessors.Remove(successorId);
				}
				else
				{
					int index = context.Random.Next(potentialSuccessors.Count);
					successorId = potentialSuccessors[index];
					potentialSuccessors.RemoveAt(index);
				}
				GameData.Domains.Character.Character successor = DomainManager.Character.GetElement_Objects(successorId);
				DomainManager.Organization.ChangeGrade(context, successor, 8, destPrincipal: true);
				OnOrganizationLeaderChange(context, successorId, successor.GetGender());
				handled.Add(charId);
			}
			lackingMembers.ExceptWith(handled);
			handled.Clear();
		}
		else
		{
			lackingMembers.Clear();
		}
		orgInfo = new OrganizationInfo(OrgTemplateId, 7, principal: true, Id);
		orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		lackingMembers = LackingCoreMembers.GetMembers(7);
		gradeMembers = Members.GetMembers(7);
		expectedAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
		if (gradeMembers.Count < expectedAmount)
		{
			potentialSuccessors.Clear();
			foreach (int charId2 in lackingMembers)
			{
				if (potentialSuccessors.Count <= 0)
				{
					GetWuxianSaintessesPotentialSuccessors(orgInfo, potentialSaintesses, potentialSuccessors);
				}
				if (potentialSuccessors.Count <= 0)
				{
					break;
				}
				int successorId2 = skillsData.GetRecommendedCharIdInList(potentialSuccessors);
				if (successorId2 >= 0)
				{
					skillsData.OfflineRemoveRecommendedCharId(successorId2);
					DomainManager.Extra.SetProfessionData(context, professionData);
					potentialSuccessors.Remove(successorId2);
				}
				else
				{
					int index2 = context.Random.Next(potentialSuccessors.Count);
					successorId2 = potentialSuccessors[index2];
					potentialSuccessors.RemoveAt(index2);
				}
				potentialSaintesses.Remove(successorId2);
				GameData.Domains.Character.Character successor2 = DomainManager.Character.GetElement_Objects(successorId2);
				DomainManager.Organization.ChangeGrade(context, successor2, 7, destPrincipal: true);
				handled.Add(charId2);
			}
			lackingMembers.ExceptWith(handled);
			handled.Clear();
		}
		else
		{
			lackingMembers.Clear();
		}
		for (sbyte grade = 6; grade > 0; grade--)
		{
			lackingMembers = LackingCoreMembers.GetMembers(grade);
			orgInfo = new OrganizationInfo(OrgTemplateId, grade, principal: true, Id);
			orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
			gradeMembers = Members.GetMembers(grade);
			int currAmount = ((orgMemberCfg.DeputySpouseDowngrade >= 0) ? GetPrincipalAmount(grade) : gradeMembers.Count);
			int requiredAmount = GetExpectedCoreMemberAmount(orgMemberCfg);
			handled.Clear();
			foreach (int charId3 in lackingMembers)
			{
				if (orgMemberCfg.Amount > 0 && currAmount >= requiredAmount)
				{
					handled.UnionWith(lackingMembers);
					break;
				}
				GetOrganizationMemberPotentialSuccessors(charId3, orgInfo, potentialSuccessors);
				if (potentialSuccessors.Count > 0)
				{
					int successorId3 = skillsData.GetRecommendedCharIdInList(potentialSuccessors);
					if (successorId3 >= 0)
					{
						skillsData.OfflineRemoveRecommendedCharId(successorId3);
						DomainManager.Extra.SetProfessionData(context, professionData);
					}
					else
					{
						successorId3 = potentialSuccessors.GetRandom(context.Random);
					}
					GameData.Domains.Character.Character successor3 = DomainManager.Character.GetElement_Objects(successorId3);
					DomainManager.Organization.ChangeGrade(context, successor3, grade, destPrincipal: true);
					handled.Add(charId3);
					currAmount++;
				}
			}
			lackingMembers.ExceptWith(handled);
		}
		RecruitOrCreateLackingMembers(context);
		ObjectPool<List<int>>.Instance.Return(potentialSuccessors);
		ObjectPool<List<int>>.Instance.Return(potentialSaintesses);
		ObjectPool<HashSet<int>>.Instance.Return(handled);
		SetLackingCoreMembers(LackingCoreMembers, context);
	}

	protected virtual void RecruitOrCreateLackingMembers(DataContext context)
	{
		throw new NotImplementedException();
	}

	public int GetExpectedCoreMemberAmount(OrganizationMemberItem orgMemberCfg)
	{
		if (orgMemberCfg.RestrictPrincipalAmount)
		{
			return orgMemberCfg.Amount;
		}
		sbyte b2;
		if (Config.Organization.Instance[OrgTemplateId].IsSect)
		{
			sbyte sectMainStoryTaskStatus = DomainManager.Story.GetSectMainStoryTaskStatus(OrgTemplateId);
			if (1 == 0)
			{
			}
			sbyte b = sectMainStoryTaskStatus switch
			{
				1 => orgMemberCfg.UpAmount, 
				2 => orgMemberCfg.DownAmount, 
				_ => orgMemberCfg.Amount, 
			};
			if (1 == 0)
			{
			}
			b2 = b;
		}
		else
		{
			b2 = orgMemberCfg.Amount;
		}
		return b2 * DomainManager.World.GetWorldPopulationFactor() / 100;
	}

	public int GetExpectedCoreMemberAmount(int grade)
	{
		return GetExpectedCoreMemberAmount(OrganizationMember.Instance[Config.Organization.Instance[OrgTemplateId].Members[grade]]);
	}

	public int GetPrincipalAmount(sbyte grade)
	{
		int principalAmount = 0;
		HashSet<int> gradeMembers = Members.GetMembers(grade);
		foreach (int charId in gradeMembers)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetOrganizationInfo().Principal)
			{
				principalAmount++;
			}
		}
		return principalAmount;
	}

	private void GetWuxianPotentialSaintessesByHereditary(List<int> potentialSaintesses)
	{
		HashSet<int> clanLeaders = Members.GetMembers(5);
		foreach (int clanLeaderId in clanLeaders)
		{
			RelatedCharacters clanLeaderRelatedCharIds = DomainManager.Character.GetRelatedCharacters(clanLeaderId);
			if (clanLeaderRelatedCharIds != null)
			{
				GetSaintessCandidates(clanLeaderRelatedCharIds.BloodChildren.GetCollection(), potentialSaintesses);
				GetSaintessCandidates(clanLeaderRelatedCharIds.StepChildren.GetCollection(), potentialSaintesses);
				GetSaintessCandidates(clanLeaderRelatedCharIds.AdoptiveChildren.GetCollection(), potentialSaintesses);
			}
		}
	}

	private void GetWuxianLeaderPotentialSuccessors(OrganizationInfo orgInfo, List<int> potentialSaintesses, List<int> potentialSuccessors)
	{
		HashSet<int> saintesses = Members.GetMembers(7);
		if (saintesses.Count > 0)
		{
			GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, saintesses, potentialSuccessors);
		}
		if (potentialSuccessors.Count <= 0)
		{
			GetWuxianSaintessesPotentialSuccessors(orgInfo, potentialSaintesses, potentialSuccessors);
		}
	}

	private void GetWuxianSaintessesPotentialSuccessors(OrganizationInfo orgInfo, List<int> potentialSaintesses, List<int> potentialSuccessors)
	{
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, potentialSaintesses, potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		for (sbyte successorGrade = 4; successorGrade >= 0; successorGrade--)
		{
			HashSet<int> sourceMembers = Members.GetMembers(successorGrade);
			GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, sourceMembers, potentialSuccessors);
			if (potentialSuccessors.Count > 0)
			{
				break;
			}
		}
	}

	private void GetNonHereditaryPotentialSuccessors(OrganizationInfo orgInfo, List<int> potentialSuccessors)
	{
		OrganizationMemberItem orgMemberCfg = orgInfo.GetOrgMemberConfig();
		sbyte[] potentialSuccessorGrades = orgMemberCfg.PotentialSuccessorGrades;
		if (potentialSuccessorGrades != null && potentialSuccessorGrades.Length > 0)
		{
			sbyte[] potentialSuccessorGrades2 = orgMemberCfg.PotentialSuccessorGrades;
			foreach (sbyte successorGrade in potentialSuccessorGrades2)
			{
				HashSet<int> sourceMembers = Members.GetMembers(successorGrade);
				GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, sourceMembers, potentialSuccessors);
				if (potentialSuccessors.Count > 0)
				{
					break;
				}
			}
			return;
		}
		for (sbyte successorGrade2 = (sbyte)(orgInfo.Grade - 1); successorGrade2 >= 0; successorGrade2--)
		{
			HashSet<int> sourceMembers2 = Members.GetMembers(successorGrade2);
			GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, sourceMembers2, potentialSuccessors);
			if (potentialSuccessors.Count > 0)
			{
				break;
			}
		}
	}

	private void GetOrganizationMemberPotentialSuccessors(int charId, OrganizationInfo orgInfo, List<int> potentialSuccessors)
	{
		potentialSuccessors.Clear();
		RelatedCharacters relatedCharacters = DomainManager.Character.GetRelatedCharacters(charId);
		if (relatedCharacters == null)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.BloodChildren.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.StepChildren.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.AdoptiveChildren.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		if (relatedCharacters.HusbandsAndWives.GetCount() > 0)
		{
			foreach (int spouseId in relatedCharacters.HusbandsAndWives.GetCollection())
			{
				if (DomainManager.Character.TryGetElement_Objects(spouseId, out var spouse))
				{
					OrganizationInfo spouseOrgInfo = spouse.GetOrganizationInfo();
					if (spouseOrgInfo.OrgTemplateId != orgInfo.OrgTemplateId || spouseOrgInfo.SettlementId != orgInfo.SettlementId || spouseOrgInfo.Grade > orgInfo.Grade || (spouseOrgInfo.Grade == orgInfo.Grade && spouseOrgInfo.Principal))
					{
						break;
					}
					potentialSuccessors.Add(spouseId);
				}
			}
			if (potentialSuccessors.Count > 0)
			{
				return;
			}
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.BloodBrothersAndSisters.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.StepBrothersAndSisters.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.AdoptiveBrothersAndSisters.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.BloodParents.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count > 0)
		{
			return;
		}
		GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.StepParents.GetCollection(), potentialSuccessors);
		if (potentialSuccessors.Count <= 0)
		{
			GetOrganizationMemberPotentialSuccessorsInSet(orgInfo, relatedCharacters.AdoptiveParents.GetCollection(), potentialSuccessors);
			if (potentialSuccessors.Count <= 0)
			{
				GetNonHereditaryPotentialSuccessors(orgInfo, potentialSuccessors);
			}
		}
	}

	internal void GetOrganizationMemberPotentialSuccessorsForDisplay(int charId, OrganizationInfo orgInfo, List<int> potentialSuccessors)
	{
		OrganizationMemberItem memberConfig = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		if (memberConfig.TemplateId == 145)
		{
			List<int> potentialSaintesses = ObjectPool<List<int>>.Instance.Get();
			potentialSaintesses.Clear();
			GetWuxianPotentialSaintessesByHereditary(potentialSaintesses);
			GetWuxianLeaderPotentialSuccessors(orgInfo, potentialSaintesses, potentialSuccessors);
		}
		else if (memberConfig.TemplateId == 146)
		{
			List<int> potentialSaintesses2 = ObjectPool<List<int>>.Instance.Get();
			potentialSaintesses2.Clear();
			GetWuxianPotentialSaintessesByHereditary(potentialSaintesses2);
			GetWuxianSaintessesPotentialSuccessors(orgInfo, potentialSaintesses2, potentialSuccessors);
		}
		else
		{
			OrganizationItem item = Config.Organization.Instance.GetItem(orgInfo.OrgTemplateId);
			if (item != null && item.Hereditary)
			{
				GetOrganizationMemberPotentialSuccessors(charId, orgInfo, potentialSuccessors);
			}
			else
			{
				GetNonHereditaryPotentialSuccessors(orgInfo, potentialSuccessors);
			}
		}
	}

	private static void GetOrganizationMemberPotentialSuccessorsInSet(OrganizationInfo orgInfo, IEnumerable<int> charIds, List<int> result)
	{
		result.Clear();
		int currMaxInfluencePower = -1;
		sbyte requiredGender = OrganizationDomain.GetOrgMemberConfig(orgInfo).Gender;
		foreach (int relatedCharId in charIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(relatedCharId, out var relatedChar) || !relatedChar.IsInteractableAsIntelligentCharacter())
			{
				continue;
			}
			OrganizationInfo relatedCharOrgInfo = relatedChar.GetOrganizationInfo();
			if (orgInfo.SettlementId == relatedCharOrgInfo.SettlementId && orgInfo.Grade > relatedCharOrgInfo.Grade && relatedCharOrgInfo.Principal && (requiredGender == -1 || relatedChar.GetGender() == requiredGender))
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(relatedCharId);
				short influencePower = settlementCharacter.GetInfluencePower();
				if (influencePower > currMaxInfluencePower)
				{
					result.Clear();
					currMaxInfluencePower = influencePower;
					result.Add(relatedCharId);
				}
				else if (influencePower == currMaxInfluencePower)
				{
					result.Add(relatedCharId);
				}
			}
		}
	}

	private void GetSaintessCandidates(HashSet<int> charSet, List<int> result)
	{
		foreach (int charId in charSet)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetGender() == 0 && character.GetOrganizationInfo().Grade < 6)
			{
				RelatedCharacters relatedChars = DomainManager.Character.GetRelatedCharacters(charId);
				if (relatedChars.AdoptiveChildren.GetCount() <= 0 && relatedChars.BloodChildren.GetCount() <= 0 && relatedChars.StepChildren.GetCount() <= 0 && relatedChars.HusbandsAndWives.GetCount() <= 0 && !result.Contains(charId))
				{
					result.Add(charId);
				}
			}
		}
	}

	public bool RemoveSettlementFeatures(DataContext context, GameData.Domains.Character.Character character)
	{
		IReadOnlyList<SettlementMemberFeature> settlementMemberFeatures = DomainManager.Organization.GetSettlementMemberFeatures(Id);
		if (settlementMemberFeatures == null)
		{
			return false;
		}
		bool modified = false;
		List<short> featureIds = character.GetFeatureIds();
		foreach (SettlementMemberFeature featureInfo in settlementMemberFeatures)
		{
			int index = featureIds.IndexOf(featureInfo.FeatureId);
			if (index >= 0)
			{
				character.RemoveFeature(context, featureInfo.FeatureId);
				modified = true;
			}
		}
		return modified;
	}

	public bool AddSettlementFeatures(DataContext context, GameData.Domains.Character.Character character)
	{
		IReadOnlyList<SettlementMemberFeature> settlementMemberFeatures = DomainManager.Organization.GetSettlementMemberFeatures(Id);
		if (settlementMemberFeatures == null)
		{
			return false;
		}
		bool modified = false;
		sbyte grade = character.GetOrganizationInfo().Grade;
		foreach (SettlementMemberFeature featureInfo in settlementMemberFeatures)
		{
			if (grade >= featureInfo.MinGrade && grade <= featureInfo.MaxGrade)
			{
				modified |= character.AddFeature(context, featureInfo.FeatureId);
			}
		}
		return modified;
	}

	private void OnOrganizationLeaderChange(DataContext context, int charId, sbyte gender)
	{
		Dictionary<int, (GameData.Domains.Character.Character, short)> baseInfluencePowers = new Dictionary<int, (GameData.Domains.Character.Character, short)>();
		HashSet<int> relatedCharIds = new HashSet<int>();
		short influencePowerUpdateInterval = Config.Organization.Instance[OrgTemplateId].InfluencePowerUpdateInterval;
		if (influencePowerUpdateInterval > 0)
		{
			UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds);
			SetInfluencePowerUpdateDate(DomainManager.World.GetCurrDate() + influencePowerUpdateInterval, context);
		}
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (OrganizationDomain.IsSect(OrgTemplateId))
		{
			monthlyNotificationCollection.AddSectUpgrade(charId, Id, OrgTemplateId, 8, orgPrincipal: true, gender);
		}
		else
		{
			monthlyNotificationCollection.AddCivilianSettlementUpgrade(charId, Id, OrgTemplateId, 8, orgPrincipal: true, gender);
		}
	}

	public void UpdateInfluencePowers(DataContext context, Dictionary<int, (GameData.Domains.Character.Character character, short baseInfluencePower)> baseInfluencePowers, HashSet<int> relatedCharIds)
	{
		UpdateInfluencePowers(context, baseInfluencePowers, relatedCharIds, DomainManager.Organization.GetCurrTournamentState() == EMartialArtTournamentState.WaitTrigger);
	}

	public void UpdateInfluencePowers(DataContext context, Dictionary<int, (GameData.Domains.Character.Character character, short baseInfluencePower)> baseInfluencePowers, HashSet<int> relatedCharIds, bool updateTreasury)
	{
		OnUpdateInfluencePowers(context, baseInfluencePowers);
		short mainMorality = ((this is CivilianSettlement cs) ? cs.UpdateMainMorality(context) : Config.Organization.Instance[OrgTemplateId].MainMorality);
		sbyte mainBehaviorType = GameData.Domains.Character.BehaviorType.GetBehaviorType(mainMorality);
		int normalInfluenceFactor;
		int combatInfluenceFactor;
		int combatFactorUnit;
		if (!OrganizationDomain.IsSect(OrgTemplateId))
		{
			normalInfluenceFactor = 20;
			combatInfluenceFactor = 80;
			combatFactorUnit = 4000;
		}
		else
		{
			normalInfluenceFactor = 20;
			combatInfluenceFactor = 80;
			combatFactorUnit = 2000;
		}
		baseInfluencePowers.Clear();
		short[] gradeInfluencePowers = GlobalConfig.Instance.OrgCharBaseInfluencePowers;
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			SettlementTreasury treasury = GetTreasury(grade);
			foreach (int charId in gradeMembers)
			{
				short gradeInfluencePower = gradeInfluencePowers[grade];
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				sbyte behaviorType = GameData.Domains.Character.BehaviorType.GetBehaviorType(character.GetMorality());
				bool principal = character.GetOrganizationInfo().Principal;
				int baseInfluencePower = CalcBaseInfluencePower(gradeInfluencePower, mainBehaviorType, behaviorType, principal);
				baseInfluencePower = baseInfluencePower * treasury.CalcBonusInfluencePower(charId) / 100;
				baseInfluencePowers.Add(charId, (character, (short)((baseInfluencePower * normalInfluenceFactor + character.GetCombatPower() * combatInfluenceFactor / combatFactorUnit) / 100)));
			}
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(8);
		AristocratSkillsData skillsData = professionData.GetSkillsData<AristocratSkillsData>();
		bool skillsDataChanged = false;
		short approvingRate = CalcApprovingRate();
		foreach (KeyValuePair<int, (GameData.Domains.Character.Character, short)> entry in baseInfluencePowers)
		{
			int charId2 = entry.Key;
			(GameData.Domains.Character.Character, short) value = entry.Value;
			GameData.Domains.Character.Character character2 = value.Item1;
			short baseInfluencePower2 = value.Item2;
			SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(charId2);
			int influencePower = settlementCharacter.CalcInfluencePower(character2, baseInfluencePower2, baseInfluencePowers, relatedCharIds);
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			if (approvingRate >= 600 && DomainManager.Character.TryGetRelation(charId2, taiwuCharId, out var selfToTaiwu))
			{
				sbyte favorType = FavorabilityType.GetFavorabilityType(selfToTaiwu.Favorability);
				influencePower += influencePower * favorType * 5 / 100;
			}
			settlementCharacter.SetInfluencePower((short)Math.Clamp(influencePower, 0, 32767), context);
			skillsDataChanged = skillsData.OfflineRemoveInfluencePowerBonus(charId2) || skillsDataChanged;
		}
		if (updateTreasury)
		{
			UpdateTreasury(context);
		}
		if (skillsDataChanged)
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
	}

	private void OnUpdateInfluencePowers(DataContext context, Dictionary<int, (GameData.Domains.Character.Character character, short baseInfluencePower)> _)
	{
		if (OrganizationConfig.IsSect)
		{
			AutoUpgrade(context);
		}
	}

	private void AutoUpgrade(DataContext context)
	{
		BinaryHeap<GameData.Domains.Character.Character> heap = new BinaryHeap<GameData.Domains.Character.Character>((GameData.Domains.Character.Character y, GameData.Domains.Character.Character x) => x.GetCombatPower().CompareTo(y.GetCombatPower()), 64);
		LifeRecordCollection liferecord = DomainManager.LifeRecord.GetLifeRecordCollection();
		int date = DomainManager.World.GetCurrDate();
		int cumPerson = 0;
		int cumExpected = 0;
		foreach (OrganizationMemberItem memberCfg in OrganizationConfig.Members.Select((short x) => OrganizationMember.Instance[x]).Reverse())
		{
			if (memberCfg.UpgradeLevel <= 0)
			{
				continue;
			}
			int newGrade = memberCfg.Grade + memberCfg.UpgradeLevel;
			OrganizationMemberItem newCfg = OrganizationMember.Instance[OrganizationConfig.Members[newGrade]];
			OrgMemberCollection members = GetMembers();
			HashSet<int> oldGradePersons = members.GetMembers(memberCfg.Grade);
			int oldExpected = GetExpectedCoreMemberAmount(memberCfg.Grade);
			HashSet<int> newGradePersons = members.GetMembers(newCfg.Grade);
			cumPerson += newGradePersons.Count;
			cumExpected += GetExpectedCoreMemberAmount(newCfg.Grade);
			int target = (cumPerson + oldGradePersons.Count) * 3 * cumExpected / (3 * cumExpected + 4 * oldExpected) - cumPerson;
			if (target <= 0)
			{
				continue;
			}
			foreach (int charId in oldGradePersons)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var child) && child.GetAgeGroup() != 2 && (newCfg.Gender == -1 || newCfg.Gender == child.GetGender()))
				{
					heap.Push(child);
					if (heap.Count > target)
					{
						heap.Pop();
					}
				}
			}
			while (heap.Count > 0)
			{
				GameData.Domains.Character.Character child2 = heap.Pop();
				OrganizationInfo oldGrade = child2.GetOrganizationInfo();
				DomainManager.Organization.ChangeGrade(context, child2, newCfg.Grade, destPrincipal: true, autoCommitLifeRecord: false);
				liferecord.AddAutoChangeGrade(child2.GetId(), date, oldGrade.OrgTemplateId, oldGrade.Grade, oldGrade.Principal, child2.GetGender(), oldGrade.OrgTemplateId, newCfg.Grade, oldGrade.Principal, child2.GetGender());
				cumPerson++;
			}
		}
	}

	public void UpdateTaiwuVillagerInfluencePowers(DataContext context, Dictionary<int, (GameData.Domains.Character.Character character, short baseInfluencePower)> baseInfluencePowers, HashSet<int> relatedCharIds)
	{
		baseInfluencePowers.Clear();
		short[] gradeInfluencePowers = GlobalConfig.Instance.OrgCharBaseInfluencePowers;
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				short baseInfluencePower = gradeInfluencePowers[grade];
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				baseInfluencePowers.Add(charId, (character, (short)((baseInfluencePower * 20 + character.GetCombatPower() * 80 / 4000) / 100)));
			}
		}
		foreach (KeyValuePair<int, (GameData.Domains.Character.Character, short)> entry in baseInfluencePowers)
		{
			int charId2 = entry.Key;
			(GameData.Domains.Character.Character, short) value = entry.Value;
			GameData.Domains.Character.Character character2 = value.Item1;
			short baseInfluencePower2 = value.Item2;
			SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(charId2);
			int influencePower = settlementCharacter.CalcInfluencePower(character2, baseInfluencePower2, baseInfluencePowers, relatedCharIds);
			settlementCharacter.SetInfluencePower((short)Math.Clamp(influencePower, 0, 32767), context);
		}
		DomainManager.Taiwu.UpdateTaiwuTreasury(context);
	}

	public GameData.Domains.Character.Character CreateCoreCharacter(DataContext context, sbyte grade)
	{
		List<short> blockIds = ObjectPool<List<short>>.Instance.Get();
		blockIds.Clear();
		DomainManager.Map.GetSettlementBlocks(Location.AreaId, Location.BlockId, blockIds);
		List<short> nearbyBlockIds = ObjectPool<List<short>>.Instance.Get();
		nearbyBlockIds.Clear();
		DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(Location.AreaId, Location.BlockId, nearbyBlockIds);
		sbyte mapStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(Location.AreaId);
		SettlementMembersCreationInfo info = new SettlementMembersCreationInfo(OrgTemplateId, Id, mapStateTemplateId, Location.AreaId, blockIds, nearbyBlockIds);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(OrgTemplateId, grade);
		info.CoreMemberConfig = orgMemberCfg;
		OrganizationDomain.CreateCoreCharacter(context, info);
		GameData.Domains.Character.Character createdChar = info.CoreChar;
		info.CompleteCreatingCharacters();
		ObjectPool<List<short>>.Instance.Return(blockIds);
		ObjectPool<List<short>>.Instance.Return(nearbyBlockIds);
		return createdChar;
	}

	private static short CalcBaseInfluencePower(short gradeInfluencePower, sbyte mainBehaviorType, sbyte behaviorType, bool principal)
	{
		int num;
		switch (mainBehaviorType - behaviorType)
		{
		default:
			num = 50;
			break;
		case -1:
		case 1:
			num = 75;
			break;
		case 0:
			num = 100;
			break;
		}
		int percent = num;
		int influencePower = gradeInfluencePower * percent / 100;
		if (!principal)
		{
			influencePower /= 2;
		}
		return (short)influencePower;
	}

	private static (short currValue, short maxValue) CalcCultureAndSafety(short configValue, IRandomSource random)
	{
		int maxValue;
		if (configValue < 0)
		{
			int value = -configValue;
			maxValue = random.Next(value / 2, value + 1) * 5;
		}
		else if (configValue != 0 && random.CheckPercentProb(50))
		{
			int variation = (1 + random.Next(5)) * 5;
			maxValue = configValue + (random.CheckPercentProb(35) ? variation : (-variation));
			if (maxValue < 0)
			{
				maxValue = 0;
			}
		}
		else
		{
			maxValue = configValue;
		}
		return (currValue: (short)(maxValue / 2), maxValue: (short)maxValue);
	}

	public (int Curr, int Max) GetPopulationInfo()
	{
		short factor = WorldCreation.DefValue.WorldPopulation.InfluenceFactors[DomainManager.World.GetWorldPopulationType()];
		int curr = 0;
		int extra = 0;
		foreach (int charId in Members)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetCreatingType() == 1)
			{
				if ((character.GetDarkAshProtector() & 0xFFFFFDFFu) == 0)
				{
					curr++;
				}
				else
				{
					extra++;
				}
			}
		}
		return (Curr: curr + extra, Max: (OrganizationConfig.PopulationThreshold != -1) ? (factor * OrganizationConfig.PopulationThreshold / 100 + extra) : (-1));
	}

	public virtual void ResetLocalCache()
	{
		_treasuries = null;
	}

	public bool HasTreasury()
	{
		return OrgTemplateId != 0 && OrgTemplateId != 16 && Location.IsValid();
	}

	public SettlementTreasury GetTreasury(sbyte grade)
	{
		return Treasuries.GetTreasury(GetLayer(grade));
	}

	public int GetMemberSelfImproveSpeedFactor()
	{
		return GlobalConfig.Instance.MemberSelfImproveSpeedFactor[Treasuries.GetTreasuryResourceStatus()];
	}

	public int CalcItemContribution(ItemKey itemKey, int amount)
	{
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		SettlementTreasury treasury = GetTreasury(Treasuries, grade);
		return treasury.CalcItemContribution(itemKey, amount);
	}

	public void InitializeTreasurySupplyRequirements()
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			(sbyte min, sbyte max) groupGradeRange = Grade.GetGroupGradeRange(treasury.LayerIndex);
			sbyte minGrade = groupGradeRange.min;
			sbyte maxGrade = groupGradeRange.max;
			OrganizationItem orgConfig = Config.Organization.Instance[OrgTemplateId];
			for (sbyte grade = minGrade; grade <= maxGrade; grade++)
			{
				short memberTemplateId = orgConfig.Members[grade];
				OrganizationMemberItem memberConfig = OrganizationMember.Instance[memberTemplateId];
				foreach (PresetInventoryItem presetItem in memberConfig.Inventory)
				{
					if (CanItemBeSupplied(presetItem.Type, presetItem.TemplateId, grade, out var templateId))
					{
						ShortPair key = new ShortPair(presetItem.Type, grade);
						_supplyItems.TryAdd(key, new List<short>());
						_supplyItems[key].Add(templateId);
					}
				}
				PresetEquipmentItemWithProb[] equipment = memberConfig.Equipment;
				for (int j = 0; j < equipment.Length; j++)
				{
					PresetEquipmentItemWithProb presetItem2 = equipment[j];
					if (CanItemBeSupplied(presetItem2.Type, presetItem2.TemplateId, grade, out var templateId2))
					{
						ShortPair key2 = new ShortPair(presetItem2.Type, grade);
						_supplyItems.TryAdd(key2, new List<short>());
						_supplyItems[key2].Add(templateId2);
					}
				}
			}
		}
		foreach (PresetOrgMemberCombatSkill presetSkill in OrganizationMember.Instance[Config.Organization.Instance[OrgTemplateId].Members[8]].CombatSkills)
		{
			CombatSkillItem presetSkillCfg = Config.CombatSkill.Instance[presetSkill.SkillGroupId];
			IReadOnlyList<CombatSkillItem> group = CombatSkillDomain.GetLearnableCombatSkills(presetSkillCfg.SectId, presetSkillCfg.Type);
			foreach (CombatSkillItem config in group)
			{
				_supplyBooks.TryAdd(config.Grade, new List<short>());
				_supplyBooks[config.Grade].Add(config.BookId);
			}
		}
	}

	public void UpdateTreasuryOnAdvanceMonth(DataContext context)
	{
		if (!HasTreasury())
		{
			return;
		}
		SettlementLayeredTreasuries treasuries = Treasuries;
		treasuries.AlertTime = (byte)Math.Max(0, treasuries.AlertTime - 1);
		SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			treasury.ClearMemberUsedPresetContribution();
		}
		SettlementTreasury[] settlementTreasuries2 = treasuries.SettlementTreasuries;
		foreach (SettlementTreasury treasury2 in settlementTreasuries2)
		{
			int[] array = (from x in treasury2.GuardIds.GetCollection()
				where !DomainManager.Character.TryGetElement_Objects(x, out var element) || element.GetCreatingType() != 1
				select x).ToArray();
			foreach (int id in array)
			{
				treasury2.GuardIds.Remove(id);
			}
		}
		if (treasuries.SettlementTreasuries.Any((SettlementTreasury settlementTreasury) => settlementTreasury.GuardIds.GetCount() < GlobalConfig.Instance.TreasuryGuardCount || settlementTreasury.GuardIds.GetCollection().Any((int charId) => !Sect.CanBeGuard(charId))))
		{
			ForceUpdateTreasuryGuards(context);
		}
		Array.Fill(HasTriggeredAllowEntryEvent, value: false);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: false);
	}

	public void UpdateTreasury(DataContext context)
	{
		if (!HasTreasury())
		{
			return;
		}
		SettlementLayeredTreasuries treasuries = Treasuries;
		int currDate = DomainManager.World.GetCurrDate();
		SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
		settlementTreasuryRecordCollection.Clear();
		settlementTreasuryRecordCollection.AddClearRecord(currDate, Id);
		settlementTreasuryRecordCollection.AddSupplementResource(currDate, Id);
		settlementTreasuryRecordCollection.AddSupplementItem(currDate, Id);
		SettlementTreasuryLayers templateLayer = GetLayer(0);
		SettlementTreasury hobbyTemplate = GetTreasury(treasuries, templateLayer);
		OfflineUpdateTreasuryHobbies(context.Random, hobbyTemplate);
		int prevTotalWorth = 0;
		SettlementTreasuryLayers[] values = Enum.GetValues<SettlementTreasuryLayers>();
		foreach (SettlementTreasuryLayers layer in values)
		{
			SettlementTreasury treasury = GetTreasury(treasuries, layer);
			treasury.Contributions.Clear();
			if (layer != templateLayer)
			{
				treasury.LovingItemSubTypes.Clear();
				treasury.HatingItemSubTypes.Clear();
				treasury.LovingItemSubTypes.AddRange(hobbyTemplate.LovingItemSubTypes);
				treasury.HatingItemSubTypes.AddRange(hobbyTemplate.HatingItemSubTypes);
			}
			prevTotalWorth += OfflineClearTreasury(context, treasury);
		}
		treasuries.SupplyLevelAddOn = 0;
		treasuries.ResupplyTotalValue = OfflineResupplyTreasury(context);
		if (treasuries.ResupplyTotalValue * GlobalConfig.Instance.TreasurySupplyLevelUpPercent / 100 < prevTotalWorth)
		{
			treasuries.SupplyLevelAddOn = 1;
			treasuries.ResupplyTotalValue = OfflineResupplyTreasury(context);
		}
		OfflineUpdateTreasuryGuards(context, treasuries);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
		DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
	}

	private void OfflineUpdateTreasuryHobbies(IRandomSource random, SettlementTreasury treasury)
	{
		treasury.LovingItemSubTypes.Clear();
		treasury.HatingItemSubTypes.Clear();
		MapAreaData mapAreaData = DomainManager.Map.GetElement_Areas(Location.AreaId);
		MapAreaItem mapAreaCfg = mapAreaData.GetConfig();
		treasury.LovingItemSubTypes.AddRange(mapAreaCfg.LovingItemSubTypes);
		treasury.HatingItemSubTypes.AddRange(mapAreaCfg.HatingItemSubTypes);
		List<int> maxInfluenceCharIds = ObjectPool<List<int>>.Instance.Get();
		sbyte grade = 9;
		while (grade-- > 6)
		{
			HashSet<int> gradeMembers = Members.GetMembers(grade);
			int maxInfluencePower = int.MinValue;
			maxInfluenceCharIds.Clear();
			foreach (int charId in gradeMembers)
			{
				SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(charId);
				short influencePower = settlementCharacter.GetInfluencePower();
				if (influencePower > maxInfluencePower)
				{
					maxInfluencePower = influencePower;
					maxInfluenceCharIds.Clear();
					maxInfluenceCharIds.Add(charId);
				}
				else if (influencePower == maxInfluencePower)
				{
					maxInfluenceCharIds.Add(charId);
				}
			}
			if (maxInfluenceCharIds.Count > 0)
			{
				int maxInfluenceCharId = maxInfluenceCharIds.GetRandom(random);
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(maxInfluenceCharId);
				short lovingItemSubType = character.GetLovingItemSubType();
				short hatingItemSubType = character.GetHatingItemSubType();
				if (!treasury.LovingItemSubTypes.Contains(lovingItemSubType) && !treasury.HatingItemSubTypes.Contains(lovingItemSubType))
				{
					treasury.LovingItemSubTypes.Add(lovingItemSubType);
				}
				if (!treasury.LovingItemSubTypes.Contains(hatingItemSubType) && !treasury.HatingItemSubTypes.Contains(hatingItemSubType))
				{
					treasury.HatingItemSubTypes.Add(hatingItemSubType);
				}
			}
		}
		ObjectPool<List<int>>.Instance.Return(maxInfluenceCharIds);
	}

	private int OfflineClearTreasury(DataContext context, SettlementTreasury treasury)
	{
		int res = 0;
		for (sbyte resourceType = 0; resourceType < 7; resourceType++)
		{
			res += ResourceTypeHelper.ResourceAmountToWorth(resourceType, treasury.Resources[resourceType]);
			treasury.Resources.Set(resourceType, 0);
		}
		res += treasury.Inventory.GetTotalValue();
		foreach (ItemKey itemKey in treasury.Inventory.Items.Keys)
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		treasury.Inventory.Items.Clear();
		return res;
	}

	private int OfflineResupplyTreasury(DataContext context)
	{
		int res = 0;
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasuryLayers[] values = Enum.GetValues<SettlementTreasuryLayers>();
		foreach (SettlementTreasuryLayers layer in values)
		{
			res += OfflineResupplyTreasury(context, GetTreasury(treasuries, layer));
		}
		return res;
	}

	private int OfflineResupplyTreasury(DataContext context, SettlementTreasury treasury)
	{
		int res = 0;
		(sbyte min, sbyte max) groupGradeRange = Grade.GetGroupGradeRange(treasury.LayerIndex);
		sbyte minGrade = groupGradeRange.min;
		sbyte maxGrade = groupGradeRange.max;
		(short[] range, sbyte[] supplyCounts) supplyRangeAndCounts = GetSupplyRangeAndCounts();
		short[] range = supplyRangeAndCounts.range;
		sbyte[] supplyCounts = supplyRangeAndCounts.supplyCounts;
		int treasurySupplyRate = DomainManager.World.GetChallengeModeData().GetTreasurySupplyRate();
		for (sbyte resourceType = 0; resourceType < 7; resourceType++)
		{
			int satisfyingThreshold = GetResourceSupplyThreshold(resourceType, maxGrade) * GameData.Domains.World.SharedMethods.GetGainResourcePercent(13) / 100;
			int supplyWorth = satisfyingThreshold * context.Random.Next(range[0], range[1] + 1) / 100;
			int supplyAmount = ResourceTypeHelper.WorthToResourceAmount(resourceType, supplyWorth);
			supplyAmount = supplyAmount * treasurySupplyRate / 100;
			treasury.Resources.Add(resourceType, supplyAmount);
			res += ResourceTypeHelper.ResourceAmountToWorth(resourceType, supplyAmount);
		}
		for (sbyte grade = minGrade; grade <= maxGrade; grade++)
		{
			int supplyCount = supplyCounts[grade];
			supplyCount = ((supplyCount == 1) ? 1 : (supplyCount * treasurySupplyRate / 100));
			for (sbyte itemType = 0; itemType < 13; itemType++)
			{
				ShortPair key = new ShortPair(itemType, grade);
				if (_supplyItems.TryGetValue(key, out var templateIds) && supplyCount > 0)
				{
					for (int i = 0; i < supplyCount; i++)
					{
						short templateId = templateIds.GetRandom(context.Random);
						ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, templateId);
						treasury.Inventory.OfflineAdd(itemKey, 1);
						DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Treasury, Id);
						res += DomainManager.Item.GetValue(itemKey);
					}
				}
			}
			if (supplyCounts[grade] > 0 && _supplyBooks.TryGetValue(grade, out var books) && books.Count > 0)
			{
				for (int j = 0; j < supplyCounts[grade]; j++)
				{
					short bookId = books.GetRandom(context.Random);
					ItemKey itemKey2 = DomainManager.Item.CreateItem(context, 10, bookId);
					treasury.Inventory.OfflineAdd(itemKey2, 1);
					DomainManager.Item.SetOwner(itemKey2, ItemOwnerType.Treasury, Id);
					res += DomainManager.Item.GetValue(itemKey2);
				}
			}
		}
		return res;
	}

	public (short[] range, sbyte[] supplyCounts) GetSupplyRangeAndCounts()
	{
		int supplyLevel = GetSupplyLevel();
		int addOn = Treasuries.SupplyLevelAddOn;
		short[] range;
		sbyte[] supplyCounts;
		if (addOn > 0)
		{
			short[] rangeMax = GlobalConfig.Instance.TreasuryResourceSupplyRanges[supplyLevel];
			short[] rangeMin = GlobalConfig.Instance.TreasuryResourceSupplyRanges[supplyLevel - addOn];
			range = new short[rangeMax.Length];
			for (int i = 0; i < rangeMax.Length; i++)
			{
				range[i] = (short)(rangeMax[i] - rangeMin[i]);
			}
			sbyte[] countsMax = GlobalConfig.Instance.TreasuryItemSupplyCounts[supplyLevel];
			sbyte[] countsMin = GlobalConfig.Instance.TreasuryItemSupplyCounts[supplyLevel - addOn];
			supplyCounts = new sbyte[countsMax.Length];
			for (int j = 0; j < countsMax.Length; j++)
			{
				supplyCounts[j] = (sbyte)(countsMax[j] - countsMin[j]);
			}
		}
		else
		{
			range = GlobalConfig.Instance.TreasuryResourceSupplyRanges[supplyLevel];
			supplyCounts = GlobalConfig.Instance.TreasuryItemSupplyCounts[supplyLevel];
		}
		return (range: range, supplyCounts: supplyCounts);
	}

	public void ConfiscateItem(DataContext context, GameData.Domains.Character.Character character, List<ItemKey> itemKeys)
	{
		AdaptableLog.TagInfo(ToString(), $"Confiscating {itemKeys.Count} items from {character}.");
		Inventory inventory = character.GetInventory();
		SettlementLayeredTreasuries treasuries = Treasuries;
		foreach (ItemKey itemKey in itemKeys)
		{
			if (itemKey.IsValid())
			{
				sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
				if (!inventory.Items.TryGetValue(itemKey, out var amount))
				{
					int equipmentIndex = character.GetEquipment().IndexOf(itemKey);
					Tester.Assert(equipmentIndex >= 0);
					character.ChangeEquipment(context, (sbyte)equipmentIndex, -1, itemKey);
					amount = 1;
				}
				inventory.OfflineRemove(itemKey, amount);
				GetTreasury(treasuries, grade).Inventory.OfflineAdd(itemKey, amount);
				Events.RaiseItemRemovedFromInventory(context, character, itemKey, amount);
				DomainManager.Item.SetOwner(itemKey, ItemOwnerType.Treasury, Id);
				SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
				int currDate = DomainManager.World.GetCurrDate();
				settlementTreasuryRecordCollection.AddConfiscateItem(currDate, Id, character.GetId(), itemKey.ItemType, itemKey.TemplateId);
				DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
			}
		}
		character.SetInventory(inventory, context);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
	}

	public void ConfiscateResources(DataContext context, GameData.Domains.Character.Character character, ref ResourceInts resources)
	{
		int totalWorth = resources.GetTotalWorth();
		if (totalWorth > 0)
		{
			AdaptableLog.TagInfo(ToString(), $"Confiscating {totalWorth} worth of resources from {character}.");
			sbyte grade = character.GetOrganizationInfo().Grade;
			ref ResourceInts charResources = ref character.GetResources();
			charResources = charResources.Subtract(ref resources);
			character.SetResources(ref charResources, context);
			SettlementLayeredTreasuries treasuries = Treasuries;
			GetTreasury(treasuries, grade).Resources.Add(ref resources);
			DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
		}
	}

	public void StoreItemInTreasury(DataContext context, GameData.Domains.Character.Character character, ItemKey itemKey, int amount, sbyte layerIndex, bool isBequest)
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury treasury = ((layerIndex >= 0) ? treasuries.GetTreasury(layerIndex) : GetTreasury(treasuries, ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId)));
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		int worth = CalcItemContribution(itemKey, amount);
		item.SetOwner(ItemOwnerType.Treasury, Id);
		treasury.Inventory.OfflineAdd(itemKey, amount);
		treasury.OfflineChangeContribution(character, worth);
		if (worth > 0)
		{
			if (isTaiwu)
			{
				lifeRecordCollection.AddTaiwuStorageItemToTreasury(charId, currDate, Id, itemKey.ItemType, itemKey.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddStorageItemToTreasury(charId, currDate, Id, itemKey.ItemType, itemKey.TemplateId, worth);
			}
		}
		if (isTaiwu)
		{
			settlementTreasuryRecordCollection.AddTaiwuStorageItem(currDate, Id, charId, itemKey.ItemType, itemKey.TemplateId);
		}
		else if (isBequest)
		{
			settlementTreasuryRecordCollection.AddDonateLegacy(currDate, Id, charId, itemKey.ItemType, itemKey.TemplateId);
		}
		else
		{
			settlementTreasuryRecordCollection.AddStorageItem(currDate, Id, charId, itemKey.ItemType, itemKey.TemplateId, worth);
		}
		DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
	}

	public void TakeItemFromTreasury(DataContext context, GameData.Domains.Character.Character character, ItemKey itemKey, int amount)
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury treasury = GetTreasury(treasuries, ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId));
		if (treasury.Inventory.GetInventoryItemCount(itemKey) < amount)
		{
			treasury = treasuries.SettlementTreasuries.Where((SettlementTreasury settlementTreasury) => settlementTreasury != treasury).FirstOrDefault((SettlementTreasury settlementTreasury) => settlementTreasury.Inventory.GetInventoryItemCount(itemKey) >= amount);
			if (treasury == null)
			{
				AdaptableLog.Warning("item count is incorrect on TakeItemFromTreasury");
				return;
			}
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
		ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
		int worth = CalcItemContribution(itemKey, amount);
		if (!treasury.Inventory.Items.ContainsKey(itemKey))
		{
			SettlementTreasury[] settlementTreasuries = treasuries.SettlementTreasuries;
			foreach (SettlementTreasury t in settlementTreasuries)
			{
				if (t.Inventory.Items.ContainsKey(itemKey))
				{
					treasury = t;
				}
			}
		}
		item.RemoveOwner(ItemOwnerType.Treasury, Id);
		treasury.Inventory.OfflineRemove(itemKey, amount);
		treasury.OfflineChangeContribution(character, -worth);
		if (worth > 0)
		{
			if (isTaiwu)
			{
				lifeRecordCollection.AddTaiwuTakeItemFromTreasury(charId, currDate, Id, itemKey.ItemType, itemKey.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddTakeItemFromTreasury(charId, currDate, Id, itemKey.ItemType, itemKey.TemplateId, worth);
			}
		}
		if (isTaiwu)
		{
			settlementTreasuryRecordCollection.AddTaiwuTakeOutItem(currDate, Id, charId, itemKey.ItemType, itemKey.TemplateId);
		}
		else
		{
			settlementTreasuryRecordCollection.AddTakeOutItem(currDate, Id, charId, itemKey.ItemType, itemKey.TemplateId, worth);
		}
		DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
	}

	public void RemoveItemFromTreasury(DataContext context, ItemKey itemKey, int amount, bool deleteItem = false)
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury treasury = GetTreasury(treasuries, ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId));
		treasury.Inventory.OfflineRemove(itemKey, amount);
		DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Treasury, Id);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
		if (deleteItem)
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
	}

	public void StoreResourceInTreasury(DataContext context, GameData.Domains.Character.Character character, sbyte resourceType, int amount, sbyte layerIndex)
	{
		int worth = DomainManager.Organization.CalcResourceContribution(OrgTemplateId, resourceType, amount);
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury treasury = ((layerIndex >= 0) ? treasuries.GetTreasury(layerIndex) : GetTreasury(treasuries, character.GetOrganizationInfo().Grade));
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
		treasury.Resources.Add(resourceType, amount);
		treasury.OfflineChangeContribution(character, worth);
		if (worth > 0)
		{
			if (isTaiwu)
			{
				lifeRecordCollection.AddTaiwuStorageResourceToTreasury(charId, currDate, Id, resourceType, amount);
			}
			else
			{
				lifeRecordCollection.AddStorageResourceToTreasury(charId, currDate, Id, resourceType, amount, worth);
			}
		}
		if (isTaiwu)
		{
			settlementTreasuryRecordCollection.AddTaiwuStorageResource(currDate, Id, charId, resourceType, amount);
		}
		else
		{
			settlementTreasuryRecordCollection.AddStorageResource(currDate, Id, charId, resourceType, amount, worth);
		}
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
		DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
	}

	public void TakeResourceFromTreasury(DataContext context, GameData.Domains.Character.Character character, sbyte resourceType, int amount, sbyte layerIndex)
	{
		int worth = DomainManager.Organization.CalcResourceContribution(OrgTemplateId, resourceType, amount);
		SettlementLayeredTreasuries treasuries = Treasuries;
		SettlementTreasury treasury = ((layerIndex >= 0) ? treasuries.GetTreasury(layerIndex) : GetTreasury(treasuries, character.GetOrganizationInfo().Grade));
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		SettlementTreasuryRecordCollection settlementTreasuryRecordCollection = DomainManager.Organization.GetSettlementTreasuryRecordCollection(context, Id);
		treasury.Resources.Subtract(resourceType, amount);
		treasury.OfflineChangeContribution(character, -worth);
		if (worth > 0)
		{
			if (isTaiwu)
			{
				lifeRecordCollection.AddTaiwuTakeResourceFromTreasury(charId, currDate, Id, resourceType, amount);
			}
			else
			{
				lifeRecordCollection.AddTakeResourceFromTreasury(charId, currDate, Id, resourceType, amount, worth);
			}
		}
		if (isTaiwu)
		{
			settlementTreasuryRecordCollection.AddTaiwuTakeOutResource(currDate, Id, charId, resourceType, amount);
		}
		else
		{
			settlementTreasuryRecordCollection.AddTakeOutResource(currDate, Id, charId, resourceType, amount, worth);
		}
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: true);
		DomainManager.Organization.SetSettlementTreasuryRecordCollection(context, Id, settlementTreasuryRecordCollection);
	}

	public static bool IsGuarding(int charId, bool includeNonIntelligentCharacter = false)
	{
		GameData.Domains.Character.Character guard;
		return DomainManager.Character.TryGetElement_Objects(charId, out guard) && ((guard.GetCreatingType() == 1) ? CharacterMatcher.DefValue.InSettlement.Match(guard) : includeNonIntelligentCharacter);
	}

	public IEnumerable<int> GetPrisonerRelatedGuards(SettlementPrisoner prisoner)
	{
		return from charId in Treasuries.GetTreasury((SettlementTreasuryLayers)Math.Clamp((int)prisoner.GetPrisonType(), 0, 2)).GuardIds.GetCollection()
			where IsGuarding(charId)
			select charId;
	}

	public void RefreshGuards(DataContext context)
	{
		for (sbyte i = 0; i < 3; i++)
		{
			foreach (int _ in GetGuardsUnsorted(context, i))
			{
			}
		}
	}

	public IEnumerable<int> GetGuardsUnsorted(DataContext context, sbyte treasuryGrade)
	{
		SettlementTreasury treasury = Treasuries.GetTreasury(treasuryGrade);
		int count = 0;
		foreach (int guardId in treasury.GuardIds.GetCollection())
		{
			if (IsGuarding(guardId, includeNonIntelligentCharacter: true))
			{
				yield return guardId;
				count++;
			}
		}
		bool modified = false;
		while (count++ < GlobalConfig.Instance.TreasuryGuardCount)
		{
			modified = true;
			int charId = CreateNonIntelligentGuard(context, treasuryGrade, 0);
			treasury.GuardIds.Add(charId);
			yield return charId;
		}
		if (modified)
		{
			DomainManager.Extra.SetTreasuries(context, Id, Treasuries, needUpdateTotalValue: false);
		}
	}

	public IEnumerable<(GameData.Domains.Character.Character Character, short Favor)> GetGuardsAndFavors(DataContext context, sbyte treasuryGrade)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		return (from data in GetGuardsUnsorted(context, treasuryGrade).Select(delegate(int charId)
			{
				GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(charId);
				return (character: element_Objects, DomainManager.Character.GetFavorability(charId, taiwuCharId));
			})
			orderby (data.character.GetCreatingType() != 1, -data.character.GetCombatPower())
			select data).Take(GlobalConfig.Instance.TreasuryGuardCount);
	}

	public IEnumerable<int> GetGuards(DataContext context, sbyte treasuryGrade)
	{
		return from characterAndFavor in GetGuardsAndFavors(context, treasuryGrade)
			select characterAndFavor.Character.GetId();
	}

	public CharacterDisplayData[] GetGuardsDisplayData(DataContext context, sbyte treasuryGrade)
	{
		return GetGuardsAndFavors(context, treasuryGrade).Select(delegate((GameData.Domains.Character.Character Character, short Favor) characterAndFavor)
		{
			CharacterDisplayData characterDisplayData = DomainManager.Character.GetCharacterDisplayData(characterAndFavor.Character.GetId());
			characterDisplayData.FavorabilityToTaiwu = characterAndFavor.Favor;
			return characterDisplayData;
		}).ToArray();
	}

	public int CreateNonIntelligentGuard(DataContext context, sbyte treasuryGrade, sbyte offset = 0)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		SettlementTreasury settlementTreasury = Treasuries.GetTreasury(treasuryGrade);
		sbyte orgTemplateId = GetOrgTemplateId();
		sbyte grade = (sbyte)Math.Clamp(((this is Sect) ? GlobalConfig.Instance.SectTreasuryGuardMaxGrade[treasuryGrade] : GlobalConfig.Instance.TreasuryGuardMaxGrade[treasuryGrade]) + offset, 0, 8);
		short templateId = ((this is Sect) ? GameData.Domains.Character.Character.GetSectRandomEnemyTemplateIdByGrade(orgTemplateId, grade) : CivilianSettlement.GetTreasuryGuardTemplateId(grade));
		int charId = DomainManager.Character.CreateNonIntelligentCharacter(context, templateId);
		GameData.Domains.Character.Character guard = DomainManager.Character.GetElement_Objects(charId);
		guard.AddFeature(context, GetTreasuryGuardFeatureId(settlementTreasury.LayerIndex));
		DomainManager.Character.DirectlySetFavorabilities(context, charId, taiwuCharId, DomainManager.Character.CalcInitialFavorability(context.Random, charId, taiwuCharId), DomainManager.Character.CalcInitialFavorability(context.Random, taiwuCharId, charId));
		return charId;
	}

	public void ForceUpdateTreasuryGuards(DataContext context)
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		OfflineUpdateTreasuryGuards(context, treasuries);
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: false);
	}

	public void SetAlterTime(DataContext context, byte time)
	{
		SettlementLayeredTreasuries treasuries = Treasuries;
		Treasuries.AlertTime = time;
		DomainManager.Extra.SetTreasuries(context, Id, treasuries, needUpdateTotalValue: false);
	}

	public byte GetAlterTime(DataContext context)
	{
		return Treasuries.AlertTime;
	}

	private SettlementTreasuryLayers GetLayer(sbyte grade)
	{
		return (SettlementTreasuryLayers)Grade.GetGroup(grade);
	}

	private SettlementTreasury GetTreasury(SettlementLayeredTreasuries treasuries, sbyte grade)
	{
		return treasuries.GetTreasury(GetLayer(grade));
	}

	private SettlementTreasury GetTreasury(SettlementLayeredTreasuries treasuries, SettlementTreasuryLayers layer)
	{
		return treasuries.GetTreasury(layer);
	}

	private int GetResourceSupplyThreshold(sbyte resourceType, sbyte grade)
	{
		OrganizationMemberItem memberConfig = OrganizationDomain.GetOrgMemberConfig(OrgTemplateId, grade);
		return memberConfig.GetAdjustedResourceSatisfyingThreshold(resourceType);
	}

	private bool CanItemBeSupplied(sbyte itemType, short templateId, sbyte targetGrade, out short targetTemplateId)
	{
		targetTemplateId = templateId;
		if (!ItemTemplateHelper.CheckTemplateValid(itemType, templateId))
		{
			return false;
		}
		if (ItemTemplateHelper.GetItemSubType(itemType, targetTemplateId) == 1204)
		{
			return true;
		}
		short groupId = ItemTemplateHelper.GetGroupId(itemType, templateId);
		if (groupId < 0)
		{
			return false;
		}
		for (int i = 0; i <= 8; i++)
		{
			targetTemplateId = (short)(groupId + i);
			if (!ItemTemplateHelper.CheckTemplateValid(itemType, targetTemplateId))
			{
				return false;
			}
			if (ItemTemplateHelper.GetGrade(itemType, targetTemplateId) == targetGrade)
			{
				short targetGroupId = ItemTemplateHelper.GetGroupId(itemType, targetTemplateId);
				return targetGroupId >= 0 && targetGroupId == groupId;
			}
		}
		return false;
	}

	public Inventory GetSupplyItems()
	{
		Inventory inventory = new Inventory();
		foreach (KeyValuePair<ShortPair, List<short>> supplyItem in _supplyItems)
		{
			supplyItem.Deconstruct(out var key, out var value);
			ShortPair shortPair = key;
			List<short> list = value;
			sbyte itemType = (sbyte)shortPair.First;
			foreach (short templateId in list)
			{
				ItemKey itemKey = new ItemKey(itemType, 0, templateId, -1);
				inventory.OfflineAdd(itemKey, 1);
			}
		}
		foreach (List<short> list2 in _supplyBooks.Values)
		{
			foreach (short templateId2 in list2)
			{
				ItemKey itemKey2 = new ItemKey(10, 0, templateId2, -1);
				inventory.OfflineAdd(itemKey2, 1);
			}
		}
		return inventory;
	}

	public virtual int GetSupplyLevel()
	{
		return DomainManager.Organization.IsCreatingSettlements() ? 2 : (1 + Treasuries.SupplyLevelAddOn);
	}

	public virtual short GetTreasuryGuardFeatureId(sbyte layerIndex)
	{
		int offset = layerIndex + 1;
		return (short)(691 + offset);
	}

	protected abstract void OfflineUpdateTreasuryGuards(DataContext context, SettlementLayeredTreasuries treasuries);

	public short GetId()
	{
		return Id;
	}

	public sbyte GetOrgTemplateId()
	{
		return OrgTemplateId;
	}

	public Location GetLocation()
	{
		return Location;
	}

	public short GetCulture()
	{
		return Culture;
	}

	public abstract void SetCulture(short culture, DataContext context);

	public short GetMaxCulture()
	{
		return MaxCulture;
	}

	public abstract void SetMaxCulture(short maxCulture, DataContext context);

	public short GetSafety()
	{
		return Safety;
	}

	public abstract void SetSafety(short safety, DataContext context);

	public short GetMaxSafety()
	{
		return MaxSafety;
	}

	public abstract void SetMaxSafety(short maxSafety, DataContext context);

	public int GetPopulation()
	{
		return Population;
	}

	public abstract void SetPopulation(int population, DataContext context);

	public int GetMaxPopulation()
	{
		return MaxPopulation;
	}

	public abstract void SetMaxPopulation(int maxPopulation, DataContext context);

	public int GetStandardOnStagePopulation()
	{
		return StandardOnStagePopulation;
	}

	public abstract void SetStandardOnStagePopulation(int standardOnStagePopulation, DataContext context);

	public OrgMemberCollection GetMembers()
	{
		return Members;
	}

	public abstract void SetMembers(OrgMemberCollection members, DataContext context);

	public OrgMemberCollection GetLackingCoreMembers()
	{
		return LackingCoreMembers;
	}

	public abstract void SetLackingCoreMembers(OrgMemberCollection lackingCoreMembers, DataContext context);

	public short GetApprovingRateUpperLimitBonus()
	{
		return ApprovingRateUpperLimitBonus;
	}

	public abstract void SetApprovingRateUpperLimitBonus(short approvingRateUpperLimitBonus, DataContext context);

	public int GetInfluencePowerUpdateDate()
	{
		return InfluencePowerUpdateDate;
	}

	public abstract void SetInfluencePowerUpdateDate(int influencePowerUpdateDate, DataContext context);

	public abstract short GetApprovingRateUpperLimitTempBonus();

	public ValueInfo SelectValue(Evaluator evaluator, string identifier)
	{
		if (1 == 0)
		{
		}
		ValueInfo result = ((identifier == "MapBlock") ? evaluator.PushEvaluationResult(DomainManager.Map.GetBlock(Location)) : ((!(identifier == "ArgBox")) ? ValueInfo.Void : evaluator.PushEvaluationResult(DomainManager.Extra.GetSectMainStoryEventArgBox(OrgTemplateId))));
		if (1 == 0)
		{
		}
		return result;
	}
}
