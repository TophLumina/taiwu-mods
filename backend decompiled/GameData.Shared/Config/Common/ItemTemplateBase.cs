namespace Config.Common;

public abstract class ItemTemplateBase
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte ItemType;

	public readonly short ItemSubType;

	public readonly sbyte Grade;

	public readonly string Icon;

	public readonly string Desc;

	public readonly bool Transferable;

	public readonly bool Stackable;

	public readonly bool Wagerable;

	public readonly bool Refinable;

	public readonly bool Poisonable;

	public readonly bool Repairable;

	public readonly short MaxDurability;

	public readonly int BaseWeight;

	public readonly int BaseValue;

	public readonly int BasePrice;

	public readonly sbyte HappinessChange;

	public readonly int FavorabilityChange;

	public readonly sbyte GiftLevel;

	public readonly sbyte DropRate;

	public readonly sbyte ResourceType;

	public readonly short PreservationDuration;
}
