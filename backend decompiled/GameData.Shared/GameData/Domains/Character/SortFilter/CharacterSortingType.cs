namespace GameData.Domains.Character.SortFilter;

/// <summary>
/// 排序规则
/// </summary>
public static class CharacterSortingType
{
	/// <summary>
	/// 显示名
	/// </summary>
	public const int Name = 0;

	/// <summary>
	/// 身份
	/// </summary>
	public const int Grade = 1;

	/// <summary>
	/// 年龄
	/// </summary>
	public const int Age = 2;

	/// <summary>
	/// 健康
	/// </summary>
	public const int Health = 3;

	/// <summary>
	/// 性别
	/// </summary>
	public const int Gender = 4;

	/// <summary>
	/// 立场
	/// </summary>
	public const int BehaviorType = 5;

	/// <summary>
	/// 心情
	/// </summary>
	public const int Happiness = 6;

	/// <summary>
	/// 好感
	/// </summary>
	public const int Favorability = 7;

	/// <summary>
	/// 名誉
	/// </summary>
	public const int Fame = 8;

	/// <summary>
	/// 居住 - 只用于村民
	/// </summary>
	public const int Reside = 9;

	/// <summary>
	/// 工作 - 只用于村民
	/// </summary>
	public const int Work = 10;

	/// <summary>
	/// 进攻机略
	/// </summary>
	public const int AttackMedal = 11;

	/// <summary>
	/// 守御机略
	/// </summary>
	public const int DefenseMedal = 12;

	/// <summary>
	/// 机略
	/// </summary>
	public const int WisdomMedal = 13;

	/// <summary>
	/// 武学成长修正
	/// </summary>
	public const int CombatSkillAgeAdjust = 17;

	/// <summary>
	/// 技艺成长修正
	/// </summary>
	public const int LifeSkillAgeAdjust = 18;

	/// <summary>
	/// 伤势标记数量
	/// </summary>
	public const int DefeatMarkCount = 19;

	/// <summary>
	/// 内息紊乱
	/// </summary>
	public const int DisorderOfQi = 20;

	/// <summary>
	/// 轮回数
	/// </summary>
	public const int PreexistenceCharCount = 21;

	/// <summary>
	/// 当前行囊负重
	/// </summary>
	public const int CurrInventoryLoad = 22;

	/// <summary>
	/// 关押的人数
	/// </summary>
	public const int KidnappedCharCount = 23;

	/// <summary>
	/// 从属
	/// 未实现排序
	/// </summary>
	public const int Organization = 24;

	/// <summary>
	/// 所在位置
	/// 未实现排序
	/// </summary>
	public const int Location = 25;

	/// <summary>
	/// 第一个资源类型
	/// </summary>
	public const int ResourceTypeBegin = 26;

	/// <summary>
	/// 最后一个资源类型
	/// </summary>
	public const int ResourceTypeEnd = 33;

	/// <summary>
	/// 精纯
	/// </summary>
	public const int ConsummateLevel = 34;

	/// <summary>
	/// 剩余关押时长
	/// </summary>
	public const int PrisonTime = 35;

	/// <summary>
	/// 惩罚力度
	/// </summary>
	public const int PunishmentSeverity = 36;

	/// <summary>
	/// 悬赏金额
	/// </summary>
	public const int BountyAmount = 37;

	/// <summary>
	/// 村民需求物品的等待时间
	/// </summary>
	public const int VillagerNeedWaitTime = 38;

	/// <summary>
	/// 技艺造诣
	/// </summary>
	public const int LifeSkillAttainment = 39;

	/// <summary>
	/// 魅力
	/// </summary>
	public const int Attraction = 201;

	/// <summary>
	/// 后续类型减去 <see cref="F:GameData.Domains.Character.SortFilter.CharacterSortingType.CharacterPropertyReferencedTypeBegin" /> 则为 <see cref="T:ECharacterPropertyReferencedType" />
	/// </summary>
	public const int CharacterPropertyReferencedTypeBegin = 100;

	/// <summary>
	/// 将排序类型 <see cref="T:GameData.Domains.Character.SortFilter.CharacterSortingType" /> 转换成角色属性引用类型 <see cref="T:ECharacterPropertyReferencedType" />
	/// </summary>
	public static ECharacterPropertyReferencedType GetReferencedType(int sortingType)
	{
		return (ECharacterPropertyReferencedType)(sortingType - 100);
	}

	/// <summary>
	/// 将角色属性引用类型 <see cref="T:ECharacterPropertyReferencedType" /> 转换成排序类型 <see cref="T:GameData.Domains.Character.SortFilter.CharacterSortingType" />
	/// </summary>
	public static int GetCharacterSortingType(ECharacterPropertyReferencedType referencedType)
	{
		return (int)(100 + referencedType);
	}
}
