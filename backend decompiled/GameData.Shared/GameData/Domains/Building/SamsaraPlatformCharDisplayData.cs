using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

/// <summary>
/// 轮回台人物显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class SamsaraPlatformCharDisplayData : ISerializableGameData, ISelectCharacterData
{
	/// <summary>
	/// 轮回进度
	/// </summary>
	[SerializableGameDataField]
	public int Progress = -1;

	/// <summary>
	/// 人物数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList Data;

	[SerializableGameDataField]
	public int DeadAt;

	/// <summary>
	/// ISelectCharacterData接口
	/// </summary>
	int ISelectCharacterData.CharacterId => Data?.CharacterId ?? (-1);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public int Id => Data?.CharacterId ?? (-1);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public short TemplateId => Data?.CharacterTemplateId ?? (-1);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public NameRelatedData NameRelatedData => Data?.NameData ?? default(NameRelatedData);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public AvatarRelatedData AvatarRelatedData => Data?.AvatarRelatedData ?? new AvatarRelatedData();

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public MainAttributes MainAttributes => Data?.MaxMainAttributes ?? default(MainAttributes);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public CombatSkillShorts CombatSkillQualifications => Data?.CombatSkillQualifications ?? default(CombatSkillShorts);

	/// <summary>
	/// 前端旧接口
	/// </summary>
	public LifeSkillShorts LifeSkillQualifications => Data?.LifeSkillQualifications ?? default(LifeSkillShorts);

	/// <summary>
	/// ISelectCharacterData接口
	/// </summary>
	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return Data;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SamsaraPlatformCharDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SamsaraPlatformCharDisplayData(SamsaraPlatformCharDisplayData other)
	{
		Progress = other.Progress;
		Data = new CharacterDisplayDataForGeneralScrollList(other.Data);
		DeadAt = other.DeadAt;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SamsaraPlatformCharDisplayData other)
	{
		Progress = other.Progress;
		Data = new CharacterDisplayDataForGeneralScrollList(other.Data);
		DeadAt = other.DeadAt;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((Data == null) ? (totalSize + 2) : (totalSize + (2 + Data.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Progress;
		pCurrData += 4;
		if (Data != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Data.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = DeadAt;
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
		Progress = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Data = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += Data.Deserialize(pCurrData);
		}
		else
		{
			Data = null;
		}
		DeadAt = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
