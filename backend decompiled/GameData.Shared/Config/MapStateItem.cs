using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapStateItem : ConfigItem<MapStateItem, sbyte>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 州域名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 州域主城所在区域ID
	/// - 对应MapArea的模板id
	/// </summary>
	public readonly sbyte MainAreaID;

	/// <summary>
	/// 州域门派所在区域ID
	/// - 对应MapArea的模板id
	/// </summary>
	public readonly sbyte SectAreaID;

	/// <summary>
	/// 州域门派ID
	/// - 对应门派的团体Organization模板 ID
	/// </summary>
	public readonly sbyte SectID;

	/// <summary>
	/// 促织属性成长倾向
	/// </summary>
	public readonly short CricketAffix;

	/// <summary>
	/// 州域模板人物 ID
	/// - 州对应的主角及门派人物模板 ID. {女性, 男性}.
	/// </summary>
	public readonly short[] TemplateCharacterIds;

	/// <summary>
	/// 州域可选出生地类型
	/// - 对应Sheet-&gt;BornMapType仅为对照表，不是枚举导出Sheet
	/// - 
	/// - 0 平原
	/// - 1 山岳
	/// - 2 森林
	/// - 3 湖泽
	/// - 4 海滨
	/// - 5 雪山
	/// </summary>
	public readonly byte[] BornMapType;

	/// <summary>
	/// 邻接州域表
	/// </summary>
	public readonly sbyte[] NeighborStates;

	/// <summary>
	/// 使用车站所耗银钱
	/// - 使用该州域的车站需要消耗的银钱
	/// </summary>
	public readonly sbyte TravalMoney;

	/// <summary>
	/// 小地图图片
	/// </summary>
	public readonly string MiniMap;

	/// <summary>
	/// 跑商设定中资源购买配置
	/// - 跑商设定中资源购买配置
	/// </summary>
	public readonly short[] ResBuy;

	/// <summary>
	/// 跑商设定中资源售出配置
	/// - 跑商设定中资源售出配置
	/// </summary>
	public readonly short[] ResSell;

	/// <summary>
	/// 地图BGM
	/// - 不在任何定居点范围内时播放
	/// </summary>
	public readonly string Bgm;

	/// <summary>
	/// 门派选择音效
	/// - 创建人物界面选择门派时播放
	/// </summary>
	public readonly string BirthSound;

	/// <summary>
	/// 遮罩位置
	/// </summary>
	public readonly float[] MaskPos;

	/// <summary>
	/// 州域分隔线位置
	/// </summary>
	public readonly float[] DelimPos;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="name">州域名</param>
	/// <param name="mainAreaID">州域主城所在区域ID - 对应MapArea的模板id</param>
	/// <param name="sectAreaID">州域门派所在区域ID - 对应MapArea的模板id</param>
	/// <param name="sectID">州域门派ID - 对应门派的团体Organization模板 ID</param>
	/// <param name="cricketAffix">促织属性成长倾向</param>
	/// <param name="templateCharacterIds">州域模板人物 ID - 州对应的主角及门派人物模板 ID. {女性, 男性}.</param>
	/// <param name="bornMapType">州域可选出生地类型 - 对应Sheet-&gt;BornMapType仅为对照表，不是枚举导出Sheet  0 平原 1 山岳 2 森林 3 湖泽 4 海滨 5 雪山</param>
	/// <param name="neighborStates">邻接州域表</param>
	/// <param name="travalMoney">使用车站所耗银钱 - 使用该州域的车站需要消耗的银钱</param>
	/// <param name="miniMap">小地图图片</param>
	/// <param name="resBuy">跑商设定中资源购买配置 - 跑商设定中资源购买配置</param>
	/// <param name="resSell">跑商设定中资源售出配置 - 跑商设定中资源售出配置</param>
	/// <param name="bgm">地图BGM - 不在任何定居点范围内时播放</param>
	/// <param name="birthSound">门派选择音效 - 创建人物界面选择门派时播放</param>
	/// <param name="maskPos">遮罩位置</param>
	/// <param name="delimPos">州域分隔线位置</param>
	public MapStateItem(sbyte templateId, string name, sbyte mainAreaID, sbyte sectAreaID, sbyte sectID, short cricketAffix, short[] templateCharacterIds, byte[] bornMapType, sbyte[] neighborStates, sbyte travalMoney, string miniMap, short[] resBuy, short[] resSell, string bgm, string birthSound, float[] maskPos, float[] delimPos)
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapStateItem Duplicate(int templateId)
	{
		return new MapStateItem((sbyte)templateId, this);
	}
}
