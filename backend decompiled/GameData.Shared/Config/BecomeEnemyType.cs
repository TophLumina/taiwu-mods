using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BecomeEnemyType : ConfigData<BecomeEnemyTypeItem, short>
{
	public static class DefKey
	{
		public const short Unknown = 0;

		public const short Kidnap = 1;

		public const short ConfessLoveFail = 2;

		public const short Breakup = 3;

		public const short ProposeFail = 4;

		public const short SecretInformationBroadcast = 5;

		public const short WugForestSpirit = 6;

		public const short Attack = 7;

		public const short ExpelVillager = 8;

		public const short Rape = 9;
	}

	public static class DefValue
	{
		public static BecomeEnemyTypeItem Unknown => Instance[(short)0];

		public static BecomeEnemyTypeItem Kidnap => Instance[(short)1];

		public static BecomeEnemyTypeItem ConfessLoveFail => Instance[(short)2];

		public static BecomeEnemyTypeItem Breakup => Instance[(short)3];

		public static BecomeEnemyTypeItem ProposeFail => Instance[(short)4];

		public static BecomeEnemyTypeItem SecretInformationBroadcast => Instance[(short)5];

		public static BecomeEnemyTypeItem WugForestSpirit => Instance[(short)6];

		public static BecomeEnemyTypeItem Attack => Instance[(short)7];

		public static BecomeEnemyTypeItem ExpelVillager => Instance[(short)8];

		public static BecomeEnemyTypeItem Rape => Instance[(short)9];
	}

	public static BecomeEnemyType Instance = new BecomeEnemyType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "DefaultLifeRecord", "DefaultMonthlyNotification", "TemplateId" };

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
		_dataArray.Add(new BecomeEnemyTypeItem(0, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_0"), 26, 25, notifyTaiwuPeopleOnly: true));
		_dataArray.Add(new BecomeEnemyTypeItem(1, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_1"), 26, 20, notifyTaiwuPeopleOnly: true));
		_dataArray.Add(new BecomeEnemyTypeItem(2, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_2"), 26, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(3, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_3"), 26, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(4, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_4"), 26, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(5, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_5"), 724, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(6, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_6"), 723, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(7, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_7"), 26, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(8, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_8"), 26, -1, notifyTaiwuPeopleOnly: false));
		_dataArray.Add(new BecomeEnemyTypeItem(9, LocalStringManager.GetConfig("BecomeEnemyType_language", "Name_9"), 26, -1, notifyTaiwuPeopleOnly: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BecomeEnemyTypeItem>(10);
		CreateItems0();
	}
}
