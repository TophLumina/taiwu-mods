using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 产物信息
/// </summary>
[AutoGenerateSerializableGameData]
public struct Production : ISerializableGameData
{
	/// <summary>
	/// 类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType;

	/// <summary>
	/// 模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	///
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="templateId"></param>
	public Production(sbyte itemType, short templateId)
	{
		ItemType = itemType;
		TemplateId = templateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ItemType;
		byte* num = pData + 1;
		*(short*)num = TemplateId;
		int totalSize = (int)(num + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
