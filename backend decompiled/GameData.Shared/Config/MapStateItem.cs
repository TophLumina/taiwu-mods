using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapStateItem : ConfigItem<MapStateItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly short MainAreaID;

	public readonly short SectAreaID;

	public readonly sbyte SectID;

	public readonly short CricketAffix;

	public readonly short[] TemplateCharacterIds;

	public readonly byte[] BornMapType;

	public readonly sbyte[] NeighborStates;

	public readonly sbyte TravalMoney;

	public readonly string MiniMap;

	public readonly short[] ResBuy;

	public readonly short[] ResSell;

	public readonly string Bgm;

	public readonly string BirthSound;

	public readonly float[] MaskPos;

	public readonly float[] DelimPos;

	public MapStateItem(sbyte templateId, string name, short mainAreaID, short sectAreaID, sbyte sectID, short cricketAffix, short[] templateCharacterIds, byte[] bornMapType, sbyte[] neighborStates, sbyte travalMoney, string miniMap, short[] resBuy, short[] resSell, string bgm, string birthSound, float[] maskPos, float[] delimPos)
	{
		TemplateId = templateId;
		Name = name;
		MainAreaID = mainAreaID;
		SectAreaID = sectAreaID;
		SectID = sectID;
		CricketAffix = cricketAffix;
		TemplateCharacterIds = templateCharacterIds;
		BornMapType = bornMapType;
		NeighborStates = neighborStates;
		TravalMoney = travalMoney;
		MiniMap = miniMap;
		ResBuy = resBuy;
		ResSell = resSell;
		Bgm = bgm;
		BirthSound = birthSound;
		MaskPos = maskPos;
		DelimPos = delimPos;
	}

	public MapStateItem()
	{
		TemplateId = 0;
		Name = null;
		MainAreaID = 0;
		SectAreaID = 0;
		SectID = 0;
		CricketAffix = 0;
		TemplateCharacterIds = new short[2] { -1, -1 };
		BornMapType = new byte[0];
		NeighborStates = new sbyte[0];
		TravalMoney = -1;
		MiniMap = null;
		ResBuy = new short[0];
		ResSell = new short[0];
		Bgm = null;
		BirthSound = null;
		MaskPos = new float[2];
		DelimPos = new float[2];
	}

	public MapStateItem(sbyte templateId, MapStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		MainAreaID = other.MainAreaID;
		SectAreaID = other.SectAreaID;
		SectID = other.SectID;
		CricketAffix = other.CricketAffix;
		TemplateCharacterIds = other.TemplateCharacterIds;
		BornMapType = other.BornMapType;
		NeighborStates = other.NeighborStates;
		TravalMoney = other.TravalMoney;
		MiniMap = other.MiniMap;
		ResBuy = other.ResBuy;
		ResSell = other.ResSell;
		Bgm = other.Bgm;
		BirthSound = other.BirthSound;
		MaskPos = other.MaskPos;
		DelimPos = other.DelimPos;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapStateItem Duplicate(int templateId)
	{
		return new MapStateItem((sbyte)templateId, this);
	}
}
