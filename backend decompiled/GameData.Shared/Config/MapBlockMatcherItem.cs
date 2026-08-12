using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockMatcherItem : ConfigItem<MapBlockMatcherItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 限定地形大类
	/// - 不填表示不限制
	/// </summary>
	public readonly EMapBlockType[] IncludeTypes;

	/// <summary>
	/// 限定地形细类
	/// - 不填表示不限制
	/// </summary>
	public readonly EMapBlockSubType[] IncludeSubTypes;

	/// <summary>
	/// 排除地形大类
	/// - 不填表示不排除
	/// </summary>
	public readonly EMapBlockType[] ExcludeTypes;

	/// <summary>
	/// 排除地形细类
	/// - 不填表示不排除
	/// </summary>
	public readonly EMapBlockSubType[] ExcludeSubTypes;

	/// <summary>
	/// 排除有智能人物
	/// - 不包含太吾
	/// </summary>
	public readonly bool ExcludeBlocksWithIntelligentCharacters;

	/// <summary>
	/// 排除有奇遇
	/// </summary>
	public readonly bool ExcludeBlocksWithAdventure;

	/// <summary>
	/// 排除有特效
	/// - 地主血光特效等
	/// </summary>
	public readonly bool ExcludeBlocksWithEffect;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="includeTypes">限定地形大类 - 不填表示不限制</param>
	/// <param name="includeSubTypes">限定地形细类 - 不填表示不限制</param>
	/// <param name="excludeTypes">排除地形大类 - 不填表示不排除</param>
	/// <param name="excludeSubTypes">排除地形细类 - 不填表示不排除</param>
	/// <param name="excludeBlocksWithIntelligentCharacters">排除有智能人物 - 不包含太吾</param>
	/// <param name="excludeBlocksWithAdventure">排除有奇遇</param>
	/// <param name="excludeBlocksWithEffect">排除有特效 - 地主血光特效等</param>
	public MapBlockMatcherItem(short templateId, EMapBlockType[] includeTypes, EMapBlockSubType[] includeSubTypes, EMapBlockType[] excludeTypes, EMapBlockSubType[] excludeSubTypes, bool excludeBlocksWithIntelligentCharacters, bool excludeBlocksWithAdventure, bool excludeBlocksWithEffect)
	{
		TemplateId = templateId;
		IncludeTypes = includeTypes;
		IncludeSubTypes = includeSubTypes;
		ExcludeTypes = excludeTypes;
		ExcludeSubTypes = excludeSubTypes;
		ExcludeBlocksWithIntelligentCharacters = excludeBlocksWithIntelligentCharacters;
		ExcludeBlocksWithAdventure = excludeBlocksWithAdventure;
		ExcludeBlocksWithEffect = excludeBlocksWithEffect;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapBlockMatcherItem()
	{
		TemplateId = 0;
		IncludeTypes = null;
		IncludeSubTypes = null;
		ExcludeTypes = null;
		ExcludeSubTypes = null;
		ExcludeBlocksWithIntelligentCharacters = false;
		ExcludeBlocksWithAdventure = false;
		ExcludeBlocksWithEffect = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapBlockMatcherItem(short templateId, MapBlockMatcherItem other)
	{
		TemplateId = templateId;
		IncludeTypes = other.IncludeTypes;
		IncludeSubTypes = other.IncludeSubTypes;
		ExcludeTypes = other.ExcludeTypes;
		ExcludeSubTypes = other.ExcludeSubTypes;
		ExcludeBlocksWithIntelligentCharacters = other.ExcludeBlocksWithIntelligentCharacters;
		ExcludeBlocksWithAdventure = other.ExcludeBlocksWithAdventure;
		ExcludeBlocksWithEffect = other.ExcludeBlocksWithEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapBlockMatcherItem Duplicate(int templateId)
	{
		return new MapBlockMatcherItem((short)templateId, this);
	}
}
