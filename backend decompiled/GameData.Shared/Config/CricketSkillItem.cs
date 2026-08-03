using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketSkillItem : ConfigItem<CricketSkillItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 发动时机
	/// </summary>
	public readonly string EffectCondition;

	/// <summary>
	/// 技能效果
	/// </summary>
	public readonly string EffectDesc;

	/// <summary>
	/// 生效提示
	/// </summary>
	public readonly string EffectTips;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="effectCondition">发动时机</param>
	/// <param name="effectDesc">技能效果</param>
	/// <param name="effectTips">生效提示</param>
	public CricketSkillItem(int templateId, string name, string effectCondition, string effectDesc, string effectTips)
	{
		TemplateId = templateId;
		Name = name;
		EffectCondition = effectCondition;
		EffectDesc = effectDesc;
		EffectTips = effectTips;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CricketSkillItem()
	{
		TemplateId = 0;
		Name = null;
		EffectCondition = null;
		EffectDesc = null;
		EffectTips = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CricketSkillItem(int templateId, CricketSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EffectCondition = other.EffectCondition;
		EffectDesc = other.EffectDesc;
		EffectTips = other.EffectTips;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CricketSkillItem Duplicate(int templateId)
	{
		return new CricketSkillItem(templateId, this);
	}
}
