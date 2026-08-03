namespace GameData.Domains.Combat;

public enum CombatCharacterStateType : sbyte
{
	Invalid = -1,
	Idle,
	SelectChangeTrick,
	PrepareAttack,
	BreakAttack,
	Attack,
	PrepareUnlockAttack,
	UnlockAttack,
	RawCreate,
	PrepareSkill,
	CastSkill,
	PrepareOtherAction,
	PrepareUseItem,
	UseItem,
	SelectMercy,
	DelaySettlement,
	ChangeCharacter,
	TeammateCommand,
	ChangeBossPhase,
	JumpMove,
	AnimalAttack,
	SpecialShow
}
