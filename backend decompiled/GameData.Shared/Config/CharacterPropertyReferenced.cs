using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterPropertyReferenced : ConfigData<CharacterPropertyReferencedItem, short>
{
	public static CharacterPropertyReferenced Instance = new CharacterPropertyReferenced();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayType", "TemplateId", "Type" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new CharacterPropertyReferencedItem(0, ECharacterPropertyReferencedType.Strength, 0, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(1, ECharacterPropertyReferencedType.Dexterity, 1, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(2, ECharacterPropertyReferencedType.Concentration, 2, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(3, ECharacterPropertyReferencedType.Vitality, 3, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(4, ECharacterPropertyReferencedType.Energy, 4, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(5, ECharacterPropertyReferencedType.Intelligence, 5, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(6, ECharacterPropertyReferencedType.HitRateStrength, 6, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(7, ECharacterPropertyReferencedType.HitRateTechnique, 7, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(8, ECharacterPropertyReferencedType.HitRateSpeed, 8, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(9, ECharacterPropertyReferencedType.HitRateMind, 9, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(10, ECharacterPropertyReferencedType.PenetrateOfOuter, 10, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(11, ECharacterPropertyReferencedType.PenetrateOfInner, 11, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(12, ECharacterPropertyReferencedType.AvoidRateStrength, 12, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(13, ECharacterPropertyReferencedType.AvoidRateTechnique, 13, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(14, ECharacterPropertyReferencedType.AvoidRateSpeed, 14, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(15, ECharacterPropertyReferencedType.AvoidRateMind, 15, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(16, ECharacterPropertyReferencedType.PenetrateResistOfOuter, 16, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(17, ECharacterPropertyReferencedType.PenetrateResistOfInner, 17, boostedByPower: true, featureStandardIsAdd: false, legendaryBookIsAdd: false, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(18, ECharacterPropertyReferencedType.RecoveryOfStance, 18, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(19, ECharacterPropertyReferencedType.RecoveryOfBreath, 19, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(20, ECharacterPropertyReferencedType.MoveSpeed, 20, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(21, ECharacterPropertyReferencedType.RecoveryOfFlaw, 21, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(22, ECharacterPropertyReferencedType.CastSpeed, 22, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(23, ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint, 23, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(24, ECharacterPropertyReferencedType.WeaponSwitchSpeed, 24, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(25, ECharacterPropertyReferencedType.AttackSpeed, 25, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(26, ECharacterPropertyReferencedType.InnerRatio, 26, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(27, ECharacterPropertyReferencedType.RecoveryOfQiDisorder, 27, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(28, ECharacterPropertyReferencedType.ResistOfHotPoison, 28, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(29, ECharacterPropertyReferencedType.ResistOfGloomyPoison, 29, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(30, ECharacterPropertyReferencedType.ResistOfColdPoison, 30, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(31, ECharacterPropertyReferencedType.ResistOfRedPoison, 31, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(32, ECharacterPropertyReferencedType.ResistOfRottenPoison, 32, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(33, ECharacterPropertyReferencedType.ResistOfIllusoryPoison, 33, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(34, ECharacterPropertyReferencedType.QualificationMusic, 34, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(35, ECharacterPropertyReferencedType.QualificationChess, 35, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(36, ECharacterPropertyReferencedType.QualificationPoem, 36, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(37, ECharacterPropertyReferencedType.QualificationPainting, 37, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(38, ECharacterPropertyReferencedType.QualificationMath, 38, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(39, ECharacterPropertyReferencedType.QualificationAppraisal, 39, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(40, ECharacterPropertyReferencedType.QualificationForging, 40, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(41, ECharacterPropertyReferencedType.QualificationWoodworking, 41, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(42, ECharacterPropertyReferencedType.QualificationMedicine, 42, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(43, ECharacterPropertyReferencedType.QualificationToxicology, 43, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(44, ECharacterPropertyReferencedType.QualificationWeaving, 44, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(45, ECharacterPropertyReferencedType.QualificationJade, 45, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(46, ECharacterPropertyReferencedType.QualificationTaoism, 46, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(47, ECharacterPropertyReferencedType.QualificationBuddhism, 47, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(48, ECharacterPropertyReferencedType.QualificationCooking, 48, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(49, ECharacterPropertyReferencedType.QualificationEclectic, 49, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(50, ECharacterPropertyReferencedType.AttainmentMusic, 50, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(51, ECharacterPropertyReferencedType.AttainmentChess, 51, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(52, ECharacterPropertyReferencedType.AttainmentPoem, 52, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(53, ECharacterPropertyReferencedType.AttainmentPainting, 53, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(54, ECharacterPropertyReferencedType.AttainmentMath, 54, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(55, ECharacterPropertyReferencedType.AttainmentAppraisal, 55, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(56, ECharacterPropertyReferencedType.AttainmentForging, 56, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(57, ECharacterPropertyReferencedType.AttainmentWoodworking, 57, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(58, ECharacterPropertyReferencedType.AttainmentMedicine, 58, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(59, ECharacterPropertyReferencedType.AttainmentToxicology, 59, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CharacterPropertyReferencedItem(60, ECharacterPropertyReferencedType.AttainmentWeaving, 60, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(61, ECharacterPropertyReferencedType.AttainmentJade, 61, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(62, ECharacterPropertyReferencedType.AttainmentTaoism, 62, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(63, ECharacterPropertyReferencedType.AttainmentBuddhism, 63, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(64, ECharacterPropertyReferencedType.AttainmentCooking, 64, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(65, ECharacterPropertyReferencedType.AttainmentEclectic, 65, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(66, ECharacterPropertyReferencedType.QualificationNeigong, 66, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(67, ECharacterPropertyReferencedType.QualificationPosing, 67, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(68, ECharacterPropertyReferencedType.QualificationStunt, 68, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(69, ECharacterPropertyReferencedType.QualificationFistAndPalm, 69, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(70, ECharacterPropertyReferencedType.QualificationFinger, 70, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(71, ECharacterPropertyReferencedType.QualificationLeg, 71, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(72, ECharacterPropertyReferencedType.QualificationThrow, 72, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(73, ECharacterPropertyReferencedType.QualificationSword, 73, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(74, ECharacterPropertyReferencedType.QualificationBlade, 74, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(75, ECharacterPropertyReferencedType.QualificationPolearm, 75, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(76, ECharacterPropertyReferencedType.QualificationSpecial, 76, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(77, ECharacterPropertyReferencedType.QualificationWhip, 77, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(78, ECharacterPropertyReferencedType.QualificationControllableShot, 78, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(79, ECharacterPropertyReferencedType.QualificationCombatMusic, 79, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(80, ECharacterPropertyReferencedType.AttainmentNeigong, 80, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(81, ECharacterPropertyReferencedType.AttainmentPosing, 81, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(82, ECharacterPropertyReferencedType.AttainmentStunt, 82, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(83, ECharacterPropertyReferencedType.AttainmentFistAndPalm, 83, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(84, ECharacterPropertyReferencedType.AttainmentFinger, 84, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(85, ECharacterPropertyReferencedType.AttainmentLeg, 85, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(86, ECharacterPropertyReferencedType.AttainmentThrow, 86, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(87, ECharacterPropertyReferencedType.AttainmentSword, 87, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(88, ECharacterPropertyReferencedType.AttainmentBlade, 88, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(89, ECharacterPropertyReferencedType.AttainmentPolearm, 89, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(90, ECharacterPropertyReferencedType.AttainmentSpecial, 90, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(91, ECharacterPropertyReferencedType.AttainmentWhip, 91, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(92, ECharacterPropertyReferencedType.AttainmentControllableShot, 92, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(93, ECharacterPropertyReferencedType.AttainmentCombatMusic, 93, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(94, ECharacterPropertyReferencedType.PersonalityCalm, 94, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(95, ECharacterPropertyReferencedType.PersonalityClever, 95, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(96, ECharacterPropertyReferencedType.PersonalityEnthusiastic, 96, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(97, ECharacterPropertyReferencedType.PersonalityBrave, 97, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(98, ECharacterPropertyReferencedType.PersonalityFirm, 98, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(99, ECharacterPropertyReferencedType.PersonalityLucky, 99, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(100, ECharacterPropertyReferencedType.PersonalityPerceptive, 100, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(101, ECharacterPropertyReferencedType.Attraction, 101, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(102, ECharacterPropertyReferencedType.Fertility, 102, boostedByPower: true, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(103, ECharacterPropertyReferencedType.HobbyChangingPeriod, 103, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(104, ECharacterPropertyReferencedType.MaxHealth, 105, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(105, ECharacterPropertyReferencedType.MaxNeili, 106, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(106, ECharacterPropertyReferencedType.AttainmentDivinePower, 107, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(107, ECharacterPropertyReferencedType.AttainmentGhostTechnique, 108, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(108, ECharacterPropertyReferencedType.LifeSkillBookReadEfficiency, 109, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(109, ECharacterPropertyReferencedType.CombatSkillBookReadEfficiency, 110, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(110, ECharacterPropertyReferencedType.CombatSkillProficiency, 111, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(111, ECharacterPropertyReferencedType.CricketLuckPoint, 112, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(112, ECharacterPropertyReferencedType.RecoveryStrength, 113, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(113, ECharacterPropertyReferencedType.RecoveryDexterity, 114, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(114, ECharacterPropertyReferencedType.RecoveryConcentration, 115, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(115, ECharacterPropertyReferencedType.RecoveryVitality, 116, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(116, ECharacterPropertyReferencedType.RecoveryEnergy, 117, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(117, ECharacterPropertyReferencedType.RecoveryIntelligence, 118, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(118, ECharacterPropertyReferencedType.BaseDamageStep, 119, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(119, ECharacterPropertyReferencedType.BreakStepNeigong, 120, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CharacterPropertyReferencedItem(120, ECharacterPropertyReferencedType.BreakStepPosing, 121, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(121, ECharacterPropertyReferencedType.BreakStepStunt, 122, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(122, ECharacterPropertyReferencedType.BreakStepFistAndPalm, 123, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(123, ECharacterPropertyReferencedType.BreakStepFinger, 124, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(124, ECharacterPropertyReferencedType.BreakStepLeg, 125, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(125, ECharacterPropertyReferencedType.BreakStepThrow, 126, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(126, ECharacterPropertyReferencedType.BreakStepSword, 127, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(127, ECharacterPropertyReferencedType.BreakStepBlade, 128, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(128, ECharacterPropertyReferencedType.BreakStepPolearm, 129, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(129, ECharacterPropertyReferencedType.BreakStepSpecial, 130, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(130, ECharacterPropertyReferencedType.BreakStepWhip, 131, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(131, ECharacterPropertyReferencedType.BreakStepControllableShot, 132, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(132, ECharacterPropertyReferencedType.BreakStepCombatMusic, 133, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(133, ECharacterPropertyReferencedType.ConfessingLoveSuccessOdds, 134, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(134, ECharacterPropertyReferencedType.InnateGenericGrid, 135, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(135, ECharacterPropertyReferencedType.MysteryItemCompatibility, 136, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(136, ECharacterPropertyReferencedType.SkillPowerNeigong, 137, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(137, ECharacterPropertyReferencedType.SkillPowerAttack, 138, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(138, ECharacterPropertyReferencedType.SkillPowerAgile, 139, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(139, ECharacterPropertyReferencedType.SkillPowerDefense, 140, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(140, ECharacterPropertyReferencedType.SkillPowerAssist, 141, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(141, ECharacterPropertyReferencedType.BaseDamageStepOuterHead, 142, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(142, ECharacterPropertyReferencedType.BaseDamageStepOuterChest, 143, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(143, ECharacterPropertyReferencedType.BaseDamageStepOuterHand, 144, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(144, ECharacterPropertyReferencedType.BaseDamageStepOuterBelly, 145, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(145, ECharacterPropertyReferencedType.BaseDamageStepOuterLeg, 146, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(146, ECharacterPropertyReferencedType.BaseDamageStepInnerHead, 147, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(147, ECharacterPropertyReferencedType.BaseDamageStepInnerChest, 148, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(148, ECharacterPropertyReferencedType.BaseDamageStepInnerHand, 149, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(149, ECharacterPropertyReferencedType.BaseDamageStepInnerBelly, 150, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(150, ECharacterPropertyReferencedType.BaseDamageStepInnerLeg, 151, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(151, ECharacterPropertyReferencedType.BaseDamageStepFatal, 152, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(152, ECharacterPropertyReferencedType.BaseDamageStepMind, 153, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(153, ECharacterPropertyReferencedType.Wisdom, 154, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(154, ECharacterPropertyReferencedType.NeiliAllocationAddSpeed, 155, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(155, ECharacterPropertyReferencedType.NeiliAllocationReduceSpeed, 156, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(156, ECharacterPropertyReferencedType.SkillSlotCountNeigong, 157, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(157, ECharacterPropertyReferencedType.SkillSlotCountAttack, 158, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(158, ECharacterPropertyReferencedType.SkillSlotCountAgile, 159, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(159, ECharacterPropertyReferencedType.SkillSlotCountDefense, 160, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(160, ECharacterPropertyReferencedType.SkillSlotCountAssist, 161, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: false));
		_dataArray.Add(new CharacterPropertyReferencedItem(161, ECharacterPropertyReferencedType.RecoveryStrengthMonthly, 113, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
		_dataArray.Add(new CharacterPropertyReferencedItem(162, ECharacterPropertyReferencedType.RecoveryDexterityMonthly, 114, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
		_dataArray.Add(new CharacterPropertyReferencedItem(163, ECharacterPropertyReferencedType.RecoveryConcentrationMonthly, 115, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
		_dataArray.Add(new CharacterPropertyReferencedItem(164, ECharacterPropertyReferencedType.RecoveryVitalityMonthly, 116, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
		_dataArray.Add(new CharacterPropertyReferencedItem(165, ECharacterPropertyReferencedType.RecoveryEnergyMonthly, 117, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
		_dataArray.Add(new CharacterPropertyReferencedItem(166, ECharacterPropertyReferencedType.RecoveryIntelligenceMonthly, 118, boostedByPower: false, featureStandardIsAdd: true, legendaryBookIsAdd: true, isMonthly: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterPropertyReferencedItem>(167);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
