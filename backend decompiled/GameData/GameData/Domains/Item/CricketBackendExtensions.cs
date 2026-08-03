namespace GameData.Domains.Item;

public static class CricketBackendExtensions
{
	public static string CalcCricketName(this ItemKey key)
	{
		if (key.ItemType != 11 || !DomainManager.Item.TryGetElement_Crickets(key.Id, out var cricket))
		{
			return string.Empty;
		}
		short colorId = cricket.GetColorId();
		short partId = cricket.GetPartId();
		return (colorId: colorId, partId: partId).CalcCricketName();
	}
}
