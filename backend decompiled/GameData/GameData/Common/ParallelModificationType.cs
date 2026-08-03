namespace GameData.Common;

public enum ParallelModificationType : ushort
{
	[ParallelModification(4, "ComplementCreateIntelligentCharacter")]
	CreateIntelligentCharacter,
	[ParallelModification(4, "ComplementCreateNewbornChildren")]
	CreateNewbornChildren,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementSetInitialCombatSkillBreakouts")]
	SetInitialCombatSkillBreakouts,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementSetInitialCombatSkillAttainmentPanels")]
	SetInitialCombatSkillAttainmentPanels,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementPracticeAndBreakoutCombatSkill")]
	PracticeAndBreakoutCombatSkills,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementActivateCombatSkillPages")]
	ActivateCombatSkillPages,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementUpdateBreakPlateBonuses")]
	UpdateBreakPlateBonuses,
	[ParallelModification("GameData.Domains.Character.Ai.Equipping", "ComplementSelectEquipments")]
	SelectEquipments,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_MixedPoisonEffect")]
	PeriAdvanceMonthMixedPoisonEffect,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_UpdateStatus")]
	PeriAdvanceMonthUpdateStatus,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_SelfImprovement")]
	PeriAdvanceMonthSelfImprovement,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_SelfImprovement_LearnNewSkills")]
	PeriAdvanceMonthSelfImprovementLearnNewSkills,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_SelfImprovement_Reading")]
	PeriAdvanceMonthSelfImprovementReading,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_ActivePreparation_GetSupply")]
	PeriAdvanceMonthActivePreparationGetSupply,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_ActivePreparation")]
	PeriAdvanceMonthActivePreparation,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_LoseOverloadItems")]
	PeriAdvanceMonthLoseOverloadItems,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_RelationsUpdate")]
	PeriAdvanceMonthRelationsUpdate,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_ExecuteFixedActions")]
	PeriAdvanceMonthExecuteFixedActions,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPostAdvanceMonth_UpdateMissions")]
	PostAdvanceMonthUpdateMissions,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPostAdvanceMonth_UpdateGoals")]
	PeriAdvanceMonthUpdateGoals,
	PeriAdvanceMonthUpdateActions,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_UpdatePrimaryGoalAndActions")]
	PeriAdvanceMonthUpdatePrimaryGoalAndActions,
	[ParallelModification("GameData.Domains.Character.Character", "ComplementPeriAdvanceMonth_UpdateSecondaryGoalAndActions")]
	PeriAdvanceMonthUpdateSecondaryGoalAndActions,
	[ParallelModification(2, "ComplementUpdateMapArea")]
	UpdateMapArea,
	[ParallelModification(2, "SetBlockData")]
	UpdateBrokenArea,
	[ParallelModification(9, "ComplementUpdateBuilding")]
	UpdateBuilding,
	[ParallelModification(10, "ComplementPreAdvanceMonth_UpdateRandomEnemies")]
	PreAdvanceMonthUpdateRandomEnemies,
	[ParallelModification(19, "ComplementPreAdvanceMonth_UpdateNpcTaming")]
	PreAdvanceMonthUpdateNpcTaming
}
