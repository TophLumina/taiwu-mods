using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 招募角色信息列表
/// </summary>
[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class RecruitCharacterDataList : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Items = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "Items" };
	}

	[SerializableGameDataField]
	public List<RecruitCharacterData> Items = new List<RecruitCharacterData>();

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (Items != null)
		{
			totalSize += 2;
			int elementsCount = Items.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				RecruitCharacterData element = Items[i];
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
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				RecruitCharacterData element = Items[i];
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Items == null)
				{
					Items = new List<RecruitCharacterData>(elementsCount);
				}
				else
				{
					Items.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num2 > 0)
					{
						RecruitCharacterData element = new RecruitCharacterData();
						pCurrData += element.Deserialize(pCurrData);
						Items.Add(element);
					}
					else
					{
						Items.Add(null);
					}
				}
			}
			else
			{
				Items?.Clear();
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
