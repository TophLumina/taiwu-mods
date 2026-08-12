using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MonthlyActionsItem : ConfigItem<MonthlyActionsItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 月份要求
	/// - 每达到列表中的月份都尝试执行逻辑，如果逻辑行为处于进行中则不会尝试进行该行为
	/// </summary>
	public readonly List<sbyte> EnterMonthList;

	/// <summary>
	/// 地点省份要求
	/// - 填写-1表示不要求发生在什么省份，否则填写MapState表里的TemplateId
	/// </summary>
	public readonly sbyte MapState;

	/// <summary>
	/// 地点地区要求
	/// - 填写-1表示不限定在什么地区发生
	/// - 1 ： 在省份主要城市所在地区发生
	/// - 2： 在省份门派所属地区发生
	/// - 3： 在非主要城市和门派所在地区发生
	/// - 0 ： 在太吾村所在地区发生(填写0时，省份要求自动失效)
	/// </summary>
	public readonly sbyte MapArea;

	/// <summary>
	/// 地块地形细类要求
	/// - 填写MapBlock配置表里的t_SubType里对应的数字
	/// - 如果填写的是一个确定的城市、门派、太吾村，则地点和省份要求都失效
	/// </summary>
	public readonly List<short> MapBlockSubType;

	/// <summary>
	/// 人物搜索范围
	/// - 在当前区域 (0) 、州域 (1) 、还是全世界 (2) 搜索人物
	/// </summary>
	public readonly sbyte CharacterSearchRange;

	/// <summary>
	/// 关键人物移动是否可见
	/// - 如果关键人物的移动不可见，则参与人物会和关键人物同时开始往目标地移动；否则要等到关键人物移动到目标地，位置变为不知所踪后，参与人物才开始往目标地点移动
	/// </summary>
	public readonly bool MajorTargetMoveVisible;

	/// <summary>
	/// 关键人物筛选
	/// - {{{角色筛选表中的TemplateId},最小人数,最大人数(可选)}}
	/// </summary>
	public readonly CharacterFilterRequirement[] MajorTargetFilterList;

	/// <summary>
	/// 参与人物筛选
	/// - {{{角色筛选表中的TemplateId},最小人数,最大人数(可选)}}
	/// </summary>
	public readonly CharacterFilterRequirement[] ParticipateTargetFilterList;

	/// <summary>
	/// 奇遇名
	/// - 满足人数条件或达到准备时节数后，添加该奇遇到地图上
	/// </summary>
	public readonly short AdventureId;

	/// <summary>
	/// 过月通知
	/// - 奇遇变得可见后，添加该过月通知到过月通知列表
	/// </summary>
	public readonly short NotificationId;

	/// <summary>
	/// 是否为外道巢穴
	/// - 外道巢穴类奇遇为每个地区单独生成，且同一地区同时会生成多个，不同的外道巢穴按照等级统一管理生成
	/// </summary>
	public readonly bool IsEnemyNest;

	/// <summary>
	/// 允许临时关键角色
	/// - 不允许的情况如果无法拉取到足够的角色，奇遇将不会生成
	/// </summary>
	public readonly bool AllowTemporaryMajorCharacter;

	/// <summary>
	/// 允许临时参与角色
	/// - 不允许的情况如果无法拉取到足够的角色，奇遇将不会生成
	/// </summary>
	public readonly bool AllowTemporaryParticipateCharacter;

	/// <summary>
	/// 可能将临时关键角色转化为真实角色
	/// - 如果生成临时关键角色，是否可能将他们转化成真实角色；不包含玩家手动在事件中生成临时角色的情况（这种需要在奇遇编辑器中配置）
	/// </summary>
	public readonly bool WillConvertTemporaryMajorCharacters;

	/// <summary>
	/// 可能将临时参与角色转化为真实角色
	/// - 如果生成临时参与角色，是否可能将他们转化成真实角色；不包含玩家手动在事件中生成临时角色的情况（这种需要在奇遇编辑器中配置）
	/// </summary>
	public readonly bool WillConvertTemporaryParticipateCharacters;

	/// <summary>
	/// 允许提前开放
	/// - 如果允许提前开放，则人数满足条件后会立即开始添加奇遇
	/// </summary>
	public readonly bool CanActionBeforehand;

	/// <summary>
	/// 准备时长
	/// - 准备时节数到达后，智能补足缺少的人并开启
	/// </summary>
	public readonly sbyte PreparationDuration;

	/// <summary>
	/// 预告时间
	/// - 达到最低参与人数且允许提前开放OR达到准备时节数上限，奇遇将被添加到地图地块上。此时将出现预告：N时节后奇遇开始。如果填写的值是0，则奇遇立即开始
	/// </summary>
	public readonly sbyte PreannouncingTime;

	/// <summary>
	/// 触发间隔
	/// - 距离最近一次移除该奇遇的最短月份数，该时间段内奇遇无法再次触发。如果该间隔小于等于0表示该奇遇不会被托管自动定期触发，而是需要手动触发
	/// </summary>
	public readonly sbyte MinInterval;

	/// <summary>
	/// 超时失败间隔
	/// - 因为超时导致触发失败后，下一次触发的间隔。当该值为0时，超时与正常完成的触发间隔相同
	/// </summary>
	public readonly short MinFailureInterval;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="enterMonthList">月份要求 - 每达到列表中的月份都尝试执行逻辑，如果逻辑行为处于进行中则不会尝试进行该行为</param>
	/// <param name="mapState">地点省份要求 - 填写-1表示不要求发生在什么省份，否则填写MapState表里的TemplateId</param>
	/// <param name="mapArea">地点地区要求 - 填写-1表示不限定在什么地区发生 1 ： 在省份主要城市所在地区发生 2： 在省份门派所属地区发生 3： 在非主要城市和门派所在地区发生 0 ： 在太吾村所在地区发生(填写0时，省份要求自动失效)</param>
	/// <param name="mapBlockSubType">地块地形细类要求 - 填写MapBlock配置表里的t_SubType里对应的数字 如果填写的是一个确定的城市、门派、太吾村，则地点和省份要求都失效</param>
	/// <param name="characterSearchRange">人物搜索范围 - 在当前区域 (0) 、州域 (1) 、还是全世界 (2) 搜索人物</param>
	/// <param name="majorTargetMoveVisible">关键人物移动是否可见 - 如果关键人物的移动不可见，则参与人物会和关键人物同时开始往目标地移动；否则要等到关键人物移动到目标地，位置变为不知所踪后，参与人物才开始往目标地点移动</param>
	/// <param name="majorTargetFilterList">关键人物筛选 - {{{角色筛选表中的TemplateId},最小人数,最大人数(可选)}}</param>
	/// <param name="participateTargetFilterList">参与人物筛选 - {{{角色筛选表中的TemplateId},最小人数,最大人数(可选)}}</param>
	/// <param name="adventureId">奇遇名 - 满足人数条件或达到准备时节数后，添加该奇遇到地图上</param>
	/// <param name="notificationId">过月通知 - 奇遇变得可见后，添加该过月通知到过月通知列表</param>
	/// <param name="isEnemyNest">是否为外道巢穴 - 外道巢穴类奇遇为每个地区单独生成，且同一地区同时会生成多个，不同的外道巢穴按照等级统一管理生成</param>
	/// <param name="allowTemporaryMajorCharacter">允许临时关键角色 - 不允许的情况如果无法拉取到足够的角色，奇遇将不会生成</param>
	/// <param name="allowTemporaryParticipateCharacter">允许临时参与角色 - 不允许的情况如果无法拉取到足够的角色，奇遇将不会生成</param>
	/// <param name="willConvertTemporaryMajorCharacters">可能将临时关键角色转化为真实角色 - 如果生成临时关键角色，是否可能将他们转化成真实角色；不包含玩家手动在事件中生成临时角色的情况（这种需要在奇遇编辑器中配置）</param>
	/// <param name="willConvertTemporaryParticipateCharacters">可能将临时参与角色转化为真实角色 - 如果生成临时参与角色，是否可能将他们转化成真实角色；不包含玩家手动在事件中生成临时角色的情况（这种需要在奇遇编辑器中配置）</param>
	/// <param name="canActionBeforehand">允许提前开放 - 如果允许提前开放，则人数满足条件后会立即开始添加奇遇</param>
	/// <param name="preparationDuration">准备时长 - 准备时节数到达后，智能补足缺少的人并开启</param>
	/// <param name="preannouncingTime">预告时间 - 达到最低参与人数且允许提前开放OR达到准备时节数上限，奇遇将被添加到地图地块上。此时将出现预告：N时节后奇遇开始。如果填写的值是0，则奇遇立即开始</param>
	/// <param name="minInterval">触发间隔 - 距离最近一次移除该奇遇的最短月份数，该时间段内奇遇无法再次触发。如果该间隔小于等于0表示该奇遇不会被托管自动定期触发，而是需要手动触发</param>
	/// <param name="minFailureInterval">超时失败间隔 - 因为超时导致触发失败后，下一次触发的间隔。当该值为0时，超时与正常完成的触发间隔相同</param>
	public MonthlyActionsItem(short templateId, string name, List<sbyte> enterMonthList, sbyte mapState, sbyte mapArea, List<short> mapBlockSubType, sbyte characterSearchRange, bool majorTargetMoveVisible, CharacterFilterRequirement[] majorTargetFilterList, CharacterFilterRequirement[] participateTargetFilterList, short adventureId, short notificationId, bool isEnemyNest, bool allowTemporaryMajorCharacter, bool allowTemporaryParticipateCharacter, bool willConvertTemporaryMajorCharacters, bool willConvertTemporaryParticipateCharacters, bool canActionBeforehand, sbyte preparationDuration, sbyte preannouncingTime, sbyte minInterval, short minFailureInterval)
	{
		TemplateId = templateId;
		Name = name;
		EnterMonthList = enterMonthList;
		MapState = mapState;
		MapArea = mapArea;
		MapBlockSubType = mapBlockSubType;
		CharacterSearchRange = characterSearchRange;
		MajorTargetMoveVisible = majorTargetMoveVisible;
		MajorTargetFilterList = majorTargetFilterList;
		ParticipateTargetFilterList = participateTargetFilterList;
		AdventureId = adventureId;
		NotificationId = notificationId;
		IsEnemyNest = isEnemyNest;
		AllowTemporaryMajorCharacter = allowTemporaryMajorCharacter;
		AllowTemporaryParticipateCharacter = allowTemporaryParticipateCharacter;
		WillConvertTemporaryMajorCharacters = willConvertTemporaryMajorCharacters;
		WillConvertTemporaryParticipateCharacters = willConvertTemporaryParticipateCharacters;
		CanActionBeforehand = canActionBeforehand;
		PreparationDuration = preparationDuration;
		PreannouncingTime = preannouncingTime;
		MinInterval = minInterval;
		MinFailureInterval = minFailureInterval;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MonthlyActionsItem()
	{
		TemplateId = 0;
		Name = null;
		EnterMonthList = new List<sbyte>();
		MapState = 0;
		MapArea = 0;
		MapBlockSubType = new List<short>();
		CharacterSearchRange = 0;
		MajorTargetMoveVisible = false;
		MajorTargetFilterList = new CharacterFilterRequirement[0];
		ParticipateTargetFilterList = new CharacterFilterRequirement[0];
		AdventureId = 0;
		NotificationId = 0;
		IsEnemyNest = false;
		AllowTemporaryMajorCharacter = false;
		AllowTemporaryParticipateCharacter = false;
		WillConvertTemporaryMajorCharacters = false;
		WillConvertTemporaryParticipateCharacters = false;
		CanActionBeforehand = true;
		PreparationDuration = 0;
		PreannouncingTime = 0;
		MinInterval = 0;
		MinFailureInterval = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MonthlyActionsItem(short templateId, MonthlyActionsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EnterMonthList = other.EnterMonthList;
		MapState = other.MapState;
		MapArea = other.MapArea;
		MapBlockSubType = other.MapBlockSubType;
		CharacterSearchRange = other.CharacterSearchRange;
		MajorTargetMoveVisible = other.MajorTargetMoveVisible;
		MajorTargetFilterList = other.MajorTargetFilterList;
		ParticipateTargetFilterList = other.ParticipateTargetFilterList;
		AdventureId = other.AdventureId;
		NotificationId = other.NotificationId;
		IsEnemyNest = other.IsEnemyNest;
		AllowTemporaryMajorCharacter = other.AllowTemporaryMajorCharacter;
		AllowTemporaryParticipateCharacter = other.AllowTemporaryParticipateCharacter;
		WillConvertTemporaryMajorCharacters = other.WillConvertTemporaryMajorCharacters;
		WillConvertTemporaryParticipateCharacters = other.WillConvertTemporaryParticipateCharacters;
		CanActionBeforehand = other.CanActionBeforehand;
		PreparationDuration = other.PreparationDuration;
		PreannouncingTime = other.PreannouncingTime;
		MinInterval = other.MinInterval;
		MinFailureInterval = other.MinFailureInterval;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MonthlyActionsItem Duplicate(int templateId)
	{
		return new MonthlyActionsItem((short)templateId, this);
	}
}
