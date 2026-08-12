using System;
using System.Linq;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 淬毒效果
/// </summary>
[Obsolete("Instead by FullPoisonEffects. Now only for archive data fix. Do not delete this code.")]
public struct PoisonEffects : ISerializableGameData, IEquatable<PoisonEffects>
{
	/// <summary>
	/// 淬毒物品，最终的ID，混合毒也是一个ID
	/// </summary>
	private unsafe fixed short _medicineTemplateIds[1];

	/// <summary>
	/// 已经被鉴定
	/// </summary>
	public bool IsIdentified;

	private PoisonsAndLevels _poisons;

	/// <summary>
	/// 最大淬毒栏位
	/// </summary>
	public const int MaxPoisonCount = 3;

	/// <summary>
	/// 是否有毒
	/// </summary>
	public bool HasPoison => GetTotalPoisonCount() > 0;

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值,依赖于 <see cref="F:GameData.Domains.Item.PoisonEffects.MaxPoisonCount" /> 的值
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* medicineTemplateIds = _medicineTemplateIds)
		{
			*medicineTemplateIds = -1;
		}
		_poisons.Initialize();
		IsIdentified = false;
	}

	public bool Equals(PoisonEffects other)
	{
		if (IsIdentified != other.IsIdentified)
		{
			return false;
		}
		if (!_poisons.Equals(other._poisons))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 是否为两种毒组成的混合毒药
	/// </summary>
	/// <returns></returns>
	public unsafe bool IsTwoPoisonsMix()
	{
		if (_medicineTemplateIds[0] >= 389)
		{
			return _medicineTemplateIds[0] <= 403;
		}
		return false;
	}

	/// <summary>
	/// 是否为三种毒组成的混合毒药
	/// </summary>
	/// <returns></returns>
	public unsafe bool IsThreePoisonsMix()
	{
		if (_medicineTemplateIds[0] >= 404)
		{
			return _medicineTemplateIds[0] <= 423;
		}
		return false;
	}

	/// <summary>
	/// 获取栏位所有的毒的效果
	/// </summary>
	/// <returns></returns>
	public PoisonsAndLevels GetAllPoisonsAndLevels()
	{
		return _poisons;
	}

	/// <summary>
	/// 获取栏位所有的材料
	/// </summary>
	/// <returns></returns>
	public unsafe short[] GetAllMedicineTemplateIds()
	{
		short[] ids = new short[3];
		for (int i = 0; i < ids.Length; i++)
		{
			ids[i] = -1;
		}
		int index = 0;
		for (int j = 0; j < 6; j++)
		{
			short value = _poisons.Values[j];
			sbyte level = _poisons.Levels[j];
			int type = j;
			if (value <= 0)
			{
				continue;
			}
			Medicine.Instance.Iterate(delegate(MedicineItem m)
			{
				if (m.PoisonType == type && m.EffectValue == value && m.EffectThresholdValue == level)
				{
					short[] array = ids;
					int num = index;
					index = num + 1;
					array[num] = m.TemplateId;
					return false;
				}
				return true;
			});
		}
		return ids;
	}

	/// <summary>
	/// 获取最终的淬毒材料，可能是混合毒
	/// </summary>
	/// <returns></returns>
	public unsafe short GetMedicineTemplateId()
	{
		return _medicineTemplateIds[0];
	}

	/// <summary>
	/// 获取指定栏位的淬毒材料，仅用于淬毒解毒等需要知道具体毒时
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public short GetMedicineTemplateIdAt(int index)
	{
		if (index < 0 || index >= 3)
		{
			throw new ArgumentOutOfRangeException("index", index, "poison slot index is out of range.");
		}
		return GetAllMedicineTemplateIds()[index];
	}

	/// <summary>
	/// 解毒，ID是目前含有的毒
	/// </summary>
	public unsafe void Remove(short materialTemplateId)
	{
		if (Enumerable.Contains(GetAllMedicineTemplateIds(), materialTemplateId))
		{
			short oldId = materialTemplateId;
			if (oldId > -1)
			{
				MedicineItem oldConfig = Medicine.Instance[oldId];
				ref sbyte reference = ref _poisons.Levels[oldConfig.PoisonType];
				reference -= (sbyte)oldConfig.EffectThresholdValue;
				ref short reference2 = ref _poisons.Values[oldConfig.PoisonType];
				reference2 -= oldConfig.EffectValue;
				CalcFinialMedicineId();
			}
		}
	}

	/// <summary>
	/// 淬毒
	/// </summary>
	public unsafe void Add(short materialTemplateId)
	{
		if (GetTotalPoisonCount() > 3)
		{
			throw new Exception($"can not set more than {3} poisons");
		}
		if (materialTemplateId <= -1)
		{
			return;
		}
		short[] allMedicineTemplateIds = GetAllMedicineTemplateIds();
		MedicineItem config = Medicine.Instance[materialTemplateId];
		int oldId = -1;
		short[] array = allMedicineTemplateIds;
		foreach (short id in array)
		{
			if (id >= 0 && Medicine.Instance[id].PoisonType == config.PoisonType)
			{
				oldId = id;
				break;
			}
		}
		bool needSet = false;
		if (oldId <= -1)
		{
			needSet = true;
		}
		else
		{
			MedicineItem oldConfig = Medicine.Instance[oldId];
			if (oldConfig.PoisonType != config.PoisonType)
			{
				ref sbyte reference = ref _poisons.Levels[oldConfig.PoisonType];
				reference -= (sbyte)oldConfig.EffectThresholdValue;
				ref short reference2 = ref _poisons.Values[oldConfig.PoisonType];
				reference2 -= oldConfig.EffectValue;
				needSet = true;
			}
			else if (oldConfig.Grade < config.Grade)
			{
				needSet = true;
			}
		}
		if (needSet)
		{
			_poisons.Levels[config.PoisonType] = (sbyte)config.EffectThresholdValue;
			_poisons.Values[config.PoisonType] = config.EffectValue;
		}
		CalcFinialMedicineId();
	}

	/// <summary>
	/// 重新计算最终的毒药ID
	/// </summary>
	public unsafe void CalcFinialMedicineId()
	{
		switch (GetTotalPoisonCount())
		{
		case 0:
			_medicineTemplateIds[0] = -1;
			break;
		case 1:
		{
			ref short medicineTemplateIds2 = ref _medicineTemplateIds[0];
			medicineTemplateIds2 = GetAllMedicineTemplateIds()[0];
			break;
		}
		default:
		{
			ref short medicineTemplateIds = ref _medicineTemplateIds[0];
			medicineTemplateIds = MixedPoisonType.PoisonsAndLevelToMedicineTemplateId(ref _poisons);
			break;
		}
		}
	}

	/// <summary>
	/// 获取总淬毒次数
	/// </summary>
	/// <returns></returns>
	public sbyte GetTotalPoisonCount()
	{
		return _poisons.GetTotalPoisonCount();
	}

	/// <summary>
	/// 是否包含某种毒药
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public unsafe bool Contains(short templateId)
	{
		MedicineItem config = Medicine.Instance[templateId];
		for (int i = 0; i < 6; i++)
		{
			if (config.PoisonType == i && config.EffectValue == _poisons.Values[i])
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 获取毒素的最高品级
	/// </summary>
	/// <returns></returns>
	public int GetMaxGrade()
	{
		return GetAllMedicineTemplateIds().Max((short id) => (id <= -1) ? (-1) : Medicine.Instance[id].Grade);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 21;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		fixed (short* pItems = _medicineTemplateIds)
		{
			*(short*)pCurrData = *pItems;
			pCurrData += 2;
		}
		pCurrData += _poisons.Serialize(pCurrData);
		*pCurrData = (IsIdentified ? ((byte)1) : ((byte)0));
		pCurrData++;
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		fixed (short* medicineTemplateIds = _medicineTemplateIds)
		{
			*medicineTemplateIds = *(short*)pCurrData;
			pCurrData += 2;
		}
		pCurrData += _poisons.Deserialize(pCurrData);
		IsIdentified = *pCurrData != 0;
		pCurrData++;
		return (int)(pCurrData - pData);
	}
}
