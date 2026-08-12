using GameData.Serializer;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 交易辩论时的观众评价
/// </summary>
public class DebateComment : ISerializableGameData
{
	/// <summary>
	/// 观众Id
	/// </summary>
	[SerializableGameDataField]
	public int SpectatorId;

	/// <summary>
	/// 较艺者Id
	/// </summary>
	[SerializableGameDataField]
	public int PlayerId;

	/// <summary>
	/// 模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	///
	/// </summary>
	/// <param name="spectatorId"></param>
	/// <param name="playerId"></param>
	/// <param name="templateId"></param>
	public DebateComment(int spectatorId, int playerId, short templateId)
	{
		SpectatorId = spectatorId;
		PlayerId = playerId;
		TemplateId = templateId;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DebateComment()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DebateComment(DebateComment other)
	{
		SpectatorId = other.SpectatorId;
		PlayerId = other.PlayerId;
		TemplateId = other.TemplateId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DebateComment other)
	{
		SpectatorId = other.SpectatorId;
		PlayerId = other.PlayerId;
		TemplateId = other.TemplateId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SpectatorId;
		byte* num = pData + 4;
		*(int*)num = PlayerId;
		byte* num2 = num + 4;
		*(short*)num2 = TemplateId;
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
		SpectatorId = *(int*)pCurrData;
		pCurrData += 4;
		PlayerId = *(int*)pCurrData;
		pCurrData += 4;
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
