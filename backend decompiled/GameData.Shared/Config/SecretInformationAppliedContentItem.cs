using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedContentItem : ConfigItem<SecretInformationAppliedContentItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 跳转结果
	/// - 如果此列不为默认值，则直接跳转到对应的result
	/// </summary>
	public readonly short LinkedResult;

	/// <summary>
	/// 这一列不应有默认值，由策划在新增回应内容时手动维护，如果此列没有内容，会导致引用了该内容的事件报错
	/// </summary>
	public readonly string[] Texts;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="linkedResult">跳转结果 - 如果此列不为默认值，则直接跳转到对应的result</param>
	/// <param name="texts">这一列不应有默认值，由策划在新增回应内容时手动维护，如果此列没有内容，会导致引用了该内容的事件报错</param>
	public SecretInformationAppliedContentItem(short templateId, short linkedResult, string[] texts)
	{
		TemplateId = templateId;
		LinkedResult = linkedResult;
		Texts = texts;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationAppliedContentItem()
	{
		TemplateId = 0;
		LinkedResult = 0;
		Texts = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationAppliedContentItem(short templateId, SecretInformationAppliedContentItem other)
	{
		TemplateId = templateId;
		LinkedResult = other.LinkedResult;
		Texts = other.Texts;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationAppliedContentItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedContentItem((short)templateId, this);
	}
}
