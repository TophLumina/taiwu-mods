using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 新版淬毒数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class FullPoisonEffects : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort PoisonSlotList = 0;

		public const ushort IsIdentified = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "PoisonSlotList", "IsIdentified" };
	}

	/// <summary>
	/// 最大淬毒栏位
	/// </summary>
	public static readonly int MaxSlotCount = 3;

	/// <summary>
	/// 槽位列表
	/// </summary>
	[SerializableGameDataField]
	public List<PoisonSlot> PoisonSlotList;

	/// <summary>
	/// 是否已鉴定
	/// </summary>
	[SerializableGameDataField]
	public bool IsIdentified;

	/// <summary>
	/// 是否经过凝炼
	/// </summary>
	public bool IsCondensed => PoisonSlotList?.Any((PoisonSlot p) => p.IsCondensed) ?? false;

	/// <summary>
	/// 是否有效
	/// </summary>
	public bool IsValid => PoisonSlotList?.Any((PoisonSlot p) => p.IsValid) ?? false;

	/// <summary>
	/// 当前有效槽位数量
	/// </summary>
	public int CurrentValidSlotCount => PoisonSlotList?.Count((PoisonSlot p) => p.IsValid) ?? 0;

	/// <summary>
	/// 是否是混合毒
	/// </summary>
	public bool IsMixed
	{
		get
		{
			List<PoisonSlot> poisonSlotList = PoisonSlotList;
			if (poisonSlotList == null)
			{
				return false;
			}
			return poisonSlotList.Count((PoisonSlot p) => p.IsValid && p.IsAddPoison) > 1;
		}
	}

	/// <summary>
	/// 是否是三种混合毒
	/// </summary>
	public bool IsThreeMixed => PoisonSlotList?.Count((PoisonSlot p) => p.IsValid && p.IsAddPoison) == MaxSlotCount;

	/// <summary>
	/// 完全清理
	/// </summary>
	public void Clear()
	{
		PoisonSlotList?.Clear();
	}

	/// <summary>
	/// 只清理凝炼数据
	/// </summary>
	public void ClearCondense()
	{
		PoisonSlotList?.ForEach(delegate(PoisonSlot s)
		{
			s.CondensedMedicineTemplateIdList?.Clear();
		});
	}

	/// <summary>
	/// 淬毒
	/// </summary>
	public void AddPoison(short templateId, IReadOnlyList<short> condensedMedicineTemplateIdList)
	{
		if (templateId < 0)
		{
			throw new Exception("Poison template Id is invalid.");
		}
		int sameIndex = PoisonSlotList?.FindIndex((PoisonSlot p) => p.IsSameType(templateId) || !p.IsValid) ?? (-1);
		if (sameIndex >= 0)
		{
			PoisonSlotList[sameIndex].SetPoison(templateId, condensedMedicineTemplateIdList);
			return;
		}
		if (IsValid && PoisonSlotList?.Count >= MaxSlotCount)
		{
			throw new Exception($"Poison slot cannot be more than {MaxSlotCount} on add poison");
		}
		PoisonSlot slot = new PoisonSlot();
		slot.SetPoison(templateId, condensedMedicineTemplateIdList);
		if (PoisonSlotList == null)
		{
			PoisonSlotList = new List<PoisonSlot>();
		}
		PoisonSlotList.Add(slot);
	}

	/// <summary>
	/// 解毒
	/// </summary>
	public void RemovePoison(short templateId)
	{
		int sameIndex = PoisonSlotList?.FindIndex((PoisonSlot p) => p.IsSameType(templateId)) ?? (-1);
		if (sameIndex < 0)
		{
			throw new Exception("Not find target poison to remove");
		}
		PoisonSlotList.RemoveAt(sameIndex);
	}

	/// <summary>
	/// 获取毒素的量和等级
	/// </summary>
	public PoisonsAndLevels GetAllPoisonsAndLevels()
	{
		PoisonsAndLevels poisons = default(PoisonsAndLevels);
		poisons.Initialize();
		if (IsValid)
		{
			foreach (PoisonSlot poisonSlot in PoisonSlotList)
			{
				PoisonsAndLevels poisonsAndLevels = poisonSlot.GetPoisonsAndLevels();
				poisons.Add(poisonsAndLevels);
			}
		}
		return poisons;
	}

	/// <summary>
	/// 是否包含指定毒素类型
	/// </summary>
	/// <param name="poisonType"><see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	/// <returns></returns>
	public bool ContainsPoisonType(sbyte poisonType)
	{
		if (PoisonSlotList == null)
		{
			return false;
		}
		foreach (PoisonSlot poisonSlot in PoisonSlotList)
		{
			if (poisonSlot.GetPoisonType() == poisonType)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 是否包含同类毒素
	/// </summary>
	/// <param name="medicineTemplateId"><see cref="F:Config.MedicineItem.TemplateId" /></param>
	/// <returns></returns>
	public bool ContainsPoisonOfSameType(short medicineTemplateId)
	{
		if (PoisonSlotList == null)
		{
			return false;
		}
		foreach (PoisonSlot poisonSlot in PoisonSlotList)
		{
			if (poisonSlot.IsSameType(medicineTemplateId))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 获取模板ID
	/// </summary>
	/// <returns></returns>
	public short GetMedicineTemplateId()
	{
		if (!IsValid)
		{
			return -1;
		}
		if (IsMixed)
		{
			return GetMixedMedicineTemplateId();
		}
		return PoisonSlotList.First().MedicineTemplateId;
	}

	/// <summary>
	/// 获取混合毒的模板ID
	/// </summary>
	/// <returns></returns>
	public short GetMixedMedicineTemplateId()
	{
		if (!IsMixed)
		{
			return -1;
		}
		return GetAllPoisonsAndLevels().GetMixTemplateId();
	}

	/// <summary>
	/// 获取全部毒物的模板ID
	/// </summary>
	/// <returns></returns>
	public List<short> GetAllMedicineTemplateIds(bool includeCondensed = false)
	{
		if (!IsValid)
		{
			return null;
		}
		List<short> list = new List<short>();
		foreach (PoisonSlot poisonSlot in PoisonSlotList)
		{
			list.Add(poisonSlot.MedicineTemplateId);
			if (includeCondensed && poisonSlot.IsCondensed)
			{
				list.AddRange(poisonSlot.CondensedMedicineTemplateIdList);
			}
		}
		return list;
	}

	/// <summary>
	/// 获取指定索引的毒物
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public short GetMedicineTemplateIdAt(int index)
	{
		List<short> list = GetAllMedicineTemplateIds();
		if (list.CheckIndex(index))
		{
			return list[index];
		}
		return -1;
	}

	/// <summary>
	/// 是否为两种毒组成的混合毒药
	/// </summary>
	/// <returns></returns>
	public bool IsTwoPoisonsMix()
	{
		short id = GetMedicineTemplateId();
		if (id >= 389)
		{
			return id <= 403;
		}
		return false;
	}

	/// <summary>
	/// 是否为三种毒组成的混合毒药
	/// </summary>
	/// <returns></returns>
	public bool IsThreePoisonsMix()
	{
		short id = GetMedicineTemplateId();
		if (id >= 404)
		{
			return id <= 423;
		}
		return false;
	}

	/// <summary>
	/// 获取毒素种类数量
	/// </summary>
	/// <returns></returns>
	public int GetTotalPoisonCount()
	{
		if (!IsValid)
		{
			return 0;
		}
		return PoisonSlotList.Count((PoisonSlot s) => s.IsValid);
	}

	/// <summary>
	/// 获取毒素的最高品级
	/// </summary>
	/// <returns></returns>
	public int GetMaxGrade()
	{
		return GetAllMedicineTemplateIds()?.Max((short id) => (id <= -1) ? (-1) : Medicine.Instance[id].Grade) ?? 0;
	}

	/// <summary>
	/// 比较值是否相同
	/// </summary>
	public bool SameOf(FullPoisonEffects other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (IsIdentified != other.IsIdentified)
		{
			return false;
		}
		if (PoisonSlotList == null && other.PoisonSlotList == null)
		{
			return true;
		}
		if (PoisonSlotList == null || other.PoisonSlotList == null)
		{
			return false;
		}
		if (PoisonSlotList.Count != other.PoisonSlotList.Count)
		{
			return false;
		}
		for (int i = 0; i < PoisonSlotList.Count; i++)
		{
			if (!PoisonSlotList[i].SameOf(other.PoisonSlotList[i]))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public FullPoisonEffects()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public FullPoisonEffects(FullPoisonEffects other)
	{
		if (other.PoisonSlotList != null)
		{
			List<PoisonSlot> item = other.PoisonSlotList;
			int elementsCount = item.Count;
			PoisonSlotList = new List<PoisonSlot>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				PoisonSlotList.Add(new PoisonSlot(item[i]));
			}
		}
		else
		{
			PoisonSlotList = null;
		}
		IsIdentified = other.IsIdentified;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(FullPoisonEffects other)
	{
		if (other.PoisonSlotList != null)
		{
			List<PoisonSlot> item = other.PoisonSlotList;
			int elementsCount = item.Count;
			PoisonSlotList = new List<PoisonSlot>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				PoisonSlotList.Add(new PoisonSlot(item[i]));
			}
		}
		else
		{
			PoisonSlotList = null;
		}
		IsIdentified = other.IsIdentified;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (PoisonSlotList != null)
		{
			totalSize += 2;
			int elementsCount = PoisonSlotList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				PoisonSlot element = PoisonSlotList[i];
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (PoisonSlotList != null)
		{
			int elementsCount = PoisonSlotList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				PoisonSlot element = PoisonSlotList[i];
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
		*pCurrData = (IsIdentified ? ((byte)1) : ((byte)0));
		pCurrData++;
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
				if (PoisonSlotList == null)
				{
					PoisonSlotList = new List<PoisonSlot>(elementsCount);
				}
				else
				{
					PoisonSlotList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						PoisonSlot element = new PoisonSlot();
						pCurrData += element.Deserialize(pCurrData);
						PoisonSlotList.Add(element);
					}
					else
					{
						PoisonSlotList.Add(null);
					}
				}
			}
			else
			{
				PoisonSlotList?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			IsIdentified = *pCurrData != 0;
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
