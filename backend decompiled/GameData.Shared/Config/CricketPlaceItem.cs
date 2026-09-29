using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPlaceItem : ConfigItem<CricketPlaceItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte Cyan;

	public readonly sbyte Yellow;

	public readonly sbyte Purple;

	public readonly sbyte Red;

	public readonly sbyte Black;

	public readonly sbyte White;

	public readonly sbyte Trash;

	public readonly sbyte PlaceRate;

	public readonly string[][] Icon;

	public readonly string CatchAniBack;

	public readonly string CatchAni;

	public readonly short[] UselessItemList;

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

	public override CricketPlaceItem Duplicate(int templateId)
	{
		return new CricketPlaceItem((sbyte)templateId, this);
	}
}
