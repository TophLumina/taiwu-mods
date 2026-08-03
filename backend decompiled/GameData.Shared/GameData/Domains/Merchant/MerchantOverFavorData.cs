using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

/// <summary>
/// 一个商会的全部超好感数据
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class MerchantOverFavorData : ISerializableGameData, ICloneable
{
	private static class FieldIds
	{
		public const ushort MerchantOverFavorLevelDataArray = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "MerchantOverFavorLevelDataArray" };
	}

	/// <summary>
	/// 所有等级的超好感数据
	/// </summary>
	[SerializableGameDataField]
	public MerchantOverFavorLevelData[] MerchantOverFavorLevelDataArray = new MerchantOverFavorLevelData[7];

	public object Clone()
	{
		MerchantOverFavorData result = new MerchantOverFavorData
		{
			MerchantOverFavorLevelDataArray = new MerchantOverFavorLevelData[MerchantOverFavorLevelDataArray.Length]
		};
		for (int i = 0; i < MerchantOverFavorLevelDataArray.Length; i++)
		{
			MerchantOverFavorLevelData originLevelData = MerchantOverFavorLevelDataArray[i];
			result.MerchantOverFavorLevelDataArray[i] = originLevelData?.Clone() as MerchantOverFavorLevelData;
		}
		return result;
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
		if (MerchantOverFavorLevelDataArray != null)
		{
			totalSize += 2;
			int elementsCount = MerchantOverFavorLevelDataArray.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				MerchantOverFavorLevelData element = MerchantOverFavorLevelDataArray[i];
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
		if (MerchantOverFavorLevelDataArray != null)
		{
			int elementsCount = MerchantOverFavorLevelDataArray.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				MerchantOverFavorLevelData element = MerchantOverFavorLevelDataArray[i];
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
				if (MerchantOverFavorLevelDataArray == null || MerchantOverFavorLevelDataArray.Length != elementsCount)
				{
					MerchantOverFavorLevelDataArray = new MerchantOverFavorLevelData[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num2 > 0)
					{
						MerchantOverFavorLevelData element = MerchantOverFavorLevelDataArray[i] ?? new MerchantOverFavorLevelData();
						pCurrData += element.Deserialize(pCurrData);
						MerchantOverFavorLevelDataArray[i] = element;
					}
					else
					{
						MerchantOverFavorLevelDataArray[i] = null;
					}
				}
			}
			else
			{
				MerchantOverFavorLevelDataArray = null;
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
