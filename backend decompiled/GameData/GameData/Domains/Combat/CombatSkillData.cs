using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatSkillData : BaseGameDataObject, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 8;

		public const uint CanUse_Offset = 8u;

		public const int CanUse_Size = 1;

		public const uint LeftCdFrame_Offset = 9u;

		public const int LeftCdFrame_Size = 2;

		public const uint TotalCdFrame_Offset = 11u;

		public const int TotalCdFrame_Size = 2;

		public const uint ConstAffecting_Offset = 13u;

		public const int ConstAffecting_Size = 1;

		public const uint ShowAffectTips_Offset = 14u;

		public const int ShowAffectTips_Size = 1;

		public const uint Silencing_Offset = 15u;

		public const int Silencing_Size = 1;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private CombatSkillKey _id;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canUse;

	[CollectionObjectField(false, true, false, false, false)]
	private short _leftCdFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private short _totalCdFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _silencing;

	[CollectionObjectField(false, false, true, false, false)]
	private readonly List<CombatSkillBanReasonData> _banReason = new List<CombatSkillBanReasonData>();

	[CollectionObjectField(false, false, true, false, false)]
	private readonly List<CombatSkillEffectData> _effectData = new List<CombatSkillEffectData>();

	[CollectionObjectField(false, false, true, false, false)]
	private bool _canAffect;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _constAffecting;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _showAffectTips;

	public const int FixedSize = 16;

	public const int DynamicCount = 0;

	private static readonly ushort[] ArchiveFieldIds = new ushort[7] { 0, 1, 2, 3, 4, 5, 6 };

	private static readonly int[] FixedArchiveFieldSizes = new int[7] { 8, 1, 2, 2, 1, 1, 1 };

	[ObjectCollectionDependency(8, 29, new ushort[] { 1 }, Scope = InfluenceScope.Self)]
	private void CalcBanReason(List<CombatSkillBanReasonData> banReason)
	{
		banReason.Clear();
		if (_canUse)
		{
			return;
		}
		int charId = _id.CharId;
		short skillId = _id.SkillTemplateId;
		if (!DomainManager.Combat.TryGetElement_CombatCharacterDict(charId, out var combatChar) || !DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(charId, skillId), out var combatSkill))
		{
			return;
		}
		CombatDomain combatDomain = DomainManager.Combat;
		CombatSkillItem config = Config.CombatSkill.Instance[skillId];
		if (!combatDomain.SkillCanUseInCurrCombat(charId, config))
		{
			AddReason(ECombatSkillBanReasonType.CombatConfigBan);
			return;
		}
		if (_leftCdFrame != 0)
		{
			AddReason(ECombatSkillBanReasonType.Silencing);
			return;
		}
		if (!combatDomain.HasSkillNeedBodyPart(combatChar, skillId))
		{
			AddReason(ECombatSkillBanReasonType.BodyPartBroken);
			return;
		}
		if (config.EquipType == 1 && !combatDomain.WeaponHasNeedTrick(combatChar, skillId, combatDomain.GetUsingWeaponData(combatChar)))
		{
			AddReason(ECombatSkillBanReasonType.WeaponTrickMismatch);
			return;
		}
		if (!combatDomain.SkillCostEnough(combatChar, skillId))
		{
			foreach (ECombatSkillBanReasonType type in DomainManager.Combat.CalcSkillCostEnoughBanReasons(combatChar, skillId))
			{
				AddReason(type);
			}
		}
		if (banReason.Count == 0)
		{
			AddReason(ECombatSkillBanReasonType.SpecialEffectBan);
		}
		void AddReason(ECombatSkillBanReasonType banReasonType)
		{
			banReason.Add(new CombatSkillBanReasonData(banReasonType, combatSkill, combatChar));
		}
	}

	[ObjectCollectionDependency(17, 2, new ushort[] { 253 }, Scope = InfluenceScope.CombatSkillDataAffectedByTheSpecialEffects)]
	private void CalcEffectData(List<CombatSkillEffectData> effectData)
	{
		effectData.Clear();
		DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, 253, effectData);
	}

	[ObjectCollectionDependency(17, 2, new ushort[] { 286, 284, 285 }, Scope = InfluenceScope.CombatSkillDataAffectedByTheSpecialEffects)]
	private bool CalcCanAffect()
	{
		sbyte equipType = Config.CombatSkill.Instance[_id.SkillTemplateId].EquipType;
		if (1 == 0)
		{
		}
		ushort num = equipType switch
		{
			2 => 286, 
			3 => 284, 
			4 => 285, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort fieldId = num;
		return fieldId == ushort.MaxValue || DomainManager.SpecialEffect.ModifyData(_id.CharId, _id.SkillTemplateId, fieldId, dataValue: true);
	}

	public CombatSkillData(CombatSkillKey id)
		: this()
	{
		_id = id;
	}

	public void RaiseSkillSilence(DataContext context)
	{
		SetSilencing(silencing: true, context);
		Events.RaiseSkillSilence(context, _id);
	}

	public void RaiseSkillSilenceEnd(DataContext context)
	{
		SetSilencing(silencing: false, context);
		Events.RaiseSkillSilenceEnd(context, _id);
	}

	public CombatSkillKey GetId()
	{
		return _id;
	}

	public void SetId(CombatSkillKey id, DataContext context)
	{
		_id = id;
		SetModifiedAndInvalidateInfluencedCache(0, context);
	}

	public bool GetCanUse()
	{
		return _canUse;
	}

	public void SetCanUse(bool canUse, DataContext context)
	{
		_canUse = canUse;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public short GetLeftCdFrame()
	{
		return _leftCdFrame;
	}

	public void SetLeftCdFrame(short leftCdFrame, DataContext context)
	{
		_leftCdFrame = leftCdFrame;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public short GetTotalCdFrame()
	{
		return _totalCdFrame;
	}

	public void SetTotalCdFrame(short totalCdFrame, DataContext context)
	{
		_totalCdFrame = totalCdFrame;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public bool GetConstAffecting()
	{
		return _constAffecting;
	}

	public void SetConstAffecting(bool constAffecting, DataContext context)
	{
		_constAffecting = constAffecting;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public bool GetShowAffectTips()
	{
		return _showAffectTips;
	}

	public void SetShowAffectTips(bool showAffectTips, DataContext context)
	{
		_showAffectTips = showAffectTips;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public bool GetSilencing()
	{
		return _silencing;
	}

	public void SetSilencing(bool silencing, DataContext context)
	{
		_silencing = silencing;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public List<CombatSkillBanReasonData> GetBanReason()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 7))
		{
			return _banReason;
		}
		CalcBanReason(_banReason);
		dataStates.SetCached(DataStatesOffset, 7);
		return _banReason;
	}

	public List<CombatSkillEffectData> GetEffectData()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 8))
		{
			return _effectData;
		}
		CalcEffectData(_effectData);
		dataStates.SetCached(DataStatesOffset, 8);
		return _effectData;
	}

	public bool GetCanAffect()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return _canAffect;
		}
		_canAffect = CalcCanAffect();
		dataStates.SetCached(DataStatesOffset, 9);
		return _canAffect;
	}

	public CombatSkillData()
	{
		_banReason = new List<CombatSkillBanReasonData>();
		_effectData = new List<CombatSkillEffectData>();
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
		return 16;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _id.Serialize(pCurrData);
		*pCurrData = (_canUse ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = _leftCdFrame;
		pCurrData += 2;
		*(short*)pCurrData = _totalCdFrame;
		pCurrData += 2;
		*pCurrData = (_constAffecting ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_showAffectTips ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_silencing ? ((byte)1) : ((byte)0));
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
				pCurrData += _id.Deserialize(pCurrData);
				continue;
			case 1:
				_canUse = *pCurrData != 0;
				pCurrData++;
				continue;
			case 2:
				_leftCdFrame = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 3:
				_totalCdFrame = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 4:
				_constAffecting = *pCurrData != 0;
				pCurrData++;
				continue;
			case 5:
				_showAffectTips = *pCurrData != 0;
				pCurrData++;
				continue;
			case 6:
				_silencing = *pCurrData != 0;
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
}
