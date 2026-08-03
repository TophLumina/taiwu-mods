namespace GameData.Domains.Character;

/// <summary>
/// 铭刻状态
/// 小于0隐藏按钮；等于0可铭刻；大于0按位显示不可铭刻的原因tips
/// </summary>
public static class InscriptionStatus
{
	/// <summary>
	/// 太吾
	/// </summary>
	public const sbyte Taiwu = -1;

	/// <summary>
	/// 非智能角色
	/// </summary>
	public const sbyte NotIntelligentCharacter = -2;

	/// <summary>
	/// 主线进度不到继承太吾
	/// </summary>
	public const sbyte MainStoryLineProgress = -3;

	/// <summary>
	/// 可铭刻
	/// </summary>
	public const sbyte Inscribable = 0;

	/// <summary>
	/// 已铭刻过
	/// </summary>
	public const sbyte Inscribed = 1;

	/// <summary>
	/// 镜像角色
	/// </summary>
	public const sbyte MirrorCharacter = 2;

	/// <summary>
	/// 不是同道
	/// </summary>
	public const sbyte NotTeammate = 3;

	/// <summary>
	/// 未成年
	/// </summary>
	public const sbyte NotAdult = 4;

	/// <summary>
	/// 好感度不足
	/// </summary>
	public const sbyte Favorability = 5;

	/// <summary>
	/// 野兽同道
	/// </summary>
	public const sbyte IsBeastCarrier = 6;

	/// <summary>
	///
	/// </summary>
	public const sbyte Count = 7;
}
