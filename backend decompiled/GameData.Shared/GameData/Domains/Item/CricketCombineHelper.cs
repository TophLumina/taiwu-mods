using System;
using Config;
using GameData.Domains.Item.Display;

namespace GameData.Domains.Item;

public static class CricketCombineHelper
{
	public static bool IsCombineCricket(this (short colorId, short partId) tuple)
	{
		return tuple.partId > 0;
	}

	public static int CalcCricketCatchLucky(this (short colorId, short partId) tuple)
	{
		short value = CricketParts.Instance[tuple.colorId].CatchInfluence;
		if (tuple.IsCombineCricket())
		{
			value += CricketParts.Instance[tuple.partId].CatchInfluence;
		}
		return value;
	}

	public static sbyte CalcCricketGrade(this (short colorId, short partId) tuple)
	{
		sbyte level = CricketParts.Instance[tuple.colorId].Level;
		if (tuple.IsCombineCricket())
		{
			level = Math.Max(level, CricketParts.Instance[tuple.partId].Level);
		}
		return level;
	}

	public static string CalcCricketName(this (short colorId, short partId) tuple)
	{
		CricketPartsItem colorConfig = CricketParts.Instance[tuple.colorId];
		if (!tuple.IsCombineCricket())
		{
			return colorConfig.Name;
		}
		CricketPartsItem partConfig = CricketParts.Instance[tuple.partId];
		if (colorConfig.NameOrder < partConfig.NameOrder)
		{
			return LocalStringManager.GetFormat(LanguageKey.LK_Cricket_CombineName, partConfig.Name, colorConfig.NameAtSecond);
		}
		return LocalStringManager.GetFormat(LanguageKey.LK_Cricket_CombineName, colorConfig.Name, partConfig.NameAtSecond);
	}

	public static string CalcCricketName(this ITradeableContent data)
	{
		int nameId = data.CricketData?.NameId ?? (-1);
		return CalcCricketName(data.CricketColorId, data.CricketPartId, nameId);
	}

	public static string CalcCricketName(short colorId, short partId, int nameId)
	{
		string customName = ItemTemplateHelper.GetName(nameId);
		if (!string.IsNullOrEmpty(customName))
		{
			return customName;
		}
		return (colorId: colorId, partId: partId).CalcCricketName();
	}
}
