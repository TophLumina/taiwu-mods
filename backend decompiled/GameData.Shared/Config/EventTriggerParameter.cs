using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerParameter : ConfigData<EventTriggerParameterItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 目标人物
		/// </summary>
		public const int CharacterId = 0;

		/// <summary>
		/// 人物模板
		/// </summary>
		public const int CharacterTemplateId = 1;

		/// <summary>
		/// 目标坟墓
		/// </summary>
		public const int TombId = 2;

		/// <summary>
		/// 目标动物
		/// </summary>
		public const int AnimalId = 3;

		/// <summary>
		/// 目标商队
		/// </summary>
		public const int CaravanId = 4;

		/// <summary>
		/// 目标元鸡
		/// </summary>
		public const int ChickenId = 5;

		/// <summary>
		/// 元鸡模板
		/// </summary>
		public const int ChickenTemplateId = 6;

		/// <summary>
		/// 目标道具
		/// </summary>
		public const int ItemKey = 7;

		/// <summary>
		/// 触发位置
		/// </summary>
		public const int Location = 8;

		/// <summary>
		/// 邀约位置
		/// </summary>
		public const int InviteLocation = 9;

		/// <summary>
		/// 相枢化身类型
		/// </summary>
		public const int XiangshuAvatarId = 10;

		/// <summary>
		/// 移动来源地格
		/// </summary>
		public const int BlockFrom = 11;

		/// <summary>
		/// 移动目标地格
		/// </summary>
		public const int BlockTo = 12;

		/// <summary>
		/// 数量
		/// </summary>
		public const int Amount = 13;

		/// <summary>
		/// 是否太吾死亡
		/// </summary>
		public const int IsTaiwuDying = 14;

		/// <summary>
		/// 动画后黑屏遮罩可见
		/// </summary>
		public const int MaskVisible = 15;

		/// <summary>
		/// 产业建筑
		/// </summary>
		public const int BuildingBlockKey = 16;

		/// <summary>
		/// 产业建筑模板
		/// </summary>
		public const int BuildingTemplateId = 17;

		/// <summary>
		/// 捕捉促织成功
		/// </summary>
		public const int CricketCatchSuccess = 18;

		/// <summary>
		/// 志向模板
		/// </summary>
		public const int ProfessionTemplateId = 19;

		/// <summary>
		/// 志向技能模板
		/// </summary>
		public const int ProfessionSkillTemplateId = 20;

		/// <summary>
		/// 蛟池
		/// </summary>
		public const int PoolId = 21;

		/// <summary>
		/// 资源类型
		/// </summary>
		public const int ResourceType = 22;

		/// <summary>
		/// 是否触发事件拾取物
		/// </summary>
		public const int IsEvent = 23;

		/// <summary>
		/// 界面名称
		/// </summary>
		public const int UIName = 24;

		/// <summary>
		/// 贼人品级
		/// </summary>
		public const int ThiefLevel = 25;

		/// <summary>
		/// 是否超时
		/// </summary>
		public const int IsTimeout = 26;

		/// <summary>
		/// 毁坏区域等级
		/// </summary>
		public const int BrokenLevel = 27;

		/// <summary>
		/// 挖掘结果
		/// </summary>
		public const int FindResult = 28;

		/// <summary>
		/// 梦回记忆类型
		/// </summary>
		public const int DreamBackUnlockStateType = 29;

		/// <summary>
		/// 行囊操作类型
		/// </summary>
		public const int InventoryItemOperationType = 30;

		/// <summary>
		/// 章节索引
		/// </summary>
		public const int ChapterIndex = 31;

		/// <summary>
		/// 三才三魔类型
		/// </summary>
		public const int VitalType = 32;

		/// <summary>
		/// 是否为三才
		/// </summary>
		public const int IsGoodEnd = 33;

		/// <summary>
		/// 诛魔试炼索引
		/// </summary>
		public const int BossIndex = 34;

		/// <summary>
		/// 是否拾取所有
		/// </summary>
		public const int IsPickUpAll = 35;

		/// <summary>
		/// 拾取物索引
		/// </summary>
		public const int MapPickupIndex = 36;

		/// <summary>
		/// 库房监牢分页
		/// </summary>
		public const int TreasuryOrPrisonCurrentPage = 37;

		/// <summary>
		/// 库房监牢访问状态
		/// </summary>
		public const int TreasuryOrPrisonVisitStatus = 38;

		/// <summary>
		/// 超度的人数
		/// </summary>
		public const int MonkProfessionSaveCount = 39;

		/// <summary>
		/// 产业建筑等级
		/// </summary>
		public const int BuildingLevel = 40;

		/// <summary>
		/// 选择行囊道具
		/// </summary>
		public const int SelectInventoryItemKey = 51;

		/// <summary>
		/// 蛟卵道具
		/// </summary>
		public const int JiaoEggItemKey = 41;

		/// <summary>
		/// 天劫符箓道具
		/// </summary>
		public const int TianjieFuluItemKey = 42;

		/// <summary>
		/// 天劫符箓数量
		/// </summary>
		public const int TianjieFuluCount = 43;

		/// <summary>
		/// 正在获得界面展示物品
		/// </summary>
		public const int ShowingGetItem = 44;

		/// <summary>
		/// 较艺已妥协次数
		/// </summary>
		public const int LifeSkillCombatConcessionCount = 45;

		/// <summary>
		/// 较艺已拒绝利诱次数
		/// </summary>
		public const int LifeSkillCombatInducementCount = 46;

		/// <summary>
		/// 和犯人互动类型
		/// </summary>
		public const int InteractPrisonerType = 47;

		/// <summary>
		/// 预留整数参数
		/// </summary>
		public const int PresetInt = 48;

		/// <summary>
		/// 预留布尔参数
		/// </summary>
		public const int PresetBool = 49;

		/// <summary>
		/// 完成传承后事件
		/// </summary>
		public const int OnFinishPassingLegacyEvent = 50;

		/// <summary>
		/// 突破成功
		/// </summary>
		public const int BreakSuccess = 52;

		/// <summary>
		/// 功法模板
		/// </summary>
		public const int CombatSkillTemplateId = 53;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 目标人物
		/// </summary>
		public static EventTriggerParameterItem CharacterId => Instance[0];

		/// <summary>
		/// 人物模板
		/// </summary>
		public static EventTriggerParameterItem CharacterTemplateId => Instance[1];

		/// <summary>
		/// 目标坟墓
		/// </summary>
		public static EventTriggerParameterItem TombId => Instance[2];

		/// <summary>
		/// 目标动物
		/// </summary>
		public static EventTriggerParameterItem AnimalId => Instance[3];

		/// <summary>
		/// 目标商队
		/// </summary>
		public static EventTriggerParameterItem CaravanId => Instance[4];

		/// <summary>
		/// 目标元鸡
		/// </summary>
		public static EventTriggerParameterItem ChickenId => Instance[5];

		/// <summary>
		/// 元鸡模板
		/// </summary>
		public static EventTriggerParameterItem ChickenTemplateId => Instance[6];

		/// <summary>
		/// 目标道具
		/// </summary>
		public static EventTriggerParameterItem ItemKey => Instance[7];

		/// <summary>
		/// 触发位置
		/// </summary>
		public static EventTriggerParameterItem Location => Instance[8];

		/// <summary>
		/// 邀约位置
		/// </summary>
		public static EventTriggerParameterItem InviteLocation => Instance[9];

		/// <summary>
		/// 相枢化身类型
		/// </summary>
		public static EventTriggerParameterItem XiangshuAvatarId => Instance[10];

		/// <summary>
		/// 移动来源地格
		/// </summary>
		public static EventTriggerParameterItem BlockFrom => Instance[11];

		/// <summary>
		/// 移动目标地格
		/// </summary>
		public static EventTriggerParameterItem BlockTo => Instance[12];

		/// <summary>
		/// 数量
		/// </summary>
		public static EventTriggerParameterItem Amount => Instance[13];

		/// <summary>
		/// 是否太吾死亡
		/// </summary>
		public static EventTriggerParameterItem IsTaiwuDying => Instance[14];

		/// <summary>
		/// 动画后黑屏遮罩可见
		/// </summary>
		public static EventTriggerParameterItem MaskVisible => Instance[15];

		/// <summary>
		/// 产业建筑
		/// </summary>
		public static EventTriggerParameterItem BuildingBlockKey => Instance[16];

		/// <summary>
		/// 产业建筑模板
		/// </summary>
		public static EventTriggerParameterItem BuildingTemplateId => Instance[17];

		/// <summary>
		/// 捕捉促织成功
		/// </summary>
		public static EventTriggerParameterItem CricketCatchSuccess => Instance[18];

		/// <summary>
		/// 志向模板
		/// </summary>
		public static EventTriggerParameterItem ProfessionTemplateId => Instance[19];

		/// <summary>
		/// 志向技能模板
		/// </summary>
		public static EventTriggerParameterItem ProfessionSkillTemplateId => Instance[20];

		/// <summary>
		/// 蛟池
		/// </summary>
		public static EventTriggerParameterItem PoolId => Instance[21];

		/// <summary>
		/// 资源类型
		/// </summary>
		public static EventTriggerParameterItem ResourceType => Instance[22];

		/// <summary>
		/// 是否触发事件拾取物
		/// </summary>
		public static EventTriggerParameterItem IsEvent => Instance[23];

		/// <summary>
		/// 界面名称
		/// </summary>
		public static EventTriggerParameterItem UIName => Instance[24];

		/// <summary>
		/// 贼人品级
		/// </summary>
		public static EventTriggerParameterItem ThiefLevel => Instance[25];

		/// <summary>
		/// 是否超时
		/// </summary>
		public static EventTriggerParameterItem IsTimeout => Instance[26];

		/// <summary>
		/// 毁坏区域等级
		/// </summary>
		public static EventTriggerParameterItem BrokenLevel => Instance[27];

		/// <summary>
		/// 挖掘结果
		/// </summary>
		public static EventTriggerParameterItem FindResult => Instance[28];

		/// <summary>
		/// 梦回记忆类型
		/// </summary>
		public static EventTriggerParameterItem DreamBackUnlockStateType => Instance[29];

		/// <summary>
		/// 行囊操作类型
		/// </summary>
		public static EventTriggerParameterItem InventoryItemOperationType => Instance[30];

		/// <summary>
		/// 章节索引
		/// </summary>
		public static EventTriggerParameterItem ChapterIndex => Instance[31];

		/// <summary>
		/// 三才三魔类型
		/// </summary>
		public static EventTriggerParameterItem VitalType => Instance[32];

		/// <summary>
		/// 是否为三才
		/// </summary>
		public static EventTriggerParameterItem IsGoodEnd => Instance[33];

		/// <summary>
		/// 诛魔试炼索引
		/// </summary>
		public static EventTriggerParameterItem BossIndex => Instance[34];

		/// <summary>
		/// 是否拾取所有
		/// </summary>
		public static EventTriggerParameterItem IsPickUpAll => Instance[35];

		/// <summary>
		/// 拾取物索引
		/// </summary>
		public static EventTriggerParameterItem MapPickupIndex => Instance[36];

		/// <summary>
		/// 库房监牢分页
		/// </summary>
		public static EventTriggerParameterItem TreasuryOrPrisonCurrentPage => Instance[37];

		/// <summary>
		/// 库房监牢访问状态
		/// </summary>
		public static EventTriggerParameterItem TreasuryOrPrisonVisitStatus => Instance[38];

		/// <summary>
		/// 超度的人数
		/// </summary>
		public static EventTriggerParameterItem MonkProfessionSaveCount => Instance[39];

		/// <summary>
		/// 产业建筑等级
		/// </summary>
		public static EventTriggerParameterItem BuildingLevel => Instance[40];

		/// <summary>
		/// 选择行囊道具
		/// </summary>
		public static EventTriggerParameterItem SelectInventoryItemKey => Instance[51];

		/// <summary>
		/// 蛟卵道具
		/// </summary>
		public static EventTriggerParameterItem JiaoEggItemKey => Instance[41];

		/// <summary>
		/// 天劫符箓道具
		/// </summary>
		public static EventTriggerParameterItem TianjieFuluItemKey => Instance[42];

		/// <summary>
		/// 天劫符箓数量
		/// </summary>
		public static EventTriggerParameterItem TianjieFuluCount => Instance[43];

		/// <summary>
		/// 正在获得界面展示物品
		/// </summary>
		public static EventTriggerParameterItem ShowingGetItem => Instance[44];

		/// <summary>
		/// 较艺已妥协次数
		/// </summary>
		public static EventTriggerParameterItem LifeSkillCombatConcessionCount => Instance[45];

		/// <summary>
		/// 较艺已拒绝利诱次数
		/// </summary>
		public static EventTriggerParameterItem LifeSkillCombatInducementCount => Instance[46];

		/// <summary>
		/// 和犯人互动类型
		/// </summary>
		public static EventTriggerParameterItem InteractPrisonerType => Instance[47];

		/// <summary>
		/// 预留整数参数
		/// </summary>
		public static EventTriggerParameterItem PresetInt => Instance[48];

		/// <summary>
		/// 预留布尔参数
		/// </summary>
		public static EventTriggerParameterItem PresetBool => Instance[49];

		/// <summary>
		/// 完成传承后事件
		/// </summary>
		public static EventTriggerParameterItem OnFinishPassingLegacyEvent => Instance[50];

		/// <summary>
		/// 突破成功
		/// </summary>
		public static EventTriggerParameterItem BreakSuccess => Instance[52];

		/// <summary>
		/// 功法模板
		/// </summary>
		public static EventTriggerParameterItem CombatSkillTemplateId => Instance[53];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventTriggerParameter Instance = new EventTriggerParameter();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "DataTypeName", "ArgBoxKey" };

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
		_dataArray.Add(new EventTriggerParameterItem(0, "int", "CharacterId"));
		_dataArray.Add(new EventTriggerParameterItem(1, "short", "CharacterTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(2, "int", "TombId"));
		_dataArray.Add(new EventTriggerParameterItem(3, "int", "AnimalId"));
		_dataArray.Add(new EventTriggerParameterItem(4, "int", "CaravanId"));
		_dataArray.Add(new EventTriggerParameterItem(5, "int", "ChickenId"));
		_dataArray.Add(new EventTriggerParameterItem(6, "short", "ChickenTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(7, "ItemKey", "ItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(8, "Location", "Location"));
		_dataArray.Add(new EventTriggerParameterItem(9, "Location", "InviteLocation"));
		_dataArray.Add(new EventTriggerParameterItem(10, "sbyte", "XiangshuAvatarId"));
		_dataArray.Add(new EventTriggerParameterItem(11, "Location", "BlockFrom"));
		_dataArray.Add(new EventTriggerParameterItem(12, "Location", "BlockTo"));
		_dataArray.Add(new EventTriggerParameterItem(13, "int", "Amount"));
		_dataArray.Add(new EventTriggerParameterItem(14, "bool", "IsTaiwuDying"));
		_dataArray.Add(new EventTriggerParameterItem(15, "bool", "MaskVisible"));
		_dataArray.Add(new EventTriggerParameterItem(16, "BuildingBlockKey", "BuildingBlockKey"));
		_dataArray.Add(new EventTriggerParameterItem(17, "short", "BuildingTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(18, "bool", "CricketCatchSuccess"));
		_dataArray.Add(new EventTriggerParameterItem(19, "int", "ProfessionTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(20, "int", "ProfessionSkillTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(21, "int", "PoolId"));
		_dataArray.Add(new EventTriggerParameterItem(22, "sbyte", "ResourceType"));
		_dataArray.Add(new EventTriggerParameterItem(23, "bool", "IsEvent"));
		_dataArray.Add(new EventTriggerParameterItem(24, "string", "UIName"));
		_dataArray.Add(new EventTriggerParameterItem(25, "sbyte", "ThiefLevel"));
		_dataArray.Add(new EventTriggerParameterItem(26, "bool", "IsTimeout"));
		_dataArray.Add(new EventTriggerParameterItem(27, "int", "BrokenLevel"));
		_dataArray.Add(new EventTriggerParameterItem(28, "TreasureFindResult", "FindResult"));
		_dataArray.Add(new EventTriggerParameterItem(29, "sbyte", "DreamBackUnlockStateType"));
		_dataArray.Add(new EventTriggerParameterItem(30, "sbyte", "InventoryItemOperationType"));
		_dataArray.Add(new EventTriggerParameterItem(31, "short", "ChapterIndex"));
		_dataArray.Add(new EventTriggerParameterItem(32, "int", "VitalType"));
		_dataArray.Add(new EventTriggerParameterItem(33, "bool", "IsGoodEnd"));
		_dataArray.Add(new EventTriggerParameterItem(34, "int", "BossIndex"));
		_dataArray.Add(new EventTriggerParameterItem(35, "bool", "IsPickUpAll"));
		_dataArray.Add(new EventTriggerParameterItem(36, "int", "MapPickupIndex"));
		_dataArray.Add(new EventTriggerParameterItem(37, "sbyte", "CurrentPage"));
		_dataArray.Add(new EventTriggerParameterItem(38, "byte", "TreasuryOrPrisonVisitStatus"));
		_dataArray.Add(new EventTriggerParameterItem(39, "int", "SaveCount"));
		_dataArray.Add(new EventTriggerParameterItem(40, "sbyte", "Level"));
		_dataArray.Add(new EventTriggerParameterItem(41, "ItemKey", "EggItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(42, "ItemKey", "ItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(43, "int", "Count"));
		_dataArray.Add(new EventTriggerParameterItem(44, "bool", "ShowingGetItem"));
		_dataArray.Add(new EventTriggerParameterItem(45, "sbyte", "ConcessionCount"));
		_dataArray.Add(new EventTriggerParameterItem(46, "sbyte", "InducementCount"));
		_dataArray.Add(new EventTriggerParameterItem(47, "int", "InteractPrisonerType"));
		_dataArray.Add(new EventTriggerParameterItem(48, "int", "PresetInt"));
		_dataArray.Add(new EventTriggerParameterItem(49, "bool", "PresetBool"));
		_dataArray.Add(new EventTriggerParameterItem(50, "string", "OnFinishPassingLegacyEvent"));
		_dataArray.Add(new EventTriggerParameterItem(51, "ItemKey", "SelectItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(52, "bool", "BreakSuccess"));
		_dataArray.Add(new EventTriggerParameterItem(53, "short", "CombatSkillTemplateId"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventTriggerParameterItem>(54);
		CreateItems0();
	}
}
