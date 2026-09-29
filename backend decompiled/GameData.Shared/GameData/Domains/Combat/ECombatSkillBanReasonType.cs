namespace GameData.Domains.Combat;

public enum ECombatSkillBanReasonType : sbyte
{
	None = -1,
	Undefined,
	StanceNotEnough,
	BreathNotEnough,
	MobilityNotEnough,
	TrickNotEnough,
	WugNotEnough,
	NeiliAllocationNotEnough,
	WeaponTrickMismatch,
	WeaponDestroyed,
	BodyPartBroken,
	SpecialEffectBan,
	CombatConfigBan,
	Silencing
}
