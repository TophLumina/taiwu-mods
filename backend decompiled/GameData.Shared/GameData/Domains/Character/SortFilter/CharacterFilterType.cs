namespace GameData.Domains.Character.SortFilter;

/// <summary>
/// 筛选规则
/// </summary>
public static class CharacterFilterType
{
	/// <summary>
	/// 指定了悟轮回的母亲
	/// </summary>
	public const sbyte DirectSamsaraMother = 0;

	/// <summary>
	/// 在指定奇遇中
	/// </summary>
	public const sbyte InTargetAdventure = 1;

	/// <summary>
	/// 与指定角色有关系
	/// </summary>
	public const sbyte HasRelationWithCharacter = 2;

	/// <summary>
	/// 百花生命链接目标
	/// </summary>
	public const sbyte CanLinkInLifeDeathGate = 3;

	/// <summary>
	/// 需求公库物品的村民
	/// </summary>
	public const sbyte NeedTreasuryItemVillager = 4;

	/// <summary>
	/// 认识太吾的，排除同道
	/// </summary>
	public const sbyte CanMakeAppointment = 5;

	/// <summary>
	/// 姬穸吸食真气的目标
	/// </summary>
	public const sbyte JixiCanDrainNeili = 6;

	/// <summary>
	/// 姬穸转移五行的目标
	/// </summary>
	public const sbyte JixiCanTransferFiveElements = 7;
}
