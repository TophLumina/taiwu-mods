using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Combat;

/// <summary>
/// 战败标记详细信息数据（仅包含需要后端获取的字段）
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class DefeatMarkDetailInfoDisplayData : ISerializableGameData
{
	/// <summary>
	/// 毒素发作触发进度（仅毒素类型使用）
	/// 含义根据毒素类型不同：
	/// - 烈毒：剩余兵器攻击次数
	/// - 郁毒：剩余需要移动距离
	/// - 寒毒：剩余需要失去提气百分比
	/// - 赤毒：剩余需要失去架势百分比
	/// - 腐毒/幻毒：0（不使用）
	/// </summary>
	[SerializableGameDataField]
	public int PoisonTriggerProgress;

	/// <summary>
	/// 状态强度（仅状态类型使用）
	/// </summary>
	[SerializableGameDataField]
	public int StateBuffPower;

	/// <summary>
	/// 该角色服食栏中各槽位的蛊虫 TemplateId，按槽位索引排列（仅蛊标记使用）
	/// 无蛊的槽位为 -1，数组长度固定为 EatingItems.MaxCount
	/// </summary>
	[SerializableGameDataField]
	public short[] WugTemplateIds;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((WugTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * WugTemplateIds.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = PoisonTriggerProgress;
		pCurrData += 4;
		*(int*)pCurrData = StateBuffPower;
		pCurrData += 4;
		if (WugTemplateIds != null)
		{
			int elementsCount = WugTemplateIds.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = WugTemplateIds[i];
				pCurrData += 2;
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
		PoisonTriggerProgress = *(int*)pCurrData;
		pCurrData += 4;
		StateBuffPower = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (WugTemplateIds == null || WugTemplateIds.Length != elementsCount)
			{
				WugTemplateIds = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				WugTemplateIds[i] = *(short*)pCurrData;
				pCurrData += 2;
			}
		}
		else
		{
			WugTemplateIds = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
