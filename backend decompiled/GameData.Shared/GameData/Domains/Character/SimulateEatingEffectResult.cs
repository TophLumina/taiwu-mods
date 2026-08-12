using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 模拟服食结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SimulateEatingEffectResult : ISerializableGameData
{
	/// <summary>
	/// 内息值上限
	/// </summary>
	[SerializableGameDataField]
	public int MaxDisorderOfQi;

	/// <summary>
	/// 内息值下限
	/// </summary>
	[SerializableGameDataField]
	public int MinDisorderOfQi;

	/// <summary>
	/// 中毒量
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts Poisons;

	/// <summary>
	/// 健康
	/// </summary>
	[SerializableGameDataField]
	public int Health;

	/// <summary>
	/// 伤势
	/// </summary>
	[SerializableGameDataField]
	public Injuries Injuries;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SimulateEatingEffectResult()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SimulateEatingEffectResult(SimulateEatingEffectResult other)
	{
		MaxDisorderOfQi = other.MaxDisorderOfQi;
		MinDisorderOfQi = other.MinDisorderOfQi;
		Poisons = other.Poisons;
		Health = other.Health;
		Injuries = other.Injuries;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SimulateEatingEffectResult other)
	{
		MaxDisorderOfQi = other.MaxDisorderOfQi;
		MinDisorderOfQi = other.MinDisorderOfQi;
		Poisons = other.Poisons;
		Health = other.Health;
		Injuries = other.Injuries;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 52;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = MaxDisorderOfQi;
		pCurrData += 4;
		*(int*)pCurrData = MinDisorderOfQi;
		pCurrData += 4;
		pCurrData += Poisons.Serialize(pCurrData);
		*(int*)pCurrData = Health;
		pCurrData += 4;
		pCurrData += Injuries.Serialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
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
		MaxDisorderOfQi = *(int*)pCurrData;
		pCurrData += 4;
		MinDisorderOfQi = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Poisons.Deserialize(pCurrData);
		Health = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Injuries.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
