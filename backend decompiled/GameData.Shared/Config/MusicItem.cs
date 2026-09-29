using System;
using Config.Common;

namespace Config;

[Serializable]
public class MusicItem : ConfigItem<MusicItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short MapBlock;

	public readonly sbyte MapState;

	public readonly string Icon;

	public readonly short HitRateMind;

	public readonly int AvoidRateMind;

	public readonly short TemporaryFeature;

	public readonly string Desc;

	public readonly string Evaluation;

	public MusicItem(short templateId, string name, short mapBlock, sbyte mapState, string icon, short hitRateMind, int avoidRateMind, short temporaryFeature, string desc, string evaluation)
	{
		TemplateId = templateId;
		Name = name;
		MapBlock = mapBlock;
		MapState = mapState;
		Icon = icon;
		HitRateMind = hitRateMind;
		AvoidRateMind = avoidRateMind;
		TemporaryFeature = temporaryFeature;
		Desc = desc;
		Evaluation = evaluation;
	}

	public MusicItem()
	{
		TemplateId = 0;
		Name = null;
		MapBlock = 0;
		MapState = 0;
		Icon = null;
		HitRateMind = 0;
		AvoidRateMind = 0;
		TemporaryFeature = 0;
		Desc = null;
		Evaluation = null;
	}

	public MusicItem(short templateId, MusicItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		MapBlock = other.MapBlock;
		MapState = other.MapState;
		Icon = other.Icon;
		HitRateMind = other.HitRateMind;
		AvoidRateMind = other.AvoidRateMind;
		TemporaryFeature = other.TemporaryFeature;
		Desc = other.Desc;
		Evaluation = other.Evaluation;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MusicItem Duplicate(int templateId)
	{
		return new MusicItem((short)templateId, this);
	}

	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.HitRateMind => HitRateMind, 
			ECharacterPropertyReferencedType.AvoidRateMind => AvoidRateMind, 
			_ => 0, 
		};
	}
}
