using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheck : ConfigData<InteractCheckItem, short>
{
	public static class DefKey
	{
		public const short ScamAction = 0;

		public const short StealAction = 1;

		public const short RobAction = 2;

		public const short PoisonAction = 3;

		public const short PlotHarmAction = 4;

		public const short ConfessionLove = 5;

		public const short StealLifeSkillAction = 6;

		public const short StealCombatSkillAction = 7;
	}

	public static class DefValue
	{
		public static InteractCheckItem ScamAction => Instance[(short)0];

		public static InteractCheckItem StealAction => Instance[(short)1];

		public static InteractCheckItem RobAction => Instance[(short)2];

		public static InteractCheckItem PoisonAction => Instance[(short)3];

		public static InteractCheckItem PlotHarmAction => Instance[(short)4];

		public static InteractCheckItem ConfessionLove => Instance[(short)5];

		public static InteractCheckItem StealLifeSkillAction => Instance[(short)6];

		public static InteractCheckItem StealCombatSkillAction => Instance[(short)7];
	}

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
