using System;

namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 事件系统监听时等待完成的行为名字
/// </summary>
public static class EventActionNames
{
	/// <summary>
	/// 获得物品显示完毕
	/// </summary>
	public const string GetItemShowed = "GetItemShowed";

	/// <summary>
	/// 战斗结束
	/// </summary>
	public const string CombatOver = "CombatOver";

	/// <summary>
	/// 战斗准备界面已打开
	/// </summary>
	public const string CombatPrepareOnShowed = "CombatPrepareOnShowed";

	/// <summary>
	/// 战斗中与敌方距离发生变化回调
	/// </summary>
	public const string CombatDistanceWithEnemyChanged = "CombatDistanceWithEnemyChanged";

	/// <summary>
	/// 幽蟒伤势变化
	/// </summary>
	public const string CombatSnakeInjuryChanged = "CombatSnakeInjuryChanged";

	/// <summary>
	/// 战斗中普通攻击结束
	/// </summary>
	public const string CombatNormalAttackEnd = "CombatNormalAttackEnd";

	/// <summary>
	/// 战斗中功法施展准备完毕
	/// </summary>
	public const string CombatSkillPrepareEnd = "CombatSkillPrepareEnd";

	/// <summary>
	/// 战斗中功法施展完毕
	/// </summary>
	public const string CombatSkillCastEnd = "CombatSkillCastEnd";

	/// <summary>
	/// 输入行为执行完毕
	/// </summary>
	public const string InputActionComplete = "InputActionComplete";

	/// <summary>
	/// 过月通知显示完毕
	/// </summary>
	public const string MonthNotifyShowed = "MonthNotifyShowed";

	/// <summary>
	/// 退出奇遇
	/// </summary>
	public const string ExitAdventure = "ExitAdventure";

	/// <summary>
	/// 退出大事件
	/// </summary>
	public const string ExitMajorEvent = "ExitMajorEvent";

	/// <summary>
	/// 商店交易完毕
	/// </summary>
	public const string ShopActionComplete = "ShopActionComplete";

	/// <summary>
	/// 交换藏书界面
	/// </summary>
	public const string ExchangeBookComplete = "ExchangeBookComplete";

	/// <summary>
	/// 交换物资界面
	/// </summary>
	public const string ExchangeComplete = "ExchangeComplete";

	/// <summary>
	/// 促织决斗结束
	/// </summary>
	public const string CricketCombatOver = "CricketCombatOver";

	/// <summary>
	/// 捉蛐蛐结束
	/// </summary>
	public const string CricketCatchOver = "CricketCatchOver";

	/// <summary>
	/// 梳头修面行为结束
	/// </summary>
	public const string CharacterShaveComplete = "CharacterShaveComplete";

	/// <summary>
	/// 驱毒疗伤行为结束
	/// </summary>
	public const string HealActionComplete = "HealActionComplete";

	/// <summary>
	/// 较艺界面
	/// </summary>
	public const string LifeSkillBattleComplete = "LifeSkillBattleComplete";

	/// <summary>
	/// 播放过场动画完毕
	/// </summary>
	public const string PerformCutsceneComplete = "PerformCutsceneComplete";

	/// <summary>
	/// CG播放行为完毕
	/// </summary>
	public const string CgPlayActionFinish = "CgPlayActionFinish";

	/// <summary>
	/// 选择继承人行为完毕
	/// </summary>
	[Obsolete]
	public const string SelectSuccessorComplete = "SelectSuccessorComplete";

	/// <summary>
	/// 传剑行为完毕
	/// </summary>
	public const string PassingLegacyComplete = "PassingLegacyComplete";

	/// <summary>
	/// 相枢绘卷显示完毕
	/// </summary>
	public const string GameLineScrollShowed = "GameLineScrollShowed";

	/// <summary>
	/// 移动染尘子和太吾到双姝争锋完毕
	/// </summary>
	public const string MoveTaiwuAndRanChenZiComplete = "MoveTaiwuAndRanChenZiComplete";

	/// <summary>
	/// 主线-顺河而下
	/// </summary>
	public const string MainStoryMeetMapRiver = "MainstoryMeetMapRiver";

	/// <summary>
	/// 主线-豪言壮语
	/// </summary>
	public const string MainStoryHeroicWords = "MainStoryHeroicWords";

	/// <summary>
	/// 主线-抵达太吾村区域
	/// </summary>
	public const string MainStoryEnterTaiwuArea = "MainStotyEnterTaiwuArea";

	/// <summary>
	/// 主线-旅行到过去的太吾村
	/// </summary>
	public const string TravelToPastTaiwuVillage = "TravelToPastTaiwuVillage";

	public const string BackFromPastTaiwuVillage = "BackFromPastTaiwuVillage";

	/// <summary>
	/// 主线-剑冢现世表现完毕
	/// </summary>
	public const string MainStorySwordTombAppearComplete = "MainStorySwordTombAppearComplete";

	/// <summary>
	/// 解锁荒废驿站表现完毕
	/// </summary>
	public const string UnlockTaiwuStationComplete = "UnlockTaiwuStationComplete";

	/// <summary>
	/// 演武-打开了产业视图
	/// </summary>
	public const string TutorialChaptersBuildingAreaShowed = "TutorialChaptersBuildingAreaShowed";

	/// <summary>
	/// 演武尝试过月
	/// </summary>
	public const string TutorialChaptersTryAdvanceMonth = "TutorialChaptersTryAdvanceMonth";

	/// <summary>
	/// 制造系统显示完毕
	/// </summary>
	public const string MakeSystemShowed = "MakeSystemShowed";

	/// <summary>
	/// 演武视频失去焦点
	/// </summary>
	public const string TutorialVideoLostFocus = "TutorialVedioLostFocus";

	/// <summary>
	/// 演武中设置沛然诀为周天运转内功
	/// </summary>
	public const string SetPeiRanJueAsLoopNeigongInTutorial = "SetPeiRanJueAsLoopNeigongInTutorial";

	/// <summary>
	/// 演武完成研读天枢玄机
	/// </summary>
	public const string FinishReadingTianShuXuanJi = "FinishReadingTianShuXuanJi";

	/// <summary>
	/// 演武完成修习天枢玄机
	/// </summary>
	public const string FinishPracticeTianShuXuanJi = "FinishPracticeTianShuXuanJi";

	/// <summary>
	/// 演武完成突破天枢玄机
	/// 突破成功/突破失败都会通知事件系统这个监听触发点
	/// </summary>
	public const string FinishBreakTianShuXuanJi = "FinishBreakTianShuXuanJi";

	/// <summary>
	/// 演武七完成内力分配
	/// </summary>
	public const string FinishNeiliAllocateInTutorial7 = "FinishNeiliAllocateInTutorial7";

	/// <summary>
	/// 选择人物结束
	/// </summary>
	public const string SelectCharOver = "SelectCharOver";

	/// <summary>
	/// 升级版选择人物行为结束
	/// </summary>
	public const string UltimateSelectCharOver = " UltimateSelectCharOver";

	/// <summary>
	/// 商会总部交易结束，富商二技能用
	/// </summary>
	public const string MerchantShopClose = "MerchantShopClose";

	/// <summary>
	/// 确认技能执行(如果有动画播放需求在动画播放完毕之后)
	/// </summary>
	public const string ConfirmProfessionSkillExecuteAndAnimComplete = "ConfirmProfessionSkillExecuteAndAnimComplete";

	/// <summary>
	/// 技能解锁动画播放完成
	/// </summary>
	[Obsolete]
	public const string OpenProfessionSkillUnlocked = "OpenProfessionSkillUnlocked";

	/// <summary>
	/// 地区主线结局画卷播放完
	/// </summary>
	public const string SectMainStoryScrollShowed = "SectMainStoryScrollShowed";

	/// <summary>
	/// 挖掘宝藏动画播放完
	/// </summary>
	public const string FindTreasureMaterial = "FindTreasureMaterial";

	/// <summary>
	/// 选择地区完毕
	/// </summary>
	public const string SelectMapAreaOver = "SelectMapAreaOver";

	/// <summary>
	/// 世界地图抖动结束
	/// </summary>
	public const string WorldMapShaken = "WorldMapShaken";

	/// <summary>
	/// 修改书页完成
	/// </summary>
	public const string BookModified = "BookModified";

	/// <summary>
	/// 修改同道指令完成
	/// </summary>
	public const string UpgradeTeammateCommand = "UpgradeTeammateCommand";

	/// <summary>
	/// 守卫神木
	/// </summary>
	public const string DefendHeavenlyTree = "DefendHeavenlyTree";

	/// <summary>
	/// 世界地图已聚焦
	/// </summary>
	public const string WorldMapFocused = "WorldMapFocused";

	/// <summary>
	/// 已完成对话框界面的选择
	/// </summary>
	public const string DialogChoiceMade = "DialogChoiceMade";

	/// <summary>
	/// 峨眉特殊功法突破
	/// </summary>
	public const string CombatSkillSpecialBreak = "CombatSkillSpecialBreak";

	/// <summary>
	/// 前端UI_BlackMask显示遮罩完成
	/// </summary>
	public const string OnBlackMaskShowComplete = "OnBlackMaskShowComplete";

	/// <summary>
	/// 前端UI_BlackMask隐藏遮罩完成
	/// </summary>
	public const string OnBlackMaskHideComplete = "OnBlackMaskHideComplete";

	/// <summary>
	/// 遗惠选择完成
	/// </summary>
	public const string SelectLegacyComplete = "SelectLegacyComplete";

	/// <summary>
	/// 伏虞剑移动结束
	/// </summary>
	public const string FuyuMoveFinish = "FuyuMoveFinish";

	/// <summary>
	/// CG显示倒计时结束
	/// </summary>
	public const string TextureShowCountDown = "TextureShowCountDown";

	/// <summary>
	/// 蛟龙养育方案对话框
	/// </summary>
	public const string DlcLoongJiaoDialog = "DlcLoongJiaoDialog";

	/// <summary>
	/// 播放神龙debuff动画
	/// </summary>
	public const string PlayLoongDebuffAnimation = "PlayLoongDebuffAnimation";

	/// <summary>
	/// 百花地主特殊互动结束
	/// </summary>
	public const string FinishBaihuaSectMainStorySpecial = "FinishBaihuaSectMainStorySpecial";

	/// <summary>
	/// 定居点监牢交互结束
	/// </summary>
	public const string SettlementPrisonComplete = "SettlementPrisonComplete";

	/// <summary>
	/// 打开仓库结束
	/// </summary>
	public const string WarehouseShowed = "WarehouseShowed";

	/// <summary>
	/// 云游道3技能执行
	/// </summary>
	public const string TravelingTaoistMonkSkill2Executed = "TravelingTaoistMonkSkill2Executed";

	/// <summary>
	/// 检测敏感词
	/// </summary>
	public const string CheckSensitiveWord = "CheckSensitiveWord";

	/// <summary>
	/// 恩义互动-州府条例界面 结束，可以自定义罪行程度
	/// </summary>
	public const string FinishCityPunishmentSeverityCustomizeUI = "FinishCityPunishmentSeverityCustomizeUI";

	/// <summary>
	/// 元山小游戏互动-结束游戏
	/// </summary>
	public const string FinishYuanshanMiniGame = "FinishYuanshanMiniGame";

	/// <summary>
	/// 结束选择功法
	/// </summary>
	public const string FinishSelectCombatSkill = "FinishSelectCombatSkill";

	/// <summary>
	/// 选择特性结束
	/// </summary>
	public const string SelectCharacterFeatureFinish = "SelectCharacterFeatureFinish";

	/// <summary>
	/// 匠人面板
	/// </summary>
	public const string FinishCraftsmanPanelUI = "FinishCraftsmanPanelUI";

	/// <summary>
	/// 打开地主解锁界面
	/// </summary>
	public const string ShowSectMainStoryUnlock = "ShowSectMainStoryUnlock";

	/// <summary>
	/// 打开地主升级互动界面
	/// </summary>
	public const string ShowSectMainStorySpecialInteract = "ShowSectMainStorySpecialInteract";

	/// <summary>
	/// 退出新版奇遇
	/// </summary>
	public const string AdventureRemakeExit = "AdventureRemakeExit";

	/// <summary>
	/// 功能解锁显示完毕
	/// </summary>
	public const string NewFeatureHintShowed = "NewFeatureHintShowed";

	/// <summary>
	/// 确认地区剧情开启和PV查看弹窗
	/// </summary>
	public const string SectStoryPopUpToggle = "SectStoryPopUpToggle";

	/// <summary>
	/// 镜头移动结束
	/// </summary>
	public const string AdventureCameraMoveToBlockFinish = "AdventureCameraMoveToBlockFinish";

	/// <summary>
	/// 等待一定时间  结束
	/// </summary>
	public const string AdventureDelayFinish = "AdventureDelayFinish";

	/// <summary>
	/// 奇遇选择元素结束
	/// </summary>
	public const string AdventureSelectElementFinish = "AdventureSelectElementFinish";

	/// <summary>
	/// 切换日期显示效果结束
	/// </summary>
	public const string AfterSwitchDateDisplayFinish = "AfterSwitchDateDisplayFinish";

	/// <summary>
	/// 促织化人表演结束
	/// </summary>
	public const string CricketPolymorphEffectOver = "CricketPolymorphEffectOver";

	/// <summary>
	/// 运功栏增加的全屏动画提示结束
	/// </summary>
	public const string ShowUnlockSkillSlotAnimOver = "ShowUnlockSkillSlotAnimOver";

	/// <summary>
	/// 播放交互判断动画结束
	/// </summary>
	public const string PlayInteractCheckAnimationFinish = "PlayInteractCheckAnimationFinish";
}
