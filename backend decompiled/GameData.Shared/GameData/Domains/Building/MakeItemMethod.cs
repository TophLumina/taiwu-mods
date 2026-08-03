namespace GameData.Domains.Building;

/// <summary>
/// 建筑操作类型
/// -1: 上次选择的缓存值，用于获取太吾亲自制造物品的存放位置。目前这个缓存数值与【太吾亲自制造】区间重合，这是有意设计的
/// &gt;=0: 建筑默认值
/// [-16, 0): 太吾亲自制造 -- 需注意-1对应杂学，而杂学并不能用于制造物品，因此-1可用于缓存
/// [-32, -16): Npc代制
///
/// 需注意：修改此处定义时应当做存档修复
/// 为保证程序能意识到修改的发生，这里填入两个魔数（<see cref="F:GameData.Domains.Character.LifeSkillType.Eclectic" />=15与<see cref="F:GameData.Domains.Character.LifeSkillType.Count" />=16）
/// 以防止这两个数修改之后无人做存档修复
/// </summary>
public static class MakeItemMethod
{
	/// <summary>
	/// 上次制造的缓存，由于太吾永远不会使用杂学（<see cref="F:GameData.Domains.Character.LifeSkillType.Eclectic" />）制造物品，这里可以使用杂学做缓存
	/// </summary>
	public const int Cache = -1;

	/// <summary>
	/// 代制资源长度，应保证这个数值与<see cref="F:GameData.Domains.Character.LifeSkillType.Count" />一致
	/// 此处使用
	/// </summary>
	public const int ResourceLength = 16;

	/// <summary>
	/// NPC代制（起点），需保证下面的三个区间不重叠
	/// </summary>
	public const int Npc = -32;

	/// <summary>
	/// 太吾亲手制造（起点）
	/// </summary>
	public const int Taiwu = -16;

	/// <summary>
	/// 村民代制（起点）
	/// </summary>
	public const int Villager = 0;
}
