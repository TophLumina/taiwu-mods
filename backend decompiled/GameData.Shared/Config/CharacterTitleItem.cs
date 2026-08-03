using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTitleItem : ConfigItem<CharacterTitleItem, short>
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
	/// 关联杂物
	/// </summary>
	public readonly short Misc;

	/// <summary>
	/// 持续时间
	/// - 手动添加后的持续时间, -1表示该称号不能直接添加
	/// </summary>
	public readonly int Duration;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="misc">关联杂物</param>
	/// <param name="duration">持续时间 - 手动添加后的持续时间, -1表示该称号不能直接添加</param>
	public CharacterTitleItem(short templateId, string name, short misc, int duration)
	{
		TemplateId = templateId;
		Name = name;
		Misc = misc;
		Duration = duration;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterTitleItem()
	{
		TemplateId = 0;
		Name = null;
		Misc = 0;
		Duration = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterTitleItem(short templateId, CharacterTitleItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Misc = other.Misc;
		Duration = other.Duration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterTitleItem Duplicate(int templateId)
	{
		return new CharacterTitleItem((short)templateId, this);
	}
}
