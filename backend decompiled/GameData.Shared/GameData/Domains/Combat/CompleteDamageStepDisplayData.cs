using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class CompleteDamageStepDisplayData : ISerializableGameData
{
	[SerializableGameDataField(ArrayElementsCount = 7)]
	public OuterAndInnerDamageStepDisplayData[] BodyPart = new OuterAndInnerDamageStepDisplayData[7];

	[SerializableGameDataField]
	public DamageStepDisplayData Mind;

	[SerializableGameDataField]
	public DamageStepDisplayData Fatal;

	[SerializableGameDataField]
	public DamageStepCollection CharacterBaseDamageSteps;

	[SerializableGameDataField]
	public sbyte CharacterConsummateLevel;

	public CompleteDamageStepDisplayData()
	{
	}

	public CompleteDamageStepDisplayData(CompleteDamageStepDisplayData other)
	{
		OuterAndInnerDamageStepDisplayData[] item = other.BodyPart;
		int elementsCount = item.Length;
		BodyPart = new OuterAndInnerDamageStepDisplayData[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			BodyPart[i] = item[i];
		}
		Mind = other.Mind;
		Fatal = other.Fatal;
		CharacterBaseDamageSteps = new DamageStepCollection(other.CharacterBaseDamageSteps);
		CharacterConsummateLevel = other.CharacterConsummateLevel;
	}

	public void Assign(CompleteDamageStepDisplayData other)
	{
		OuterAndInnerDamageStepDisplayData[] item = other.BodyPart;
		int elementsCount = item.Length;
		BodyPart = new OuterAndInnerDamageStepDisplayData[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			BodyPart[i] = item[i];
		}
		Mind = other.Mind;
		Fatal = other.Fatal;
		CharacterBaseDamageSteps = new DamageStepCollection(other.CharacterBaseDamageSteps);
		CharacterConsummateLevel = other.CharacterConsummateLevel;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 449;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		Tester.Assert(BodyPart.Length == 7);
		for (int i = 0; i < 7; i++)
		{
			pCurrData += BodyPart[i].Serialize(pCurrData);
		}
		pCurrData += Mind.Serialize(pCurrData);
		pCurrData += Fatal.Serialize(pCurrData);
		pCurrData += CharacterBaseDamageSteps.Serialize(pCurrData);
		*pCurrData = (byte)CharacterConsummateLevel;
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
		if (BodyPart == null || BodyPart.Length != 7)
		{
			BodyPart = new OuterAndInnerDamageStepDisplayData[7];
		}
		for (int i = 0; i < 7; i++)
		{
			OuterAndInnerDamageStepDisplayData element = default(OuterAndInnerDamageStepDisplayData);
			pCurrData += element.Deserialize(pCurrData);
			BodyPart[i] = element;
		}
		pCurrData += Mind.Deserialize(pCurrData);
		pCurrData += Fatal.Deserialize(pCurrData);
		if (CharacterBaseDamageSteps == null)
		{
			CharacterBaseDamageSteps = new DamageStepCollection();
		}
		pCurrData += CharacterBaseDamageSteps.Deserialize(pCurrData);
		CharacterConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
