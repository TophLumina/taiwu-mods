using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.DLC.FiveLoong;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Material : ItemBase, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint TemplateId_Offset = 4u;

		public const int TemplateId_Size = 2;

		public const uint MaxDurability_Offset = 6u;

		public const int MaxDurability_Size = 2;

		public const uint CurrDurability_Offset = 8u;

		public const int CurrDurability_Size = 2;

		public const uint ModificationState_Offset = 10u;

		public const int ModificationState_Size = 1;
	}

	public const int FixedSize = 11;

	public const int DynamicCount = 0;

	private static readonly ushort[] ArchiveFieldIds = new ushort[5] { 0, 1, 2, 3, 4 };

	private static readonly int[] FixedArchiveFieldSizes = new int[5] { 4, 2, 2, 2, 1 };

	public override void SetMaxDurability(short maxDurability, DataContext context)
	{
		MaxDurability = maxDurability;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public override void SetCurrDurability(short currDurability, DataContext context)
	{
		CurrDurability = currDurability;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public override void SetModificationState(byte modificationState, DataContext context)
	{
		ModificationState = modificationState;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Material.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Material.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Material.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Material.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Material.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Material.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Material.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Material.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Material.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Material.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Material.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Material.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Material.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Material.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Material.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Material.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Material.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetRefiningEffect()
	{
		return Config.Material.Instance[TemplateId].RefiningEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetResourceAmount()
	{
		return Config.Material.Instance[TemplateId].ResourceAmount;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetRequiredLifeSkillType()
	{
		return Config.Material.Instance[TemplateId].RequiredLifeSkillType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetRequiredAttainment()
	{
		return Config.Material.Instance[TemplateId].RequiredAttainment;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetRequiredResourceAmount()
	{
		return Config.Material.Instance[TemplateId].RequiredResourceAmount;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<short> GetCraftableItemTypes()
	{
		return Config.Material.Instance[TemplateId].CraftableItemTypes;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ref readonly PoisonsAndLevels GetInnatePoisons()
	{
		return ref Config.Material.Instance[TemplateId].InnatePoisons;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Material.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Material.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Material.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfInner()
	{
		return Config.Material.Instance[TemplateId].PenetrateResistOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateMind()
	{
		return Config.Material.Instance[TemplateId].AvoidRateMind;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfOuter()
	{
		return Config.Material.Instance[TemplateId].PenetrateResistOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateSpeed()
	{
		return Config.Material.Instance[TemplateId].AvoidRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBreath()
	{
		return Config.Material.Instance[TemplateId].RecoveryOfBreath;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetMoveSpeed()
	{
		return Config.Material.Instance[TemplateId].MoveSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfFlaw()
	{
		return Config.Material.Instance[TemplateId].RecoveryOfFlaw;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetCastSpeed()
	{
		return Config.Material.Instance[TemplateId].CastSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBlockedAcupoint()
	{
		return Config.Material.Instance[TemplateId].RecoveryOfBlockedAcupoint;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfStance()
	{
		return Config.Material.Instance[TemplateId].RecoveryOfStance;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateTechnique()
	{
		return Config.Material.Instance[TemplateId].AvoidRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Material.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAttackSpeed()
	{
		return Config.Material.Instance[TemplateId].AttackSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetInnerRatio()
	{
		return Config.Material.Instance[TemplateId].InnerRatio;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfQiDisorder()
	{
		return Config.Material.Instance[TemplateId].RecoveryOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfHotPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfHotPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfGloomyPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfGloomyPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateStrength()
	{
		return Config.Material.Instance[TemplateId].AvoidRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfColdPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfColdPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRedPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfRedPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRottenPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfRottenPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfIllusoryPoison()
	{
		return Config.Material.Instance[TemplateId].ResistOfIllusoryPoison;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetConsumedFeatureMedals()
	{
		return Config.Material.Instance[TemplateId].ConsumedFeatureMedals;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetWeaponSwitchSpeed()
	{
		return Config.Material.Instance[TemplateId].WeaponSwitchSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfInner()
	{
		return Config.Material.Instance[TemplateId].PenetrateOfInner;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetPrimaryEffectValue()
	{
		return Config.Material.Instance[TemplateId].PrimaryEffectValue;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateMind()
	{
		return Config.Material.Instance[TemplateId].HitRateMind;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Material.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Material.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Material.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Material.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMaterialProperty GetProperty()
	{
		return Config.Material.Instance[TemplateId].Property;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBreakBonusEffect()
	{
		return Config.Material.Instance[TemplateId].BreakBonusEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PresetInventoryItem> GetDisassembleResultItemList()
	{
		return Config.Material.Instance[TemplateId].DisassembleResultItemList;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDisassembleResultCount()
	{
		return Config.Material.Instance[TemplateId].DisassembleResultCount;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDuration()
	{
		return Config.Material.Instance[TemplateId].Duration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseMaxHealthDelta()
	{
		return Config.Material.Instance[TemplateId].BaseMaxHealthDelta;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectType GetPrimaryEffectType()
	{
		return Config.Material.Instance[TemplateId].PrimaryEffectType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetPrimaryEffectThresholdValue()
	{
		return Config.Material.Instance[TemplateId].PrimaryEffectThresholdValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetPrimaryInjuryRecoveryTimes()
	{
		return Config.Material.Instance[TemplateId].PrimaryInjuryRecoveryTimes;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetPrimaryRecoverAllInjuries()
	{
		return Config.Material.Instance[TemplateId].PrimaryRecoverAllInjuries;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectType GetSecondaryEffectType()
	{
		return Config.Material.Instance[TemplateId].SecondaryEffectType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectSubType GetSecondaryEffectSubType()
	{
		return Config.Material.Instance[TemplateId].SecondaryEffectSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetSecondaryEffectThresholdValue()
	{
		return Config.Material.Instance[TemplateId].SecondaryEffectThresholdValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetSecondaryEffectValue()
	{
		return Config.Material.Instance[TemplateId].SecondaryEffectValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetSecondaryInjuryRecoveryTimes()
	{
		return Config.Material.Instance[TemplateId].SecondaryInjuryRecoveryTimes;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetSecondaryRecoverAllInjuries()
	{
		return Config.Material.Instance[TemplateId].SecondaryRecoverAllInjuries;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateStrength()
	{
		return Config.Material.Instance[TemplateId].HitRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateTechnique()
	{
		return Config.Material.Instance[TemplateId].HitRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateSpeed()
	{
		return Config.Material.Instance[TemplateId].HitRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfOuter()
	{
		return Config.Material.Instance[TemplateId].PenetrateOfOuter;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectSubType GetPrimaryEffectSubType()
	{
		return Config.Material.Instance[TemplateId].PrimaryEffectSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMaterialFilterType GetFilterType()
	{
		return Config.Material.Instance[TemplateId].FilterType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMaterialFilterHardness GetFilterHardness()
	{
		return Config.Material.Instance[TemplateId].FilterHardness;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetUseFrame()
	{
		return Config.Material.Instance[TemplateId].UseFrame;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Material.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Material.Instance[TemplateId].FunctionDesc;
	}

	public Material()
	{
	}

	public Material(short templateId)
	{
		MaterialItem template = Config.Material.Instance[templateId];
		TemplateId = template.TemplateId;
		MaxDurability = template.MaxDurability;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		return 11;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = MaxDurability;
		pCurrData += 2;
		*(short*)pCurrData = CurrDurability;
		pCurrData += 2;
		*pCurrData = ModificationState;
		pCurrData++;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				Id = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 1:
				TemplateId = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 2:
				MaxDurability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 3:
				CurrDurability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 4:
				ModificationState = *pCurrData;
				pCurrData++;
				continue;
			}
			if (fieldIndex < fixedFieldSizes.Length)
			{
				int fieldSize = fixedFieldSizes[fieldIndex];
				pCurrData += fieldSize;
			}
			else
			{
				int fieldSize2 = *(int*)pCurrData;
				pCurrData += 4;
				pCurrData += fieldSize2;
			}
		}
		return (int)(pCurrData - pData);
	}

	public Material(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return GetCharacterPropertyBonus(TemplateId, type);
	}

	public static int GetCharacterPropertyBonus(short templateId, ECharacterPropertyReferencedType type)
	{
		MaterialItem config = Config.Material.Instance[templateId];
		return config.GetCharacterPropertyBonusInt(type);
	}

	public override int GetValue()
	{
		GameData.DLC.FiveLoong.Jiao jiao;
		return DomainManager.Extra.TryGetJiaoByItemKey(GetItemKey(), out jiao) ? jiao.Properties.Get(jiao.TemplateId, 6) : Config.Material.Instance[TemplateId].BaseValue;
	}

	public override sbyte GetHappinessChange()
	{
		GameData.DLC.FiveLoong.Jiao jiao;
		return DomainManager.Extra.TryGetJiaoByItemKey(GetItemKey(), out jiao) ? ((sbyte)jiao.Properties.Get(jiao.TemplateId, 7)) : Config.Material.Instance[TemplateId].BaseHappinessChange;
	}

	public override int GetFavorabilityChange()
	{
		GameData.DLC.FiveLoong.Jiao jiao;
		return DomainManager.Extra.TryGetJiaoByItemKey(GetItemKey(), out jiao) ? jiao.Properties.Get(jiao.TemplateId, 8) : Config.Material.Instance[TemplateId].BaseFavorabilityChange;
	}
}
