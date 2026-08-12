using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 用于演出的摧破功法当前攻击序号和命中情况数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct SkillIndexAndHitData : ISerializableGameData
{
	/// <summary>
	/// 当前攻击序号
	/// </summary>
	[SerializableGameDataField]
	public int SkillIndex;

	/// <summary>
	/// 最终命中率
	/// </summary>
	[SerializableGameDataField]
	public int HitOdds;

	/// <summary>
	/// 是否命中，因存在强制命中与化解的机制，与 HitOdds 可能有偏差
	/// </summary>
	[SerializableGameDataField]
	public bool Hit;

	/// <summary>
	/// 无效值
	/// </summary>
	public static SkillIndexAndHitData Invalid => new SkillIndexAndHitData(-1, 0, hit: false);

	/// <summary>
	/// 构造方法
	/// </summary>
	public SkillIndexAndHitData(int skillIndex, int hitOdds, bool hit)
	{
		SkillIndex = skillIndex;
		HitOdds = hitOdds;
		Hit = hit;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SkillIndex;
		byte* num = pData + 4;
		*(int*)num = HitOdds;
		byte* num2 = num + 4;
		*num2 = (Hit ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num2 + 1 - pData);
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
		SkillIndex = *(int*)pCurrData;
		pCurrData += 4;
		HitOdds = *(int*)pCurrData;
		pCurrData += 4;
		Hit = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
