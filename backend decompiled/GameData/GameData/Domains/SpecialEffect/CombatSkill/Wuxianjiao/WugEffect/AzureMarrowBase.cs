using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class AzureMarrowBase : WugEffectBase
{
	private const int MakeLoveRateAddPercent = 100;

	private const int AddPoisonTypeCount = 3;

	private const int AddPoisonLevel = 3;

	private const int AddPoisonValue = 3600;

	private const int ChangeWugCount = 3;

	private bool _affected;

	protected AzureMarrowBase()
	{
	}

	protected AzureMarrowBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 28;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsGrown)
		{
			CreateAffectedData(267, EDataModifyType.TotalPercent, -1);
			CreateAffectedData(298, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(292, EDataModifyType.Add, -1);
		}
		if (base.IsGrown)
		{
			Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		Events.RegisterHandler_MakeLove(OnMakeLove);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsGrown)
		{
			Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		Events.UnRegisterHandler_MakeLove(OnMakeLove);
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		Events.RegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		Events.UnRegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			267 => 100, 
			292 => base.IsElite ? (base.IsGood ? 1 : (-1)) : 0, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 298 || !base.CanAffect)
		{
			return dataValue;
		}
		return true;
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		if (!base.CanAffect)
		{
			return;
		}
		Location location = CharObj.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 1, includeCenter: true);
		IEnumerable<GameData.Domains.Character.Character> neighborChars = neighborBlocks.Where((MapBlockData x) => x.CharacterSet != null).SelectMany((MapBlockData x) => x.CharacterSet).Select(DomainManager.Character.GetElement_Objects);
		HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		if (groupCharIds.Contains(CharObj.GetId()))
		{
			neighborChars = neighborChars.Union(groupCharIds.Select(DomainManager.Character.GetElement_Objects));
		}
		if (neighborChars.All((GameData.Domains.Character.Character x) => x.GetGender() == CharObj.GetGender()))
		{
			List<sbyte> poisonTypes = ObjectPool<List<sbyte>>.Instance.Get();
			poisonTypes.Clear();
			for (sbyte i = 0; i < 6; i++)
			{
				poisonTypes.Add(i);
			}
			CollectionUtils.Shuffle(context.Random, poisonTypes);
			for (int i2 = 0; i2 < 3; i2++)
			{
				sbyte poisonType = poisonTypes[i2];
				CharObj.ChangePoisoned(context, poisonType, 3, 3600);
			}
			ObjectPool<List<sbyte>>.Instance.Return(poisonTypes);
			LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
			AddLifeRecord(lifeRecord.AddWugAzureMarrowAddPoison);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	private void OnMakeLove(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character target, sbyte makeLoveState)
	{
		if (!base.CanAffect || !CheckValid() || (character.GetId() != base.CharacterId && target.GetId() != base.CharacterId) || makeLoveState == 4 || character.GetGender() == target.GetGender())
		{
			return;
		}
		GameData.Domains.Character.Character addWugChar = ((character.GetId() == base.CharacterId) ? target : character);
		int addWugCharId = addWugChar.GetId();
		EatingItems eatingItems = addWugChar.GetEatingItems();
		LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
		int existIndex = eatingItems.IndexOfWug(WugConfig.WugType);
		MedicineItem existConfig = ((existIndex < 0) ? null : Config.Medicine.Instance[eatingItems.Get(existIndex).TemplateId]);
		if (base.IsGrown && base.IsElite && existConfig?.WugGrowthType != 4)
		{
			short addWugTemplateId = ItemDomain.GetWugTemplateId(WugConfig.WugType, 3);
			addWugChar.AddWug(context, addWugTemplateId, -1);
			AddLifeRecord(lifeRecord.AddWugAzureMarrowAddWug, addWugCharId, addWugTemplateId);
		}
		else if (base.CanChangeToGrown)
		{
			short grownId = ItemDomain.GetWugTemplateId(WugConfig.WugType, 4);
			if (WugGrowthType.CanChangeToGrown(existConfig?.WugGrowthType ?? (-1)))
			{
				CharObj.AddWug(context, grownId, -1);
				AddLifeRecord(lifeRecord.AddWugAzureMarrowChangeToGrown, addWugCharId, base.CharacterId, grownId);
			}
			else
			{
				CharObj.RemoveWug(context, WugConfig.TemplateId);
			}
			addWugChar.AddWug(context, grownId, -1);
			AddLifeRecord(lifeRecord.AddWugAzureMarrowChangeToGrown, addWugChar.GetId(), grownId);
		}
	}

	private void OnAddFatalDamageMark(DataContext context, CombatCharacter combatChar, int count)
	{
		if (combatChar.GetId() == base.CharacterId && !_affected && base.CanAffect)
		{
			_affected = true;
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		_affected = false;
		List<short> prefer = ObjectPool<List<short>>.Instance.Get();
		List<short> normal = ObjectPool<List<short>>.Instance.Get();
		prefer.Clear();
		normal.Clear();
		EatingItems eatingItems = CharObj.GetEatingItems();
		for (sbyte wugType = 0; wugType < 8; wugType++)
		{
			if (wugType != WugConfig.WugType)
			{
				int index = eatingItems.IndexOfWug(wugType);
				if (index >= 0)
				{
					sbyte oldWugGrowthType = Config.Medicine.Instance[eatingItems.Get(index).TemplateId].WugGrowthType;
					sbyte newWugGrowthType = GetChangedWugGrowthType(oldWugGrowthType);
					if (newWugGrowthType >= 0)
					{
						short newWug = ItemDomain.GetWugTemplateId(wugType, newWugGrowthType);
						if (WugGrowthType.IsWugGrowthTypeCombatOnly(oldWugGrowthType))
						{
							prefer.Add(newWug);
						}
						else
						{
							normal.Add(newWug);
						}
					}
				}
			}
		}
		bool affected = false;
		foreach (short newWug2 in RandomUtils.GetRandomUnrepeated(context.Random, 3, prefer, normal))
		{
			combatChar.AddWug(context, newWug2, base.CharacterId, EWugReplaceType.All, -1);
			ShowEffectTips(context, (byte)((!base.IsGood || !normal.Contains(newWug2)) ? 1u : 2u));
			affected = true;
		}
		if (affected)
		{
			CostWugInCombat(context);
		}
		ObjectPool<List<short>>.Instance.Return(prefer);
		ObjectPool<List<short>>.Instance.Return(normal);
	}

	private sbyte GetChangedWugGrowthType(sbyte oldGrowthType)
	{
		if (WugGrowthType.IsWugGrowthTypeCombatOnly(oldGrowthType))
		{
			return (sbyte)(base.IsGood ? 1 : 3);
		}
		if (oldGrowthType == 4)
		{
			return (sbyte)(base.IsGood ? 1 : (-1));
		}
		return (sbyte)(base.IsGood ? (-1) : 4);
	}
}
