using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 角色持有秘闻数据
/// </summary>
public class SecretInformationCharacterData : ISerializableGameData
{
	/// <summary>
	/// 秘闻元数据 Id
	/// </summary>
	[SerializableGameDataField]
	public int SecretInformationMetaDataId;

	/// <summary>
	/// 秘闻的传播分支, 即"初始来源", -1 表示无
	/// <para>秘闻在初始生成的时候, 可能没有传播者存在, 在这种情况下，当第一次传播发生时, 传播者会作为秘闻的"初始来源"和"来源"传递给被传播者</para>
	/// <para>"初始来源"会添加到 <see cref="!:SecretInformationDisseminationData" /> 中记录总传播次数。一旦有了"初始来源", 它在传播过程中就不会再发生改变, 永远保持原样传递给下一个被传播者</para>
	/// <para>而"来源"则会根据每次传播而变更</para>
	/// </summary>
	[SerializableGameDataField]
	public int SecretInformationDisseminationBranch;

	/// <summary>
	/// 已废弃……
	/// <para>秘闻的"来源"人物 Id, -1 表示无</para>
	/// <para>解释详见 <see cref="F:GameData.Domains.Information.SecretInformationCharacterData.SecretInformationDisseminationBranch" /></para>
	/// </summary>
	[SerializableGameDataField]
	public int SourceCharacterId;

	/// <summary>
	/// 新建角色秘闻数据
	/// </summary>
	/// <param name="secretInformationMetaDataId">秘闻元数据 Id</param>
	/// <param name="sourceCharacterId">秘闻来源人物 Id</param>
	/// <param name="secretInformationDisseminationBranch">秘闻传播分支 Id (初始来源人物 Id)</param>
	public SecretInformationCharacterData(int secretInformationMetaDataId, int secretInformationDisseminationBranch = -1)
	{
		SecretInformationMetaDataId = secretInformationMetaDataId;
		SecretInformationDisseminationBranch = secretInformationDisseminationBranch;
		SourceCharacterId = 0;
	}

	/// <summary>
	/// 空构造方法用于反序列化
	/// </summary>
	public SecretInformationCharacterData()
		: this(-1)
	{
	}

	public SecretInformationCharacterData(SecretInformationCharacterData other)
	{
		SecretInformationMetaDataId = other.SecretInformationMetaDataId;
		SecretInformationDisseminationBranch = other.SecretInformationDisseminationBranch;
		SourceCharacterId = other.SourceCharacterId;
	}

	public void Assign(SecretInformationCharacterData other)
	{
		SecretInformationMetaDataId = other.SecretInformationMetaDataId;
		SecretInformationDisseminationBranch = other.SecretInformationDisseminationBranch;
		SourceCharacterId = other.SourceCharacterId;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SecretInformationMetaDataId;
		byte* num = pData + 4;
		*(int*)num = SecretInformationDisseminationBranch;
		byte* num2 = num + 4;
		*(int*)num2 = SourceCharacterId;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SecretInformationMetaDataId = *(int*)pCurrData;
		pCurrData += 4;
		SecretInformationDisseminationBranch = *(int*)pCurrData;
		pCurrData += 4;
		SourceCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
