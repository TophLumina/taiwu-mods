using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakBonusEffect : ConfigData<SkillBreakBonusEffectItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 音律技艺书
		/// </summary>
		public const sbyte MusicBook = 0;

		/// <summary>
		/// 弈棋技艺书
		/// </summary>
		public const sbyte ChessBook = 1;

		/// <summary>
		/// 诗书技艺书
		/// </summary>
		public const sbyte PoemBook = 2;

		/// <summary>
		/// 绘画技艺书
		/// </summary>
		public const sbyte PaintingBook = 3;

		/// <summary>
		/// 医术技艺书
		/// </summary>
		public const sbyte MedicineBook = 4;

		/// <summary>
		/// 毒术技艺书
		/// </summary>
		public const sbyte ToxicologyBook = 5;

		/// <summary>
		/// 锻造技艺书
		/// </summary>
		public const sbyte ForgingBook = 6;

		/// <summary>
		/// 制木技艺书
		/// </summary>
		public const sbyte WoodWorkingBook = 7;

		/// <summary>
		/// 织锦技艺书
		/// </summary>
		public const sbyte WeavingBook = 8;

		/// <summary>
		/// 巧匠技艺书
		/// </summary>
		public const sbyte JadeBook = 9;

		/// <summary>
		/// 术数技艺书
		/// </summary>
		public const sbyte MathBook = 10;

		/// <summary>
		/// 品鉴技艺书
		/// </summary>
		public const sbyte AppraisalBook = 11;

		/// <summary>
		/// 厨艺技艺书
		/// </summary>
		public const sbyte CookingBook = 12;

		/// <summary>
		/// 杂学技艺书
		/// </summary>
		public const sbyte EclecticBook = 13;

		/// <summary>
		/// 佛学技艺书
		/// </summary>
		public const sbyte BuddhismBook = 14;

		/// <summary>
		/// 道法技艺书
		/// </summary>
		public const sbyte TaoismBook = 15;

		/// <summary>
		/// 外伤丹药
		/// </summary>
		public const sbyte HealInjuryOuter = 16;

		/// <summary>
		/// 内伤丹药
		/// </summary>
		public const sbyte HealInjuryInner = 17;

		/// <summary>
		/// 解毒丹药
		/// </summary>
		public const sbyte HealPoison = 18;

		/// <summary>
		/// 内息丹药
		/// </summary>
		public const sbyte HealQiDisorder = 19;

		/// <summary>
		/// 健康丹药
		/// </summary>
		public const sbyte HealHealth = 20;

		/// <summary>
		/// 攻击丹药
		/// </summary>
		public const sbyte Attack = 21;

		/// <summary>
		/// 防御丹药
		/// </summary>
		public const sbyte Defence = 22;

		/// <summary>
		/// 命中丹药
		/// </summary>
		public const sbyte HitValue = 23;

		/// <summary>
		/// 化解丹药
		/// </summary>
		public const sbyte AvoidValue = 24;

		/// <summary>
		/// 气势丹药
		/// </summary>
		public const sbyte BreathStance = 25;

		/// <summary>
		/// 施展丹药
		/// </summary>
		public const sbyte Cast = 26;

		/// <summary>
		/// 移速丹药
		/// </summary>
		public const sbyte MoveSpeed = 27;

		/// <summary>
		/// 攻速丹药
		/// </summary>
		public const sbyte AttackSpeed = 28;

		/// <summary>
		/// 金铁引子
		/// </summary>
		public const sbyte MetalMaterial = 29;

		/// <summary>
		/// 木材引子
		/// </summary>
		public const sbyte WoodMaterial = 30;

		/// <summary>
		/// 玉石引子
		/// </summary>
		public const sbyte JadeMaterial = 31;

		/// <summary>
		/// 织锦引子
		/// </summary>
		public const sbyte FabricMaterial = 32;

		/// <summary>
		/// 相互爱慕的人物
		/// </summary>
		public const sbyte RelationAdore = 33;

		/// <summary>
		/// 相互仇恨的人物
		/// </summary>
		public const sbyte RelationEnemy = 34;

		/// <summary>
		/// 水果
		/// </summary>
		public const sbyte Fruit = 35;

		/// <summary>
		/// 茶
		/// </summary>
		public const sbyte Tea = 36;

		/// <summary>
		/// 历练
		/// </summary>
		public const sbyte Exp = 37;

		/// <summary>
		/// 食物
		/// </summary>
		public const sbyte Food = 38;

		/// <summary>
		/// 酒
		/// </summary>
		public const sbyte Wine = 39;

		/// <summary>
		/// 血露
		/// </summary>
		public const sbyte BloodDew = 40;

		/// <summary>
		/// 烈毒毒药
		/// </summary>
		public const sbyte HotPoison = 41;

		/// <summary>
		/// 郁毒毒药
		/// </summary>
		public const sbyte GloomyPoison = 42;

		/// <summary>
		/// 赤毒毒药
		/// </summary>
		public const sbyte RedPoison = 43;

		/// <summary>
		/// 寒毒毒药
		/// </summary>
		public const sbyte ColdPoison = 44;

		/// <summary>
		/// 腐毒毒药
		/// </summary>
		public const sbyte RottenPoison = 45;

		/// <summary>
		/// 幻毒毒药
		/// </summary>
		public const sbyte IllusoryPoison = 46;

		/// <summary>
		/// 亲友
		/// </summary>
		public const sbyte Friend = 47;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 音律技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem MusicBook => Instance[(sbyte)0];

		/// <summary>
		/// 弈棋技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem ChessBook => Instance[(sbyte)1];

		/// <summary>
		/// 诗书技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem PoemBook => Instance[(sbyte)2];

		/// <summary>
		/// 绘画技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem PaintingBook => Instance[(sbyte)3];

		/// <summary>
		/// 医术技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem MedicineBook => Instance[(sbyte)4];

		/// <summary>
		/// 毒术技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem ToxicologyBook => Instance[(sbyte)5];

		/// <summary>
		/// 锻造技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem ForgingBook => Instance[(sbyte)6];

		/// <summary>
		/// 制木技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem WoodWorkingBook => Instance[(sbyte)7];

		/// <summary>
		/// 织锦技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem WeavingBook => Instance[(sbyte)8];

		/// <summary>
		/// 巧匠技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem JadeBook => Instance[(sbyte)9];

		/// <summary>
		/// 术数技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem MathBook => Instance[(sbyte)10];

		/// <summary>
		/// 品鉴技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem AppraisalBook => Instance[(sbyte)11];

		/// <summary>
		/// 厨艺技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem CookingBook => Instance[(sbyte)12];

		/// <summary>
		/// 杂学技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem EclecticBook => Instance[(sbyte)13];

		/// <summary>
		/// 佛学技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem BuddhismBook => Instance[(sbyte)14];

		/// <summary>
		/// 道法技艺书
		/// </summary>
		public static SkillBreakBonusEffectItem TaoismBook => Instance[(sbyte)15];

		/// <summary>
		/// 外伤丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HealInjuryOuter => Instance[(sbyte)16];

		/// <summary>
		/// 内伤丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HealInjuryInner => Instance[(sbyte)17];

		/// <summary>
		/// 解毒丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HealPoison => Instance[(sbyte)18];

		/// <summary>
		/// 内息丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HealQiDisorder => Instance[(sbyte)19];

		/// <summary>
		/// 健康丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HealHealth => Instance[(sbyte)20];

		/// <summary>
		/// 攻击丹药
		/// </summary>
		public static SkillBreakBonusEffectItem Attack => Instance[(sbyte)21];

		/// <summary>
		/// 防御丹药
		/// </summary>
		public static SkillBreakBonusEffectItem Defence => Instance[(sbyte)22];

		/// <summary>
		/// 命中丹药
		/// </summary>
		public static SkillBreakBonusEffectItem HitValue => Instance[(sbyte)23];

		/// <summary>
		/// 化解丹药
		/// </summary>
		public static SkillBreakBonusEffectItem AvoidValue => Instance[(sbyte)24];

		/// <summary>
		/// 气势丹药
		/// </summary>
		public static SkillBreakBonusEffectItem BreathStance => Instance[(sbyte)25];

		/// <summary>
		/// 施展丹药
		/// </summary>
		public static SkillBreakBonusEffectItem Cast => Instance[(sbyte)26];

		/// <summary>
		/// 移速丹药
		/// </summary>
		public static SkillBreakBonusEffectItem MoveSpeed => Instance[(sbyte)27];

		/// <summary>
		/// 攻速丹药
		/// </summary>
		public static SkillBreakBonusEffectItem AttackSpeed => Instance[(sbyte)28];

		/// <summary>
		/// 金铁引子
		/// </summary>
		public static SkillBreakBonusEffectItem MetalMaterial => Instance[(sbyte)29];

		/// <summary>
		/// 木材引子
		/// </summary>
		public static SkillBreakBonusEffectItem WoodMaterial => Instance[(sbyte)30];

		/// <summary>
		/// 玉石引子
		/// </summary>
		public static SkillBreakBonusEffectItem JadeMaterial => Instance[(sbyte)31];

		/// <summary>
		/// 织锦引子
		/// </summary>
		public static SkillBreakBonusEffectItem FabricMaterial => Instance[(sbyte)32];

		/// <summary>
		/// 相互爱慕的人物
		/// </summary>
		public static SkillBreakBonusEffectItem RelationAdore => Instance[(sbyte)33];

		/// <summary>
		/// 相互仇恨的人物
		/// </summary>
		public static SkillBreakBonusEffectItem RelationEnemy => Instance[(sbyte)34];

		/// <summary>
		/// 水果
		/// </summary>
		public static SkillBreakBonusEffectItem Fruit => Instance[(sbyte)35];

		/// <summary>
		/// 茶
		/// </summary>
		public static SkillBreakBonusEffectItem Tea => Instance[(sbyte)36];

		/// <summary>
		/// 历练
		/// </summary>
		public static SkillBreakBonusEffectItem Exp => Instance[(sbyte)37];

		/// <summary>
		/// 食物
		/// </summary>
		public static SkillBreakBonusEffectItem Food => Instance[(sbyte)38];

		/// <summary>
		/// 酒
		/// </summary>
		public static SkillBreakBonusEffectItem Wine => Instance[(sbyte)39];

		/// <summary>
		/// 血露
		/// </summary>
		public static SkillBreakBonusEffectItem BloodDew => Instance[(sbyte)40];

		/// <summary>
		/// 烈毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem HotPoison => Instance[(sbyte)41];

		/// <summary>
		/// 郁毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem GloomyPoison => Instance[(sbyte)42];

		/// <summary>
		/// 赤毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem RedPoison => Instance[(sbyte)43];

		/// <summary>
		/// 寒毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem ColdPoison => Instance[(sbyte)44];

		/// <summary>
		/// 腐毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem RottenPoison => Instance[(sbyte)45];

		/// <summary>
		/// 幻毒毒药
		/// </summary>
		public static SkillBreakBonusEffectItem IllusoryPoison => Instance[(sbyte)46];

		/// <summary>
		/// 亲友
		/// </summary>
		public static SkillBreakBonusEffectItem Friend => Instance[(sbyte)47];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SkillBreakBonusEffect Instance = new SkillBreakBonusEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ShortName", "Name", "EffectNeigong", "EffectAttack", "EffectAgile", "EffectDefense", "EffectAssist", "TemplateId" };

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
		_dataArray.Add(new SkillBreakBonusEffectItem(0, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_0"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_0"), 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakBonusEffectItem(1, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_1"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_1"), 1, 1, 1, 1, 1));
		_dataArray.Add(new SkillBreakBonusEffectItem(2, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_2"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_2"), 2, 2, 2, 2, 2));
		_dataArray.Add(new SkillBreakBonusEffectItem(3, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_3"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_3"), 3, 3, 3, 3, 3));
		_dataArray.Add(new SkillBreakBonusEffectItem(4, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_4"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_4"), -1, 4, -1, 4, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(5, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_5"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_5"), -1, 5, -1, 5, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(6, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_6"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_6"), -1, 6, -1, 6, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(7, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_7"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_7"), -1, 7, -1, 7, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(8, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_8"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_8"), -1, 8, -1, 8, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(9, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_9"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_9"), -1, 9, -1, 9, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(10, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_10"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_10"), -1, 10, 10, 10, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(11, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_11"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_11"), -1, 11, 11, 11, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(12, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_12"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_12"), -1, 12, 12, 12, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(13, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_13"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_13"), -1, 13, 13, 13, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(14, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_14"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_14"), 14, 14, 14, 14, 14));
		_dataArray.Add(new SkillBreakBonusEffectItem(15, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_15"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_15"), 15, 15, 15, 15, 15));
		_dataArray.Add(new SkillBreakBonusEffectItem(16, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_16"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_16"), 16, 16, 16, 16, 16));
		_dataArray.Add(new SkillBreakBonusEffectItem(17, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_17"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_17"), 16, 16, 16, 16, 16));
		_dataArray.Add(new SkillBreakBonusEffectItem(18, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_18"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_18"), 17, 17, 17, 17, 17));
		_dataArray.Add(new SkillBreakBonusEffectItem(19, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_19"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_19"), 18, 18, 18, 18, 18));
		_dataArray.Add(new SkillBreakBonusEffectItem(20, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_20"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_20"), 19, 19, 19, 19, 19));
		_dataArray.Add(new SkillBreakBonusEffectItem(21, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_21"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_21"), 20, 20, 20, 20, 20));
		_dataArray.Add(new SkillBreakBonusEffectItem(22, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_22"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_22"), 21, 21, 21, 21, 21));
		_dataArray.Add(new SkillBreakBonusEffectItem(23, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_23"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_23"), 22, 22, 22, 22, 22));
		_dataArray.Add(new SkillBreakBonusEffectItem(24, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_24"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_24"), 23, 23, 23, 23, 23));
		_dataArray.Add(new SkillBreakBonusEffectItem(25, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_25"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_25"), 24, 24, 24, 24, 24));
		_dataArray.Add(new SkillBreakBonusEffectItem(26, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_26"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_26"), 25, 25, 25, 25, 25));
		_dataArray.Add(new SkillBreakBonusEffectItem(27, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_27"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_27"), 26, 26, 26, 26, 26));
		_dataArray.Add(new SkillBreakBonusEffectItem(28, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_28"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_28"), 27, 27, 27, 27, 27));
		_dataArray.Add(new SkillBreakBonusEffectItem(29, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_29"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_29"), 28, 32, 36, 40, 44));
		_dataArray.Add(new SkillBreakBonusEffectItem(30, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_30"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_30"), 29, 33, 37, 41, 45));
		_dataArray.Add(new SkillBreakBonusEffectItem(31, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_31"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_31"), 30, 34, 38, 42, 46));
		_dataArray.Add(new SkillBreakBonusEffectItem(32, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_32"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_32"), 31, 35, 39, 43, 47));
		_dataArray.Add(new SkillBreakBonusEffectItem(33, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_33"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_33"), 48, 48, 48, 48, 48));
		_dataArray.Add(new SkillBreakBonusEffectItem(34, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_34"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_34"), 49, 49, 49, 49, 49));
		_dataArray.Add(new SkillBreakBonusEffectItem(35, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_35"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_35"), 50, -1, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(36, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_36"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_36"), 51, 51, 51, 51, 51));
		_dataArray.Add(new SkillBreakBonusEffectItem(37, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_37"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_37"), 52, 52, 52, 52, 52));
		_dataArray.Add(new SkillBreakBonusEffectItem(38, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_38"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_38"), 53, 53, 53, 53, 53));
		_dataArray.Add(new SkillBreakBonusEffectItem(39, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_39"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_39"), 54, 54, 54, 54, 54));
		_dataArray.Add(new SkillBreakBonusEffectItem(40, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_40"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_40"), 55, 55, 55, 55, 55));
		_dataArray.Add(new SkillBreakBonusEffectItem(41, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_41"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_41"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(42, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_42"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_42"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(43, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_43"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_43"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(44, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_44"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_44"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(45, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_45"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_45"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(46, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_46"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_46"), -1, 56, -1, -1, -1));
		_dataArray.Add(new SkillBreakBonusEffectItem(47, LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "ShortName_47"), LocalStringManager.GetConfig("SkillBreakBonusEffect_language", "Name_47"), 57, 57, 57, 57, 57));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakBonusEffectItem>(48);
		CreateItems0();
	}
}
