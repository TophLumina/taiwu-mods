using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 研读进度数据结构体
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public struct ReadProgressData : ISerializableGameData
{
	/// <summary>
	/// 技能模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 每页研读进度（100表示完成）
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] ReadingProgress;

	/// <summary>
	/// 每页正逆练类型（仅功法书有效）
	/// 正练: CombatSkillDirection.Direct, 逆练: CombatSkillDirection.Reverse
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] PageType;

	/// <summary>
	/// 是否已突破（仅功法书有效）
	/// </summary>
	[SerializableGameDataField]
	public bool IsBrokenOut;

	public ReadProgressData(short templateId, sbyte[] readingProgress, sbyte[] pageType, bool isBrokenOut)
	{
		TemplateId = -1;
		TemplateId = templateId;
		ReadingProgress = readingProgress;
		PageType = pageType;
		IsBrokenOut = isBrokenOut;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((ReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + ReadingProgress.Length)));
		totalSize = ((PageType == null) ? (totalSize + 2) : (totalSize + (2 + PageType.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		if (ReadingProgress != null)
		{
			int elementsCount = ReadingProgress.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)ReadingProgress[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PageType != null)
		{
			int elementsCount2 = PageType.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (byte)PageType[j];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsBrokenOut ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ReadingProgress == null || ReadingProgress.Length != elementsCount)
			{
				ReadingProgress = new sbyte[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ReadingProgress[i] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			ReadingProgress = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (PageType == null || PageType.Length != elementsCount2)
			{
				PageType = new sbyte[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				PageType[j] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			PageType = null;
		}
		IsBrokenOut = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
