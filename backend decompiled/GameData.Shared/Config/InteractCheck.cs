using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheck : ConfigData<InteractCheckItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 互动-敌对-唬骗
		/// </summary>
		public const short ScamAction = 0;

		/// <summary>
		/// 互动-敌对-窃取
		/// </summary>
		public const short StealAction = 1;

		/// <summary>
		/// 互动-敌对-抢夺
		/// </summary>
		public const short RobAction = 2;

		/// <summary>
		/// 互动-敌对-毒害
		/// </summary>
		public const short PoisonAction = 3;

		/// <summary>
		/// 互动-敌对-暗中损害
		/// </summary>
		public const short PlotHarmAction = 4;

		/// <summary>
		/// 互动-亲近-倾诉爱意
		/// </summary>
		public const short ConfessionLove = 5;

		/// <summary>
		/// 互动-修习-偷师技艺
		/// </summary>
		public const short StealLifeSkillAction = 6;

		/// <summary>
		/// 互动-修习-偷师功法
		/// </summary>
		public const short StealCombatSkillAction = 7;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 互动-敌对-唬骗
		/// </summary>
		public static InteractCheckItem ScamAction => Instance[(short)0];

		/// <summary>
		/// 互动-敌对-窃取
		/// </summary>
		public static InteractCheckItem StealAction => Instance[(short)1];

		/// <summary>
		/// 互动-敌对-抢夺
		/// </summary>
		public static InteractCheckItem RobAction => Instance[(short)2];

		/// <summary>
		/// 互动-敌对-毒害
		/// </summary>
		public static InteractCheckItem PoisonAction => Instance[(short)3];

		/// <summary>
		/// 互动-敌对-暗中损害
		/// </summary>
		public static InteractCheckItem PlotHarmAction => Instance[(short)4];

		/// <summary>
		/// 互动-亲近-倾诉爱意
		/// </summary>
		public static InteractCheckItem ConfessionLove => Instance[(short)5];

		/// <summary>
		/// 互动-修习-偷师技艺
		/// </summary>
		public static InteractCheckItem StealLifeSkillAction => Instance[(short)6];

		/// <summary>
		/// 互动-修习-偷师功法
		/// </summary>
		public static InteractCheckItem StealCombatSkillAction => Instance[(short)7];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static InteractCheck Instance = new InteractCheck();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ActionPhaseList", "EscapePhaseList", "TemplateId" };

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
		_dataArray.Add(new InteractCheckItem(0, new short[3] { 1, 2, 36 }, new short[1] { 3 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(1, new short[3] { 5, 6, 7 }, new short[1] { 8 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(2, new short[3] { 10, 11, 12 }, new short[1] { 13 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(3, new short[3] { 15, 16, 17 }, new short[1] { 18 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(4, new short[3] { 20, 21, 22 }, new short[1] { 23 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(5, new short[2] { 24, 25 }, new short[1] { -1 }, checkAllPhase: true));
		_dataArray.Add(new InteractCheckItem(6, new short[3] { 27, 28, 29 }, new short[1] { 30 }, checkAllPhase: false));
		_dataArray.Add(new InteractCheckItem(7, new short[3] { 32, 33, 34 }, new short[1] { 35 }, checkAllPhase: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InteractCheckItem>(8);
		CreateItems0();
	}
}
