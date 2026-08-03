using System;
using Config.Common;

namespace Config;

[Serializable]
public class BodyPartItem : ConfigItem<BodyPartItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 封穴效果描述
	/// </summary>
	public readonly string AcupointDesc;

	/// <summary>
	/// 封穴效果参数
	/// </summary>
	public readonly int[] AcupointParam;

	/// <summary>
	/// 封穴效果档位
	/// </summary>
	public readonly int[] AcupointTime;

	/// <summary>
	/// Tips图标
	/// </summary>
	public readonly string MouseTipIcon;

	/// <summary>
	/// 外伤图标
	/// </summary>
	public readonly string OuterInjuryIcon;

	/// <summary>
	/// 内伤图标
	/// </summary>
	public readonly string InnerInjuryIcon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="acupointDesc">封穴效果描述</param>
	/// <param name="acupointParam">封穴效果参数</param>
	/// <param name="acupointTime">封穴效果档位</param>
	/// <param name="mouseTipIcon">Tips图标</param>
	/// <param name="outerInjuryIcon">外伤图标</param>
	/// <param name="innerInjuryIcon">内伤图标</param>
	public BodyPartItem(sbyte templateId, string name, string acupointDesc, int[] acupointParam, int[] acupointTime, string mouseTipIcon, string outerInjuryIcon, string innerInjuryIcon)
	{
		TemplateId = templateId;
		Name = name;
		AcupointDesc = acupointDesc;
		AcupointParam = acupointParam;
		AcupointTime = acupointTime;
		MouseTipIcon = mouseTipIcon;
		OuterInjuryIcon = outerInjuryIcon;
		InnerInjuryIcon = innerInjuryIcon;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BodyPartItem()
	{
		TemplateId = 0;
		Name = null;
		AcupointDesc = null;
		AcupointParam = null;
		AcupointTime = new int[3] { 0, 50, 75 };
		MouseTipIcon = null;
		OuterInjuryIcon = null;
		InnerInjuryIcon = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BodyPartItem(sbyte templateId, BodyPartItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		AcupointDesc = other.AcupointDesc;
		AcupointParam = other.AcupointParam;
		AcupointTime = other.AcupointTime;
		MouseTipIcon = other.MouseTipIcon;
		OuterInjuryIcon = other.OuterInjuryIcon;
		InnerInjuryIcon = other.InnerInjuryIcon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BodyPartItem Duplicate(int templateId)
	{
		return new BodyPartItem((sbyte)templateId, this);
	}
}
