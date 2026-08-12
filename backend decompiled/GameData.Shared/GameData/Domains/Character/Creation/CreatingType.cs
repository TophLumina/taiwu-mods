namespace GameData.Domains.Character.Creation;

/// <summary>
/// 角色生成方式
/// </summary>
public static class CreatingType
{
	/// <summary>
	/// 固定角色 (不会重复创建的预设角色，如 Boss, 剧情人物等)
	/// </summary>
	public const byte FixedCharacter = 0;

	/// <summary>
	/// 智能角色 (随机姓名和属性, 有生活行为的角色)
	/// </summary>
	public const byte IntelligentCharacter = 1;

	/// <summary>
	/// 随机敌人 (无随机姓名, 属性随机)
	/// </summary>
	public const byte RandomEnemy = 2;

	/// <summary>
	/// 固定敌人 (可以重复创建的预设角色，如动物)
	/// </summary>
	public const byte FixedEnemy = 3;

	/// <summary>
	/// 是否为根据固定模板数据生成，使用固定头像的预设角色创建类型
	/// </summary>
	public static bool IsFixedPresetType(byte creatingType)
	{
		if (creatingType != 0)
		{
			return creatingType == 3;
		}
		return true;
	}

	/// <summary>
	/// 是否为非演化角色类型
	/// </summary>
	public static bool IsNonEvolutionaryType(byte creatingType)
	{
		if (creatingType != 0 && creatingType != 2)
		{
			return creatingType == 3;
		}
		return true;
	}
}
