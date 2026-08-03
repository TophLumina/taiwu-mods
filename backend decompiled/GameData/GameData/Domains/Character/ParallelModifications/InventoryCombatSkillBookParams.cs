namespace GameData.Domains.Character.ParallelModifications;

public readonly struct InventoryCombatSkillBookParams(short templateId, byte pageTypes)
{
	public readonly short TemplateId = templateId;

	public readonly byte PageTypes = pageTypes;
}
