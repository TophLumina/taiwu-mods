using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 然山地区主线 - 三尸角色的额外数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectStoryThreeCorpsesCharacter : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort IsGoodEnd = 1;

		public const ushort Target = 2;

		public const ushort EndDate = 3;

		public const ushort NextDate = 4;

		public const ushort Notch = 5;

		public const ushort LegendaryBooks = 6;

		public const ushort IsUpgraded = 7;

		public const ushort Id = 8;

		public const ushort TargetOwner = 9;

		public const ushort Progress = 10;

		public const ushort IsAroundTaiwu = 11;

		public const ushort TaiwuId = 12;

		public const ushort PassLegacyEventTriggered = 13;

		public const ushort GiveUpCount = 14;

		public const ushort Count = 15;

		public static readonly string[] FieldId2FieldName = new string[15]
		{
			"TemplateId", "IsGoodEnd", "Target", "EndDate", "NextDate", "Notch", "LegendaryBooks", "IsUpgraded", "Id", "TargetOwner",
			"Progress", "IsAroundTaiwu", "TaiwuId", "PassLegacyEventTriggered", "GiveUpCount"
		};
	}

	/// <summary>
	/// 三尸角色的角色Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 三尸角色的角色模板Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 是否是好结局
	/// 坏结局会使得角色在剧情结束后不会出现
	/// </summary>
	[SerializableGameDataField]
	public bool IsGoodEnd;

	/// <summary>
	/// 亲密事件进度
	/// 进度满会暂时在地图上消失
	/// </summary>
	[SerializableGameDataField]
	public sbyte Progress;

	/// <summary>
	/// 当前目标
	/// 没有目标会使其出现在太吾村周围
	/// </summary>
	[SerializableGameDataField]
	public sbyte Target;

	/// <summary>
	/// 当前目标的拥有者
	/// </summary>
	[SerializableGameDataField]
	public int TargetOwner;

	/// <summary>
	/// 跟随结束日期
	/// </summary>
	[SerializableGameDataField]
	public int EndDate;

	/// <summary>
	/// 下次尝试行动的日期
	/// </summary>
	[SerializableGameDataField]
	public int NextDate;

	/// <summary>
	/// 选择的档次
	/// </summary>
	[SerializableGameDataField]
	public sbyte Notch;

	/// <summary>
	/// 奇书列表
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> LegendaryBooks;

	/// <summary>
	/// 是否升过级
	/// 未升级可存2本书，升级后可存4本书
	/// 当前版本不存在该功能，留下接口等待地区主线升级剧情后使用
	/// </summary>
	[SerializableGameDataField]
	public bool IsUpgraded;

	/// <summary>
	/// 是否跟随太吾
	/// </summary>
	[SerializableGameDataField]
	public bool IsAroundTaiwu;

	/// <summary>
	/// 初见太吾的Id
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuId;

	/// <summary>
	/// 传剑事件是否触发过
	/// </summary>
	[SerializableGameDataField]
	public bool PassLegacyEventTriggered;

	/// <summary>
	/// 传剑事件是否触发过
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, int> GiveUpCount;

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="templateId"></param>
	public SectStoryThreeCorpsesCharacter(int id, short templateId, int taiwuId)
	{
		Id = id;
		TemplateId = templateId;
		IsGoodEnd = false;
		Progress = 0;
		Target = -1;
		TargetOwner = -1;
		EndDate = -1;
		NextDate = -1;
		Notch = 0;
		LegendaryBooks = null;
		IsUpgraded = false;
		IsAroundTaiwu = true;
		TaiwuId = taiwuId;
		PassLegacyEventTriggered = false;
		GiveUpCount = new Dictionary<int, int>();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryThreeCorpsesCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectStoryThreeCorpsesCharacter(SectStoryThreeCorpsesCharacter other)
	{
		TemplateId = other.TemplateId;
		IsGoodEnd = other.IsGoodEnd;
		Target = other.Target;
		EndDate = other.EndDate;
		NextDate = other.NextDate;
		Notch = other.Notch;
		LegendaryBooks = ((other.LegendaryBooks == null) ? null : new List<sbyte>(other.LegendaryBooks));
		IsUpgraded = other.IsUpgraded;
		Id = other.Id;
		TargetOwner = other.TargetOwner;
		Progress = other.Progress;
		IsAroundTaiwu = other.IsAroundTaiwu;
		TaiwuId = other.TaiwuId;
		PassLegacyEventTriggered = other.PassLegacyEventTriggered;
		GiveUpCount = ((other.GiveUpCount == null) ? null : new Dictionary<int, int>(other.GiveUpCount));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectStoryThreeCorpsesCharacter other)
	{
		TemplateId = other.TemplateId;
		IsGoodEnd = other.IsGoodEnd;
		Target = other.Target;
		EndDate = other.EndDate;
		NextDate = other.NextDate;
		Notch = other.Notch;
		LegendaryBooks = ((other.LegendaryBooks == null) ? null : new List<sbyte>(other.LegendaryBooks));
		IsUpgraded = other.IsUpgraded;
		Id = other.Id;
		TargetOwner = other.TargetOwner;
		Progress = other.Progress;
		IsAroundTaiwu = other.IsAroundTaiwu;
		TaiwuId = other.TaiwuId;
		PassLegacyEventTriggered = other.PassLegacyEventTriggered;
		GiveUpCount = ((other.GiveUpCount == null) ? null : new Dictionary<int, int>(other.GiveUpCount));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 31;
		totalSize = ((LegendaryBooks == null) ? (totalSize + 2) : (totalSize + (2 + LegendaryBooks.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(GiveUpCount);
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
		*(short*)pCurrData = 15;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (IsGoodEnd ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)Target;
		pCurrData++;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		*(int*)pCurrData = NextDate;
		pCurrData += 4;
		*pCurrData = (byte)Notch;
		pCurrData++;
		if (LegendaryBooks != null)
		{
			int elementsCount = LegendaryBooks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)LegendaryBooks[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsUpgraded ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(int*)pCurrData = TargetOwner;
		pCurrData += 4;
		*pCurrData = (byte)Progress;
		pCurrData++;
		*pCurrData = (IsAroundTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TaiwuId;
		pCurrData += 4;
		*pCurrData = (PassLegacyEventTriggered ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref GiveUpCount);
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
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 1)
		{
			IsGoodEnd = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			Target = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			EndDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			NextDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			Notch = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (LegendaryBooks == null)
				{
					LegendaryBooks = new List<sbyte>(elementsCount);
				}
				else
				{
					LegendaryBooks.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					LegendaryBooks.Add((sbyte)pCurrData[i]);
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				LegendaryBooks?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			IsUpgraded = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 8)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			TargetOwner = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 10)
		{
			Progress = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 11)
		{
			IsAroundTaiwu = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			TaiwuId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 13)
		{
			PassLegacyEventTriggered = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 14)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref GiveUpCount);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
