using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 选项可用条件数据
/// </summary>
public struct OptionAvailableInfo : ISerializableGameData
{
	/// <summary>
	/// 选项可用条件的信息数据
	/// 每条数据长度为
	/// 各条数据是或的关系
	/// </summary>
	[SerializableGameDataField]
	public OptionAvailableInfoMinimumElement[] Data;

	/// <summary>
	/// 由选项可用条件判定的结果
	/// </summary>
	[SerializableGameDataField]
	public bool PassState;

	/// <summary>
	/// 元素是否隐藏
	/// </summary>
	[SerializableGameDataField]
	public bool Hide;

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public OptionAvailableInfo(OptionAvailableInfo other)
	{
		OptionAvailableInfoMinimumElement[] item = other.Data;
		int elementsCount = item.Length;
		Data = new OptionAvailableInfoMinimumElement[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Data[i] = new OptionAvailableInfoMinimumElement(item[i]);
		}
		PassState = other.PassState;
		Hide = other.Hide;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(OptionAvailableInfo other)
	{
		OptionAvailableInfoMinimumElement[] item = other.Data;
		int elementsCount = item.Length;
		Data = new OptionAvailableInfoMinimumElement[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Data[i] = new OptionAvailableInfoMinimumElement(item[i]);
		}
		PassState = other.PassState;
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
		int totalSize = 2;
		if (Data != null)
		{
			totalSize += 2;
			int elementsCount = Data.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += Data[i].GetSerializedSize();
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
		if (Data != null)
		{
			int elementsCount = Data.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = Data[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (PassState ? ((byte)1) : ((byte)0));
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Data == null || Data.Length != elementsCount)
			{
				Data = new OptionAvailableInfoMinimumElement[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				OptionAvailableInfoMinimumElement element = default(OptionAvailableInfoMinimumElement);
				pCurrData += element.Deserialize(pCurrData);
				Data[i] = element;
			}
		}
		else
		{
			Data = null;
		}
		PassState = *pCurrData != 0;
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
