using System;
using Config.Common;

namespace Config;

[Serializable]
public class StoryScrollItem : ConfigItem<StoryScrollItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 绘卷主体
	/// - 此列写明该绘卷描绘的是哪一位剑冢化身
	/// </summary>
	public readonly sbyte StoryBoss;

	/// <summary>
	/// 地区主线门派
	/// - 此列写明该绘卷描绘的是哪一个地区门派
	/// </summary>
	public readonly sbyte StorySect;

	/// <summary>
	/// 绘卷页面阶段
	/// - 此列填写当前这一页绘卷是在剧情的哪个阶段，化身分为生缘执灭解/劫；地区绘卷分为盛/衰
	/// </summary>
	public readonly EStoryScrollStoryResultMark StoryResultMark;

	/// <summary>
	/// 文案内容
	/// - 此列填写悬停的文案内容，绘卷上的文字组件不会自动换行，需要策划在填写文案的时候手动换行
	/// </summary>
	public readonly string StoryNote;

	/// <summary>
	/// 绘卷入口（地区）
	/// - 此列填写解锁的地区绘卷（斜躺小图版）
	/// </summary>
	public readonly string StoryUnlocked;

	/// <summary>
	/// 绘卷首部
	/// - 此列填写绘卷首部icon，化身绘卷入口本体复用此列
	/// </summary>
	public readonly string StoryTypeIcon;

	/// <summary>
	/// 首部挂饰
	/// - 展开的绘卷上首部右侧的挂饰
	/// </summary>
	public readonly string StoryCharm;

	/// <summary>
	/// 绘卷尾部
	/// - 此列填写绘卷尾部icon
	/// </summary>
	public readonly string StoryEnd;

	/// <summary>
	/// 绘卷页面
	/// - 此列对应的是绘卷页面的插画资源的命名，实际的文字将会在这一张图片上出现；特殊注明：地区绘卷均已绘制完成，此处仅填写已经实装的绘卷，其余将统一留空，待后续实装后填写
	/// </summary>
	public readonly string StoryImage;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="storyBoss">绘卷主体 - 此列写明该绘卷描绘的是哪一位剑冢化身</param>
	/// <param name="storySect">地区主线门派 - 此列写明该绘卷描绘的是哪一个地区门派</param>
	/// <param name="storyResultMark">绘卷页面阶段 - 此列填写当前这一页绘卷是在剧情的哪个阶段，化身分为生缘执灭解/劫；地区绘卷分为盛/衰</param>
	/// <param name="storyNote">文案内容 - 此列填写悬停的文案内容，绘卷上的文字组件不会自动换行，需要策划在填写文案的时候手动换行</param>
	/// <param name="storyUnlocked">绘卷入口（地区） - 此列填写解锁的地区绘卷（斜躺小图版）</param>
	/// <param name="storyTypeIcon">绘卷首部 - 此列填写绘卷首部icon，化身绘卷入口本体复用此列</param>
	/// <param name="storyCharm">首部挂饰 - 展开的绘卷上首部右侧的挂饰</param>
	/// <param name="storyEnd">绘卷尾部 - 此列填写绘卷尾部icon</param>
	/// <param name="storyImage">绘卷页面 - 此列对应的是绘卷页面的插画资源的命名，实际的文字将会在这一张图片上出现；特殊注明：地区绘卷均已绘制完成，此处仅填写已经实装的绘卷，其余将统一留空，待后续实装后填写</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override StoryScrollItem Duplicate(int templateId)
	{
		return new StoryScrollItem((short)templateId, this);
	}
}
