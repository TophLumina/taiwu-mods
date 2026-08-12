using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterAlertnessRecordItem : ConfigItem<CharacterAlertnessRecordItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数4" 共 5 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly ECharacterAlertnessRecordType Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">显示名称</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数4" 共 5 个字段.</param>
	/// <param name="type">类型</param>
	public CharacterAlertnessRecordItem(short templateId, string name, string desc, string[] parameters, ECharacterAlertnessRecordType type)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		Type = type;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterAlertnessRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[5] { "", "", "", "", "" };
		Type = ECharacterAlertnessRecordType.Initial;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterAlertnessRecordItem(short templateId, CharacterAlertnessRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		Type = other.Type;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterAlertnessRecordItem Duplicate(int templateId)
	{
		return new CharacterAlertnessRecordItem((short)templateId, this);
	}
}
