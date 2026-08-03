using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Cricket;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Cricket : ItemBase, ISerializableGameData
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

		public const uint ColorId_Offset = 11u;

		public const int ColorId_Size = 2;

		public const uint PartId_Offset = 13u;

		public const int PartId_Size = 2;

		public const uint Injuries_Offset = 15u;

		public const int Injuries_Size = 10;

		public const uint WinsCount_Offset = 25u;

		public const int WinsCount_Size = 2;

		public const uint LossesCount_Offset = 27u;

		public const int LossesCount_Size = 2;

		public const uint BestEnemyColorId_Offset = 29u;

		public const int BestEnemyColorId_Size = 2;

		public const uint BestEnemyPartId_Offset = 31u;

		public const int BestEnemyPartId_Size = 2;

		public const uint AgeObsolete_Offset = 33u;

		public const int AgeObsolete_Size = 1;

		public const uint AgeProgress_Offset = 34u;

		public const int AgeProgress_Size = 4;

		public const uint Spirit_Offset = 38u;

		public const int Spirit_Size = 4;

		public const uint OriginState_Offset = 42u;

		public const int OriginState_Size = 1;

		public const uint PolymorphRateFix_Offset = 43u;

		public const int PolymorphRateFix_Size = 4;

		public const uint NameId_Offset = 47u;

		public const int NameId_Size = 4;
	}

	[CollectionObjectField(false, true, false, true, false)]
	private short _colorId;

	[CollectionObjectField(false, true, false, true, false)]
	private short _partId;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 5)]
	private short[] _injuries;

	[CollectionObjectField(false, true, false, false, false)]
	private short _winsCount;

	[CollectionObjectField(false, true, false, false, false)]
	private short _lossesCount;

	[CollectionObjectField(false, true, false, false, false)]
	private short _bestEnemyColorId;

	[CollectionObjectField(false, true, false, false, false)]
	private short _bestEnemyPartId;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _ageObsolete;

	[CollectionObjectField(false, true, false, false, false)]
	private int _ageProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private int _spirit;

	[CollectionObjectField(false, true, false, false, false)]
	private CricketSpiritProperty _spiritAddProperties;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _originState;

	[CollectionObjectField(false, true, false, false, false)]
	private int _polymorphRateFix;

	[CollectionObjectField(false, true, false, false, false)]
	private int _nameId;

	public const int FixedSize = 51;

	public const int DynamicCount = 1;

	private static readonly ushort[] ArchiveFieldIds = new ushort[19]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 16, 17, 18, 15
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[18]
	{
		4, 2, 2, 2, 1, 2, 2, 10, 2, 2,
		2, 2, 1, 4, 4, 1, 4, 4
	};

	private static List<(short templateId, short rate)>[] _cricketTemplateRates;

	private int Age => _ageProgress / AgePerYear;

	private int AgePerYear => GlobalConfig.Instance.CricketAgeProgressPerYear;

	public bool IsAlive => Age < CalcMaxAge() && CurrDurability > 0;

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

	public short GetColorId()
	{
		return _colorId;
	}

	public short GetPartId()
	{
		return _partId;
	}

	public short[] GetInjuries()
	{
		return _injuries;
	}

	public void SetInjuries(short[] injuries, DataContext context)
	{
		_injuries = injuries;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public short GetWinsCount()
	{
		return _winsCount;
	}

	public void SetWinsCount(short winsCount, DataContext context)
	{
		_winsCount = winsCount;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public short GetLossesCount()
	{
		return _lossesCount;
	}

	public void SetLossesCount(short lossesCount, DataContext context)
	{
		_lossesCount = lossesCount;
		SetModifiedAndInvalidateInfluencedCache(9, context);
	}

	public short GetBestEnemyColorId()
	{
		return _bestEnemyColorId;
	}

	public void SetBestEnemyColorId(short bestEnemyColorId, DataContext context)
	{
		_bestEnemyColorId = bestEnemyColorId;
		SetModifiedAndInvalidateInfluencedCache(10, context);
	}

	public short GetBestEnemyPartId()
	{
		return _bestEnemyPartId;
	}

	public void SetBestEnemyPartId(short bestEnemyPartId, DataContext context)
	{
		_bestEnemyPartId = bestEnemyPartId;
		SetModifiedAndInvalidateInfluencedCache(11, context);
	}

	public sbyte GetAgeObsolete()
	{
		return _ageObsolete;
	}

	public void SetAgeObsolete(sbyte ageObsolete, DataContext context)
	{
		_ageObsolete = ageObsolete;
		SetModifiedAndInvalidateInfluencedCache(12, context);
	}

	public int GetAgeProgress()
	{
		return _ageProgress;
	}

	public void SetAgeProgress(int ageProgress, DataContext context)
	{
		_ageProgress = ageProgress;
		SetModifiedAndInvalidateInfluencedCache(13, context);
	}

	public int GetSpirit()
	{
		return _spirit;
	}

	public void SetSpirit(int spirit, DataContext context)
	{
		_spirit = spirit;
		SetModifiedAndInvalidateInfluencedCache(14, context);
	}

	public CricketSpiritProperty GetSpiritAddProperties()
	{
		return _spiritAddProperties;
	}

	public void SetSpiritAddProperties(CricketSpiritProperty spiritAddProperties, DataContext context)
	{
		_spiritAddProperties = spiritAddProperties;
		SetModifiedAndInvalidateInfluencedCache(15, context);
	}

	public sbyte GetOriginState()
	{
		return _originState;
	}

	public void SetOriginState(sbyte originState, DataContext context)
	{
		_originState = originState;
		SetModifiedAndInvalidateInfluencedCache(16, context);
	}

	public int GetPolymorphRateFix()
	{
		return _polymorphRateFix;
	}

	public void SetPolymorphRateFix(int polymorphRateFix, DataContext context)
	{
		_polymorphRateFix = polymorphRateFix;
		SetModifiedAndInvalidateInfluencedCache(17, context);
	}

	public int GetNameId()
	{
		return _nameId;
	}

	public void SetNameId(int nameId, DataContext context)
	{
		_nameId = nameId;
		SetModifiedAndInvalidateInfluencedCache(18, context);
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Cricket.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Cricket.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Cricket.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Cricket.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Cricket.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Cricket.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Cricket.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Cricket.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Cricket.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Cricket.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Cricket.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Cricket.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Cricket.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Cricket.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Cricket.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Cricket.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Cricket.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Cricket.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Cricket.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Cricket.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Cricket.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Cricket.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Cricket.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Cricket.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Cricket.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Cricket.Instance[TemplateId].TaskLock;
	}

	public Cricket()
	{
		_injuries = new short[5];
		_spiritAddProperties = new CricketSpiritProperty();
	}

	public Cricket(short templateId)
	{
		CricketItem template = Config.Cricket.Instance[templateId];
		TemplateId = template.TemplateId;
		MaxDurability = template.MaxDurability;
		_injuries = new short[5];
		_spiritAddProperties = new CricketSpiritProperty();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
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
		int totalSize = 55;
		int dataSize = _spiritAddProperties.GetSerializedSize();
		return totalSize + dataSize;
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
		*(short*)pCurrData = _colorId;
		pCurrData += 2;
		*(short*)pCurrData = _partId;
		pCurrData += 2;
		if (_injuries.Length != 5)
		{
			throw new Exception("Elements count of field _injuries is not equal to declaration");
		}
		for (int i = 0; i < 5; i++)
		{
			((short*)pCurrData)[i] = _injuries[i];
		}
		pCurrData += 10;
		*(short*)pCurrData = _winsCount;
		pCurrData += 2;
		*(short*)pCurrData = _lossesCount;
		pCurrData += 2;
		*(short*)pCurrData = _bestEnemyColorId;
		pCurrData += 2;
		*(short*)pCurrData = _bestEnemyPartId;
		pCurrData += 2;
		*pCurrData = (byte)_ageObsolete;
		pCurrData++;
		*(int*)pCurrData = _ageProgress;
		pCurrData += 4;
		*(int*)pCurrData = _spirit;
		pCurrData += 4;
		*pCurrData = (byte)_originState;
		pCurrData++;
		*(int*)pCurrData = _polymorphRateFix;
		pCurrData += 4;
		*(int*)pCurrData = _nameId;
		pCurrData += 4;
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _spiritAddProperties.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_spiritAddProperties"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
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
				break;
			case 1:
				TemplateId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 2:
				MaxDurability = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 3:
				CurrDurability = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 4:
				ModificationState = *pCurrData;
				pCurrData++;
				break;
			case 5:
				_colorId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 6:
				_partId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 7:
			{
				if (_injuries.Length != 5)
				{
					throw new Exception("Elements count of field _injuries is not equal to declaration");
				}
				for (int i = 0; i < 5; i++)
				{
					_injuries[i] = ((short*)pCurrData)[i];
				}
				pCurrData += 10;
				break;
			}
			case 8:
				_winsCount = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 9:
				_lossesCount = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 10:
				_bestEnemyColorId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 11:
				_bestEnemyPartId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 12:
				_ageObsolete = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 13:
				_ageProgress = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 14:
				_spirit = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 16:
				_originState = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 17:
				_polymorphRateFix = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 18:
				_nameId = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 15:
				pCurrData += 4;
				pCurrData += _spiritAddProperties.Deserialize(pCurrData);
				break;
			default:
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
				break;
			}
		}
		return (int)(pCurrData - pData);
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return 0;
	}

	public override int GetValue()
	{
		if (CurrDurability <= 0)
		{
			return 0;
		}
		int selfValue = ((_partId > 0) ? Math.Max(CricketParts.Instance[_colorId].Value, CricketParts.Instance[_partId].Value) : CricketParts.Instance[_colorId].Value);
		int bestEnemyValue = ((_bestEnemyColorId > 0) ? Math.Max(CricketParts.Instance[_bestEnemyColorId].Value, CricketParts.Instance[_bestEnemyPartId].Value) : 0);
		return Math.Max(selfValue, bestEnemyValue);
	}

	public bool IsCombinedCricket()
	{
		return _partId != 0;
	}

	public CricketPartsItem GetColorData()
	{
		return CricketParts.Instance[_colorId];
	}

	public CricketPartsItem GetPartsData()
	{
		return CricketParts.Instance[_partId];
	}

	public int CalcCatchLucky()
	{
		short value = GetColorData().CatchInfluence;
		if (IsCombinedCricket())
		{
			value += GetPartsData().CatchInfluence;
		}
		return value;
	}

	public int CalcCombatValue()
	{
		sbyte enemyGrade = CalcGrade(_bestEnemyColorId, _bestEnemyPartId);
		return Math.Max(_winsCount - _lossesCount, 0) * (enemyGrade + 1) * ((_lossesCount > 0) ? 1 : 2);
	}

	public bool AllowPolymorph()
	{
		if (!IsAlive)
		{
			return false;
		}
		CricketPartsItem config = CricketParts.Instance[_colorId];
		if (config.CharacterMale < 0 || config.CharacterFemale < 0)
		{
			return false;
		}
		return _spirit >= GlobalConfig.Instance.CricketSpiritMax;
	}

	public void AddSpiritByWin(DataContext context, short enemyColorId, short enemyPartId)
	{
		sbyte grade = CalcGrade(enemyColorId, enemyPartId);
		int addValue = GlobalConfig.Instance.CricketCombatAddSpirit[grade];
		AddSpirit(context, addValue);
	}

	public void AddSpirit(DataContext context, int addValue)
	{
		int newSpirit = Math.Clamp(_spirit + addValue, _spirit, GlobalConfig.Instance.CricketSpiritMax);
		if (newSpirit == _spirit)
		{
			return;
		}
		SetSpirit(newSpirit, context);
		int needGrowthCount = newSpirit / GlobalConfig.Instance.CricketSpiritUnit;
		if (needGrowthCount > _spiritAddProperties.GrowthCount)
		{
			int growthCount = needGrowthCount - _spiritAddProperties.GrowthCount;
			bool durabilityChanged = false;
			for (int i = 0; i < growthCount; i++)
			{
				durabilityChanged = OfflineGrowthBySpirit(context) || durabilityChanged;
			}
			_spiritAddProperties.GrowthCount += growthCount;
			SetSpiritAddProperties(_spiritAddProperties, context);
			if (durabilityChanged)
			{
				SetCurrDurability(CurrDurability, context);
				SetMaxDurability(MaxDurability, context);
			}
		}
	}

	private bool OfflineGrowthBySpirit(DataContext context)
	{
		List<short> weights = ObjectPool<List<short>>.Instance.Get();
		weights.Clear();
		CricketPartsItem colorConfig = CricketParts.Instance[_colorId];
		CricketAffixesItem colorAffix = CricketAffixes.Instance[colorConfig.Affix];
		weights.AddRange(colorAffix.Weights);
		MapStateItem stateConfig = MapState.Instance[_originState];
		CricketAffixesItem stateAffix = CricketAffixes.Instance[stateConfig.CricketAffix];
		for (int i = 0; i < stateAffix.Weights.Length; i++)
		{
			weights[i] = (short)Math.Max(weights[i] + stateAffix.Weights[i], 0);
		}
		bool changeDurability = false;
		int[] addProperties = GlobalConfig.Instance.CricketSpiritGrowthProperties;
		int bonusType = RandomUtils.GetRandomIndex(weights, context.Random);
		if (bonusType >= addProperties.Length)
		{
			changeDurability = true;
			CurrDurability += GlobalConfig.Instance.CricketSpiritGrowthDurability;
			MaxDurability += GlobalConfig.Instance.CricketSpiritGrowthDurability;
			AddGrowthNotificationDurability();
		}
		else
		{
			int addValue = GlobalConfig.Instance.CricketSpiritGrowthProperties[bonusType];
			ECricketCombatPropertyType type = (ECricketCombatPropertyType)bonusType;
			CricketSpiritProperty spiritAddProperties = _spiritAddProperties;
			if (spiritAddProperties.PropertyAddValues == null)
			{
				spiritAddProperties.PropertyAddValues = new Dictionary<ECricketCombatPropertyType, int>();
			}
			int existValue = _spiritAddProperties.PropertyAddValues.GetOrDefault(type);
			_spiritAddProperties.PropertyAddValues[type] = existValue + addValue;
			AddGrowthNotification(type);
		}
		return changeDurability;
	}

	private void AddGrowthNotificationDurability()
	{
		if (DomainManager.World.GetAdvancingMonthState() == 0)
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
			instantNotification.AddCricketDurabilityUp(_colorId, _partId, _nameId);
		}
		else
		{
			MonthlyNotificationCollection monthlyNotification = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotification.AddCricketGrowUp(_colorId, _partId, _nameId);
		}
	}

	private void AddGrowthNotification(ECricketCombatPropertyType type)
	{
		if (DomainManager.World.GetAdvancingMonthState() == 0)
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
			switch (type)
			{
			case ECricketCombatPropertyType.Hp:
				instantNotification.AddCricketHPUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Sp:
				instantNotification.AddCricketSPUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Vigor:
				instantNotification.AddCricketVigorUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Strength:
				instantNotification.AddCricketStrengthUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Bite:
				instantNotification.AddCricketBiteUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Deadliness:
				instantNotification.AddCricketDeadlinessUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Damage:
				instantNotification.AddCricketDamageUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Cripple:
				instantNotification.AddCricketCrippleUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Defense:
				instantNotification.AddCricketDefenceUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.DamageReduce:
				instantNotification.AddCricketDamageReduceUp(_colorId, _partId, _nameId);
				break;
			case ECricketCombatPropertyType.Counter:
				instantNotification.AddCricketCounterUp(_colorId, _partId, _nameId);
				break;
			}
		}
		else
		{
			MonthlyNotificationCollection monthlyNotification = DomainManager.World.GetMonthlyNotificationCollection();
			monthlyNotification.AddCricketGrowUp(_colorId, _partId, _nameId);
		}
	}

	public bool UpdateCricketAge(DataContext context, CValuePercent agePercent)
	{
		if (CurrDurability <= 0)
		{
			return false;
		}
		_ageProgress = Math.Min(_ageProgress + AgePerYear * agePercent, CalcMaxAge() * AgePerYear);
		SetAgeProgress(_ageProgress, context);
		if (IsAlive)
		{
			return false;
		}
		SetCurrDurability(0, context);
		return true;
	}

	public void Rebirth(DataContext context)
	{
		SetAgeProgress(0, context);
		SetCurrDurability(MaxDurability, context);
	}

	public void Name(DataContext context, int nameId)
	{
		SetNameId(nameId, context);
	}

	public void SetAge(DataContext context, int age)
	{
		SetAgeProgress(age * AgePerYear, context);
	}

	public bool Match(CricketCombatConfig config)
	{
		if (!IsAlive)
		{
			return false;
		}
		if (config.OnlyNoInjury && _injuries.Any((short x) => x > 0))
		{
			return false;
		}
		sbyte grade = GetGrade();
		return grade >= config.MinGrade && grade <= config.MaxGrade;
	}

	public Cricket(IRandomSource random, short colorId, short partId, int itemId)
		: this(0)
	{
		Initialize(random, colorId, partId, itemId);
	}

	public Cricket(IRandomSource random, short templateId, int itemId)
		: this(random, templateId, itemId, isSpecial: false)
	{
	}

	public Cricket(IRandomSource random, short templateId, int itemId, bool isSpecial)
		: this(templateId)
	{
		sbyte grade = (sbyte)templateId;
		var (colorId, partId) = GenerateRandomColorAndPart(random, grade, isSpecial);
		Initialize(random, colorId, partId, itemId);
	}

	private void Initialize(IRandomSource random, short colorId, short partId, int itemId)
	{
		_colorId = colorId;
		_partId = partId;
		_nameId = -1;
		_originState = DomainManager.Taiwu.GetTaiwuValidStateTemplateId();
		Id = itemId;
		sbyte grade = CalcGrade(colorId, partId);
		TemplateId = grade;
		int durability = grade + 1 + CalcHp() / 20;
		durability = Math.Max(durability * random.Next(65, 136) / 100, 1);
		MaxDurability = (short)durability;
		CurrDurability = (short)durability;
		_bestEnemyColorId = -1;
		_bestEnemyPartId = -1;
		_ageProgress = CalcMaxAge() * random.Next(0, 21) / 100 * GlobalConfig.Instance.CricketAgeProgressPerYear;
		int maxInjuriesCount = Math.Min(3, durability - 1);
		for (int i = 0; i < maxInjuriesCount; i++)
		{
			if (random.CheckPercentProb(10))
			{
				CurrDurability--;
				if (random.CheckPercentProb(66))
				{
					int injuryType = random.Next(2);
					_injuries[injuryType] += 5;
				}
				else
				{
					int injuryType2 = 2 + random.Next(3);
					_injuries[injuryType2]++;
				}
			}
		}
	}

	public static void InitializeCricketWeights()
	{
		if (_cricketTemplateRates == null)
		{
			_cricketTemplateRates = new List<(short, short)>[27];
		}
		for (int i = 0; i < 27; i++)
		{
			List<(short, short)>[] cricketTemplateRates = _cricketTemplateRates;
			int num = i;
			if (cricketTemplateRates[num] == null)
			{
				cricketTemplateRates[num] = new List<(short, short)>();
			}
			_cricketTemplateRates[i].Clear();
		}
		int cachingIndex = 0;
		_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance
			where a.NpcSpecialRate != 0
			select ((short TemplateId, short))(TemplateId: a.TemplateId, a.NpcSpecialRate));
		sbyte grade;
		for (grade = 7; grade < 9; grade++)
		{
			_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance
				where a.Level == grade
				select ((short TemplateId, short))(TemplateId: a.TemplateId, a.Rate));
		}
		sbyte grade2;
		for (grade2 = 1; grade2 < 7; grade2++)
		{
			_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance.Where(delegate(CricketPartsItem a)
				{
					ECricketPartsType type = a.Type;
					return type >= ECricketPartsType.Cyan && type <= ECricketPartsType.White && a.Level <= grade2;
				})
				select ((short TemplateId, short))(TemplateId: a.TemplateId, a.Rate));
			_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance.Where(delegate(CricketPartsItem a)
				{
					ECricketPartsType type = a.Type;
					return type >= ECricketPartsType.Cyan && type <= ECricketPartsType.White && a.Level == grade2;
				})
				select ((short TemplateId, short))(TemplateId: a.TemplateId, a.Rate));
			_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance
				where a.Type == ECricketPartsType.Parts && a.Level <= grade2
				select ((short TemplateId, short))(TemplateId: a.TemplateId, a.Rate));
			_cricketTemplateRates[cachingIndex++].AddRange(from a in CricketParts.Instance
				where a.Type == ECricketPartsType.Parts && a.Level == grade2
				select ((short TemplateId, short))(TemplateId: a.TemplateId, a.Rate));
		}
	}

	private static (short colorId, short partId) GenerateRandomColorAndPart(IRandomSource random, sbyte grade, bool isSpecial)
	{
		short colorId = 0;
		short partId = 0;
		if (grade >= 7)
		{
			int index = ((!isSpecial) ? (grade - 7 + 1) : 0);
			colorId = RandomUtils.GetRandomResult(_cricketTemplateRates[index], random);
		}
		else if (grade >= 1)
		{
			bool lockPart = grade == 6 || random.CheckPercentProb(75);
			int indexRoot = (grade - 1) * 4 + 3;
			int indexPart = (lockPart ? (indexRoot + 3) : (indexRoot + 2));
			int indexColor = (lockPart ? indexRoot : (indexRoot + 1));
			colorId = RandomUtils.GetRandomResult(_cricketTemplateRates[indexColor], random);
			partId = RandomUtils.GetRandomResult(_cricketTemplateRates[indexPart], random);
		}
		else
		{
			colorId = 0;
		}
		return (colorId: colorId, partId: partId);
	}

	private static sbyte CalcGrade(short colorId, short partId)
	{
		if (colorId < 0)
		{
			return 0;
		}
		sbyte value = CricketParts.Instance[colorId].Level;
		if (partId > 0)
		{
			value = Math.Max(CricketParts.Instance[partId].Level, value);
		}
		return value;
	}

	private int CalcHp()
	{
		short value = CricketParts.Instance[_colorId].HP;
		if (_partId > 0)
		{
			value += CricketParts.Instance[_partId].HP;
		}
		return value;
	}

	public int CalcMaxAge()
	{
		int value = CricketParts.Instance[_colorId].Life;
		if (_partId > 0)
		{
			value += CricketParts.Instance[_partId].Life;
		}
		return value + DomainManager.Extra.GetCricketExtraAge(Id);
	}
}
