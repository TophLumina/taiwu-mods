using Config;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Information;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Information;

/// <summary>
/// 秘闻显示数据
/// <para>因秘闻结构复杂不便表现模块交互获取, 特此设置秘闻专用显示数据类</para>
/// </summary>
[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true)]
public class SecretInformationDisplayData : ISerializableGameData
{
	/// <summary>
	/// 秘闻 Id
	/// </summary>
	[SerializableGameDataField]
	public SecretInformationId SecretInformationId;

	/// <summary>
	/// 秘闻模板 Id
	/// <see cref="T:Config.SecretInformation" />
	/// </summary>
	[SerializableGameDataField]
	public short SecretInformationTemplateId;

	/// <summary>
	/// 持有此秘闻的人数
	/// </summary>
	[SerializableGameDataField]
	public int HolderCount;

	/// <summary>
	/// 来源
	/// </summary>
	[SerializableGameDataField]
	public int SourceCharacterId;

	/// <summary>
	/// 是否公开
	/// </summary>
	[SerializableGameDataField]
	public bool IsInBroadcast;

	/// <summary>
	/// 威望消耗
	/// </summary>
	[SerializableGameDataField]
	public int AuthorityCostWhenDisseminating;

	/// <summary>
	/// 威望消耗(公开)
	/// 限定志向技能专用字段
	/// </summary>
	[SerializableGameDataField]
	public int AuthorityCostWhenDisseminatingForBroadcast;

	/// <summary>
	/// 使用次数
	/// </summary>
	[SerializableGameDataField]
	public int UsedCount;

	/// <summary>
	/// 发生地点
	/// </summary>
	[SerializableGameDataField]
	public FullBlockName Location;

	/// <summary>
	/// 发生日期
	/// </summary>
	[SerializableGameDataField]
	public int OccurenceDate;

	/// <summary>
	/// 秘闻事号
	/// </summary>
	[SerializableGameDataField]
	public SecretOccurenceId OccurenceId;

	/// <summary>
	/// 传播概率
	/// </summary>
	[SerializableGameDataField]
	public int DisseminationRate;

	/// <summary>
	/// 交易时的价格
	/// </summary>
	[SerializableGameDataField]
	public int ShopValue;

	/// <summary>
	/// 参数包
	/// </summary>
	[SerializableGameDataField]
	public byte[] ParametersPack;

	/// <summary>
	/// 获取actorId/reactorId与secActorId
	/// </summary>
	/// <param name="actorId">主要人物，为-1时无效</param>
	/// <param name="reactorId">次要人物，为-1时无效</param>
	/// <param name="secActorId">次要人物2，为-1时无效</param>
	public void GetCharacterRelatedParameter(out int actorId, out int reactorId, out int secActorId)
	{
		SecretInformationItem infoConfig = SecretInformation.Instance.GetItem(SecretInformationTemplateId);
		SecretInformationEffectItem effectConfig = SecretInformationEffect.Instance.GetItem(infoConfig.DefaultEffectId);
		int actor = -1;
		int reactor = -1;
		int secActor = -1;
		ParametersPack.ExtractSecretParameters(infoConfig, delegate(int idx, int charId)
		{
			if (idx == effectConfig.ActorIndex)
			{
				actor = charId;
			}
			else if (idx == effectConfig.ReactorIndex)
			{
				reactor = charId;
			}
			else if (idx == effectConfig.SecactorIndex)
			{
				secActor = charId;
			}
		});
		actorId = actor;
		reactorId = reactor;
		secActorId = secActor;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SecretInformationDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SecretInformationDisplayData(SecretInformationDisplayData other)
	{
		SecretInformationId = other.SecretInformationId;
		SecretInformationTemplateId = other.SecretInformationTemplateId;
		HolderCount = other.HolderCount;
		SourceCharacterId = other.SourceCharacterId;
		IsInBroadcast = other.IsInBroadcast;
		AuthorityCostWhenDisseminating = other.AuthorityCostWhenDisseminating;
		AuthorityCostWhenDisseminatingForBroadcast = other.AuthorityCostWhenDisseminatingForBroadcast;
		UsedCount = other.UsedCount;
		Location = other.Location;
		OccurenceDate = other.OccurenceDate;
		OccurenceId = other.OccurenceId;
		DisseminationRate = other.DisseminationRate;
		ShopValue = other.ShopValue;
		byte[] item = other.ParametersPack;
		int elementsCount = item.Length;
		ParametersPack = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			ParametersPack[i] = item[i];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SecretInformationDisplayData other)
	{
		SecretInformationId = other.SecretInformationId;
		SecretInformationTemplateId = other.SecretInformationTemplateId;
		HolderCount = other.HolderCount;
		SourceCharacterId = other.SourceCharacterId;
		IsInBroadcast = other.IsInBroadcast;
		AuthorityCostWhenDisseminating = other.AuthorityCostWhenDisseminating;
		AuthorityCostWhenDisseminatingForBroadcast = other.AuthorityCostWhenDisseminatingForBroadcast;
		UsedCount = other.UsedCount;
		Location = other.Location;
		OccurenceDate = other.OccurenceDate;
		OccurenceId = other.OccurenceId;
		DisseminationRate = other.DisseminationRate;
		ShopValue = other.ShopValue;
		byte[] item = other.ParametersPack;
		int elementsCount = item.Length;
		ParametersPack = new byte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			ParametersPack[i] = item[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 43;
		totalSize += Location.GetSerializedSize();
		totalSize = ((ParametersPack == null) ? (totalSize + 2) : (totalSize + (2 + ParametersPack.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SecretInformationId.Serialize(pCurrData);
		*(short*)pCurrData = SecretInformationTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = HolderCount;
		pCurrData += 4;
		*(int*)pCurrData = SourceCharacterId;
		pCurrData += 4;
		*pCurrData = (IsInBroadcast ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = AuthorityCostWhenDisseminating;
		pCurrData += 4;
		*(int*)pCurrData = AuthorityCostWhenDisseminatingForBroadcast;
		pCurrData += 4;
		*(int*)pCurrData = UsedCount;
		pCurrData += 4;
		int fieldSize = Location.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = OccurenceDate;
		pCurrData += 4;
		pCurrData += OccurenceId.Serialize(pCurrData);
		*(int*)pCurrData = DisseminationRate;
		pCurrData += 4;
		*(int*)pCurrData = ShopValue;
		pCurrData += 4;
		if (ParametersPack != null)
		{
			int elementsCount = ParametersPack.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = ParametersPack[i];
				pCurrData++;
			}
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SecretInformationId.Deserialize(pCurrData);
		SecretInformationTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		HolderCount = *(int*)pCurrData;
		pCurrData += 4;
		SourceCharacterId = *(int*)pCurrData;
		pCurrData += 4;
		IsInBroadcast = *pCurrData != 0;
		pCurrData++;
		AuthorityCostWhenDisseminating = *(int*)pCurrData;
		pCurrData += 4;
		AuthorityCostWhenDisseminatingForBroadcast = *(int*)pCurrData;
		pCurrData += 4;
		UsedCount = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		OccurenceDate = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += OccurenceId.Deserialize(pCurrData);
		DisseminationRate = *(int*)pCurrData;
		pCurrData += 4;
		ShopValue = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ParametersPack == null || ParametersPack.Length != elementsCount)
			{
				ParametersPack = new byte[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ParametersPack[i] = *pCurrData;
				pCurrData++;
			}
		}
		else
		{
			ParametersPack = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
