using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Boss : ConfigData<BossItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte XiangShu = 9;

		public const sbyte RanChenZi = 10;

		public const sbyte HuanXin = 11;

		public const sbyte RealXiangshu = 14;

		public const sbyte Tiandi = 15;
	}

	public static class DefValue
	{
		public static BossItem XiangShu => Instance[(sbyte)9];

		public static BossItem RanChenZi => Instance[(sbyte)10];

		public static BossItem HuanXin => Instance[(sbyte)11];

		public static BossItem RealXiangshu => Instance[(sbyte)14];

		public static BossItem Tiandi => Instance[(sbyte)15];
	}

	public static Boss Instance = new Boss();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"CharacterIdList", "CombatConfig", "PhaseAttackSkills", "PhaseWeapons", "FailPlayerAssetSkill", "PlayerCastSkills", "TemplateId", "AssetFileName", "AniPrefix", "DefendSkillParticlePrefix",
		"DefendSkillSoundPrefix", "PetAniPrefix", "AttackDistances", "AttackAnimation", "AttackParticles", "AttackSounds", "AttackEffectPostfix", "EatParticles", "TopicalParticles", "FailAnimation",
		"FailParticles", "FailSounds", "JumpMoveParticles", "FailPlayerAni", "FailAniDistance", "DynamicIllustration", "ShadowTexture", "ShadowPos", "IllustrationUnlockParticle"
	};

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
		_dataArray.Add(new BossItem(0, new short[20]
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 120,
			121, 122, 123, 124, 125, 126, 127, 128, 210, 1304
		}, "boss1", new List<string> { "boss1_", "boss1_angry_" }, new List<string> { "Particle_boss1_", "Particle_boss1_angry_" }, new List<string> { "se_boss1_", "se_boss1_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 24, 40, 60 },
			new sbyte[3] { 25, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss1_A_000_0", "Particle_boss1_angry_A_000_0" }, new List<string> { "se_boss1_A_000_0", "se_boss1_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss1_C_020", "Particle_boss1_angry_C_020" }, new List<string> { "Particle_boss1_C_021", "Particle_boss1_angry_C_021" }, "C_005", new List<string> { "Particle_boss1_C_005", "Particle_boss1_angry_C_005" }, new List<string> { "se_boss1_C_005", "se_boss1_angry_C_005" }, new string[1] { "" }, new List<short> { 54 }, new List<short[]>
		{
			new short[3] { 804, 805, 806 },
			new short[3] { 807, 808, 809 }
		}, hasSceneChangeEffect: true, new List<string> { "Particle_boss1_M_003_fly", "Particle_boss1_M_004_fly" }, null, null, null, -1, new List<short> { 804, 805, 807, 808 }, new List<string> { "character_boss1/character_boss1_SkeletonData", "character_boss1_joy/character_boss1_joy_SkeletonData", "character_boss1_sad/character_boss1_sad_SkeletonData", "character_bosskid1/character_bosskid1_SkeletonData", "character_bosskid1_joy/character_bosskid1_joy_SkeletonData", "character_bosskid1_sad/character_bosskid1_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2001", "tw_ui_tt_hj_ren_2001_joy", "tw_ui_tt_hj_ren_2001_sad", "gamelinescroll_npcface_kid_2001", "tw_ui_tt_hj_kid_2001_joy", "tw_ui_tt_hj_kid_2001_sad" }, new List<short[]>
		{
			new short[2] { -30, 208 },
			new short[2] { -57, 196 },
			new short[2] { -28, 127 },
			new short[2] { 0, 93 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2001", "eff_Gamelinescroll_ui_huijuan_xs_rensad2001", "eff_Gamelinescroll_ui_huijuan_xs_kid2001", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2001" }));
		_dataArray.Add(new BossItem(1, new short[20]
		{
			48, 49, 50, 51, 52, 53, 54, 55, 56, 129,
			130, 131, 132, 133, 134, 135, 136, 137, 211, 1305
		}, "boss2", new List<string> { "boss2_", "boss2_angry_" }, new List<string> { "Particle_boss2_", "Particle_boss2_angry_" }, new List<string> { "se_boss2_", "se_boss2_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 33, 53, 73 },
			new sbyte[3] { 35, 53, 73 }
		}, "A_000_0", new List<string> { "Particle_boss2_A_000_0", "Particle_boss2_angry_A_000_0" }, new List<string> { "se_boss2_A_000_0", "se_boss2_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss2_C_020", "Particle_boss2_angry_C_020" }, new List<string> { "Particle_boss2_C_021", "Particle_boss2_angry_C_021" }, "C_005", new List<string> { "Particle_boss2_C_005", "Particle_boss2_angry_C_005" }, new List<string> { "se_boss2_C_005", "se_boss2_angry_C_005" }, new string[1] { "" }, new List<short> { 55 }, new List<short[]>
		{
			new short[3] { 810, 811, 812 },
			new short[3] { 813, 814, 815 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 810, 811, 813, 814 }, new List<string> { "character_boss2/character_boss2_SkeletonData", "character_boss2_joy/character_boss2_joy_SkeletonData", "character_boss2_sad/character_boss2_sad_SkeletonData", "character_bosskid2/character_bosskid2_SkeletonData", "character_bosskid2_joy/character_bosskid2_joy_SkeletonData", "character_bosskid2_sad/character_bosskid2_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2002", "tw_ui_tt_hj_ren_2002_joy", "tw_ui_tt_hj_ren_2002_sad", "gamelinescroll_npcface_kid_2002", "tw_ui_tt_hj_kid_2002_joy", "tw_ui_tt_hj_kid_2002_sad" }, new List<short[]>
		{
			new short[2] { -108, 203 },
			new short[2] { -22, 194 },
			new short[2] { -26, 168 },
			new short[2] { 30, 190 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2002", "eff_Gamelinescroll_ui_huijuan_xs_rensad2002", "eff_Gamelinescroll_ui_huijuan_xs_kid2002", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2002" }));
		_dataArray.Add(new BossItem(2, new short[20]
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 138,
			139, 140, 141, 142, 143, 144, 145, 146, 212, 1306
		}, "boss3", new List<string> { "boss3_", "boss3_angry_" }, new List<string> { "Particle_boss3_", "Particle_boss3_angry_" }, new List<string> { "se_boss3_", "se_boss3_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 22, 40, 60 },
			new sbyte[3] { 24, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss3_A_000_0", "Particle_boss3_angry_A_000_0" }, new List<string> { "se_boss3_A_000_0", "se_boss3_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss3_C_020", "Particle_boss3_angry_C_020" }, new List<string> { "Particle_boss3_C_021", "Particle_boss3_angry_C_021" }, "C_005", new List<string> { "Particle_boss3_C_005", "Particle_boss3_angry_C_005" }, new List<string> { "se_boss3_C_005", "se_boss3_angry_C_005" }, new string[1] { "" }, new List<short> { 56 }, new List<short[]>
		{
			new short[3] { 816, 817, 818 },
			new short[3] { 819, 820, 821 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 816, 818, 819, 821 }, new List<string> { "character_boss3/character_boss3_SkeletonData", "character_boss3_joy/character_boss3_joy_SkeletonData", "character_boss3_sad/character_boss3_sad_SkeletonData", "character_bosskid3/character_bosskid3_SkeletonData", "character_bosskid3_joy/character_bosskid3_joy_SkeletonData", "character_bosskid3_sad/character_bosskid3_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2003", "tw_ui_tt_hj_ren_2003_joy", "tw_ui_tt_hj_ren_2003_sad", "gamelinescroll_npcface_kid_2003", "tw_ui_tt_hj_kid_2003_joy", "tw_ui_tt_hj_kid_2003_sad" }, new List<short[]>
		{
			new short[2] { -49, 238 },
			new short[2] { -11, 195 },
			new short[2] { -24, 176 },
			new short[2] { -40, 164 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2003", "eff_Gamelinescroll_ui_huijuan_xs_rensad2003", "eff_Gamelinescroll_ui_huijuan_xs_kid2003", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2003" }));
		_dataArray.Add(new BossItem(3, new short[20]
		{
			66, 67, 68, 69, 70, 71, 72, 73, 74, 147,
			148, 149, 150, 151, 152, 153, 154, 155, 213, 1307
		}, "boss4", new List<string> { "boss4_", "boss4_angry_" }, new List<string> { "Particle_boss4_", "Particle_boss4_angry_" }, new List<string> { "se_boss4_", "se_boss4_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 23, 40, 60 },
			new sbyte[3] { 17, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss4_A_000_0", "Particle_boss4_angry_A_000_0" }, new List<string> { "se_boss4_A_000_0", "se_boss4_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss4_C_020", "Particle_boss4_angry_C_020" }, new List<string> { "Particle_boss4_C_021", "Particle_boss4_angry_C_021" }, "C_005", new List<string> { "Particle_boss4_C_005", "Particle_boss4_angry_C_005" }, new List<string> { "se_boss4_C_005", "se_boss4_angry_C_005" }, new string[1] { "" }, new List<short> { 57 }, new List<short[]>
		{
			new short[3] { 822, 823, 824 },
			new short[3] { 825, 826, 827 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 822, 824, 825, 827 }, new List<string> { "character_boss4/character_boss4_SkeletonData", "character_boss4_joy/character_boss4_joy_SkeletonData", "character_boss4_sad/character_boss4_sad_SkeletonData", "character_bosskid4/character_bosskid4_SkeletonData", "character_bosskid4_joy/character_bosskid4_joy_SkeletonData", "character_bosskid4_sad/character_bosskid4_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2004", "tw_ui_tt_hj_ren_2004_joy", "tw_ui_tt_hj_ren_2004_sad", "gamelinescroll_npcface_kid_2004", "tw_ui_tt_hj_kid_2004_joy", "tw_ui_tt_hj_kid_2004_sad" }, new List<short[]>
		{
			new short[2] { -18, 174 },
			new short[2] { 9, 183 },
			new short[2] { -44, 140 },
			new short[2] { -49, 144 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2004", "eff_Gamelinescroll_ui_huijuan_xs_rensad2004", "eff_Gamelinescroll_ui_huijuan_xs_kid2004", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2004" }));
		_dataArray.Add(new BossItem(4, new short[20]
		{
			75, 76, 77, 78, 79, 80, 81, 82, 83, 156,
			157, 158, 159, 160, 161, 162, 163, 164, 214, 1308
		}, "boss5", new List<string> { "boss5_", "boss5_angry_" }, new List<string> { "Particle_boss5_", "Particle_boss5_angry_" }, new List<string> { "se_boss5_", "se_boss5_angry_" }, new List<string> { "fox_", "fox_angry_" }, new List<sbyte[]>
		{
			new sbyte[3] { 11, 40, 60 },
			new sbyte[3] { 19, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss5_A_000_0", "Particle_boss5_angry_A_000_0" }, new List<string> { "se_boss5_A_000_0", "se_boss5_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss5_C_020", "Particle_boss5_angry_C_020" }, new List<string> { "Particle_boss5_C_021", "Particle_boss5_angry_C_021" }, "C_005", new List<string> { "Particle_boss5_C_005", "Particle_boss5_angry_C_005" }, new List<string> { "se_boss5_C_005", "se_boss5_angry_C_005" }, new string[2] { "Particle_boss5_fox_C_005", "Particle_boss5_fox_angry_C_005" }, new List<short> { 58 }, new List<short[]>
		{
			new short[3] { 828, 829, 830 },
			new short[3] { 831, 832, 833 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 828, 829, 831, 832 }, new List<string> { "character_boss5/character_boss5_SkeletonData", "character_boss5_joy/character_boss5_joy_SkeletonData", "character_boss5_sad/character_boss5_sad_SkeletonData", "character_bosskid5/character_bosskid5_SkeletonData", "character_bosskid5_joy/character_bosskid5_joy_SkeletonData", "character_bosskid5_sad/character_bosskid5_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2005", "tw_ui_tt_hj_ren_2005_joy", "tw_ui_tt_hj_ren_2005_sad", "gamelinescroll_npcface_kid_2005", "tw_ui_tt_hj_kid_2005_joy", "tw_ui_tt_hj_kid_2005_sad" }, new List<short[]>
		{
			new short[2] { 25, 178 },
			new short[2] { -38, 182 },
			new short[2] { -24, 191 },
			new short[2] { -50, 150 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2005", "eff_Gamelinescroll_ui_huijuan_xs_rensad2005", "eff_Gamelinescroll_ui_huijuan_xs_kid2005", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2005" }));
		_dataArray.Add(new BossItem(5, new short[20]
		{
			84, 85, 86, 87, 88, 89, 90, 91, 92, 165,
			166, 167, 168, 169, 170, 171, 172, 173, 215, 1309
		}, "boss6", new List<string> { "boss6_", "boss6_angry_" }, new List<string> { "Particle_boss6_", "Particle_boss6_angry_" }, new List<string> { "se_boss6_", "se_boss6_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 35, 40, 70 },
			new sbyte[3] { 38, 50, 70 }
		}, "A_000_0", new List<string> { "Particle_boss6_A_000_0", "Particle_boss6_angry_A_000_0" }, new List<string> { "se_boss6_A_000_0", "se_boss6_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss6_C_020", "Particle_boss6_angry_C_020" }, new List<string> { "Particle_boss6_C_021", "Particle_boss6_angry_C_021" }, "C_005", new List<string> { "Particle_boss6_C_005", "Particle_boss6_angry_C_005" }, new List<string> { "se_boss6_C_005", "se_boss6_angry_C_005" }, new string[1] { "" }, new List<short> { 59 }, new List<short[]>
		{
			new short[3] { 834, 835, 836 },
			new short[3] { 837, 838, 839 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 835, 834, 838, 837 }, new List<string> { "character_boss6/character_boss6_SkeletonData", "character_boss6_joy/character_boss6_joy_SkeletonData", "character_boss6_sad/character_boss6_sad_SkeletonData", "character_bosskid6/character_bosskid6_SkeletonData", "character_bosskid6_joy/character_bosskid6_joy_SkeletonData", "character_bosskid6_sad/character_bosskid6_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2006", "tw_ui_tt_hj_ren_2006_joy", "tw_ui_tt_hj_ren_2006_sad", "gamelinescroll_npcface_kid_2006", "tw_ui_tt_hj_kid_2006_joy", "tw_ui_tt_hj_kid_2006_sad" }, new List<short[]>
		{
			new short[2] { -29, 168 },
			new short[2] { -16, 211 },
			new short[2] { -38, 159 },
			new short[2] { -42, 162 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2006", "eff_Gamelinescroll_ui_huijuan_xs_rensad2006", "eff_Gamelinescroll_ui_huijuan_xs_kid2006", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2006" }));
		_dataArray.Add(new BossItem(6, new short[20]
		{
			93, 94, 95, 96, 97, 98, 99, 100, 101, 174,
			175, 176, 177, 178, 179, 180, 181, 182, 216, 1310
		}, "boss7", new List<string> { "boss7_", "boss7_angry_" }, new List<string> { "Particle_boss7_", "Particle_boss7_angry_" }, new List<string> { "se_boss7_", "se_boss7_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 17, 40, 60 },
			new sbyte[3] { 18, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss7_A_000_0", "Particle_boss7_angry_A_000_0" }, new List<string> { "se_boss7_A_000_0", "se_boss7_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss7_C_020", "Particle_boss7_angry_C_020" }, new List<string> { "Particle_boss7_C_021", "Particle_boss7_angry_C_021" }, "C_005", new List<string> { "Particle_boss7_C_005", "Particle_boss7_angry_C_005" }, new List<string> { "se_boss7_C_005", "se_boss7_angry_C_005" }, new string[1] { "" }, new List<short> { 60 }, new List<short[]>
		{
			new short[3] { 840, 841, 842 },
			new short[3] { 843, 844, 845 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 841, 840, 844, 843 }, new List<string> { "character_boss7/character_boss7_SkeletonData", "character_boss7_joy/character_boss7_joy_SkeletonData", "character_boss7_sad/character_boss7_sad_SkeletonData", "character_bosskid7/character_bosskid7_SkeletonData", "character_bosskid7_joy/character_bosskid7_joy_SkeletonData", "character_bosskid7_sad/character_bosskid7_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2007", "tw_ui_tt_hj_ren_2007_joy", "tw_ui_tt_hj_ren_2007_sad", "gamelinescroll_npcface_kid_2007", "tw_ui_tt_hj_kid_2007_joy", "tw_ui_tt_hj_kid_2007_sad" }, new List<short[]>
		{
			new short[2] { 8, 183 },
			new short[2] { -5, 188 },
			new short[2] { -35, 134 },
			new short[2] { -25, 148 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2007", "eff_Gamelinescroll_ui_huijuan_xs_rensad2007", "eff_Gamelinescroll_ui_huijuan_xs_kid2007", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2007" }));
		_dataArray.Add(new BossItem(7, new short[20]
		{
			102, 103, 104, 105, 106, 107, 108, 109, 110, 183,
			184, 185, 186, 187, 188, 189, 190, 191, 217, 1311
		}, "boss8", new List<string> { "boss8_", "boss8_angry_" }, new List<string> { "Particle_boss8_", "Particle_boss8_angry_" }, new List<string> { "se_boss8_", "se_boss8_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 20, 40, 60 },
			new sbyte[3] { 22, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss8_A_000_0", "Particle_boss8_angry_A_000_0" }, new List<string> { "se_boss8_A_000_0", "se_boss8_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss8_C_020", "Particle_boss8_angry_C_020" }, new List<string> { "Particle_boss8_C_021", "Particle_boss8_angry_C_021" }, "C_005", new List<string> { "Particle_boss8_C_005", "Particle_boss8_angry_C_005" }, new List<string> { "se_boss8_C_005", "se_boss8_angry_C_005" }, new string[1] { "" }, new List<short> { 61 }, new List<short[]>
		{
			new short[3] { 846, 847, 848 },
			new short[3] { 849, 850, 851 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 847, 846, 850, 849 }, new List<string> { "character_boss8/character_boss8_SkeletonData", "character_boss8_joy/character_boss8_joy_SkeletonData", "character_boss8_sad/character_boss8_sad_SkeletonData", "character_bosskid8/character_bosskid8_SkeletonData", "character_bosskid8_joy/character_bosskid8_joy_SkeletonData", "character_bosskid9_sad/character_bosskid8_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2008", "tw_ui_tt_hj_ren_2008_joy", "tw_ui_tt_hj_ren_2008_sad", "gamelinescroll_npcface_kid_2008", "tw_ui_tt_hj_kid_2008_joy", "tw_ui_tt_hj_kid_2008_sad" }, new List<short[]>
		{
			new short[2] { -55, 210 },
			new short[2] { -36, 220 },
			new short[2] { -23, 166 },
			new short[2] { -11, 193 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2008", "eff_Gamelinescroll_ui_huijuan_xs_rensad2008", "eff_Gamelinescroll_ui_huijuan_xs_kid2008", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2008" }));
		_dataArray.Add(new BossItem(8, new short[20]
		{
			111, 112, 113, 114, 115, 116, 117, 118, 119, 192,
			193, 194, 195, 196, 197, 198, 199, 200, 218, 1312
		}, "boss9", new List<string> { "boss9_", "boss9_angry_" }, new List<string> { "Particle_boss9_", "Particle_boss9_angry_" }, new List<string> { "se_boss9_", "se_boss9_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 32, 45, 60 },
			new sbyte[3] { 30, 45, 60 }
		}, "A_000_0", new List<string> { "Particle_boss9_A_000_0", "Particle_boss9_angry_A_000_0" }, new List<string> { "se_boss9_A_000_0", "se_boss9_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss9_C_020", "Particle_boss9_angry_C_020" }, new List<string> { "Particle_boss9_C_021", "Particle_boss9_angry_C_021" }, "C_005", new List<string> { "Particle_boss9_C_005", "Particle_boss9_angry_C_005" }, new List<string> { "se_boss9_C_005", "se_boss9_angry_C_005" }, new string[1] { "" }, new List<short> { 62 }, new List<short[]>
		{
			new short[3] { 852, 853, 854 },
			new short[3] { 855, 856, 857 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short> { 852, 853, 855, 856 }, new List<string> { "character_boss9/character_boss9_SkeletonData", "character_boss9_joy/character_boss9_joy_SkeletonData", "character_boss9_sad/character_boss9_sad_SkeletonData", "character_bosskid9/character_bosskid9_SkeletonData", "character_bosskid9_joy/character_bosskid9_joy_SkeletonData", "character_bosskid9_sad/character_bosskid9_sad_SkeletonData" }, new List<string> { "gamelinescroll_npcface_2009", "tw_ui_tt_hj_ren_2009_joy", "tw_ui_tt_hj_ren_2009_sad", "gamelinescroll_npcface_kid_2009", "tw_ui_tt_hj_kid_2009_joy", "tw_ui_tt_hj_kid_2009_sad" }, new List<short[]>
		{
			new short[2] { -25, 156 },
			new short[2] { -10, 143 },
			new short[2] { -8, 102 },
			new short[2] { -11, 164 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren2009", "eff_Gamelinescroll_ui_huijuan_xs_rensad2009", "eff_Gamelinescroll_ui_huijuan_xs_kid2009", "eff_Gamelinescroll_ui_huijuan_xs_kidsad2009" }));
		_dataArray.Add(new BossItem(9, new short[3] { 904, 905, 1339 }, "boss10", new List<string> { "boss10_", "boss10_angry_" }, new List<string> { "Particle_boss10_", "Particle_boss10_angry_" }, new List<string> { "se_boss10_", "se_boss10_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 20, 40, 60 },
			new sbyte[3] { 25, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss10_A_000_0", "Particle_boss10_angry_A_000_0" }, new List<string> { "se_boss10_A_000_0", "se_boss10_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss10_C_020", "Particle_boss10_angry_C_020" }, new List<string> { "Particle_boss10_C_021", "Particle_boss10_angry_C_021" }, "C_005", new List<string> { "Particle_boss10_C_005", "Particle_boss10_angry_C_005" }, new List<string> { "se_boss10_C_005", "se_boss10_angry_C_005" }, new string[1] { "" }, new List<short> { 72 }, new List<short[]>
		{
			new short[3] { 858, 859, 860 },
			new short[3] { 861, 862, 863 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short>(), null, null, null, null));
		_dataArray.Add(new BossItem(10, new short[3] { 918, 1342, 1315 }, "boss11", new List<string> { "boss11_step1_", "boss11_step2_", "boss11_step3_", "boss11_step4_", "boss11_step5_", "boss11_step6_" }, new List<string> { "Particle_boss11_step1_", "Particle_boss11_step2_", "Particle_boss11_step3_", "Particle_boss11_step4_", "Particle_boss11_step5_", "Particle_boss11_step6_" }, new List<string> { "se_boss11_step1_", "se_boss11_step2_", "se_boss11_step3_", "se_boss11_step4_", "se_boss11_step5_", "se_boss11_step6_" }, null, new List<sbyte[]>
		{
			new sbyte[1] { 16 },
			new sbyte[1] { 15 },
			new sbyte[1] { 27 },
			new sbyte[1] { 18 },
			new sbyte[1] { 22 },
			new sbyte[1] { 40 }
		}, "A_000_0", new List<string> { "Particle_boss11_step1_A_000_0", "Particle_boss11_step2_A_000_0", "Particle_boss11_step3_A_000_0", "Particle_boss11_step4_A_000_0", "Particle_boss11_step5_A_000_0", "Particle_boss11_step6_A_000_0" }, new List<string> { "se_boss11_step1_A_000_0", "se_boss11_step2_A_000_0", "se_boss11_step3_A_000_0", "se_boss11_step4_A_000_0", "se_boss11_step5_A_000_0", "se_boss11_step6_A_000_0" }, new List<string> { "", "", "" }, new List<string> { "Particle_boss11_step1_C_020", "Particle_boss11_step2_C_020", "Particle_boss11_step3_C_020", "Particle_boss11_step4_C_020", "Particle_boss11_step5_C_020", "Particle_boss11_step6_C_020" }, new List<string> { "Particle_boss11_step1_C_021", "Particle_boss11_step2_C_021", "Particle_boss11_step3_C_021", "Particle_boss11_step4_C_021", "Particle_boss11_step5_C_021", "Particle_boss11_step6_C_021" }, "C_005", new List<string> { "Particle_boss11_step1_C_005", "Particle_boss11_step2_C_005", "Particle_boss11_step3_C_005", "Particle_boss11_step4_C_005", "Particle_boss11_step5_C_005", "Particle_boss11_step6_C_005" }, new List<string> { "se_boss11_step1_C_005", "se_boss11_step2_C_005", "se_boss11_step3_C_005", "se_boss11_step4_C_005", "se_boss11_step5_C_005", "se_boss11_step6_C_005" }, new string[1] { "" }, new List<short> { 73 }, new List<short[]>
		{
			new short[1] { 864 },
			new short[1] { 865 },
			new short[1] { 866 },
			new short[1] { 867 },
			new short[1] { 868 },
			new short[1] { 869 }
		}, hasSceneChangeEffect: true, null, new List<short[]>
		{
			new short[1] { 876 },
			new short[1] { 877 },
			new short[1] { 878 },
			new short[1] { 879 },
			new short[1] { 880 },
			new short[1] { 881 }
		}, new List<string> { "S_boss11_step1_C_005", "S_boss11_step2_C_005", "S_boss11_step3_C_005", "S_boss11_step4_C_005", "S_boss11_step5_C_005" }, new List<sbyte> { 40, 40, 40, 70, 16 }, 864, new List<short>(), new List<string> { "", "character_boss11_joy/ranchenzi_dedao_SkeletonData", "character_boss11_sad/ranchenzi_rumo_SkeletonData" }, new List<string> { "gamelinescroll_npcface_107", "tw_ui_tt_hj_ren_107_joy", "tw_ui_tt_hj_ren_107_sad" }, new List<short[]>
		{
			new short[2] { -27, 207 },
			new short[2] { -13, 180 }
		}, new List<string> { "eff_Gamelinescroll_ui_huijuan_xs_ren107", "eff_Gamelinescroll_ui_huijuan_xs_rensad107" }));
		_dataArray.Add(new BossItem(11, new short[1] { 910 }, "boss12", new List<string> { "boss12_", "boss12_angry_" }, new List<string> { "Particle_boss12_", "Particle_boss12_angry_" }, new List<string> { "se_boss12_", "se_boss12_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 18, 40, 60 },
			new sbyte[3] { 20, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss12_A_000_0", "Particle_boss12_angry_A_000_0" }, new List<string> { "se_boss12_A_000_0", "se_boss12_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss12_C_020", "Particle_boss12_angry_C_020" }, new List<string> { "Particle_boss12_C_021", "Particle_boss12_angry_C_021" }, "C_005", new List<string> { "Particle_boss12_C_005", "Particle_boss12_angry_C_005" }, new List<string> { "se_boss12_C_005", "se_boss12_angry_C_005" }, new string[1] { "" }, new List<short> { 74 }, new List<short[]>
		{
			new short[3] { 870, 871, 872 },
			new short[3] { 873, 874, 875 }
		}, hasSceneChangeEffect: false, null, null, null, null, -1, new List<short>(), null, null, null, null));
		_dataArray.Add(new BossItem(12, new short[3] { 913, 1340, 1313 }, "boss13", new List<string> { "boss13_", "boss13_angry_" }, new List<string> { "Particle_boss13_", "Particle_boss13_angry_" }, new List<string> { "se_boss13_", "se_boss13_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 20, 40, 60 },
			new sbyte[3] { 20, 40, 60 }
		}, "A_000_0", new List<string> { "Particle_boss13_A_000_0", "Particle_boss13_angry_A_000_0" }, new List<string> { "se_boss13_A_000_0", "se_boss13_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss13_C_020", "Particle_boss13_angry_C_020" }, new List<string> { "Particle_boss13_C_021", "Particle_boss13_angry_C_021" }, "C_005", new List<string> { "Particle_boss13_C_005", "Particle_boss13_angry_C_005" }, new List<string> { "se_boss13_C_005", "se_boss13_angry_C_005" }, new string[1] { "" }, new List<short> { 75 }, new List<short[]>
		{
			new short[3] { 876, 877, 878 },
			new short[3] { 879, 880, 881 }
		}, hasSceneChangeEffect: false, null, null, null, null, -1, new List<short>(), null, null, null, null));
		_dataArray.Add(new BossItem(13, new short[3] { 1182, 1341, 1314 }, "boss14", new List<string> { "boss14_", "boss14_angry_" }, new List<string> { "Particle_boss14_", "Particle_boss14_angry_" }, new List<string> { "se_boss14_", "se_boss14_angry_" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 20, 50, 70 },
			new sbyte[3] { 20, 50, 70 }
		}, "A_000_0", new List<string> { "Particle_boss14_A_000_0", "Particle_boss14_angry_A_000_0" }, new List<string> { "se_boss14_A_000_0", "se_boss14_angry_A_000_0" }, new List<string> { "", "b", "c" }, new List<string> { "Particle_boss14_C_020", "Particle_boss14_angry_C_020" }, new List<string> { "Particle_boss14_C_021", "Particle_boss14_angry_C_021" }, "C_005", new List<string> { "Particle_boss14_C_005", "Particle_boss14_angry_C_005" }, new List<string> { "se_boss14_C_005", "se_boss14_angry_C_005" }, new string[1] { "" }, new List<short> { 76 }, new List<short[]>
		{
			new short[3] { 882, 883, 884 },
			new short[3] { 885, 886, 887 }
		}, hasSceneChangeEffect: false, null, null, null, null, -1, new List<short>(), null, null, null, null));
		_dataArray.Add(new BossItem(14, new short[1] { 1174 }, "boss18", new List<string> { "boss18_", "boss18_1_" }, new List<string> { "Particle_boss18_", "Particle_boss18_1_" }, new List<string> { "se_boss18_1_", "se_boss18_1" }, null, new List<sbyte[]>
		{
			new sbyte[3] { 40, 50, 63 },
			new sbyte[3] { 40, 50, 63 }
		}, "A_000_0", new List<string> { "Particle_boss18_1_A_000_0", "Particle_boss18_1_A_000_0" }, new List<string> { "se_boss18_1_A_000_0", "se_boss18_1_A_000_0" }, new List<string> { "", "b", "c" }, null, null, "C_005", new List<string> { "Particle_boss18_C_005", "" }, new List<string> { "se_boss18_C_005", "se_boss18_1_C_005" }, new string[1] { "" }, new List<short> { 251 }, new List<short[]>
		{
			new short[3] { 861, 862, 863 },
			new short[3] { 941, 942, 943 }
		}, hasSceneChangeEffect: true, null, null, null, null, -1, new List<short>(), null, null, null, null));
		_dataArray.Add(new BossItem(15, new short[2] { 1113, 1338 }, "boss16", new List<string> { "boss16_", "boss16_" }, new List<string> { "Particle_boss16_", "Particle_boss16_" }, new List<string> { "se_boss16_", "se_boss16_" }, null, new List<sbyte[]>
		{
			new sbyte[2] { 40, 85 },
			new sbyte[2] { 40, 85 }
		}, "A_000_0", new List<string> { "Particle_boss16_A_000_0", "Particle_boss16_A_000_0" }, new List<string> { "se_boss16_A_000_0", "se_boss16_A_000_0" }, new List<string> { "", "b" }, null, null, "C_005", new List<string> { "Particle_boss16_C_005", "Particle_boss16_C_005" }, new List<string> { "se_boss16_C_005", "se_boss16_C_005" }, new string[1] { "" }, new List<short> { 252, 263 }, new List<short[]>
		{
			new short[2] { 944, 945 },
			new short[4] { 944, 945, 948, 949 }
		}, hasSceneChangeEffect: false, null, null, null, null, -1, new List<short>(), null, null, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BossItem>(16);
		CreateItems0();
	}
}
