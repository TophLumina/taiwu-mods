using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 精简版角色数据
/// </summary>
[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class AbridgedCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort CharTemplateId = 1;

		public const ushort Gender = 2;

		public const ushort MonkType = 3;

		public const ushort Avatar = 4;

		public const ushort ClothingDisplayId = 5;

		public const ushort FullName = 6;

		public const ushort OrganizationInfo = 7;

		public const ushort MonasticTitle = 8;

		public const ushort CustomDisplayNameId = 9;

		public const ushort SelfRelationToTaiwu = 10;

		public const ushort TaiwuRelationToSelf = 11;

		public const ushort AliveState = 12;

		public const ushort CurrAge = 13;

		public const ushort ActualAge = 14;

		public const ushort Location = 15;

		public const ushort BirthDate = 16;

		public const ushort Count = 17;

		public static readonly string[] FieldId2FieldName = new string[17]
		{
			"Id", "CharTemplateId", "Gender", "MonkType", "Avatar", "ClothingDisplayId", "FullName", "OrganizationInfo", "MonasticTitle", "CustomDisplayNameId",
			"SelfRelationToTaiwu", "TaiwuRelationToSelf", "AliveState", "CurrAge", "ActualAge", "Location", "BirthDate"
		};
	}

	/// <summary>
	/// 角色实例 ID.
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 角色模板 ID.
	/// </summary>
	[SerializableGameDataField]
	public short CharTemplateId;

	/// <summary>
	/// 性别
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 当前年龄
	/// </summary>
	[SerializableGameDataField]
	public short CurrAge;

	/// <summary>
	/// 真实年龄
	/// </summary>
	[SerializableGameDataField]
	public short ActualAge;

	/// <summary>
	/// 出家类型
	/// </summary>
	[SerializableGameDataField]
	public byte MonkType;

	/// <summary>
	/// 基本信息 - 外貌
	/// </summary>
	[SerializableGameDataField]
	public AvatarData Avatar;

	/// <summary>
	/// 基本信息 - 衣装的显示 ID
	/// </summary>
	[SerializableGameDataField]
	public short ClothingDisplayId;

	/// <summary>
	/// 随机姓名
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	/// <summary>
	/// 从属信息
	/// </summary>
	[SerializableGameDataField]
	public OrganizationInfo OrganizationInfo;

	/// <summary>
	/// 法号
	/// </summary>
	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	/// <summary>
	/// 自定义显示名 ID
	/// </summary>
	[SerializableGameDataField]
	public int CustomDisplayNameId;

	/// <summary>
	/// 对太吾的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort SelfRelationToTaiwu;

	/// <summary>
	/// 太吾对自身的关系
	/// </summary>
	[SerializableGameDataField]
	public ushort TaiwuRelationToSelf;

	/// <summary>
	/// 存活状态 (精简前)
	/// <see cref="T:GameData.Domains.Character.AliveState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte AliveState;

	/// <summary>
	/// 位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 出身日期
	/// </summary>
	[SerializableGameDataField]
	public int BirthDate;

	/// <summary>
	/// 生成能够用于显示的形象数据
	/// </summary>
	public AvatarRelatedData GenerateAvatarRelatedData()
	{
		return new AvatarRelatedData
		{
			AvatarData = new AvatarData(Avatar),
			DisplayAge = CurrAge,
			ClothingDisplayId = ClothingDisplayId
		};
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AbridgedCharacter()
	{
		Id = -1;
		Avatar = new AvatarData();
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AbridgedCharacter(AbridgedCharacter other)
	{
		Id = other.Id;
		CharTemplateId = other.CharTemplateId;
		Gender = other.Gender;
		MonkType = other.MonkType;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		FullName = other.FullName;
		OrganizationInfo = other.OrganizationInfo;
		MonasticTitle = other.MonasticTitle;
		CustomDisplayNameId = other.CustomDisplayNameId;
		SelfRelationToTaiwu = other.SelfRelationToTaiwu;
		TaiwuRelationToSelf = other.TaiwuRelationToSelf;
		AliveState = other.AliveState;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		Location = other.Location;
		BirthDate = other.BirthDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AbridgedCharacter other)
	{
		Id = other.Id;
		CharTemplateId = other.CharTemplateId;
		Gender = other.Gender;
		MonkType = other.MonkType;
		Avatar = new AvatarData(other.Avatar);
		ClothingDisplayId = other.ClothingDisplayId;
		FullName = other.FullName;
		OrganizationInfo = other.OrganizationInfo;
		MonasticTitle = other.MonasticTitle;
		CustomDisplayNameId = other.CustomDisplayNameId;
		SelfRelationToTaiwu = other.SelfRelationToTaiwu;
		TaiwuRelationToSelf = other.TaiwuRelationToSelf;
		AliveState = other.AliveState;
		CurrAge = other.CurrAge;
		ActualAge = other.ActualAge;
		Location = other.Location;
		BirthDate = other.BirthDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 55;
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
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
		*(short*)pCurrData = 17;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = CharTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = MonkType;
		pCurrData++;
		if (Avatar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = ClothingDisplayId;
		pCurrData += 2;
		pCurrData += FullName.Serialize(pCurrData);
		pCurrData += OrganizationInfo.Serialize(pCurrData);
		pCurrData += MonasticTitle.Serialize(pCurrData);
		*(int*)pCurrData = CustomDisplayNameId;
		pCurrData += 4;
		*(ushort*)pCurrData = SelfRelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = TaiwuRelationToSelf;
		pCurrData += 2;
		*pCurrData = (byte)AliveState;
		pCurrData++;
		*(short*)pCurrData = CurrAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			CharTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			Gender = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			MonkType = *pCurrData;
			pCurrData++;
		}
		if (num > 4)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (Avatar == null)
				{
					Avatar = new AvatarData();
				}
				pCurrData += Avatar.Deserialize(pCurrData);
			}
			else
			{
				Avatar = null;
			}
		}
		if (num > 5)
		{
			ClothingDisplayId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 6)
		{
			pCurrData += FullName.Deserialize(pCurrData);
		}
		if (num > 7)
		{
			pCurrData += OrganizationInfo.Deserialize(pCurrData);
		}
		if (num > 8)
		{
			pCurrData += MonasticTitle.Deserialize(pCurrData);
		}
		if (num > 9)
		{
			CustomDisplayNameId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 10)
		{
			SelfRelationToTaiwu = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 11)
		{
			TaiwuRelationToSelf = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 12)
		{
			AliveState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 13)
		{
			CurrAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 14)
		{
			ActualAge = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 15)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 16)
		{
			BirthDate = *(int*)pCurrData;
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
