using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true)]
public class TaiwuLifeSummary : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TaiwuCharId = 0;

		public const ushort SummaryValues = 1;

		public const ushort Achievements = 2;

		public const ushort AbridgedCharacter = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "TaiwuCharId", "SummaryValues", "Achievements", "AbridgedCharacter" };
	}

	[SerializableGameDataField]
	private int _taiwuCharId = -1;

	[SerializableGameDataField]
	private Dictionary<int, int> _summaryValues = new Dictionary<int, int>();

	[SerializableGameDataField]
	private List<int> _achievements = new List<int>();

	[SerializableGameDataField]
	private AbridgedCharacter _abridgedCharacter;

	public int TaiwuCharId => _taiwuCharId;

	public bool IsValid => _taiwuCharId >= 0;

	public AbridgedCharacter AbridgedCharacter => _abridgedCharacter;

	public bool IsArchived => _abridgedCharacter != null;

	public TaiwuLifeSummary(int taiwuCharId)
	{
		_taiwuCharId = taiwuCharId;
	}

	/// <summary>
	/// 传剑时记录太吾各项数据
	/// </summary>
	public void Archive(AbridgedCharacter abridgedCharacter)
	{
		_abridgedCharacter = abridgedCharacter;
	}

	/// <summary>
	/// 记录一条数据
	/// </summary>
	/// <param name="templateId"></param>
	public void Record(int templateId)
	{
		if (_summaryValues.TryGetValue(templateId, out var value))
		{
			_summaryValues[templateId] = value + 1;
		}
		else
		{
			_summaryValues.Add(templateId, 1);
		}
	}

	/// <summary>
	/// 记录多条数据
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="value"></param>
	public void Record(int templateId, int value)
	{
		if (_summaryValues.TryGetValue(templateId, out var prevValue))
		{
			_summaryValues[templateId] = prevValue + value;
		}
		else
		{
			_summaryValues.Add(templateId, value);
		}
	}

	/// <summary>
	/// 直接设置一条数据
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="value"></param>
	public void Set(int templateId, int value)
	{
		_summaryValues[templateId] = value;
	}

	/// <summary>
	/// 获取数据
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int Get(int templateId)
	{
		return _summaryValues.GetValueOrDefault(templateId, 0);
	}

	/// <summary>
	/// 是否有指定值
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public bool Contains(int templateId)
	{
		return _summaryValues.ContainsKey(templateId);
	}

	/// <summary>
	/// 添加一条成就
	/// </summary>
	/// <param name="templateId"></param>
	public void RecordAchievement(int templateId)
	{
		if (!_achievements.Contains(templateId))
		{
			_achievements.Add(templateId);
		}
	}

	public List<int> GetAchievements()
	{
		return _achievements;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TaiwuLifeSummary()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TaiwuLifeSummary(TaiwuLifeSummary other)
	{
		_taiwuCharId = other._taiwuCharId;
		_summaryValues = ((other._summaryValues == null) ? null : new Dictionary<int, int>(other._summaryValues));
		_achievements = ((other._achievements == null) ? null : new List<int>(other._achievements));
		_abridgedCharacter = new AbridgedCharacter(other._abridgedCharacter);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TaiwuLifeSummary other)
	{
		_taiwuCharId = other._taiwuCharId;
		_summaryValues = ((other._summaryValues == null) ? null : new Dictionary<int, int>(other._summaryValues));
		_achievements = ((other._achievements == null) ? null : new List<int>(other._achievements));
		_abridgedCharacter = new AbridgedCharacter(other._abridgedCharacter);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_summaryValues);
		totalSize = ((_achievements == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _achievements.Count)));
		totalSize = ((_abridgedCharacter == null) ? (totalSize + 2) : (totalSize + (2 + _abridgedCharacter.GetSerializedSize())));
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
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*(int*)pCurrData = _taiwuCharId;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref _summaryValues);
		if (_achievements != null)
		{
			int elementsCount = _achievements.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _achievements[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_abridgedCharacter != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = _abridgedCharacter.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			_taiwuCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _summaryValues);
		}
		if (fieldCount > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_achievements == null)
				{
					_achievements = new List<int>(elementsCount);
				}
				else
				{
					_achievements.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_achievements.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_achievements?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				if (_abridgedCharacter == null)
				{
					_abridgedCharacter = new AbridgedCharacter();
				}
				pCurrData += _abridgedCharacter.Deserialize(pCurrData);
			}
			else
			{
				_abridgedCharacter = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
