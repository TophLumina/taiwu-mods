using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Config;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;
using GameData.Domains.SpecialEffect.EquipmentEffect;
using GameData.Domains.SpecialEffect.Misc;
using GameData.Domains.Taiwu;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect;

[GameDataDomain(17)]
public class SpecialEffectDomain : BaseGameDataDomain
{
	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private Dictionary<long, SpecialEffectWrapper> _effectDict;

	[DomainData(DomainDataType.SingleValue, true, false, false, false)]
	private long _nextEffectId;

	[DomainData(DomainDataType.ObjectCollection, false, false, false, false)]
	private readonly Dictionary<int, AffectedData> _affectedDatas;

	private readonly ConcurrentBag<(long effectId, int charId, short skillId)> _brokenEffectsChangedDuringAdvance = new ConcurrentBag<(long, int, short)>();

	private readonly Dictionary<long, long> _featureEffectDict = new Dictionary<long, long>();

	private readonly List<CastBoostEffectDisplayData> _costNeiliEffectDisplayDataCache = new List<CastBoostEffectDisplayData>();

	private bool _domainInitialized;

	public static readonly Dictionary<short, string> BreakBodyFeatureEffectClassName = new Dictionary<short, string>
	{
		[199] = "CombatSkill.Xuehoujiao.BreakBodyEffect.HeadHurt",
		[200] = "CombatSkill.Xuehoujiao.BreakBodyEffect.HeadCrash",
		[201] = "CombatSkill.Xuehoujiao.BreakBodyEffect.ChestHurt",
		[202] = "CombatSkill.Xuehoujiao.BreakBodyEffect.ChestCrash",
		[203] = "CombatSkill.Xuehoujiao.BreakBodyEffect.BellyHurt",
		[204] = "CombatSkill.Xuehoujiao.BreakBodyEffect.BellyCrash",
		[205] = "CombatSkill.Xuehoujiao.BreakBodyEffect.HandHurt",
		[206] = "CombatSkill.Xuehoujiao.BreakBodyEffect.HandCrash",
		[207] = "CombatSkill.Xuehoujiao.BreakBodyEffect.LegHurt",
		[208] = "CombatSkill.Xuehoujiao.BreakBodyEffect.LegCrash"
	};

	private bool _updatingErrorEffect;

	private readonly HashSet<int> _requestUpdateCombatSkillCharIds = new HashSet<int>();

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[3][];

	private static readonly DataInfluence[][] CacheInfluencesAffectedDatas = new DataInfluence[345][];

	private readonly ObjectCollectionDataStates _dataStatesAffectedDatas = new ObjectCollectionDataStates(345, 0);

	public readonly ObjectCollectionHelperData HelperDataAffectedDatas;

	private Queue<uint> _pendingLoadingOperationIds;

	private static readonly List<Action> ResetOnInitializeGameDataModuleEffects = new List<Action>();

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		_domainInitialized = true;
		Events.RegisterHandler_AddWug(OnAddWug);
		InvokeResetHandlers();
	}

	private void OnLoadedArchiveData()
	{
		_domainInitialized = false;
		Events.RegisterHandler_AddWug(OnAddWug);
		InvokeResetHandlers();
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		if (!isNewWorld)
		{
			OnLoadedAllArchiveData(context);
		}
	}

	private void OnLoadedAllArchiveData(DataContext context)
	{
		List<long> removeList = new List<long>();
		_updatingErrorEffect = true;
		foreach (KeyValuePair<long, SpecialEffectWrapper> entry in _effectDict)
		{
			SpecialEffectBase effect = entry.Value.Effect;
			if (IsErrorEffectOnLoad(effect))
			{
				removeList.Add(entry.Key);
				continue;
			}
			effect.OnEnable(context);
			AddDataUid(context, effect);
			effect.OnDataAdded(context);
			if (effect is FeatureEffectBase featureEffect)
			{
				_featureEffectDict.Add(GetFeatureEffectKey(featureEffect.CharacterId, featureEffect.FeatureId), featureEffect.Id);
			}
		}
		foreach (long removeId in removeList)
		{
			RemoveElement_EffectDict(removeId, context);
		}
		_updatingErrorEffect = false;
		_requestUpdateCombatSkillCharIds.Remove(DomainManager.Taiwu.GetTaiwuCharId());
		foreach (int charId in _requestUpdateCombatSkillCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				UpdateEquippedSkillEffect(context, character);
			}
		}
		_requestUpdateCombatSkillCharIds.Clear();
		_domainInitialized = true;
	}

	private bool IsErrorEffect(SpecialEffectBase effect)
	{
		if (effect.Type < 0)
		{
			return true;
		}
		if (effect.CharObj == null)
		{
			return true;
		}
		if (effect is CombatSkillEffectBase { IsLegendaryBookEffect: false } skillEffect)
		{
			sbyte activeType = Config.SpecialEffect.Instance[skillEffect.EffectId].EffectActiveType;
			if (activeType == 1 || activeType == 0)
			{
				return true;
			}
			if (activeType == 2 && !effect.CharObj.IsCombatSkillEquipped(skillEffect.SkillKey.SkillTemplateId))
			{
				return true;
			}
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(skillEffect.SkillKey, out var _))
			{
				return true;
			}
		}
		if (effect is WugEffectBase wugEffect && effect.CharObj.GetEatingItems().IndexOfWug(wugEffect.WugTemplateId) < 0)
		{
			return true;
		}
		return false;
	}

	private bool IsErrorEffectOnLoad(SpecialEffectBase effect)
	{
		if (IsErrorEffect(effect))
		{
			return true;
		}
		if (effect is CombatSkillEffectBase { IsLegendaryBookEffect: false } combatSkillEffect)
		{
			return combatSkillEffect.SkillInstance.GetSpecialEffectId() != effect.Id;
		}
		return false;
	}

	[DomainMethod]
	public List<CastBoostEffectDisplayData> GetAllCostNeiliEffectData(int charId, short skillId)
	{
		_costNeiliEffectDisplayDataCache.Clear();
		if (!DomainManager.Combat.IsCharInCombat(charId))
		{
			return _costNeiliEffectDisplayDataCache;
		}
		if (skillId >= 0)
		{
			ModifyData(charId, skillId, 235, _costNeiliEffectDisplayDataCache);
		}
		return _costNeiliEffectDisplayDataCache;
	}

	[DomainMethod]
	public void CostNeiliEffect(DataContext context, int charId, short skillId, short effectId)
	{
		Events.RaiseCombatCostNeiliConfirm(context, charId, skillId, effectId);
	}

	[DomainMethod]
	public bool CanCostTrickDuringPreparingSkill(int charId, short skillId)
	{
		return ModifyData(charId, skillId, 322, dataValue: false);
	}

	[DomainMethod]
	public bool CostTrickDuringPreparingSkill(DataContext context, int charId, int trickIndex)
	{
		if (!DomainManager.Combat.IsCharInCombat(charId))
		{
			return false;
		}
		CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		short preparingSkillId = combatChar.GetPreparingSkillId();
		if (preparingSkillId < 0 || !CanCostTrickDuringPreparingSkill(charId, preparingSkillId))
		{
			return false;
		}
		IReadOnlyDictionary<int, sbyte> tricks = combatChar.GetTricks().Tricks;
		if (!tricks.TryGetValue(trickIndex, out var trickType))
		{
			return false;
		}
		DomainManager.Combat.RemoveTrick(context, combatChar, trickType, 1, removedByAlly: true, trickIndex);
		Events.RaiseCostTrickDuringPreparingSkill(context, charId);
		return true;
	}

	public long Add(DataContext context, SpecialEffectBase effect)
	{
		if (_effectDict.ContainsKey(_nextEffectId))
		{
			throw new Exception($"SpecialEffectSystem: nextEffectId {_nextEffectId} already exists.");
		}
		if (effect == null)
		{
			throw new Exception("SpecialEffectSystem: effect can not be null.");
		}
		effect.Id = _nextEffectId;
		AddElement_EffectDict(effect.Id, new SpecialEffectWrapper
		{
			Effect = effect
		}, context);
		do
		{
			_nextEffectId++;
			if (_nextEffectId < 0)
			{
				_nextEffectId = 0L;
			}
		}
		while (_effectDict.ContainsKey(_nextEffectId));
		SetNextEffectId(_nextEffectId, context);
		if (_domainInitialized)
		{
			effect.OnEnable(context);
			AddDataUid(context, effect);
			effect.OnDataAdded(context);
		}
		return effect.Id;
	}

	public long Add(DataContext context, int charId, string effectName)
	{
		string fullTypeName = "GameData.Domains.SpecialEffect." + effectName;
		Type specialEffectType = Type.GetType(fullTypeName);
		if (specialEffectType == null)
		{
			throw new Exception("Cannot find type '" + fullTypeName + "'.");
		}
		SpecialEffectBase effect = (SpecialEffectBase)Activator.CreateInstance(specialEffectType, charId);
		Add(context, effect);
		return effect.Id;
	}

	public void Add(DataContext context, int charId, short skillTemplateId, sbyte effectActiveType, sbyte direction = -1)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
		if (direction < 0)
		{
			direction = skill.GetDirection();
		}
		short effectTemplateId = (short)(direction switch
		{
			1 => skillConfig.ReverseEffectID, 
			0 => skillConfig.DirectEffectID, 
			_ => -1, 
		});
		if (effectTemplateId < 0)
		{
			return;
		}
		SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectTemplateId];
		if (effectConfig.EffectActiveType == effectActiveType && !string.IsNullOrEmpty(effectConfig.ClassName))
		{
			string fullTypeName = "GameData.Domains.SpecialEffect." + effectConfig.ClassName;
			Type specialEffectType = Type.GetType(fullTypeName);
			if (specialEffectType == null)
			{
				throw new Exception("Cannot find type '" + fullTypeName + "'.");
			}
			SpecialEffectBase effect = ((effectActiveType == 3) ? ((SpecialEffectBase)Activator.CreateInstance(specialEffectType, skillKey, direction)) : ((SpecialEffectBase)Activator.CreateInstance(specialEffectType, skillKey)));
			Add(context, effect);
			if (effectActiveType == 3 || effectActiveType == 2 || effectActiveType == 1)
			{
				skill.SetSpecialEffectId(effect.Id, context);
			}
		}
	}

	public long AddCombatStateEffect(DataContext context, int charId, sbyte stateType, short stateId, short power, bool reverse)
	{
		CombatStateEffect effect = new CombatStateEffect(charId, stateType, stateId, power, reverse);
		Add(context, effect);
		return effect.Id;
	}

	public void AddEquipmentEffect(DataContext context, int charId, ItemKey equipKey)
	{
		short effectId = DomainManager.Item.GetBaseEquipment(equipKey).GetEquipmentEffectId();
		if (effectId >= 0)
		{
			AddEquipmentEffect(context, charId, equipKey, effectId);
		}
	}

	public long AddEquipmentEffect(DataContext context, int charId, ItemKey equipKey, short effectId)
	{
		string className = Config.EquipmentEffect.Instance[effectId].EffectClassName;
		if (string.IsNullOrEmpty(className))
		{
			return -1L;
		}
		string fullTypeName = "GameData.Domains.SpecialEffect." + className;
		Type specialEffectType = Type.GetType(fullTypeName);
		if (specialEffectType == null)
		{
			throw new Exception("Cannot find type '" + fullTypeName + "'.");
		}
		SpecialEffectBase effect = (SpecialEffectBase)Activator.CreateInstance(specialEffectType, charId, equipKey);
		return Add(context, effect);
	}

	public long AddEquipmentEffect(DataContext context, int charId, int itemId, int specialEffectId)
	{
		string className = Config.SpecialEffect.Instance[specialEffectId].ClassName;
		if (string.IsNullOrEmpty(className))
		{
			return -1L;
		}
		string fullTypeName = "GameData.Domains.SpecialEffect." + className;
		Type specialEffectType = Type.GetType(fullTypeName);
		if (specialEffectType == null)
		{
			throw new Exception("Cannot find type '" + fullTypeName + "'.");
		}
		SpecialEffectBase effect = (SpecialEffectBase)Activator.CreateInstance(specialEffectType, charId, itemId);
		return Add(context, effect);
	}

	public void AddEquipmentMastery(DataContext context, int charId, ItemKey equipKey)
	{
		IItemConfig config = equipKey.GetConfig();
		if (config == null || config.EquipmentMasteryId < 0)
		{
			return;
		}
		AddEquipmentEffect(context, charId, equipKey.Id, config.EquipmentMasteryId);
		if (config is ArmorItem { RelatedWeapon: >=0 } armor)
		{
			WeaponItem shoesWeapon = Config.Weapon.Instance[armor.RelatedWeapon];
			if (shoesWeapon.EquipmentMasteryId >= 0)
			{
				AddEquipmentEffect(context, charId, equipKey.Id, shoesWeapon.EquipmentMasteryId);
			}
		}
	}

	public void AddFeatureEffect(DataContext context, int charId, short featureId)
	{
		string className = CharacterFeature.Instance[featureId].AssociatedSpecialEffect;
		if (!string.IsNullOrEmpty(className))
		{
			long effectKey = GetFeatureEffectKey(charId, featureId);
			string fullTypeName = "GameData.Domains.SpecialEffect." + className;
			Type specialEffectType = Type.GetType(fullTypeName);
			if (specialEffectType == null)
			{
				throw new Exception("Cannot find type '" + fullTypeName + "'.");
			}
			SpecialEffectBase effect = (SpecialEffectBase)Activator.CreateInstance(specialEffectType, charId, featureId);
			Add(context, effect);
			_featureEffectDict.Add(effectKey, effect.Id);
		}
	}

	public long AddAddPenetrateAndPenetrateResistEffect(DataContext context, int charId, OuterAndInnerInts addPenetrate, OuterAndInnerInts addPenetrateResist)
	{
		SpecialEffectBase effect = new AddPenetrateAndPenetrateResist(charId, addPenetrate, addPenetrateResist);
		Add(context, effect);
		return effect.Id;
	}

	public long AddAddMaxHealthEffect(DataContext context, int charId, int addMaxHealth)
	{
		SpecialEffectBase effect = new AddMaxHealth(charId, addMaxHealth);
		Add(context, effect);
		return effect.Id;
	}

	public SpecialEffectBase Get(long effectId)
	{
		return _effectDict.ContainsKey(effectId) ? _effectDict[effectId].Effect : null;
	}

	public void Remove(DataContext context, long effectId)
	{
		if (_effectDict.ContainsKey(effectId))
		{
			SpecialEffectBase effect = _effectDict[effectId].Effect;
			RemoveDataUid(context, effect);
			effect.OnDisable(context);
			RemoveElement_EffectDict(effectId, context);
		}
	}

	public void Remove(DataContext context, int charId, short skillTemplateId, sbyte effectActiveType)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		if (skill.GetSpecialEffectId() >= 0)
		{
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
			short effectTemplateId = (short)((skill.GetDirection() == 0) ? skillConfig.DirectEffectID : skillConfig.ReverseEffectID);
			if (Config.SpecialEffect.Instance[effectTemplateId].EffectActiveType == effectActiveType && (effectActiveType == 3 || effectActiveType == 2))
			{
				Remove(context, skill.GetSpecialEffectId());
				skill.SetSpecialEffectId(-1L, context);
			}
		}
	}

	private void Remove(DataContext context, List<long> removeIdList, bool removeAffectedData = true, bool clearCharObj = false)
	{
		foreach (long effectId in removeIdList)
		{
			if (_effectDict.TryGetValue(effectId, out var effectWrapper))
			{
				SpecialEffectBase effect = effectWrapper.Effect;
				if (clearCharObj)
				{
					effect.CharObj = null;
				}
				effect.OnDisable(context);
				if (removeAffectedData)
				{
					RemoveDataUid(context, effect);
				}
				if (effect is CombatSkillEffectBase && DomainManager.CombatSkill.TryGetElement_CombatSkills(((CombatSkillEffectBase)effect).SkillKey, out var skill))
				{
					skill.SetSpecialEffectId(-1L, context);
				}
				RemoveElement_EffectDict(effectId, context);
			}
		}
	}

	public void RemoveAllEffectsInCombat(DataContext context)
	{
		List<long> removeList = ObjectPool<List<long>>.Instance.Get();
		removeList.Clear();
		foreach (KeyValuePair<long, SpecialEffectWrapper> entry in _effectDict)
		{
			SpecialEffectBase effect = entry.Value.Effect;
			if (effect is CombatStateEffect stateEffect)
			{
				stateEffect.OnDisable(context);
				RemoveDataUid(context, stateEffect);
				removeList.Add(entry.Key);
			}
			else if (effect is PestleEffectBase pestleEffect)
			{
				pestleEffect.OnDisable(context);
				RemoveDataUid(context, pestleEffect);
				removeList.Add(entry.Key);
			}
			else if (effect is EquipmentEffectBase { AutoRemoveAfterCombat: not false } equipEffect)
			{
				equipEffect.OnDisable(context);
				RemoveDataUid(context, equipEffect);
				removeList.Add(entry.Key);
			}
			else
			{
				if (!(effect is CombatSkillEffectBase { IsLegendaryBookEffect: false } skillEffect))
				{
					continue;
				}
				sbyte activeType = Config.SpecialEffect.Instance[skillEffect.EffectId].EffectActiveType;
				if (activeType == 1 || activeType == 0)
				{
					skillEffect.OnDisable(context);
					RemoveDataUid(context, skillEffect);
					removeList.Add(entry.Key);
					if (activeType == 1)
					{
						DomainManager.CombatSkill.GetElement_CombatSkills(skillEffect.SkillKey).SetSpecialEffectId(-1L, context);
					}
				}
			}
		}
		for (int i = 0; i < removeList.Count; i++)
		{
			RemoveElement_EffectDict(removeList[i], context);
		}
		ObjectPool<List<long>>.Instance.Return(removeList);
	}

	public void RemoveFeatureEffect(DataContext context, int charId, short featureId)
	{
		long effectKey = GetFeatureEffectKey(charId, featureId);
		if (_featureEffectDict.ContainsKey(effectKey))
		{
			Remove(context, _featureEffectDict[effectKey]);
			_featureEffectDict.Remove(effectKey);
		}
	}

	public void RemoveAllEquippedSkillEffects(DataContext context, GameData.Domains.Character.Character character)
	{
		foreach (short skillId in character.GetCombatSkillEquipment())
		{
			DomainManager.SpecialEffect.Remove(context, character.GetId(), skillId, 2);
		}
	}

	public void RemoveAllBrokenSkillEffects(DataContext context, GameData.Domains.Character.Character character)
	{
		List<short> learnedCombatSkills = character.GetLearnedCombatSkills();
		foreach (short skillId in learnedCombatSkills)
		{
			if (skillId >= 0)
			{
				DomainManager.SpecialEffect.Remove(context, character.GetId(), skillId, 3);
			}
		}
	}

	public void AddAllBrokenSkillEffects(DataContext context, GameData.Domains.Character.Character character)
	{
		List<short> learnedCombatSkills = character.GetLearnedCombatSkills();
		foreach (short skillId in learnedCombatSkills)
		{
			if (skillId >= 0)
			{
				DomainManager.SpecialEffect.Add(context, character.GetId(), skillId, 3, -1);
			}
		}
	}

	private long GetFeatureEffectKey(int charId, short featureId)
	{
		return (long)charId * 1000000L + featureId;
	}

	private void AddDataUid(DataContext context, SpecialEffectBase effect)
	{
		if (effect.AffectDatas == null)
		{
			return;
		}
		foreach (AffectedDataKey dataKey in effect.AffectDatas.Keys)
		{
			AppendDataUid(context, effect, dataKey);
		}
	}

	public void AppendDataUid(DataContext context, SpecialEffectBase effect, AffectedDataKey dataKey)
	{
		if (!_affectedDatas.ContainsKey(dataKey.CharId))
		{
			AddElement_AffectedDatas(dataKey.CharId, new AffectedData(dataKey.CharId));
		}
		AffectedData affectedDatas = _affectedDatas[dataKey.CharId];
		SpecialEffectList effectList = affectedDatas.GetEffectList(dataKey.FieldId, createIfNull: true);
		effectList.EffectList.Add(effect);
		affectedDatas.SetEffectList(context, dataKey.FieldId, effectList);
	}

	public void RemoveDataUid(DataContext context, SpecialEffectBase effect, AffectedDataKey dataKey)
	{
		if (effect.AffectDatas != null && effect.AffectDatas.ContainsKey(dataKey))
		{
			AffectedData affectedData = _affectedDatas[dataKey.CharId];
			SpecialEffectList effectList = affectedData.GetEffectList(dataKey.FieldId);
			effectList?.EffectList.Remove(effect);
			affectedData.SetEffectList(context, dataKey.FieldId, effectList);
		}
	}

	public void RemoveDataUid(DataContext context, SpecialEffectBase effect)
	{
		if (effect.AffectDatas == null)
		{
			return;
		}
		foreach (AffectedDataKey dataKey in effect.AffectDatas.Keys)
		{
			AffectedData affectedData = _affectedDatas[dataKey.CharId];
			SpecialEffectList effectList = affectedData.GetEffectList(dataKey.FieldId);
			effectList?.EffectList.Remove(effect);
			affectedData.SetEffectList(context, dataKey.FieldId, effectList);
		}
	}

	public void InvalidateCache(DataContext context, int charId, ushort fieldId)
	{
		if (_affectedDatas.ContainsKey(charId))
		{
			AffectedData affectedData = _affectedDatas[charId];
			affectedData.SetEffectList(context, fieldId, affectedData.GetEffectList(fieldId));
			return;
		}
		AddElement_AffectedDatas(charId, new AffectedData(charId));
		AffectedData affectedDatas = _affectedDatas[charId];
		affectedDatas.SetEffectList(context, fieldId, null);
		RemoveElement_AffectedDatas(charId);
	}

	public void ChangeAffectedDataUids(DataContext context, SpecialEffectBase effect, Dictionary<AffectedDataKey, EDataModifyType> affectDataUids)
	{
		RemoveDataUid(context, effect);
		effect.AffectDatas = affectDataUids;
		AddDataUid(context, effect);
	}

	public int ModifyValue(int charId, ushort fieldId, int value, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, int extraAdd = 0, int extraAddPercent = 0, int extraTotalPercentAdd = 0, int extraTotalPercentReduce = 0)
	{
		return ModifyValue(charId, -1, fieldId, value, customParam0, customParam1, customParam2, extraAdd, extraAddPercent, extraTotalPercentAdd, extraTotalPercentReduce);
	}

	public int ModifyValue(int charId, short skillId, ushort fieldId, int value, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, int extraAdd = 0, int extraAddPercent = 0, int extraTotalPercentAdd = 0, int extraTotalPercentReduce = 0)
	{
		CValueModify modify = GetModify(charId, skillId, fieldId, customParam0, customParam1, customParam2);
		modify += new CValueModify(extraAdd, extraAddPercent, extraTotalPercentAdd, extraTotalPercentReduce);
		return value * modify;
	}

	public int ModifyValueCustom(int charId, ushort fieldId, int value, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, int extraAdd = 0, int extraAddPercent = 0, int extraTotalPercentAdd = 0, int extraTotalPercentReduce = 0)
	{
		return ModifyValueCustom(charId, -1, fieldId, value, customParam0, customParam1, customParam2, extraAdd, extraAddPercent, extraTotalPercentAdd, extraTotalPercentReduce);
	}

	public int ModifyValueCustom(int charId, short skillId, ushort fieldId, int value, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, int extraAdd = 0, int extraAddPercent = 0, int extraTotalPercentAdd = 0, int extraTotalPercentReduce = 0)
	{
		value = ModifyValue(charId, skillId, fieldId, value, customParam0, customParam1, customParam2, extraAdd, extraAddPercent, extraTotalPercentAdd, extraTotalPercentReduce);
		return ModifyData(charId, skillId, fieldId, value, customParam0, customParam1, customParam2);
	}

	public CValueModify GetModify(int charId, ushort fieldId, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, EDataSumType valueSumType = EDataSumType.All)
	{
		return GetModify(charId, -1, fieldId, customParam0, customParam1, customParam2, valueSumType);
	}

	public CValueModify GetModify(int charId, short combatSkillId, ushort fieldId, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, EDataSumType valueSumType = EDataSumType.All)
	{
		if (valueSumType == EDataSumType.None)
		{
			return CValueModify.Zero;
		}
		int add = GetModifyValue(charId, combatSkillId, fieldId, EDataModifyType.Add, customParam0, customParam1, customParam2, valueSumType);
		int addPercent = GetModifyValue(charId, combatSkillId, fieldId, EDataModifyType.AddPercent, customParam0, customParam1, customParam2, valueSumType);
		(int, int) totalPercent = GetTotalPercentModifyValue(charId, combatSkillId, fieldId, customParam0, customParam1, customParam2);
		int num;
		if (valueSumType != EDataSumType.OnlyReduce)
		{
			(num, _) = totalPercent;
		}
		else
		{
			num = 0;
		}
		int totalPercentAdd = num;
		int totalPercentReduce = ((valueSumType != EDataSumType.OnlyAdd) ? totalPercent.Item2 : 0);
		return new CValueModify(add, addPercent, totalPercentAdd, totalPercentReduce);
	}

	public int GetModifyValue(int charId, ushort fieldId, EDataModifyType modifyType, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, EDataSumType valueSumType = EDataSumType.All)
	{
		return GetModifyValue(charId, -1, fieldId, modifyType, customParam0, customParam1, customParam2, valueSumType);
	}

	public int GetModifyValue(int charId, short combatSkillId, ushort fieldId, EDataModifyType modifyType, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1, EDataSumType valueSumType = EDataSumType.All)
	{
		if (modifyType != EDataModifyType.Add && modifyType != EDataModifyType.AddPercent)
		{
			throw new Exception($"Invalid DataModifyType {modifyType}");
		}
		if (!_affectedDatas.ContainsKey(charId))
		{
			return 0;
		}
		SpecialEffectList effectList = GetElement_AffectedDatas(charId).GetEffectList(fieldId);
		int modifyValue = 0;
		if (effectList != null)
		{
			AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
			for (int i = 0; i < effectList.EffectList.Count; i++)
			{
				SpecialEffectBase effect = effectList.EffectList[i];
				if (effect.AffectDatas.TryGetValue(dataKey, out var type) && type == modifyType)
				{
					int value = effect.GetModifyValue(dataKey, modifyValue);
					modifyValue = valueSumType.Sum(modifyValue, value);
				}
			}
		}
		return modifyValue;
	}

	public (int add, int reduce) GetTotalPercentModifyValue(int charId, short combatSkillId, ushort fieldId, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		(int, int) modifyValue = (0, 0);
		if (!_affectedDatas.ContainsKey(charId))
		{
			return modifyValue;
		}
		SpecialEffectList effectList = GetElement_AffectedDatas(charId).GetEffectList(fieldId);
		if (effectList != null)
		{
			AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
			for (int i = 0; i < effectList.EffectList.Count; i++)
			{
				SpecialEffectBase effect = effectList.EffectList[i];
				if (effect.AffectDatas.TryGetValue(dataKey, out var type) && type == EDataModifyType.TotalPercent)
				{
					int value = effect.GetModifyValue(dataKey, 0);
					if (value > modifyValue.Item1)
					{
						modifyValue.Item1 = value;
					}
					else if (value < modifyValue.Item2)
					{
						modifyValue.Item2 = value;
					}
				}
			}
		}
		return modifyValue;
	}

	private void CalcCustomModifyEffectList(AffectedDataKey dataKey, List<SpecialEffectBase> customEffectList)
	{
		customEffectList.Clear();
		if (!_affectedDatas.ContainsKey(dataKey.CharId))
		{
			return;
		}
		SpecialEffectList effectList = GetElement_AffectedDatas(dataKey.CharId).GetEffectList(dataKey.FieldId);
		if (effectList == null)
		{
			return;
		}
		for (int i = 0; i < effectList.EffectList.Count; i++)
		{
			SpecialEffectBase effect = effectList.EffectList[i];
			if (effect.AffectDatas.TryGetValue(dataKey, out var type) && type == EDataModifyType.Custom)
			{
				customEffectList.Add(effect);
			}
		}
	}

	public bool ModifyData(int charId, short combatSkillId, ushort fieldId, bool dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public int ModifyData(int charId, short combatSkillId, ushort fieldId, int dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public long ModifyData(int charId, short combatSkillId, ushort fieldId, long dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public HitOrAvoidInts ModifyData(int charId, short combatSkillId, ushort fieldId, HitOrAvoidInts dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public NeiliProportionOfFiveElements ModifyData(int charId, short combatSkillId, ushort fieldId, NeiliProportionOfFiveElements dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public OuterAndInnerInts ModifyData(int charId, short combatSkillId, ushort fieldId, OuterAndInnerInts dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public List<NeedTrick> ModifyData(int charId, short combatSkillId, ushort fieldId, List<NeedTrick> dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public (sbyte, sbyte) ModifyData(int charId, short combatSkillId, ushort fieldId, (sbyte, sbyte) dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public List<ItemKeyAndCount> ModifyData(int charId, short combatSkillId, ushort fieldId, List<ItemKeyAndCount> dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public List<CastBoostEffectDisplayData> ModifyData(int charId, short combatSkillId, ushort fieldId, List<CastBoostEffectDisplayData> dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public List<CombatSkillEffectData> ModifyData(int charId, short combatSkillId, ushort fieldId, List<CombatSkillEffectData> dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public BoolArray8 ModifyData(int charId, short combatSkillId, ushort fieldId, BoolArray8 dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public CombatCharacter ModifyData(int charId, short combatSkillId, ushort fieldId, CombatCharacter dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		CalcCustomModifyEffectList(dataKey, customEffectList);
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public List<int> ModifyData(int charId, short combatSkillId, ushort fieldId, List<int> dataValue, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		AffectedDataKey dataKey = new AffectedDataKey(charId, fieldId, combatSkillId, customParam0, customParam1, customParam2);
		List<SpecialEffectBase> customEffectList = ObjectPool<List<SpecialEffectBase>>.Instance.Get();
		for (int i = 0; i < customEffectList.Count; i++)
		{
			dataValue = customEffectList[i].GetModifiedValue(dataKey, dataValue);
		}
		ObjectPool<List<SpecialEffectBase>>.Instance.Return(customEffectList);
		return dataValue;
	}

	public void OnCharacterCreated(DataContext context, GameData.Domains.Character.Character character)
	{
		if (!_affectedDatas.ContainsKey(character.GetId()))
		{
			AddElement_AffectedDatas(character.GetId(), new AffectedData(character.GetId()));
		}
	}

	public void OnCharacterRemoved(DataContext context, GameData.Domains.Character.Character character)
	{
		List<long> removeIdList = ObjectPool<List<long>>.Instance.Get();
		removeIdList.Clear();
		foreach (KeyValuePair<long, SpecialEffectWrapper> entry in _effectDict)
		{
			if (entry.Value.Effect.CharacterId == character.GetId())
			{
				removeIdList.Add(entry.Key);
			}
		}
		Remove(context, removeIdList, removeAffectedData: false);
		RemoveElement_AffectedDatas(character.GetId());
		ObjectPool<List<long>>.Instance.Return(removeIdList);
	}

	public void AddCombatSkillSpecialEffects(DataContext context, int charId, short[] combatSkills, sbyte activeType)
	{
		foreach (short skillId in combatSkills)
		{
			if (skillId >= 0)
			{
				DomainManager.SpecialEffect.Add(context, charId, skillId, activeType, -1);
			}
		}
	}

	public void UpdateEquippedSkillEffect(DataContext context, GameData.Domains.Character.Character character)
	{
		if (_updatingErrorEffect)
		{
			_requestUpdateCombatSkillCharIds.Add(character.GetId());
			return;
		}
		foreach (short skillId in character.GetLearnedCombatSkills())
		{
			Remove(context, character.GetId(), skillId, 2);
		}
		foreach (short skillId2 in character.GetCombatSkillEquipment())
		{
			if (character.GetCombatSkillCanAffect(skillId2))
			{
				Add(context, character.GetId(), skillId2, 2, -1);
			}
		}
	}

	private void OnAddWug(DataContext context, int charId, short wugTemplateId, short replacedWug)
	{
		long effectId = Add(context, charId, Config.Medicine.Instance[wugTemplateId].SpecialEffectClass);
		if (_effectDict.TryGetValue(effectId, out var effectWrapper))
		{
			((WugEffectBase)effectWrapper.Effect).OnEffectAdded(context, replacedWug);
		}
	}

	public void AddBrokenEffectChangedDuringAdvance(long effectId, int charId, short skillId)
	{
		_brokenEffectsChangedDuringAdvance.Add((effectId, charId, skillId));
	}

	public void ApplyBrokenEffectChangedDuringAdvance(DataContext context)
	{
		foreach (var changedEffect in _brokenEffectsChangedDuringAdvance)
		{
			GameData.Domains.CombatSkill.CombatSkill skill;
			sbyte direction = (sbyte)(DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(changedEffect.charId, changedEffect.skillId), out skill) ? skill.GetDirection() : (-1));
			if (changedEffect.effectId >= 0)
			{
				DomainManager.SpecialEffect.Remove(context, changedEffect.effectId);
			}
			if (direction >= 0)
			{
				DomainManager.SpecialEffect.Add(context, changedEffect.charId, changedEffect.skillId, 3, direction);
			}
		}
		_brokenEffectsChangedDuringAdvance.Clear();
	}

	public void SaveEffect(DataContext context, long effectId)
	{
		SetElement_EffectDict(effectId, _effectDict[effectId], context);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<SpecialEffectWrapper> taiwuEffects = (crossArchiveGameData.TaiwuEffects = new List<SpecialEffectWrapper>());
		foreach (SpecialEffectWrapper effectWrapper in _effectDict.Values)
		{
			if (effectWrapper.Effect != null && effectWrapper.Effect.CharacterId == taiwuCharId)
			{
				taiwuEffects.Add(effectWrapper);
			}
		}
	}

	public void UnpackCrossArchiveGameData_Items(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<SpecialEffectWrapper> taiwuEffects = crossArchiveGameData.TaiwuEffects;
		if (taiwuEffects == null)
		{
			return;
		}
		Dictionary<long, sbyte> weaponEffectIds = new Dictionary<long, sbyte>();
		Dictionary<long, sbyte> skillEffectIds = new Dictionary<long, sbyte>();
		for (sbyte i = 0; i < 14; i++)
		{
			if (DomainManager.Extra.TryGetElement_LegendaryBookWeaponEffectId(i, out var weaponEffectId))
			{
				weaponEffectIds[weaponEffectId] = i;
			}
			if (DomainManager.Extra.TryGetElement_LegendaryBookSkillEffectId(i, out var skillEffectIdList))
			{
				List<long> items = skillEffectIdList.Items;
				if (items != null && items.Count > 0)
				{
					foreach (long skillEffectId in skillEffectIdList.Items)
					{
						if (skillEffectId >= 0)
						{
							skillEffectIds[skillEffectId] = i;
						}
					}
				}
			}
		}
		List<SpecialEffectWrapper> collectedEffects = new List<SpecialEffectWrapper>();
		foreach (SpecialEffectWrapper effectWrapper in taiwuEffects)
		{
			SpecialEffectBase effect = effectWrapper.Effect;
			bool anyMissing;
			if (effect is EquipmentEffectBase equipmentEffect)
			{
				equipmentEffect.EquipItemKey = DomainManager.Item.UnpackCrossArchiveItem(context, crossArchiveGameData, equipmentEffect.EquipItemKey);
				anyMissing = !equipmentEffect.EquipItemKey.IsValid();
			}
			else
			{
				if (!(effect is CombatSkillEffectBase { IsLegendaryBookEffect: not false } combatSkillEffect))
				{
					continue;
				}
				combatSkillEffect.SkillKey.CharId = taiwuCharId;
				anyMissing = !DomainManager.CombatSkill.TryGetElement_CombatSkills(combatSkillEffect.SkillKey, out var _);
			}
			effect.OnDreamBack(context);
			effect.CharObj = taiwuChar;
			effect.CharacterId = taiwuCharId;
			collectedEffects.Add(effectWrapper);
			long prevEffectId = effect.Id;
			long currEffectId = ((anyMissing || IsErrorEffect(effect)) ? (-1) : Add(context, effect));
			if (weaponEffectIds.TryGetValue(prevEffectId, out var weaponSkillType))
			{
				DomainManager.Extra.SetLegendaryBookWeaponEffectId(context, weaponSkillType, currEffectId, prevEffectId);
			}
			if (skillEffectIds.TryGetValue(prevEffectId, out var combatSkillType))
			{
				DomainManager.Extra.SetLegendaryBookSkillEffectId(context, combatSkillType, currEffectId, prevEffectId);
			}
		}
		foreach (SpecialEffectWrapper collectedEffect in collectedEffects)
		{
			taiwuEffects.Remove(collectedEffect);
		}
	}

	public void UnpackCrossArchiveGameData_CombatSkills(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<SpecialEffectWrapper> taiwuEffects = crossArchiveGameData.TaiwuEffects;
		if (taiwuEffects == null)
		{
			return;
		}
		List<SpecialEffectWrapper> collectedEffects = new List<SpecialEffectWrapper>();
		Dictionary<int, CombatSkillEffectBase> existEffects = new Dictionary<int, CombatSkillEffectBase>();
		foreach (SpecialEffectWrapper effectWrapper in _effectDict.Values)
		{
			SpecialEffectBase effect = effectWrapper.Effect;
			if (effect.CharacterId == taiwuCharId && effect is CombatSkillEffectBase { IsLegendaryBookEffect: false } combatSkillEffect)
			{
				existEffects.Add(combatSkillEffect.Type, combatSkillEffect);
			}
		}
		foreach (SpecialEffectWrapper effectWrapper2 in taiwuEffects)
		{
			SpecialEffectBase effectBase = effectWrapper2.Effect;
			if (!(effectBase is CombatSkillEffectBase { IsLegendaryBookEffect: false } effect2))
			{
				continue;
			}
			effect2.CharObj = taiwuChar;
			effect2.CharacterId = taiwuCharId;
			effect2.SkillKey.CharId = taiwuCharId;
			collectedEffects.Add(effectWrapper2);
			if (!IsErrorEffect(effect2))
			{
				if (existEffects.TryGetValue(effect2.Type, out var existEffect))
				{
					effect2.Id = existEffect.Id;
					DomainManager.Extra.AddConflictSpecialEffect(context, effectWrapper2);
				}
				else
				{
					effect2.OnDreamBack(context);
					Add(context, effect2);
					effect2.SkillInstance.SetSpecialEffectId(effect2.Id, context);
				}
			}
		}
		foreach (SpecialEffectWrapper collectedEffect in collectedEffects)
		{
			taiwuEffects.Remove(collectedEffect);
		}
	}

	public void OverwriteSpecialEffectWithConflictCombatSkill(DataContext context, ConflictCombatSkill conflictCombatSkill)
	{
		if (!DomainManager.Extra.TryGetConflictCombatSkillEffect(conflictCombatSkill.TemplateId, out var effect))
		{
			return;
		}
		effect.CharObj = DomainManager.Taiwu.GetTaiwu();
		effect.CharacterId = DomainManager.Taiwu.GetTaiwuCharId();
		effect.SkillKey.CharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (IsErrorEffect(effect))
		{
			return;
		}
		if (!_effectDict.ContainsKey(effect.Id))
		{
			foreach (var (effectId, effectWrapper) in _effectDict)
			{
				if (effectWrapper.Effect.CharacterId == effect.CharacterId && effectWrapper.Effect.Type == effect.Type)
				{
					effect.Id = effectId;
				}
			}
		}
		Remove(context, effect.Id);
		effect.OnDreamBack(context);
		Add(context, effect);
		effect.SkillInstance.SetSpecialEffectId(effect.Id, context);
	}

	public SpecialEffectDomain()
		: base(3)
	{
		_effectDict = new Dictionary<long, SpecialEffectWrapper>(0);
		_nextEffectId = 0L;
		_affectedDatas = new Dictionary<int, AffectedData>(0);
		HelperDataAffectedDatas = new ObjectCollectionHelperData(17, 2, CacheInfluencesAffectedDatas, _dataStatesAffectedDatas, isArchive: false);
		OnInitializedDomainData();
	}

	private SpecialEffectWrapper GetElement_EffectDict(long elementId)
	{
		return _effectDict[elementId];
	}

	private bool TryGetElement_EffectDict(long elementId, out SpecialEffectWrapper value)
	{
		return _effectDict.TryGetValue(elementId, out value);
	}

	private void AddElement_EffectDict(long elementId, SpecialEffectWrapper value, DataContext context)
	{
		_effectDict.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void SetElement_EffectDict(long elementId, SpecialEffectWrapper value, DataContext context)
	{
		_effectDict[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_EffectDict(long elementId, DataContext context)
	{
		_effectDict.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void ClearEffectDict(DataContext context)
	{
		_effectDict.Clear();
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private long GetNextEffectId()
	{
		return _nextEffectId;
	}

	private void SetNextEffectId(long value, DataContext context)
	{
		_nextEffectId = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private AffectedData GetElement_AffectedDatas(int objectId)
	{
		return _affectedDatas[objectId];
	}

	private bool TryGetElement_AffectedDatas(int objectId, out AffectedData element)
	{
		return _affectedDatas.TryGetValue(objectId, out element);
	}

	private void AddElement_AffectedDatas(int objectId, AffectedData instance)
	{
		instance.CollectionHelperData = HelperDataAffectedDatas;
		instance.DataStatesOffset = _dataStatesAffectedDatas.Create();
		_affectedDatas.Add(objectId, instance);
	}

	private void RemoveElement_AffectedDatas(int objectId)
	{
		if (_affectedDatas.TryGetValue(objectId, out var instance))
		{
			_dataStatesAffectedDatas.Remove(instance.DataStatesOffset);
			_affectedDatas.Remove(objectId);
		}
	}

	private void ClearAffectedDatas()
	{
		_dataStatesAffectedDatas.Clear();
		_affectedDatas.Clear();
	}

	private void ResetModifiedWrapper_AffectedDatas(int objectId, ushort fieldId)
	{
		if (_affectedDatas.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 345)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesAffectedDatas.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesAffectedDatas.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_AffectedDatas(int objectId, ushort fieldId)
	{
		if (!_affectedDatas.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 345)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesAffectedDatas.IsModified(instance.DataStatesOffset, fieldId);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)2);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_effectDict);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueUnmanaged(_nextEffectId);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			switch (domainDataMeta.DataId)
			{
			case 0:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_effectDict);
				break;
			case 1:
				archive.ReadSingleValueUnmanaged(ref _nextEffectId);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(17);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 1:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 2:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 2:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				short skillId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId2);
				List<CastBoostEffectDisplayData> returnValue2 = GetAllCostNeiliEffectData(charId3, skillId2);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 3)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				short skillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId);
				short effectId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectId);
				CostNeiliEffect(context, charId2, skillId, effectId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				short skillId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId3);
				bool returnValue3 = CanCostTrickDuringPreparingSkill(charId4, skillId3);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 2)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				int trickIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref trickIndex);
				bool returnValue = CostTrickDuringPreparingSkill(context, charId, trickIndex);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		switch (dataId)
		{
		case 0:
			return;
		case 1:
			return;
		case 2:
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 2:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 2:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		case 2:
			throw new Exception($"Not allow to verify modification state of dataId {dataId}");
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 2:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _affectedDatas, influencedObjects))
				{
					int influencedObjectsCount = influencedObjects.Count;
					for (int i = 0; i < influencedObjectsCount; i++)
					{
						BaseGameDataObject targetObject = influencedObjects[i];
						List<DataUid> targetUids = influence.TargetUids;
						int targetUidsCount = targetUids.Count;
						for (int j = 0; j < targetUidsCount; j++)
						{
							targetObject.InvalidateSelfAndInfluencedCache((ushort)targetUids[j].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesAffectedDatas, _dataStatesAffectedDatas, influence, context);
				}
				influencedObjects.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesAffectedDatas, _dataStatesAffectedDatas, influence, context);
			}
			break;
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
		case 1:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
		foreach (KeyValuePair<int, AffectedData> affectedData in _affectedDatas)
		{
			AffectedData instance = affectedData.Value;
			instance.CollectionHelperData = HelperDataAffectedDatas;
			instance.DataStatesOffset = _dataStatesAffectedDatas.Create();
		}
	}

	public static void RegisterResetHandler(Action action)
	{
		ResetOnInitializeGameDataModuleEffects.Add(action);
	}

	private static void InvokeResetHandlers()
	{
		foreach (Action effectHandler in ResetOnInitializeGameDataModuleEffects)
		{
			effectHandler();
		}
	}
}
