using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class SkillBook : ItemBase, ISerializableGameData
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

		public const uint PageTypes_Offset = 11u;

		public const int PageTypes_Size = 1;

		public const uint PageIncompleteState_Offset = 12u;

		public const int PageIncompleteState_Size = 2;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private byte _pageTypes;

	[CollectionObjectField(false, true, false, false, false)]
	private ushort _pageIncompleteState;

	public const int FixedSize = 14;

	public const int DynamicCount = 0;

	private static readonly ushort[] ArchiveFieldIds = new ushort[7] { 0, 1, 2, 3, 4, 5, 6 };

	private static readonly int[] FixedArchiveFieldSizes = new int[7] { 4, 2, 2, 2, 1, 1, 2 };

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return 0;
	}

	public byte GetPageCount()
	{
		return (byte)((GetLifeSkillType() >= 0) ? 5 : 6);
	}

	public bool IsCombatSkillBook()
	{
		return GetCombatSkillType() >= 0;
	}

	public bool CanFix()
	{
		ushort pageIncompleteState = GetPageIncompleteState();
		int pageCount = (IsCombatSkillBook() ? 6 : 5);
		bool canFix = false;
		for (byte i = 0; i < pageCount; i++)
		{
			sbyte state = SkillBookStateHelper.GetPageIncompleteState(pageIncompleteState, i);
			if (state == 1 || state == 2)
			{
				canFix = true;
				break;
			}
		}
		return canFix;
	}

	public bool AnyCompletePage()
	{
		ushort state = GetPageIncompleteState();
		int pageCount = (IsCombatSkillBook() ? 6 : 5);
		for (byte i = 0; i < pageCount; i++)
		{
			if (SkillBookStateHelper.GetPageIncompleteState(state, i) == 0)
			{
				return true;
			}
		}
		return false;
	}

	public (sbyte pageNum, int needProgress) GetFixProgress()
	{
		int pageCount = (IsCombatSkillBook() ? 6 : 5);
		ushort pageIncompleteState = GetPageIncompleteState();
		sbyte grade = ItemTemplateHelper.GetGrade(10, TemplateId);
		int needProgress = GlobalConfig.Instance.FixBookTotalProgress[grade];
		sbyte incompletePage = -1;
		for (sbyte i = 0; i < pageCount; i++)
		{
			switch (SkillBookStateHelper.GetPageIncompleteState(pageIncompleteState, (byte)i))
			{
			case 1:
				incompletePage = i;
				break;
			case 2:
				incompletePage = i;
				needProgress *= 3;
				break;
			default:
				continue;
			}
			break;
		}
		return (pageNum: incompletePage, needProgress: needProgress);
	}

	public void SetOutlinePageType(DataContext context, sbyte behaviorType)
	{
		_pageTypes = SkillBookStateHelper.SetOutlinePageType(_pageTypes, behaviorType);
		SetPageTypes(_pageTypes, context);
	}

	public void SetNormalPageType(DataContext context, byte pageId, sbyte direction)
	{
		_pageTypes = SkillBookStateHelper.SetNormalPageType(_pageTypes, pageId, direction);
		SetPageTypes(_pageTypes, context);
	}

	public SkillBook(IRandomSource random, short templateId, int itemId, sbyte completePagesCount = -1, sbyte lostPagesCount = -1, sbyte outlinePageType = -1, sbyte normalPagesDirectProb = 50, bool outlineAlwaysComplete = true)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		SkillBookItem config = Config.SkillBook.Instance[TemplateId];
		sbyte skillGroup = SkillGroup.FromItemSubType(config.ItemSubType);
		if (skillGroup == 1)
		{
			_pageTypes = GenerateCombatPageTypes(random, outlinePageType, normalPagesDirectProb);
		}
		_pageIncompleteState = GeneratePageIncompleteState(random, skillGroup, config.Grade, completePagesCount, lostPagesCount, outlineAlwaysComplete);
	}

	public SkillBook(IRandomSource random, short templateId, int itemId, byte pageTypes, sbyte completePagesCount = -1, sbyte lostPagesCount = -1, bool outlineAlwaysComplete = true)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		SkillBookItem config = Config.SkillBook.Instance[TemplateId];
		sbyte skillGroup = SkillGroup.FromItemSubType(config.ItemSubType);
		sbyte outlinePageType = (sbyte)Math.Clamp((int)SkillBookStateHelper.GetOutlinePageType(pageTypes), 0, 4);
		_pageTypes = SkillBookStateHelper.SetOutlinePageType(pageTypes, outlinePageType);
		_pageIncompleteState = GeneratePageIncompleteState(random, skillGroup, config.Grade, completePagesCount, lostPagesCount, outlineAlwaysComplete);
	}

	public SkillBook(IRandomSource random, short templateId, int itemId, ushort activationState)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		SkillBookItem config = Config.SkillBook.Instance[TemplateId];
		_pageTypes = GenerateCombatPageTypes(activationState);
		_pageIncompleteState = GeneratePageIncompleteState(random, 1, config.Grade, -1, -1, outlineAlwaysComplete: true);
	}

	public SkillBook(IRandomSource random, short templateId, int itemId, byte pageTypes, ushort pageIncompleteState)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		_pageTypes = pageTypes;
		_pageIncompleteState = pageIncompleteState;
	}

	public static byte GenerateCombatPageTypes(IRandomSource random, sbyte outlinePageType, sbyte normalPagesDirectProb)
	{
		byte pageTypes = 0;
		if (outlinePageType == -1)
		{
			outlinePageType = GameData.Domains.Character.BehaviorType.GetRandomBehaviorType(random);
		}
		outlinePageType = (sbyte)Math.Clamp((int)outlinePageType, 0, 4);
		pageTypes = SkillBookStateHelper.SetOutlinePageType(pageTypes, outlinePageType);
		for (byte pageId = 1; pageId < 6; pageId++)
		{
			sbyte direction = ((!random.CheckPercentProb(normalPagesDirectProb)) ? ((sbyte)1) : ((sbyte)0));
			pageTypes = SkillBookStateHelper.SetNormalPageType(pageTypes, pageId, direction);
		}
		return pageTypes;
	}

	public static byte GenerateCombatPageTypes(ushort activationState)
	{
		byte pageTypes = 0;
		sbyte outlinePageType = CombatSkillStateHelper.GetActiveOutlinePageType(activationState);
		if (outlinePageType == -1)
		{
			throw new Exception("Failed to get the type of the active outline page");
		}
		outlinePageType = (sbyte)Math.Clamp((int)outlinePageType, 0, 4);
		pageTypes = SkillBookStateHelper.SetOutlinePageType(pageTypes, outlinePageType);
		for (byte pageId = 1; pageId < 6; pageId++)
		{
			sbyte direction = CombatSkillStateHelper.GetPageActiveDirection(activationState, pageId);
			if (direction == -1)
			{
				throw new Exception("Failed to get the type of the active normal page");
			}
			pageTypes = SkillBookStateHelper.SetNormalPageType(pageTypes, pageId, direction);
		}
		return pageTypes;
	}

	public unsafe static ushort GeneratePageIncompleteState(IRandomSource random, sbyte skillGroup, sbyte grade, sbyte completePagesCount, sbyte lostPagesCount, bool outlineAlwaysComplete)
	{
		int normalPagesCount = ((skillGroup == 1) ? 5 : 5);
		if (completePagesCount < 0)
		{
			float mean = 3f - (float)grade / 4f;
			float min = Math.Max(0f, mean - 1f);
			float max = Math.Min(normalPagesCount, mean + 1f);
			completePagesCount = ((!(min > max)) ? ((sbyte)Math.Round(RedzenHelper.NormalDistribute(random, mean, 0.5f, min, max))) : ((sbyte)max));
		}
		if (lostPagesCount < 0)
		{
			float mean2 = -1f + (float)grade / 2.667f;
			float min2 = Math.Max(0f, mean2 - 1f);
			float max2 = Math.Min(normalPagesCount - completePagesCount, mean2 + 1f);
			lostPagesCount = ((!(min2 > max2)) ? ((sbyte)Math.Round(RedzenHelper.NormalDistribute(random, mean2, 0.5f, min2, max2))) : ((sbyte)max2));
		}
		int incompletePagesCount = normalPagesCount - completePagesCount - lostPagesCount;
		if (incompletePagesCount < 0)
		{
			throw new Exception($"IncompletePagesCount is less than zero: {incompletePagesCount}");
		}
		sbyte* pStates = stackalloc sbyte[(int)(uint)normalPagesCount];
		for (int i = 0; i < normalPagesCount; i++)
		{
			pStates[i] = -1;
		}
		for (int j = 0; j < normalPagesCount; j++)
		{
			if (completePagesCount <= 0)
			{
				break;
			}
			int completeProb = 70 - j * 10;
			if (random.CheckPercentProb(completeProb))
			{
				pStates[j] = 0;
				completePagesCount--;
			}
		}
		int leftPagesCount = completePagesCount + incompletePagesCount + lostPagesCount;
		sbyte* pLeftStates = stackalloc sbyte[(int)(uint)leftPagesCount];
		for (int k = 0; k < completePagesCount; k++)
		{
			pLeftStates[k] = 0;
		}
		for (sbyte i2 = completePagesCount; i2 < completePagesCount + incompletePagesCount; i2++)
		{
			pLeftStates[i2] = 1;
		}
		for (int l = completePagesCount + incompletePagesCount; l < leftPagesCount; l++)
		{
			pLeftStates[l] = 2;
		}
		CollectionUtils.Shuffle(random, pLeftStates, leftPagesCount);
		int m = 0;
		int leftPageId = 0;
		for (; m < normalPagesCount; m++)
		{
			if (pStates[m] == -1)
			{
				pStates[m] = pLeftStates[leftPageId++];
			}
		}
		ushort states = 0;
		byte pageBeginId = 0;
		if (skillGroup == 1)
		{
			sbyte outlineState = (sbyte)((!outlineAlwaysComplete && random.CheckPercentProb(90)) ? 2 : 0);
			states = SkillBookStateHelper.SetPageIncompleteState(states, 0, outlineState);
			pageBeginId = 1;
		}
		for (int n = 0; n < normalPagesCount; n++)
		{
			byte pageId = (byte)(pageBeginId + n);
			sbyte state = pStates[n];
			states = SkillBookStateHelper.SetPageIncompleteState(states, pageId, state);
		}
		return states;
	}

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

	public byte GetPageTypes()
	{
		return _pageTypes;
	}

	public void SetPageTypes(byte pageTypes, DataContext context)
	{
		_pageTypes = pageTypes;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public ushort GetPageIncompleteState()
	{
		return _pageIncompleteState;
	}

	public void SetPageIncompleteState(ushort pageIncompleteState, DataContext context)
	{
		_pageIncompleteState = pageIncompleteState;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.SkillBook.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.SkillBook.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.SkillBook.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.SkillBook.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.SkillBook.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.SkillBook.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.SkillBook.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.SkillBook.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.SkillBook.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.SkillBook.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.SkillBook.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.SkillBook.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.SkillBook.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.SkillBook.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.SkillBook.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.SkillBook.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.SkillBook.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetLifeSkillType()
	{
		return Config.SkillBook.Instance[TemplateId].LifeSkillType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetLifeSkillTemplateId()
	{
		return Config.SkillBook.Instance[TemplateId].LifeSkillTemplateId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetCombatSkillType()
	{
		return Config.SkillBook.Instance[TemplateId].CombatSkillType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatSkillTemplateId()
	{
		return Config.SkillBook.Instance[TemplateId].CombatSkillTemplateId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetLegacyPoint()
	{
		return Config.SkillBook.Instance[TemplateId].LegacyPoint;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<short> GetReferenceBooksWithBonus()
	{
		return Config.SkillBook.Instance[TemplateId].ReferenceBooksWithBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.SkillBook.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.SkillBook.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.SkillBook.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.SkillBook.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.SkillBook.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.SkillBook.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.SkillBook.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBreakBonusEffect()
	{
		return Config.SkillBook.Instance[TemplateId].BreakBonusEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.SkillBook.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.SkillBook.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.SkillBook.Instance[TemplateId].FunctionDesc;
	}

	public SkillBook()
	{
	}

	public SkillBook(short templateId)
	{
		SkillBookItem template = Config.SkillBook.Instance[templateId];
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
		return 14;
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
		*pCurrData = _pageTypes;
		pCurrData++;
		*(ushort*)pCurrData = _pageIncompleteState;
		pCurrData += 2;
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
			case 5:
				_pageTypes = *pCurrData;
				pCurrData++;
				continue;
			case 6:
				_pageIncompleteState = *(ushort*)pCurrData;
				pCurrData += 2;
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
}
