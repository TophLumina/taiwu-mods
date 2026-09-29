using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

[Obsolete("use SectStoryHeavenlyTreeExtendable instead.")]
public struct SectStoryHeavenlyTree : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public ushort GrowPoint;

	public SectStoryHeavenlyTree(int id, short templateId, Location location)
	{
		Id = id;
		TemplateId = templateId;
		Location = location;
		GrowPoint = 0;
	}

	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, ushort growPoint)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
	}

	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, ushort growPoint, ushort triggerRandomEnemyCount)
	{
		Id = tree.Id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = growPoint;
	}

	public SectStoryHeavenlyTree(SectStoryHeavenlyTree tree, int id)
	{
		Id = id;
		TemplateId = tree.TemplateId;
		Location = tree.Location;
		GrowPoint = tree.GrowPoint;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
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
