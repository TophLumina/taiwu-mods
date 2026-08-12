using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 轻量级人头数据，仅用于显示人头+姓名
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct NameAndAvatar : ISerializableGameData
{
	/// <summary>
	/// 肖像数据，可能为空
	/// 为空时应显示死人
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData Avatar;

	/// <summary>
	/// 姓名数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData Name;

	/// <summary>
	/// 用于传递IsTaiwu变量
	/// </summary>
	[SerializableGameDataField]
	public bool IsTaiwu;

	/// <summary>
	/// 人物Id
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 人物模板获取语法糖（前端显示用，防止义父人头显示异常）
	/// </summary>
	public short CharTemplateId => Name.CharTemplateId;

	/// <summary>
	/// 此处约定avatar为null时数据无效
	/// </summary>
	public bool IsValid => Avatar != null;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		totalSize += Name.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
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
		pCurrData += Name.Serialize(pCurrData);
		*pCurrData = (IsTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
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
			Avatar = new AvatarRelatedData();
			pCurrData += Avatar.Deserialize(pCurrData);
		}
		else
		{
			Avatar = null;
		}
		pCurrData += Name.Deserialize(pCurrData);
		IsTaiwu = *pCurrData != 0;
		pCurrData++;
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
