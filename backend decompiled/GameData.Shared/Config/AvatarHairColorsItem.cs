using System;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHairColorsItem : ConfigItem<AvatarHairColorsItem, byte>
{
	/// <summary>
	/// 颜色id
	/// - 每个id对应一个颜色
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 颜色十六进制值
	/// </summary>
	public readonly string ColorHex;

	/// <summary>
	/// 出现几率（中文）
	/// </summary>
	public readonly byte ObbCn;

	/// <summary>
	/// 出现几率（繁体中文）
	/// </summary>
	public readonly byte ObbChn;

	/// <summary>
	/// 出现几率（日文）
	/// </summary>
	public readonly byte ObbJp;

	/// <summary>
	/// 出现几率（英文）
	/// </summary>
	public readonly byte ObbEn;

	/// <summary>
	/// 事件描述文本
	/// </summary>
	public readonly string DisplayDesc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">颜色id - 每个id对应一个颜色</param>
	/// <param name="colorHex">颜色十六进制值</param>
	/// <param name="obbCn">出现几率（中文）</param>
	/// <param name="obbChn">出现几率（繁体中文）</param>
	/// <param name="obbJp">出现几率（日文）</param>
	/// <param name="obbEn">出现几率（英文）</param>
	/// <param name="displayDesc">事件描述文本</param>
	public AvatarHairColorsItem(byte templateId, string colorHex, byte obbCn, byte obbChn, byte obbJp, byte obbEn, string displayDesc)
	{
		TemplateId = templateId;
		ColorHex = colorHex;
		ObbCn = obbCn;
		ObbChn = obbChn;
		ObbJp = obbJp;
		ObbEn = obbEn;
		DisplayDesc = displayDesc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AvatarHairColorsItem()
	{
		TemplateId = 0;
		ColorHex = null;
		ObbCn = 0;
		ObbChn = 0;
		ObbJp = 0;
		ObbEn = 0;
		DisplayDesc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AvatarHairColorsItem(byte templateId, AvatarHairColorsItem other)
	{
		TemplateId = templateId;
		ColorHex = other.ColorHex;
		ObbCn = other.ObbCn;
		ObbChn = other.ObbChn;
		ObbJp = other.ObbJp;
		ObbEn = other.ObbEn;
		DisplayDesc = other.DisplayDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AvatarHairColorsItem Duplicate(int templateId)
	{
		return new AvatarHairColorsItem((byte)templateId, this);
	}
}
