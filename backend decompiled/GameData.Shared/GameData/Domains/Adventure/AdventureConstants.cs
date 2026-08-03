namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇内事件键
/// </summary>
public static class AdventureConstants
{
	/// <summary>
	/// 奇遇 ID
	/// </summary>
	public const string AdventureId = "ConchShipPresetKey_AdventureId";

	/// <summary>
	/// 元素 ID
	/// </summary>
	public const string ElementId = "ConchShipPresetKey_ElementId";

	/// <summary>
	/// 临时道具键
	/// </summary>
	public const string TemporaryItemKey = "ConchShipPresetKey_TemporaryItemKey";

	/// <summary>
	/// 地格 ID
	/// </summary>
	public const string BlockIndex = "ConchShipPresetKey_BlockIndex";

	/// <summary>
	/// 已消耗的时间
	/// </summary>
	public const string TimeCosted = "ConchShipPresetKey_CostedTime";

	/// <summary>
	/// 已完成的行为
	/// </summary>
	public const string FinishedAction = "ConchShipPresetKey_FinishedAction";

	/// <summary>
	/// 大事件 - 主要角色前缀
	/// </summary>
	public const string MajorCharacter = "MajorCharacter_";

	/// <summary>
	/// 大事件 - 次要角色前缀
	/// </summary>
	public const string ParticipateCharacter = "ParticipateCharacter_";

	/// <summary>
	/// 进入时消耗的道具
	/// </summary>
	public const string EnterItems = "EnterItems_";

	/// <summary>
	/// 大事件实例
	/// </summary>
	public const string MajorEvent = "ConchShipPresetKey_MajorEvent";

	/// <summary>
	/// 大事件指令写入的气氛类型（值为 int，对应 EAdventureMajorEventAtmosphereType）
	/// </summary>
	public const string MajorEventAtmosphereType = "ConchShipPresetKey_MajorEventAtmosphereType";

	/// <summary>
	/// 是否因超时而删除
	/// </summary>
	public const string IsTimeout = "ConchShipPresetKey_IsTimeout";

	/// <summary>
	/// 删除时太吾在里面
	/// </summary>
	public const string IsRunning = "ConchShipPresetKey_IsRunning";

	/// <summary>
	/// 奇遇/大事件移除类型
	/// </summary>
	public const string RemoveType = "ConchShipPresetKey_RemoveType";

	/// <summary>
	/// 奇遇全局特效
	/// </summary>
	public const string AdventureGlobalParticle = "ConchShipPresetKey_Adventure_Global_Particle";

	/// <summary>
	/// 视野类型
	/// </summary>
	public const string ViewType = "view_range_";

	/// <summary>
	/// 近程视野
	/// </summary>
	public const string ViewTypeNear = "view_range_0";

	/// <summary>
	/// 远程视野
	/// </summary>
	public const string ViewTypeFar = "view_range_1";

	/// <summary>
	/// 自定义文本已触发
	/// </summary>
	public const string CustomTextInvoked = "ConchShipPresetKey_CustomTextInvoked_";

	/// <summary>
	/// 元素角色自定义等级，用于前端显示角色品级
	/// 没有设置元素角色信息但又需要前端显示角色品级的时候，需要设置此元素变量
	/// </summary>
	public const string CharacterDefineGrade = "ConchShipPresetKey_CharacterDefineGrade";

	/// <summary>
	/// 天下武林盟会主办方
	/// </summary>
	public const string MartialArtTournamentHost = "MainOrg";

	/// <summary>
	/// 近程视野默认值
	/// </summary>
	public const int ViewTypeDefaultValueNear = 1;

	/// <summary>
	/// 远程视野默认值
	/// </summary>
	public const int ViewTypeDefaultValueFar = 3;

	/// <summary>
	/// 变量风格 - 普通/状态 - 太吾
	/// </summary>
	public const int ParameterStyleTaiwu = 0;

	/// <summary>
	/// 变量风格 - 普通/状态 - 全局
	/// </summary>
	public const int ParameterStyleGlobal = 1;

	/// <summary>
	/// 变量风格 - 状态 - 全局反转
	/// </summary>
	public const int ParameterStyleGlobalReverse = 2;

	/// <summary>
	/// 变量风格 - 影响 - 曼哈顿
	/// </summary>
	public const int ParameterStyleInfluenceManhattan = 0;

	/// <summary>s
	/// 变量风格 - 影响 - 区域盒
	/// </summary>
	public const int ParameterStyleInfluenceRegionBox = 1;

	/// <summary>
	/// 每月召集角色数量上限
	/// 类型：int
	/// </summary>
	public const string CallCharacterCountLimit = "ConchShipPresetKey_CallCharacterCountLimit";

	/// <summary>
	/// 隐藏时不召集角色
	/// 类型：bool
	/// </summary>
	public const string CallCharactersExceptHide = "ConchShipPresetKey_CallCharactersExceptHide";

	/// <summary>
	/// 自动结束隐藏的日期
	/// 类型：int，对应 <see cref="P:GameData.IGameContext.CurrDate" />
	/// </summary>
	public const string AutoStopHideDate = "ConchShipPresetKey_AutoStopHideDate";

	/// <summary>
	/// 自动检查是否拉齐人的日期
	/// 类型：int，对应 <see cref="P:GameData.IGameContext.CurrDate" />
	/// </summary>
	public const string AutoCheckSatisfiedDate = "ConchShipPresetKey_AutoCheckSatisfiedDate";

	/// <summary>
	/// 召集角色阶段后自动移除
	/// 类型：bool
	/// </summary>
	public const string RemoveAfterCallCharacters = "ConchShipPresetKey_RemoveAfterCallCharacters";

	/// <summary>
	/// 隐藏前的状态
	/// 类型：int，对应 <see cref="T:GameData.Domains.Adventure.EAdventureStatusType" />
	/// </summary>
	public const string HidePrevStatus = "ConchShipPresetKey_HidePrevStatus";

	/// <summary>
	/// 奇遇元素跟随地格索引
	/// 类型：<see cref="T:GameData.Adventure.AdventureBlockIndex" />
	/// </summary>
	public const string FollowTargetBlockIndex = "ConchShipPresetKey_FollowTargetBlockIndex";

	/// <summary>
	/// 奇遇元素跟随元素 ID
	/// 类型：int
	/// </summary>
	public const string FollowTargetElementId = "ConchShipPresetKey_FollowTargetElementId";

	/// <summary>
	/// 奇遇任务总数
	/// 类型：int
	/// </summary>
	public const string TaskCount = "ConchShipPresetKey_Task_Count";

	/// <summary>
	/// 绑架元素的标识 <see cref="P:GameData.Adventure.AdventureElementData.Tags" />
	/// </summary>
	public const string KidnappingElement = "CSPreset_Kidnapping";

	/// <summary>
	/// 避免死亡
	/// </summary>
	public const string AvoidDeathElement = "AvoidDeathInAdvanceMonth";

	/// <summary>
	/// 默认地格图标
	/// </summary>
	public const string BlockIconDefault = "adventure_block_default";

	/// <summary>
	/// 本地化文本包名称
	/// </summary>
	public const string LocalStringPackName = "AdventureCore_language";

	/// <summary>
	/// 奇遇任务键
	/// 类型：<see cref="T:GameData.Domains.World.Task.TaskData" />
	/// </summary>
	public static string TaskKey(int index)
	{
		return "ConchShipPresetKey_Task_" + index;
	}
}
