using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 豪客志向技能数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class WineTasterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort VillagersLastLearnSkillDate = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "VillagersLastLearnSkillDate" };
	}

	/// <summary>
	/// 村民上次通过武院习得技艺的时间
	/// </summary>
	[SerializableGameDataField]
	public int VillagersLastLearnSkillDate;

	/// <inheritdoc />
	public void Initialize()
	{
		VillagersLastLearnSkillDate = 0;
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		Assign(sourceData as WineTasterSkillsData);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public WineTasterSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public WineTasterSkillsData(WineTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(WineTasterSkillsData other)
	{
		VillagersLastLearnSkillDate = other.VillagersLastLearnSkillDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
