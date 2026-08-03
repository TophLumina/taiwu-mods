using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法显示数据。用于向前端返回显示所需数据，使前端不必监听功法数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class EquipCombatSkillDisplayData : ISerializableGameData
{
	/// <summary>
	/// 功法数据
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillDisplayDataCharacterMenuListItem> CombatSkillDisplayDatas;

	/// <summary>
	/// 当前预设 ID.
	/// 功法方案只是一个记录, 并不代表角色在切换方案或读档时仍然拥有这些功法. 读档时并不会根据功法方案的数据改变角色功法.
	/// 当预设 ID 变化时，根据当前的装配情况保存旧预设的功法配置信息.
	/// </summary>
	[SerializableGameDataField]
	public int CurrentPlanId;

	/// <summary>
	/// 锁定功法装备配置.
	/// 锁定后过月AI逻辑不再会改变该角色的功法配置
	/// </summary>
	[SerializableGameDataField]
	public bool IsCombatSkillLocked;

	/// <summary>
	/// 当前功法装备预设列表
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillEquipment CurrentEquipPlan;

	/// <summary>
	/// 各类功法万用格分配个数
	/// </summary>
	[SerializableGameDataField]
	public byte[] GenericGridAllocation;

	/// <summary>
	/// 预设总数
	/// </summary>
	[SerializableGameDataField]
	public int PlanCount;

	/// <summary>
	/// 当前战斗功法排序方案
	/// </summary>
	[SerializableGameDataField]
	public ShortList CombatSkillOrderPlan;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public EquipCombatSkillDisplayData()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (CombatSkillDisplayDatas != null)
		{
			totalSize += 2;
			int elementsCount = CombatSkillDisplayDatas.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = CombatSkillDisplayDatas[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CurrentEquipPlan == null) ? (totalSize + 2) : (totalSize + (2 + CurrentEquipPlan.GetSerializedSize())));
		totalSize = ((GenericGridAllocation == null) ? (totalSize + 2) : (totalSize + (2 + GenericGridAllocation.Length)));
		totalSize += CombatSkillOrderPlan.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CombatSkillDisplayDatas != null)
		{
			int elementsCount = CombatSkillDisplayDatas.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = CombatSkillDisplayDatas[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CurrentPlanId;
		pCurrData += 4;
		*pCurrData = (IsCombatSkillLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CurrentEquipPlan != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize = CurrentEquipPlan.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GenericGridAllocation != null)
		{
			int elementsCount2 = GenericGridAllocation.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = GenericGridAllocation[j];
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = PlanCount;
		pCurrData += 4;
		int fieldSize2 = CombatSkillOrderPlan.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int totalSize = (int)(pCurrData - pData);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CombatSkillDisplayDatas == null)
			{
				CombatSkillDisplayDatas = new List<CombatSkillDisplayDataCharacterMenuListItem>(elementsCount);
			}
			else
			{
				CombatSkillDisplayDatas.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CombatSkillDisplayDataCharacterMenuListItem element = new CombatSkillDisplayDataCharacterMenuListItem();
					pCurrData += element.Deserialize(pCurrData);
					CombatSkillDisplayDatas.Add(element);
				}
				else
				{
					CombatSkillDisplayDatas.Add(null);
				}
			}
		}
		else
		{
			CombatSkillDisplayDatas?.Clear();
		}
		CurrentPlanId = *(int*)pCurrData;
		pCurrData += 4;
		IsCombatSkillLocked = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (CurrentEquipPlan == null)
			{
				CurrentEquipPlan = new CombatSkillEquipment();
			}
			pCurrData += CurrentEquipPlan.Deserialize(pCurrData);
		}
		else
		{
			CurrentEquipPlan = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (GenericGridAllocation == null || GenericGridAllocation.Length != elementsCount2)
			{
				GenericGridAllocation = new byte[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				GenericGridAllocation[j] = pCurrData[j];
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			GenericGridAllocation = null;
		}
		PlanCount = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += CombatSkillOrderPlan.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
