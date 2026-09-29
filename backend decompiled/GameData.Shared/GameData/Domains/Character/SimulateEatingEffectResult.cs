using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForArchive = true)]
public class SimulateEatingEffectResult : ISerializableGameData
{
	[SerializableGameDataField]
	public int MaxDisorderOfQi;

	[SerializableGameDataField]
	public int MinDisorderOfQi;

	[SerializableGameDataField]
	public PoisonInts Poisons;

	[SerializableGameDataField]
	public int Health;

	[SerializableGameDataField]
	public Injuries Injuries;

	public SimulateEatingEffectResult()
	{
	}

	public SimulateEatingEffectResult(SimulateEatingEffectResult other)
	{
		MaxDisorderOfQi = other.MaxDisorderOfQi;
		MinDisorderOfQi = other.MinDisorderOfQi;
		Poisons = other.Poisons;
		Health = other.Health;
		Injuries = other.Injuries;
	}

	public void Assign(SimulateEatingEffectResult other)
	{
		MaxDisorderOfQi = other.MaxDisorderOfQi;
		MinDisorderOfQi = other.MinDisorderOfQi;
		Poisons = other.Poisons;
		Health = other.Health;
		Injuries = other.Injuries;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 52;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
