using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class ItemAutoOperationSettingData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort DiscardGroup = 0;

		public const ushort DisassembleGroup = 1;

		public const ushort DisassembleWhenDiscard = 2;

		public const ushort DiscardWhenDisassemble = 3;

		public const ushort DisassembleToolGrade = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "DiscardGroup", "DisassembleGroup", "DisassembleWhenDiscard", "DiscardWhenDisassemble", "DisassembleToolGrade" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemAutoOperationSettingGroup DiscardGroup;

	[SerializableGameDataField(FieldIndex = 1)]
	public ItemAutoOperationSettingGroup DisassembleGroup;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool DisassembleWhenDiscard;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool DiscardWhenDisassemble;

	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte DisassembleToolGrade;

	public void Init()
	{
		DiscardGroup = new ItemAutoOperationSettingGroup();
		DiscardGroup.Init(EItemAutoOperationType.Discard);
		DisassembleGroup = new ItemAutoOperationSettingGroup();
		DisassembleGroup.Init(EItemAutoOperationType.Disassemble);
	}

	public void ResetDiscard()
	{
		DiscardGroup.Init(EItemAutoOperationType.Discard);
	}

	public void ResetDisassemble()
	{
		DisassembleWhenDiscard = false;
		DiscardWhenDisassemble = false;
		DisassembleToolGrade = 0;
		DisassembleGroup.Init(EItemAutoOperationType.Disassemble);
	}

	public ItemAutoOperationSettingData()
	{
	}

	public ItemAutoOperationSettingData(ItemAutoOperationSettingData other)
	{
		DiscardGroup = new ItemAutoOperationSettingGroup(other.DiscardGroup);
		DisassembleGroup = new ItemAutoOperationSettingGroup(other.DisassembleGroup);
		DisassembleWhenDiscard = other.DisassembleWhenDiscard;
		DiscardWhenDisassemble = other.DiscardWhenDisassemble;
		DisassembleToolGrade = other.DisassembleToolGrade;
	}

	public void Assign(ItemAutoOperationSettingData other)
	{
		DiscardGroup = new ItemAutoOperationSettingGroup(other.DiscardGroup);
		DisassembleGroup = new ItemAutoOperationSettingGroup(other.DisassembleGroup);
		DisassembleWhenDiscard = other.DisassembleWhenDiscard;
		DiscardWhenDisassemble = other.DiscardWhenDisassemble;
		DisassembleToolGrade = other.DisassembleToolGrade;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((DiscardGroup == null) ? (totalSize + 2) : (totalSize + (2 + DiscardGroup.GetSerializedSize())));
		totalSize = ((DisassembleGroup == null) ? (totalSize + 2) : (totalSize + (2 + DisassembleGroup.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		if (DiscardGroup != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = DiscardGroup.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DisassembleGroup != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = DisassembleGroup.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (DisassembleWhenDiscard ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (DiscardWhenDisassemble ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)DisassembleToolGrade;
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
				DiscardGroup = new ItemAutoOperationSettingGroup();
				pCurrData += DiscardGroup.Deserialize(pCurrData);
			}
			else
			{
				DiscardGroup = null;
			}
		}
		if (num > 1)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				DisassembleGroup = new ItemAutoOperationSettingGroup();
				pCurrData += DisassembleGroup.Deserialize(pCurrData);
			}
			else
			{
				DisassembleGroup = null;
			}
		}
		if (num > 2)
		{
			DisassembleWhenDiscard = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			DiscardWhenDisassemble = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 4)
		{
			DisassembleToolGrade = (sbyte)(*pCurrData);
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
