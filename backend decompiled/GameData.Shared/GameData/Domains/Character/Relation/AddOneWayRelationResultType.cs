namespace GameData.Domains.Character.Relation;

/// <summary>
/// 人物界面添加单向关系结果类型，需要按位操作以达到所有原因都通知到前端的目的
/// </summary>
public static class AddOneWayRelationResultType
{
	/// <summary>
	/// 可以添加单向关系
	/// </summary>
	public const sbyte AbleToAdd = 0;

	/// <summary>
	/// 冷却时间未到，无法爱慕
	/// </summary>
	public const sbyte CooldownBlockToAddAdoreRelation = 1;

	/// <summary>
	/// 冷却时间未到，无法仇视
	/// </summary>
	public const sbyte CooldownBlockToAddEnemyRelation = 2;

	/// <summary>
	/// 已经存在爱慕关系，无法再次添加
	/// </summary>
	public const sbyte AlreadyAdore = 3;

	/// <summary>
	/// 已经存在仇视关系，无法再次添加
	/// </summary>
	public const sbyte AlreadyEnemy = 4;

	/// <summary>
	/// 主线进度未达到，无法添加爱慕关系
	/// </summary>
	public const sbyte MainStoryLineProgressNotReach = 5;

	/// <summary>
	/// npc爱慕太吾，因此太吾不能再点击添加爱慕关系（需要去事件互动进行表白）
	/// </summary>
	public const sbyte NpcAdoreTaiwu = 6;

	/// <summary>
	/// 太吾本身未成年，无法添加爱慕关系
	/// </summary>
	public const sbyte TaiwuNotAdultForAdore = 7;

	/// <summary>
	/// 未成年npc无法添加爱慕关系
	/// </summary>
	public const sbyte NotAdultForAdore = 8;

	/// <summary>
	/// 近亲关系不能添加爱慕关系
	/// </summary>
	public const sbyte CloseRelativeCanNotAdore = 9;

	/// <summary>
	/// 还不是朋友关系不能点击添加爱慕关系
	/// </summary>
	public const sbyte NotFriend = 10;

	/// <summary>
	/// 太吾是净体转世，永远不会被他人视为仇敌，也不会视他人为仇敌；但可以仇视恶体，被恶体仇视
	/// </summary>
	public const sbyte TaiwuIsPureReincarnation = 11;

	/// <summary>
	/// 太吾是恶体转世，永远不会被他人爱慕，也不会主动爱慕他人；但可以爱慕净体，被净体爱慕
	/// </summary>
	public const sbyte TaiwuIsContaminatedReincarnation = 12;

	/// <summary>
	/// 目标人物是净体转世，永远不会被他人视为仇敌，也不会视他人为仇敌；但可以仇视恶体，被恶体仇视
	/// </summary>
	public const sbyte NpcIsPureReincarnation = 13;

	/// <summary>
	/// Npc是恶体转世，永远不会被他人爱慕，也不会主动爱慕他人；但可以爱慕净体，被净体爱慕
	/// </summary>
	public const sbyte NpcIsContaminatedReincarnation = 14;

	/// <summary>
	/// 尚未认识
	/// </summary>
	public const sbyte Unknown = 15;
}
