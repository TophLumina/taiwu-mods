using System;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

[Serializable]
public struct LifeSkillItem : ISerializableGameData
{
	public const int PagesCount = 5;

	public const byte CompleteReadingState = 31;

	public short SkillTemplateId;

	public byte ReadingState;

	public LifeSkillItem(short skillTemplateId)
	{
		SkillTemplateId = skillTemplateId;
		ReadingState = 0;
	}

	public LifeSkillItem(short skillTemplateId, sbyte pagesReadCount)
	{
		SkillTemplateId = skillTemplateId;
		ReadingState = 0;
		if (pagesReadCount > 0)
		{
			SetRandomPagesRead(ExternalDataBridge.Context.Random, pagesReadCount);
		}
	}

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

	public bool IsPageRead(byte pageId)
	{
		return (ReadingState & (1 << (int)pageId)) != 0;
	}

	public bool IsAllPagesRead()
	{
		return (ReadingState & 0x1F) == 31;
	}

	public bool IsAnyPagesRead()
	{
		return ReadingState != 0;
	}

	public void SetPageRead(byte pageId)
	{
		ReadingState = (byte)(ReadingState | (1 << (int)pageId));
	}

	public void SetPageUnread(byte pageId)
	{
		ReadingState = (byte)(ReadingState & ~(1 << (int)pageId));
	}

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
