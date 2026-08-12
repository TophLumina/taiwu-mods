using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialFunctionType : ConfigData<TutorialFunctionTypeItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 产业_进入
		/// </summary>
		public const short BuildingAreaEnter = 0;

		/// <summary>
		/// 产业_取消建造
		/// </summary>
		public const short BuildingManageStopBuild = 1;

		/// <summary>
		/// 人物_进入
		/// </summary>
		public const short CharacterMenuEnter = 2;

		/// <summary>
		/// 人物_造诣
		/// </summary>
		public const short CharacterMenuAttainment = 3;

		/// <summary>
		/// 人物_运功
		/// </summary>
		public const short CharacterMenuEquipCombatSkill = 4;

		/// <summary>
		/// 人物_真气
		/// </summary>
		public const short CharacterMenuNeili = 5;

		/// <summary>
		/// 人物_关系
		/// </summary>
		public const short CharacterMenuRelationship = 6;

		/// <summary>
		/// 人物_突破
		/// </summary>
		public const short CharacterMenuBreakout = 7;

		/// <summary>
		/// 人物_行囊
		/// </summary>
		public const short CharacterMenuInventory = 8;

		/// <summary>
		/// 人物_经历
		/// </summary>
		public const short CharacterMenuLifeRecord = 9;

		/// <summary>
		/// 人物_见闻
		/// </summary>
		public const short CharacterMenuInformation = 10;

		/// <summary>
		/// 主界面_研读
		/// </summary>
		public const short ViewBottomReading = 11;

		/// <summary>
		/// 主界面_周天
		/// </summary>
		public const short ViewBottomLooping = 12;

		/// <summary>
		/// 主界面_过月
		/// </summary>
		public const short ViewBottomAdvanceMonth = 13;

		/// <summary>
		/// 研读_卸下
		/// </summary>
		public const short ReadingRemoveCurrentBook = 14;

		/// <summary>
		/// 周天_卸下
		/// </summary>
		public const short LoopingRemoveCurrentSkill = 15;

		/// <summary>
		/// 地图_移动
		/// </summary>
		public const short MapMove = 16;

		/// <summary>
		/// 地图_采集
		/// </summary>
		public const short MapCollectResource = 17;

		/// <summary>
		/// 地图_志向
		/// </summary>
		public const short MapTaiwuProfession = 18;

		/// <summary>
		/// 战斗_打断功法
		/// </summary>
		public const short CombatInterruptSkill = 19;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 产业_进入
		/// </summary>
		public static TutorialFunctionTypeItem BuildingAreaEnter => Instance[(short)0];

		/// <summary>
		/// 产业_取消建造
		/// </summary>
		public static TutorialFunctionTypeItem BuildingManageStopBuild => Instance[(short)1];

		/// <summary>
		/// 人物_进入
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuEnter => Instance[(short)2];

		/// <summary>
		/// 人物_造诣
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuAttainment => Instance[(short)3];

		/// <summary>
		/// 人物_运功
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuEquipCombatSkill => Instance[(short)4];

		/// <summary>
		/// 人物_真气
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuNeili => Instance[(short)5];

		/// <summary>
		/// 人物_关系
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuRelationship => Instance[(short)6];

		/// <summary>
		/// 人物_突破
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuBreakout => Instance[(short)7];

		/// <summary>
		/// 人物_行囊
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuInventory => Instance[(short)8];

		/// <summary>
		/// 人物_经历
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuLifeRecord => Instance[(short)9];

		/// <summary>
		/// 人物_见闻
		/// </summary>
		public static TutorialFunctionTypeItem CharacterMenuInformation => Instance[(short)10];

		/// <summary>
		/// 主界面_研读
		/// </summary>
		public static TutorialFunctionTypeItem ViewBottomReading => Instance[(short)11];

		/// <summary>
		/// 主界面_周天
		/// </summary>
		public static TutorialFunctionTypeItem ViewBottomLooping => Instance[(short)12];

		/// <summary>
		/// 主界面_过月
		/// </summary>
		public static TutorialFunctionTypeItem ViewBottomAdvanceMonth => Instance[(short)13];

		/// <summary>
		/// 研读_卸下
		/// </summary>
		public static TutorialFunctionTypeItem ReadingRemoveCurrentBook => Instance[(short)14];

		/// <summary>
		/// 周天_卸下
		/// </summary>
		public static TutorialFunctionTypeItem LoopingRemoveCurrentSkill => Instance[(short)15];

		/// <summary>
		/// 地图_移动
		/// </summary>
		public static TutorialFunctionTypeItem MapMove => Instance[(short)16];

		/// <summary>
		/// 地图_采集
		/// </summary>
		public static TutorialFunctionTypeItem MapCollectResource => Instance[(short)17];

		/// <summary>
		/// 地图_志向
		/// </summary>
		public static TutorialFunctionTypeItem MapTaiwuProfession => Instance[(short)18];

		/// <summary>
		/// 战斗_打断功法
		/// </summary>
		public static TutorialFunctionTypeItem CombatInterruptSkill => Instance[(short)19];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TutorialFunctionType Instance = new TutorialFunctionType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new TutorialFunctionTypeItem(0));
		_dataArray.Add(new TutorialFunctionTypeItem(1));
		_dataArray.Add(new TutorialFunctionTypeItem(2));
		_dataArray.Add(new TutorialFunctionTypeItem(3));
		_dataArray.Add(new TutorialFunctionTypeItem(4));
		_dataArray.Add(new TutorialFunctionTypeItem(5));
		_dataArray.Add(new TutorialFunctionTypeItem(6));
		_dataArray.Add(new TutorialFunctionTypeItem(7));
		_dataArray.Add(new TutorialFunctionTypeItem(8));
		_dataArray.Add(new TutorialFunctionTypeItem(9));
		_dataArray.Add(new TutorialFunctionTypeItem(10));
		_dataArray.Add(new TutorialFunctionTypeItem(11));
		_dataArray.Add(new TutorialFunctionTypeItem(12));
		_dataArray.Add(new TutorialFunctionTypeItem(13));
		_dataArray.Add(new TutorialFunctionTypeItem(14));
		_dataArray.Add(new TutorialFunctionTypeItem(15));
		_dataArray.Add(new TutorialFunctionTypeItem(16));
		_dataArray.Add(new TutorialFunctionTypeItem(17));
		_dataArray.Add(new TutorialFunctionTypeItem(18));
		_dataArray.Add(new TutorialFunctionTypeItem(19));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TutorialFunctionTypeItem>(20);
		CreateItems0();
	}
}
