using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPlaceItem : ConfigItem<CricketPlaceItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 青虫
	/// - 出现青色品质概率
	/// </summary>
	public readonly sbyte Cyan;

	/// <summary>
	/// 黄虫
	/// - 出现黄色品质概率
	/// </summary>
	public readonly sbyte Yellow;

	/// <summary>
	/// 紫虫
	/// - 出现紫色品质概率
	/// </summary>
	public readonly sbyte Purple;

	/// <summary>
	/// 赤虫
	/// - 出现赤色品质概率
	/// </summary>
	public readonly sbyte Red;

	/// <summary>
	/// 黑虫
	/// - 出现黑色品质概率
	/// </summary>
	public readonly sbyte Black;

	/// <summary>
	/// 白虫
	/// - 出现白色品质概率
	/// </summary>
	public readonly sbyte White;

	/// <summary>
	/// 呆物
	/// - 出现呆物概率
	/// </summary>
	public readonly sbyte Trash;

	/// <summary>
	/// 地点出现概率
	/// </summary>
	public readonly sbyte PlaceRate;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string[][] Icon;

	/// <summary>
	/// 捕捉动画底图
	/// </summary>
	public readonly string CatchAniBack;

	/// <summary>
	/// 捕捉动画
	/// </summary>
	public readonly string CatchAni;

	/// <summary>
	/// 杂虫列表
	/// - 可捕捉到的杂虫的列表，对应Misc道具表中的ID
	/// </summary>
	public readonly short[] UselessItemList;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="cyan">青虫 - 出现青色品质概率</param>
	/// <param name="yellow">黄虫 - 出现黄色品质概率</param>
	/// <param name="purple">紫虫 - 出现紫色品质概率</param>
	/// <param name="red">赤虫 - 出现赤色品质概率</param>
	/// <param name="black">黑虫 - 出现黑色品质概率</param>
	/// <param name="white">白虫 - 出现白色品质概率</param>
	/// <param name="trash">呆物 - 出现呆物概率</param>
	/// <param name="placeRate">地点出现概率</param>
	/// <param name="icon">图标</param>
	/// <param name="catchAniBack">捕捉动画底图</param>
	/// <param name="catchAni">捕捉动画</param>
	/// <param name="uselessItemList">杂虫列表 - 可捕捉到的杂虫的列表，对应Misc道具表中的ID</param>
	public CricketPlaceItem(sbyte templateId, sbyte cyan, sbyte yellow, sbyte purple, sbyte red, sbyte black, sbyte white, sbyte trash, sbyte placeRate, string[][] icon, string catchAniBack, string catchAni, short[] uselessItemList)
	{
		TemplateId = templateId;
		Cyan = cyan;
		Yellow = yellow;
		Purple = purple;
		Red = red;
		Black = black;
		White = white;
		Trash = trash;
		PlaceRate = placeRate;
		Icon = icon;
		CatchAniBack = catchAniBack;
		CatchAni = catchAni;
		UselessItemList = uselessItemList;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CricketPlaceItem()
	{
		TemplateId = 0;
		Cyan = 0;
		Yellow = 0;
		Purple = 0;
		Red = 0;
		Black = 0;
		White = 0;
		Trash = 0;
		PlaceRate = 0;
		Icon = null;
		CatchAniBack = null;
		CatchAni = null;
		UselessItemList = new short[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CricketPlaceItem(sbyte templateId, CricketPlaceItem other)
	{
		TemplateId = templateId;
		Cyan = other.Cyan;
		Yellow = other.Yellow;
		Purple = other.Purple;
		Red = other.Red;
		Black = other.Black;
		White = other.White;
		Trash = other.Trash;
		PlaceRate = other.PlaceRate;
		Icon = other.Icon;
		CatchAniBack = other.CatchAniBack;
		CatchAni = other.CatchAni;
		UselessItemList = other.UselessItemList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CricketPlaceItem Duplicate(int templateId)
	{
		return new CricketPlaceItem((sbyte)templateId, this);
	}
}
