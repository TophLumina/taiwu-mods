using System;
using System.Collections.Generic;
using System.Diagnostics;
using Config;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

/// <summary>
/// 定居点公库
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SettlementTreasury : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort GuardIds = 0;

		public const ushort TemplateGuardIds = 1;

		public const ushort Resources = 2;

		public const ushort LovingItemSubTypes = 3;

		public const ushort HatingItemSubTypes = 4;

		public const ushort Contributions = 5;

		public const ushort Inventory = 6;

		public const ushort LayerIndex = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "GuardIds", "TemplateGuardIds", "Resources", "LovingItemSubTypes", "HatingItemSubTypes", "Contributions", "Inventory", "LayerIndex" };
	}

	/// <summary>
	/// 公库守卫角色 ID 集合
	/// 可能包含一个或多个非智能NPC
	/// 非智能NPC会在过月时被Settlement.UpdateTreasuryOnAdvanceMonth清空
	/// 相关函数：
	/// 1. 获取（临时）守卫：Settlement.GetGuardsDisplayData / Settlement.GetGuards
	/// 2. 刷新临时守卫：Settlement.GetGuardsUnsorted / Settlement.RefreshGuards
	/// 3. 更新智能NPC守卫：Settlement.ForceUpdateTreasuryGuards / Settlement.UpdateTreasuryOnAdvanceMonth
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet GuardIds;

	/// <summary>
	/// 公库模板守卫 ID 集合
	/// </summary>
	[SerializableGameDataField]
	public List<short> TemplateGuardIds = new List<short>();

	/// <summary>
	/// 公库资源
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts Resources;

	/// <summary>
	/// 公库物品
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public Inventory Inventory = new Inventory();

	/// <summary>
	/// 喜好物品子类型集合
	/// </summary>
	[SerializableGameDataField]
	public List<short> LovingItemSubTypes = new List<short>();

	/// <summary>
	/// 厌恶物品子类型集合
	/// </summary>
	[SerializableGameDataField]
	public List<short> HatingItemSubTypes = new List<short>();

	/// <summary>
	/// 成员贡献值集合
	/// 角色ID =&gt; 贡献值
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> Contributions = new Dictionary<int, int>();

	/// <summary>
	/// 库房层级 <see cref="T:GameData.Domains.Organization.SettlementTreasuryLayers" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte LayerIndex;

	/// <summary>
	/// 是否需要提交数据，非序列化
	/// </summary>
	public bool NeedCommit;

	/// <summary>
	/// 成员已使用的预设贡献值
	/// </summary>
	private readonly Dictionary<int, int> _memberUsedPresetContributions = new Dictionary<int, int>();

	/// <summary>
	/// 计算贡献提供的势力值加成
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public int CalcBonusInfluencePower(int charId)
	{
		int contribution = Contributions.GetValueOrDefault(charId, 0);
		int accessoryValue = Accessory.Instance[(short)8].BaseValue;
		return 100 + MathUtils.Min(contribution * 10 / accessoryValue, 100);
	}

	/// <summary>
	/// 指定子类型和价值，计算根据喜好修正后的价值
	/// </summary>
	/// <param name="itemSubType">物品子类型 <see cref="T:GameData.Domains.Item.ItemSubType" /></param>
	/// <param name="worth">物品价值</param>
	/// <returns>修正后的价值</returns>
	public int CalcAdjustedWorth(short itemSubType, int worth)
	{
		if (LovingItemSubTypes.Contains(itemSubType))
		{
			return worth * 125 / 100;
		}
		if (HatingItemSubTypes.Contains(itemSubType))
		{
			return worth * 50 / 100;
		}
		return worth;
	}

	/// <summary>
	/// 获取角色的贡献度
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public int GetContribution(int charId)
	{
		if (!Contributions.TryGetValue(charId, out var contribution))
		{
			return 0;
		}
		return contribution;
	}

	/// <summary>
	/// 检测是否有无效数据并进行修复.
	/// </summary>
	public void DetectAndFixInvalidData()
	{
		for (sbyte resourceType = 0; resourceType < 8; resourceType++)
		{
			if (Resources[resourceType] < 0)
			{
				AdaptableLog.Warning($"Invalid resource amount for settlement treasury: type={resourceType},value={Resources[resourceType]}\n{new StackTrace()}", appendWarningMessage: true);
				Resources[resourceType] = 0;
			}
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 35;
		totalSize += GuardIds.GetSerializedSize();
		totalSize = ((TemplateGuardIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TemplateGuardIds.Count)));
		totalSize = ((LovingItemSubTypes == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LovingItemSubTypes.Count)));
		totalSize = ((HatingItemSubTypes == null) ? (totalSize + 2) : (totalSize + (2 + 2 * HatingItemSubTypes.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(Contributions);
		totalSize = ((Inventory == null) ? (totalSize + 4) : (totalSize + (4 + Inventory.GetSerializedSize())));
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
		*(short*)pCurrData = 8;
		pCurrData += 2;
		int fieldSize = GuardIds.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (TemplateGuardIds != null)
		{
			int elementsCount = TemplateGuardIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TemplateGuardIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Resources.Serialize(pCurrData);
		if (LovingItemSubTypes != null)
		{
			int elementsCount2 = LovingItemSubTypes.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = LovingItemSubTypes[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HatingItemSubTypes != null)
		{
			int elementsCount3 = HatingItemSubTypes.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = HatingItemSubTypes[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref Contributions);
		if (Inventory != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize2 = Inventory.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= int.MaxValue);
			*(int*)intPtr = fieldSize2;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (byte)LayerIndex;
		pCurrData++;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += GuardIds.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TemplateGuardIds == null)
				{
					TemplateGuardIds = new List<short>(elementsCount);
				}
				else
				{
					TemplateGuardIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					TemplateGuardIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				TemplateGuardIds?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += Resources.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (LovingItemSubTypes == null)
				{
					LovingItemSubTypes = new List<short>(elementsCount2);
				}
				else
				{
					LovingItemSubTypes.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					LovingItemSubTypes.Add(((short*)pCurrData)[j]);
				}
				pCurrData += 2 * elementsCount2;
			}
			else
			{
				LovingItemSubTypes?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (HatingItemSubTypes == null)
				{
					HatingItemSubTypes = new List<short>(elementsCount3);
				}
				else
				{
					HatingItemSubTypes.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					HatingItemSubTypes.Add(((short*)pCurrData)[k]);
				}
				pCurrData += 2 * elementsCount3;
			}
			else
			{
				HatingItemSubTypes?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref Contributions);
		}
		if (fieldCount > 6)
		{
			int num = *(int*)pCurrData;
			pCurrData += 4;
			if (num > 0)
			{
				if (Inventory == null)
				{
					Inventory = new Inventory();
				}
				pCurrData += Inventory.Deserialize(pCurrData);
			}
			else
			{
				Inventory = null;
			}
		}
		if (fieldCount > 7)
		{
			LayerIndex = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 清空成员已用的预设贡献值
	/// </summary>
	public void ClearMemberUsedPresetContribution()
	{
		_memberUsedPresetContributions.Clear();
	}

	/// <summary>
	/// 获取成员的贡献值.
	/// 包含预设贡献值和累计贡献值.
	/// </summary>
	public int GetMemberContribution(int charId, OrganizationInfo orgInfo)
	{
		int presetContribution = orgInfo.GetOrgMemberConfig().ContributionPerMonth;
		int usedPresetContribution = _memberUsedPresetContributions.GetValueOrDefault(charId, 0);
		return Contributions.GetValueOrDefault(charId, 0) + presetContribution - usedPresetContribution;
	}

	/// <summary>
	/// 离线修改成员贡献值.
	/// 会优先使用预设贡献值, 用完后再使用累计贡献值.
	/// </summary>
	public void OfflineChangeContribution(int charId, int presetContribution, int delta)
	{
		if (delta >= 0)
		{
			OfflineChanceActualContribution(charId, delta);
			return;
		}
		int prevAmount = _memberUsedPresetContributions.GetValueOrDefault(charId);
		int remainingAmount = presetContribution - prevAmount;
		if (remainingAmount + delta >= 0)
		{
			_memberUsedPresetContributions[charId] = prevAmount - delta;
			return;
		}
		OfflineChanceActualContribution(charId, remainingAmount + delta);
		_memberUsedPresetContributions[charId] = presetContribution;
	}

	private void OfflineChanceActualContribution(int charId, int delta)
	{
		if (Contributions.TryGetValue(charId, out var value))
		{
			Contributions[charId] = (int)Math.Clamp((long)value + (long)delta, -2147483648L, 2147483647L);
		}
		else
		{
			Contributions.Add(charId, Math.Clamp(delta, int.MinValue, int.MaxValue));
		}
	}
}
