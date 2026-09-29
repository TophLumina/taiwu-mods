using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class TeaTasterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort VillagersLastLearnSkillDate = 0;

		public const ushort ActionPointGained = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "VillagersLastLearnSkillDate", "ActionPointGained" };
	}

	[SerializableGameDataField]
	public int VillagersLastLearnSkillDate;

	[SerializableGameDataField]
	public int ActionPointGained;

	public void Initialize()
	{
		VillagersLastLearnSkillDate = 0;
		ActionPointGained = 0;
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		Assign(sourceData as TeaTasterSkillsData);
	}

	public TeaTasterSkillsData()
	{
	}

	public TeaTasterSkillsData(TeaTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
		ActionPointGained = other.ActionPointGained;
	}

	public void Assign(TeaTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
		ActionPointGained = other.ActionPointGained;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
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
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(int*)num = VillagersLastLearnSkillDate;
		byte* num2 = num + 4;
		*(int*)num2 = ActionPointGained;
		int totalSize = (int)(num2 + 4 - pData);
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
		if (num > 1)
		{
			ActionPointGained = *(int*)pCurrData;
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
