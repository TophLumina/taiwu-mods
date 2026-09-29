using System;
using GameData.Domains.Character.AvatarSystem;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[Serializable]
[SerializableGameData(NotRestrictCollectionSerializedSize = true, IsExtensible = true)]
public class AvatarRelatedData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort AvatarData = 0;

		public const ushort DisplayAge = 1;

		public const ushort ClothingDisplayId = 2;

		public const ushort HasNewGoods = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "AvatarData", "DisplayAge", "ClothingDisplayId", "HasNewGoods" };
	}

	[SerializableGameDataField]
	public AvatarData AvatarData;

	[SerializableGameDataField]
	public short DisplayAge;

	[SerializableGameDataField]
	public short ClothingDisplayId;

	[SerializableGameDataField]
	public bool HasNewGoods;

	public AvatarRelatedData()
	{
	}

	public AvatarRelatedData(AvatarRelatedData other)
	{
		AvatarData = new AvatarData(other.AvatarData);
		DisplayAge = other.DisplayAge;
		ClothingDisplayId = other.ClothingDisplayId;
		HasNewGoods = other.HasNewGoods;
	}

	public void Assign(AvatarRelatedData other)
	{
		AvatarData = new AvatarData(other.AvatarData);
		DisplayAge = other.DisplayAge;
		ClothingDisplayId = other.ClothingDisplayId;
		HasNewGoods = other.HasNewGoods;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((AvatarData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (AvatarData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = DisplayAge;
		pCurrData += 2;
		*(short*)pCurrData = ClothingDisplayId;
		pCurrData += 2;
		*pCurrData = (HasNewGoods ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (AvatarData == null)
				{
					AvatarData = new AvatarData();
				}
				pCurrData += AvatarData.Deserialize(pCurrData);
			}
			else
			{
				AvatarData = null;
			}
		}
		if (num > 1)
		{
			DisplayAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			ClothingDisplayId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 3)
		{
			HasNewGoods = *pCurrData != 0;
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
