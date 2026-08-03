using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class AiRelations : ConfigData<AiRelationsItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 结下仇怨
		/// </summary>
		public const short StartEnemyRelation = 0;

		/// <summary>
		/// 化解仇怨
		/// </summary>
		public const short EndEnemyRelation = 1;

		/// <summary>
		/// 爱慕
		/// </summary>
		public const short StartAdoredRelation = 2;

		/// <summary>
		/// 表白
		/// </summary>
		public const short StartBoyOrGirlFriendRelation = 3;

		/// <summary>
		/// 分手
		/// </summary>
		public const short EndBoyOrGirlFriendRelation = 4;

		/// <summary>
		/// 求婚
		/// </summary>
		public const short StartHusbandOrWifeRelation = 5;

		/// <summary>
		/// 结为好友
		/// </summary>
		public const short StartFriendRelation = 6;

		/// <summary>
		/// 断绝友谊
		/// </summary>
		public const short EndFriendRelation = 7;

		/// <summary>
		/// 义结金兰
		/// </summary>
		public const short StartSwornBrotherOrSisterRelation = 8;

		/// <summary>
		/// 割袍断义
		/// </summary>
		public const short EndSwornBrotherOrSisterRelation = 9;

		/// <summary>
		/// 拜认父母
		/// </summary>
		public const short GetAdoptedRelation = 10;

		/// <summary>
		/// 收养子女
		/// </summary>
		public const short AdoptingRelation = 11;

		/// <summary>
		/// 离婚
		/// </summary>
		public const short EndHusbandOrWifeRelation = 12;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 结下仇怨
		/// </summary>
		public static AiRelationsItem StartEnemyRelation => Instance[(short)0];

		/// <summary>
		/// 化解仇怨
		/// </summary>
		public static AiRelationsItem EndEnemyRelation => Instance[(short)1];

		/// <summary>
		/// 爱慕
		/// </summary>
		public static AiRelationsItem StartAdoredRelation => Instance[(short)2];

		/// <summary>
		/// 表白
		/// </summary>
		public static AiRelationsItem StartBoyOrGirlFriendRelation => Instance[(short)3];

		/// <summary>
		/// 分手
		/// </summary>
		public static AiRelationsItem EndBoyOrGirlFriendRelation => Instance[(short)4];

		/// <summary>
		/// 求婚
		/// </summary>
		public static AiRelationsItem StartHusbandOrWifeRelation => Instance[(short)5];

		/// <summary>
		/// 结为好友
		/// </summary>
		public static AiRelationsItem StartFriendRelation => Instance[(short)6];

		/// <summary>
		/// 断绝友谊
		/// </summary>
		public static AiRelationsItem EndFriendRelation => Instance[(short)7];

		/// <summary>
		/// 义结金兰
		/// </summary>
		public static AiRelationsItem StartSwornBrotherOrSisterRelation => Instance[(short)8];

		/// <summary>
		/// 割袍断义
		/// </summary>
		public static AiRelationsItem EndSwornBrotherOrSisterRelation => Instance[(short)9];

		/// <summary>
		/// 拜认父母
		/// </summary>
		public static AiRelationsItem GetAdoptedRelation => Instance[(short)10];

		/// <summary>
		/// 收养子女
		/// </summary>
		public static AiRelationsItem AdoptingRelation => Instance[(short)11];

		/// <summary>
		/// 离婚
		/// </summary>
		public static AiRelationsItem EndHusbandOrWifeRelation => Instance[(short)12];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AiRelations Instance = new AiRelations();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "PersonalityType" };

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
		_dataArray.Add(new AiRelationsItem(0, 3, new short[0], new short[5] { 0, -1, -2, -1, 0 }, new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(2000, 2000, 2000),
			new RelationTriggerOnBehaviorChance(1000, 500, 500),
			new RelationTriggerOnBehaviorChance(1500, 1500, 1500),
			new RelationTriggerOnBehaviorChance(3000, 4500, 4500),
			new RelationTriggerOnBehaviorChance(2500, 2500, 2500)
		}, -500, -500, 2500, 0));
		_dataArray.Add(new AiRelationsItem(1, 0, new short[5] { 5, 3, 4, 3, 5 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(2000, 2000, 2000),
			new RelationTriggerOnBehaviorChance(3000, 4500, 4500),
			new RelationTriggerOnBehaviorChance(2500, 2500, 2500),
			new RelationTriggerOnBehaviorChance(1000, 500, 500),
			new RelationTriggerOnBehaviorChance(1500, 1500, 1500)
		}, 500, 500, -1000, 0));
		_dataArray.Add(new AiRelationsItem(2, 2, new short[5] { 2, 1, 0, 1, 2 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(1000, 0, 0),
			new RelationTriggerOnBehaviorChance(2000, 5, 50),
			new RelationTriggerOnBehaviorChance(2500, 15, 150),
			new RelationTriggerOnBehaviorChance(3000, 10, 100),
			new RelationTriggerOnBehaviorChance(1500, 10, 150)
		}, 0, 0, 0, 0));
		_dataArray.Add(new AiRelationsItem(3, 3, new short[5] { 3, 2, 1, 2, 3 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(1000, 0, 0),
			new RelationTriggerOnBehaviorChance(2000, 5, 50),
			new RelationTriggerOnBehaviorChance(2500, 15, 150),
			new RelationTriggerOnBehaviorChance(3000, 10, 100),
			new RelationTriggerOnBehaviorChance(1500, 10, 150)
		}, 0, 0, 0, 0));
		_dataArray.Add(new AiRelationsItem(4, 0, new short[0], new short[5] { 0, -2, -1, -2, 0 }, new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(1000, 1000, 1000),
			new RelationTriggerOnBehaviorChance(1500, 750, 750),
			new RelationTriggerOnBehaviorChance(2000, 2000, 2000),
			new RelationTriggerOnBehaviorChance(3000, 4500, 4500),
			new RelationTriggerOnBehaviorChance(2500, 2500, 2500)
		}, 0, 0, 0, 0));
		_dataArray.Add(new AiRelationsItem(5, 4, new short[5] { 5, 4, 3, 4, 5 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(3000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(2500, -30000, -30000),
			new RelationTriggerOnBehaviorChance(2000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1500, -30000, -30000)
		}, 0, 0, 0, 0));
		_dataArray.Add(new AiRelationsItem(6, 2, new short[5] { 4, 3, 2, 3, 4 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(750, 750, 750),
			new RelationTriggerOnBehaviorChance(1500, 2250, 2250),
			new RelationTriggerOnBehaviorChance(1000, 1000, 1000),
			new RelationTriggerOnBehaviorChance(1250, 625, 625),
			new RelationTriggerOnBehaviorChance(500, 500, 500)
		}, 250, 250, -500, 0));
		_dataArray.Add(new AiRelationsItem(7, 0, new short[0], new short[5] { -2, -4, -3, -4, -2 }, new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(2500, 2500, 2500),
			new RelationTriggerOnBehaviorChance(1000, 500, 500),
			new RelationTriggerOnBehaviorChance(2000, 2000, 2000),
			new RelationTriggerOnBehaviorChance(1500, 2250, 2250),
			new RelationTriggerOnBehaviorChance(3000, 3000, 3000)
		}, -500, -500, 2500, 0));
		_dataArray.Add(new AiRelationsItem(8, 2, new short[5] { 5, 4, 3, 4, 5 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(750, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1500, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1250, -30000, -30000),
			new RelationTriggerOnBehaviorChance(500, -30000, -30000)
		}, 250, 250, -500, 0));
		_dataArray.Add(new AiRelationsItem(9, 0, new short[0], new short[5] { -4, -6, -5, -6, -4 }, new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(2500, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(2000, -30000, -30000),
			new RelationTriggerOnBehaviorChance(1500, -30000, -30000),
			new RelationTriggerOnBehaviorChance(3000, -30000, -30000)
		}, -500, -500, 2500, 0));
		_dataArray.Add(new AiRelationsItem(10, 4, new short[5] { 4, 3, 2, 3, 4 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(1000, 0, 0)
		}, 500, 500, -2000, 0));
		_dataArray.Add(new AiRelationsItem(11, 4, new short[5] { 4, 3, 2, 3, 4 }, new short[0], new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(500, 0, 0),
			new RelationTriggerOnBehaviorChance(1000, 0, 0)
		}, 500, 500, -2000, 0));
		_dataArray.Add(new AiRelationsItem(12, 4, new short[0], new short[5] { -4, -6, -5, -6, -4 }, new RelationTriggerOnBehaviorChance[5]
		{
			new RelationTriggerOnBehaviorChance(1500, 1500, 1500),
			new RelationTriggerOnBehaviorChance(1000, 500, 500),
			new RelationTriggerOnBehaviorChance(2000, 2000, 2000),
			new RelationTriggerOnBehaviorChance(3000, 4500, 4500),
			new RelationTriggerOnBehaviorChance(2500, 2500, 2500)
		}, -500, -500, 2500, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiRelationsItem>(13);
		CreateItems0();
	}
}
