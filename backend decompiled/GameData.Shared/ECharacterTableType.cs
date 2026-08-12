/// <summary>
/// CharacterTable -&gt; Type
/// </summary>
public enum ECharacterTableType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 状态
	/// </summary>
	GeneralProperty,
	/// <summary>
	/// 属性
	/// </summary>
	MainAndAttackProperty,
	/// <summary>
	/// 命中
	/// </summary>
	HitProperty,
	/// <summary>
	/// 技艺
	/// </summary>
	LifeSkill,
	/// <summary>
	/// 武学
	/// </summary>
	CombatSkill,
	/// <summary>
	/// 赋性
	/// </summary>
	Personality,
	/// <summary>
	/// 持有
	/// </summary>
	ItemAndResource,
	/// <summary>
	/// 指令
	/// </summary>
	Command,
	/// <summary>
	/// 奇书争夺者
	/// </summary>
	LegendBookCompetitors,
	/// <summary>
	/// 入魔堕魔者
	/// </summary>
	LegendBookFallen,
	/// <summary>
	/// 村民
	/// </summary>
	Villager,
	/// <summary>
	/// 拿取
	/// </summary>
	VillagerNeed,
	Count
}
