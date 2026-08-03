using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Config;
using GameData.Combat.Math;
using GameData.Domains.CombatSkill;
using GameData.Domains.LegendaryBook;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 功法突破盘
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class SkillBreakPlate : ISerializableGameData, IEnumerable<SkillBreakPlateGrid>, IEnumerable
{
	public static class FieldIds
	{
		public const ushort Grids = 0;

		public const ushort Width = 1;

		public const ushort Height = 2;

		public const ushort InternalState = 3;

		public const ushort StepBase = 4;

		public const ushort StepExtraNormal = 5;

		public const ushort StepCostedNormal = 6;

		public const ushort StepCostedGoneMad = 7;

		public const ushort Current = 8;

		public const ushort BaseSuccessRate = 9;

		public const ushort SuccessCount = 10;

		public const ushort FailedCount = 11;

		public const ushort SelectedPages = 12;

		public const ushort SelectPath = 13;

		public const ushort Bonuses = 14;

		public const ushort GridSwaps = 15;

		public const ushort SwapCount = 16;

		public const ushort LegendaryBookState = 17;

		public const ushort Count = 18;

		public static readonly string[] FieldId2FieldName = new string[18]
		{
			"Grids", "Width", "Height", "InternalState", "StepBase", "StepExtraNormal", "StepCostedNormal", "StepCostedGoneMad", "Current", "BaseSuccessRate",
			"SuccessCount", "FailedCount", "SelectedPages", "SelectPath", "Bonuses", "GridSwaps", "SwapCount", "LegendaryBookState"
		};
	}

	/// <summary>
	/// 相邻突破格查找表
	/// </summary>
	private readonly SkillBreakPlateAxial[] _neighborAxial = new SkillBreakPlateAxial[6]
	{
		(q: -1, r: 0),
		(q: 1, r: 0),
		(q: 0, r: -1),
		(q: 0, r: 1),
		(q: -1, r: 1),
		(q: 1, r: -1)
	};

	/// <summary>
	/// 生成特殊格子的概率
	/// </summary>
	private const byte SpecialGridOdds = 37;

	/// <summary>
	/// 成功率随机范围
	/// </summary>
	private const byte SuccessRateRandomRange = 15;

	/// <summary>
	/// 默认格式化实现
	/// </summary>
	private static readonly ISkillBreakPlateFormatter DefaultFormatter = new SkillBreakPlateFormatterDefault();

	/// <summary>
	/// 索引缓存 0 号
	/// </summary>
	private static readonly List<SkillBreakPlateIndex> IndexesCache0 = new List<SkillBreakPlateIndex>();

	/// <summary>
	/// 索引缓存 1 号
	/// </summary>
	private static readonly List<SkillBreakPlateIndex> IndexesCache1 = new List<SkillBreakPlateIndex>();

	/// <summary>
	/// 索引缓存 2 号
	/// </summary>
	private static readonly List<SkillBreakPlateIndex> IndexesCache2 = new List<SkillBreakPlateIndex>();

	/// <summary>
	/// 特殊突破格生成权重
	/// </summary>
	private static List<(sbyte, short)> _specialGridTypeGenerateWeights;

	/// <summary>
	/// 特殊突破格转换权重
	/// </summary>
	private static List<(sbyte, short)> _specialGridTypeConvertWeights;

	/// <summary>
	/// 突破格数据
	/// 坐标系为：
	/// y+
	/// ^
	/// |
	/// o ——&gt; x+
	/// 自中心向外依次为 Center -&gt; (Border -&gt; Margin)[Edge]
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private SkillBreakPlateGrid[] _grids;

	/// <summary>
	/// 内部状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	private sbyte _internalState;

	/// <summary>
	/// 额外天资数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	private int _stepExtraNormal;

	/// <summary>
	/// 突破路径
	/// </summary>
	[SerializableGameDataField(FieldIndex = 13)]
	private List<SkillBreakPlateIndex> _selectPath;

	/// <summary>
	/// 加成数据
	/// </summary>
	[SerializableGameDataField(FieldIndex = 14)]
	private Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus> _bonuses;

	/// <summary>
	/// 格子交换映射：Key -&gt; Value 表示 Key 位置的格子被 Value 位置的格子替换
	/// </summary>
	[SerializableGameDataField(FieldIndex = 15)]
	private Dictionary<SkillBreakPlateIndex, SkillBreakPlateIndex> _gridSwaps;

	/// <summary>
	/// 奇书阴阳眼状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 17)]
	public ELegendaryBookSlotState LegendaryBookState;

	private GlobalConfig Global => GlobalConfig.Instance;

	/// <summary>
	/// 未走火入魔的天资数
	/// </summary>
	public int StepNormal => StepBase * (CValuePercentBonus)OutlineConfig.StepBonusNormal + _stepExtraNormal + (LegendaryBookState.ContainsYang() ? Global.LegendaryBookYangAddStepNormal : 0);

	/// <summary>
	/// 已走火入魔的天资数
	/// </summary>
	public int StepGoneMad => StepBase * (CValuePercentBonus)OutlineConfig.StepBonusGoneMad + (LegendaryBookState.ContainsYin() ? Global.LegendaryBookYinAddStepGoneMad : 0);

	/// <summary>
	/// 天资数上限
	/// </summary>
	public int StepTotal => StepNormal + StepGoneMad;

	/// <summary>
	/// 步数已耗尽
	/// </summary>
	public bool StepExhausted
	{
		get
		{
			if (StepCostedNormal >= StepNormal)
			{
				return StepCostedGoneMad >= StepGoneMad;
			}
			return false;
		}
	}

	/// <summary>
	/// 当前点是否有任意邻居
	/// </summary>
	public bool AnyNeighbors => GetNeighbors(Current).Any(MaybeSuccess);

	/// <summary>
	/// 突破盘状态
	/// </summary>
	public ESkillBreakPlateState State => (ESkillBreakPlateState)_internalState;

	/// <summary>
	/// 是否突破成功
	/// </summary>
	public bool Success => State == ESkillBreakPlateState.Success;

	/// <summary>
	/// 是否突破失败
	/// </summary>
	public bool Failed => State == ESkillBreakPlateState.Failed;

	/// <summary>
	/// 是否已结束
	/// </summary>
	public bool Finished => State != ESkillBreakPlateState.NotFinished;

	/// <summary>
	/// 增加的威力上限值
	/// </summary>
	/// <returns></returns>
	public int AddMaxPower => GetIndexes().Where(IsSelectedPoint).Sum((Func<SkillBreakPlateIndex, int>)CalcAddMaxPower);

	/// <summary>
	/// 突破路径
	/// </summary>
	public IReadOnlyList<SkillBreakPlateIndex> SelectPath => _selectPath;

	/// <summary>
	/// 总纲类型，对应立场类型 <see cref="T:GameData.Domains.Character.BehaviorType" />
	/// </summary>
	public sbyte OutlineType => CombatSkillStateHelper.GetActiveOutlinePageType(SelectedPages);

	/// <summary>
	/// 总纲加成配置
	/// </summary>
	public SkillBreakOutlineEffectItem OutlineConfig => SkillBreakOutlineEffect.Instance[OutlineType];

	/// <summary>
	/// 填充过任意玄机
	/// </summary>
	public bool AnyBonus
	{
		get
		{
			Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus> bonuses = _bonuses;
			if (bonuses != null)
			{
				return bonuses.Count > 0;
			}
			return false;
		}
	}

	/// <summary>
	/// 突破盘宽度
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public byte Width { get; private set; }

	/// <summary>
	/// 突破盘高度
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public byte Height { get; private set; }

	/// <summary>
	/// 基础天资数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public int StepBase { get; set; }

	/// <summary>
	/// 已使用天资数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public int StepCostedNormal { get; private set; }

	/// <summary>
	/// 已使用入魔数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	public int StepCostedGoneMad { get; private set; }

	/// <summary>
	/// 当前位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public SkillBreakPlateIndex Current { get; private set; }

	/// <summary>
	/// 基础成功率
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	public byte BaseSuccessRate { get; set; }

	/// <summary>
	/// 连接成功的次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 10)]
	public int SuccessCount { get; set; }

	/// <summary>
	/// 连接失败的次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 11)]
	public int FailedCount { get; set; }

	/// <summary>
	/// 选中的书页
	/// </summary>
	[SerializableGameDataField(FieldIndex = 12)]
	public ushort SelectedPages { get; private set; }

	/// <summary>
	/// 交换次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 16)]
	public int SwapCount { get; private set; }

	/// <summary>
	/// 索引某位置的突破格
	/// </summary>
	/// <param name="x">列数</param>
	/// <param name="y">行数</param>
	/// <exception cref="T:System.IndexOutOfRangeException"></exception>
	public SkillBreakPlateGrid this[int x, int y]
	{
		get
		{
			if (x < 0 || x >= Width)
			{
				throw new IndexOutOfRangeException($"x value {x} is out of range 0 ~ {Width - 1}");
			}
			if (y < 0 || y >= Height)
			{
				throw new IndexOutOfRangeException($"y value {y} is out of range 0 ~ {Height - 1}");
			}
			return _grids[x + y * Width];
		}
		private set
		{
			_grids[x + y * Width] = value;
		}
	}

	/// <summary>
	/// 索引某位置的突破格
	/// </summary>
	/// <param name="index">位置</param>
	public SkillBreakPlateGrid this[SkillBreakPlateIndex index]
	{
		get
		{
			return this[index.X, index.Y];
		}
		private set
		{
			this[index.X, index.Y] = value;
		}
	}

	/// <summary>
	/// 是否为突出行（列数为宽度）
	/// </summary>
	public static bool IsProtrusion(int y)
	{
		return y % 2 != 0;
	}

	/// <summary>
	/// 初始化特殊突破格权重
	/// </summary>
	private static void InitializedWeights()
	{
		if (_specialGridTypeGenerateWeights != null && _specialGridTypeConvertWeights != null)
		{
			return;
		}
		_specialGridTypeGenerateWeights = new List<(sbyte, short)>();
		_specialGridTypeConvertWeights = new List<(sbyte, short)>();
		foreach (SkillBreakGridTypeItem type in (IEnumerable<SkillBreakGridTypeItem>)SkillBreakGridType.Instance)
		{
			_specialGridTypeGenerateWeights.Add((type.TemplateId, type.WeightOnGenerate));
			_specialGridTypeConvertWeights.Add((type.TemplateId, type.WeightOnConvert));
		}
	}

	/// <summary>
	/// 随机一个突破格的类型（此实现假定所有未初始化的突破格数据都处于 IndexesCache，如有调整则应一并修改）
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	private static sbyte RandomGridType(IRandomSource random)
	{
		if (!random.CheckPercentProb(37))
		{
			return 3;
		}
		return RandomSpecialGridType(random);
	}

	/// <summary>
	/// 随机特殊突破格类型
	/// </summary>
	/// <param name="random"></param>
	/// <param name="byGenerate">使用生成时权重</param>
	/// <returns></returns>
	private static sbyte RandomSpecialGridType(IRandomSource random, bool byGenerate = true)
	{
		InitializedWeights();
		return RandomUtils.GetRandomResult(byGenerate ? _specialGridTypeGenerateWeights : _specialGridTypeConvertWeights, random);
	}

	/// <summary>
	/// 判定某个格子的威力
	/// </summary>
	private static short RandomGridPower(IRandomSource random, ref int power, ref int chance, int powerPerGrid)
	{
		short gridPower = 0;
		for (int i = 0; i < powerPerGrid; i++)
		{
			if (random.CheckProb(power, chance))
			{
				gridPower++;
				power--;
			}
			chance--;
		}
		return gridPower;
	}

	/// <summary>
	/// 随机一个突破格的字段
	/// </summary>
	/// <param name="random"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	private static SkillBreakPlateGrid RandomGridData(IRandomSource random, sbyte templateId)
	{
		sbyte successRateFix = (sbyte)random.Next(-15, 16);
		sbyte showRate = ((templateId > 3) ? GlobalConfig.Instance.BreakoutShowSpecialCellBaseOdds : GlobalConfig.Instance.BreakoutShowNormalCellBaseOdds);
		ESkillBreakGridState state = ((!random.CheckPercentProb(showRate)) ? ESkillBreakGridState.Invisible : ESkillBreakGridState.Showed);
		return new SkillBreakPlateGrid(templateId, successRateFix, state);
	}

	/// <summary>
	/// 基于配置构造
	/// </summary>
	public SkillBreakPlate(IRandomSource random, SkillBreakPlateItem config, ushort selectedPages, int success = 0, int failed = 0)
		: this(random, config.PlateWidth, config.PlateHeight, selectedPages, config.BonusCount, config.TotalMaxPower, success, failed)
	{
	}

	/// <summary>
	/// 脱离配置构造（用于单元测试）
	/// </summary>
	/// <param name="random"></param>
	/// <param name="width">突破盘宽度</param>
	/// <param name="height">突破盘高度</param>
	/// <param name="selectedPages">选中的书页</param>
	/// <param name="bonus">玄机格数量</param>
	/// <param name="power">可分布的威力上限</param>
	/// <param name="success">上次突破连接成功的格子数量</param>
	/// <param name="failed">上次突破连接失败的格子数量</param>
	public SkillBreakPlate(IRandomSource random, byte width, byte height, ushort selectedPages, int bonus = 0, int power = 0, int success = 0, int failed = 0)
	{
		Width = width;
		Height = height;
		SelectedPages = selectedPages;
		StepCostedNormal = (StepCostedGoneMad = 0);
		Current = SkillBreakPlateIndex.Invalid;
		SwapCount = 0;
		GenerateBreakGrids(random, bonus, power, success, failed);
		UpdateCanSelectGrids();
	}

	/// <summary>
	/// 生成突破盘
	/// </summary>
	private void GenerateBreakGrids(IRandomSource random, int bonusCount, int power, int success, int failed)
	{
		_grids = new SkillBreakPlateGrid[Width * Height];
		IndexesCache0.Clear();
		IndexesCache1.Clear();
		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				if (IsStartPoint(x, y))
				{
					this[x, y] = new SkillBreakPlateGrid(0, 100, ESkillBreakGridState.Selected);
				}
				else if (IsEndPoint(x, y))
				{
					this[x, y] = new SkillBreakPlateGrid(1, 100, ESkillBreakGridState.Showed);
				}
				else if (IsOutPoint(x, y))
				{
					this[x, y] = new SkillBreakPlateGrid(3, 0, ESkillBreakGridState.Invisible);
				}
				else if (IsMarginPoint(x, y))
				{
					this[x, y] = RandomGridData(random, 3);
				}
				else
				{
					(IsCenterArea(x, y) ? IndexesCache0 : IndexesCache1).Add((x: x, y: y));
				}
			}
		}
		GenerateBreakGridsBonus(random, bonusCount);
		GenerateBreakGridsPower(random, power);
		GenerateBreakGridsPrev(random, success, failed);
	}

	/// <summary>
	/// 生成突破盘 - 玄机格
	/// </summary>
	private void GenerateBreakGridsBonus(IRandomSource random, int bonusCount)
	{
		IndexesCache2.Clear();
		IndexesCache2.AddRange(IndexesCache0.Where(IsBonusArea));
		IndexesCache2.AddRange(IndexesCache1.Where(IsBonusArea));
		bonusCount = MathUtils.Min(bonusCount, IndexesCache2.Count);
		for (int i = 0; i < bonusCount; i++)
		{
			int posIndex = random.Next(IndexesCache2.Count);
			SkillBreakPlateIndex pos = IndexesCache2[posIndex];
			CollectionUtils.SwapAndRemove(IndexesCache2, posIndex);
			int index0 = IndexesCache0.IndexOf(pos);
			if (index0 >= 0)
			{
				CollectionUtils.SwapAndRemove(IndexesCache0, index0);
			}
			int index1 = IndexesCache1.IndexOf(pos);
			if (index1 >= 0)
			{
				CollectionUtils.SwapAndRemove(IndexesCache1, index1);
			}
			this[pos] = new SkillBreakPlateGrid(2, 100, ESkillBreakGridState.Showed);
		}
	}

	/// <summary>
	/// 生成突破盘 - 如常、特殊格、分布威力上限
	/// </summary>
	private void GenerateBreakGridsPower(IRandomSource random, int power)
	{
		CValuePercent powerCenterPercent = MathUtils.Clamp(50 + OutlineConfig.PowerAddCenterRate, 0, 100);
		int powerCenter = power * powerCenterPercent;
		int powerEdge = power - powerCenter;
		int powerPerGrid = OutlineConfig.MaxPowerPerGrid;
		int chanceCenter = IndexesCache0.Count * powerPerGrid;
		int chanceEdge = IndexesCache1.Count * powerPerGrid;
		foreach (SkillBreakPlateIndex index in IndexesCache0)
		{
			sbyte templateId = RandomGridType(random);
			this[index] = RandomGridData(random, templateId);
			this[index].AddMaxPower = RandomGridPower(random, ref powerCenter, ref chanceCenter, powerPerGrid);
		}
		foreach (SkillBreakPlateIndex index2 in IndexesCache1)
		{
			sbyte templateId2 = RandomGridType(random);
			this[index2] = RandomGridData(random, templateId2);
			this[index2].AddMaxPower = RandomGridPower(random, ref powerEdge, ref chanceEdge, powerPerGrid);
		}
	}

	/// <summary>
	/// 生成突破盘 - 完备、覆辙格替换如常格
	/// </summary>
	private void GenerateBreakGridsPrev(IRandomSource random, int lastSuccess, int lastFailed)
	{
		IndexesCache0.Clear();
		foreach (SkillBreakPlateIndex index in GetIndexes())
		{
			if (this[index].TemplateId == 3)
			{
				IndexesCache0.Add(index);
			}
		}
		for (int i = 0; i < IndexesCache0.Count; i++)
		{
			if (random.CheckProb(lastSuccess + lastFailed, IndexesCache0.Count - i))
			{
				bool success = RandomIsInner(random, lastSuccess > 0, lastFailed > 0);
				if (success)
				{
					lastSuccess--;
				}
				else
				{
					lastFailed--;
				}
				SkillBreakPlateIndex index2 = IndexesCache0[i];
				this[index2].TemplateId = (sbyte)(success ? 22 : 23);
			}
		}
	}

	/// <summary>
	/// 随机内外属性.
	/// TODO: 该方法从 CRandom 中提取. 需要将CRandom提到通用库
	/// </summary>
	/// <param name="random"></param>
	/// <param name="anyInner">是否可随机为内</param>
	/// <param name="anyOuter">是否可随机为外</param>
	/// <returns>随机为内</returns>
	public static bool RandomIsInner(IRandomSource random, bool anyInner, bool anyOuter)
	{
		if (anyOuter)
		{
			if (anyInner)
			{
				return random.CheckPercentProb(50);
			}
			return false;
		}
		return true;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return ToString(DefaultFormatter);
	}

	/// <summary>
	/// 转换为字符串矩阵
	/// </summary>
	/// <param name="formatter"></param>
	/// <returns></returns>
	public string ToString(ISkillBreakPlateFormatter formatter)
	{
		StringBuilder builder = new StringBuilder();
		builder.AppendLine($"SkillBreakPlate Outline {OutlineType} ({Width}x{Height})");
		for (int y = Height - 1; y >= 0; y--)
		{
			bool isProtrusion = IsProtrusion(y);
			int width = (int)Width - ((!isProtrusion) ? 1 : 0);
			for (int x = 0; x < width; x++)
			{
				if (!isProtrusion)
				{
					builder.Append(formatter.AlignSpace);
				}
				SkillBreakPlateGrid grid = GetGridAt(x, y);
				builder.Append(formatter.Format((x: x, y: y), grid));
				if (isProtrusion && x != width - 1)
				{
					builder.Append(formatter.AlignSpace);
				}
			}
			builder.AppendLine();
		}
		return builder.ToString();
	}

	/// <summary>
	/// 检查指定位置是否处于有效范围
	/// </summary>
	public bool CheckIndex(int x, int y)
	{
		if (x >= 0 && x < Width && y >= 0 && y < Height)
		{
			return !IsOutPoint(x, y);
		}
		return false;
	}

	/// <inheritdoc cref="M:GameData.Domains.Taiwu.SkillBreakPlate.CheckIndex(System.Int32,System.Int32)" />
	public bool CheckIndex(SkillBreakPlateIndex index)
	{
		return CheckIndex(index.X, index.Y);
	}

	/// <summary>
	/// 当前能否选中某个突破格
	/// </summary>
	public bool CanSelectBreak(SkillBreakPlateIndex index)
	{
		if (!CheckIndex(index) || GetGridAt(index).State != ESkillBreakGridState.CanSelect)
		{
			return false;
		}
		if (StepExhausted)
		{
			return CalcCostStep(index) <= 0;
		}
		return true;
	}

	/// <summary>
	/// 获取某位置的突破格（考虑交换）
	/// </summary>
	/// <param name="x">列数</param>
	/// <param name="y">行数</param>
	/// <returns></returns>
	public SkillBreakPlateGrid GetGridAt(int x, int y)
	{
		SkillBreakPlateIndex index = (x: x, y: y);
		return GetGridAt(index);
	}

	/// <summary>
	/// 获取某位置的突破格（考虑交换）
	/// </summary>
	/// <param name="index">位置</param>
	/// <returns></returns>
	public SkillBreakPlateGrid GetGridAt(SkillBreakPlateIndex index)
	{
		if (_gridSwaps != null && _gridSwaps.TryGetValue(index, out var swappedIndex))
		{
			return this[swappedIndex];
		}
		return this[index];
	}

	/// <summary>
	/// 获取物理存储位置（考虑交换）
	/// </summary>
	/// <param name="logicalIndex">逻辑位置</param>
	/// <returns>物理位置</returns>
	private SkillBreakPlateIndex GetPhysicalIndex(SkillBreakPlateIndex logicalIndex)
	{
		if (_gridSwaps == null || !_gridSwaps.TryGetValue(logicalIndex, out var swappedIndex))
		{
			return logicalIndex;
		}
		return swappedIndex;
	}

	/// <summary>
	/// 获取某位置玄机格的填充数据
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public SkillBreakPlateBonus GetBonus(SkillBreakPlateIndex index)
	{
		return _bonuses?.GetOrDefault(index, SkillBreakPlateBonus.Invalid) ?? SkillBreakPlateBonus.Invalid;
	}

	/// <summary>
	/// 获取所有玄机格加成效果
	/// </summary>
	public IEnumerable<SkillBreakPlateBonus> GetBonuses()
	{
		if (!Success)
		{
			return Enumerable.Empty<SkillBreakPlateBonus>();
		}
		return GetBonusesWithoutCheck();
	}

	/// <summary>
	/// 获取所有玄机格加成效果，无论是否已完成突破
	/// </summary>
	public IEnumerable<SkillBreakPlateBonus> GetBonusesWithoutCheck()
	{
		IEnumerable<SkillBreakPlateBonus> enumerable = _bonuses?.Values;
		return enumerable ?? Enumerable.Empty<SkillBreakPlateBonus>();
	}

	/// <summary>
	/// 获取有效突破格索引
	/// </summary>
	/// <returns></returns>
	public IEnumerable<SkillBreakPlateIndex> GetIndexes()
	{
		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				if (CheckIndex(x, y))
				{
					yield return (x: x, y: y);
				}
			}
		}
	}

	/// <inheritdoc />
	public IEnumerator<SkillBreakPlateGrid> GetEnumerator()
	{
		for (int x = 0; x < Width; x++)
		{
			for (int y = 0; y < Height; y++)
			{
				if (CheckIndex(x, y))
				{
					yield return GetGridAt(x, y);
				}
			}
		}
	}

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	/// 计算当前突破步数下每步消耗的历练值
	/// </summary>
	/// <param name="baseCostExp">基础消耗历练值</param>
	/// <returns></returns>
	[Obsolete("Use overload instead.")]
	public int CalcCostExp(int baseCostExp)
	{
		return baseCostExp + baseCostExp * StepCostedGoneMad * 10 / 100;
	}

	/// <summary>
	/// 计算当前突破步数下连接某突破格消耗的历练值
	/// </summary>
	/// <param name="baseCostExp">基础消耗历练值</param>
	/// <param name="index">要连接的突破格位置</param>
	/// <returns></returns>
	public int CalcCostExp(int baseCostExp, SkillBreakPlateIndex index)
	{
		CValuePercentBonus bonus = 0;
		if (IsCenterArea(index.X, index.Y))
		{
			bonus += (CValuePercentBonus)OutlineConfig.AddExpCostCenter;
		}
		else
		{
			bonus += (CValuePercentBonus)OutlineConfig.AddExpCostEdge;
		}
		if (CalcStepIsInGoneMad(index))
		{
			bonus += (CValuePercentBonus)OutlineConfig.AddExpCostGoneMad;
		}
		else
		{
			bonus += (CValuePercentBonus)OutlineConfig.AddExpCostNormal;
		}
		return baseCostExp * bonus;
	}

	/// <summary>
	/// 计算连接某个格子需要消耗的天资或入魔步数
	/// </summary>
	public byte CalcCostStep(SkillBreakPlateIndex index)
	{
		return GetGridAt(index).Template.CostBreakCount;
	}

	/// <summary>
	/// 计算连接某个格子是否会作为走火入魔连接
	/// </summary>
	public bool CalcStepIsInGoneMad(SkillBreakPlateIndex index)
	{
		byte stepCost = CalcCostStep(index);
		int stepCostedGoneMad = StepCostedGoneMad + ((StepCostedNormal >= StepNormal) ? stepCost : 0);
		if (StepCostedNormal >= StepNormal)
		{
			return stepCostedGoneMad > 0;
		}
		return false;
	}

	/// <summary>
	/// 计算某个格子增加的威力上限值
	/// </summary>
	public int CalcAddMaxPower(SkillBreakPlateIndex index)
	{
		int value = CalcAddMaxPowerBase(index);
		if (GetGridAt(index).Template.IgnoreEffectAddMaxPower)
		{
			return value;
		}
		int successNeighborCount = 0;
		foreach (SkillBreakPlateIndex neighbor in GetPureNeighbors(index))
		{
			if (!(neighbor == index) && GetGridAt(neighbor).State == ESkillBreakGridState.Selected)
			{
				if (GetGridAt(neighbor).Template.ClearNeighborMaxPower && GetGridAt(index).TemplateId != 2)
				{
					return 0;
				}
				successNeighborCount++;
				value += GetGridAt(neighbor).Template.NeighborAddMaxPowerWhenActive;
			}
		}
		return value + successNeighborCount * GetGridAt(index).Template.SucceedNeighborAddMaxPower;
	}

	/// <summary>
	/// 计算某个格子作为玄机格增加的威力上限值
	/// </summary>
	public int CalcAddMaxPowerAsBonus(SkillBreakPlateIndex index, int impactRange)
	{
		int total = 0;
		int totalNormal = 0;
		int totalGoneMad = 0;
		foreach (SkillBreakPlateIndex neighborIndex in GetPureNeighbors(index, impactRange))
		{
			SkillBreakPlateGrid neighbor = GetGridAt(neighborIndex);
			int value = ((neighbor.TemplateId != 2) ? CalcAddMaxPower(neighborIndex) : 0);
			if (value == 0)
			{
				continue;
			}
			total += value;
			if (neighbor.State == ESkillBreakGridState.Selected)
			{
				if (neighbor.RecordedStepIsGoneMad)
				{
					totalGoneMad += value;
				}
				else
				{
					totalNormal += value;
				}
			}
		}
		int num = total * (CValuePercentBonus)OutlineConfig.BonusAddMaxPower + totalNormal * (CValuePercent)OutlineConfig.BonusAddMaxPowerNormal + totalGoneMad * (CValuePercent)OutlineConfig.BonusAddMaxPowerGoneMad;
		CValuePercent correctionFactor = GlobalConfig.Instance.BreakoutBonusAddPowerCorrectionFactor;
		return num * correctionFactor;
	}

	/// <summary>
	/// 计算某个格子增加的威力上限值 - 基础值
	/// </summary>
	private int CalcAddMaxPowerBase(SkillBreakPlateIndex index)
	{
		SkillBreakPlateGrid grid = GetGridAt(index);
		switch (grid.TemplateId)
		{
		case 0:
		case 1:
			return 0;
		case 2:
			return CalcAddMaxPowerAsBonus(index, GetBonus(index).ImpactRange);
		default:
			return grid.AddMaxPower;
		}
	}

	/// <summary>
	/// 计算指定突破格的成功率
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public short CalcSuccessRate(SkillBreakPlateIndex index)
	{
		SkillBreakPlateGrid grid = GetGridAt(index);
		if (grid.Template.FixedSuccessRate > 0)
		{
			return grid.Template.FixedSuccessRate;
		}
		if (grid.State == ESkillBreakGridState.Selected && grid.RecordedSuccessRate > 0)
		{
			return grid.RecordedSuccessRate;
		}
		int successRate = MathUtils.Clamp(BaseSuccessRate + grid.SuccessRateFix, 5, 100);
		successRate *= (CValuePercentBonus)grid.Template.SuccessRateBonus;
		successRate *= CalcSuccessRateBonus(index);
		if (CheckIndex(Current))
		{
			successRate += GetGridAt(Current).Template.NextSuccessRateBonus;
		}
		return (short)MathUtils.Clamp(successRate, 0, 100);
	}

	/// <summary>
	/// 计算指定突破格的成功率 - 周边格相关修正系数
	/// </summary>
	private CValuePercentBonus CalcSuccessRateBonus(SkillBreakPlateIndex index)
	{
		int bonus = 0;
		int stepMoreHalf = MathUtils.Max(StepCostedNormal - StepNormal * CValueHalf.RoundUp, 0);
		int stepLessHalf = MathUtils.Max(StepNormal * CValueHalf.RoundDown - StepCostedNormal, 0);
		int successNeighborCount = 0;
		foreach (SkillBreakPlateIndex neighborPos in GetPureNeighbors(index))
		{
			SkillBreakPlateGrid neighbor = GetGridAt(neighborPos);
			bonus += neighbor.Template.BreakCountAboveHalfBonus * stepMoreHalf;
			bonus += neighbor.Template.BreakCountBelowHalfBonus * stepLessHalf;
			if (!(neighborPos == index))
			{
				bonus += neighbor.Template.NeighborSuccessRateBonus;
				if (neighbor.State == ESkillBreakGridState.Selected)
				{
					bonus += neighbor.Template.NeighborSuccessRateBonusWhenActive;
					successNeighborCount++;
				}
			}
		}
		return bonus + GetGridAt(index).Template.SucceedNeighborSuccessRateBonus * successNeighborCount;
	}

	/// <summary>
	/// 计算两点间距离
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public int CalcDistance(SkillBreakPlateIndex a, SkillBreakPlateIndex b)
	{
		if (!CheckIndex(a) || !CheckIndex(b))
		{
			return -1;
		}
		return SkillBreakPlateAxial.Distance(a, b);
	}

	/// <summary>
	/// 获取某个点的有效邻接点
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	private IEnumerable<SkillBreakPlateIndex> GetNeighbors(SkillBreakPlateIndex pos)
	{
		if (!CheckIndex(pos))
		{
			return GetNeighborsByStart();
		}
		return GetNeighborsGeneral(pos);
	}

	/// <summary>
	/// 获取某个点的有效邻接点 - 起点
	/// </summary>
	private IEnumerable<SkillBreakPlateIndex> GetNeighborsByStart()
	{
		return (from pos in GetIndexes()
			where IsStartPoint(pos.X, pos.Y)
			select pos).SelectMany(GetNeighborsGeneral);
	}

	/// <summary>
	/// 获取某个点的有效邻接点 - 通常
	/// </summary>
	private IEnumerable<SkillBreakPlateIndex> GetNeighborsGeneral(SkillBreakPlateIndex pos)
	{
		SkillBreakPlateGrid grid = GetGridAt(pos);
		SkillBreakPlateAxial axial = pos;
		SkillBreakPlateAxial[] neighborAxial = _neighborAxial;
		foreach (SkillBreakPlateAxial offset in neighborAxial)
		{
			SkillBreakPlateIndex neighborPos = (SkillBreakPlateIndex)(axial + offset * grid.Template.NextStepOffset);
			if (CheckIndex(neighborPos) && GetGridAt(neighborPos).State.CanInteract())
			{
				yield return neighborPos;
			}
		}
		if (!grid.Template.NextStepCanJumpToSame)
		{
			yield break;
		}
		foreach (SkillBreakPlateIndex otherIndex in GetIndexes())
		{
			if (!(pos == otherIndex) && CalcDistance(pos, otherIndex) != grid.Template.NextStepOffset && GetGridAt(otherIndex).TemplateId == grid.TemplateId && GetGridAt(otherIndex).State.CanInteract())
			{
				yield return otherIndex;
			}
		}
	}

	/// <summary>
	/// 获取某个点指定距离内的其它有效点
	/// </summary>
	/// <param name="pos"></param>
	/// <param name="distance"></param>
	/// <returns></returns>
	private IEnumerable<SkillBreakPlateIndex> GetPureNeighbors(SkillBreakPlateIndex pos, int distance = 1)
	{
		foreach (SkillBreakPlateIndex index in GetIndexes())
		{
			if (CalcDistance(pos, index) <= distance)
			{
				yield return index;
			}
		}
	}

	/// <summary>
	/// 是否有可能成功
	/// </summary>
	private bool MaybeSuccess(SkillBreakPlateIndex index)
	{
		return CalcSuccessRate(index) > 0;
	}

	/// <summary>
	/// 是否已选中的点
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	private bool IsSelectedPoint(SkillBreakPlateIndex pos)
	{
		return GetGridAt(pos).State == ESkillBreakGridState.Selected;
	}

	/// <summary>
	/// 某位置是否为隐藏格
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	private bool IsOutPoint(int x, int y)
	{
		if (!IsProtrusion(y))
		{
			return x == Width - 1;
		}
		return false;
	}

	/// <summary>
	/// 某位置是否为起点
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	private bool IsStartPoint(int x, int y)
	{
		if (y != 0 && y != Height - 1)
		{
			return false;
		}
		if (x != 0 && x != Width - (IsProtrusion(y) ? 1 : 2))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 某位置是否为终点
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	private bool IsEndPoint(int x, int y)
	{
		if (x == ((int)Width - ((!IsProtrusion(y)) ? 1 : 0)) / 2)
		{
			return y == Height / 2;
		}
		return false;
	}

	/// <summary>
	/// 某位置是否为边缘
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	private bool IsMarginPoint(int x, int y)
	{
		int depressionFix = ((!IsProtrusion(y)) ? 1 : 0);
		if (x != 0 && x != Width - 1 - depressionFix && y != 0)
		{
			return y == Height - 1;
		}
		return true;
	}

	/// <summary>
	/// 某位置是否处于中心区域
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	private bool IsCenterArea(int x, int y)
	{
		int centerHeight = Height / 2 + Height % 2;
		int edgeHeight = (Height - centerHeight) / 2;
		if (y < edgeHeight || y >= Height - edgeHeight)
		{
			return false;
		}
		int centerWidth = Width / 2 + Width % 2;
		int edgeWidth = (Width - centerWidth) / 2;
		int depressionFix = ((!IsProtrusion(y)) ? 1 : 0);
		if (x >= edgeWidth)
		{
			return x < Width - edgeWidth - depressionFix;
		}
		return false;
	}

	/// <summary>
	/// 指定位置是否可生成玄机格
	/// </summary>
	private bool IsBonusArea(SkillBreakPlateIndex index)
	{
		SkillBreakPlateIndex skillBreakPlateIndex = index;
		skillBreakPlateIndex.Deconstruct(out var x, out var y);
		int x2 = x;
		int y2 = y;
		int depressionFix = ((!IsProtrusion(y2)) ? 1 : 0);
		if (x2 >= 3 && x2 < Width - 3 - depressionFix && y2 >= 3)
		{
			return y2 < Height - 3;
		}
		return false;
	}

	/// <summary>
	/// 检查两个格子是否可以交换
	/// </summary>
	/// <param name="indexA">格子A的位置</param>
	/// <param name="indexB">格子B的位置</param>
	/// <returns>是否可以交换</returns>
	public bool CanSwapGrid(SkillBreakPlateIndex indexA, SkillBreakPlateIndex indexB)
	{
		if (!CheckIndex(indexA) || !CheckIndex(indexB))
		{
			return false;
		}
		if (indexA == indexB)
		{
			return false;
		}
		SkillBreakPlateGrid gridA = GetGridAt(indexA);
		SkillBreakPlateGrid gridB = GetGridAt(indexB);
		if (!CanSwapGridCheck(indexA, gridA))
		{
			return false;
		}
		if (!CanSwapGridCheck(indexB, gridB))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 检查单个格子是否满足交换条件
	/// </summary>
	private bool CanSwapGridCheck(SkillBreakPlateIndex index, SkillBreakPlateGrid grid)
	{
		if (IsStartPoint(index.X, index.Y))
		{
			return false;
		}
		if (IsEndPoint(index.X, index.Y))
		{
			return false;
		}
		if (grid.State == ESkillBreakGridState.Selected)
		{
			return false;
		}
		if (grid.State == ESkillBreakGridState.Invisible)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 交换两个格子
	/// </summary>
	/// <param name="indexA">格子A的位置</param>
	/// <param name="indexB">格子B的位置</param>
	/// <returns>是否交换成功</returns>
	public bool SwapGrid(SkillBreakPlateIndex indexA, SkillBreakPlateIndex indexB)
	{
		if (!CanSwapGrid(indexA, indexB))
		{
			return false;
		}
		if (_gridSwaps == null)
		{
			_gridSwaps = new Dictionary<SkillBreakPlateIndex, SkillBreakPlateIndex>();
		}
		SkillBreakPlateIndex actualA = _gridSwaps.GetOrDefault(indexA, indexA);
		SkillBreakPlateIndex actualB = _gridSwaps.GetOrDefault(indexB, indexB);
		if (actualB == indexA)
		{
			_gridSwaps.Remove(indexA);
		}
		else
		{
			_gridSwaps[indexA] = actualB;
		}
		if (actualA == indexB)
		{
			_gridSwaps.Remove(indexB);
		}
		else
		{
			_gridSwaps[indexB] = actualA;
		}
		SwapCount++;
		RevealVisibilityAroundSwappedGrids(indexA, indexB);
		UpdateState();
		UpdateCanSelectGrids();
		return true;
	}

	/// <summary>
	/// 揭示交换格子周围1圈的视野
	/// </summary>
	private void RevealVisibilityAroundSwappedGrids(SkillBreakPlateIndex indexA, SkillBreakPlateIndex indexB)
	{
		foreach (SkillBreakPlateIndex neighbor in GetPureNeighbors(indexA))
		{
			if (GetGridAt(neighbor).State == ESkillBreakGridState.Invisible)
			{
				this[GetPhysicalIndex(neighbor)].State = ESkillBreakGridState.Showed;
			}
		}
		foreach (SkillBreakPlateIndex neighbor2 in GetPureNeighbors(indexB))
		{
			if (GetGridAt(neighbor2).State == ESkillBreakGridState.Invisible)
			{
				this[GetPhysicalIndex(neighbor2)].State = ESkillBreakGridState.Showed;
			}
		}
	}

	/// <summary>
	/// 清空某位置的玄机格数据
	/// </summary>
	public bool ClearBonus(SkillBreakPlateIndex index)
	{
		if (!SetBonusCheck(index) || _bonuses == null || !_bonuses.ContainsKey(index))
		{
			return false;
		}
		_bonuses.Remove(index);
		return true;
	}

	/// <summary>
	/// 设置某位置的玄机格数据
	/// </summary>
	public bool SetBonus(SkillBreakPlateIndex index, SkillBreakPlateBonus bonus)
	{
		if (!SetBonusCheck(index) || bonus.ShouldBeRemoved())
		{
			return false;
		}
		if (_bonuses == null)
		{
			_bonuses = new Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus>();
		}
		_bonuses[index] = bonus;
		foreach (SkillBreakPlateIndex neighbor in GetPureNeighbors(index, bonus.ImpactRange))
		{
			if (GetGridAt(neighbor).State == ESkillBreakGridState.Invisible)
			{
				this[GetPhysicalIndex(neighbor)].State = ESkillBreakGridState.Showed;
			}
		}
		return true;
	}

	/// <summary>
	/// 设置某位置的玄机格数据 - 校验该位置是否可设置玄机格
	/// </summary>
	private bool SetBonusCheck(SkillBreakPlateIndex index)
	{
		if (!CheckIndex(index))
		{
			return false;
		}
		if (GetGridAt(index).TemplateId == 2)
		{
			return GetGridAt(index).State == ESkillBreakGridState.Selected;
		}
		return false;
	}

	/// <summary>
	/// 重置所有关系类玄机的角色 ID，仅限梦回时调用
	/// </summary>
	public void ResetRelationBonuses()
	{
		if (_bonuses == null)
		{
			return;
		}
		IndexesCache0.Clear();
		IndexesCache0.AddRange(_bonuses.Keys);
		foreach (SkillBreakPlateIndex key in IndexesCache0)
		{
			_bonuses[key] = _bonuses[key].ResetRelationCharIds();
		}
	}

	/// <summary>
	/// 选中下个突破格
	/// </summary>
	public bool SelectBreak(IRandomSource random, SkillBreakPlateIndex index, out bool selectInGoneMad)
	{
		selectInGoneMad = CalcStepIsInGoneMad(index);
		if (!CanSelectBreak(index) || Finished)
		{
			return false;
		}
		short successRate = CalcSuccessRate(index);
		bool success = random.CheckPercentProb(successRate);
		UpdateCurrentAndRecordPath(index, success);
		bool failed = !success && !GetPureNeighbors(index).Any((SkillBreakPlateIndex x) => GetGridAt(x).State == ESkillBreakGridState.Selected && GetGridAt(x).Template.NeighborFailedToCanSelect);
		if (selectInGoneMad)
		{
			StepCostedGoneMad += CalcCostStep(index);
		}
		else
		{
			StepCostedNormal += CalcCostStep(index);
		}
		this[GetPhysicalIndex(index)].State = (success ? ESkillBreakGridState.Selected : ((!failed) ? ESkillBreakGridState.CanSelect : ESkillBreakGridState.Failed));
		if (success || failed)
		{
			RecordSuccessRate(index, successRate, selectInGoneMad);
		}
		if (CalcCostStep(index) == 0)
		{
			selectInGoneMad = false;
		}
		if (success)
		{
			SuccessCount++;
		}
		else
		{
			FailedCount++;
		}
		if (success)
		{
			SelectBreakSpecialEffect(random, index);
		}
		UpdateState();
		UpdateCanSelectGrids();
		return true;
	}

	/// <summary>
	/// 选中下个突破格 - 结算特殊格效果
	/// </summary>
	private void SelectBreakSpecialEffect(IRandomSource random, SkillBreakPlateIndex index)
	{
		SkillBreakGridTypeItem config = GetGridAt(index).Template;
		_stepExtraNormal += config.AddStepNormal;
		SelectBreakSpecialEffectShowInvisible(random, config.ShowInvisibleCount);
		IndexesCache0.Clear();
		IndexesCache1.Clear();
		foreach (SkillBreakPlateIndex neighbor in GetPureNeighbors(index))
		{
			if (!(neighbor == index) && GetGridAt(neighbor).State.CanInteract())
			{
				if (GetGridAt(neighbor).Template.Type == ESkillBreakGridTypeType.Normal)
				{
					IndexesCache0.Add(neighbor);
				}
				if (GetGridAt(neighbor).Template.Type == ESkillBreakGridTypeType.Special && config.AllNeighborSpecialConvertToNormalGrid)
				{
					this[GetPhysicalIndex(neighbor)].TemplateId = 3;
				}
				if (!GetGridAt(neighbor).Template.IgnoreEffectAddMaxPower)
				{
					IndexesCache1.Add(neighbor);
				}
			}
		}
		int markFailedCount = config.TransferPowerAndConvertToFailedNeighborCount;
		foreach (SkillBreakPlateIndex neighbor2 in RandomUtils.GetRandomUnrepeated(random, markFailedCount, IndexesCache1))
		{
			this[GetPhysicalIndex(neighbor2)].State = ESkillBreakGridState.Failed;
			if (this[GetPhysicalIndex(neighbor2)].AddMaxPower > 0)
			{
				this[GetPhysicalIndex(index)].AddMaxPower = MathUtils.Max(this[GetPhysicalIndex(index)].AddMaxPower, 0) + this[GetPhysicalIndex(neighbor2)].AddMaxPower;
			}
			this[GetPhysicalIndex(neighbor2)].AddMaxPower = 0;
		}
		if (IndexesCache0.Count == 0)
		{
			return;
		}
		if (config.RandomNeighborNormalConvertToSameGrid)
		{
			int cacheIndex = random.Next(IndexesCache0.Count);
			SkillBreakPlateIndex neighbor3 = IndexesCache0[cacheIndex];
			CollectionUtils.SwapAndRemove(IndexesCache0, cacheIndex);
			this[GetPhysicalIndex(neighbor3)].TemplateId = config.TemplateId;
		}
		if (!config.AllNeighborNormalConvertToSpecialGrid)
		{
			return;
		}
		foreach (SkillBreakPlateIndex neighbor4 in IndexesCache0)
		{
			this[GetPhysicalIndex(neighbor4)].TemplateId = RandomSpecialGridType(random, byGenerate: false);
		}
	}

	/// <summary>
	/// 选中下个突破格 - 结算特殊格效果 - 揭示隐藏格
	/// </summary>
	private void SelectBreakSpecialEffectShowInvisible(IRandomSource random, int showInvisibleCount)
	{
		IndexesCache0.Clear();
		foreach (SkillBreakPlateIndex index in GetIndexes())
		{
			if (GetGridAt(index).State == ESkillBreakGridState.Invisible)
			{
				IndexesCache0.Add(index);
			}
		}
		foreach (SkillBreakPlateIndex index2 in RandomUtils.GetRandomUnrepeated(random, showInvisibleCount, IndexesCache0))
		{
			this[GetPhysicalIndex(index2)].State = ESkillBreakGridState.Showed;
		}
	}

	/// <summary>
	/// 更新当前点并记录路径
	/// </summary>
	private void UpdateCurrentAndRecordPath(SkillBreakPlateIndex index, bool success)
	{
		if (_selectPath == null)
		{
			_selectPath = new List<SkillBreakPlateIndex>();
		}
		if (Current == SkillBreakPlateIndex.Invalid)
		{
			foreach (SkillBreakPlateIndex neighbor in GetPureNeighbors(index))
			{
				if (IsStartPoint(neighbor.X, neighbor.Y))
				{
					_selectPath.Add(neighbor);
				}
			}
		}
		if (success)
		{
			Current = index;
		}
		_selectPath.Add(index);
	}

	/// <summary>
	/// 记录成功率与相关状态
	/// </summary>
	private void RecordSuccessRate(SkillBreakPlateIndex index, short successRate, bool inGoneMad)
	{
		this[GetPhysicalIndex(index)].RecordedSuccessRate = successRate;
		this[GetPhysicalIndex(index)].RecordedStepIsGoneMad = inGoneMad;
	}

	/// <summary>
	/// 更新可选位置
	/// </summary>
	private void UpdateCanSelectGrids()
	{
		ClearAllCanSelectGrids();
		if (Finished)
		{
			return;
		}
		foreach (SkillBreakPlateIndex neighbor in GetNeighbors(Current))
		{
			this[GetPhysicalIndex(neighbor)].State = (MaybeSuccess(neighbor) ? ESkillBreakGridState.CanSelect : ESkillBreakGridState.Showed);
		}
	}

	/// <summary>
	/// 清空所有可选中状态
	/// </summary>
	private void ClearAllCanSelectGrids()
	{
		foreach (SkillBreakPlateIndex index in GetIndexes())
		{
			if (GetGridAt(index).State == ESkillBreakGridState.CanSelect)
			{
				this[GetPhysicalIndex(index)].State = ESkillBreakGridState.Showed;
			}
		}
	}

	/// <summary>
	/// 更新突破盘状态
	/// </summary>
	private void UpdateState()
	{
		if (IsEndPoint(Current.X, Current.Y))
		{
			_internalState = 1;
		}
		else if (!AnyNeighbors)
		{
			_internalState = 2;
		}
		else
		{
			_internalState = 0;
		}
	}

	/// <summary>
	/// 更新选中的书页
	/// </summary>
	public bool UpdateSelectedPages(ushort selectedPages)
	{
		if (OutlineType != CombatSkillStateHelper.GetActiveOutlinePageType(SelectedPages))
		{
			return false;
		}
		SelectedPages = selectedPages;
		return true;
	}

	/// <summary>
	/// GM 使用的设置当前格接口
	/// </summary>
	public void SelectBreakWithoutCheck(SkillBreakPlateIndex index)
	{
		Current = index;
		if (CheckIndex(index))
		{
			this[GetPhysicalIndex(index)].State = ESkillBreakGridState.Selected;
		}
		UpdateState();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SkillBreakPlate()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SkillBreakPlate(SkillBreakPlate other)
	{
		SkillBreakPlateGrid[] item = other._grids;
		int elementsCount = item.Length;
		_grids = new SkillBreakPlateGrid[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_grids[i] = new SkillBreakPlateGrid(item[i]);
		}
		Width = other.Width;
		Height = other.Height;
		_internalState = other._internalState;
		StepBase = other.StepBase;
		_stepExtraNormal = other._stepExtraNormal;
		StepCostedNormal = other.StepCostedNormal;
		StepCostedGoneMad = other.StepCostedGoneMad;
		Current = other.Current;
		BaseSuccessRate = other.BaseSuccessRate;
		SuccessCount = other.SuccessCount;
		FailedCount = other.FailedCount;
		SelectedPages = other.SelectedPages;
		_selectPath = ((other._selectPath == null) ? null : new List<SkillBreakPlateIndex>(other._selectPath));
		_bonuses = ((other._bonuses == null) ? null : new Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus>(other._bonuses));
		_gridSwaps = ((other._gridSwaps == null) ? null : new Dictionary<SkillBreakPlateIndex, SkillBreakPlateIndex>(other._gridSwaps));
		SwapCount = other.SwapCount;
		LegendaryBookState = other.LegendaryBookState;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SkillBreakPlate other)
	{
		SkillBreakPlateGrid[] item = other._grids;
		int elementsCount = item.Length;
		_grids = new SkillBreakPlateGrid[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_grids[i] = new SkillBreakPlateGrid(item[i]);
		}
		Width = other.Width;
		Height = other.Height;
		_internalState = other._internalState;
		StepBase = other.StepBase;
		_stepExtraNormal = other._stepExtraNormal;
		StepCostedNormal = other.StepCostedNormal;
		StepCostedGoneMad = other.StepCostedGoneMad;
		Current = other.Current;
		BaseSuccessRate = other.BaseSuccessRate;
		SuccessCount = other.SuccessCount;
		FailedCount = other.FailedCount;
		SelectedPages = other.SelectedPages;
		_selectPath = ((other._selectPath == null) ? null : new List<SkillBreakPlateIndex>(other._selectPath));
		_bonuses = ((other._bonuses == null) ? null : new Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus>(other._bonuses));
		_gridSwaps = ((other._gridSwaps == null) ? null : new Dictionary<SkillBreakPlateIndex, SkillBreakPlateIndex>(other._gridSwaps));
		SwapCount = other.SwapCount;
		LegendaryBookState = other.LegendaryBookState;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 45;
		if (_grids != null)
		{
			totalSize += 2;
			for (int i = 0; i < _grids.Length; i++)
			{
				totalSize = ((_grids[i] == null) ? (totalSize + 2) : (totalSize + (2 + _grids[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((_selectPath == null) ? (totalSize + 2) : (totalSize + (2 + 8 * _selectPath.Count)));
		totalSize += 4;
		if (_bonuses != null)
		{
			foreach (KeyValuePair<SkillBreakPlateIndex, SkillBreakPlateBonus> pair in _bonuses)
			{
				totalSize += pair.Key.GetSerializedSize();
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (_gridSwaps != null)
		{
			foreach (KeyValuePair<SkillBreakPlateIndex, SkillBreakPlateIndex> pair2 in _gridSwaps)
			{
				totalSize += pair2.Key.GetSerializedSize();
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 18;
		pCurrData += 2;
		if (_grids != null)
		{
			int elementsCount = _grids.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (_grids[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = _grids[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = Width;
		pCurrData++;
		*pCurrData = Height;
		pCurrData++;
		*pCurrData = (byte)_internalState;
		pCurrData++;
		*(int*)pCurrData = StepBase;
		pCurrData += 4;
		*(int*)pCurrData = _stepExtraNormal;
		pCurrData += 4;
		*(int*)pCurrData = StepCostedNormal;
		pCurrData += 4;
		*(int*)pCurrData = StepCostedGoneMad;
		pCurrData += 4;
		pCurrData += Current.Serialize(pCurrData);
		*pCurrData = BaseSuccessRate;
		pCurrData++;
		*(int*)pCurrData = SuccessCount;
		pCurrData += 4;
		*(int*)pCurrData = FailedCount;
		pCurrData += 4;
		*(ushort*)pCurrData = SelectedPages;
		pCurrData += 2;
		if (_selectPath != null)
		{
			int elementsCount2 = _selectPath.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += _selectPath[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_bonuses != null)
		{
			*(int*)pCurrData = _bonuses.Count;
			pCurrData += 4;
			foreach (KeyValuePair<SkillBreakPlateIndex, SkillBreakPlateBonus> pair in _bonuses)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (_gridSwaps != null)
		{
			*(int*)pCurrData = _gridSwaps.Count;
			pCurrData += 4;
			foreach (KeyValuePair<SkillBreakPlateIndex, SkillBreakPlateIndex> pair2 in _gridSwaps)
			{
				pCurrData += pair2.Key.Serialize(pCurrData);
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = SwapCount;
		pCurrData += 4;
		*pCurrData = (byte)LegendaryBookState;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_grids == null || _grids.Length != elementsCount)
				{
					_grids = new SkillBreakPlateGrid[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						_grids[i] = new SkillBreakPlateGrid();
						pCurrData += _grids[i].Deserialize(pCurrData);
					}
					else
					{
						_grids[i] = null;
					}
				}
			}
			else
			{
				_grids = null;
			}
		}
		if (fieldCount > 1)
		{
			Width = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			Height = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			_internalState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			StepBase = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			_stepExtraNormal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			StepCostedNormal = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			StepCostedGoneMad = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 8)
		{
			SkillBreakPlateIndex CurrentValue = Current;
			pCurrData += CurrentValue.Deserialize(pCurrData);
			Current = CurrentValue;
		}
		if (fieldCount > 9)
		{
			BaseSuccessRate = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			SuccessCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 11)
		{
			FailedCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 12)
		{
			SelectedPages = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 13)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_selectPath == null)
				{
					_selectPath = new List<SkillBreakPlateIndex>();
				}
				else
				{
					_selectPath.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					SkillBreakPlateIndex element = default(SkillBreakPlateIndex);
					pCurrData += element.Deserialize(pCurrData);
					_selectPath.Add(element);
				}
			}
			else
			{
				_selectPath?.Clear();
			}
		}
		if (fieldCount > 14)
		{
			int _bonusesElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (_bonusesElementsCount > 0)
			{
				if (_bonuses == null)
				{
					_bonuses = new Dictionary<SkillBreakPlateIndex, SkillBreakPlateBonus>();
				}
				else
				{
					_bonuses.Clear();
				}
				for (int k = 0; k < _bonusesElementsCount; k++)
				{
					SkillBreakPlateIndex key = default(SkillBreakPlateIndex);
					pCurrData += key.Deserialize(pCurrData);
					SkillBreakPlateBonus value = default(SkillBreakPlateBonus);
					pCurrData += value.Deserialize(pCurrData);
					_bonuses.Add(key, value);
				}
			}
			else
			{
				_bonuses?.Clear();
			}
		}
		if (fieldCount > 15)
		{
			int _gridSwapsElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (_gridSwapsElementsCount > 0)
			{
				if (_gridSwaps == null)
				{
					_gridSwaps = new Dictionary<SkillBreakPlateIndex, SkillBreakPlateIndex>();
				}
				else
				{
					_gridSwaps.Clear();
				}
				for (int l = 0; l < _gridSwapsElementsCount; l++)
				{
					SkillBreakPlateIndex key2 = default(SkillBreakPlateIndex);
					pCurrData += key2.Deserialize(pCurrData);
					SkillBreakPlateIndex value2 = default(SkillBreakPlateIndex);
					pCurrData += value2.Deserialize(pCurrData);
					_gridSwaps.Add(key2, value2);
				}
			}
			else
			{
				_gridSwaps?.Clear();
			}
		}
		if (fieldCount > 16)
		{
			SwapCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 17)
		{
			LegendaryBookState = (ELegendaryBookSlotState)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
