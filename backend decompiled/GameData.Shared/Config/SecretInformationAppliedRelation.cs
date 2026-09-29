using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedRelation : ConfigData<SecretInformationAppliedRelationItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte NoneRelative = 0;

		public const sbyte Actor = 1;

		public const sbyte ActorAllied = 2;

		public const sbyte ActorEnemy = 3;

		public const sbyte Reactor = 4;

		public const sbyte ReactorAllied = 5;

		public const sbyte ReactorEnemy = 6;

		public const sbyte Secactor = 7;

		public const sbyte SecactorAllied = 8;

		public const sbyte SecactorEnemy = 9;

		public const sbyte ActorLoved = 10;

		public const sbyte ReactorLoved = 11;

		public const sbyte SecactorLoved = 12;

		public const sbyte ActorAdored = 13;

		public const sbyte ReactorAdored = 14;

		public const sbyte SecactorAdored = 15;

		public const sbyte ActorSectLeader = 16;

		public const sbyte ReactorSectLeader = 17;

		public const sbyte SecactorSectLeader = 18;

		public const sbyte RelatedItemType = 19;
	}

	public static class DefValue
	{
		public static SecretInformationAppliedRelationItem NoneRelative => Instance[(sbyte)0];

		public static SecretInformationAppliedRelationItem Actor => Instance[(sbyte)1];

		public static SecretInformationAppliedRelationItem ActorAllied => Instance[(sbyte)2];

		public static SecretInformationAppliedRelationItem ActorEnemy => Instance[(sbyte)3];

		public static SecretInformationAppliedRelationItem Reactor => Instance[(sbyte)4];

		public static SecretInformationAppliedRelationItem ReactorAllied => Instance[(sbyte)5];

		public static SecretInformationAppliedRelationItem ReactorEnemy => Instance[(sbyte)6];

		public static SecretInformationAppliedRelationItem Secactor => Instance[(sbyte)7];

		public static SecretInformationAppliedRelationItem SecactorAllied => Instance[(sbyte)8];

		public static SecretInformationAppliedRelationItem SecactorEnemy => Instance[(sbyte)9];

		public static SecretInformationAppliedRelationItem ActorLoved => Instance[(sbyte)10];

		public static SecretInformationAppliedRelationItem ReactorLoved => Instance[(sbyte)11];

		public static SecretInformationAppliedRelationItem SecactorLoved => Instance[(sbyte)12];

		public static SecretInformationAppliedRelationItem ActorAdored => Instance[(sbyte)13];

		public static SecretInformationAppliedRelationItem ReactorAdored => Instance[(sbyte)14];

		public static SecretInformationAppliedRelationItem SecactorAdored => Instance[(sbyte)15];

		public static SecretInformationAppliedRelationItem ActorSectLeader => Instance[(sbyte)16];

		public static SecretInformationAppliedRelationItem ReactorSectLeader => Instance[(sbyte)17];

		public static SecretInformationAppliedRelationItem SecactorSectLeader => Instance[(sbyte)18];

		public static SecretInformationAppliedRelationItem RelatedItemType => Instance[(sbyte)19];
	}

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
