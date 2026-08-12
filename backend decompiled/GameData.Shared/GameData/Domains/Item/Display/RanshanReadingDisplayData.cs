using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item.Display;

/// <summary>
/// 然山读书显示数据
/// </summary>
public class RanshanReadingDisplayData : ISerializableGameData
{
	/// <summary>
	/// 预测数据
	/// </summary>
	[SerializableGameDataField]
	public int[] PreviewProgress;

	/// <summary>
	/// 书页状态
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] State;

	/// <summary>
	/// 研读进度
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] ReadingProgress;

	/// <summary>
	/// 正逆，仅功法书有
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] Type;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public RanshanReadingDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public RanshanReadingDisplayData(RanshanReadingDisplayData other)
	{
		int[] item = other.PreviewProgress;
		int elementsCount = item.Length;
		PreviewProgress = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			PreviewProgress[i] = item[i];
		}
		sbyte[] item2 = other.State;
		int elementsCount2 = item2.Length;
		State = new sbyte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			State[j] = item2[j];
		}
		sbyte[] item3 = other.ReadingProgress;
		int elementsCount3 = item3.Length;
		ReadingProgress = new sbyte[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			ReadingProgress[k] = item3[k];
		}
		sbyte[] item4 = other.Type;
		int elementsCount4 = item4.Length;
		Type = new sbyte[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			Type[l] = item4[l];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(RanshanReadingDisplayData other)
	{
		int[] item = other.PreviewProgress;
		int elementsCount = item.Length;
		PreviewProgress = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			PreviewProgress[i] = item[i];
		}
		sbyte[] item2 = other.State;
		int elementsCount2 = item2.Length;
		State = new sbyte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			State[j] = item2[j];
		}
		sbyte[] item3 = other.ReadingProgress;
		int elementsCount3 = item3.Length;
		ReadingProgress = new sbyte[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			ReadingProgress[k] = item3[k];
		}
		sbyte[] item4 = other.Type;
		int elementsCount4 = item4.Length;
		Type = new sbyte[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			Type[l] = item4[l];
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((PreviewProgress == null) ? (totalSize + 2) : (totalSize + (2 + 4 * PreviewProgress.Length)));
		totalSize = ((State == null) ? (totalSize + 2) : (totalSize + (2 + State.Length)));
		totalSize = ((ReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + ReadingProgress.Length)));
		totalSize = ((Type == null) ? (totalSize + 2) : (totalSize + (2 + Type.Length)));
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
		if (PreviewProgress != null)
		{
			int elementsCount = PreviewProgress.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = PreviewProgress[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (State != null)
		{
			int elementsCount2 = State.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (byte)State[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadingProgress != null)
		{
			int elementsCount3 = ReadingProgress.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = (byte)ReadingProgress[k];
			}
			pCurrData += elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Type != null)
		{
			int elementsCount4 = Type.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)Type[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
			if (PreviewProgress == null || PreviewProgress.Length != elementsCount)
			{
				PreviewProgress = new int[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PreviewProgress[i] = ((int*)pCurrData)[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			PreviewProgress = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (State == null || State.Length != elementsCount2)
			{
				State = new sbyte[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				State[j] = (sbyte)pCurrData[j];
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			State = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ReadingProgress == null || ReadingProgress.Length != elementsCount3)
			{
				ReadingProgress = new sbyte[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ReadingProgress[k] = (sbyte)pCurrData[k];
			}
			pCurrData += (int)elementsCount3;
		}
		else
		{
			ReadingProgress = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (Type == null || Type.Length != elementsCount4)
			{
				Type = new sbyte[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				Type[l] = (sbyte)pCurrData[l];
			}
			pCurrData += (int)elementsCount4;
		}
		else
		{
			Type = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
