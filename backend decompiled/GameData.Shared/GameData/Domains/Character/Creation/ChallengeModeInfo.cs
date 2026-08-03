using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Creation;

/// <summary>
/// 玄狱难度信息
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class ChallengeModeInfo : ISerializableGameData
{
	/// <summary>
	/// 大道轮回角色特性奖励
	/// </summary>
	[SerializableGameDataField]
	public short ReincarnationBonusFeatureId = -1;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ChallengeModeInfo()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ChallengeModeInfo(ChallengeModeInfo other)
	{
		ReincarnationBonusFeatureId = other.ReincarnationBonusFeatureId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ChallengeModeInfo other)
	{
		ReincarnationBonusFeatureId = other.ReincarnationBonusFeatureId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = ReincarnationBonusFeatureId;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ReincarnationBonusFeatureId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
