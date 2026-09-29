using System;
using Config.Common;

namespace Config;

[Serializable]
public class OtherActionTypeItem : ConfigItem<OtherActionTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string PrepareAnim;

	public readonly string PrepareParticle;

	public readonly string PrepareEndAnim;

	public readonly string PrepareEndParticle;

	public readonly string ForwardAnim;

	public readonly string ForwardParticle;

	public readonly string BackwardAnim;

	public readonly string BackwardParticle;

	public readonly string ForwardFastAnim;

	public readonly string ForwardFastParticle;

	public readonly string BackwardFastAnim;

	public readonly string BackwardFastParticle;

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

	public override OtherActionTypeItem Duplicate(int templateId)
	{
		return new OtherActionTypeItem((sbyte)templateId, this);
	}
}
