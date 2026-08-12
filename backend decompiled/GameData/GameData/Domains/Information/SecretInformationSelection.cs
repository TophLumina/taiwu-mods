namespace GameData.Domains.Information;

public class SecretInformationSelection
{
	public static class SelectionGroupKeys
	{
		public static readonly string Normal = "NormalSelection";

		public static readonly string Special = "SpecialSelection";

		public static readonly string MainAttributeCost = "MainAttributeCost";

		public static readonly string FiveBehavior = "FiveBehavior";

		public static readonly string OtherOption = "OtherOption";
	}

	public static class SelectionArgKey
	{
		public static readonly string Visible = "Visible";

		public static readonly string Available = "Available";

		public static readonly string ResultIndex = "ResultIndex";

		public static readonly string Content = "Content";

		public static readonly string Cost = "Cost";
	}

	public enum SelectionGroup
	{
		Normal,
		Special,
		MainAttributeCost,
		FiveBehavior,
		OtherOption
	}

	public struct SelectionItem(short templateId, short priority, string content, SelectionGroup selectionGroup, bool available, short resultIndex, short extraIndex, short extraValue)
	{
		public short TemplateId = templateId;

		public short Priority = priority;

		public string Content = content;

		public SelectionGroup SelectionGroup = selectionGroup;

		public bool Available = available;

		public short ResultIndex = resultIndex;

		public short ExtraIndex = extraIndex;

		public short ExtraValue = extraValue;
	}
}
