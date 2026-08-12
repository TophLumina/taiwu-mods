using System;
using System.Collections.Generic;
using System.Linq;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerType : ConfigData<EventTriggerTypeItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾进行了一次地格移动
		/// </summary>
		public const int TaiwuBlockChanged = 0;

		/// <summary>
		/// 用户点击角色头像进行交互
		/// </summary>
		public const int CharacterClicked = 1;

		/// <summary>
		/// 用户点击动物头像进行交互
		/// </summary>
		public const int AnimalAvatarClicked = 2;

		/// <summary>
		/// 用户点击紫竹化身进行交互
		/// </summary>
		public const int PurpleBambooAvatarClicked = 3;

		/// <summary>
		/// 用户点击固定角色
		/// </summary>
		public const int FixedCharacterClicked = 4;

		/// <summary>
		/// 用户点击固定敌人
		/// </summary>
		public const int FixedEnemyClicked = 5;

		/// <summary>
		/// 用户点击模板敌人进行交互
		/// </summary>
		public const int CharacterTemplateClicked = 6;

		/// <summary>
		/// 用户点击坟墓进行交互
		/// </summary>
		public const int NpcTombClicked = 7;

		/// <summary>
		/// 和监牢犯人互动
		/// </summary>
		public const int InteractPrisoner = 8;

		/// <summary>
		/// 同道被直接遣离
		/// </summary>
		public const int LetTeammateLeaveGroup = 9;

		/// <summary>
		/// 需要传剑
		/// </summary>
		public const int NeedToPassLegacy = 10;

		/// <summary>
		/// 申请商队交互
		/// </summary>
		public const int CaravanClicked = 11;

		/// <summary>
		/// 申请俘虏交互
		/// </summary>
		public const int KidnappedCharacterClicked = 12;

		/// <summary>
		/// 存档进入游戏
		/// </summary>
		public const int RecordEnterGame = 13;

		/// <summary>
		/// 游戏时间到达了新的月份
		/// </summary>
		public const int NewGameMonth = 14;

		/// <summary>
		/// 黑屏动画控制结束
		/// </summary>
		public const int BlackMaskAnimationComplete = 15;

		/// <summary>
		/// 退出界面
		/// </summary>
		public const int CloseUI = 16;

		/// <summary>
		/// 进入产业视图
		/// </summary>
		public const int EnterBuildingArea = 62;

		/// <summary>
		/// 产业系统中点击建筑
		/// </summary>
		public const int SectBuildingClicked = 17;

		/// <summary>
		/// 产业系统建筑建造/扩建完毕
		/// </summary>
		public const int ConstructComplete = 18;

		/// <summary>
		/// 收取了制造的产物
		/// </summary>
		public const int CollectedMakingSystemItem = 19;

		/// <summary>
		/// 产业系统中点击门派特色建筑
		/// </summary>
		public const int OnSectSpecialBuildingClicked = 20;

		/// <summary>
		/// 产业系统中点击元鸡舍
		/// </summary>
		public const int OnClickedChickenCoop = 21;

		/// <summary>
		/// 产业系统中点击定居点库房
		/// </summary>
		public const int OnSettlementTreasuryBuildingClicked = 22;

		/// <summary>
		/// 切换监牢页面
		/// </summary>
		public const int SwitchToGuardedPage = 23;

		/// <summary>
		/// 太吾村被毁灭
		/// </summary>
		public const int TaiwuVillageDestroyed = 24;

		/// <summary>
		/// 监牢按钮
		/// </summary>
		public const int OnClickedPrisonBtn = 25;

		/// <summary>
		/// 收监按钮
		/// </summary>
		public const int OnClickedSendPrisonBtn = 26;

		/// <summary>
		/// 点击元鸡
		/// </summary>
		public const int ClickChicken = 27;

		/// <summary>
		/// 用户完成捕捉促织行为
		/// </summary>
		public const int MainStoryFinishCatchCricket = 28;

		/// <summary>
		/// 用户进入太吾梦回存档
		/// </summary>
		public const int UserLoadDreamBackArchive = 29;

		/// <summary>
		/// 较艺迫使不语被点击
		/// </summary>
		public const int LifeSkillCombatForceSilent = 30;

		/// <summary>
		/// 战斗开始
		/// </summary>
		public const int CombatOpening = 31;

		/// <summary>
		/// 志向系统资历进度发生变化
		/// </summary>
		public const int ProfessionExperienceChange = 32;

		/// <summary>
		/// 点击使用志向技能
		/// </summary>
		public const int ProfessionSkillClicked = 33;

		/// <summary>
		/// 太吾获得了天劫符箓
		/// </summary>
		public const int TaiwuGotTianjieFulu = 34;

		/// <summary>
		/// 太吾高僧超度人数改变
		/// </summary>
		public const int TaiwuSaveCountChange = 35;

		/// <summary>
		/// 太吾挖掘到心材
		/// </summary>
		public const int TaiwuFindMaterial = 36;

		/// <summary>
		/// 太吾挖掘到额外物品
		/// </summary>
		public const int TaiwuFindExtraTreasure = 37;

		/// <summary>
		/// 村民被逐出太吾村
		/// </summary>
		public const int TaiwuVillagerExpelled = 38;

		/// <summary>
		/// 太吾梦回
		/// </summary>
		public const int TaiwuCrossArchive = 39;

		/// <summary>
		/// 太吾梦回找回记忆
		/// </summary>
		public const int TaiwuCrossArchiveFindMemory = 40;

		/// <summary>
		/// 操作行囊物品
		/// </summary>
		public const int OperateInventoryItem = 41;

		/// <summary>
		/// 确认进入剑冢奇遇
		/// </summary>
		public const int ConfirmEnterSwordTomb = 42;

		/// <summary>
		/// 太吾被捕快押送至门派
		/// </summary>
		public const int TaiwuBeHuntedArrivedSect = 43;

		/// <summary>
		/// 太吾被捕快押送途中捕快死亡
		/// </summary>
		public const int TaiwuBeHuntedHunterDie = 44;

		/// <summary>
		/// 点击触发批量地格拾取物
		/// </summary>
		public const int TriggerBatchMapPickupEvent = 45;

		/// <summary>
		/// 点击触发地格拾取物
		/// </summary>
		public const int TriggerMapPickupEvent = 46;

		/// <summary>
		/// 进行邀约
		/// </summary>
		public const int TaiwuInvite = 47;

		/// <summary>
		/// 进入演武触发
		/// </summary>
		public const int EnterTutorialChapter = 48;

		/// <summary>
		/// 演武中在禁止移动时尝试移动
		/// </summary>
		public const int TryMoveWhenMoveDisabled = 49;

		/// <summary>
		/// 演武中尝试移动到不可到达地格
		/// </summary>
		public const int TryMoveToInvalidLocationInTutorial = 50;

		/// <summary>
		/// 太吾遣返三魔三才
		/// </summary>
		public const int TaiwuDeportVitals = 51;

		/// <summary>
		/// 伏龙地主决战丧魂钟效果逆转
		/// </summary>
		public const int SoulWitheringBellTransfer = 52;

		/// <summary>
		/// 铸剑地主捕捉贼人
		/// </summary>
		public const int CatchThief = 53;

		/// <summary>
		/// 狮相特殊互动打鼓多次
		/// </summary>
		public const int OnShixiangDrumClickedManyTimes = 54;

		/// <summary>
		/// 金刚地主点击转世按钮
		/// </summary>
		public const int JingangSectMainStoryReborn = 55;

		/// <summary>
		/// 金刚地主点击高升魂灵按钮
		/// </summary>
		public const int JingangSectMainStoryMonkSoul = 56;

		/// <summary>
		/// 太吾采集资源采到了神木种子
		/// </summary>
		public const int TaiwuCollectWudangHeavenlyTreeSeed = 57;

		/// <summary>
		/// 少林地区主线诛魔试炼开始挑战
		/// </summary>
		public const int StartSectShaolinDemonSlayer = 58;

		/// <summary>
		/// Dlc 蛟池初始互动
		/// </summary>
		public const int DlcLoongPutJiaoEggs = 59;

		/// <summary>
		/// Dlc 蛟池通常互动
		/// </summary>
		public const int DlcLoongInteractJiao = 60;

		/// <summary>
		/// Dlc 蛟池安抚
		/// </summary>
		public const int DlcLoongPetJiao = 61;

		/// <summary>
		/// 培育元鸡按钮
		/// </summary>
		public const int OnClickedCultivateFeather = 63;

		/// <summary>
		/// 旅行到达目的地
		/// </summary>
		public const int OnFinishTravel = 64;

		/// <summary>
		/// 点击残损巨剑
		/// </summary>
		public const int ClickDamageHugeSword = 65;

		/// <summary>
		/// 大事件节点
		/// </summary>
		public const int MajorEventPoint = 66;

		/// <summary>
		/// 太吾赠送杂物道具
		/// </summary>
		public const int TaiwuMiscGift = 67;

		/// <summary>
		/// 夜华夫人幻影袭击
		/// </summary>
		public const int TwelveImmortals2AttackTaiwu = 68;

		/// <summary>
		/// 首次走入十二仙影响范围
		/// </summary>
		public const int FirstIntoTwelveImmortalsImpactRange = 69;

		/// <summary>
		/// 点击峨眉指点图标
		/// </summary>
		public const int ClickEmeiGuidance = 70;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾进行了一次地格移动
		/// </summary>
		public static EventTriggerTypeItem TaiwuBlockChanged => Instance[0];

		/// <summary>
		/// 用户点击角色头像进行交互
		/// </summary>
		public static EventTriggerTypeItem CharacterClicked => Instance[1];

		/// <summary>
		/// 用户点击动物头像进行交互
		/// </summary>
		public static EventTriggerTypeItem AnimalAvatarClicked => Instance[2];

		/// <summary>
		/// 用户点击紫竹化身进行交互
		/// </summary>
		public static EventTriggerTypeItem PurpleBambooAvatarClicked => Instance[3];

		/// <summary>
		/// 用户点击固定角色
		/// </summary>
		public static EventTriggerTypeItem FixedCharacterClicked => Instance[4];

		/// <summary>
		/// 用户点击固定敌人
		/// </summary>
		public static EventTriggerTypeItem FixedEnemyClicked => Instance[5];

		/// <summary>
		/// 用户点击模板敌人进行交互
		/// </summary>
		public static EventTriggerTypeItem CharacterTemplateClicked => Instance[6];

		/// <summary>
		/// 用户点击坟墓进行交互
		/// </summary>
		public static EventTriggerTypeItem NpcTombClicked => Instance[7];

		/// <summary>
		/// 和监牢犯人互动
		/// </summary>
		public static EventTriggerTypeItem InteractPrisoner => Instance[8];

		/// <summary>
		/// 同道被直接遣离
		/// </summary>
		public static EventTriggerTypeItem LetTeammateLeaveGroup => Instance[9];

		/// <summary>
		/// 需要传剑
		/// </summary>
		public static EventTriggerTypeItem NeedToPassLegacy => Instance[10];

		/// <summary>
		/// 申请商队交互
		/// </summary>
		public static EventTriggerTypeItem CaravanClicked => Instance[11];

		/// <summary>
		/// 申请俘虏交互
		/// </summary>
		public static EventTriggerTypeItem KidnappedCharacterClicked => Instance[12];

		/// <summary>
		/// 存档进入游戏
		/// </summary>
		public static EventTriggerTypeItem RecordEnterGame => Instance[13];

		/// <summary>
		/// 游戏时间到达了新的月份
		/// </summary>
		public static EventTriggerTypeItem NewGameMonth => Instance[14];

		/// <summary>
		/// 黑屏动画控制结束
		/// </summary>
		public static EventTriggerTypeItem BlackMaskAnimationComplete => Instance[15];

		/// <summary>
		/// 退出界面
		/// </summary>
		public static EventTriggerTypeItem CloseUI => Instance[16];

		/// <summary>
		/// 进入产业视图
		/// </summary>
		public static EventTriggerTypeItem EnterBuildingArea => Instance[62];

		/// <summary>
		/// 产业系统中点击建筑
		/// </summary>
		public static EventTriggerTypeItem SectBuildingClicked => Instance[17];

		/// <summary>
		/// 产业系统建筑建造/扩建完毕
		/// </summary>
		public static EventTriggerTypeItem ConstructComplete => Instance[18];

		/// <summary>
		/// 收取了制造的产物
		/// </summary>
		public static EventTriggerTypeItem CollectedMakingSystemItem => Instance[19];

		/// <summary>
		/// 产业系统中点击门派特色建筑
		/// </summary>
		public static EventTriggerTypeItem OnSectSpecialBuildingClicked => Instance[20];

		/// <summary>
		/// 产业系统中点击元鸡舍
		/// </summary>
		public static EventTriggerTypeItem OnClickedChickenCoop => Instance[21];

		/// <summary>
		/// 产业系统中点击定居点库房
		/// </summary>
		public static EventTriggerTypeItem OnSettlementTreasuryBuildingClicked => Instance[22];

		/// <summary>
		/// 切换监牢页面
		/// </summary>
		public static EventTriggerTypeItem SwitchToGuardedPage => Instance[23];

		/// <summary>
		/// 太吾村被毁灭
		/// </summary>
		public static EventTriggerTypeItem TaiwuVillageDestroyed => Instance[24];

		/// <summary>
		/// 监牢按钮
		/// </summary>
		public static EventTriggerTypeItem OnClickedPrisonBtn => Instance[25];

		/// <summary>
		/// 收监按钮
		/// </summary>
		public static EventTriggerTypeItem OnClickedSendPrisonBtn => Instance[26];

		/// <summary>
		/// 点击元鸡
		/// </summary>
		public static EventTriggerTypeItem ClickChicken => Instance[27];

		/// <summary>
		/// 用户完成捕捉促织行为
		/// </summary>
		public static EventTriggerTypeItem MainStoryFinishCatchCricket => Instance[28];

		/// <summary>
		/// 用户进入太吾梦回存档
		/// </summary>
		public static EventTriggerTypeItem UserLoadDreamBackArchive => Instance[29];

		/// <summary>
		/// 较艺迫使不语被点击
		/// </summary>
		public static EventTriggerTypeItem LifeSkillCombatForceSilent => Instance[30];

		/// <summary>
		/// 战斗开始
		/// </summary>
		public static EventTriggerTypeItem CombatOpening => Instance[31];

		/// <summary>
		/// 志向系统资历进度发生变化
		/// </summary>
		public static EventTriggerTypeItem ProfessionExperienceChange => Instance[32];

		/// <summary>
		/// 点击使用志向技能
		/// </summary>
		public static EventTriggerTypeItem ProfessionSkillClicked => Instance[33];

		/// <summary>
		/// 太吾获得了天劫符箓
		/// </summary>
		public static EventTriggerTypeItem TaiwuGotTianjieFulu => Instance[34];

		/// <summary>
		/// 太吾高僧超度人数改变
		/// </summary>
		public static EventTriggerTypeItem TaiwuSaveCountChange => Instance[35];

		/// <summary>
		/// 太吾挖掘到心材
		/// </summary>
		public static EventTriggerTypeItem TaiwuFindMaterial => Instance[36];

		/// <summary>
		/// 太吾挖掘到额外物品
		/// </summary>
		public static EventTriggerTypeItem TaiwuFindExtraTreasure => Instance[37];

		/// <summary>
		/// 村民被逐出太吾村
		/// </summary>
		public static EventTriggerTypeItem TaiwuVillagerExpelled => Instance[38];

		/// <summary>
		/// 太吾梦回
		/// </summary>
		public static EventTriggerTypeItem TaiwuCrossArchive => Instance[39];

		/// <summary>
		/// 太吾梦回找回记忆
		/// </summary>
		public static EventTriggerTypeItem TaiwuCrossArchiveFindMemory => Instance[40];

		/// <summary>
		/// 操作行囊物品
		/// </summary>
		public static EventTriggerTypeItem OperateInventoryItem => Instance[41];

		/// <summary>
		/// 确认进入剑冢奇遇
		/// </summary>
		public static EventTriggerTypeItem ConfirmEnterSwordTomb => Instance[42];

		/// <summary>
		/// 太吾被捕快押送至门派
		/// </summary>
		public static EventTriggerTypeItem TaiwuBeHuntedArrivedSect => Instance[43];

		/// <summary>
		/// 太吾被捕快押送途中捕快死亡
		/// </summary>
		public static EventTriggerTypeItem TaiwuBeHuntedHunterDie => Instance[44];

		/// <summary>
		/// 点击触发批量地格拾取物
		/// </summary>
		public static EventTriggerTypeItem TriggerBatchMapPickupEvent => Instance[45];

		/// <summary>
		/// 点击触发地格拾取物
		/// </summary>
		public static EventTriggerTypeItem TriggerMapPickupEvent => Instance[46];

		/// <summary>
		/// 进行邀约
		/// </summary>
		public static EventTriggerTypeItem TaiwuInvite => Instance[47];

		/// <summary>
		/// 进入演武触发
		/// </summary>
		public static EventTriggerTypeItem EnterTutorialChapter => Instance[48];

		/// <summary>
		/// 演武中在禁止移动时尝试移动
		/// </summary>
		public static EventTriggerTypeItem TryMoveWhenMoveDisabled => Instance[49];

		/// <summary>
		/// 演武中尝试移动到不可到达地格
		/// </summary>
		public static EventTriggerTypeItem TryMoveToInvalidLocationInTutorial => Instance[50];

		/// <summary>
		/// 太吾遣返三魔三才
		/// </summary>
		public static EventTriggerTypeItem TaiwuDeportVitals => Instance[51];

		/// <summary>
		/// 伏龙地主决战丧魂钟效果逆转
		/// </summary>
		public static EventTriggerTypeItem SoulWitheringBellTransfer => Instance[52];

		/// <summary>
		/// 铸剑地主捕捉贼人
		/// </summary>
		public static EventTriggerTypeItem CatchThief => Instance[53];

		/// <summary>
		/// 狮相特殊互动打鼓多次
		/// </summary>
		public static EventTriggerTypeItem OnShixiangDrumClickedManyTimes => Instance[54];

		/// <summary>
		/// 金刚地主点击转世按钮
		/// </summary>
		public static EventTriggerTypeItem JingangSectMainStoryReborn => Instance[55];

		/// <summary>
		/// 金刚地主点击高升魂灵按钮
		/// </summary>
		public static EventTriggerTypeItem JingangSectMainStoryMonkSoul => Instance[56];

		/// <summary>
		/// 太吾采集资源采到了神木种子
		/// </summary>
		public static EventTriggerTypeItem TaiwuCollectWudangHeavenlyTreeSeed => Instance[57];

		/// <summary>
		/// 少林地区主线诛魔试炼开始挑战
		/// </summary>
		public static EventTriggerTypeItem StartSectShaolinDemonSlayer => Instance[58];

		/// <summary>
		/// Dlc 蛟池初始互动
		/// </summary>
		public static EventTriggerTypeItem DlcLoongPutJiaoEggs => Instance[59];

		/// <summary>
		/// Dlc 蛟池通常互动
		/// </summary>
		public static EventTriggerTypeItem DlcLoongInteractJiao => Instance[60];

		/// <summary>
		/// Dlc 蛟池安抚
		/// </summary>
		public static EventTriggerTypeItem DlcLoongPetJiao => Instance[61];

		/// <summary>
		/// 培育元鸡按钮
		/// </summary>
		public static EventTriggerTypeItem OnClickedCultivateFeather => Instance[63];

		/// <summary>
		/// 旅行到达目的地
		/// </summary>
		public static EventTriggerTypeItem OnFinishTravel => Instance[64];

		/// <summary>
		/// 点击残损巨剑
		/// </summary>
		public static EventTriggerTypeItem ClickDamageHugeSword => Instance[65];

		/// <summary>
		/// 大事件节点
		/// </summary>
		public static EventTriggerTypeItem MajorEventPoint => Instance[66];

		/// <summary>
		/// 太吾赠送杂物道具
		/// </summary>
		public static EventTriggerTypeItem TaiwuMiscGift => Instance[67];

		/// <summary>
		/// 夜华夫人幻影袭击
		/// </summary>
		public static EventTriggerTypeItem TwelveImmortals2AttackTaiwu => Instance[68];

		/// <summary>
		/// 首次走入十二仙影响范围
		/// </summary>
		public static EventTriggerTypeItem FirstIntoTwelveImmortalsImpactRange => Instance[69];

		/// <summary>
		/// 点击峨眉指点图标
		/// </summary>
		public static EventTriggerTypeItem ClickEmeiGuidance => Instance[70];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventTriggerType Instance = new EventTriggerType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Parameters", "TemplateId", "KeyCode" };

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
		_dataArray.Add(new EventTriggerTypeItem(0, new int[2] { 11, 12 }, "TaiwuBlockChanged", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(1, new int[1], "CharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(2, new int[1] { 3 }, "AnimalAvatarClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(3, new int[2] { 0, 10 }, "PurpleBambooAvatarClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(4, new int[2] { 0, 1 }, "FixedCharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(5, new int[2] { 0, 1 }, "FixedEnemyClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(6, new int[1] { 1 }, "CharacterTemplateClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(7, new int[1] { 2 }, "NpcTombClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(8, new int[2] { 0, 47 }, "InteractPrisoner", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(9, new int[1], "LetTeammateLeaveGroup", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(10, new int[2] { 14, 50 }, "NeedToPassLegacy", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(11, new int[1] { 4 }, "CaravanClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(12, new int[1], "KidnappedCharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(13, new int[0], "RecordEnterGame", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(14, new int[0], "NewGameMonth", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(15, new int[1] { 15 }, "BlackMaskAnimationComplete", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(16, new int[3] { 24, 49, 48 }, "CloseUI", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(17, new int[1] { 17 }, "SectBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(18, new int[3] { 16, 17, 40 }, "ConstructComplete", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(19, new int[3] { 16, 17, 44 }, "CollectedMakingSystemItem", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(20, new int[1] { 17 }, "OnSectSpecialBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(21, new int[0], "OnClickedChickenCoop", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(22, new int[2] { 17, 37 }, "OnSettlementTreasuryBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(23, new int[2] { 38, 37 }, "SwitchToGuardedPage", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(24, new int[0], "TaiwuVillageDestroyed", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(25, new int[1] { 17 }, "OnClickedPrisonBtn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(26, new int[0], "OnClickedSendPrisonBtn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(27, new int[2] { 5, 6 }, "ClickChicken", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(28, new int[1] { 18 }, "MainStoryFinishCatchCricket", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(29, new int[0], "UserLoadDreamBackArchive", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(30, new int[3] { 0, 45, 46 }, "LifeSkillCombatForceSilent", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(31, new int[1], "CombatOpening", canTriggerInAdvanceMonth: true, canTriggerInCombat: true, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(32, new int[1] { 19 }, "ProfessionExperienceChange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(33, new int[1] { 20 }, "ProfessionSkillClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(34, new int[3] { 0, 42, 43 }, "TaiwuGotTianjieFulu", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(35, new int[1] { 39 }, "TaiwuSaveCountChange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(36, new int[2] { 27, 28 }, "TaiwuFindMaterial", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(37, new int[1] { 28 }, "TaiwuFindExtraTreasure", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(38, new int[1], "TaiwuVillagerExpelled", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(39, new int[0], "TaiwuCrossArchive", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(40, new int[1] { 29 }, "TaiwuCrossArchiveFindMemory", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(41, new int[4] { 0, 30, 51, 13 }, "OperateInventoryItem", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(42, new int[0], "ConfirmEnterSwordTomb", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(43, new int[1], "TaiwuBeHuntedArrivedSect", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(44, new int[1], "TaiwuBeHuntedHunterDie", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(45, new int[3] { 8, 35, 36 }, "TriggerBatchMapPickupEvent", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(46, new int[2] { 8, 23 }, "TriggerMapPickupEvent", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(47, new int[2] { 0, 9 }, "TaiwuInvite", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(48, new int[1] { 31 }, "EnterTutorialChapter", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(49, new int[0], "TryMoveWhenMoveDisabled", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(50, new int[0], "TryMoveToInvalidLocationInTutorial", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(51, new int[2] { 32, 33 }, "TaiwuDeportVitals", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(52, new int[0], "SoulWitheringBellTransfer", canTriggerInAdvanceMonth: false, canTriggerInCombat: true, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(53, new int[2] { 25, 26 }, "CatchThief", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(54, new int[0], "OnShixiangDrumClickedManyTimes", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(55, new int[0], "JingangSectMainStoryReborn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(56, new int[0], "JingangSectMainStoryMonkSoul", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(57, new int[1] { 22 }, "TaiwuCollectWudangHeavenlyTreeSeed", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(58, new int[1] { 34 }, "StartSectShaolinDemonSlayer", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(59, new int[2] { 21, 41 }, "DlcLoongPutJiaoEggs", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventTriggerTypeItem(60, new int[1] { 21 }, "DlcLoongInteractJiao", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(61, new int[1] { 21 }, "DlcLoongPetJiao", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(62, new int[1] { 8 }, "EnterBuildingArea", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(63, new int[0], "OnClickedCultivateFeather", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(64, new int[0], "OnFinishTravel", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(65, new int[0], "ClickDamageHugeSword", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(66, new int[0], "MajorEventPoint", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(67, new int[2] { 0, 7 }, "TaiwuMiscGift", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(68, new int[0], "TwelveImmortals2AttackTaiwu", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(69, new int[1], "FirstIntoTwelveImmortalsImpactRange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(70, new int[1], "ClickEmeiGuidance", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventTriggerTypeItem>(71);
		CreateItems0();
		CreateItems1();
	}

	public EventTriggerTypeItem GetByKeyCode(string keyCode)
	{
		return this.FirstOrDefault((EventTriggerTypeItem trigger) => trigger.KeyCode == keyCode);
	}
}
