using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 已经获取过卡牌的技艺的书页
/// </summary>
public struct LifeSkillCombatReadBookPageData(LifeSkillCombatReadBookPageData other) : ISerializableGameData
{
	/// <summary>
	/// 页码列表
	/// </summary>
	[SerializableGameDataField]
	public List<byte> PageList = new List<byte>(other.PageList);

	public void Assign(LifeSkillCombatReadBookPageData other)
	{
		PageList = new List<byte>(other.PageList);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((PageList == null) ? (totalSize + 2) : (totalSize + (2 + PageList.Count)));
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
		if (PageList != null)
		{
			int elementsCount = PageList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = PageList[i];
			}
			pCurrData += elementsCount;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (PageList == null)
			{
				PageList = new List<byte>(elementsCount);
			}
			else
			{
				PageList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PageList.Add(pCurrData[i]);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			PageList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
