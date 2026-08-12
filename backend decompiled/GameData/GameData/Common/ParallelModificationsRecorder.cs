using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Domains;
using GameData.Domains.Adventure.Modifications;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Common;

public class ParallelModificationsRecorder
{
	private const int DataPoolInitialCapacity = 1048576;

	private const int ObjectsInitialCapacity = 16384;

	private readonly RawDataPool _dataPool;

	private readonly List<object> _objects;

	public ParallelModificationsRecorder()
	{
		_dataPool = new RawDataPool(1048576);
		_objects = new List<object>(16384);
	}

	public void RecordType(ParallelModificationType type)
	{
		_dataPool.AddUnmanaged(type);
	}

	public void RecordParameterUnmanaged<T>(T value) where T : unmanaged
	{
		_dataPool.AddUnmanaged(value);
	}

	public unsafe void RecordParameterNonTrivialStruct<T>(T value) where T : struct, ISerializableGameData
	{
		byte* pData = default(byte*);
		_dataPool.Allocate(value.GetSerializedSize(), &pData);
		value.Serialize(pData);
	}

	public void RecordParameterClass<T>(T value) where T : class
	{
		int index = _objects.Count;
		_dataPool.AddUnmanaged(index);
		_objects.Add(value);
	}

	public unsafe void ApplyAll(DataContext context)
	{
		int dataSize = _dataPool.RawDataSize;
		if (dataSize > 0)
		{
			byte* pData = _dataPool.GetPointer(0);
			byte* pEnd = pData + dataSize;
			while (pData < pEnd)
			{
				pData = Apply(context, pData);
			}
			_dataPool.Clear();
			_objects.Clear();
		}
	}

	private unsafe byte* Apply(DataContext context, byte* pData)
	{
		ParallelModificationType type = *(ParallelModificationType*)pData;
		pData += 2;
		switch (type)
		{
		case ParallelModificationType.CreateIntelligentCharacter:
		{
			CreateIntelligentCharacterModification mod15 = (CreateIntelligentCharacterModification)_objects[*(int*)pData];
			pData += 4;
			bool autoComplement = *pData != 0;
			pData++;
			DomainManager.Character.ComplementCreateIntelligentCharacter(context, mod15, autoComplement);
			return pData;
		}
		case ParallelModificationType.CreateNewbornChildren:
		{
			CreateNewBornChildrenModification mod14 = (CreateNewBornChildrenModification)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Character.ComplementCreateNewbornChildren(context, mod14);
			return pData;
		}
		case ParallelModificationType.SetInitialCombatSkillBreakouts:
		{
			List<CombatSkillInitialBreakoutData> brokenOutSkills = (List<CombatSkillInitialBreakoutData>)_objects[*(int*)pData];
			pData += 4;
			Character character9 = (Character)_objects[*(int*)pData];
			pData += 4;
			NeiliProportionOfFiveElements neiliProportion = *(NeiliProportionOfFiveElements*)pData;
			pData += sizeof(NeiliProportionOfFiveElements);
			int[] extraNeiliAllocationProgress = (int[])_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementSetInitialCombatSkillBreakouts(context, brokenOutSkills, character9, neiliProportion, extraNeiliAllocationProgress);
			return pData;
		}
		case ParallelModificationType.SetInitialCombatSkillAttainmentPanels:
		{
			Character character8 = (Character)_objects[*(int*)pData];
			pData += 4;
			short[] panels = (short[])_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementSetInitialCombatSkillAttainmentPanels(context, character8, panels);
			return pData;
		}
		case ParallelModificationType.PracticeAndBreakoutCombatSkills:
		{
			PracticeAndBreakoutModification mod13 = (PracticeAndBreakoutModification)_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementPracticeAndBreakoutCombatSkill(context, mod13);
			return pData;
		}
		case ParallelModificationType.ActivateCombatSkillPages:
		{
			List<(CombatSkill, ushort)> newlyActivatedCombatSkills = (List<(CombatSkill, ushort)>)_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementActivateCombatSkillPages(context, newlyActivatedCombatSkills);
			return pData;
		}
		case ParallelModificationType.UpdateBreakPlateBonuses:
		{
			UpdateBreakPlateBonusesModification mod12 = (UpdateBreakPlateBonusesModification)_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementUpdateBreakPlateBonuses(context, mod12);
			return pData;
		}
		case ParallelModificationType.SelectEquipments:
		{
			SelectEquipmentsModification mod11 = (SelectEquipmentsModification)_objects[*(int*)pData];
			pData += 4;
			Equipping.ComplementSelectEquipments(context, mod11);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthMixedPoisonEffect:
		{
			Character character7 = (Character)_objects[*(int*)pData];
			pData += 4;
			List<(sbyte, int)> mixedPoisonInfoList = (List<(sbyte, int)>)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_MixedPoisonEffect(context, character7, mixedPoisonInfoList);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthUpdateStatus:
		{
			PeriAdvanceMonthUpdateStatusModification mod10 = (PeriAdvanceMonthUpdateStatusModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_UpdateStatus(context, mod10);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthSelfImprovement:
		{
			PeriAdvanceMonthSelfImprovementModification mod9 = (PeriAdvanceMonthSelfImprovementModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_SelfImprovement(context, mod9);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthSelfImprovementLearnNewSkills:
		{
			Character character6 = (Character)_objects[*(int*)pData];
			pData += 4;
			(short, short, byte) combatSkillToLearn = Unsafe.Read<(short, short, byte)>(pData);
			pData += Unsafe.SizeOf<(short, short, byte)>();
			(short, short, byte) lifeSkillToLearn = Unsafe.Read<(short, short, byte)>(pData);
			pData += Unsafe.SizeOf<(short, short, byte)>();
			Character.ComplementPeriAdvanceMonth_SelfImprovement_LearnNewSkills(context, character6, combatSkillToLearn, lifeSkillToLearn);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthSelfImprovementReading:
		{
			Character character5 = (Character)_objects[*(int*)pData];
			pData += 4;
			SkillBook readingBook = (SkillBook)_objects[*(int*)pData];
			pData += 4;
			int learnedSkillIndex = *(int*)pData;
			pData += 4;
			byte readingPage = *pData;
			pData++;
			sbyte succeedPageCount = (sbyte)(*pData);
			pData++;
			Character.ComplementPeriAdvanceMonth_SelfImprovement_Reading(context, character5, readingBook, learnedSkillIndex, readingPage, succeedPageCount);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthActivePreparationGetSupply:
		{
			PeriAdvanceMonthGetSupplyModification mod8 = (PeriAdvanceMonthGetSupplyModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_ActivePreparation_GetSupply(context, mod8);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthActivePreparation:
		{
			PeriAdvanceMonthActivePreparationModification mod7 = (PeriAdvanceMonthActivePreparationModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_ActivePreparation(context, mod7);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthLoseOverloadItems:
		{
			PeriAdvanceMonthLoseOverloadItemsModification mod6 = (PeriAdvanceMonthLoseOverloadItemsModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_LoseOverloadItems(context, mod6);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthRelationsUpdate:
		{
			PeriAdvanceMonthRelationsUpdateModification mod5 = (PeriAdvanceMonthRelationsUpdateModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_RelationsUpdate(context, mod5);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthExecuteFixedActions:
		{
			PeriAdvanceMonthFixedActionModification mod4 = (PeriAdvanceMonthFixedActionModification)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_ExecuteFixedActions(context, mod4);
			return pData;
		}
		case ParallelModificationType.PostAdvanceMonthUpdateMissions:
		{
			Character character4 = (Character)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPostAdvanceMonth_UpdateMissions(context, character4);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthUpdateGoals:
		{
			Character character3 = (Character)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPostAdvanceMonth_UpdateGoals(context, character3);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthUpdatePrimaryGoalAndActions:
		{
			Character character2 = (Character)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_UpdatePrimaryGoalAndActions(context, character2);
			return pData;
		}
		case ParallelModificationType.PeriAdvanceMonthUpdateSecondaryGoalAndActions:
		{
			Character character = (Character)_objects[*(int*)pData];
			pData += 4;
			Character.ComplementPeriAdvanceMonth_UpdateSecondaryGoalAndActions(context, character);
			return pData;
		}
		case ParallelModificationType.UpdateMapArea:
		{
			ParallelMapAreaModification mod3 = (ParallelMapAreaModification)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Map.ComplementUpdateMapArea(context, mod3);
			return pData;
		}
		case ParallelModificationType.UpdateBrokenArea:
		{
			MapBlockData block = (MapBlockData)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Map.SetBlockData(context, block);
			return pData;
		}
		case ParallelModificationType.UpdateBuilding:
		{
			ParallelBuildingModification modification = (ParallelBuildingModification)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Building.ComplementUpdateBuilding(context, modification);
			return pData;
		}
		case ParallelModificationType.PreAdvanceMonthUpdateRandomEnemies:
		{
			PreAdvanceMonthRandomEnemiesModification mod2 = (PreAdvanceMonthRandomEnemiesModification)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Adventure.ComplementPreAdvanceMonth_UpdateRandomEnemies(context, mod2);
			return pData;
		}
		case ParallelModificationType.PreAdvanceMonthUpdateNpcTaming:
		{
			PreAdvanceMonthNpcTamingModification mod = (PreAdvanceMonthNpcTamingModification)_objects[*(int*)pData];
			pData += 4;
			DomainManager.Extra.ComplementPreAdvanceMonth_UpdateNpcTaming(context, mod);
			return pData;
		}
		default:
			throw new Exception($"Unsupported ParallelModificationType: {type}");
		}
	}
}
