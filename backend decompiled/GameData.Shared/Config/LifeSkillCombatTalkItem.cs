using System;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillCombatTalkItem : ConfigItem<LifeSkillCombatTalkItem, short>
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
	/// 通用对白
	/// </summary>
	public readonly string NormalContent;

	/// <summary>
	/// 需要替换内容
	/// </summary>
	public readonly bool NeedRepalceType;

	/// <summary>
	/// 刚正对白
	/// </summary>
	public readonly string JustContent;

	/// <summary>
	/// 仁善对白
	/// </summary>
	public readonly string KindContent;

	/// <summary>
	/// 中庸对白
	/// </summary>
	public readonly string EvenContent;

	/// <summary>
	/// 叛逆对白
	/// </summary>
	public readonly string RebelContent;

	/// <summary>
	/// 唯我对白
	/// </summary>
	public readonly string EgoisticContent;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="normalContent">通用对白</param>
	/// <param name="needRepalceType">需要替换内容</param>
	/// <param name="justContent">刚正对白</param>
	/// <param name="kindContent">仁善对白</param>
	/// <param name="evenContent">中庸对白</param>
	/// <param name="rebelContent">叛逆对白</param>
	/// <param name="egoisticContent">唯我对白</param>
	public LifeSkillCombatTalkItem(short templateId, string name, string normalContent, bool needRepalceType, string justContent, string kindContent, string evenContent, string rebelContent, string egoisticContent)
	{
		TemplateId = templateId;
		Name = name;
		NormalContent = normalContent;
		NeedRepalceType = needRepalceType;
		JustContent = justContent;
		KindContent = kindContent;
		EvenContent = evenContent;
		RebelContent = rebelContent;
		EgoisticContent = egoisticContent;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeSkillCombatTalkItem()
	{
		TemplateId = 0;
		Name = null;
		NormalContent = null;
		NeedRepalceType = false;
		JustContent = null;
		KindContent = null;
		EvenContent = null;
		RebelContent = null;
		EgoisticContent = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LifeSkillCombatTalkItem(short templateId, LifeSkillCombatTalkItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		NormalContent = other.NormalContent;
		NeedRepalceType = other.NeedRepalceType;
		JustContent = other.JustContent;
		KindContent = other.KindContent;
		EvenContent = other.EvenContent;
		RebelContent = other.RebelContent;
		EgoisticContent = other.EgoisticContent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeSkillCombatTalkItem Duplicate(int templateId)
	{
		return new LifeSkillCombatTalkItem((short)templateId, this);
	}
}
