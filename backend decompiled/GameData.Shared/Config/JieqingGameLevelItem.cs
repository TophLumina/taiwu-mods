using System;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGameLevelItem : ConfigItem<JieqingGameLevelItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 目标分数
	/// </summary>
	public readonly sbyte SingPitch;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="singPitch">目标分数</param>
	public JieqingGameLevelItem(short templateId, sbyte singPitch)
	{
		TemplateId = templateId;
		SingPitch = singPitch;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JieqingGameLevelItem()
	{
		TemplateId = 0;
		SingPitch = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JieqingGameLevelItem(short templateId, JieqingGameLevelItem other)
	{
		TemplateId = templateId;
		SingPitch = other.SingPitch;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JieqingGameLevelItem Duplicate(int templateId)
	{
		return new JieqingGameLevelItem((short)templateId, this);
	}
}
