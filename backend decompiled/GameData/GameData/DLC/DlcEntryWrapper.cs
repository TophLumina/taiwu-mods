using GameData.Serializer;

namespace GameData.DLC;

[SerializableGameData(NotForDisplayModule = true)]
public class DlcEntryWrapper : ISerializableGameData
{
	[SerializableGameDataField]
	private DlcId _dlcId;

	[SerializableGameDataField]
	private IDlcEntry _dlcEntry;

	public DlcEntryWrapper()
	{
	}

	public DlcEntryWrapper(DlcId dlcId, IDlcEntry dlcEntry)
	{
		_dlcId = dlcId;
		_dlcEntry = dlcEntry;
	}

	public IDlcEntry GetDlcEntry()
	{
		return _dlcEntry;
	}

	public void Update(ulong version, IDlcEntry entry)
	{
		_dlcId.Version = version;
		_dlcEntry = entry;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return _dlcId.GetSerializedSize() + 4 + (_dlcEntry?.GetSerializedSize() ?? 0);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _dlcId.Serialize(pCurrData);
		if (_dlcEntry != null)
		{
			byte* pFieldSize = pCurrData;
			pCurrData += 4;
			int fieldSize = _dlcEntry.Serialize(pCurrData);
			pCurrData += fieldSize;
			*(int*)pFieldSize = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _dlcId.Deserialize(pCurrData);
		uint fieldSize = *(uint*)pCurrData;
		pCurrData += 4;
		_dlcEntry = DlcManager.CreateDlcEntry(_dlcId);
		if (fieldSize != 0)
		{
			pCurrData += _dlcEntry.Deserialize(pCurrData);
		}
		return (int)(pCurrData - pData);
	}
}
