namespace GameData.Domains.Character.ParallelModifications;

public readonly struct AddOrIncreaseInjuryParams(sbyte bodyPartType, bool isInnerInjury, sbyte injuryValue)
{
	public readonly sbyte BodyPartType = bodyPartType;

	public readonly bool IsInnerInjury = isInnerInjury;

	public readonly sbyte InjuryValue = injuryValue;
}
