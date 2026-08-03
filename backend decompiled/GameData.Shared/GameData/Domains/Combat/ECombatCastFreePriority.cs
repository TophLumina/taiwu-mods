namespace GameData.Domains.Combat;

/// <summary>
/// 战斗中无消耗施展功法优先级
/// </summary>
public enum ECombatCastFreePriority
{
	/// <summary>
	/// 无极刀法、韦驮伏魔剑，施展结束后如满足条件则复读或触发其它功法
	/// </summary>
	AutoMoveAndCast,
	/// <summary>
	/// 玉女神剑，在其他功法及引发的功法施展结束后转回自身
	/// </summary>
	YuNvShenJian,
	/// <summary>
	/// 青女履冰，在功法施展结束后再次触发
	/// </summary>
	QingNvLvBing,
	/// <summary>
	/// 无瑕七绝剑，在界青快剑与界青暗手快剑及引发的功法施展结束后触发新的界青暗手快剑或其它功法
	/// </summary>
	WuXiaQiJueJian,
	/// <summary>
	/// 一般优先级
	/// </summary>
	Normal,
	/// <summary>
	/// 剑柄功法
	/// </summary>
	SwordFragment,
	/// <summary>
	/// 使用管理员接口触发的无消耗施展
	/// </summary>
	Gm
}
