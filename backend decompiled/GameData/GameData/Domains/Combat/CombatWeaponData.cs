using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatWeaponData : BaseGameDataObject, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint WeaponTricks_Offset = 4u;

		public const int WeaponTricks_Size = 6;

		public const uint CanChangeTo_Offset = 10u;

		public const int CanChangeTo_Size = 1;

		public const uint Durability_Offset = 11u;

		public const int Durability_Size = 2;

		public const uint CdFrame_Offset = 13u;

		public const int CdFrame_Size = 2;

		public const uint AutoAttackEffect_Offset = 15u;

		public const int AutoAttackEffect_Size = 3;

		public const uint FixedCdLeftFrame_Offset = 18u;

		public const int FixedCdLeftFrame_Size = 2;

		public const uint FixedCdTotalFrame_Offset = 20u;

		public const int FixedCdTotalFrame_Size = 2;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private int _id;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 6)]
	private sbyte[] _weaponTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canChangeTo;

	[CollectionObjectField(false, true, false, false, false)]
	private short _durability;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _innerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private short _cdFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private short _fixedCdLeftFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private short _fixedCdTotalFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private SkillEffectKey _autoAttackEffect;

	[CollectionObjectField(false, true, false, false, false)]
	private List<SkillEffectKey> _pestleEffect;

	public const int FixedSize = 22;

	public const int DynamicCount = 1;

	private static readonly ushort[] ArchiveFieldIds = new ushort[9] { 0, 1, 2, 3, 4, 5, 7, 8, 6 };

	private static readonly int[] FixedArchiveFieldSizes = new int[8] { 4, 6, 1, 2, 2, 3, 2, 2 };

	public CombatCharacter Character { get; }

	public int Index { get; private set; }

	public bool NotInAnyCd => _cdFrame == 0 && _fixedCdLeftFrame == 0;

	public GameData.Domains.Item.Weapon Item => DomainManager.Item.GetElement_Weapons(_id);

	public short TemplateId => Item.GetTemplateId();

	public WeaponItem Template => Config.Weapon.Instance[TemplateId];

	[SingleValueDependency(5, new ushort[] { 24 }, Condition = InfluenceCondition.CombatWeaponIsTaiwuWeapon)]
	[SingleValueDependency(8, new ushort[] { 31 }, Condition = InfluenceCondition.CombatWeaponIsNotTaiwuWeapon)]
	private sbyte CalcInnerRatio()
	{
		if (!DomainManager.Combat.IsCharInCombat(Character.GetId()))
		{
			return _innerRatio;
		}
		if (Character.IsTaiwu)
		{
			return DomainManager.Taiwu.GetWeaponCurrInnerRatios()[Index];
		}
		return Template.DefaultInnerRatio;
	}

	public CombatWeaponData(ItemKey key, CombatCharacter character)
		: this()
	{
		_id = key.Id;
		Character = character;
	}

	public void Init(DataContext context, int index)
	{
		Index = index;
		SetDurability(Item.GetCurrDurability(), context);
		SetCdFrame(0, context);
		SetFixedCdLeftFrame(0, context);
		SetFixedCdTotalFrame(0, context);
		SetCanChangeTo(index >= 3 || GetDurability() > 0, context);
		SetAutoAttackEffect(new SkillEffectKey(-1, isDirect: false), context);
		_pestleEffect.Clear();
		SetPestleEffect(_pestleEffect, context);
	}

	public void SetPestleEffect(DataContext context, int charId, string effectName, SkillEffectKey effectKey)
	{
		if (!_pestleEffect.Contains(effectKey))
		{
			_pestleEffect.Add(effectKey);
			SetPestleEffect(_pestleEffect, context);
			DomainManager.SpecialEffect.Add(context, charId, effectKey, effectName);
		}
	}

	public void RemovePestleEffect(DataContext context)
	{
		foreach (SkillEffectKey effectKey in _pestleEffect)
		{
			Events.RaiseRemovePestleEffect(context, effectKey);
		}
		_pestleEffect.Clear();
		SetPestleEffect(_pestleEffect, context);
	}

	public int GetId()
	{
		return _id;
	}

	public void SetId(int id, DataContext context)
	{
		_id = id;
		SetModifiedAndInvalidateInfluencedCache(0, context);
	}

	public sbyte[] GetWeaponTricks()
	{
		return _weaponTricks;
	}

	public void SetWeaponTricks(sbyte[] weaponTricks, DataContext context)
	{
		_weaponTricks = weaponTricks;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public bool GetCanChangeTo()
	{
		return _canChangeTo;
	}

	public void SetCanChangeTo(bool canChangeTo, DataContext context)
	{
		_canChangeTo = canChangeTo;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public short GetDurability()
	{
		return _durability;
	}

	public void SetDurability(short durability, DataContext context)
	{
		_durability = durability;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public short GetCdFrame()
	{
		return _cdFrame;
	}

	public void SetCdFrame(short cdFrame, DataContext context)
	{
		_cdFrame = cdFrame;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public SkillEffectKey GetAutoAttackEffect()
	{
		return _autoAttackEffect;
	}

	public void SetAutoAttackEffect(SkillEffectKey autoAttackEffect, DataContext context)
	{
		_autoAttackEffect = autoAttackEffect;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public List<SkillEffectKey> GetPestleEffect()
	{
		return _pestleEffect;
	}

	public void SetPestleEffect(List<SkillEffectKey> pestleEffect, DataContext context)
	{
		_pestleEffect = pestleEffect;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public short GetFixedCdLeftFrame()
	{
		return _fixedCdLeftFrame;
	}

	public void SetFixedCdLeftFrame(short fixedCdLeftFrame, DataContext context)
	{
		_fixedCdLeftFrame = fixedCdLeftFrame;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public short GetFixedCdTotalFrame()
	{
		return _fixedCdTotalFrame;
	}

	public void SetFixedCdTotalFrame(short fixedCdTotalFrame, DataContext context)
	{
		_fixedCdTotalFrame = fixedCdTotalFrame;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public sbyte GetInnerRatio()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return _innerRatio;
		}
		_innerRatio = CalcInnerRatio();
		dataStates.SetCached(DataStatesOffset, 9);
		return _innerRatio;
	}

	public CombatWeaponData()
	{
		_weaponTricks = new sbyte[6];
		_pestleEffect = new List<SkillEffectKey>();
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
		int totalSize = 26;
		int elementsCount = _pestleEffect.Count;
		int contentSize = 3 * elementsCount;
		int dataSize = 2 + contentSize;
		return totalSize + dataSize;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		if (_weaponTricks.Length != 6)
		{
			throw new Exception("Elements count of field _weaponTricks is not equal to declaration");
		}
		for (int i = 0; i < 6; i++)
		{
			pCurrData[i] = (byte)_weaponTricks[i];
		}
		pCurrData += 6;
		*pCurrData = (_canChangeTo ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = _durability;
		pCurrData += 2;
		*(short*)pCurrData = _cdFrame;
		pCurrData += 2;
		pCurrData += _autoAttackEffect.Serialize(pCurrData);
		*(short*)pCurrData = _fixedCdLeftFrame;
		pCurrData += 2;
		*(short*)pCurrData = _fixedCdTotalFrame;
		pCurrData += 2;
		int elementsCount = _pestleEffect.Count;
		int contentSize = 3 * elementsCount;
		if (contentSize > 4194300)
		{
			throw new Exception($"Size of field {"_pestleEffect"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int j = 0; j < elementsCount; j++)
		{
			pCurrData += _pestleEffect[j].Serialize(pCurrData);
		}
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
				_id = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 1:
			{
				if (_weaponTricks.Length != 6)
				{
					throw new Exception("Elements count of field _weaponTricks is not equal to declaration");
				}
				for (int i = 0; i < 6; i++)
				{
					_weaponTricks[i] = (sbyte)pCurrData[i];
				}
				pCurrData += 6;
				break;
			}
			case 2:
				_canChangeTo = *pCurrData != 0;
				pCurrData++;
				break;
			case 3:
				_durability = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 4:
				_cdFrame = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 5:
				pCurrData += _autoAttackEffect.Deserialize(pCurrData);
				break;
			case 7:
				_fixedCdLeftFrame = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 8:
				_fixedCdTotalFrame = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 6:
			{
				pCurrData += 4;
				ushort elementsCount = *(ushort*)pCurrData;
				pCurrData += 2;
				_pestleEffect.Clear();
				for (int j = 0; j < elementsCount; j++)
				{
					SkillEffectKey element = default(SkillEffectKey);
					pCurrData += element.Deserialize(pCurrData);
					_pestleEffect.Add(element);
				}
				break;
			}
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
}
