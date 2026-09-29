namespace GameData.Domains.Item;

public interface IItemData
{
	ItemKey Key { get; }

	int Value { get; }

	short Durability { get; }

	short MaxDurability { get; }
}
