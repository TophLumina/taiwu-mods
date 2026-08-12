using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 定居点显示数据。用于向前端返回显示所需数据，使前端不必监听定居点数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct SettlementDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsInfluencePowerUpdatePaused;

	[SerializableGameDataField]
	public sbyte OrgTemplateId;

	[SerializableGameDataField]
	public short Culture;

	[SerializableGameDataField]
	public short MaxCulture;

	[SerializableGameDataField]
	public short Safety;

	[SerializableGameDataField]
	public short MaxSafety;

	[SerializableGameDataField]
	public short AreaTemplateId;

	[SerializableGameDataField]
	public short ApprovingRate;

	[SerializableGameDataField]
	public int SettlementId;

	[SerializableGameDataField]
	public int Population;

	[SerializableGameDataField]
	public int MaxPopulation;

	[SerializableGameDataField]
	public int InfluencePowerUpdateDate;

	[SerializableGameDataField]
	public int ApprovingRateUpperLimit;

	[SerializableGameDataField]
	public SettlementNameRelatedData SettlementNameRelatedData;

	[SerializableGameDataField]
	public sbyte[] PlaceHolder;

	public short RandomNameId => SettlementNameRelatedData.RandomNameId;

	/// <summary>
	/// 获取定居点玄灰显示状态
	/// </summary>
	public LanguageKey DarkAshStatus
	{
		get
		{
			if (MaxPopulation >= 0)
			{
				if (Population <= MaxPopulation && ExternalDataBridge.Context.TaiwuLocation.AreaId != 138)
				{
					if (Population <= MaxPopulation * 3 / 4)
					{
						return LanguageKey.LK_MouseTip_DarkAsh_Population0;
					}
					return LanguageKey.LK_MouseTip_DarkAsh_Population1;
				}
				return LanguageKey.LK_MouseTip_DarkAsh_Population2;
			}
			return LanguageKey.LK_MouseTip_DarkAsh_Population3;
		}
	}

	public LanguageKey DarkAshTips
	{
		get
		{
			if ((MaxPopulation >= 0 && Population >= MaxPopulation) || ExternalDataBridge.Context.TaiwuLocation.AreaId == 138)
			{
				return LanguageKey.LK_MouseTip_DarkAsh_Population_Active;
			}
			return LanguageKey.LK_MouseTip_DarkAsh_Population_Inactive;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 34;
		totalSize += SettlementNameRelatedData.GetSerializedSize();
		totalSize = ((PlaceHolder == null) ? (totalSize + 2) : (totalSize + (2 + PlaceHolder.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsInfluencePowerUpdatePaused ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)OrgTemplateId;
		pCurrData++;
		*(short*)pCurrData = Culture;
		pCurrData += 2;
		*(short*)pCurrData = MaxCulture;
		pCurrData += 2;
		*(short*)pCurrData = Safety;
		pCurrData += 2;
		*(short*)pCurrData = MaxSafety;
		pCurrData += 2;
		*(short*)pCurrData = AreaTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = ApprovingRate;
		pCurrData += 2;
		*(int*)pCurrData = SettlementId;
		pCurrData += 4;
		*(int*)pCurrData = Population;
		pCurrData += 4;
		*(int*)pCurrData = MaxPopulation;
		pCurrData += 4;
		*(int*)pCurrData = InfluencePowerUpdateDate;
		pCurrData += 4;
		*(int*)pCurrData = ApprovingRateUpperLimit;
		pCurrData += 4;
		pCurrData += SettlementNameRelatedData.Serialize(pCurrData);
		if (PlaceHolder != null)
		{
			int elementsCount = PlaceHolder.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)PlaceHolder[i];
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
		IsInfluencePowerUpdatePaused = *pCurrData != 0;
		pCurrData++;
		OrgTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		Culture = *(short*)pCurrData;
		pCurrData += 2;
		MaxCulture = *(short*)pCurrData;
		pCurrData += 2;
		Safety = *(short*)pCurrData;
		pCurrData += 2;
		MaxSafety = *(short*)pCurrData;
		pCurrData += 2;
		AreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ApprovingRate = *(short*)pCurrData;
		pCurrData += 2;
		SettlementId = *(int*)pCurrData;
		pCurrData += 4;
		Population = *(int*)pCurrData;
		pCurrData += 4;
		MaxPopulation = *(int*)pCurrData;
		pCurrData += 4;
		InfluencePowerUpdateDate = *(int*)pCurrData;
		pCurrData += 4;
		ApprovingRateUpperLimit = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += SettlementNameRelatedData.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (PlaceHolder == null || PlaceHolder.Length != elementsCount)
			{
				PlaceHolder = new sbyte[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PlaceHolder[i] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			PlaceHolder = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
