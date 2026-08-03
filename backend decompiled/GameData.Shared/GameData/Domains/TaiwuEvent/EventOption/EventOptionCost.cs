using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.EventOption;

/// <summary>
/// 选项消耗
/// </summary>
[Serializable]
[SerializableGameData(NotForDisplayModule = true, NotForArchive = true)]
public class EventOptionCost : ISerializableGameData
{
	/// <summary>
	/// 消耗类型 <see cref="T:Config.EventOptionConsumeType.DefKey" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ConsumeType;

	/// <summary>
	/// 消耗数量
	/// </summary>
	[SerializableGameDataField]
	public int CostAmount;

	/// <summary>
	/// 是否自动扣除
	/// </summary>
	[SerializableGameDataField]
	public bool AutoConsume;

	/// <summary>
	/// 公式
	/// </summary>
	[SerializableGameDataField]
	public string Expression;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public EventOptionCost()
	{
		ConsumeType = -1;
		CostAmount = 0;
		AutoConsume = false;
		Expression = null;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public EventOptionCost(EventOptionCost other)
	{
		ConsumeType = other.ConsumeType;
		CostAmount = other.CostAmount;
		AutoConsume = other.AutoConsume;
		Expression = other.Expression;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(EventOptionCost other)
	{
		ConsumeType = other.ConsumeType;
		CostAmount = other.CostAmount;
		AutoConsume = other.AutoConsume;
		Expression = other.Expression;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Expression == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Expression.Length)));
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
		*pCurrData = (byte)ConsumeType;
		pCurrData++;
		*(int*)pCurrData = CostAmount;
		pCurrData += 4;
		*pCurrData = (AutoConsume ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Expression != null)
		{
			int elementsCount = Expression.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Expression)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
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
		ConsumeType = (sbyte)(*pCurrData);
		pCurrData++;
		CostAmount = *(int*)pCurrData;
		pCurrData += 4;
		AutoConsume = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			Expression = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Expression = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
