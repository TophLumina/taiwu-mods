namespace GameData.Domains.Item;

public static class ItemKeyHelper
{
	public static IItemData GetData(this ItemKey itemKey)
	{
		return DomainManager.Item.GetBaseItem(itemKey);
	}
}
