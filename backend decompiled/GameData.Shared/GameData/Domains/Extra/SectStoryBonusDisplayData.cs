using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 地区主线 - 峨眉 - 突破格加成显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SectStoryBonusDisplayData : ISerializableGameData
{
	/// <summary>
	/// 功法 ID
	/// </summary>
	[SerializableGameDataField]
	public short CombatSkillId;

	/// <summary>
	/// 已设置的额外突破格
	/// </summary>
	[SerializableGameDataField]
	public List<short> BreakBonusTemplateIds;

	/// <summary>
	/// 额外加成，根据 <see cref="F:GameData.Domains.Extra.SectStoryBonusDisplayData.BreakBonusTemplateIds" /> 计算的值
	/// </summary>
	[SerializableGameDataField]
	public SkillBreakBonusCollection ExtraBonus;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryBonusDisplayData()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((BreakBonusTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * BreakBonusTemplateIds.Count)));
		totalSize = ((ExtraBonus == null) ? (totalSize + 2) : (totalSize + (2 + ExtraBonus.GetSerializedSize())));
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
		*(short*)pCurrData = CombatSkillId;
		pCurrData += 2;
		if (BreakBonusTemplateIds != null)
		{
			int elementsCount = BreakBonusTemplateIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = BreakBonusTemplateIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ExtraBonus != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ExtraBonus.Serialize(pCurrData);
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
		CombatSkillId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BreakBonusTemplateIds == null)
			{
				BreakBonusTemplateIds = new List<short>(elementsCount);
			}
			else
			{
				BreakBonusTemplateIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				BreakBonusTemplateIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			BreakBonusTemplateIds?.Clear();
		}
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ExtraBonus == null)
			{
				ExtraBonus = new SkillBreakBonusCollection();
			}
			pCurrData += ExtraBonus.Deserialize(pCurrData);
		}
		else
		{
			ExtraBonus = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
