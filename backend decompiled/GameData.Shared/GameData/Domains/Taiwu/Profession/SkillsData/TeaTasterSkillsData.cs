using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 贵客志向技能数据
/// </summary>
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

	/// <summary>
	/// 村民上次通过书院习得技艺的时间
	/// </summary>
	[SerializableGameDataField]
	public int VillagersLastLearnSkillDate;

	/// <summary>
	/// 当月通过饮茶获取的额外行动力
	/// </summary>
	[SerializableGameDataField]
	public int ActionPointGained;

	/// <inheritdoc />
	public void Initialize()
	{
		VillagersLastLearnSkillDate = 0;
		ActionPointGained = 0;
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		Assign(sourceData as TeaTasterSkillsData);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TeaTasterSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TeaTasterSkillsData(TeaTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
		ActionPointGained = other.ActionPointGained;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TeaTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
		ActionPointGained = other.ActionPointGained;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
