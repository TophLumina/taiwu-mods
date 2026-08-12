using System.Collections.Generic;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthGetSupplyModification
{
	public Character Character;

	public bool PersonalNeedChanged;

	public bool ResourceChanged;

	public List<(sbyte type, short templateId, int amount)> ItemsToCreate;

	public bool IsChanged => PersonalNeedChanged || ResourceChanged || ItemsToCreate != null;

	public PeriAdvanceMonthGetSupplyModification(Character character)
	{
		Character = character;
	}

	public void AddItemToCreate(sbyte type, short templateId, int amount)
	{
		if (ItemsToCreate == null)
		{
			ItemsToCreate = new List<(sbyte, short, int)>();
		}
		ItemsToCreate.Add((type, templateId, amount));
	}
}
