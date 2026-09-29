using System;
using GameData.Serializer;

namespace GameData.Domains.Information;

public struct SecretInformationKey : ISerializableGameData, IEquatable<SecretInformationKey>
{
	public short TemplateId;

	public int Id;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 6;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		*(int*)(pData + 2) = Id;
		return 6;
	}

	public unsafe int Deserialize(byte* pData)
	{
		TemplateId = *(short*)pData;
		Id = *(int*)(pData + 2);
		return 6;
	}

	public bool Equals(SecretInformationKey other)
	{
		if (TemplateId == other.TemplateId)
		{
			return Id == other.Id;
		}
		return false;
	}
}
