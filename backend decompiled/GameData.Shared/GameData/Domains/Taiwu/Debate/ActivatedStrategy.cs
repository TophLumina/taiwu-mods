using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 辩论中正在生效的策略
/// </summary>
public class ActivatedStrategy : ISerializableGameData
{
	/// <summary>
	/// Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 附着的论点Id
	/// </summary>
	[SerializableGameDataField]
	public int PawnId;

	/// <summary>
	/// 模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 是否是太吾释放
	/// </summary>
	[SerializableGameDataField]
	public bool IsCastedByTaiwu;

	/// <summary>
	/// 是否揭示
	/// </summary>
	[SerializableGameDataField]
	public bool IsRevealed;

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="pawnId"></param>
	/// <param name="templateId"></param>
	/// <param name="isCastedByTaiwu"></param>
	public ActivatedStrategy(int id, int pawnId, short templateId, bool isCastedByTaiwu)
	{
		Id = id;
		PawnId = pawnId;
		TemplateId = templateId;
		IsCastedByTaiwu = isCastedByTaiwu;
		IsRevealed = false;
	}

	/// <summary>
	/// 获取策略配置
	/// </summary>
	/// <returns></returns>
	public DebateStrategyItem GetConfig()
	{
		return DebateStrategy.Instance[TemplateId];
	}

	/// <summary>
	/// 获取策略触发类型
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public EDebateStrategyTriggerType GetTriggerType()
	{
		return GetConfig().TriggerType;
	}

	/// <summary>
	/// 是否惰性
	/// </summary>
	/// <returns></returns>
	public bool GetIsInertia()
	{
		DebateStrategyItem config = GetConfig();
		if (config.EffectList == null || config.EffectList.Count == 0)
		{
			return false;
		}
		foreach (IntPair effect in config.EffectList)
		{
			if (effect.First == 35)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ActivatedStrategy()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ActivatedStrategy(ActivatedStrategy other)
	{
		Id = other.Id;
		PawnId = other.PawnId;
		TemplateId = other.TemplateId;
		IsCastedByTaiwu = other.IsCastedByTaiwu;
		IsRevealed = other.IsRevealed;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ActivatedStrategy other)
	{
		Id = other.Id;
		PawnId = other.PawnId;
		TemplateId = other.TemplateId;
		IsCastedByTaiwu = other.IsCastedByTaiwu;
		IsRevealed = other.IsRevealed;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
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
		*(int*)pData = Id;
		byte* num = pData + 4;
		*(int*)num = PawnId;
		byte* num2 = num + 4;
		*(short*)num2 = TemplateId;
		byte* num3 = num2 + 2;
		*num3 = (IsCastedByTaiwu ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (IsRevealed ? ((byte)1) : ((byte)0));
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		PawnId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		IsCastedByTaiwu = *pCurrData != 0;
		pCurrData++;
		IsRevealed = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
