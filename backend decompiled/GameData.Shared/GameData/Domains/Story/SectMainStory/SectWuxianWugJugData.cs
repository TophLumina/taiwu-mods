using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 五仙万蛊坛数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectWuxianWugJugData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Poisons = 0;

		public const ushort LastRefiningDate = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Poisons", "LastRefiningDate" };
	}

	/// <summary>
	/// 六毒毒素量
	/// </summary>
	[SerializableGameDataField]
	private List<int> _poisons = new List<int>(6);

	/// <summary>
	/// 上次炼制日期
	/// </summary>
	[SerializableGameDataField]
	private int _lastRefiningDate;

	/// <summary>
	/// 只读毒素量
	/// </summary>
	public IReadOnlyList<int> Poisons => _poisons;

	/// <summary>
	/// 计算总毒素量
	/// </summary>
	public int TotalPoison => GetTotalPoison();

	/// <summary>
	/// 只读炼制日期
	/// </summary>
	public int LastRefiningDate => _lastRefiningDate;

	/// <summary>
	/// 获取总毒素量
	/// </summary>
	/// <returns></returns>
	public int GetTotalPoison()
	{
		int sum = 0;
		foreach (int poison in Poisons)
		{
			sum += poison;
		}
		return sum;
	}

	/// <summary>
	/// 重置数据
	/// </summary>
	public void Reset()
	{
		_poisons.Clear();
		for (int i = 0; i < 6; i++)
		{
			_poisons.Add(0);
		}
		_lastRefiningDate = -1;
	}

	/// <summary>
	/// 增加指定毒素
	/// </summary>
	/// <param name="poisonType"></param>
	/// <param name="addValue"></param>
	public void AddPoison(sbyte poisonType, int addValue)
	{
		if (_poisons.Count != 6)
		{
			Reset();
		}
		_poisons[poisonType] = MathUtils.Clamp(_poisons[poisonType] + addValue, 0, 357913941);
	}

	/// <summary>
	/// 减少指定毒素
	/// </summary>
	/// <param name="poisonType"></param>
	/// <param name="reduceValue"></param>
	public void ReducePoison(sbyte poisonType, int reduceValue)
	{
		AddPoison(poisonType, -reduceValue);
	}

	/// <summary>
	/// 更新炼制日期
	/// </summary>
	public void UpdateRefiningDate()
	{
		_lastRefiningDate = ExternalDataBridge.Context.CurrDate;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectWuxianWugJugData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectWuxianWugJugData(SectWuxianWugJugData other)
	{
		_poisons = ((other._poisons == null) ? null : new List<int>(other._poisons));
		_lastRefiningDate = other._lastRefiningDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectWuxianWugJugData other)
	{
		_poisons = ((other._poisons == null) ? null : new List<int>(other._poisons));
		_lastRefiningDate = other._lastRefiningDate;
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
		totalSize = ((_poisons == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _poisons.Count)));
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (_poisons != null)
		{
			int elementsCount = _poisons.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _poisons[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _lastRefiningDate;
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
				if (_poisons == null)
				{
					_poisons = new List<int>(elementsCount);
				}
				else
				{
					_poisons.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_poisons.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_poisons?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			_lastRefiningDate = *(int*)pCurrData;
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
