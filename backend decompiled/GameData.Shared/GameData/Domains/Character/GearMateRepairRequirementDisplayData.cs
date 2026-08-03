using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 一次性给前端机关人修理显示需要的数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class GearMateRepairRequirementDisplayData : ISerializableGameData
{
	/// <summary>
	/// 机关人
	/// </summary>
	[SerializableGameDataField]
	public int GearMateId;

	/// <summary>
	/// 诊疗类型<see cref="T:GameData.Domains.Character.GearMateRepairType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte RepairType;

	/// <summary>
	/// 资源类型<see cref="F:GameData.Domains.Character.GearMateRepairRequirementDisplayData.ResourceType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ResourceType;

	/// <summary>
	/// 资源消耗
	/// </summary>
	[SerializableGameDataField]
	public int ResourceCost;

	/// <summary>
	/// 造诣类型<see cref="F:GameData.Domains.Character.GearMateRepairRequirementDisplayData.LifeSkillType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeSkillType;

	/// <summary>
	/// 造诣需要
	/// </summary>
	[SerializableGameDataField]
	public int AttainmentCount;

	/// <summary>
	/// 引子等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemGrade;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = GearMateId;
		byte* num = pData + 4;
		*num = (byte)RepairType;
		byte* num2 = num + 1;
		*num2 = (byte)ResourceType;
		byte* num3 = num2 + 1;
		*(int*)num3 = ResourceCost;
		byte* num4 = num3 + 4;
		*num4 = (byte)LifeSkillType;
		byte* num5 = num4 + 1;
		*(int*)num5 = AttainmentCount;
		byte* num6 = num5 + 4;
		*num6 = (byte)ItemGrade;
		int totalSize = (int)(num6 + 1 - pData);
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
		GearMateId = *(int*)pCurrData;
		pCurrData += 4;
		RepairType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceCost = *(int*)pCurrData;
		pCurrData += 4;
		LifeSkillType = (sbyte)(*pCurrData);
		pCurrData++;
		AttainmentCount = *(int*)pCurrData;
		pCurrData += 4;
		ItemGrade = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
