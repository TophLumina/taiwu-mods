using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventActorsItem : ConfigItem<EventActorsItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Texture;

	public readonly string SpineName;

	public readonly string SpineSkinName;

	public readonly sbyte Gender;

	public readonly byte[] Age;

	public readonly short[] Attraction;

	public readonly short Clothing;

	public readonly bool IsMonk;

	public readonly sbyte PresetBodyType;

	public EventActorsItem(short templateId, string name, string texture, string spineName, string spineSkinName, sbyte gender, byte[] age, short[] attraction, short clothing, bool isMonk, sbyte presetBodyType)
	{
		TemplateId = templateId;
		Name = name;
		Texture = texture;
		SpineName = spineName;
		SpineSkinName = spineSkinName;
		Gender = gender;
		Age = age;
		Attraction = attraction;
		Clothing = clothing;
		IsMonk = isMonk;
		PresetBodyType = presetBodyType;
	}

	public EventActorsItem()
	{
		TemplateId = 0;
		Name = null;
		Texture = null;
		SpineName = null;
		SpineSkinName = null;
		Gender = -1;
		Age = new byte[2] { 18, 60 };
		Attraction = new short[2] { 0, 900 };
		Clothing = 0;
		IsMonk = false;
		PresetBodyType = -1;
	}

	public EventActorsItem(short templateId, EventActorsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Texture = other.Texture;
		SpineName = other.SpineName;
		SpineSkinName = other.SpineSkinName;
		Gender = other.Gender;
		Age = other.Age;
		Attraction = other.Attraction;
		Clothing = other.Clothing;
		IsMonk = other.IsMonk;
		PresetBodyType = other.PresetBodyType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventActorsItem Duplicate(int templateId)
	{
		return new EventActorsItem((short)templateId, this);
	}
}
