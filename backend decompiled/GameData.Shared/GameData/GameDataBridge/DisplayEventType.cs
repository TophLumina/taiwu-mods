using System;

namespace GameData.GameDataBridge;

/// <summary>
/// 数据模块推送给表现模块的事件的类型.
/// *** 添加新类型时, 需要写清楚所需要的参数, 以及每个参数的类型, 方便其他人调用. ***
/// *** 事件的参数在前后端的一致性由各个事件的创建者保证. ***
/// </summary>
public enum DisplayEventType : ushort
{
	/// <summary>
	/// 开启捕捉蛐蛐界面.
	/// 参数: 无.
	/// </summary>
	OpenCatchCricket,
	/// <summary>
	/// 结束奇遇.
	/// 参数: 无.
	/// </summary>
	ExitAdventure,
	/// <summary>
	/// 开启蛐蛐战斗.
	/// 参数: 对手 ID (int).
	/// </summary>
	OpenCricketBattle,
	/// <summary>
	/// 开启接受配置的蛐蛐战斗
	/// </summary>
	OpenCricketBattleWithConfig,
	/// <summary>
	/// 开启商店.
	/// 参数: 商人 ID (int).
	/// </summary>
	OpenShop,
	/// <summary>
	/// 开启藏书交换.
	/// 参数: 交易对象 ID (int).
	/// </summary>
	OpenBookTrade,
	/// <summary>
	/// 停止自动开始战斗
	/// </summary>
	StopAutoStartCombat,
	/// <summary>
	/// 开始战斗.
	/// 参数: 对手队伍角色 ID 集合 (List[int]), 战斗配置 ID (short).
	/// </summary>
	StartCombat,
	/// <summary>
	/// 战斗准备界面修改同道指令
	/// 参数: bool isAlly, 修改后的同道指令列表 List{sbyte}
	/// </summary>
	ChangeTeammateCommandOnCombatBegin,
	/// <summary>
	/// 战中同道气泡演出
	/// 参数：气泡显示数据 (TeammateCommandDisplayData)
	/// </summary>
	CombatShowCommand,
	/// <summary>
	/// 战中特效跳字演出
	/// 参数：跳字显示数据 (bool isAlly, ShowSpecialEffectDisplayData data)
	/// </summary>
	CombatShowSpecialEffect,
	/// <summary>
	/// 战斗投降表现
	/// 参数：投降表现数据 (List{int}，转为 List{DefeatMarkKey} 使用)
	/// </summary>
	CombatShowSurrenderMark,
	/// <summary>
	/// 战斗逃跑表现
	/// 参数：战败角色 ID (int fleeCharId), 战败角色动画 (string, fleeAnimation)
	/// </summary>
	CombatShowFleeAnimation,
	/// <summary>
	/// 战斗吸取真气表现
	/// 参数：被吸取真气角色 ID (int srcCharId)，吸取真气角色 ID (int dstCharId)，真气类型 (byte neiliAllocationType)
	/// </summary>
	CombatShowAbsorbNeiliAllocation,
	/// <summary>
	/// 战斗天髓宝箓获得灵文秘文表现
	/// 参数：是否为灵文 (bool isDirect)，获得灵文秘文的角色 ID (int charId)
	/// </summary>
	CombatShowTianSuiBaoLu,
	/// <summary>
	/// 演武进程.
	/// 参数: 对话框标题 (string), 对话框内容 (string).
	/// </summary>
	ShowDialogFromEvent,
	/// <summary>
	/// 开启较艺.
	/// 参数: 对手 ID (int).
	/// </summary>
	OpenLifeSkillCombat,
	/// <summary>
	/// 返回演武章节界面.
	/// 参数: 章节数 (int).
	/// </summary>
	BackToTutorialChapterMenu,
	/// <summary>
	/// 刷新当前州内商队数据.
	/// 参数: List[(int, short, short, CaravanPath)].
	/// TODO 改成实现了 ISerializableGameData 的类
	/// </summary>
	RefreshCaravanData,
	/// <summary>
	/// 推送消息到前端 GM 面板.
	/// 参数: 消息文本 (string).
	/// </summary>
	ShowGmPanelMessage,
	/// <summary>
	/// 事件触发洗头修面.
	/// 参数: cutterCharId (int), targetCharId (int).
	/// </summary>
	StartShavingActionByEvent,
	/// <summary>
	/// 为主线捕捉促织阶段打开过月通知，显示促织虫鸣事件
	/// </summary>
	OpenMonthNotifyForCricketContent,
	/// <summary>
	/// 打开大事件准备界面
	/// </summary>
	OpenMajorEventPrepare,
	/// <summary>
	/// 打开奇遇准备界面
	/// </summary>
	OpenAdventurePrepare,
	/// <summary>
	/// 操作黑色遮罩界面
	/// 参数1：showMask(bool)  true - 渐变显示黑色遮罩 false-渐变隐藏黑色遮罩
	/// 参数2：tweenTime(float) 动画渐变时长
	/// 参数3：hideViewAfterAnimation(bool) 动画渐变完毕是否隐藏遮罩界面
	/// </summary>
	OperateBlackMaskView,
	/// <summary>
	/// 开始进行剑冢出现的表现
	/// </summary>
	StartCreateSwordTomb,
	/// <summary>
	/// 移除一个剑冢
	/// </summary>
	RemoveSwordTomb,
	/// <summary>
	/// 开始解锁荒废驿站的表现
	/// </summary>
	StartUnlockTaiwuStation,
	/// <summary>
	/// 打开贴图展示界面
	/// </summary>
	OpenPictureShow,
	/// <summary>
	/// 打开获得界面-展示获得物品
	/// </summary>
	OpenGetItem_Item,
	/// <summary>
	/// 打开获得界面-展示获得元鸡
	/// </summary>
	OpenGetItem_Chicken,
	/// <summary>
	/// 打开获得界面-展示获得角色
	/// </summary>
	OpenGetItem_Character,
	/// <summary>
	/// 打开获得界面-展示获得秘闻
	/// </summary>
	OpenGetItem_SecretInformation,
	/// <summary>
	/// 打开获得界面-展示获得遗惠
	/// </summary>
	OpenGetItem_Legacy,
	/// <summary>
	/// 打开获得界面-展示获得特性
	/// </summary>
	OpenGetItem_Feature,
	/// <summary>
	/// 展示事件CG贴图
	/// </summary>
	ShowEventCgTexture,
	/// <summary>
	/// 打开传剑激活界面
	/// </summary>
	OpenLegacyActivate,
	/// <summary>
	/// 主线移动太吾和染尘子
	/// </summary>
	MainStoryMoveTaiwuAndRanChenZi,
	/// <summary>
	/// 音频播放命令
	/// </summary>
	PlayAudioCommand,
	/// <summary>
	/// 视频播放命令
	/// </summary>
	PlayMediaCommand,
	/// <summary>
	/// 过场动画播放
	/// </summary>
	PerformCutscene,
	/// <summary>
	/// 设置主线背景音乐
	/// </summary>
	SetMainStoryBgm,
	/// <summary>
	/// 一个区域传送的信息
	/// </summary>
	AreaTravelCommand,
	/// <summary>
	/// 较艺迫使不语结果
	/// 参数1：迫使不语类型 <see cref="T:GameData.Domains.TaiwuEvent.Enum.LifeSkillCombatForceSilentType" />
	/// 参数2：迫使不语结果 bool
	/// </summary>
	LifeSkillCombatForceSilentResult,
	/// <summary>
	/// 打开选择人物界面，选择魂魄
	/// </summary>
	SelectCharSoul,
	/// <summary>
	/// 打开设置武器式界面
	/// </summary>
	OpenChangeWeaponTrick,
	/// <summary>
	/// 打开投资商队界面
	/// </summary>
	OpenInvestCaravan,
	/// <summary>
	/// 打开制造药品的界面
	/// </summary>
	OpenMakeMedicine,
	/// <summary>
	/// 打开技能使用的确认界面
	/// </summary>
	ConfirmProfessionSkillExecute,
	/// <summary>
	/// 了悟轮回选择轮回母亲
	/// </summary>
	UltimateSelectCharacterForDirectSamsaraMother,
	/// <summary>
	/// 打开四阶技能的动画表现界面
	/// </summary>
	ConfirmSkillExecuteAndPlayAnim,
	/// <summary>
	/// 打开志向技能解锁的界面
	/// </summary>
	OpenProfessionSkillUnlocked,
	/// <summary>
	/// 设置前端禁止移动
	/// </summary>
	SetDisableMoving,
	/// <summary>
	/// 设置事件系统阻止用户输入的状态
	/// </summary>
	SetEventLockInputState,
	/// <summary>
	/// 事件系统后端已完成全部已触发事件的处理
	/// </summary>
	EventHandleComplete,
	/// <summary>
	/// 打开地区主线结局绘卷
	/// </summary>
	SectMainStoryEndScroll,
	/// <summary>
	/// 打开挖掘宝藏界面
	/// </summary>
	FindTreasureMaterial,
	/// <summary>
	/// 关闭人物信息界面
	/// </summary>
	CloseCharacterMenu,
	/// <summary>
	/// 打开空桑选择地区界面
	/// 应注意，这是空桑专用界面，左边有一个鼎，与其他界面不通用
	/// </summary>
	OpenKongsangSelectMapArea,
	/// <summary>
	/// 隐藏产业界面
	/// </summary>
	HideBuildingArea,
	/// <summary>
	/// 世界地图抖动
	/// </summary>
	WorldMapDoShakeByEvent,
	/// <summary>
	/// 少林地区主线特殊互动
	/// </summary>
	OpenSectShaolinDemonSlayer,
	/// <summary>
	/// 打开修改书页界面
	/// </summary>
	OpenModifyBook,
	/// <summary>
	/// 打开同道指令升级界面
	/// </summary>
	OpenUpgradeTeammateCommand,
	/// <summary>
	/// 打开守卫神木
	/// </summary>
	OpenDefendHeavenlyTree,
	/// <summary>
	/// 打开神采非凡 促织页面
	/// </summary>
	OpenExtraordinaryCricket,
	/// <summary>
	/// 世界地图聚焦
	/// float: duration 聚焦秒数
	/// </summary>
	WorldMapDoFocusByEvent,
	/// <summary>
	/// 由于某些数据已经过期，强制清空经历缓存
	/// </summary>
	ForceClearLifeRecordCache,
	/// <summary>
	/// 打开峨眉功法特殊突破界面
	/// </summary>
	OpenCombatSkillSpecialBreak,
	/// <summary>
	/// 太吾梦回
	/// </summary>
	TaiwuCrossArchive,
	/// <summary>
	/// 太吾梦回前端特殊效果
	/// </summary>
	TaiwuCrossArchiveSpecialEffect,
	/// <summary>
	/// 打开事件确认弹窗
	/// </summary>
	ShowEventConfirmWindow,
	/// <summary>
	/// 伏虞剑柄移动
	/// </summary>
	FuyuHiltMove,
	/// <summary>
	/// 伏虞剑柄引导结束
	/// </summary>
	FuyuHiltGuidingFinish,
	/// <summary>
	/// 打开遗惠界面
	/// </summary>
	OpenSelectLegacy,
	/// <summary>
	/// 梦回融合功法冲突时打开人物功法界面
	/// </summary>
	OpenCombatConflict,
	/// <summary>
	/// 梦回专用音效开关设置
	/// </summary>
	DreamBackSetAudioSetting,
	/// <summary>
	/// 刷新蛟池状态
	/// </summary>
	RenderJiaoPoolState,
	/// <summary>
	/// 确认蛟池养育方案弹窗
	/// </summary>
	ConfirmJiaoNurturanceDialog,
	/// <summary>
	/// 播放神龙debuff动效
	/// </summary>
	PlayLoongDebuffAnimation,
	/// <summary>
	/// 提供给 Mod 的后端调用前端接口
	/// param0 - modIdStr : string
	/// param1 - customData : string
	/// </summary>
	ModDisplayEvent,
	/// <summary>
	/// 五仙万蛊坛
	/// </summary>
	WuxianWugFairy,
	/// <summary>
	/// 五仙升级互动-驱动王蛊界面
	/// </summary>
	WuxianWugKingDrive,
	/// <summary>
	/// 然山托管奇书
	/// </summary>
	RanshanLegendaryBookKeeping,
	/// <summary>
	/// 百花特殊互动界面
	/// </summary>
	BaihuaSectMainStorySpecial,
	/// <summary>
	/// 定居点库房事件
	/// </summary>
	SettlementTreasuryEffect,
	/// <summary>
	/// 打开定居点监牢
	/// </summary>
	OpenSettlementPrison,
	/// <summary>
	/// 打开仓库界面
	/// </summary>
	OpenWarehouse,
	/// <summary>
	/// 打开志向技能的特殊界面
	/// 贵客/豪客/乞丐/旅人/云游僧
	/// </summary>
	OpenProfessionSkillSpecial,
	/// <summary>
	/// 打开贵客/豪客的结算界面
	/// </summary>
	OpenTasterUltimateResult,
	/// <summary>
	/// 打开云游道3技能界面
	/// </summary>
	/// 参数：对象Id(int)
	OpenTravelingTaoistMonkSkill2,
	/// <summary>
	/// 打开金口玉言 秘闻选择界面
	/// </summary>
	OpenSelectSecretInformationLiteratiSkill2,
	/// <summary>
	/// 打开谈天说地 见闻选择界面
	/// </summary>
	OpenSelectNormalInformationLiteratiSkill3,
	/// <summary>
	/// 打开复活促织 促织选择界面
	/// </summary>
	OpenSelectCricketDukeSkill2,
	/// <summary>
	/// 太吾被捕
	/// </summary>
	TaiwuBeKidnapped,
	/// <summary>
	/// 志向额外技能解锁
	/// </summary>
	ExtraProfessionSkillUnlocked,
	/// <summary>
	/// 隐藏大地图
	/// </summary>
	HidePartWorldMap,
	/// <summary>
	/// 通知前端显示一个弹窗
	/// 参数：对话框标题 (string), 对话框内容 (string)
	/// 采用和<see cref="F:GameData.GameDataBridge.DisplayEventType.ShowDialogFromEvent" />一样的格式
	/// </summary>
	ShowNormalDialog,
	/// <summary>
	/// 互动检测动画
	/// </summary>
	InteractCheckAnimation,
	/// <summary>
	/// 检测敏感词
	/// </summary>
	CheckSensitiveWord,
	/// <summary>
	/// 打开恩义互动-州府条例界面，可以自定义罪行程度
	/// </summary>
	OpenCityPunishmentSeverityCustomizeUI,
	/// <summary>
	/// 身份互动-大夫-疗伤驱毒
	/// </summary>
	StartDoctorHeal,
	/// <summary>
	/// 开始治疗
	/// </summary>
	StartHeal,
	/// <summary>
	/// 开始选择功法
	/// </summary>
	SelectCombatSkill,
	/// <summary>
	/// 选择诛魔试炼人物特性
	/// </summary>
	SelectDemonSlayerCharacterFeature,
	/// <summary>
	/// 选择人物特性
	/// </summary>
	CommonSelectCharacterFeature,
	/// <summary>
	/// 解锁较艺策略
	/// </summary>
	UnlockLifeSkillCombatStrategy,
	/// <summary>
	/// 改变较艺中的数据，比如GM抽卡
	/// </summary>
	ChangeLifeSkillCombatData,
	/// <summary>
	/// 让前端播放拾取物获得的特效
	/// </summary>
	PlayMapPickupEffect,
	/// <summary>
	/// 打开匠人面板
	/// </summary>
	OpenCraftsmanPanelUI,
	/// <summary>
	/// 武当初始逆练
	/// </summary>
	SectMainStoryWudangStart,
	/// <summary>
	/// 让前端播放元山小游戏动画
	/// </summary>
	ShowYuanshanMiniGame,
	/// <summary>
	/// 播放三才/三魔入狱/出狱动画
	/// </summary>
	PlayVitalAnim,
	/// <summary>
	/// 修改前端的监牢访问状态以完成切换页签，需传一个byte代表为监牢访问状态，再传一个sbyte代表为当前开启页签，-1为不修改页签
	/// </summary>
	SwitchGuardedPageStatus,
	/// <summary>
	/// 打开地主解锁界面
	/// </summary>
	ShowSectMainStoryUnlock,
	/// <summary>
	///  打开地主升级互动界面
	/// </summary>
	ShowSectMainStorySpecialInteract,
	/// <summary>
	/// 改变音乐播放状态
	/// </summary>
	ChangeMusicStatus,
	/// <summary>
	/// 改变音效播放状态
	/// </summary>
	ChangeSoundStatus,
	/// <summary>
	/// 改变音乐音量大小
	/// </summary>
	ChangeMusicVolume,
	/// <summary>
	/// 播放音乐指定次数
	/// </summary>
	PlayMusicForCount,
	/// <summary>
	/// 新版奇遇完成时调用，未完成时不调用
	/// </summary>
	ShowAdventureFinish,
	/// <summary>
	/// 新版奇遇元素播放警戒动画
	/// </summary>
	AdventureElementAlertAnim,
	/// <summary>
	/// 新版奇遇地形素材转换
	/// </summary>
	AdventureBlockChangeIcon,
	/// <summary>
	/// 奇遇元素出现消失特效播放
	/// </summary>
	AdventureElementShowHideEffect,
	/// <summary>
	/// 地格分组添加删除氛围特效
	/// </summary>
	[Obsolete]
	AdventureGroupEffect,
	/// <summary>
	/// 奇遇刷新地格特效
	/// </summary>
	AdventureRefreshBlockEffect,
	/// <summary>
	/// 奇遇刷新全局特效
	/// </summary>
	AdventureRefreshGlobalEffect,
	/// <summary>
	/// 太吾显示气泡
	/// </summary>
	AdventureTaiwuShowDialog,
	/// <summary>
	/// 元素显示气泡
	/// </summary>
	AdventureElementShowDialog,
	/// <summary>
	/// 棋子倒地动画
	/// </summary>
	AdventureElementDeleteAnim,
	/// <summary>
	/// 镜头移动
	/// </summary>
	AdventureCameraMoveToBlock,
	/// <summary>
	/// 等待一定时间
	/// </summary>
	AdventureDelayAction,
	/// <summary>
	/// 奇遇事件处理完成
	/// </summary>
	AdventureEventHandled,
	/// <summary>
	/// 新功能解锁，参数 NewFunctionUnlock表的TemplateId
	/// </summary>
	NewFeatureUnlock,
	/// <summary>
	/// 地区剧情开启和PV查看弹窗
	/// </summary>
	SectStoryPopUpToggle,
	/// <summary>
	/// 音频播放命令带渐入渐出
	/// </summary>
	PlayAudioCommandWithFade,
	/// <summary>
	/// 打开交换面板，需传参一个int，用于指示与哪个Npc进行交换
	/// </summary>
	ShowExchangePanel,
	/// <summary>
	/// 打开璇女造花生人界面
	/// </summary>
	ShowCreateMirrorCharacter,
	/// <summary>
	/// 返回标题
	/// </summary>
	BackToMainMenu,
	/// <summary>
	/// 开始抓蛐蛐
	/// </summary>
	TriggerCricketCatch,
	/// <summary>
	/// 奇遇开始选择元素
	/// </summary>
	AdventureStartSelectElement,
	/// <summary>
	/// 进入奇遇
	/// </summary>
	EnterAdventureFromEvent,
	/// <summary>
	/// 从事件直接打开大事件
	/// </summary>
	EnterMajorEventFromEvent,
	/// <summary>
	/// 大事件跳过结束动画
	/// </summary>
	MajorEventSkipCompleteAnim,
	/// <summary>
	/// 打开经历界面
	/// 参数 int CharId
	/// </summary>
	ReadLifeRecord,
	/// <summary>
	/// 播放运功栏增加的全屏动画提示
	/// 参数1：功法装备类型 <see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" />
	/// 参数2：增加数量
	/// 参数3：最大内力增加数量
	/// </summary>
	ShowUnlockSkillSlotAnim,
	/// <summary>
	/// 切换日期/未知日期展示，参数 bool isUnknown
	/// </summary>
	SwitchDate,
	/// <summary>
	/// 促织化人表演
	/// 参数：cricketItemId(int), colorId(int), partId(int), charId(int)
	/// </summary>
	CricketPolymorphEffect,
	/// <summary>
	/// 月报窗口关闭时移动到太吾村所在地区.
	/// 参数: 无.
	/// </summary>
	MoveTaiwuVillageAreaOnMonthNotifyClosed,
	/// <summary>
	/// 播放指定音效
	/// 参数: 音效资源名称 (string).
	/// </summary>
	PlaySpecifiedSound
}
