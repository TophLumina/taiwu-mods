using System.Collections.Generic;
using GameData.Domains.Organization.Display;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForArchive = true)]
public struct BuildingManageYieldTipsData(int arg1) : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ManageProduceValuationMin = 0;

		public const ushort ManageProduceValuationMax = 1;

		public const ushort ResourceOutputValuation = 2;

		public const ushort ProduceResourceType = 3;

		public const ushort ManagerAttainment = 4;

		public const ushort BuildingProduceDependencyData = 5;

		public const ushort ProduceDependencies = 6;

		public const ushort SafetyOrCultureFactorSettlementsAndPickValue = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "ManageProduceValuationMin", "ManageProduceValuationMax", "ResourceOutputValuation", "ProduceResourceType", "ManagerAttainment", "BuildingProduceDependencyData", "ProduceDependencies", "SafetyOrCultureFactorSettlementsAndPickValue" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int ManageProduceValuationMin = 0;

	[SerializableGameDataField(FieldIndex = 1)]
	public int ManageProduceValuationMax = 0;

	[SerializableGameDataField(FieldIndex = 2)]
	public int ResourceOutputValuation = 0;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte ProduceResourceType = 0;

	[SerializableGameDataField(FieldIndex = 4)]
	public int ManagerAttainment = 0;

	[SerializableGameDataField(FieldIndex = 5)]
	public BuildingProduceDependencyData BuildingProduceDependencyData = default(BuildingProduceDependencyData);

	[SerializableGameDataField(FieldIndex = 6)]
	public Dictionary<BuildingBlockKey, BuildingProduceDependencyData> ProduceDependencies = new Dictionary<BuildingBlockKey, BuildingProduceDependencyData>();

	[SerializableGameDataField(FieldIndex = 7)]
	public Dictionary<int, SettlementDisplayData> SafetyOrCultureFactorSettlementsAndPickValue = new Dictionary<int, SettlementDisplayData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 59;
		totalSize += 4;
		if (ProduceDependencies != null)
		{
			foreach (KeyValuePair<BuildingBlockKey, BuildingProduceDependencyData> pair in ProduceDependencies)
			{
				totalSize += pair.Key.GetSerializedSize();
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (SafetyOrCultureFactorSettlementsAndPickValue != null)
		{
			foreach (KeyValuePair<int, SettlementDisplayData> pair2 in SafetyOrCultureFactorSettlementsAndPickValue)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(int*)pCurrData = ManageProduceValuationMin;
		pCurrData += 4;
		*(int*)pCurrData = ManageProduceValuationMax;
		pCurrData += 4;
		*(int*)pCurrData = ResourceOutputValuation;
		pCurrData += 4;
		*pCurrData = (byte)ProduceResourceType;
		pCurrData++;
		*(int*)pCurrData = ManagerAttainment;
		pCurrData += 4;
		pCurrData += BuildingProduceDependencyData.Serialize(pCurrData);
		if (ProduceDependencies != null)
		{
			*(int*)pCurrData = ProduceDependencies.Count;
			pCurrData += 4;
			foreach (KeyValuePair<BuildingBlockKey, BuildingProduceDependencyData> pair in ProduceDependencies)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SafetyOrCultureFactorSettlementsAndPickValue != null)
		{
			*(int*)pCurrData = SafetyOrCultureFactorSettlementsAndPickValue.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, SettlementDisplayData> pair2 in SafetyOrCultureFactorSettlementsAndPickValue)
			{
				*(int*)pCurrData = pair2.Key;
				pCurrData += 4;
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ManageProduceValuationMin = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ManageProduceValuationMax = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			ResourceOutputValuation = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ProduceResourceType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			ManagerAttainment = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			pCurrData += BuildingProduceDependencyData.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			int ProduceDependenciesElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (ProduceDependenciesElementsCount > 0)
			{
				if (ProduceDependencies == null)
				{
					ProduceDependencies = new Dictionary<BuildingBlockKey, BuildingProduceDependencyData>();
				}
				else
				{
					ProduceDependencies.Clear();
				}
				for (int i = 0; i < ProduceDependenciesElementsCount; i++)
				{
					BuildingBlockKey key = default(BuildingBlockKey);
					pCurrData += key.Deserialize(pCurrData);
					BuildingProduceDependencyData value = default(BuildingProduceDependencyData);
					pCurrData += value.Deserialize(pCurrData);
					ProduceDependencies.Add(key, value);
				}
			}
			else
			{
				ProduceDependencies?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			int SafetyOrCultureFactorSettlementsAndPickValueElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (SafetyOrCultureFactorSettlementsAndPickValueElementsCount > 0)
			{
				if (SafetyOrCultureFactorSettlementsAndPickValue == null)
				{
					SafetyOrCultureFactorSettlementsAndPickValue = new Dictionary<int, SettlementDisplayData>();
				}
				else
				{
					SafetyOrCultureFactorSettlementsAndPickValue.Clear();
				}
				for (int j = 0; j < SafetyOrCultureFactorSettlementsAndPickValueElementsCount; j++)
				{
					int key2 = *(int*)pCurrData;
					pCurrData += 4;
					SettlementDisplayData value2 = default(SettlementDisplayData);
					pCurrData += value2.Deserialize(pCurrData);
					SafetyOrCultureFactorSettlementsAndPickValue.Add(key2, value2);
				}
			}
			else
			{
				SafetyOrCultureFactorSettlementsAndPickValue?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
