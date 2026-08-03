using System;
using Config.Common;

namespace Config;

[Serializable]
public class MusicItem : ConfigItem<MusicItem, short>
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
	/// 地块
	/// - 太吾村、门派、主城
	/// </summary>
	public readonly short MapBlock;

	/// <summary>
	/// 州域
	/// </summary>
	public readonly sbyte MapState;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 动心
	/// - 动心守心只要收集就有加成
	/// </summary>
	public readonly short HitRateMind;

	/// <summary>
	/// 守心
	/// </summary>
	public readonly int AvoidRateMind;

	/// <summary>
	/// 临时特性加成
	/// - 七元赋性加值仅在播放对应的音乐时有加成
	/// </summary>
	public readonly short TemporaryFeature;

	/// <summary>
	/// 曲子简述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 曲子点评
	/// </summary>
	public readonly string Evaluation;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="mapBlock">地块 - 太吾村、门派、主城</param>
	/// <param name="mapState">州域</param>
	/// <param name="icon">图标</param>
	/// <param name="hitRateMind">动心 - 动心守心只要收集就有加成</param>
	/// <param name="avoidRateMind">守心</param>
	/// <param name="temporaryFeature">临时特性加成 - 七元赋性加值仅在播放对应的音乐时有加成</param>
	/// <param name="desc">曲子简述</param>
	/// <param name="evaluation">曲子点评</param>
	public MusicItem(short templateId, string name, short mapBlock, sbyte mapState, string icon, short hitRateMind, int avoidRateMind, short temporaryFeature, string desc, string evaluation)
	{
		TemplateId = templateId;
		Name = name;
		MapBlock = mapBlock;
		MapState = mapState;
		Icon = icon;
		HitRateMind = hitRateMind;
		AvoidRateMind = avoidRateMind;
		TemporaryFeature = temporaryFeature;
		Desc = desc;
		Evaluation = evaluation;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MusicItem()
	{
		TemplateId = 0;
		Name = null;
		MapBlock = 0;
		MapState = 0;
		Icon = null;
		HitRateMind = 0;
		AvoidRateMind = 0;
		TemporaryFeature = 0;
		Desc = null;
		Evaluation = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MusicItem(short templateId, MusicItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		MapBlock = other.MapBlock;
		MapState = other.MapState;
		Icon = other.Icon;
		HitRateMind = other.HitRateMind;
		AvoidRateMind = other.AvoidRateMind;
		TemporaryFeature = other.TemporaryFeature;
		Desc = other.Desc;
		Evaluation = other.Evaluation;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MusicItem Duplicate(int templateId)
	{
		return new MusicItem((short)templateId, this);
	}

	/// <summary>
	/// 获取CharacterProperty加成
	/// </summary>
	/// <param name="key"></param>
	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.HitRateMind => HitRateMind, 
			ECharacterPropertyReferencedType.AvoidRateMind => AvoidRateMind, 
			_ => 0, 
		};
	}
}
