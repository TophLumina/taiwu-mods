using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct CombatResultSnapshot : ISerializableGameData
{
	[SerializableGameDataField]
	public int Exp;

	[SerializableGameDataField]
	public ResourceInts Resource;

	[SerializableGameDataField]
	public int AreaSpiritualDebt;

	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	[SerializableGameDataField]
	public EatingItems EatingItemList;

	[SerializableGameDataField]
	public Injuries Injuries;

	[SerializableGameDataField]
	public PoisonInts Poisons;

	[SerializableGameDataField]
	public PoisonInts PoisonResists;

	[SerializableGameDataField]
	public byte ImmunePoisonExtra;

	[SerializableGameDataField]
	public MainAttributes MainAttribute;

	[SerializableGameDataField]
	public short DisorderOfQi;

	[SerializableGameDataField]
	public short ChangeOfQiDisorder;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short DisplayAge;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public sbyte BirthMonth;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public short HealthRecovery;

	[SerializableGameDataField]
	public byte CreatingType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 226;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		pCurrData += Resource.Serialize(pCurrData);
		*(int*)pCurrData = AreaSpiritualDebt;
		pCurrData += 4;
		*pCurrData = (byte)CanEatingMaxCount;
		pCurrData++;
		pCurrData += EatingItemList.Serialize(pCurrData);
		pCurrData += Injuries.Serialize(pCurrData);
		pCurrData += Poisons.Serialize(pCurrData);
		pCurrData += PoisonResists.Serialize(pCurrData);
		*pCurrData = ImmunePoisonExtra;
		pCurrData++;
		pCurrData += MainAttribute.Serialize(pCurrData);
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		*(short*)pCurrData = ChangeOfQiDisorder;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = DisplayAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*(short*)pCurrData = HealthRecovery;
		pCurrData += 2;
		*pCurrData = CreatingType;
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
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Resource.Deserialize(pCurrData);
		AreaSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		CanEatingMaxCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EatingItemList.Deserialize(pCurrData);
		pCurrData += Injuries.Deserialize(pCurrData);
		pCurrData += Poisons.Deserialize(pCurrData);
		pCurrData += PoisonResists.Deserialize(pCurrData);
		ImmunePoisonExtra = *pCurrData;
		pCurrData++;
		pCurrData += MainAttribute.Deserialize(pCurrData);
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		ChangeOfQiDisorder = *(short*)pCurrData;
		pCurrData += 2;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		DisplayAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		BirthMonth = (sbyte)(*pCurrData);
		pCurrData++;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		HealthRecovery = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
