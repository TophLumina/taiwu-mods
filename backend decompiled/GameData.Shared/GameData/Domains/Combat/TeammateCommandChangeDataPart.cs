using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 同道指令变化数据部分（单方阵营）
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class TeammateCommandChangeDataPart : ISerializableGameData
{
	/// <summary>
	/// 同道角色 ID 列表
	/// </summary>
	[SerializableGameDataField]
	public List<int> TeammateCharIds = new List<int>();

	/// <summary>
	/// 各同道原始指令
	/// </summary>
	[SerializableGameDataField]
	public List<SByteList> OriginTeammateCommands = new List<SByteList>();

	/// <summary>
	/// 各同道被替换后的指令
	/// </summary>
	[SerializableGameDataField]
	public List<SByteList> ReplaceTeammateCommands = new List<SByteList>();

	/// <summary>
	/// 被三魔/才替换的同道角色 ID
	/// 同道索引【0~2】-&gt; 同道角色 ID
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> BetrayedCharIds = new Dictionary<int, int>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TeammateCommandChangeDataPart()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TeammateCommandChangeDataPart(TeammateCommandChangeDataPart other)
	{
		TeammateCharIds = ((other.TeammateCharIds == null) ? null : new List<int>(other.TeammateCharIds));
		if (other.OriginTeammateCommands != null)
		{
			List<SByteList> item = other.OriginTeammateCommands;
			int elementsCount = item.Count;
			OriginTeammateCommands = new List<SByteList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				OriginTeammateCommands.Add(new SByteList(item[i]));
			}
		}
		else
		{
			OriginTeammateCommands = null;
		}
		if (other.ReplaceTeammateCommands != null)
		{
			List<SByteList> item2 = other.ReplaceTeammateCommands;
			int elementsCount2 = item2.Count;
			ReplaceTeammateCommands = new List<SByteList>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				ReplaceTeammateCommands.Add(new SByteList(item2[j]));
			}
		}
		else
		{
			ReplaceTeammateCommands = null;
		}
		BetrayedCharIds = ((other.BetrayedCharIds == null) ? null : new Dictionary<int, int>(other.BetrayedCharIds));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TeammateCommandChangeDataPart other)
	{
		TeammateCharIds = ((other.TeammateCharIds == null) ? null : new List<int>(other.TeammateCharIds));
		if (other.OriginTeammateCommands != null)
		{
			List<SByteList> item = other.OriginTeammateCommands;
			int elementsCount = item.Count;
			OriginTeammateCommands = new List<SByteList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				OriginTeammateCommands.Add(new SByteList(item[i]));
			}
		}
		else
		{
			OriginTeammateCommands = null;
		}
		if (other.ReplaceTeammateCommands != null)
		{
			List<SByteList> item2 = other.ReplaceTeammateCommands;
			int elementsCount2 = item2.Count;
			ReplaceTeammateCommands = new List<SByteList>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				ReplaceTeammateCommands.Add(new SByteList(item2[j]));
			}
		}
		else
		{
			ReplaceTeammateCommands = null;
		}
		BetrayedCharIds = ((other.BetrayedCharIds == null) ? null : new Dictionary<int, int>(other.BetrayedCharIds));
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
		totalSize = ((TeammateCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * TeammateCharIds.Count)));
		if (OriginTeammateCommands != null)
		{
			totalSize += 2;
			int elementsCount = OriginTeammateCommands.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += OriginTeammateCommands[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ReplaceTeammateCommands != null)
		{
			totalSize += 2;
			int elementsCount2 = ReplaceTeammateCommands.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				totalSize += ReplaceTeammateCommands[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(BetrayedCharIds);
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
		if (TeammateCharIds != null)
		{
			int elementsCount = TeammateCharIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = TeammateCharIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OriginTeammateCommands != null)
		{
			int elementsCount2 = OriginTeammateCommands.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int subDataSize = OriginTeammateCommands[j].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReplaceTeammateCommands != null)
		{
			int elementsCount3 = ReplaceTeammateCommands.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				int subDataSize2 = ReplaceTeammateCommands[k].Serialize(pCurrData);
				pCurrData += subDataSize2;
				Tester.Assert(subDataSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref BetrayedCharIds);
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
			if (TeammateCharIds == null)
			{
				TeammateCharIds = new List<int>(elementsCount);
			}
			else
			{
				TeammateCharIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TeammateCharIds.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			TeammateCharIds?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (OriginTeammateCommands == null)
			{
				OriginTeammateCommands = new List<SByteList>(elementsCount2);
			}
			else
			{
				OriginTeammateCommands.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				SByteList element = default(SByteList);
				pCurrData += element.Deserialize(pCurrData);
				OriginTeammateCommands.Add(element);
			}
		}
		else
		{
			OriginTeammateCommands?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ReplaceTeammateCommands == null)
			{
				ReplaceTeammateCommands = new List<SByteList>(elementsCount3);
			}
			else
			{
				ReplaceTeammateCommands.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				SByteList element2 = default(SByteList);
				pCurrData += element2.Deserialize(pCurrData);
				ReplaceTeammateCommands.Add(element2);
			}
		}
		else
		{
			ReplaceTeammateCommands?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref BetrayedCharIds);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
