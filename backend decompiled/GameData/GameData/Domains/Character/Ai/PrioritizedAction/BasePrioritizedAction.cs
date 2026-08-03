using GameData.Common;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

[SerializableGameData(NotForDisplayModule = true)]
public abstract class BasePrioritizedAction : ISerializableGameData
{
	[SerializableGameDataField]
	public NpcTravelTarget Target;

	[SerializableGameDataField]
	public bool HasArrived = false;

	public abstract short ActionType { get; }

	public virtual bool CanJointActionWith(BasePrioritizedAction other)
	{
		return ActionType == other.ActionType && Target.IsSameTargetWith(other.Target);
	}

	public virtual bool CheckValid(Character selfChar)
	{
		return Target.RemainingMonth > 0;
	}

	public abstract void OnStart(DataContext context, Character selfChar);

	public abstract void OnInterrupt(DataContext context, Character selfChar);

	public virtual void OnArrival(DataContext context, Character selfChar)
	{
	}

	public virtual void OnTraveling(DataContext context, Character selfChar)
	{
	}

	public abstract bool Execute(DataContext context, Character selfChar);

	public virtual void OnCharacterDead(DataContext context, Character selfChar)
	{
	}

	public virtual bool IsSerializedSizeFixed()
	{
		return true;
	}

	public virtual int GetSerializedSize()
	{
		int totalSize = 17;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe virtual int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Target.Serialize(pCurrData);
		*pCurrData = (HasArrived ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe virtual int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Target.Deserialize(pCurrData);
		HasArrived = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
