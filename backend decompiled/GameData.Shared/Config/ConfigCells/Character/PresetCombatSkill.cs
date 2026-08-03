using System;

namespace Config.ConfigCells.Character;

/// <summary>
/// 预设功法数据
///
/// 模板数据中单个功法的配置格式有以下五种:
///     `功法模板 ID`
///     `功法模板 ID, 已读总纲页数, 已读正练书页数, 已读逆练书页数`
///     `功法模板 ID, 已读总纲页数, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}`
///     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, 已读正练书页数, 已读逆练书页数`
///     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}`
/// 已读总纲页数取值范围 [0, 5].
/// 已读正逆练书页数取值范围 [0, 5].
/// 总纲类型N是否已读: 指定位置的元素和指定位置的总纲类型对应, 0 为未读, 1 为已读.
/// 总纲类型: 0: 刚正, 1: 仁善, 2: 中庸, 3: 叛逆, 4: 唯我.
/// 正逆练页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
/// 示例：
///     `{3, 100}`: 功法模板 ID 3, 修习度 100.
///     `{5, 30, 2, 3, 0}`: 功法模板 ID 5, 修习度 30, 随机两个总纲已读, 正练随机 3 页已读, 逆练全部未读.
///     `{2, 100, {1,1,0,0,0}, {1,1,1,1,1}, {0,0,1,0,0}}`: 功法模板 ID 2, 修习度 100, 已读总纲刚正及仁善, 正练全部已读, 逆练已读第 2 页.
///
/// 因为是模板数据, 所以不会使任何随机量被确定, 也不会进行突破.
/// </summary>
[Serializable]
public struct PresetCombatSkill
{
	/// <summary>
	/// 功法模板 ID
	/// </summary>
	public readonly short SkillTemplateId;

	/// <summary>
	/// 已读总纲页数 (随机决定具体哪些类型已读).
	/// 为 -1 表示转而使用具体的已读状态.
	/// </summary>
	public readonly sbyte OutlinePagesReadCount;

	/// <summary>
	/// 总纲的已读状态.
	/// 长度固定, 指定位置的元素和指定位置的总纲类型对应, 0 为未读, 1 为已读.
	/// 总纲类型参见 <see cref="T:GameData.Domains.Character.BehaviorType" />.
	/// </summary>
	public readonly bool[] OutlinePagesReadStates;

	/// <summary>
	/// 正练书页已读页数 (随机决定具体哪些页已读).
	/// 为 -1 表示转而使用具体的已读状态.
	/// </summary>
	public readonly sbyte DirectPagesReadCount;

	/// <summary>
	/// 正练书页具体的已读状态.
	/// 长度固定, 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
	/// </summary>
	public readonly bool[] DirectPagesReadStates;

	/// <summary>
	/// 逆练书页已读页数 (随机决定具体哪些页已读).
	/// 为 -1 表示转而使用具体的已读状态.
	/// </summary>
	public readonly sbyte ReversePagesReadCount;

	/// <summary>
	/// 逆练书页具体的已读状态.
	/// 长度固定, 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
	/// </summary>
	public readonly bool[] ReversePagesReadStates;

	/// <summary>
	/// 配置类型 1 和 2 的构造方法
	/// </summary>
	public PresetCombatSkill(short skillTemplateId, sbyte outlinePagesReadCount = 0, sbyte directPagesReadCount = 0, sbyte reversePagesReadCount = 0)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = outlinePagesReadCount;
		OutlinePagesReadStates = null;
		DirectPagesReadCount = directPagesReadCount;
		DirectPagesReadStates = null;
		ReversePagesReadCount = reversePagesReadCount;
		ReversePagesReadStates = null;
	}

	/// <summary>
	/// 配置类型 3 的构造方法
	/// </summary>
	public PresetCombatSkill(short skillTemplateId, sbyte outlinePagesReadCount, int[] directPagesReadStates, int[] reversePagesReadStates)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = outlinePagesReadCount;
		OutlinePagesReadStates = null;
		DirectPagesReadCount = -1;
		DirectPagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			DirectPagesReadStates[i] = directPagesReadStates[i] != 0;
		}
		ReversePagesReadCount = -1;
		ReversePagesReadStates = new bool[5];
		for (int j = 0; j < 5; j++)
		{
			ReversePagesReadStates[j] = reversePagesReadStates[j] != 0;
		}
	}

	/// <summary>
	/// 配置类型 4 的构造方法
	/// </summary>
	public PresetCombatSkill(short skillTemplateId, int[] outlinePagesReadStates, sbyte directPagesReadCount, sbyte reversePagesReadCount)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = -1;
		OutlinePagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			OutlinePagesReadStates[i] = outlinePagesReadStates[i] != 0;
		}
		DirectPagesReadCount = directPagesReadCount;
		DirectPagesReadStates = null;
		ReversePagesReadCount = reversePagesReadCount;
		ReversePagesReadStates = null;
	}

	/// <summary>
	/// 配置类型 5 的构造方法
	/// </summary>
	public PresetCombatSkill(short skillTemplateId, int[] outlinePagesReadStates, int[] directPagesReadStates, int[] reversePagesReadStates)
	{
		SkillTemplateId = skillTemplateId;
		OutlinePagesReadCount = -1;
		OutlinePagesReadStates = new bool[5];
		for (int i = 0; i < 5; i++)
		{
			OutlinePagesReadStates[i] = outlinePagesReadStates[i] != 0;
		}
		DirectPagesReadCount = -1;
		DirectPagesReadStates = new bool[5];
		for (int j = 0; j < 5; j++)
		{
			DirectPagesReadStates[j] = directPagesReadStates[j] != 0;
		}
		ReversePagesReadCount = -1;
		ReversePagesReadStates = new bool[5];
		for (int k = 0; k < 5; k++)
		{
			ReversePagesReadStates[k] = reversePagesReadStates[k] != 0;
		}
	}
}
