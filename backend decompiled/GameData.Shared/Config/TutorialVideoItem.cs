using System;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialVideoItem : ConfigItem<TutorialVideoItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 视频文件夹
	/// </summary>
	public readonly string VideoPath;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 分P标题
	/// </summary>
	public readonly string[] PartsTitle;

	/// <summary>
	/// 分P描述
	/// </summary>
	public readonly string[] PartsDesc;

	/// <summary>
	/// 分P视频
	/// </summary>
	public readonly string[] PartVideos;

	/// <summary>
	/// 所属演武章节
	/// </summary>
	public readonly short Chapter;

	/// <summary>
	/// 章节内索引
	/// </summary>
	public readonly short SectionIndex;

	/// <summary>
	/// 演武章节名称
	/// </summary>
	public readonly string ChapterName;

	/// <summary>
	/// 演武概述
	/// </summary>
	public readonly string VideoSummary;

	/// <summary>
	/// 自定义坐标
	/// - 最小化引导在屏幕上的坐标. 不指定时为默认坐标.
	/// </summary>
	public readonly int[] CustomPosition;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="videoPath">视频文件夹</param>
	/// <param name="name">名称</param>
	/// <param name="partsTitle">分P标题</param>
	/// <param name="partsDesc">分P描述</param>
	/// <param name="partVideos">分P视频</param>
	/// <param name="chapter">所属演武章节</param>
	/// <param name="sectionIndex">章节内索引</param>
	/// <param name="chapterName">演武章节名称</param>
	/// <param name="videoSummary">演武概述</param>
	/// <param name="customPosition">自定义坐标 - 最小化引导在屏幕上的坐标. 不指定时为默认坐标.</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TutorialVideoItem Duplicate(int templateId)
	{
		return new TutorialVideoItem((short)templateId, this);
	}
}
