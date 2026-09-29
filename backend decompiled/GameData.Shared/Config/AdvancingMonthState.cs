using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthState : ConfigData<AdvancingMonthStateItem, int>
{
	public static class DefKey
	{
		public const int NotInProcess = 0;

		public const int PreAdvancingLastMonthEnding = 1;

		public const int PeriAdvancingUpdateCharacterStatus = 2;

		public const int PeriAdvancingUpdateRandomEnemies = 3;

		public const int PeriAdvancingCharacterSelfImprovement = 4;

		public const int PeriAdvancingCharacterActivePreparation = 5;

		public const int PeriAdvancingCharacterPassivePreparation = 6;

		public const int PeriAdvancingCharacterRelationsUpdate = 7;

		public const int PeriAdvancingCharacterPersonalNeedsProcessing = 8;

		public const int PeriAdvancingCharacterPrioritizedAction = 9;

		public const int PeriAdvancingCharacterGeneralAction = 10;

		public const int PeriAdvancingCharacterFixedAction = 11;

		public const int PeriAdvancingInformationSpreading = 12;

		public const int PostAdvancingEnterNewMonth = 13;

		public const int DisplayingMonthlyNotifications = 14;
	}

	public static class DefValue
	{
		public static AdvancingMonthStateItem NotInProcess => Instance[0];

		public static AdvancingMonthStateItem PreAdvancingLastMonthEnding => Instance[1];

		public static AdvancingMonthStateItem PeriAdvancingUpdateCharacterStatus => Instance[2];

		public static AdvancingMonthStateItem PeriAdvancingUpdateRandomEnemies => Instance[3];

		public static AdvancingMonthStateItem PeriAdvancingCharacterSelfImprovement => Instance[4];

		public static AdvancingMonthStateItem PeriAdvancingCharacterActivePreparation => Instance[5];

		public static AdvancingMonthStateItem PeriAdvancingCharacterPassivePreparation => Instance[6];

		public static AdvancingMonthStateItem PeriAdvancingCharacterRelationsUpdate => Instance[7];

		public static AdvancingMonthStateItem PeriAdvancingCharacterPersonalNeedsProcessing => Instance[8];

		public static AdvancingMonthStateItem PeriAdvancingCharacterPrioritizedAction => Instance[9];

		public static AdvancingMonthStateItem PeriAdvancingCharacterGeneralAction => Instance[10];

		public static AdvancingMonthStateItem PeriAdvancingCharacterFixedAction => Instance[11];

		public static AdvancingMonthStateItem PeriAdvancingInformationSpreading => Instance[12];

		public static AdvancingMonthStateItem PostAdvancingEnterNewMonth => Instance[13];

		public static AdvancingMonthStateItem DisplayingMonthlyNotifications => Instance[14];
	}

	public static AdvancingMonthState Instance = new AdvancingMonthState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "HintText", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AdvancingMonthStateItem(0, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_0")));
		_dataArray.Add(new AdvancingMonthStateItem(1, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_1")));
		_dataArray.Add(new AdvancingMonthStateItem(2, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_2")));
		_dataArray.Add(new AdvancingMonthStateItem(3, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_3")));
		_dataArray.Add(new AdvancingMonthStateItem(4, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_4")));
		_dataArray.Add(new AdvancingMonthStateItem(5, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_5")));
		_dataArray.Add(new AdvancingMonthStateItem(6, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_6")));
		_dataArray.Add(new AdvancingMonthStateItem(7, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_7")));
		_dataArray.Add(new AdvancingMonthStateItem(8, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_8")));
		_dataArray.Add(new AdvancingMonthStateItem(9, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_9")));
		_dataArray.Add(new AdvancingMonthStateItem(10, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_10")));
		_dataArray.Add(new AdvancingMonthStateItem(11, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_11")));
		_dataArray.Add(new AdvancingMonthStateItem(12, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_12")));
		_dataArray.Add(new AdvancingMonthStateItem(13, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_13")));
		_dataArray.Add(new AdvancingMonthStateItem(14, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_14")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdvancingMonthStateItem>(15);
		CreateItems0();
	}
}
