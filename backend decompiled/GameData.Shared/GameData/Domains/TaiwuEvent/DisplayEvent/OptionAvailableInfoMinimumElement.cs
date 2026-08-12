using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public struct OptionAvailableInfoMinimumElement : ISerializableGameData
{
	/// <summary>
	/// 对应的条件Id
	/// </summary>
	[SerializableGameDataField]
	public short ConditionId;

	/// <summary>
	/// 格式化条件文本时要使用的参数数组
	/// </summary>
	[SerializableGameDataField]
	public string[] FormatArgs;

	/// <summary>
	/// 元素是否满足条件
	/// </summary>
	[SerializableGameDataField]
	public bool Pass;

	/// <summary>
	/// 元素是否隐藏
	/// 某些选项元素可能需要根据条件的结果来显示或隐藏
	/// </summary>
	[SerializableGameDataField]
	public bool Hide;

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public OptionAvailableInfoMinimumElement(OptionAvailableInfoMinimumElement other)
	{
		ConditionId = other.ConditionId;
		string[] item = other.FormatArgs;
		int elementsCount = item.Length;
		FormatArgs = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			FormatArgs[i] = item[i];
		}
		Pass = other.Pass;
		Hide = other.Hide;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(OptionAvailableInfoMinimumElement other)
	{
		ConditionId = other.ConditionId;
		string[] item = other.FormatArgs;
		int elementsCount = item.Length;
		FormatArgs = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			FormatArgs[i] = item[i];
		}
		Pass = other.Pass;
		Hide = other.Hide;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (FormatArgs != null)
		{
			totalSize += 2;
			int elementsCount = FormatArgs.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = FormatArgs[i];
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
		*(short*)pCurrData = ConditionId;
		pCurrData += 2;
		if (FormatArgs != null)
		{
			int elementsCount = FormatArgs.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = FormatArgs[i];
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
		*pCurrData = (Hide ? ((byte)1) : ((byte)0));
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
		ConditionId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FormatArgs == null || FormatArgs.Length != elementsCount)
			{
				FormatArgs = new string[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					FormatArgs[i] = Encoding.Unicode.GetString(pCurrData, subDataSize);
					pCurrData += subDataSize;
				}
				else
				{
					FormatArgs[i] = null;
				}
			}
		}
		else
		{
			FormatArgs = null;
		}
		Pass = *pCurrData != 0;
		pCurrData++;
		Hide = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
