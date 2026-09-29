using System;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class BuildingOptionAutoGiveMemberPreset : ISerializableGameData
{
	[Flags]
	public enum InfluenceRangeFlag
	{
		Leader = 1,
		Member = 2
	}

	public enum PickRule
	{
		ManageFirst,
		QualificationFirst,
		ReadingFirst,
		QualificationMax
	}

	[Flags]
	public enum RoleRule : sbyte
	{
		None = 0,
		OnlyRole = 1,
		AllowChild = 2,
		NotAllowRole = 4,
		AllowNoPotential = 8,
		AllowNoReadableBook = 0x10
	}

	public static class FieldIds
	{
		public const ushort InfluenceRange = 0;

		public const ushort PickRuleForLeader = 1;

		public const ushort PickRuleForMember = 2;

		public const ushort Amount = 3;

		public const ushort RoleRuleForLeader = 4;

		public const ushort RoleRuleForMember = 5;

		public const ushort LockCharForLeader = 6;

		public const ushort LockCharForMember = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "InfluenceRange", "PickRuleForLeader", "PickRuleForMember", "Amount", "RoleRuleForLeader", "RoleRuleForMember", "LockCharForLeader", "LockCharForMember" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte InfluenceRange = 3;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte PickRuleForLeader;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte PickRuleForMember;

	[SerializableGameDataField(FieldIndex = 3)]
	public int Amount = 6;

	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte RoleRuleForLeader;

	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte RoleRuleForMember = 30;

	[SerializableGameDataField(FieldIndex = 6)]
	public bool LockCharForLeader = true;

	[SerializableGameDataField(FieldIndex = 7)]
	public bool LockCharForMember = true;

	public bool GetIsInfluenceLeader()
	{
		return (InfluenceRange & 1) != 0;
	}

	public bool GetIsInfluenceMember()
	{
		return (InfluenceRange & 2) != 0;
	}

	public void SetIsInfluenceLeader(bool select)
	{
		if (select)
		{
			InfluenceRange |= 1;
		}
		else
		{
			InfluenceRange &= -2;
		}
	}

	public void SetIsInfluenceMember(bool select)
	{
		if (select)
		{
			InfluenceRange |= 2;
		}
		else
		{
			InfluenceRange &= -3;
		}
	}

	public BuildingOptionAutoGiveMemberPreset()
	{
	}

	public BuildingOptionAutoGiveMemberPreset(BuildingOptionAutoGiveMemberPreset other)
	{
		InfluenceRange = other.InfluenceRange;
		PickRuleForLeader = other.PickRuleForLeader;
		PickRuleForMember = other.PickRuleForMember;
		Amount = other.Amount;
		RoleRuleForLeader = other.RoleRuleForLeader;
		RoleRuleForMember = other.RoleRuleForMember;
		LockCharForLeader = other.LockCharForLeader;
		LockCharForMember = other.LockCharForMember;
	}

	public void Assign(BuildingOptionAutoGiveMemberPreset other)
	{
		InfluenceRange = other.InfluenceRange;
		PickRuleForLeader = other.PickRuleForLeader;
		PickRuleForMember = other.PickRuleForMember;
		Amount = other.Amount;
		RoleRuleForLeader = other.RoleRuleForLeader;
		RoleRuleForMember = other.RoleRuleForMember;
		LockCharForLeader = other.LockCharForLeader;
		LockCharForMember = other.LockCharForMember;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 8;
		byte* num = pData + 2;
		*num = (byte)InfluenceRange;
		byte* num2 = num + 1;
		*num2 = (byte)PickRuleForLeader;
		byte* num3 = num2 + 1;
		*num3 = (byte)PickRuleForMember;
		byte* num4 = num3 + 1;
		*(int*)num4 = Amount;
		byte* num5 = num4 + 4;
		*num5 = (byte)RoleRuleForLeader;
		byte* num6 = num5 + 1;
		*num6 = (byte)RoleRuleForMember;
		byte* num7 = num6 + 1;
		*num7 = (LockCharForLeader ? ((byte)1) : ((byte)0));
		byte* num8 = num7 + 1;
		*num8 = (LockCharForMember ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num8 + 1 - pData);
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
			InfluenceRange = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			PickRuleForLeader = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			PickRuleForMember = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 4)
		{
			RoleRuleForLeader = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 5)
		{
			RoleRuleForMember = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 6)
		{
			LockCharForLeader = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 7)
		{
			LockCharForMember = *pCurrData != 0;
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
