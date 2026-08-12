using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 娱乐大众
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class EntertainingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 行动效果数目
	/// </summary>
	[SerializableGameDataField]
	public int ActionEffectCount;

	/// <summary>
	/// 行动效果的值
	/// </summary>
	[SerializableGameDataField]
	public int ActionEffectValue;

	/// <summary>
	/// 元鸡影响好感人数
	/// </summary>
	[SerializableGameDataField]
	public int ExtraPeopleCount;

	/// <summary>
	/// 元鸡影响好感程度
	/// </summary>
	[SerializableGameDataField]
	public int RelationChange;

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = ActionEffectCount;
		byte* num = pData + 4;
		*(int*)num = ActionEffectValue;
		byte* num2 = num + 4;
		*(int*)num2 = ExtraPeopleCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = RelationChange;
		int totalSize = (int)(num3 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ActionEffectCount = *(int*)pCurrData;
		pCurrData += 4;
		ActionEffectValue = *(int*)pCurrData;
		pCurrData += 4;
		ExtraPeopleCount = *(int*)pCurrData;
		pCurrData += 4;
		RelationChange = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
