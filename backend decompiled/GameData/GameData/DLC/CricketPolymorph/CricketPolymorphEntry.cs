using GameData.Common;
using GameData.Domains;
using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class CricketPolymorphEntry : IDlcEntry, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Count = 0;
	}

	public void OnLoadedArchiveData(bool firstEnable)
	{
	}

	public void OnEnterNewWorld()
	{
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
		DomainManager.Taiwu.InvokePolymorphMonthlyEvent(context);
		DomainManager.Taiwu.InvokeWaitForReturnPolymorphMonthlyEvent();
	}

	public void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive)
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 0;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
