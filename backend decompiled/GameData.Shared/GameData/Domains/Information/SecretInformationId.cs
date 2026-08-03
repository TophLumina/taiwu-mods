using System;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Information;

/// <summary>
/// 秘闻 Id
/// </summary>
[AutoGenerateSerializableGameData]
public struct SecretInformationId : IEquatable<SecretInformationId>, ISerializableGameData
{
	/// <summary>
	/// Id
	/// </summary>
	[SerializableGameDataField]
	private int _id = -1;

	/// <summary>
	/// 默认非法 Id
	/// </summary>
	private const int InvalidId = -1;

	/// <summary>
	/// 非法值
	/// </summary>
	public static SecretInformationId Invalid
	{
		get
		{
			SecretInformationId result = new SecretInformationId();
			result._id = -1;
			return result;
		}
	}

	/// <summary>
	/// 有效性
	/// </summary>
	public bool Valid => _id >= 0;

	public SecretInformationId()
	{
	}

	/// <summary>
	/// 转为 <see cref="T:System.Int32" />
	/// </summary>
	public static explicit operator int(SecretInformationId occurenceId)
	{
		return occurenceId._id;
	}

	/// <summary>
	/// 转为 <see cref="T:GameData.Domains.Information.SecretInformationId" />
	/// </summary>
	public static explicit operator SecretInformationId(int value)
	{
		SecretInformationId result = new SecretInformationId();
		result._id = value;
		return result;
	}

	public static bool operator ==(SecretInformationId self, SecretInformationId other)
	{
		return self._id == other._id;
	}

	public static bool operator !=(SecretInformationId self, SecretInformationId other)
	{
		return !(self == other);
	}

	/// <inheritdoc cref="M:System.Object.ToString" />
	public override string ToString()
	{
		return string.Format("{0}: {1}", "SecretInformationId", _id);
	}

	public bool Equals(SecretInformationId other)
	{
		return _id == other._id;
	}

	public override bool Equals(object obj)
	{
		if (obj is SecretInformationId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _id;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = _id;
		int totalSize = (int)(pData + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_id = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
