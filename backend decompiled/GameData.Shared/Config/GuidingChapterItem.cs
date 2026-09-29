using System;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterItem : ConfigItem<GuidingChapterItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short Class;

	public readonly bool ObsoleteItem;

	public readonly string[] PartTitle;

	public readonly string PartImage;

	public readonly short PartCount;

	public readonly string[] PartDesc;

	public readonly string Encyclopedia;

	public GuidingChapterItem(short templateId, string name, short shortClass, bool obsoleteItem, string[] partTitle, string partImage, short partCount, string[] partDesc, string encyclopedia)
	{
		TemplateId = templateId;
		Name = name;
		Class = shortClass;
		ObsoleteItem = obsoleteItem;
		PartTitle = partTitle;
		PartImage = partImage;
		PartCount = partCount;
		PartDesc = partDesc;
		Encyclopedia = encyclopedia;
	}

	public GuidingChapterItem()
	{
		TemplateId = 0;
		Name = null;
		Class = 0;
		ObsoleteItem = false;
		PartTitle = new string[0];
		PartImage = null;
		PartCount = 0;
		PartDesc = new string[0];
		Encyclopedia = null;
	}

	public GuidingChapterItem(short templateId, GuidingChapterItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Class = other.Class;
		ObsoleteItem = other.ObsoleteItem;
		PartTitle = other.PartTitle;
		PartImage = other.PartImage;
		PartCount = other.PartCount;
		PartDesc = other.PartDesc;
		Encyclopedia = other.Encyclopedia;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override GuidingChapterItem Duplicate(int templateId)
	{
		return new GuidingChapterItem((short)templateId, this);
	}
}
