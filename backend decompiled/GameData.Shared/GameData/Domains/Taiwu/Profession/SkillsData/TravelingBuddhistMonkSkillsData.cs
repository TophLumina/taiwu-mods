using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 旅行僧相关数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class TravelingBuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort StateTempleVisited = 0;

		public const ushort StateTempleLocation = 1;

		public const ushort GeneratedTempleIndices = 2;

		public const ushort SelectedSkill3FeatureId = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "StateTempleVisited", "StateTempleLocation", "GeneratedTempleIndices", "SelectedSkill3FeatureId" };
	}

	/// <summary>
	/// 每次生成的寺庙数量
	/// </summary>
	public const int GenerateTempleCount = 5;

	/// <summary>
	/// 4技能默认特性。
	/// </summary>
	public const short DefaultSelectedSkill3FeatureId = 252;

	/// <summary>
	/// 各个州域的寺庙是否被访问过
	/// areaId -&gt; 是否访问过
	/// 这里是用数组当Dict用，实际生成了哪些寺庙，要根据_generatedTempleIndices才知道哪些州域是生成了寺庙的
	/// </summary>
	[SerializableGameDataField]
	private bool[] _stateTempleVisited;

	/// <summary>
	/// 各个州域的寺庙所在位置
	/// areaId -&gt; 寺庙地点 blockId
	/// 这里是用数组当Dict用，实际生成了哪些寺庙，要根据_generatedTempleIndices才知道哪些州域是生成了寺庙的
	/// </summary>
	[SerializableGameDataField]
	private Location[] _stateTempleLocation;

	/// <summary>
	/// 哪些下标的州域生成了寺庙
	/// </summary>
	[SerializableGameDataField]
	private List<int> _generatedTempleIndices;

	/// <summary>
	/// 4技能选中的特性是哪个。用于重新装配技能时，自动赋予太吾上次选择的特性。
	/// 如果是-1，则会在装配时自动选择九世轮回特性中的第一个，并记录。
	/// 只要4技能装配中，这个值不能是-1。
	/// </summary>
	[SerializableGameDataField]
	private short _selectedSkill3FeatureId;

	/// <summary>
	/// 是否拜访完所有寺庙
	/// </summary>
	public bool HasVisitedAllTemple => GetVisitedTempleCount() >= 15;

	/// <inheritdoc />
	public void Initialize()
	{
		_generatedTempleIndices?.Clear();
		if (_stateTempleVisited != null)
		{
			for (int i = 0; i < _stateTempleVisited.Length; i++)
			{
				_stateTempleVisited[i] = false;
				_stateTempleLocation[i] = Location.Invalid;
			}
		}
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteTravelingBuddhistMonkSkillsData)
		{
			OfflineClearAllTampleState();
			_selectedSkill3FeatureId = -1;
		}
	}

	/// <summary>
	/// 在指定地块创建寺庙, 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	public void OfflineCreateTemple(sbyte stateId, Location location)
	{
		_stateTempleLocation[stateId] = location;
		if (_generatedTempleIndices == null)
		{
			_generatedTempleIndices = new List<int>();
		}
		if (!_generatedTempleIndices.Contains(stateId))
		{
			_generatedTempleIndices.Add(stateId);
		}
	}

	/// <summary>
	/// 将指定区域的寺庙设为已访问, 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	public void OfflineSetStateTempleVisited(sbyte stateId)
	{
		if (!_stateTempleVisited[stateId])
		{
			_stateTempleVisited[stateId] = true;
		}
	}

	public void OfflineClearAllTampleState()
	{
		if (_generatedTempleIndices == null)
		{
			_generatedTempleIndices = new List<int>();
		}
		_generatedTempleIndices.Clear();
		for (int i = 0; i < _stateTempleVisited.Length; i++)
		{
			_stateTempleVisited[i] = false;
			_stateTempleLocation[i] = Location.Invalid;
		}
	}

	/// <summary>
	/// 获取被访问的寺庙数量
	/// </summary>
	/// <returns></returns>
	public int GetVisitedTempleCount()
	{
		return _stateTempleVisited.Count((bool x) => x);
	}

	public bool IsGeneratedTempleIndex(int index)
	{
		return _generatedTempleIndices?.Contains(index) ?? false;
	}

	/// <summary>
	/// 检查指定区域是否建立过寺庙
	/// </summary>
	public bool StateHasTemple(sbyte stateId)
	{
		if (IsGeneratedTempleIndex(stateId) && _stateTempleLocation.CheckIndex(stateId))
		{
			return _stateTempleLocation[stateId].IsValid();
		}
		return false;
	}

	public Location GetStateTempleLocation(sbyte stateId)
	{
		if (!_stateTempleLocation.CheckIndex(stateId))
		{
			return Location.Invalid;
		}
		return _stateTempleLocation[stateId];
	}

	/// <summary>
	/// 检查指定区域的寺庙是否被访问过
	/// </summary>
	public bool IsStateTempleVisited(sbyte stateId)
	{
		if (_stateTempleVisited.CheckIndex(stateId))
		{
			return _stateTempleVisited[stateId];
		}
		return false;
	}

	public TravelingBuddhistMonkSkillsData()
	{
		_stateTempleLocation = new Location[15];
		_stateTempleVisited = new bool[15];
	}

	public short GetSelectedSkill3FeatureId()
	{
		return _selectedSkill3FeatureId;
	}

	public void OfflineSetSelectedSkill3FeatureId(short featureId)
	{
		_selectedSkill3FeatureId = featureId;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelingBuddhistMonkSkillsData(TravelingBuddhistMonkSkillsData other)
	{
		bool[] item = other._stateTempleVisited;
		int elementsCount = item.Length;
		_stateTempleVisited = new bool[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_stateTempleVisited[i] = item[i];
		}
		Location[] item2 = other._stateTempleLocation;
		int elementsCount2 = item2.Length;
		_stateTempleLocation = new Location[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			_stateTempleLocation[j] = item2[j];
		}
		_generatedTempleIndices = ((other._generatedTempleIndices == null) ? null : new List<int>(other._generatedTempleIndices));
		_selectedSkill3FeatureId = other._selectedSkill3FeatureId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelingBuddhistMonkSkillsData other)
	{
		bool[] item = other._stateTempleVisited;
		int elementsCount = item.Length;
		_stateTempleVisited = new bool[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_stateTempleVisited[i] = item[i];
		}
		Location[] item2 = other._stateTempleLocation;
		int elementsCount2 = item2.Length;
		_stateTempleLocation = new Location[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			_stateTempleLocation[j] = item2[j];
		}
		_generatedTempleIndices = ((other._generatedTempleIndices == null) ? null : new List<int>(other._generatedTempleIndices));
		_selectedSkill3FeatureId = other._selectedSkill3FeatureId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((_stateTempleVisited == null) ? (totalSize + 2) : (totalSize + (2 + _stateTempleVisited.Length)));
		totalSize = ((_stateTempleLocation == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _stateTempleLocation.Length)));
		totalSize = ((_generatedTempleIndices == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _generatedTempleIndices.Count)));
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
		if (_stateTempleVisited != null)
		{
			int elementsCount = _stateTempleVisited.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (_stateTempleVisited[i] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_stateTempleLocation != null)
		{
			int elementsCount2 = _stateTempleLocation.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += _stateTempleLocation[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_generatedTempleIndices != null)
		{
			int elementsCount3 = _generatedTempleIndices.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = _generatedTempleIndices[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = _selectedSkill3FeatureId;
		pCurrData += 2;
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
				if (_stateTempleVisited == null || _stateTempleVisited.Length != elementsCount)
				{
					_stateTempleVisited = new bool[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_stateTempleVisited[i] = pCurrData[i] != 0;
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				_stateTempleVisited = null;
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_stateTempleLocation == null || _stateTempleLocation.Length != elementsCount2)
				{
					_stateTempleLocation = new Location[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					Location element = default(Location);
					pCurrData += element.Deserialize(pCurrData);
					_stateTempleLocation[j] = element;
				}
			}
			else
			{
				_stateTempleLocation = null;
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (_generatedTempleIndices == null)
				{
					_generatedTempleIndices = new List<int>(elementsCount3);
				}
				else
				{
					_generatedTempleIndices.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					_generatedTempleIndices.Add(((int*)pCurrData)[k]);
				}
				pCurrData += 4 * elementsCount3;
			}
			else
			{
				_generatedTempleIndices?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			_selectedSkill3FeatureId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
