using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 地区主线 - 武当 - 神木数据
/// </summary>
[Obsolete("use SectStoryHeavenlyTreeExtendable instead.")]
public struct SectStoryHeavenlyTree : ISerializableGameData
{
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
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="templateId"></param>
	/// <param name="location"></param>
	public SectStoryHeavenlyTree(int id, short templateId, Location location)
	{
		Id = id;
		TemplateId = templateId;
		Location = location;
		GrowPoint = 0;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="growPoint"></param>
	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, ushort growPoint)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="growPoint"></param>
	/// <param name="triggerRandomEnemyCount"></param>
	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, ushort growPoint, ushort triggerRandomEnemyCount)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="tree"></param>
	/// <param name="id"></param>
	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, int id)
	{
		Id = id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = tree.GrowPoint;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
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
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(ushort*)pCurrData = GrowPoint;
		pCurrData += 2;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += Location.Deserialize(pCurrData);
		GrowPoint = *(ushort*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
