using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PuppetItem : ConfigItem<PuppetItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EPuppetType Type;

	/// <summary>
	/// 立绘
	/// </summary>
	public readonly string Avatar;

	/// <summary>
	/// 关联地区主线
	/// - 对应 Organization 表
	/// </summary>
	public readonly sbyte SectId;

	/// <summary>
	/// 角色模板
	/// - 对应Character表
	/// </summary>
	public readonly short CharacterId;

	/// <summary>
	/// 可选难度
	/// - 对应精纯值
	/// </summary>
	public readonly List<sbyte> Difficulties;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="type">类型</param>
	/// <param name="avatar">立绘</param>
	/// <param name="sectId">关联地区主线 - 对应 Organization 表</param>
	/// <param name="characterId">角色模板 - 对应Character表</param>
	/// <param name="difficulties">可选难度 - 对应精纯值</param>
	public PuppetItem(short templateId, string name, string desc, EPuppetType type, string avatar, sbyte sectId, short characterId, List<sbyte> difficulties)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Type = type;
		Avatar = avatar;
		SectId = sectId;
		CharacterId = characterId;
		Difficulties = difficulties;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PuppetItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Type = EPuppetType.Invalid;
		Avatar = null;
		SectId = 0;
		CharacterId = 0;
		Difficulties = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PuppetItem(short templateId, PuppetItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Type = other.Type;
		Avatar = other.Avatar;
		SectId = other.SectId;
		CharacterId = other.CharacterId;
		Difficulties = other.Difficulties;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PuppetItem Duplicate(int templateId)
	{
		return new PuppetItem((short)templateId, this);
	}
}
