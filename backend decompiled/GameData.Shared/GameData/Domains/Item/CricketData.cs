using GameData.Combat.Cricket;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true)]
public class CricketData : ISerializableGameData
{
	[SerializableGameDataField]
	public short[] Injuries;

	[SerializableGameDataField]
	public short WinsCount;

	[SerializableGameDataField]
	public short LossesCount;

	[SerializableGameDataField]
	public short BestEnemyColorId;

	[SerializableGameDataField]
	public short BestEnemyPartId;

	[SerializableGameDataField]
	public int AgeProgress;

	[SerializableGameDataField]
	public short MaxAge;

	[SerializableGameDataField]
	public bool IsSmart;

	[SerializableGameDataField]
	public bool IsIdentified;

	[SerializableGameDataField]
	public int CricketValue;

	[SerializableGameDataField]
	public int Spirit;

	[SerializableGameDataField]
	public CricketSpiritProperty SpiritAddProperties;

	[SerializableGameDataField]
	public sbyte OriginState;

	[SerializableGameDataField]
	public int NameId;

	public short InjuryHp => Injuries[0];

	public short InjurySp => Injuries[1];

	public short InjuryVigor => Injuries[2];

	public short InjuryStrength => Injuries[3];

	public short InjuryBite => Injuries[4];

	public string AgeStr => AgeProgress.ToQuotientRemainderString(GlobalConfig.Instance.CricketAgeProgressPerYear);

	public bool NaturalDeath => AgeProgress >= MaxAge * GlobalConfig.Instance.CricketAgeProgressPerYear;

	public static implicit operator CricketInjury(CricketData data)
	{
		return new CricketInjury
		{
			Hp = data.InjuryHp,
			Sp = data.InjurySp,
			Vigor = data.InjuryVigor,
			Strength = data.InjuryStrength,
			Bite = data.InjuryBite
		};
	}

	public CricketData()
	{
	}

	public CricketData(CricketData other)
	{
		short[] item = other.Injuries;
		int elementsCount = item.Length;
		Injuries = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Injuries[i] = item[i];
		}
		WinsCount = other.WinsCount;
		LossesCount = other.LossesCount;
		BestEnemyColorId = other.BestEnemyColorId;
		BestEnemyPartId = other.BestEnemyPartId;
		AgeProgress = other.AgeProgress;
		MaxAge = other.MaxAge;
		IsSmart = other.IsSmart;
		IsIdentified = other.IsIdentified;
		CricketValue = other.CricketValue;
		Spirit = other.Spirit;
		SpiritAddProperties = new CricketSpiritProperty(other.SpiritAddProperties);
		OriginState = other.OriginState;
		NameId = other.NameId;
	}

	public void Assign(CricketData other)
	{
		short[] item = other.Injuries;
		int elementsCount = item.Length;
		Injuries = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Injuries[i] = item[i];
		}
		WinsCount = other.WinsCount;
		LossesCount = other.LossesCount;
		BestEnemyColorId = other.BestEnemyColorId;
		BestEnemyPartId = other.BestEnemyPartId;
		AgeProgress = other.AgeProgress;
		MaxAge = other.MaxAge;
		IsSmart = other.IsSmart;
		IsIdentified = other.IsIdentified;
		CricketValue = other.CricketValue;
		Spirit = other.Spirit;
		SpiritAddProperties = new CricketSpiritProperty(other.SpiritAddProperties);
		OriginState = other.OriginState;
		NameId = other.NameId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 29;
		totalSize = ((Injuries == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Injuries.Length)));
		totalSize = ((SpiritAddProperties == null) ? (totalSize + 2) : (totalSize + (2 + SpiritAddProperties.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Injuries != null)
		{
			int elementsCount = Injuries.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = Injuries[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = WinsCount;
		pCurrData += 2;
		*(short*)pCurrData = LossesCount;
		pCurrData += 2;
		*(short*)pCurrData = BestEnemyColorId;
		pCurrData += 2;
		*(short*)pCurrData = BestEnemyPartId;
		pCurrData += 2;
		*(int*)pCurrData = AgeProgress;
		pCurrData += 4;
		*(short*)pCurrData = MaxAge;
		pCurrData += 2;
		*pCurrData = (IsSmart ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsIdentified ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CricketValue;
		pCurrData += 4;
		*(int*)pCurrData = Spirit;
		pCurrData += 4;
		if (SpiritAddProperties != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SpiritAddProperties.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)OriginState;
		pCurrData++;
		*(int*)pCurrData = NameId;
		pCurrData += 4;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Injuries == null || Injuries.Length != elementsCount)
			{
				Injuries = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Injuries[i] = ((short*)pCurrData)[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			Injuries = null;
		}
		WinsCount = *(short*)pCurrData;
		pCurrData += 2;
		LossesCount = *(short*)pCurrData;
		pCurrData += 2;
		BestEnemyColorId = *(short*)pCurrData;
		pCurrData += 2;
		BestEnemyPartId = *(short*)pCurrData;
		pCurrData += 2;
		AgeProgress = *(int*)pCurrData;
		pCurrData += 4;
		MaxAge = *(short*)pCurrData;
		pCurrData += 2;
		IsSmart = *pCurrData != 0;
		pCurrData++;
		IsIdentified = *pCurrData != 0;
		pCurrData++;
		CricketValue = *(int*)pCurrData;
		pCurrData += 4;
		Spirit = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SpiritAddProperties == null)
			{
				SpiritAddProperties = new CricketSpiritProperty();
			}
			pCurrData += SpiritAddProperties.Deserialize(pCurrData);
		}
		else
		{
			SpiritAddProperties = null;
		}
		OriginState = (sbyte)(*pCurrData);
		pCurrData++;
		NameId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
