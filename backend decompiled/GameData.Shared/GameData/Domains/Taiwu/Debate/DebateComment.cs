using GameData.Serializer;

namespace GameData.Domains.Taiwu.Debate;

public class DebateComment : ISerializableGameData
{
	[SerializableGameDataField]
	public int SpectatorId;

	[SerializableGameDataField]
	public int PlayerId;

	[SerializableGameDataField]
	public short TemplateId;

	public DebateComment(int spectatorId, int playerId, short templateId)
	{
		SpectatorId = spectatorId;
		PlayerId = playerId;
		TemplateId = templateId;
	}

	public DebateComment()
	{
	}

	public DebateComment(DebateComment other)
	{
		SpectatorId = other.SpectatorId;
		PlayerId = other.PlayerId;
		TemplateId = other.TemplateId;
	}

	public void Assign(DebateComment other)
	{
		SpectatorId = other.SpectatorId;
		PlayerId = other.PlayerId;
		TemplateId = other.TemplateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
