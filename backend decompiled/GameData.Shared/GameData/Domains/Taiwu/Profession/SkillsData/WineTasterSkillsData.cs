using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class WineTasterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort VillagersLastLearnSkillDate = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "VillagersLastLearnSkillDate" };
	}

	[SerializableGameDataField]
	public int VillagersLastLearnSkillDate;

	public void Initialize()
	{
		VillagersLastLearnSkillDate = 0;
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		Assign(sourceData as WineTasterSkillsData);
	}

	public WineTasterSkillsData()
	{
	}

	public WineTasterSkillsData(WineTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
	}

	public void Assign(WineTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(int*)num = VillagersLastLearnSkillDate;
		int totalSize = (int)(num + 4 - pData);
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
			VillagersLastLearnSkillDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
