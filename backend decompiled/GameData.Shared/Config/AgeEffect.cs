using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class AgeEffect : ConfigData<AgeEffectItem, sbyte>
{
	public static AgeEffect Instance = new AgeEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "SkillQualificationPrecocious", "SkillQualificationLateBlooming", "FertilityMale", "FertilityFemale" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AgeEffectItem(0, 0, 15, -20, new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -100, -100));
		_dataArray.Add(new AgeEffectItem(1, 0, 15, -20, new MainAttributes(0, 0, 0, 0, 0, 10), new MainAttributes(0, 0, 0, 0, 0, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(2, 0, 15, -20, new MainAttributes(0, 0, 0, 0, 0, 20), new MainAttributes(0, 0, 0, 0, 0, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(3, 0, 15, -20, new MainAttributes(10, 10, 10, 10, 10, 30), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(4, 0, 15, -20, new MainAttributes(15, 15, 15, 15, 15, 40), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(5, 0, 15, -18, new MainAttributes(20, 20, 20, 20, 20, 50), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(6, 0, 15, -18, new MainAttributes(25, 25, 25, 25, 25, 60), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(7, 0, 15, -18, new MainAttributes(30, 30, 30, 30, 30, 70), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(8, 0, 15, -18, new MainAttributes(35, 35, 35, 35, 35, 80), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(9, 0, 15, -18, new MainAttributes(40, 40, 40, 40, 40, 90), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(10, 0, 15, -16, new MainAttributes(45, 45, 45, 45, 45, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(11, 0, 15, -16, new MainAttributes(50, 50, 50, 50, 50, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(12, 0, 15, -16, new MainAttributes(60, 60, 60, 60, 60, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(13, 0, 15, -16, new MainAttributes(70, 70, 70, 70, 70, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(14, 0, 15, -16, new MainAttributes(80, 80, 80, 80, 80, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(15, 0, 14, -14, new MainAttributes(90, 90, 90, 90, 90, 100), new MainAttributes(100, 100, 20, 100, 30, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(16, 0, 14, -14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 30, 100, 40, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(17, 0, 14, -14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 30, 100, 40, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(18, 0, 14, -14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 30, 100, 40, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(19, 0, 14, -14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 30, 100, 40, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(20, 0, 13, -12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 40, 100, 50, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(21, 0, 13, -12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 40, 100, 50, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(22, 0, 13, -12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 40, 100, 50, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(23, 0, 13, -12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 40, 100, 50, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(24, 0, 13, -12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 40, 100, 50, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(25, 0, 12, -10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 50, 100, 60, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(26, 0, 12, -10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 50, 100, 60, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(27, 0, 12, -10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 50, 100, 60, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(28, 0, 12, -10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 50, 100, 60, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(29, 0, 12, -10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 50, 100, 60, 100), 0, 0));
		_dataArray.Add(new AgeEffectItem(30, 0, 11, 10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 60, 100, 70, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(31, 0, 11, 10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 60, 100, 70, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(32, 0, 11, 10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 60, 100, 70, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(33, 0, 11, 10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 60, 100, 70, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(34, 0, 11, 10, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 60, 100, 70, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(35, 0, 10, 12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 70, 100, 80, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(36, 0, 10, 12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 70, 100, 80, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(37, 0, 10, 12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 70, 100, 80, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(38, 0, 10, 12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 70, 100, 80, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(39, 0, 10, 12, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 70, 100, 80, 100), 0, -25));
		_dataArray.Add(new AgeEffectItem(40, 0, -10, 14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 80, 70, 90, 100), -25, -50));
		_dataArray.Add(new AgeEffectItem(41, 0, -10, 14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 80, 70, 90, 100), -25, -50));
		_dataArray.Add(new AgeEffectItem(42, 0, -10, 14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 80, 70, 90, 100), -25, -50));
		_dataArray.Add(new AgeEffectItem(43, 0, -10, 14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 80, 70, 90, 100), -25, -50));
		_dataArray.Add(new AgeEffectItem(44, 0, -10, 14, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 80, 70, 90, 100), -25, -50));
		_dataArray.Add(new AgeEffectItem(45, 0, -11, 16, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 90, 70, 100, 100), -25, -75));
		_dataArray.Add(new AgeEffectItem(46, 0, -11, 16, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 90, 70, 100, 100), -25, -75));
		_dataArray.Add(new AgeEffectItem(47, 0, -11, 16, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 90, 70, 100, 100), -25, -75));
		_dataArray.Add(new AgeEffectItem(48, 0, -11, 16, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 90, 70, 100, 100), -25, -75));
		_dataArray.Add(new AgeEffectItem(49, 0, -11, 16, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 100, 90, 70, 100, 100), -25, -75));
		_dataArray.Add(new AgeEffectItem(50, 0, -12, 18, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(51, 0, -12, 18, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(52, 0, -12, 18, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(53, 0, -12, 18, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(54, 0, -12, 18, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(55, 0, -13, 20, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(56, 0, -13, 20, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(57, 0, -13, 20, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(58, 0, -13, 20, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
		_dataArray.Add(new AgeEffectItem(59, 0, -13, 20, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(100, 70, 100, 60, 100, 100), -50, -100));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AgeEffectItem(60, 0, -14, 22, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(61, 0, -14, 22, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(62, 0, -14, 22, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(63, 0, -14, 22, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(64, 0, -14, 22, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(65, 0, -15, 24, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(66, 0, -15, 24, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(67, 0, -15, 24, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(68, 0, -15, 24, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(69, 0, -15, 24, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(70, 60, 100, 50, 100, 100), -75, -100));
		_dataArray.Add(new AgeEffectItem(70, 0, -16, 26, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(71, 0, -16, 26, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(72, 0, -16, 26, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(73, 0, -16, 26, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(74, 0, -16, 26, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(75, 0, -17, 28, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(76, 0, -17, 28, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(77, 0, -17, 28, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(78, 0, -17, 28, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(79, 0, -17, 28, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(60, 50, 100, 40, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(80, 0, -18, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(81, 0, -18, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(82, 0, -18, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(83, 0, -18, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(84, 0, -18, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(85, 0, -19, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(86, 0, -19, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(87, 0, -19, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(88, 0, -19, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(89, 0, -19, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(50, 40, 100, 30, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(90, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(91, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(92, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(93, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(94, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(95, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(96, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(97, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(98, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(99, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(40, 30, 100, 20, 100, 100), -100, -100));
		_dataArray.Add(new AgeEffectItem(100, 0, -20, 30, new MainAttributes(100, 100, 100, 100, 100, 100), new MainAttributes(30, 20, 100, 10, 100, 100), -100, -100));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AgeEffectItem>(101);
		CreateItems0();
		CreateItems1();
	}
}
