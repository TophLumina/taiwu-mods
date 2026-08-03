using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedRelation : ConfigData<SecretInformationAppliedRelationItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 非当事人
		/// </summary>
		public const sbyte NoneRelative = 0;

		/// <summary>
		/// 行为人
		/// </summary>
		public const sbyte Actor = 1;

		/// <summary>
		/// 行为人亲友
		/// </summary>
		public const sbyte ActorAllied = 2;

		/// <summary>
		/// 行为人敌人
		/// </summary>
		public const sbyte ActorEnemy = 3;

		/// <summary>
		/// 接受者1
		/// </summary>
		public const sbyte Reactor = 4;

		/// <summary>
		/// 接受者1亲友
		/// </summary>
		public const sbyte ReactorAllied = 5;

		/// <summary>
		/// 接受者1敌人
		/// </summary>
		public const sbyte ReactorEnemy = 6;

		/// <summary>
		/// 接受者2
		/// </summary>
		public const sbyte Secactor = 7;

		/// <summary>
		/// 接受者2亲友
		/// </summary>
		public const sbyte SecactorAllied = 8;

		/// <summary>
		/// 接受者2敌人
		/// </summary>
		public const sbyte SecactorEnemy = 9;

		/// <summary>
		/// 行为人相好
		/// </summary>
		public const sbyte ActorLoved = 10;

		/// <summary>
		/// 接受者1相好
		/// </summary>
		public const sbyte ReactorLoved = 11;

		/// <summary>
		/// 接受者2相好
		/// </summary>
		public const sbyte SecactorLoved = 12;

		/// <summary>
		/// 行为人爱慕
		/// </summary>
		public const sbyte ActorAdored = 13;

		/// <summary>
		/// 接受者1爱慕
		/// </summary>
		public const sbyte ReactorAdored = 14;

		/// <summary>
		/// 接受者2爱慕
		/// </summary>
		public const sbyte SecactorAdored = 15;

		/// <summary>
		/// 行为人掌门
		/// </summary>
		public const sbyte ActorSectLeader = 16;

		/// <summary>
		/// 接受者1掌门
		/// </summary>
		public const sbyte ReactorSectLeader = 17;

		/// <summary>
		/// 接受者2掌门
		/// </summary>
		public const sbyte SecactorSectLeader = 18;

		/// <summary>
		/// 涉及道具类型
		/// </summary>
		public const sbyte RelatedItemType = 19;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 非当事人
		/// </summary>
		public static SecretInformationAppliedRelationItem NoneRelative => Instance[(sbyte)0];

		/// <summary>
		/// 行为人
		/// </summary>
		public static SecretInformationAppliedRelationItem Actor => Instance[(sbyte)1];

		/// <summary>
		/// 行为人亲友
		/// </summary>
		public static SecretInformationAppliedRelationItem ActorAllied => Instance[(sbyte)2];

		/// <summary>
		/// 行为人敌人
		/// </summary>
		public static SecretInformationAppliedRelationItem ActorEnemy => Instance[(sbyte)3];

		/// <summary>
		/// 接受者1
		/// </summary>
		public static SecretInformationAppliedRelationItem Reactor => Instance[(sbyte)4];

		/// <summary>
		/// 接受者1亲友
		/// </summary>
		public static SecretInformationAppliedRelationItem ReactorAllied => Instance[(sbyte)5];

		/// <summary>
		/// 接受者1敌人
		/// </summary>
		public static SecretInformationAppliedRelationItem ReactorEnemy => Instance[(sbyte)6];

		/// <summary>
		/// 接受者2
		/// </summary>
		public static SecretInformationAppliedRelationItem Secactor => Instance[(sbyte)7];

		/// <summary>
		/// 接受者2亲友
		/// </summary>
		public static SecretInformationAppliedRelationItem SecactorAllied => Instance[(sbyte)8];

		/// <summary>
		/// 接受者2敌人
		/// </summary>
		public static SecretInformationAppliedRelationItem SecactorEnemy => Instance[(sbyte)9];

		/// <summary>
		/// 行为人相好
		/// </summary>
		public static SecretInformationAppliedRelationItem ActorLoved => Instance[(sbyte)10];

		/// <summary>
		/// 接受者1相好
		/// </summary>
		public static SecretInformationAppliedRelationItem ReactorLoved => Instance[(sbyte)11];

		/// <summary>
		/// 接受者2相好
		/// </summary>
		public static SecretInformationAppliedRelationItem SecactorLoved => Instance[(sbyte)12];

		/// <summary>
		/// 行为人爱慕
		/// </summary>
		public static SecretInformationAppliedRelationItem ActorAdored => Instance[(sbyte)13];

		/// <summary>
		/// 接受者1爱慕
		/// </summary>
		public static SecretInformationAppliedRelationItem ReactorAdored => Instance[(sbyte)14];

		/// <summary>
		/// 接受者2爱慕
		/// </summary>
		public static SecretInformationAppliedRelationItem SecactorAdored => Instance[(sbyte)15];

		/// <summary>
		/// 行为人掌门
		/// </summary>
		public static SecretInformationAppliedRelationItem ActorSectLeader => Instance[(sbyte)16];

		/// <summary>
		/// 接受者1掌门
		/// </summary>
		public static SecretInformationAppliedRelationItem ReactorSectLeader => Instance[(sbyte)17];

		/// <summary>
		/// 接受者2掌门
		/// </summary>
		public static SecretInformationAppliedRelationItem SecactorSectLeader => Instance[(sbyte)18];

		/// <summary>
		/// 涉及道具类型
		/// </summary>
		public static SecretInformationAppliedRelationItem RelatedItemType => Instance[(sbyte)19];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SecretInformationAppliedRelation Instance = new SecretInformationAppliedRelation();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new SecretInformationAppliedRelationItem(0, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_0")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(1, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_1")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(2, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_2")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(3, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_3")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(4, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_4")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(5, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_5")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(6, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_6")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(7, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_7")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(8, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_8")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(9, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_9")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(10, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_10")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(11, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_11")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(12, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_12")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(13, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_13")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(14, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_14")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(15, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_15")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(16, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_16")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(17, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_17")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(18, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_18")));
		_dataArray.Add(new SecretInformationAppliedRelationItem(19, LocalStringManager.GetConfig("SecretInformationAppliedRelation_language", "Name_19")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationAppliedRelationItem>(20);
		CreateItems0();
	}
}
