using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 同道指令生效时显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct TeammateCommandDisplayData : ISerializableGameData
{
	/// <summary>
	/// 是否己方触发的效果
	/// </summary>
	[SerializableGameDataField]
	public bool IsAlly;

	/// <summary>
	/// 角色在同道队伍中的索引 0~3
	/// </summary>
	[SerializableGameDataField]
	public sbyte IndexCharacter;

	/// <summary>
	/// 角色在同道队伍中的有效索引 0~3
	/// </summary>
	[SerializableGameDataField]
	public sbyte ValidIndexCharacter;

	/// <summary>
	/// 指令在所有指令中的索引 0~2
	/// </summary>
	[SerializableGameDataField]
	public sbyte IndexCommand;

	/// <summary>
	/// 指令类型 <see cref="T:Config.TeammateCommand" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte CmdType;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (IsAlly ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (byte)IndexCharacter;
		byte* num2 = num + 1;
		*num2 = (byte)ValidIndexCharacter;
		byte* num3 = num2 + 1;
		*num3 = (byte)IndexCommand;
		byte* num4 = num3 + 1;
		*num4 = (byte)CmdType;
		int totalSize = (int)(num4 + 1 - pData);
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
		IsAlly = *pCurrData != 0;
		pCurrData++;
		IndexCharacter = (sbyte)(*pCurrData);
		pCurrData++;
		ValidIndexCharacter = (sbyte)(*pCurrData);
		pCurrData++;
		IndexCommand = (sbyte)(*pCurrData);
		pCurrData++;
		CmdType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
