using GameData.Serializer;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 少林升级互动 - 无字角色的额外数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectStoryShaolinWordlessCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort Status = 1;

		public const ushort PreviousDate = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Id", "Status", "PreviousDate" };
	}

	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public int Id = -1;

	/// <summary>
	/// 状态
	/// </summary>
	[SerializableGameDataField]
	public sbyte Status;

	/// <summary>
	/// 上次切换时间
	/// </summary>
	[SerializableGameDataField]
	public int PreviousDate = -1;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryShaolinWordlessCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectStoryShaolinWordlessCharacter(SectStoryShaolinWordlessCharacter other)
	{
		Id = other.Id;
		Status = other.Status;
		PreviousDate = other.PreviousDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectStoryShaolinWordlessCharacter other)
	{
		Id = other.Id;
		Status = other.Status;
		PreviousDate = other.PreviousDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*(int*)num = Id;
		byte* num2 = num + 4;
		*num2 = (byte)Status;
		byte* num3 = num2 + 1;
		*(int*)num3 = PreviousDate;
		int totalSize = (int)(num3 + 4 - pData);
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
			Status = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			PreviousDate = *(int*)pCurrData;
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
