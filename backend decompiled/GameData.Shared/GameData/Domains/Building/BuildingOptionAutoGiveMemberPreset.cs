using System;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑自动指派预设
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class BuildingOptionAutoGiveMemberPreset : ISerializableGameData
{
	/// <summary>
	/// 影响范围组成
	/// </summary>
	[Flags]
	public enum InfluenceRangeFlag
	{
		/// <summary>
		/// 领袖
		/// </summary>
		Leader = 1,
		/// <summary>
		/// 成员
		/// </summary>
		Member = 2
	}

	/// <summary>
	/// 选取规则
	/// </summary>
	public enum PickRule
	{
		/// <summary>
		/// 收益优先
		/// </summary>
		ManageFirst,
		/// <summary>
		/// 资质优先
		/// </summary>
		QualificationFirst,
		/// <summary>
		/// 研读优先
		/// </summary>
		ReadingFirst,
		/// <summary>
		/// （学徒）资质最高优先
		/// 需注意，这个按钮是新加的，前端按钮摆放顺序是0312而不是0123
		/// </summary>
		QualificationMax
	}

	/// <summary>
	/// 身份规则
	/// </summary>
	[Flags]
	public enum RoleRule : sbyte
	{
		/// <summary>
		/// 无规则
		/// </summary>
		None = 0,
		/// <summary>
		/// 仅符合身份
		/// </summary>
		OnlyRole = 1,
		/// <summary>
		/// 允许孩童
		/// </summary>
		AllowChild = 2,
		/// <summary>
		/// 排除身份
		/// </summary>
		NotAllowRole = 4,
		/// <summary>
		/// 允许潜力已尽
		/// </summary>
		AllowNoPotential = 8,
		/// <summary>
		/// 允许无可研读
		/// </summary>
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

	/// <summary>
	/// 影响范围
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte InfluenceRange = 3;

	/// <summary>
	/// 领袖规则
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte PickRuleForLeader;

	/// <summary>
	/// 组员规则
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte PickRuleForMember;

	/// <summary>
	/// 自动指派成员的数量
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public int Amount = 6;

	/// <summary>
	/// 领袖的身份限制规则
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public sbyte RoleRuleForLeader;

	/// <summary>
	/// 组员的身份限制规则
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte RoleRuleForMember = 30;

	/// <summary>
	/// 领袖的锁定人物，默认锁定
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	public bool LockCharForLeader = true;

	/// <summary>
	/// 组员的锁定人物，默认锁定
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingOptionAutoGiveMemberPreset()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
