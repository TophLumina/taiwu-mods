using GameData.Serializer;

namespace GameData.Domains.World;

/// <summary>
/// 动物
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class NotificationSortingGroup : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort Priority = 1;

		public const ushort IsHidden = 2;

		public const ushort IsOnTop = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "Id", "Priority", "IsHidden", "IsOnTop" };
	}

	/// <summary>
	/// Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 优先度
	/// </summary>
	[SerializableGameDataField]
	public int Priority;

	/// <summary>
	/// 是否隐藏
	/// </summary>
	[SerializableGameDataField]
	public bool IsHidden;

	/// <summary>
	/// 是否置顶
	/// </summary>
	[SerializableGameDataField]
	public bool IsOnTop;

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="priority"></param>
	/// <param name="isHidden"></param>
	/// <param name="isOnTop"></param>
	public NotificationSortingGroup(int id, int priority, bool isHidden, bool isOnTop)
	{
		Id = id;
		Priority = priority;
		IsHidden = isHidden;
		IsOnTop = isOnTop;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public NotificationSortingGroup()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public NotificationSortingGroup(NotificationSortingGroup other)
	{
		Id = other.Id;
		Priority = other.Priority;
		IsHidden = other.IsHidden;
		IsOnTop = other.IsOnTop;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(NotificationSortingGroup other)
	{
		Id = other.Id;
		Priority = other.Priority;
		IsHidden = other.IsHidden;
		IsOnTop = other.IsOnTop;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = Id;
		byte* num2 = num + 4;
		*(int*)num2 = Priority;
		byte* num3 = num2 + 4;
		*num3 = (IsHidden ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (IsOnTop ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num4 + 1 - pData);
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
			Priority = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			IsHidden = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			IsOnTop = *pCurrData != 0;
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
