using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.TemporaryModification;

[SerializableGameData(NotForDisplayModule = true)]
public class CharacterModificationRecords : RawDataBlock
{
	public int Savepoint;

	public CharacterModificationRecords()
	{
		Savepoint = -1;
	}

	public CharacterModificationRecords(int initialCapacity)
		: base(initialCapacity)
	{
		Savepoint = -1;
	}

	public void RecordHappiness(sbyte oriValue, sbyte currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.Happiness, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveHappiness(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordBaseMorality(short oriValue, short currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.BaseMorality, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveBaseMorality(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordFeatureIds(List<short> oriValue, List<short> currValue)
	{
		List<ShortListModification> modifications = CalcDelta(oriValue, currValue);
		ushort dataSize = CalcDataSize(modifications);
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.FeatureIds, dataSize);
		WriteDelta(offset, modifications);
	}

	public unsafe static List<ShortListModification> RetrieveFeatureIds(byte* pModificationData, ushort dataSize)
	{
		return ReadDeltaShortList(pModificationData, dataSize);
	}

	public void RecordBaseMainAttributes(MainAttributes oriValue, MainAttributes currValue)
	{
		MainAttributes delta = currValue.Subtract(oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.BaseMainAttributes, dataSize);
		WriteDelta(offset, delta);
	}

	public unsafe static MainAttributes RetrieveBaseMainAttributes(byte* pModificationData)
	{
		return ReadDeltaMainAttributes(pModificationData);
	}

	public void RecordDisorderOfQi(short oriValue, short currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.DisorderOfQi, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveDisorderOfQi(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordInjuries(Injuries oriValue, Injuries currValue)
	{
		Injuries delta = currValue.Subtract(oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.Injuries, dataSize);
		WriteDelta(offset, delta);
	}

	public unsafe static Injuries RetrieveInjuries(byte* pModificationData)
	{
		return ReadDeltaInjuries(pModificationData);
	}

	public void RecordExtraNeili(int oriValue, int currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.ExtraNeili, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveExtraNeili(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordConsummateLevel(sbyte oriValue, sbyte currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.ConsummateLevel, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveConsummateLevel(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordBaseLifeSkillQualifications(ref LifeSkillShorts oriValue, ref LifeSkillShorts currValue)
	{
		LifeSkillShorts delta = currValue.Subtract(ref oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.BaseLifeSkillQualifications, dataSize);
		WriteDelta(offset, ref delta);
	}

	public unsafe static LifeSkillShorts RetrieveBaseLifeSkillQualifications(byte* pModificationData)
	{
		return ReadDeltaLifeSkillShorts(pModificationData);
	}

	public void RecordBaseCombatSkillQualifications(ref CombatSkillShorts oriValue, ref CombatSkillShorts currValue)
	{
		CombatSkillShorts delta = currValue.Subtract(ref oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.BaseCombatSkillQualifications, dataSize);
		WriteDelta(offset, ref delta);
	}

	public unsafe static CombatSkillShorts RetrieveBaseCombatSkillQualifications(byte* pModificationData)
	{
		return ReadDeltaCombatSkillShorts(pModificationData);
	}

	public void RecordResources(ref ResourceInts oriValue, ref ResourceInts currValue)
	{
		ResourceInts delta = currValue.Subtract(ref oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.Resources, dataSize);
		WriteDelta(offset, ref delta);
	}

	public unsafe static ResourceInts RetrieveResources(byte* pModificationData)
	{
		return ReadDeltaResourceInts(pModificationData);
	}

	public void RecordCurrMainAttributes(MainAttributes oriValue, MainAttributes currValue)
	{
		MainAttributes delta = currValue.Subtract(oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.CurrMainAttributes, dataSize);
		WriteDelta(offset, delta);
	}

	public unsafe static MainAttributes RetrieveCurrMainAttributes(byte* pModificationData)
	{
		return ReadDeltaMainAttributes(pModificationData);
	}

	public void RecordPoisoned(ref PoisonInts oriValue, ref PoisonInts currValue)
	{
		PoisonInts delta = currValue.Subtract(ref oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.Poisoned, dataSize);
		WriteDelta(offset, ref delta);
	}

	public unsafe static PoisonInts RetrievePoisoned(byte* pModificationData)
	{
		return ReadDeltaPoisonInts(pModificationData);
	}

	public void RecordCurrNeili(int oriValue, int currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.CurrNeili, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveCurrNeili(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordExtraNeiliAllocation(NeiliAllocation oriValue, NeiliAllocation currValue)
	{
		NeiliAllocation delta = currValue.Subtract(oriValue);
		ushort dataSize = (ushort)delta.GetSerializedSize();
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.ExtraNeiliAllocation, dataSize);
		WriteDelta(offset, delta);
	}

	public unsafe static NeiliAllocation RetrieveExtraNeiliAllocation(byte* pModificationData)
	{
		return ReadDeltaNeiliAllocation(pModificationData);
	}

	public void RecordXiangshuInfection(byte oriValue, byte currValue)
	{
		int delta = currValue - oriValue;
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.XiangshuInfection, 4);
		WriteDelta(offset, delta);
	}

	public unsafe static int RetrieveXiangshuInfection(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordCurrAge(short oriValue, short currValue)
	{
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.CurrAge, 4);
		WriteDelta(offset, oriValue);
	}

	public unsafe static int RetrieveCurrAge(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void RecordHealth(short oriValue, short currValue)
	{
		int offset = BeginAddingRecord(RevertibleCharacterPropertyType.Health, 4);
		WriteDelta(offset, oriValue);
	}

	public unsafe static int RetrieveHealth(byte* pModificationData)
	{
		return ReadDeltaInt(pModificationData);
	}

	public void CreateSavepoint()
	{
		if (Savepoint >= 0)
		{
			throw new Exception("Cannot create savepoint when there is already a savepoint");
		}
		Savepoint = Size;
	}

	public void DeleteSavepoint()
	{
		if (Savepoint < 0)
		{
			throw new Exception("Cannot delete savepoint when there is no savepoint");
		}
		Savepoint = -1;
	}

	public unsafe (RevertibleCharacterPropertyType propertyType, int offset, ushort dataSize) Pop(byte* pRawData)
	{
		byte* pEnd = pRawData + Size;
		ushort dataSize = *((ushort*)pEnd - 1);
		Size -= 1 + dataSize + 2;
		if (Size < 0)
		{
			throw new Exception("Index of RawData out of range");
		}
		return (propertyType: (RevertibleCharacterPropertyType)pRawData[Size], offset: Size + 1, dataSize: dataSize);
	}

	private unsafe int BeginAddingRecord(RevertibleCharacterPropertyType propertyType, ushort dataSize)
	{
		int offset = Size;
		int newSize = Size + 1 + dataSize + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			*(int*)pCurrData = (int)propertyType;
			*(ushort*)(pCurrData + 1 + (int)dataSize) = dataSize;
		}
		return offset + 1;
	}

	private unsafe void WriteDelta(int offset, int delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			*(int*)pCurrData = delta;
		}
	}

	private unsafe static int ReadDeltaInt(byte* pModificationData)
	{
		return *(int*)pModificationData;
	}

	private static List<ShortListModification> CalcDelta(List<short> srcElements, List<short> destElements)
	{
		List<ShortListModification> modifications = new List<ShortListModification>();
		int srcIndex = 0;
		int destIndex = 0;
		int srcCount = srcElements.Count;
		int destCount = destElements.Count;
		short currIndex = 0;
		while (srcIndex < srcCount && destIndex < destCount)
		{
			short srcElement = srcElements[srcIndex];
			int index = destElements.IndexOf(srcElement, destIndex);
			if (index == destIndex)
			{
				srcIndex++;
				destIndex++;
				currIndex++;
				continue;
			}
			if (index < 0)
			{
				modifications.Add(new ShortListModification(1, currIndex, srcElement));
				srcIndex++;
				continue;
			}
			for (int i = destIndex; i < index; i++)
			{
				modifications.Add(new ShortListModification(0, currIndex++, destElements[i]));
			}
			srcIndex++;
			destIndex = index + 1;
			currIndex++;
		}
		if (srcIndex < srcCount)
		{
			for (int j = srcIndex; j < srcCount; j++)
			{
				modifications.Add(new ShortListModification(1, currIndex, srcElements[j]));
			}
		}
		else if (destIndex < destCount)
		{
			for (int k = destIndex; k < destCount; k++)
			{
				modifications.Add(new ShortListModification(0, currIndex++, destElements[k]));
			}
		}
		return modifications;
	}

	private static ushort CalcDataSize(List<ShortListModification> modifications)
	{
		int dataSize = ShortListModification.GetFixedSerializedSize() * modifications.Count;
		if (dataSize > 65535)
		{
			throw new Exception("Data size of modifications must be less than 64KB");
		}
		return (ushort)dataSize;
	}

	private unsafe void WriteDelta(int offset, List<ShortListModification> modifications)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int i = 0;
			for (int elementsCount = modifications.Count; i < elementsCount; i++)
			{
				pCurrData += modifications[i].Serialize(pCurrData);
			}
		}
	}

	private unsafe static List<ShortListModification> ReadDeltaShortList(byte* pModificationData, ushort dataSize)
	{
		int elementsCount = dataSize / ShortListModification.GetFixedSerializedSize();
		Tester.Assert(ShortListModification.GetFixedSerializedSize() * elementsCount == dataSize);
		List<ShortListModification> modifications = new List<ShortListModification>();
		byte* pCurrData = pModificationData;
		for (int i = 0; i < elementsCount; i++)
		{
			ShortListModification modification = default(ShortListModification);
			pCurrData += modification.Deserialize(pCurrData);
			modifications.Add(modification);
		}
		return modifications;
	}

	private unsafe void WriteDelta(int offset, MainAttributes delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static MainAttributes ReadDeltaMainAttributes(byte* pModificationData)
	{
		MainAttributes delta = default(MainAttributes);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, Injuries delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static Injuries ReadDeltaInjuries(byte* pModificationData)
	{
		Injuries delta = default(Injuries);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, ref LifeSkillShorts delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static LifeSkillShorts ReadDeltaLifeSkillShorts(byte* pModificationData)
	{
		LifeSkillShorts delta = default(LifeSkillShorts);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, ref CombatSkillShorts delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static CombatSkillShorts ReadDeltaCombatSkillShorts(byte* pModificationData)
	{
		CombatSkillShorts delta = default(CombatSkillShorts);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, ref ResourceInts delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static ResourceInts ReadDeltaResourceInts(byte* pModificationData)
	{
		ResourceInts delta = default(ResourceInts);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, ref PoisonInts delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static PoisonInts ReadDeltaPoisonInts(byte* pModificationData)
	{
		PoisonInts delta = default(PoisonInts);
		delta.Deserialize(pModificationData);
		return delta;
	}

	private unsafe void WriteDelta(int offset, NeiliAllocation delta)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			delta.Serialize(pCurrData);
		}
	}

	private unsafe static NeiliAllocation ReadDeltaNeiliAllocation(byte* pModificationData)
	{
		NeiliAllocation delta = default(NeiliAllocation);
		delta.Deserialize(pModificationData);
		return delta;
	}
}
