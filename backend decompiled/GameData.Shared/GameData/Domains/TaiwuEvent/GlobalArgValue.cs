using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.TaiwuEvent;

/// <summary>
/// 自 SerializeDefault 迁移而来的匿名结构
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct GlobalArgValue : ISerializableGameData
{
	public bool Val1;

	public int Val2;

	public static implicit operator GlobalArgValue((bool, int) tuple)
	{
		GlobalArgValue result = default(GlobalArgValue);
		(result.Val1, result.Val2) = tuple;
		return result;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
