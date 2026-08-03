using System;
using Config.Common;

namespace Config;

[Serializable]
public class OtherActionTypeItem : ConfigItem<OtherActionTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 读条动画
	/// </summary>
	public readonly string PrepareAnim;

	/// <summary>
	/// 读条特效
	/// </summary>
	public readonly string PrepareParticle;

	/// <summary>
	/// 读条结束动画
	/// </summary>
	public readonly string PrepareEndAnim;

	/// <summary>
	/// 读条结束特效
	/// </summary>
	public readonly string PrepareEndParticle;

	/// <summary>
	/// 常速前进动画
	/// </summary>
	public readonly string ForwardAnim;

	/// <summary>
	/// 常速前进特效
	/// </summary>
	public readonly string ForwardParticle;

	/// <summary>
	/// 常速后退动画
	/// </summary>
	public readonly string BackwardAnim;

	/// <summary>
	/// 常速后退特效
	/// </summary>
	public readonly string BackwardParticle;

	/// <summary>
	/// 快速前进动画
	/// </summary>
	public readonly string ForwardFastAnim;

	/// <summary>
	/// 快速前进特效
	/// </summary>
	public readonly string ForwardFastParticle;

	/// <summary>
	/// 快速后退动画
	/// </summary>
	public readonly string BackwardFastAnim;

	/// <summary>
	/// 快速后退特效
	/// </summary>
	public readonly string BackwardFastParticle;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="prepareAnim">读条动画</param>
	/// <param name="prepareParticle">读条特效</param>
	/// <param name="prepareEndAnim">读条结束动画</param>
	/// <param name="prepareEndParticle">读条结束特效</param>
	/// <param name="forwardAnim">常速前进动画</param>
	/// <param name="forwardParticle">常速前进特效</param>
	/// <param name="backwardAnim">常速后退动画</param>
	/// <param name="backwardParticle">常速后退特效</param>
	/// <param name="forwardFastAnim">快速前进动画</param>
	/// <param name="forwardFastParticle">快速前进特效</param>
	/// <param name="backwardFastAnim">快速后退动画</param>
	/// <param name="backwardFastParticle">快速后退特效</param>
	public OtherActionTypeItem(sbyte templateId, string prepareAnim, string prepareParticle, string prepareEndAnim, string prepareEndParticle, string forwardAnim, string forwardParticle, string backwardAnim, string backwardParticle, string forwardFastAnim, string forwardFastParticle, string backwardFastAnim, string backwardFastParticle)
	{
		TemplateId = templateId;
		PrepareAnim = prepareAnim;
		PrepareParticle = prepareParticle;
		PrepareEndAnim = prepareEndAnim;
		PrepareEndParticle = prepareEndParticle;
		ForwardAnim = forwardAnim;
		ForwardParticle = forwardParticle;
		BackwardAnim = backwardAnim;
		BackwardParticle = backwardParticle;
		ForwardFastAnim = forwardFastAnim;
		ForwardFastParticle = forwardFastParticle;
		BackwardFastAnim = backwardFastAnim;
		BackwardFastParticle = backwardFastParticle;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public OtherActionTypeItem()
	{
		TemplateId = 0;
		PrepareAnim = null;
		PrepareParticle = null;
		PrepareEndAnim = null;
		PrepareEndParticle = null;
		ForwardAnim = null;
		ForwardParticle = null;
		BackwardAnim = null;
		BackwardParticle = null;
		ForwardFastAnim = null;
		ForwardFastParticle = null;
		BackwardFastAnim = null;
		BackwardFastParticle = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public OtherActionTypeItem(sbyte templateId, OtherActionTypeItem other)
	{
		TemplateId = templateId;
		PrepareAnim = other.PrepareAnim;
		PrepareParticle = other.PrepareParticle;
		PrepareEndAnim = other.PrepareEndAnim;
		PrepareEndParticle = other.PrepareEndParticle;
		ForwardAnim = other.ForwardAnim;
		ForwardParticle = other.ForwardParticle;
		BackwardAnim = other.BackwardAnim;
		BackwardParticle = other.BackwardParticle;
		ForwardFastAnim = other.ForwardFastAnim;
		ForwardFastParticle = other.ForwardFastParticle;
		BackwardFastAnim = other.BackwardFastAnim;
		BackwardFastParticle = other.BackwardFastParticle;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override OtherActionTypeItem Duplicate(int templateId)
	{
		return new OtherActionTypeItem((sbyte)templateId, this);
	}
}
