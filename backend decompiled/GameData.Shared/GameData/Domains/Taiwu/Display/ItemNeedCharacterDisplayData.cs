using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 村民需要的物品 的人物显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class ItemNeedCharacterDisplayData : ISerializableGameData, ISelectCharacterData, IVillagerSelectCharacterData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public int CharacterTemplateId;

	/// <summary>
	/// 姓名数据
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	/// <summary>
	/// 角色创建类型
	/// </summary>
	[SerializableGameDataField]
	public byte CreatingType;

	/// <summary>
	/// 拿取时间
	/// </summary>
	[SerializableGameDataField]
	public int TakeTime;

	/// <summary>
	/// 拿取数量
	/// </summary>
	[SerializableGameDataField]
	public int TakeAmount;

	/// <summary>
	/// 对太吾的好感度
	/// </summary>
	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	/// <summary>
	/// 见过太吾
	/// </summary>
	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	/// <summary>
	/// 与太吾的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	/// <summary>
	/// 太吾与之的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	/// <summary>
	/// 身份
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 势力值
	/// </summary>
	[SerializableGameDataField]
	public int PowerLevel;

	/// <summary>
	/// 是否为同道
	/// </summary>
	[SerializableGameDataField]
	public bool IsCompanion;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList GeneralScrollListData;

	int ISelectCharacterData.CharacterId => CharacterId;

	sbyte IVillagerSelectCharacterData.WorkType => -1;

	byte IVillagerSelectCharacterData.WorkStatus => 0;

	int IVillagerSelectCharacterData.ArrangementTemplateId => -1;

	int IVillagerSelectCharacterData.BuildingBlockTemplateId => -1;

	bool IVillagerSelectCharacterData.IsBuyOperation => false;

	int IVillagerSelectCharacterData.GraveId => -1;

	int IVillagerSelectCharacterData.SwordTombId => -1;

	int IVillagerSelectCharacterData.RoleTemplateId => RoleTemplateId;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ItemNeedCharacterDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ItemNeedCharacterDisplayData(ItemNeedCharacterDisplayData other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		FullName = other.FullName;
		NameData = other.NameData;
		Health = other.Health;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		CreatingType = other.CreatingType;
		TakeTime = other.TakeTime;
		TakeAmount = other.TakeAmount;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		PowerLevel = other.PowerLevel;
		IsCompanion = other.IsCompanion;
		GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList(other.GeneralScrollListData);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ItemNeedCharacterDisplayData other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		FullName = other.FullName;
		NameData = other.NameData;
		Health = other.Health;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		CreatingType = other.CreatingType;
		TakeTime = other.TakeTime;
		TakeAmount = other.TakeAmount;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		PowerLevel = other.PowerLevel;
		IsCompanion = other.IsCompanion;
		GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList(other.GeneralScrollListData);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 75;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((GeneralScrollListData == null) ? (totalSize + 2) : (totalSize + (2 + GeneralScrollListData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(int*)pCurrData = CharacterTemplateId;
		pCurrData += 4;
		pCurrData += FullName.Serialize(pCurrData);
		pCurrData += NameData.Serialize(pCurrData);
		*(short*)pCurrData = Health;
		pCurrData += 2;
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = CreatingType;
		pCurrData++;
		*(int*)pCurrData = TakeTime;
		pCurrData += 4;
		*(int*)pCurrData = TakeAmount;
		pCurrData += 4;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = PowerLevel;
		pCurrData += 4;
		*pCurrData = (IsCompanion ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (GeneralScrollListData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GeneralScrollListData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		CharacterTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += FullName.Deserialize(pCurrData);
		pCurrData += NameData.Deserialize(pCurrData);
		Health = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		CreatingType = *pCurrData;
		pCurrData++;
		TakeTime = *(int*)pCurrData;
		pCurrData += 4;
		TakeAmount = *(int*)pCurrData;
		pCurrData += 4;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		PowerLevel = *(int*)pCurrData;
		pCurrData += 4;
		IsCompanion = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (GeneralScrollListData == null)
			{
				GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList();
			}
			pCurrData += GeneralScrollListData.Deserialize(pCurrData);
		}
		else
		{
			GeneralScrollListData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return GeneralScrollListData;
	}
}
