using GameData.Serializer;

namespace GameData.Domains.Taiwu.Debate;

[SerializableGameData(IsExtensible = true)]
public class DebateNodeEffectState : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort CasterId = 2;

		public const ushort Duration = 3;

		public const ushort IsHelpTaiwu = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "Id", "TemplateId", "CasterId", "Duration", "IsHelpTaiwu" };
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public int TemplateId;

	[SerializableGameDataField]
	public int CasterId;

	[SerializableGameDataField]
	public int Duration;

	[SerializableGameDataField]
	public bool IsHelpTaiwu;

	public static readonly DebateNodeEffectState Invalid = new DebateNodeEffectState(-1, -1, -1, -1, isHelpTaiwu: false);

	public DebateNodeEffectState(int id, int templateId, int casterId, int duration, bool isHelpTaiwu)
	{
		Id = id;
		TemplateId = templateId;
		CasterId = casterId;
		Duration = duration;
		IsHelpTaiwu = isHelpTaiwu;
	}

	public override string ToString()
	{
		return $"DebateNodeEffectState(id: {Id}, templateId: {TemplateId}, casterId: {CasterId}, duration: {Duration}, isHelpTaiwu: {IsHelpTaiwu})";
	}

	public DebateNodeEffectState()
	{
	}

	public DebateNodeEffectState(DebateNodeEffectState other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		CasterId = other.CasterId;
		Duration = other.Duration;
		IsHelpTaiwu = other.IsHelpTaiwu;
	}

	public void Assign(DebateNodeEffectState other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		CasterId = other.CasterId;
		Duration = other.Duration;
		IsHelpTaiwu = other.IsHelpTaiwu;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 5;
		byte* num = pData + 2;
		*(int*)num = Id;
		byte* num2 = num + 4;
		*(int*)num2 = TemplateId;
		byte* num3 = num2 + 4;
		*(int*)num3 = CasterId;
		byte* num4 = num3 + 4;
		*(int*)num4 = Duration;
		byte* num5 = num4 + 4;
		*num5 = (IsHelpTaiwu ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			TemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			CasterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			Duration = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 4)
		{
			IsHelpTaiwu = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
