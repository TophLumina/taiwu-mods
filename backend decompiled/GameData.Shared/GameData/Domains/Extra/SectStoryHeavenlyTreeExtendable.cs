using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 地区主线 - 武当 - 神木数据
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectStoryHeavenlyTreeExtendable : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort Location = 2;

		public const ushort GrowPoint = 3;

		public const ushort TriggerRandomEnemyCount = 4;

		public const ushort MetInDream = 5;

		public const ushort FindFairyland = 6;

		public const ushort FightWithSnake = 7;

		public const ushort SnakeTemplateId = 8;

		public const ushort ReadBookList = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "Id", "TemplateId", "Location", "GrowPoint", "TriggerRandomEnemyCount", "MetInDream", "FindFairyland", "FightWithSnake", "SnakeTemplateId", "ReadBookList" };
	}

	/// <summary>
	/// 神木角色id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 神木种类
	/// Misc TemplateId
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 神木位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 神木成长值 
	/// </summary>
	[SerializableGameDataField]
	public ushort GrowPoint;

	/// <summary>
	/// 神木成长时触发生成相枢爪牙的次数
	/// </summary>
	[SerializableGameDataField]
	public ushort TriggerRandomEnemyCount;

	/// <summary>
	/// 神木入梦事件是否触发
	/// </summary>
	[SerializableGameDataField]
	public bool MetInDream;

	/// <summary>
	/// 神木是否已经发现洞天
	/// </summary>
	[SerializableGameDataField]
	public bool FindFairyland;

	/// <summary>
	/// 是否已经和洞天的蛇战斗过
	/// </summary>
	[SerializableGameDataField]
	public bool FightWithSnake;

	/// <summary>
	/// 神木洞天对应的蛇
	/// </summary>
	[SerializableGameDataField]
	public short SnakeTemplateId;

	/// <summary>
	/// 神木读过的书
	/// </summary>
	[SerializableGameDataField]
	public List<short> ReadBookList;

	/// <summary>
	/// 生长值未满，才能进行清空敌人、培育的操作
	/// </summary>
	public bool IsGrowPointMax => GrowPoint >= 900;

	/// <summary>
	/// 获取成长阶段对应的人物模板
	/// </summary>
	public int GrowTemplateId => GameData.Domains.World.SharedMethods.GetHeavenlyTreeTemplateIdByGrowValue(GrowPoint);

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="templateId"></param>
	/// <param name="location"></param>
	public SectStoryHeavenlyTreeExtendable(int id, short templateId, Location location)
	{
		Id = id;
		TemplateId = templateId;
		Location = location;
		GrowPoint = 0;
		TriggerRandomEnemyCount = 0;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="growPoint"></param>
	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, ushort growPoint)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
		TriggerRandomEnemyCount = tree.TriggerRandomEnemyCount;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="growPoint"></param>
	/// <param name="triggerRandomEnemyCount"></param>
	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, ushort growPoint, ushort triggerRandomEnemyCount)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
		TriggerRandomEnemyCount = triggerRandomEnemyCount;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="id"></param>
	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable tree, int id)
	{
		Id = id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = tree.GrowPoint;
		TriggerRandomEnemyCount = tree.TriggerRandomEnemyCount;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryHeavenlyTreeExtendable()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectStoryHeavenlyTreeExtendable(SectStoryHeavenlyTreeExtendable other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		Location = other.Location;
		GrowPoint = other.GrowPoint;
		TriggerRandomEnemyCount = other.TriggerRandomEnemyCount;
		MetInDream = other.MetInDream;
		FindFairyland = other.FindFairyland;
		FightWithSnake = other.FightWithSnake;
		SnakeTemplateId = other.SnakeTemplateId;
		ReadBookList = ((other.ReadBookList == null) ? null : new List<short>(other.ReadBookList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectStoryHeavenlyTreeExtendable other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		Location = other.Location;
		GrowPoint = other.GrowPoint;
		TriggerRandomEnemyCount = other.TriggerRandomEnemyCount;
		MetInDream = other.MetInDream;
		FindFairyland = other.FindFairyland;
		FightWithSnake = other.FightWithSnake;
		SnakeTemplateId = other.SnakeTemplateId;
		ReadBookList = ((other.ReadBookList == null) ? null : new List<short>(other.ReadBookList));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 21;
		totalSize = ((ReadBookList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReadBookList.Count)));
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
		*(short*)pCurrData = 10;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(ushort*)pCurrData = GrowPoint;
		pCurrData += 2;
		*(ushort*)pCurrData = TriggerRandomEnemyCount;
		pCurrData += 2;
		*pCurrData = (MetInDream ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (FindFairyland ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (FightWithSnake ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = SnakeTemplateId;
		pCurrData += 2;
		if (ReadBookList != null)
		{
			int elementsCount = ReadBookList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = ReadBookList[i];
			}
			pCurrData += 2 * elementsCount;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			GrowPoint = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			TriggerRandomEnemyCount = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			MetInDream = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 6)
		{
			FindFairyland = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 7)
		{
			FightWithSnake = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 8)
		{
			SnakeTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 9)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (ReadBookList == null)
				{
					ReadBookList = new List<short>(elementsCount);
				}
				else
				{
					ReadBookList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ReadBookList.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				ReadBookList?.Clear();
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
