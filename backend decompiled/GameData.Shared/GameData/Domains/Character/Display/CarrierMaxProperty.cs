using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class CarrierMaxProperty : ISerializableGameData
{
	[SerializableGameDataField]
	public int WorkingCarrierMaxInventoryLoadBonus;

	[SerializableGameDataField]
	public int WorkingCarrierKidnapMaxSlotCount;

	[SerializableGameDataField]
	public int WorkingCarrierTimeBonus;

	[SerializableGameDataField]
	public int WorkingCarrierDropBonus;

	[SerializableGameDataField]
	public int WorkingCarrierExploreBonusRate;

	[SerializableGameDataField]
	public int WorkingCarrierCaptureRateBonus;

	public CarrierMaxProperty()
	{
	}

	public CarrierMaxProperty(CarrierMaxProperty other)
	{
		WorkingCarrierMaxInventoryLoadBonus = other.WorkingCarrierMaxInventoryLoadBonus;
		WorkingCarrierKidnapMaxSlotCount = other.WorkingCarrierKidnapMaxSlotCount;
		WorkingCarrierTimeBonus = other.WorkingCarrierTimeBonus;
		WorkingCarrierDropBonus = other.WorkingCarrierDropBonus;
		WorkingCarrierExploreBonusRate = other.WorkingCarrierExploreBonusRate;
		WorkingCarrierCaptureRateBonus = other.WorkingCarrierCaptureRateBonus;
	}

	public void Assign(CarrierMaxProperty other)
	{
		WorkingCarrierMaxInventoryLoadBonus = other.WorkingCarrierMaxInventoryLoadBonus;
		WorkingCarrierKidnapMaxSlotCount = other.WorkingCarrierKidnapMaxSlotCount;
		WorkingCarrierTimeBonus = other.WorkingCarrierTimeBonus;
		WorkingCarrierDropBonus = other.WorkingCarrierDropBonus;
		WorkingCarrierExploreBonusRate = other.WorkingCarrierExploreBonusRate;
		WorkingCarrierCaptureRateBonus = other.WorkingCarrierCaptureRateBonus;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = WorkingCarrierMaxInventoryLoadBonus;
		byte* num = pData + 4;
		*(int*)num = WorkingCarrierKidnapMaxSlotCount;
		byte* num2 = num + 4;
		*(int*)num2 = WorkingCarrierTimeBonus;
		byte* num3 = num2 + 4;
		*(int*)num3 = WorkingCarrierDropBonus;
		byte* num4 = num3 + 4;
		*(int*)num4 = WorkingCarrierExploreBonusRate;
		byte* num5 = num4 + 4;
		*(int*)num5 = WorkingCarrierCaptureRateBonus;
		int totalSize = (int)(num5 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		WorkingCarrierMaxInventoryLoadBonus = *(int*)pCurrData;
		pCurrData += 4;
		WorkingCarrierKidnapMaxSlotCount = *(int*)pCurrData;
		pCurrData += 4;
		WorkingCarrierTimeBonus = *(int*)pCurrData;
		pCurrData += 4;
		WorkingCarrierDropBonus = *(int*)pCurrData;
		pCurrData += 4;
		WorkingCarrierExploreBonusRate = *(int*)pCurrData;
		pCurrData += 4;
		WorkingCarrierCaptureRateBonus = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
