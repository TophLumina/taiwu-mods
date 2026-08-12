namespace GameData.Domains.Character.Ai;

public class AdjustableAiActionType
{
	public const sbyte InvalidSubType = -1;

	public const sbyte AcquireItem = 0;

	public const sbyte AcquireResource = 1;

	public const sbyte AcquireCombatSkill = 2;

	public const sbyte AcquireLifeSkill = 3;

	public const sbyte MakeLove = 4;

	public const sbyte Harm = 5;

	public const sbyte EatForbiddenFood = 6;

	public const sbyte KillInPrivate = 7;

	public const sbyte KidnapInPrivate = 8;

	public const sbyte AddPoisonToItem = 9;

	public const sbyte StartRelation = 10;

	public const sbyte LifeSkillCombatForceSilent = 11;
}
