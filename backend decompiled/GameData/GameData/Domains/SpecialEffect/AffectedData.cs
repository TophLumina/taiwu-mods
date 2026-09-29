using System;
using GameData.Common;
using GameData.Serializer;

namespace GameData.Domains.SpecialEffect;

[SerializableGameData(NotForDisplayModule = true)]
public class AffectedData : BaseGameDataObject, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private int _id;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxDexterity;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxConcentration;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxVitality;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxEnergy;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxIntelligence;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _recoveryOfStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _recoveryOfBreath;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _moveSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _recoveryOfFlaw;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _castSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _recoveryOfBlockedAcupoint;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponSwitchSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _innerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _recoveryOfQiDisorder;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _minorAttributeFixMaxValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _minorAttributeFixMinValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfHotPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfGloomyPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfColdPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfRedPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfRottenPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfIllusoryPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _resistOfAllPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _personalitiesAll;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _displayAge;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliProportionOfFiveElements;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillAlsoAsFiveElements;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponMaxPower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponUseRequirement;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponAttackRange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _armorMaxPower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _armorUseRequirement;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _equipmentPower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _ignoreEquipmentOverload;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _equipmentBonus;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _equipmentMasteryAffectOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitAddByTempValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitCanChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitChangeEffectPercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidAddByTempValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidCanChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _avoidChangeEffectPercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _penetrateOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _penetrateInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _penetrateResistOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _penetrateResistInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _consummateLevelBonus;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _consummateLevelRelatedMainAttributesHitValues;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _consummateLevelRelatedMainAttributesAvoidValues;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _consummateLevelRelatedMainAttributesPenetrations;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _consummateLevelRelatedMainAttributesPenetrationResists;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliAllocationAttack;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliAllocationAgile;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliAllocationDefense;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliAllocationAssist;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _happiness;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxHealth;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healthCost;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _moveSpeedCanChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _goneMadInAllBreak;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _xiangshuInfectionDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healthDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _happinessDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _currAgeDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _neiliDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeLoveRateOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _takeRevengeRateOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canMakeLoveSpecialOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canReadingOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canAutoHealOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canRecoverHealthOnMonthChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _featureBonusReverse;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeHarmfulActionSuccessRate;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptHarmfulActionSuccessRate;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerHitStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerHitTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerHitSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerHitMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerAvoidStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerAvoidTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerAvoidSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerAvoidMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerPenetrateOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerPenetrateInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerPenetrateResistOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerPenetrateResistInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerCriticalOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackHitType;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeDirectDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeMindDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeBounceDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeFightBackDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeFatalDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makePoisonLevel;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makePoisonValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makePoisonResist;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makePoisonTarget;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerHitOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerFightBackHitOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerPursueOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _causedInjuryChangeToOld;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _causedPoisonChangeToOld;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _causedInjuryChangeToOldOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptInjuryChangeToOldOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _causedMindChangeToInfiniteOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _allMarkChangeToMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mindMarkChangeToFatal;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mindUpheavalTime;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeDamageCanReduce;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _ignoreArmor;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeDamageType;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canMakeInjuryToNoInjuryPart;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makePoisonType;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackWeapon;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackTrick;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackGetTrickCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackPrepareFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackRecoveryFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _unlockSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _normalAttackChangeToUnlockAttack;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _rawCreateEffectList;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _extraFlawCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _flawBonusFactor;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackCanBounce;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackCanFightBack;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackCanPursue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _makeFightBackInjuryMark;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _legSkillUseShoes;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerDirectFinalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackerFinalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderHitStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderHitTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderHitSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderHitMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderAvoidStrength;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderAvoidTechnique;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderAvoidSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderAvoidMind;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderPenetrateOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderPenetrateInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderPenetrateResistOuter;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderPenetrateResistInner;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderCriticalOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptDirectDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptMindDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptBounceDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptFightBackDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptFatalDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptPoisonLevel;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptPoisonValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptPoisonResist;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptPoisonTarget;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderHitOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderFightBackHitOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderPursueOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptDamageCanAdd;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acceptMaxInjuryCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _bouncePower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _fightBackPower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _directDamageInnerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderDirectFinalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defenderFinalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _unyieldingFallen;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _outerInjuryImmunity;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _innerInjuryImmunity;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _directDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _directInjuryMark;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _goneMadInjury;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _finalGoneMadInjury;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healInjurySpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healInjuryBuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healInjuryDebuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healInjuryWithFatalRequireAttainment;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healPoisonSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healPoisonBuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healPoisonDebuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _medicineEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healFlawSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _healAcupointSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _fleeSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxFlawCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canAddFlaw;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _flawLevel;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _flawLevelCanReduce;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _flawCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxAcupointCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canAddAcupoint;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acupointLevel;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acupointLevelCanReduce;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acupointCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _addNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canChangeNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canGetTrick;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _getTrickType;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackBodyPart;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackBodyPartOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponEquipAttack;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponEquipDefense;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _armorEquipAttack;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _armorEquipDefense;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _equipmentWeight;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackRangeForward;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackRangeBackward;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _attackRangeMaxAcupoint;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _moveCanBeStopped;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canForcedMove;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mobilityCanBeRemoved;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mobilityCostByEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _stanceCostByEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _breathCostByEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _moveDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _lockDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _jumpPrepareFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _bounceInjuryMark;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillHasCost;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _combatStateEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _changeNeedUseSkill;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _changeDistanceIsMove;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _replaceCharHit;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canAddPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canReducePoison;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _reducePoisonValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _poisonCanAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _poisonAffectCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _poisonAffectThreshold;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _poisonAffectProduceValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mixPoisonInfinityAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mixPoisonCanAffectCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _jiTrickAsWeaponTrickCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _uselessTrickAsJiTrickCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitReduceDurability;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _changeDurability;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _jumpMoveDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _combatStateToAdd;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _combatStatePower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _breakBodyPartInjuryCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _bodyPartIsBroken;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxTrickCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxBreathPercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxStancePercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxMobilityPercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _extraBreathPercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _extraStancePercent;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _moveCostMobility;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defendSkillKeepTime;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _bounceRange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mindMarkKeepTime;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mindMarkCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillMobilityCostPerFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canAddWug;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hasGodWeaponBuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hasGodArmorBuff;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _teammateCmdRequireGenerateValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _teammateCmdEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _teammateCmdCanUse;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _flawRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _acupointRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mindMarkRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _injuryAutoHealSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canRecoverBreath;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canRecoverStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _fatalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _wugFatalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _fatalDamageMarkCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _finalFatalDamageMarkCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canFightBackDuringPrepareSkill;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canFightBackOutOfAttackRange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canFightBackWithHit;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillPrepareSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _breathRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _stanceRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _mobilityRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxChangeTrickCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _changeTrickProgressAddValue;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _agileSkillCanAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _defendSkillCanAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _assistSkillCanAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _power;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _maxPower;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _powerCanReduce;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _powerAddRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _powerReduceRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _powerEffectReverse;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _useRequirement;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _currInnerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costBreathAndStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costBreath;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costMobility;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillCostTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCostEnemyUsableTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCostUselessTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCostShaTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _effectDirection;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _effectDirectionCanChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _gridCost;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _prepareTotalProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _specificGridCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _genericGridCount;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCriticalHit;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _criticalDamage;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _certainCriticalHit;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _inevitableHit;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _inevitableAvoid;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canInterrupt;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _interruptOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canSilence;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _silenceOdds;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _silenceFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _weaponSilenceFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCastWithBrokenBodyPart;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _addPowerCanBeRemoved;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _skillType;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _effectCountCanChange;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _stayEffectCountOnAddPhase;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCast;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCastInDefend;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _hitDistribution;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCastOnLackBreath;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCastOnLackStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _convertCostBreathAndStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costBreathOnCast;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _costStanceOnCast;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canUseMobilityAsBreath;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canUseMobilityAsStance;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _castCostNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _castCostNeiliAllocationIsAbsorb;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCostNeiliAllocationEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _canCostTrickDuringPreparingSkill;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _validItemList;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _useItemCostNoWisdom;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _combatSkillDataEffectList;

	[CollectionObjectField(false, true, false, false, false)]
	private SpecialEffectList _combatSkillAiScorePower;

	public const int FixedSize = 4;

	public const int DynamicCount = 345;

	private static readonly ushort[] ArchiveFieldIds = new ushort[346]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
		20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
		30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
		40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
		50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
		60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
		70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
		80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
		90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
		100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
		110, 111, 112, 113, 114, 115, 116, 117, 118, 119,
		120, 121, 122, 123, 124, 125, 126, 127, 128, 129,
		130, 131, 132, 133, 134, 135, 136, 137, 138, 139,
		140, 141, 142, 143, 144, 145, 146, 147, 148, 149,
		150, 151, 152, 153, 154, 155, 156, 157, 158, 159,
		160, 161, 162, 163, 164, 165, 166, 167, 168, 169,
		170, 171, 172, 173, 174, 175, 176, 177, 178, 179,
		180, 181, 182, 183, 184, 185, 186, 187, 188, 189,
		190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
		200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
		210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
		220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
		230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
		240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
		250, 251, 252, 253, 254, 255, 256, 257, 258, 259,
		260, 261, 262, 263, 264, 265, 266, 267, 268, 269,
		270, 271, 272, 273, 274, 275, 276, 277, 278, 279,
		280, 281, 282, 283, 284, 285, 286, 287, 288, 289,
		290, 291, 292, 293, 294, 295, 296, 297, 298, 299,
		300, 301, 302, 303, 304, 305, 306, 307, 308, 309,
		310, 311, 312, 313, 314, 315, 316, 317, 318, 319,
		320, 321, 322, 323, 324, 325, 326, 327, 328, 329,
		330, 331, 332, 333, 334, 335, 336, 337, 338, 339,
		340, 341, 342, 343, 344, 345
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[1] { 4 };

	public AffectedData(int charId)
	{
		_id = charId;
	}

	public SpecialEffectList GetEffectList(ushort fieldId, bool createIfNull = false)
	{
		switch (fieldId)
		{
		case 1:
			if (_maxStrength == null && createIfNull)
			{
				_maxStrength = new SpecialEffectList();
			}
			return _maxStrength;
		case 2:
			if (_maxDexterity == null && createIfNull)
			{
				_maxDexterity = new SpecialEffectList();
			}
			return _maxDexterity;
		case 3:
			if (_maxConcentration == null && createIfNull)
			{
				_maxConcentration = new SpecialEffectList();
			}
			return _maxConcentration;
		case 4:
			if (_maxVitality == null && createIfNull)
			{
				_maxVitality = new SpecialEffectList();
			}
			return _maxVitality;
		case 5:
			if (_maxEnergy == null && createIfNull)
			{
				_maxEnergy = new SpecialEffectList();
			}
			return _maxEnergy;
		case 6:
			if (_maxIntelligence == null && createIfNull)
			{
				_maxIntelligence = new SpecialEffectList();
			}
			return _maxIntelligence;
		case 7:
			if (_recoveryOfStance == null && createIfNull)
			{
				_recoveryOfStance = new SpecialEffectList();
			}
			return _recoveryOfStance;
		case 8:
			if (_recoveryOfBreath == null && createIfNull)
			{
				_recoveryOfBreath = new SpecialEffectList();
			}
			return _recoveryOfBreath;
		case 9:
			if (_moveSpeed == null && createIfNull)
			{
				_moveSpeed = new SpecialEffectList();
			}
			return _moveSpeed;
		case 10:
			if (_recoveryOfFlaw == null && createIfNull)
			{
				_recoveryOfFlaw = new SpecialEffectList();
			}
			return _recoveryOfFlaw;
		case 11:
			if (_castSpeed == null && createIfNull)
			{
				_castSpeed = new SpecialEffectList();
			}
			return _castSpeed;
		case 12:
			if (_recoveryOfBlockedAcupoint == null && createIfNull)
			{
				_recoveryOfBlockedAcupoint = new SpecialEffectList();
			}
			return _recoveryOfBlockedAcupoint;
		case 13:
			if (_weaponSwitchSpeed == null && createIfNull)
			{
				_weaponSwitchSpeed = new SpecialEffectList();
			}
			return _weaponSwitchSpeed;
		case 14:
			if (_attackSpeed == null && createIfNull)
			{
				_attackSpeed = new SpecialEffectList();
			}
			return _attackSpeed;
		case 15:
			if (_innerRatio == null && createIfNull)
			{
				_innerRatio = new SpecialEffectList();
			}
			return _innerRatio;
		case 16:
			if (_recoveryOfQiDisorder == null && createIfNull)
			{
				_recoveryOfQiDisorder = new SpecialEffectList();
			}
			return _recoveryOfQiDisorder;
		case 17:
			if (_minorAttributeFixMaxValue == null && createIfNull)
			{
				_minorAttributeFixMaxValue = new SpecialEffectList();
			}
			return _minorAttributeFixMaxValue;
		case 18:
			if (_minorAttributeFixMinValue == null && createIfNull)
			{
				_minorAttributeFixMinValue = new SpecialEffectList();
			}
			return _minorAttributeFixMinValue;
		case 19:
			if (_resistOfHotPoison == null && createIfNull)
			{
				_resistOfHotPoison = new SpecialEffectList();
			}
			return _resistOfHotPoison;
		case 20:
			if (_resistOfGloomyPoison == null && createIfNull)
			{
				_resistOfGloomyPoison = new SpecialEffectList();
			}
			return _resistOfGloomyPoison;
		case 21:
			if (_resistOfColdPoison == null && createIfNull)
			{
				_resistOfColdPoison = new SpecialEffectList();
			}
			return _resistOfColdPoison;
		case 22:
			if (_resistOfRedPoison == null && createIfNull)
			{
				_resistOfRedPoison = new SpecialEffectList();
			}
			return _resistOfRedPoison;
		case 23:
			if (_resistOfRottenPoison == null && createIfNull)
			{
				_resistOfRottenPoison = new SpecialEffectList();
			}
			return _resistOfRottenPoison;
		case 24:
			if (_resistOfIllusoryPoison == null && createIfNull)
			{
				_resistOfIllusoryPoison = new SpecialEffectList();
			}
			return _resistOfIllusoryPoison;
		case 245:
			if (_resistOfAllPoison == null && createIfNull)
			{
				_resistOfAllPoison = new SpecialEffectList();
			}
			return _resistOfAllPoison;
		case 302:
			if (_personalitiesAll == null && createIfNull)
			{
				_personalitiesAll = new SpecialEffectList();
			}
			return _personalitiesAll;
		case 25:
			if (_displayAge == null && createIfNull)
			{
				_displayAge = new SpecialEffectList();
			}
			return _displayAge;
		case 26:
			if (_neiliProportionOfFiveElements == null && createIfNull)
			{
				_neiliProportionOfFiveElements = new SpecialEffectList();
			}
			return _neiliProportionOfFiveElements;
		case 240:
			if (_skillAlsoAsFiveElements == null && createIfNull)
			{
				_skillAlsoAsFiveElements = new SpecialEffectList();
			}
			return _skillAlsoAsFiveElements;
		case 27:
			if (_weaponMaxPower == null && createIfNull)
			{
				_weaponMaxPower = new SpecialEffectList();
			}
			return _weaponMaxPower;
		case 28:
			if (_weaponUseRequirement == null && createIfNull)
			{
				_weaponUseRequirement = new SpecialEffectList();
			}
			return _weaponUseRequirement;
		case 29:
			if (_weaponAttackRange == null && createIfNull)
			{
				_weaponAttackRange = new SpecialEffectList();
			}
			return _weaponAttackRange;
		case 30:
			if (_armorMaxPower == null && createIfNull)
			{
				_armorMaxPower = new SpecialEffectList();
			}
			return _armorMaxPower;
		case 31:
			if (_armorUseRequirement == null && createIfNull)
			{
				_armorUseRequirement = new SpecialEffectList();
			}
			return _armorUseRequirement;
		case 313:
			if (_equipmentPower == null && createIfNull)
			{
				_equipmentPower = new SpecialEffectList();
			}
			return _equipmentPower;
		case 278:
			if (_ignoreEquipmentOverload == null && createIfNull)
			{
				_ignoreEquipmentOverload = new SpecialEffectList();
			}
			return _ignoreEquipmentOverload;
		case 308:
			if (_equipmentBonus == null && createIfNull)
			{
				_equipmentBonus = new SpecialEffectList();
			}
			return _equipmentBonus;
		case 338:
			if (_equipmentMasteryAffectOdds == null && createIfNull)
			{
				_equipmentMasteryAffectOdds = new SpecialEffectList();
			}
			return _equipmentMasteryAffectOdds;
		case 32:
			if (_hitStrength == null && createIfNull)
			{
				_hitStrength = new SpecialEffectList();
			}
			return _hitStrength;
		case 33:
			if (_hitTechnique == null && createIfNull)
			{
				_hitTechnique = new SpecialEffectList();
			}
			return _hitTechnique;
		case 34:
			if (_hitSpeed == null && createIfNull)
			{
				_hitSpeed = new SpecialEffectList();
			}
			return _hitSpeed;
		case 35:
			if (_hitMind == null && createIfNull)
			{
				_hitMind = new SpecialEffectList();
			}
			return _hitMind;
		case 276:
			if (_hitAddByTempValue == null && createIfNull)
			{
				_hitAddByTempValue = new SpecialEffectList();
			}
			return _hitAddByTempValue;
		case 36:
			if (_hitCanChange == null && createIfNull)
			{
				_hitCanChange = new SpecialEffectList();
			}
			return _hitCanChange;
		case 37:
			if (_hitChangeEffectPercent == null && createIfNull)
			{
				_hitChangeEffectPercent = new SpecialEffectList();
			}
			return _hitChangeEffectPercent;
		case 38:
			if (_avoidStrength == null && createIfNull)
			{
				_avoidStrength = new SpecialEffectList();
			}
			return _avoidStrength;
		case 39:
			if (_avoidTechnique == null && createIfNull)
			{
				_avoidTechnique = new SpecialEffectList();
			}
			return _avoidTechnique;
		case 40:
			if (_avoidSpeed == null && createIfNull)
			{
				_avoidSpeed = new SpecialEffectList();
			}
			return _avoidSpeed;
		case 41:
			if (_avoidMind == null && createIfNull)
			{
				_avoidMind = new SpecialEffectList();
			}
			return _avoidMind;
		case 277:
			if (_avoidAddByTempValue == null && createIfNull)
			{
				_avoidAddByTempValue = new SpecialEffectList();
			}
			return _avoidAddByTempValue;
		case 42:
			if (_avoidCanChange == null && createIfNull)
			{
				_avoidCanChange = new SpecialEffectList();
			}
			return _avoidCanChange;
		case 43:
			if (_avoidChangeEffectPercent == null && createIfNull)
			{
				_avoidChangeEffectPercent = new SpecialEffectList();
			}
			return _avoidChangeEffectPercent;
		case 44:
			if (_penetrateOuter == null && createIfNull)
			{
				_penetrateOuter = new SpecialEffectList();
			}
			return _penetrateOuter;
		case 45:
			if (_penetrateInner == null && createIfNull)
			{
				_penetrateInner = new SpecialEffectList();
			}
			return _penetrateInner;
		case 46:
			if (_penetrateResistOuter == null && createIfNull)
			{
				_penetrateResistOuter = new SpecialEffectList();
			}
			return _penetrateResistOuter;
		case 47:
			if (_penetrateResistInner == null && createIfNull)
			{
				_penetrateResistInner = new SpecialEffectList();
			}
			return _penetrateResistInner;
		case 296:
			if (_consummateLevelBonus == null && createIfNull)
			{
				_consummateLevelBonus = new SpecialEffectList();
			}
			return _consummateLevelBonus;
		case 236:
			if (_consummateLevelRelatedMainAttributesHitValues == null && createIfNull)
			{
				_consummateLevelRelatedMainAttributesHitValues = new SpecialEffectList();
			}
			return _consummateLevelRelatedMainAttributesHitValues;
		case 237:
			if (_consummateLevelRelatedMainAttributesAvoidValues == null && createIfNull)
			{
				_consummateLevelRelatedMainAttributesAvoidValues = new SpecialEffectList();
			}
			return _consummateLevelRelatedMainAttributesAvoidValues;
		case 238:
			if (_consummateLevelRelatedMainAttributesPenetrations == null && createIfNull)
			{
				_consummateLevelRelatedMainAttributesPenetrations = new SpecialEffectList();
			}
			return _consummateLevelRelatedMainAttributesPenetrations;
		case 239:
			if (_consummateLevelRelatedMainAttributesPenetrationResists == null && createIfNull)
			{
				_consummateLevelRelatedMainAttributesPenetrationResists = new SpecialEffectList();
			}
			return _consummateLevelRelatedMainAttributesPenetrationResists;
		case 48:
			if (_neiliAllocationAttack == null && createIfNull)
			{
				_neiliAllocationAttack = new SpecialEffectList();
			}
			return _neiliAllocationAttack;
		case 49:
			if (_neiliAllocationAgile == null && createIfNull)
			{
				_neiliAllocationAgile = new SpecialEffectList();
			}
			return _neiliAllocationAgile;
		case 50:
			if (_neiliAllocationDefense == null && createIfNull)
			{
				_neiliAllocationDefense = new SpecialEffectList();
			}
			return _neiliAllocationDefense;
		case 51:
			if (_neiliAllocationAssist == null && createIfNull)
			{
				_neiliAllocationAssist = new SpecialEffectList();
			}
			return _neiliAllocationAssist;
		case 52:
			if (_happiness == null && createIfNull)
			{
				_happiness = new SpecialEffectList();
			}
			return _happiness;
		case 53:
			if (_maxHealth == null && createIfNull)
			{
				_maxHealth = new SpecialEffectList();
			}
			return _maxHealth;
		case 54:
			if (_healthCost == null && createIfNull)
			{
				_healthCost = new SpecialEffectList();
			}
			return _healthCost;
		case 55:
			if (_moveSpeedCanChange == null && createIfNull)
			{
				_moveSpeedCanChange = new SpecialEffectList();
			}
			return _moveSpeedCanChange;
		case 266:
			if (_goneMadInAllBreak == null && createIfNull)
			{
				_goneMadInAllBreak = new SpecialEffectList();
			}
			return _goneMadInAllBreak;
		case 261:
			if (_xiangshuInfectionDelta == null && createIfNull)
			{
				_xiangshuInfectionDelta = new SpecialEffectList();
			}
			return _xiangshuInfectionDelta;
		case 262:
			if (_healthDelta == null && createIfNull)
			{
				_healthDelta = new SpecialEffectList();
			}
			return _healthDelta;
		case 269:
			if (_happinessDelta == null && createIfNull)
			{
				_happinessDelta = new SpecialEffectList();
			}
			return _happinessDelta;
		case 265:
			if (_currAgeDelta == null && createIfNull)
			{
				_currAgeDelta = new SpecialEffectList();
			}
			return _currAgeDelta;
		case 297:
			if (_neiliDelta == null && createIfNull)
			{
				_neiliDelta = new SpecialEffectList();
			}
			return _neiliDelta;
		case 267:
			if (_makeLoveRateOnMonthChange == null && createIfNull)
			{
				_makeLoveRateOnMonthChange = new SpecialEffectList();
			}
			return _makeLoveRateOnMonthChange;
		case 295:
			if (_takeRevengeRateOnMonthChange == null && createIfNull)
			{
				_takeRevengeRateOnMonthChange = new SpecialEffectList();
			}
			return _takeRevengeRateOnMonthChange;
		case 298:
			if (_canMakeLoveSpecialOnMonthChange == null && createIfNull)
			{
				_canMakeLoveSpecialOnMonthChange = new SpecialEffectList();
			}
			return _canMakeLoveSpecialOnMonthChange;
		case 259:
			if (_canReadingOnMonthChange == null && createIfNull)
			{
				_canReadingOnMonthChange = new SpecialEffectList();
			}
			return _canReadingOnMonthChange;
		case 268:
			if (_canAutoHealOnMonthChange == null && createIfNull)
			{
				_canAutoHealOnMonthChange = new SpecialEffectList();
			}
			return _canAutoHealOnMonthChange;
		case 294:
			if (_canRecoverHealthOnMonthChange == null && createIfNull)
			{
				_canRecoverHealthOnMonthChange = new SpecialEffectList();
			}
			return _canRecoverHealthOnMonthChange;
		case 292:
			if (_featureBonusReverse == null && createIfNull)
			{
				_featureBonusReverse = new SpecialEffectList();
			}
			return _featureBonusReverse;
		case 331:
			if (_makeHarmfulActionSuccessRate == null && createIfNull)
			{
				_makeHarmfulActionSuccessRate = new SpecialEffectList();
			}
			return _makeHarmfulActionSuccessRate;
		case 332:
			if (_acceptHarmfulActionSuccessRate == null && createIfNull)
			{
				_acceptHarmfulActionSuccessRate = new SpecialEffectList();
			}
			return _acceptHarmfulActionSuccessRate;
		case 56:
			if (_attackerHitStrength == null && createIfNull)
			{
				_attackerHitStrength = new SpecialEffectList();
			}
			return _attackerHitStrength;
		case 57:
			if (_attackerHitTechnique == null && createIfNull)
			{
				_attackerHitTechnique = new SpecialEffectList();
			}
			return _attackerHitTechnique;
		case 58:
			if (_attackerHitSpeed == null && createIfNull)
			{
				_attackerHitSpeed = new SpecialEffectList();
			}
			return _attackerHitSpeed;
		case 59:
			if (_attackerHitMind == null && createIfNull)
			{
				_attackerHitMind = new SpecialEffectList();
			}
			return _attackerHitMind;
		case 60:
			if (_attackerAvoidStrength == null && createIfNull)
			{
				_attackerAvoidStrength = new SpecialEffectList();
			}
			return _attackerAvoidStrength;
		case 61:
			if (_attackerAvoidTechnique == null && createIfNull)
			{
				_attackerAvoidTechnique = new SpecialEffectList();
			}
			return _attackerAvoidTechnique;
		case 62:
			if (_attackerAvoidSpeed == null && createIfNull)
			{
				_attackerAvoidSpeed = new SpecialEffectList();
			}
			return _attackerAvoidSpeed;
		case 63:
			if (_attackerAvoidMind == null && createIfNull)
			{
				_attackerAvoidMind = new SpecialEffectList();
			}
			return _attackerAvoidMind;
		case 64:
			if (_attackerPenetrateOuter == null && createIfNull)
			{
				_attackerPenetrateOuter = new SpecialEffectList();
			}
			return _attackerPenetrateOuter;
		case 65:
			if (_attackerPenetrateInner == null && createIfNull)
			{
				_attackerPenetrateInner = new SpecialEffectList();
			}
			return _attackerPenetrateInner;
		case 66:
			if (_attackerPenetrateResistOuter == null && createIfNull)
			{
				_attackerPenetrateResistOuter = new SpecialEffectList();
			}
			return _attackerPenetrateResistOuter;
		case 67:
			if (_attackerPenetrateResistInner == null && createIfNull)
			{
				_attackerPenetrateResistInner = new SpecialEffectList();
			}
			return _attackerPenetrateResistInner;
		case 341:
			if (_attackerCriticalOdds == null && createIfNull)
			{
				_attackerCriticalOdds = new SpecialEffectList();
			}
			return _attackerCriticalOdds;
		case 68:
			if (_attackHitType == null && createIfNull)
			{
				_attackHitType = new SpecialEffectList();
			}
			return _attackHitType;
		case 69:
			if (_makeDirectDamage == null && createIfNull)
			{
				_makeDirectDamage = new SpecialEffectList();
			}
			return _makeDirectDamage;
		case 274:
			if (_makeMindDamage == null && createIfNull)
			{
				_makeMindDamage = new SpecialEffectList();
			}
			return _makeMindDamage;
		case 70:
			if (_makeBounceDamage == null && createIfNull)
			{
				_makeBounceDamage = new SpecialEffectList();
			}
			return _makeBounceDamage;
		case 71:
			if (_makeFightBackDamage == null && createIfNull)
			{
				_makeFightBackDamage = new SpecialEffectList();
			}
			return _makeFightBackDamage;
		case 333:
			if (_makeFatalDamage == null && createIfNull)
			{
				_makeFatalDamage = new SpecialEffectList();
			}
			return _makeFatalDamage;
		case 72:
			if (_makePoisonLevel == null && createIfNull)
			{
				_makePoisonLevel = new SpecialEffectList();
			}
			return _makePoisonLevel;
		case 73:
			if (_makePoisonValue == null && createIfNull)
			{
				_makePoisonValue = new SpecialEffectList();
			}
			return _makePoisonValue;
		case 233:
			if (_makePoisonResist == null && createIfNull)
			{
				_makePoisonResist = new SpecialEffectList();
			}
			return _makePoisonResist;
		case 246:
			if (_makePoisonTarget == null && createIfNull)
			{
				_makePoisonTarget = new SpecialEffectList();
			}
			return _makePoisonTarget;
		case 74:
			if (_attackerHitOdds == null && createIfNull)
			{
				_attackerHitOdds = new SpecialEffectList();
			}
			return _attackerHitOdds;
		case 75:
			if (_attackerFightBackHitOdds == null && createIfNull)
			{
				_attackerFightBackHitOdds = new SpecialEffectList();
			}
			return _attackerFightBackHitOdds;
		case 76:
			if (_attackerPursueOdds == null && createIfNull)
			{
				_attackerPursueOdds = new SpecialEffectList();
			}
			return _attackerPursueOdds;
		case 77:
			if (_causedInjuryChangeToOld == null && createIfNull)
			{
				_causedInjuryChangeToOld = new SpecialEffectList();
			}
			return _causedInjuryChangeToOld;
		case 78:
			if (_causedPoisonChangeToOld == null && createIfNull)
			{
				_causedPoisonChangeToOld = new SpecialEffectList();
			}
			return _causedPoisonChangeToOld;
		case 335:
			if (_causedInjuryChangeToOldOdds == null && createIfNull)
			{
				_causedInjuryChangeToOldOdds = new SpecialEffectList();
			}
			return _causedInjuryChangeToOldOdds;
		case 345:
			if (_acceptInjuryChangeToOldOdds == null && createIfNull)
			{
				_acceptInjuryChangeToOldOdds = new SpecialEffectList();
			}
			return _acceptInjuryChangeToOldOdds;
		case 336:
			if (_causedMindChangeToInfiniteOdds == null && createIfNull)
			{
				_causedMindChangeToInfiniteOdds = new SpecialEffectList();
			}
			return _causedMindChangeToInfiniteOdds;
		case 287:
			if (_allMarkChangeToMind == null && createIfNull)
			{
				_allMarkChangeToMind = new SpecialEffectList();
			}
			return _allMarkChangeToMind;
		case 288:
			if (_mindMarkChangeToFatal == null && createIfNull)
			{
				_mindMarkChangeToFatal = new SpecialEffectList();
			}
			return _mindMarkChangeToFatal;
		case 330:
			if (_mindUpheavalTime == null && createIfNull)
			{
				_mindUpheavalTime = new SpecialEffectList();
			}
			return _mindUpheavalTime;
		case 325:
			if (_makeDamageCanReduce == null && createIfNull)
			{
				_makeDamageCanReduce = new SpecialEffectList();
			}
			return _makeDamageCanReduce;
		case 280:
			if (_ignoreArmor == null && createIfNull)
			{
				_ignoreArmor = new SpecialEffectList();
			}
			return _ignoreArmor;
		case 79:
			if (_makeDamageType == null && createIfNull)
			{
				_makeDamageType = new SpecialEffectList();
			}
			return _makeDamageType;
		case 80:
			if (_canMakeInjuryToNoInjuryPart == null && createIfNull)
			{
				_canMakeInjuryToNoInjuryPart = new SpecialEffectList();
			}
			return _canMakeInjuryToNoInjuryPart;
		case 81:
			if (_makePoisonType == null && createIfNull)
			{
				_makePoisonType = new SpecialEffectList();
			}
			return _makePoisonType;
		case 82:
			if (_normalAttackWeapon == null && createIfNull)
			{
				_normalAttackWeapon = new SpecialEffectList();
			}
			return _normalAttackWeapon;
		case 83:
			if (_normalAttackTrick == null && createIfNull)
			{
				_normalAttackTrick = new SpecialEffectList();
			}
			return _normalAttackTrick;
		case 326:
			if (_normalAttackGetTrickCount == null && createIfNull)
			{
				_normalAttackGetTrickCount = new SpecialEffectList();
			}
			return _normalAttackGetTrickCount;
		case 282:
			if (_normalAttackPrepareFrame == null && createIfNull)
			{
				_normalAttackPrepareFrame = new SpecialEffectList();
			}
			return _normalAttackPrepareFrame;
		case 319:
			if (_normalAttackRecoveryFrame == null && createIfNull)
			{
				_normalAttackRecoveryFrame = new SpecialEffectList();
			}
			return _normalAttackRecoveryFrame;
		case 315:
			if (_unlockSpeed == null && createIfNull)
			{
				_unlockSpeed = new SpecialEffectList();
			}
			return _unlockSpeed;
		case 305:
			if (_normalAttackChangeToUnlockAttack == null && createIfNull)
			{
				_normalAttackChangeToUnlockAttack = new SpecialEffectList();
			}
			return _normalAttackChangeToUnlockAttack;
		case 310:
			if (_rawCreateEffectList == null && createIfNull)
			{
				_rawCreateEffectList = new SpecialEffectList();
			}
			return _rawCreateEffectList;
		case 84:
			if (_extraFlawCount == null && createIfNull)
			{
				_extraFlawCount = new SpecialEffectList();
			}
			return _extraFlawCount;
		case 316:
			if (_flawBonusFactor == null && createIfNull)
			{
				_flawBonusFactor = new SpecialEffectList();
			}
			return _flawBonusFactor;
		case 85:
			if (_attackCanBounce == null && createIfNull)
			{
				_attackCanBounce = new SpecialEffectList();
			}
			return _attackCanBounce;
		case 86:
			if (_attackCanFightBack == null && createIfNull)
			{
				_attackCanFightBack = new SpecialEffectList();
			}
			return _attackCanFightBack;
		case 252:
			if (_attackCanPursue == null && createIfNull)
			{
				_attackCanPursue = new SpecialEffectList();
			}
			return _attackCanPursue;
		case 87:
			if (_makeFightBackInjuryMark == null && createIfNull)
			{
				_makeFightBackInjuryMark = new SpecialEffectList();
			}
			return _makeFightBackInjuryMark;
		case 88:
			if (_legSkillUseShoes == null && createIfNull)
			{
				_legSkillUseShoes = new SpecialEffectList();
			}
			return _legSkillUseShoes;
		case 321:
			if (_attackerDirectFinalDamageValue == null && createIfNull)
			{
				_attackerDirectFinalDamageValue = new SpecialEffectList();
			}
			return _attackerDirectFinalDamageValue;
		case 89:
			if (_attackerFinalDamageValue == null && createIfNull)
			{
				_attackerFinalDamageValue = new SpecialEffectList();
			}
			return _attackerFinalDamageValue;
		case 90:
			if (_defenderHitStrength == null && createIfNull)
			{
				_defenderHitStrength = new SpecialEffectList();
			}
			return _defenderHitStrength;
		case 91:
			if (_defenderHitTechnique == null && createIfNull)
			{
				_defenderHitTechnique = new SpecialEffectList();
			}
			return _defenderHitTechnique;
		case 92:
			if (_defenderHitSpeed == null && createIfNull)
			{
				_defenderHitSpeed = new SpecialEffectList();
			}
			return _defenderHitSpeed;
		case 93:
			if (_defenderHitMind == null && createIfNull)
			{
				_defenderHitMind = new SpecialEffectList();
			}
			return _defenderHitMind;
		case 94:
			if (_defenderAvoidStrength == null && createIfNull)
			{
				_defenderAvoidStrength = new SpecialEffectList();
			}
			return _defenderAvoidStrength;
		case 95:
			if (_defenderAvoidTechnique == null && createIfNull)
			{
				_defenderAvoidTechnique = new SpecialEffectList();
			}
			return _defenderAvoidTechnique;
		case 96:
			if (_defenderAvoidSpeed == null && createIfNull)
			{
				_defenderAvoidSpeed = new SpecialEffectList();
			}
			return _defenderAvoidSpeed;
		case 97:
			if (_defenderAvoidMind == null && createIfNull)
			{
				_defenderAvoidMind = new SpecialEffectList();
			}
			return _defenderAvoidMind;
		case 98:
			if (_defenderPenetrateOuter == null && createIfNull)
			{
				_defenderPenetrateOuter = new SpecialEffectList();
			}
			return _defenderPenetrateOuter;
		case 99:
			if (_defenderPenetrateInner == null && createIfNull)
			{
				_defenderPenetrateInner = new SpecialEffectList();
			}
			return _defenderPenetrateInner;
		case 100:
			if (_defenderPenetrateResistOuter == null && createIfNull)
			{
				_defenderPenetrateResistOuter = new SpecialEffectList();
			}
			return _defenderPenetrateResistOuter;
		case 101:
			if (_defenderPenetrateResistInner == null && createIfNull)
			{
				_defenderPenetrateResistInner = new SpecialEffectList();
			}
			return _defenderPenetrateResistInner;
		case 342:
			if (_defenderCriticalOdds == null && createIfNull)
			{
				_defenderCriticalOdds = new SpecialEffectList();
			}
			return _defenderCriticalOdds;
		case 102:
			if (_acceptDirectDamage == null && createIfNull)
			{
				_acceptDirectDamage = new SpecialEffectList();
			}
			return _acceptDirectDamage;
		case 275:
			if (_acceptMindDamage == null && createIfNull)
			{
				_acceptMindDamage = new SpecialEffectList();
			}
			return _acceptMindDamage;
		case 103:
			if (_acceptBounceDamage == null && createIfNull)
			{
				_acceptBounceDamage = new SpecialEffectList();
			}
			return _acceptBounceDamage;
		case 104:
			if (_acceptFightBackDamage == null && createIfNull)
			{
				_acceptFightBackDamage = new SpecialEffectList();
			}
			return _acceptFightBackDamage;
		case 334:
			if (_acceptFatalDamage == null && createIfNull)
			{
				_acceptFatalDamage = new SpecialEffectList();
			}
			return _acceptFatalDamage;
		case 105:
			if (_acceptPoisonLevel == null && createIfNull)
			{
				_acceptPoisonLevel = new SpecialEffectList();
			}
			return _acceptPoisonLevel;
		case 106:
			if (_acceptPoisonValue == null && createIfNull)
			{
				_acceptPoisonValue = new SpecialEffectList();
			}
			return _acceptPoisonValue;
		case 232:
			if (_acceptPoisonResist == null && createIfNull)
			{
				_acceptPoisonResist = new SpecialEffectList();
			}
			return _acceptPoisonResist;
		case 247:
			if (_acceptPoisonTarget == null && createIfNull)
			{
				_acceptPoisonTarget = new SpecialEffectList();
			}
			return _acceptPoisonTarget;
		case 107:
			if (_defenderHitOdds == null && createIfNull)
			{
				_defenderHitOdds = new SpecialEffectList();
			}
			return _defenderHitOdds;
		case 108:
			if (_defenderFightBackHitOdds == null && createIfNull)
			{
				_defenderFightBackHitOdds = new SpecialEffectList();
			}
			return _defenderFightBackHitOdds;
		case 109:
			if (_defenderPursueOdds == null && createIfNull)
			{
				_defenderPursueOdds = new SpecialEffectList();
			}
			return _defenderPursueOdds;
		case 324:
			if (_acceptDamageCanAdd == null && createIfNull)
			{
				_acceptDamageCanAdd = new SpecialEffectList();
			}
			return _acceptDamageCanAdd;
		case 110:
			if (_acceptMaxInjuryCount == null && createIfNull)
			{
				_acceptMaxInjuryCount = new SpecialEffectList();
			}
			return _acceptMaxInjuryCount;
		case 111:
			if (_bouncePower == null && createIfNull)
			{
				_bouncePower = new SpecialEffectList();
			}
			return _bouncePower;
		case 112:
			if (_fightBackPower == null && createIfNull)
			{
				_fightBackPower = new SpecialEffectList();
			}
			return _fightBackPower;
		case 113:
			if (_directDamageInnerRatio == null && createIfNull)
			{
				_directDamageInnerRatio = new SpecialEffectList();
			}
			return _directDamageInnerRatio;
		case 318:
			if (_defenderDirectFinalDamageValue == null && createIfNull)
			{
				_defenderDirectFinalDamageValue = new SpecialEffectList();
			}
			return _defenderDirectFinalDamageValue;
		case 114:
			if (_defenderFinalDamageValue == null && createIfNull)
			{
				_defenderFinalDamageValue = new SpecialEffectList();
			}
			return _defenderFinalDamageValue;
		case 281:
			if (_unyieldingFallen == null && createIfNull)
			{
				_unyieldingFallen = new SpecialEffectList();
			}
			return _unyieldingFallen;
		case 242:
			if (_outerInjuryImmunity == null && createIfNull)
			{
				_outerInjuryImmunity = new SpecialEffectList();
			}
			return _outerInjuryImmunity;
		case 241:
			if (_innerInjuryImmunity == null && createIfNull)
			{
				_innerInjuryImmunity = new SpecialEffectList();
			}
			return _innerInjuryImmunity;
		case 115:
			if (_directDamageValue == null && createIfNull)
			{
				_directDamageValue = new SpecialEffectList();
			}
			return _directDamageValue;
		case 116:
			if (_directInjuryMark == null && createIfNull)
			{
				_directInjuryMark = new SpecialEffectList();
			}
			return _directInjuryMark;
		case 117:
			if (_goneMadInjury == null && createIfNull)
			{
				_goneMadInjury = new SpecialEffectList();
			}
			return _goneMadInjury;
		case 320:
			if (_finalGoneMadInjury == null && createIfNull)
			{
				_finalGoneMadInjury = new SpecialEffectList();
			}
			return _finalGoneMadInjury;
		case 118:
			if (_healInjurySpeed == null && createIfNull)
			{
				_healInjurySpeed = new SpecialEffectList();
			}
			return _healInjurySpeed;
		case 119:
			if (_healInjuryBuff == null && createIfNull)
			{
				_healInjuryBuff = new SpecialEffectList();
			}
			return _healInjuryBuff;
		case 120:
			if (_healInjuryDebuff == null && createIfNull)
			{
				_healInjuryDebuff = new SpecialEffectList();
			}
			return _healInjuryDebuff;
		case 328:
			if (_healInjuryWithFatalRequireAttainment == null && createIfNull)
			{
				_healInjuryWithFatalRequireAttainment = new SpecialEffectList();
			}
			return _healInjuryWithFatalRequireAttainment;
		case 121:
			if (_healPoisonSpeed == null && createIfNull)
			{
				_healPoisonSpeed = new SpecialEffectList();
			}
			return _healPoisonSpeed;
		case 122:
			if (_healPoisonBuff == null && createIfNull)
			{
				_healPoisonBuff = new SpecialEffectList();
			}
			return _healPoisonBuff;
		case 123:
			if (_healPoisonDebuff == null && createIfNull)
			{
				_healPoisonDebuff = new SpecialEffectList();
			}
			return _healPoisonDebuff;
		case 260:
			if (_medicineEffect == null && createIfNull)
			{
				_medicineEffect = new SpecialEffectList();
			}
			return _medicineEffect;
		case 314:
			if (_healFlawSpeed == null && createIfNull)
			{
				_healFlawSpeed = new SpecialEffectList();
			}
			return _healFlawSpeed;
		case 299:
			if (_healAcupointSpeed == null && createIfNull)
			{
				_healAcupointSpeed = new SpecialEffectList();
			}
			return _healAcupointSpeed;
		case 124:
			if (_fleeSpeed == null && createIfNull)
			{
				_fleeSpeed = new SpecialEffectList();
			}
			return _fleeSpeed;
		case 125:
			if (_maxFlawCount == null && createIfNull)
			{
				_maxFlawCount = new SpecialEffectList();
			}
			return _maxFlawCount;
		case 126:
			if (_canAddFlaw == null && createIfNull)
			{
				_canAddFlaw = new SpecialEffectList();
			}
			return _canAddFlaw;
		case 127:
			if (_flawLevel == null && createIfNull)
			{
				_flawLevel = new SpecialEffectList();
			}
			return _flawLevel;
		case 128:
			if (_flawLevelCanReduce == null && createIfNull)
			{
				_flawLevelCanReduce = new SpecialEffectList();
			}
			return _flawLevelCanReduce;
		case 129:
			if (_flawCount == null && createIfNull)
			{
				_flawCount = new SpecialEffectList();
			}
			return _flawCount;
		case 130:
			if (_maxAcupointCount == null && createIfNull)
			{
				_maxAcupointCount = new SpecialEffectList();
			}
			return _maxAcupointCount;
		case 131:
			if (_canAddAcupoint == null && createIfNull)
			{
				_canAddAcupoint = new SpecialEffectList();
			}
			return _canAddAcupoint;
		case 132:
			if (_acupointLevel == null && createIfNull)
			{
				_acupointLevel = new SpecialEffectList();
			}
			return _acupointLevel;
		case 133:
			if (_acupointLevelCanReduce == null && createIfNull)
			{
				_acupointLevelCanReduce = new SpecialEffectList();
			}
			return _acupointLevelCanReduce;
		case 134:
			if (_acupointCount == null && createIfNull)
			{
				_acupointCount = new SpecialEffectList();
			}
			return _acupointCount;
		case 135:
			if (_addNeiliAllocation == null && createIfNull)
			{
				_addNeiliAllocation = new SpecialEffectList();
			}
			return _addNeiliAllocation;
		case 136:
			if (_costNeiliAllocation == null && createIfNull)
			{
				_costNeiliAllocation = new SpecialEffectList();
			}
			return _costNeiliAllocation;
		case 137:
			if (_canChangeNeiliAllocation == null && createIfNull)
			{
				_canChangeNeiliAllocation = new SpecialEffectList();
			}
			return _canChangeNeiliAllocation;
		case 138:
			if (_canGetTrick == null && createIfNull)
			{
				_canGetTrick = new SpecialEffectList();
			}
			return _canGetTrick;
		case 139:
			if (_getTrickType == null && createIfNull)
			{
				_getTrickType = new SpecialEffectList();
			}
			return _getTrickType;
		case 140:
			if (_attackBodyPart == null && createIfNull)
			{
				_attackBodyPart = new SpecialEffectList();
			}
			return _attackBodyPart;
		case 306:
			if (_attackBodyPartOdds == null && createIfNull)
			{
				_attackBodyPartOdds = new SpecialEffectList();
			}
			return _attackBodyPartOdds;
		case 141:
			if (_weaponEquipAttack == null && createIfNull)
			{
				_weaponEquipAttack = new SpecialEffectList();
			}
			return _weaponEquipAttack;
		case 142:
			if (_weaponEquipDefense == null && createIfNull)
			{
				_weaponEquipDefense = new SpecialEffectList();
			}
			return _weaponEquipDefense;
		case 143:
			if (_armorEquipAttack == null && createIfNull)
			{
				_armorEquipAttack = new SpecialEffectList();
			}
			return _armorEquipAttack;
		case 144:
			if (_armorEquipDefense == null && createIfNull)
			{
				_armorEquipDefense = new SpecialEffectList();
			}
			return _armorEquipDefense;
		case 309:
			if (_equipmentWeight == null && createIfNull)
			{
				_equipmentWeight = new SpecialEffectList();
			}
			return _equipmentWeight;
		case 145:
			if (_attackRangeForward == null && createIfNull)
			{
				_attackRangeForward = new SpecialEffectList();
			}
			return _attackRangeForward;
		case 146:
			if (_attackRangeBackward == null && createIfNull)
			{
				_attackRangeBackward = new SpecialEffectList();
			}
			return _attackRangeBackward;
		case 272:
			if (_attackRangeMaxAcupoint == null && createIfNull)
			{
				_attackRangeMaxAcupoint = new SpecialEffectList();
			}
			return _attackRangeMaxAcupoint;
		case 148:
			if (_canForcedMove == null && createIfNull)
			{
				_canForcedMove = new SpecialEffectList();
			}
			return _canForcedMove;
		case 149:
			if (_mobilityCanBeRemoved == null && createIfNull)
			{
				_mobilityCanBeRemoved = new SpecialEffectList();
			}
			return _mobilityCanBeRemoved;
		case 150:
			if (_mobilityCostByEffect == null && createIfNull)
			{
				_mobilityCostByEffect = new SpecialEffectList();
			}
			return _mobilityCostByEffect;
		case 254:
			if (_stanceCostByEffect == null && createIfNull)
			{
				_stanceCostByEffect = new SpecialEffectList();
			}
			return _stanceCostByEffect;
		case 255:
			if (_breathCostByEffect == null && createIfNull)
			{
				_breathCostByEffect = new SpecialEffectList();
			}
			return _breathCostByEffect;
		case 147:
			if (_moveCanBeStopped == null && createIfNull)
			{
				_moveCanBeStopped = new SpecialEffectList();
			}
			return _moveCanBeStopped;
		case 151:
			if (_moveDistance == null && createIfNull)
			{
				_moveDistance = new SpecialEffectList();
			}
			return _moveDistance;
		case 244:
			if (_lockDistance == null && createIfNull)
			{
				_lockDistance = new SpecialEffectList();
			}
			return _lockDistance;
		case 152:
			if (_jumpPrepareFrame == null && createIfNull)
			{
				_jumpPrepareFrame = new SpecialEffectList();
			}
			return _jumpPrepareFrame;
		case 153:
			if (_bounceInjuryMark == null && createIfNull)
			{
				_bounceInjuryMark = new SpecialEffectList();
			}
			return _bounceInjuryMark;
		case 154:
			if (_skillHasCost == null && createIfNull)
			{
				_skillHasCost = new SpecialEffectList();
			}
			return _skillHasCost;
		case 155:
			if (_combatStateEffect == null && createIfNull)
			{
				_combatStateEffect = new SpecialEffectList();
			}
			return _combatStateEffect;
		case 156:
			if (_changeNeedUseSkill == null && createIfNull)
			{
				_changeNeedUseSkill = new SpecialEffectList();
			}
			return _changeNeedUseSkill;
		case 157:
			if (_changeDistanceIsMove == null && createIfNull)
			{
				_changeDistanceIsMove = new SpecialEffectList();
			}
			return _changeDistanceIsMove;
		case 158:
			if (_replaceCharHit == null && createIfNull)
			{
				_replaceCharHit = new SpecialEffectList();
			}
			return _replaceCharHit;
		case 159:
			if (_canAddPoison == null && createIfNull)
			{
				_canAddPoison = new SpecialEffectList();
			}
			return _canAddPoison;
		case 160:
			if (_canReducePoison == null && createIfNull)
			{
				_canReducePoison = new SpecialEffectList();
			}
			return _canReducePoison;
		case 161:
			if (_reducePoisonValue == null && createIfNull)
			{
				_reducePoisonValue = new SpecialEffectList();
			}
			return _reducePoisonValue;
		case 162:
			if (_poisonCanAffect == null && createIfNull)
			{
				_poisonCanAffect = new SpecialEffectList();
			}
			return _poisonCanAffect;
		case 163:
			if (_poisonAffectCount == null && createIfNull)
			{
				_poisonAffectCount = new SpecialEffectList();
			}
			return _poisonAffectCount;
		case 243:
			if (_poisonAffectThreshold == null && createIfNull)
			{
				_poisonAffectThreshold = new SpecialEffectList();
			}
			return _poisonAffectThreshold;
		case 258:
			if (_poisonAffectProduceValue == null && createIfNull)
			{
				_poisonAffectProduceValue = new SpecialEffectList();
			}
			return _poisonAffectProduceValue;
		case 271:
			if (_mixPoisonInfinityAffect == null && createIfNull)
			{
				_mixPoisonInfinityAffect = new SpecialEffectList();
			}
			return _mixPoisonInfinityAffect;
		case 343:
			if (_mixPoisonCanAffectCount == null && createIfNull)
			{
				_mixPoisonCanAffectCount = new SpecialEffectList();
			}
			return _mixPoisonCanAffectCount;
		case 164:
			if (_costTricks == null && createIfNull)
			{
				_costTricks = new SpecialEffectList();
			}
			return _costTricks;
		case 311:
			if (_jiTrickAsWeaponTrickCount == null && createIfNull)
			{
				_jiTrickAsWeaponTrickCount = new SpecialEffectList();
			}
			return _jiTrickAsWeaponTrickCount;
		case 312:
			if (_uselessTrickAsJiTrickCount == null && createIfNull)
			{
				_uselessTrickAsJiTrickCount = new SpecialEffectList();
			}
			return _uselessTrickAsJiTrickCount;
		case 337:
			if (_hitReduceDurability == null && createIfNull)
			{
				_hitReduceDurability = new SpecialEffectList();
			}
			return _hitReduceDurability;
		case 307:
			if (_changeDurability == null && createIfNull)
			{
				_changeDurability = new SpecialEffectList();
			}
			return _changeDurability;
		case 165:
			if (_jumpMoveDistance == null && createIfNull)
			{
				_jumpMoveDistance = new SpecialEffectList();
			}
			return _jumpMoveDistance;
		case 166:
			if (_combatStateToAdd == null && createIfNull)
			{
				_combatStateToAdd = new SpecialEffectList();
			}
			return _combatStateToAdd;
		case 167:
			if (_combatStatePower == null && createIfNull)
			{
				_combatStatePower = new SpecialEffectList();
			}
			return _combatStatePower;
		case 168:
			if (_breakBodyPartInjuryCount == null && createIfNull)
			{
				_breakBodyPartInjuryCount = new SpecialEffectList();
			}
			return _breakBodyPartInjuryCount;
		case 169:
			if (_bodyPartIsBroken == null && createIfNull)
			{
				_bodyPartIsBroken = new SpecialEffectList();
			}
			return _bodyPartIsBroken;
		case 170:
			if (_maxTrickCount == null && createIfNull)
			{
				_maxTrickCount = new SpecialEffectList();
			}
			return _maxTrickCount;
		case 171:
			if (_maxBreathPercent == null && createIfNull)
			{
				_maxBreathPercent = new SpecialEffectList();
			}
			return _maxBreathPercent;
		case 172:
			if (_maxStancePercent == null && createIfNull)
			{
				_maxStancePercent = new SpecialEffectList();
			}
			return _maxStancePercent;
		case 273:
			if (_maxMobilityPercent == null && createIfNull)
			{
				_maxMobilityPercent = new SpecialEffectList();
			}
			return _maxMobilityPercent;
		case 173:
			if (_extraBreathPercent == null && createIfNull)
			{
				_extraBreathPercent = new SpecialEffectList();
			}
			return _extraBreathPercent;
		case 174:
			if (_extraStancePercent == null && createIfNull)
			{
				_extraStancePercent = new SpecialEffectList();
			}
			return _extraStancePercent;
		case 175:
			if (_moveCostMobility == null && createIfNull)
			{
				_moveCostMobility = new SpecialEffectList();
			}
			return _moveCostMobility;
		case 176:
			if (_defendSkillKeepTime == null && createIfNull)
			{
				_defendSkillKeepTime = new SpecialEffectList();
			}
			return _defendSkillKeepTime;
		case 177:
			if (_bounceRange == null && createIfNull)
			{
				_bounceRange = new SpecialEffectList();
			}
			return _bounceRange;
		case 178:
			if (_mindMarkKeepTime == null && createIfNull)
			{
				_mindMarkKeepTime = new SpecialEffectList();
			}
			return _mindMarkKeepTime;
		case 249:
			if (_mindMarkCount == null && createIfNull)
			{
				_mindMarkCount = new SpecialEffectList();
			}
			return _mindMarkCount;
		case 179:
			if (_skillMobilityCostPerFrame == null && createIfNull)
			{
				_skillMobilityCostPerFrame = new SpecialEffectList();
			}
			return _skillMobilityCostPerFrame;
		case 180:
			if (_canAddWug == null && createIfNull)
			{
				_canAddWug = new SpecialEffectList();
			}
			return _canAddWug;
		case 181:
			if (_hasGodWeaponBuff == null && createIfNull)
			{
				_hasGodWeaponBuff = new SpecialEffectList();
			}
			return _hasGodWeaponBuff;
		case 182:
			if (_hasGodArmorBuff == null && createIfNull)
			{
				_hasGodArmorBuff = new SpecialEffectList();
			}
			return _hasGodArmorBuff;
		case 183:
			if (_teammateCmdRequireGenerateValue == null && createIfNull)
			{
				_teammateCmdRequireGenerateValue = new SpecialEffectList();
			}
			return _teammateCmdRequireGenerateValue;
		case 184:
			if (_teammateCmdEffect == null && createIfNull)
			{
				_teammateCmdEffect = new SpecialEffectList();
			}
			return _teammateCmdEffect;
		case 270:
			if (_teammateCmdCanUse == null && createIfNull)
			{
				_teammateCmdCanUse = new SpecialEffectList();
			}
			return _teammateCmdCanUse;
		case 185:
			if (_flawRecoverSpeed == null && createIfNull)
			{
				_flawRecoverSpeed = new SpecialEffectList();
			}
			return _flawRecoverSpeed;
		case 186:
			if (_acupointRecoverSpeed == null && createIfNull)
			{
				_acupointRecoverSpeed = new SpecialEffectList();
			}
			return _acupointRecoverSpeed;
		case 187:
			if (_mindMarkRecoverSpeed == null && createIfNull)
			{
				_mindMarkRecoverSpeed = new SpecialEffectList();
			}
			return _mindMarkRecoverSpeed;
		case 188:
			if (_injuryAutoHealSpeed == null && createIfNull)
			{
				_injuryAutoHealSpeed = new SpecialEffectList();
			}
			return _injuryAutoHealSpeed;
		case 189:
			if (_canRecoverBreath == null && createIfNull)
			{
				_canRecoverBreath = new SpecialEffectList();
			}
			return _canRecoverBreath;
		case 190:
			if (_canRecoverStance == null && createIfNull)
			{
				_canRecoverStance = new SpecialEffectList();
			}
			return _canRecoverStance;
		case 191:
			if (_fatalDamageValue == null && createIfNull)
			{
				_fatalDamageValue = new SpecialEffectList();
			}
			return _fatalDamageValue;
		case 293:
			if (_wugFatalDamageValue == null && createIfNull)
			{
				_wugFatalDamageValue = new SpecialEffectList();
			}
			return _wugFatalDamageValue;
		case 192:
			if (_fatalDamageMarkCount == null && createIfNull)
			{
				_fatalDamageMarkCount = new SpecialEffectList();
			}
			return _fatalDamageMarkCount;
		case 303:
			if (_finalFatalDamageMarkCount == null && createIfNull)
			{
				_finalFatalDamageMarkCount = new SpecialEffectList();
			}
			return _finalFatalDamageMarkCount;
		case 193:
			if (_canFightBackDuringPrepareSkill == null && createIfNull)
			{
				_canFightBackDuringPrepareSkill = new SpecialEffectList();
			}
			return _canFightBackDuringPrepareSkill;
		case 340:
			if (_canFightBackOutOfAttackRange == null && createIfNull)
			{
				_canFightBackOutOfAttackRange = new SpecialEffectList();
			}
			return _canFightBackOutOfAttackRange;
		case 250:
			if (_canFightBackWithHit == null && createIfNull)
			{
				_canFightBackWithHit = new SpecialEffectList();
			}
			return _canFightBackWithHit;
		case 194:
			if (_skillPrepareSpeed == null && createIfNull)
			{
				_skillPrepareSpeed = new SpecialEffectList();
			}
			return _skillPrepareSpeed;
		case 195:
			if (_breathRecoverSpeed == null && createIfNull)
			{
				_breathRecoverSpeed = new SpecialEffectList();
			}
			return _breathRecoverSpeed;
		case 196:
			if (_stanceRecoverSpeed == null && createIfNull)
			{
				_stanceRecoverSpeed = new SpecialEffectList();
			}
			return _stanceRecoverSpeed;
		case 197:
			if (_mobilityRecoverSpeed == null && createIfNull)
			{
				_mobilityRecoverSpeed = new SpecialEffectList();
			}
			return _mobilityRecoverSpeed;
		case 300:
			if (_maxChangeTrickCount == null && createIfNull)
			{
				_maxChangeTrickCount = new SpecialEffectList();
			}
			return _maxChangeTrickCount;
		case 198:
			if (_changeTrickProgressAddValue == null && createIfNull)
			{
				_changeTrickProgressAddValue = new SpecialEffectList();
			}
			return _changeTrickProgressAddValue;
		case 286:
			if (_agileSkillCanAffect == null && createIfNull)
			{
				_agileSkillCanAffect = new SpecialEffectList();
			}
			return _agileSkillCanAffect;
		case 284:
			if (_defendSkillCanAffect == null && createIfNull)
			{
				_defendSkillCanAffect = new SpecialEffectList();
			}
			return _defendSkillCanAffect;
		case 285:
			if (_assistSkillCanAffect == null && createIfNull)
			{
				_assistSkillCanAffect = new SpecialEffectList();
			}
			return _assistSkillCanAffect;
		case 199:
			if (_power == null && createIfNull)
			{
				_power = new SpecialEffectList();
			}
			return _power;
		case 200:
			if (_maxPower == null && createIfNull)
			{
				_maxPower = new SpecialEffectList();
			}
			return _maxPower;
		case 201:
			if (_powerCanReduce == null && createIfNull)
			{
				_powerCanReduce = new SpecialEffectList();
			}
			return _powerCanReduce;
		case 256:
			if (_powerAddRatio == null && createIfNull)
			{
				_powerAddRatio = new SpecialEffectList();
			}
			return _powerAddRatio;
		case 257:
			if (_powerReduceRatio == null && createIfNull)
			{
				_powerReduceRatio = new SpecialEffectList();
			}
			return _powerReduceRatio;
		case 291:
			if (_powerEffectReverse == null && createIfNull)
			{
				_powerEffectReverse = new SpecialEffectList();
			}
			return _powerEffectReverse;
		case 202:
			if (_useRequirement == null && createIfNull)
			{
				_useRequirement = new SpecialEffectList();
			}
			return _useRequirement;
		case 203:
			if (_currInnerRatio == null && createIfNull)
			{
				_currInnerRatio = new SpecialEffectList();
			}
			return _currInnerRatio;
		case 204:
			if (_costBreathAndStance == null && createIfNull)
			{
				_costBreathAndStance = new SpecialEffectList();
			}
			return _costBreathAndStance;
		case 205:
			if (_costBreath == null && createIfNull)
			{
				_costBreath = new SpecialEffectList();
			}
			return _costBreath;
		case 206:
			if (_costStance == null && createIfNull)
			{
				_costStance = new SpecialEffectList();
			}
			return _costStance;
		case 207:
			if (_costMobility == null && createIfNull)
			{
				_costMobility = new SpecialEffectList();
			}
			return _costMobility;
		case 208:
			if (_skillCostTricks == null && createIfNull)
			{
				_skillCostTricks = new SpecialEffectList();
			}
			return _skillCostTricks;
		case 279:
			if (_canCostEnemyUsableTricks == null && createIfNull)
			{
				_canCostEnemyUsableTricks = new SpecialEffectList();
			}
			return _canCostEnemyUsableTricks;
		case 283:
			if (_canCostUselessTricks == null && createIfNull)
			{
				_canCostUselessTricks = new SpecialEffectList();
			}
			return _canCostUselessTricks;
		case 317:
			if (_canCostShaTricks == null && createIfNull)
			{
				_canCostShaTricks = new SpecialEffectList();
			}
			return _canCostShaTricks;
		case 209:
			if (_effectDirection == null && createIfNull)
			{
				_effectDirection = new SpecialEffectList();
			}
			return _effectDirection;
		case 210:
			if (_effectDirectionCanChange == null && createIfNull)
			{
				_effectDirectionCanChange = new SpecialEffectList();
			}
			return _effectDirectionCanChange;
		case 211:
			if (_gridCost == null && createIfNull)
			{
				_gridCost = new SpecialEffectList();
			}
			return _gridCost;
		case 212:
			if (_prepareTotalProgress == null && createIfNull)
			{
				_prepareTotalProgress = new SpecialEffectList();
			}
			return _prepareTotalProgress;
		case 213:
			if (_specificGridCount == null && createIfNull)
			{
				_specificGridCount = new SpecialEffectList();
			}
			return _specificGridCount;
		case 214:
			if (_genericGridCount == null && createIfNull)
			{
				_genericGridCount = new SpecialEffectList();
			}
			return _genericGridCount;
		case 234:
			if (_canCriticalHit == null && createIfNull)
			{
				_canCriticalHit = new SpecialEffectList();
			}
			return _canCriticalHit;
		case 339:
			if (_criticalDamage == null && createIfNull)
			{
				_criticalDamage = new SpecialEffectList();
			}
			return _criticalDamage;
		case 248:
			if (_certainCriticalHit == null && createIfNull)
			{
				_certainCriticalHit = new SpecialEffectList();
			}
			return _certainCriticalHit;
		case 251:
			if (_inevitableHit == null && createIfNull)
			{
				_inevitableHit = new SpecialEffectList();
			}
			return _inevitableHit;
		case 290:
			if (_inevitableAvoid == null && createIfNull)
			{
				_inevitableAvoid = new SpecialEffectList();
			}
			return _inevitableAvoid;
		case 215:
			if (_canInterrupt == null && createIfNull)
			{
				_canInterrupt = new SpecialEffectList();
			}
			return _canInterrupt;
		case 216:
			if (_interruptOdds == null && createIfNull)
			{
				_interruptOdds = new SpecialEffectList();
			}
			return _interruptOdds;
		case 217:
			if (_canSilence == null && createIfNull)
			{
				_canSilence = new SpecialEffectList();
			}
			return _canSilence;
		case 218:
			if (_silenceOdds == null && createIfNull)
			{
				_silenceOdds = new SpecialEffectList();
			}
			return _silenceOdds;
		case 264:
			if (_silenceFrame == null && createIfNull)
			{
				_silenceFrame = new SpecialEffectList();
			}
			return _silenceFrame;
		case 263:
			if (_weaponSilenceFrame == null && createIfNull)
			{
				_weaponSilenceFrame = new SpecialEffectList();
			}
			return _weaponSilenceFrame;
		case 219:
			if (_canCastWithBrokenBodyPart == null && createIfNull)
			{
				_canCastWithBrokenBodyPart = new SpecialEffectList();
			}
			return _canCastWithBrokenBodyPart;
		case 220:
			if (_addPowerCanBeRemoved == null && createIfNull)
			{
				_addPowerCanBeRemoved = new SpecialEffectList();
			}
			return _addPowerCanBeRemoved;
		case 221:
			if (_skillType == null && createIfNull)
			{
				_skillType = new SpecialEffectList();
			}
			return _skillType;
		case 222:
			if (_effectCountCanChange == null && createIfNull)
			{
				_effectCountCanChange = new SpecialEffectList();
			}
			return _effectCountCanChange;
		case 327:
			if (_stayEffectCountOnAddPhase == null && createIfNull)
			{
				_stayEffectCountOnAddPhase = new SpecialEffectList();
			}
			return _stayEffectCountOnAddPhase;
		case 289:
			if (_canCast == null && createIfNull)
			{
				_canCast = new SpecialEffectList();
			}
			return _canCast;
		case 223:
			if (_canCastInDefend == null && createIfNull)
			{
				_canCastInDefend = new SpecialEffectList();
			}
			return _canCastInDefend;
		case 224:
			if (_hitDistribution == null && createIfNull)
			{
				_hitDistribution = new SpecialEffectList();
			}
			return _hitDistribution;
		case 225:
			if (_canCastOnLackBreath == null && createIfNull)
			{
				_canCastOnLackBreath = new SpecialEffectList();
			}
			return _canCastOnLackBreath;
		case 226:
			if (_canCastOnLackStance == null && createIfNull)
			{
				_canCastOnLackStance = new SpecialEffectList();
			}
			return _canCastOnLackStance;
		case 301:
			if (_convertCostBreathAndStance == null && createIfNull)
			{
				_convertCostBreathAndStance = new SpecialEffectList();
			}
			return _convertCostBreathAndStance;
		case 227:
			if (_costBreathOnCast == null && createIfNull)
			{
				_costBreathOnCast = new SpecialEffectList();
			}
			return _costBreathOnCast;
		case 228:
			if (_costStanceOnCast == null && createIfNull)
			{
				_costStanceOnCast = new SpecialEffectList();
			}
			return _costStanceOnCast;
		case 229:
			if (_canUseMobilityAsBreath == null && createIfNull)
			{
				_canUseMobilityAsBreath = new SpecialEffectList();
			}
			return _canUseMobilityAsBreath;
		case 230:
			if (_canUseMobilityAsStance == null && createIfNull)
			{
				_canUseMobilityAsStance = new SpecialEffectList();
			}
			return _canUseMobilityAsStance;
		case 231:
			if (_castCostNeiliAllocation == null && createIfNull)
			{
				_castCostNeiliAllocation = new SpecialEffectList();
			}
			return _castCostNeiliAllocation;
		case 344:
			if (_castCostNeiliAllocationIsAbsorb == null && createIfNull)
			{
				_castCostNeiliAllocationIsAbsorb = new SpecialEffectList();
			}
			return _castCostNeiliAllocationIsAbsorb;
		case 235:
			if (_canCostNeiliAllocationEffect == null && createIfNull)
			{
				_canCostNeiliAllocationEffect = new SpecialEffectList();
			}
			return _canCostNeiliAllocationEffect;
		case 322:
			if (_canCostTrickDuringPreparingSkill == null && createIfNull)
			{
				_canCostTrickDuringPreparingSkill = new SpecialEffectList();
			}
			return _canCostTrickDuringPreparingSkill;
		case 323:
			if (_validItemList == null && createIfNull)
			{
				_validItemList = new SpecialEffectList();
			}
			return _validItemList;
		case 329:
			if (_useItemCostNoWisdom == null && createIfNull)
			{
				_useItemCostNoWisdom = new SpecialEffectList();
			}
			return _useItemCostNoWisdom;
		case 253:
			if (_combatSkillDataEffectList == null && createIfNull)
			{
				_combatSkillDataEffectList = new SpecialEffectList();
			}
			return _combatSkillDataEffectList;
		case 304:
			if (_combatSkillAiScorePower == null && createIfNull)
			{
				_combatSkillAiScorePower = new SpecialEffectList();
			}
			return _combatSkillAiScorePower;
		default:
			throw new Exception($"AffectedData filed with id {fieldId} not found");
		}
	}

	public void SetEffectList(DataContext context, ushort fieldId, SpecialEffectList effectList)
	{
		switch (fieldId)
		{
		case 1:
			SetMaxStrength(effectList, context);
			return;
		case 2:
			SetMaxDexterity(effectList, context);
			return;
		case 3:
			SetMaxConcentration(effectList, context);
			return;
		case 4:
			SetMaxVitality(effectList, context);
			return;
		case 5:
			SetMaxEnergy(effectList, context);
			return;
		case 6:
			SetMaxIntelligence(effectList, context);
			return;
		case 7:
			SetRecoveryOfStance(effectList, context);
			return;
		case 8:
			SetRecoveryOfBreath(effectList, context);
			return;
		case 9:
			SetMoveSpeed(effectList, context);
			return;
		case 10:
			SetRecoveryOfFlaw(effectList, context);
			return;
		case 11:
			SetCastSpeed(effectList, context);
			return;
		case 12:
			SetRecoveryOfBlockedAcupoint(effectList, context);
			return;
		case 13:
			SetWeaponSwitchSpeed(effectList, context);
			return;
		case 14:
			SetAttackSpeed(effectList, context);
			return;
		case 15:
			SetInnerRatio(effectList, context);
			return;
		case 16:
			SetRecoveryOfQiDisorder(effectList, context);
			return;
		case 17:
			SetMinorAttributeFixMaxValue(effectList, context);
			return;
		case 18:
			SetMinorAttributeFixMinValue(effectList, context);
			return;
		case 19:
			SetResistOfHotPoison(effectList, context);
			return;
		case 20:
			SetResistOfGloomyPoison(effectList, context);
			return;
		case 21:
			SetResistOfColdPoison(effectList, context);
			return;
		case 22:
			SetResistOfRedPoison(effectList, context);
			return;
		case 23:
			SetResistOfRottenPoison(effectList, context);
			return;
		case 24:
			SetResistOfIllusoryPoison(effectList, context);
			return;
		case 245:
			SetResistOfAllPoison(effectList, context);
			return;
		case 302:
			SetPersonalitiesAll(effectList, context);
			return;
		case 25:
			SetDisplayAge(effectList, context);
			return;
		case 26:
			SetNeiliProportionOfFiveElements(effectList, context);
			return;
		case 240:
			SetSkillAlsoAsFiveElements(effectList, context);
			return;
		case 27:
			SetWeaponMaxPower(effectList, context);
			return;
		case 28:
			SetWeaponUseRequirement(effectList, context);
			return;
		case 29:
			SetWeaponAttackRange(effectList, context);
			return;
		case 30:
			SetArmorMaxPower(effectList, context);
			return;
		case 31:
			SetArmorUseRequirement(effectList, context);
			return;
		case 313:
			SetEquipmentPower(effectList, context);
			return;
		case 278:
			SetIgnoreEquipmentOverload(effectList, context);
			return;
		case 308:
			SetEquipmentBonus(effectList, context);
			return;
		case 338:
			SetEquipmentMasteryAffectOdds(effectList, context);
			return;
		case 32:
			SetHitStrength(effectList, context);
			return;
		case 33:
			SetHitTechnique(effectList, context);
			return;
		case 34:
			SetHitSpeed(effectList, context);
			return;
		case 35:
			SetHitMind(effectList, context);
			return;
		case 276:
			SetHitAddByTempValue(effectList, context);
			return;
		case 36:
			SetHitCanChange(effectList, context);
			return;
		case 37:
			SetHitChangeEffectPercent(effectList, context);
			return;
		case 38:
			SetAvoidStrength(effectList, context);
			return;
		case 39:
			SetAvoidTechnique(effectList, context);
			return;
		case 40:
			SetAvoidSpeed(effectList, context);
			return;
		case 41:
			SetAvoidMind(effectList, context);
			return;
		case 277:
			SetAvoidAddByTempValue(effectList, context);
			return;
		case 42:
			SetAvoidCanChange(effectList, context);
			return;
		case 43:
			SetAvoidChangeEffectPercent(effectList, context);
			return;
		case 44:
			SetPenetrateOuter(effectList, context);
			return;
		case 45:
			SetPenetrateInner(effectList, context);
			return;
		case 46:
			SetPenetrateResistOuter(effectList, context);
			return;
		case 47:
			SetPenetrateResistInner(effectList, context);
			return;
		case 296:
			SetConsummateLevelBonus(effectList, context);
			return;
		case 236:
			SetConsummateLevelRelatedMainAttributesHitValues(effectList, context);
			return;
		case 237:
			SetConsummateLevelRelatedMainAttributesAvoidValues(effectList, context);
			return;
		case 238:
			SetConsummateLevelRelatedMainAttributesPenetrations(effectList, context);
			return;
		case 239:
			SetConsummateLevelRelatedMainAttributesPenetrationResists(effectList, context);
			return;
		case 48:
			SetNeiliAllocationAttack(effectList, context);
			return;
		case 49:
			SetNeiliAllocationAgile(effectList, context);
			return;
		case 50:
			SetNeiliAllocationDefense(effectList, context);
			return;
		case 51:
			SetNeiliAllocationAssist(effectList, context);
			return;
		case 52:
			SetHappiness(effectList, context);
			return;
		case 53:
			SetMaxHealth(effectList, context);
			return;
		case 54:
			SetHealthCost(effectList, context);
			return;
		case 55:
			SetMoveSpeedCanChange(effectList, context);
			return;
		case 266:
			SetGoneMadInAllBreak(effectList, context);
			return;
		case 261:
			SetXiangshuInfectionDelta(effectList, context);
			return;
		case 262:
			SetHealthDelta(effectList, context);
			return;
		case 269:
			SetHappinessDelta(effectList, context);
			return;
		case 265:
			SetCurrAgeDelta(effectList, context);
			return;
		case 297:
			SetNeiliDelta(effectList, context);
			return;
		case 267:
			SetMakeLoveRateOnMonthChange(effectList, context);
			return;
		case 295:
			SetTakeRevengeRateOnMonthChange(effectList, context);
			return;
		case 298:
			SetCanMakeLoveSpecialOnMonthChange(effectList, context);
			return;
		case 259:
			SetCanReadingOnMonthChange(effectList, context);
			return;
		case 268:
			SetCanAutoHealOnMonthChange(effectList, context);
			return;
		case 294:
			SetCanRecoverHealthOnMonthChange(effectList, context);
			return;
		case 292:
			SetFeatureBonusReverse(effectList, context);
			return;
		case 331:
			SetMakeHarmfulActionSuccessRate(effectList, context);
			return;
		case 332:
			SetAcceptHarmfulActionSuccessRate(effectList, context);
			return;
		case 56:
			SetAttackerHitStrength(effectList, context);
			return;
		case 57:
			SetAttackerHitTechnique(effectList, context);
			return;
		case 58:
			SetAttackerHitSpeed(effectList, context);
			return;
		case 59:
			SetAttackerHitMind(effectList, context);
			return;
		case 60:
			SetAttackerAvoidStrength(effectList, context);
			return;
		case 61:
			SetAttackerAvoidTechnique(effectList, context);
			return;
		case 62:
			SetAttackerAvoidSpeed(effectList, context);
			return;
		case 63:
			SetAttackerAvoidMind(effectList, context);
			return;
		case 64:
			SetAttackerPenetrateOuter(effectList, context);
			return;
		case 65:
			SetAttackerPenetrateInner(effectList, context);
			return;
		case 66:
			SetAttackerPenetrateResistOuter(effectList, context);
			return;
		case 67:
			SetAttackerPenetrateResistInner(effectList, context);
			return;
		case 341:
			SetAttackerCriticalOdds(effectList, context);
			return;
		case 68:
			SetAttackHitType(effectList, context);
			return;
		case 69:
			SetMakeDirectDamage(effectList, context);
			return;
		case 274:
			SetMakeMindDamage(effectList, context);
			return;
		case 70:
			SetMakeBounceDamage(effectList, context);
			return;
		case 71:
			SetMakeFightBackDamage(effectList, context);
			return;
		case 333:
			SetMakeFatalDamage(effectList, context);
			return;
		case 72:
			SetMakePoisonLevel(effectList, context);
			return;
		case 73:
			SetMakePoisonValue(effectList, context);
			return;
		case 233:
			SetMakePoisonResist(effectList, context);
			return;
		case 246:
			SetMakePoisonTarget(effectList, context);
			return;
		case 74:
			SetAttackerHitOdds(effectList, context);
			return;
		case 75:
			SetAttackerFightBackHitOdds(effectList, context);
			return;
		case 76:
			SetAttackerPursueOdds(effectList, context);
			return;
		case 77:
			SetCausedInjuryChangeToOld(effectList, context);
			return;
		case 78:
			SetCausedPoisonChangeToOld(effectList, context);
			return;
		case 335:
			SetCausedInjuryChangeToOldOdds(effectList, context);
			return;
		case 345:
			SetAcceptInjuryChangeToOldOdds(effectList, context);
			return;
		case 336:
			SetCausedMindChangeToInfiniteOdds(effectList, context);
			return;
		case 287:
			SetAllMarkChangeToMind(effectList, context);
			return;
		case 288:
			SetMindMarkChangeToFatal(effectList, context);
			return;
		case 330:
			SetMindUpheavalTime(effectList, context);
			return;
		case 325:
			SetMakeDamageCanReduce(effectList, context);
			return;
		case 280:
			SetIgnoreArmor(effectList, context);
			return;
		case 79:
			SetMakeDamageType(effectList, context);
			return;
		case 80:
			SetCanMakeInjuryToNoInjuryPart(effectList, context);
			return;
		case 81:
			SetMakePoisonType(effectList, context);
			return;
		case 82:
			SetNormalAttackWeapon(effectList, context);
			return;
		case 83:
			SetNormalAttackTrick(effectList, context);
			return;
		case 326:
			SetNormalAttackGetTrickCount(effectList, context);
			return;
		case 282:
			SetNormalAttackPrepareFrame(effectList, context);
			return;
		case 319:
			SetNormalAttackRecoveryFrame(effectList, context);
			return;
		case 315:
			SetUnlockSpeed(effectList, context);
			return;
		case 305:
			SetNormalAttackChangeToUnlockAttack(effectList, context);
			return;
		case 310:
			SetRawCreateEffectList(effectList, context);
			return;
		case 84:
			SetExtraFlawCount(effectList, context);
			return;
		case 316:
			SetFlawBonusFactor(effectList, context);
			return;
		case 85:
			SetAttackCanBounce(effectList, context);
			return;
		case 86:
			SetAttackCanFightBack(effectList, context);
			return;
		case 252:
			SetAttackCanPursue(effectList, context);
			return;
		case 87:
			SetMakeFightBackInjuryMark(effectList, context);
			return;
		case 88:
			SetLegSkillUseShoes(effectList, context);
			return;
		case 321:
			SetAttackerDirectFinalDamageValue(effectList, context);
			return;
		case 89:
			SetAttackerFinalDamageValue(effectList, context);
			return;
		case 90:
			SetDefenderHitStrength(effectList, context);
			return;
		case 91:
			SetDefenderHitTechnique(effectList, context);
			return;
		case 92:
			SetDefenderHitSpeed(effectList, context);
			return;
		case 93:
			SetDefenderHitMind(effectList, context);
			return;
		case 94:
			SetDefenderAvoidStrength(effectList, context);
			return;
		case 95:
			SetDefenderAvoidTechnique(effectList, context);
			return;
		case 96:
			SetDefenderAvoidSpeed(effectList, context);
			return;
		case 97:
			SetDefenderAvoidMind(effectList, context);
			return;
		case 98:
			SetDefenderPenetrateOuter(effectList, context);
			return;
		case 99:
			SetDefenderPenetrateInner(effectList, context);
			return;
		case 100:
			SetDefenderPenetrateResistOuter(effectList, context);
			return;
		case 101:
			SetDefenderPenetrateResistInner(effectList, context);
			return;
		case 342:
			SetDefenderCriticalOdds(effectList, context);
			return;
		case 102:
			SetAcceptDirectDamage(effectList, context);
			return;
		case 275:
			SetAcceptMindDamage(effectList, context);
			return;
		case 103:
			SetAcceptBounceDamage(effectList, context);
			return;
		case 104:
			SetAcceptFightBackDamage(effectList, context);
			return;
		case 334:
			SetAcceptFatalDamage(effectList, context);
			return;
		case 105:
			SetAcceptPoisonLevel(effectList, context);
			return;
		case 106:
			SetAcceptPoisonValue(effectList, context);
			return;
		case 232:
			SetAcceptPoisonResist(effectList, context);
			return;
		case 247:
			SetAcceptPoisonTarget(effectList, context);
			return;
		case 107:
			SetDefenderHitOdds(effectList, context);
			return;
		case 108:
			SetDefenderFightBackHitOdds(effectList, context);
			return;
		case 109:
			SetDefenderPursueOdds(effectList, context);
			return;
		case 324:
			SetAcceptDamageCanAdd(effectList, context);
			return;
		case 110:
			SetAcceptMaxInjuryCount(effectList, context);
			return;
		case 111:
			SetBouncePower(effectList, context);
			return;
		case 112:
			SetFightBackPower(effectList, context);
			return;
		case 113:
			SetDirectDamageInnerRatio(effectList, context);
			return;
		case 318:
			SetDefenderDirectFinalDamageValue(effectList, context);
			return;
		case 114:
			SetDefenderFinalDamageValue(effectList, context);
			return;
		case 281:
			SetUnyieldingFallen(effectList, context);
			return;
		case 242:
			SetOuterInjuryImmunity(effectList, context);
			return;
		case 241:
			SetInnerInjuryImmunity(effectList, context);
			return;
		case 115:
			SetDirectDamageValue(effectList, context);
			return;
		case 116:
			SetDirectInjuryMark(effectList, context);
			return;
		case 117:
			SetGoneMadInjury(effectList, context);
			return;
		case 320:
			SetFinalGoneMadInjury(effectList, context);
			return;
		case 118:
			SetHealInjurySpeed(effectList, context);
			return;
		case 119:
			SetHealInjuryBuff(effectList, context);
			return;
		case 120:
			SetHealInjuryDebuff(effectList, context);
			return;
		case 328:
			SetHealInjuryWithFatalRequireAttainment(effectList, context);
			return;
		case 121:
			SetHealPoisonSpeed(effectList, context);
			return;
		case 122:
			SetHealPoisonBuff(effectList, context);
			return;
		case 123:
			SetHealPoisonDebuff(effectList, context);
			return;
		case 260:
			SetMedicineEffect(effectList, context);
			return;
		case 314:
			SetHealFlawSpeed(effectList, context);
			return;
		case 299:
			SetHealAcupointSpeed(effectList, context);
			return;
		case 124:
			SetFleeSpeed(effectList, context);
			return;
		case 126:
			SetCanAddFlaw(effectList, context);
			return;
		case 127:
			SetFlawLevel(effectList, context);
			return;
		case 128:
			SetFlawLevelCanReduce(effectList, context);
			return;
		case 129:
			SetFlawCount(effectList, context);
			return;
		case 125:
			SetMaxFlawCount(effectList, context);
			return;
		case 130:
			SetMaxAcupointCount(effectList, context);
			return;
		case 131:
			SetCanAddAcupoint(effectList, context);
			return;
		case 132:
			SetAcupointLevel(effectList, context);
			return;
		case 133:
			SetAcupointLevelCanReduce(effectList, context);
			return;
		case 134:
			SetAcupointCount(effectList, context);
			return;
		case 135:
			SetAddNeiliAllocation(effectList, context);
			return;
		case 136:
			SetCostNeiliAllocation(effectList, context);
			return;
		case 137:
			SetCanChangeNeiliAllocation(effectList, context);
			return;
		case 138:
			SetCanGetTrick(effectList, context);
			return;
		case 139:
			SetGetTrickType(effectList, context);
			return;
		case 140:
			SetAttackBodyPart(effectList, context);
			return;
		case 306:
			SetAttackBodyPartOdds(effectList, context);
			return;
		case 141:
			SetWeaponEquipAttack(effectList, context);
			return;
		case 142:
			SetWeaponEquipDefense(effectList, context);
			return;
		case 143:
			SetArmorEquipAttack(effectList, context);
			return;
		case 144:
			SetArmorEquipDefense(effectList, context);
			return;
		case 309:
			SetEquipmentWeight(effectList, context);
			return;
		case 145:
			SetAttackRangeForward(effectList, context);
			return;
		case 146:
			SetAttackRangeBackward(effectList, context);
			return;
		case 272:
			SetAttackRangeMaxAcupoint(effectList, context);
			return;
		case 148:
			SetCanForcedMove(effectList, context);
			return;
		case 149:
			SetMobilityCanBeRemoved(effectList, context);
			return;
		case 150:
			SetMobilityCostByEffect(effectList, context);
			return;
		case 254:
			SetStanceCostByEffect(effectList, context);
			return;
		case 255:
			SetBreathCostByEffect(effectList, context);
			return;
		case 147:
			SetMoveCanBeStopped(effectList, context);
			return;
		case 151:
			SetMoveDistance(effectList, context);
			return;
		case 244:
			SetLockDistance(effectList, context);
			return;
		case 152:
			SetJumpPrepareFrame(effectList, context);
			return;
		case 153:
			SetBounceInjuryMark(effectList, context);
			return;
		case 154:
			SetSkillHasCost(effectList, context);
			return;
		case 155:
			SetCombatStateEffect(effectList, context);
			return;
		case 156:
			SetChangeNeedUseSkill(effectList, context);
			return;
		case 157:
			SetChangeDistanceIsMove(effectList, context);
			return;
		case 158:
			SetReplaceCharHit(effectList, context);
			return;
		case 159:
			SetCanAddPoison(effectList, context);
			return;
		case 160:
			SetCanReducePoison(effectList, context);
			return;
		case 161:
			SetReducePoisonValue(effectList, context);
			return;
		case 162:
			SetPoisonCanAffect(effectList, context);
			return;
		case 163:
			SetPoisonAffectCount(effectList, context);
			return;
		case 243:
			SetPoisonAffectThreshold(effectList, context);
			return;
		case 258:
			SetPoisonAffectProduceValue(effectList, context);
			return;
		case 271:
			SetMixPoisonInfinityAffect(effectList, context);
			return;
		case 343:
			SetMixPoisonCanAffectCount(effectList, context);
			return;
		case 164:
			SetCostTricks(effectList, context);
			return;
		case 311:
			SetJiTrickAsWeaponTrickCount(effectList, context);
			return;
		case 312:
			SetUselessTrickAsJiTrickCount(effectList, context);
			return;
		case 337:
			SetHitReduceDurability(effectList, context);
			return;
		case 307:
			SetChangeDurability(effectList, context);
			return;
		case 165:
			SetJumpMoveDistance(effectList, context);
			return;
		case 166:
			SetCombatStateToAdd(effectList, context);
			return;
		case 167:
			SetCombatStatePower(effectList, context);
			return;
		case 168:
			SetBreakBodyPartInjuryCount(effectList, context);
			return;
		case 169:
			SetBodyPartIsBroken(effectList, context);
			return;
		case 170:
			SetMaxTrickCount(effectList, context);
			return;
		case 171:
			SetMaxBreathPercent(effectList, context);
			return;
		case 172:
			SetMaxStancePercent(effectList, context);
			return;
		case 273:
			SetMaxMobilityPercent(effectList, context);
			return;
		case 173:
			SetExtraBreathPercent(effectList, context);
			return;
		case 174:
			SetExtraStancePercent(effectList, context);
			return;
		case 175:
			SetMoveCostMobility(effectList, context);
			return;
		case 176:
			SetDefendSkillKeepTime(effectList, context);
			return;
		case 177:
			SetBounceRange(effectList, context);
			return;
		case 178:
			SetMindMarkKeepTime(effectList, context);
			return;
		case 249:
			SetMindMarkCount(effectList, context);
			return;
		case 179:
			SetSkillMobilityCostPerFrame(effectList, context);
			return;
		case 180:
			SetCanAddWug(effectList, context);
			return;
		case 181:
			SetHasGodWeaponBuff(effectList, context);
			return;
		case 182:
			SetHasGodArmorBuff(effectList, context);
			return;
		case 183:
			SetTeammateCmdRequireGenerateValue(effectList, context);
			return;
		case 184:
			SetTeammateCmdEffect(effectList, context);
			return;
		case 270:
			SetTeammateCmdCanUse(effectList, context);
			return;
		case 185:
			SetFlawRecoverSpeed(effectList, context);
			return;
		case 186:
			SetAcupointRecoverSpeed(effectList, context);
			return;
		case 187:
			SetMindMarkRecoverSpeed(effectList, context);
			return;
		case 188:
			SetInjuryAutoHealSpeed(effectList, context);
			return;
		case 189:
			SetCanRecoverBreath(effectList, context);
			return;
		case 190:
			SetCanRecoverStance(effectList, context);
			return;
		case 191:
			SetFatalDamageValue(effectList, context);
			return;
		case 293:
			SetWugFatalDamageValue(effectList, context);
			return;
		case 192:
			SetFatalDamageMarkCount(effectList, context);
			return;
		case 303:
			SetFinalFatalDamageMarkCount(effectList, context);
			return;
		case 193:
			SetCanFightBackDuringPrepareSkill(effectList, context);
			return;
		case 340:
			SetCanFightBackOutOfAttackRange(effectList, context);
			return;
		case 250:
			SetCanFightBackWithHit(effectList, context);
			return;
		case 194:
			SetSkillPrepareSpeed(effectList, context);
			return;
		case 195:
			SetBreathRecoverSpeed(effectList, context);
			return;
		case 196:
			SetStanceRecoverSpeed(effectList, context);
			return;
		case 197:
			SetMobilityRecoverSpeed(effectList, context);
			return;
		case 300:
			SetMaxChangeTrickCount(effectList, context);
			return;
		case 198:
			SetChangeTrickProgressAddValue(effectList, context);
			return;
		case 286:
			SetAgileSkillCanAffect(effectList, context);
			return;
		case 284:
			SetDefendSkillCanAffect(effectList, context);
			return;
		case 285:
			SetAssistSkillCanAffect(effectList, context);
			return;
		case 199:
			SetPower(effectList, context);
			return;
		case 200:
			SetMaxPower(effectList, context);
			return;
		case 201:
			SetPowerCanReduce(effectList, context);
			return;
		case 256:
			SetPowerAddRatio(effectList, context);
			return;
		case 257:
			SetPowerReduceRatio(effectList, context);
			return;
		case 291:
			SetPowerEffectReverse(effectList, context);
			return;
		case 202:
			SetUseRequirement(effectList, context);
			return;
		case 203:
			SetCurrInnerRatio(effectList, context);
			return;
		case 204:
			SetCostBreathAndStance(effectList, context);
			return;
		case 205:
			SetCostBreath(effectList, context);
			return;
		case 206:
			SetCostStance(effectList, context);
			return;
		case 207:
			SetCostMobility(effectList, context);
			return;
		case 208:
			SetSkillCostTricks(effectList, context);
			return;
		case 279:
			SetCanCostEnemyUsableTricks(effectList, context);
			return;
		case 283:
			SetCanCostUselessTricks(effectList, context);
			return;
		case 317:
			SetCanCostShaTricks(effectList, context);
			return;
		case 209:
			SetEffectDirection(effectList, context);
			return;
		case 210:
			SetEffectDirectionCanChange(effectList, context);
			return;
		case 211:
			SetGridCost(effectList, context);
			return;
		case 212:
			SetPrepareTotalProgress(effectList, context);
			return;
		case 213:
			SetSpecificGridCount(effectList, context);
			return;
		case 214:
			SetGenericGridCount(effectList, context);
			return;
		case 234:
			SetCanCriticalHit(effectList, context);
			return;
		case 339:
			SetCriticalDamage(effectList, context);
			return;
		case 248:
			SetCertainCriticalHit(effectList, context);
			return;
		case 251:
			SetInevitableHit(effectList, context);
			return;
		case 290:
			SetInevitableAvoid(effectList, context);
			return;
		case 215:
			SetCanInterrupt(effectList, context);
			return;
		case 216:
			SetInterruptOdds(effectList, context);
			return;
		case 217:
			SetCanSilence(effectList, context);
			return;
		case 218:
			SetSilenceOdds(effectList, context);
			return;
		case 264:
			SetSilenceFrame(effectList, context);
			return;
		case 263:
			SetWeaponSilenceFrame(effectList, context);
			return;
		case 219:
			SetCanCastWithBrokenBodyPart(effectList, context);
			return;
		case 220:
			SetAddPowerCanBeRemoved(effectList, context);
			return;
		case 221:
			SetSkillType(effectList, context);
			return;
		case 222:
			SetEffectCountCanChange(effectList, context);
			return;
		case 327:
			SetStayEffectCountOnAddPhase(effectList, context);
			return;
		case 289:
			SetCanCast(effectList, context);
			return;
		case 223:
			SetCanCastInDefend(effectList, context);
			return;
		case 224:
			SetHitDistribution(effectList, context);
			return;
		case 225:
			SetCanCastOnLackBreath(effectList, context);
			return;
		case 226:
			SetCanCastOnLackStance(effectList, context);
			return;
		case 301:
			SetConvertCostBreathAndStance(effectList, context);
			return;
		case 227:
			SetCostBreathOnCast(effectList, context);
			return;
		case 228:
			SetCostStanceOnCast(effectList, context);
			return;
		case 229:
			SetCanUseMobilityAsBreath(effectList, context);
			return;
		case 230:
			SetCanUseMobilityAsStance(effectList, context);
			return;
		case 231:
			SetCastCostNeiliAllocation(effectList, context);
			return;
		case 344:
			SetCastCostNeiliAllocationIsAbsorb(effectList, context);
			return;
		case 235:
			SetCanCostNeiliAllocationEffect(effectList, context);
			return;
		case 322:
			SetCanCostTrickDuringPreparingSkill(effectList, context);
			return;
		case 323:
			SetValidItemList(effectList, context);
			return;
		case 329:
			SetUseItemCostNoWisdom(effectList, context);
			return;
		case 253:
			SetCombatSkillDataEffectList(effectList, context);
			return;
		case 304:
			SetCombatSkillAiScorePower(effectList, context);
			return;
		}
		throw new Exception($"Effect list of fieldId {fieldId} not found");
	}

	public int GetId()
	{
		return _id;
	}

	public void SetId(int id, DataContext context)
	{
		_id = id;
		SetModifiedAndInvalidateInfluencedCache(0, context);
	}

	public SpecialEffectList GetMaxStrength()
	{
		return _maxStrength;
	}

	public void SetMaxStrength(SpecialEffectList maxStrength, DataContext context)
	{
		_maxStrength = maxStrength;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public SpecialEffectList GetMaxDexterity()
	{
		return _maxDexterity;
	}

	public void SetMaxDexterity(SpecialEffectList maxDexterity, DataContext context)
	{
		_maxDexterity = maxDexterity;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public SpecialEffectList GetMaxConcentration()
	{
		return _maxConcentration;
	}

	public void SetMaxConcentration(SpecialEffectList maxConcentration, DataContext context)
	{
		_maxConcentration = maxConcentration;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public SpecialEffectList GetMaxVitality()
	{
		return _maxVitality;
	}

	public void SetMaxVitality(SpecialEffectList maxVitality, DataContext context)
	{
		_maxVitality = maxVitality;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public SpecialEffectList GetMaxEnergy()
	{
		return _maxEnergy;
	}

	public void SetMaxEnergy(SpecialEffectList maxEnergy, DataContext context)
	{
		_maxEnergy = maxEnergy;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public SpecialEffectList GetMaxIntelligence()
	{
		return _maxIntelligence;
	}

	public void SetMaxIntelligence(SpecialEffectList maxIntelligence, DataContext context)
	{
		_maxIntelligence = maxIntelligence;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public SpecialEffectList GetRecoveryOfStance()
	{
		return _recoveryOfStance;
	}

	public void SetRecoveryOfStance(SpecialEffectList recoveryOfStance, DataContext context)
	{
		_recoveryOfStance = recoveryOfStance;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public SpecialEffectList GetRecoveryOfBreath()
	{
		return _recoveryOfBreath;
	}

	public void SetRecoveryOfBreath(SpecialEffectList recoveryOfBreath, DataContext context)
	{
		_recoveryOfBreath = recoveryOfBreath;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public SpecialEffectList GetMoveSpeed()
	{
		return _moveSpeed;
	}

	public void SetMoveSpeed(SpecialEffectList moveSpeed, DataContext context)
	{
		_moveSpeed = moveSpeed;
		SetModifiedAndInvalidateInfluencedCache(9, context);
	}

	public SpecialEffectList GetRecoveryOfFlaw()
	{
		return _recoveryOfFlaw;
	}

	public void SetRecoveryOfFlaw(SpecialEffectList recoveryOfFlaw, DataContext context)
	{
		_recoveryOfFlaw = recoveryOfFlaw;
		SetModifiedAndInvalidateInfluencedCache(10, context);
	}

	public SpecialEffectList GetCastSpeed()
	{
		return _castSpeed;
	}

	public void SetCastSpeed(SpecialEffectList castSpeed, DataContext context)
	{
		_castSpeed = castSpeed;
		SetModifiedAndInvalidateInfluencedCache(11, context);
	}

	public SpecialEffectList GetRecoveryOfBlockedAcupoint()
	{
		return _recoveryOfBlockedAcupoint;
	}

	public void SetRecoveryOfBlockedAcupoint(SpecialEffectList recoveryOfBlockedAcupoint, DataContext context)
	{
		_recoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		SetModifiedAndInvalidateInfluencedCache(12, context);
	}

	public SpecialEffectList GetWeaponSwitchSpeed()
	{
		return _weaponSwitchSpeed;
	}

	public void SetWeaponSwitchSpeed(SpecialEffectList weaponSwitchSpeed, DataContext context)
	{
		_weaponSwitchSpeed = weaponSwitchSpeed;
		SetModifiedAndInvalidateInfluencedCache(13, context);
	}

	public SpecialEffectList GetAttackSpeed()
	{
		return _attackSpeed;
	}

	public void SetAttackSpeed(SpecialEffectList attackSpeed, DataContext context)
	{
		_attackSpeed = attackSpeed;
		SetModifiedAndInvalidateInfluencedCache(14, context);
	}

	public SpecialEffectList GetInnerRatio()
	{
		return _innerRatio;
	}

	public void SetInnerRatio(SpecialEffectList innerRatio, DataContext context)
	{
		_innerRatio = innerRatio;
		SetModifiedAndInvalidateInfluencedCache(15, context);
	}

	public SpecialEffectList GetRecoveryOfQiDisorder()
	{
		return _recoveryOfQiDisorder;
	}

	public void SetRecoveryOfQiDisorder(SpecialEffectList recoveryOfQiDisorder, DataContext context)
	{
		_recoveryOfQiDisorder = recoveryOfQiDisorder;
		SetModifiedAndInvalidateInfluencedCache(16, context);
	}

	public SpecialEffectList GetMinorAttributeFixMaxValue()
	{
		return _minorAttributeFixMaxValue;
	}

	public void SetMinorAttributeFixMaxValue(SpecialEffectList minorAttributeFixMaxValue, DataContext context)
	{
		_minorAttributeFixMaxValue = minorAttributeFixMaxValue;
		SetModifiedAndInvalidateInfluencedCache(17, context);
	}

	public SpecialEffectList GetMinorAttributeFixMinValue()
	{
		return _minorAttributeFixMinValue;
	}

	public void SetMinorAttributeFixMinValue(SpecialEffectList minorAttributeFixMinValue, DataContext context)
	{
		_minorAttributeFixMinValue = minorAttributeFixMinValue;
		SetModifiedAndInvalidateInfluencedCache(18, context);
	}

	public SpecialEffectList GetResistOfHotPoison()
	{
		return _resistOfHotPoison;
	}

	public void SetResistOfHotPoison(SpecialEffectList resistOfHotPoison, DataContext context)
	{
		_resistOfHotPoison = resistOfHotPoison;
		SetModifiedAndInvalidateInfluencedCache(19, context);
	}

	public SpecialEffectList GetResistOfGloomyPoison()
	{
		return _resistOfGloomyPoison;
	}

	public void SetResistOfGloomyPoison(SpecialEffectList resistOfGloomyPoison, DataContext context)
	{
		_resistOfGloomyPoison = resistOfGloomyPoison;
		SetModifiedAndInvalidateInfluencedCache(20, context);
	}

	public SpecialEffectList GetResistOfColdPoison()
	{
		return _resistOfColdPoison;
	}

	public void SetResistOfColdPoison(SpecialEffectList resistOfColdPoison, DataContext context)
	{
		_resistOfColdPoison = resistOfColdPoison;
		SetModifiedAndInvalidateInfluencedCache(21, context);
	}

	public SpecialEffectList GetResistOfRedPoison()
	{
		return _resistOfRedPoison;
	}

	public void SetResistOfRedPoison(SpecialEffectList resistOfRedPoison, DataContext context)
	{
		_resistOfRedPoison = resistOfRedPoison;
		SetModifiedAndInvalidateInfluencedCache(22, context);
	}

	public SpecialEffectList GetResistOfRottenPoison()
	{
		return _resistOfRottenPoison;
	}

	public void SetResistOfRottenPoison(SpecialEffectList resistOfRottenPoison, DataContext context)
	{
		_resistOfRottenPoison = resistOfRottenPoison;
		SetModifiedAndInvalidateInfluencedCache(23, context);
	}

	public SpecialEffectList GetResistOfIllusoryPoison()
	{
		return _resistOfIllusoryPoison;
	}

	public void SetResistOfIllusoryPoison(SpecialEffectList resistOfIllusoryPoison, DataContext context)
	{
		_resistOfIllusoryPoison = resistOfIllusoryPoison;
		SetModifiedAndInvalidateInfluencedCache(24, context);
	}

	public SpecialEffectList GetDisplayAge()
	{
		return _displayAge;
	}

	public void SetDisplayAge(SpecialEffectList displayAge, DataContext context)
	{
		_displayAge = displayAge;
		SetModifiedAndInvalidateInfluencedCache(25, context);
	}

	public SpecialEffectList GetNeiliProportionOfFiveElements()
	{
		return _neiliProportionOfFiveElements;
	}

	public void SetNeiliProportionOfFiveElements(SpecialEffectList neiliProportionOfFiveElements, DataContext context)
	{
		_neiliProportionOfFiveElements = neiliProportionOfFiveElements;
		SetModifiedAndInvalidateInfluencedCache(26, context);
	}

	public SpecialEffectList GetWeaponMaxPower()
	{
		return _weaponMaxPower;
	}

	public void SetWeaponMaxPower(SpecialEffectList weaponMaxPower, DataContext context)
	{
		_weaponMaxPower = weaponMaxPower;
		SetModifiedAndInvalidateInfluencedCache(27, context);
	}

	public SpecialEffectList GetWeaponUseRequirement()
	{
		return _weaponUseRequirement;
	}

	public void SetWeaponUseRequirement(SpecialEffectList weaponUseRequirement, DataContext context)
	{
		_weaponUseRequirement = weaponUseRequirement;
		SetModifiedAndInvalidateInfluencedCache(28, context);
	}

	public SpecialEffectList GetWeaponAttackRange()
	{
		return _weaponAttackRange;
	}

	public void SetWeaponAttackRange(SpecialEffectList weaponAttackRange, DataContext context)
	{
		_weaponAttackRange = weaponAttackRange;
		SetModifiedAndInvalidateInfluencedCache(29, context);
	}

	public SpecialEffectList GetArmorMaxPower()
	{
		return _armorMaxPower;
	}

	public void SetArmorMaxPower(SpecialEffectList armorMaxPower, DataContext context)
	{
		_armorMaxPower = armorMaxPower;
		SetModifiedAndInvalidateInfluencedCache(30, context);
	}

	public SpecialEffectList GetArmorUseRequirement()
	{
		return _armorUseRequirement;
	}

	public void SetArmorUseRequirement(SpecialEffectList armorUseRequirement, DataContext context)
	{
		_armorUseRequirement = armorUseRequirement;
		SetModifiedAndInvalidateInfluencedCache(31, context);
	}

	public SpecialEffectList GetHitStrength()
	{
		return _hitStrength;
	}

	public void SetHitStrength(SpecialEffectList hitStrength, DataContext context)
	{
		_hitStrength = hitStrength;
		SetModifiedAndInvalidateInfluencedCache(32, context);
	}

	public SpecialEffectList GetHitTechnique()
	{
		return _hitTechnique;
	}

	public void SetHitTechnique(SpecialEffectList hitTechnique, DataContext context)
	{
		_hitTechnique = hitTechnique;
		SetModifiedAndInvalidateInfluencedCache(33, context);
	}

	public SpecialEffectList GetHitSpeed()
	{
		return _hitSpeed;
	}

	public void SetHitSpeed(SpecialEffectList hitSpeed, DataContext context)
	{
		_hitSpeed = hitSpeed;
		SetModifiedAndInvalidateInfluencedCache(34, context);
	}

	public SpecialEffectList GetHitMind()
	{
		return _hitMind;
	}

	public void SetHitMind(SpecialEffectList hitMind, DataContext context)
	{
		_hitMind = hitMind;
		SetModifiedAndInvalidateInfluencedCache(35, context);
	}

	public SpecialEffectList GetHitCanChange()
	{
		return _hitCanChange;
	}

	public void SetHitCanChange(SpecialEffectList hitCanChange, DataContext context)
	{
		_hitCanChange = hitCanChange;
		SetModifiedAndInvalidateInfluencedCache(36, context);
	}

	public SpecialEffectList GetHitChangeEffectPercent()
	{
		return _hitChangeEffectPercent;
	}

	public void SetHitChangeEffectPercent(SpecialEffectList hitChangeEffectPercent, DataContext context)
	{
		_hitChangeEffectPercent = hitChangeEffectPercent;
		SetModifiedAndInvalidateInfluencedCache(37, context);
	}

	public SpecialEffectList GetAvoidStrength()
	{
		return _avoidStrength;
	}

	public void SetAvoidStrength(SpecialEffectList avoidStrength, DataContext context)
	{
		_avoidStrength = avoidStrength;
		SetModifiedAndInvalidateInfluencedCache(38, context);
	}

	public SpecialEffectList GetAvoidTechnique()
	{
		return _avoidTechnique;
	}

	public void SetAvoidTechnique(SpecialEffectList avoidTechnique, DataContext context)
	{
		_avoidTechnique = avoidTechnique;
		SetModifiedAndInvalidateInfluencedCache(39, context);
	}

	public SpecialEffectList GetAvoidSpeed()
	{
		return _avoidSpeed;
	}

	public void SetAvoidSpeed(SpecialEffectList avoidSpeed, DataContext context)
	{
		_avoidSpeed = avoidSpeed;
		SetModifiedAndInvalidateInfluencedCache(40, context);
	}

	public SpecialEffectList GetAvoidMind()
	{
		return _avoidMind;
	}

	public void SetAvoidMind(SpecialEffectList avoidMind, DataContext context)
	{
		_avoidMind = avoidMind;
		SetModifiedAndInvalidateInfluencedCache(41, context);
	}

	public SpecialEffectList GetAvoidCanChange()
	{
		return _avoidCanChange;
	}

	public void SetAvoidCanChange(SpecialEffectList avoidCanChange, DataContext context)
	{
		_avoidCanChange = avoidCanChange;
		SetModifiedAndInvalidateInfluencedCache(42, context);
	}

	public SpecialEffectList GetAvoidChangeEffectPercent()
	{
		return _avoidChangeEffectPercent;
	}

	public void SetAvoidChangeEffectPercent(SpecialEffectList avoidChangeEffectPercent, DataContext context)
	{
		_avoidChangeEffectPercent = avoidChangeEffectPercent;
		SetModifiedAndInvalidateInfluencedCache(43, context);
	}

	public SpecialEffectList GetPenetrateOuter()
	{
		return _penetrateOuter;
	}

	public void SetPenetrateOuter(SpecialEffectList penetrateOuter, DataContext context)
	{
		_penetrateOuter = penetrateOuter;
		SetModifiedAndInvalidateInfluencedCache(44, context);
	}

	public SpecialEffectList GetPenetrateInner()
	{
		return _penetrateInner;
	}

	public void SetPenetrateInner(SpecialEffectList penetrateInner, DataContext context)
	{
		_penetrateInner = penetrateInner;
		SetModifiedAndInvalidateInfluencedCache(45, context);
	}

	public SpecialEffectList GetPenetrateResistOuter()
	{
		return _penetrateResistOuter;
	}

	public void SetPenetrateResistOuter(SpecialEffectList penetrateResistOuter, DataContext context)
	{
		_penetrateResistOuter = penetrateResistOuter;
		SetModifiedAndInvalidateInfluencedCache(46, context);
	}

	public SpecialEffectList GetPenetrateResistInner()
	{
		return _penetrateResistInner;
	}

	public void SetPenetrateResistInner(SpecialEffectList penetrateResistInner, DataContext context)
	{
		_penetrateResistInner = penetrateResistInner;
		SetModifiedAndInvalidateInfluencedCache(47, context);
	}

	public SpecialEffectList GetNeiliAllocationAttack()
	{
		return _neiliAllocationAttack;
	}

	public void SetNeiliAllocationAttack(SpecialEffectList neiliAllocationAttack, DataContext context)
	{
		_neiliAllocationAttack = neiliAllocationAttack;
		SetModifiedAndInvalidateInfluencedCache(48, context);
	}

	public SpecialEffectList GetNeiliAllocationAgile()
	{
		return _neiliAllocationAgile;
	}

	public void SetNeiliAllocationAgile(SpecialEffectList neiliAllocationAgile, DataContext context)
	{
		_neiliAllocationAgile = neiliAllocationAgile;
		SetModifiedAndInvalidateInfluencedCache(49, context);
	}

	public SpecialEffectList GetNeiliAllocationDefense()
	{
		return _neiliAllocationDefense;
	}

	public void SetNeiliAllocationDefense(SpecialEffectList neiliAllocationDefense, DataContext context)
	{
		_neiliAllocationDefense = neiliAllocationDefense;
		SetModifiedAndInvalidateInfluencedCache(50, context);
	}

	public SpecialEffectList GetNeiliAllocationAssist()
	{
		return _neiliAllocationAssist;
	}

	public void SetNeiliAllocationAssist(SpecialEffectList neiliAllocationAssist, DataContext context)
	{
		_neiliAllocationAssist = neiliAllocationAssist;
		SetModifiedAndInvalidateInfluencedCache(51, context);
	}

	public SpecialEffectList GetHappiness()
	{
		return _happiness;
	}

	public void SetHappiness(SpecialEffectList happiness, DataContext context)
	{
		_happiness = happiness;
		SetModifiedAndInvalidateInfluencedCache(52, context);
	}

	public SpecialEffectList GetMaxHealth()
	{
		return _maxHealth;
	}

	public void SetMaxHealth(SpecialEffectList maxHealth, DataContext context)
	{
		_maxHealth = maxHealth;
		SetModifiedAndInvalidateInfluencedCache(53, context);
	}

	public SpecialEffectList GetHealthCost()
	{
		return _healthCost;
	}

	public void SetHealthCost(SpecialEffectList healthCost, DataContext context)
	{
		_healthCost = healthCost;
		SetModifiedAndInvalidateInfluencedCache(54, context);
	}

	public SpecialEffectList GetMoveSpeedCanChange()
	{
		return _moveSpeedCanChange;
	}

	public void SetMoveSpeedCanChange(SpecialEffectList moveSpeedCanChange, DataContext context)
	{
		_moveSpeedCanChange = moveSpeedCanChange;
		SetModifiedAndInvalidateInfluencedCache(55, context);
	}

	public SpecialEffectList GetAttackerHitStrength()
	{
		return _attackerHitStrength;
	}

	public void SetAttackerHitStrength(SpecialEffectList attackerHitStrength, DataContext context)
	{
		_attackerHitStrength = attackerHitStrength;
		SetModifiedAndInvalidateInfluencedCache(56, context);
	}

	public SpecialEffectList GetAttackerHitTechnique()
	{
		return _attackerHitTechnique;
	}

	public void SetAttackerHitTechnique(SpecialEffectList attackerHitTechnique, DataContext context)
	{
		_attackerHitTechnique = attackerHitTechnique;
		SetModifiedAndInvalidateInfluencedCache(57, context);
	}

	public SpecialEffectList GetAttackerHitSpeed()
	{
		return _attackerHitSpeed;
	}

	public void SetAttackerHitSpeed(SpecialEffectList attackerHitSpeed, DataContext context)
	{
		_attackerHitSpeed = attackerHitSpeed;
		SetModifiedAndInvalidateInfluencedCache(58, context);
	}

	public SpecialEffectList GetAttackerHitMind()
	{
		return _attackerHitMind;
	}

	public void SetAttackerHitMind(SpecialEffectList attackerHitMind, DataContext context)
	{
		_attackerHitMind = attackerHitMind;
		SetModifiedAndInvalidateInfluencedCache(59, context);
	}

	public SpecialEffectList GetAttackerAvoidStrength()
	{
		return _attackerAvoidStrength;
	}

	public void SetAttackerAvoidStrength(SpecialEffectList attackerAvoidStrength, DataContext context)
	{
		_attackerAvoidStrength = attackerAvoidStrength;
		SetModifiedAndInvalidateInfluencedCache(60, context);
	}

	public SpecialEffectList GetAttackerAvoidTechnique()
	{
		return _attackerAvoidTechnique;
	}

	public void SetAttackerAvoidTechnique(SpecialEffectList attackerAvoidTechnique, DataContext context)
	{
		_attackerAvoidTechnique = attackerAvoidTechnique;
		SetModifiedAndInvalidateInfluencedCache(61, context);
	}

	public SpecialEffectList GetAttackerAvoidSpeed()
	{
		return _attackerAvoidSpeed;
	}

	public void SetAttackerAvoidSpeed(SpecialEffectList attackerAvoidSpeed, DataContext context)
	{
		_attackerAvoidSpeed = attackerAvoidSpeed;
		SetModifiedAndInvalidateInfluencedCache(62, context);
	}

	public SpecialEffectList GetAttackerAvoidMind()
	{
		return _attackerAvoidMind;
	}

	public void SetAttackerAvoidMind(SpecialEffectList attackerAvoidMind, DataContext context)
	{
		_attackerAvoidMind = attackerAvoidMind;
		SetModifiedAndInvalidateInfluencedCache(63, context);
	}

	public SpecialEffectList GetAttackerPenetrateOuter()
	{
		return _attackerPenetrateOuter;
	}

	public void SetAttackerPenetrateOuter(SpecialEffectList attackerPenetrateOuter, DataContext context)
	{
		_attackerPenetrateOuter = attackerPenetrateOuter;
		SetModifiedAndInvalidateInfluencedCache(64, context);
	}

	public SpecialEffectList GetAttackerPenetrateInner()
	{
		return _attackerPenetrateInner;
	}

	public void SetAttackerPenetrateInner(SpecialEffectList attackerPenetrateInner, DataContext context)
	{
		_attackerPenetrateInner = attackerPenetrateInner;
		SetModifiedAndInvalidateInfluencedCache(65, context);
	}

	public SpecialEffectList GetAttackerPenetrateResistOuter()
	{
		return _attackerPenetrateResistOuter;
	}

	public void SetAttackerPenetrateResistOuter(SpecialEffectList attackerPenetrateResistOuter, DataContext context)
	{
		_attackerPenetrateResistOuter = attackerPenetrateResistOuter;
		SetModifiedAndInvalidateInfluencedCache(66, context);
	}

	public SpecialEffectList GetAttackerPenetrateResistInner()
	{
		return _attackerPenetrateResistInner;
	}

	public void SetAttackerPenetrateResistInner(SpecialEffectList attackerPenetrateResistInner, DataContext context)
	{
		_attackerPenetrateResistInner = attackerPenetrateResistInner;
		SetModifiedAndInvalidateInfluencedCache(67, context);
	}

	public SpecialEffectList GetAttackHitType()
	{
		return _attackHitType;
	}

	public void SetAttackHitType(SpecialEffectList attackHitType, DataContext context)
	{
		_attackHitType = attackHitType;
		SetModifiedAndInvalidateInfluencedCache(68, context);
	}

	public SpecialEffectList GetMakeDirectDamage()
	{
		return _makeDirectDamage;
	}

	public void SetMakeDirectDamage(SpecialEffectList makeDirectDamage, DataContext context)
	{
		_makeDirectDamage = makeDirectDamage;
		SetModifiedAndInvalidateInfluencedCache(69, context);
	}

	public SpecialEffectList GetMakeBounceDamage()
	{
		return _makeBounceDamage;
	}

	public void SetMakeBounceDamage(SpecialEffectList makeBounceDamage, DataContext context)
	{
		_makeBounceDamage = makeBounceDamage;
		SetModifiedAndInvalidateInfluencedCache(70, context);
	}

	public SpecialEffectList GetMakeFightBackDamage()
	{
		return _makeFightBackDamage;
	}

	public void SetMakeFightBackDamage(SpecialEffectList makeFightBackDamage, DataContext context)
	{
		_makeFightBackDamage = makeFightBackDamage;
		SetModifiedAndInvalidateInfluencedCache(71, context);
	}

	public SpecialEffectList GetMakePoisonLevel()
	{
		return _makePoisonLevel;
	}

	public void SetMakePoisonLevel(SpecialEffectList makePoisonLevel, DataContext context)
	{
		_makePoisonLevel = makePoisonLevel;
		SetModifiedAndInvalidateInfluencedCache(72, context);
	}

	public SpecialEffectList GetMakePoisonValue()
	{
		return _makePoisonValue;
	}

	public void SetMakePoisonValue(SpecialEffectList makePoisonValue, DataContext context)
	{
		_makePoisonValue = makePoisonValue;
		SetModifiedAndInvalidateInfluencedCache(73, context);
	}

	public SpecialEffectList GetAttackerHitOdds()
	{
		return _attackerHitOdds;
	}

	public void SetAttackerHitOdds(SpecialEffectList attackerHitOdds, DataContext context)
	{
		_attackerHitOdds = attackerHitOdds;
		SetModifiedAndInvalidateInfluencedCache(74, context);
	}

	public SpecialEffectList GetAttackerFightBackHitOdds()
	{
		return _attackerFightBackHitOdds;
	}

	public void SetAttackerFightBackHitOdds(SpecialEffectList attackerFightBackHitOdds, DataContext context)
	{
		_attackerFightBackHitOdds = attackerFightBackHitOdds;
		SetModifiedAndInvalidateInfluencedCache(75, context);
	}

	public SpecialEffectList GetAttackerPursueOdds()
	{
		return _attackerPursueOdds;
	}

	public void SetAttackerPursueOdds(SpecialEffectList attackerPursueOdds, DataContext context)
	{
		_attackerPursueOdds = attackerPursueOdds;
		SetModifiedAndInvalidateInfluencedCache(76, context);
	}

	public SpecialEffectList GetCausedInjuryChangeToOld()
	{
		return _causedInjuryChangeToOld;
	}

	public void SetCausedInjuryChangeToOld(SpecialEffectList causedInjuryChangeToOld, DataContext context)
	{
		_causedInjuryChangeToOld = causedInjuryChangeToOld;
		SetModifiedAndInvalidateInfluencedCache(77, context);
	}

	public SpecialEffectList GetCausedPoisonChangeToOld()
	{
		return _causedPoisonChangeToOld;
	}

	public void SetCausedPoisonChangeToOld(SpecialEffectList causedPoisonChangeToOld, DataContext context)
	{
		_causedPoisonChangeToOld = causedPoisonChangeToOld;
		SetModifiedAndInvalidateInfluencedCache(78, context);
	}

	public SpecialEffectList GetMakeDamageType()
	{
		return _makeDamageType;
	}

	public void SetMakeDamageType(SpecialEffectList makeDamageType, DataContext context)
	{
		_makeDamageType = makeDamageType;
		SetModifiedAndInvalidateInfluencedCache(79, context);
	}

	public SpecialEffectList GetCanMakeInjuryToNoInjuryPart()
	{
		return _canMakeInjuryToNoInjuryPart;
	}

	public void SetCanMakeInjuryToNoInjuryPart(SpecialEffectList canMakeInjuryToNoInjuryPart, DataContext context)
	{
		_canMakeInjuryToNoInjuryPart = canMakeInjuryToNoInjuryPart;
		SetModifiedAndInvalidateInfluencedCache(80, context);
	}

	public SpecialEffectList GetMakePoisonType()
	{
		return _makePoisonType;
	}

	public void SetMakePoisonType(SpecialEffectList makePoisonType, DataContext context)
	{
		_makePoisonType = makePoisonType;
		SetModifiedAndInvalidateInfluencedCache(81, context);
	}

	public SpecialEffectList GetNormalAttackWeapon()
	{
		return _normalAttackWeapon;
	}

	public void SetNormalAttackWeapon(SpecialEffectList normalAttackWeapon, DataContext context)
	{
		_normalAttackWeapon = normalAttackWeapon;
		SetModifiedAndInvalidateInfluencedCache(82, context);
	}

	public SpecialEffectList GetNormalAttackTrick()
	{
		return _normalAttackTrick;
	}

	public void SetNormalAttackTrick(SpecialEffectList normalAttackTrick, DataContext context)
	{
		_normalAttackTrick = normalAttackTrick;
		SetModifiedAndInvalidateInfluencedCache(83, context);
	}

	public SpecialEffectList GetExtraFlawCount()
	{
		return _extraFlawCount;
	}

	public void SetExtraFlawCount(SpecialEffectList extraFlawCount, DataContext context)
	{
		_extraFlawCount = extraFlawCount;
		SetModifiedAndInvalidateInfluencedCache(84, context);
	}

	public SpecialEffectList GetAttackCanBounce()
	{
		return _attackCanBounce;
	}

	public void SetAttackCanBounce(SpecialEffectList attackCanBounce, DataContext context)
	{
		_attackCanBounce = attackCanBounce;
		SetModifiedAndInvalidateInfluencedCache(85, context);
	}

	public SpecialEffectList GetAttackCanFightBack()
	{
		return _attackCanFightBack;
	}

	public void SetAttackCanFightBack(SpecialEffectList attackCanFightBack, DataContext context)
	{
		_attackCanFightBack = attackCanFightBack;
		SetModifiedAndInvalidateInfluencedCache(86, context);
	}

	public SpecialEffectList GetMakeFightBackInjuryMark()
	{
		return _makeFightBackInjuryMark;
	}

	public void SetMakeFightBackInjuryMark(SpecialEffectList makeFightBackInjuryMark, DataContext context)
	{
		_makeFightBackInjuryMark = makeFightBackInjuryMark;
		SetModifiedAndInvalidateInfluencedCache(87, context);
	}

	public SpecialEffectList GetLegSkillUseShoes()
	{
		return _legSkillUseShoes;
	}

	public void SetLegSkillUseShoes(SpecialEffectList legSkillUseShoes, DataContext context)
	{
		_legSkillUseShoes = legSkillUseShoes;
		SetModifiedAndInvalidateInfluencedCache(88, context);
	}

	public SpecialEffectList GetAttackerFinalDamageValue()
	{
		return _attackerFinalDamageValue;
	}

	public void SetAttackerFinalDamageValue(SpecialEffectList attackerFinalDamageValue, DataContext context)
	{
		_attackerFinalDamageValue = attackerFinalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(89, context);
	}

	public SpecialEffectList GetDefenderHitStrength()
	{
		return _defenderHitStrength;
	}

	public void SetDefenderHitStrength(SpecialEffectList defenderHitStrength, DataContext context)
	{
		_defenderHitStrength = defenderHitStrength;
		SetModifiedAndInvalidateInfluencedCache(90, context);
	}

	public SpecialEffectList GetDefenderHitTechnique()
	{
		return _defenderHitTechnique;
	}

	public void SetDefenderHitTechnique(SpecialEffectList defenderHitTechnique, DataContext context)
	{
		_defenderHitTechnique = defenderHitTechnique;
		SetModifiedAndInvalidateInfluencedCache(91, context);
	}

	public SpecialEffectList GetDefenderHitSpeed()
	{
		return _defenderHitSpeed;
	}

	public void SetDefenderHitSpeed(SpecialEffectList defenderHitSpeed, DataContext context)
	{
		_defenderHitSpeed = defenderHitSpeed;
		SetModifiedAndInvalidateInfluencedCache(92, context);
	}

	public SpecialEffectList GetDefenderHitMind()
	{
		return _defenderHitMind;
	}

	public void SetDefenderHitMind(SpecialEffectList defenderHitMind, DataContext context)
	{
		_defenderHitMind = defenderHitMind;
		SetModifiedAndInvalidateInfluencedCache(93, context);
	}

	public SpecialEffectList GetDefenderAvoidStrength()
	{
		return _defenderAvoidStrength;
	}

	public void SetDefenderAvoidStrength(SpecialEffectList defenderAvoidStrength, DataContext context)
	{
		_defenderAvoidStrength = defenderAvoidStrength;
		SetModifiedAndInvalidateInfluencedCache(94, context);
	}

	public SpecialEffectList GetDefenderAvoidTechnique()
	{
		return _defenderAvoidTechnique;
	}

	public void SetDefenderAvoidTechnique(SpecialEffectList defenderAvoidTechnique, DataContext context)
	{
		_defenderAvoidTechnique = defenderAvoidTechnique;
		SetModifiedAndInvalidateInfluencedCache(95, context);
	}

	public SpecialEffectList GetDefenderAvoidSpeed()
	{
		return _defenderAvoidSpeed;
	}

	public void SetDefenderAvoidSpeed(SpecialEffectList defenderAvoidSpeed, DataContext context)
	{
		_defenderAvoidSpeed = defenderAvoidSpeed;
		SetModifiedAndInvalidateInfluencedCache(96, context);
	}

	public SpecialEffectList GetDefenderAvoidMind()
	{
		return _defenderAvoidMind;
	}

	public void SetDefenderAvoidMind(SpecialEffectList defenderAvoidMind, DataContext context)
	{
		_defenderAvoidMind = defenderAvoidMind;
		SetModifiedAndInvalidateInfluencedCache(97, context);
	}

	public SpecialEffectList GetDefenderPenetrateOuter()
	{
		return _defenderPenetrateOuter;
	}

	public void SetDefenderPenetrateOuter(SpecialEffectList defenderPenetrateOuter, DataContext context)
	{
		_defenderPenetrateOuter = defenderPenetrateOuter;
		SetModifiedAndInvalidateInfluencedCache(98, context);
	}

	public SpecialEffectList GetDefenderPenetrateInner()
	{
		return _defenderPenetrateInner;
	}

	public void SetDefenderPenetrateInner(SpecialEffectList defenderPenetrateInner, DataContext context)
	{
		_defenderPenetrateInner = defenderPenetrateInner;
		SetModifiedAndInvalidateInfluencedCache(99, context);
	}

	public SpecialEffectList GetDefenderPenetrateResistOuter()
	{
		return _defenderPenetrateResistOuter;
	}

	public void SetDefenderPenetrateResistOuter(SpecialEffectList defenderPenetrateResistOuter, DataContext context)
	{
		_defenderPenetrateResistOuter = defenderPenetrateResistOuter;
		SetModifiedAndInvalidateInfluencedCache(100, context);
	}

	public SpecialEffectList GetDefenderPenetrateResistInner()
	{
		return _defenderPenetrateResistInner;
	}

	public void SetDefenderPenetrateResistInner(SpecialEffectList defenderPenetrateResistInner, DataContext context)
	{
		_defenderPenetrateResistInner = defenderPenetrateResistInner;
		SetModifiedAndInvalidateInfluencedCache(101, context);
	}

	public SpecialEffectList GetAcceptDirectDamage()
	{
		return _acceptDirectDamage;
	}

	public void SetAcceptDirectDamage(SpecialEffectList acceptDirectDamage, DataContext context)
	{
		_acceptDirectDamage = acceptDirectDamage;
		SetModifiedAndInvalidateInfluencedCache(102, context);
	}

	public SpecialEffectList GetAcceptBounceDamage()
	{
		return _acceptBounceDamage;
	}

	public void SetAcceptBounceDamage(SpecialEffectList acceptBounceDamage, DataContext context)
	{
		_acceptBounceDamage = acceptBounceDamage;
		SetModifiedAndInvalidateInfluencedCache(103, context);
	}

	public SpecialEffectList GetAcceptFightBackDamage()
	{
		return _acceptFightBackDamage;
	}

	public void SetAcceptFightBackDamage(SpecialEffectList acceptFightBackDamage, DataContext context)
	{
		_acceptFightBackDamage = acceptFightBackDamage;
		SetModifiedAndInvalidateInfluencedCache(104, context);
	}

	public SpecialEffectList GetAcceptPoisonLevel()
	{
		return _acceptPoisonLevel;
	}

	public void SetAcceptPoisonLevel(SpecialEffectList acceptPoisonLevel, DataContext context)
	{
		_acceptPoisonLevel = acceptPoisonLevel;
		SetModifiedAndInvalidateInfluencedCache(105, context);
	}

	public SpecialEffectList GetAcceptPoisonValue()
	{
		return _acceptPoisonValue;
	}

	public void SetAcceptPoisonValue(SpecialEffectList acceptPoisonValue, DataContext context)
	{
		_acceptPoisonValue = acceptPoisonValue;
		SetModifiedAndInvalidateInfluencedCache(106, context);
	}

	public SpecialEffectList GetDefenderHitOdds()
	{
		return _defenderHitOdds;
	}

	public void SetDefenderHitOdds(SpecialEffectList defenderHitOdds, DataContext context)
	{
		_defenderHitOdds = defenderHitOdds;
		SetModifiedAndInvalidateInfluencedCache(107, context);
	}

	public SpecialEffectList GetDefenderFightBackHitOdds()
	{
		return _defenderFightBackHitOdds;
	}

	public void SetDefenderFightBackHitOdds(SpecialEffectList defenderFightBackHitOdds, DataContext context)
	{
		_defenderFightBackHitOdds = defenderFightBackHitOdds;
		SetModifiedAndInvalidateInfluencedCache(108, context);
	}

	public SpecialEffectList GetDefenderPursueOdds()
	{
		return _defenderPursueOdds;
	}

	public void SetDefenderPursueOdds(SpecialEffectList defenderPursueOdds, DataContext context)
	{
		_defenderPursueOdds = defenderPursueOdds;
		SetModifiedAndInvalidateInfluencedCache(109, context);
	}

	public SpecialEffectList GetAcceptMaxInjuryCount()
	{
		return _acceptMaxInjuryCount;
	}

	public void SetAcceptMaxInjuryCount(SpecialEffectList acceptMaxInjuryCount, DataContext context)
	{
		_acceptMaxInjuryCount = acceptMaxInjuryCount;
		SetModifiedAndInvalidateInfluencedCache(110, context);
	}

	public SpecialEffectList GetBouncePower()
	{
		return _bouncePower;
	}

	public void SetBouncePower(SpecialEffectList bouncePower, DataContext context)
	{
		_bouncePower = bouncePower;
		SetModifiedAndInvalidateInfluencedCache(111, context);
	}

	public SpecialEffectList GetFightBackPower()
	{
		return _fightBackPower;
	}

	public void SetFightBackPower(SpecialEffectList fightBackPower, DataContext context)
	{
		_fightBackPower = fightBackPower;
		SetModifiedAndInvalidateInfluencedCache(112, context);
	}

	public SpecialEffectList GetDirectDamageInnerRatio()
	{
		return _directDamageInnerRatio;
	}

	public void SetDirectDamageInnerRatio(SpecialEffectList directDamageInnerRatio, DataContext context)
	{
		_directDamageInnerRatio = directDamageInnerRatio;
		SetModifiedAndInvalidateInfluencedCache(113, context);
	}

	public SpecialEffectList GetDefenderFinalDamageValue()
	{
		return _defenderFinalDamageValue;
	}

	public void SetDefenderFinalDamageValue(SpecialEffectList defenderFinalDamageValue, DataContext context)
	{
		_defenderFinalDamageValue = defenderFinalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(114, context);
	}

	public SpecialEffectList GetDirectDamageValue()
	{
		return _directDamageValue;
	}

	public void SetDirectDamageValue(SpecialEffectList directDamageValue, DataContext context)
	{
		_directDamageValue = directDamageValue;
		SetModifiedAndInvalidateInfluencedCache(115, context);
	}

	public SpecialEffectList GetDirectInjuryMark()
	{
		return _directInjuryMark;
	}

	public void SetDirectInjuryMark(SpecialEffectList directInjuryMark, DataContext context)
	{
		_directInjuryMark = directInjuryMark;
		SetModifiedAndInvalidateInfluencedCache(116, context);
	}

	public SpecialEffectList GetGoneMadInjury()
	{
		return _goneMadInjury;
	}

	public void SetGoneMadInjury(SpecialEffectList goneMadInjury, DataContext context)
	{
		_goneMadInjury = goneMadInjury;
		SetModifiedAndInvalidateInfluencedCache(117, context);
	}

	public SpecialEffectList GetHealInjurySpeed()
	{
		return _healInjurySpeed;
	}

	public void SetHealInjurySpeed(SpecialEffectList healInjurySpeed, DataContext context)
	{
		_healInjurySpeed = healInjurySpeed;
		SetModifiedAndInvalidateInfluencedCache(118, context);
	}

	public SpecialEffectList GetHealInjuryBuff()
	{
		return _healInjuryBuff;
	}

	public void SetHealInjuryBuff(SpecialEffectList healInjuryBuff, DataContext context)
	{
		_healInjuryBuff = healInjuryBuff;
		SetModifiedAndInvalidateInfluencedCache(119, context);
	}

	public SpecialEffectList GetHealInjuryDebuff()
	{
		return _healInjuryDebuff;
	}

	public void SetHealInjuryDebuff(SpecialEffectList healInjuryDebuff, DataContext context)
	{
		_healInjuryDebuff = healInjuryDebuff;
		SetModifiedAndInvalidateInfluencedCache(120, context);
	}

	public SpecialEffectList GetHealPoisonSpeed()
	{
		return _healPoisonSpeed;
	}

	public void SetHealPoisonSpeed(SpecialEffectList healPoisonSpeed, DataContext context)
	{
		_healPoisonSpeed = healPoisonSpeed;
		SetModifiedAndInvalidateInfluencedCache(121, context);
	}

	public SpecialEffectList GetHealPoisonBuff()
	{
		return _healPoisonBuff;
	}

	public void SetHealPoisonBuff(SpecialEffectList healPoisonBuff, DataContext context)
	{
		_healPoisonBuff = healPoisonBuff;
		SetModifiedAndInvalidateInfluencedCache(122, context);
	}

	public SpecialEffectList GetHealPoisonDebuff()
	{
		return _healPoisonDebuff;
	}

	public void SetHealPoisonDebuff(SpecialEffectList healPoisonDebuff, DataContext context)
	{
		_healPoisonDebuff = healPoisonDebuff;
		SetModifiedAndInvalidateInfluencedCache(123, context);
	}

	public SpecialEffectList GetFleeSpeed()
	{
		return _fleeSpeed;
	}

	public void SetFleeSpeed(SpecialEffectList fleeSpeed, DataContext context)
	{
		_fleeSpeed = fleeSpeed;
		SetModifiedAndInvalidateInfluencedCache(124, context);
	}

	public SpecialEffectList GetMaxFlawCount()
	{
		return _maxFlawCount;
	}

	public void SetMaxFlawCount(SpecialEffectList maxFlawCount, DataContext context)
	{
		_maxFlawCount = maxFlawCount;
		SetModifiedAndInvalidateInfluencedCache(125, context);
	}

	public SpecialEffectList GetCanAddFlaw()
	{
		return _canAddFlaw;
	}

	public void SetCanAddFlaw(SpecialEffectList canAddFlaw, DataContext context)
	{
		_canAddFlaw = canAddFlaw;
		SetModifiedAndInvalidateInfluencedCache(126, context);
	}

	public SpecialEffectList GetFlawLevel()
	{
		return _flawLevel;
	}

	public void SetFlawLevel(SpecialEffectList flawLevel, DataContext context)
	{
		_flawLevel = flawLevel;
		SetModifiedAndInvalidateInfluencedCache(127, context);
	}

	public SpecialEffectList GetFlawLevelCanReduce()
	{
		return _flawLevelCanReduce;
	}

	public void SetFlawLevelCanReduce(SpecialEffectList flawLevelCanReduce, DataContext context)
	{
		_flawLevelCanReduce = flawLevelCanReduce;
		SetModifiedAndInvalidateInfluencedCache(128, context);
	}

	public SpecialEffectList GetFlawCount()
	{
		return _flawCount;
	}

	public void SetFlawCount(SpecialEffectList flawCount, DataContext context)
	{
		_flawCount = flawCount;
		SetModifiedAndInvalidateInfluencedCache(129, context);
	}

	public SpecialEffectList GetMaxAcupointCount()
	{
		return _maxAcupointCount;
	}

	public void SetMaxAcupointCount(SpecialEffectList maxAcupointCount, DataContext context)
	{
		_maxAcupointCount = maxAcupointCount;
		SetModifiedAndInvalidateInfluencedCache(130, context);
	}

	public SpecialEffectList GetCanAddAcupoint()
	{
		return _canAddAcupoint;
	}

	public void SetCanAddAcupoint(SpecialEffectList canAddAcupoint, DataContext context)
	{
		_canAddAcupoint = canAddAcupoint;
		SetModifiedAndInvalidateInfluencedCache(131, context);
	}

	public SpecialEffectList GetAcupointLevel()
	{
		return _acupointLevel;
	}

	public void SetAcupointLevel(SpecialEffectList acupointLevel, DataContext context)
	{
		_acupointLevel = acupointLevel;
		SetModifiedAndInvalidateInfluencedCache(132, context);
	}

	public SpecialEffectList GetAcupointLevelCanReduce()
	{
		return _acupointLevelCanReduce;
	}

	public void SetAcupointLevelCanReduce(SpecialEffectList acupointLevelCanReduce, DataContext context)
	{
		_acupointLevelCanReduce = acupointLevelCanReduce;
		SetModifiedAndInvalidateInfluencedCache(133, context);
	}

	public SpecialEffectList GetAcupointCount()
	{
		return _acupointCount;
	}

	public void SetAcupointCount(SpecialEffectList acupointCount, DataContext context)
	{
		_acupointCount = acupointCount;
		SetModifiedAndInvalidateInfluencedCache(134, context);
	}

	public SpecialEffectList GetAddNeiliAllocation()
	{
		return _addNeiliAllocation;
	}

	public void SetAddNeiliAllocation(SpecialEffectList addNeiliAllocation, DataContext context)
	{
		_addNeiliAllocation = addNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(135, context);
	}

	public SpecialEffectList GetCostNeiliAllocation()
	{
		return _costNeiliAllocation;
	}

	public void SetCostNeiliAllocation(SpecialEffectList costNeiliAllocation, DataContext context)
	{
		_costNeiliAllocation = costNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(136, context);
	}

	public SpecialEffectList GetCanChangeNeiliAllocation()
	{
		return _canChangeNeiliAllocation;
	}

	public void SetCanChangeNeiliAllocation(SpecialEffectList canChangeNeiliAllocation, DataContext context)
	{
		_canChangeNeiliAllocation = canChangeNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(137, context);
	}

	public SpecialEffectList GetCanGetTrick()
	{
		return _canGetTrick;
	}

	public void SetCanGetTrick(SpecialEffectList canGetTrick, DataContext context)
	{
		_canGetTrick = canGetTrick;
		SetModifiedAndInvalidateInfluencedCache(138, context);
	}

	public SpecialEffectList GetGetTrickType()
	{
		return _getTrickType;
	}

	public void SetGetTrickType(SpecialEffectList getTrickType, DataContext context)
	{
		_getTrickType = getTrickType;
		SetModifiedAndInvalidateInfluencedCache(139, context);
	}

	public SpecialEffectList GetAttackBodyPart()
	{
		return _attackBodyPart;
	}

	public void SetAttackBodyPart(SpecialEffectList attackBodyPart, DataContext context)
	{
		_attackBodyPart = attackBodyPart;
		SetModifiedAndInvalidateInfluencedCache(140, context);
	}

	public SpecialEffectList GetWeaponEquipAttack()
	{
		return _weaponEquipAttack;
	}

	public void SetWeaponEquipAttack(SpecialEffectList weaponEquipAttack, DataContext context)
	{
		_weaponEquipAttack = weaponEquipAttack;
		SetModifiedAndInvalidateInfluencedCache(141, context);
	}

	public SpecialEffectList GetWeaponEquipDefense()
	{
		return _weaponEquipDefense;
	}

	public void SetWeaponEquipDefense(SpecialEffectList weaponEquipDefense, DataContext context)
	{
		_weaponEquipDefense = weaponEquipDefense;
		SetModifiedAndInvalidateInfluencedCache(142, context);
	}

	public SpecialEffectList GetArmorEquipAttack()
	{
		return _armorEquipAttack;
	}

	public void SetArmorEquipAttack(SpecialEffectList armorEquipAttack, DataContext context)
	{
		_armorEquipAttack = armorEquipAttack;
		SetModifiedAndInvalidateInfluencedCache(143, context);
	}

	public SpecialEffectList GetArmorEquipDefense()
	{
		return _armorEquipDefense;
	}

	public void SetArmorEquipDefense(SpecialEffectList armorEquipDefense, DataContext context)
	{
		_armorEquipDefense = armorEquipDefense;
		SetModifiedAndInvalidateInfluencedCache(144, context);
	}

	public SpecialEffectList GetAttackRangeForward()
	{
		return _attackRangeForward;
	}

	public void SetAttackRangeForward(SpecialEffectList attackRangeForward, DataContext context)
	{
		_attackRangeForward = attackRangeForward;
		SetModifiedAndInvalidateInfluencedCache(145, context);
	}

	public SpecialEffectList GetAttackRangeBackward()
	{
		return _attackRangeBackward;
	}

	public void SetAttackRangeBackward(SpecialEffectList attackRangeBackward, DataContext context)
	{
		_attackRangeBackward = attackRangeBackward;
		SetModifiedAndInvalidateInfluencedCache(146, context);
	}

	public SpecialEffectList GetMoveCanBeStopped()
	{
		return _moveCanBeStopped;
	}

	public void SetMoveCanBeStopped(SpecialEffectList moveCanBeStopped, DataContext context)
	{
		_moveCanBeStopped = moveCanBeStopped;
		SetModifiedAndInvalidateInfluencedCache(147, context);
	}

	public SpecialEffectList GetCanForcedMove()
	{
		return _canForcedMove;
	}

	public void SetCanForcedMove(SpecialEffectList canForcedMove, DataContext context)
	{
		_canForcedMove = canForcedMove;
		SetModifiedAndInvalidateInfluencedCache(148, context);
	}

	public SpecialEffectList GetMobilityCanBeRemoved()
	{
		return _mobilityCanBeRemoved;
	}

	public void SetMobilityCanBeRemoved(SpecialEffectList mobilityCanBeRemoved, DataContext context)
	{
		_mobilityCanBeRemoved = mobilityCanBeRemoved;
		SetModifiedAndInvalidateInfluencedCache(149, context);
	}

	public SpecialEffectList GetMobilityCostByEffect()
	{
		return _mobilityCostByEffect;
	}

	public void SetMobilityCostByEffect(SpecialEffectList mobilityCostByEffect, DataContext context)
	{
		_mobilityCostByEffect = mobilityCostByEffect;
		SetModifiedAndInvalidateInfluencedCache(150, context);
	}

	public SpecialEffectList GetMoveDistance()
	{
		return _moveDistance;
	}

	public void SetMoveDistance(SpecialEffectList moveDistance, DataContext context)
	{
		_moveDistance = moveDistance;
		SetModifiedAndInvalidateInfluencedCache(151, context);
	}

	public SpecialEffectList GetJumpPrepareFrame()
	{
		return _jumpPrepareFrame;
	}

	public void SetJumpPrepareFrame(SpecialEffectList jumpPrepareFrame, DataContext context)
	{
		_jumpPrepareFrame = jumpPrepareFrame;
		SetModifiedAndInvalidateInfluencedCache(152, context);
	}

	public SpecialEffectList GetBounceInjuryMark()
	{
		return _bounceInjuryMark;
	}

	public void SetBounceInjuryMark(SpecialEffectList bounceInjuryMark, DataContext context)
	{
		_bounceInjuryMark = bounceInjuryMark;
		SetModifiedAndInvalidateInfluencedCache(153, context);
	}

	public SpecialEffectList GetSkillHasCost()
	{
		return _skillHasCost;
	}

	public void SetSkillHasCost(SpecialEffectList skillHasCost, DataContext context)
	{
		_skillHasCost = skillHasCost;
		SetModifiedAndInvalidateInfluencedCache(154, context);
	}

	public SpecialEffectList GetCombatStateEffect()
	{
		return _combatStateEffect;
	}

	public void SetCombatStateEffect(SpecialEffectList combatStateEffect, DataContext context)
	{
		_combatStateEffect = combatStateEffect;
		SetModifiedAndInvalidateInfluencedCache(155, context);
	}

	public SpecialEffectList GetChangeNeedUseSkill()
	{
		return _changeNeedUseSkill;
	}

	public void SetChangeNeedUseSkill(SpecialEffectList changeNeedUseSkill, DataContext context)
	{
		_changeNeedUseSkill = changeNeedUseSkill;
		SetModifiedAndInvalidateInfluencedCache(156, context);
	}

	public SpecialEffectList GetChangeDistanceIsMove()
	{
		return _changeDistanceIsMove;
	}

	public void SetChangeDistanceIsMove(SpecialEffectList changeDistanceIsMove, DataContext context)
	{
		_changeDistanceIsMove = changeDistanceIsMove;
		SetModifiedAndInvalidateInfluencedCache(157, context);
	}

	public SpecialEffectList GetReplaceCharHit()
	{
		return _replaceCharHit;
	}

	public void SetReplaceCharHit(SpecialEffectList replaceCharHit, DataContext context)
	{
		_replaceCharHit = replaceCharHit;
		SetModifiedAndInvalidateInfluencedCache(158, context);
	}

	public SpecialEffectList GetCanAddPoison()
	{
		return _canAddPoison;
	}

	public void SetCanAddPoison(SpecialEffectList canAddPoison, DataContext context)
	{
		_canAddPoison = canAddPoison;
		SetModifiedAndInvalidateInfluencedCache(159, context);
	}

	public SpecialEffectList GetCanReducePoison()
	{
		return _canReducePoison;
	}

	public void SetCanReducePoison(SpecialEffectList canReducePoison, DataContext context)
	{
		_canReducePoison = canReducePoison;
		SetModifiedAndInvalidateInfluencedCache(160, context);
	}

	public SpecialEffectList GetReducePoisonValue()
	{
		return _reducePoisonValue;
	}

	public void SetReducePoisonValue(SpecialEffectList reducePoisonValue, DataContext context)
	{
		_reducePoisonValue = reducePoisonValue;
		SetModifiedAndInvalidateInfluencedCache(161, context);
	}

	public SpecialEffectList GetPoisonCanAffect()
	{
		return _poisonCanAffect;
	}

	public void SetPoisonCanAffect(SpecialEffectList poisonCanAffect, DataContext context)
	{
		_poisonCanAffect = poisonCanAffect;
		SetModifiedAndInvalidateInfluencedCache(162, context);
	}

	public SpecialEffectList GetPoisonAffectCount()
	{
		return _poisonAffectCount;
	}

	public void SetPoisonAffectCount(SpecialEffectList poisonAffectCount, DataContext context)
	{
		_poisonAffectCount = poisonAffectCount;
		SetModifiedAndInvalidateInfluencedCache(163, context);
	}

	public SpecialEffectList GetCostTricks()
	{
		return _costTricks;
	}

	public void SetCostTricks(SpecialEffectList costTricks, DataContext context)
	{
		_costTricks = costTricks;
		SetModifiedAndInvalidateInfluencedCache(164, context);
	}

	public SpecialEffectList GetJumpMoveDistance()
	{
		return _jumpMoveDistance;
	}

	public void SetJumpMoveDistance(SpecialEffectList jumpMoveDistance, DataContext context)
	{
		_jumpMoveDistance = jumpMoveDistance;
		SetModifiedAndInvalidateInfluencedCache(165, context);
	}

	public SpecialEffectList GetCombatStateToAdd()
	{
		return _combatStateToAdd;
	}

	public void SetCombatStateToAdd(SpecialEffectList combatStateToAdd, DataContext context)
	{
		_combatStateToAdd = combatStateToAdd;
		SetModifiedAndInvalidateInfluencedCache(166, context);
	}

	public SpecialEffectList GetCombatStatePower()
	{
		return _combatStatePower;
	}

	public void SetCombatStatePower(SpecialEffectList combatStatePower, DataContext context)
	{
		_combatStatePower = combatStatePower;
		SetModifiedAndInvalidateInfluencedCache(167, context);
	}

	public SpecialEffectList GetBreakBodyPartInjuryCount()
	{
		return _breakBodyPartInjuryCount;
	}

	public void SetBreakBodyPartInjuryCount(SpecialEffectList breakBodyPartInjuryCount, DataContext context)
	{
		_breakBodyPartInjuryCount = breakBodyPartInjuryCount;
		SetModifiedAndInvalidateInfluencedCache(168, context);
	}

	public SpecialEffectList GetBodyPartIsBroken()
	{
		return _bodyPartIsBroken;
	}

	public void SetBodyPartIsBroken(SpecialEffectList bodyPartIsBroken, DataContext context)
	{
		_bodyPartIsBroken = bodyPartIsBroken;
		SetModifiedAndInvalidateInfluencedCache(169, context);
	}

	public SpecialEffectList GetMaxTrickCount()
	{
		return _maxTrickCount;
	}

	public void SetMaxTrickCount(SpecialEffectList maxTrickCount, DataContext context)
	{
		_maxTrickCount = maxTrickCount;
		SetModifiedAndInvalidateInfluencedCache(170, context);
	}

	public SpecialEffectList GetMaxBreathPercent()
	{
		return _maxBreathPercent;
	}

	public void SetMaxBreathPercent(SpecialEffectList maxBreathPercent, DataContext context)
	{
		_maxBreathPercent = maxBreathPercent;
		SetModifiedAndInvalidateInfluencedCache(171, context);
	}

	public SpecialEffectList GetMaxStancePercent()
	{
		return _maxStancePercent;
	}

	public void SetMaxStancePercent(SpecialEffectList maxStancePercent, DataContext context)
	{
		_maxStancePercent = maxStancePercent;
		SetModifiedAndInvalidateInfluencedCache(172, context);
	}

	public SpecialEffectList GetExtraBreathPercent()
	{
		return _extraBreathPercent;
	}

	public void SetExtraBreathPercent(SpecialEffectList extraBreathPercent, DataContext context)
	{
		_extraBreathPercent = extraBreathPercent;
		SetModifiedAndInvalidateInfluencedCache(173, context);
	}

	public SpecialEffectList GetExtraStancePercent()
	{
		return _extraStancePercent;
	}

	public void SetExtraStancePercent(SpecialEffectList extraStancePercent, DataContext context)
	{
		_extraStancePercent = extraStancePercent;
		SetModifiedAndInvalidateInfluencedCache(174, context);
	}

	public SpecialEffectList GetMoveCostMobility()
	{
		return _moveCostMobility;
	}

	public void SetMoveCostMobility(SpecialEffectList moveCostMobility, DataContext context)
	{
		_moveCostMobility = moveCostMobility;
		SetModifiedAndInvalidateInfluencedCache(175, context);
	}

	public SpecialEffectList GetDefendSkillKeepTime()
	{
		return _defendSkillKeepTime;
	}

	public void SetDefendSkillKeepTime(SpecialEffectList defendSkillKeepTime, DataContext context)
	{
		_defendSkillKeepTime = defendSkillKeepTime;
		SetModifiedAndInvalidateInfluencedCache(176, context);
	}

	public SpecialEffectList GetBounceRange()
	{
		return _bounceRange;
	}

	public void SetBounceRange(SpecialEffectList bounceRange, DataContext context)
	{
		_bounceRange = bounceRange;
		SetModifiedAndInvalidateInfluencedCache(177, context);
	}

	public SpecialEffectList GetMindMarkKeepTime()
	{
		return _mindMarkKeepTime;
	}

	public void SetMindMarkKeepTime(SpecialEffectList mindMarkKeepTime, DataContext context)
	{
		_mindMarkKeepTime = mindMarkKeepTime;
		SetModifiedAndInvalidateInfluencedCache(178, context);
	}

	public SpecialEffectList GetSkillMobilityCostPerFrame()
	{
		return _skillMobilityCostPerFrame;
	}

	public void SetSkillMobilityCostPerFrame(SpecialEffectList skillMobilityCostPerFrame, DataContext context)
	{
		_skillMobilityCostPerFrame = skillMobilityCostPerFrame;
		SetModifiedAndInvalidateInfluencedCache(179, context);
	}

	public SpecialEffectList GetCanAddWug()
	{
		return _canAddWug;
	}

	public void SetCanAddWug(SpecialEffectList canAddWug, DataContext context)
	{
		_canAddWug = canAddWug;
		SetModifiedAndInvalidateInfluencedCache(180, context);
	}

	public SpecialEffectList GetHasGodWeaponBuff()
	{
		return _hasGodWeaponBuff;
	}

	public void SetHasGodWeaponBuff(SpecialEffectList hasGodWeaponBuff, DataContext context)
	{
		_hasGodWeaponBuff = hasGodWeaponBuff;
		SetModifiedAndInvalidateInfluencedCache(181, context);
	}

	public SpecialEffectList GetHasGodArmorBuff()
	{
		return _hasGodArmorBuff;
	}

	public void SetHasGodArmorBuff(SpecialEffectList hasGodArmorBuff, DataContext context)
	{
		_hasGodArmorBuff = hasGodArmorBuff;
		SetModifiedAndInvalidateInfluencedCache(182, context);
	}

	public SpecialEffectList GetTeammateCmdRequireGenerateValue()
	{
		return _teammateCmdRequireGenerateValue;
	}

	public void SetTeammateCmdRequireGenerateValue(SpecialEffectList teammateCmdRequireGenerateValue, DataContext context)
	{
		_teammateCmdRequireGenerateValue = teammateCmdRequireGenerateValue;
		SetModifiedAndInvalidateInfluencedCache(183, context);
	}

	public SpecialEffectList GetTeammateCmdEffect()
	{
		return _teammateCmdEffect;
	}

	public void SetTeammateCmdEffect(SpecialEffectList teammateCmdEffect, DataContext context)
	{
		_teammateCmdEffect = teammateCmdEffect;
		SetModifiedAndInvalidateInfluencedCache(184, context);
	}

	public SpecialEffectList GetFlawRecoverSpeed()
	{
		return _flawRecoverSpeed;
	}

	public void SetFlawRecoverSpeed(SpecialEffectList flawRecoverSpeed, DataContext context)
	{
		_flawRecoverSpeed = flawRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(185, context);
	}

	public SpecialEffectList GetAcupointRecoverSpeed()
	{
		return _acupointRecoverSpeed;
	}

	public void SetAcupointRecoverSpeed(SpecialEffectList acupointRecoverSpeed, DataContext context)
	{
		_acupointRecoverSpeed = acupointRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(186, context);
	}

	public SpecialEffectList GetMindMarkRecoverSpeed()
	{
		return _mindMarkRecoverSpeed;
	}

	public void SetMindMarkRecoverSpeed(SpecialEffectList mindMarkRecoverSpeed, DataContext context)
	{
		_mindMarkRecoverSpeed = mindMarkRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(187, context);
	}

	public SpecialEffectList GetInjuryAutoHealSpeed()
	{
		return _injuryAutoHealSpeed;
	}

	public void SetInjuryAutoHealSpeed(SpecialEffectList injuryAutoHealSpeed, DataContext context)
	{
		_injuryAutoHealSpeed = injuryAutoHealSpeed;
		SetModifiedAndInvalidateInfluencedCache(188, context);
	}

	public SpecialEffectList GetCanRecoverBreath()
	{
		return _canRecoverBreath;
	}

	public void SetCanRecoverBreath(SpecialEffectList canRecoverBreath, DataContext context)
	{
		_canRecoverBreath = canRecoverBreath;
		SetModifiedAndInvalidateInfluencedCache(189, context);
	}

	public SpecialEffectList GetCanRecoverStance()
	{
		return _canRecoverStance;
	}

	public void SetCanRecoverStance(SpecialEffectList canRecoverStance, DataContext context)
	{
		_canRecoverStance = canRecoverStance;
		SetModifiedAndInvalidateInfluencedCache(190, context);
	}

	public SpecialEffectList GetFatalDamageValue()
	{
		return _fatalDamageValue;
	}

	public void SetFatalDamageValue(SpecialEffectList fatalDamageValue, DataContext context)
	{
		_fatalDamageValue = fatalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(191, context);
	}

	public SpecialEffectList GetFatalDamageMarkCount()
	{
		return _fatalDamageMarkCount;
	}

	public void SetFatalDamageMarkCount(SpecialEffectList fatalDamageMarkCount, DataContext context)
	{
		_fatalDamageMarkCount = fatalDamageMarkCount;
		SetModifiedAndInvalidateInfluencedCache(192, context);
	}

	public SpecialEffectList GetCanFightBackDuringPrepareSkill()
	{
		return _canFightBackDuringPrepareSkill;
	}

	public void SetCanFightBackDuringPrepareSkill(SpecialEffectList canFightBackDuringPrepareSkill, DataContext context)
	{
		_canFightBackDuringPrepareSkill = canFightBackDuringPrepareSkill;
		SetModifiedAndInvalidateInfluencedCache(193, context);
	}

	public SpecialEffectList GetSkillPrepareSpeed()
	{
		return _skillPrepareSpeed;
	}

	public void SetSkillPrepareSpeed(SpecialEffectList skillPrepareSpeed, DataContext context)
	{
		_skillPrepareSpeed = skillPrepareSpeed;
		SetModifiedAndInvalidateInfluencedCache(194, context);
	}

	public SpecialEffectList GetBreathRecoverSpeed()
	{
		return _breathRecoverSpeed;
	}

	public void SetBreathRecoverSpeed(SpecialEffectList breathRecoverSpeed, DataContext context)
	{
		_breathRecoverSpeed = breathRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(195, context);
	}

	public SpecialEffectList GetStanceRecoverSpeed()
	{
		return _stanceRecoverSpeed;
	}

	public void SetStanceRecoverSpeed(SpecialEffectList stanceRecoverSpeed, DataContext context)
	{
		_stanceRecoverSpeed = stanceRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(196, context);
	}

	public SpecialEffectList GetMobilityRecoverSpeed()
	{
		return _mobilityRecoverSpeed;
	}

	public void SetMobilityRecoverSpeed(SpecialEffectList mobilityRecoverSpeed, DataContext context)
	{
		_mobilityRecoverSpeed = mobilityRecoverSpeed;
		SetModifiedAndInvalidateInfluencedCache(197, context);
	}

	public SpecialEffectList GetChangeTrickProgressAddValue()
	{
		return _changeTrickProgressAddValue;
	}

	public void SetChangeTrickProgressAddValue(SpecialEffectList changeTrickProgressAddValue, DataContext context)
	{
		_changeTrickProgressAddValue = changeTrickProgressAddValue;
		SetModifiedAndInvalidateInfluencedCache(198, context);
	}

	public SpecialEffectList GetPower()
	{
		return _power;
	}

	public void SetPower(SpecialEffectList power, DataContext context)
	{
		_power = power;
		SetModifiedAndInvalidateInfluencedCache(199, context);
	}

	public SpecialEffectList GetMaxPower()
	{
		return _maxPower;
	}

	public void SetMaxPower(SpecialEffectList maxPower, DataContext context)
	{
		_maxPower = maxPower;
		SetModifiedAndInvalidateInfluencedCache(200, context);
	}

	public SpecialEffectList GetPowerCanReduce()
	{
		return _powerCanReduce;
	}

	public void SetPowerCanReduce(SpecialEffectList powerCanReduce, DataContext context)
	{
		_powerCanReduce = powerCanReduce;
		SetModifiedAndInvalidateInfluencedCache(201, context);
	}

	public SpecialEffectList GetUseRequirement()
	{
		return _useRequirement;
	}

	public void SetUseRequirement(SpecialEffectList useRequirement, DataContext context)
	{
		_useRequirement = useRequirement;
		SetModifiedAndInvalidateInfluencedCache(202, context);
	}

	public SpecialEffectList GetCurrInnerRatio()
	{
		return _currInnerRatio;
	}

	public void SetCurrInnerRatio(SpecialEffectList currInnerRatio, DataContext context)
	{
		_currInnerRatio = currInnerRatio;
		SetModifiedAndInvalidateInfluencedCache(203, context);
	}

	public SpecialEffectList GetCostBreathAndStance()
	{
		return _costBreathAndStance;
	}

	public void SetCostBreathAndStance(SpecialEffectList costBreathAndStance, DataContext context)
	{
		_costBreathAndStance = costBreathAndStance;
		SetModifiedAndInvalidateInfluencedCache(204, context);
	}

	public SpecialEffectList GetCostBreath()
	{
		return _costBreath;
	}

	public void SetCostBreath(SpecialEffectList costBreath, DataContext context)
	{
		_costBreath = costBreath;
		SetModifiedAndInvalidateInfluencedCache(205, context);
	}

	public SpecialEffectList GetCostStance()
	{
		return _costStance;
	}

	public void SetCostStance(SpecialEffectList costStance, DataContext context)
	{
		_costStance = costStance;
		SetModifiedAndInvalidateInfluencedCache(206, context);
	}

	public SpecialEffectList GetCostMobility()
	{
		return _costMobility;
	}

	public void SetCostMobility(SpecialEffectList costMobility, DataContext context)
	{
		_costMobility = costMobility;
		SetModifiedAndInvalidateInfluencedCache(207, context);
	}

	public SpecialEffectList GetSkillCostTricks()
	{
		return _skillCostTricks;
	}

	public void SetSkillCostTricks(SpecialEffectList skillCostTricks, DataContext context)
	{
		_skillCostTricks = skillCostTricks;
		SetModifiedAndInvalidateInfluencedCache(208, context);
	}

	public SpecialEffectList GetEffectDirection()
	{
		return _effectDirection;
	}

	public void SetEffectDirection(SpecialEffectList effectDirection, DataContext context)
	{
		_effectDirection = effectDirection;
		SetModifiedAndInvalidateInfluencedCache(209, context);
	}

	public SpecialEffectList GetEffectDirectionCanChange()
	{
		return _effectDirectionCanChange;
	}

	public void SetEffectDirectionCanChange(SpecialEffectList effectDirectionCanChange, DataContext context)
	{
		_effectDirectionCanChange = effectDirectionCanChange;
		SetModifiedAndInvalidateInfluencedCache(210, context);
	}

	public SpecialEffectList GetGridCost()
	{
		return _gridCost;
	}

	public void SetGridCost(SpecialEffectList gridCost, DataContext context)
	{
		_gridCost = gridCost;
		SetModifiedAndInvalidateInfluencedCache(211, context);
	}

	public SpecialEffectList GetPrepareTotalProgress()
	{
		return _prepareTotalProgress;
	}

	public void SetPrepareTotalProgress(SpecialEffectList prepareTotalProgress, DataContext context)
	{
		_prepareTotalProgress = prepareTotalProgress;
		SetModifiedAndInvalidateInfluencedCache(212, context);
	}

	public SpecialEffectList GetSpecificGridCount()
	{
		return _specificGridCount;
	}

	public void SetSpecificGridCount(SpecialEffectList specificGridCount, DataContext context)
	{
		_specificGridCount = specificGridCount;
		SetModifiedAndInvalidateInfluencedCache(213, context);
	}

	public SpecialEffectList GetGenericGridCount()
	{
		return _genericGridCount;
	}

	public void SetGenericGridCount(SpecialEffectList genericGridCount, DataContext context)
	{
		_genericGridCount = genericGridCount;
		SetModifiedAndInvalidateInfluencedCache(214, context);
	}

	public SpecialEffectList GetCanInterrupt()
	{
		return _canInterrupt;
	}

	public void SetCanInterrupt(SpecialEffectList canInterrupt, DataContext context)
	{
		_canInterrupt = canInterrupt;
		SetModifiedAndInvalidateInfluencedCache(215, context);
	}

	public SpecialEffectList GetInterruptOdds()
	{
		return _interruptOdds;
	}

	public void SetInterruptOdds(SpecialEffectList interruptOdds, DataContext context)
	{
		_interruptOdds = interruptOdds;
		SetModifiedAndInvalidateInfluencedCache(216, context);
	}

	public SpecialEffectList GetCanSilence()
	{
		return _canSilence;
	}

	public void SetCanSilence(SpecialEffectList canSilence, DataContext context)
	{
		_canSilence = canSilence;
		SetModifiedAndInvalidateInfluencedCache(217, context);
	}

	public SpecialEffectList GetSilenceOdds()
	{
		return _silenceOdds;
	}

	public void SetSilenceOdds(SpecialEffectList silenceOdds, DataContext context)
	{
		_silenceOdds = silenceOdds;
		SetModifiedAndInvalidateInfluencedCache(218, context);
	}

	public SpecialEffectList GetCanCastWithBrokenBodyPart()
	{
		return _canCastWithBrokenBodyPart;
	}

	public void SetCanCastWithBrokenBodyPart(SpecialEffectList canCastWithBrokenBodyPart, DataContext context)
	{
		_canCastWithBrokenBodyPart = canCastWithBrokenBodyPart;
		SetModifiedAndInvalidateInfluencedCache(219, context);
	}

	public SpecialEffectList GetAddPowerCanBeRemoved()
	{
		return _addPowerCanBeRemoved;
	}

	public void SetAddPowerCanBeRemoved(SpecialEffectList addPowerCanBeRemoved, DataContext context)
	{
		_addPowerCanBeRemoved = addPowerCanBeRemoved;
		SetModifiedAndInvalidateInfluencedCache(220, context);
	}

	public SpecialEffectList GetSkillType()
	{
		return _skillType;
	}

	public void SetSkillType(SpecialEffectList skillType, DataContext context)
	{
		_skillType = skillType;
		SetModifiedAndInvalidateInfluencedCache(221, context);
	}

	public SpecialEffectList GetEffectCountCanChange()
	{
		return _effectCountCanChange;
	}

	public void SetEffectCountCanChange(SpecialEffectList effectCountCanChange, DataContext context)
	{
		_effectCountCanChange = effectCountCanChange;
		SetModifiedAndInvalidateInfluencedCache(222, context);
	}

	public SpecialEffectList GetCanCastInDefend()
	{
		return _canCastInDefend;
	}

	public void SetCanCastInDefend(SpecialEffectList canCastInDefend, DataContext context)
	{
		_canCastInDefend = canCastInDefend;
		SetModifiedAndInvalidateInfluencedCache(223, context);
	}

	public SpecialEffectList GetHitDistribution()
	{
		return _hitDistribution;
	}

	public void SetHitDistribution(SpecialEffectList hitDistribution, DataContext context)
	{
		_hitDistribution = hitDistribution;
		SetModifiedAndInvalidateInfluencedCache(224, context);
	}

	public SpecialEffectList GetCanCastOnLackBreath()
	{
		return _canCastOnLackBreath;
	}

	public void SetCanCastOnLackBreath(SpecialEffectList canCastOnLackBreath, DataContext context)
	{
		_canCastOnLackBreath = canCastOnLackBreath;
		SetModifiedAndInvalidateInfluencedCache(225, context);
	}

	public SpecialEffectList GetCanCastOnLackStance()
	{
		return _canCastOnLackStance;
	}

	public void SetCanCastOnLackStance(SpecialEffectList canCastOnLackStance, DataContext context)
	{
		_canCastOnLackStance = canCastOnLackStance;
		SetModifiedAndInvalidateInfluencedCache(226, context);
	}

	public SpecialEffectList GetCostBreathOnCast()
	{
		return _costBreathOnCast;
	}

	public void SetCostBreathOnCast(SpecialEffectList costBreathOnCast, DataContext context)
	{
		_costBreathOnCast = costBreathOnCast;
		SetModifiedAndInvalidateInfluencedCache(227, context);
	}

	public SpecialEffectList GetCostStanceOnCast()
	{
		return _costStanceOnCast;
	}

	public void SetCostStanceOnCast(SpecialEffectList costStanceOnCast, DataContext context)
	{
		_costStanceOnCast = costStanceOnCast;
		SetModifiedAndInvalidateInfluencedCache(228, context);
	}

	public SpecialEffectList GetCanUseMobilityAsBreath()
	{
		return _canUseMobilityAsBreath;
	}

	public void SetCanUseMobilityAsBreath(SpecialEffectList canUseMobilityAsBreath, DataContext context)
	{
		_canUseMobilityAsBreath = canUseMobilityAsBreath;
		SetModifiedAndInvalidateInfluencedCache(229, context);
	}

	public SpecialEffectList GetCanUseMobilityAsStance()
	{
		return _canUseMobilityAsStance;
	}

	public void SetCanUseMobilityAsStance(SpecialEffectList canUseMobilityAsStance, DataContext context)
	{
		_canUseMobilityAsStance = canUseMobilityAsStance;
		SetModifiedAndInvalidateInfluencedCache(230, context);
	}

	public SpecialEffectList GetCastCostNeiliAllocation()
	{
		return _castCostNeiliAllocation;
	}

	public void SetCastCostNeiliAllocation(SpecialEffectList castCostNeiliAllocation, DataContext context)
	{
		_castCostNeiliAllocation = castCostNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(231, context);
	}

	public SpecialEffectList GetAcceptPoisonResist()
	{
		return _acceptPoisonResist;
	}

	public void SetAcceptPoisonResist(SpecialEffectList acceptPoisonResist, DataContext context)
	{
		_acceptPoisonResist = acceptPoisonResist;
		SetModifiedAndInvalidateInfluencedCache(232, context);
	}

	public SpecialEffectList GetMakePoisonResist()
	{
		return _makePoisonResist;
	}

	public void SetMakePoisonResist(SpecialEffectList makePoisonResist, DataContext context)
	{
		_makePoisonResist = makePoisonResist;
		SetModifiedAndInvalidateInfluencedCache(233, context);
	}

	public SpecialEffectList GetCanCriticalHit()
	{
		return _canCriticalHit;
	}

	public void SetCanCriticalHit(SpecialEffectList canCriticalHit, DataContext context)
	{
		_canCriticalHit = canCriticalHit;
		SetModifiedAndInvalidateInfluencedCache(234, context);
	}

	public SpecialEffectList GetCanCostNeiliAllocationEffect()
	{
		return _canCostNeiliAllocationEffect;
	}

	public void SetCanCostNeiliAllocationEffect(SpecialEffectList canCostNeiliAllocationEffect, DataContext context)
	{
		_canCostNeiliAllocationEffect = canCostNeiliAllocationEffect;
		SetModifiedAndInvalidateInfluencedCache(235, context);
	}

	public SpecialEffectList GetConsummateLevelRelatedMainAttributesHitValues()
	{
		return _consummateLevelRelatedMainAttributesHitValues;
	}

	public void SetConsummateLevelRelatedMainAttributesHitValues(SpecialEffectList consummateLevelRelatedMainAttributesHitValues, DataContext context)
	{
		_consummateLevelRelatedMainAttributesHitValues = consummateLevelRelatedMainAttributesHitValues;
		SetModifiedAndInvalidateInfluencedCache(236, context);
	}

	public SpecialEffectList GetConsummateLevelRelatedMainAttributesAvoidValues()
	{
		return _consummateLevelRelatedMainAttributesAvoidValues;
	}

	public void SetConsummateLevelRelatedMainAttributesAvoidValues(SpecialEffectList consummateLevelRelatedMainAttributesAvoidValues, DataContext context)
	{
		_consummateLevelRelatedMainAttributesAvoidValues = consummateLevelRelatedMainAttributesAvoidValues;
		SetModifiedAndInvalidateInfluencedCache(237, context);
	}

	public SpecialEffectList GetConsummateLevelRelatedMainAttributesPenetrations()
	{
		return _consummateLevelRelatedMainAttributesPenetrations;
	}

	public void SetConsummateLevelRelatedMainAttributesPenetrations(SpecialEffectList consummateLevelRelatedMainAttributesPenetrations, DataContext context)
	{
		_consummateLevelRelatedMainAttributesPenetrations = consummateLevelRelatedMainAttributesPenetrations;
		SetModifiedAndInvalidateInfluencedCache(238, context);
	}

	public SpecialEffectList GetConsummateLevelRelatedMainAttributesPenetrationResists()
	{
		return _consummateLevelRelatedMainAttributesPenetrationResists;
	}

	public void SetConsummateLevelRelatedMainAttributesPenetrationResists(SpecialEffectList consummateLevelRelatedMainAttributesPenetrationResists, DataContext context)
	{
		_consummateLevelRelatedMainAttributesPenetrationResists = consummateLevelRelatedMainAttributesPenetrationResists;
		SetModifiedAndInvalidateInfluencedCache(239, context);
	}

	public SpecialEffectList GetSkillAlsoAsFiveElements()
	{
		return _skillAlsoAsFiveElements;
	}

	public void SetSkillAlsoAsFiveElements(SpecialEffectList skillAlsoAsFiveElements, DataContext context)
	{
		_skillAlsoAsFiveElements = skillAlsoAsFiveElements;
		SetModifiedAndInvalidateInfluencedCache(240, context);
	}

	public SpecialEffectList GetInnerInjuryImmunity()
	{
		return _innerInjuryImmunity;
	}

	public void SetInnerInjuryImmunity(SpecialEffectList innerInjuryImmunity, DataContext context)
	{
		_innerInjuryImmunity = innerInjuryImmunity;
		SetModifiedAndInvalidateInfluencedCache(241, context);
	}

	public SpecialEffectList GetOuterInjuryImmunity()
	{
		return _outerInjuryImmunity;
	}

	public void SetOuterInjuryImmunity(SpecialEffectList outerInjuryImmunity, DataContext context)
	{
		_outerInjuryImmunity = outerInjuryImmunity;
		SetModifiedAndInvalidateInfluencedCache(242, context);
	}

	public SpecialEffectList GetPoisonAffectThreshold()
	{
		return _poisonAffectThreshold;
	}

	public void SetPoisonAffectThreshold(SpecialEffectList poisonAffectThreshold, DataContext context)
	{
		_poisonAffectThreshold = poisonAffectThreshold;
		SetModifiedAndInvalidateInfluencedCache(243, context);
	}

	public SpecialEffectList GetLockDistance()
	{
		return _lockDistance;
	}

	public void SetLockDistance(SpecialEffectList lockDistance, DataContext context)
	{
		_lockDistance = lockDistance;
		SetModifiedAndInvalidateInfluencedCache(244, context);
	}

	public SpecialEffectList GetResistOfAllPoison()
	{
		return _resistOfAllPoison;
	}

	public void SetResistOfAllPoison(SpecialEffectList resistOfAllPoison, DataContext context)
	{
		_resistOfAllPoison = resistOfAllPoison;
		SetModifiedAndInvalidateInfluencedCache(245, context);
	}

	public SpecialEffectList GetMakePoisonTarget()
	{
		return _makePoisonTarget;
	}

	public void SetMakePoisonTarget(SpecialEffectList makePoisonTarget, DataContext context)
	{
		_makePoisonTarget = makePoisonTarget;
		SetModifiedAndInvalidateInfluencedCache(246, context);
	}

	public SpecialEffectList GetAcceptPoisonTarget()
	{
		return _acceptPoisonTarget;
	}

	public void SetAcceptPoisonTarget(SpecialEffectList acceptPoisonTarget, DataContext context)
	{
		_acceptPoisonTarget = acceptPoisonTarget;
		SetModifiedAndInvalidateInfluencedCache(247, context);
	}

	public SpecialEffectList GetCertainCriticalHit()
	{
		return _certainCriticalHit;
	}

	public void SetCertainCriticalHit(SpecialEffectList certainCriticalHit, DataContext context)
	{
		_certainCriticalHit = certainCriticalHit;
		SetModifiedAndInvalidateInfluencedCache(248, context);
	}

	public SpecialEffectList GetMindMarkCount()
	{
		return _mindMarkCount;
	}

	public void SetMindMarkCount(SpecialEffectList mindMarkCount, DataContext context)
	{
		_mindMarkCount = mindMarkCount;
		SetModifiedAndInvalidateInfluencedCache(249, context);
	}

	public SpecialEffectList GetCanFightBackWithHit()
	{
		return _canFightBackWithHit;
	}

	public void SetCanFightBackWithHit(SpecialEffectList canFightBackWithHit, DataContext context)
	{
		_canFightBackWithHit = canFightBackWithHit;
		SetModifiedAndInvalidateInfluencedCache(250, context);
	}

	public SpecialEffectList GetInevitableHit()
	{
		return _inevitableHit;
	}

	public void SetInevitableHit(SpecialEffectList inevitableHit, DataContext context)
	{
		_inevitableHit = inevitableHit;
		SetModifiedAndInvalidateInfluencedCache(251, context);
	}

	public SpecialEffectList GetAttackCanPursue()
	{
		return _attackCanPursue;
	}

	public void SetAttackCanPursue(SpecialEffectList attackCanPursue, DataContext context)
	{
		_attackCanPursue = attackCanPursue;
		SetModifiedAndInvalidateInfluencedCache(252, context);
	}

	public SpecialEffectList GetCombatSkillDataEffectList()
	{
		return _combatSkillDataEffectList;
	}

	public void SetCombatSkillDataEffectList(SpecialEffectList combatSkillDataEffectList, DataContext context)
	{
		_combatSkillDataEffectList = combatSkillDataEffectList;
		SetModifiedAndInvalidateInfluencedCache(253, context);
	}

	public SpecialEffectList GetStanceCostByEffect()
	{
		return _stanceCostByEffect;
	}

	public void SetStanceCostByEffect(SpecialEffectList stanceCostByEffect, DataContext context)
	{
		_stanceCostByEffect = stanceCostByEffect;
		SetModifiedAndInvalidateInfluencedCache(254, context);
	}

	public SpecialEffectList GetBreathCostByEffect()
	{
		return _breathCostByEffect;
	}

	public void SetBreathCostByEffect(SpecialEffectList breathCostByEffect, DataContext context)
	{
		_breathCostByEffect = breathCostByEffect;
		SetModifiedAndInvalidateInfluencedCache(255, context);
	}

	public SpecialEffectList GetPowerAddRatio()
	{
		return _powerAddRatio;
	}

	public void SetPowerAddRatio(SpecialEffectList powerAddRatio, DataContext context)
	{
		_powerAddRatio = powerAddRatio;
		SetModifiedAndInvalidateInfluencedCache(256, context);
	}

	public SpecialEffectList GetPowerReduceRatio()
	{
		return _powerReduceRatio;
	}

	public void SetPowerReduceRatio(SpecialEffectList powerReduceRatio, DataContext context)
	{
		_powerReduceRatio = powerReduceRatio;
		SetModifiedAndInvalidateInfluencedCache(257, context);
	}

	public SpecialEffectList GetPoisonAffectProduceValue()
	{
		return _poisonAffectProduceValue;
	}

	public void SetPoisonAffectProduceValue(SpecialEffectList poisonAffectProduceValue, DataContext context)
	{
		_poisonAffectProduceValue = poisonAffectProduceValue;
		SetModifiedAndInvalidateInfluencedCache(258, context);
	}

	public SpecialEffectList GetCanReadingOnMonthChange()
	{
		return _canReadingOnMonthChange;
	}

	public void SetCanReadingOnMonthChange(SpecialEffectList canReadingOnMonthChange, DataContext context)
	{
		_canReadingOnMonthChange = canReadingOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(259, context);
	}

	public SpecialEffectList GetMedicineEffect()
	{
		return _medicineEffect;
	}

	public void SetMedicineEffect(SpecialEffectList medicineEffect, DataContext context)
	{
		_medicineEffect = medicineEffect;
		SetModifiedAndInvalidateInfluencedCache(260, context);
	}

	public SpecialEffectList GetXiangshuInfectionDelta()
	{
		return _xiangshuInfectionDelta;
	}

	public void SetXiangshuInfectionDelta(SpecialEffectList xiangshuInfectionDelta, DataContext context)
	{
		_xiangshuInfectionDelta = xiangshuInfectionDelta;
		SetModifiedAndInvalidateInfluencedCache(261, context);
	}

	public SpecialEffectList GetHealthDelta()
	{
		return _healthDelta;
	}

	public void SetHealthDelta(SpecialEffectList healthDelta, DataContext context)
	{
		_healthDelta = healthDelta;
		SetModifiedAndInvalidateInfluencedCache(262, context);
	}

	public SpecialEffectList GetWeaponSilenceFrame()
	{
		return _weaponSilenceFrame;
	}

	public void SetWeaponSilenceFrame(SpecialEffectList weaponSilenceFrame, DataContext context)
	{
		_weaponSilenceFrame = weaponSilenceFrame;
		SetModifiedAndInvalidateInfluencedCache(263, context);
	}

	public SpecialEffectList GetSilenceFrame()
	{
		return _silenceFrame;
	}

	public void SetSilenceFrame(SpecialEffectList silenceFrame, DataContext context)
	{
		_silenceFrame = silenceFrame;
		SetModifiedAndInvalidateInfluencedCache(264, context);
	}

	public SpecialEffectList GetCurrAgeDelta()
	{
		return _currAgeDelta;
	}

	public void SetCurrAgeDelta(SpecialEffectList currAgeDelta, DataContext context)
	{
		_currAgeDelta = currAgeDelta;
		SetModifiedAndInvalidateInfluencedCache(265, context);
	}

	public SpecialEffectList GetGoneMadInAllBreak()
	{
		return _goneMadInAllBreak;
	}

	public void SetGoneMadInAllBreak(SpecialEffectList goneMadInAllBreak, DataContext context)
	{
		_goneMadInAllBreak = goneMadInAllBreak;
		SetModifiedAndInvalidateInfluencedCache(266, context);
	}

	public SpecialEffectList GetMakeLoveRateOnMonthChange()
	{
		return _makeLoveRateOnMonthChange;
	}

	public void SetMakeLoveRateOnMonthChange(SpecialEffectList makeLoveRateOnMonthChange, DataContext context)
	{
		_makeLoveRateOnMonthChange = makeLoveRateOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(267, context);
	}

	public SpecialEffectList GetCanAutoHealOnMonthChange()
	{
		return _canAutoHealOnMonthChange;
	}

	public void SetCanAutoHealOnMonthChange(SpecialEffectList canAutoHealOnMonthChange, DataContext context)
	{
		_canAutoHealOnMonthChange = canAutoHealOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(268, context);
	}

	public SpecialEffectList GetHappinessDelta()
	{
		return _happinessDelta;
	}

	public void SetHappinessDelta(SpecialEffectList happinessDelta, DataContext context)
	{
		_happinessDelta = happinessDelta;
		SetModifiedAndInvalidateInfluencedCache(269, context);
	}

	public SpecialEffectList GetTeammateCmdCanUse()
	{
		return _teammateCmdCanUse;
	}

	public void SetTeammateCmdCanUse(SpecialEffectList teammateCmdCanUse, DataContext context)
	{
		_teammateCmdCanUse = teammateCmdCanUse;
		SetModifiedAndInvalidateInfluencedCache(270, context);
	}

	public SpecialEffectList GetMixPoisonInfinityAffect()
	{
		return _mixPoisonInfinityAffect;
	}

	public void SetMixPoisonInfinityAffect(SpecialEffectList mixPoisonInfinityAffect, DataContext context)
	{
		_mixPoisonInfinityAffect = mixPoisonInfinityAffect;
		SetModifiedAndInvalidateInfluencedCache(271, context);
	}

	public SpecialEffectList GetAttackRangeMaxAcupoint()
	{
		return _attackRangeMaxAcupoint;
	}

	public void SetAttackRangeMaxAcupoint(SpecialEffectList attackRangeMaxAcupoint, DataContext context)
	{
		_attackRangeMaxAcupoint = attackRangeMaxAcupoint;
		SetModifiedAndInvalidateInfluencedCache(272, context);
	}

	public SpecialEffectList GetMaxMobilityPercent()
	{
		return _maxMobilityPercent;
	}

	public void SetMaxMobilityPercent(SpecialEffectList maxMobilityPercent, DataContext context)
	{
		_maxMobilityPercent = maxMobilityPercent;
		SetModifiedAndInvalidateInfluencedCache(273, context);
	}

	public SpecialEffectList GetMakeMindDamage()
	{
		return _makeMindDamage;
	}

	public void SetMakeMindDamage(SpecialEffectList makeMindDamage, DataContext context)
	{
		_makeMindDamage = makeMindDamage;
		SetModifiedAndInvalidateInfluencedCache(274, context);
	}

	public SpecialEffectList GetAcceptMindDamage()
	{
		return _acceptMindDamage;
	}

	public void SetAcceptMindDamage(SpecialEffectList acceptMindDamage, DataContext context)
	{
		_acceptMindDamage = acceptMindDamage;
		SetModifiedAndInvalidateInfluencedCache(275, context);
	}

	public SpecialEffectList GetHitAddByTempValue()
	{
		return _hitAddByTempValue;
	}

	public void SetHitAddByTempValue(SpecialEffectList hitAddByTempValue, DataContext context)
	{
		_hitAddByTempValue = hitAddByTempValue;
		SetModifiedAndInvalidateInfluencedCache(276, context);
	}

	public SpecialEffectList GetAvoidAddByTempValue()
	{
		return _avoidAddByTempValue;
	}

	public void SetAvoidAddByTempValue(SpecialEffectList avoidAddByTempValue, DataContext context)
	{
		_avoidAddByTempValue = avoidAddByTempValue;
		SetModifiedAndInvalidateInfluencedCache(277, context);
	}

	public SpecialEffectList GetIgnoreEquipmentOverload()
	{
		return _ignoreEquipmentOverload;
	}

	public void SetIgnoreEquipmentOverload(SpecialEffectList ignoreEquipmentOverload, DataContext context)
	{
		_ignoreEquipmentOverload = ignoreEquipmentOverload;
		SetModifiedAndInvalidateInfluencedCache(278, context);
	}

	public SpecialEffectList GetCanCostEnemyUsableTricks()
	{
		return _canCostEnemyUsableTricks;
	}

	public void SetCanCostEnemyUsableTricks(SpecialEffectList canCostEnemyUsableTricks, DataContext context)
	{
		_canCostEnemyUsableTricks = canCostEnemyUsableTricks;
		SetModifiedAndInvalidateInfluencedCache(279, context);
	}

	public SpecialEffectList GetIgnoreArmor()
	{
		return _ignoreArmor;
	}

	public void SetIgnoreArmor(SpecialEffectList ignoreArmor, DataContext context)
	{
		_ignoreArmor = ignoreArmor;
		SetModifiedAndInvalidateInfluencedCache(280, context);
	}

	public SpecialEffectList GetUnyieldingFallen()
	{
		return _unyieldingFallen;
	}

	public void SetUnyieldingFallen(SpecialEffectList unyieldingFallen, DataContext context)
	{
		_unyieldingFallen = unyieldingFallen;
		SetModifiedAndInvalidateInfluencedCache(281, context);
	}

	public SpecialEffectList GetNormalAttackPrepareFrame()
	{
		return _normalAttackPrepareFrame;
	}

	public void SetNormalAttackPrepareFrame(SpecialEffectList normalAttackPrepareFrame, DataContext context)
	{
		_normalAttackPrepareFrame = normalAttackPrepareFrame;
		SetModifiedAndInvalidateInfluencedCache(282, context);
	}

	public SpecialEffectList GetCanCostUselessTricks()
	{
		return _canCostUselessTricks;
	}

	public void SetCanCostUselessTricks(SpecialEffectList canCostUselessTricks, DataContext context)
	{
		_canCostUselessTricks = canCostUselessTricks;
		SetModifiedAndInvalidateInfluencedCache(283, context);
	}

	public SpecialEffectList GetDefendSkillCanAffect()
	{
		return _defendSkillCanAffect;
	}

	public void SetDefendSkillCanAffect(SpecialEffectList defendSkillCanAffect, DataContext context)
	{
		_defendSkillCanAffect = defendSkillCanAffect;
		SetModifiedAndInvalidateInfluencedCache(284, context);
	}

	public SpecialEffectList GetAssistSkillCanAffect()
	{
		return _assistSkillCanAffect;
	}

	public void SetAssistSkillCanAffect(SpecialEffectList assistSkillCanAffect, DataContext context)
	{
		_assistSkillCanAffect = assistSkillCanAffect;
		SetModifiedAndInvalidateInfluencedCache(285, context);
	}

	public SpecialEffectList GetAgileSkillCanAffect()
	{
		return _agileSkillCanAffect;
	}

	public void SetAgileSkillCanAffect(SpecialEffectList agileSkillCanAffect, DataContext context)
	{
		_agileSkillCanAffect = agileSkillCanAffect;
		SetModifiedAndInvalidateInfluencedCache(286, context);
	}

	public SpecialEffectList GetAllMarkChangeToMind()
	{
		return _allMarkChangeToMind;
	}

	public void SetAllMarkChangeToMind(SpecialEffectList allMarkChangeToMind, DataContext context)
	{
		_allMarkChangeToMind = allMarkChangeToMind;
		SetModifiedAndInvalidateInfluencedCache(287, context);
	}

	public SpecialEffectList GetMindMarkChangeToFatal()
	{
		return _mindMarkChangeToFatal;
	}

	public void SetMindMarkChangeToFatal(SpecialEffectList mindMarkChangeToFatal, DataContext context)
	{
		_mindMarkChangeToFatal = mindMarkChangeToFatal;
		SetModifiedAndInvalidateInfluencedCache(288, context);
	}

	public SpecialEffectList GetCanCast()
	{
		return _canCast;
	}

	public void SetCanCast(SpecialEffectList canCast, DataContext context)
	{
		_canCast = canCast;
		SetModifiedAndInvalidateInfluencedCache(289, context);
	}

	public SpecialEffectList GetInevitableAvoid()
	{
		return _inevitableAvoid;
	}

	public void SetInevitableAvoid(SpecialEffectList inevitableAvoid, DataContext context)
	{
		_inevitableAvoid = inevitableAvoid;
		SetModifiedAndInvalidateInfluencedCache(290, context);
	}

	public SpecialEffectList GetPowerEffectReverse()
	{
		return _powerEffectReverse;
	}

	public void SetPowerEffectReverse(SpecialEffectList powerEffectReverse, DataContext context)
	{
		_powerEffectReverse = powerEffectReverse;
		SetModifiedAndInvalidateInfluencedCache(291, context);
	}

	public SpecialEffectList GetFeatureBonusReverse()
	{
		return _featureBonusReverse;
	}

	public void SetFeatureBonusReverse(SpecialEffectList featureBonusReverse, DataContext context)
	{
		_featureBonusReverse = featureBonusReverse;
		SetModifiedAndInvalidateInfluencedCache(292, context);
	}

	public SpecialEffectList GetWugFatalDamageValue()
	{
		return _wugFatalDamageValue;
	}

	public void SetWugFatalDamageValue(SpecialEffectList wugFatalDamageValue, DataContext context)
	{
		_wugFatalDamageValue = wugFatalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(293, context);
	}

	public SpecialEffectList GetCanRecoverHealthOnMonthChange()
	{
		return _canRecoverHealthOnMonthChange;
	}

	public void SetCanRecoverHealthOnMonthChange(SpecialEffectList canRecoverHealthOnMonthChange, DataContext context)
	{
		_canRecoverHealthOnMonthChange = canRecoverHealthOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(294, context);
	}

	public SpecialEffectList GetTakeRevengeRateOnMonthChange()
	{
		return _takeRevengeRateOnMonthChange;
	}

	public void SetTakeRevengeRateOnMonthChange(SpecialEffectList takeRevengeRateOnMonthChange, DataContext context)
	{
		_takeRevengeRateOnMonthChange = takeRevengeRateOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(295, context);
	}

	public SpecialEffectList GetConsummateLevelBonus()
	{
		return _consummateLevelBonus;
	}

	public void SetConsummateLevelBonus(SpecialEffectList consummateLevelBonus, DataContext context)
	{
		_consummateLevelBonus = consummateLevelBonus;
		SetModifiedAndInvalidateInfluencedCache(296, context);
	}

	public SpecialEffectList GetNeiliDelta()
	{
		return _neiliDelta;
	}

	public void SetNeiliDelta(SpecialEffectList neiliDelta, DataContext context)
	{
		_neiliDelta = neiliDelta;
		SetModifiedAndInvalidateInfluencedCache(297, context);
	}

	public SpecialEffectList GetCanMakeLoveSpecialOnMonthChange()
	{
		return _canMakeLoveSpecialOnMonthChange;
	}

	public void SetCanMakeLoveSpecialOnMonthChange(SpecialEffectList canMakeLoveSpecialOnMonthChange, DataContext context)
	{
		_canMakeLoveSpecialOnMonthChange = canMakeLoveSpecialOnMonthChange;
		SetModifiedAndInvalidateInfluencedCache(298, context);
	}

	public SpecialEffectList GetHealAcupointSpeed()
	{
		return _healAcupointSpeed;
	}

	public void SetHealAcupointSpeed(SpecialEffectList healAcupointSpeed, DataContext context)
	{
		_healAcupointSpeed = healAcupointSpeed;
		SetModifiedAndInvalidateInfluencedCache(299, context);
	}

	public SpecialEffectList GetMaxChangeTrickCount()
	{
		return _maxChangeTrickCount;
	}

	public void SetMaxChangeTrickCount(SpecialEffectList maxChangeTrickCount, DataContext context)
	{
		_maxChangeTrickCount = maxChangeTrickCount;
		SetModifiedAndInvalidateInfluencedCache(300, context);
	}

	public SpecialEffectList GetConvertCostBreathAndStance()
	{
		return _convertCostBreathAndStance;
	}

	public void SetConvertCostBreathAndStance(SpecialEffectList convertCostBreathAndStance, DataContext context)
	{
		_convertCostBreathAndStance = convertCostBreathAndStance;
		SetModifiedAndInvalidateInfluencedCache(301, context);
	}

	public SpecialEffectList GetPersonalitiesAll()
	{
		return _personalitiesAll;
	}

	public void SetPersonalitiesAll(SpecialEffectList personalitiesAll, DataContext context)
	{
		_personalitiesAll = personalitiesAll;
		SetModifiedAndInvalidateInfluencedCache(302, context);
	}

	public SpecialEffectList GetFinalFatalDamageMarkCount()
	{
		return _finalFatalDamageMarkCount;
	}

	public void SetFinalFatalDamageMarkCount(SpecialEffectList finalFatalDamageMarkCount, DataContext context)
	{
		_finalFatalDamageMarkCount = finalFatalDamageMarkCount;
		SetModifiedAndInvalidateInfluencedCache(303, context);
	}

	public SpecialEffectList GetCombatSkillAiScorePower()
	{
		return _combatSkillAiScorePower;
	}

	public void SetCombatSkillAiScorePower(SpecialEffectList combatSkillAiScorePower, DataContext context)
	{
		_combatSkillAiScorePower = combatSkillAiScorePower;
		SetModifiedAndInvalidateInfluencedCache(304, context);
	}

	public SpecialEffectList GetNormalAttackChangeToUnlockAttack()
	{
		return _normalAttackChangeToUnlockAttack;
	}

	public void SetNormalAttackChangeToUnlockAttack(SpecialEffectList normalAttackChangeToUnlockAttack, DataContext context)
	{
		_normalAttackChangeToUnlockAttack = normalAttackChangeToUnlockAttack;
		SetModifiedAndInvalidateInfluencedCache(305, context);
	}

	public SpecialEffectList GetAttackBodyPartOdds()
	{
		return _attackBodyPartOdds;
	}

	public void SetAttackBodyPartOdds(SpecialEffectList attackBodyPartOdds, DataContext context)
	{
		_attackBodyPartOdds = attackBodyPartOdds;
		SetModifiedAndInvalidateInfluencedCache(306, context);
	}

	public SpecialEffectList GetChangeDurability()
	{
		return _changeDurability;
	}

	public void SetChangeDurability(SpecialEffectList changeDurability, DataContext context)
	{
		_changeDurability = changeDurability;
		SetModifiedAndInvalidateInfluencedCache(307, context);
	}

	public SpecialEffectList GetEquipmentBonus()
	{
		return _equipmentBonus;
	}

	public void SetEquipmentBonus(SpecialEffectList equipmentBonus, DataContext context)
	{
		_equipmentBonus = equipmentBonus;
		SetModifiedAndInvalidateInfluencedCache(308, context);
	}

	public SpecialEffectList GetEquipmentWeight()
	{
		return _equipmentWeight;
	}

	public void SetEquipmentWeight(SpecialEffectList equipmentWeight, DataContext context)
	{
		_equipmentWeight = equipmentWeight;
		SetModifiedAndInvalidateInfluencedCache(309, context);
	}

	public SpecialEffectList GetRawCreateEffectList()
	{
		return _rawCreateEffectList;
	}

	public void SetRawCreateEffectList(SpecialEffectList rawCreateEffectList, DataContext context)
	{
		_rawCreateEffectList = rawCreateEffectList;
		SetModifiedAndInvalidateInfluencedCache(310, context);
	}

	public SpecialEffectList GetJiTrickAsWeaponTrickCount()
	{
		return _jiTrickAsWeaponTrickCount;
	}

	public void SetJiTrickAsWeaponTrickCount(SpecialEffectList jiTrickAsWeaponTrickCount, DataContext context)
	{
		_jiTrickAsWeaponTrickCount = jiTrickAsWeaponTrickCount;
		SetModifiedAndInvalidateInfluencedCache(311, context);
	}

	public SpecialEffectList GetUselessTrickAsJiTrickCount()
	{
		return _uselessTrickAsJiTrickCount;
	}

	public void SetUselessTrickAsJiTrickCount(SpecialEffectList uselessTrickAsJiTrickCount, DataContext context)
	{
		_uselessTrickAsJiTrickCount = uselessTrickAsJiTrickCount;
		SetModifiedAndInvalidateInfluencedCache(312, context);
	}

	public SpecialEffectList GetEquipmentPower()
	{
		return _equipmentPower;
	}

	public void SetEquipmentPower(SpecialEffectList equipmentPower, DataContext context)
	{
		_equipmentPower = equipmentPower;
		SetModifiedAndInvalidateInfluencedCache(313, context);
	}

	public SpecialEffectList GetHealFlawSpeed()
	{
		return _healFlawSpeed;
	}

	public void SetHealFlawSpeed(SpecialEffectList healFlawSpeed, DataContext context)
	{
		_healFlawSpeed = healFlawSpeed;
		SetModifiedAndInvalidateInfluencedCache(314, context);
	}

	public SpecialEffectList GetUnlockSpeed()
	{
		return _unlockSpeed;
	}

	public void SetUnlockSpeed(SpecialEffectList unlockSpeed, DataContext context)
	{
		_unlockSpeed = unlockSpeed;
		SetModifiedAndInvalidateInfluencedCache(315, context);
	}

	public SpecialEffectList GetFlawBonusFactor()
	{
		return _flawBonusFactor;
	}

	public void SetFlawBonusFactor(SpecialEffectList flawBonusFactor, DataContext context)
	{
		_flawBonusFactor = flawBonusFactor;
		SetModifiedAndInvalidateInfluencedCache(316, context);
	}

	public SpecialEffectList GetCanCostShaTricks()
	{
		return _canCostShaTricks;
	}

	public void SetCanCostShaTricks(SpecialEffectList canCostShaTricks, DataContext context)
	{
		_canCostShaTricks = canCostShaTricks;
		SetModifiedAndInvalidateInfluencedCache(317, context);
	}

	public SpecialEffectList GetDefenderDirectFinalDamageValue()
	{
		return _defenderDirectFinalDamageValue;
	}

	public void SetDefenderDirectFinalDamageValue(SpecialEffectList defenderDirectFinalDamageValue, DataContext context)
	{
		_defenderDirectFinalDamageValue = defenderDirectFinalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(318, context);
	}

	public SpecialEffectList GetNormalAttackRecoveryFrame()
	{
		return _normalAttackRecoveryFrame;
	}

	public void SetNormalAttackRecoveryFrame(SpecialEffectList normalAttackRecoveryFrame, DataContext context)
	{
		_normalAttackRecoveryFrame = normalAttackRecoveryFrame;
		SetModifiedAndInvalidateInfluencedCache(319, context);
	}

	public SpecialEffectList GetFinalGoneMadInjury()
	{
		return _finalGoneMadInjury;
	}

	public void SetFinalGoneMadInjury(SpecialEffectList finalGoneMadInjury, DataContext context)
	{
		_finalGoneMadInjury = finalGoneMadInjury;
		SetModifiedAndInvalidateInfluencedCache(320, context);
	}

	public SpecialEffectList GetAttackerDirectFinalDamageValue()
	{
		return _attackerDirectFinalDamageValue;
	}

	public void SetAttackerDirectFinalDamageValue(SpecialEffectList attackerDirectFinalDamageValue, DataContext context)
	{
		_attackerDirectFinalDamageValue = attackerDirectFinalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(321, context);
	}

	public SpecialEffectList GetCanCostTrickDuringPreparingSkill()
	{
		return _canCostTrickDuringPreparingSkill;
	}

	public void SetCanCostTrickDuringPreparingSkill(SpecialEffectList canCostTrickDuringPreparingSkill, DataContext context)
	{
		_canCostTrickDuringPreparingSkill = canCostTrickDuringPreparingSkill;
		SetModifiedAndInvalidateInfluencedCache(322, context);
	}

	public SpecialEffectList GetValidItemList()
	{
		return _validItemList;
	}

	public void SetValidItemList(SpecialEffectList validItemList, DataContext context)
	{
		_validItemList = validItemList;
		SetModifiedAndInvalidateInfluencedCache(323, context);
	}

	public SpecialEffectList GetAcceptDamageCanAdd()
	{
		return _acceptDamageCanAdd;
	}

	public void SetAcceptDamageCanAdd(SpecialEffectList acceptDamageCanAdd, DataContext context)
	{
		_acceptDamageCanAdd = acceptDamageCanAdd;
		SetModifiedAndInvalidateInfluencedCache(324, context);
	}

	public SpecialEffectList GetMakeDamageCanReduce()
	{
		return _makeDamageCanReduce;
	}

	public void SetMakeDamageCanReduce(SpecialEffectList makeDamageCanReduce, DataContext context)
	{
		_makeDamageCanReduce = makeDamageCanReduce;
		SetModifiedAndInvalidateInfluencedCache(325, context);
	}

	public SpecialEffectList GetNormalAttackGetTrickCount()
	{
		return _normalAttackGetTrickCount;
	}

	public void SetNormalAttackGetTrickCount(SpecialEffectList normalAttackGetTrickCount, DataContext context)
	{
		_normalAttackGetTrickCount = normalAttackGetTrickCount;
		SetModifiedAndInvalidateInfluencedCache(326, context);
	}

	public SpecialEffectList GetStayEffectCountOnAddPhase()
	{
		return _stayEffectCountOnAddPhase;
	}

	public void SetStayEffectCountOnAddPhase(SpecialEffectList stayEffectCountOnAddPhase, DataContext context)
	{
		_stayEffectCountOnAddPhase = stayEffectCountOnAddPhase;
		SetModifiedAndInvalidateInfluencedCache(327, context);
	}

	public SpecialEffectList GetHealInjuryWithFatalRequireAttainment()
	{
		return _healInjuryWithFatalRequireAttainment;
	}

	public void SetHealInjuryWithFatalRequireAttainment(SpecialEffectList healInjuryWithFatalRequireAttainment, DataContext context)
	{
		_healInjuryWithFatalRequireAttainment = healInjuryWithFatalRequireAttainment;
		SetModifiedAndInvalidateInfluencedCache(328, context);
	}

	public SpecialEffectList GetUseItemCostNoWisdom()
	{
		return _useItemCostNoWisdom;
	}

	public void SetUseItemCostNoWisdom(SpecialEffectList useItemCostNoWisdom, DataContext context)
	{
		_useItemCostNoWisdom = useItemCostNoWisdom;
		SetModifiedAndInvalidateInfluencedCache(329, context);
	}

	public SpecialEffectList GetMindUpheavalTime()
	{
		return _mindUpheavalTime;
	}

	public void SetMindUpheavalTime(SpecialEffectList mindUpheavalTime, DataContext context)
	{
		_mindUpheavalTime = mindUpheavalTime;
		SetModifiedAndInvalidateInfluencedCache(330, context);
	}

	public SpecialEffectList GetMakeHarmfulActionSuccessRate()
	{
		return _makeHarmfulActionSuccessRate;
	}

	public void SetMakeHarmfulActionSuccessRate(SpecialEffectList makeHarmfulActionSuccessRate, DataContext context)
	{
		_makeHarmfulActionSuccessRate = makeHarmfulActionSuccessRate;
		SetModifiedAndInvalidateInfluencedCache(331, context);
	}

	public SpecialEffectList GetAcceptHarmfulActionSuccessRate()
	{
		return _acceptHarmfulActionSuccessRate;
	}

	public void SetAcceptHarmfulActionSuccessRate(SpecialEffectList acceptHarmfulActionSuccessRate, DataContext context)
	{
		_acceptHarmfulActionSuccessRate = acceptHarmfulActionSuccessRate;
		SetModifiedAndInvalidateInfluencedCache(332, context);
	}

	public SpecialEffectList GetMakeFatalDamage()
	{
		return _makeFatalDamage;
	}

	public void SetMakeFatalDamage(SpecialEffectList makeFatalDamage, DataContext context)
	{
		_makeFatalDamage = makeFatalDamage;
		SetModifiedAndInvalidateInfluencedCache(333, context);
	}

	public SpecialEffectList GetAcceptFatalDamage()
	{
		return _acceptFatalDamage;
	}

	public void SetAcceptFatalDamage(SpecialEffectList acceptFatalDamage, DataContext context)
	{
		_acceptFatalDamage = acceptFatalDamage;
		SetModifiedAndInvalidateInfluencedCache(334, context);
	}

	public SpecialEffectList GetCausedInjuryChangeToOldOdds()
	{
		return _causedInjuryChangeToOldOdds;
	}

	public void SetCausedInjuryChangeToOldOdds(SpecialEffectList causedInjuryChangeToOldOdds, DataContext context)
	{
		_causedInjuryChangeToOldOdds = causedInjuryChangeToOldOdds;
		SetModifiedAndInvalidateInfluencedCache(335, context);
	}

	public SpecialEffectList GetCausedMindChangeToInfiniteOdds()
	{
		return _causedMindChangeToInfiniteOdds;
	}

	public void SetCausedMindChangeToInfiniteOdds(SpecialEffectList causedMindChangeToInfiniteOdds, DataContext context)
	{
		_causedMindChangeToInfiniteOdds = causedMindChangeToInfiniteOdds;
		SetModifiedAndInvalidateInfluencedCache(336, context);
	}

	public SpecialEffectList GetHitReduceDurability()
	{
		return _hitReduceDurability;
	}

	public void SetHitReduceDurability(SpecialEffectList hitReduceDurability, DataContext context)
	{
		_hitReduceDurability = hitReduceDurability;
		SetModifiedAndInvalidateInfluencedCache(337, context);
	}

	public SpecialEffectList GetEquipmentMasteryAffectOdds()
	{
		return _equipmentMasteryAffectOdds;
	}

	public void SetEquipmentMasteryAffectOdds(SpecialEffectList equipmentMasteryAffectOdds, DataContext context)
	{
		_equipmentMasteryAffectOdds = equipmentMasteryAffectOdds;
		SetModifiedAndInvalidateInfluencedCache(338, context);
	}

	public SpecialEffectList GetCriticalDamage()
	{
		return _criticalDamage;
	}

	public void SetCriticalDamage(SpecialEffectList criticalDamage, DataContext context)
	{
		_criticalDamage = criticalDamage;
		SetModifiedAndInvalidateInfluencedCache(339, context);
	}

	public SpecialEffectList GetCanFightBackOutOfAttackRange()
	{
		return _canFightBackOutOfAttackRange;
	}

	public void SetCanFightBackOutOfAttackRange(SpecialEffectList canFightBackOutOfAttackRange, DataContext context)
	{
		_canFightBackOutOfAttackRange = canFightBackOutOfAttackRange;
		SetModifiedAndInvalidateInfluencedCache(340, context);
	}

	public SpecialEffectList GetAttackerCriticalOdds()
	{
		return _attackerCriticalOdds;
	}

	public void SetAttackerCriticalOdds(SpecialEffectList attackerCriticalOdds, DataContext context)
	{
		_attackerCriticalOdds = attackerCriticalOdds;
		SetModifiedAndInvalidateInfluencedCache(341, context);
	}

	public SpecialEffectList GetDefenderCriticalOdds()
	{
		return _defenderCriticalOdds;
	}

	public void SetDefenderCriticalOdds(SpecialEffectList defenderCriticalOdds, DataContext context)
	{
		_defenderCriticalOdds = defenderCriticalOdds;
		SetModifiedAndInvalidateInfluencedCache(342, context);
	}

	public SpecialEffectList GetMixPoisonCanAffectCount()
	{
		return _mixPoisonCanAffectCount;
	}

	public void SetMixPoisonCanAffectCount(SpecialEffectList mixPoisonCanAffectCount, DataContext context)
	{
		_mixPoisonCanAffectCount = mixPoisonCanAffectCount;
		SetModifiedAndInvalidateInfluencedCache(343, context);
	}

	public SpecialEffectList GetCastCostNeiliAllocationIsAbsorb()
	{
		return _castCostNeiliAllocationIsAbsorb;
	}

	public void SetCastCostNeiliAllocationIsAbsorb(SpecialEffectList castCostNeiliAllocationIsAbsorb, DataContext context)
	{
		_castCostNeiliAllocationIsAbsorb = castCostNeiliAllocationIsAbsorb;
		SetModifiedAndInvalidateInfluencedCache(344, context);
	}

	public SpecialEffectList GetAcceptInjuryChangeToOldOdds()
	{
		return _acceptInjuryChangeToOldOdds;
	}

	public void SetAcceptInjuryChangeToOldOdds(SpecialEffectList acceptInjuryChangeToOldOdds, DataContext context)
	{
		_acceptInjuryChangeToOldOdds = acceptInjuryChangeToOldOdds;
		SetModifiedAndInvalidateInfluencedCache(345, context);
	}

	public AffectedData()
	{
		_maxStrength = new SpecialEffectList();
		_maxDexterity = new SpecialEffectList();
		_maxConcentration = new SpecialEffectList();
		_maxVitality = new SpecialEffectList();
		_maxEnergy = new SpecialEffectList();
		_maxIntelligence = new SpecialEffectList();
		_recoveryOfStance = new SpecialEffectList();
		_recoveryOfBreath = new SpecialEffectList();
		_moveSpeed = new SpecialEffectList();
		_recoveryOfFlaw = new SpecialEffectList();
		_castSpeed = new SpecialEffectList();
		_recoveryOfBlockedAcupoint = new SpecialEffectList();
		_weaponSwitchSpeed = new SpecialEffectList();
		_attackSpeed = new SpecialEffectList();
		_innerRatio = new SpecialEffectList();
		_recoveryOfQiDisorder = new SpecialEffectList();
		_minorAttributeFixMaxValue = new SpecialEffectList();
		_minorAttributeFixMinValue = new SpecialEffectList();
		_resistOfHotPoison = new SpecialEffectList();
		_resistOfGloomyPoison = new SpecialEffectList();
		_resistOfColdPoison = new SpecialEffectList();
		_resistOfRedPoison = new SpecialEffectList();
		_resistOfRottenPoison = new SpecialEffectList();
		_resistOfIllusoryPoison = new SpecialEffectList();
		_displayAge = new SpecialEffectList();
		_neiliProportionOfFiveElements = new SpecialEffectList();
		_weaponMaxPower = new SpecialEffectList();
		_weaponUseRequirement = new SpecialEffectList();
		_weaponAttackRange = new SpecialEffectList();
		_armorMaxPower = new SpecialEffectList();
		_armorUseRequirement = new SpecialEffectList();
		_hitStrength = new SpecialEffectList();
		_hitTechnique = new SpecialEffectList();
		_hitSpeed = new SpecialEffectList();
		_hitMind = new SpecialEffectList();
		_hitCanChange = new SpecialEffectList();
		_hitChangeEffectPercent = new SpecialEffectList();
		_avoidStrength = new SpecialEffectList();
		_avoidTechnique = new SpecialEffectList();
		_avoidSpeed = new SpecialEffectList();
		_avoidMind = new SpecialEffectList();
		_avoidCanChange = new SpecialEffectList();
		_avoidChangeEffectPercent = new SpecialEffectList();
		_penetrateOuter = new SpecialEffectList();
		_penetrateInner = new SpecialEffectList();
		_penetrateResistOuter = new SpecialEffectList();
		_penetrateResistInner = new SpecialEffectList();
		_neiliAllocationAttack = new SpecialEffectList();
		_neiliAllocationAgile = new SpecialEffectList();
		_neiliAllocationDefense = new SpecialEffectList();
		_neiliAllocationAssist = new SpecialEffectList();
		_happiness = new SpecialEffectList();
		_maxHealth = new SpecialEffectList();
		_healthCost = new SpecialEffectList();
		_moveSpeedCanChange = new SpecialEffectList();
		_attackerHitStrength = new SpecialEffectList();
		_attackerHitTechnique = new SpecialEffectList();
		_attackerHitSpeed = new SpecialEffectList();
		_attackerHitMind = new SpecialEffectList();
		_attackerAvoidStrength = new SpecialEffectList();
		_attackerAvoidTechnique = new SpecialEffectList();
		_attackerAvoidSpeed = new SpecialEffectList();
		_attackerAvoidMind = new SpecialEffectList();
		_attackerPenetrateOuter = new SpecialEffectList();
		_attackerPenetrateInner = new SpecialEffectList();
		_attackerPenetrateResistOuter = new SpecialEffectList();
		_attackerPenetrateResistInner = new SpecialEffectList();
		_attackHitType = new SpecialEffectList();
		_makeDirectDamage = new SpecialEffectList();
		_makeBounceDamage = new SpecialEffectList();
		_makeFightBackDamage = new SpecialEffectList();
		_makePoisonLevel = new SpecialEffectList();
		_makePoisonValue = new SpecialEffectList();
		_attackerHitOdds = new SpecialEffectList();
		_attackerFightBackHitOdds = new SpecialEffectList();
		_attackerPursueOdds = new SpecialEffectList();
		_causedInjuryChangeToOld = new SpecialEffectList();
		_causedPoisonChangeToOld = new SpecialEffectList();
		_makeDamageType = new SpecialEffectList();
		_canMakeInjuryToNoInjuryPart = new SpecialEffectList();
		_makePoisonType = new SpecialEffectList();
		_normalAttackWeapon = new SpecialEffectList();
		_normalAttackTrick = new SpecialEffectList();
		_extraFlawCount = new SpecialEffectList();
		_attackCanBounce = new SpecialEffectList();
		_attackCanFightBack = new SpecialEffectList();
		_makeFightBackInjuryMark = new SpecialEffectList();
		_legSkillUseShoes = new SpecialEffectList();
		_attackerFinalDamageValue = new SpecialEffectList();
		_defenderHitStrength = new SpecialEffectList();
		_defenderHitTechnique = new SpecialEffectList();
		_defenderHitSpeed = new SpecialEffectList();
		_defenderHitMind = new SpecialEffectList();
		_defenderAvoidStrength = new SpecialEffectList();
		_defenderAvoidTechnique = new SpecialEffectList();
		_defenderAvoidSpeed = new SpecialEffectList();
		_defenderAvoidMind = new SpecialEffectList();
		_defenderPenetrateOuter = new SpecialEffectList();
		_defenderPenetrateInner = new SpecialEffectList();
		_defenderPenetrateResistOuter = new SpecialEffectList();
		_defenderPenetrateResistInner = new SpecialEffectList();
		_acceptDirectDamage = new SpecialEffectList();
		_acceptBounceDamage = new SpecialEffectList();
		_acceptFightBackDamage = new SpecialEffectList();
		_acceptPoisonLevel = new SpecialEffectList();
		_acceptPoisonValue = new SpecialEffectList();
		_defenderHitOdds = new SpecialEffectList();
		_defenderFightBackHitOdds = new SpecialEffectList();
		_defenderPursueOdds = new SpecialEffectList();
		_acceptMaxInjuryCount = new SpecialEffectList();
		_bouncePower = new SpecialEffectList();
		_fightBackPower = new SpecialEffectList();
		_directDamageInnerRatio = new SpecialEffectList();
		_defenderFinalDamageValue = new SpecialEffectList();
		_directDamageValue = new SpecialEffectList();
		_directInjuryMark = new SpecialEffectList();
		_goneMadInjury = new SpecialEffectList();
		_healInjurySpeed = new SpecialEffectList();
		_healInjuryBuff = new SpecialEffectList();
		_healInjuryDebuff = new SpecialEffectList();
		_healPoisonSpeed = new SpecialEffectList();
		_healPoisonBuff = new SpecialEffectList();
		_healPoisonDebuff = new SpecialEffectList();
		_fleeSpeed = new SpecialEffectList();
		_maxFlawCount = new SpecialEffectList();
		_canAddFlaw = new SpecialEffectList();
		_flawLevel = new SpecialEffectList();
		_flawLevelCanReduce = new SpecialEffectList();
		_flawCount = new SpecialEffectList();
		_maxAcupointCount = new SpecialEffectList();
		_canAddAcupoint = new SpecialEffectList();
		_acupointLevel = new SpecialEffectList();
		_acupointLevelCanReduce = new SpecialEffectList();
		_acupointCount = new SpecialEffectList();
		_addNeiliAllocation = new SpecialEffectList();
		_costNeiliAllocation = new SpecialEffectList();
		_canChangeNeiliAllocation = new SpecialEffectList();
		_canGetTrick = new SpecialEffectList();
		_getTrickType = new SpecialEffectList();
		_attackBodyPart = new SpecialEffectList();
		_weaponEquipAttack = new SpecialEffectList();
		_weaponEquipDefense = new SpecialEffectList();
		_armorEquipAttack = new SpecialEffectList();
		_armorEquipDefense = new SpecialEffectList();
		_attackRangeForward = new SpecialEffectList();
		_attackRangeBackward = new SpecialEffectList();
		_moveCanBeStopped = new SpecialEffectList();
		_canForcedMove = new SpecialEffectList();
		_mobilityCanBeRemoved = new SpecialEffectList();
		_mobilityCostByEffect = new SpecialEffectList();
		_moveDistance = new SpecialEffectList();
		_jumpPrepareFrame = new SpecialEffectList();
		_bounceInjuryMark = new SpecialEffectList();
		_skillHasCost = new SpecialEffectList();
		_combatStateEffect = new SpecialEffectList();
		_changeNeedUseSkill = new SpecialEffectList();
		_changeDistanceIsMove = new SpecialEffectList();
		_replaceCharHit = new SpecialEffectList();
		_canAddPoison = new SpecialEffectList();
		_canReducePoison = new SpecialEffectList();
		_reducePoisonValue = new SpecialEffectList();
		_poisonCanAffect = new SpecialEffectList();
		_poisonAffectCount = new SpecialEffectList();
		_costTricks = new SpecialEffectList();
		_jumpMoveDistance = new SpecialEffectList();
		_combatStateToAdd = new SpecialEffectList();
		_combatStatePower = new SpecialEffectList();
		_breakBodyPartInjuryCount = new SpecialEffectList();
		_bodyPartIsBroken = new SpecialEffectList();
		_maxTrickCount = new SpecialEffectList();
		_maxBreathPercent = new SpecialEffectList();
		_maxStancePercent = new SpecialEffectList();
		_extraBreathPercent = new SpecialEffectList();
		_extraStancePercent = new SpecialEffectList();
		_moveCostMobility = new SpecialEffectList();
		_defendSkillKeepTime = new SpecialEffectList();
		_bounceRange = new SpecialEffectList();
		_mindMarkKeepTime = new SpecialEffectList();
		_skillMobilityCostPerFrame = new SpecialEffectList();
		_canAddWug = new SpecialEffectList();
		_hasGodWeaponBuff = new SpecialEffectList();
		_hasGodArmorBuff = new SpecialEffectList();
		_teammateCmdRequireGenerateValue = new SpecialEffectList();
		_teammateCmdEffect = new SpecialEffectList();
		_flawRecoverSpeed = new SpecialEffectList();
		_acupointRecoverSpeed = new SpecialEffectList();
		_mindMarkRecoverSpeed = new SpecialEffectList();
		_injuryAutoHealSpeed = new SpecialEffectList();
		_canRecoverBreath = new SpecialEffectList();
		_canRecoverStance = new SpecialEffectList();
		_fatalDamageValue = new SpecialEffectList();
		_fatalDamageMarkCount = new SpecialEffectList();
		_canFightBackDuringPrepareSkill = new SpecialEffectList();
		_skillPrepareSpeed = new SpecialEffectList();
		_breathRecoverSpeed = new SpecialEffectList();
		_stanceRecoverSpeed = new SpecialEffectList();
		_mobilityRecoverSpeed = new SpecialEffectList();
		_changeTrickProgressAddValue = new SpecialEffectList();
		_power = new SpecialEffectList();
		_maxPower = new SpecialEffectList();
		_powerCanReduce = new SpecialEffectList();
		_useRequirement = new SpecialEffectList();
		_currInnerRatio = new SpecialEffectList();
		_costBreathAndStance = new SpecialEffectList();
		_costBreath = new SpecialEffectList();
		_costStance = new SpecialEffectList();
		_costMobility = new SpecialEffectList();
		_skillCostTricks = new SpecialEffectList();
		_effectDirection = new SpecialEffectList();
		_effectDirectionCanChange = new SpecialEffectList();
		_gridCost = new SpecialEffectList();
		_prepareTotalProgress = new SpecialEffectList();
		_specificGridCount = new SpecialEffectList();
		_genericGridCount = new SpecialEffectList();
		_canInterrupt = new SpecialEffectList();
		_interruptOdds = new SpecialEffectList();
		_canSilence = new SpecialEffectList();
		_silenceOdds = new SpecialEffectList();
		_canCastWithBrokenBodyPart = new SpecialEffectList();
		_addPowerCanBeRemoved = new SpecialEffectList();
		_skillType = new SpecialEffectList();
		_effectCountCanChange = new SpecialEffectList();
		_canCastInDefend = new SpecialEffectList();
		_hitDistribution = new SpecialEffectList();
		_canCastOnLackBreath = new SpecialEffectList();
		_canCastOnLackStance = new SpecialEffectList();
		_costBreathOnCast = new SpecialEffectList();
		_costStanceOnCast = new SpecialEffectList();
		_canUseMobilityAsBreath = new SpecialEffectList();
		_canUseMobilityAsStance = new SpecialEffectList();
		_castCostNeiliAllocation = new SpecialEffectList();
		_acceptPoisonResist = new SpecialEffectList();
		_makePoisonResist = new SpecialEffectList();
		_canCriticalHit = new SpecialEffectList();
		_canCostNeiliAllocationEffect = new SpecialEffectList();
		_consummateLevelRelatedMainAttributesHitValues = new SpecialEffectList();
		_consummateLevelRelatedMainAttributesAvoidValues = new SpecialEffectList();
		_consummateLevelRelatedMainAttributesPenetrations = new SpecialEffectList();
		_consummateLevelRelatedMainAttributesPenetrationResists = new SpecialEffectList();
		_skillAlsoAsFiveElements = new SpecialEffectList();
		_innerInjuryImmunity = new SpecialEffectList();
		_outerInjuryImmunity = new SpecialEffectList();
		_poisonAffectThreshold = new SpecialEffectList();
		_lockDistance = new SpecialEffectList();
		_resistOfAllPoison = new SpecialEffectList();
		_makePoisonTarget = new SpecialEffectList();
		_acceptPoisonTarget = new SpecialEffectList();
		_certainCriticalHit = new SpecialEffectList();
		_mindMarkCount = new SpecialEffectList();
		_canFightBackWithHit = new SpecialEffectList();
		_inevitableHit = new SpecialEffectList();
		_attackCanPursue = new SpecialEffectList();
		_combatSkillDataEffectList = new SpecialEffectList();
		_stanceCostByEffect = new SpecialEffectList();
		_breathCostByEffect = new SpecialEffectList();
		_powerAddRatio = new SpecialEffectList();
		_powerReduceRatio = new SpecialEffectList();
		_poisonAffectProduceValue = new SpecialEffectList();
		_canReadingOnMonthChange = new SpecialEffectList();
		_medicineEffect = new SpecialEffectList();
		_xiangshuInfectionDelta = new SpecialEffectList();
		_healthDelta = new SpecialEffectList();
		_weaponSilenceFrame = new SpecialEffectList();
		_silenceFrame = new SpecialEffectList();
		_currAgeDelta = new SpecialEffectList();
		_goneMadInAllBreak = new SpecialEffectList();
		_makeLoveRateOnMonthChange = new SpecialEffectList();
		_canAutoHealOnMonthChange = new SpecialEffectList();
		_happinessDelta = new SpecialEffectList();
		_teammateCmdCanUse = new SpecialEffectList();
		_mixPoisonInfinityAffect = new SpecialEffectList();
		_attackRangeMaxAcupoint = new SpecialEffectList();
		_maxMobilityPercent = new SpecialEffectList();
		_makeMindDamage = new SpecialEffectList();
		_acceptMindDamage = new SpecialEffectList();
		_hitAddByTempValue = new SpecialEffectList();
		_avoidAddByTempValue = new SpecialEffectList();
		_ignoreEquipmentOverload = new SpecialEffectList();
		_canCostEnemyUsableTricks = new SpecialEffectList();
		_ignoreArmor = new SpecialEffectList();
		_unyieldingFallen = new SpecialEffectList();
		_normalAttackPrepareFrame = new SpecialEffectList();
		_canCostUselessTricks = new SpecialEffectList();
		_defendSkillCanAffect = new SpecialEffectList();
		_assistSkillCanAffect = new SpecialEffectList();
		_agileSkillCanAffect = new SpecialEffectList();
		_allMarkChangeToMind = new SpecialEffectList();
		_mindMarkChangeToFatal = new SpecialEffectList();
		_canCast = new SpecialEffectList();
		_inevitableAvoid = new SpecialEffectList();
		_powerEffectReverse = new SpecialEffectList();
		_featureBonusReverse = new SpecialEffectList();
		_wugFatalDamageValue = new SpecialEffectList();
		_canRecoverHealthOnMonthChange = new SpecialEffectList();
		_takeRevengeRateOnMonthChange = new SpecialEffectList();
		_consummateLevelBonus = new SpecialEffectList();
		_neiliDelta = new SpecialEffectList();
		_canMakeLoveSpecialOnMonthChange = new SpecialEffectList();
		_healAcupointSpeed = new SpecialEffectList();
		_maxChangeTrickCount = new SpecialEffectList();
		_convertCostBreathAndStance = new SpecialEffectList();
		_personalitiesAll = new SpecialEffectList();
		_finalFatalDamageMarkCount = new SpecialEffectList();
		_combatSkillAiScorePower = new SpecialEffectList();
		_normalAttackChangeToUnlockAttack = new SpecialEffectList();
		_attackBodyPartOdds = new SpecialEffectList();
		_changeDurability = new SpecialEffectList();
		_equipmentBonus = new SpecialEffectList();
		_equipmentWeight = new SpecialEffectList();
		_rawCreateEffectList = new SpecialEffectList();
		_jiTrickAsWeaponTrickCount = new SpecialEffectList();
		_uselessTrickAsJiTrickCount = new SpecialEffectList();
		_equipmentPower = new SpecialEffectList();
		_healFlawSpeed = new SpecialEffectList();
		_unlockSpeed = new SpecialEffectList();
		_flawBonusFactor = new SpecialEffectList();
		_canCostShaTricks = new SpecialEffectList();
		_defenderDirectFinalDamageValue = new SpecialEffectList();
		_normalAttackRecoveryFrame = new SpecialEffectList();
		_finalGoneMadInjury = new SpecialEffectList();
		_attackerDirectFinalDamageValue = new SpecialEffectList();
		_canCostTrickDuringPreparingSkill = new SpecialEffectList();
		_validItemList = new SpecialEffectList();
		_acceptDamageCanAdd = new SpecialEffectList();
		_makeDamageCanReduce = new SpecialEffectList();
		_normalAttackGetTrickCount = new SpecialEffectList();
		_stayEffectCountOnAddPhase = new SpecialEffectList();
		_healInjuryWithFatalRequireAttainment = new SpecialEffectList();
		_useItemCostNoWisdom = new SpecialEffectList();
		_mindUpheavalTime = new SpecialEffectList();
		_makeHarmfulActionSuccessRate = new SpecialEffectList();
		_acceptHarmfulActionSuccessRate = new SpecialEffectList();
		_makeFatalDamage = new SpecialEffectList();
		_acceptFatalDamage = new SpecialEffectList();
		_causedInjuryChangeToOldOdds = new SpecialEffectList();
		_causedMindChangeToInfiniteOdds = new SpecialEffectList();
		_hitReduceDurability = new SpecialEffectList();
		_equipmentMasteryAffectOdds = new SpecialEffectList();
		_criticalDamage = new SpecialEffectList();
		_canFightBackOutOfAttackRange = new SpecialEffectList();
		_attackerCriticalOdds = new SpecialEffectList();
		_defenderCriticalOdds = new SpecialEffectList();
		_mixPoisonCanAffectCount = new SpecialEffectList();
		_castCostNeiliAllocationIsAbsorb = new SpecialEffectList();
		_acceptInjuryChangeToOldOdds = new SpecialEffectList();
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
		int totalSize = 1384;
		int dataSize = _maxStrength.GetSerializedSize();
		totalSize += dataSize;
		int dataSize2 = _maxDexterity.GetSerializedSize();
		totalSize += dataSize2;
		int dataSize3 = _maxConcentration.GetSerializedSize();
		totalSize += dataSize3;
		int dataSize4 = _maxVitality.GetSerializedSize();
		totalSize += dataSize4;
		int dataSize5 = _maxEnergy.GetSerializedSize();
		totalSize += dataSize5;
		int dataSize6 = _maxIntelligence.GetSerializedSize();
		totalSize += dataSize6;
		int dataSize7 = _recoveryOfStance.GetSerializedSize();
		totalSize += dataSize7;
		int dataSize8 = _recoveryOfBreath.GetSerializedSize();
		totalSize += dataSize8;
		int dataSize9 = _moveSpeed.GetSerializedSize();
		totalSize += dataSize9;
		int dataSize10 = _recoveryOfFlaw.GetSerializedSize();
		totalSize += dataSize10;
		int dataSize11 = _castSpeed.GetSerializedSize();
		totalSize += dataSize11;
		int dataSize12 = _recoveryOfBlockedAcupoint.GetSerializedSize();
		totalSize += dataSize12;
		int dataSize13 = _weaponSwitchSpeed.GetSerializedSize();
		totalSize += dataSize13;
		int dataSize14 = _attackSpeed.GetSerializedSize();
		totalSize += dataSize14;
		int dataSize15 = _innerRatio.GetSerializedSize();
		totalSize += dataSize15;
		int dataSize16 = _recoveryOfQiDisorder.GetSerializedSize();
		totalSize += dataSize16;
		int dataSize17 = _minorAttributeFixMaxValue.GetSerializedSize();
		totalSize += dataSize17;
		int dataSize18 = _minorAttributeFixMinValue.GetSerializedSize();
		totalSize += dataSize18;
		int dataSize19 = _resistOfHotPoison.GetSerializedSize();
		totalSize += dataSize19;
		int dataSize20 = _resistOfGloomyPoison.GetSerializedSize();
		totalSize += dataSize20;
		int dataSize21 = _resistOfColdPoison.GetSerializedSize();
		totalSize += dataSize21;
		int dataSize22 = _resistOfRedPoison.GetSerializedSize();
		totalSize += dataSize22;
		int dataSize23 = _resistOfRottenPoison.GetSerializedSize();
		totalSize += dataSize23;
		int dataSize24 = _resistOfIllusoryPoison.GetSerializedSize();
		totalSize += dataSize24;
		int dataSize25 = _displayAge.GetSerializedSize();
		totalSize += dataSize25;
		int dataSize26 = _neiliProportionOfFiveElements.GetSerializedSize();
		totalSize += dataSize26;
		int dataSize27 = _weaponMaxPower.GetSerializedSize();
		totalSize += dataSize27;
		int dataSize28 = _weaponUseRequirement.GetSerializedSize();
		totalSize += dataSize28;
		int dataSize29 = _weaponAttackRange.GetSerializedSize();
		totalSize += dataSize29;
		int dataSize30 = _armorMaxPower.GetSerializedSize();
		totalSize += dataSize30;
		int dataSize31 = _armorUseRequirement.GetSerializedSize();
		totalSize += dataSize31;
		int dataSize32 = _hitStrength.GetSerializedSize();
		totalSize += dataSize32;
		int dataSize33 = _hitTechnique.GetSerializedSize();
		totalSize += dataSize33;
		int dataSize34 = _hitSpeed.GetSerializedSize();
		totalSize += dataSize34;
		int dataSize35 = _hitMind.GetSerializedSize();
		totalSize += dataSize35;
		int dataSize36 = _hitCanChange.GetSerializedSize();
		totalSize += dataSize36;
		int dataSize37 = _hitChangeEffectPercent.GetSerializedSize();
		totalSize += dataSize37;
		int dataSize38 = _avoidStrength.GetSerializedSize();
		totalSize += dataSize38;
		int dataSize39 = _avoidTechnique.GetSerializedSize();
		totalSize += dataSize39;
		int dataSize40 = _avoidSpeed.GetSerializedSize();
		totalSize += dataSize40;
		int dataSize41 = _avoidMind.GetSerializedSize();
		totalSize += dataSize41;
		int dataSize42 = _avoidCanChange.GetSerializedSize();
		totalSize += dataSize42;
		int dataSize43 = _avoidChangeEffectPercent.GetSerializedSize();
		totalSize += dataSize43;
		int dataSize44 = _penetrateOuter.GetSerializedSize();
		totalSize += dataSize44;
		int dataSize45 = _penetrateInner.GetSerializedSize();
		totalSize += dataSize45;
		int dataSize46 = _penetrateResistOuter.GetSerializedSize();
		totalSize += dataSize46;
		int dataSize47 = _penetrateResistInner.GetSerializedSize();
		totalSize += dataSize47;
		int dataSize48 = _neiliAllocationAttack.GetSerializedSize();
		totalSize += dataSize48;
		int dataSize49 = _neiliAllocationAgile.GetSerializedSize();
		totalSize += dataSize49;
		int dataSize50 = _neiliAllocationDefense.GetSerializedSize();
		totalSize += dataSize50;
		int dataSize51 = _neiliAllocationAssist.GetSerializedSize();
		totalSize += dataSize51;
		int dataSize52 = _happiness.GetSerializedSize();
		totalSize += dataSize52;
		int dataSize53 = _maxHealth.GetSerializedSize();
		totalSize += dataSize53;
		int dataSize54 = _healthCost.GetSerializedSize();
		totalSize += dataSize54;
		int dataSize55 = _moveSpeedCanChange.GetSerializedSize();
		totalSize += dataSize55;
		int dataSize56 = _attackerHitStrength.GetSerializedSize();
		totalSize += dataSize56;
		int dataSize57 = _attackerHitTechnique.GetSerializedSize();
		totalSize += dataSize57;
		int dataSize58 = _attackerHitSpeed.GetSerializedSize();
		totalSize += dataSize58;
		int dataSize59 = _attackerHitMind.GetSerializedSize();
		totalSize += dataSize59;
		int dataSize60 = _attackerAvoidStrength.GetSerializedSize();
		totalSize += dataSize60;
		int dataSize61 = _attackerAvoidTechnique.GetSerializedSize();
		totalSize += dataSize61;
		int dataSize62 = _attackerAvoidSpeed.GetSerializedSize();
		totalSize += dataSize62;
		int dataSize63 = _attackerAvoidMind.GetSerializedSize();
		totalSize += dataSize63;
		int dataSize64 = _attackerPenetrateOuter.GetSerializedSize();
		totalSize += dataSize64;
		int dataSize65 = _attackerPenetrateInner.GetSerializedSize();
		totalSize += dataSize65;
		int dataSize66 = _attackerPenetrateResistOuter.GetSerializedSize();
		totalSize += dataSize66;
		int dataSize67 = _attackerPenetrateResistInner.GetSerializedSize();
		totalSize += dataSize67;
		int dataSize68 = _attackHitType.GetSerializedSize();
		totalSize += dataSize68;
		int dataSize69 = _makeDirectDamage.GetSerializedSize();
		totalSize += dataSize69;
		int dataSize70 = _makeBounceDamage.GetSerializedSize();
		totalSize += dataSize70;
		int dataSize71 = _makeFightBackDamage.GetSerializedSize();
		totalSize += dataSize71;
		int dataSize72 = _makePoisonLevel.GetSerializedSize();
		totalSize += dataSize72;
		int dataSize73 = _makePoisonValue.GetSerializedSize();
		totalSize += dataSize73;
		int dataSize74 = _attackerHitOdds.GetSerializedSize();
		totalSize += dataSize74;
		int dataSize75 = _attackerFightBackHitOdds.GetSerializedSize();
		totalSize += dataSize75;
		int dataSize76 = _attackerPursueOdds.GetSerializedSize();
		totalSize += dataSize76;
		int dataSize77 = _causedInjuryChangeToOld.GetSerializedSize();
		totalSize += dataSize77;
		int dataSize78 = _causedPoisonChangeToOld.GetSerializedSize();
		totalSize += dataSize78;
		int dataSize79 = _makeDamageType.GetSerializedSize();
		totalSize += dataSize79;
		int dataSize80 = _canMakeInjuryToNoInjuryPart.GetSerializedSize();
		totalSize += dataSize80;
		int dataSize81 = _makePoisonType.GetSerializedSize();
		totalSize += dataSize81;
		int dataSize82 = _normalAttackWeapon.GetSerializedSize();
		totalSize += dataSize82;
		int dataSize83 = _normalAttackTrick.GetSerializedSize();
		totalSize += dataSize83;
		int dataSize84 = _extraFlawCount.GetSerializedSize();
		totalSize += dataSize84;
		int dataSize85 = _attackCanBounce.GetSerializedSize();
		totalSize += dataSize85;
		int dataSize86 = _attackCanFightBack.GetSerializedSize();
		totalSize += dataSize86;
		int dataSize87 = _makeFightBackInjuryMark.GetSerializedSize();
		totalSize += dataSize87;
		int dataSize88 = _legSkillUseShoes.GetSerializedSize();
		totalSize += dataSize88;
		int dataSize89 = _attackerFinalDamageValue.GetSerializedSize();
		totalSize += dataSize89;
		int dataSize90 = _defenderHitStrength.GetSerializedSize();
		totalSize += dataSize90;
		int dataSize91 = _defenderHitTechnique.GetSerializedSize();
		totalSize += dataSize91;
		int dataSize92 = _defenderHitSpeed.GetSerializedSize();
		totalSize += dataSize92;
		int dataSize93 = _defenderHitMind.GetSerializedSize();
		totalSize += dataSize93;
		int dataSize94 = _defenderAvoidStrength.GetSerializedSize();
		totalSize += dataSize94;
		int dataSize95 = _defenderAvoidTechnique.GetSerializedSize();
		totalSize += dataSize95;
		int dataSize96 = _defenderAvoidSpeed.GetSerializedSize();
		totalSize += dataSize96;
		int dataSize97 = _defenderAvoidMind.GetSerializedSize();
		totalSize += dataSize97;
		int dataSize98 = _defenderPenetrateOuter.GetSerializedSize();
		totalSize += dataSize98;
		int dataSize99 = _defenderPenetrateInner.GetSerializedSize();
		totalSize += dataSize99;
		int dataSize100 = _defenderPenetrateResistOuter.GetSerializedSize();
		totalSize += dataSize100;
		int dataSize101 = _defenderPenetrateResistInner.GetSerializedSize();
		totalSize += dataSize101;
		int dataSize102 = _acceptDirectDamage.GetSerializedSize();
		totalSize += dataSize102;
		int dataSize103 = _acceptBounceDamage.GetSerializedSize();
		totalSize += dataSize103;
		int dataSize104 = _acceptFightBackDamage.GetSerializedSize();
		totalSize += dataSize104;
		int dataSize105 = _acceptPoisonLevel.GetSerializedSize();
		totalSize += dataSize105;
		int dataSize106 = _acceptPoisonValue.GetSerializedSize();
		totalSize += dataSize106;
		int dataSize107 = _defenderHitOdds.GetSerializedSize();
		totalSize += dataSize107;
		int dataSize108 = _defenderFightBackHitOdds.GetSerializedSize();
		totalSize += dataSize108;
		int dataSize109 = _defenderPursueOdds.GetSerializedSize();
		totalSize += dataSize109;
		int dataSize110 = _acceptMaxInjuryCount.GetSerializedSize();
		totalSize += dataSize110;
		int dataSize111 = _bouncePower.GetSerializedSize();
		totalSize += dataSize111;
		int dataSize112 = _fightBackPower.GetSerializedSize();
		totalSize += dataSize112;
		int dataSize113 = _directDamageInnerRatio.GetSerializedSize();
		totalSize += dataSize113;
		int dataSize114 = _defenderFinalDamageValue.GetSerializedSize();
		totalSize += dataSize114;
		int dataSize115 = _directDamageValue.GetSerializedSize();
		totalSize += dataSize115;
		int dataSize116 = _directInjuryMark.GetSerializedSize();
		totalSize += dataSize116;
		int dataSize117 = _goneMadInjury.GetSerializedSize();
		totalSize += dataSize117;
		int dataSize118 = _healInjurySpeed.GetSerializedSize();
		totalSize += dataSize118;
		int dataSize119 = _healInjuryBuff.GetSerializedSize();
		totalSize += dataSize119;
		int dataSize120 = _healInjuryDebuff.GetSerializedSize();
		totalSize += dataSize120;
		int dataSize121 = _healPoisonSpeed.GetSerializedSize();
		totalSize += dataSize121;
		int dataSize122 = _healPoisonBuff.GetSerializedSize();
		totalSize += dataSize122;
		int dataSize123 = _healPoisonDebuff.GetSerializedSize();
		totalSize += dataSize123;
		int dataSize124 = _fleeSpeed.GetSerializedSize();
		totalSize += dataSize124;
		int dataSize125 = _maxFlawCount.GetSerializedSize();
		totalSize += dataSize125;
		int dataSize126 = _canAddFlaw.GetSerializedSize();
		totalSize += dataSize126;
		int dataSize127 = _flawLevel.GetSerializedSize();
		totalSize += dataSize127;
		int dataSize128 = _flawLevelCanReduce.GetSerializedSize();
		totalSize += dataSize128;
		int dataSize129 = _flawCount.GetSerializedSize();
		totalSize += dataSize129;
		int dataSize130 = _maxAcupointCount.GetSerializedSize();
		totalSize += dataSize130;
		int dataSize131 = _canAddAcupoint.GetSerializedSize();
		totalSize += dataSize131;
		int dataSize132 = _acupointLevel.GetSerializedSize();
		totalSize += dataSize132;
		int dataSize133 = _acupointLevelCanReduce.GetSerializedSize();
		totalSize += dataSize133;
		int dataSize134 = _acupointCount.GetSerializedSize();
		totalSize += dataSize134;
		int dataSize135 = _addNeiliAllocation.GetSerializedSize();
		totalSize += dataSize135;
		int dataSize136 = _costNeiliAllocation.GetSerializedSize();
		totalSize += dataSize136;
		int dataSize137 = _canChangeNeiliAllocation.GetSerializedSize();
		totalSize += dataSize137;
		int dataSize138 = _canGetTrick.GetSerializedSize();
		totalSize += dataSize138;
		int dataSize139 = _getTrickType.GetSerializedSize();
		totalSize += dataSize139;
		int dataSize140 = _attackBodyPart.GetSerializedSize();
		totalSize += dataSize140;
		int dataSize141 = _weaponEquipAttack.GetSerializedSize();
		totalSize += dataSize141;
		int dataSize142 = _weaponEquipDefense.GetSerializedSize();
		totalSize += dataSize142;
		int dataSize143 = _armorEquipAttack.GetSerializedSize();
		totalSize += dataSize143;
		int dataSize144 = _armorEquipDefense.GetSerializedSize();
		totalSize += dataSize144;
		int dataSize145 = _attackRangeForward.GetSerializedSize();
		totalSize += dataSize145;
		int dataSize146 = _attackRangeBackward.GetSerializedSize();
		totalSize += dataSize146;
		int dataSize147 = _moveCanBeStopped.GetSerializedSize();
		totalSize += dataSize147;
		int dataSize148 = _canForcedMove.GetSerializedSize();
		totalSize += dataSize148;
		int dataSize149 = _mobilityCanBeRemoved.GetSerializedSize();
		totalSize += dataSize149;
		int dataSize150 = _mobilityCostByEffect.GetSerializedSize();
		totalSize += dataSize150;
		int dataSize151 = _moveDistance.GetSerializedSize();
		totalSize += dataSize151;
		int dataSize152 = _jumpPrepareFrame.GetSerializedSize();
		totalSize += dataSize152;
		int dataSize153 = _bounceInjuryMark.GetSerializedSize();
		totalSize += dataSize153;
		int dataSize154 = _skillHasCost.GetSerializedSize();
		totalSize += dataSize154;
		int dataSize155 = _combatStateEffect.GetSerializedSize();
		totalSize += dataSize155;
		int dataSize156 = _changeNeedUseSkill.GetSerializedSize();
		totalSize += dataSize156;
		int dataSize157 = _changeDistanceIsMove.GetSerializedSize();
		totalSize += dataSize157;
		int dataSize158 = _replaceCharHit.GetSerializedSize();
		totalSize += dataSize158;
		int dataSize159 = _canAddPoison.GetSerializedSize();
		totalSize += dataSize159;
		int dataSize160 = _canReducePoison.GetSerializedSize();
		totalSize += dataSize160;
		int dataSize161 = _reducePoisonValue.GetSerializedSize();
		totalSize += dataSize161;
		int dataSize162 = _poisonCanAffect.GetSerializedSize();
		totalSize += dataSize162;
		int dataSize163 = _poisonAffectCount.GetSerializedSize();
		totalSize += dataSize163;
		int dataSize164 = _costTricks.GetSerializedSize();
		totalSize += dataSize164;
		int dataSize165 = _jumpMoveDistance.GetSerializedSize();
		totalSize += dataSize165;
		int dataSize166 = _combatStateToAdd.GetSerializedSize();
		totalSize += dataSize166;
		int dataSize167 = _combatStatePower.GetSerializedSize();
		totalSize += dataSize167;
		int dataSize168 = _breakBodyPartInjuryCount.GetSerializedSize();
		totalSize += dataSize168;
		int dataSize169 = _bodyPartIsBroken.GetSerializedSize();
		totalSize += dataSize169;
		int dataSize170 = _maxTrickCount.GetSerializedSize();
		totalSize += dataSize170;
		int dataSize171 = _maxBreathPercent.GetSerializedSize();
		totalSize += dataSize171;
		int dataSize172 = _maxStancePercent.GetSerializedSize();
		totalSize += dataSize172;
		int dataSize173 = _extraBreathPercent.GetSerializedSize();
		totalSize += dataSize173;
		int dataSize174 = _extraStancePercent.GetSerializedSize();
		totalSize += dataSize174;
		int dataSize175 = _moveCostMobility.GetSerializedSize();
		totalSize += dataSize175;
		int dataSize176 = _defendSkillKeepTime.GetSerializedSize();
		totalSize += dataSize176;
		int dataSize177 = _bounceRange.GetSerializedSize();
		totalSize += dataSize177;
		int dataSize178 = _mindMarkKeepTime.GetSerializedSize();
		totalSize += dataSize178;
		int dataSize179 = _skillMobilityCostPerFrame.GetSerializedSize();
		totalSize += dataSize179;
		int dataSize180 = _canAddWug.GetSerializedSize();
		totalSize += dataSize180;
		int dataSize181 = _hasGodWeaponBuff.GetSerializedSize();
		totalSize += dataSize181;
		int dataSize182 = _hasGodArmorBuff.GetSerializedSize();
		totalSize += dataSize182;
		int dataSize183 = _teammateCmdRequireGenerateValue.GetSerializedSize();
		totalSize += dataSize183;
		int dataSize184 = _teammateCmdEffect.GetSerializedSize();
		totalSize += dataSize184;
		int dataSize185 = _flawRecoverSpeed.GetSerializedSize();
		totalSize += dataSize185;
		int dataSize186 = _acupointRecoverSpeed.GetSerializedSize();
		totalSize += dataSize186;
		int dataSize187 = _mindMarkRecoverSpeed.GetSerializedSize();
		totalSize += dataSize187;
		int dataSize188 = _injuryAutoHealSpeed.GetSerializedSize();
		totalSize += dataSize188;
		int dataSize189 = _canRecoverBreath.GetSerializedSize();
		totalSize += dataSize189;
		int dataSize190 = _canRecoverStance.GetSerializedSize();
		totalSize += dataSize190;
		int dataSize191 = _fatalDamageValue.GetSerializedSize();
		totalSize += dataSize191;
		int dataSize192 = _fatalDamageMarkCount.GetSerializedSize();
		totalSize += dataSize192;
		int dataSize193 = _canFightBackDuringPrepareSkill.GetSerializedSize();
		totalSize += dataSize193;
		int dataSize194 = _skillPrepareSpeed.GetSerializedSize();
		totalSize += dataSize194;
		int dataSize195 = _breathRecoverSpeed.GetSerializedSize();
		totalSize += dataSize195;
		int dataSize196 = _stanceRecoverSpeed.GetSerializedSize();
		totalSize += dataSize196;
		int dataSize197 = _mobilityRecoverSpeed.GetSerializedSize();
		totalSize += dataSize197;
		int dataSize198 = _changeTrickProgressAddValue.GetSerializedSize();
		totalSize += dataSize198;
		int dataSize199 = _power.GetSerializedSize();
		totalSize += dataSize199;
		int dataSize200 = _maxPower.GetSerializedSize();
		totalSize += dataSize200;
		int dataSize201 = _powerCanReduce.GetSerializedSize();
		totalSize += dataSize201;
		int dataSize202 = _useRequirement.GetSerializedSize();
		totalSize += dataSize202;
		int dataSize203 = _currInnerRatio.GetSerializedSize();
		totalSize += dataSize203;
		int dataSize204 = _costBreathAndStance.GetSerializedSize();
		totalSize += dataSize204;
		int dataSize205 = _costBreath.GetSerializedSize();
		totalSize += dataSize205;
		int dataSize206 = _costStance.GetSerializedSize();
		totalSize += dataSize206;
		int dataSize207 = _costMobility.GetSerializedSize();
		totalSize += dataSize207;
		int dataSize208 = _skillCostTricks.GetSerializedSize();
		totalSize += dataSize208;
		int dataSize209 = _effectDirection.GetSerializedSize();
		totalSize += dataSize209;
		int dataSize210 = _effectDirectionCanChange.GetSerializedSize();
		totalSize += dataSize210;
		int dataSize211 = _gridCost.GetSerializedSize();
		totalSize += dataSize211;
		int dataSize212 = _prepareTotalProgress.GetSerializedSize();
		totalSize += dataSize212;
		int dataSize213 = _specificGridCount.GetSerializedSize();
		totalSize += dataSize213;
		int dataSize214 = _genericGridCount.GetSerializedSize();
		totalSize += dataSize214;
		int dataSize215 = _canInterrupt.GetSerializedSize();
		totalSize += dataSize215;
		int dataSize216 = _interruptOdds.GetSerializedSize();
		totalSize += dataSize216;
		int dataSize217 = _canSilence.GetSerializedSize();
		totalSize += dataSize217;
		int dataSize218 = _silenceOdds.GetSerializedSize();
		totalSize += dataSize218;
		int dataSize219 = _canCastWithBrokenBodyPart.GetSerializedSize();
		totalSize += dataSize219;
		int dataSize220 = _addPowerCanBeRemoved.GetSerializedSize();
		totalSize += dataSize220;
		int dataSize221 = _skillType.GetSerializedSize();
		totalSize += dataSize221;
		int dataSize222 = _effectCountCanChange.GetSerializedSize();
		totalSize += dataSize222;
		int dataSize223 = _canCastInDefend.GetSerializedSize();
		totalSize += dataSize223;
		int dataSize224 = _hitDistribution.GetSerializedSize();
		totalSize += dataSize224;
		int dataSize225 = _canCastOnLackBreath.GetSerializedSize();
		totalSize += dataSize225;
		int dataSize226 = _canCastOnLackStance.GetSerializedSize();
		totalSize += dataSize226;
		int dataSize227 = _costBreathOnCast.GetSerializedSize();
		totalSize += dataSize227;
		int dataSize228 = _costStanceOnCast.GetSerializedSize();
		totalSize += dataSize228;
		int dataSize229 = _canUseMobilityAsBreath.GetSerializedSize();
		totalSize += dataSize229;
		int dataSize230 = _canUseMobilityAsStance.GetSerializedSize();
		totalSize += dataSize230;
		int dataSize231 = _castCostNeiliAllocation.GetSerializedSize();
		totalSize += dataSize231;
		int dataSize232 = _acceptPoisonResist.GetSerializedSize();
		totalSize += dataSize232;
		int dataSize233 = _makePoisonResist.GetSerializedSize();
		totalSize += dataSize233;
		int dataSize234 = _canCriticalHit.GetSerializedSize();
		totalSize += dataSize234;
		int dataSize235 = _canCostNeiliAllocationEffect.GetSerializedSize();
		totalSize += dataSize235;
		int dataSize236 = _consummateLevelRelatedMainAttributesHitValues.GetSerializedSize();
		totalSize += dataSize236;
		int dataSize237 = _consummateLevelRelatedMainAttributesAvoidValues.GetSerializedSize();
		totalSize += dataSize237;
		int dataSize238 = _consummateLevelRelatedMainAttributesPenetrations.GetSerializedSize();
		totalSize += dataSize238;
		int dataSize239 = _consummateLevelRelatedMainAttributesPenetrationResists.GetSerializedSize();
		totalSize += dataSize239;
		int dataSize240 = _skillAlsoAsFiveElements.GetSerializedSize();
		totalSize += dataSize240;
		int dataSize241 = _innerInjuryImmunity.GetSerializedSize();
		totalSize += dataSize241;
		int dataSize242 = _outerInjuryImmunity.GetSerializedSize();
		totalSize += dataSize242;
		int dataSize243 = _poisonAffectThreshold.GetSerializedSize();
		totalSize += dataSize243;
		int dataSize244 = _lockDistance.GetSerializedSize();
		totalSize += dataSize244;
		int dataSize245 = _resistOfAllPoison.GetSerializedSize();
		totalSize += dataSize245;
		int dataSize246 = _makePoisonTarget.GetSerializedSize();
		totalSize += dataSize246;
		int dataSize247 = _acceptPoisonTarget.GetSerializedSize();
		totalSize += dataSize247;
		int dataSize248 = _certainCriticalHit.GetSerializedSize();
		totalSize += dataSize248;
		int dataSize249 = _mindMarkCount.GetSerializedSize();
		totalSize += dataSize249;
		int dataSize250 = _canFightBackWithHit.GetSerializedSize();
		totalSize += dataSize250;
		int dataSize251 = _inevitableHit.GetSerializedSize();
		totalSize += dataSize251;
		int dataSize252 = _attackCanPursue.GetSerializedSize();
		totalSize += dataSize252;
		int dataSize253 = _combatSkillDataEffectList.GetSerializedSize();
		totalSize += dataSize253;
		int dataSize254 = _stanceCostByEffect.GetSerializedSize();
		totalSize += dataSize254;
		int dataSize255 = _breathCostByEffect.GetSerializedSize();
		totalSize += dataSize255;
		int dataSize256 = _powerAddRatio.GetSerializedSize();
		totalSize += dataSize256;
		int dataSize257 = _powerReduceRatio.GetSerializedSize();
		totalSize += dataSize257;
		int dataSize258 = _poisonAffectProduceValue.GetSerializedSize();
		totalSize += dataSize258;
		int dataSize259 = _canReadingOnMonthChange.GetSerializedSize();
		totalSize += dataSize259;
		int dataSize260 = _medicineEffect.GetSerializedSize();
		totalSize += dataSize260;
		int dataSize261 = _xiangshuInfectionDelta.GetSerializedSize();
		totalSize += dataSize261;
		int dataSize262 = _healthDelta.GetSerializedSize();
		totalSize += dataSize262;
		int dataSize263 = _weaponSilenceFrame.GetSerializedSize();
		totalSize += dataSize263;
		int dataSize264 = _silenceFrame.GetSerializedSize();
		totalSize += dataSize264;
		int dataSize265 = _currAgeDelta.GetSerializedSize();
		totalSize += dataSize265;
		int dataSize266 = _goneMadInAllBreak.GetSerializedSize();
		totalSize += dataSize266;
		int dataSize267 = _makeLoveRateOnMonthChange.GetSerializedSize();
		totalSize += dataSize267;
		int dataSize268 = _canAutoHealOnMonthChange.GetSerializedSize();
		totalSize += dataSize268;
		int dataSize269 = _happinessDelta.GetSerializedSize();
		totalSize += dataSize269;
		int dataSize270 = _teammateCmdCanUse.GetSerializedSize();
		totalSize += dataSize270;
		int dataSize271 = _mixPoisonInfinityAffect.GetSerializedSize();
		totalSize += dataSize271;
		int dataSize272 = _attackRangeMaxAcupoint.GetSerializedSize();
		totalSize += dataSize272;
		int dataSize273 = _maxMobilityPercent.GetSerializedSize();
		totalSize += dataSize273;
		int dataSize274 = _makeMindDamage.GetSerializedSize();
		totalSize += dataSize274;
		int dataSize275 = _acceptMindDamage.GetSerializedSize();
		totalSize += dataSize275;
		int dataSize276 = _hitAddByTempValue.GetSerializedSize();
		totalSize += dataSize276;
		int dataSize277 = _avoidAddByTempValue.GetSerializedSize();
		totalSize += dataSize277;
		int dataSize278 = _ignoreEquipmentOverload.GetSerializedSize();
		totalSize += dataSize278;
		int dataSize279 = _canCostEnemyUsableTricks.GetSerializedSize();
		totalSize += dataSize279;
		int dataSize280 = _ignoreArmor.GetSerializedSize();
		totalSize += dataSize280;
		int dataSize281 = _unyieldingFallen.GetSerializedSize();
		totalSize += dataSize281;
		int dataSize282 = _normalAttackPrepareFrame.GetSerializedSize();
		totalSize += dataSize282;
		int dataSize283 = _canCostUselessTricks.GetSerializedSize();
		totalSize += dataSize283;
		int dataSize284 = _defendSkillCanAffect.GetSerializedSize();
		totalSize += dataSize284;
		int dataSize285 = _assistSkillCanAffect.GetSerializedSize();
		totalSize += dataSize285;
		int dataSize286 = _agileSkillCanAffect.GetSerializedSize();
		totalSize += dataSize286;
		int dataSize287 = _allMarkChangeToMind.GetSerializedSize();
		totalSize += dataSize287;
		int dataSize288 = _mindMarkChangeToFatal.GetSerializedSize();
		totalSize += dataSize288;
		int dataSize289 = _canCast.GetSerializedSize();
		totalSize += dataSize289;
		int dataSize290 = _inevitableAvoid.GetSerializedSize();
		totalSize += dataSize290;
		int dataSize291 = _powerEffectReverse.GetSerializedSize();
		totalSize += dataSize291;
		int dataSize292 = _featureBonusReverse.GetSerializedSize();
		totalSize += dataSize292;
		int dataSize293 = _wugFatalDamageValue.GetSerializedSize();
		totalSize += dataSize293;
		int dataSize294 = _canRecoverHealthOnMonthChange.GetSerializedSize();
		totalSize += dataSize294;
		int dataSize295 = _takeRevengeRateOnMonthChange.GetSerializedSize();
		totalSize += dataSize295;
		int dataSize296 = _consummateLevelBonus.GetSerializedSize();
		totalSize += dataSize296;
		int dataSize297 = _neiliDelta.GetSerializedSize();
		totalSize += dataSize297;
		int dataSize298 = _canMakeLoveSpecialOnMonthChange.GetSerializedSize();
		totalSize += dataSize298;
		int dataSize299 = _healAcupointSpeed.GetSerializedSize();
		totalSize += dataSize299;
		int dataSize300 = _maxChangeTrickCount.GetSerializedSize();
		totalSize += dataSize300;
		int dataSize301 = _convertCostBreathAndStance.GetSerializedSize();
		totalSize += dataSize301;
		int dataSize302 = _personalitiesAll.GetSerializedSize();
		totalSize += dataSize302;
		int dataSize303 = _finalFatalDamageMarkCount.GetSerializedSize();
		totalSize += dataSize303;
		int dataSize304 = _combatSkillAiScorePower.GetSerializedSize();
		totalSize += dataSize304;
		int dataSize305 = _normalAttackChangeToUnlockAttack.GetSerializedSize();
		totalSize += dataSize305;
		int dataSize306 = _attackBodyPartOdds.GetSerializedSize();
		totalSize += dataSize306;
		int dataSize307 = _changeDurability.GetSerializedSize();
		totalSize += dataSize307;
		int dataSize308 = _equipmentBonus.GetSerializedSize();
		totalSize += dataSize308;
		int dataSize309 = _equipmentWeight.GetSerializedSize();
		totalSize += dataSize309;
		int dataSize310 = _rawCreateEffectList.GetSerializedSize();
		totalSize += dataSize310;
		int dataSize311 = _jiTrickAsWeaponTrickCount.GetSerializedSize();
		totalSize += dataSize311;
		int dataSize312 = _uselessTrickAsJiTrickCount.GetSerializedSize();
		totalSize += dataSize312;
		int dataSize313 = _equipmentPower.GetSerializedSize();
		totalSize += dataSize313;
		int dataSize314 = _healFlawSpeed.GetSerializedSize();
		totalSize += dataSize314;
		int dataSize315 = _unlockSpeed.GetSerializedSize();
		totalSize += dataSize315;
		int dataSize316 = _flawBonusFactor.GetSerializedSize();
		totalSize += dataSize316;
		int dataSize317 = _canCostShaTricks.GetSerializedSize();
		totalSize += dataSize317;
		int dataSize318 = _defenderDirectFinalDamageValue.GetSerializedSize();
		totalSize += dataSize318;
		int dataSize319 = _normalAttackRecoveryFrame.GetSerializedSize();
		totalSize += dataSize319;
		int dataSize320 = _finalGoneMadInjury.GetSerializedSize();
		totalSize += dataSize320;
		int dataSize321 = _attackerDirectFinalDamageValue.GetSerializedSize();
		totalSize += dataSize321;
		int dataSize322 = _canCostTrickDuringPreparingSkill.GetSerializedSize();
		totalSize += dataSize322;
		int dataSize323 = _validItemList.GetSerializedSize();
		totalSize += dataSize323;
		int dataSize324 = _acceptDamageCanAdd.GetSerializedSize();
		totalSize += dataSize324;
		int dataSize325 = _makeDamageCanReduce.GetSerializedSize();
		totalSize += dataSize325;
		int dataSize326 = _normalAttackGetTrickCount.GetSerializedSize();
		totalSize += dataSize326;
		int dataSize327 = _stayEffectCountOnAddPhase.GetSerializedSize();
		totalSize += dataSize327;
		int dataSize328 = _healInjuryWithFatalRequireAttainment.GetSerializedSize();
		totalSize += dataSize328;
		int dataSize329 = _useItemCostNoWisdom.GetSerializedSize();
		totalSize += dataSize329;
		int dataSize330 = _mindUpheavalTime.GetSerializedSize();
		totalSize += dataSize330;
		int dataSize331 = _makeHarmfulActionSuccessRate.GetSerializedSize();
		totalSize += dataSize331;
		int dataSize332 = _acceptHarmfulActionSuccessRate.GetSerializedSize();
		totalSize += dataSize332;
		int dataSize333 = _makeFatalDamage.GetSerializedSize();
		totalSize += dataSize333;
		int dataSize334 = _acceptFatalDamage.GetSerializedSize();
		totalSize += dataSize334;
		int dataSize335 = _causedInjuryChangeToOldOdds.GetSerializedSize();
		totalSize += dataSize335;
		int dataSize336 = _causedMindChangeToInfiniteOdds.GetSerializedSize();
		totalSize += dataSize336;
		int dataSize337 = _hitReduceDurability.GetSerializedSize();
		totalSize += dataSize337;
		int dataSize338 = _equipmentMasteryAffectOdds.GetSerializedSize();
		totalSize += dataSize338;
		int dataSize339 = _criticalDamage.GetSerializedSize();
		totalSize += dataSize339;
		int dataSize340 = _canFightBackOutOfAttackRange.GetSerializedSize();
		totalSize += dataSize340;
		int dataSize341 = _attackerCriticalOdds.GetSerializedSize();
		totalSize += dataSize341;
		int dataSize342 = _defenderCriticalOdds.GetSerializedSize();
		totalSize += dataSize342;
		int dataSize343 = _mixPoisonCanAffectCount.GetSerializedSize();
		totalSize += dataSize343;
		int dataSize344 = _castCostNeiliAllocationIsAbsorb.GetSerializedSize();
		totalSize += dataSize344;
		int dataSize345 = _acceptInjuryChangeToOldOdds.GetSerializedSize();
		return totalSize + dataSize345;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _maxStrength.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_maxStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		byte* pBegin2 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxDexterity.Serialize(pCurrData);
		int fieldSize2 = (int)(pCurrData - pBegin2 - 4);
		if (fieldSize2 > 4194304)
		{
			throw new Exception($"Size of field {"_maxDexterity"} must be less than {4096}KB");
		}
		*(int*)pBegin2 = fieldSize2;
		byte* pBegin3 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxConcentration.Serialize(pCurrData);
		int fieldSize3 = (int)(pCurrData - pBegin3 - 4);
		if (fieldSize3 > 4194304)
		{
			throw new Exception($"Size of field {"_maxConcentration"} must be less than {4096}KB");
		}
		*(int*)pBegin3 = fieldSize3;
		byte* pBegin4 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxVitality.Serialize(pCurrData);
		int fieldSize4 = (int)(pCurrData - pBegin4 - 4);
		if (fieldSize4 > 4194304)
		{
			throw new Exception($"Size of field {"_maxVitality"} must be less than {4096}KB");
		}
		*(int*)pBegin4 = fieldSize4;
		byte* pBegin5 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxEnergy.Serialize(pCurrData);
		int fieldSize5 = (int)(pCurrData - pBegin5 - 4);
		if (fieldSize5 > 4194304)
		{
			throw new Exception($"Size of field {"_maxEnergy"} must be less than {4096}KB");
		}
		*(int*)pBegin5 = fieldSize5;
		byte* pBegin6 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxIntelligence.Serialize(pCurrData);
		int fieldSize6 = (int)(pCurrData - pBegin6 - 4);
		if (fieldSize6 > 4194304)
		{
			throw new Exception($"Size of field {"_maxIntelligence"} must be less than {4096}KB");
		}
		*(int*)pBegin6 = fieldSize6;
		byte* pBegin7 = pCurrData;
		pCurrData += 4;
		pCurrData += _recoveryOfStance.Serialize(pCurrData);
		int fieldSize7 = (int)(pCurrData - pBegin7 - 4);
		if (fieldSize7 > 4194304)
		{
			throw new Exception($"Size of field {"_recoveryOfStance"} must be less than {4096}KB");
		}
		*(int*)pBegin7 = fieldSize7;
		byte* pBegin8 = pCurrData;
		pCurrData += 4;
		pCurrData += _recoveryOfBreath.Serialize(pCurrData);
		int fieldSize8 = (int)(pCurrData - pBegin8 - 4);
		if (fieldSize8 > 4194304)
		{
			throw new Exception($"Size of field {"_recoveryOfBreath"} must be less than {4096}KB");
		}
		*(int*)pBegin8 = fieldSize8;
		byte* pBegin9 = pCurrData;
		pCurrData += 4;
		pCurrData += _moveSpeed.Serialize(pCurrData);
		int fieldSize9 = (int)(pCurrData - pBegin9 - 4);
		if (fieldSize9 > 4194304)
		{
			throw new Exception($"Size of field {"_moveSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin9 = fieldSize9;
		byte* pBegin10 = pCurrData;
		pCurrData += 4;
		pCurrData += _recoveryOfFlaw.Serialize(pCurrData);
		int fieldSize10 = (int)(pCurrData - pBegin10 - 4);
		if (fieldSize10 > 4194304)
		{
			throw new Exception($"Size of field {"_recoveryOfFlaw"} must be less than {4096}KB");
		}
		*(int*)pBegin10 = fieldSize10;
		byte* pBegin11 = pCurrData;
		pCurrData += 4;
		pCurrData += _castSpeed.Serialize(pCurrData);
		int fieldSize11 = (int)(pCurrData - pBegin11 - 4);
		if (fieldSize11 > 4194304)
		{
			throw new Exception($"Size of field {"_castSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin11 = fieldSize11;
		byte* pBegin12 = pCurrData;
		pCurrData += 4;
		pCurrData += _recoveryOfBlockedAcupoint.Serialize(pCurrData);
		int fieldSize12 = (int)(pCurrData - pBegin12 - 4);
		if (fieldSize12 > 4194304)
		{
			throw new Exception($"Size of field {"_recoveryOfBlockedAcupoint"} must be less than {4096}KB");
		}
		*(int*)pBegin12 = fieldSize12;
		byte* pBegin13 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponSwitchSpeed.Serialize(pCurrData);
		int fieldSize13 = (int)(pCurrData - pBegin13 - 4);
		if (fieldSize13 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponSwitchSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin13 = fieldSize13;
		byte* pBegin14 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackSpeed.Serialize(pCurrData);
		int fieldSize14 = (int)(pCurrData - pBegin14 - 4);
		if (fieldSize14 > 4194304)
		{
			throw new Exception($"Size of field {"_attackSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin14 = fieldSize14;
		byte* pBegin15 = pCurrData;
		pCurrData += 4;
		pCurrData += _innerRatio.Serialize(pCurrData);
		int fieldSize15 = (int)(pCurrData - pBegin15 - 4);
		if (fieldSize15 > 4194304)
		{
			throw new Exception($"Size of field {"_innerRatio"} must be less than {4096}KB");
		}
		*(int*)pBegin15 = fieldSize15;
		byte* pBegin16 = pCurrData;
		pCurrData += 4;
		pCurrData += _recoveryOfQiDisorder.Serialize(pCurrData);
		int fieldSize16 = (int)(pCurrData - pBegin16 - 4);
		if (fieldSize16 > 4194304)
		{
			throw new Exception($"Size of field {"_recoveryOfQiDisorder"} must be less than {4096}KB");
		}
		*(int*)pBegin16 = fieldSize16;
		byte* pBegin17 = pCurrData;
		pCurrData += 4;
		pCurrData += _minorAttributeFixMaxValue.Serialize(pCurrData);
		int fieldSize17 = (int)(pCurrData - pBegin17 - 4);
		if (fieldSize17 > 4194304)
		{
			throw new Exception($"Size of field {"_minorAttributeFixMaxValue"} must be less than {4096}KB");
		}
		*(int*)pBegin17 = fieldSize17;
		byte* pBegin18 = pCurrData;
		pCurrData += 4;
		pCurrData += _minorAttributeFixMinValue.Serialize(pCurrData);
		int fieldSize18 = (int)(pCurrData - pBegin18 - 4);
		if (fieldSize18 > 4194304)
		{
			throw new Exception($"Size of field {"_minorAttributeFixMinValue"} must be less than {4096}KB");
		}
		*(int*)pBegin18 = fieldSize18;
		byte* pBegin19 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfHotPoison.Serialize(pCurrData);
		int fieldSize19 = (int)(pCurrData - pBegin19 - 4);
		if (fieldSize19 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfHotPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin19 = fieldSize19;
		byte* pBegin20 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfGloomyPoison.Serialize(pCurrData);
		int fieldSize20 = (int)(pCurrData - pBegin20 - 4);
		if (fieldSize20 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfGloomyPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin20 = fieldSize20;
		byte* pBegin21 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfColdPoison.Serialize(pCurrData);
		int fieldSize21 = (int)(pCurrData - pBegin21 - 4);
		if (fieldSize21 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfColdPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin21 = fieldSize21;
		byte* pBegin22 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfRedPoison.Serialize(pCurrData);
		int fieldSize22 = (int)(pCurrData - pBegin22 - 4);
		if (fieldSize22 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfRedPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin22 = fieldSize22;
		byte* pBegin23 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfRottenPoison.Serialize(pCurrData);
		int fieldSize23 = (int)(pCurrData - pBegin23 - 4);
		if (fieldSize23 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfRottenPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin23 = fieldSize23;
		byte* pBegin24 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfIllusoryPoison.Serialize(pCurrData);
		int fieldSize24 = (int)(pCurrData - pBegin24 - 4);
		if (fieldSize24 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfIllusoryPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin24 = fieldSize24;
		byte* pBegin25 = pCurrData;
		pCurrData += 4;
		pCurrData += _displayAge.Serialize(pCurrData);
		int fieldSize25 = (int)(pCurrData - pBegin25 - 4);
		if (fieldSize25 > 4194304)
		{
			throw new Exception($"Size of field {"_displayAge"} must be less than {4096}KB");
		}
		*(int*)pBegin25 = fieldSize25;
		byte* pBegin26 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliProportionOfFiveElements.Serialize(pCurrData);
		int fieldSize26 = (int)(pCurrData - pBegin26 - 4);
		if (fieldSize26 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliProportionOfFiveElements"} must be less than {4096}KB");
		}
		*(int*)pBegin26 = fieldSize26;
		byte* pBegin27 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponMaxPower.Serialize(pCurrData);
		int fieldSize27 = (int)(pCurrData - pBegin27 - 4);
		if (fieldSize27 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponMaxPower"} must be less than {4096}KB");
		}
		*(int*)pBegin27 = fieldSize27;
		byte* pBegin28 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponUseRequirement.Serialize(pCurrData);
		int fieldSize28 = (int)(pCurrData - pBegin28 - 4);
		if (fieldSize28 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponUseRequirement"} must be less than {4096}KB");
		}
		*(int*)pBegin28 = fieldSize28;
		byte* pBegin29 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponAttackRange.Serialize(pCurrData);
		int fieldSize29 = (int)(pCurrData - pBegin29 - 4);
		if (fieldSize29 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponAttackRange"} must be less than {4096}KB");
		}
		*(int*)pBegin29 = fieldSize29;
		byte* pBegin30 = pCurrData;
		pCurrData += 4;
		pCurrData += _armorMaxPower.Serialize(pCurrData);
		int fieldSize30 = (int)(pCurrData - pBegin30 - 4);
		if (fieldSize30 > 4194304)
		{
			throw new Exception($"Size of field {"_armorMaxPower"} must be less than {4096}KB");
		}
		*(int*)pBegin30 = fieldSize30;
		byte* pBegin31 = pCurrData;
		pCurrData += 4;
		pCurrData += _armorUseRequirement.Serialize(pCurrData);
		int fieldSize31 = (int)(pCurrData - pBegin31 - 4);
		if (fieldSize31 > 4194304)
		{
			throw new Exception($"Size of field {"_armorUseRequirement"} must be less than {4096}KB");
		}
		*(int*)pBegin31 = fieldSize31;
		byte* pBegin32 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitStrength.Serialize(pCurrData);
		int fieldSize32 = (int)(pCurrData - pBegin32 - 4);
		if (fieldSize32 > 4194304)
		{
			throw new Exception($"Size of field {"_hitStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin32 = fieldSize32;
		byte* pBegin33 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitTechnique.Serialize(pCurrData);
		int fieldSize33 = (int)(pCurrData - pBegin33 - 4);
		if (fieldSize33 > 4194304)
		{
			throw new Exception($"Size of field {"_hitTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin33 = fieldSize33;
		byte* pBegin34 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitSpeed.Serialize(pCurrData);
		int fieldSize34 = (int)(pCurrData - pBegin34 - 4);
		if (fieldSize34 > 4194304)
		{
			throw new Exception($"Size of field {"_hitSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin34 = fieldSize34;
		byte* pBegin35 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitMind.Serialize(pCurrData);
		int fieldSize35 = (int)(pCurrData - pBegin35 - 4);
		if (fieldSize35 > 4194304)
		{
			throw new Exception($"Size of field {"_hitMind"} must be less than {4096}KB");
		}
		*(int*)pBegin35 = fieldSize35;
		byte* pBegin36 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitCanChange.Serialize(pCurrData);
		int fieldSize36 = (int)(pCurrData - pBegin36 - 4);
		if (fieldSize36 > 4194304)
		{
			throw new Exception($"Size of field {"_hitCanChange"} must be less than {4096}KB");
		}
		*(int*)pBegin36 = fieldSize36;
		byte* pBegin37 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitChangeEffectPercent.Serialize(pCurrData);
		int fieldSize37 = (int)(pCurrData - pBegin37 - 4);
		if (fieldSize37 > 4194304)
		{
			throw new Exception($"Size of field {"_hitChangeEffectPercent"} must be less than {4096}KB");
		}
		*(int*)pBegin37 = fieldSize37;
		byte* pBegin38 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidStrength.Serialize(pCurrData);
		int fieldSize38 = (int)(pCurrData - pBegin38 - 4);
		if (fieldSize38 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin38 = fieldSize38;
		byte* pBegin39 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidTechnique.Serialize(pCurrData);
		int fieldSize39 = (int)(pCurrData - pBegin39 - 4);
		if (fieldSize39 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin39 = fieldSize39;
		byte* pBegin40 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidSpeed.Serialize(pCurrData);
		int fieldSize40 = (int)(pCurrData - pBegin40 - 4);
		if (fieldSize40 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin40 = fieldSize40;
		byte* pBegin41 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidMind.Serialize(pCurrData);
		int fieldSize41 = (int)(pCurrData - pBegin41 - 4);
		if (fieldSize41 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidMind"} must be less than {4096}KB");
		}
		*(int*)pBegin41 = fieldSize41;
		byte* pBegin42 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidCanChange.Serialize(pCurrData);
		int fieldSize42 = (int)(pCurrData - pBegin42 - 4);
		if (fieldSize42 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidCanChange"} must be less than {4096}KB");
		}
		*(int*)pBegin42 = fieldSize42;
		byte* pBegin43 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidChangeEffectPercent.Serialize(pCurrData);
		int fieldSize43 = (int)(pCurrData - pBegin43 - 4);
		if (fieldSize43 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidChangeEffectPercent"} must be less than {4096}KB");
		}
		*(int*)pBegin43 = fieldSize43;
		byte* pBegin44 = pCurrData;
		pCurrData += 4;
		pCurrData += _penetrateOuter.Serialize(pCurrData);
		int fieldSize44 = (int)(pCurrData - pBegin44 - 4);
		if (fieldSize44 > 4194304)
		{
			throw new Exception($"Size of field {"_penetrateOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin44 = fieldSize44;
		byte* pBegin45 = pCurrData;
		pCurrData += 4;
		pCurrData += _penetrateInner.Serialize(pCurrData);
		int fieldSize45 = (int)(pCurrData - pBegin45 - 4);
		if (fieldSize45 > 4194304)
		{
			throw new Exception($"Size of field {"_penetrateInner"} must be less than {4096}KB");
		}
		*(int*)pBegin45 = fieldSize45;
		byte* pBegin46 = pCurrData;
		pCurrData += 4;
		pCurrData += _penetrateResistOuter.Serialize(pCurrData);
		int fieldSize46 = (int)(pCurrData - pBegin46 - 4);
		if (fieldSize46 > 4194304)
		{
			throw new Exception($"Size of field {"_penetrateResistOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin46 = fieldSize46;
		byte* pBegin47 = pCurrData;
		pCurrData += 4;
		pCurrData += _penetrateResistInner.Serialize(pCurrData);
		int fieldSize47 = (int)(pCurrData - pBegin47 - 4);
		if (fieldSize47 > 4194304)
		{
			throw new Exception($"Size of field {"_penetrateResistInner"} must be less than {4096}KB");
		}
		*(int*)pBegin47 = fieldSize47;
		byte* pBegin48 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliAllocationAttack.Serialize(pCurrData);
		int fieldSize48 = (int)(pCurrData - pBegin48 - 4);
		if (fieldSize48 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliAllocationAttack"} must be less than {4096}KB");
		}
		*(int*)pBegin48 = fieldSize48;
		byte* pBegin49 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliAllocationAgile.Serialize(pCurrData);
		int fieldSize49 = (int)(pCurrData - pBegin49 - 4);
		if (fieldSize49 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliAllocationAgile"} must be less than {4096}KB");
		}
		*(int*)pBegin49 = fieldSize49;
		byte* pBegin50 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliAllocationDefense.Serialize(pCurrData);
		int fieldSize50 = (int)(pCurrData - pBegin50 - 4);
		if (fieldSize50 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliAllocationDefense"} must be less than {4096}KB");
		}
		*(int*)pBegin50 = fieldSize50;
		byte* pBegin51 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliAllocationAssist.Serialize(pCurrData);
		int fieldSize51 = (int)(pCurrData - pBegin51 - 4);
		if (fieldSize51 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliAllocationAssist"} must be less than {4096}KB");
		}
		*(int*)pBegin51 = fieldSize51;
		byte* pBegin52 = pCurrData;
		pCurrData += 4;
		pCurrData += _happiness.Serialize(pCurrData);
		int fieldSize52 = (int)(pCurrData - pBegin52 - 4);
		if (fieldSize52 > 4194304)
		{
			throw new Exception($"Size of field {"_happiness"} must be less than {4096}KB");
		}
		*(int*)pBegin52 = fieldSize52;
		byte* pBegin53 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxHealth.Serialize(pCurrData);
		int fieldSize53 = (int)(pCurrData - pBegin53 - 4);
		if (fieldSize53 > 4194304)
		{
			throw new Exception($"Size of field {"_maxHealth"} must be less than {4096}KB");
		}
		*(int*)pBegin53 = fieldSize53;
		byte* pBegin54 = pCurrData;
		pCurrData += 4;
		pCurrData += _healthCost.Serialize(pCurrData);
		int fieldSize54 = (int)(pCurrData - pBegin54 - 4);
		if (fieldSize54 > 4194304)
		{
			throw new Exception($"Size of field {"_healthCost"} must be less than {4096}KB");
		}
		*(int*)pBegin54 = fieldSize54;
		byte* pBegin55 = pCurrData;
		pCurrData += 4;
		pCurrData += _moveSpeedCanChange.Serialize(pCurrData);
		int fieldSize55 = (int)(pCurrData - pBegin55 - 4);
		if (fieldSize55 > 4194304)
		{
			throw new Exception($"Size of field {"_moveSpeedCanChange"} must be less than {4096}KB");
		}
		*(int*)pBegin55 = fieldSize55;
		byte* pBegin56 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerHitStrength.Serialize(pCurrData);
		int fieldSize56 = (int)(pCurrData - pBegin56 - 4);
		if (fieldSize56 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerHitStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin56 = fieldSize56;
		byte* pBegin57 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerHitTechnique.Serialize(pCurrData);
		int fieldSize57 = (int)(pCurrData - pBegin57 - 4);
		if (fieldSize57 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerHitTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin57 = fieldSize57;
		byte* pBegin58 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerHitSpeed.Serialize(pCurrData);
		int fieldSize58 = (int)(pCurrData - pBegin58 - 4);
		if (fieldSize58 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerHitSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin58 = fieldSize58;
		byte* pBegin59 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerHitMind.Serialize(pCurrData);
		int fieldSize59 = (int)(pCurrData - pBegin59 - 4);
		if (fieldSize59 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerHitMind"} must be less than {4096}KB");
		}
		*(int*)pBegin59 = fieldSize59;
		byte* pBegin60 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerAvoidStrength.Serialize(pCurrData);
		int fieldSize60 = (int)(pCurrData - pBegin60 - 4);
		if (fieldSize60 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerAvoidStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin60 = fieldSize60;
		byte* pBegin61 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerAvoidTechnique.Serialize(pCurrData);
		int fieldSize61 = (int)(pCurrData - pBegin61 - 4);
		if (fieldSize61 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerAvoidTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin61 = fieldSize61;
		byte* pBegin62 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerAvoidSpeed.Serialize(pCurrData);
		int fieldSize62 = (int)(pCurrData - pBegin62 - 4);
		if (fieldSize62 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerAvoidSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin62 = fieldSize62;
		byte* pBegin63 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerAvoidMind.Serialize(pCurrData);
		int fieldSize63 = (int)(pCurrData - pBegin63 - 4);
		if (fieldSize63 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerAvoidMind"} must be less than {4096}KB");
		}
		*(int*)pBegin63 = fieldSize63;
		byte* pBegin64 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerPenetrateOuter.Serialize(pCurrData);
		int fieldSize64 = (int)(pCurrData - pBegin64 - 4);
		if (fieldSize64 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerPenetrateOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin64 = fieldSize64;
		byte* pBegin65 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerPenetrateInner.Serialize(pCurrData);
		int fieldSize65 = (int)(pCurrData - pBegin65 - 4);
		if (fieldSize65 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerPenetrateInner"} must be less than {4096}KB");
		}
		*(int*)pBegin65 = fieldSize65;
		byte* pBegin66 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerPenetrateResistOuter.Serialize(pCurrData);
		int fieldSize66 = (int)(pCurrData - pBegin66 - 4);
		if (fieldSize66 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerPenetrateResistOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin66 = fieldSize66;
		byte* pBegin67 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerPenetrateResistInner.Serialize(pCurrData);
		int fieldSize67 = (int)(pCurrData - pBegin67 - 4);
		if (fieldSize67 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerPenetrateResistInner"} must be less than {4096}KB");
		}
		*(int*)pBegin67 = fieldSize67;
		byte* pBegin68 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackHitType.Serialize(pCurrData);
		int fieldSize68 = (int)(pCurrData - pBegin68 - 4);
		if (fieldSize68 > 4194304)
		{
			throw new Exception($"Size of field {"_attackHitType"} must be less than {4096}KB");
		}
		*(int*)pBegin68 = fieldSize68;
		byte* pBegin69 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeDirectDamage.Serialize(pCurrData);
		int fieldSize69 = (int)(pCurrData - pBegin69 - 4);
		if (fieldSize69 > 4194304)
		{
			throw new Exception($"Size of field {"_makeDirectDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin69 = fieldSize69;
		byte* pBegin70 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeBounceDamage.Serialize(pCurrData);
		int fieldSize70 = (int)(pCurrData - pBegin70 - 4);
		if (fieldSize70 > 4194304)
		{
			throw new Exception($"Size of field {"_makeBounceDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin70 = fieldSize70;
		byte* pBegin71 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeFightBackDamage.Serialize(pCurrData);
		int fieldSize71 = (int)(pCurrData - pBegin71 - 4);
		if (fieldSize71 > 4194304)
		{
			throw new Exception($"Size of field {"_makeFightBackDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin71 = fieldSize71;
		byte* pBegin72 = pCurrData;
		pCurrData += 4;
		pCurrData += _makePoisonLevel.Serialize(pCurrData);
		int fieldSize72 = (int)(pCurrData - pBegin72 - 4);
		if (fieldSize72 > 4194304)
		{
			throw new Exception($"Size of field {"_makePoisonLevel"} must be less than {4096}KB");
		}
		*(int*)pBegin72 = fieldSize72;
		byte* pBegin73 = pCurrData;
		pCurrData += 4;
		pCurrData += _makePoisonValue.Serialize(pCurrData);
		int fieldSize73 = (int)(pCurrData - pBegin73 - 4);
		if (fieldSize73 > 4194304)
		{
			throw new Exception($"Size of field {"_makePoisonValue"} must be less than {4096}KB");
		}
		*(int*)pBegin73 = fieldSize73;
		byte* pBegin74 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerHitOdds.Serialize(pCurrData);
		int fieldSize74 = (int)(pCurrData - pBegin74 - 4);
		if (fieldSize74 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerHitOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin74 = fieldSize74;
		byte* pBegin75 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerFightBackHitOdds.Serialize(pCurrData);
		int fieldSize75 = (int)(pCurrData - pBegin75 - 4);
		if (fieldSize75 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerFightBackHitOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin75 = fieldSize75;
		byte* pBegin76 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerPursueOdds.Serialize(pCurrData);
		int fieldSize76 = (int)(pCurrData - pBegin76 - 4);
		if (fieldSize76 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerPursueOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin76 = fieldSize76;
		byte* pBegin77 = pCurrData;
		pCurrData += 4;
		pCurrData += _causedInjuryChangeToOld.Serialize(pCurrData);
		int fieldSize77 = (int)(pCurrData - pBegin77 - 4);
		if (fieldSize77 > 4194304)
		{
			throw new Exception($"Size of field {"_causedInjuryChangeToOld"} must be less than {4096}KB");
		}
		*(int*)pBegin77 = fieldSize77;
		byte* pBegin78 = pCurrData;
		pCurrData += 4;
		pCurrData += _causedPoisonChangeToOld.Serialize(pCurrData);
		int fieldSize78 = (int)(pCurrData - pBegin78 - 4);
		if (fieldSize78 > 4194304)
		{
			throw new Exception($"Size of field {"_causedPoisonChangeToOld"} must be less than {4096}KB");
		}
		*(int*)pBegin78 = fieldSize78;
		byte* pBegin79 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeDamageType.Serialize(pCurrData);
		int fieldSize79 = (int)(pCurrData - pBegin79 - 4);
		if (fieldSize79 > 4194304)
		{
			throw new Exception($"Size of field {"_makeDamageType"} must be less than {4096}KB");
		}
		*(int*)pBegin79 = fieldSize79;
		byte* pBegin80 = pCurrData;
		pCurrData += 4;
		pCurrData += _canMakeInjuryToNoInjuryPart.Serialize(pCurrData);
		int fieldSize80 = (int)(pCurrData - pBegin80 - 4);
		if (fieldSize80 > 4194304)
		{
			throw new Exception($"Size of field {"_canMakeInjuryToNoInjuryPart"} must be less than {4096}KB");
		}
		*(int*)pBegin80 = fieldSize80;
		byte* pBegin81 = pCurrData;
		pCurrData += 4;
		pCurrData += _makePoisonType.Serialize(pCurrData);
		int fieldSize81 = (int)(pCurrData - pBegin81 - 4);
		if (fieldSize81 > 4194304)
		{
			throw new Exception($"Size of field {"_makePoisonType"} must be less than {4096}KB");
		}
		*(int*)pBegin81 = fieldSize81;
		byte* pBegin82 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackWeapon.Serialize(pCurrData);
		int fieldSize82 = (int)(pCurrData - pBegin82 - 4);
		if (fieldSize82 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackWeapon"} must be less than {4096}KB");
		}
		*(int*)pBegin82 = fieldSize82;
		byte* pBegin83 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackTrick.Serialize(pCurrData);
		int fieldSize83 = (int)(pCurrData - pBegin83 - 4);
		if (fieldSize83 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackTrick"} must be less than {4096}KB");
		}
		*(int*)pBegin83 = fieldSize83;
		byte* pBegin84 = pCurrData;
		pCurrData += 4;
		pCurrData += _extraFlawCount.Serialize(pCurrData);
		int fieldSize84 = (int)(pCurrData - pBegin84 - 4);
		if (fieldSize84 > 4194304)
		{
			throw new Exception($"Size of field {"_extraFlawCount"} must be less than {4096}KB");
		}
		*(int*)pBegin84 = fieldSize84;
		byte* pBegin85 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackCanBounce.Serialize(pCurrData);
		int fieldSize85 = (int)(pCurrData - pBegin85 - 4);
		if (fieldSize85 > 4194304)
		{
			throw new Exception($"Size of field {"_attackCanBounce"} must be less than {4096}KB");
		}
		*(int*)pBegin85 = fieldSize85;
		byte* pBegin86 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackCanFightBack.Serialize(pCurrData);
		int fieldSize86 = (int)(pCurrData - pBegin86 - 4);
		if (fieldSize86 > 4194304)
		{
			throw new Exception($"Size of field {"_attackCanFightBack"} must be less than {4096}KB");
		}
		*(int*)pBegin86 = fieldSize86;
		byte* pBegin87 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeFightBackInjuryMark.Serialize(pCurrData);
		int fieldSize87 = (int)(pCurrData - pBegin87 - 4);
		if (fieldSize87 > 4194304)
		{
			throw new Exception($"Size of field {"_makeFightBackInjuryMark"} must be less than {4096}KB");
		}
		*(int*)pBegin87 = fieldSize87;
		byte* pBegin88 = pCurrData;
		pCurrData += 4;
		pCurrData += _legSkillUseShoes.Serialize(pCurrData);
		int fieldSize88 = (int)(pCurrData - pBegin88 - 4);
		if (fieldSize88 > 4194304)
		{
			throw new Exception($"Size of field {"_legSkillUseShoes"} must be less than {4096}KB");
		}
		*(int*)pBegin88 = fieldSize88;
		byte* pBegin89 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerFinalDamageValue.Serialize(pCurrData);
		int fieldSize89 = (int)(pCurrData - pBegin89 - 4);
		if (fieldSize89 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerFinalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin89 = fieldSize89;
		byte* pBegin90 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderHitStrength.Serialize(pCurrData);
		int fieldSize90 = (int)(pCurrData - pBegin90 - 4);
		if (fieldSize90 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderHitStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin90 = fieldSize90;
		byte* pBegin91 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderHitTechnique.Serialize(pCurrData);
		int fieldSize91 = (int)(pCurrData - pBegin91 - 4);
		if (fieldSize91 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderHitTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin91 = fieldSize91;
		byte* pBegin92 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderHitSpeed.Serialize(pCurrData);
		int fieldSize92 = (int)(pCurrData - pBegin92 - 4);
		if (fieldSize92 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderHitSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin92 = fieldSize92;
		byte* pBegin93 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderHitMind.Serialize(pCurrData);
		int fieldSize93 = (int)(pCurrData - pBegin93 - 4);
		if (fieldSize93 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderHitMind"} must be less than {4096}KB");
		}
		*(int*)pBegin93 = fieldSize93;
		byte* pBegin94 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderAvoidStrength.Serialize(pCurrData);
		int fieldSize94 = (int)(pCurrData - pBegin94 - 4);
		if (fieldSize94 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderAvoidStrength"} must be less than {4096}KB");
		}
		*(int*)pBegin94 = fieldSize94;
		byte* pBegin95 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderAvoidTechnique.Serialize(pCurrData);
		int fieldSize95 = (int)(pCurrData - pBegin95 - 4);
		if (fieldSize95 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderAvoidTechnique"} must be less than {4096}KB");
		}
		*(int*)pBegin95 = fieldSize95;
		byte* pBegin96 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderAvoidSpeed.Serialize(pCurrData);
		int fieldSize96 = (int)(pCurrData - pBegin96 - 4);
		if (fieldSize96 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderAvoidSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin96 = fieldSize96;
		byte* pBegin97 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderAvoidMind.Serialize(pCurrData);
		int fieldSize97 = (int)(pCurrData - pBegin97 - 4);
		if (fieldSize97 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderAvoidMind"} must be less than {4096}KB");
		}
		*(int*)pBegin97 = fieldSize97;
		byte* pBegin98 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderPenetrateOuter.Serialize(pCurrData);
		int fieldSize98 = (int)(pCurrData - pBegin98 - 4);
		if (fieldSize98 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderPenetrateOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin98 = fieldSize98;
		byte* pBegin99 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderPenetrateInner.Serialize(pCurrData);
		int fieldSize99 = (int)(pCurrData - pBegin99 - 4);
		if (fieldSize99 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderPenetrateInner"} must be less than {4096}KB");
		}
		*(int*)pBegin99 = fieldSize99;
		byte* pBegin100 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderPenetrateResistOuter.Serialize(pCurrData);
		int fieldSize100 = (int)(pCurrData - pBegin100 - 4);
		if (fieldSize100 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderPenetrateResistOuter"} must be less than {4096}KB");
		}
		*(int*)pBegin100 = fieldSize100;
		byte* pBegin101 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderPenetrateResistInner.Serialize(pCurrData);
		int fieldSize101 = (int)(pCurrData - pBegin101 - 4);
		if (fieldSize101 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderPenetrateResistInner"} must be less than {4096}KB");
		}
		*(int*)pBegin101 = fieldSize101;
		byte* pBegin102 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptDirectDamage.Serialize(pCurrData);
		int fieldSize102 = (int)(pCurrData - pBegin102 - 4);
		if (fieldSize102 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptDirectDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin102 = fieldSize102;
		byte* pBegin103 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptBounceDamage.Serialize(pCurrData);
		int fieldSize103 = (int)(pCurrData - pBegin103 - 4);
		if (fieldSize103 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptBounceDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin103 = fieldSize103;
		byte* pBegin104 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptFightBackDamage.Serialize(pCurrData);
		int fieldSize104 = (int)(pCurrData - pBegin104 - 4);
		if (fieldSize104 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptFightBackDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin104 = fieldSize104;
		byte* pBegin105 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptPoisonLevel.Serialize(pCurrData);
		int fieldSize105 = (int)(pCurrData - pBegin105 - 4);
		if (fieldSize105 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptPoisonLevel"} must be less than {4096}KB");
		}
		*(int*)pBegin105 = fieldSize105;
		byte* pBegin106 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptPoisonValue.Serialize(pCurrData);
		int fieldSize106 = (int)(pCurrData - pBegin106 - 4);
		if (fieldSize106 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptPoisonValue"} must be less than {4096}KB");
		}
		*(int*)pBegin106 = fieldSize106;
		byte* pBegin107 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderHitOdds.Serialize(pCurrData);
		int fieldSize107 = (int)(pCurrData - pBegin107 - 4);
		if (fieldSize107 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderHitOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin107 = fieldSize107;
		byte* pBegin108 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderFightBackHitOdds.Serialize(pCurrData);
		int fieldSize108 = (int)(pCurrData - pBegin108 - 4);
		if (fieldSize108 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderFightBackHitOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin108 = fieldSize108;
		byte* pBegin109 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderPursueOdds.Serialize(pCurrData);
		int fieldSize109 = (int)(pCurrData - pBegin109 - 4);
		if (fieldSize109 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderPursueOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin109 = fieldSize109;
		byte* pBegin110 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptMaxInjuryCount.Serialize(pCurrData);
		int fieldSize110 = (int)(pCurrData - pBegin110 - 4);
		if (fieldSize110 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptMaxInjuryCount"} must be less than {4096}KB");
		}
		*(int*)pBegin110 = fieldSize110;
		byte* pBegin111 = pCurrData;
		pCurrData += 4;
		pCurrData += _bouncePower.Serialize(pCurrData);
		int fieldSize111 = (int)(pCurrData - pBegin111 - 4);
		if (fieldSize111 > 4194304)
		{
			throw new Exception($"Size of field {"_bouncePower"} must be less than {4096}KB");
		}
		*(int*)pBegin111 = fieldSize111;
		byte* pBegin112 = pCurrData;
		pCurrData += 4;
		pCurrData += _fightBackPower.Serialize(pCurrData);
		int fieldSize112 = (int)(pCurrData - pBegin112 - 4);
		if (fieldSize112 > 4194304)
		{
			throw new Exception($"Size of field {"_fightBackPower"} must be less than {4096}KB");
		}
		*(int*)pBegin112 = fieldSize112;
		byte* pBegin113 = pCurrData;
		pCurrData += 4;
		pCurrData += _directDamageInnerRatio.Serialize(pCurrData);
		int fieldSize113 = (int)(pCurrData - pBegin113 - 4);
		if (fieldSize113 > 4194304)
		{
			throw new Exception($"Size of field {"_directDamageInnerRatio"} must be less than {4096}KB");
		}
		*(int*)pBegin113 = fieldSize113;
		byte* pBegin114 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderFinalDamageValue.Serialize(pCurrData);
		int fieldSize114 = (int)(pCurrData - pBegin114 - 4);
		if (fieldSize114 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderFinalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin114 = fieldSize114;
		byte* pBegin115 = pCurrData;
		pCurrData += 4;
		pCurrData += _directDamageValue.Serialize(pCurrData);
		int fieldSize115 = (int)(pCurrData - pBegin115 - 4);
		if (fieldSize115 > 4194304)
		{
			throw new Exception($"Size of field {"_directDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin115 = fieldSize115;
		byte* pBegin116 = pCurrData;
		pCurrData += 4;
		pCurrData += _directInjuryMark.Serialize(pCurrData);
		int fieldSize116 = (int)(pCurrData - pBegin116 - 4);
		if (fieldSize116 > 4194304)
		{
			throw new Exception($"Size of field {"_directInjuryMark"} must be less than {4096}KB");
		}
		*(int*)pBegin116 = fieldSize116;
		byte* pBegin117 = pCurrData;
		pCurrData += 4;
		pCurrData += _goneMadInjury.Serialize(pCurrData);
		int fieldSize117 = (int)(pCurrData - pBegin117 - 4);
		if (fieldSize117 > 4194304)
		{
			throw new Exception($"Size of field {"_goneMadInjury"} must be less than {4096}KB");
		}
		*(int*)pBegin117 = fieldSize117;
		byte* pBegin118 = pCurrData;
		pCurrData += 4;
		pCurrData += _healInjurySpeed.Serialize(pCurrData);
		int fieldSize118 = (int)(pCurrData - pBegin118 - 4);
		if (fieldSize118 > 4194304)
		{
			throw new Exception($"Size of field {"_healInjurySpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin118 = fieldSize118;
		byte* pBegin119 = pCurrData;
		pCurrData += 4;
		pCurrData += _healInjuryBuff.Serialize(pCurrData);
		int fieldSize119 = (int)(pCurrData - pBegin119 - 4);
		if (fieldSize119 > 4194304)
		{
			throw new Exception($"Size of field {"_healInjuryBuff"} must be less than {4096}KB");
		}
		*(int*)pBegin119 = fieldSize119;
		byte* pBegin120 = pCurrData;
		pCurrData += 4;
		pCurrData += _healInjuryDebuff.Serialize(pCurrData);
		int fieldSize120 = (int)(pCurrData - pBegin120 - 4);
		if (fieldSize120 > 4194304)
		{
			throw new Exception($"Size of field {"_healInjuryDebuff"} must be less than {4096}KB");
		}
		*(int*)pBegin120 = fieldSize120;
		byte* pBegin121 = pCurrData;
		pCurrData += 4;
		pCurrData += _healPoisonSpeed.Serialize(pCurrData);
		int fieldSize121 = (int)(pCurrData - pBegin121 - 4);
		if (fieldSize121 > 4194304)
		{
			throw new Exception($"Size of field {"_healPoisonSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin121 = fieldSize121;
		byte* pBegin122 = pCurrData;
		pCurrData += 4;
		pCurrData += _healPoisonBuff.Serialize(pCurrData);
		int fieldSize122 = (int)(pCurrData - pBegin122 - 4);
		if (fieldSize122 > 4194304)
		{
			throw new Exception($"Size of field {"_healPoisonBuff"} must be less than {4096}KB");
		}
		*(int*)pBegin122 = fieldSize122;
		byte* pBegin123 = pCurrData;
		pCurrData += 4;
		pCurrData += _healPoisonDebuff.Serialize(pCurrData);
		int fieldSize123 = (int)(pCurrData - pBegin123 - 4);
		if (fieldSize123 > 4194304)
		{
			throw new Exception($"Size of field {"_healPoisonDebuff"} must be less than {4096}KB");
		}
		*(int*)pBegin123 = fieldSize123;
		byte* pBegin124 = pCurrData;
		pCurrData += 4;
		pCurrData += _fleeSpeed.Serialize(pCurrData);
		int fieldSize124 = (int)(pCurrData - pBegin124 - 4);
		if (fieldSize124 > 4194304)
		{
			throw new Exception($"Size of field {"_fleeSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin124 = fieldSize124;
		byte* pBegin125 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxFlawCount.Serialize(pCurrData);
		int fieldSize125 = (int)(pCurrData - pBegin125 - 4);
		if (fieldSize125 > 4194304)
		{
			throw new Exception($"Size of field {"_maxFlawCount"} must be less than {4096}KB");
		}
		*(int*)pBegin125 = fieldSize125;
		byte* pBegin126 = pCurrData;
		pCurrData += 4;
		pCurrData += _canAddFlaw.Serialize(pCurrData);
		int fieldSize126 = (int)(pCurrData - pBegin126 - 4);
		if (fieldSize126 > 4194304)
		{
			throw new Exception($"Size of field {"_canAddFlaw"} must be less than {4096}KB");
		}
		*(int*)pBegin126 = fieldSize126;
		byte* pBegin127 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawLevel.Serialize(pCurrData);
		int fieldSize127 = (int)(pCurrData - pBegin127 - 4);
		if (fieldSize127 > 4194304)
		{
			throw new Exception($"Size of field {"_flawLevel"} must be less than {4096}KB");
		}
		*(int*)pBegin127 = fieldSize127;
		byte* pBegin128 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawLevelCanReduce.Serialize(pCurrData);
		int fieldSize128 = (int)(pCurrData - pBegin128 - 4);
		if (fieldSize128 > 4194304)
		{
			throw new Exception($"Size of field {"_flawLevelCanReduce"} must be less than {4096}KB");
		}
		*(int*)pBegin128 = fieldSize128;
		byte* pBegin129 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawCount.Serialize(pCurrData);
		int fieldSize129 = (int)(pCurrData - pBegin129 - 4);
		if (fieldSize129 > 4194304)
		{
			throw new Exception($"Size of field {"_flawCount"} must be less than {4096}KB");
		}
		*(int*)pBegin129 = fieldSize129;
		byte* pBegin130 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxAcupointCount.Serialize(pCurrData);
		int fieldSize130 = (int)(pCurrData - pBegin130 - 4);
		if (fieldSize130 > 4194304)
		{
			throw new Exception($"Size of field {"_maxAcupointCount"} must be less than {4096}KB");
		}
		*(int*)pBegin130 = fieldSize130;
		byte* pBegin131 = pCurrData;
		pCurrData += 4;
		pCurrData += _canAddAcupoint.Serialize(pCurrData);
		int fieldSize131 = (int)(pCurrData - pBegin131 - 4);
		if (fieldSize131 > 4194304)
		{
			throw new Exception($"Size of field {"_canAddAcupoint"} must be less than {4096}KB");
		}
		*(int*)pBegin131 = fieldSize131;
		byte* pBegin132 = pCurrData;
		pCurrData += 4;
		pCurrData += _acupointLevel.Serialize(pCurrData);
		int fieldSize132 = (int)(pCurrData - pBegin132 - 4);
		if (fieldSize132 > 4194304)
		{
			throw new Exception($"Size of field {"_acupointLevel"} must be less than {4096}KB");
		}
		*(int*)pBegin132 = fieldSize132;
		byte* pBegin133 = pCurrData;
		pCurrData += 4;
		pCurrData += _acupointLevelCanReduce.Serialize(pCurrData);
		int fieldSize133 = (int)(pCurrData - pBegin133 - 4);
		if (fieldSize133 > 4194304)
		{
			throw new Exception($"Size of field {"_acupointLevelCanReduce"} must be less than {4096}KB");
		}
		*(int*)pBegin133 = fieldSize133;
		byte* pBegin134 = pCurrData;
		pCurrData += 4;
		pCurrData += _acupointCount.Serialize(pCurrData);
		int fieldSize134 = (int)(pCurrData - pBegin134 - 4);
		if (fieldSize134 > 4194304)
		{
			throw new Exception($"Size of field {"_acupointCount"} must be less than {4096}KB");
		}
		*(int*)pBegin134 = fieldSize134;
		byte* pBegin135 = pCurrData;
		pCurrData += 4;
		pCurrData += _addNeiliAllocation.Serialize(pCurrData);
		int fieldSize135 = (int)(pCurrData - pBegin135 - 4);
		if (fieldSize135 > 4194304)
		{
			throw new Exception($"Size of field {"_addNeiliAllocation"} must be less than {4096}KB");
		}
		*(int*)pBegin135 = fieldSize135;
		byte* pBegin136 = pCurrData;
		pCurrData += 4;
		pCurrData += _costNeiliAllocation.Serialize(pCurrData);
		int fieldSize136 = (int)(pCurrData - pBegin136 - 4);
		if (fieldSize136 > 4194304)
		{
			throw new Exception($"Size of field {"_costNeiliAllocation"} must be less than {4096}KB");
		}
		*(int*)pBegin136 = fieldSize136;
		byte* pBegin137 = pCurrData;
		pCurrData += 4;
		pCurrData += _canChangeNeiliAllocation.Serialize(pCurrData);
		int fieldSize137 = (int)(pCurrData - pBegin137 - 4);
		if (fieldSize137 > 4194304)
		{
			throw new Exception($"Size of field {"_canChangeNeiliAllocation"} must be less than {4096}KB");
		}
		*(int*)pBegin137 = fieldSize137;
		byte* pBegin138 = pCurrData;
		pCurrData += 4;
		pCurrData += _canGetTrick.Serialize(pCurrData);
		int fieldSize138 = (int)(pCurrData - pBegin138 - 4);
		if (fieldSize138 > 4194304)
		{
			throw new Exception($"Size of field {"_canGetTrick"} must be less than {4096}KB");
		}
		*(int*)pBegin138 = fieldSize138;
		byte* pBegin139 = pCurrData;
		pCurrData += 4;
		pCurrData += _getTrickType.Serialize(pCurrData);
		int fieldSize139 = (int)(pCurrData - pBegin139 - 4);
		if (fieldSize139 > 4194304)
		{
			throw new Exception($"Size of field {"_getTrickType"} must be less than {4096}KB");
		}
		*(int*)pBegin139 = fieldSize139;
		byte* pBegin140 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackBodyPart.Serialize(pCurrData);
		int fieldSize140 = (int)(pCurrData - pBegin140 - 4);
		if (fieldSize140 > 4194304)
		{
			throw new Exception($"Size of field {"_attackBodyPart"} must be less than {4096}KB");
		}
		*(int*)pBegin140 = fieldSize140;
		byte* pBegin141 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponEquipAttack.Serialize(pCurrData);
		int fieldSize141 = (int)(pCurrData - pBegin141 - 4);
		if (fieldSize141 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponEquipAttack"} must be less than {4096}KB");
		}
		*(int*)pBegin141 = fieldSize141;
		byte* pBegin142 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponEquipDefense.Serialize(pCurrData);
		int fieldSize142 = (int)(pCurrData - pBegin142 - 4);
		if (fieldSize142 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponEquipDefense"} must be less than {4096}KB");
		}
		*(int*)pBegin142 = fieldSize142;
		byte* pBegin143 = pCurrData;
		pCurrData += 4;
		pCurrData += _armorEquipAttack.Serialize(pCurrData);
		int fieldSize143 = (int)(pCurrData - pBegin143 - 4);
		if (fieldSize143 > 4194304)
		{
			throw new Exception($"Size of field {"_armorEquipAttack"} must be less than {4096}KB");
		}
		*(int*)pBegin143 = fieldSize143;
		byte* pBegin144 = pCurrData;
		pCurrData += 4;
		pCurrData += _armorEquipDefense.Serialize(pCurrData);
		int fieldSize144 = (int)(pCurrData - pBegin144 - 4);
		if (fieldSize144 > 4194304)
		{
			throw new Exception($"Size of field {"_armorEquipDefense"} must be less than {4096}KB");
		}
		*(int*)pBegin144 = fieldSize144;
		byte* pBegin145 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackRangeForward.Serialize(pCurrData);
		int fieldSize145 = (int)(pCurrData - pBegin145 - 4);
		if (fieldSize145 > 4194304)
		{
			throw new Exception($"Size of field {"_attackRangeForward"} must be less than {4096}KB");
		}
		*(int*)pBegin145 = fieldSize145;
		byte* pBegin146 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackRangeBackward.Serialize(pCurrData);
		int fieldSize146 = (int)(pCurrData - pBegin146 - 4);
		if (fieldSize146 > 4194304)
		{
			throw new Exception($"Size of field {"_attackRangeBackward"} must be less than {4096}KB");
		}
		*(int*)pBegin146 = fieldSize146;
		byte* pBegin147 = pCurrData;
		pCurrData += 4;
		pCurrData += _moveCanBeStopped.Serialize(pCurrData);
		int fieldSize147 = (int)(pCurrData - pBegin147 - 4);
		if (fieldSize147 > 4194304)
		{
			throw new Exception($"Size of field {"_moveCanBeStopped"} must be less than {4096}KB");
		}
		*(int*)pBegin147 = fieldSize147;
		byte* pBegin148 = pCurrData;
		pCurrData += 4;
		pCurrData += _canForcedMove.Serialize(pCurrData);
		int fieldSize148 = (int)(pCurrData - pBegin148 - 4);
		if (fieldSize148 > 4194304)
		{
			throw new Exception($"Size of field {"_canForcedMove"} must be less than {4096}KB");
		}
		*(int*)pBegin148 = fieldSize148;
		byte* pBegin149 = pCurrData;
		pCurrData += 4;
		pCurrData += _mobilityCanBeRemoved.Serialize(pCurrData);
		int fieldSize149 = (int)(pCurrData - pBegin149 - 4);
		if (fieldSize149 > 4194304)
		{
			throw new Exception($"Size of field {"_mobilityCanBeRemoved"} must be less than {4096}KB");
		}
		*(int*)pBegin149 = fieldSize149;
		byte* pBegin150 = pCurrData;
		pCurrData += 4;
		pCurrData += _mobilityCostByEffect.Serialize(pCurrData);
		int fieldSize150 = (int)(pCurrData - pBegin150 - 4);
		if (fieldSize150 > 4194304)
		{
			throw new Exception($"Size of field {"_mobilityCostByEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin150 = fieldSize150;
		byte* pBegin151 = pCurrData;
		pCurrData += 4;
		pCurrData += _moveDistance.Serialize(pCurrData);
		int fieldSize151 = (int)(pCurrData - pBegin151 - 4);
		if (fieldSize151 > 4194304)
		{
			throw new Exception($"Size of field {"_moveDistance"} must be less than {4096}KB");
		}
		*(int*)pBegin151 = fieldSize151;
		byte* pBegin152 = pCurrData;
		pCurrData += 4;
		pCurrData += _jumpPrepareFrame.Serialize(pCurrData);
		int fieldSize152 = (int)(pCurrData - pBegin152 - 4);
		if (fieldSize152 > 4194304)
		{
			throw new Exception($"Size of field {"_jumpPrepareFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin152 = fieldSize152;
		byte* pBegin153 = pCurrData;
		pCurrData += 4;
		pCurrData += _bounceInjuryMark.Serialize(pCurrData);
		int fieldSize153 = (int)(pCurrData - pBegin153 - 4);
		if (fieldSize153 > 4194304)
		{
			throw new Exception($"Size of field {"_bounceInjuryMark"} must be less than {4096}KB");
		}
		*(int*)pBegin153 = fieldSize153;
		byte* pBegin154 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillHasCost.Serialize(pCurrData);
		int fieldSize154 = (int)(pCurrData - pBegin154 - 4);
		if (fieldSize154 > 4194304)
		{
			throw new Exception($"Size of field {"_skillHasCost"} must be less than {4096}KB");
		}
		*(int*)pBegin154 = fieldSize154;
		byte* pBegin155 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatStateEffect.Serialize(pCurrData);
		int fieldSize155 = (int)(pCurrData - pBegin155 - 4);
		if (fieldSize155 > 4194304)
		{
			throw new Exception($"Size of field {"_combatStateEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin155 = fieldSize155;
		byte* pBegin156 = pCurrData;
		pCurrData += 4;
		pCurrData += _changeNeedUseSkill.Serialize(pCurrData);
		int fieldSize156 = (int)(pCurrData - pBegin156 - 4);
		if (fieldSize156 > 4194304)
		{
			throw new Exception($"Size of field {"_changeNeedUseSkill"} must be less than {4096}KB");
		}
		*(int*)pBegin156 = fieldSize156;
		byte* pBegin157 = pCurrData;
		pCurrData += 4;
		pCurrData += _changeDistanceIsMove.Serialize(pCurrData);
		int fieldSize157 = (int)(pCurrData - pBegin157 - 4);
		if (fieldSize157 > 4194304)
		{
			throw new Exception($"Size of field {"_changeDistanceIsMove"} must be less than {4096}KB");
		}
		*(int*)pBegin157 = fieldSize157;
		byte* pBegin158 = pCurrData;
		pCurrData += 4;
		pCurrData += _replaceCharHit.Serialize(pCurrData);
		int fieldSize158 = (int)(pCurrData - pBegin158 - 4);
		if (fieldSize158 > 4194304)
		{
			throw new Exception($"Size of field {"_replaceCharHit"} must be less than {4096}KB");
		}
		*(int*)pBegin158 = fieldSize158;
		byte* pBegin159 = pCurrData;
		pCurrData += 4;
		pCurrData += _canAddPoison.Serialize(pCurrData);
		int fieldSize159 = (int)(pCurrData - pBegin159 - 4);
		if (fieldSize159 > 4194304)
		{
			throw new Exception($"Size of field {"_canAddPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin159 = fieldSize159;
		byte* pBegin160 = pCurrData;
		pCurrData += 4;
		pCurrData += _canReducePoison.Serialize(pCurrData);
		int fieldSize160 = (int)(pCurrData - pBegin160 - 4);
		if (fieldSize160 > 4194304)
		{
			throw new Exception($"Size of field {"_canReducePoison"} must be less than {4096}KB");
		}
		*(int*)pBegin160 = fieldSize160;
		byte* pBegin161 = pCurrData;
		pCurrData += 4;
		pCurrData += _reducePoisonValue.Serialize(pCurrData);
		int fieldSize161 = (int)(pCurrData - pBegin161 - 4);
		if (fieldSize161 > 4194304)
		{
			throw new Exception($"Size of field {"_reducePoisonValue"} must be less than {4096}KB");
		}
		*(int*)pBegin161 = fieldSize161;
		byte* pBegin162 = pCurrData;
		pCurrData += 4;
		pCurrData += _poisonCanAffect.Serialize(pCurrData);
		int fieldSize162 = (int)(pCurrData - pBegin162 - 4);
		if (fieldSize162 > 4194304)
		{
			throw new Exception($"Size of field {"_poisonCanAffect"} must be less than {4096}KB");
		}
		*(int*)pBegin162 = fieldSize162;
		byte* pBegin163 = pCurrData;
		pCurrData += 4;
		pCurrData += _poisonAffectCount.Serialize(pCurrData);
		int fieldSize163 = (int)(pCurrData - pBegin163 - 4);
		if (fieldSize163 > 4194304)
		{
			throw new Exception($"Size of field {"_poisonAffectCount"} must be less than {4096}KB");
		}
		*(int*)pBegin163 = fieldSize163;
		byte* pBegin164 = pCurrData;
		pCurrData += 4;
		pCurrData += _costTricks.Serialize(pCurrData);
		int fieldSize164 = (int)(pCurrData - pBegin164 - 4);
		if (fieldSize164 > 4194304)
		{
			throw new Exception($"Size of field {"_costTricks"} must be less than {4096}KB");
		}
		*(int*)pBegin164 = fieldSize164;
		byte* pBegin165 = pCurrData;
		pCurrData += 4;
		pCurrData += _jumpMoveDistance.Serialize(pCurrData);
		int fieldSize165 = (int)(pCurrData - pBegin165 - 4);
		if (fieldSize165 > 4194304)
		{
			throw new Exception($"Size of field {"_jumpMoveDistance"} must be less than {4096}KB");
		}
		*(int*)pBegin165 = fieldSize165;
		byte* pBegin166 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatStateToAdd.Serialize(pCurrData);
		int fieldSize166 = (int)(pCurrData - pBegin166 - 4);
		if (fieldSize166 > 4194304)
		{
			throw new Exception($"Size of field {"_combatStateToAdd"} must be less than {4096}KB");
		}
		*(int*)pBegin166 = fieldSize166;
		byte* pBegin167 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatStatePower.Serialize(pCurrData);
		int fieldSize167 = (int)(pCurrData - pBegin167 - 4);
		if (fieldSize167 > 4194304)
		{
			throw new Exception($"Size of field {"_combatStatePower"} must be less than {4096}KB");
		}
		*(int*)pBegin167 = fieldSize167;
		byte* pBegin168 = pCurrData;
		pCurrData += 4;
		pCurrData += _breakBodyPartInjuryCount.Serialize(pCurrData);
		int fieldSize168 = (int)(pCurrData - pBegin168 - 4);
		if (fieldSize168 > 4194304)
		{
			throw new Exception($"Size of field {"_breakBodyPartInjuryCount"} must be less than {4096}KB");
		}
		*(int*)pBegin168 = fieldSize168;
		byte* pBegin169 = pCurrData;
		pCurrData += 4;
		pCurrData += _bodyPartIsBroken.Serialize(pCurrData);
		int fieldSize169 = (int)(pCurrData - pBegin169 - 4);
		if (fieldSize169 > 4194304)
		{
			throw new Exception($"Size of field {"_bodyPartIsBroken"} must be less than {4096}KB");
		}
		*(int*)pBegin169 = fieldSize169;
		byte* pBegin170 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxTrickCount.Serialize(pCurrData);
		int fieldSize170 = (int)(pCurrData - pBegin170 - 4);
		if (fieldSize170 > 4194304)
		{
			throw new Exception($"Size of field {"_maxTrickCount"} must be less than {4096}KB");
		}
		*(int*)pBegin170 = fieldSize170;
		byte* pBegin171 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxBreathPercent.Serialize(pCurrData);
		int fieldSize171 = (int)(pCurrData - pBegin171 - 4);
		if (fieldSize171 > 4194304)
		{
			throw new Exception($"Size of field {"_maxBreathPercent"} must be less than {4096}KB");
		}
		*(int*)pBegin171 = fieldSize171;
		byte* pBegin172 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxStancePercent.Serialize(pCurrData);
		int fieldSize172 = (int)(pCurrData - pBegin172 - 4);
		if (fieldSize172 > 4194304)
		{
			throw new Exception($"Size of field {"_maxStancePercent"} must be less than {4096}KB");
		}
		*(int*)pBegin172 = fieldSize172;
		byte* pBegin173 = pCurrData;
		pCurrData += 4;
		pCurrData += _extraBreathPercent.Serialize(pCurrData);
		int fieldSize173 = (int)(pCurrData - pBegin173 - 4);
		if (fieldSize173 > 4194304)
		{
			throw new Exception($"Size of field {"_extraBreathPercent"} must be less than {4096}KB");
		}
		*(int*)pBegin173 = fieldSize173;
		byte* pBegin174 = pCurrData;
		pCurrData += 4;
		pCurrData += _extraStancePercent.Serialize(pCurrData);
		int fieldSize174 = (int)(pCurrData - pBegin174 - 4);
		if (fieldSize174 > 4194304)
		{
			throw new Exception($"Size of field {"_extraStancePercent"} must be less than {4096}KB");
		}
		*(int*)pBegin174 = fieldSize174;
		byte* pBegin175 = pCurrData;
		pCurrData += 4;
		pCurrData += _moveCostMobility.Serialize(pCurrData);
		int fieldSize175 = (int)(pCurrData - pBegin175 - 4);
		if (fieldSize175 > 4194304)
		{
			throw new Exception($"Size of field {"_moveCostMobility"} must be less than {4096}KB");
		}
		*(int*)pBegin175 = fieldSize175;
		byte* pBegin176 = pCurrData;
		pCurrData += 4;
		pCurrData += _defendSkillKeepTime.Serialize(pCurrData);
		int fieldSize176 = (int)(pCurrData - pBegin176 - 4);
		if (fieldSize176 > 4194304)
		{
			throw new Exception($"Size of field {"_defendSkillKeepTime"} must be less than {4096}KB");
		}
		*(int*)pBegin176 = fieldSize176;
		byte* pBegin177 = pCurrData;
		pCurrData += 4;
		pCurrData += _bounceRange.Serialize(pCurrData);
		int fieldSize177 = (int)(pCurrData - pBegin177 - 4);
		if (fieldSize177 > 4194304)
		{
			throw new Exception($"Size of field {"_bounceRange"} must be less than {4096}KB");
		}
		*(int*)pBegin177 = fieldSize177;
		byte* pBegin178 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindMarkKeepTime.Serialize(pCurrData);
		int fieldSize178 = (int)(pCurrData - pBegin178 - 4);
		if (fieldSize178 > 4194304)
		{
			throw new Exception($"Size of field {"_mindMarkKeepTime"} must be less than {4096}KB");
		}
		*(int*)pBegin178 = fieldSize178;
		byte* pBegin179 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillMobilityCostPerFrame.Serialize(pCurrData);
		int fieldSize179 = (int)(pCurrData - pBegin179 - 4);
		if (fieldSize179 > 4194304)
		{
			throw new Exception($"Size of field {"_skillMobilityCostPerFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin179 = fieldSize179;
		byte* pBegin180 = pCurrData;
		pCurrData += 4;
		pCurrData += _canAddWug.Serialize(pCurrData);
		int fieldSize180 = (int)(pCurrData - pBegin180 - 4);
		if (fieldSize180 > 4194304)
		{
			throw new Exception($"Size of field {"_canAddWug"} must be less than {4096}KB");
		}
		*(int*)pBegin180 = fieldSize180;
		byte* pBegin181 = pCurrData;
		pCurrData += 4;
		pCurrData += _hasGodWeaponBuff.Serialize(pCurrData);
		int fieldSize181 = (int)(pCurrData - pBegin181 - 4);
		if (fieldSize181 > 4194304)
		{
			throw new Exception($"Size of field {"_hasGodWeaponBuff"} must be less than {4096}KB");
		}
		*(int*)pBegin181 = fieldSize181;
		byte* pBegin182 = pCurrData;
		pCurrData += 4;
		pCurrData += _hasGodArmorBuff.Serialize(pCurrData);
		int fieldSize182 = (int)(pCurrData - pBegin182 - 4);
		if (fieldSize182 > 4194304)
		{
			throw new Exception($"Size of field {"_hasGodArmorBuff"} must be less than {4096}KB");
		}
		*(int*)pBegin182 = fieldSize182;
		byte* pBegin183 = pCurrData;
		pCurrData += 4;
		pCurrData += _teammateCmdRequireGenerateValue.Serialize(pCurrData);
		int fieldSize183 = (int)(pCurrData - pBegin183 - 4);
		if (fieldSize183 > 4194304)
		{
			throw new Exception($"Size of field {"_teammateCmdRequireGenerateValue"} must be less than {4096}KB");
		}
		*(int*)pBegin183 = fieldSize183;
		byte* pBegin184 = pCurrData;
		pCurrData += 4;
		pCurrData += _teammateCmdEffect.Serialize(pCurrData);
		int fieldSize184 = (int)(pCurrData - pBegin184 - 4);
		if (fieldSize184 > 4194304)
		{
			throw new Exception($"Size of field {"_teammateCmdEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin184 = fieldSize184;
		byte* pBegin185 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawRecoverSpeed.Serialize(pCurrData);
		int fieldSize185 = (int)(pCurrData - pBegin185 - 4);
		if (fieldSize185 > 4194304)
		{
			throw new Exception($"Size of field {"_flawRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin185 = fieldSize185;
		byte* pBegin186 = pCurrData;
		pCurrData += 4;
		pCurrData += _acupointRecoverSpeed.Serialize(pCurrData);
		int fieldSize186 = (int)(pCurrData - pBegin186 - 4);
		if (fieldSize186 > 4194304)
		{
			throw new Exception($"Size of field {"_acupointRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin186 = fieldSize186;
		byte* pBegin187 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindMarkRecoverSpeed.Serialize(pCurrData);
		int fieldSize187 = (int)(pCurrData - pBegin187 - 4);
		if (fieldSize187 > 4194304)
		{
			throw new Exception($"Size of field {"_mindMarkRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin187 = fieldSize187;
		byte* pBegin188 = pCurrData;
		pCurrData += 4;
		pCurrData += _injuryAutoHealSpeed.Serialize(pCurrData);
		int fieldSize188 = (int)(pCurrData - pBegin188 - 4);
		if (fieldSize188 > 4194304)
		{
			throw new Exception($"Size of field {"_injuryAutoHealSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin188 = fieldSize188;
		byte* pBegin189 = pCurrData;
		pCurrData += 4;
		pCurrData += _canRecoverBreath.Serialize(pCurrData);
		int fieldSize189 = (int)(pCurrData - pBegin189 - 4);
		if (fieldSize189 > 4194304)
		{
			throw new Exception($"Size of field {"_canRecoverBreath"} must be less than {4096}KB");
		}
		*(int*)pBegin189 = fieldSize189;
		byte* pBegin190 = pCurrData;
		pCurrData += 4;
		pCurrData += _canRecoverStance.Serialize(pCurrData);
		int fieldSize190 = (int)(pCurrData - pBegin190 - 4);
		if (fieldSize190 > 4194304)
		{
			throw new Exception($"Size of field {"_canRecoverStance"} must be less than {4096}KB");
		}
		*(int*)pBegin190 = fieldSize190;
		byte* pBegin191 = pCurrData;
		pCurrData += 4;
		pCurrData += _fatalDamageValue.Serialize(pCurrData);
		int fieldSize191 = (int)(pCurrData - pBegin191 - 4);
		if (fieldSize191 > 4194304)
		{
			throw new Exception($"Size of field {"_fatalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin191 = fieldSize191;
		byte* pBegin192 = pCurrData;
		pCurrData += 4;
		pCurrData += _fatalDamageMarkCount.Serialize(pCurrData);
		int fieldSize192 = (int)(pCurrData - pBegin192 - 4);
		if (fieldSize192 > 4194304)
		{
			throw new Exception($"Size of field {"_fatalDamageMarkCount"} must be less than {4096}KB");
		}
		*(int*)pBegin192 = fieldSize192;
		byte* pBegin193 = pCurrData;
		pCurrData += 4;
		pCurrData += _canFightBackDuringPrepareSkill.Serialize(pCurrData);
		int fieldSize193 = (int)(pCurrData - pBegin193 - 4);
		if (fieldSize193 > 4194304)
		{
			throw new Exception($"Size of field {"_canFightBackDuringPrepareSkill"} must be less than {4096}KB");
		}
		*(int*)pBegin193 = fieldSize193;
		byte* pBegin194 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillPrepareSpeed.Serialize(pCurrData);
		int fieldSize194 = (int)(pCurrData - pBegin194 - 4);
		if (fieldSize194 > 4194304)
		{
			throw new Exception($"Size of field {"_skillPrepareSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin194 = fieldSize194;
		byte* pBegin195 = pCurrData;
		pCurrData += 4;
		pCurrData += _breathRecoverSpeed.Serialize(pCurrData);
		int fieldSize195 = (int)(pCurrData - pBegin195 - 4);
		if (fieldSize195 > 4194304)
		{
			throw new Exception($"Size of field {"_breathRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin195 = fieldSize195;
		byte* pBegin196 = pCurrData;
		pCurrData += 4;
		pCurrData += _stanceRecoverSpeed.Serialize(pCurrData);
		int fieldSize196 = (int)(pCurrData - pBegin196 - 4);
		if (fieldSize196 > 4194304)
		{
			throw new Exception($"Size of field {"_stanceRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin196 = fieldSize196;
		byte* pBegin197 = pCurrData;
		pCurrData += 4;
		pCurrData += _mobilityRecoverSpeed.Serialize(pCurrData);
		int fieldSize197 = (int)(pCurrData - pBegin197 - 4);
		if (fieldSize197 > 4194304)
		{
			throw new Exception($"Size of field {"_mobilityRecoverSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin197 = fieldSize197;
		byte* pBegin198 = pCurrData;
		pCurrData += 4;
		pCurrData += _changeTrickProgressAddValue.Serialize(pCurrData);
		int fieldSize198 = (int)(pCurrData - pBegin198 - 4);
		if (fieldSize198 > 4194304)
		{
			throw new Exception($"Size of field {"_changeTrickProgressAddValue"} must be less than {4096}KB");
		}
		*(int*)pBegin198 = fieldSize198;
		byte* pBegin199 = pCurrData;
		pCurrData += 4;
		pCurrData += _power.Serialize(pCurrData);
		int fieldSize199 = (int)(pCurrData - pBegin199 - 4);
		if (fieldSize199 > 4194304)
		{
			throw new Exception($"Size of field {"_power"} must be less than {4096}KB");
		}
		*(int*)pBegin199 = fieldSize199;
		byte* pBegin200 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxPower.Serialize(pCurrData);
		int fieldSize200 = (int)(pCurrData - pBegin200 - 4);
		if (fieldSize200 > 4194304)
		{
			throw new Exception($"Size of field {"_maxPower"} must be less than {4096}KB");
		}
		*(int*)pBegin200 = fieldSize200;
		byte* pBegin201 = pCurrData;
		pCurrData += 4;
		pCurrData += _powerCanReduce.Serialize(pCurrData);
		int fieldSize201 = (int)(pCurrData - pBegin201 - 4);
		if (fieldSize201 > 4194304)
		{
			throw new Exception($"Size of field {"_powerCanReduce"} must be less than {4096}KB");
		}
		*(int*)pBegin201 = fieldSize201;
		byte* pBegin202 = pCurrData;
		pCurrData += 4;
		pCurrData += _useRequirement.Serialize(pCurrData);
		int fieldSize202 = (int)(pCurrData - pBegin202 - 4);
		if (fieldSize202 > 4194304)
		{
			throw new Exception($"Size of field {"_useRequirement"} must be less than {4096}KB");
		}
		*(int*)pBegin202 = fieldSize202;
		byte* pBegin203 = pCurrData;
		pCurrData += 4;
		pCurrData += _currInnerRatio.Serialize(pCurrData);
		int fieldSize203 = (int)(pCurrData - pBegin203 - 4);
		if (fieldSize203 > 4194304)
		{
			throw new Exception($"Size of field {"_currInnerRatio"} must be less than {4096}KB");
		}
		*(int*)pBegin203 = fieldSize203;
		byte* pBegin204 = pCurrData;
		pCurrData += 4;
		pCurrData += _costBreathAndStance.Serialize(pCurrData);
		int fieldSize204 = (int)(pCurrData - pBegin204 - 4);
		if (fieldSize204 > 4194304)
		{
			throw new Exception($"Size of field {"_costBreathAndStance"} must be less than {4096}KB");
		}
		*(int*)pBegin204 = fieldSize204;
		byte* pBegin205 = pCurrData;
		pCurrData += 4;
		pCurrData += _costBreath.Serialize(pCurrData);
		int fieldSize205 = (int)(pCurrData - pBegin205 - 4);
		if (fieldSize205 > 4194304)
		{
			throw new Exception($"Size of field {"_costBreath"} must be less than {4096}KB");
		}
		*(int*)pBegin205 = fieldSize205;
		byte* pBegin206 = pCurrData;
		pCurrData += 4;
		pCurrData += _costStance.Serialize(pCurrData);
		int fieldSize206 = (int)(pCurrData - pBegin206 - 4);
		if (fieldSize206 > 4194304)
		{
			throw new Exception($"Size of field {"_costStance"} must be less than {4096}KB");
		}
		*(int*)pBegin206 = fieldSize206;
		byte* pBegin207 = pCurrData;
		pCurrData += 4;
		pCurrData += _costMobility.Serialize(pCurrData);
		int fieldSize207 = (int)(pCurrData - pBegin207 - 4);
		if (fieldSize207 > 4194304)
		{
			throw new Exception($"Size of field {"_costMobility"} must be less than {4096}KB");
		}
		*(int*)pBegin207 = fieldSize207;
		byte* pBegin208 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillCostTricks.Serialize(pCurrData);
		int fieldSize208 = (int)(pCurrData - pBegin208 - 4);
		if (fieldSize208 > 4194304)
		{
			throw new Exception($"Size of field {"_skillCostTricks"} must be less than {4096}KB");
		}
		*(int*)pBegin208 = fieldSize208;
		byte* pBegin209 = pCurrData;
		pCurrData += 4;
		pCurrData += _effectDirection.Serialize(pCurrData);
		int fieldSize209 = (int)(pCurrData - pBegin209 - 4);
		if (fieldSize209 > 4194304)
		{
			throw new Exception($"Size of field {"_effectDirection"} must be less than {4096}KB");
		}
		*(int*)pBegin209 = fieldSize209;
		byte* pBegin210 = pCurrData;
		pCurrData += 4;
		pCurrData += _effectDirectionCanChange.Serialize(pCurrData);
		int fieldSize210 = (int)(pCurrData - pBegin210 - 4);
		if (fieldSize210 > 4194304)
		{
			throw new Exception($"Size of field {"_effectDirectionCanChange"} must be less than {4096}KB");
		}
		*(int*)pBegin210 = fieldSize210;
		byte* pBegin211 = pCurrData;
		pCurrData += 4;
		pCurrData += _gridCost.Serialize(pCurrData);
		int fieldSize211 = (int)(pCurrData - pBegin211 - 4);
		if (fieldSize211 > 4194304)
		{
			throw new Exception($"Size of field {"_gridCost"} must be less than {4096}KB");
		}
		*(int*)pBegin211 = fieldSize211;
		byte* pBegin212 = pCurrData;
		pCurrData += 4;
		pCurrData += _prepareTotalProgress.Serialize(pCurrData);
		int fieldSize212 = (int)(pCurrData - pBegin212 - 4);
		if (fieldSize212 > 4194304)
		{
			throw new Exception($"Size of field {"_prepareTotalProgress"} must be less than {4096}KB");
		}
		*(int*)pBegin212 = fieldSize212;
		byte* pBegin213 = pCurrData;
		pCurrData += 4;
		pCurrData += _specificGridCount.Serialize(pCurrData);
		int fieldSize213 = (int)(pCurrData - pBegin213 - 4);
		if (fieldSize213 > 4194304)
		{
			throw new Exception($"Size of field {"_specificGridCount"} must be less than {4096}KB");
		}
		*(int*)pBegin213 = fieldSize213;
		byte* pBegin214 = pCurrData;
		pCurrData += 4;
		pCurrData += _genericGridCount.Serialize(pCurrData);
		int fieldSize214 = (int)(pCurrData - pBegin214 - 4);
		if (fieldSize214 > 4194304)
		{
			throw new Exception($"Size of field {"_genericGridCount"} must be less than {4096}KB");
		}
		*(int*)pBegin214 = fieldSize214;
		byte* pBegin215 = pCurrData;
		pCurrData += 4;
		pCurrData += _canInterrupt.Serialize(pCurrData);
		int fieldSize215 = (int)(pCurrData - pBegin215 - 4);
		if (fieldSize215 > 4194304)
		{
			throw new Exception($"Size of field {"_canInterrupt"} must be less than {4096}KB");
		}
		*(int*)pBegin215 = fieldSize215;
		byte* pBegin216 = pCurrData;
		pCurrData += 4;
		pCurrData += _interruptOdds.Serialize(pCurrData);
		int fieldSize216 = (int)(pCurrData - pBegin216 - 4);
		if (fieldSize216 > 4194304)
		{
			throw new Exception($"Size of field {"_interruptOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin216 = fieldSize216;
		byte* pBegin217 = pCurrData;
		pCurrData += 4;
		pCurrData += _canSilence.Serialize(pCurrData);
		int fieldSize217 = (int)(pCurrData - pBegin217 - 4);
		if (fieldSize217 > 4194304)
		{
			throw new Exception($"Size of field {"_canSilence"} must be less than {4096}KB");
		}
		*(int*)pBegin217 = fieldSize217;
		byte* pBegin218 = pCurrData;
		pCurrData += 4;
		pCurrData += _silenceOdds.Serialize(pCurrData);
		int fieldSize218 = (int)(pCurrData - pBegin218 - 4);
		if (fieldSize218 > 4194304)
		{
			throw new Exception($"Size of field {"_silenceOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin218 = fieldSize218;
		byte* pBegin219 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCastWithBrokenBodyPart.Serialize(pCurrData);
		int fieldSize219 = (int)(pCurrData - pBegin219 - 4);
		if (fieldSize219 > 4194304)
		{
			throw new Exception($"Size of field {"_canCastWithBrokenBodyPart"} must be less than {4096}KB");
		}
		*(int*)pBegin219 = fieldSize219;
		byte* pBegin220 = pCurrData;
		pCurrData += 4;
		pCurrData += _addPowerCanBeRemoved.Serialize(pCurrData);
		int fieldSize220 = (int)(pCurrData - pBegin220 - 4);
		if (fieldSize220 > 4194304)
		{
			throw new Exception($"Size of field {"_addPowerCanBeRemoved"} must be less than {4096}KB");
		}
		*(int*)pBegin220 = fieldSize220;
		byte* pBegin221 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillType.Serialize(pCurrData);
		int fieldSize221 = (int)(pCurrData - pBegin221 - 4);
		if (fieldSize221 > 4194304)
		{
			throw new Exception($"Size of field {"_skillType"} must be less than {4096}KB");
		}
		*(int*)pBegin221 = fieldSize221;
		byte* pBegin222 = pCurrData;
		pCurrData += 4;
		pCurrData += _effectCountCanChange.Serialize(pCurrData);
		int fieldSize222 = (int)(pCurrData - pBegin222 - 4);
		if (fieldSize222 > 4194304)
		{
			throw new Exception($"Size of field {"_effectCountCanChange"} must be less than {4096}KB");
		}
		*(int*)pBegin222 = fieldSize222;
		byte* pBegin223 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCastInDefend.Serialize(pCurrData);
		int fieldSize223 = (int)(pCurrData - pBegin223 - 4);
		if (fieldSize223 > 4194304)
		{
			throw new Exception($"Size of field {"_canCastInDefend"} must be less than {4096}KB");
		}
		*(int*)pBegin223 = fieldSize223;
		byte* pBegin224 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitDistribution.Serialize(pCurrData);
		int fieldSize224 = (int)(pCurrData - pBegin224 - 4);
		if (fieldSize224 > 4194304)
		{
			throw new Exception($"Size of field {"_hitDistribution"} must be less than {4096}KB");
		}
		*(int*)pBegin224 = fieldSize224;
		byte* pBegin225 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCastOnLackBreath.Serialize(pCurrData);
		int fieldSize225 = (int)(pCurrData - pBegin225 - 4);
		if (fieldSize225 > 4194304)
		{
			throw new Exception($"Size of field {"_canCastOnLackBreath"} must be less than {4096}KB");
		}
		*(int*)pBegin225 = fieldSize225;
		byte* pBegin226 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCastOnLackStance.Serialize(pCurrData);
		int fieldSize226 = (int)(pCurrData - pBegin226 - 4);
		if (fieldSize226 > 4194304)
		{
			throw new Exception($"Size of field {"_canCastOnLackStance"} must be less than {4096}KB");
		}
		*(int*)pBegin226 = fieldSize226;
		byte* pBegin227 = pCurrData;
		pCurrData += 4;
		pCurrData += _costBreathOnCast.Serialize(pCurrData);
		int fieldSize227 = (int)(pCurrData - pBegin227 - 4);
		if (fieldSize227 > 4194304)
		{
			throw new Exception($"Size of field {"_costBreathOnCast"} must be less than {4096}KB");
		}
		*(int*)pBegin227 = fieldSize227;
		byte* pBegin228 = pCurrData;
		pCurrData += 4;
		pCurrData += _costStanceOnCast.Serialize(pCurrData);
		int fieldSize228 = (int)(pCurrData - pBegin228 - 4);
		if (fieldSize228 > 4194304)
		{
			throw new Exception($"Size of field {"_costStanceOnCast"} must be less than {4096}KB");
		}
		*(int*)pBegin228 = fieldSize228;
		byte* pBegin229 = pCurrData;
		pCurrData += 4;
		pCurrData += _canUseMobilityAsBreath.Serialize(pCurrData);
		int fieldSize229 = (int)(pCurrData - pBegin229 - 4);
		if (fieldSize229 > 4194304)
		{
			throw new Exception($"Size of field {"_canUseMobilityAsBreath"} must be less than {4096}KB");
		}
		*(int*)pBegin229 = fieldSize229;
		byte* pBegin230 = pCurrData;
		pCurrData += 4;
		pCurrData += _canUseMobilityAsStance.Serialize(pCurrData);
		int fieldSize230 = (int)(pCurrData - pBegin230 - 4);
		if (fieldSize230 > 4194304)
		{
			throw new Exception($"Size of field {"_canUseMobilityAsStance"} must be less than {4096}KB");
		}
		*(int*)pBegin230 = fieldSize230;
		byte* pBegin231 = pCurrData;
		pCurrData += 4;
		pCurrData += _castCostNeiliAllocation.Serialize(pCurrData);
		int fieldSize231 = (int)(pCurrData - pBegin231 - 4);
		if (fieldSize231 > 4194304)
		{
			throw new Exception($"Size of field {"_castCostNeiliAllocation"} must be less than {4096}KB");
		}
		*(int*)pBegin231 = fieldSize231;
		byte* pBegin232 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptPoisonResist.Serialize(pCurrData);
		int fieldSize232 = (int)(pCurrData - pBegin232 - 4);
		if (fieldSize232 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptPoisonResist"} must be less than {4096}KB");
		}
		*(int*)pBegin232 = fieldSize232;
		byte* pBegin233 = pCurrData;
		pCurrData += 4;
		pCurrData += _makePoisonResist.Serialize(pCurrData);
		int fieldSize233 = (int)(pCurrData - pBegin233 - 4);
		if (fieldSize233 > 4194304)
		{
			throw new Exception($"Size of field {"_makePoisonResist"} must be less than {4096}KB");
		}
		*(int*)pBegin233 = fieldSize233;
		byte* pBegin234 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCriticalHit.Serialize(pCurrData);
		int fieldSize234 = (int)(pCurrData - pBegin234 - 4);
		if (fieldSize234 > 4194304)
		{
			throw new Exception($"Size of field {"_canCriticalHit"} must be less than {4096}KB");
		}
		*(int*)pBegin234 = fieldSize234;
		byte* pBegin235 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCostNeiliAllocationEffect.Serialize(pCurrData);
		int fieldSize235 = (int)(pCurrData - pBegin235 - 4);
		if (fieldSize235 > 4194304)
		{
			throw new Exception($"Size of field {"_canCostNeiliAllocationEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin235 = fieldSize235;
		byte* pBegin236 = pCurrData;
		pCurrData += 4;
		pCurrData += _consummateLevelRelatedMainAttributesHitValues.Serialize(pCurrData);
		int fieldSize236 = (int)(pCurrData - pBegin236 - 4);
		if (fieldSize236 > 4194304)
		{
			throw new Exception($"Size of field {"_consummateLevelRelatedMainAttributesHitValues"} must be less than {4096}KB");
		}
		*(int*)pBegin236 = fieldSize236;
		byte* pBegin237 = pCurrData;
		pCurrData += 4;
		pCurrData += _consummateLevelRelatedMainAttributesAvoidValues.Serialize(pCurrData);
		int fieldSize237 = (int)(pCurrData - pBegin237 - 4);
		if (fieldSize237 > 4194304)
		{
			throw new Exception($"Size of field {"_consummateLevelRelatedMainAttributesAvoidValues"} must be less than {4096}KB");
		}
		*(int*)pBegin237 = fieldSize237;
		byte* pBegin238 = pCurrData;
		pCurrData += 4;
		pCurrData += _consummateLevelRelatedMainAttributesPenetrations.Serialize(pCurrData);
		int fieldSize238 = (int)(pCurrData - pBegin238 - 4);
		if (fieldSize238 > 4194304)
		{
			throw new Exception($"Size of field {"_consummateLevelRelatedMainAttributesPenetrations"} must be less than {4096}KB");
		}
		*(int*)pBegin238 = fieldSize238;
		byte* pBegin239 = pCurrData;
		pCurrData += 4;
		pCurrData += _consummateLevelRelatedMainAttributesPenetrationResists.Serialize(pCurrData);
		int fieldSize239 = (int)(pCurrData - pBegin239 - 4);
		if (fieldSize239 > 4194304)
		{
			throw new Exception($"Size of field {"_consummateLevelRelatedMainAttributesPenetrationResists"} must be less than {4096}KB");
		}
		*(int*)pBegin239 = fieldSize239;
		byte* pBegin240 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillAlsoAsFiveElements.Serialize(pCurrData);
		int fieldSize240 = (int)(pCurrData - pBegin240 - 4);
		if (fieldSize240 > 4194304)
		{
			throw new Exception($"Size of field {"_skillAlsoAsFiveElements"} must be less than {4096}KB");
		}
		*(int*)pBegin240 = fieldSize240;
		byte* pBegin241 = pCurrData;
		pCurrData += 4;
		pCurrData += _innerInjuryImmunity.Serialize(pCurrData);
		int fieldSize241 = (int)(pCurrData - pBegin241 - 4);
		if (fieldSize241 > 4194304)
		{
			throw new Exception($"Size of field {"_innerInjuryImmunity"} must be less than {4096}KB");
		}
		*(int*)pBegin241 = fieldSize241;
		byte* pBegin242 = pCurrData;
		pCurrData += 4;
		pCurrData += _outerInjuryImmunity.Serialize(pCurrData);
		int fieldSize242 = (int)(pCurrData - pBegin242 - 4);
		if (fieldSize242 > 4194304)
		{
			throw new Exception($"Size of field {"_outerInjuryImmunity"} must be less than {4096}KB");
		}
		*(int*)pBegin242 = fieldSize242;
		byte* pBegin243 = pCurrData;
		pCurrData += 4;
		pCurrData += _poisonAffectThreshold.Serialize(pCurrData);
		int fieldSize243 = (int)(pCurrData - pBegin243 - 4);
		if (fieldSize243 > 4194304)
		{
			throw new Exception($"Size of field {"_poisonAffectThreshold"} must be less than {4096}KB");
		}
		*(int*)pBegin243 = fieldSize243;
		byte* pBegin244 = pCurrData;
		pCurrData += 4;
		pCurrData += _lockDistance.Serialize(pCurrData);
		int fieldSize244 = (int)(pCurrData - pBegin244 - 4);
		if (fieldSize244 > 4194304)
		{
			throw new Exception($"Size of field {"_lockDistance"} must be less than {4096}KB");
		}
		*(int*)pBegin244 = fieldSize244;
		byte* pBegin245 = pCurrData;
		pCurrData += 4;
		pCurrData += _resistOfAllPoison.Serialize(pCurrData);
		int fieldSize245 = (int)(pCurrData - pBegin245 - 4);
		if (fieldSize245 > 4194304)
		{
			throw new Exception($"Size of field {"_resistOfAllPoison"} must be less than {4096}KB");
		}
		*(int*)pBegin245 = fieldSize245;
		byte* pBegin246 = pCurrData;
		pCurrData += 4;
		pCurrData += _makePoisonTarget.Serialize(pCurrData);
		int fieldSize246 = (int)(pCurrData - pBegin246 - 4);
		if (fieldSize246 > 4194304)
		{
			throw new Exception($"Size of field {"_makePoisonTarget"} must be less than {4096}KB");
		}
		*(int*)pBegin246 = fieldSize246;
		byte* pBegin247 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptPoisonTarget.Serialize(pCurrData);
		int fieldSize247 = (int)(pCurrData - pBegin247 - 4);
		if (fieldSize247 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptPoisonTarget"} must be less than {4096}KB");
		}
		*(int*)pBegin247 = fieldSize247;
		byte* pBegin248 = pCurrData;
		pCurrData += 4;
		pCurrData += _certainCriticalHit.Serialize(pCurrData);
		int fieldSize248 = (int)(pCurrData - pBegin248 - 4);
		if (fieldSize248 > 4194304)
		{
			throw new Exception($"Size of field {"_certainCriticalHit"} must be less than {4096}KB");
		}
		*(int*)pBegin248 = fieldSize248;
		byte* pBegin249 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindMarkCount.Serialize(pCurrData);
		int fieldSize249 = (int)(pCurrData - pBegin249 - 4);
		if (fieldSize249 > 4194304)
		{
			throw new Exception($"Size of field {"_mindMarkCount"} must be less than {4096}KB");
		}
		*(int*)pBegin249 = fieldSize249;
		byte* pBegin250 = pCurrData;
		pCurrData += 4;
		pCurrData += _canFightBackWithHit.Serialize(pCurrData);
		int fieldSize250 = (int)(pCurrData - pBegin250 - 4);
		if (fieldSize250 > 4194304)
		{
			throw new Exception($"Size of field {"_canFightBackWithHit"} must be less than {4096}KB");
		}
		*(int*)pBegin250 = fieldSize250;
		byte* pBegin251 = pCurrData;
		pCurrData += 4;
		pCurrData += _inevitableHit.Serialize(pCurrData);
		int fieldSize251 = (int)(pCurrData - pBegin251 - 4);
		if (fieldSize251 > 4194304)
		{
			throw new Exception($"Size of field {"_inevitableHit"} must be less than {4096}KB");
		}
		*(int*)pBegin251 = fieldSize251;
		byte* pBegin252 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackCanPursue.Serialize(pCurrData);
		int fieldSize252 = (int)(pCurrData - pBegin252 - 4);
		if (fieldSize252 > 4194304)
		{
			throw new Exception($"Size of field {"_attackCanPursue"} must be less than {4096}KB");
		}
		*(int*)pBegin252 = fieldSize252;
		byte* pBegin253 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatSkillDataEffectList.Serialize(pCurrData);
		int fieldSize253 = (int)(pCurrData - pBegin253 - 4);
		if (fieldSize253 > 4194304)
		{
			throw new Exception($"Size of field {"_combatSkillDataEffectList"} must be less than {4096}KB");
		}
		*(int*)pBegin253 = fieldSize253;
		byte* pBegin254 = pCurrData;
		pCurrData += 4;
		pCurrData += _stanceCostByEffect.Serialize(pCurrData);
		int fieldSize254 = (int)(pCurrData - pBegin254 - 4);
		if (fieldSize254 > 4194304)
		{
			throw new Exception($"Size of field {"_stanceCostByEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin254 = fieldSize254;
		byte* pBegin255 = pCurrData;
		pCurrData += 4;
		pCurrData += _breathCostByEffect.Serialize(pCurrData);
		int fieldSize255 = (int)(pCurrData - pBegin255 - 4);
		if (fieldSize255 > 4194304)
		{
			throw new Exception($"Size of field {"_breathCostByEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin255 = fieldSize255;
		byte* pBegin256 = pCurrData;
		pCurrData += 4;
		pCurrData += _powerAddRatio.Serialize(pCurrData);
		int fieldSize256 = (int)(pCurrData - pBegin256 - 4);
		if (fieldSize256 > 4194304)
		{
			throw new Exception($"Size of field {"_powerAddRatio"} must be less than {4096}KB");
		}
		*(int*)pBegin256 = fieldSize256;
		byte* pBegin257 = pCurrData;
		pCurrData += 4;
		pCurrData += _powerReduceRatio.Serialize(pCurrData);
		int fieldSize257 = (int)(pCurrData - pBegin257 - 4);
		if (fieldSize257 > 4194304)
		{
			throw new Exception($"Size of field {"_powerReduceRatio"} must be less than {4096}KB");
		}
		*(int*)pBegin257 = fieldSize257;
		byte* pBegin258 = pCurrData;
		pCurrData += 4;
		pCurrData += _poisonAffectProduceValue.Serialize(pCurrData);
		int fieldSize258 = (int)(pCurrData - pBegin258 - 4);
		if (fieldSize258 > 4194304)
		{
			throw new Exception($"Size of field {"_poisonAffectProduceValue"} must be less than {4096}KB");
		}
		*(int*)pBegin258 = fieldSize258;
		byte* pBegin259 = pCurrData;
		pCurrData += 4;
		pCurrData += _canReadingOnMonthChange.Serialize(pCurrData);
		int fieldSize259 = (int)(pCurrData - pBegin259 - 4);
		if (fieldSize259 > 4194304)
		{
			throw new Exception($"Size of field {"_canReadingOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin259 = fieldSize259;
		byte* pBegin260 = pCurrData;
		pCurrData += 4;
		pCurrData += _medicineEffect.Serialize(pCurrData);
		int fieldSize260 = (int)(pCurrData - pBegin260 - 4);
		if (fieldSize260 > 4194304)
		{
			throw new Exception($"Size of field {"_medicineEffect"} must be less than {4096}KB");
		}
		*(int*)pBegin260 = fieldSize260;
		byte* pBegin261 = pCurrData;
		pCurrData += 4;
		pCurrData += _xiangshuInfectionDelta.Serialize(pCurrData);
		int fieldSize261 = (int)(pCurrData - pBegin261 - 4);
		if (fieldSize261 > 4194304)
		{
			throw new Exception($"Size of field {"_xiangshuInfectionDelta"} must be less than {4096}KB");
		}
		*(int*)pBegin261 = fieldSize261;
		byte* pBegin262 = pCurrData;
		pCurrData += 4;
		pCurrData += _healthDelta.Serialize(pCurrData);
		int fieldSize262 = (int)(pCurrData - pBegin262 - 4);
		if (fieldSize262 > 4194304)
		{
			throw new Exception($"Size of field {"_healthDelta"} must be less than {4096}KB");
		}
		*(int*)pBegin262 = fieldSize262;
		byte* pBegin263 = pCurrData;
		pCurrData += 4;
		pCurrData += _weaponSilenceFrame.Serialize(pCurrData);
		int fieldSize263 = (int)(pCurrData - pBegin263 - 4);
		if (fieldSize263 > 4194304)
		{
			throw new Exception($"Size of field {"_weaponSilenceFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin263 = fieldSize263;
		byte* pBegin264 = pCurrData;
		pCurrData += 4;
		pCurrData += _silenceFrame.Serialize(pCurrData);
		int fieldSize264 = (int)(pCurrData - pBegin264 - 4);
		if (fieldSize264 > 4194304)
		{
			throw new Exception($"Size of field {"_silenceFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin264 = fieldSize264;
		byte* pBegin265 = pCurrData;
		pCurrData += 4;
		pCurrData += _currAgeDelta.Serialize(pCurrData);
		int fieldSize265 = (int)(pCurrData - pBegin265 - 4);
		if (fieldSize265 > 4194304)
		{
			throw new Exception($"Size of field {"_currAgeDelta"} must be less than {4096}KB");
		}
		*(int*)pBegin265 = fieldSize265;
		byte* pBegin266 = pCurrData;
		pCurrData += 4;
		pCurrData += _goneMadInAllBreak.Serialize(pCurrData);
		int fieldSize266 = (int)(pCurrData - pBegin266 - 4);
		if (fieldSize266 > 4194304)
		{
			throw new Exception($"Size of field {"_goneMadInAllBreak"} must be less than {4096}KB");
		}
		*(int*)pBegin266 = fieldSize266;
		byte* pBegin267 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeLoveRateOnMonthChange.Serialize(pCurrData);
		int fieldSize267 = (int)(pCurrData - pBegin267 - 4);
		if (fieldSize267 > 4194304)
		{
			throw new Exception($"Size of field {"_makeLoveRateOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin267 = fieldSize267;
		byte* pBegin268 = pCurrData;
		pCurrData += 4;
		pCurrData += _canAutoHealOnMonthChange.Serialize(pCurrData);
		int fieldSize268 = (int)(pCurrData - pBegin268 - 4);
		if (fieldSize268 > 4194304)
		{
			throw new Exception($"Size of field {"_canAutoHealOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin268 = fieldSize268;
		byte* pBegin269 = pCurrData;
		pCurrData += 4;
		pCurrData += _happinessDelta.Serialize(pCurrData);
		int fieldSize269 = (int)(pCurrData - pBegin269 - 4);
		if (fieldSize269 > 4194304)
		{
			throw new Exception($"Size of field {"_happinessDelta"} must be less than {4096}KB");
		}
		*(int*)pBegin269 = fieldSize269;
		byte* pBegin270 = pCurrData;
		pCurrData += 4;
		pCurrData += _teammateCmdCanUse.Serialize(pCurrData);
		int fieldSize270 = (int)(pCurrData - pBegin270 - 4);
		if (fieldSize270 > 4194304)
		{
			throw new Exception($"Size of field {"_teammateCmdCanUse"} must be less than {4096}KB");
		}
		*(int*)pBegin270 = fieldSize270;
		byte* pBegin271 = pCurrData;
		pCurrData += 4;
		pCurrData += _mixPoisonInfinityAffect.Serialize(pCurrData);
		int fieldSize271 = (int)(pCurrData - pBegin271 - 4);
		if (fieldSize271 > 4194304)
		{
			throw new Exception($"Size of field {"_mixPoisonInfinityAffect"} must be less than {4096}KB");
		}
		*(int*)pBegin271 = fieldSize271;
		byte* pBegin272 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackRangeMaxAcupoint.Serialize(pCurrData);
		int fieldSize272 = (int)(pCurrData - pBegin272 - 4);
		if (fieldSize272 > 4194304)
		{
			throw new Exception($"Size of field {"_attackRangeMaxAcupoint"} must be less than {4096}KB");
		}
		*(int*)pBegin272 = fieldSize272;
		byte* pBegin273 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxMobilityPercent.Serialize(pCurrData);
		int fieldSize273 = (int)(pCurrData - pBegin273 - 4);
		if (fieldSize273 > 4194304)
		{
			throw new Exception($"Size of field {"_maxMobilityPercent"} must be less than {4096}KB");
		}
		*(int*)pBegin273 = fieldSize273;
		byte* pBegin274 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeMindDamage.Serialize(pCurrData);
		int fieldSize274 = (int)(pCurrData - pBegin274 - 4);
		if (fieldSize274 > 4194304)
		{
			throw new Exception($"Size of field {"_makeMindDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin274 = fieldSize274;
		byte* pBegin275 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptMindDamage.Serialize(pCurrData);
		int fieldSize275 = (int)(pCurrData - pBegin275 - 4);
		if (fieldSize275 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptMindDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin275 = fieldSize275;
		byte* pBegin276 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitAddByTempValue.Serialize(pCurrData);
		int fieldSize276 = (int)(pCurrData - pBegin276 - 4);
		if (fieldSize276 > 4194304)
		{
			throw new Exception($"Size of field {"_hitAddByTempValue"} must be less than {4096}KB");
		}
		*(int*)pBegin276 = fieldSize276;
		byte* pBegin277 = pCurrData;
		pCurrData += 4;
		pCurrData += _avoidAddByTempValue.Serialize(pCurrData);
		int fieldSize277 = (int)(pCurrData - pBegin277 - 4);
		if (fieldSize277 > 4194304)
		{
			throw new Exception($"Size of field {"_avoidAddByTempValue"} must be less than {4096}KB");
		}
		*(int*)pBegin277 = fieldSize277;
		byte* pBegin278 = pCurrData;
		pCurrData += 4;
		pCurrData += _ignoreEquipmentOverload.Serialize(pCurrData);
		int fieldSize278 = (int)(pCurrData - pBegin278 - 4);
		if (fieldSize278 > 4194304)
		{
			throw new Exception($"Size of field {"_ignoreEquipmentOverload"} must be less than {4096}KB");
		}
		*(int*)pBegin278 = fieldSize278;
		byte* pBegin279 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCostEnemyUsableTricks.Serialize(pCurrData);
		int fieldSize279 = (int)(pCurrData - pBegin279 - 4);
		if (fieldSize279 > 4194304)
		{
			throw new Exception($"Size of field {"_canCostEnemyUsableTricks"} must be less than {4096}KB");
		}
		*(int*)pBegin279 = fieldSize279;
		byte* pBegin280 = pCurrData;
		pCurrData += 4;
		pCurrData += _ignoreArmor.Serialize(pCurrData);
		int fieldSize280 = (int)(pCurrData - pBegin280 - 4);
		if (fieldSize280 > 4194304)
		{
			throw new Exception($"Size of field {"_ignoreArmor"} must be less than {4096}KB");
		}
		*(int*)pBegin280 = fieldSize280;
		byte* pBegin281 = pCurrData;
		pCurrData += 4;
		pCurrData += _unyieldingFallen.Serialize(pCurrData);
		int fieldSize281 = (int)(pCurrData - pBegin281 - 4);
		if (fieldSize281 > 4194304)
		{
			throw new Exception($"Size of field {"_unyieldingFallen"} must be less than {4096}KB");
		}
		*(int*)pBegin281 = fieldSize281;
		byte* pBegin282 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackPrepareFrame.Serialize(pCurrData);
		int fieldSize282 = (int)(pCurrData - pBegin282 - 4);
		if (fieldSize282 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackPrepareFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin282 = fieldSize282;
		byte* pBegin283 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCostUselessTricks.Serialize(pCurrData);
		int fieldSize283 = (int)(pCurrData - pBegin283 - 4);
		if (fieldSize283 > 4194304)
		{
			throw new Exception($"Size of field {"_canCostUselessTricks"} must be less than {4096}KB");
		}
		*(int*)pBegin283 = fieldSize283;
		byte* pBegin284 = pCurrData;
		pCurrData += 4;
		pCurrData += _defendSkillCanAffect.Serialize(pCurrData);
		int fieldSize284 = (int)(pCurrData - pBegin284 - 4);
		if (fieldSize284 > 4194304)
		{
			throw new Exception($"Size of field {"_defendSkillCanAffect"} must be less than {4096}KB");
		}
		*(int*)pBegin284 = fieldSize284;
		byte* pBegin285 = pCurrData;
		pCurrData += 4;
		pCurrData += _assistSkillCanAffect.Serialize(pCurrData);
		int fieldSize285 = (int)(pCurrData - pBegin285 - 4);
		if (fieldSize285 > 4194304)
		{
			throw new Exception($"Size of field {"_assistSkillCanAffect"} must be less than {4096}KB");
		}
		*(int*)pBegin285 = fieldSize285;
		byte* pBegin286 = pCurrData;
		pCurrData += 4;
		pCurrData += _agileSkillCanAffect.Serialize(pCurrData);
		int fieldSize286 = (int)(pCurrData - pBegin286 - 4);
		if (fieldSize286 > 4194304)
		{
			throw new Exception($"Size of field {"_agileSkillCanAffect"} must be less than {4096}KB");
		}
		*(int*)pBegin286 = fieldSize286;
		byte* pBegin287 = pCurrData;
		pCurrData += 4;
		pCurrData += _allMarkChangeToMind.Serialize(pCurrData);
		int fieldSize287 = (int)(pCurrData - pBegin287 - 4);
		if (fieldSize287 > 4194304)
		{
			throw new Exception($"Size of field {"_allMarkChangeToMind"} must be less than {4096}KB");
		}
		*(int*)pBegin287 = fieldSize287;
		byte* pBegin288 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindMarkChangeToFatal.Serialize(pCurrData);
		int fieldSize288 = (int)(pCurrData - pBegin288 - 4);
		if (fieldSize288 > 4194304)
		{
			throw new Exception($"Size of field {"_mindMarkChangeToFatal"} must be less than {4096}KB");
		}
		*(int*)pBegin288 = fieldSize288;
		byte* pBegin289 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCast.Serialize(pCurrData);
		int fieldSize289 = (int)(pCurrData - pBegin289 - 4);
		if (fieldSize289 > 4194304)
		{
			throw new Exception($"Size of field {"_canCast"} must be less than {4096}KB");
		}
		*(int*)pBegin289 = fieldSize289;
		byte* pBegin290 = pCurrData;
		pCurrData += 4;
		pCurrData += _inevitableAvoid.Serialize(pCurrData);
		int fieldSize290 = (int)(pCurrData - pBegin290 - 4);
		if (fieldSize290 > 4194304)
		{
			throw new Exception($"Size of field {"_inevitableAvoid"} must be less than {4096}KB");
		}
		*(int*)pBegin290 = fieldSize290;
		byte* pBegin291 = pCurrData;
		pCurrData += 4;
		pCurrData += _powerEffectReverse.Serialize(pCurrData);
		int fieldSize291 = (int)(pCurrData - pBegin291 - 4);
		if (fieldSize291 > 4194304)
		{
			throw new Exception($"Size of field {"_powerEffectReverse"} must be less than {4096}KB");
		}
		*(int*)pBegin291 = fieldSize291;
		byte* pBegin292 = pCurrData;
		pCurrData += 4;
		pCurrData += _featureBonusReverse.Serialize(pCurrData);
		int fieldSize292 = (int)(pCurrData - pBegin292 - 4);
		if (fieldSize292 > 4194304)
		{
			throw new Exception($"Size of field {"_featureBonusReverse"} must be less than {4096}KB");
		}
		*(int*)pBegin292 = fieldSize292;
		byte* pBegin293 = pCurrData;
		pCurrData += 4;
		pCurrData += _wugFatalDamageValue.Serialize(pCurrData);
		int fieldSize293 = (int)(pCurrData - pBegin293 - 4);
		if (fieldSize293 > 4194304)
		{
			throw new Exception($"Size of field {"_wugFatalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin293 = fieldSize293;
		byte* pBegin294 = pCurrData;
		pCurrData += 4;
		pCurrData += _canRecoverHealthOnMonthChange.Serialize(pCurrData);
		int fieldSize294 = (int)(pCurrData - pBegin294 - 4);
		if (fieldSize294 > 4194304)
		{
			throw new Exception($"Size of field {"_canRecoverHealthOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin294 = fieldSize294;
		byte* pBegin295 = pCurrData;
		pCurrData += 4;
		pCurrData += _takeRevengeRateOnMonthChange.Serialize(pCurrData);
		int fieldSize295 = (int)(pCurrData - pBegin295 - 4);
		if (fieldSize295 > 4194304)
		{
			throw new Exception($"Size of field {"_takeRevengeRateOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin295 = fieldSize295;
		byte* pBegin296 = pCurrData;
		pCurrData += 4;
		pCurrData += _consummateLevelBonus.Serialize(pCurrData);
		int fieldSize296 = (int)(pCurrData - pBegin296 - 4);
		if (fieldSize296 > 4194304)
		{
			throw new Exception($"Size of field {"_consummateLevelBonus"} must be less than {4096}KB");
		}
		*(int*)pBegin296 = fieldSize296;
		byte* pBegin297 = pCurrData;
		pCurrData += 4;
		pCurrData += _neiliDelta.Serialize(pCurrData);
		int fieldSize297 = (int)(pCurrData - pBegin297 - 4);
		if (fieldSize297 > 4194304)
		{
			throw new Exception($"Size of field {"_neiliDelta"} must be less than {4096}KB");
		}
		*(int*)pBegin297 = fieldSize297;
		byte* pBegin298 = pCurrData;
		pCurrData += 4;
		pCurrData += _canMakeLoveSpecialOnMonthChange.Serialize(pCurrData);
		int fieldSize298 = (int)(pCurrData - pBegin298 - 4);
		if (fieldSize298 > 4194304)
		{
			throw new Exception($"Size of field {"_canMakeLoveSpecialOnMonthChange"} must be less than {4096}KB");
		}
		*(int*)pBegin298 = fieldSize298;
		byte* pBegin299 = pCurrData;
		pCurrData += 4;
		pCurrData += _healAcupointSpeed.Serialize(pCurrData);
		int fieldSize299 = (int)(pCurrData - pBegin299 - 4);
		if (fieldSize299 > 4194304)
		{
			throw new Exception($"Size of field {"_healAcupointSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin299 = fieldSize299;
		byte* pBegin300 = pCurrData;
		pCurrData += 4;
		pCurrData += _maxChangeTrickCount.Serialize(pCurrData);
		int fieldSize300 = (int)(pCurrData - pBegin300 - 4);
		if (fieldSize300 > 4194304)
		{
			throw new Exception($"Size of field {"_maxChangeTrickCount"} must be less than {4096}KB");
		}
		*(int*)pBegin300 = fieldSize300;
		byte* pBegin301 = pCurrData;
		pCurrData += 4;
		pCurrData += _convertCostBreathAndStance.Serialize(pCurrData);
		int fieldSize301 = (int)(pCurrData - pBegin301 - 4);
		if (fieldSize301 > 4194304)
		{
			throw new Exception($"Size of field {"_convertCostBreathAndStance"} must be less than {4096}KB");
		}
		*(int*)pBegin301 = fieldSize301;
		byte* pBegin302 = pCurrData;
		pCurrData += 4;
		pCurrData += _personalitiesAll.Serialize(pCurrData);
		int fieldSize302 = (int)(pCurrData - pBegin302 - 4);
		if (fieldSize302 > 4194304)
		{
			throw new Exception($"Size of field {"_personalitiesAll"} must be less than {4096}KB");
		}
		*(int*)pBegin302 = fieldSize302;
		byte* pBegin303 = pCurrData;
		pCurrData += 4;
		pCurrData += _finalFatalDamageMarkCount.Serialize(pCurrData);
		int fieldSize303 = (int)(pCurrData - pBegin303 - 4);
		if (fieldSize303 > 4194304)
		{
			throw new Exception($"Size of field {"_finalFatalDamageMarkCount"} must be less than {4096}KB");
		}
		*(int*)pBegin303 = fieldSize303;
		byte* pBegin304 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatSkillAiScorePower.Serialize(pCurrData);
		int fieldSize304 = (int)(pCurrData - pBegin304 - 4);
		if (fieldSize304 > 4194304)
		{
			throw new Exception($"Size of field {"_combatSkillAiScorePower"} must be less than {4096}KB");
		}
		*(int*)pBegin304 = fieldSize304;
		byte* pBegin305 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackChangeToUnlockAttack.Serialize(pCurrData);
		int fieldSize305 = (int)(pCurrData - pBegin305 - 4);
		if (fieldSize305 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackChangeToUnlockAttack"} must be less than {4096}KB");
		}
		*(int*)pBegin305 = fieldSize305;
		byte* pBegin306 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackBodyPartOdds.Serialize(pCurrData);
		int fieldSize306 = (int)(pCurrData - pBegin306 - 4);
		if (fieldSize306 > 4194304)
		{
			throw new Exception($"Size of field {"_attackBodyPartOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin306 = fieldSize306;
		byte* pBegin307 = pCurrData;
		pCurrData += 4;
		pCurrData += _changeDurability.Serialize(pCurrData);
		int fieldSize307 = (int)(pCurrData - pBegin307 - 4);
		if (fieldSize307 > 4194304)
		{
			throw new Exception($"Size of field {"_changeDurability"} must be less than {4096}KB");
		}
		*(int*)pBegin307 = fieldSize307;
		byte* pBegin308 = pCurrData;
		pCurrData += 4;
		pCurrData += _equipmentBonus.Serialize(pCurrData);
		int fieldSize308 = (int)(pCurrData - pBegin308 - 4);
		if (fieldSize308 > 4194304)
		{
			throw new Exception($"Size of field {"_equipmentBonus"} must be less than {4096}KB");
		}
		*(int*)pBegin308 = fieldSize308;
		byte* pBegin309 = pCurrData;
		pCurrData += 4;
		pCurrData += _equipmentWeight.Serialize(pCurrData);
		int fieldSize309 = (int)(pCurrData - pBegin309 - 4);
		if (fieldSize309 > 4194304)
		{
			throw new Exception($"Size of field {"_equipmentWeight"} must be less than {4096}KB");
		}
		*(int*)pBegin309 = fieldSize309;
		byte* pBegin310 = pCurrData;
		pCurrData += 4;
		pCurrData += _rawCreateEffectList.Serialize(pCurrData);
		int fieldSize310 = (int)(pCurrData - pBegin310 - 4);
		if (fieldSize310 > 4194304)
		{
			throw new Exception($"Size of field {"_rawCreateEffectList"} must be less than {4096}KB");
		}
		*(int*)pBegin310 = fieldSize310;
		byte* pBegin311 = pCurrData;
		pCurrData += 4;
		pCurrData += _jiTrickAsWeaponTrickCount.Serialize(pCurrData);
		int fieldSize311 = (int)(pCurrData - pBegin311 - 4);
		if (fieldSize311 > 4194304)
		{
			throw new Exception($"Size of field {"_jiTrickAsWeaponTrickCount"} must be less than {4096}KB");
		}
		*(int*)pBegin311 = fieldSize311;
		byte* pBegin312 = pCurrData;
		pCurrData += 4;
		pCurrData += _uselessTrickAsJiTrickCount.Serialize(pCurrData);
		int fieldSize312 = (int)(pCurrData - pBegin312 - 4);
		if (fieldSize312 > 4194304)
		{
			throw new Exception($"Size of field {"_uselessTrickAsJiTrickCount"} must be less than {4096}KB");
		}
		*(int*)pBegin312 = fieldSize312;
		byte* pBegin313 = pCurrData;
		pCurrData += 4;
		pCurrData += _equipmentPower.Serialize(pCurrData);
		int fieldSize313 = (int)(pCurrData - pBegin313 - 4);
		if (fieldSize313 > 4194304)
		{
			throw new Exception($"Size of field {"_equipmentPower"} must be less than {4096}KB");
		}
		*(int*)pBegin313 = fieldSize313;
		byte* pBegin314 = pCurrData;
		pCurrData += 4;
		pCurrData += _healFlawSpeed.Serialize(pCurrData);
		int fieldSize314 = (int)(pCurrData - pBegin314 - 4);
		if (fieldSize314 > 4194304)
		{
			throw new Exception($"Size of field {"_healFlawSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin314 = fieldSize314;
		byte* pBegin315 = pCurrData;
		pCurrData += 4;
		pCurrData += _unlockSpeed.Serialize(pCurrData);
		int fieldSize315 = (int)(pCurrData - pBegin315 - 4);
		if (fieldSize315 > 4194304)
		{
			throw new Exception($"Size of field {"_unlockSpeed"} must be less than {4096}KB");
		}
		*(int*)pBegin315 = fieldSize315;
		byte* pBegin316 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawBonusFactor.Serialize(pCurrData);
		int fieldSize316 = (int)(pCurrData - pBegin316 - 4);
		if (fieldSize316 > 4194304)
		{
			throw new Exception($"Size of field {"_flawBonusFactor"} must be less than {4096}KB");
		}
		*(int*)pBegin316 = fieldSize316;
		byte* pBegin317 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCostShaTricks.Serialize(pCurrData);
		int fieldSize317 = (int)(pCurrData - pBegin317 - 4);
		if (fieldSize317 > 4194304)
		{
			throw new Exception($"Size of field {"_canCostShaTricks"} must be less than {4096}KB");
		}
		*(int*)pBegin317 = fieldSize317;
		byte* pBegin318 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderDirectFinalDamageValue.Serialize(pCurrData);
		int fieldSize318 = (int)(pCurrData - pBegin318 - 4);
		if (fieldSize318 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderDirectFinalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin318 = fieldSize318;
		byte* pBegin319 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackRecoveryFrame.Serialize(pCurrData);
		int fieldSize319 = (int)(pCurrData - pBegin319 - 4);
		if (fieldSize319 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackRecoveryFrame"} must be less than {4096}KB");
		}
		*(int*)pBegin319 = fieldSize319;
		byte* pBegin320 = pCurrData;
		pCurrData += 4;
		pCurrData += _finalGoneMadInjury.Serialize(pCurrData);
		int fieldSize320 = (int)(pCurrData - pBegin320 - 4);
		if (fieldSize320 > 4194304)
		{
			throw new Exception($"Size of field {"_finalGoneMadInjury"} must be less than {4096}KB");
		}
		*(int*)pBegin320 = fieldSize320;
		byte* pBegin321 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerDirectFinalDamageValue.Serialize(pCurrData);
		int fieldSize321 = (int)(pCurrData - pBegin321 - 4);
		if (fieldSize321 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerDirectFinalDamageValue"} must be less than {4096}KB");
		}
		*(int*)pBegin321 = fieldSize321;
		byte* pBegin322 = pCurrData;
		pCurrData += 4;
		pCurrData += _canCostTrickDuringPreparingSkill.Serialize(pCurrData);
		int fieldSize322 = (int)(pCurrData - pBegin322 - 4);
		if (fieldSize322 > 4194304)
		{
			throw new Exception($"Size of field {"_canCostTrickDuringPreparingSkill"} must be less than {4096}KB");
		}
		*(int*)pBegin322 = fieldSize322;
		byte* pBegin323 = pCurrData;
		pCurrData += 4;
		pCurrData += _validItemList.Serialize(pCurrData);
		int fieldSize323 = (int)(pCurrData - pBegin323 - 4);
		if (fieldSize323 > 4194304)
		{
			throw new Exception($"Size of field {"_validItemList"} must be less than {4096}KB");
		}
		*(int*)pBegin323 = fieldSize323;
		byte* pBegin324 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptDamageCanAdd.Serialize(pCurrData);
		int fieldSize324 = (int)(pCurrData - pBegin324 - 4);
		if (fieldSize324 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptDamageCanAdd"} must be less than {4096}KB");
		}
		*(int*)pBegin324 = fieldSize324;
		byte* pBegin325 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeDamageCanReduce.Serialize(pCurrData);
		int fieldSize325 = (int)(pCurrData - pBegin325 - 4);
		if (fieldSize325 > 4194304)
		{
			throw new Exception($"Size of field {"_makeDamageCanReduce"} must be less than {4096}KB");
		}
		*(int*)pBegin325 = fieldSize325;
		byte* pBegin326 = pCurrData;
		pCurrData += 4;
		pCurrData += _normalAttackGetTrickCount.Serialize(pCurrData);
		int fieldSize326 = (int)(pCurrData - pBegin326 - 4);
		if (fieldSize326 > 4194304)
		{
			throw new Exception($"Size of field {"_normalAttackGetTrickCount"} must be less than {4096}KB");
		}
		*(int*)pBegin326 = fieldSize326;
		byte* pBegin327 = pCurrData;
		pCurrData += 4;
		pCurrData += _stayEffectCountOnAddPhase.Serialize(pCurrData);
		int fieldSize327 = (int)(pCurrData - pBegin327 - 4);
		if (fieldSize327 > 4194304)
		{
			throw new Exception($"Size of field {"_stayEffectCountOnAddPhase"} must be less than {4096}KB");
		}
		*(int*)pBegin327 = fieldSize327;
		byte* pBegin328 = pCurrData;
		pCurrData += 4;
		pCurrData += _healInjuryWithFatalRequireAttainment.Serialize(pCurrData);
		int fieldSize328 = (int)(pCurrData - pBegin328 - 4);
		if (fieldSize328 > 4194304)
		{
			throw new Exception($"Size of field {"_healInjuryWithFatalRequireAttainment"} must be less than {4096}KB");
		}
		*(int*)pBegin328 = fieldSize328;
		byte* pBegin329 = pCurrData;
		pCurrData += 4;
		pCurrData += _useItemCostNoWisdom.Serialize(pCurrData);
		int fieldSize329 = (int)(pCurrData - pBegin329 - 4);
		if (fieldSize329 > 4194304)
		{
			throw new Exception($"Size of field {"_useItemCostNoWisdom"} must be less than {4096}KB");
		}
		*(int*)pBegin329 = fieldSize329;
		byte* pBegin330 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindUpheavalTime.Serialize(pCurrData);
		int fieldSize330 = (int)(pCurrData - pBegin330 - 4);
		if (fieldSize330 > 4194304)
		{
			throw new Exception($"Size of field {"_mindUpheavalTime"} must be less than {4096}KB");
		}
		*(int*)pBegin330 = fieldSize330;
		byte* pBegin331 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeHarmfulActionSuccessRate.Serialize(pCurrData);
		int fieldSize331 = (int)(pCurrData - pBegin331 - 4);
		if (fieldSize331 > 4194304)
		{
			throw new Exception($"Size of field {"_makeHarmfulActionSuccessRate"} must be less than {4096}KB");
		}
		*(int*)pBegin331 = fieldSize331;
		byte* pBegin332 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptHarmfulActionSuccessRate.Serialize(pCurrData);
		int fieldSize332 = (int)(pCurrData - pBegin332 - 4);
		if (fieldSize332 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptHarmfulActionSuccessRate"} must be less than {4096}KB");
		}
		*(int*)pBegin332 = fieldSize332;
		byte* pBegin333 = pCurrData;
		pCurrData += 4;
		pCurrData += _makeFatalDamage.Serialize(pCurrData);
		int fieldSize333 = (int)(pCurrData - pBegin333 - 4);
		if (fieldSize333 > 4194304)
		{
			throw new Exception($"Size of field {"_makeFatalDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin333 = fieldSize333;
		byte* pBegin334 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptFatalDamage.Serialize(pCurrData);
		int fieldSize334 = (int)(pCurrData - pBegin334 - 4);
		if (fieldSize334 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptFatalDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin334 = fieldSize334;
		byte* pBegin335 = pCurrData;
		pCurrData += 4;
		pCurrData += _causedInjuryChangeToOldOdds.Serialize(pCurrData);
		int fieldSize335 = (int)(pCurrData - pBegin335 - 4);
		if (fieldSize335 > 4194304)
		{
			throw new Exception($"Size of field {"_causedInjuryChangeToOldOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin335 = fieldSize335;
		byte* pBegin336 = pCurrData;
		pCurrData += 4;
		pCurrData += _causedMindChangeToInfiniteOdds.Serialize(pCurrData);
		int fieldSize336 = (int)(pCurrData - pBegin336 - 4);
		if (fieldSize336 > 4194304)
		{
			throw new Exception($"Size of field {"_causedMindChangeToInfiniteOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin336 = fieldSize336;
		byte* pBegin337 = pCurrData;
		pCurrData += 4;
		pCurrData += _hitReduceDurability.Serialize(pCurrData);
		int fieldSize337 = (int)(pCurrData - pBegin337 - 4);
		if (fieldSize337 > 4194304)
		{
			throw new Exception($"Size of field {"_hitReduceDurability"} must be less than {4096}KB");
		}
		*(int*)pBegin337 = fieldSize337;
		byte* pBegin338 = pCurrData;
		pCurrData += 4;
		pCurrData += _equipmentMasteryAffectOdds.Serialize(pCurrData);
		int fieldSize338 = (int)(pCurrData - pBegin338 - 4);
		if (fieldSize338 > 4194304)
		{
			throw new Exception($"Size of field {"_equipmentMasteryAffectOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin338 = fieldSize338;
		byte* pBegin339 = pCurrData;
		pCurrData += 4;
		pCurrData += _criticalDamage.Serialize(pCurrData);
		int fieldSize339 = (int)(pCurrData - pBegin339 - 4);
		if (fieldSize339 > 4194304)
		{
			throw new Exception($"Size of field {"_criticalDamage"} must be less than {4096}KB");
		}
		*(int*)pBegin339 = fieldSize339;
		byte* pBegin340 = pCurrData;
		pCurrData += 4;
		pCurrData += _canFightBackOutOfAttackRange.Serialize(pCurrData);
		int fieldSize340 = (int)(pCurrData - pBegin340 - 4);
		if (fieldSize340 > 4194304)
		{
			throw new Exception($"Size of field {"_canFightBackOutOfAttackRange"} must be less than {4096}KB");
		}
		*(int*)pBegin340 = fieldSize340;
		byte* pBegin341 = pCurrData;
		pCurrData += 4;
		pCurrData += _attackerCriticalOdds.Serialize(pCurrData);
		int fieldSize341 = (int)(pCurrData - pBegin341 - 4);
		if (fieldSize341 > 4194304)
		{
			throw new Exception($"Size of field {"_attackerCriticalOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin341 = fieldSize341;
		byte* pBegin342 = pCurrData;
		pCurrData += 4;
		pCurrData += _defenderCriticalOdds.Serialize(pCurrData);
		int fieldSize342 = (int)(pCurrData - pBegin342 - 4);
		if (fieldSize342 > 4194304)
		{
			throw new Exception($"Size of field {"_defenderCriticalOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin342 = fieldSize342;
		byte* pBegin343 = pCurrData;
		pCurrData += 4;
		pCurrData += _mixPoisonCanAffectCount.Serialize(pCurrData);
		int fieldSize343 = (int)(pCurrData - pBegin343 - 4);
		if (fieldSize343 > 4194304)
		{
			throw new Exception($"Size of field {"_mixPoisonCanAffectCount"} must be less than {4096}KB");
		}
		*(int*)pBegin343 = fieldSize343;
		byte* pBegin344 = pCurrData;
		pCurrData += 4;
		pCurrData += _castCostNeiliAllocationIsAbsorb.Serialize(pCurrData);
		int fieldSize344 = (int)(pCurrData - pBegin344 - 4);
		if (fieldSize344 > 4194304)
		{
			throw new Exception($"Size of field {"_castCostNeiliAllocationIsAbsorb"} must be less than {4096}KB");
		}
		*(int*)pBegin344 = fieldSize344;
		byte* pBegin345 = pCurrData;
		pCurrData += 4;
		pCurrData += _acceptInjuryChangeToOldOdds.Serialize(pCurrData);
		int fieldSize345 = (int)(pCurrData - pBegin345 - 4);
		if (fieldSize345 > 4194304)
		{
			throw new Exception($"Size of field {"_acceptInjuryChangeToOldOdds"} must be less than {4096}KB");
		}
		*(int*)pBegin345 = fieldSize345;
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
				_id = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 1:
				pCurrData += 4;
				pCurrData += _maxStrength.Deserialize(pCurrData);
				continue;
			case 2:
				pCurrData += 4;
				pCurrData += _maxDexterity.Deserialize(pCurrData);
				continue;
			case 3:
				pCurrData += 4;
				pCurrData += _maxConcentration.Deserialize(pCurrData);
				continue;
			case 4:
				pCurrData += 4;
				pCurrData += _maxVitality.Deserialize(pCurrData);
				continue;
			case 5:
				pCurrData += 4;
				pCurrData += _maxEnergy.Deserialize(pCurrData);
				continue;
			case 6:
				pCurrData += 4;
				pCurrData += _maxIntelligence.Deserialize(pCurrData);
				continue;
			case 7:
				pCurrData += 4;
				pCurrData += _recoveryOfStance.Deserialize(pCurrData);
				continue;
			case 8:
				pCurrData += 4;
				pCurrData += _recoveryOfBreath.Deserialize(pCurrData);
				continue;
			case 9:
				pCurrData += 4;
				pCurrData += _moveSpeed.Deserialize(pCurrData);
				continue;
			case 10:
				pCurrData += 4;
				pCurrData += _recoveryOfFlaw.Deserialize(pCurrData);
				continue;
			case 11:
				pCurrData += 4;
				pCurrData += _castSpeed.Deserialize(pCurrData);
				continue;
			case 12:
				pCurrData += 4;
				pCurrData += _recoveryOfBlockedAcupoint.Deserialize(pCurrData);
				continue;
			case 13:
				pCurrData += 4;
				pCurrData += _weaponSwitchSpeed.Deserialize(pCurrData);
				continue;
			case 14:
				pCurrData += 4;
				pCurrData += _attackSpeed.Deserialize(pCurrData);
				continue;
			case 15:
				pCurrData += 4;
				pCurrData += _innerRatio.Deserialize(pCurrData);
				continue;
			case 16:
				pCurrData += 4;
				pCurrData += _recoveryOfQiDisorder.Deserialize(pCurrData);
				continue;
			case 17:
				pCurrData += 4;
				pCurrData += _minorAttributeFixMaxValue.Deserialize(pCurrData);
				continue;
			case 18:
				pCurrData += 4;
				pCurrData += _minorAttributeFixMinValue.Deserialize(pCurrData);
				continue;
			case 19:
				pCurrData += 4;
				pCurrData += _resistOfHotPoison.Deserialize(pCurrData);
				continue;
			case 20:
				pCurrData += 4;
				pCurrData += _resistOfGloomyPoison.Deserialize(pCurrData);
				continue;
			case 21:
				pCurrData += 4;
				pCurrData += _resistOfColdPoison.Deserialize(pCurrData);
				continue;
			case 22:
				pCurrData += 4;
				pCurrData += _resistOfRedPoison.Deserialize(pCurrData);
				continue;
			case 23:
				pCurrData += 4;
				pCurrData += _resistOfRottenPoison.Deserialize(pCurrData);
				continue;
			case 24:
				pCurrData += 4;
				pCurrData += _resistOfIllusoryPoison.Deserialize(pCurrData);
				continue;
			case 25:
				pCurrData += 4;
				pCurrData += _displayAge.Deserialize(pCurrData);
				continue;
			case 26:
				pCurrData += 4;
				pCurrData += _neiliProportionOfFiveElements.Deserialize(pCurrData);
				continue;
			case 27:
				pCurrData += 4;
				pCurrData += _weaponMaxPower.Deserialize(pCurrData);
				continue;
			case 28:
				pCurrData += 4;
				pCurrData += _weaponUseRequirement.Deserialize(pCurrData);
				continue;
			case 29:
				pCurrData += 4;
				pCurrData += _weaponAttackRange.Deserialize(pCurrData);
				continue;
			case 30:
				pCurrData += 4;
				pCurrData += _armorMaxPower.Deserialize(pCurrData);
				continue;
			case 31:
				pCurrData += 4;
				pCurrData += _armorUseRequirement.Deserialize(pCurrData);
				continue;
			case 32:
				pCurrData += 4;
				pCurrData += _hitStrength.Deserialize(pCurrData);
				continue;
			case 33:
				pCurrData += 4;
				pCurrData += _hitTechnique.Deserialize(pCurrData);
				continue;
			case 34:
				pCurrData += 4;
				pCurrData += _hitSpeed.Deserialize(pCurrData);
				continue;
			case 35:
				pCurrData += 4;
				pCurrData += _hitMind.Deserialize(pCurrData);
				continue;
			case 36:
				pCurrData += 4;
				pCurrData += _hitCanChange.Deserialize(pCurrData);
				continue;
			case 37:
				pCurrData += 4;
				pCurrData += _hitChangeEffectPercent.Deserialize(pCurrData);
				continue;
			case 38:
				pCurrData += 4;
				pCurrData += _avoidStrength.Deserialize(pCurrData);
				continue;
			case 39:
				pCurrData += 4;
				pCurrData += _avoidTechnique.Deserialize(pCurrData);
				continue;
			case 40:
				pCurrData += 4;
				pCurrData += _avoidSpeed.Deserialize(pCurrData);
				continue;
			case 41:
				pCurrData += 4;
				pCurrData += _avoidMind.Deserialize(pCurrData);
				continue;
			case 42:
				pCurrData += 4;
				pCurrData += _avoidCanChange.Deserialize(pCurrData);
				continue;
			case 43:
				pCurrData += 4;
				pCurrData += _avoidChangeEffectPercent.Deserialize(pCurrData);
				continue;
			case 44:
				pCurrData += 4;
				pCurrData += _penetrateOuter.Deserialize(pCurrData);
				continue;
			case 45:
				pCurrData += 4;
				pCurrData += _penetrateInner.Deserialize(pCurrData);
				continue;
			case 46:
				pCurrData += 4;
				pCurrData += _penetrateResistOuter.Deserialize(pCurrData);
				continue;
			case 47:
				pCurrData += 4;
				pCurrData += _penetrateResistInner.Deserialize(pCurrData);
				continue;
			case 48:
				pCurrData += 4;
				pCurrData += _neiliAllocationAttack.Deserialize(pCurrData);
				continue;
			case 49:
				pCurrData += 4;
				pCurrData += _neiliAllocationAgile.Deserialize(pCurrData);
				continue;
			case 50:
				pCurrData += 4;
				pCurrData += _neiliAllocationDefense.Deserialize(pCurrData);
				continue;
			case 51:
				pCurrData += 4;
				pCurrData += _neiliAllocationAssist.Deserialize(pCurrData);
				continue;
			case 52:
				pCurrData += 4;
				pCurrData += _happiness.Deserialize(pCurrData);
				continue;
			case 53:
				pCurrData += 4;
				pCurrData += _maxHealth.Deserialize(pCurrData);
				continue;
			case 54:
				pCurrData += 4;
				pCurrData += _healthCost.Deserialize(pCurrData);
				continue;
			case 55:
				pCurrData += 4;
				pCurrData += _moveSpeedCanChange.Deserialize(pCurrData);
				continue;
			case 56:
				pCurrData += 4;
				pCurrData += _attackerHitStrength.Deserialize(pCurrData);
				continue;
			case 57:
				pCurrData += 4;
				pCurrData += _attackerHitTechnique.Deserialize(pCurrData);
				continue;
			case 58:
				pCurrData += 4;
				pCurrData += _attackerHitSpeed.Deserialize(pCurrData);
				continue;
			case 59:
				pCurrData += 4;
				pCurrData += _attackerHitMind.Deserialize(pCurrData);
				continue;
			case 60:
				pCurrData += 4;
				pCurrData += _attackerAvoidStrength.Deserialize(pCurrData);
				continue;
			case 61:
				pCurrData += 4;
				pCurrData += _attackerAvoidTechnique.Deserialize(pCurrData);
				continue;
			case 62:
				pCurrData += 4;
				pCurrData += _attackerAvoidSpeed.Deserialize(pCurrData);
				continue;
			case 63:
				pCurrData += 4;
				pCurrData += _attackerAvoidMind.Deserialize(pCurrData);
				continue;
			case 64:
				pCurrData += 4;
				pCurrData += _attackerPenetrateOuter.Deserialize(pCurrData);
				continue;
			case 65:
				pCurrData += 4;
				pCurrData += _attackerPenetrateInner.Deserialize(pCurrData);
				continue;
			case 66:
				pCurrData += 4;
				pCurrData += _attackerPenetrateResistOuter.Deserialize(pCurrData);
				continue;
			case 67:
				pCurrData += 4;
				pCurrData += _attackerPenetrateResistInner.Deserialize(pCurrData);
				continue;
			case 68:
				pCurrData += 4;
				pCurrData += _attackHitType.Deserialize(pCurrData);
				continue;
			case 69:
				pCurrData += 4;
				pCurrData += _makeDirectDamage.Deserialize(pCurrData);
				continue;
			case 70:
				pCurrData += 4;
				pCurrData += _makeBounceDamage.Deserialize(pCurrData);
				continue;
			case 71:
				pCurrData += 4;
				pCurrData += _makeFightBackDamage.Deserialize(pCurrData);
				continue;
			case 72:
				pCurrData += 4;
				pCurrData += _makePoisonLevel.Deserialize(pCurrData);
				continue;
			case 73:
				pCurrData += 4;
				pCurrData += _makePoisonValue.Deserialize(pCurrData);
				continue;
			case 74:
				pCurrData += 4;
				pCurrData += _attackerHitOdds.Deserialize(pCurrData);
				continue;
			case 75:
				pCurrData += 4;
				pCurrData += _attackerFightBackHitOdds.Deserialize(pCurrData);
				continue;
			case 76:
				pCurrData += 4;
				pCurrData += _attackerPursueOdds.Deserialize(pCurrData);
				continue;
			case 77:
				pCurrData += 4;
				pCurrData += _causedInjuryChangeToOld.Deserialize(pCurrData);
				continue;
			case 78:
				pCurrData += 4;
				pCurrData += _causedPoisonChangeToOld.Deserialize(pCurrData);
				continue;
			case 79:
				pCurrData += 4;
				pCurrData += _makeDamageType.Deserialize(pCurrData);
				continue;
			case 80:
				pCurrData += 4;
				pCurrData += _canMakeInjuryToNoInjuryPart.Deserialize(pCurrData);
				continue;
			case 81:
				pCurrData += 4;
				pCurrData += _makePoisonType.Deserialize(pCurrData);
				continue;
			case 82:
				pCurrData += 4;
				pCurrData += _normalAttackWeapon.Deserialize(pCurrData);
				continue;
			case 83:
				pCurrData += 4;
				pCurrData += _normalAttackTrick.Deserialize(pCurrData);
				continue;
			case 84:
				pCurrData += 4;
				pCurrData += _extraFlawCount.Deserialize(pCurrData);
				continue;
			case 85:
				pCurrData += 4;
				pCurrData += _attackCanBounce.Deserialize(pCurrData);
				continue;
			case 86:
				pCurrData += 4;
				pCurrData += _attackCanFightBack.Deserialize(pCurrData);
				continue;
			case 87:
				pCurrData += 4;
				pCurrData += _makeFightBackInjuryMark.Deserialize(pCurrData);
				continue;
			case 88:
				pCurrData += 4;
				pCurrData += _legSkillUseShoes.Deserialize(pCurrData);
				continue;
			case 89:
				pCurrData += 4;
				pCurrData += _attackerFinalDamageValue.Deserialize(pCurrData);
				continue;
			case 90:
				pCurrData += 4;
				pCurrData += _defenderHitStrength.Deserialize(pCurrData);
				continue;
			case 91:
				pCurrData += 4;
				pCurrData += _defenderHitTechnique.Deserialize(pCurrData);
				continue;
			case 92:
				pCurrData += 4;
				pCurrData += _defenderHitSpeed.Deserialize(pCurrData);
				continue;
			case 93:
				pCurrData += 4;
				pCurrData += _defenderHitMind.Deserialize(pCurrData);
				continue;
			case 94:
				pCurrData += 4;
				pCurrData += _defenderAvoidStrength.Deserialize(pCurrData);
				continue;
			case 95:
				pCurrData += 4;
				pCurrData += _defenderAvoidTechnique.Deserialize(pCurrData);
				continue;
			case 96:
				pCurrData += 4;
				pCurrData += _defenderAvoidSpeed.Deserialize(pCurrData);
				continue;
			case 97:
				pCurrData += 4;
				pCurrData += _defenderAvoidMind.Deserialize(pCurrData);
				continue;
			case 98:
				pCurrData += 4;
				pCurrData += _defenderPenetrateOuter.Deserialize(pCurrData);
				continue;
			case 99:
				pCurrData += 4;
				pCurrData += _defenderPenetrateInner.Deserialize(pCurrData);
				continue;
			case 100:
				pCurrData += 4;
				pCurrData += _defenderPenetrateResistOuter.Deserialize(pCurrData);
				continue;
			case 101:
				pCurrData += 4;
				pCurrData += _defenderPenetrateResistInner.Deserialize(pCurrData);
				continue;
			case 102:
				pCurrData += 4;
				pCurrData += _acceptDirectDamage.Deserialize(pCurrData);
				continue;
			case 103:
				pCurrData += 4;
				pCurrData += _acceptBounceDamage.Deserialize(pCurrData);
				continue;
			case 104:
				pCurrData += 4;
				pCurrData += _acceptFightBackDamage.Deserialize(pCurrData);
				continue;
			case 105:
				pCurrData += 4;
				pCurrData += _acceptPoisonLevel.Deserialize(pCurrData);
				continue;
			case 106:
				pCurrData += 4;
				pCurrData += _acceptPoisonValue.Deserialize(pCurrData);
				continue;
			case 107:
				pCurrData += 4;
				pCurrData += _defenderHitOdds.Deserialize(pCurrData);
				continue;
			case 108:
				pCurrData += 4;
				pCurrData += _defenderFightBackHitOdds.Deserialize(pCurrData);
				continue;
			case 109:
				pCurrData += 4;
				pCurrData += _defenderPursueOdds.Deserialize(pCurrData);
				continue;
			case 110:
				pCurrData += 4;
				pCurrData += _acceptMaxInjuryCount.Deserialize(pCurrData);
				continue;
			case 111:
				pCurrData += 4;
				pCurrData += _bouncePower.Deserialize(pCurrData);
				continue;
			case 112:
				pCurrData += 4;
				pCurrData += _fightBackPower.Deserialize(pCurrData);
				continue;
			case 113:
				pCurrData += 4;
				pCurrData += _directDamageInnerRatio.Deserialize(pCurrData);
				continue;
			case 114:
				pCurrData += 4;
				pCurrData += _defenderFinalDamageValue.Deserialize(pCurrData);
				continue;
			case 115:
				pCurrData += 4;
				pCurrData += _directDamageValue.Deserialize(pCurrData);
				continue;
			case 116:
				pCurrData += 4;
				pCurrData += _directInjuryMark.Deserialize(pCurrData);
				continue;
			case 117:
				pCurrData += 4;
				pCurrData += _goneMadInjury.Deserialize(pCurrData);
				continue;
			case 118:
				pCurrData += 4;
				pCurrData += _healInjurySpeed.Deserialize(pCurrData);
				continue;
			case 119:
				pCurrData += 4;
				pCurrData += _healInjuryBuff.Deserialize(pCurrData);
				continue;
			case 120:
				pCurrData += 4;
				pCurrData += _healInjuryDebuff.Deserialize(pCurrData);
				continue;
			case 121:
				pCurrData += 4;
				pCurrData += _healPoisonSpeed.Deserialize(pCurrData);
				continue;
			case 122:
				pCurrData += 4;
				pCurrData += _healPoisonBuff.Deserialize(pCurrData);
				continue;
			case 123:
				pCurrData += 4;
				pCurrData += _healPoisonDebuff.Deserialize(pCurrData);
				continue;
			case 124:
				pCurrData += 4;
				pCurrData += _fleeSpeed.Deserialize(pCurrData);
				continue;
			case 125:
				pCurrData += 4;
				pCurrData += _maxFlawCount.Deserialize(pCurrData);
				continue;
			case 126:
				pCurrData += 4;
				pCurrData += _canAddFlaw.Deserialize(pCurrData);
				continue;
			case 127:
				pCurrData += 4;
				pCurrData += _flawLevel.Deserialize(pCurrData);
				continue;
			case 128:
				pCurrData += 4;
				pCurrData += _flawLevelCanReduce.Deserialize(pCurrData);
				continue;
			case 129:
				pCurrData += 4;
				pCurrData += _flawCount.Deserialize(pCurrData);
				continue;
			case 130:
				pCurrData += 4;
				pCurrData += _maxAcupointCount.Deserialize(pCurrData);
				continue;
			case 131:
				pCurrData += 4;
				pCurrData += _canAddAcupoint.Deserialize(pCurrData);
				continue;
			case 132:
				pCurrData += 4;
				pCurrData += _acupointLevel.Deserialize(pCurrData);
				continue;
			case 133:
				pCurrData += 4;
				pCurrData += _acupointLevelCanReduce.Deserialize(pCurrData);
				continue;
			case 134:
				pCurrData += 4;
				pCurrData += _acupointCount.Deserialize(pCurrData);
				continue;
			case 135:
				pCurrData += 4;
				pCurrData += _addNeiliAllocation.Deserialize(pCurrData);
				continue;
			case 136:
				pCurrData += 4;
				pCurrData += _costNeiliAllocation.Deserialize(pCurrData);
				continue;
			case 137:
				pCurrData += 4;
				pCurrData += _canChangeNeiliAllocation.Deserialize(pCurrData);
				continue;
			case 138:
				pCurrData += 4;
				pCurrData += _canGetTrick.Deserialize(pCurrData);
				continue;
			case 139:
				pCurrData += 4;
				pCurrData += _getTrickType.Deserialize(pCurrData);
				continue;
			case 140:
				pCurrData += 4;
				pCurrData += _attackBodyPart.Deserialize(pCurrData);
				continue;
			case 141:
				pCurrData += 4;
				pCurrData += _weaponEquipAttack.Deserialize(pCurrData);
				continue;
			case 142:
				pCurrData += 4;
				pCurrData += _weaponEquipDefense.Deserialize(pCurrData);
				continue;
			case 143:
				pCurrData += 4;
				pCurrData += _armorEquipAttack.Deserialize(pCurrData);
				continue;
			case 144:
				pCurrData += 4;
				pCurrData += _armorEquipDefense.Deserialize(pCurrData);
				continue;
			case 145:
				pCurrData += 4;
				pCurrData += _attackRangeForward.Deserialize(pCurrData);
				continue;
			case 146:
				pCurrData += 4;
				pCurrData += _attackRangeBackward.Deserialize(pCurrData);
				continue;
			case 147:
				pCurrData += 4;
				pCurrData += _moveCanBeStopped.Deserialize(pCurrData);
				continue;
			case 148:
				pCurrData += 4;
				pCurrData += _canForcedMove.Deserialize(pCurrData);
				continue;
			case 149:
				pCurrData += 4;
				pCurrData += _mobilityCanBeRemoved.Deserialize(pCurrData);
				continue;
			case 150:
				pCurrData += 4;
				pCurrData += _mobilityCostByEffect.Deserialize(pCurrData);
				continue;
			case 151:
				pCurrData += 4;
				pCurrData += _moveDistance.Deserialize(pCurrData);
				continue;
			case 152:
				pCurrData += 4;
				pCurrData += _jumpPrepareFrame.Deserialize(pCurrData);
				continue;
			case 153:
				pCurrData += 4;
				pCurrData += _bounceInjuryMark.Deserialize(pCurrData);
				continue;
			case 154:
				pCurrData += 4;
				pCurrData += _skillHasCost.Deserialize(pCurrData);
				continue;
			case 155:
				pCurrData += 4;
				pCurrData += _combatStateEffect.Deserialize(pCurrData);
				continue;
			case 156:
				pCurrData += 4;
				pCurrData += _changeNeedUseSkill.Deserialize(pCurrData);
				continue;
			case 157:
				pCurrData += 4;
				pCurrData += _changeDistanceIsMove.Deserialize(pCurrData);
				continue;
			case 158:
				pCurrData += 4;
				pCurrData += _replaceCharHit.Deserialize(pCurrData);
				continue;
			case 159:
				pCurrData += 4;
				pCurrData += _canAddPoison.Deserialize(pCurrData);
				continue;
			case 160:
				pCurrData += 4;
				pCurrData += _canReducePoison.Deserialize(pCurrData);
				continue;
			case 161:
				pCurrData += 4;
				pCurrData += _reducePoisonValue.Deserialize(pCurrData);
				continue;
			case 162:
				pCurrData += 4;
				pCurrData += _poisonCanAffect.Deserialize(pCurrData);
				continue;
			case 163:
				pCurrData += 4;
				pCurrData += _poisonAffectCount.Deserialize(pCurrData);
				continue;
			case 164:
				pCurrData += 4;
				pCurrData += _costTricks.Deserialize(pCurrData);
				continue;
			case 165:
				pCurrData += 4;
				pCurrData += _jumpMoveDistance.Deserialize(pCurrData);
				continue;
			case 166:
				pCurrData += 4;
				pCurrData += _combatStateToAdd.Deserialize(pCurrData);
				continue;
			case 167:
				pCurrData += 4;
				pCurrData += _combatStatePower.Deserialize(pCurrData);
				continue;
			case 168:
				pCurrData += 4;
				pCurrData += _breakBodyPartInjuryCount.Deserialize(pCurrData);
				continue;
			case 169:
				pCurrData += 4;
				pCurrData += _bodyPartIsBroken.Deserialize(pCurrData);
				continue;
			case 170:
				pCurrData += 4;
				pCurrData += _maxTrickCount.Deserialize(pCurrData);
				continue;
			case 171:
				pCurrData += 4;
				pCurrData += _maxBreathPercent.Deserialize(pCurrData);
				continue;
			case 172:
				pCurrData += 4;
				pCurrData += _maxStancePercent.Deserialize(pCurrData);
				continue;
			case 173:
				pCurrData += 4;
				pCurrData += _extraBreathPercent.Deserialize(pCurrData);
				continue;
			case 174:
				pCurrData += 4;
				pCurrData += _extraStancePercent.Deserialize(pCurrData);
				continue;
			case 175:
				pCurrData += 4;
				pCurrData += _moveCostMobility.Deserialize(pCurrData);
				continue;
			case 176:
				pCurrData += 4;
				pCurrData += _defendSkillKeepTime.Deserialize(pCurrData);
				continue;
			case 177:
				pCurrData += 4;
				pCurrData += _bounceRange.Deserialize(pCurrData);
				continue;
			case 178:
				pCurrData += 4;
				pCurrData += _mindMarkKeepTime.Deserialize(pCurrData);
				continue;
			case 179:
				pCurrData += 4;
				pCurrData += _skillMobilityCostPerFrame.Deserialize(pCurrData);
				continue;
			case 180:
				pCurrData += 4;
				pCurrData += _canAddWug.Deserialize(pCurrData);
				continue;
			case 181:
				pCurrData += 4;
				pCurrData += _hasGodWeaponBuff.Deserialize(pCurrData);
				continue;
			case 182:
				pCurrData += 4;
				pCurrData += _hasGodArmorBuff.Deserialize(pCurrData);
				continue;
			case 183:
				pCurrData += 4;
				pCurrData += _teammateCmdRequireGenerateValue.Deserialize(pCurrData);
				continue;
			case 184:
				pCurrData += 4;
				pCurrData += _teammateCmdEffect.Deserialize(pCurrData);
				continue;
			case 185:
				pCurrData += 4;
				pCurrData += _flawRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 186:
				pCurrData += 4;
				pCurrData += _acupointRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 187:
				pCurrData += 4;
				pCurrData += _mindMarkRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 188:
				pCurrData += 4;
				pCurrData += _injuryAutoHealSpeed.Deserialize(pCurrData);
				continue;
			case 189:
				pCurrData += 4;
				pCurrData += _canRecoverBreath.Deserialize(pCurrData);
				continue;
			case 190:
				pCurrData += 4;
				pCurrData += _canRecoverStance.Deserialize(pCurrData);
				continue;
			case 191:
				pCurrData += 4;
				pCurrData += _fatalDamageValue.Deserialize(pCurrData);
				continue;
			case 192:
				pCurrData += 4;
				pCurrData += _fatalDamageMarkCount.Deserialize(pCurrData);
				continue;
			case 193:
				pCurrData += 4;
				pCurrData += _canFightBackDuringPrepareSkill.Deserialize(pCurrData);
				continue;
			case 194:
				pCurrData += 4;
				pCurrData += _skillPrepareSpeed.Deserialize(pCurrData);
				continue;
			case 195:
				pCurrData += 4;
				pCurrData += _breathRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 196:
				pCurrData += 4;
				pCurrData += _stanceRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 197:
				pCurrData += 4;
				pCurrData += _mobilityRecoverSpeed.Deserialize(pCurrData);
				continue;
			case 198:
				pCurrData += 4;
				pCurrData += _changeTrickProgressAddValue.Deserialize(pCurrData);
				continue;
			case 199:
				pCurrData += 4;
				pCurrData += _power.Deserialize(pCurrData);
				continue;
			case 200:
				pCurrData += 4;
				pCurrData += _maxPower.Deserialize(pCurrData);
				continue;
			case 201:
				pCurrData += 4;
				pCurrData += _powerCanReduce.Deserialize(pCurrData);
				continue;
			case 202:
				pCurrData += 4;
				pCurrData += _useRequirement.Deserialize(pCurrData);
				continue;
			case 203:
				pCurrData += 4;
				pCurrData += _currInnerRatio.Deserialize(pCurrData);
				continue;
			case 204:
				pCurrData += 4;
				pCurrData += _costBreathAndStance.Deserialize(pCurrData);
				continue;
			case 205:
				pCurrData += 4;
				pCurrData += _costBreath.Deserialize(pCurrData);
				continue;
			case 206:
				pCurrData += 4;
				pCurrData += _costStance.Deserialize(pCurrData);
				continue;
			case 207:
				pCurrData += 4;
				pCurrData += _costMobility.Deserialize(pCurrData);
				continue;
			case 208:
				pCurrData += 4;
				pCurrData += _skillCostTricks.Deserialize(pCurrData);
				continue;
			case 209:
				pCurrData += 4;
				pCurrData += _effectDirection.Deserialize(pCurrData);
				continue;
			case 210:
				pCurrData += 4;
				pCurrData += _effectDirectionCanChange.Deserialize(pCurrData);
				continue;
			case 211:
				pCurrData += 4;
				pCurrData += _gridCost.Deserialize(pCurrData);
				continue;
			case 212:
				pCurrData += 4;
				pCurrData += _prepareTotalProgress.Deserialize(pCurrData);
				continue;
			case 213:
				pCurrData += 4;
				pCurrData += _specificGridCount.Deserialize(pCurrData);
				continue;
			case 214:
				pCurrData += 4;
				pCurrData += _genericGridCount.Deserialize(pCurrData);
				continue;
			case 215:
				pCurrData += 4;
				pCurrData += _canInterrupt.Deserialize(pCurrData);
				continue;
			case 216:
				pCurrData += 4;
				pCurrData += _interruptOdds.Deserialize(pCurrData);
				continue;
			case 217:
				pCurrData += 4;
				pCurrData += _canSilence.Deserialize(pCurrData);
				continue;
			case 218:
				pCurrData += 4;
				pCurrData += _silenceOdds.Deserialize(pCurrData);
				continue;
			case 219:
				pCurrData += 4;
				pCurrData += _canCastWithBrokenBodyPart.Deserialize(pCurrData);
				continue;
			case 220:
				pCurrData += 4;
				pCurrData += _addPowerCanBeRemoved.Deserialize(pCurrData);
				continue;
			case 221:
				pCurrData += 4;
				pCurrData += _skillType.Deserialize(pCurrData);
				continue;
			case 222:
				pCurrData += 4;
				pCurrData += _effectCountCanChange.Deserialize(pCurrData);
				continue;
			case 223:
				pCurrData += 4;
				pCurrData += _canCastInDefend.Deserialize(pCurrData);
				continue;
			case 224:
				pCurrData += 4;
				pCurrData += _hitDistribution.Deserialize(pCurrData);
				continue;
			case 225:
				pCurrData += 4;
				pCurrData += _canCastOnLackBreath.Deserialize(pCurrData);
				continue;
			case 226:
				pCurrData += 4;
				pCurrData += _canCastOnLackStance.Deserialize(pCurrData);
				continue;
			case 227:
				pCurrData += 4;
				pCurrData += _costBreathOnCast.Deserialize(pCurrData);
				continue;
			case 228:
				pCurrData += 4;
				pCurrData += _costStanceOnCast.Deserialize(pCurrData);
				continue;
			case 229:
				pCurrData += 4;
				pCurrData += _canUseMobilityAsBreath.Deserialize(pCurrData);
				continue;
			case 230:
				pCurrData += 4;
				pCurrData += _canUseMobilityAsStance.Deserialize(pCurrData);
				continue;
			case 231:
				pCurrData += 4;
				pCurrData += _castCostNeiliAllocation.Deserialize(pCurrData);
				continue;
			case 232:
				pCurrData += 4;
				pCurrData += _acceptPoisonResist.Deserialize(pCurrData);
				continue;
			case 233:
				pCurrData += 4;
				pCurrData += _makePoisonResist.Deserialize(pCurrData);
				continue;
			case 234:
				pCurrData += 4;
				pCurrData += _canCriticalHit.Deserialize(pCurrData);
				continue;
			case 235:
				pCurrData += 4;
				pCurrData += _canCostNeiliAllocationEffect.Deserialize(pCurrData);
				continue;
			case 236:
				pCurrData += 4;
				pCurrData += _consummateLevelRelatedMainAttributesHitValues.Deserialize(pCurrData);
				continue;
			case 237:
				pCurrData += 4;
				pCurrData += _consummateLevelRelatedMainAttributesAvoidValues.Deserialize(pCurrData);
				continue;
			case 238:
				pCurrData += 4;
				pCurrData += _consummateLevelRelatedMainAttributesPenetrations.Deserialize(pCurrData);
				continue;
			case 239:
				pCurrData += 4;
				pCurrData += _consummateLevelRelatedMainAttributesPenetrationResists.Deserialize(pCurrData);
				continue;
			case 240:
				pCurrData += 4;
				pCurrData += _skillAlsoAsFiveElements.Deserialize(pCurrData);
				continue;
			case 241:
				pCurrData += 4;
				pCurrData += _innerInjuryImmunity.Deserialize(pCurrData);
				continue;
			case 242:
				pCurrData += 4;
				pCurrData += _outerInjuryImmunity.Deserialize(pCurrData);
				continue;
			case 243:
				pCurrData += 4;
				pCurrData += _poisonAffectThreshold.Deserialize(pCurrData);
				continue;
			case 244:
				pCurrData += 4;
				pCurrData += _lockDistance.Deserialize(pCurrData);
				continue;
			case 245:
				pCurrData += 4;
				pCurrData += _resistOfAllPoison.Deserialize(pCurrData);
				continue;
			case 246:
				pCurrData += 4;
				pCurrData += _makePoisonTarget.Deserialize(pCurrData);
				continue;
			case 247:
				pCurrData += 4;
				pCurrData += _acceptPoisonTarget.Deserialize(pCurrData);
				continue;
			case 248:
				pCurrData += 4;
				pCurrData += _certainCriticalHit.Deserialize(pCurrData);
				continue;
			case 249:
				pCurrData += 4;
				pCurrData += _mindMarkCount.Deserialize(pCurrData);
				continue;
			case 250:
				pCurrData += 4;
				pCurrData += _canFightBackWithHit.Deserialize(pCurrData);
				continue;
			case 251:
				pCurrData += 4;
				pCurrData += _inevitableHit.Deserialize(pCurrData);
				continue;
			case 252:
				pCurrData += 4;
				pCurrData += _attackCanPursue.Deserialize(pCurrData);
				continue;
			case 253:
				pCurrData += 4;
				pCurrData += _combatSkillDataEffectList.Deserialize(pCurrData);
				continue;
			case 254:
				pCurrData += 4;
				pCurrData += _stanceCostByEffect.Deserialize(pCurrData);
				continue;
			case 255:
				pCurrData += 4;
				pCurrData += _breathCostByEffect.Deserialize(pCurrData);
				continue;
			case 256:
				pCurrData += 4;
				pCurrData += _powerAddRatio.Deserialize(pCurrData);
				continue;
			case 257:
				pCurrData += 4;
				pCurrData += _powerReduceRatio.Deserialize(pCurrData);
				continue;
			case 258:
				pCurrData += 4;
				pCurrData += _poisonAffectProduceValue.Deserialize(pCurrData);
				continue;
			case 259:
				pCurrData += 4;
				pCurrData += _canReadingOnMonthChange.Deserialize(pCurrData);
				continue;
			case 260:
				pCurrData += 4;
				pCurrData += _medicineEffect.Deserialize(pCurrData);
				continue;
			case 261:
				pCurrData += 4;
				pCurrData += _xiangshuInfectionDelta.Deserialize(pCurrData);
				continue;
			case 262:
				pCurrData += 4;
				pCurrData += _healthDelta.Deserialize(pCurrData);
				continue;
			case 263:
				pCurrData += 4;
				pCurrData += _weaponSilenceFrame.Deserialize(pCurrData);
				continue;
			case 264:
				pCurrData += 4;
				pCurrData += _silenceFrame.Deserialize(pCurrData);
				continue;
			case 265:
				pCurrData += 4;
				pCurrData += _currAgeDelta.Deserialize(pCurrData);
				continue;
			case 266:
				pCurrData += 4;
				pCurrData += _goneMadInAllBreak.Deserialize(pCurrData);
				continue;
			case 267:
				pCurrData += 4;
				pCurrData += _makeLoveRateOnMonthChange.Deserialize(pCurrData);
				continue;
			case 268:
				pCurrData += 4;
				pCurrData += _canAutoHealOnMonthChange.Deserialize(pCurrData);
				continue;
			case 269:
				pCurrData += 4;
				pCurrData += _happinessDelta.Deserialize(pCurrData);
				continue;
			case 270:
				pCurrData += 4;
				pCurrData += _teammateCmdCanUse.Deserialize(pCurrData);
				continue;
			case 271:
				pCurrData += 4;
				pCurrData += _mixPoisonInfinityAffect.Deserialize(pCurrData);
				continue;
			case 272:
				pCurrData += 4;
				pCurrData += _attackRangeMaxAcupoint.Deserialize(pCurrData);
				continue;
			case 273:
				pCurrData += 4;
				pCurrData += _maxMobilityPercent.Deserialize(pCurrData);
				continue;
			case 274:
				pCurrData += 4;
				pCurrData += _makeMindDamage.Deserialize(pCurrData);
				continue;
			case 275:
				pCurrData += 4;
				pCurrData += _acceptMindDamage.Deserialize(pCurrData);
				continue;
			case 276:
				pCurrData += 4;
				pCurrData += _hitAddByTempValue.Deserialize(pCurrData);
				continue;
			case 277:
				pCurrData += 4;
				pCurrData += _avoidAddByTempValue.Deserialize(pCurrData);
				continue;
			case 278:
				pCurrData += 4;
				pCurrData += _ignoreEquipmentOverload.Deserialize(pCurrData);
				continue;
			case 279:
				pCurrData += 4;
				pCurrData += _canCostEnemyUsableTricks.Deserialize(pCurrData);
				continue;
			case 280:
				pCurrData += 4;
				pCurrData += _ignoreArmor.Deserialize(pCurrData);
				continue;
			case 281:
				pCurrData += 4;
				pCurrData += _unyieldingFallen.Deserialize(pCurrData);
				continue;
			case 282:
				pCurrData += 4;
				pCurrData += _normalAttackPrepareFrame.Deserialize(pCurrData);
				continue;
			case 283:
				pCurrData += 4;
				pCurrData += _canCostUselessTricks.Deserialize(pCurrData);
				continue;
			case 284:
				pCurrData += 4;
				pCurrData += _defendSkillCanAffect.Deserialize(pCurrData);
				continue;
			case 285:
				pCurrData += 4;
				pCurrData += _assistSkillCanAffect.Deserialize(pCurrData);
				continue;
			case 286:
				pCurrData += 4;
				pCurrData += _agileSkillCanAffect.Deserialize(pCurrData);
				continue;
			case 287:
				pCurrData += 4;
				pCurrData += _allMarkChangeToMind.Deserialize(pCurrData);
				continue;
			case 288:
				pCurrData += 4;
				pCurrData += _mindMarkChangeToFatal.Deserialize(pCurrData);
				continue;
			case 289:
				pCurrData += 4;
				pCurrData += _canCast.Deserialize(pCurrData);
				continue;
			case 290:
				pCurrData += 4;
				pCurrData += _inevitableAvoid.Deserialize(pCurrData);
				continue;
			case 291:
				pCurrData += 4;
				pCurrData += _powerEffectReverse.Deserialize(pCurrData);
				continue;
			case 292:
				pCurrData += 4;
				pCurrData += _featureBonusReverse.Deserialize(pCurrData);
				continue;
			case 293:
				pCurrData += 4;
				pCurrData += _wugFatalDamageValue.Deserialize(pCurrData);
				continue;
			case 294:
				pCurrData += 4;
				pCurrData += _canRecoverHealthOnMonthChange.Deserialize(pCurrData);
				continue;
			case 295:
				pCurrData += 4;
				pCurrData += _takeRevengeRateOnMonthChange.Deserialize(pCurrData);
				continue;
			case 296:
				pCurrData += 4;
				pCurrData += _consummateLevelBonus.Deserialize(pCurrData);
				continue;
			case 297:
				pCurrData += 4;
				pCurrData += _neiliDelta.Deserialize(pCurrData);
				continue;
			case 298:
				pCurrData += 4;
				pCurrData += _canMakeLoveSpecialOnMonthChange.Deserialize(pCurrData);
				continue;
			case 299:
				pCurrData += 4;
				pCurrData += _healAcupointSpeed.Deserialize(pCurrData);
				continue;
			case 300:
				pCurrData += 4;
				pCurrData += _maxChangeTrickCount.Deserialize(pCurrData);
				continue;
			case 301:
				pCurrData += 4;
				pCurrData += _convertCostBreathAndStance.Deserialize(pCurrData);
				continue;
			case 302:
				pCurrData += 4;
				pCurrData += _personalitiesAll.Deserialize(pCurrData);
				continue;
			case 303:
				pCurrData += 4;
				pCurrData += _finalFatalDamageMarkCount.Deserialize(pCurrData);
				continue;
			case 304:
				pCurrData += 4;
				pCurrData += _combatSkillAiScorePower.Deserialize(pCurrData);
				continue;
			case 305:
				pCurrData += 4;
				pCurrData += _normalAttackChangeToUnlockAttack.Deserialize(pCurrData);
				continue;
			case 306:
				pCurrData += 4;
				pCurrData += _attackBodyPartOdds.Deserialize(pCurrData);
				continue;
			case 307:
				pCurrData += 4;
				pCurrData += _changeDurability.Deserialize(pCurrData);
				continue;
			case 308:
				pCurrData += 4;
				pCurrData += _equipmentBonus.Deserialize(pCurrData);
				continue;
			case 309:
				pCurrData += 4;
				pCurrData += _equipmentWeight.Deserialize(pCurrData);
				continue;
			case 310:
				pCurrData += 4;
				pCurrData += _rawCreateEffectList.Deserialize(pCurrData);
				continue;
			case 311:
				pCurrData += 4;
				pCurrData += _jiTrickAsWeaponTrickCount.Deserialize(pCurrData);
				continue;
			case 312:
				pCurrData += 4;
				pCurrData += _uselessTrickAsJiTrickCount.Deserialize(pCurrData);
				continue;
			case 313:
				pCurrData += 4;
				pCurrData += _equipmentPower.Deserialize(pCurrData);
				continue;
			case 314:
				pCurrData += 4;
				pCurrData += _healFlawSpeed.Deserialize(pCurrData);
				continue;
			case 315:
				pCurrData += 4;
				pCurrData += _unlockSpeed.Deserialize(pCurrData);
				continue;
			case 316:
				pCurrData += 4;
				pCurrData += _flawBonusFactor.Deserialize(pCurrData);
				continue;
			case 317:
				pCurrData += 4;
				pCurrData += _canCostShaTricks.Deserialize(pCurrData);
				continue;
			case 318:
				pCurrData += 4;
				pCurrData += _defenderDirectFinalDamageValue.Deserialize(pCurrData);
				continue;
			case 319:
				pCurrData += 4;
				pCurrData += _normalAttackRecoveryFrame.Deserialize(pCurrData);
				continue;
			case 320:
				pCurrData += 4;
				pCurrData += _finalGoneMadInjury.Deserialize(pCurrData);
				continue;
			case 321:
				pCurrData += 4;
				pCurrData += _attackerDirectFinalDamageValue.Deserialize(pCurrData);
				continue;
			case 322:
				pCurrData += 4;
				pCurrData += _canCostTrickDuringPreparingSkill.Deserialize(pCurrData);
				continue;
			case 323:
				pCurrData += 4;
				pCurrData += _validItemList.Deserialize(pCurrData);
				continue;
			case 324:
				pCurrData += 4;
				pCurrData += _acceptDamageCanAdd.Deserialize(pCurrData);
				continue;
			case 325:
				pCurrData += 4;
				pCurrData += _makeDamageCanReduce.Deserialize(pCurrData);
				continue;
			case 326:
				pCurrData += 4;
				pCurrData += _normalAttackGetTrickCount.Deserialize(pCurrData);
				continue;
			case 327:
				pCurrData += 4;
				pCurrData += _stayEffectCountOnAddPhase.Deserialize(pCurrData);
				continue;
			case 328:
				pCurrData += 4;
				pCurrData += _healInjuryWithFatalRequireAttainment.Deserialize(pCurrData);
				continue;
			case 329:
				pCurrData += 4;
				pCurrData += _useItemCostNoWisdom.Deserialize(pCurrData);
				continue;
			case 330:
				pCurrData += 4;
				pCurrData += _mindUpheavalTime.Deserialize(pCurrData);
				continue;
			case 331:
				pCurrData += 4;
				pCurrData += _makeHarmfulActionSuccessRate.Deserialize(pCurrData);
				continue;
			case 332:
				pCurrData += 4;
				pCurrData += _acceptHarmfulActionSuccessRate.Deserialize(pCurrData);
				continue;
			case 333:
				pCurrData += 4;
				pCurrData += _makeFatalDamage.Deserialize(pCurrData);
				continue;
			case 334:
				pCurrData += 4;
				pCurrData += _acceptFatalDamage.Deserialize(pCurrData);
				continue;
			case 335:
				pCurrData += 4;
				pCurrData += _causedInjuryChangeToOldOdds.Deserialize(pCurrData);
				continue;
			case 336:
				pCurrData += 4;
				pCurrData += _causedMindChangeToInfiniteOdds.Deserialize(pCurrData);
				continue;
			case 337:
				pCurrData += 4;
				pCurrData += _hitReduceDurability.Deserialize(pCurrData);
				continue;
			case 338:
				pCurrData += 4;
				pCurrData += _equipmentMasteryAffectOdds.Deserialize(pCurrData);
				continue;
			case 339:
				pCurrData += 4;
				pCurrData += _criticalDamage.Deserialize(pCurrData);
				continue;
			case 340:
				pCurrData += 4;
				pCurrData += _canFightBackOutOfAttackRange.Deserialize(pCurrData);
				continue;
			case 341:
				pCurrData += 4;
				pCurrData += _attackerCriticalOdds.Deserialize(pCurrData);
				continue;
			case 342:
				pCurrData += 4;
				pCurrData += _defenderCriticalOdds.Deserialize(pCurrData);
				continue;
			case 343:
				pCurrData += 4;
				pCurrData += _mixPoisonCanAffectCount.Deserialize(pCurrData);
				continue;
			case 344:
				pCurrData += 4;
				pCurrData += _castCostNeiliAllocationIsAbsorb.Deserialize(pCurrData);
				continue;
			case 345:
				pCurrData += 4;
				pCurrData += _acceptInjuryChangeToOldOdds.Deserialize(pCurrData);
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
