using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 五方神龙 - 蛟和龙子在前端显示时的数据结构
/// 用于一次获取tips需要显示的数据，不再需要多层异步
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class JiaoLoongDisplayData : ISerializableGameData
{
	/// <summary>
	/// 蛟从卵开始使用的Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 物品的显示数据
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	/// <summary>
	/// 是蛟还是龙子
	/// </summary>
	[SerializableGameDataField]
	public bool IsJiao;

	/// <summary>
	/// 蛟的数据
	/// </summary>
	[SerializableGameDataField]
	public Jiao Jiao;

	/// <summary>
	/// 龙子的数据
	/// </summary>
	[SerializableGameDataField]
	public ChildrenOfLoong Loong;

	/// <summary>
	/// 可选的化龙结果
	/// 小于等于0时不可化龙
	/// </summary>
	[SerializableGameDataField]
	public int EvolutionChoice;

	/// <summary>
	/// 根据当前ItemKey的TemplateId获取的Jiao配置表中的TemplateId
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 驯服度
	/// </summary>
	[SerializableGameDataField]
	public int TamePoint;

	/// <summary>
	/// 最大驯服度
	/// </summary>
	[SerializableGameDataField]
	public int MaxTamePoint;

	/// <summary>
	/// 蛟龙名称数据
	/// </summary>
	[SerializableGameDataField]
	public JiaoLoongNameRelatedData JiaoLoongNameRelatedData;

	/// <summary>
	/// 颜色数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte ColorCount;

	/// <summary>
	/// 是否是蛟卵
	/// </summary>
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
		int totalSize = 20;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		totalSize = ((Jiao == null) ? (totalSize + 2) : (totalSize + (2 + Jiao.GetSerializedSize())));
		totalSize = ((Loong == null) ? (totalSize + 2) : (totalSize + (2 + Loong.GetSerializedSize())));
		totalSize += JiaoLoongNameRelatedData.GetSerializedSize();
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
