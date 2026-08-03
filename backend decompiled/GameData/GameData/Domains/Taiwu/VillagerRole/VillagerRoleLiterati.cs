using System;
using System.Collections.Generic;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Filters;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleLiterati : VillagerRoleBase, IVillagerRoleContact, IVillagerRoleInfluence, IVillagerRoleArrangementExecutor, IVillagerRoleSelectLocation
{
	private static class FieldIds
	{
		public const ushort ArrangementTemplateId = 0;

		public const ushort PositiveAction = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ArrangementTemplateId", "PositiveAction" };
	}

	[SerializableGameDataField]
	public bool PositiveAction = true;

	public override short RoleTemplateId => 4;

	public bool IncreaseFavorability => PositiveAction;

	public int LearnActionRepeatChance => SharedMethods.CalculateLiteratiLearnActionRepeatChance(Character.GetPersonalities());

	public int LearnRequestSuccessChanceBonus => SharedMethods.CalculateLiteratiLearnRequestSuccessChanceBonus(Character.GetPersonalities());

	public int ContactFavorabilityChange => SharedMethods.CalculateLiteratiContactFavorabilityChange(Character.GetPersonalities(), Character.GetLifeSkillAttainments());

	public int ContactCharacterAmount => SharedMethods.CalculateLiteratiContactCharacterAmount(Character.GetPersonalities());

	public int EntertainTargetAmount => SharedMethods.CalculateLiteratiEntertainTargetAmount(Character.GetPersonalities());

	public int EntertainHappinessChange => SharedMethods.CalculateLiteratiEntertainHappinessChange(Character.GetPersonalities(), Character.GetLifeSkillAttainments());

	public int SecretInformationGainChance => SharedMethods.CalculateLiteratiSecretInformationGainChance(Character.GetPersonalities());

	internal int ActionEffectCount => VillagerRoleFormula.DefValue.LiteratiWorkUsableCount.Calculate(Character.GetPersonality(1));

	internal int ActionEffectValue => VillagerRoleFormula.DefValue.LiteratiWorkEffectiveValue.Calculate(CalcLiteratiLifeSkillMaxAttainment());

	internal int ExtraPeopleCount => VillagerRoleFormula.DefValue.LiteratiChickenInfluenceCount.Calculate(Character.GetPersonality(1));

	internal int RelationChange => VillagerRoleFormula.DefValue.LiteratiChickenRelationChange.Calculate(CalcLiteratiLifeSkillMaxAttainment());

	public int InfluenceSettlementValueChange => SharedMethods.CalculateLiteratiInfluenceSettlementValueChange(Character.GetPersonalities(), Character.GetLifeSkillAttainments());

	void IVillagerRoleArrangementExecutor.ExecuteArrangementAction(DataContext context)
	{
		int arrangementTemplateId = ArrangementTemplateId;
		int num = arrangementTemplateId;
		if (num == 11)
		{
			ApplyEntertainAction(context);
		}
	}

	private void ApplyEntertainAction(DataContext context)
	{
		Location location = Character.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		settlementIds.Clear();
		DomainManager.Map.GetAreaSettlementIds(location.AreaId, settlementIds, containsMainCity: true, containsSect: true);
		if (settlementIds.Count <= 0)
		{
			ObjectPool<List<short>>.Instance.Return(settlementIds);
			return;
		}
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		int charId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int count = ActionEffectCount;
		int value = ActionEffectValue;
		short pickedSettlementId = settlementIds[context.Random.Next(settlementIds.Count)];
		Settlement settlement = DomainManager.Organization.GetSettlement(pickedSettlementId);
		short culture = settlement.GetCulture();
		short safety = settlement.GetSafety();
		List<int> extraCharIds = ObjectPool<List<int>>.Instance.Get();
		Dictionary<int, int> favorMap = ObjectPool<Dictionary<int, int>>.Instance.Get();
		int addCount = 0;
		int minusCount = 0;
		int key;
		for (int i = 0; i < count; i++)
		{
			IRandomSource random = context.Random;
			sbyte behaviorType = Character.GetBehaviorType();
			if (1 == 0)
			{
			}
			key = behaviorType switch
			{
				0 => 75, 
				1 => 100, 
				3 => 0, 
				4 => 25, 
				_ => 50, 
			};
			if (1 == 0)
			{
			}
			int sign = (random.CheckPercentProb(key) ? 1 : (-1));
			extraCharIds.Clear();
			if (context.Random.NextBool())
			{
				settlement.ChangeSafety(context, sign * value);
			}
			else
			{
				settlement.ChangeCulture(context, sign * value);
			}
			if (base.HasChickenUpgradeEffect)
			{
				OrgMemberCollection memberCollection = settlement.GetMembers();
				if (memberCollection != null)
				{
					List<int> members = ObjectPool<List<int>>.Instance.Get();
					members.Clear();
					memberCollection.GetAllMembers(members);
					foreach (int id in members)
					{
						extraCharIds.Add(id);
					}
					ObjectPool<List<int>>.Instance.Return(members);
				}
			}
			if (extraCharIds.Count <= 0)
			{
				continue;
			}
			int peopleCount = ExtraPeopleCount;
			int num = Math.Max(RelationChange, 0);
			IRandomSource random2 = context.Random;
			sbyte behaviorType2 = Character.GetBehaviorType();
			if (1 == 0)
			{
			}
			key = behaviorType2 switch
			{
				0 => 75, 
				1 => 100, 
				3 => 0, 
				4 => 25, 
				_ => 50, 
			};
			if (1 == 0)
			{
			}
			int relationChange = num * (random2.CheckPercentProb(key) ? 1 : (-1));
			extraCharIds.Remove(DomainManager.Taiwu.GetTaiwuCharId());
			CollectionUtils.Shuffle(context.Random, extraCharIds);
			int diff = extraCharIds.Count - peopleCount;
			if (diff > 0)
			{
				extraCharIds.RemoveRange(0, diff);
			}
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			foreach (int targetId in extraCharIds)
			{
				if (DomainManager.Character.TryGetElement_Objects(targetId, out var target))
				{
					DomainManager.Character.ChangeFavorabilityOptional(context, target, taiwu, relationChange, 5);
					favorMap.TryAdd(targetId, 0);
					Dictionary<int, int> dictionary = favorMap;
					key = targetId;
					dictionary[key] += relationChange;
				}
			}
		}
		short cultureNow = settlement.GetCulture();
		short safetyNow = settlement.GetSafety();
		if (safetyNow > safety)
		{
			lifeRecordCollection.AddLiteratiSpreadingInfluenceSafetyUp(charId, currDate, pickedSettlementId);
		}
		else if (safetyNow < safety)
		{
			lifeRecordCollection.AddLiteratiSpreadingInfluenceSafetyDown(charId, currDate, pickedSettlementId);
		}
		if (cultureNow > culture)
		{
			lifeRecordCollection.AddLiteratiSpreadingInfluenceCultureUp(charId, currDate, pickedSettlementId);
		}
		else if (cultureNow < culture)
		{
			lifeRecordCollection.AddLiteratiSpreadingInfluenceCultureDown(charId, currDate, pickedSettlementId);
		}
		foreach (KeyValuePair<int, int> item in favorMap)
		{
			item.Deconstruct(out key, out var value2);
			int id2 = key;
			int delta = value2;
			if (delta < 0)
			{
				minusCount++;
				lifeRecordCollection.AddLiteratiBeConnectedRelationshipDown(id2, currDate, charId, pickedSettlementId);
			}
			else if (delta > 0)
			{
				addCount++;
				lifeRecordCollection.AddLiteratiBeConnectedRelationshipUp(id2, currDate, charId, pickedSettlementId);
			}
		}
		if (addCount > 0)
		{
			lifeRecordCollection.AddLiteratiConnectRelationshipUp(charId, currDate, pickedSettlementId, addCount);
			lifeRecordCollection.AddLiteratiConnectRelationshipUpTaiwu(taiwuId, currDate, charId, pickedSettlementId);
		}
		if (minusCount > 0)
		{
			lifeRecordCollection.AddLiteratiConnectRelationshipDown(charId, currDate, pickedSettlementId, minusCount);
			lifeRecordCollection.AddLiteratiConnectRelationshipDownTaiwu(taiwuId, currDate, charId, pickedSettlementId);
		}
		ObjectPool<List<int>>.Instance.Return(extraCharIds);
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		ObjectPool<Dictionary<int, int>>.Instance.Return(favorMap);
		CharacterDomain.AddLockMovementCharSet(charId);
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId < 0 && (WorkData == null || WorkData.WorkType != 1) && base.AutoActionStates[6])
		{
			TryAddNextAutoTravelTarget(context, AutoActionBlockFilter);
			AutoWriteAndDrawAction(context);
		}
	}

	private bool AutoActionBlockFilter(MapBlockData blockData)
	{
		MapDomain mapDomain = DomainManager.Map;
		Location location = Character.GetLocation();
		if (location.IsValid() && mapDomain.GetStateIdByAreaId(location.AreaId) == mapDomain.GetStateIdByAreaId(blockData.AreaId))
		{
			HashSet<int> characterSet = blockData.CharacterSet;
			if (characterSet != null && characterSet.Count >= 3)
			{
				return true;
			}
		}
		return false;
	}

	private void AutoWriteAndDrawAction(DataContext context)
	{
		Location location = Character.GetLocation();
		MapBlockData block = DomainManager.Map.GetBlock(location);
		int count = VillagerRoleFormula.DefValue.LiteratiAutoActionInfluenceCount.Calculate(Character.GetPersonality(1));
		ObjectPool<List<int>> listPool = ObjectPool<List<int>>.Instance;
		List<int> range = listPool.Get();
		range.Clear();
		range.AddRange(block.CharacterSet);
		range.Remove(Character.GetId());
		CollectionUtils.Shuffle(context.Random, range);
		int rangeDiff = range.Count - count;
		if (rangeDiff > 0)
		{
			range.RemoveRange(0, rangeDiff);
		}
		int delta = VillagerRoleFormula.DefValue.LiteratiAutoActionHappinessChange.Calculate(CalcLiteratiLifeSkillMaxAttainment());
		int charId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int addCount = 0;
		int minusCount = 0;
		foreach (int targetCharId in range)
		{
			GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
			IRandomSource random = context.Random;
			sbyte behaviorType = Character.GetBehaviorType();
			if (1 == 0)
			{
			}
			int percentProb = behaviorType switch
			{
				0 => 75, 
				1 => 100, 
				3 => 0, 
				4 => 25, 
				_ => 50, 
			};
			if (1 == 0)
			{
			}
			int sign = (random.CheckPercentProb(percentProb) ? 1 : (-1));
			int value = delta * sign;
			targetChar.ChangeHappiness(context, value);
			if (value > 0)
			{
				addCount++;
				lifeRecordCollection.AddLiteratiBeEntertainedUp(targetCharId, currDate, charId, location);
			}
			else if (value < 0)
			{
				minusCount++;
				lifeRecordCollection.AddLiteratiBeEntertainedDown(targetCharId, currDate, charId, location);
			}
		}
		if (addCount > 0)
		{
			lifeRecordCollection.AddLiteratiEntertainingUp(charId, currDate, location, addCount);
		}
		if (minusCount > 0)
		{
			lifeRecordCollection.AddLiteratiEntertainingDown(charId, currDate, location, minusCount);
		}
		listPool.Return(range);
		CharacterDomain.AddLockMovementCharSet(charId);
	}

	public void SelectContactTargets(IRandomSource random, List<GameData.Domains.Character.Character> selectedCharList, int selectAmount)
	{
		selectedCharList.Clear();
		Location location = Character.GetLocation();
		MapBlockData currBlock = DomainManager.Map.GetBlock(location);
		if (currBlock.BelongBlockId >= 0)
		{
			MapCharacterFilter.Find(CharacterFilter, selectedCharList, location.AreaId);
			if (selectedCharList.Count > selectAmount)
			{
				selectedCharList.RemoveRange(selectAmount, selectedCharList.Count - selectAmount);
			}
		}
		bool CharacterFilter(GameData.Domains.Character.Character character)
		{
			if (OrganizationDomain.IsLargeSect(character.GetOrganizationInfo().OrgTemplateId))
			{
				return false;
			}
			if (character == Character)
			{
				return false;
			}
			Location charLocation = character.GetLocation();
			MapBlockData block = DomainManager.Map.GetBlock(charLocation);
			if (block.IsNonDeveloped())
			{
				return false;
			}
			if (block.BelongBlockId != currBlock.BelongBlockId)
			{
				return false;
			}
			return true;
		}
	}

	void IVillagerRoleInfluence.ApplyInfluenceAction(DataContext context)
	{
		int valueChange = InfluenceSettlementValueChange;
		if (!PositiveAction)
		{
			valueChange = -valueChange;
		}
		short areaId = Character.GetLocation().AreaId;
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
		int authorityGain = 0;
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				settlement.ChangeCulture(context, valueChange);
				authorityGain += GetSettlementInfluenceAuthorityGain(settlement);
			}
		}
		DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 7, authorityGain);
	}

	public int GetSettlementInfluenceAuthorityGain(Settlement settlement)
	{
		if (settlement == null)
		{
			return 0;
		}
		int safetyValue = (PositiveAction ? settlement.GetCulture() : (settlement.GetMaxCulture() - settlement.GetCulture()));
		return safetyValue * (50 + Character.GetPersonality(1) / 2) / 100;
	}

	private static IEnumerable<sbyte> CalcLiteratiLifeSkillTypes()
	{
		yield return 0;
		yield return 1;
		yield return 2;
		yield return 3;
	}

	private int CalcLiteratiLifeSkillMaxAttainment()
	{
		LifeSkillShorts items = Character.GetLifeSkillAttainments();
		short max = short.MinValue;
		foreach (sbyte lifeSkillType in CalcLiteratiLifeSkillTypes())
		{
			if (items[lifeSkillType] > max)
			{
				max = items[lifeSkillType];
			}
		}
		return max;
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new EntertainingDisplayData
		{
			ActionEffectCount = ActionEffectCount,
			ActionEffectValue = ActionEffectValue,
			ExtraPeopleCount = ExtraPeopleCount,
			RelationChange = RelationChange
		};
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 7;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*pCurrData = (PositiveAction ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ArrangementTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			PositiveAction = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
