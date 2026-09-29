using System.Collections.Generic;
using Config;

namespace GameData.Utilities;

public interface IItemConfig
{
	short TemplateId { get; }

	sbyte ItemType { get; }

	short ItemSubType { get; }

	string Name { get; }

	string Icon { get; }

	sbyte Grade { get; }

	short GroupId { get; }

	sbyte MaxUseDistance => 0;

	short Duration => 0;

	int BaseValue { get; }

	MysteryEffectItem MysteryEffect => Config.MysteryEffect.Instance[MysteryEffectId];

	int MysteryEffectId => -1;

	int EquipmentMasteryId => -1;

	short MakeItemSubType => -1;

	List<int> TaskLock { get; }
}
