using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class DebateEvaluation : ConfigData<DebateEvaluationItem, short>
{
	public static class DefKey
	{
		public const short DebateWin = 0;

		public const short DebateLose = 1;

		public const short Bully = 2;

		public const short OverCome = 3;

		public const short Surrender = 4;
	}

	public static class DefValue
	{
		public static DebateEvaluationItem DebateWin => Instance[(short)0];

		public static DebateEvaluationItem DebateLose => Instance[(short)1];

		public static DebateEvaluationItem Bully => Instance[(short)2];

		public static DebateEvaluationItem OverCome => Instance[(short)3];

		public static DebateEvaluationItem Surrender => Instance[(short)4];
	}

	public static DebateEvaluation Instance = new DebateEvaluation();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ResultTip", "FameAction", "AddLegacyPoint", "TemplateId" };

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
		_dataArray.Add(new DebateEvaluationItem(0, LocalStringManager.GetConfig("DebateEvaluation_language", "Name_0"), LocalStringManager.GetConfig("DebateEvaluation_language", "ResultTip_0"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, new List<LegacyPointReference>(), 2));
		_dataArray.Add(new DebateEvaluationItem(1, LocalStringManager.GetConfig("DebateEvaluation_language", "Name_1"), LocalStringManager.GetConfig("DebateEvaluation_language", "ResultTip_1"), 0, 0, -25, 0, 0, -100, 0, 0, -50, 0, 50, -50, -50, -1, new List<LegacyPointReference>(), -2));
		_dataArray.Add(new DebateEvaluationItem(2, LocalStringManager.GetConfig("DebateEvaluation_language", "Name_2"), LocalStringManager.GetConfig("DebateEvaluation_language", "ResultTip_2"), 0, -50, 0, 0, -50, 0, 0, 50, 0, 0, -50, -50, -50, -1, new List<LegacyPointReference>(), 0));
		_dataArray.Add(new DebateEvaluationItem(3, LocalStringManager.GetConfig("DebateEvaluation_language", "Name_3"), LocalStringManager.GetConfig("DebateEvaluation_language", "ResultTip_3"), 0, 50, 0, 0, 50, 0, 0, 50, 0, 0, -50, 50, 50, -1, new List<LegacyPointReference>(), 0));
		_dataArray.Add(new DebateEvaluationItem(4, LocalStringManager.GetConfig("DebateEvaluation_language", "Name_4"), LocalStringManager.GetConfig("DebateEvaluation_language", "ResultTip_4"), 0, 0, -75, 0, 0, -100, 0, 0, -100, 0, 100, -1000, -1000, 85, new List<LegacyPointReference>(), 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateEvaluationItem>(5);
		CreateItems0();
	}
}
