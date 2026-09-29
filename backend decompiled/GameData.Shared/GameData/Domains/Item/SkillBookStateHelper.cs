namespace GameData.Domains.Item;

public static class SkillBookStateHelper
{
	public static byte SetOutlinePageType(byte pageTypes, sbyte behaviorType)
	{
		return (byte)((pageTypes & 0xF8) | (byte)behaviorType);
	}

	public static sbyte GetOutlinePageType(byte pageTypes)
	{
		return (sbyte)(pageTypes & 7);
	}

	public static byte SetNormalPageType(byte pageTypes, byte pageId, sbyte direction)
	{
		int index = 3 + pageId - 1;
		return (byte)((direction == 0) ? (pageTypes & ~(1 << index)) : (pageTypes | (1 << index)));
	}

	public static sbyte GetNormalPageType(byte pageTypes, byte pageId)
	{
		int index = 3 + pageId - 1;
		return ((pageTypes & (1 << index)) != 0) ? ((sbyte)1) : ((sbyte)0);
	}

	public static ushort SetPageIncompleteState(ushort pageIncompleteState, byte pageId, sbyte state)
	{
		int index = pageId * 2;
		return (ushort)((pageIncompleteState & ~(3 << index)) | (state << index));
	}

	public static sbyte GetPageIncompleteState(ushort pageIncompleteState, byte pageId)
	{
		int index = pageId * 2;
		return (sbyte)((pageIncompleteState >> index) & 3);
	}

	public static int GetTotalIncompleteStateValue(ushort pageIncompleteState, int pageCount)
	{
		int stateVal = 0;
		for (byte pageId = 0; pageId < pageCount; pageId++)
		{
			sbyte incompleteState = GetPageIncompleteState(pageIncompleteState, pageId);
			stateVal += SkillBookPageIncompleteState.BaseReadingSpeed[incompleteState] / 2;
		}
		return stateVal;
	}
}
