using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.FiveLoong;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class JiaoLoongDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	[SerializableGameDataField]
	public bool IsJiao;

	[SerializableGameDataField]
	public Jiao Jiao;

	[SerializableGameDataField]
	public ChildrenOfLoong Loong;

	[SerializableGameDataField]
	public int EvolutionChoice;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public int TamePoint;

	[SerializableGameDataField]
	public int MaxTamePoint;

	[SerializableGameDataField]
	public JiaoLoongNameRelatedData JiaoLoongNameRelatedData;

	[SerializableGameDataField]
	public sbyte ColorCount;

	public bool IsEgg
	{
		get
		{
			if (IsJiao)
			{
				Jiao jiao = Jiao;
				if (jiao != null)
				{
					return jiao.GrowthStage == 0;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 32;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		totalSize = ((Jiao == null) ? (totalSize + 2) : (totalSize + (2 + Jiao.GetSerializedSize())));
		totalSize = ((Loong == null) ? (totalSize + 2) : (totalSize + (2 + Loong.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsJiao ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Jiao != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = Jiao.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Loong != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = Loong.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = EvolutionChoice;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(int*)pCurrData = TamePoint;
		pCurrData += 4;
		*(int*)pCurrData = MaxTamePoint;
		pCurrData += 4;
		pCurrData += JiaoLoongNameRelatedData.Serialize(pCurrData);
		*pCurrData = (byte)ColorCount;
		pCurrData++;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ItemDisplayData = new ItemDisplayData();
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		IsJiao = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			Jiao = new Jiao();
			pCurrData += Jiao.Deserialize(pCurrData);
		}
		else
		{
			Jiao = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			Loong = new ChildrenOfLoong();
			pCurrData += Loong.Deserialize(pCurrData);
		}
		else
		{
			Loong = null;
		}
		EvolutionChoice = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		TamePoint = *(int*)pCurrData;
		pCurrData += 4;
		MaxTamePoint = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += JiaoLoongNameRelatedData.Deserialize(pCurrData);
		ColorCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
