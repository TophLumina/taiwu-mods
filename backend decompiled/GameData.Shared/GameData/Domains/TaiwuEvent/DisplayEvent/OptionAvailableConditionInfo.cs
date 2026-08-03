using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 选项可用条件数据 - 指令系统
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class OptionAvailableConditionInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public int EventFunctionId;

	[SerializableGameDataField]
	public string[] Args;

	[SerializableGameDataField]
	public bool Pass;

	public OptionAvailableConditionInfo()
	{
	}

	public OptionAvailableConditionInfo(int funcId, bool pass, params string[] args)
	{
		EventFunctionId = funcId;
		Args = args;
		Pass = pass;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (Args != null)
		{
			totalSize += 2;
			int elementsCount = Args.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = Args[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = EventFunctionId;
		pCurrData += 4;
		if (Args != null)
		{
			int elementsCount = Args.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = Args[i];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar = element)
					{
						for (int j = 0; j < subElementsCount; j++)
						{
							((short*)pCurrData)[j] = (short)pChar[j];
						}
					}
					pCurrData += 2 * subElementsCount;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (Pass ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		EventFunctionId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Args == null || Args.Length != elementsCount)
			{
				Args = new string[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					Args[i] = Encoding.Unicode.GetString(pCurrData, subDataSize);
					pCurrData += subDataSize;
				}
				else
				{
					Args[i] = null;
				}
			}
		}
		else
		{
			Args = null;
		}
		Pass = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
