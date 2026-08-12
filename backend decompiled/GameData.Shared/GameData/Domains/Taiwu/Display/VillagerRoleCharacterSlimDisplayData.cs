using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 一个有身份的村民的显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleCharacterSlimDisplayData : ISerializableGameData
{
	/// <summary>
	/// 角色id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 什么身份
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 在做哪个工作
	/// </summary>
	[SerializableGameDataField]
	public short ArrangementTemplateId;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Id;
		byte* num = pData + 4;
		*(short*)num = RoleTemplateId;
		byte* num2 = num + 2;
		*(short*)num2 = ArrangementTemplateId;
		int totalSize = (int)(num2 + 2 - pData);
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ArrangementTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
