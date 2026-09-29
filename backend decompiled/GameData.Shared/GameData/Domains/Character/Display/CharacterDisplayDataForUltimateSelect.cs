using System;
using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CharacterDisplayDataForUltimateSelect : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[SerializableGameDataField]
	public short Charm;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public sbyte HappinessType;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public sbyte FameType;

	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	[SerializableGameDataField]
	public bool IsReclusiveChar;

	[SerializableGameDataField]
	public FullBlockName LocationNameData;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public int BirthDate;

	[SerializableGameDataField]
	public short PreexistenceCharCount;

	[SerializableGameDataField]
	public sbyte DefeatMarkCount;

	[SerializableGameDataField]
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

	[SerializableGameDataField]
	public int ConsummateLevel;

	[SerializableGameDataField]
	public sbyte BirthMonth;

	[SerializableGameDataField]
	public MainAttributes MaxMainAttributes;

	[SerializableGameDataField]
	public OuterAndInnerInts Penetrations;

	[SerializableGameDataField]
	public OuterAndInnerInts PenetrationResists;

	[SerializableGameDataField]
	public HitOrAvoidInts HitValues;

	[SerializableGameDataField]
	public HitOrAvoidInts AvoidValues;

	[SerializableGameDataField]
	public short DisorderOfQi;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public ResourceInts Resources;

	[SerializableGameDataField]
	public int CurrInventoryLoad;

	[SerializableGameDataField]
	public int MaxInventoryLoad;

	[SerializableGameDataField]
	public sbyte KidnapCount;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportionOfFiveElements;

	[SerializableGameDataField]
	public sbyte VillagerNeedWaitTime;

	[SerializableGameDataField]
	public bool Trapped;

	[SerializableGameDataField]
	public bool Invited;

	[SerializableGameDataField]
	public bool PrioritizeActionOverInvite;

	private Dictionary<int, (int, string)> _valuesCache;

	public (int, string) this[int sortingTypeId]
	{
		get
		{
			if (!_valuesCache.TryGetValue(sortingTypeId, out var tuple))
			{
				return (0, string.Empty);
			}
			return tuple;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 270;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize += LocationNameData.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*pCurrData = CreatingType;
		pCurrData++;
		pCurrData += NameRelatedData.Serialize(pCurrData);
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = PhysiologicalAge;
		pCurrData += 2;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = (byte)HappinessType;
		pCurrData++;
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)FameType;
		pCurrData++;
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		*pCurrData = (IsReclusiveChar ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize2 = LocationNameData.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*(short*)pCurrData = PreexistenceCharCount;
		pCurrData += 2;
		*pCurrData = (byte)DefeatMarkCount;
		pCurrData++;
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
		*(int*)pCurrData = ConsummateLevel;
		pCurrData += 4;
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		pCurrData += MaxMainAttributes.Serialize(pCurrData);
		pCurrData += Penetrations.Serialize(pCurrData);
		pCurrData += PenetrationResists.Serialize(pCurrData);
		pCurrData += HitValues.Serialize(pCurrData);
		pCurrData += AvoidValues.Serialize(pCurrData);
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillGrowthType;
		pCurrData++;
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)CombatSkillGrowthType;
		pCurrData++;
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += Resources.Serialize(pCurrData);
		*(int*)pCurrData = CurrInventoryLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxInventoryLoad;
		pCurrData += 4;
		*pCurrData = (byte)KidnapCount;
		pCurrData++;
		pCurrData += NeiliProportionOfFiveElements.Serialize(pCurrData);
		*pCurrData = (byte)VillagerNeedWaitTime;
		pCurrData++;
		*pCurrData = (Trapped ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Invited ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (PrioritizeActionOverInvite ? ((byte)1) : ((byte)0));
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		CreatingType = *pCurrData;
		pCurrData++;
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		HappinessType = (sbyte)(*pCurrData);
		pCurrData++;
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		FameType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += OrganizationInfo.Deserialize(pCurrData);
		IsReclusiveChar = *pCurrData != 0;
		pCurrData++;
		pCurrData += LocationNameData.Deserialize(pCurrData);
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
		PreexistenceCharCount = *(short*)pCurrData;
		pCurrData += 2;
		DefeatMarkCount = (sbyte)(*pCurrData);
		pCurrData++;
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
		ConsummateLevel = *(int*)pCurrData;
		pCurrData += 4;
		BirthMonth = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += MaxMainAttributes.Deserialize(pCurrData);
		pCurrData += Penetrations.Deserialize(pCurrData);
		pCurrData += PenetrationResists.Deserialize(pCurrData);
		pCurrData += HitValues.Deserialize(pCurrData);
		pCurrData += AvoidValues.Deserialize(pCurrData);
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		LifeSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		CombatSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Personalities.Deserialize(pCurrData);
		pCurrData += Resources.Deserialize(pCurrData);
		CurrInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxInventoryLoad = *(int*)pCurrData;
		pCurrData += 4;
		KidnapCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += NeiliProportionOfFiveElements.Deserialize(pCurrData);
		VillagerNeedWaitTime = (sbyte)(*pCurrData);
		pCurrData++;
		Trapped = *pCurrData != 0;
		pCurrData++;
		Invited = *pCurrData != 0;
		pCurrData++;
		PrioritizeActionOverInvite = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public void InitValuesCache(Action<CharacterDisplayDataForUltimateSelect, Dictionary<int, (int, string)>> initCache)
	{
		if (_valuesCache == null)
		{
			_valuesCache = new Dictionary<int, (int, string)>();
			initCache(this, _valuesCache);
		}
	}
}
