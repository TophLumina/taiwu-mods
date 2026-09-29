using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class DamageCompareData : ISerializableGameData
{
	private const int MaxHitType = 3;

	[SerializableGameDataField]
	public bool IsAlly;

	[SerializableGameDataField]
	public short SkillId;

	[SerializableGameDataField]
	public int OuterAttackValue;

	[SerializableGameDataField]
	public int InnerAttackValue;

	[SerializableGameDataField]
	public int OuterDefendValue;

	[SerializableGameDataField]
	public int InnerDefendValue;

	[SerializableGameDataField]
	public int WeaponAttack;

	[SerializableGameDataField]
	public int WeaponDefend;

	[SerializableGameDataField]
	public int ArmorAttack;

	[SerializableGameDataField]
	public int ArmorDefend;

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly sbyte[] HitType = new sbyte[3];

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly int[] HitValue = new int[3];

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly int[] AvoidValue = new int[3];

	public DamageCompareData()
	{
		Clear();
	}

	public void Clear()
	{
		SkillId = -1;
		OuterAttackValue = (InnerAttackValue = (OuterDefendValue = (InnerDefendValue = -1)));
		WeaponAttack = (WeaponDefend = (ArmorAttack = (ArmorDefend = -1)));
		for (int i = 0; i < 3; i++)
		{
			HitType[i] = -1;
			HitValue[i] = -1;
			AvoidValue[i] = -1;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 62;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsAlly ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = SkillId;
		pCurrData += 2;
		*(int*)pCurrData = OuterAttackValue;
		pCurrData += 4;
		*(int*)pCurrData = InnerAttackValue;
		pCurrData += 4;
		*(int*)pCurrData = OuterDefendValue;
		pCurrData += 4;
		*(int*)pCurrData = InnerDefendValue;
		pCurrData += 4;
		*(int*)pCurrData = WeaponAttack;
		pCurrData += 4;
		*(int*)pCurrData = WeaponDefend;
		pCurrData += 4;
		*(int*)pCurrData = ArmorAttack;
		pCurrData += 4;
		*(int*)pCurrData = ArmorDefend;
		pCurrData += 4;
		for (int i = 0; i < 3; i++)
		{
			pCurrData[i] = (byte)HitType[i];
		}
		pCurrData += 3;
		for (int j = 0; j < 3; j++)
		{
			((int*)pCurrData)[j] = HitValue[j];
		}
		pCurrData += 12;
		for (int k = 0; k < 3; k++)
		{
			((int*)pCurrData)[k] = AvoidValue[k];
		}
		pCurrData += 12;
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
		IsAlly = *pCurrData != 0;
		pCurrData++;
		SkillId = *(short*)pCurrData;
		pCurrData += 2;
		OuterAttackValue = *(int*)pCurrData;
		pCurrData += 4;
		InnerAttackValue = *(int*)pCurrData;
		pCurrData += 4;
		OuterDefendValue = *(int*)pCurrData;
		pCurrData += 4;
		InnerDefendValue = *(int*)pCurrData;
		pCurrData += 4;
		WeaponAttack = *(int*)pCurrData;
		pCurrData += 4;
		WeaponDefend = *(int*)pCurrData;
		pCurrData += 4;
		ArmorAttack = *(int*)pCurrData;
		pCurrData += 4;
		ArmorDefend = *(int*)pCurrData;
		pCurrData += 4;
		for (int i = 0; i < 3; i++)
		{
			HitType[i] = (sbyte)pCurrData[i];
		}
		pCurrData += 3;
		for (int j = 0; j < 3; j++)
		{
			HitValue[j] = ((int*)pCurrData)[j];
		}
		pCurrData += 12;
		for (int k = 0; k < 3; k++)
		{
			AvoidValue[k] = ((int*)pCurrData)[k];
		}
		pCurrData += 12;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
