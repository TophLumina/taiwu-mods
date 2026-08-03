using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true)]
public class PregnantState : ISerializableGameData
{
	[SerializableGameDataField(CollectionMaxElementsCount = 255)]
	public List<short> MotherFeatureIds;

	[SerializableGameDataField]
	public bool CreateMotherRelation;

	[SerializableGameDataField]
	public bool CreateFatherRelation;

	[SerializableGameDataField]
	public int FatherId;

	[SerializableGameDataField(CollectionMaxElementsCount = 255)]
	public List<short> FatherFeatureIds;

	[SerializableGameDataField]
	public Genome FatherGenome;

	[SerializableGameDataField]
	public int ExpectedBirthDate;

	[SerializableGameDataField]
	public bool IsHuman;

	public PregnantState(Character mother, Character father, bool isRaped)
	{
		MotherFeatureIds = new List<short>(mother.GetFeatureIds());
		CreateMotherRelation = true;
		if (father != null)
		{
			CreateFatherRelation = !isRaped;
			FatherId = father.GetId();
			FatherFeatureIds = new List<short>(father.GetFeatureIds());
			FatherGenome = father.GetGenome();
		}
		else
		{
			CreateFatherRelation = false;
			FatherId = -1;
		}
	}

	public static bool CheckPregnant(IRandomSource random, Character father, Character mother, bool isRape)
	{
		sbyte baseFertility = (sbyte)(isRape ? 20 : 60);
		int fatherId = father.GetId();
		int motherId = mother.GetId();
		if (!Character.CheckMakeLoveRole(father, mother))
		{
			return false;
		}
		if (mother.GetFeatureIds().Contains(198))
		{
			return false;
		}
		if (DomainManager.Character.TryGetElement_PregnancyLockEndDates(motherId, out var _))
		{
			return false;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		bool anyTaiwu = motherId == taiwuCharId || fatherId == taiwuCharId;
		int divisor = (anyTaiwu ? 20 : 40);
		short fatherFertility = father.GetFertility();
		int fatherChildCount = DomainManager.Character.GetRelatedCharIds(fatherId, 2).Count;
		if (fatherFertility / divisor < fatherChildCount)
		{
			return false;
		}
		short motherFertility = mother.GetFertility();
		int motherChildCount = DomainManager.Character.GetRelatedCharIds(motherId, 2).Count;
		if (motherFertility / divisor < motherChildCount)
		{
			return false;
		}
		if (anyTaiwu)
		{
			return random.CheckPercentProb(baseFertility * fatherFertility * motherFertility / 10000);
		}
		int chance = baseFertility * fatherFertility * motherFertility / 10000;
		if (father.GetOrganizationInfo().OrgTemplateId == 16 || mother.GetOrganizationInfo().OrgTemplateId == 16)
		{
			int homelessCount = DomainManager.Building.GetHomeless().GetCount();
			if (homelessCount > 0)
			{
				chance /= 10 * homelessCount;
			}
		}
		return random.CheckPercentProb(chance);
	}

	public override string ToString()
	{
		return $"{{{{Father:{FatherId}, ExpectedBirthDate:{ExpectedBirthDate}, IsHuman:{IsHuman}}}";
	}

	public PregnantState()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 75;
		totalSize = ((MotherFeatureIds == null) ? (totalSize + 1) : (totalSize + (1 + 2 * MotherFeatureIds.Count)));
		totalSize = ((FatherFeatureIds == null) ? (totalSize + 1) : (totalSize + (1 + 2 * FatherFeatureIds.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (MotherFeatureIds != null)
		{
			int elementsCount = MotherFeatureIds.Count;
			Tester.Assert(elementsCount <= 255);
			*pCurrData = (byte)elementsCount;
			pCurrData++;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = MotherFeatureIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*pCurrData = 0;
			pCurrData++;
		}
		*pCurrData = (CreateMotherRelation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (CreateFatherRelation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = FatherId;
		pCurrData += 4;
		if (FatherFeatureIds != null)
		{
			int elementsCount2 = FatherFeatureIds.Count;
			Tester.Assert(elementsCount2 <= 255);
			*pCurrData = (byte)elementsCount2;
			pCurrData++;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = FatherFeatureIds[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*pCurrData = 0;
			pCurrData++;
		}
		pCurrData += FatherGenome.Serialize(pCurrData);
		*(int*)pCurrData = ExpectedBirthDate;
		pCurrData += 4;
		*pCurrData = (IsHuman ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		byte elementsCount = *pCurrData;
		pCurrData++;
		if (elementsCount > 0)
		{
			if (MotherFeatureIds == null)
			{
				MotherFeatureIds = new List<short>(elementsCount);
			}
			else
			{
				MotherFeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				MotherFeatureIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			MotherFeatureIds?.Clear();
		}
		CreateMotherRelation = *pCurrData != 0;
		pCurrData++;
		CreateFatherRelation = *pCurrData != 0;
		pCurrData++;
		FatherId = *(int*)pCurrData;
		pCurrData += 4;
		byte elementsCount2 = *pCurrData;
		pCurrData++;
		if (elementsCount2 > 0)
		{
			if (FatherFeatureIds == null)
			{
				FatherFeatureIds = new List<short>(elementsCount2);
			}
			else
			{
				FatherFeatureIds.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				FatherFeatureIds.Add(((short*)pCurrData)[j]);
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			FatherFeatureIds?.Clear();
		}
		pCurrData += FatherGenome.Deserialize(pCurrData);
		ExpectedBirthDate = *(int*)pCurrData;
		pCurrData += 4;
		IsHuman = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
