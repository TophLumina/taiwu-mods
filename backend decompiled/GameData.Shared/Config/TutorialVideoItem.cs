using System;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialVideoItem : ConfigItem<TutorialVideoItem, short>
{
	public readonly short TemplateId;

	public readonly string VideoPath;

	public readonly string Name;

	public readonly string[] PartsTitle;

	public readonly string[] PartsDesc;

	public readonly string[] PartVideos;

	public readonly short Chapter;

	public readonly short SectionIndex;

	public readonly string ChapterName;

	public readonly string VideoSummary;

	public readonly int[] CustomPosition;

	public TutorialVideoItem(short templateId, string videoPath, string name, string[] partsTitle, string[] partsDesc, string[] partVideos, short chapter, short sectionIndex, string chapterName, string videoSummary, int[] customPosition)
	{
		TemplateId = templateId;
		VideoPath = videoPath;
		Name = name;
		PartsTitle = partsTitle;
		PartsDesc = partsDesc;
		PartVideos = partVideos;
		Chapter = chapter;
		SectionIndex = sectionIndex;
		ChapterName = chapterName;
		VideoSummary = videoSummary;
		CustomPosition = customPosition;
	}

	public TutorialVideoItem()
	{
		TemplateId = 0;
		VideoPath = null;
		Name = null;
		PartsTitle = null;
		PartsDesc = null;
		PartVideos = null;
		Chapter = 0;
		SectionIndex = -1;
		ChapterName = null;
		VideoSummary = null;
		CustomPosition = null;
	}

	public TutorialVideoItem(short templateId, TutorialVideoItem other)
	{
		TemplateId = templateId;
		VideoPath = other.VideoPath;
		Name = other.Name;
		PartsTitle = other.PartsTitle;
		PartsDesc = other.PartsDesc;
		PartVideos = other.PartVideos;
		Chapter = other.Chapter;
		SectionIndex = other.SectionIndex;
		ChapterName = other.ChapterName;
		VideoSummary = other.VideoSummary;
		CustomPosition = other.CustomPosition;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TutorialVideoItem Duplicate(int templateId)
	{
		return new TutorialVideoItem((short)templateId, this);
	}
}
