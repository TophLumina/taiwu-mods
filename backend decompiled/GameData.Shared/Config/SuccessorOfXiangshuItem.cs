using System;
using Config.Common;

namespace Config;

[Serializable]
public class SuccessorOfXiangshuItem : ConfigItem<SuccessorOfXiangshuItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte MapState;

	public readonly short[] Character;

	public readonly short CharacterFeature;

	public SuccessorOfXiangshuItem(sbyte templateId, sbyte mapState, short[] character, short characterFeature)
	{
		TemplateId = templateId;
		MapState = mapState;
		Character = character;
		CharacterFeature = characterFeature;
	}

	public SuccessorOfXiangshuItem()
	{
		TemplateId = 0;
		MapState = 0;
		Character = null;
		CharacterFeature = 0;
	}

	public SuccessorOfXiangshuItem(sbyte templateId, SuccessorOfXiangshuItem other)
	{
		TemplateId = templateId;
		MapState = other.MapState;
		Character = other.Character;
		CharacterFeature = other.CharacterFeature;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SuccessorOfXiangshuItem Duplicate(int templateId)
	{
		return new SuccessorOfXiangshuItem((sbyte)templateId, this);
	}
}
