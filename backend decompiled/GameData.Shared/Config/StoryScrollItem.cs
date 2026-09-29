using System;
using Config.Common;

namespace Config;

[Serializable]
public class StoryScrollItem : ConfigItem<StoryScrollItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte StoryBoss;

	public readonly sbyte StorySect;

	public readonly EStoryScrollStoryResultMark StoryResultMark;

	public readonly string StoryNote;

	public readonly string StoryUnlocked;

	public readonly string StoryTypeIcon;

	public readonly string StoryCharm;

	public readonly string StoryEnd;

	public readonly string StoryImage;

	public StoryScrollItem(short templateId, sbyte storyBoss, sbyte storySect, EStoryScrollStoryResultMark storyResultMark, string storyNote, string storyUnlocked, string storyTypeIcon, string storyCharm, string storyEnd, string storyImage)
	{
		TemplateId = templateId;
		StoryBoss = storyBoss;
		StorySect = storySect;
		StoryResultMark = storyResultMark;
		StoryNote = storyNote;
		StoryUnlocked = storyUnlocked;
		StoryTypeIcon = storyTypeIcon;
		StoryCharm = storyCharm;
		StoryEnd = storyEnd;
		StoryImage = storyImage;
	}

	public StoryScrollItem()
	{
		TemplateId = 0;
		StoryBoss = 0;
		StorySect = 0;
		StoryResultMark = EStoryScrollStoryResultMark.StoryResultMark0;
		StoryNote = null;
		StoryUnlocked = null;
		StoryTypeIcon = null;
		StoryCharm = null;
		StoryEnd = null;
		StoryImage = null;
	}

	public StoryScrollItem(short templateId, StoryScrollItem other)
	{
		TemplateId = templateId;
		StoryBoss = other.StoryBoss;
		StorySect = other.StorySect;
		StoryResultMark = other.StoryResultMark;
		StoryNote = other.StoryNote;
		StoryUnlocked = other.StoryUnlocked;
		StoryTypeIcon = other.StoryTypeIcon;
		StoryCharm = other.StoryCharm;
		StoryEnd = other.StoryEnd;
		StoryImage = other.StoryImage;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override StoryScrollItem Duplicate(int templateId)
	{
		return new StoryScrollItem((short)templateId, this);
	}
}
