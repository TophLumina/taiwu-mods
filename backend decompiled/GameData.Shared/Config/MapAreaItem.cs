using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Utilities;

namespace Config;

[Serializable]
public class MapAreaItem : ConfigItem<MapAreaItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 所属州ID
	/// - 该区域可能出现在的州域id，对应配置表MapState的模板id
	/// </summary>
	public readonly sbyte StateID;

	/// <summary>
	/// 区域名key
	/// - 区域名key
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 区域描述文本key
	/// - 区域描述文本key
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 大小
	/// - 决定了地图生成时初始的地图尺寸会有多大，这个并不是地图最终看到的大小，经过不规则外形变化后，这个地图可见尺寸大小会缩小
	/// </summary>
	public readonly byte Size;

	/// <summary>
	/// 在世界地图上的坐标
	/// </summary>
	public readonly sbyte[] WorldMapPos;

	/// <summary>
	/// 相邻区域列表
	/// - 配置格式{{区域ID，旅行消耗，{旅行路线，世界坐标列表...}}...}。为避免重复配置，仅配置ID大于本区域的相邻区域
	/// </summary>
	public readonly AreaTravelRoute[] NeighborAreas;

	/// <summary>
	/// 大地图图标
	/// - {已开通驿站,鼠标悬停,可开通驿站,不可开通驿站}
	/// </summary>
	public readonly string BigMapIcon;

	/// <summary>
	/// 小地图图标列表
	/// </summary>
	public readonly string[] MiniMapIcons;

	/// <summary>
	/// 特殊地块图集
	/// </summary>
	public readonly string BlockAtlas;

	/// <summary>
	/// 小地图上的位置
	/// </summary>
	public readonly short[] MiniMapPos;

	/// <summary>
	/// 恩义
	/// - 地区恩义
	/// </summary>
	public readonly byte Fame;

	/// <summary>
	/// 巢穴修正
	/// - 地区巢穴修正
	/// </summary>
	public readonly byte EnemyAdjust;

	/// <summary>
	/// 巢穴升阶次数上限
	/// - 地区巢穴最多成功升级的次数上限。
	/// </summary>
	public readonly byte MaxNestUpgradeAmount;

	/// <summary>
	/// 巢穴生成
	/// - {{{EnemyNest引用, 间隔}}}
	/// </summary>
	public readonly List<EnemyNestCreationInfo[]> EnemyNests;

	/// <summary>
	/// 初始生成时间
	/// - 在游戏开始时，为每个地区单独随机各组巢穴的生成等待计时参数，从玩家游戏进度达到“世界过月开始迭代”开始计算，以此参数做为相应巢穴第一次生成的等待计时，参数分两个值{生成月份的下限，生成月份的上限}
	/// </summary>
	public readonly List<IntPair> EnemyNestCreationDateRanges;

	/// <summary>
	/// 定居点地块列表
	/// - 按照聚居程度依次从高到低排列，包括该区域会出现的全部聚居地列表，填入的id是MapBlock表中的模板id
	/// - 定居点中的所有地形，在区域地形随机过程中都会出现且只出现一次。每个元素出现后，都需要执行属地必要地形随机。第一个参数必须是该地区的主要地块类型
	/// </summary>
	public readonly short[] SettlementBlockCore;

	/// <summary>
	/// 团体ID列表
	/// - 填入的id对应Organization的模板id
	/// </summary>
	public readonly sbyte[] OrganizationId;

	/// <summary>
	/// 居中地块
	/// - 在定居点中的某个地块，强制要求居中，填入的是在SettlementBlockCore中出现过的id
	/// </summary>
	public readonly short CenterBlock;

	/// <summary>
	/// 驿站坐标
	/// - 在定居点SettlementBlockCore中索引位置定居点的属地生成本区域驿站地块
	/// - 若太吾村位于本区域，则无视此配置
	/// </summary>
	public readonly sbyte StationLocate;

	/// <summary>
	/// 自定义地块配置名
	/// - 对应线上文档CustomMapArea中的sheet名，配置此列后将使用相应sheet中的数据生成地块
	/// </summary>
	public readonly string CustomBlockConfig;

	/// <summary>
	/// 区域方位
	/// - 地区属于哪个方位
	/// </summary>
	public readonly EMapAreaAreaDirection AreaDirection;

	/// <summary>
	/// 开化地形库
	/// - 本区域定居点属地内的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。
	/// - 
	/// - {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}
	/// </summary>
	public readonly List<short[]> DevelopedBlockCore;

	/// <summary>
	/// 普通地形库
	/// - 本区域定居点属地外一定范围内的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。
	/// - 
	/// - {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}
	/// </summary>
	public readonly List<short[]> NormalBlockCore;

	/// <summary>
	/// 野外地形库
	/// - 本区域除开化和普通以外地块的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。
	/// - 
	/// - {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}
	/// </summary>
	public readonly List<short[]> WildBlockCore;

	/// <summary>
	/// 多格常见地形库
	/// - 本区域常见的多格地形集合，填入的id是表MapBlock的模板id，只能填占多格的地形。
	/// - 需要指定每种地形的随机个数上限。
	/// - 
	/// - {{地形id1,个数上限1},{地形id2,个数上限2}····{地形idn,个数上限n}}
	/// </summary>
	public readonly List<short[]> BigBaseBlockCore;

	/// <summary>
	/// 连续地形库
	/// - 需要特别处理为多块地块连续生成的地形（在地形概率库中必须包含连续地形库的全部地形），填入的地块细类id是表MapBlock中t_SubType中的id。
	/// - 哪些地形会被拉平，以什么方式拉平会在代码里处理，不配置
	/// - {{地块细类id,在该区域的成组数量，最小连续地块数,最大连续地块数},{地块细类id,在该区域的成组数量，最小连续地块数,最大连续地块数}}
	/// - 在连续地块数范围内随机一个值，然后覆盖替换周围地块，不能覆盖聚居地和名胜库本身
	/// </summary>
	public readonly List<short[]> SeriesBlockCore;

	/// <summary>
	/// 使用指定地形形成包围圈
	/// - 生成地形的最终修正算法，该地区出现被一种地形把一片区域包围形成单一出入口区域。把指定地形扩展为一条包围一片区域的路径（路径不能包含阻挡地形，聚居地块，名胜地块），把该路径随机一点移除,路径上剩余的点替换为该地形，填入的地块细类id是表MapBlock中t_SubType中的id。
	/// - 
	/// - 格式：
	/// - {{包围地块细类id，指定必须包围的地块id(-1表示不指定，则全地图随机一块)，出口数量，距离包围地块距离最小值,距离包围地块距离最大值}}
	/// - 
	/// - 注意：处于数组后面的元素会覆盖前面元素的生成结果，所以建议把阻挡类型地块的包围圈配置放在最后一个位置
	/// </summary>
	public readonly List<short[]> EncircleBlockCore;

	/// <summary>
	/// 名胜库
	/// - 风景名胜库（如果放置了多个名胜，所有景点都会生成到该区域，位置随机），填入的id是MapBlock表中的模板id
	/// - 名胜库除不会替换定居点列表元素本身外，包括静态库属地在内的全部地块都会作为名胜库的可用地块
	/// </summary>
	public readonly short[] SceneryBlockCore;

	/// <summary>
	/// 寺庙名称
	/// - 有寺庙的城市的寺庙名称
	/// </summary>
	public readonly string TempleName;

	/// <summary>
	/// 寺庙说明
	/// - 有寺庙的城市的寺庙说明
	/// </summary>
	public readonly string TempleDesc;

	/// <summary>
	/// 洞天名称
	/// - 有洞天的城市的洞天名称
	/// </summary>
	public readonly string[] CaveName;

	/// <summary>
	/// 洞天名称
	/// - 洞天说明
	/// </summary>
	public readonly string[] CaveDesc;

	/// <summary>
	/// 喜好物品子类型
	/// </summary>
	public readonly List<short> LovingItemSubTypes;

	/// <summary>
	/// 厌恶物品子类型
	/// </summary>
	public readonly List<short> HatingItemSubTypes;

	/// <summary>
	/// 是否应当显示玄灰状态
	/// </summary>
	public readonly bool ShowDarkAshStatus;

	/// <summary>
	/// 图像位置
	/// </summary>
	public readonly float[] ImagePos;

	/// <summary>
	/// 世界地图位置
	/// </summary>
	public readonly float[] RoadPos;

	/// <summary>
	/// 辅助列 - 地区子类型
	/// - 0=城镇，1=门派，2=普通城市，3=山脉，4=水系
	/// </summary>
	public readonly sbyte AreaType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="stateID">所属州ID - 该区域可能出现在的州域id，对应配置表MapState的模板id</param>
	/// <param name="name">区域名key - 区域名key</param>
	/// <param name="desc">区域描述文本key - 区域描述文本key</param>
	/// <param name="size">大小 - 决定了地图生成时初始的地图尺寸会有多大，这个并不是地图最终看到的大小，经过不规则外形变化后，这个地图可见尺寸大小会缩小</param>
	/// <param name="worldMapPos">在世界地图上的坐标</param>
	/// <param name="neighborAreas">相邻区域列表 - 配置格式{{区域ID，旅行消耗，{旅行路线，世界坐标列表...}}...}。为避免重复配置，仅配置ID大于本区域的相邻区域</param>
	/// <param name="bigMapIcon">大地图图标 - {已开通驿站,鼠标悬停,可开通驿站,不可开通驿站}</param>
	/// <param name="miniMapIcons">小地图图标列表</param>
	/// <param name="blockAtlas">特殊地块图集</param>
	/// <param name="miniMapPos">小地图上的位置</param>
	/// <param name="fame">恩义 - 地区恩义</param>
	/// <param name="enemyAdjust">巢穴修正 - 地区巢穴修正</param>
	/// <param name="maxNestUpgradeAmount">巢穴升阶次数上限 - 地区巢穴最多成功升级的次数上限。</param>
	/// <param name="enemyNests">巢穴生成 - {{{EnemyNest引用, 间隔}}}</param>
	/// <param name="enemyNestCreationDateRanges">初始生成时间 - 在游戏开始时，为每个地区单独随机各组巢穴的生成等待计时参数，从玩家游戏进度达到“世界过月开始迭代”开始计算，以此参数做为相应巢穴第一次生成的等待计时，参数分两个值{生成月份的下限，生成月份的上限}</param>
	/// <param name="settlementBlockCore">定居点地块列表 - 按照聚居程度依次从高到低排列，包括该区域会出现的全部聚居地列表，填入的id是MapBlock表中的模板id 定居点中的所有地形，在区域地形随机过程中都会出现且只出现一次。每个元素出现后，都需要执行属地必要地形随机。第一个参数必须是该地区的主要地块类型</param>
	/// <param name="organizationId">团体ID列表 - 填入的id对应Organization的模板id</param>
	/// <param name="centerBlock">居中地块 - 在定居点中的某个地块，强制要求居中，填入的是在SettlementBlockCore中出现过的id</param>
	/// <param name="stationLocate">驿站坐标 - 在定居点SettlementBlockCore中索引位置定居点的属地生成本区域驿站地块 若太吾村位于本区域，则无视此配置</param>
	/// <param name="customBlockConfig">自定义地块配置名 - 对应线上文档CustomMapArea中的sheet名，配置此列后将使用相应sheet中的数据生成地块</param>
	/// <param name="areaDirection">区域方位 - 地区属于哪个方位</param>
	/// <param name="developedBlockCore">开化地形库 - 本区域定居点属地内的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。  {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}</param>
	/// <param name="normalBlockCore">普通地形库 - 本区域定居点属地外一定范围内的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。  {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}</param>
	/// <param name="wildBlockCore">野外地形库 - 本区域除开化和普通以外地块的地形随机池，填入的id是表MapBlock的模板id，只能填占1格的地形。需要指定每种地形的出现几率。  {{地形id1,出现权重1},{地形id2,出现权重2}····{地形idn,出现权重n}}</param>
	/// <param name="bigBaseBlockCore">多格常见地形库 - 本区域常见的多格地形集合，填入的id是表MapBlock的模板id，只能填占多格的地形。 需要指定每种地形的随机个数上限。  {{地形id1,个数上限1},{地形id2,个数上限2}····{地形idn,个数上限n}}</param>
	/// <param name="seriesBlockCore">连续地形库 - 需要特别处理为多块地块连续生成的地形（在地形概率库中必须包含连续地形库的全部地形），填入的地块细类id是表MapBlock中t_SubType中的id。 哪些地形会被拉平，以什么方式拉平会在代码里处理，不配置 {{地块细类id,在该区域的成组数量，最小连续地块数,最大连续地块数},{地块细类id,在该区域的成组数量，最小连续地块数,最大连续地块数}} 在连续地块数范围内随机一个值，然后覆盖替换周围地块，不能覆盖聚居地和名胜库本身</param>
	/// <param name="encircleBlockCore">使用指定地形形成包围圈 - 生成地形的最终修正算法，该地区出现被一种地形把一片区域包围形成单一出入口区域。把指定地形扩展为一条包围一片区域的路径（路径不能包含阻挡地形，聚居地块，名胜地块），把该路径随机一点移除,路径上剩余的点替换为该地形，填入的地块细类id是表MapBlock中t_SubType中的id。  格式： {{包围地块细类id，指定必须包围的地块id(-1表示不指定，则全地图随机一块)，出口数量，距离包围地块距离最小值,距离包围地块距离最大值}}  注意：处于数组后面的元素会覆盖前面元素的生成结果，所以建议把阻挡类型地块的包围圈配置放在最后一个位置</param>
	/// <param name="sceneryBlockCore">名胜库 - 风景名胜库（如果放置了多个名胜，所有景点都会生成到该区域，位置随机），填入的id是MapBlock表中的模板id 名胜库除不会替换定居点列表元素本身外，包括静态库属地在内的全部地块都会作为名胜库的可用地块</param>
	/// <param name="templeName">寺庙名称 - 有寺庙的城市的寺庙名称</param>
	/// <param name="templeDesc">寺庙说明 - 有寺庙的城市的寺庙说明</param>
	/// <param name="caveName">洞天名称 - 有洞天的城市的洞天名称</param>
	/// <param name="caveDesc">洞天名称 - 洞天说明</param>
	/// <param name="lovingItemSubTypes">喜好物品子类型</param>
	/// <param name="hatingItemSubTypes">厌恶物品子类型</param>
	/// <param name="showDarkAshStatus">是否应当显示玄灰状态</param>
	/// <param name="imagePos">图像位置</param>
	/// <param name="roadPos">世界地图位置</param>
	/// <param name="areaType">辅助列 - 地区子类型 - 0=城镇，1=门派，2=普通城市，3=山脉，4=水系</param>
	public MapAreaItem(short templateId, sbyte stateID, string name, string desc, byte size, sbyte[] worldMapPos, AreaTravelRoute[] neighborAreas, string bigMapIcon, string[] miniMapIcons, string blockAtlas, short[] miniMapPos, byte fame, byte enemyAdjust, byte maxNestUpgradeAmount, List<EnemyNestCreationInfo[]> enemyNests, List<IntPair> enemyNestCreationDateRanges, short[] settlementBlockCore, sbyte[] organizationId, short centerBlock, sbyte stationLocate, string customBlockConfig, EMapAreaAreaDirection areaDirection, List<short[]> developedBlockCore, List<short[]> normalBlockCore, List<short[]> wildBlockCore, List<short[]> bigBaseBlockCore, List<short[]> seriesBlockCore, List<short[]> encircleBlockCore, short[] sceneryBlockCore, string templeName, string templeDesc, string[] caveName, string[] caveDesc, List<short> lovingItemSubTypes, List<short> hatingItemSubTypes, bool showDarkAshStatus, float[] imagePos, float[] roadPos, sbyte areaType)
	{
		TemplateId = templateId;
		StateID = stateID;
		Name = name;
		Desc = desc;
		Size = size;
		WorldMapPos = worldMapPos;
		NeighborAreas = neighborAreas;
		BigMapIcon = bigMapIcon;
		MiniMapIcons = miniMapIcons;
		BlockAtlas = blockAtlas;
		MiniMapPos = miniMapPos;
		Fame = fame;
		EnemyAdjust = enemyAdjust;
		MaxNestUpgradeAmount = maxNestUpgradeAmount;
		EnemyNests = enemyNests;
		EnemyNestCreationDateRanges = enemyNestCreationDateRanges;
		SettlementBlockCore = settlementBlockCore;
		OrganizationId = organizationId;
		CenterBlock = centerBlock;
		StationLocate = stationLocate;
		CustomBlockConfig = customBlockConfig;
		AreaDirection = areaDirection;
		DevelopedBlockCore = developedBlockCore;
		NormalBlockCore = normalBlockCore;
		WildBlockCore = wildBlockCore;
		BigBaseBlockCore = bigBaseBlockCore;
		SeriesBlockCore = seriesBlockCore;
		EncircleBlockCore = encircleBlockCore;
		SceneryBlockCore = sceneryBlockCore;
		TempleName = templeName;
		TempleDesc = templeDesc;
		CaveName = caveName;
		CaveDesc = caveDesc;
		LovingItemSubTypes = lovingItemSubTypes;
		HatingItemSubTypes = hatingItemSubTypes;
		ShowDarkAshStatus = showDarkAshStatus;
		ImagePos = imagePos;
		RoadPos = roadPos;
		AreaType = areaType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapAreaItem()
	{
		TemplateId = 0;
		StateID = 0;
		Name = null;
		Desc = null;
		Size = 0;
		WorldMapPos = new sbyte[2] { -1, -1 };
		NeighborAreas = new AreaTravelRoute[0];
		BigMapIcon = null;
		MiniMapIcons = new string[4] { "", "", "", "" };
		BlockAtlas = null;
		MiniMapPos = new short[2] { -1, -1 };
		Fame = 0;
		EnemyAdjust = 0;
		MaxNestUpgradeAmount = 5;
		EnemyNests = new List<EnemyNestCreationInfo[]>();
		EnemyNestCreationDateRanges = new List<IntPair>();
		SettlementBlockCore = new short[0];
		OrganizationId = new sbyte[0];
		CenterBlock = 0;
		StationLocate = -1;
		CustomBlockConfig = null;
		AreaDirection = EMapAreaAreaDirection.South;
		DevelopedBlockCore = new List<short[]>
		{
			new short[2] { 39, 33 },
			new short[2] { 40, 33 },
			new short[2] { 41, 33 },
			new short[2] { 42, 33 },
			new short[2] { 43, 33 },
			new short[2] { 44, 33 },
			new short[2] { 45, 33 },
			new short[2] { 46, 33 },
			new short[2] { 47, 33 },
			new short[2] { 48, 33 },
			new short[2] { 49, 33 },
			new short[2] { 50, 33 },
			new short[2] { 51, 33 },
			new short[2] { 52, 33 },
			new short[2] { 53, 33 },
			new short[2] { 54, 33 },
			new short[2] { 55, 33 },
			new short[2] { 56, 33 },
			new short[2] { 109, 10 },
			new short[2] { 110, 10 },
			new short[2] { 111, 10 }
		};
		NormalBlockCore = new List<short[]>
		{
			new short[2] { 57, 33 },
			new short[2] { 58, 33 },
			new short[2] { 59, 33 },
			new short[2] { 63, 33 },
			new short[2] { 64, 33 },
			new short[2] { 65, 33 },
			new short[2] { 69, 33 },
			new short[2] { 70, 33 },
			new short[2] { 71, 33 },
			new short[2] { 75, 33 },
			new short[2] { 76, 33 },
			new short[2] { 77, 33 },
			new short[2] { 81, 33 },
			new short[2] { 82, 33 },
			new short[2] { 83, 33 },
			new short[2] { 87, 33 },
			new short[2] { 88, 33 },
			new short[2] { 89, 33 },
			new short[2] { 112, 30 },
			new short[2] { 113, 30 },
			new short[2] { 114, 30 },
			new short[2] { 124, 30 }
		};
		WildBlockCore = new List<short[]>
		{
			new short[2] { 93, 33 },
			new short[2] { 94, 33 },
			new short[2] { 95, 33 },
			new short[2] { 96, 33 },
			new short[2] { 97, 33 },
			new short[2] { 98, 33 },
			new short[2] { 99, 33 },
			new short[2] { 100, 33 },
			new short[2] { 101, 33 },
			new short[2] { 102, 33 },
			new short[2] { 103, 33 },
			new short[2] { 104, 33 },
			new short[2] { 105, 33 },
			new short[2] { 106, 33 },
			new short[2] { 107, 33 },
			new short[2] { 108, 33 },
			new short[2] { 115, 40 },
			new short[2] { 116, 40 },
			new short[2] { 117, 40 },
			new short[2] { 124, 30 }
		};
		BigBaseBlockCore = new List<short[]>
		{
			new short[2] { 60, 1 },
			new short[2] { 78, 1 },
			new short[2] { 61, 1 },
			new short[2] { 79, 1 },
			new short[2] { 62, 1 },
			new short[2] { 80, 1 }
		};
		SeriesBlockCore = new List<short[]>();
		EncircleBlockCore = new List<short[]>();
		SceneryBlockCore = new short[0];
		TempleName = null;
		TempleDesc = null;
		CaveName = null;
		CaveDesc = null;
		LovingItemSubTypes = new List<short>();
		HatingItemSubTypes = new List<short>();
		ShowDarkAshStatus = true;
		ImagePos = new float[2];
		RoadPos = new float[2];
		AreaType = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapAreaItem(short templateId, MapAreaItem other)
	{
		TemplateId = templateId;
		StateID = other.StateID;
		Name = other.Name;
		Desc = other.Desc;
		Size = other.Size;
		WorldMapPos = other.WorldMapPos;
		NeighborAreas = other.NeighborAreas;
		BigMapIcon = other.BigMapIcon;
		MiniMapIcons = other.MiniMapIcons;
		BlockAtlas = other.BlockAtlas;
		MiniMapPos = other.MiniMapPos;
		Fame = other.Fame;
		EnemyAdjust = other.EnemyAdjust;
		MaxNestUpgradeAmount = other.MaxNestUpgradeAmount;
		EnemyNests = other.EnemyNests;
		EnemyNestCreationDateRanges = other.EnemyNestCreationDateRanges;
		SettlementBlockCore = other.SettlementBlockCore;
		OrganizationId = other.OrganizationId;
		CenterBlock = other.CenterBlock;
		StationLocate = other.StationLocate;
		CustomBlockConfig = other.CustomBlockConfig;
		AreaDirection = other.AreaDirection;
		DevelopedBlockCore = other.DevelopedBlockCore;
		NormalBlockCore = other.NormalBlockCore;
		WildBlockCore = other.WildBlockCore;
		BigBaseBlockCore = other.BigBaseBlockCore;
		SeriesBlockCore = other.SeriesBlockCore;
		EncircleBlockCore = other.EncircleBlockCore;
		SceneryBlockCore = other.SceneryBlockCore;
		TempleName = other.TempleName;
		TempleDesc = other.TempleDesc;
		CaveName = other.CaveName;
		CaveDesc = other.CaveDesc;
		LovingItemSubTypes = other.LovingItemSubTypes;
		HatingItemSubTypes = other.HatingItemSubTypes;
		ShowDarkAshStatus = other.ShowDarkAshStatus;
		ImagePos = other.ImagePos;
		RoadPos = other.RoadPos;
		AreaType = other.AreaType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapAreaItem Duplicate(int templateId)
	{
		return new MapAreaItem((short)templateId, this);
	}
}
