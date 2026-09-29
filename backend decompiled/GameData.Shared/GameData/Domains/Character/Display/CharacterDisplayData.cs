using System;
using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Domains.Merchant;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public byte MonkType;

	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public short PhysiologicalAge;

	[Obsolete("Unless necessary, use PhysiologicalAge instead.")]
	[SerializableGameDataField]
	public short CurrAge;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public sbyte BehaviorType;

	[SerializableGameDataField]
	public sbyte FameType;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public bool IsApproveTaiwu;

	[SerializableGameDataField]
	public short ApproveTaiwu;

	[SerializableGameDataField]
	public short InfluencePower;

	[SerializableGameDataField]
	public int Contribution;

	[SerializableGameDataField]
	public int ContributionPerMonth;

	[SerializableGameDataField]
	public List<short> TitleIds;

	[SerializableGameDataField]
	public bool CompletelyInfected;

	[SerializableGameDataField]
	public byte ValidKidnapSlotCount;

	[SerializableGameDataField]
	public sbyte AliveState;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public int BirthDate;

	[SerializableGameDataField]
	public ulong ExternalRelationState;

	[SerializableGameDataField]
	public sbyte LegendaryBookOwnerState;

	[SerializableGameDataField]
	public List<sbyte> LegendaryBooks;

	[SerializableGameDataField]
	public int CustomDisplayNameId;

	[SerializableGameDataField]
	public bool IsXiangshuInfectedDemon;

	[SerializableGameDataField]
	public byte SettlementTreasuryGuardInfo;

	[SerializableGameDataField]
	public sbyte BountyPunishmentSeverity;

	[SerializableGameDataField]
	public sbyte BountyOrgTemplate;

	[SerializableGameDataField]
	public bool CanNotSpeak;

	[SerializableGameDataField]
	public bool IsFollowedByTaiwu;

	[SerializableGameDataField]
	public int NickNameId;

	[SerializableGameDataField]
	public int ExtraNameTextTemplateId;

	[SerializableGameDataField]
	public sbyte IdealSect;

	[SerializableGameDataField]
	public sbyte CurrOrgTemplate;

	[SerializableGameDataField]
	public uint DarkAshProtector;

	[SerializableGameDataField]
	public DarkAshCounter DarkAshCounter;

	[SerializableGameDataField]
	public CharacterDisplayData OrganizationMemberPotentialSuccessor;

	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	[SerializableGameDataField]
	public short Charm;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public sbyte HealthStateFlags;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public sbyte MerchantTemplateId;

	[SerializableGameDataField]
	public bool IsSameFactionWithTaiwu;

	[SerializableGameDataField]
	public int FortuneExtraLegacyPointWorth;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public int AttackMedal;

	[SerializableGameDataField]
	public int DefenceMedal;

	[SerializableGameDataField]
	public int WisdomMedal;

	[SerializableGameDataField]
	public short SamsaraCount;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public byte AgeAffector;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public int Alertness;

	[SerializableGameDataField]
	public sbyte MerchantType;

	[SerializableGameDataField]
	public MerchantExpData MerchantExpData;

	[SerializableGameDataField]
	public ProfessionData CurrentProfession;

	[SerializableGameDataField]
	public bool IsSearchedCharacter;

	[SerializableGameDataField]
	public Dictionary<short, bool> VisibleCharacterInteractionEventOptionDict;

	[SerializableGameDataField]
	public sbyte XiangshuType;

	[SerializableGameDataField]
	public int NoInteractionReason = -1;

	[SerializableGameDataField]
	public bool ShowGraveInfoInFollowingMode;

	public int GraveDuration
	{
		get
		{
			return Contribution;
		}
		set
		{
			Contribution = value;
		}
	}

	public int DeathDate
	{
		get
		{
			return ContributionPerMonth;
		}
		set
		{
			ContributionPerMonth = value;
		}
	}

	public bool IsSettlementTreasuryGuard => SettlementTreasuryGuardLevel != 0;

	public byte SettlementTreasuryGuardLevel => (byte)(SettlementTreasuryGuardInfo & 3);

	public bool SettlementTreasuryGuardWorking => (SettlementTreasuryGuardInfo & 4) != 0;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 166;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((TitleIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleIds.Count)));
		totalSize = ((LegendaryBooks == null) ? (totalSize + 2) : (totalSize + (2 + LegendaryBooks.Count)));
		totalSize = ((OrganizationMemberPotentialSuccessor == null) ? (totalSize + 2) : (totalSize + (2 + OrganizationMemberPotentialSuccessor.GetSerializedSize())));
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((MerchantExpData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantExpData.GetSerializedSize())));
		totalSize = ((CurrentProfession == null) ? (totalSize + 2) : (totalSize + (2 + CurrentProfession.GetSerializedSize())));
		totalSize += 4;
		if (VisibleCharacterInteractionEventOptionDict != null)
		{
			foreach (KeyValuePair<short, bool> item in VisibleCharacterInteractionEventOptionDict)
			{
				_ = item;
				totalSize += 2;
				totalSize++;
			}
		}
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
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = CreatingType;
		pCurrData++;
		*pCurrData = (byte)Gender;
		pCurrData++;
		pCurrData += FullName.Serialize(pCurrData);
		*pCurrData = MonkType;
		pCurrData++;
		pCurrData += MonasticTitle.Serialize(pCurrData);
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
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		pCurrData += OrgInfo.Serialize(pCurrData);
		*pCurrData = (byte)BehaviorType;
		pCurrData++;
		*pCurrData = (byte)FameType;
		pCurrData++;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsApproveTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = ApproveTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = InfluencePower;
		pCurrData += 2;
		*(int*)pCurrData = Contribution;
		pCurrData += 4;
		*(int*)pCurrData = ContributionPerMonth;
		pCurrData += 4;
		if (TitleIds != null)
		{
			int elementsCount = TitleIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = TitleIds[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (CompletelyInfected ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = ValidKidnapSlotCount;
		pCurrData++;
		*pCurrData = (byte)AliveState;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*(ulong*)pCurrData = ExternalRelationState;
		pCurrData += 8;
		*pCurrData = (byte)LegendaryBookOwnerState;
		pCurrData++;
		if (LegendaryBooks != null)
		{
			int elementsCount2 = LegendaryBooks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (byte)LegendaryBooks[j];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CustomDisplayNameId;
		pCurrData += 4;
		*pCurrData = (IsXiangshuInfectedDemon ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = SettlementTreasuryGuardInfo;
		pCurrData++;
		*pCurrData = (byte)BountyPunishmentSeverity;
		pCurrData++;
		*pCurrData = (byte)BountyOrgTemplate;
		pCurrData++;
		*pCurrData = (CanNotSpeak ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsFollowedByTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = NickNameId;
		pCurrData += 4;
		*(int*)pCurrData = ExtraNameTextTemplateId;
		pCurrData += 4;
		*pCurrData = (byte)IdealSect;
		pCurrData++;
		*pCurrData = (byte)CurrOrgTemplate;
		pCurrData++;
		*(uint*)pCurrData = DarkAshProtector;
		pCurrData += 4;
		pCurrData += DarkAshCounter.Serialize(pCurrData);
		if (OrganizationMemberPotentialSuccessor != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = OrganizationMemberPotentialSuccessor.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = Charm;
		pCurrData += 2;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*pCurrData = (byte)HealthStateFlags;
		pCurrData++;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*pCurrData = (byte)MerchantTemplateId;
		pCurrData++;
		*pCurrData = (IsSameFactionWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = FortuneExtraLegacyPointWorth;
		pCurrData += 4;
		pCurrData += Personalities.Serialize(pCurrData);
		*(int*)pCurrData = AttackMedal;
		pCurrData += 4;
		*(int*)pCurrData = DefenceMedal;
		pCurrData += 4;
		*(int*)pCurrData = WisdomMedal;
		pCurrData += 4;
		*(short*)pCurrData = SamsaraCount;
		pCurrData += 2;
		if (FeatureIds != null)
		{
			int elementsCount3 = FeatureIds.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*(short*)pCurrData = FeatureIds[k];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = AgeAffector;
		pCurrData++;
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*(int*)pCurrData = Alertness;
		pCurrData += 4;
		*pCurrData = (byte)MerchantType;
		pCurrData++;
		if (MerchantExpData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = MerchantExpData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrentProfession != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = CurrentProfession.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsSearchedCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (VisibleCharacterInteractionEventOptionDict != null)
		{
			*(int*)pCurrData = VisibleCharacterInteractionEventOptionDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, bool> pair in VisibleCharacterInteractionEventOptionDict)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*pCurrData = (pair.Value ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (byte)XiangshuType;
		pCurrData++;
		*(int*)pCurrData = NoInteractionReason;
		pCurrData += 4;
		*pCurrData = (ShowGraveInfoInFollowingMode ? ((byte)1) : ((byte)0));
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
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += FullName.Deserialize(pCurrData);
		MonkType = *pCurrData;
		pCurrData++;
		pCurrData += MonasticTitle.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			AvatarRelatedData = new AvatarRelatedData();
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		PhysiologicalAge = *(short*)pCurrData;
		pCurrData += 2;
		CurrAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += OrgInfo.Deserialize(pCurrData);
		BehaviorType = (sbyte)(*pCurrData);
		pCurrData++;
		FameType = (sbyte)(*pCurrData);
		pCurrData++;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsApproveTaiwu = *pCurrData != 0;
		pCurrData++;
		ApproveTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		InfluencePower = *(short*)pCurrData;
		pCurrData += 2;
		Contribution = *(int*)pCurrData;
		pCurrData += 4;
		ContributionPerMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TitleIds == null)
			{
				TitleIds = new List<short>();
			}
			else
			{
				TitleIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				TitleIds.Add(element);
			}
		}
		else
		{
			TitleIds?.Clear();
		}
		CompletelyInfected = *pCurrData != 0;
		pCurrData++;
		ValidKidnapSlotCount = *pCurrData;
		pCurrData++;
		AliveState = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
		ExternalRelationState = *(ulong*)pCurrData;
		pCurrData += 8;
		LegendaryBookOwnerState = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (LegendaryBooks == null)
			{
				LegendaryBooks = new List<sbyte>();
			}
			else
			{
				LegendaryBooks.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				sbyte element2 = (sbyte)(*pCurrData);
				pCurrData++;
				LegendaryBooks.Add(element2);
			}
		}
		else
		{
			LegendaryBooks?.Clear();
		}
		CustomDisplayNameId = *(int*)pCurrData;
		pCurrData += 4;
		IsXiangshuInfectedDemon = *pCurrData != 0;
		pCurrData++;
		SettlementTreasuryGuardInfo = *pCurrData;
		pCurrData++;
		BountyPunishmentSeverity = (sbyte)(*pCurrData);
		pCurrData++;
		BountyOrgTemplate = (sbyte)(*pCurrData);
		pCurrData++;
		CanNotSpeak = *pCurrData != 0;
		pCurrData++;
		IsFollowedByTaiwu = *pCurrData != 0;
		pCurrData++;
		NickNameId = *(int*)pCurrData;
		pCurrData += 4;
		ExtraNameTextTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		IdealSect = (sbyte)(*pCurrData);
		pCurrData++;
		CurrOrgTemplate = (sbyte)(*pCurrData);
		pCurrData++;
		DarkAshProtector = *(uint*)pCurrData;
		pCurrData += 4;
		pCurrData += DarkAshCounter.Deserialize(pCurrData);
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			OrganizationMemberPotentialSuccessor = new CharacterDisplayData();
			pCurrData += OrganizationMemberPotentialSuccessor.Deserialize(pCurrData);
		}
		else
		{
			OrganizationMemberPotentialSuccessor = null;
		}
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		Charm = *(short*)pCurrData;
		pCurrData += 2;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		HealthStateFlags = (sbyte)(*pCurrData);
		pCurrData++;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		MerchantTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		IsSameFactionWithTaiwu = *pCurrData != 0;
		pCurrData++;
		FortuneExtraLegacyPointWorth = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Personalities.Deserialize(pCurrData);
		AttackMedal = *(int*)pCurrData;
		pCurrData += 4;
		DefenceMedal = *(int*)pCurrData;
		pCurrData += 4;
		WisdomMedal = *(int*)pCurrData;
		pCurrData += 4;
		SamsaraCount = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>();
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				short element3 = *(short*)pCurrData;
				pCurrData += 2;
				FeatureIds.Add(element3);
			}
		}
		else
		{
			FeatureIds?.Clear();
		}
		AgeAffector = *pCurrData;
		pCurrData++;
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		Alertness = *(int*)pCurrData;
		pCurrData += 4;
		MerchantType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			MerchantExpData = new MerchantExpData();
			pCurrData += MerchantExpData.Deserialize(pCurrData);
		}
		else
		{
			MerchantExpData = null;
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			CurrentProfession = new ProfessionData();
			pCurrData += CurrentProfession.Deserialize(pCurrData);
		}
		else
		{
			CurrentProfession = null;
		}
		IsSearchedCharacter = *pCurrData != 0;
		pCurrData++;
		int VisibleCharacterInteractionEventOptionDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (VisibleCharacterInteractionEventOptionDictElementsCount > 0)
		{
			if (VisibleCharacterInteractionEventOptionDict == null)
			{
				VisibleCharacterInteractionEventOptionDict = new Dictionary<short, bool>();
			}
			else
			{
				VisibleCharacterInteractionEventOptionDict.Clear();
			}
			for (int l = 0; l < VisibleCharacterInteractionEventOptionDictElementsCount; l++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				bool value = *pCurrData != 0;
				pCurrData++;
				VisibleCharacterInteractionEventOptionDict.Add(key, value);
			}
		}
		else
		{
			VisibleCharacterInteractionEventOptionDict?.Clear();
		}
		XiangshuType = (sbyte)(*pCurrData);
		pCurrData++;
		NoInteractionReason = *(int*)pCurrData;
		pCurrData += 4;
		ShowGraveInfoInFollowingMode = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
