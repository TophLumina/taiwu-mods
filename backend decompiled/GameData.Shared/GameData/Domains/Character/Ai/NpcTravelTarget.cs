using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

/// <summary>
/// NPC移动目标
/// </summary>
public struct NpcTravelTarget : ISerializableGameData
{
	/// <summary>
	/// 目标类型
	/// </summary>
	[SerializableGameDataField]
	private bool _isTargetFixedLocation;

	/// <summary>
	/// 目标角色ID
	/// </summary>
	[SerializableGameDataField]
	public int TargetCharId;

	/// <summary>
	/// 固定目标地点
	/// </summary>
	[SerializableGameDataField]
	private Location _targetLocation;

	/// <summary>
	/// 该目标剩余有效时间
	/// </summary>
	[SerializableGameDataField]
	public int RemainingMonth;

	/// <summary>
	/// 以固定地点为目标
	/// </summary>
	/// <param name="targetLocation">目标地点</param>
	/// <param name="maxDuration">该目标最长持续时间</param>
	public NpcTravelTarget(Location targetLocation, int maxDuration)
	{
		_isTargetFixedLocation = true;
		_targetLocation = targetLocation;
		TargetCharId = -1;
		RemainingMonth = maxDuration;
	}

	/// <summary>
	/// 以指定角色为目标
	/// </summary>
	/// <param name="targetCharId">目标角色</param>
	/// <param name="maxDuration">该目标最长持续时间</param>
	public NpcTravelTarget(int targetCharId, int maxDuration)
	{
		_isTargetFixedLocation = false;
		_targetLocation = Location.Invalid;
		TargetCharId = targetCharId;
		RemainingMonth = maxDuration;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (_isTargetFixedLocation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TargetCharId;
		pCurrData += 4;
		pCurrData += _targetLocation.Serialize(pCurrData);
		*(int*)pCurrData = RemainingMonth;
		pCurrData += 4;
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
		_isTargetFixedLocation = *pCurrData != 0;
		pCurrData++;
		TargetCharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += _targetLocation.Deserialize(pCurrData);
		RemainingMonth = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool IsSameTargetWith(NpcTravelTarget other)
	{
		if (other._isTargetFixedLocation != _isTargetFixedLocation)
		{
			return false;
		}
		if (!_isTargetFixedLocation)
		{
			return other.TargetCharId == TargetCharId;
		}
		return other._targetLocation.Equals(_targetLocation);
	}

	public bool TryGetFixedLocation(out Location location)
	{
		location = _targetLocation;
		return _isTargetFixedLocation;
	}
}
