using System;

namespace Config;

[Serializable]
public class EnhancedRichTextTagsItem
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 是否有关闭标识
	/// </summary>
	public readonly bool HasCloseTag;

	/// <summary>
	/// 有单独的处理器
	/// </summary>
	public readonly bool HasHandler;

	/// <summary>
	/// Open Tag 直接替换
	/// </summary>
	public readonly string OpenTagReplacement;

	/// <summary>
	/// Close Tag 直接替换
	/// </summary>
	public readonly string CloseTagReplacement;

	/// <summary>
	/// Open Tag 前确保自动换行数
	/// </summary>
	public readonly byte OpenTagLineBreakCount;

	/// <summary>
	/// Close Tag 后自动换行
	/// </summary>
	public readonly byte CloseTagLineBreakCount;

	public EnhancedRichTextTagsItem(short arg0, string arg1, bool arg2, bool arg3, string arg4, string arg5, byte arg6, byte arg7)
	{
		TemplateId = arg0;
		Name = arg1;
		HasCloseTag = arg2;
		HasHandler = arg3;
		OpenTagReplacement = arg4;
		CloseTagReplacement = arg5;
		OpenTagLineBreakCount = arg6;
		CloseTagLineBreakCount = arg7;
	}

	public EnhancedRichTextTagsItem()
	{
		TemplateId = 0;
		Name = null;
		HasCloseTag = true;
		HasHandler = false;
		OpenTagReplacement = null;
		CloseTagReplacement = null;
		OpenTagLineBreakCount = 0;
		CloseTagLineBreakCount = 0;
	}
}
