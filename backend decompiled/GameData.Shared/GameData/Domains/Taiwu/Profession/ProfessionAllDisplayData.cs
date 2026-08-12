using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

/// <summary>
/// 角色志向展示数据
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ProfessionAllDisplayData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrProfessionId = 0;

		public const ushort ProfessionDataList = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CurrProfessionId", "ProfessionDataList" };
	}

	/// <summary>
	/// 当前志向
	/// </summary>
	[SerializableGameDataField]
	public int CurrProfessionId;

	/// <summary>
	/// 所有志向
	/// </summary>
	[SerializableGameDataField]
	public List<ProfessionData> ProfessionDataList;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (ProfessionDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < ProfessionDataList.Count; i++)
			{
				ProfessionData element = ProfessionDataList[i];
				totalSize = ((element == null) ? (totalSize + 4) : (totalSize + (4 + element.GetSerializedSize())));
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
		*(int*)pCurrData = CurrProfessionId;
		pCurrData += 4;
		if (ProfessionDataList != null)
		{
			int elementsCount = ProfessionDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ProfessionData element = ProfessionDataList[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 4;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= int.MaxValue);
					*(int*)intPtr = subDataSize;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
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
			CurrProfessionId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ProfessionDataList == null)
				{
					ProfessionDataList = new List<ProfessionData>(elementsCount);
				}
				else
				{
					ProfessionDataList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					int num2 = *(int*)pCurrData;
					pCurrData += 4;
					if (num2 > 0)
					{
						ProfessionData element = new ProfessionData();
						pCurrData += element.Deserialize(pCurrData);
						ProfessionDataList.Add(element);
					}
					else
					{
						ProfessionDataList.Add(null);
					}
				}
			}
			else
			{
				ProfessionDataList?.Clear();
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
