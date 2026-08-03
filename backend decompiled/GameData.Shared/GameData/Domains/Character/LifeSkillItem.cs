using System;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 角色的技艺对象.
///
/// 模板数据中单个技艺的配置格式有以下两种:
///     `技艺模板 ID, 已读页数`
///     `技艺模板 ID, {页1是否已读, 页2, ...}`
/// 技艺模板 ID 参考 LifeSkill 表.
/// 已读页数取值范围: [0, 5].
/// 页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
/// 示例:
///     `{5, 3}`: 技艺模板 ID 5, 随机三页已读.
///     `{8, {1,1,0,0,0}}`: 技艺模板 ID 8, 前两页已读.
/// </summary>
[Serializable]
public struct LifeSkillItem : ISerializableGameData
{
	/// <summary>
	/// 技艺书的书页数
	/// </summary>
	public const int PagesCount = 5;

	/// <summary>
	/// 读完所有书页的状态
	/// </summary>
	public const byte CompleteReadingState = 31;

	/// <summary>
	/// 技艺模板 ID
	/// </summary>
	public short SkillTemplateId;

	/// <summary>
	/// 各书页是否已读 (0 ~ 4bit)
	/// </summary>
	public byte ReadingState;

	public LifeSkillItem(short skillTemplateId)
	{
		SkillTemplateId = skillTemplateId;
		ReadingState = 0;
	}

	/// <summary>
	/// 从模板数据创建技艺对象
	/// </summary>
	/// <param name="skillTemplateId"></param>
	/// <param name="pagesReadCount"></param>
	public LifeSkillItem(short skillTemplateId, sbyte pagesReadCount)
	{
		SkillTemplateId = skillTemplateId;
		ReadingState = 0;
		if (pagesReadCount > 0)
		{
			SetRandomPagesRead(ExternalDataBridge.Context.Random, pagesReadCount);
		}
	}

	/// <summary>
	/// 从模板数据创建技艺对象
	/// </summary>
	/// <param name="skillTemplateId"></param>
	/// <param name="pagesReadStates"></param>
	public LifeSkillItem(short skillTemplateId, int[] pagesReadStates)
	{
		SkillTemplateId = skillTemplateId;
		ReadingState = 0;
		SetPagesRead(pagesReadStates);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = SkillTemplateId;
		pData[2] = ReadingState;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		SkillTemplateId = *(short*)pData;
		ReadingState = pData[2];
		return 4;
	}

	/// <summary>
	/// 获取指定书页是否已读
	/// </summary>
	/// <param name="pageId"></param>
	/// <returns></returns>
	public bool IsPageRead(byte pageId)
	{
		return (ReadingState & (1 << (int)pageId)) != 0;
	}

	/// <summary>
	/// 获取是否所有书页均已读
	/// </summary>
	/// <returns></returns>
	public bool IsAllPagesRead()
	{
		return (ReadingState & 0x1F) == 31;
	}

	/// <summary>
	/// 获取是否存在已读书页
	/// </summary>
	/// <returns></returns>
	public bool IsAnyPagesRead()
	{
		return ReadingState != 0;
	}

	/// <summary>
	/// 设置指定书页为已读
	/// </summary>
	/// <param name="pageId"></param>
	public void SetPageRead(byte pageId)
	{
		ReadingState = (byte)(ReadingState | (1 << (int)pageId));
	}

	/// <summary>
	/// 设置指定书页为未读
	/// </summary>
	/// <param name="pageId"></param>
	public void SetPageUnread(byte pageId)
	{
		ReadingState = (byte)(ReadingState & ~(1 << (int)pageId));
	}

	/// <summary>
	/// 获取书本的已读页数
	/// </summary>
	/// <returns></returns>
	public int GetReadPagesCount()
	{
		uint state = ReadingState;
		int count = 0;
		while (state != 0)
		{
			state &= state - 1;
			count++;
		}
		return count;
	}

	/// <summary>
	/// 随机设置指定页数已读
	/// </summary>
	/// <param name="random"></param>
	/// <param name="readPagesCount"></param>
	public unsafe void SetRandomPagesRead(IRandomSource random, sbyte readPagesCount)
	{
		byte* pPageIds = stackalloc byte[5];
		for (byte i = 0; i < 5; i++)
		{
			pPageIds[(int)i] = i;
		}
		byte* pShuffledPageIds = CollectionUtils.Shuffle(random, pPageIds, 5, readPagesCount);
		for (byte* pPageId = pShuffledPageIds; pPageId < pShuffledPageIds + readPagesCount; pPageId++)
		{
			SetPageRead(*pPageId);
		}
	}

	/// <summary>
	/// 设置指定的多个页已读
	/// </summary>
	/// <param name="pagesReadStates"></param>
	private void SetPagesRead(int[] pagesReadStates)
	{
		for (byte pageId = 0; pageId < 5; pageId++)
		{
			if (pagesReadStates[pageId] != 0)
			{
				SetPageRead(pageId);
			}
		}
	}
}
