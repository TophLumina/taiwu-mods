using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterPropertyReferencedItem : ConfigItem<CharacterPropertyReferencedItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 可引用类型
	/// - 可被其他表引用的角色属性类型
	/// </summary>
	public readonly ECharacterPropertyReferencedType Type;

	/// <summary>
	/// 显示类型
	/// - 前端显示用的角色属性类型. 参见 CharacterPropertyDisplay 表. 为 -1 表示没有对应的显示类型.
	/// </summary>
	public readonly short DisplayType;

	/// <summary>
	/// 受威力与修习度影响
	/// - 在作为功法加成时生效，只影响正值加成，负值仍保留原值
	/// </summary>
	public readonly bool BoostedByPower;

	/// <summary>
	/// 特性默认加成类型是否为加值
	/// - 影响 Config.CharacterFeatureItem.GetCharacterPropertyBonusInt 返回值的计算，不影响单独 PercentBonus 列的加成类型
	/// </summary>
	public readonly bool FeatureStandardIsAdd;

	/// <summary>
	/// 奇书加成类型是否为加值
	/// </summary>
	public readonly bool LegendaryBookIsAdd;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">可引用类型 - 可被其他表引用的角色属性类型</param>
	/// <param name="displayType">显示类型 - 前端显示用的角色属性类型. 参见 CharacterPropertyDisplay 表. 为 -1 表示没有对应的显示类型.</param>
	/// <param name="boostedByPower">受威力与修习度影响 - 在作为功法加成时生效，只影响正值加成，负值仍保留原值</param>
	/// <param name="featureStandardIsAdd">特性默认加成类型是否为加值 - 影响 Config.CharacterFeatureItem.GetCharacterPropertyBonusInt 返回值的计算，不影响单独 PercentBonus 列的加成类型</param>
	/// <param name="legendaryBookIsAdd">奇书加成类型是否为加值</param>
	public CharacterPropertyReferencedItem(short templateId, ECharacterPropertyReferencedType type, short displayType, bool boostedByPower, bool featureStandardIsAdd, bool legendaryBookIsAdd)
	{
		TemplateId = templateId;
		Type = type;
		DisplayType = displayType;
		BoostedByPower = boostedByPower;
		FeatureStandardIsAdd = featureStandardIsAdd;
		LegendaryBookIsAdd = legendaryBookIsAdd;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterPropertyReferencedItem()
	{
		TemplateId = 0;
		Type = ECharacterPropertyReferencedType.Strength;
		DisplayType = 0;
		BoostedByPower = false;
		FeatureStandardIsAdd = true;
		LegendaryBookIsAdd = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterPropertyReferencedItem(short templateId, CharacterPropertyReferencedItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		DisplayType = other.DisplayType;
		BoostedByPower = other.BoostedByPower;
		FeatureStandardIsAdd = other.FeatureStandardIsAdd;
		LegendaryBookIsAdd = other.LegendaryBookIsAdd;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterPropertyReferencedItem Duplicate(int templateId)
	{
		return new CharacterPropertyReferencedItem((short)templateId, this);
	}
}
