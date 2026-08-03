using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 王蛊驱动显示数据。用于向前端返回王蛊驱动状态的显示数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true, NotForArchive = true)]
public class WugKingDriveDisplayData : ISerializableGameData
{
	/// <summary>
	/// 角色 ID
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// 王蛊类型 (WugType)
	/// </summary>
	[SerializableGameDataField]
	public sbyte WugType;

	/// <summary>
	/// 驱动类型 (WugKingDriveType: None/Positive/Negative)
	/// </summary>
	[SerializableGameDataField]
	public sbyte DriveType;

	/// <summary>
	/// 驱动开始日期
	/// </summary>
	[SerializableGameDataField]
	public int StartDate;

	/// <summary>
	/// 是否可以驱动（冷却检查）
	/// </summary>
	[SerializableGameDataField]
	public bool CanDrive;

	/// <summary>
	/// 王蛊是否在服食栏中
	/// </summary>
	[SerializableGameDataField]
	public bool IsInEatingSlot;

	/// <summary>
	/// 关联的王蛊物品显示数据
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
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
		*pCurrData = (byte)WugType;
		pCurrData++;
		*pCurrData = (byte)DriveType;
		pCurrData++;
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		*pCurrData = (CanDrive ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInEatingSlot ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		WugType = (sbyte)(*pCurrData);
		pCurrData++;
		DriveType = (sbyte)(*pCurrData);
		pCurrData++;
		StartDate = *(int*)pCurrData;
		pCurrData += 4;
		CanDrive = *pCurrData != 0;
		pCurrData++;
		IsInEatingSlot = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ItemDisplayData == null)
			{
				ItemDisplayData = new ItemDisplayData();
			}
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
