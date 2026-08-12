using System;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterItem : ConfigItem<GuidingChapterItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 引导条目名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 所属大类
	/// </summary>
	public readonly short Class;

	/// <summary>
	/// 废弃
	/// </summary>
	public readonly bool ObsoleteItem;

	/// <summary>
	/// 分P标题
	/// </summary>
	public readonly string[] PartTitle;

	/// <summary>
	/// 教学图片
	/// </summary>
	public readonly string PartImage;

	/// <summary>
	/// 分p数量
	/// </summary>
	public readonly short PartCount;

	/// <summary>
	/// 教学描述
	/// </summary>
	public readonly string[] PartDesc;

	/// <summary>
	/// 跳转百晓册
	/// </summary>
	public readonly string Encyclopedia;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">引导条目名称</param>
	/// <param name="shortClass">所属大类</param>
	/// <param name="obsoleteItem">废弃</param>
	/// <param name="partTitle">分P标题</param>
	/// <param name="partImage">教学图片</param>
	/// <param name="partCount">分p数量</param>
	/// <param name="partDesc">教学描述</param>
	/// <param name="encyclopedia">跳转百晓册</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override GuidingChapterItem Duplicate(int templateId)
	{
		return new GuidingChapterItem((short)templateId, this);
	}
}
