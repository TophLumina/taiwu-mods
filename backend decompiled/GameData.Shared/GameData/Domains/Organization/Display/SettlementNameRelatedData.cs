using Config;
using GameData.Serializer;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 定居点名称相关数据
/// </summary>
public struct SettlementNameRelatedData : ISerializableGameData
{
	/// <summary>
	/// 定居点随机名称 ID.
	/// 小于 0 表示该定居点使用固定名称.
	/// </summary>
	public short RandomNameId;

	/// <summary>
	/// 所在地块模板 ID.
	/// 定居点的固定名称从地块配置数据中获取.
	/// </summary>
	public short MapBlockTemplateId;

	/// <summary>
	/// 定居点名称相关数据
	/// </summary>
	/// <param name="randomNameId"></param>
	/// <param name="mapBlockTemplateId"></param>
	public SettlementNameRelatedData(short randomNameId, short mapBlockTemplateId)
	{
		RandomNameId = randomNameId;
		MapBlockTemplateId = mapBlockTemplateId;
	}

	/// <summary>
	/// 获取定居点名
	/// </summary>
	/// <returns></returns>
	public string GetName()
	{
		if (RandomNameId != -1)
		{
			if (RandomNameId == ExternalDataBridge.Context.StockadeInStoryNameId)
			{
				return LocalStringManager.Get(LanguageKey.LK_Stockade_InStory);
			}
			return LocalTownNames.Instance.TownNameCore[RandomNameId].Name;
		}
		if (MapBlockTemplateId == -1)
		{
			return Config.Organization.Instance[(sbyte)0].Name;
		}
		if (MapBlockTemplateId == 17 || MapBlockTemplateId == 18)
		{
			return MapArea.Instance[(short)136].Name;
		}
		return MapBlock.Instance[MapBlockTemplateId].Name;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = RandomNameId;
		((short*)pData)[1] = MapBlockTemplateId;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		RandomNameId = *(short*)pData;
		MapBlockTemplateId = ((short*)pData)[1];
		return 4;
	}
}
