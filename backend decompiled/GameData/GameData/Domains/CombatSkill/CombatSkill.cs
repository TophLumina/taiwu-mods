using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Config;
using Config.ConfigCells.Character;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.Taiwu;
using GameData.Domains.TaiwuEvent;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatSkill : BaseGameDataObject, ICombatSkillBridge, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 8;

		public const uint ReadingState_Offset = 8u;

		public const int ReadingState_Size = 2;

		public const uint ActivationState_Offset = 10u;

		public const int ActivationState_Size = 2;

		public const uint ForcedBreakoutStepsCount_Offset = 12u;

		public const int ForcedBreakoutStepsCount_Size = 1;

		public const uint BreakoutStepsCount_Offset = 13u;

		public const int BreakoutStepsCount_Size = 1;

		public const uint InnerRatio_Offset = 14u;

		public const int InnerRatio_Size = 1;

		public const uint ObtainedNeili_Offset = 15u;

		public const int ObtainedNeili_Size = 2;

		public const uint Revoked_Offset = 17u;

		public const int Revoked_Size = 1;

		public const uint SpecialEffectId_Offset = 18u;

		public const int SpecialEffectId_Size = 8;
	}

	[CollectionObjectField(false, true, false, true, false)]
	private CombatSkillKey _id;

	[CollectionObjectField(false, true, false, false, false)]
	private ushort _readingState;

	[CollectionObjectField(false, true, false, false, false)]
	private ushort _activationState;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _forcedBreakoutStepsCount;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _breakoutStepsCount;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _innerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private short _obtainedNeili;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _revoked;

	[CollectionObjectField(false, true, false, false, false)]
	private long _specialEffectId;

	[CollectionObjectField(false, false, true, false, false)]
	private short _power;

	[CollectionObjectField(false, false, true, false, false)]
	private short _requirementsPower;

	[CollectionObjectField(false, false, true, false, false)]
	private short _maxPower;

	[CollectionObjectField(false, false, true, false, false)]
	private short _requirementPercent;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _direction = -2;

	[CollectionObjectField(false, false, true, false, false)]
	private short _baseScore;

	[CollectionObjectField(false, false, true, false, false)]
	private int _plateAddMaxPower;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _currInnerRatio;

	[CollectionObjectField(false, false, true, false, false)]
	private HitOrAvoidInts _hitValue;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerInts _penetrations;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _costBreathAndStancePercent;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _costBreathPercent;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _costStancePercent;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _costMobilityPercent;

	[CollectionObjectField(false, false, true, false, false)]
	private HitOrAvoidInts _addHitValueOnCast;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerInts _addPenetrateResist;

	[CollectionObjectField(false, false, true, false, false)]
	private HitOrAvoidInts _addAvoidValueOnCast;

	[CollectionObjectField(false, false, true, false, false)]
	private int _fightBackPower;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerInts _bouncePower;

	private static readonly short[] BaseScoreOfGrades = new short[9] { 100, 167, 278, 463, 772, 1286, 2143, 3572, 5954 };

	public const int FixedSize = 26;

	public const int DynamicCount = 0;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

	private static readonly int[] FixedArchiveFieldSizes = new int[9] { 8, 2, 2, 1, 1, 1, 2, 1, 8 };

	public CombatSkillItem Template => Config.CombatSkill.Instance[_id.SkillTemplateId];

	private bool HasProficiency => !PlayerCastBossSkills.Ids.Contains(_id.SkillTemplateId);

	short ICombatSkillBridge.SkillTemplateId => _id.SkillTemplateId;

	OuterAndInnerInts ICombatSkillBridge.CostBreathStance => DomainManager.Combat.GetSkillCostBreathStance(_id.CharId, this);

	[ObjectCollectionDependency(7, 0, new ushort[] { 3, 12, 2, 26 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 5, 56, 17, 58 }, Scope = InfluenceScope.CombatSkillsOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 199, 291 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.CombatSkillsOfAllCharsInCombat)]
	[ObjectCollectionDependency(8, 10, new ushort[] { 3, 103, 29 }, Scope = InfluenceScope.CombatSkillsOfTheCombatChar)]
	[SingleValueCollectionDependency(8, new ushort[] { 6, 7 }, Scope = InfluenceScope.CombatSkillsAffectedByPowerChangeInCombat)]
	[SingleValueCollectionDependency(8, new ushort[] { 8 }, Scope = InfluenceScope.CombatSkillsAffectedByPowerReplaceInCombat)]
	[ObjectCollectionDependency(8, 29, new ushort[] { 6 }, Scope = InfluenceScope.CombatSkillsAffectedByCombatSkillDataInCombat)]
	[SingleValueDependency(1, new ushort[] { 26 }, Scope = InfluenceScope.All)]
	private short CalcPower()
	{
		if (DomainManager.Combat.IsInCombat() && DomainManager.Combat.TryGetElement_SkillDataDict(_id, out var combatSkillData) && combatSkillData.GetSilencing())
		{
			return 0;
		}
		if (DomainManager.Combat.IsInCombat() && DomainManager.Combat.GetAllSkillPowerReplaceInCombat().ContainsKey(_id))
		{
			return DomainManager.CombatSkill.GetElement_CombatSkills(DomainManager.Combat.GetAllSkillPowerReplaceInCombat()[_id]).GetPower();
		}
		int power = GetRequirementsPower();
		CValueModify modify = CalcBasePowerModify();
		modify += CalcEffectPowerModify();
		power *= modify;
		power = Math.Max(power, 0);
		power = DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 199, power);
		return (short)Math.Clamp(power, 10, GlobalConfig.Instance.CombatSkillMaxPower);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 10, 11 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 79, 96, 97, 98, 99 }, Scope = InfluenceScope.CombatSkillsOfTheChar)]
	private short CalcRequirementsPower()
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		short fixPower = character.GetFixCombatSkillPower();
		if (fixPower >= 0)
		{
			return fixPower;
		}
		int power = 0;
		short maxPower = GetMaxPower();
		List<(int, int, int)> requirements = GetRequirementsAndActualValues(character);
		int requirementsCount = (HasProficiency ? (requirements.Count - 1) : requirements.Count);
		int num;
		if (!HasProficiency)
		{
			num = 0;
		}
		else
		{
			num = Math.Min(requirements[requirements.Count - 1].Item3 * 100 / requirements[requirements.Count - 1].Item2, maxPower);
		}
		int proficiencyPower = num;
		if (requirementsCount > 0)
		{
			for (int i = 0; i < requirementsCount; i++)
			{
				(int, int, int) tuple = requirements[i];
				int required = tuple.Item2;
				int actual = tuple.Item3;
				int requirementPower = ((required > 0) ? Math.Min(actual * 100 / required, maxPower) : 0);
				if (requirementPower >= proficiencyPower)
				{
					power += requirementPower;
					continue;
				}
				power += proficiencyPower;
				proficiencyPower = requirementPower;
			}
			power /= requirementsCount;
		}
		else
		{
			power = 100;
		}
		return (short)Math.Clamp(power, 0, 32767);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 111, 116, 56 }, Scope = InfluenceScope.CombatSkillsOfTheChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.CombatSkillsOfAllCharsInCombat)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 200, 240 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	private short CalcMaxPower()
	{
		int maxPower = GlobalConfig.Instance.CombatSkillMaxBasePower;
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[_id.SkillTemplateId];
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		bool isGuardCombat = false;
		argBox.Get("IsGuardCombat", ref isGuardCombat);
		if (isGuardCombat && DomainManager.Combat.IsCharInCombat(_id.CharId) && character.IsTreasuryGuard())
		{
			return GlobalConfig.Instance.CombatSkillMaxPower;
		}
		maxPower += CombatSkillDomain.FiveElementIndexesSum(_id.CharId, skillConfig, NeiliType.Instance[character.GetNeiliType()].MaxPowerChange);
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			maxPower += effect.AddMaxPower;
		}
		maxPower += GetBreakoutGridCombatSkillPropertyBonus(1);
		ref LifeSkillShorts lifeSkillAttainments = ref character.GetLifeSkillAttainments();
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			maxPower += breakBonuse.CalcAddMaxPower(skillConfig.EquipType, ref lifeSkillAttainments);
		}
		maxPower += character.GetSkillBreakoutStepsMaxPower(_id.SkillTemplateId);
		CombatSkillEquipment combatSkillEquipment = character.GetCombatSkillEquipment();
		if (combatSkillEquipment.IsCombatSkillEquipped(_id.SkillTemplateId))
		{
			ArraySegmentList<short>.Enumerator enumerator3 = combatSkillEquipment.Neigong.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				short neigongId = enumerator3.Current;
				if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: _id.CharId, skillId: neigongId), out var skill))
				{
					continue;
				}
				foreach (SkillBreakPlateBonus breakBonuse2 in skill.GetBreakBonuses())
				{
					maxPower += breakBonuse2.CalcAddOtherSkillMaxPower(Template.EquipType);
				}
			}
		}
		ItemKey[] equipment = character.GetEquipment();
		for (sbyte i = 8; i <= 10; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && itemKey.ItemType == 2)
			{
				AccessoryItem accessoryItem = Config.Accessory.Instance[itemKey.TemplateId];
				maxPower += accessoryItem.CombatSkillAddMaxPower;
			}
		}
		maxPower += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 200, EDataModifyType.Add);
		return (short)Math.Clamp(maxPower, 0, GlobalConfig.Instance.CombatSkillMaxPower);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 111 }, Scope = InfluenceScope.CombatSkillsOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 202 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private short CalcRequirementPercent()
	{
		int requirementPercent = 100;
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			requirementPercent += effect.AddRequirement;
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			requirementPercent += breakBonuse.CalcReduceRequirements(Template.EquipType);
		}
		requirementPercent += (short)DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 202, EDataModifyType.Add);
		requirementPercent += GetBreakoutGridCombatSkillPropertyBonus(48);
		if (DomainManager.Extra.IsCombatSkillMasteredByCharacter(_id.CharId, _id.SkillTemplateId))
		{
			CombatSkillItem template = Config.CombatSkill.Instance[_id.SkillTemplateId];
			if (template.GridCost == 2)
			{
				requirementPercent += 150;
			}
			else if (template.GridCost == 3)
			{
				requirementPercent += 100;
			}
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[_id.SkillTemplateId];
		(int, int) total = CombatSkillDomain.FiveElementIndexesTotal(_id.CharId, skillConfig, NeiliType.Instance[character.GetNeiliType()].RequirementChange);
		requirementPercent *= (CValuePercentBonus)(total.Item1 + total.Item2);
		return (short)Math.Max(requirementPercent, 10);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 209 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	private sbyte CalcDirection()
	{
		sbyte direction = CombatSkillStateHelper.GetCombatSkillDirection(_activationState);
		if (DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 210, dataValue: true))
		{
			direction = (sbyte)DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 209, direction);
		}
		if (_direction == direction)
		{
			return direction;
		}
		if (_direction == -2)
		{
			bool flag = (uint)direction <= 1u;
			bool needEffect = flag;
			bool hasEffect = _specialEffectId >= 0;
			if (hasEffect == needEffect)
			{
				return direction;
			}
		}
		CombatSkillItem configData = Config.CombatSkill.Instance[_id.SkillTemplateId];
		int effectId = ((direction == 0) ? configData.DirectEffectID : configData.ReverseEffectID);
		if (Config.SpecialEffect.Instance[effectId].EffectActiveType != 3)
		{
			return direction;
		}
		if (_id.CharId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DataContext context = DataContextManager.GetCurrentThreadDataContext();
			if (_specialEffectId >= 0)
			{
				DomainManager.SpecialEffect.Remove(context, _specialEffectId);
			}
			if (direction >= 0)
			{
				DomainManager.SpecialEffect.Add(context, _id.CharId, _id.SkillTemplateId, 3, direction);
			}
		}
		else
		{
			DomainManager.SpecialEffect.AddBrokenEffectChangedDuringAdvance(_specialEffectId, _id.CharId, _id.SkillTemplateId);
		}
		return direction;
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9, 2 }, Scope = InfluenceScope.Self)]
	private short CalcBaseScore()
	{
		sbyte grade = Config.CombatSkill.Instance[_id.SkillTemplateId].Grade;
		int value = BaseScoreOfGrades[grade] * GetPower() / 100;
		if (CombatSkillStateHelper.IsBrokenOut(_activationState))
		{
			value = value * 3 / 2;
		}
		return (short)value;
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 5 }, Condition = InfluenceCondition.CombatSkillIsProactive, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 91 }, Scope = InfluenceScope.CombatSkillsOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 203 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private sbyte CalcCurrInnerRatio()
	{
		int baseRatio = GetBaseInnerRatio();
		int charInnerRatio = DomainManager.Character.GetElement_Objects(_id.CharId).GetInnerRatio();
		int changeRange = GetInnerRatioChangeRange() * charInnerRatio / 100;
		int min = Math.Max(baseRatio - changeRange, 0);
		int max = Math.Min(baseRatio + changeRange, 100);
		int currInnerRatio = Math.Clamp(GetInnerRatio(), min, max);
		currInnerRatio += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 203, EDataModifyType.Add);
		currInnerRatio = Math.Clamp(currInnerRatio, 0, 100);
		return (sbyte)currInnerRatio;
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 224 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private unsafe HitOrAvoidInts CalcHitValue()
	{
		bool isMindHit = CombatSkillEquipType.IsMindHitSkill(_id.SkillTemplateId);
		CValuePercent power = GetPower();
		CValuePercent totalHit = GetTotalHit();
		HitOrAvoidInts hitValue = default(HitOrAvoidInts);
		HitOrAvoidInts hitDistribution = GetHitDistribution();
		for (int i = 0; i < 3; i++)
		{
			hitValue.Items[i] = ((!isMindHit) ? (hitDistribution.Items[i] * totalHit * power) : 0);
		}
		hitValue.Items[3] = (isMindHit ? ((int)totalHit * power) : 0);
		return hitValue;
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9, 14, 2 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private OuterAndInnerInts CalcPenetrations()
	{
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[_id.SkillTemplateId];
		int totalPenetrate = skillConfig.Penetrate;
		totalPenetrate += GetBreakoutGridCombatSkillPropertyBonus(72);
		CValuePercentBonus bonus = GetBreakoutGridCombatSkillPropertyBonus(29);
		CValuePercent power = GetPower();
		totalPenetrate = totalPenetrate * bonus * power;
		OuterAndInnerInts penetrations = default(OuterAndInnerInts);
		penetrations.Inner = totalPenetrate * GetCurrInnerRatio() / 100;
		penetrations.Outer = totalPenetrate - penetrations.Inner;
		return penetrations;
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private sbyte CalcCostBreathAndStancePercent()
	{
		int totalCost = Config.CombatSkill.Instance[_id.SkillTemplateId].BreathStanceTotalCost;
		totalCost += GetBreakoutGridCombatSkillPropertyBonus(3);
		CValuePercentBonus bonus = 0;
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			bonus += (CValuePercentBonus)effect.CostBreathAndStance;
		}
		totalCost *= bonus;
		return (sbyte)Math.Clamp(totalCost, 0, 100);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 17, 14 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 205, 204 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	private sbyte CalcCostBreathPercent()
	{
		sbyte costBreathAndStancePercent = GetCostBreathAndStancePercent();
		int costBreath = costBreathAndStancePercent * GetCurrInnerRatio() / 100;
		int percent = 100 + DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 205, EDataModifyType.AddPercent);
		percent += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 204, EDataModifyType.AddPercent);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		ref LifeSkillShorts lifeSkillAttainments = ref character.GetLifeSkillAttainments();
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			percent -= breakBonuse.CalcReduceCostBreath(Template.EquipType, ref lifeSkillAttainments);
		}
		costBreath = costBreath * percent / 100;
		(int, int) totalPercent = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id.CharId, _id.SkillTemplateId, 205);
		(int, int) totalPercentAll = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id.CharId, _id.SkillTemplateId, 204);
		totalPercent.Item1 = Math.Max(totalPercent.Item1, totalPercentAll.Item1);
		totalPercent.Item2 = Math.Min(totalPercent.Item2, totalPercentAll.Item2);
		percent = Math.Max(100 + totalPercent.Item1 + totalPercent.Item2, 0);
		costBreath = costBreath * percent / 100;
		costBreath = DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 205, costBreath);
		return (sbyte)Math.Clamp(costBreath, 0, 100);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 17, 14 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 206, 204 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	private sbyte CalcCostStancePercent()
	{
		sbyte costBreathAndStancePercent = GetCostBreathAndStancePercent();
		int costStance = costBreathAndStancePercent - costBreathAndStancePercent * GetCurrInnerRatio() / 100;
		int percent = 100 + DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 206, EDataModifyType.AddPercent);
		percent += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 204, EDataModifyType.AddPercent);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		ref LifeSkillShorts lifeSkillAttainments = ref character.GetLifeSkillAttainments();
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			percent -= breakBonuse.CalcReduceCostStance(Template.EquipType, ref lifeSkillAttainments);
		}
		costStance = costStance * percent / 100;
		(int, int) totalPercent = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id.CharId, _id.SkillTemplateId, 206);
		(int, int) totalPercentAll = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id.CharId, _id.SkillTemplateId, 204);
		totalPercent.Item1 = Math.Max(totalPercent.Item1, totalPercentAll.Item1);
		totalPercent.Item2 = Math.Min(totalPercent.Item2, totalPercentAll.Item2);
		percent = Math.Max(100 + totalPercent.Item1 + totalPercent.Item2, 0);
		costStance = costStance * percent / 100;
		costStance = DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 206, costStance);
		return (sbyte)Math.Clamp(costStance, 0, 100);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 207 }, Scope = InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private sbyte CalcCostMobilityPercent()
	{
		int costMobility = Config.CombatSkill.Instance[_id.SkillTemplateId].MobilityCost;
		costMobility = Math.Max(costMobility + GetBreakoutGridCombatSkillPropertyBonus(10), 0);
		int bonus = 0;
		if (Template.EquipType == 2)
		{
			foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
			{
				bonus += breakBonuse.CalcCostMobilityByCast();
			}
		}
		costMobility = DomainManager.SpecialEffect.ModifyValueCustom(_id.CharId, _id.SkillTemplateId, 207, costMobility, -1, -1, -1, 0, bonus);
		return (sbyte)Math.Clamp(costMobility, 0, 100);
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9, 2 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private HitOrAvoidInts CalcAddHitValueOnCast()
	{
		return CombatSkillDomain.CalcAddHitValueOnCast(this, GetPower());
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9 }, Scope = InfluenceScope.Self)]
	private OuterAndInnerInts CalcAddPenetrateResist()
	{
		return CombatSkillDomain.CalcAddPenetrateResist(this, GetPower());
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private HitOrAvoidInts CalcAddAvoidValueOnCast()
	{
		return CombatSkillDomain.CalcAddAvoidValueOnCast(this, GetPower());
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9, 2 }, Scope = InfluenceScope.Self)]
	private int CalcFightBackPower()
	{
		return CombatSkillDomain.CalcFightBackPower(this, GetPower());
	}

	[ObjectCollectionDependency(7, 0, new ushort[] { 9 }, Scope = InfluenceScope.Self)]
	private OuterAndInnerInts CalcBouncePower()
	{
		return CombatSkillDomain.CalcBouncePower(this, GetPower());
	}

	[SingleValueCollectionDependency(5, new ushort[] { 114 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 93 }, Scope = InfluenceScope.CombatSkillsOfTaiwuChar)]
	private int CalcPlateAddMaxPower()
	{
		if (DomainManager.Taiwu.GetCombatSkillLuohanId(_id.SkillTemplateId) >= 0)
		{
			return GameData.Domains.Taiwu.SharedMethods.GetLuohanBreakMaxPower(_id.SkillTemplateId, DomainManager.Taiwu.GetTaiwu().GetCombatSkillQualifications());
		}
		if (DomainManager.Taiwu.TryGetElement_CombatSkillBreakPlates(_id.SkillTemplateId, out var plate))
		{
			return plate.AddMaxPower;
		}
		return 0;
	}

	private CValueModify CalcBasePowerModify()
	{
		int add = 0;
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			add += effect.AddPower;
		}
		add += GetBreakoutGridCombatSkillPropertyBonus(0);
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			add += breakBonuse.CalcAddPower(Template.EquipType);
		}
		foreach (short featureId in character.GetValidFeatureIds())
		{
			CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId];
			add += featureCfg.CombatSkillPowerBonuses[Template.EquipType];
			List<FeatureAddSkillPower> combatSkillTypePowerBonuses = featureCfg.CombatSkillTypePowerBonuses;
			if (combatSkillTypePowerBonuses != null && combatSkillTypePowerBonuses.Count > 0)
			{
				add += featureCfg.CombatSkillTypePowerBonuses.Where((FeatureAddSkillPower bonus) => bonus.CombatSkillType == Template.Type).Sum((FeatureAddSkillPower bonus) => bonus.AddValue);
			}
			foreach (int fiveElement in CombatSkillDomain.FiveElementIndexes(_id.CharId, Template))
			{
				if (fiveElement != 5)
				{
					add += featureCfg.FiveElementPowerBonuses[fiveElement];
				}
			}
		}
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 8; i <= 10; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && itemKey.ItemType == 2)
			{
				AccessoryItem accessoryItem = Config.Accessory.Instance[itemKey.TemplateId];
				if (accessoryItem.BonusCombatSkillSect == Template.SectId)
				{
					add += GlobalConfig.Instance.SectAccessoryBonusCombatSkillPower;
				}
			}
		}
		int addPercent = _id.GetNeiliAllocationPowerAddPercent();
		if (DomainManager.Combat.IsInCombat() && Template.Type == 2)
		{
			short templateId = DomainManager.Combat.CombatConfig.TemplateId;
			if ((uint)(templateId - 159) <= 1u)
			{
				addPercent += 200;
			}
		}
		CValueModify result = new CValueModify(add, addPercent);
		return result + character.CalcMysteryBonusCombatSkillPower(Template.EquipType);
	}

	private CValueModify CalcEffectPowerModify()
	{
		CValueModify effectAdd = DomainManager.SpecialEffect.GetModify(_id.CharId, _id.SkillTemplateId, 199, -1, -1, -1, EDataSumType.OnlyAdd);
		CValueModify effectReduce = DomainManager.SpecialEffect.GetModify(_id.CharId, _id.SkillTemplateId, 199, -1, -1, -1, EDataSumType.OnlyReduce);
		if (!DomainManager.Combat.IsInCombat())
		{
			return CalcFinalModify();
		}
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(_id.CharId, out var combatChar))
		{
			effectAdd += combatChar.CalcAddPowerUntilCast(_id.SkillTemplateId);
			ETeammateCommandImplement implement = combatChar.ExecutingTeammateCommandImplement;
			if ((implement == ETeammateCommandImplement.Defend || implement == ETeammateCommandImplement.AttackSkill) ? true : false)
			{
				CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(combatChar.IsAlly);
				CValuePercentBonus teammateBonus = DomainManager.SpecialEffect.GetModifyValue(mainChar.GetId(), 184, EDataModifyType.Add, (int)implement);
				effectAdd = effectAdd.ChangeA(combatChar.ExecutingTeammateCommandConfig.IntArg * teammateBonus);
			}
		}
		if (DomainManager.Combat.TryGetElement_SkillPowerAddInCombat(_id, out var powerChangeCollection))
		{
			effectAdd = effectAdd.ChangeA(powerChangeCollection.GetTotalChangeValue());
		}
		if (DomainManager.Combat.TryGetElement_SkillPowerReduceInCombat(_id, out powerChangeCollection))
		{
			effectReduce = effectReduce.ChangeA(powerChangeCollection.GetTotalChangeValue());
		}
		return CalcFinalModify();
		CValueModify CalcFinalModify()
		{
			effectAdd = effectAdd.ChangeA(DomainManager.SpecialEffect.GetModify(_id.CharId, _id.SkillTemplateId, 256));
			effectReduce = effectReduce.ChangeA(DomainManager.SpecialEffect.GetModify(_id.CharId, _id.SkillTemplateId, 257));
			EDataReverseType reverseType = CalcPowerEffectReverseType();
			bool canReduce = DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 201, dataValue: true);
			CValueModify finalModify = effectAdd * reverseType;
			if (canReduce)
			{
				finalModify += effectReduce * reverseType;
			}
			return finalModify;
		}
	}

	private EDataReverseType CalcPowerEffectReverseType()
	{
		int effectReverseStatus = DomainManager.SpecialEffect.ModifyValue(_id.CharId, _id.SkillTemplateId, 291, 0);
		if (1 == 0)
		{
		}
		EDataReverseType result = ((effectReverseStatus < 0) ? EDataReverseType.AddToReduce : ((effectReverseStatus > 0) ? EDataReverseType.ReduceToAdd : EDataReverseType.None));
		if (1 == 0)
		{
		}
		return result;
	}

	public int GetCharPropertyBonus(ECharacterPropertyReferencedType propertyType)
	{
		short propertyId = (short)propertyType;
		int bonus = 0;
		bool isTaiwu = _id.CharId == DomainManager.Taiwu.GetTaiwuCharId();
		if (CombatSkillDomain.EquipAddPropertyDict[_id.SkillTemplateId] != null)
		{
			int value = CombatSkillDomain.EquipAddPropertyDict[_id.SkillTemplateId][propertyId];
			ApplyBonus(value);
		}
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			int mappingValue = effect.GetMapping(propertyType);
			int value2 = CalcPageEffectValue(mappingValue);
			ApplyBonus(value2);
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			int value3 = breakBonuse.CalcEquipAddProperty(Template.EquipType, propertyType);
			ApplyBonus(value3);
		}
		GameData.Domains.Character.Character charObj;
		if (isTaiwu && DomainManager.Story.TryGetEmeiExtraBonusCollection(_id.SkillTemplateId, out var extraBonusCollection))
		{
			ApplyBonusCollection(extraBonusCollection);
		}
		else if (!isTaiwu && DomainManager.Character.TryGetElement_Objects(_id.CharId, out charObj) && charObj.IsGearMate)
		{
			GearMate gearMate = DomainManager.Extra.GetGearMateById(_id.CharId);
			if (gearMate.SectEmeiSkillBreakBonus != null && gearMate.SectEmeiSkillBreakBonus.TryGetValue(_id.SkillTemplateId, out var gearMateBonusCollection))
			{
				ApplyBonusCollection(gearMateBonusCollection);
			}
		}
		return bonus;
		void ApplyBonus(int bonusValue)
		{
			bonus += CalcCharacterPropertyBonus(propertyId, bonusValue);
		}
		void ApplyBonusCollection(SkillBreakBonusCollection bonusCollection)
		{
			if (bonusCollection != null && bonusCollection.CharacterPropertyBonusDict.TryGetValue(propertyId, out var breakBonus))
			{
				ApplyBonus(breakBonus);
			}
		}
	}

	public int GetBreakoutGridCombatSkillPropertyBonus(short propertyId)
	{
		int bonus = 0;
		bool isTaiwu = _id.CharId == DomainManager.Taiwu.GetTaiwuCharId();
		GameData.Domains.Character.Character charObj;
		if (isTaiwu && DomainManager.Story.TryGetEmeiExtraBonusCollection(_id.SkillTemplateId, out var extraBonusCollection))
		{
			ApplyBonusCollection(extraBonusCollection);
		}
		else if (!isTaiwu && DomainManager.Character.TryGetElement_Objects(_id.CharId, out charObj) && charObj.IsGearMate)
		{
			GearMate gearMate = DomainManager.Extra.GetGearMateById(_id.CharId);
			if (gearMate.SectEmeiSkillBreakBonus != null && gearMate.SectEmeiSkillBreakBonus.TryGetValue(_id.SkillTemplateId, out var gearMateBonusCollection))
			{
				ApplyBonusCollection(gearMateBonusCollection);
			}
		}
		return bonus;
		void ApplyBonusCollection(SkillBreakBonusCollection bonusCollection)
		{
			if (bonusCollection != null && bonusCollection.CombatSkillPropertyBonusDict.TryGetValue(propertyId, out var breakBonus))
			{
				bonus += breakBonus;
			}
		}
	}

	private int CalcPageEffectValue(int mappingValue)
	{
		return mappingValue * Template.GridCost;
	}

	private int CalcCharacterPropertyBonus(int propertyId, int bonus)
	{
		CharacterPropertyReferencedItem propertyConfig = CharacterPropertyReferenced.Instance[propertyId];
		return CalcCharacterPropertyBonus(propertyId, bonus, propertyConfig.BoostedByPower ? GetPower() : 0);
	}

	private int CalcCharacterPropertyBonus(int propertyId, int bonus, CValuePercent power)
	{
		CharacterPropertyReferencedItem propertyConfig = CharacterPropertyReferenced.Instance[propertyId];
		return (propertyConfig.BoostedByPower && bonus > 0) ? (bonus * power) : bonus;
	}

	public int CalcNeiliAllocationBonus(ECharacterPropertyReferencedType propertyType, int stepCount)
	{
		return CalcNeiliAllocationBonus(propertyType, stepCount, GetPower());
	}

	private int CalcNeiliAllocationBonus(ECharacterPropertyReferencedType propertyType, int stepCount, int power)
	{
		int valuePerStep = Config.CombatSkill.Instance[_id.SkillTemplateId].GetMapping(propertyType);
		if (valuePerStep <= 0)
		{
			return 0;
		}
		int percent = GlobalConfig.Instance.CombatSkillNeiliAllocationBonusPercent;
		return valuePerStep * stepCount * power * percent / 10000;
	}

	public List<(short, short, bool)> GetBreakAddPropertyList(CValuePercent power)
	{
		List<(short, short, bool)> addPropertyList = new List<(short, short, bool)>();
		Dictionary<int, int> propertyIdValues = ObjectPool<Dictionary<int, int>>.Instance.Get();
		List<int> extraPropertyIds = ObjectPool<List<int>>.Instance.Get();
		propertyIdValues.Clear();
		extraPropertyIds.Clear();
		foreach (ECharacterPropertyReferencedType bonusType in GameData.Domains.Character.Character.BonusAndPoisonResistPropertyTypes)
		{
			int bonusId = (int)bonusType;
			foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
			{
				int mappingValue = effect.GetMapping(bonusType);
				if (mappingValue != 0)
				{
					int value = CalcPageEffectValue(mappingValue);
					if (value != 0)
					{
						AddProperty(bonusId, CalcCharacterPropertyBonus(bonusId, value, power));
					}
				}
			}
			foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
			{
				int value2 = breakBonuse.CalcEquipAddProperty(Template.EquipType, bonusType);
				if (value2 != 0)
				{
					AddProperty(bonusId, CalcCharacterPropertyBonus(bonusId, value2, power));
				}
			}
		}
		SkillBreakBonusCollection extraCollection = null;
		GameData.Domains.Character.Character charObj;
		if (_id.CharId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			extraCollection = DomainManager.Story.GetEmeiBreakBonusCollection(_id.SkillTemplateId);
		}
		else if (DomainManager.Character.TryGetElement_Objects(_id.CharId, out charObj) && charObj.IsGearMate)
		{
			GearMate gearMate = DomainManager.Extra.GetGearMateById(_id.CharId);
			gearMate.SectEmeiSkillBreakBonus?.TryGetValue(_id.SkillTemplateId, out extraCollection);
		}
		if (extraCollection != null)
		{
			foreach (KeyValuePair<short, short> bonus in extraCollection.CharacterPropertyBonusDict)
			{
				AddProperty(bonus.Key, CalcCharacterBonus(bonus));
				extraPropertyIds.Add(bonus.Key);
			}
			foreach (KeyValuePair<short, short> bonus2 in extraCollection.CombatSkillPropertyBonusDict)
			{
				int key = CharacterPropertyReferenced.Instance.Count + bonus2.Key;
				AddProperty(key, bonus2.Value);
				extraPropertyIds.Add(key);
			}
		}
		foreach (KeyValuePair<int, int> propertyIdValue in propertyIdValues)
		{
			addPropertyList.Add(((short)propertyIdValue.Key, (short)propertyIdValue.Value, extraPropertyIds.Contains(propertyIdValue.Key)));
		}
		ObjectPool<Dictionary<int, int>>.Instance.Return(propertyIdValues);
		ObjectPool<List<int>>.Instance.Return(extraPropertyIds);
		return addPropertyList;
		void AddProperty(int propertyId, int num)
		{
			propertyIdValues[propertyId] = propertyIdValues.GetOrDefault(propertyId) + num;
		}
		int CalcCharacterBonus(KeyValuePair<short, short> keyValuePair)
		{
			return CalcCharacterPropertyBonus(keyValuePair.Key, keyValuePair.Value, power);
		}
	}

	public List<(short, int)> GetNeiliAllocationPropertyList(int power)
	{
		CombatSkillItem config = Config.CombatSkill.Instance[_id.SkillTemplateId];
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetElement_Objects(_id.CharId, out character) ? config.CalcNeiliAllocationBonus(power, character.CalcNeiliAllocationStepCount) : config.CalcDefaultNeiliAllocationBonus();
	}

	public List<(int type, int required, int actual)> GetRequirementsAndActualValues(GameData.Domains.Character.Character character, bool skillExist = true)
	{
		if (PlayerCastBossSkills.Ids.Contains(_id.SkillTemplateId) && _id.CharId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return new List<(int, int, int)>();
		}
		CombatSkillItem config = Config.CombatSkill.Instance[_id.SkillTemplateId];
		List<PropertyAndValue> requirements = config.UsingRequirement;
		CValuePercent requirementPercent = (skillExist ? GetRequirementPercent() : 100);
		List<(int, int, int)> result = new List<(int, int, int)>();
		CValuePercent teammatePercent = GlobalConfig.Instance.TreasuryGuardAttainmentPercent;
		int addLifeSkillAttainment = 0;
		if (character != null && skillExist)
		{
			sbyte equipType = config.EquipType;
			ref LifeSkillShorts lifeSkillAttainments = ref character.GetLifeSkillAttainments();
			foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
			{
				addLifeSkillAttainment += breakBonuse.CalcAddLifeSkillRequirement(equipType, ref lifeSkillAttainments);
			}
		}
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		bool isGuardCombat = false;
		argBox.Get("IsGuardCombat", ref isGuardCombat);
		for (int i = 0; i < requirements.Count; i++)
		{
			PropertyAndValue requirement = requirements[i];
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)requirement.PropertyId;
			int value = character?.GetPropertyValue(propertyType) ?? 0;
			if (propertyType.IsLifeSkillTypeAttainment())
			{
				value += addLifeSkillAttainment;
			}
			if (isGuardCombat && character != null && character.IsTreasuryGuard())
			{
				foreach (CombatCharacter teammateCharacter in DomainManager.Combat.GetTeammateCharacters(character.GetId()))
				{
					value += teammateCharacter.GetCharacter().GetPropertyValue(propertyType) * teammatePercent;
				}
			}
			result.Add((requirement.PropertyId, requirement.Value * requirementPercent, value));
		}
		if (!HasProficiency)
		{
			return result;
		}
		int v;
		int proficiency = (DomainManager.Extra.TryGetElement_CombatSkillProficiencies(_id, out v) ? v : 0);
		result.Add((110, 300 * requirementPercent, proficiency));
		return result;
	}

	public bool CanBreakout()
	{
		return CombatSkillStateHelper.HasReadOutlinePages(_readingState) && CombatSkillStateHelper.IsReadNormalPagesMeetConditionOfBreakout(_readingState) && !_revoked;
	}

	public void ObtainNeili(DataContext context, short obtainedNeili)
	{
		short oriObtainedNeili = _obtainedNeili;
		short totalObtainableNeili = GetTotalObtainableNeili();
		if (_obtainedNeili < totalObtainableNeili)
		{
			_obtainedNeili += obtainedNeili;
			if (_obtainedNeili > totalObtainableNeili)
			{
				_obtainedNeili = totalObtainableNeili;
			}
			if (_obtainedNeili != oriObtainedNeili)
			{
				SetObtainedNeili(_obtainedNeili, context);
			}
		}
	}

	public sbyte GetBaseInnerRatio()
	{
		sbyte baseInnerRatio = Config.CombatSkill.Instance[_id.SkillTemplateId].BaseInnerRatio;
		return (sbyte)Math.Clamp(baseInnerRatio + GetBreakoutGridCombatSkillPropertyBonus(4), 0, 100);
	}

	public sbyte GetInnerRatioChangeRange()
	{
		int innerRatioChangeRange = Config.CombatSkill.Instance[_id.SkillTemplateId].InnerRatioChangeRange;
		innerRatioChangeRange += GetBreakoutGridCombatSkillPropertyBonus(5);
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			innerRatioChangeRange += breakBonuse.CalcInnerRatioChangeRange(Template.EquipType);
		}
		return (sbyte)Math.Clamp(innerRatioChangeRange, 0, 100);
	}

	public short GetTotalObtainableNeili()
	{
		int value = Config.CombatSkill.Instance[_id.SkillTemplateId].TotalObtainableNeili;
		value += GetBreakoutGridCombatSkillPropertyBonus(6);
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			value += breakBonuse.CalcTotalObtainableNeili();
		}
		return (short)Math.Clamp(value, 0, 32767);
	}

	public sbyte GetFiveElementsChange()
	{
		sbyte fiveElementChange = Config.CombatSkill.Instance[_id.SkillTemplateId].FiveElementChangePerLoop;
		return (sbyte)(fiveElementChange + GetBreakoutGridCombatSkillPropertyBonus(8));
	}

	public sbyte[] GetSpecificGridCount(bool preview = false)
	{
		sbyte[] specificGrids = new sbyte[4];
		GetSpecificGridCount(specificGrids, preview);
		return specificGrids;
	}

	public void GetSpecificGridCount(Span<sbyte> specificGrids, bool preview = false)
	{
		specificGrids.Fill(0);
		for (sbyte equipType = 1; equipType < 5; equipType++)
		{
			specificGrids[equipType - 1] = GetSpecificGridCount(equipType, preview);
		}
	}

	public sbyte GetSpecificGridCount(sbyte equipType, bool preview = false)
	{
		int i = equipType - 1;
		int specificGridCount = GetBreakoutGridCombatSkillPropertyBonus((short)(49 + i));
		bool isMastered = DomainManager.Extra.IsCombatSkillMasteredByCharacter(_id.CharId, _id.SkillTemplateId);
		if (preview)
		{
			isMastered = !isMastered;
		}
		if (isMastered)
		{
			return (sbyte)Math.Clamp(specificGridCount, 0, 127);
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			specificGridCount += breakBonuse.CalcSpecificGridCount(equipType);
		}
		sbyte[] configGrids = Config.CombatSkill.Instance[_id.SkillTemplateId].SpecificGrids;
		specificGridCount += configGrids[i];
		specificGridCount += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 213, EDataModifyType.Add, i);
		return (sbyte)Math.Clamp(specificGridCount, 0, 127);
	}

	public sbyte GetGenericGridCount(bool preview = false)
	{
		bool isMastered = DomainManager.Extra.IsCombatSkillMasteredByCharacter(_id.CharId, _id.SkillTemplateId);
		if (preview)
		{
			isMastered = !isMastered;
		}
		if (isMastered)
		{
			return Config.CombatSkill.Instance[_id.SkillTemplateId].GridCost;
		}
		int genericGrid = Config.CombatSkill.Instance[_id.SkillTemplateId].GenericGrid + GetBreakoutGridCombatSkillPropertyBonus(9);
		genericGrid += DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 214, EDataModifyType.Add);
		return (sbyte)Math.Clamp(genericGrid, 0, 127);
	}

	private short GetTotalHit()
	{
		int totalHit = Config.CombatSkill.Instance[_id.SkillTemplateId].TotalHit;
		totalHit += GetBreakoutGridCombatSkillPropertyBonus(73);
		CValuePercentBonus bonus = GetBreakoutGridCombatSkillPropertyBonus(30);
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			bonus += (CValuePercentBonus)effect.HitFactor;
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			bonus += (CValuePercentBonus)breakBonuse.CalcTotalHit();
		}
		return (short)(totalHit * bonus);
	}

	public int GetPrepareTotalProgress()
	{
		int prepareTotalProgress = Config.CombatSkill.Instance[_id.SkillTemplateId].PrepareTotalProgress;
		int percent = DomainManager.SpecialEffect.GetModifyValue(_id.CharId, _id.SkillTemplateId, 212, EDataModifyType.AddPercent);
		int gridAddPercent = GetBreakoutGridCombatSkillPropertyBonus(2);
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			gridAddPercent += effect.CastFrame;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(_id.CharId);
		ref LifeSkillShorts lifeSkillAttainments = ref character.GetLifeSkillAttainments();
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			gridAddPercent -= breakBonuse.CalcReduceCastFrame(Template.EquipType, ref lifeSkillAttainments);
		}
		return Math.Max(prepareTotalProgress * (100 + percent + gridAddPercent) / 100, 0);
	}

	public short GetDistanceAdditionWhenCast(bool forward)
	{
		int distance = Config.CombatSkill.Instance[_id.SkillTemplateId].DistanceAdditionWhenCast;
		if (Template.EquipType != 1)
		{
			return (short)distance;
		}
		distance += GetBreakoutGridCombatSkillPropertyBonus(34);
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			distance += (forward ? effect.AttackRangeForward : effect.AttackRangeBackward);
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			distance += breakBonuse.CalcAddAttackRange(forward);
		}
		return (short)distance;
	}

	public short GetContinuousFrames()
	{
		short continuousFrames = Config.CombatSkill.Instance[_id.SkillTemplateId].ContinuousFrames;
		CValuePercentBonus bonus = GetBreakoutGridCombatSkillPropertyBonus(28);
		return (short)(continuousFrames * bonus);
	}

	public short GetBounceDistance()
	{
		short bounceDistance = Config.CombatSkill.Instance[_id.SkillTemplateId].BounceDistance;
		return (short)(bounceDistance + GetBreakoutGridCombatSkillPropertyBonus(27));
	}

	public unsafe HitOrAvoidInts GetHitDistribution()
	{
		sbyte[] configValue = Config.CombatSkill.Instance[_id.SkillTemplateId].PerHitDamageRateDistribution;
		HitOrAvoidInts hitDistribution = default(HitOrAvoidInts);
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			sbyte distribution = configValue[hitType];
			if (hitType < 3)
			{
				distribution = (sbyte)(distribution + GetBreakoutGridCombatSkillPropertyBonus((short)(31 + hitType)));
			}
			hitDistribution.Items[hitType] = distribution;
		}
		int sum = 0;
		for (sbyte hitType2 = 0; hitType2 < 4; hitType2++)
		{
			sum += hitDistribution.Items[hitType2];
		}
		if (sum != 100)
		{
			for (sbyte hitType3 = 0; hitType3 < 4; hitType3++)
			{
				hitDistribution.Items[hitType3] = configValue[hitType3];
			}
		}
		hitDistribution = DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 224, hitDistribution);
		return hitDistribution;
	}

	public IEnumerable<int> GetBodyPartWeights()
	{
		sbyte[] configRate = Config.CombatSkill.Instance[_id.SkillTemplateId].InjuryPartAtkRateDistribution;
		CValuePercentBonus chestBonus = GetBreakoutGridCombatSkillPropertyBonus(35);
		CValuePercentBonus bellyBonus = GetBreakoutGridCombatSkillPropertyBonus(36);
		CValuePercentBonus headBonus = GetBreakoutGridCombatSkillPropertyBonus(37);
		CValuePercentBonus handBonus = GetBreakoutGridCombatSkillPropertyBonus(38);
		CValuePercentBonus legBonus = GetBreakoutGridCombatSkillPropertyBonus(39);
		for (sbyte i = 0; i < 7; i++)
		{
			if (1 == 0)
			{
			}
			CValuePercentBonus cValuePercentBonus;
			switch (i)
			{
			case 0:
				cValuePercentBonus = chestBonus;
				break;
			case 1:
				cValuePercentBonus = bellyBonus;
				break;
			case 2:
				cValuePercentBonus = headBonus;
				break;
			case 3:
			case 4:
				cValuePercentBonus = handBonus;
				break;
			case 5:
			case 6:
				cValuePercentBonus = legBonus;
				break;
			default:
				cValuePercentBonus = 0;
				break;
			}
			if (1 == 0)
			{
			}
			CValuePercentBonus bonus = cValuePercentBonus;
			yield return configRate[i] * bonus;
		}
	}

	private int[] GetConfigAffectRequirePower()
	{
		sbyte direction = GetDirection();
		if ((direction < 0 || direction >= 2) ? true : false)
		{
			return null;
		}
		CombatSkillItem configSkill = Config.CombatSkill.Instance[_id.SkillTemplateId];
		SpecialEffectItem configEffect = Config.SpecialEffect.Instance[(direction == 0) ? configSkill.DirectEffectID : configSkill.ReverseEffectID];
		return configEffect.AffectRequirePower;
	}

	public unsafe int GetSumMax2HitDistribution()
	{
		HitOrAvoidInts hitDistribution = GetHitDistribution();
		int max0 = hitDistribution.Items[0];
		int max1 = hitDistribution.Items[1];
		for (int i = 2; i < 4; i++)
		{
			int hit = hitDistribution.Items[i];
			if (max0 > max1)
			{
				if (hit > max1)
				{
					max1 = hit;
				}
			}
			else if (hit > max0)
			{
				max0 = hit;
			}
		}
		return Math.Max(max0, 0) + Math.Max(max1, 0);
	}

	public bool AnyAffectRequirePower()
	{
		int[] configAffectRequirePower = GetConfigAffectRequirePower();
		return configAffectRequirePower != null && configAffectRequirePower.Length > 0;
	}

	public IEnumerable<int> GetAffectRequirePower()
	{
		int[] configAffectRequirePower = GetConfigAffectRequirePower();
		if (configAffectRequirePower != null && configAffectRequirePower.Length > 0)
		{
			int sumMax2HitDistribution = GetSumMax2HitDistribution();
			int[] array = configAffectRequirePower;
			foreach (int requirePower in array)
			{
				yield return (requirePower >= 0) ? requirePower : sumMax2HitDistribution;
			}
		}
	}

	public bool PowerMatchAffectRequire(int power, int index)
	{
		int i = 0;
		foreach (int requirePower in GetAffectRequirePower())
		{
			if (i++ == index)
			{
				return power >= requirePower;
			}
		}
		PredefinedLog.Show(8, $"{_id.SkillTemplateId} do not has require power in index={index}, match is always true");
		return true;
	}

	public int GetAffectRequirePower(int index)
	{
		int i = 0;
		foreach (int requirePower in GetAffectRequirePower())
		{
			if (i++ == index)
			{
				return requirePower;
			}
		}
		PredefinedLog.Show(8, $"{_id.SkillTemplateId} do not has require power in index={index}, require power is always zero");
		return 0;
	}

	public unsafe PoisonsAndLevels GetPoisons()
	{
		PoisonsAndLevels poisons = Config.CombatSkill.Instance[_id.SkillTemplateId].Poisons;
		for (sbyte type = 0; type < 6; type++)
		{
			CValuePercentBonus bonus = GetBreakoutGridCombatSkillPropertyBonus((short)(42 + type));
			foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
			{
				bonus += (CValuePercentBonus)breakBonuse.CalcPoison(type);
			}
			poisons.Values[type] = (short)(poisons.Values[type] * bonus);
		}
		return poisons;
	}

	void ICombatSkillBridge.GetCostTrick(List<NeedTrick> costTricks)
	{
		DomainManager.CombatSkill.GetCombatSkillCostTrick(this, costTricks);
	}

	public (sbyte type, sbyte value) GetCostNeiliAllocation()
	{
		return DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 231, (-1, 0));
	}

	public SpecialEffectItem TryGetSpecialEffect()
	{
		CombatSkillItem config = Config.CombatSkill.Instance[_id.SkillTemplateId];
		sbyte direction = GetDirection();
		if (1 == 0)
		{
		}
		SpecialEffectItem result = direction switch
		{
			0 => Config.SpecialEffect.Instance[config.DirectEffectID], 
			1 => Config.SpecialEffect.Instance[config.ReverseEffectID], 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public int GetReadNormalPagesCount()
	{
		return CombatSkillStateHelper.GetReadNormalPagesCount(_readingState);
	}

	public IEnumerable<SkillBreakPageEffectImplementItem> GetPageEffects()
	{
		if (PlayerCastBossSkills.Ids.Contains(_id.SkillTemplateId))
		{
			yield break;
		}
		foreach (SkillBreakPageEffectItem effect in (IEnumerable<SkillBreakPageEffectItem>)SkillBreakPageEffect.Instance)
		{
			sbyte direction = ((!effect.IsDirect) ? ((sbyte)1) : ((sbyte)0));
			if (CombatSkillStateHelper.GetPageActiveDirection(_activationState, effect.PageId) == direction)
			{
				sbyte equipType = Template.EquipType;
				if (1 == 0)
				{
				}
				int num = equipType switch
				{
					0 => effect.EffectNeigong, 
					1 => effect.EffectAttack, 
					2 => effect.EffectAgile, 
					3 => effect.EffectDefense, 
					4 => effect.EffectAssist, 
					_ => -1, 
				};
				if (1 == 0)
				{
				}
				int implementId = num;
				if (implementId >= 0)
				{
					yield return SkillBreakPageEffectImplement.Instance[implementId];
				}
			}
		}
	}

	public IEnumerable<SkillBreakPlateBonus> GetBreakBonuses()
	{
		if (!CombatSkillStateHelper.IsBrokenOut(_activationState))
		{
			return Enumerable.Empty<SkillBreakPlateBonus>();
		}
		short skillId = _id.SkillTemplateId;
		IEnumerable<SkillBreakPlateBonus> result = null;
		GameData.Domains.Taiwu.SkillBreakPlate plate;
		if (DomainManager.Character.TryGetElement_Objects(_id.CharId, out var character) && character.IsGearMate)
		{
			GearMate gearMate = DomainManager.Extra.GetGearMateById(_id.CharId);
			result = ((gearMate.LuohanBreakDict == null || !gearMate.LuohanBreakDict.TryGetValue(skillId, out var luohanId)) ? gearMate.SkillBreakBonusDict.GetOrDefault(skillId) : GetLuohanBreakBonuses(luohanId));
		}
		else if (_id.CharId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			result = DomainManager.Extra.GetCharacterSkillBreakBonuses(_id.CharId, skillId).Items;
		}
		else if (DomainManager.Taiwu.GetCombatSkillLuohanId(skillId) >= 0)
		{
			result = GetLuohanBreakBonuses();
		}
		else if (DomainManager.Taiwu.TryGetElement_CombatSkillBreakPlates(skillId, out plate))
		{
			result = plate.GetBonuses();
		}
		return result ?? Enumerable.Empty<SkillBreakPlateBonus>();
	}

	private IEnumerable<SkillBreakPlateBonus> GetLuohanBreakBonuses(sbyte? luohanIdOverride = null)
	{
		int count = Config.CombatSkill.Instance[_id.SkillTemplateId].SkillBreakPlate.BonusCount;
		sbyte luohanId = luohanIdOverride ?? DomainManager.Taiwu.GetCombatSkillLuohanId(_id.SkillTemplateId);
		LuohanItem config = Luohan.Instance[luohanId];
		List<SkillBreakPlateBonus> list = new List<SkillBreakPlateBonus>();
		if (config.BonusType == ELuohanBonusType.Medicine)
		{
			for (int i = 0; i < count; i++)
			{
				foreach (short templateId in config.Medicine)
				{
					list.Add(SkillBreakPlateBonus.CreateItem(8, templateId));
				}
			}
		}
		else
		{
			ELuohanBonusType bonusType = config.BonusType;
			if (1 == 0)
			{
			}
			SkillBreakPlateBonus skillBreakPlateBonus = bonusType switch
			{
				ELuohanBonusType.Exp => SkillBreakPlateBonus.CreateExp(GlobalConfig.BreakoutBonusExpLevelValues.Length - 1), 
				ELuohanBonusType.Relation => SkillBreakPlateBonus.CreateFriendVirtual(GlobalConfig.Instance.LuohanRelationTypeAttainment, 30000), 
				ELuohanBonusType.Material => SkillBreakPlateBonus.CreateItem(5, config.Material), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			SkillBreakPlateBonus bonus = skillBreakPlateBonus;
			for (int j = 0; j < count; j++)
			{
				list.Add(bonus);
			}
		}
		return list;
	}

	public int CalcInjuryDamageStep(bool inner, sbyte bodyPart)
	{
		int baseValue = (inner ? Template.InnerDamageSteps : Template.OuterDamageSteps)[bodyPart];
		CValuePercentBonus percentBonus = CalcInjuryDamageStepBonus(inner);
		return baseValue * percentBonus;
	}

	public int CalcFatalDamageStep()
	{
		int baseValue = Template.FatalDamageStep;
		CValuePercentBonus percentBonus = CalcFatalDamageStepBonus();
		return baseValue * percentBonus;
	}

	public int CalcMindDamageStep()
	{
		int baseValue = Template.MindDamageStep;
		CValuePercentBonus percentBonus = CalcMindDamageStepBonus();
		return baseValue * percentBonus;
	}

	public CombatSkillDamageStepBonusDisplayData CalcStepBonusDisplayData()
	{
		return new CombatSkillDamageStepBonusDisplayData
		{
			InnerInjuryStepBonus = CalcInjuryDamageStepBonus(inner: true),
			OuterInjuryStepBonus = CalcInjuryDamageStepBonus(inner: false),
			FatalStepBonus = CalcFatalDamageStepBonus(),
			MindStepBonus = CalcMindDamageStepBonus()
		};
	}

	private int CalcInjuryDamageStepBonus(bool inner)
	{
		int percentBonus = 0;
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			percentBonus += breakBonuse.CalcAddInjuryStep(Template.EquipType, inner);
		}
		return percentBonus;
	}

	private int CalcFatalDamageStepBonus()
	{
		int percentBonus = 0;
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			percentBonus += breakBonuse.CalcAddFatalStep(Template.EquipType);
		}
		return percentBonus;
	}

	private int CalcMindDamageStepBonus()
	{
		int percentBonus = 0;
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			percentBonus += breakBonuse.CalcAddMindStep(Template.EquipType);
		}
		return percentBonus;
	}

	public int GetMakeDamageBreakBonus()
	{
		int bonus = 0;
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			bonus += effect.MakeDamage;
		}
		foreach (SkillBreakPlateBonus breakBonuse in GetBreakBonuses())
		{
			bonus += breakBonuse.CalcMakeDamage();
		}
		return bonus;
	}

	public int GetAcceptDirectDamageBreakBonus(bool anyFatal)
	{
		int bonus = 0;
		foreach (SkillBreakPageEffectImplementItem effect in GetPageEffects())
		{
			bonus += (anyFatal ? effect.AcceptDirectDamageOnFatal : effect.AcceptDirectDamageNoFatal);
		}
		return bonus;
	}

	public CombatSkill(int charId, short skillTemplateId, ushort readingState = 0)
	{
		_id = new CombatSkillKey(charId, skillTemplateId);
		_readingState = readingState;
		_activationState = 0;
		_forcedBreakoutStepsCount = 0;
		_breakoutStepsCount = 0;
		_innerRatio = Config.CombatSkill.Instance[skillTemplateId].BaseInnerRatio;
		_obtainedNeili = 0;
		_revoked = false;
		_specialEffectId = -1L;
	}

	public CombatSkill(IRandomSource random, int charId, short skillTemplateId, sbyte outlinePageType, sbyte directPagesReadCount, sbyte reversePagesReadCount)
	{
		_id = new CombatSkillKey(charId, skillTemplateId);
		_readingState = 0;
		_activationState = 0;
		_forcedBreakoutStepsCount = 0;
		_breakoutStepsCount = 0;
		_innerRatio = Config.CombatSkill.Instance[skillTemplateId].BaseInnerRatio;
		_obtainedNeili = 0;
		_revoked = false;
		_specialEffectId = -1L;
		if (outlinePageType >= 0)
		{
			byte internalIndex = CombatSkillStateHelper.GetOutlinePageInternalIndex(outlinePageType);
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, internalIndex);
		}
		else if (outlinePageType == -2)
		{
			sbyte randomType = GameData.Domains.Character.BehaviorType.GetRandomBehaviorType(random);
			byte internalIndex2 = CombatSkillStateHelper.GetOutlinePageInternalIndex(randomType);
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, internalIndex2);
		}
		if (directPagesReadCount > 0)
		{
			OfflineSetRandomNormalPagesRead(random, 0, directPagesReadCount);
		}
		if (reversePagesReadCount > 0)
		{
			OfflineComplementNormalPages(random, 1, reversePagesReadCount);
		}
	}

	public CombatSkill(IRandomSource random, PresetCombatSkill presetSkill)
	{
		_id = new CombatSkillKey(-1, presetSkill.SkillTemplateId);
		_readingState = 0;
		_activationState = 0;
		_forcedBreakoutStepsCount = 0;
		_breakoutStepsCount = 0;
		_innerRatio = Config.CombatSkill.Instance[presetSkill.SkillTemplateId].BaseInnerRatio;
		_obtainedNeili = 0;
		_revoked = false;
		_specialEffectId = -1L;
		if (presetSkill.OutlinePagesReadCount > 0)
		{
			OfflineSetRandomOutlinePagesRead(random, presetSkill.OutlinePagesReadCount);
		}
		else if (presetSkill.OutlinePagesReadCount < 0)
		{
			OfflineSetOutlinePagesRead(presetSkill.OutlinePagesReadStates);
		}
		if (presetSkill.DirectPagesReadCount > 0)
		{
			OfflineSetRandomNormalPagesRead(random, 0, presetSkill.DirectPagesReadCount);
		}
		else if (presetSkill.DirectPagesReadCount < 0)
		{
			OfflineSetNormalPagesRead(0, presetSkill.DirectPagesReadStates);
		}
		if (presetSkill.ReversePagesReadCount > 0)
		{
			OfflineComplementNormalPages(random, 1, presetSkill.ReversePagesReadCount);
		}
		else if (presetSkill.ReversePagesReadCount < 0)
		{
			OfflineSetNormalPagesRead(1, presetSkill.ReversePagesReadStates);
		}
	}

	public void OfflineSetCharId(int charId)
	{
		_id.CharId = charId;
	}

	public void OfflineSetSpecialEffectId(long specialEffectId)
	{
		_specialEffectId = specialEffectId;
	}

	private unsafe void OfflineSetRandomOutlinePagesRead(IRandomSource random, sbyte readPagesCount)
	{
		byte* pIndexes = stackalloc byte[5];
		for (byte i = 0; i < 5; i++)
		{
			pIndexes[(int)i] = i;
		}
		byte* pShuffledIndexes = CollectionUtils.Shuffle(random, pIndexes, 5, readPagesCount);
		for (byte* pIndex = pShuffledIndexes; pIndex < pShuffledIndexes + readPagesCount; pIndex++)
		{
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, *pIndex);
		}
	}

	private void OfflineSetOutlinePagesRead(bool[] pagesReadStates)
	{
		byte index = 0;
		byte count = 5;
		while (index < count)
		{
			if (pagesReadStates[index])
			{
				_readingState = CombatSkillStateHelper.SetPageRead(_readingState, index);
			}
			index++;
		}
	}

	private unsafe void OfflineSetRandomNormalPagesRead(IRandomSource random, sbyte direction, int readPagesCount)
	{
		byte* pPageIds = stackalloc byte[5];
		for (int i = 0; i < 5; i++)
		{
			pPageIds[i] = (byte)(i + 1);
		}
		byte* pShuffledPageIds = CollectionUtils.Shuffle(random, pPageIds, 5, readPagesCount);
		for (byte* pPageId = pShuffledPageIds; pPageId < pShuffledPageIds + readPagesCount; pPageId++)
		{
			byte pageInternalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, *pPageId);
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, pageInternalIndex);
		}
	}

	private void OfflineComplementNormalPages(IRandomSource random, sbyte direction, int readPagesCount)
	{
		Span<byte> span = stackalloc byte[5];
		SpanList<byte> unreadPageIds = span;
		span = stackalloc byte[5];
		SpanList<byte> readPageIds = span;
		for (int i = 0; i < 5; i++)
		{
			byte pageId = (byte)(i + 1);
			byte internalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId);
			if (CombatSkillStateHelper.IsPageRead(_readingState, internalIndex))
			{
				readPageIds.Add(pageId);
			}
			else
			{
				unreadPageIds.Add(pageId);
			}
		}
		unreadPageIds.Shuffle(random);
		int currPageCount = 0;
		SpanList<byte>.Enumerator enumerator = unreadPageIds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			byte pageId2 = enumerator.Current;
			if (currPageCount >= readPagesCount)
			{
				return;
			}
			byte pageInternalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId2);
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, pageInternalIndex);
			currPageCount++;
		}
		readPageIds.Shuffle(random);
		SpanList<byte>.Enumerator enumerator2 = readPageIds.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			byte pageId3 = enumerator2.Current;
			if (currPageCount >= readPagesCount)
			{
				break;
			}
			byte pageInternalIndex2 = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId3);
			_readingState = CombatSkillStateHelper.SetPageRead(_readingState, pageInternalIndex2);
			currPageCount++;
		}
	}

	private void OfflineSetNormalPagesRead(sbyte direction, bool[] pagesReadStates)
	{
		int i = 0;
		for (int count = 5; i < count; i++)
		{
			if (pagesReadStates[i])
			{
				byte pageId = (byte)(i + 1);
				byte internalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId);
				_readingState = CombatSkillStateHelper.SetPageRead(_readingState, internalIndex);
			}
		}
	}

	public unsafe static ushort GenerateRandomReadingState(IRandomSource random, byte bookPageTypes, int readPagesCount)
	{
		ushort readingState = 0;
		if (readPagesCount > 0)
		{
			sbyte outlinePageType = SkillBookStateHelper.GetOutlinePageType(bookPageTypes);
			byte internalIndex = CombatSkillStateHelper.GetOutlinePageInternalIndex(outlinePageType);
			readingState = CombatSkillStateHelper.SetPageRead(readingState, internalIndex);
			readPagesCount--;
		}
		if (readPagesCount > 0)
		{
			byte* pPageIds = stackalloc byte[5];
			for (int i = 0; i < 5; i++)
			{
				pPageIds[i] = (byte)(i + 1);
			}
			byte* pShuffledPageIds = CollectionUtils.Shuffle(random, pPageIds, 5, readPagesCount);
			for (byte* pPageId = pShuffledPageIds; pPageId < pShuffledPageIds + readPagesCount; pPageId++)
			{
				byte pageId = *pPageId;
				sbyte direction = SkillBookStateHelper.GetNormalPageType(bookPageTypes, pageId);
				byte internalIndex2 = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId);
				readingState = CombatSkillStateHelper.SetPageRead(readingState, internalIndex2);
			}
		}
		return readingState;
	}

	public CombatSkillKey GetId()
	{
		return _id;
	}

	public ushort GetReadingState()
	{
		return _readingState;
	}

	public void SetReadingState(ushort readingState, DataContext context)
	{
		_readingState = readingState;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public ushort GetActivationState()
	{
		return _activationState;
	}

	public void SetActivationState(ushort activationState, DataContext context)
	{
		_activationState = activationState;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public sbyte GetForcedBreakoutStepsCount()
	{
		return _forcedBreakoutStepsCount;
	}

	public void SetForcedBreakoutStepsCount(sbyte forcedBreakoutStepsCount, DataContext context)
	{
		_forcedBreakoutStepsCount = forcedBreakoutStepsCount;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public sbyte GetBreakoutStepsCount()
	{
		return _breakoutStepsCount;
	}

	public void SetBreakoutStepsCount(sbyte breakoutStepsCount, DataContext context)
	{
		_breakoutStepsCount = breakoutStepsCount;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public sbyte GetInnerRatio()
	{
		return _innerRatio;
	}

	public void SetInnerRatio(sbyte innerRatio, DataContext context)
	{
		_innerRatio = innerRatio;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public short GetObtainedNeili()
	{
		return _obtainedNeili;
	}

	public void SetObtainedNeili(short obtainedNeili, DataContext context)
	{
		_obtainedNeili = obtainedNeili;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public bool GetRevoked()
	{
		return _revoked;
	}

	public void SetRevoked(bool revoked, DataContext context)
	{
		_revoked = revoked;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public long GetSpecialEffectId()
	{
		return _specialEffectId;
	}

	public void SetSpecialEffectId(long specialEffectId, DataContext context)
	{
		_specialEffectId = specialEffectId;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public short GetPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return _power;
		}
		short value = CalcPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_power = value;
			dataStates.SetCached(DataStatesOffset, 9);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _power;
	}

	public short GetMaxPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 10))
		{
			return _maxPower;
		}
		short value = CalcMaxPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxPower = value;
			dataStates.SetCached(DataStatesOffset, 10);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxPower;
	}

	public short GetRequirementPercent()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 11))
		{
			return _requirementPercent;
		}
		short value = CalcRequirementPercent();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_requirementPercent = value;
			dataStates.SetCached(DataStatesOffset, 11);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _requirementPercent;
	}

	public sbyte GetDirection()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 12))
		{
			return _direction;
		}
		sbyte value = CalcDirection();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_direction = value;
			dataStates.SetCached(DataStatesOffset, 12);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _direction;
	}

	public short GetBaseScore()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 13))
		{
			return _baseScore;
		}
		short value = CalcBaseScore();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_baseScore = value;
			dataStates.SetCached(DataStatesOffset, 13);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _baseScore;
	}

	public sbyte GetCurrInnerRatio()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 14))
		{
			return _currInnerRatio;
		}
		sbyte value = CalcCurrInnerRatio();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_currInnerRatio = value;
			dataStates.SetCached(DataStatesOffset, 14);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _currInnerRatio;
	}

	public HitOrAvoidInts GetHitValue()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 15))
		{
			return _hitValue;
		}
		HitOrAvoidInts value = CalcHitValue();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_hitValue = value;
			dataStates.SetCached(DataStatesOffset, 15);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _hitValue;
	}

	public OuterAndInnerInts GetPenetrations()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 16))
		{
			return _penetrations;
		}
		OuterAndInnerInts value = CalcPenetrations();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_penetrations = value;
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
		return _penetrations;
	}

	public sbyte GetCostBreathAndStancePercent()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 17))
		{
			return _costBreathAndStancePercent;
		}
		sbyte value = CalcCostBreathAndStancePercent();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_costBreathAndStancePercent = value;
			dataStates.SetCached(DataStatesOffset, 17);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _costBreathAndStancePercent;
	}

	public sbyte GetCostBreathPercent()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 18))
		{
			return _costBreathPercent;
		}
		sbyte value = CalcCostBreathPercent();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_costBreathPercent = value;
			dataStates.SetCached(DataStatesOffset, 18);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _costBreathPercent;
	}

	public sbyte GetCostStancePercent()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 19))
		{
			return _costStancePercent;
		}
		sbyte value = CalcCostStancePercent();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_costStancePercent = value;
			dataStates.SetCached(DataStatesOffset, 19);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _costStancePercent;
	}

	public sbyte GetCostMobilityPercent()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 20))
		{
			return _costMobilityPercent;
		}
		sbyte value = CalcCostMobilityPercent();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_costMobilityPercent = value;
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
		return _costMobilityPercent;
	}

	public HitOrAvoidInts GetAddHitValueOnCast()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 21))
		{
			return _addHitValueOnCast;
		}
		HitOrAvoidInts value = CalcAddHitValueOnCast();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_addHitValueOnCast = value;
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
		return _addHitValueOnCast;
	}

	public OuterAndInnerInts GetAddPenetrateResist()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 22))
		{
			return _addPenetrateResist;
		}
		OuterAndInnerInts value = CalcAddPenetrateResist();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_addPenetrateResist = value;
			dataStates.SetCached(DataStatesOffset, 22);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _addPenetrateResist;
	}

	public HitOrAvoidInts GetAddAvoidValueOnCast()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 23))
		{
			return _addAvoidValueOnCast;
		}
		HitOrAvoidInts value = CalcAddAvoidValueOnCast();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_addAvoidValueOnCast = value;
			dataStates.SetCached(DataStatesOffset, 23);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _addAvoidValueOnCast;
	}

	public int GetFightBackPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 24))
		{
			return _fightBackPower;
		}
		int value = CalcFightBackPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_fightBackPower = value;
			dataStates.SetCached(DataStatesOffset, 24);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _fightBackPower;
	}

	public OuterAndInnerInts GetBouncePower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 25))
		{
			return _bouncePower;
		}
		OuterAndInnerInts value = CalcBouncePower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_bouncePower = value;
			dataStates.SetCached(DataStatesOffset, 25);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _bouncePower;
	}

	public short GetRequirementsPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 26))
		{
			return _requirementsPower;
		}
		short value = CalcRequirementsPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_requirementsPower = value;
			dataStates.SetCached(DataStatesOffset, 26);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _requirementsPower;
	}

	public int GetPlateAddMaxPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 27))
		{
			return _plateAddMaxPower;
		}
		int value = CalcPlateAddMaxPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_plateAddMaxPower = value;
			dataStates.SetCached(DataStatesOffset, 27);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _plateAddMaxPower;
	}

	public CombatSkill()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
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
		return 26;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _id.Serialize(pCurrData);
		*(ushort*)pCurrData = _readingState;
		pCurrData += 2;
		*(ushort*)pCurrData = _activationState;
		pCurrData += 2;
		*pCurrData = (byte)_forcedBreakoutStepsCount;
		pCurrData++;
		*pCurrData = (byte)_breakoutStepsCount;
		pCurrData++;
		*pCurrData = (byte)_innerRatio;
		pCurrData++;
		*(short*)pCurrData = _obtainedNeili;
		pCurrData += 2;
		*pCurrData = (_revoked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(long*)pCurrData = _specialEffectId;
		pCurrData += 8;
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
				pCurrData += _id.Deserialize(pCurrData);
				continue;
			case 1:
				_readingState = *(ushort*)pCurrData;
				pCurrData += 2;
				continue;
			case 2:
				_activationState = *(ushort*)pCurrData;
				pCurrData += 2;
				continue;
			case 3:
				_forcedBreakoutStepsCount = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 4:
				_breakoutStepsCount = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 5:
				_innerRatio = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 6:
				_obtainedNeili = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 7:
				_revoked = *pCurrData != 0;
				pCurrData++;
				continue;
			case 8:
				_specialEffectId = *(long*)pCurrData;
				pCurrData += 8;
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
