using System;
using GameData.Common;
using GameData.Serializer;

namespace GameData.Domains.Organization;

[SerializableGameData(NotForDisplayModule = true)]
public class CivilianSettlementCharacter : SettlementCharacter, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint OrgTemplateId_Offset = 4u;

		public const int OrgTemplateId_Size = 1;

		public const uint SettlementId_Offset = 5u;

		public const int SettlementId_Size = 2;

		public const uint ApprovedTaiwu_Offset = 7u;

		public const int ApprovedTaiwu_Size = 1;

		public const uint InfluencePower_Offset = 8u;

		public const int InfluencePower_Size = 2;

		public const uint InfluencePowerBonus_Offset = 10u;

		public const int InfluencePowerBonus_Size = 2;
	}

	public const int FixedSize = 12;

	public const int DynamicCount = 0;

	private static readonly ushort[] ArchiveFieldIds = new ushort[6] { 0, 1, 2, 3, 4, 5 };

	private static readonly int[] FixedArchiveFieldSizes = new int[6] { 4, 1, 2, 1, 2, 2 };

	public CivilianSettlementCharacter(int charId, sbyte orgTemplateId, short settlementId)
		: base(charId, orgTemplateId, settlementId)
	{
	}

	public override void SetSettlementId(short settlementId, DataContext context)
	{
		SettlementId = settlementId;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public override void SetApprovedTaiwu(bool approvedTaiwu, DataContext context)
	{
		ApprovedTaiwu = approvedTaiwu;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public override void SetInfluencePower(short influencePower, DataContext context)
	{
		InfluencePower = influencePower;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public override void SetInfluencePowerBonus(short influencePowerBonus, DataContext context)
	{
		InfluencePowerBonus = influencePowerBonus;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public CivilianSettlementCharacter()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		return 12;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*pCurrData = (byte)OrgTemplateId;
		pCurrData++;
		*(short*)pCurrData = SettlementId;
		pCurrData += 2;
		*pCurrData = (ApprovedTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = InfluencePower;
		pCurrData += 2;
		*(short*)pCurrData = InfluencePowerBonus;
		pCurrData += 2;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				Id = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 1:
				OrgTemplateId = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 2:
				SettlementId = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 3:
				ApprovedTaiwu = *pCurrData != 0;
				pCurrData++;
				continue;
			case 4:
				InfluencePower = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 5:
				InfluencePowerBonus = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			}
			if (fieldIndex < fixedFieldSizes.Length)
			{
				int fieldSize = fixedFieldSizes[fieldIndex];
				pCurrData += fieldSize;
			}
			else
			{
				int fieldSize2 = *(int*)pCurrData;
				pCurrData += 4;
				pCurrData += fieldSize2;
			}
		}
		return (int)(pCurrData - pData);
	}
}
