using System;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法的阅读和激活状态相关辅助方法
/// </summary>
public static class CombatSkillStateHelper
{
	/// <summary>
	/// 功法包含的总纲书页数
	/// </summary>
	public const int OutlinePagesCount = 5;

	/// <summary>
	/// 功法包含的一般书页数
	/// </summary>
	private const int TotalNormalPagesCount = 10;

	/// <summary>
	/// 功法包含的总书页数
	/// </summary>
	public const int TotalPagesCount = 15;

	/// <summary>
	/// 读完所有书页的状态
	/// 逆练页-正练页-总纲页
	/// </summary>
	public const ushort CompleteReadingState = 32767;

	/// <summary>
	/// 突破需要的普通页数
	/// </summary>
	public const ushort BreakoutRequiredNormalPageCount = 5;

	/// <summary>
	/// 获取书页的内部索引
	/// </summary>
	/// <param name="behaviorType"></param>
	/// <param name="direction">不能设为无效. <see cref="T:GameData.Domains.CombatSkill.CombatSkillDirection" /></param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]</param>
	/// <returns></returns>
	public static byte GetPageInternalIndex(sbyte behaviorType, sbyte direction, byte pageId)
	{
		return (byte)((pageId == 0) ? behaviorType : (5 + direction * 5 + pageId - 1));
	}

	/// <summary>
	/// 获取书页的内部索引.
	/// </summary>
	/// <param name="pageTypes">功法书的书页类型</param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]</param>
	public static byte GetPageInternalIndex(byte pageTypes, byte pageId)
	{
		sbyte outlinePageType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
		sbyte direction = SkillBookStateHelper.GetNormalPageType(pageTypes, pageId);
		return GetPageInternalIndex(outlinePageType, direction, pageId);
	}

	/// <summary>
	/// 普通书页的InternalIndex转换为其正逆相反页的InternalIndex
	/// </summary>
	/// <exception cref="!:ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 获取总纲书页的内部索引
	/// </summary>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public static byte GetOutlinePageInternalIndex(sbyte behaviorType)
	{
		return (byte)behaviorType;
	}

	/// <summary>
	/// 获取一般书页的内部索引
	/// </summary>
	/// <param name="direction">不能设为无效. <see cref="T:GameData.Domains.CombatSkill.CombatSkillDirection" /></param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]. 此处只能为一般书页</param>
	/// <returns></returns>
	public static byte GetNormalPageInternalIndex(sbyte direction, byte pageId)
	{
		return (byte)(5 + direction * 5 + pageId - 1);
	}

	/// <summary>
	/// 获取功法书页Id
	/// </summary>
	/// <param name="pageInternalIndex">书页的内部索引</param>
	/// <returns></returns>
	public static byte GetPageId(byte pageInternalIndex)
	{
		if (pageInternalIndex >= 5)
		{
			return (byte)((pageInternalIndex - 5) % 5 + 1);
		}
		return 0;
	}

	/// <summary>
	/// 获取指定书页是否已读
	/// </summary>
	/// <param name="readingState"></param>
	/// <param name="pageInternalIndex"></param>
	/// <returns></returns>
	public static bool IsPageRead(ushort readingState, byte pageInternalIndex)
	{
		return (readingState & (1 << (int)pageInternalIndex)) != 0;
	}

	/// <summary>
	/// 设置指定书页为已读
	/// </summary>
	/// <param name="readingState"></param>
	/// <param name="pageInternalIndex"></param>
	public static ushort SetPageRead(ushort readingState, byte pageInternalIndex)
	{
		return (ushort)(readingState | (1 << (int)pageInternalIndex));
	}

	/// <summary>
	/// 设置指定书页为未读
	/// </summary>
	/// <param name="readingState"></param>
	/// <param name="pageInternalIndex"></param>
	public static ushort SetPageUnread(ushort readingState, byte pageInternalIndex)
	{
		return (ushort)(readingState & ~(1 << (int)pageInternalIndex));
	}

	/// <summary>
	/// 指定总纲页是否已读
	/// </summary>
	/// <param name="readingState"></param>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public static bool HasReadOutlinePage(ushort readingState, sbyte behaviorType)
	{
		byte internalIndex = GetOutlinePageInternalIndex(behaviorType);
		return IsPageRead(readingState, internalIndex);
	}

	/// <summary>
	/// 是否有已读的总纲页
	/// </summary>
	/// <returns></returns>
	public static bool HasReadOutlinePages(ushort readingState)
	{
		return (readingState & 0x1F) != 0;
	}

	/// <summary>
	/// 获取已读的所有书页数
	/// </summary>
	/// <param name="readingState"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取已读的一般书页数
	/// </summary>
	/// <param name="readingState"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 指定研读状态可激活的书页数量
	/// </summary>
	/// <param name="readingState"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 已读普通书页是否满足突破条件.
	/// 五页普通页, 每页都至少有一种正逆类型已读.
	/// </summary>
	/// <param name="readingState"></param>
	/// <returns></returns>
	public static bool IsReadNormalPagesMeetConditionOfBreakout(ushort readingState)
	{
		return GetCanActivateNormalPagesCount(readingState) >= 5;
	}

	/// <summary>
	/// 是否满足武学造诣盘装配条件
	/// TAIWU-62146 造诣界面功法装配的条件从【完成突破】改成：学会后，满足突破条件的，都能装备
	/// </summary>
	public static bool CanEquipOnAttainmentPanel(ushort readingState, bool revoked)
	{
		if (!revoked && HasReadOutlinePages(readingState))
		{
			return IsReadNormalPagesMeetConditionOfBreakout(readingState);
		}
		return false;
	}

	/// <summary>
	/// 获取下一个正逆页都未读的书页
	/// </summary>
	/// <param name="readingState"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算离全部激活还有几页书要读
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 通过功法书的书页类型生成对应功法的阅读状态 (使指定功法书的所有页变成已读)
	/// </summary>
	/// <param name="pageTypes">功法书的书页类型</param>
	/// <returns>功法的阅读状态</returns>
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

	/// <summary>
	/// 根据已读书页随机生成一本新书的书页类型
	/// </summary>
	/// <param name="random"></param>
	/// <param name="readingState"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定书页是否已激活
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="pageInternalIndex"></param>
	/// <returns></returns>
	public static bool IsPageActive(ushort activationState, byte pageInternalIndex)
	{
		return (activationState & (1 << (int)pageInternalIndex)) != 0;
	}

	/// <summary>
	/// 获取指定书页激活的正逆练类型
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]. 此处只能为一般书页</param>
	/// <returns><see cref="T:GameData.Domains.CombatSkill.CombatSkillDirection" /></returns>
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

	/// <summary>
	/// 设置指定书页为已激活
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="pageInternalIndex"></param>
	public static ushort SetPageActive(ushort activationState, byte pageInternalIndex)
	{
		return (ushort)(activationState | (1 << (int)pageInternalIndex));
	}

	/// <summary>
	/// 设置指定书页为未激活
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="pageInternalIndex"></param>
	public static ushort SetPageInactive(ushort activationState, byte pageInternalIndex)
	{
		return (ushort)(activationState & ~(1 << (int)pageInternalIndex));
	}

	/// <summary>
	/// 获取此功法是否已突破
	/// </summary>
	/// <param name="activationState"></param>
	/// <returns></returns>
	public static bool IsBrokenOut(ushort activationState)
	{
		return GetActiveOutlinePageType(activationState) >= 0;
	}

	/// <summary>
	/// 获取此功法已激活书页是否足以生成书籍
	/// </summary>
	/// <param name="activationState"></param>
	/// <returns></returns>
	public static bool CanGenerateBookFromActivationState(ushort activationState)
	{
		if (GetActiveOutlinePageType(activationState) >= 0)
		{
			return GetNormalPagesActivationCount(activationState) >= 5;
		}
		return false;
	}

	/// <summary>
	/// 获取已激活的总纲类型
	/// </summary>
	/// <param name="activationState"></param>
	/// <returns>小于 0 表示没有激活任何总纲</returns>
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

	/// <summary>
	/// 获取指定正逆练类型的所有书页是否全部已激活
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="direction"></param>
	/// <returns></returns>
	public static bool IsAllPagesActive(ushort activationState, sbyte direction)
	{
		return ((activationState >>> 5 + direction * 5) & 0x1F) == 31;
	}

	/// <summary>
	/// 获取激活书本的正逆练类型
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取单一正逆练类型的已激活一般书页数量
	/// </summary>
	/// <param name="activationState"></param>
	/// <param name="direction"><see cref="T:GameData.Domains.CombatSkill.CombatSkillDirection" /></param>
	/// <returns></returns>
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

	/// <summary>
	///             获取已激活一般书页数量
	/// </summary>
	/// <param name="activationState"></param>
	/// <returns></returns>
	public static int GetNormalPagesActivationCount(ushort activationState)
	{
		return GetNormalPagesActivationCount(activationState, 0) + GetNormalPagesActivationCount(activationState, 1);
	}

	/// <summary>
	/// 把一个普通书页的正逆页切换
	/// </summary>
	/// <param name="activationState">原始数据</param>
	/// <param name="pageId">第几页普通页，从0到4</param>
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

	/// <summary>
	/// 随机选择一页已读总纲, 返回书页激活状态.
	/// 传入的状态要求包含至少一页已读总纲.
	/// 优先选择匹配传入的立场的总纲页.
	/// </summary>
	/// <param name="random"></param>
	/// <param name="readingState"></param>
	/// <param name="activationState">传入的书页激活状态, 调用者需要保证所有总纲书页的激活状态为空</param>
	/// <param name="behaviorType">优先立场, -1 表示不指定</param>
	/// <returns>修改后的书页激活状态</returns>
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

	/// <summary>
	/// 随机选择突破需要的一般书页, 返回书页激活状态.
	/// </summary>
	/// <param name="random"></param>
	/// <param name="readingState"></param>
	/// <param name="activationState">传入的书页激活状态, 无需保证所有一般书页的激活状态为空, 只会修改未激活且已研读的书页.</param>
	/// <returns>修改后的书页激活状态</returns>
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
