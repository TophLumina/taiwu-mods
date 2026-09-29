using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true)]
public class PossessionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort SoulCharId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "SoulCharId" };
	}

	[SerializableGameDataField]
	public int SoulCharId;

	[SerializableGameDataField]
	public List<int> SoulCharIds;

	public PossessionData(int soulCharId)
	{
		SoulCharId = soulCharId;
	}

	public PossessionData(List<int> soulCharIds)
	{
		SoulCharIds = soulCharIds;
	}

	public PossessionData()
	{
	}

	public PossessionData(PossessionData other)
	{
		SoulCharId = other.SoulCharId;
	}

	public void Assign(PossessionData other)
	{
		SoulCharId = other.SoulCharId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(int*)num = SoulCharId;
		int totalSize = (int)(num + 4 - pData);
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
			SoulCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
