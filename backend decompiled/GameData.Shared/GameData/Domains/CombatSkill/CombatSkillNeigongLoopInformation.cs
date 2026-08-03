using System.Collections.Generic;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 内功周天数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CombatSkillNeigongLoopInformation : ISerializableGameData
{
	/// <summary>
	/// 辅助内功
	/// </summary>
	[SerializableGameDataField]
	public List<short> ReferenceSkillList;

	/// <summary>
	/// 额外内力
	/// </summary>
	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationProgress;

	[SerializableGameDataField]
	public List<QiArtStrategyDisplayData> TaiwuQiArtStrategyList;

	/// <summary>
	/// 获取的内力最小，最大值
	/// </summary>
	[SerializableGameDataField]
	public (int, int) ExtraNeiliTotalRange;

	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationTotal;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillNeigongLoopInformation()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatSkillNeigongLoopInformation(CombatSkillNeigongLoopInformation other)
	{
		ReferenceSkillList = ((other.ReferenceSkillList == null) ? null : new List<short>(other.ReferenceSkillList));
		ExtraNeiliAllocationProgress = new IntList(other.ExtraNeiliAllocationProgress);
		if (other.TaiwuQiArtStrategyList != null)
		{
			List<QiArtStrategyDisplayData> item = other.TaiwuQiArtStrategyList;
			int elementsCount = item.Count;
			TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuQiArtStrategyList.Add(new QiArtStrategyDisplayData(item[i]));
			}
		}
		else
		{
			TaiwuQiArtStrategyList = null;
		}
		ExtraNeiliTotalRange = other.ExtraNeiliTotalRange;
		ExtraNeiliAllocationTotal = new IntList(other.ExtraNeiliAllocationTotal);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatSkillNeigongLoopInformation other)
	{
		ReferenceSkillList = ((other.ReferenceSkillList == null) ? null : new List<short>(other.ReferenceSkillList));
		ExtraNeiliAllocationProgress = new IntList(other.ExtraNeiliAllocationProgress);
		if (other.TaiwuQiArtStrategyList != null)
		{
			List<QiArtStrategyDisplayData> item = other.TaiwuQiArtStrategyList;
			int elementsCount = item.Count;
			TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuQiArtStrategyList.Add(new QiArtStrategyDisplayData(item[i]));
			}
		}
		else
		{
			TaiwuQiArtStrategyList = null;
		}
		ExtraNeiliTotalRange = other.ExtraNeiliTotalRange;
		ExtraNeiliAllocationTotal = new IntList(other.ExtraNeiliAllocationTotal);
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
		totalSize = ((ReferenceSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReferenceSkillList.Count)));
		totalSize += ExtraNeiliAllocationProgress.GetSerializedSize();
		totalSize = ((TaiwuQiArtStrategyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * TaiwuQiArtStrategyList.Count)));
		totalSize += ExtraNeiliAllocationTotal.GetSerializedSize();
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
		if (ReferenceSkillList != null)
		{
			int elementsCount = ReferenceSkillList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ReferenceSkillList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize = ExtraNeiliAllocationProgress.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (TaiwuQiArtStrategyList != null)
		{
			int elementsCount2 = TaiwuQiArtStrategyList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += TaiwuQiArtStrategyList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.Serialize(pCurrData, ExtraNeiliTotalRange);
		int fieldSize2 = ExtraNeiliAllocationTotal.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ReferenceSkillList == null)
			{
				ReferenceSkillList = new List<short>(elementsCount);
			}
			else
			{
				ReferenceSkillList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ReferenceSkillList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			ReferenceSkillList?.Clear();
		}
		pCurrData += ExtraNeiliAllocationProgress.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TaiwuQiArtStrategyList == null)
			{
				TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount2);
			}
			else
			{
				TaiwuQiArtStrategyList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				QiArtStrategyDisplayData element = new QiArtStrategyDisplayData();
				pCurrData += element.Deserialize(pCurrData);
				TaiwuQiArtStrategyList.Add(element);
			}
		}
		else
		{
			TaiwuQiArtStrategyList?.Clear();
		}
		pCurrData += SerializationHelper.Deserialize(pCurrData, out ExtraNeiliTotalRange);
		pCurrData += ExtraNeiliAllocationTotal.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
