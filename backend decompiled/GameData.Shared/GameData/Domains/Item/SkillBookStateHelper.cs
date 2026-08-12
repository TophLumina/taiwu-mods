namespace GameData.Domains.Item;

/// <summary>
/// 技能书残缺程度以及书页类型相关辅助方法
/// </summary>
public static class SkillBookStateHelper
{
	/// <summary>
	/// 设置功法书的总纲页的类型
	/// </summary>
	/// <param name="pageTypes">前 3bits 为总纲类型, 后 5 bits 为一般书页类型</param>
	/// <param name="behaviorType"><see cref="T:GameData.Domains.Character.BehaviorType" /></param>
	/// <returns></returns>
	public static byte SetOutlinePageType(byte pageTypes, sbyte behaviorType)
	{
		return (byte)((pageTypes & 0xF8) | (byte)behaviorType);
	}

	/// <summary>
	/// 获取功法书的总纲页的类型
	/// </summary>
	/// <param name="pageTypes">前 3bits 为总纲类型, 后 5 bits 为一般书页类型</param>
	/// <returns></returns>
	public static sbyte GetOutlinePageType(byte pageTypes)
	{
		return (sbyte)(pageTypes & 7);
	}

	/// <summary>
	/// 设置功法书的一般页的类型
	/// </summary>
	/// <param name="pageTypes">前 3bits 为总纲类型, 后 5 bits 为一般书页类型</param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]. 此处不能为 0.</param>
	/// <param name="direction">不能设为无效. <see cref="T:GameData.Domains.CombatSkill.CombatSkillDirection" /></param>
	/// <returns></returns>
	public static byte SetNormalPageType(byte pageTypes, byte pageId, sbyte direction)
	{
		int index = 3 + pageId - 1;
		return (byte)((direction == 0) ? (pageTypes & ~(1 << index)) : (pageTypes | (1 << index)));
	}

	/// <summary>
	/// 获取功法书的一般页的类型
	/// </summary>
	/// <param name="pageTypes">前 3bits 为总纲类型, 后 5 bits 为一般书页类型</param>
	/// <param name="pageId">总纲为 0, 一般书页为 [1, 5]. 此处不能为 0.</param>
	/// <returns></returns>
	public static sbyte GetNormalPageType(byte pageTypes, byte pageId)
	{
		int index = 3 + pageId - 1;
		return ((pageTypes & (1 << index)) != 0) ? ((sbyte)1) : ((sbyte)0);
	}

	/// <summary>
	/// 设置指定书页的残缺程度
	/// </summary>
	/// <param name="pageIncompleteState">每两个 bit 代表一页书的残缺程度. <see cref="T:GameData.Domains.Item.SkillBookPageIncompleteState" /></param>
	/// <param name="pageId">功法书为 [0, 5], 技艺书为 [0, 4]</param>
	/// <param name="state">单个书页的残缺程度. <see cref="T:GameData.Domains.Item.SkillBookPageIncompleteState" /></param>
	/// <returns></returns>
	public static ushort SetPageIncompleteState(ushort pageIncompleteState, byte pageId, sbyte state)
	{
		int index = pageId * 2;
		return (ushort)((pageIncompleteState & ~(3 << index)) | (state << index));
	}

	/// <summary>
	/// 获取指定书页的残缺程度
	/// </summary>
	/// <param name="pageIncompleteState">每两个 bit 代表一页书的残缺程度. <see cref="T:GameData.Domains.Item.SkillBookPageIncompleteState" /></param>
	/// <param name="pageId">功法书为 [0, 5], 技艺书为 [0, 4]</param>
	/// <returns>单个书页的残缺程度. <see cref="T:GameData.Domains.Item.SkillBookPageIncompleteState" /></returns>
	public static sbyte GetPageIncompleteState(ushort pageIncompleteState, byte pageId)
	{
		int index = pageId * 2;
		return (sbyte)((pageIncompleteState >> index) & 3);
	}

	/// <summary>
	/// 获得根据书页残缺程度对应的研读成功率计算出的书籍状态总值，书籍越完整，该值越高
	/// </summary>
	/// <param name="pageIncompleteState"></param>
	/// <param name="pageCount"></param>
	/// <returns></returns>
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
