using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementPrisonRecord : ConfigData<SettlementPrisonRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// IntrudePrison
		/// </summary>
		public const short IntrudePrison = 0;

		/// <summary>
		/// IntrudePrisonAndSentToPrisonTaiwu
		/// </summary>
		public const short IntrudePrisonAndSentToPrisonTaiwu = 1;

		/// <summary>
		/// IntrudePrisonAndPrisonBreak
		/// </summary>
		public const short IntrudePrisonAndPrisonRobbery = 2;

		/// <summary>
		/// SendingToPrisonTaiwu
		/// </summary>
		public const short SendingToPrisonTaiwu = 3;

		/// <summary>
		/// PrisonRobbery
		/// </summary>
		public const short PrisonRobbery = 4;

		/// <summary>
		/// PrisonBail
		/// </summary>
		public const short PrisonBail = 5;

		/// <summary>
		/// ImprisonedVoluntarily
		/// </summary>
		public const short ImprisonedVoluntarily = 6;

		/// <summary>
		/// ImprisonedByArrested
		/// </summary>
		public const short ImprisonedByArrested = 7;

		/// <summary>
		/// BeReleasedUponCompletionOfASentence
		/// </summary>
		public const short BeReleasedUponCompletionOfASentence = 8;

		/// <summary>
		/// PrisonBreak
		/// </summary>
		public const short PrisonBreak = 9;

		/// <summary>
		/// SentToPrisonTaiwu
		/// </summary>
		public const short SentToPrisonTaiwu = 10;

		/// <summary>
		/// PrisonerBeReleaseByAristocrat
		/// </summary>
		public const short PrisonerBeReleaseByAristocrat = 11;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// IntrudePrison
		/// </summary>
		public static SettlementPrisonRecordItem IntrudePrison => Instance[(short)0];

		/// <summary>
		/// IntrudePrisonAndSentToPrisonTaiwu
		/// </summary>
		public static SettlementPrisonRecordItem IntrudePrisonAndSentToPrisonTaiwu => Instance[(short)1];

		/// <summary>
		/// IntrudePrisonAndPrisonBreak
		/// </summary>
		public static SettlementPrisonRecordItem IntrudePrisonAndPrisonRobbery => Instance[(short)2];

		/// <summary>
		/// SendingToPrisonTaiwu
		/// </summary>
		public static SettlementPrisonRecordItem SendingToPrisonTaiwu => Instance[(short)3];

		/// <summary>
		/// PrisonRobbery
		/// </summary>
		public static SettlementPrisonRecordItem PrisonRobbery => Instance[(short)4];

		/// <summary>
		/// PrisonBail
		/// </summary>
		public static SettlementPrisonRecordItem PrisonBail => Instance[(short)5];

		/// <summary>
		/// ImprisonedVoluntarily
		/// </summary>
		public static SettlementPrisonRecordItem ImprisonedVoluntarily => Instance[(short)6];

		/// <summary>
		/// ImprisonedByArrested
		/// </summary>
		public static SettlementPrisonRecordItem ImprisonedByArrested => Instance[(short)7];

		/// <summary>
		/// BeReleasedUponCompletionOfASentence
		/// </summary>
		public static SettlementPrisonRecordItem BeReleasedUponCompletionOfASentence => Instance[(short)8];

		/// <summary>
		/// PrisonBreak
		/// </summary>
		public static SettlementPrisonRecordItem PrisonBreak => Instance[(short)9];

		/// <summary>
		/// SentToPrisonTaiwu
		/// </summary>
		public static SettlementPrisonRecordItem SentToPrisonTaiwu => Instance[(short)10];

		/// <summary>
		/// PrisonerBeReleaseByAristocrat
		/// </summary>
		public static SettlementPrisonRecordItem PrisonerBeReleaseByAristocrat => Instance[(short)11];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SettlementPrisonRecord Instance = new SettlementPrisonRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId" };

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
		_dataArray.Add(new SettlementPrisonRecordItem(0, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_0"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_0"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(1, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_1"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_1"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(2, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_2"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_2"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(3, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_3"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_3"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(4, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_4"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_4"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(5, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_5"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_5"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(6, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_6"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_6"), new string[6] { "Character", "PunishmentType", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(7, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_7"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_7"), new string[6] { "Character", "PunishmentType", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(8, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_8"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_8"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(9, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_9"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_9"), new string[6] { "Character", "", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(10, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_10"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_10"), new string[6] { "Character", "Character", "", "", "", "" }));
		_dataArray.Add(new SettlementPrisonRecordItem(11, LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Name_11"), LocalStringManager.GetConfig("SettlementPrisonRecord_language", "Desc_11"), new string[6] { "Character", "Character", "", "", "", "" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SettlementPrisonRecordItem>(12);
		CreateItems0();
	}
}
