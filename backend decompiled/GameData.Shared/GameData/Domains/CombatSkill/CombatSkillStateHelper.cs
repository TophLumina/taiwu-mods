using System;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillStateHelper
{
	public const int OutlinePagesCount = 5;

	private const int TotalNormalPagesCount = 10;

	public const int TotalPagesCount = 15;

	public const ushort CompleteReadingState = 32767;

	public const ushort BreakoutRequiredNormalPageCount = 5;

	public static byte GetPageInternalIndex(sbyte behaviorType, sbyte direction, byte pageId)
	{
		return (byte)((pageId == 0) ? behaviorType : (5 + direction * 5 + pageId - 1));
	}

	public static byte GetPageInternalIndex(byte pageTypes, byte pageId)
	{
		sbyte outlinePageType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
		sbyte direction = SkillBookStateHelper.GetNormalPageType(pageTypes, pageId);
		return GetPageInternalIndex(outlinePageType, direction, pageId);
	}

	public static byte GetNormalPageOppositeInternalIndex(byte pageInternalIndex)
	{
		if (pageInternalIndex < 5)
		{
			throw new ArgumentOutOfRangeException("pageInternalIndex", $"The pageInternalIndex {pageInternalIndex} must be a normal page index.");
		}
		if (pageInternalIndex < 10)
		{
			return (byte)(pageInternalIndex + 5);
		}
		if (pageInternalIndex < 15)
		{
			return (byte)(pageInternalIndex - 5);
		}
		throw new ArgumentOutOfRangeException("pageInternalIndex", $"The pageInternalIndex {pageInternalIndex} is out of range.");
	}

	public static byte GetOutlinePageInternalIndex(sbyte behaviorType)
	{
		return (byte)behaviorType;
	}

	public static byte GetNormalPageInternalIndex(sbyte direction, byte pageId)
	{
		return (byte)(5 + direction * 5 + pageId - 1);
	}

	public static byte GetPageId(byte pageInternalIndex)
	{
		if (pageInternalIndex >= 5)
		{
			return (byte)((pageInternalIndex - 5) % 5 + 1);
		}
		return 0;
	}

	public static bool IsPageRead(ushort readingState, byte pageInternalIndex)
	{
		return (readingState & (1 << (int)pageInternalIndex)) != 0;
	}

	public static ushort SetPageRead(ushort readingState, byte pageInternalIndex)
	{
		return (ushort)(readingState | (1 << (int)pageInternalIndex));
	}

	public static ushort SetPageUnread(ushort readingState, byte pageInternalIndex)
	{
		return (ushort)(readingState & ~(1 << (int)pageInternalIndex));
	}

	public static bool HasReadOutlinePage(ushort readingState, sbyte behaviorType)
	{
		byte internalIndex = GetOutlinePageInternalIndex(behaviorType);
		return IsPageRead(readingState, internalIndex);
	}

	public static bool HasReadOutlinePages(ushort readingState)
	{
		return (readingState & 0x1F) != 0;
	}

	public static int GetReadPagesCount(ushort readingState)
	{
		uint state = readingState;
		int count = 0;
		while (state != 0)
		{
			state &= state - 1;
			count++;
		}
		return count;
	}

	public static int GetReadNormalPagesCount(ushort readingState)
	{
		uint state = (uint)readingState >> 5;
		int count = 0;
		while (state != 0)
		{
			state &= state - 1;
			count++;
		}
		return count;
	}

	public static int GetCanActivateNormalPagesCount(ushort readingState)
	{
		int pageCount = 0;
		for (int i = 0; i < 5; i++)
		{
			byte directIndex = (byte)(5 + i);
			byte reverseIndex = (byte)(directIndex + 5);
			if ((readingState & (1 << (int)directIndex)) != 0 || (readingState & (1 << (int)reverseIndex)) != 0)
			{
				pageCount++;
			}
		}
		return pageCount;
	}

	public static bool IsReadNormalPagesMeetConditionOfBreakout(ushort readingState)
	{
		return GetCanActivateNormalPagesCount(readingState) >= 5;
	}

	public static bool CanEquipOnAttainmentPanel(ushort readingState, bool revoked)
	{
		if (!revoked && HasReadOutlinePages(readingState))
		{
			return IsReadNormalPagesMeetConditionOfBreakout(readingState);
		}
		return false;
	}

	public static byte GetNextPageToRead(ushort readingState)
	{
		for (int i = 0; i < 5; i++)
		{
			byte directIndex = (byte)(5 + i);
			if ((readingState & (1 << (int)directIndex)) == 0)
			{
				byte reverseIndex = (byte)(directIndex + 5);
				if ((readingState & (1 << (int)reverseIndex)) == 0)
				{
					return (byte)(i + 1);
				}
			}
		}
		return 6;
	}

	public static int CalcPagesToBeReadForActivation(ushort readingState)
	{
		int pageCount = ((!HasReadOutlinePages(readingState)) ? 1 : 0);
		for (int i = 0; i < 5; i++)
		{
			byte directIndex = (byte)(5 + i);
			byte reverseIndex = (byte)(directIndex + 5);
			if ((readingState & (1 << (int)directIndex)) == 0 && (readingState & (1 << (int)reverseIndex)) == 0)
			{
				pageCount++;
			}
		}
		return pageCount;
	}

	public static ushort GenerateReadingStateFromSkillBook(byte pageTypes)
	{
		ushort readingState = 0;
		byte pageIndex = GetOutlinePageInternalIndex(SkillBookStateHelper.GetOutlinePageType(pageTypes));
		readingState = SetPageRead(readingState, pageIndex);
		for (byte pageId = 1; pageId < 6; pageId++)
		{
			pageIndex = GetNormalPageInternalIndex(SkillBookStateHelper.GetNormalPageType(pageTypes, pageId), pageId);
			readingState = SetPageRead(readingState, pageIndex);
		}
		return readingState;
	}

	public static byte GeneratePageTypesFromReadingState(IRandomSource random, ushort readingState)
	{
		byte pageTypes = 0;
		SpanList<byte> validPages = stackalloc byte[5];
		for (byte pageInternalIndex = 0; pageInternalIndex < 5; pageInternalIndex++)
		{
			if (IsPageRead(readingState, pageInternalIndex))
			{
				validPages.Add(pageInternalIndex);
			}
		}
		int outlinePage = ((validPages.Count > 0) ? validPages.GetRandom(random) : random.Next(5));
		pageTypes = SkillBookStateHelper.SetOutlinePageType(pageTypes, (sbyte)outlinePage);
		validPages.Clear();
		for (byte pageId = 1; pageId < 6; pageId++)
		{
			byte directPage = GetNormalPageInternalIndex(0, pageId);
			bool directRead = IsPageRead(readingState, directPage);
			byte reversePage = GetNormalPageInternalIndex(1, pageId);
			bool reverseRead = IsPageRead(readingState, reversePage);
			sbyte direction = ((directRead == reverseRead) ? CombatSkillDirection.GetRandomDirection(random) : ((!directRead) ? ((sbyte)1) : ((sbyte)0)));
			pageTypes = SkillBookStateHelper.SetNormalPageType(pageTypes, pageId, direction);
		}
		return pageTypes;
	}

	public static bool IsPageActive(ushort activationState, byte pageInternalIndex)
	{
		return (activationState & (1 << (int)pageInternalIndex)) != 0;
	}

	public static sbyte GetPageActiveDirection(ushort activationState, byte pageId)
	{
		int directIndex = 5 + pageId - 1;
		if ((activationState & (1 << directIndex)) != 0)
		{
			return 0;
		}
		int reverseIndex = directIndex + 5;
		if ((activationState & (1 << reverseIndex)) != 0)
		{
			return 1;
		}
		return -1;
	}

	public static ushort SetPageActive(ushort activationState, byte pageInternalIndex)
	{
		return (ushort)(activationState | (1 << (int)pageInternalIndex));
	}

	public static ushort SetPageInactive(ushort activationState, byte pageInternalIndex)
	{
		return (ushort)(activationState & ~(1 << (int)pageInternalIndex));
	}

	public static bool IsBrokenOut(ushort activationState)
	{
		return GetActiveOutlinePageType(activationState) >= 0;
	}

	public static bool CanGenerateBookFromActivationState(ushort activationState)
	{
		if (GetActiveOutlinePageType(activationState) >= 0)
		{
			return GetNormalPagesActivationCount(activationState) >= 5;
		}
		return false;
	}

	public static sbyte GetActiveOutlinePageType(ushort activationState)
	{
		uint state = activationState;
		for (int i = 0; i < 5; i++)
		{
			if ((state & 1) != 0)
			{
				return (sbyte)i;
			}
			state >>= 1;
		}
		return -1;
	}

	public static bool IsAllPagesActive(ushort activationState, sbyte direction)
	{
		return ((activationState >>> 5 + direction * 5) & 0x1F) == 31;
	}

	public static sbyte GetCombatSkillDirection(ushort activationState)
	{
		if (!IsBrokenOut(activationState))
		{
			return -1;
		}
		int directCount = GetNormalPagesActivationCount(activationState, 0);
		int reverseCount = GetNormalPagesActivationCount(activationState, 1);
		if (directCount > reverseCount)
		{
			return 0;
		}
		if (directCount < reverseCount)
		{
			return 1;
		}
		return -1;
	}

	public static int GetNormalPagesActivationCount(ushort activationState, sbyte direction)
	{
		uint state = (uint)((activationState >>> 5 + direction * 5) & 0x1F);
		int count = 0;
		while (state != 0)
		{
			state &= state - 1;
			count++;
		}
		return count;
	}

	public static int GetNormalPagesActivationCount(ushort activationState)
	{
		return GetNormalPagesActivationCount(activationState, 0) + GetNormalPagesActivationCount(activationState, 1);
	}

	public static ushort SwitchNormalPageDirect(ushort activationState, int pageId)
	{
		byte directIndex = (byte)(5 + pageId);
		byte reverseIndex = (byte)(directIndex + 5);
		if ((activationState & (1 << (int)directIndex)) != 0)
		{
			activationState = SetPageInactive(activationState, directIndex);
			activationState = SetPageActive(activationState, reverseIndex);
		}
		else if ((activationState & (1 << (int)reverseIndex)) != 0)
		{
			activationState = SetPageInactive(activationState, reverseIndex);
			activationState = SetPageActive(activationState, directIndex);
		}
		return activationState;
	}

	public unsafe static ushort GenerateRandomActivatedOutlinePage(IRandomSource random, ushort readingState, ushort activationState, sbyte behaviorType = -1)
	{
		if (behaviorType >= 0 && HasReadOutlinePage(readingState, behaviorType))
		{
			return (ushort)(activationState | (1 << (int)behaviorType));
		}
		uint state = (uint)(readingState & 0x1F);
		byte* pReadPageIndexes = stackalloc byte[5];
		int readPagesCount = 0;
		for (int i = 0; i < 5; i++)
		{
			if ((state & 1) != 0)
			{
				pReadPageIndexes[readPagesCount++] = (byte)i;
			}
			state >>= 1;
		}
		byte activateIndex = pReadPageIndexes[(readPagesCount != 1) ? random.Next(readPagesCount) : 0];
		return (ushort)(activationState | (1 << (int)activateIndex));
	}

	public static ushort GenerateRandomActivatedNormalPages(IRandomSource random, ushort readingState, ushort activationState)
	{
		for (int i = 0; i < 5; i++)
		{
			byte directIndex = (byte)(5 + i);
			bool directRead = (readingState & (1 << (int)directIndex)) != 0;
			byte reverseIndex = (byte)(directIndex + 5);
			bool reverseRead = (readingState & (1 << (int)reverseIndex)) != 0;
			if ((directRead || reverseRead) && !IsPageActive(activationState, directIndex) && !IsPageActive(activationState, reverseIndex))
			{
				byte activateIndex = ((!(directRead && reverseRead)) ? (directRead ? directIndex : reverseIndex) : ((random.Next(2) == 0) ? directIndex : reverseIndex));
				activationState |= (ushort)(1 << (int)activateIndex);
			}
		}
		return activationState;
	}
}
