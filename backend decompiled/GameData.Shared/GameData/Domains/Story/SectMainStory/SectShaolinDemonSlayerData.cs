using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 少林诛魔试炼数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectShaolinDemonSlayerData : ISerializableGameData
{
	/// <summary>
	/// 每级挑战的魔头数
	/// </summary>
	public const int DemonPerLevel = 2;

	/// <summary>
	/// 最大约束数
	/// </summary>
	public const int MaxRestrictCount = 3;

	/// <summary>
	/// 约束索引缓存
	/// </summary>
	private static readonly List<int> RestrictCacheIndexes = new List<int>();

	/// <summary>
	/// 约束权重缓存
	/// </summary>
	private static readonly List<short> RestrictCacheWeights = new List<short>();

	/// <summary>
	/// 约束组缓存
	/// </summary>
	private static readonly HashSet<int> RestrictCacheGroups = new HashSet<int>();

	/// <summary>
	/// 正在挑战的约束特效
	/// 仅限后端使用
	/// </summary>
	public List<object> TrialingRestrictEffects;

	/// <summary>
	/// 魔头击败标识，转换为 BoolArray32 使用，索引为 DemonSlayerTrial 表的 TemplateId
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private uint _demonFlags0;

	/// <summary>
	/// 正在挑战的魔头顺序，每两个为一组
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	private List<int> _trialingDemons;

	/// <summary>
	/// 当前挑战级别
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	private int _trialingLevel;

	/// <summary>
	/// 各魔头的约束条件
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	private List<IntList> _trailingRestricts;

	/// <summary>
	/// 重新生成约束条件的剩余次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	private List<int> _trailingRegenerateRestrictCount;

	/// <summary>
	/// 是否处于试炼状态（已初始化魔头，且存在待挑战的魔头）
	/// </summary>
	public bool Trialing
	{
		get
		{
			List<int> trialingDemons = _trialingDemons;
			if (trialingDemons != null && trialingDemons.Count > 0)
			{
				return _trialingDemons.Count - _trialingLevel * 2 >= 2;
			}
			return false;
		}
	}

	/// <summary>
	/// 当前挑战的关卡配置
	/// </summary>
	public DemonSlayerTrialLevelItem TrialingLevel
	{
		get
		{
			if (!Trialing)
			{
				return null;
			}
			int templateId = MathUtils.Clamp(_trialingLevel, 0, DemonSlayerTrialLevel.Instance.Count - 1);
			return DemonSlayerTrialLevel.Instance[templateId];
		}
	}

	/// <summary>
	/// 生成一组随机的约束条件
	/// </summary>
	public static IntList GenerateRestricts(IRandomSource random, int demonId, int totalPower)
	{
		IntList result = IntList.Create();
		RestrictCacheGroups.Clear();
		int minRestrictPower = totalPower / 3 + ((totalPower % 3 != 0) ? 1 : 0);
		for (int i = 0; i < 3; i++)
		{
			if (totalPower < minRestrictPower)
			{
				minRestrictPower = totalPower;
				totalPower = minRestrictPower + 2;
			}
			RestrictCacheIndexes.Clear();
			RestrictCacheWeights.Clear();
			foreach (DemonSlayerTrialRestrictItem restrict in (IEnumerable<DemonSlayerTrialRestrictItem>)DemonSlayerTrialRestrict.Instance)
			{
				if (!restrict.MutexDemonId.Contains(demonId) && !RestrictCacheGroups.Contains(restrict.MutexGroupId) && restrict.Power <= totalPower && restrict.Power >= minRestrictPower && restrict.Weight > 0)
				{
					RestrictCacheIndexes.Add(restrict.TemplateId);
					RestrictCacheWeights.Add(restrict.Weight);
				}
			}
			if (RestrictCacheIndexes.Count != 0)
			{
				int restrictIndex = RandomUtils.GetRandomIndex(RestrictCacheWeights, random);
				int restrictId = RestrictCacheIndexes[restrictIndex];
				result.Items.Add(restrictId);
				DemonSlayerTrialRestrictItem restrictConfig = DemonSlayerTrialRestrict.Instance[restrictId];
				RestrictCacheGroups.Add(restrictConfig.MutexGroupId);
				totalPower -= restrictConfig.Power;
				if (totalPower <= 0)
				{
					break;
				}
			}
		}
		return result;
	}

	/// <summary>
	/// 获取当前关卡重新生成约束条件的剩余次数
	/// </summary>
	public int GetRegenerateRestrictCount()
	{
		if (!Trialing)
		{
			return 0;
		}
		return _trailingRegenerateRestrictCount[_trialingLevel];
	}

	/// <summary>
	/// 获取正在挑战的魔头
	/// </summary>
	public DemonSlayerTrialItem GetTrialingDemon(int index)
	{
		bool flag = ((index < 0 || index >= 2) ? true : false);
		if (flag || !Trialing)
		{
			return null;
		}
		int baseIndex = _trialingLevel * 2;
		int templateId = _trialingDemons[baseIndex + index];
		return DemonSlayerTrial.Instance[templateId];
	}

	/// <summary>
	/// 获取正在挑战的魔头约束
	/// </summary>
	public IEnumerable<DemonSlayerTrialRestrictItem> GetTrialingRestricts(int index)
	{
		bool flag = ((index < 0 || index >= 2) ? true : false);
		if (flag || !Trialing)
		{
			yield break;
		}
		int baseIndex = _trialingLevel * 2;
		IntList restricts = _trailingRestricts[baseIndex + index];
		List<int> items = restricts.Items;
		if (items == null || items.Count <= 0)
		{
			yield break;
		}
		foreach (int restrictId in restricts.Items)
		{
			yield return DemonSlayerTrialRestrict.Instance[restrictId];
		}
	}

	/// <summary>
	/// 指定魔头是否在任意挑战中被击败过
	/// </summary>
	public bool IsDemonDefeated(int templateId)
	{
		if (templateId < 0 || templateId >= DemonSlayerTrial.Instance.Count)
		{
			return false;
		}
		Tester.Assert(templateId < 32, "templateId < 32");
		return ((BoolArray32)_demonFlags0)[templateId];
	}

	/// <summary>
	/// 生成一轮新的挑战
	/// </summary>
	public bool GenerateDemons(IRandomSource random)
	{
		if (Trialing)
		{
			return false;
		}
		if (_trialingDemons == null)
		{
			_trialingDemons = new List<int>();
		}
		_trialingDemons.Clear();
		foreach (DemonSlayerTrialItem config in (IEnumerable<DemonSlayerTrialItem>)DemonSlayerTrial.Instance)
		{
			_trialingDemons.Add(config.TemplateId);
		}
		CollectionUtils.Shuffle(random, _trialingDemons);
		if (_trailingRestricts == null)
		{
			_trailingRestricts = new List<IntList>();
		}
		_trailingRestricts.Clear();
		for (int i = 0; i < _trialingDemons.Count; i++)
		{
			int demonId = _trialingDemons[i];
			int levelId = i / 2;
			DemonSlayerTrialLevelItem level = DemonSlayerTrialLevel.Instance[levelId];
			_trailingRestricts.Add(GenerateRestricts(random, demonId, level.TotalPower));
		}
		if (_trailingRegenerateRestrictCount == null)
		{
			_trailingRegenerateRestrictCount = new List<int>();
		}
		_trailingRegenerateRestrictCount.Clear();
		foreach (DemonSlayerTrialLevelItem level2 in (IEnumerable<DemonSlayerTrialLevelItem>)DemonSlayerTrialLevel.Instance)
		{
			_trailingRegenerateRestrictCount.Add(level2.RestrictRandomCount);
		}
		_trialingLevel = 0;
		return true;
	}

	/// <summary>
	/// 清空挑战数据
	/// </summary>
	public bool ClearDemons()
	{
		List<int> trialingDemons = _trialingDemons;
		if (trialingDemons == null || trialingDemons.Count <= 0)
		{
			List<IntList> trailingRestricts = _trailingRestricts;
			if (trailingRestricts == null || trailingRestricts.Count <= 0)
			{
				trialingDemons = _trailingRegenerateRestrictCount;
				if ((trialingDemons == null || trialingDemons.Count <= 0) && _trialingLevel == 0)
				{
					return false;
				}
			}
		}
		_trialingDemons?.Clear();
		_trailingRestricts?.Clear();
		_trailingRegenerateRestrictCount?.Clear();
		_trialingLevel = 0;
		return true;
	}

	/// <summary>
	/// 重新生成当前关卡的约束条件
	/// </summary>
	public bool ReGenerateRestricts(IRandomSource random)
	{
		if (GetRegenerateRestrictCount() <= 0)
		{
			return false;
		}
		_trailingRegenerateRestrictCount[_trialingLevel]--;
		int baseIndex = _trialingLevel * 2;
		for (int i = 0; i < 2; i++)
		{
			int templateId = _trialingDemons[baseIndex + i];
			_trailingRestricts[baseIndex + i] = GenerateRestricts(random, templateId, TrialingLevel.TotalPower);
		}
		return true;
	}

	/// <summary>
	/// 结算奖励后前往下一关
	/// </summary>
	public bool ToNextLevel()
	{
		if (!Trialing)
		{
			return false;
		}
		_trialingLevel++;
		if (!Trialing)
		{
			ClearDemons();
		}
		return true;
	}

	/// <summary>
	/// 标记指定魔头已被击败
	/// </summary>
	public bool MarkDemonAsDefeated(int templateId)
	{
		if (templateId < 0 || templateId >= DemonSlayerTrial.Instance.Count)
		{
			return false;
		}
		Tester.Assert(templateId < 32, "templateId < 32");
		BoolArray32 array = _demonFlags0;
		array[templateId] = true;
		_demonFlags0 = array;
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectShaolinDemonSlayerData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectShaolinDemonSlayerData(SectShaolinDemonSlayerData other)
	{
		_demonFlags0 = other._demonFlags0;
		_trialingDemons = ((other._trialingDemons == null) ? null : new List<int>(other._trialingDemons));
		_trialingLevel = other._trialingLevel;
		if (other._trailingRestricts != null)
		{
			List<IntList> item = other._trailingRestricts;
			int elementsCount = item.Count;
			_trailingRestricts = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_trailingRestricts.Add(new IntList(item[i]));
			}
		}
		else
		{
			_trailingRestricts = null;
		}
		_trailingRegenerateRestrictCount = ((other._trailingRegenerateRestrictCount == null) ? null : new List<int>(other._trailingRegenerateRestrictCount));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectShaolinDemonSlayerData other)
	{
		_demonFlags0 = other._demonFlags0;
		_trialingDemons = ((other._trialingDemons == null) ? null : new List<int>(other._trialingDemons));
		_trialingLevel = other._trialingLevel;
		if (other._trailingRestricts != null)
		{
			List<IntList> item = other._trailingRestricts;
			int elementsCount = item.Count;
			_trailingRestricts = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_trailingRestricts.Add(new IntList(item[i]));
			}
		}
		else
		{
			_trailingRestricts = null;
		}
		_trailingRegenerateRestrictCount = ((other._trailingRegenerateRestrictCount == null) ? null : new List<int>(other._trailingRegenerateRestrictCount));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((_trialingDemons == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _trialingDemons.Count)));
		if (_trailingRestricts != null)
		{
			totalSize += 2;
			int elementsCount = _trailingRestricts.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += _trailingRestricts[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((_trailingRegenerateRestrictCount == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _trailingRegenerateRestrictCount.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(uint*)pCurrData = _demonFlags0;
		pCurrData += 4;
		if (_trialingDemons != null)
		{
			int elementsCount = _trialingDemons.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _trialingDemons[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _trialingLevel;
		pCurrData += 4;
		if (_trailingRestricts != null)
		{
			int elementsCount2 = _trailingRestricts.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int subDataSize = _trailingRestricts[j].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_trailingRegenerateRestrictCount != null)
		{
			int elementsCount3 = _trailingRegenerateRestrictCount.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = _trailingRegenerateRestrictCount[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_demonFlags0 = *(uint*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_trialingDemons == null)
			{
				_trialingDemons = new List<int>(elementsCount);
			}
			else
			{
				_trialingDemons.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_trialingDemons.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_trialingDemons?.Clear();
		}
		_trialingLevel = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (_trailingRestricts == null)
			{
				_trailingRestricts = new List<IntList>(elementsCount2);
			}
			else
			{
				_trailingRestricts.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				IntList element = default(IntList);
				pCurrData += element.Deserialize(pCurrData);
				_trailingRestricts.Add(element);
			}
		}
		else
		{
			_trailingRestricts?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (_trailingRegenerateRestrictCount == null)
			{
				_trailingRegenerateRestrictCount = new List<int>(elementsCount3);
			}
			else
			{
				_trailingRegenerateRestrictCount.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				_trailingRegenerateRestrictCount.Add(((int*)pCurrData)[k]);
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			_trailingRegenerateRestrictCount?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
