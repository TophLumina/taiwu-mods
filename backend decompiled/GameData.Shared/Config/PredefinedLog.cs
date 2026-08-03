using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

/// <inheritdoc cref="T:Config.PredefinedLog" />
[Serializable]
public class PredefinedLog : ConfigData<PredefinedLogItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 秘闻被迫抹除
		/// </summary>
		public const short SecretInformationForcedToBeErased = 0;

		/// <summary>
		/// 加载Mod配置失败
		/// </summary>
		public const short LoadModConfigFail = 1;

		/// <summary>
		/// 加载Mod配置无Mod名
		/// </summary>
		public const short LoadModConfigFailWithoutName = 2;

		/// <summary>
		/// 加载Mod设置失败
		/// </summary>
		public const short LoadModSettingsFail = 3;

		/// <summary>
		/// 加载Mod全局设置失败
		/// </summary>
		public const short LoadModSystemSettingsFail = 4;

		/// <summary>
		/// 战斗行为剩余帧为负
		/// </summary>
		public const short CombatFrameConfigNegative = 5;

		/// <summary>
		/// 志向动画运行时异常
		/// </summary>
		public const short ProfessionSkillAnimationRuntimeException = 6;

		/// <summary>
		/// 功法特效运行时异常
		/// </summary>
		public const short CombatSpecialEffectRuntimeException = 7;

		/// <summary>
		/// 战斗运行时异常
		/// </summary>
		public const short CombatRuntimeException = 8;

		/// <summary>
		/// 视频格式不支持异常
		/// </summary>
		public const short VideoFormatUnSupportedException = 9;

		/// <summary>
		/// 读取到不存在的任务Id
		/// </summary>
		public const short TaskTemplateIdNotExist = 10;

		/// <summary>
		/// 地图运行时异常
		/// </summary>
		public const short MapRuntimeException = 11;

		/// <summary>
		/// 角色运行时异常
		/// </summary>
		public const short CharacterRuntimeException = 12;

		/// <summary>
		/// 功法运行时异常
		/// </summary>
		public const short CombatSkillRuntimeException = 13;

		/// <summary>
		/// 通信运行时异常
		/// </summary>
		public const short NetRuntimeException = 14;

		/// <summary>
		/// 较艺操作过期
		/// </summary>
		public const short LifeSkillCombatOperationExpired = 15;

		/// <summary>
		/// 梦回存档世界不匹配
		/// </summary>
		public const short DreamBackWorldNotMatch = 16;

		/// <summary>
		/// 化龙界面元素刷新异常
		/// </summary>
		public const short JiaoChangeloongRefreshIndexException = 17;

		/// <summary>
		/// 通用界面元素刷新异常
		/// </summary>
		public const short GeneralRefreshIndexException = 18;

		/// <summary>
		/// 世界运行时异常
		/// </summary>
		public const short WorldRuntimeException = 19;

		/// <summary>
		/// 道具重复
		/// </summary>
		public const short DuplicatedItemDetected = 20;

		/// <summary>
		/// 道具未被持有
		/// </summary>
		public const short UnownedItemDetected = 21;

		/// <summary>
		/// 事件切换未进入
		/// </summary>
		public const short EventChangedWithNotEntering = 22;

		/// <summary>
		/// 战斗 Ai 加载异常
		/// </summary>
		public const short CombatAiLoadException = 23;

		/// <summary>
		/// Mod 配置丢失异常
		/// </summary>
		public const short ModConfigNotFoundException = 24;

		/// <summary>
		/// 参数值不能为空
		/// </summary>
		public const short ValueCanNotBeEmpty = 25;

		/// <summary>
		/// 配置表找不到此参数
		/// </summary>
		public const short ValueNotFoundInConfigTable = 26;

		/// <summary>
		/// 找不到事件
		/// </summary>
		public const short EventNotFoundInAnyEventGroup = 27;

		/// <summary>
		/// 无效的枚举
		/// </summary>
		public const short InvalidEnumIndex = 28;

		/// <summary>
		/// Lua脚本执行异常
		/// </summary>
		public const short LuaScriptingException = 29;

		/// <summary>
		/// 元鸡缓存异常1
		/// </summary>
		public const short CacheCorruptedNoChickenInSettlement = 30;

		/// <summary>
		/// 元鸡缓存异常2
		/// </summary>
		public const short CacheCorruptedSetSettlementHasNoChicken = 31;

		/// <summary>
		/// 元鸡缓存异常3
		/// </summary>
		public const short CacheCorruptedRemoveNonExistsChicken = 32;

		/// <summary>
		/// 未知的通缉惩罚
		/// </summary>
		public const short UnknownPunishmentType = 33;

		/// <summary>
		/// 获取非存活角色的显示年龄
		/// </summary>
		public const short GetNotAliveDisplayingAge = 34;

		/// <summary>
		/// 配置设置解析失败
		/// </summary>
		public const short ConfigurationParseFailed = 35;

		/// <summary>
		/// 奇遇元素解析失败
		/// </summary>
		public const short AdventureElementNotFind = 36;

		/// <summary>
		/// 大事件模板解析失败
		/// </summary>
		public const short AdventureMajorEventNotFind = 37;

		/// <summary>
		/// 奇遇模板解析失败
		/// </summary>
		public const short AdventureNotFind = 38;

		/// <summary>
		/// 奇遇事件队列溢出
		/// </summary>
		public const short AdventureEventOverflow = 39;

		/// <summary>
		/// 奇遇生成失败
		/// </summary>
		public const short AdventureGenerateFailed = 40;

		/// <summary>
		/// 额外赌注生成失败
		/// </summary>
		public const short CricketExtraWagerGenerateFailed = 41;

		/// <summary>
		/// 升灵状态转变失败
		/// </summary>
		public const short PolymorphStateChangeFailed = 42;

		/// <summary>
		/// 加载存档异常
		/// </summary>
		public const short LoadArchiveDataFailed = 43;

		/// <summary>
		/// 保存备份存档失败
		/// </summary>
		public const short TransferToOldFailed = 44;

		/// <summary>
		/// NPC目标创建失败
		/// </summary>
		public const short CharacterGoalCreationFailed = 45;

		/// <summary>
		/// NPC行为规划失败
		/// </summary>
		public const short CharacterActionPlanningFailed = 46;

		/// <summary>
		/// NPC行为执行失败
		/// </summary>
		public const short CharacterActionExecutionFailed = 47;

		/// <summary>
		/// 通知类文本参数异常
		/// </summary>
		public const short GameMessageRenderError = 48;

		/// <summary>
		/// 通信数据序列化数据过长
		/// </summary>
		public const short SerializedSizeExceedLimit = 49;

		/// <summary>
		/// 道具堆叠异常1
		/// </summary>
		public const short InvalidItemStacking1 = 50;

		/// <summary>
		/// 道具堆叠异常2
		/// </summary>
		public const short InvalidItemStacking2 = 51;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 秘闻被迫抹除
		/// </summary>
		public static PredefinedLogItem SecretInformationForcedToBeErased => Instance[(short)0];

		/// <summary>
		/// 加载Mod配置失败
		/// </summary>
		public static PredefinedLogItem LoadModConfigFail => Instance[(short)1];

		/// <summary>
		/// 加载Mod配置无Mod名
		/// </summary>
		public static PredefinedLogItem LoadModConfigFailWithoutName => Instance[(short)2];

		/// <summary>
		/// 加载Mod设置失败
		/// </summary>
		public static PredefinedLogItem LoadModSettingsFail => Instance[(short)3];

		/// <summary>
		/// 加载Mod全局设置失败
		/// </summary>
		public static PredefinedLogItem LoadModSystemSettingsFail => Instance[(short)4];

		/// <summary>
		/// 战斗行为剩余帧为负
		/// </summary>
		public static PredefinedLogItem CombatFrameConfigNegative => Instance[(short)5];

		/// <summary>
		/// 志向动画运行时异常
		/// </summary>
		public static PredefinedLogItem ProfessionSkillAnimationRuntimeException => Instance[(short)6];

		/// <summary>
		/// 功法特效运行时异常
		/// </summary>
		public static PredefinedLogItem CombatSpecialEffectRuntimeException => Instance[(short)7];

		/// <summary>
		/// 战斗运行时异常
		/// </summary>
		public static PredefinedLogItem CombatRuntimeException => Instance[(short)8];

		/// <summary>
		/// 视频格式不支持异常
		/// </summary>
		public static PredefinedLogItem VideoFormatUnSupportedException => Instance[(short)9];

		/// <summary>
		/// 读取到不存在的任务Id
		/// </summary>
		public static PredefinedLogItem TaskTemplateIdNotExist => Instance[(short)10];

		/// <summary>
		/// 地图运行时异常
		/// </summary>
		public static PredefinedLogItem MapRuntimeException => Instance[(short)11];

		/// <summary>
		/// 角色运行时异常
		/// </summary>
		public static PredefinedLogItem CharacterRuntimeException => Instance[(short)12];

		/// <summary>
		/// 功法运行时异常
		/// </summary>
		public static PredefinedLogItem CombatSkillRuntimeException => Instance[(short)13];

		/// <summary>
		/// 通信运行时异常
		/// </summary>
		public static PredefinedLogItem NetRuntimeException => Instance[(short)14];

		/// <summary>
		/// 较艺操作过期
		/// </summary>
		public static PredefinedLogItem LifeSkillCombatOperationExpired => Instance[(short)15];

		/// <summary>
		/// 梦回存档世界不匹配
		/// </summary>
		public static PredefinedLogItem DreamBackWorldNotMatch => Instance[(short)16];

		/// <summary>
		/// 化龙界面元素刷新异常
		/// </summary>
		public static PredefinedLogItem JiaoChangeloongRefreshIndexException => Instance[(short)17];

		/// <summary>
		/// 通用界面元素刷新异常
		/// </summary>
		public static PredefinedLogItem GeneralRefreshIndexException => Instance[(short)18];

		/// <summary>
		/// 世界运行时异常
		/// </summary>
		public static PredefinedLogItem WorldRuntimeException => Instance[(short)19];

		/// <summary>
		/// 道具重复
		/// </summary>
		public static PredefinedLogItem DuplicatedItemDetected => Instance[(short)20];

		/// <summary>
		/// 道具未被持有
		/// </summary>
		public static PredefinedLogItem UnownedItemDetected => Instance[(short)21];

		/// <summary>
		/// 事件切换未进入
		/// </summary>
		public static PredefinedLogItem EventChangedWithNotEntering => Instance[(short)22];

		/// <summary>
		/// 战斗 Ai 加载异常
		/// </summary>
		public static PredefinedLogItem CombatAiLoadException => Instance[(short)23];

		/// <summary>
		/// Mod 配置丢失异常
		/// </summary>
		public static PredefinedLogItem ModConfigNotFoundException => Instance[(short)24];

		/// <summary>
		/// 参数值不能为空
		/// </summary>
		public static PredefinedLogItem ValueCanNotBeEmpty => Instance[(short)25];

		/// <summary>
		/// 配置表找不到此参数
		/// </summary>
		public static PredefinedLogItem ValueNotFoundInConfigTable => Instance[(short)26];

		/// <summary>
		/// 找不到事件
		/// </summary>
		public static PredefinedLogItem EventNotFoundInAnyEventGroup => Instance[(short)27];

		/// <summary>
		/// 无效的枚举
		/// </summary>
		public static PredefinedLogItem InvalidEnumIndex => Instance[(short)28];

		/// <summary>
		/// Lua脚本执行异常
		/// </summary>
		public static PredefinedLogItem LuaScriptingException => Instance[(short)29];

		/// <summary>
		/// 元鸡缓存异常1
		/// </summary>
		public static PredefinedLogItem CacheCorruptedNoChickenInSettlement => Instance[(short)30];

		/// <summary>
		/// 元鸡缓存异常2
		/// </summary>
		public static PredefinedLogItem CacheCorruptedSetSettlementHasNoChicken => Instance[(short)31];

		/// <summary>
		/// 元鸡缓存异常3
		/// </summary>
		public static PredefinedLogItem CacheCorruptedRemoveNonExistsChicken => Instance[(short)32];

		/// <summary>
		/// 未知的通缉惩罚
		/// </summary>
		public static PredefinedLogItem UnknownPunishmentType => Instance[(short)33];

		/// <summary>
		/// 获取非存活角色的显示年龄
		/// </summary>
		public static PredefinedLogItem GetNotAliveDisplayingAge => Instance[(short)34];

		/// <summary>
		/// 配置设置解析失败
		/// </summary>
		public static PredefinedLogItem ConfigurationParseFailed => Instance[(short)35];

		/// <summary>
		/// 奇遇元素解析失败
		/// </summary>
		public static PredefinedLogItem AdventureElementNotFind => Instance[(short)36];

		/// <summary>
		/// 大事件模板解析失败
		/// </summary>
		public static PredefinedLogItem AdventureMajorEventNotFind => Instance[(short)37];

		/// <summary>
		/// 奇遇模板解析失败
		/// </summary>
		public static PredefinedLogItem AdventureNotFind => Instance[(short)38];

		/// <summary>
		/// 奇遇事件队列溢出
		/// </summary>
		public static PredefinedLogItem AdventureEventOverflow => Instance[(short)39];

		/// <summary>
		/// 奇遇生成失败
		/// </summary>
		public static PredefinedLogItem AdventureGenerateFailed => Instance[(short)40];

		/// <summary>
		/// 额外赌注生成失败
		/// </summary>
		public static PredefinedLogItem CricketExtraWagerGenerateFailed => Instance[(short)41];

		/// <summary>
		/// 升灵状态转变失败
		/// </summary>
		public static PredefinedLogItem PolymorphStateChangeFailed => Instance[(short)42];

		/// <summary>
		/// 加载存档异常
		/// </summary>
		public static PredefinedLogItem LoadArchiveDataFailed => Instance[(short)43];

		/// <summary>
		/// 保存备份存档失败
		/// </summary>
		public static PredefinedLogItem TransferToOldFailed => Instance[(short)44];

		/// <summary>
		/// NPC目标创建失败
		/// </summary>
		public static PredefinedLogItem CharacterGoalCreationFailed => Instance[(short)45];

		/// <summary>
		/// NPC行为规划失败
		/// </summary>
		public static PredefinedLogItem CharacterActionPlanningFailed => Instance[(short)46];

		/// <summary>
		/// NPC行为执行失败
		/// </summary>
		public static PredefinedLogItem CharacterActionExecutionFailed => Instance[(short)47];

		/// <summary>
		/// 通知类文本参数异常
		/// </summary>
		public static PredefinedLogItem GameMessageRenderError => Instance[(short)48];

		/// <summary>
		/// 通信数据序列化数据过长
		/// </summary>
		public static PredefinedLogItem SerializedSizeExceedLimit => Instance[(short)49];

		/// <summary>
		/// 道具堆叠异常1
		/// </summary>
		public static PredefinedLogItem InvalidItemStacking1 => Instance[(short)50];

		/// <summary>
		/// 道具堆叠异常2
		/// </summary>
		public static PredefinedLogItem InvalidItemStacking2 => Instance[(short)51];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static PredefinedLog Instance = new PredefinedLog();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Info", "TemplateId" };

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
		_dataArray.Add(new PredefinedLogItem(0, LocalStringManager.GetConfig("PredefinedLog_language", "Name_0"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_0"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(1, LocalStringManager.GetConfig("PredefinedLog_language", "Name_1"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_1"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(2, LocalStringManager.GetConfig("PredefinedLog_language", "Name_2"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_2"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(3, LocalStringManager.GetConfig("PredefinedLog_language", "Name_3"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_3"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(4, LocalStringManager.GetConfig("PredefinedLog_language", "Name_4"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_4"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(5, LocalStringManager.GetConfig("PredefinedLog_language", "Name_5"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_5"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(6, LocalStringManager.GetConfig("PredefinedLog_language", "Name_6"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_6"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(7, LocalStringManager.GetConfig("PredefinedLog_language", "Name_7"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_7"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(8, LocalStringManager.GetConfig("PredefinedLog_language", "Name_8"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_8"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(9, LocalStringManager.GetConfig("PredefinedLog_language", "Name_9"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_9"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(10, LocalStringManager.GetConfig("PredefinedLog_language", "Name_10"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_10"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(11, LocalStringManager.GetConfig("PredefinedLog_language", "Name_11"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_11"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(12, LocalStringManager.GetConfig("PredefinedLog_language", "Name_12"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_12"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(13, LocalStringManager.GetConfig("PredefinedLog_language", "Name_13"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_13"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(14, LocalStringManager.GetConfig("PredefinedLog_language", "Name_14"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_14"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(15, LocalStringManager.GetConfig("PredefinedLog_language", "Name_15"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_15"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(16, LocalStringManager.GetConfig("PredefinedLog_language", "Name_16"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_16"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(17, LocalStringManager.GetConfig("PredefinedLog_language", "Name_17"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_17"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(18, LocalStringManager.GetConfig("PredefinedLog_language", "Name_18"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_18"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(19, LocalStringManager.GetConfig("PredefinedLog_language", "Name_19"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_19"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(20, LocalStringManager.GetConfig("PredefinedLog_language", "Name_20"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_20"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(21, LocalStringManager.GetConfig("PredefinedLog_language", "Name_21"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_21"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(22, LocalStringManager.GetConfig("PredefinedLog_language", "Name_22"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_22"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(23, LocalStringManager.GetConfig("PredefinedLog_language", "Name_23"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_23"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(24, LocalStringManager.GetConfig("PredefinedLog_language", "Name_24"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_24"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(25, LocalStringManager.GetConfig("PredefinedLog_language", "Name_25"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_25"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(26, LocalStringManager.GetConfig("PredefinedLog_language", "Name_26"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_26"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(27, LocalStringManager.GetConfig("PredefinedLog_language", "Name_27"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_27"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(28, LocalStringManager.GetConfig("PredefinedLog_language", "Name_28"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_28"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(29, LocalStringManager.GetConfig("PredefinedLog_language", "Name_29"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_29"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(30, LocalStringManager.GetConfig("PredefinedLog_language", "Name_30"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_30"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(31, LocalStringManager.GetConfig("PredefinedLog_language", "Name_31"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_31"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(32, LocalStringManager.GetConfig("PredefinedLog_language", "Name_32"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_32"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(33, LocalStringManager.GetConfig("PredefinedLog_language", "Name_33"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_33"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(34, LocalStringManager.GetConfig("PredefinedLog_language", "Name_34"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_34"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(35, LocalStringManager.GetConfig("PredefinedLog_language", "Name_35"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_35"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(36, LocalStringManager.GetConfig("PredefinedLog_language", "Name_36"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_36"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(37, LocalStringManager.GetConfig("PredefinedLog_language", "Name_37"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_37"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(38, LocalStringManager.GetConfig("PredefinedLog_language", "Name_38"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_38"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(39, LocalStringManager.GetConfig("PredefinedLog_language", "Name_39"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_39"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(40, LocalStringManager.GetConfig("PredefinedLog_language", "Name_40"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_40"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(41, LocalStringManager.GetConfig("PredefinedLog_language", "Name_41"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_41"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(42, LocalStringManager.GetConfig("PredefinedLog_language", "Name_42"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_42"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(43, LocalStringManager.GetConfig("PredefinedLog_language", "Name_43"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_43"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(44, LocalStringManager.GetConfig("PredefinedLog_language", "Name_44"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_44"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(45, LocalStringManager.GetConfig("PredefinedLog_language", "Name_45"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_45"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(46, LocalStringManager.GetConfig("PredefinedLog_language", "Name_46"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_46"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(47, LocalStringManager.GetConfig("PredefinedLog_language", "Name_47"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_47"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(48, LocalStringManager.GetConfig("PredefinedLog_language", "Name_48"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_48"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(49, LocalStringManager.GetConfig("PredefinedLog_language", "Name_49"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_49"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(50, LocalStringManager.GetConfig("PredefinedLog_language", "Name_50"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_50"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(51, LocalStringManager.GetConfig("PredefinedLog_language", "Name_51"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_51"), debugOnly: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PredefinedLogItem>(52);
		CreateItems0();
	}

	/// <summary>
	/// 打印预设黄字警告
	/// </summary>
	public static void Show(short predefinedLogId)
	{
		Instance[predefinedLogId].Log();
	}

	/// <summary>
	/// 打印预设黄字警告
	/// </summary>
	public static void Show(short predefinedLogId, object arg0)
	{
		Instance[predefinedLogId].Log(arg0);
	}

	/// <summary>
	/// 打印预设黄字警告
	/// </summary>
	public static void Show(short predefinedLogId, object arg0, object arg1)
	{
		Instance[predefinedLogId].Log(arg0, arg1);
	}

	/// <summary>
	/// 打印预设黄字警告
	/// </summary>
	public static void Show(short predefinedLogId, object arg0, object arg1, object arg2)
	{
		Instance[predefinedLogId].Log(arg0, arg1, arg2);
	}

	/// <summary>
	/// 打印预设黄字警告
	/// </summary>
	public static void Show(short predefinedLogId, params object[] parameters)
	{
		Instance[predefinedLogId].Log(parameters);
	}
}
