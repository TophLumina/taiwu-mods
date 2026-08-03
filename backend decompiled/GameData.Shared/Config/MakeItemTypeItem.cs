using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MakeItemTypeItem : ConfigItem<MakeItemTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 物品类型
	/// </summary>
	public readonly short ItemSubType;

	/// <summary>
	/// 类型名称
	/// </summary>
	public readonly string TypeName;

	/// <summary>
	/// 类型大图标
	/// - 用于代制选择类型，配了图标才能选择和进行代制
	/// </summary>
	public readonly string TypeBigIcon;

	/// <summary>
	/// 包含类别
	/// - 见MakeItemSubType；当包含类别仅有1个时，UI界面不扩展显示子类，当包含类别为多个时，UI界面扩展显示所有类别为可选子类
	/// </summary>
	public readonly List<short> MakeItemSubTypes;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="itemSubType">物品类型</param>
	/// <param name="typeName">类型名称</param>
	/// <param name="typeBigIcon">类型大图标 - 用于代制选择类型，配了图标才能选择和进行代制</param>
	/// <param name="makeItemSubTypes">包含类别 - 见MakeItemSubType；当包含类别仅有1个时，UI界面不扩展显示子类，当包含类别为多个时，UI界面扩展显示所有类别为可选子类</param>
	public MakeItemTypeItem(short templateId, string name, short itemSubType, string typeName, string typeBigIcon, List<short> makeItemSubTypes)
	{
		TemplateId = templateId;
		Name = name;
		ItemSubType = itemSubType;
		TypeName = typeName;
		TypeBigIcon = typeBigIcon;
		MakeItemSubTypes = makeItemSubTypes;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MakeItemTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ItemSubType = 0;
		TypeName = null;
		TypeBigIcon = null;
		MakeItemSubTypes = new List<short>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MakeItemTypeItem(short templateId, MakeItemTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ItemSubType = other.ItemSubType;
		TypeName = other.TypeName;
		TypeBigIcon = other.TypeBigIcon;
		MakeItemSubTypes = other.MakeItemSubTypes;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MakeItemTypeItem Duplicate(int templateId)
	{
		return new MakeItemTypeItem((short)templateId, this);
	}
}
