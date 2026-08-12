using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BecomeEnemyType : ConfigData<BecomeEnemyTypeItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 未知原因
		/// </summary>
		public const short Unknown = 0;

		/// <summary>
		/// 劫持
		/// </summary>
		public const short Kidnap = 1;

		/// <summary>
		/// 表白失败
		/// </summary>
		public const short ConfessLoveFail = 2;

		/// <summary>
		/// 分手
		/// </summary>
		public const short Breakup = 3;

		/// <summary>
		/// 求婚失败
		/// </summary>
		public const short ProposeFail = 4;

		/// <summary>
		/// 秘闻公开
		/// </summary>
		public const short SecretInformationBroadcast = 5;

		/// <summary>
		/// 魑魅蛊
		/// </summary>
		public const short WugForestSpirit = 6;

		/// <summary>
		/// 出手袭击
		/// </summary>
		public const short Attack = 7;

		/// <summary>
		/// 逐出太吾村
		/// </summary>
		public const short ExpelVillager = 8;

		/// <summary>
		/// 情难自禁
		/// </summary>
		public const short Rape = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 未知原因
		/// </summary>
		public static BecomeEnemyTypeItem Unknown => Instance[(short)0];

		/// <summary>
		/// 劫持
		/// </summary>
		public static BecomeEnemyTypeItem Kidnap => Instance[(short)1];

		/// <summary>
		/// 表白失败
		/// </summary>
		public static BecomeEnemyTypeItem ConfessLoveFail => Instance[(short)2];

		/// <summary>
		/// 分手
		/// </summary>
		public static BecomeEnemyTypeItem Breakup => Instance[(short)3];

		/// <summary>
		/// 求婚失败
		/// </summary>
		public static BecomeEnemyTypeItem ProposeFail => Instance[(short)4];

		/// <summary>
		/// 秘闻公开
		/// </summary>
		public static BecomeEnemyTypeItem SecretInformationBroadcast => Instance[(short)5];

		/// <summary>
		/// 魑魅蛊
		/// </summary>
		public static BecomeEnemyTypeItem WugForestSpirit => Instance[(short)6];

		/// <summary>
		/// 出手袭击
		/// </summary>
		public static BecomeEnemyTypeItem Attack => Instance[(short)7];

		/// <summary>
		/// 逐出太吾村
		/// </summary>
		public static BecomeEnemyTypeItem ExpelVillager => Instance[(short)8];

		/// <summary>
		/// 情难自禁
		/// </summary>
		public static BecomeEnemyTypeItem Rape => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
