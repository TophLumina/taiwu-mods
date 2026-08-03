using System;
using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 包含一个秘闻 Id 和秘闻模板 Id 的索引
/// <para>通常用于见闻数据</para>
/// </summary>
public struct SecretInformationKey : ISerializableGameData, IEquatable<SecretInformationKey>
{
	/// <summary>
	/// 秘闻模板 Id
	/// </summary>
	public short TemplateId;

	/// <summary>
	/// 秘闻实例 Id
	/// </summary>
	public int Id;

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		return 6;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		*(int*)(pData + 2) = Id;
		return 6;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		TemplateId = *(short*)pData;
		Id = *(int*)(pData + 2);
		return 6;
	}

	/// <inheritdoc />
	public bool Equals(SecretInformationKey other)
	{
		if (TemplateId == other.TemplateId)
		{
			return Id == other.Id;
		}
		return false;
	}
}
