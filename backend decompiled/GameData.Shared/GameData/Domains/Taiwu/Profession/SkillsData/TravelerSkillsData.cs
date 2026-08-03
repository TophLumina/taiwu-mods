using System.Collections.Generic;
using Config;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 旅人相关数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class TravelerSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Palaces = 0;

		public const ushort MovementConsumedActionPoints = 1;

		public const ushort ExploredMapBlockCount = 2;

		public const ushort ExploredMapBlockActionPoints = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "Palaces", "MovementConsumedActionPoints", "ExploredMapBlockCount", "ExploredMapBlockActionPoints" };
	}

	/// <summary>
	/// 所有仙府数据
	/// </summary>
	[SerializableGameDataField]
	private List<TravelerPalaceData> _palaces;

	/// <summary>
	/// 移动消耗的精力
	/// </summary>
	[SerializableGameDataField]
	private int _movementConsumedActionPoints;

	/// <summary>
	/// 移动探索的格子数量
	/// </summary>
	[SerializableGameDataField]
	private int _exploredMapBlockCount;

	/// <summary>
	/// 移动探索的格子总消耗
	/// </summary>
	[SerializableGameDataField]
	private int _exploredMapBlockActionPoints;

	/// <summary>
	/// 已建造仙府数量
	/// </summary>
	public int PalaceCount => _palaces?.Count ?? 0;

	/// <summary>
	/// 因旅人不存在旧的存档数据，于构造调用初始化方法
	/// </summary>
	public TravelerSkillsData()
	{
		Initialize();
	}

	/// <inheritdoc />
	public void Initialize()
	{
		_palaces?.Clear();
		_movementConsumedActionPoints = 0;
		_exploredMapBlockCount = 0;
		_exploredMapBlockActionPoints = 0;
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	/// <summary>
	/// 尝试获得指定索引的仙府数据
	/// </summary>
	public TravelerPalaceData TryGetPalaceData(int index)
	{
		if (_palaces == null)
		{
			return null;
		}
		if (!_palaces.CheckIndex(index))
		{
			return null;
		}
		return _palaces[index];
	}

	/// <summary>
	/// 记录移动消耗，返回资历变化
	/// </summary>
	/// <param name="actionPoints">格子配置的精力消耗[0,300] (调用方需要将天转换为精力)</param>
	/// <returns></returns>
	public int RecordMovementConsumedActionPoints(int actionPoints)
	{
		_movementConsumedActionPoints += actionPoints;
		if (_movementConsumedActionPoints < 300)
		{
			return 0;
		}
		int movementConsumedActionPoints = _movementConsumedActionPoints;
		_movementConsumedActionPoints %= 300;
		int seniorityChangeBase = movementConsumedActionPoints - _movementConsumedActionPoints;
		return ProfessionFormula.Instance[72].Calculate(seniorityChangeBase);
	}

	/// <summary>
	/// 记录移动探索的格子数量，返回资历变化
	/// </summary>
	/// <returns>格子配置的精力消耗[0,300] (调用方需要将天转换为精力)</returns>
	public int RecordExploredMapBlock(int actionPoints)
	{
		_exploredMapBlockCount++;
		_exploredMapBlockActionPoints += actionPoints;
		if (_exploredMapBlockCount < 12)
		{
			return 0;
		}
		int result = ProfessionFormula.Instance[73].Calculate(_exploredMapBlockActionPoints);
		_exploredMapBlockActionPoints = 0;
		_exploredMapBlockCount = 0;
		return result;
	}

	/// <summary>
	/// 建造仙府
	/// </summary>
	public void OfflineBuildPalace(Location location)
	{
		if (_palaces == null)
		{
			_palaces = new List<TravelerPalaceData>();
		}
		_palaces.Add(new TravelerPalaceData
		{
			Location = location
		});
	}

	/// <summary>
	/// 摧毁仙府
	/// </summary>
	public bool OfflineDestroyPalace(int index)
	{
		if (_palaces == null)
		{
			return false;
		}
		if (!_palaces.CheckIndex(index))
		{
			return false;
		}
		_palaces.RemoveAt(index);
		return true;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelerSkillsData(TravelerSkillsData other)
	{
		if (other._palaces != null)
		{
			List<TravelerPalaceData> item = other._palaces;
			int elementsCount = item.Count;
			_palaces = new List<TravelerPalaceData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_palaces.Add(new TravelerPalaceData(item[i]));
			}
		}
		else
		{
			_palaces = null;
		}
		_movementConsumedActionPoints = other._movementConsumedActionPoints;
		_exploredMapBlockCount = other._exploredMapBlockCount;
		_exploredMapBlockActionPoints = other._exploredMapBlockActionPoints;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelerSkillsData other)
	{
		if (other._palaces != null)
		{
			List<TravelerPalaceData> item = other._palaces;
			int elementsCount = item.Count;
			_palaces = new List<TravelerPalaceData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_palaces.Add(new TravelerPalaceData(item[i]));
			}
		}
		else
		{
			_palaces = null;
		}
		_movementConsumedActionPoints = other._movementConsumedActionPoints;
		_exploredMapBlockCount = other._exploredMapBlockCount;
		_exploredMapBlockActionPoints = other._exploredMapBlockActionPoints;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 14;
		if (_palaces != null)
		{
			totalSize += 2;
			int elementsCount = _palaces.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				TravelerPalaceData element = _palaces[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (_palaces != null)
		{
			int elementsCount = _palaces.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				TravelerPalaceData element = _palaces[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
		*(int*)pCurrData = _movementConsumedActionPoints;
		pCurrData += 4;
		*(int*)pCurrData = _exploredMapBlockCount;
		pCurrData += 4;
		*(int*)pCurrData = _exploredMapBlockActionPoints;
		pCurrData += 4;
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
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_palaces == null)
				{
					_palaces = new List<TravelerPalaceData>(elementsCount);
				}
				else
				{
					_palaces.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						TravelerPalaceData element = new TravelerPalaceData();
						pCurrData += element.Deserialize(pCurrData);
						_palaces.Add(element);
					}
					else
					{
						_palaces.Add(null);
					}
				}
			}
			else
			{
				_palaces?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			_movementConsumedActionPoints = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			_exploredMapBlockCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			_exploredMapBlockActionPoints = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
