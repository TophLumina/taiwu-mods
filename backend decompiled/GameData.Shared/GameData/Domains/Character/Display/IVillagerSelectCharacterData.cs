namespace GameData.Domains.Character.Display;

public interface IVillagerSelectCharacterData : ISelectCharacterData
{
	sbyte WorkType { get; }

	byte WorkStatus { get; }

	int ArrangementTemplateId { get; }

	int BuildingBlockTemplateId { get; }

	bool IsBuyOperation { get; }

	int GraveId { get; }

	int SwordTombId { get; }

	int RoleTemplateId { get; }
}
