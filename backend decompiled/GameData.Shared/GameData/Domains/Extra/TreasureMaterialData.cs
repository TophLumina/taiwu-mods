using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 一个 Area 中的宝藏数据
/// </summary>
public class TreasureMaterialData : ISerializableGameData
{
	/// <summary>
	/// 地格上的心材模板 ID
	/// K：地格 ID
	/// V：心材的 Misc 模板 ID
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, List<short>> BlockMaterialTemplateIds = new Dictionary<short, List<short>>();

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int offset = 4;
		if (BlockMaterialTemplateIds != null)
		{
			foreach (List<short> list in BlockMaterialTemplateIds.Values)
			{
				offset += 6;
				offset += 2 * (list?.Count ?? 0);
			}
		}
		int totalSize = offset;
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
		if (BlockMaterialTemplateIds != null)
		{
			int elementsCount = BlockMaterialTemplateIds.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<short, List<short>> pair in BlockMaterialTemplateIds)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				List<short> list = pair.Value;
				if (list != null)
				{
					*(int*)pCurrData = list.Count;
					pCurrData += 4;
					foreach (short templateId in list)
					{
						*(short*)pCurrData = templateId;
						pCurrData += 2;
					}
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (BlockMaterialTemplateIds == null)
			{
				BlockMaterialTemplateIds = new Dictionary<short, List<short>>();
			}
			else
			{
				BlockMaterialTemplateIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short blockId = *(short*)pCurrData;
				pCurrData += 2;
				int count = *(int*)pCurrData;
				pCurrData += 4;
				if (count != 0)
				{
					List<short> list = new List<short>();
					for (int j = 0; j < count; j++)
					{
						short templateId = *(short*)pCurrData;
						pCurrData += 2;
						list.Add(templateId);
					}
					BlockMaterialTemplateIds.Add(blockId, list);
				}
			}
		}
		else
		{
			BlockMaterialTemplateIds?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
