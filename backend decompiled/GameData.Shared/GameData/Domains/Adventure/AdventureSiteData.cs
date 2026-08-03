using System;
using Config;
using GameData.Domains.TaiwuEvent.MonthlyEventActions;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇地点信息（在地图上的地点）
/// </summary>
[Serializable]
public class AdventureSiteData : ISerializableGameData
{
	/// <summary>
	/// 对应奇遇的模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 奇遇截至剩余时间
	/// </summary>
	[SerializableGameDataField]
	public short RemainingMonths;

	/// <summary>
	/// 初次进入奇遇的数据
	/// </summary>
	[SerializableGameDataField]
	public int SiteInitData;

	/// <summary>
	/// 该奇遇点的状态 <see cref="T:GameData.Domains.Adventure.AdventureSiteState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte SiteState;

	/// <summary>
	/// 创建该奇遇的过月行为的Key，如果该奇遇点是由过月行为生成的则必须手动设置
	/// </summary>
	[SerializableGameDataField]
	public MonthlyActionKey MonthlyActionKey = MonthlyActionKey.Invalid;

	public Config.AdventureItem GetConfig()
	{
		return Config.Adventure.Instance[TemplateId];
	}

	/// <summary>
	/// 该奇遇是否为巢穴奇遇 (外道巢穴/义士据点)
	/// </summary>
	public bool IsEnemyNest()
	{
		Config.AdventureItem config = GetConfig();
		if (config.Type != 4)
		{
			return config.Type == 5;
		}
		return true;
	}

	/// <summary>
	/// 该奇遇是否为天材地宝奇遇
	/// </summary>
	public bool IsMaterialResource()
	{
		Config.AdventureItem config = GetConfig();
		sbyte beginId = 9;
		if (config.Type >= beginId)
		{
			return config.Type < beginId + 6;
		}
		return false;
	}

	public AdventureSiteData(short templateId, short remainingMonths, MonthlyActionKey monthlyActionKey)
	{
		TemplateId = templateId;
		RemainingMonths = remainingMonths;
		SiteInitData = int.MinValue;
		SiteState = ((!monthlyActionKey.IsValid()) ? ((sbyte)1) : ((sbyte)0));
		MonthlyActionKey = monthlyActionKey;
	}

	/// <summary>
	/// 奇遇点被清除时调用
	/// </summary>
	public void OnDestroy()
	{
	}

	public AdventureSiteData()
	{
	}

	public AdventureSiteData(AdventureSiteData other)
	{
		TemplateId = other.TemplateId;
		RemainingMonths = other.RemainingMonths;
		SiteInitData = other.SiteInitData;
		SiteState = other.SiteState;
		MonthlyActionKey = other.MonthlyActionKey;
	}

	public void Assign(AdventureSiteData other)
	{
		TemplateId = other.TemplateId;
		RemainingMonths = other.RemainingMonths;
		SiteInitData = other.SiteInitData;
		SiteState = other.SiteState;
		MonthlyActionKey = other.MonthlyActionKey;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = RemainingMonths;
		pCurrData += 2;
		*(int*)pCurrData = SiteInitData;
		pCurrData += 4;
		*pCurrData = (byte)SiteState;
		pCurrData++;
		pCurrData += MonthlyActionKey.Serialize(pCurrData);
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
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		RemainingMonths = *(short*)pCurrData;
		pCurrData += 2;
		SiteInitData = *(int*)pCurrData;
		pCurrData += 4;
		SiteState = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += MonthlyActionKey.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
