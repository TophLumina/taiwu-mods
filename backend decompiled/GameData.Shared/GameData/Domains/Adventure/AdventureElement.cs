using System;
using System.Collections.Generic;
using GameData.Adventure;
using GameData.Serializer;
using GameData.Utilities;
using Google.Protobuf.Collections;
using Redzen.Random;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇元素
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class AdventureElement : IAdventureParticipant, IAdventureParameterProvider, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort CoreId = 1;

		public const ushort InternalIndex = 2;

		public const ushort CharacterId = 3;

		public const ushort MovingIndex = 4;

		public const ushort MovingTimer = 5;

		public const ushort PatrolledIndexes = 6;

		public const ushort ParameterValues = 7;

		public const ushort VisibleIndex = 8;

		public const ushort ResetTarget = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "Id", "CoreId", "InternalIndex", "CharacterId", "MovingIndex", "MovingTimer", "PatrolledIndexes", "ParameterValues", "VisibleIndex", "ResetTarget" };
	}

	/// <summary>
	/// 因未配置可见条件而可见的索引
	/// </summary>
	public const int VisibleByDefaultIndex = int.MaxValue;

	/// <summary>
	/// 运行时 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int Id;

	/// <summary>
	/// 元素库 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int CoreId;

	/// <summary>
	/// 当前位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	private AdventureBlockIndex _internalIndex;

	/// <summary>
	/// 对应角色 ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public int CharacterId;

	/// <summary>
	/// 正在行动的规则序号
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	private int _movingIndex;

	/// <summary>
	/// 正在行动的规则计时器
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	private int _movingTimer;

	/// <summary>
	/// 已巡逻的地格
	/// </summary>
	[SerializableGameDataField(FieldIndex = 6)]
	private List<AdventureBlockIndex> _patrolledIndexes;

	/// <summary>
	/// 变量值
	/// </summary>
	[SerializableGameDataField(FieldIndex = 7)]
	private Dictionary<AdventureParameterKey, AdventureParameterValue> _parameterValues;

	/// <summary>
	/// 可见索引
	/// </summary>
	[SerializableGameDataField(FieldIndex = 8)]
	public int VisibleIndex;

	/// <summary>
	/// 初始生成位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 9)]
	private AdventureBlockIndex _resetTarget;

	/// <summary>
	/// 索引
	/// </summary>
	public AdventureBlockIndex Index => _internalIndex;

	/// <summary>
	/// 复位目标
	/// </summary>
	public AdventureBlockIndex ResetTarget => _resetTarget;

	/// <summary>
	/// 是否可见
	/// </summary>
	public bool Visible => VisibleIndex >= 0;

	/// <summary>
	/// 是否因未配置可见条件而可见
	/// </summary>
	public bool VisibleByDefault => VisibleIndex == int.MaxValue;

	/// <inheritdoc />
	IReadOnlyList<AdventureParameterData> IAdventureParameterProvider.Parameters => Core.Parameters;

	/// <summary>
	/// 核心数据
	/// </summary>
	public AdventureElementData Core => ExternalDataBridge.Context.AdventureCore.GetAdventureElementData(CoreId);

	/// <summary>
	/// 基于数据构造奇遇元素
	/// </summary>
	public AdventureElement(int id, int coreId, AdventureBlockIndex index)
	{
		Id = id;
		CoreId = coreId;
		SetIndex(index);
		CharacterId = -1;
		_resetTarget = index;
		_parameterValues = new Dictionary<AdventureParameterKey, AdventureParameterValue>();
		this.InitializeParameters();
	}

	/// <summary>
	/// 设置索引
	/// </summary>
	public void SetIndex(AdventureBlockIndex index)
	{
		_internalIndex = index;
	}

	/// <summary>
	/// 绑定角色
	/// </summary>
	internal void BindCharacter(int charId)
	{
		CharacterId = charId;
	}

	/// <inheritdoc />
	public AdventureParameterValue? GetParameterOrNull(AdventureParameterKey key)
	{
		return _parameterValues?.GetOrNull(key);
	}

	/// <inheritdoc />
	public void SetParameter(AdventureParameterKey key, AdventureParameterValue value)
	{
		if (_parameterValues == null)
		{
			_parameterValues = new Dictionary<AdventureParameterKey, AdventureParameterValue>();
		}
		_parameterValues[key] = value;
	}

	/// <inheritdoc />
	public void RemoveParameter(AdventureParameterKey key)
	{
		_parameterValues?.Remove(key);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"{Core.Name}({Id})";
	}

	/// <summary>
	/// 更新状态信息
	/// </summary>
	/// <param name="bridge"></param>
	/// <param name="adventureId"></param>
	/// <returns></returns>
	public bool UpdateStatus(IAdventureDomainBridge bridge, int adventureId)
	{
		int visibleIndex = -1;
		RepeatedField<AdventureElementVisibleData> conditions = Core.VisibleCondition;
		if (conditions == null || conditions.Count <= 0)
		{
			visibleIndex = int.MaxValue;
		}
		else
		{
			for (int i = 0; i < conditions.Count; i++)
			{
				AdventureElementVisibleData data = conditions[i];
				if (bridge.Check(data.VisibleCondition, adventureId, Id))
				{
					visibleIndex = i;
					break;
				}
			}
		}
		if (VisibleIndex == visibleIndex)
		{
			return false;
		}
		VisibleIndex = visibleIndex;
		return true;
	}

	/// <summary>
	/// 尝试获取跟随目标
	/// </summary>
	public AdventureBlockIndex? GetFollowTarget(AdventureRuntime adventure)
	{
		if (this.TryGetParameter("ConchShipPresetKey_FollowTargetElementId", out var elementId))
		{
			AdventureElement element = adventure.GetElement(elementId.Current);
			if (element != null)
			{
				return element.Index;
			}
		}
		if (this.TryGetParameter("ConchShipPresetKey_FollowTargetBlockIndex", out var index))
		{
			return index.AsIndex;
		}
		return null;
	}

	/// <summary>
	/// 更新移动状态
	/// </summary>
	/// <param name="bridge"></param>
	/// <param name="random"></param>
	/// <param name="adventure">所属奇遇</param>
	/// <param name="costedTime">太吾已消耗的精力</param>
	/// <returns>移动次数，负数表示未产生数据变化</returns>
	public int UpdateMove(IAdventureDomainBridge bridge, IRandomSource random, AdventureRuntime adventure, int costedTime)
	{
		int moveTimes = -1;
		if (costedTime <= 0)
		{
			return moveTimes;
		}
		if (adventure.GetElement(Id) == null)
		{
			return moveTimes;
		}
		for (int i = 0; i < Core.MoveData.Count; i++)
		{
			AdventureElementMoveData moveData = Core.MoveData[i];
			if (bridge.Check(moveData.MoveCondition, adventure.Id, Id))
			{
				if (_movingIndex != i)
				{
					_movingTimer = 0;
				}
				_movingIndex = i;
				_movingTimer += costedTime;
				int speed = Math.Max(moveData.MoveSpeed, 1);
				moveTimes = _movingTimer / speed;
				_movingTimer %= speed;
				if (moveTimes > 0)
				{
					DoMove(bridge, random, adventure, moveData, moveTimes);
				}
				break;
			}
		}
		return moveTimes;
	}

	/// <summary>
	/// 根据指定移动规则执行一次移动
	/// </summary>
	/// <param name="bridge"></param>
	/// <param name="random"></param>
	/// <param name="adventure"></param>
	/// <param name="data">移动数据</param>
	/// <param name="moveTimes">移动次数</param>
	private void DoMove(IAdventureDomainBridge bridge, IRandomSource random, AdventureRuntime adventure, AdventureElementMoveData data, int moveTimes)
	{
		AdventureTaiwu runtime = bridge.GetAdventureTaiwu();
		if (runtime.AdventureId != adventure.Id)
		{
			AdaptableLog.Warning($"Adventure element cannot move without taiwu {adventure.Id} - {Id}");
			return;
		}
		EAdventureElementMoveType type = data.MoveType;
		switch (type)
		{
		case EAdventureElementMoveType.Static:
			return;
		case EAdventureElementMoveType.RandomMove:
			DoMoveRandom(random, adventure, moveTimes);
			return;
		}
		if (AdventurePatrolHelper.TargetCheckers.TryGetValue(type, out var checker))
		{
			DoMovePatrol(random, adventure, moveTimes, data, checker);
			return;
		}
		bool flag;
		switch (type)
		{
		case EAdventureElementMoveType.Reset:
			DoMoveAStar(adventure, _resetTarget, moveTimes);
			return;
		case EAdventureElementMoveType.Follow:
			DoMoveAStar(adventure, GetFollowTarget(adventure) ?? Index, moveTimes);
			return;
		case EAdventureElementMoveType.CloserToPlayer:
		case EAdventureElementMoveType.AwayFromPlayer:
		case EAdventureElementMoveType.CloserToElement:
		case EAdventureElementMoveType.AwayFromElement:
		case EAdventureElementMoveType.CloserToTag:
		case EAdventureElementMoveType.AwayFromTag:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		if (!flag)
		{
			return;
		}
		flag = ((type == EAdventureElementMoveType.CloserToPlayer || type == EAdventureElementMoveType.CloserToElement || type == EAdventureElementMoveType.CloserToTag) ? true : false);
		bool closer = flag;
		List<IAdventureParticipant> participants = ObjectPool<List<IAdventureParticipant>>.Instance.Get();
		if ((uint)(type - 2) <= 1u)
		{
			participants.Add(runtime);
		}
		else if ((uint)(type - 8) <= 1u)
		{
			participants.AddRange(adventure.GetElementByAllTags(data.TargetTags));
		}
		else
		{
			participants.AddRange(adventure.GetElementsByCoreId(data.TargetElementId));
		}
		if (participants.Count > 0)
		{
			if (closer)
			{
				DoMoveCloser(random, adventure, moveTimes, participants);
			}
			else
			{
				DoMoveAway(random, adventure, moveTimes, participants);
			}
		}
		ObjectPool<List<IAdventureParticipant>>.Instance.Return(participants);
	}

	/// <summary>
	/// 随机移动若干次
	/// </summary>
	/// <param name="random"></param>
	/// <param name="adventure"></param>
	/// <param name="moveTimes"></param>
	private void DoMoveRandom(IRandomSource random, AdventureRuntime adventure, int moveTimes)
	{
		List<AdventureBlockIndex> pool = ObjectPool<List<AdventureBlockIndex>>.Instance.Get();
		AdventureBlockIndex newIndex = Index;
		for (int i = 0; i < moveTimes; i++)
		{
			pool.Clear();
			foreach (EAdventureDirection direction in AdventureBlockIndex.Directions)
			{
				if (adventure.IsPassable(newIndex.Move(direction)))
				{
					pool.Add(newIndex.Move(direction));
				}
			}
			if (pool.Count <= 0)
			{
				break;
			}
			newIndex = pool.GetRandom(random);
		}
		SetIndex(newIndex);
		ObjectPool<List<AdventureBlockIndex>>.Instance.Return(pool);
	}

	/// <summary>
	/// 巡逻移动若干次
	/// </summary>
	/// <param name="random"></param>
	/// <param name="adventure"></param>
	/// <param name="moveTimes"></param>
	/// <param name="data"></param>
	/// <param name="checker"></param>
	private void DoMovePatrol(IRandomSource random, AdventureRuntime adventure, int moveTimes, AdventureElementMoveData data, AdventurePatrolTargetChecker checker)
	{
		if (_patrolledIndexes == null)
		{
			_patrolledIndexes = new List<AdventureBlockIndex>();
		}
		List<AdventureBlockIndex> pool = ObjectPool<List<AdventureBlockIndex>>.Instance.Get();
		AdventureBlockIndex newIndex = Index;
		for (int i = 0; i < moveTimes; i++)
		{
			pool.Clear();
			bool anyUnpatrolled = false;
			foreach (EAdventureDirection direction in AdventureBlockIndex.Directions)
			{
				AdventureBlockIndex movedIndex = newIndex.Move(direction);
				if (!adventure.IsPassable(movedIndex) || !checker(data, adventure, newIndex, movedIndex))
				{
					continue;
				}
				bool patrolled = _patrolledIndexes.Contains(movedIndex);
				if (!(patrolled && anyUnpatrolled))
				{
					if (!patrolled && !anyUnpatrolled)
					{
						anyUnpatrolled = true;
						pool.Clear();
					}
					pool.Add(movedIndex);
				}
			}
			if (!anyUnpatrolled)
			{
				_patrolledIndexes.Clear();
			}
			if (pool.Count <= 0)
			{
				break;
			}
			newIndex = pool.GetRandom(random);
			_patrolledIndexes.Add(newIndex);
		}
		if (newIndex != Index)
		{
			SetIndex(newIndex);
		}
		ObjectPool<List<AdventureBlockIndex>>.Instance.Return(pool);
	}

	/// <summary>
	/// 通过寻路向目标移动若干次
	/// </summary>
	private bool DoMoveAStar(AdventureRuntime adventure, AdventureBlockIndex target, int moveTimes)
	{
		if (target == Index)
		{
			return false;
		}
		IReadOnlyList<AdventureBlockIndex> path = adventure.FindShortestPath(Index, target);
		if (path == null || path.Count <= 0)
		{
			return false;
		}
		moveTimes = Math.Min(moveTimes, path.Count - 1);
		AdventureBlockIndex finalIndex = path[moveTimes];
		SetIndex(finalIndex);
		return true;
	}

	/// <summary>
	/// 向指定参与者靠近若干次
	/// </summary>
	/// <param name="random"></param>
	/// <param name="adventure"></param>
	/// <param name="moveTimes"></param>
	/// <param name="participants"></param>
	private void DoMoveCloser(IRandomSource random, AdventureRuntime adventure, int moveTimes, IReadOnlyList<IAdventureParticipant> participants)
	{
		List<AdventureBlockIndex> pool = ObjectPool<List<AdventureBlockIndex>>.Instance.Get();
		int minDistance = int.MaxValue;
		AdventureBlockIndex newIndex = Index;
		foreach (IAdventureParticipant participant in participants)
		{
			AdventureBlockIndex participantIndex = participant.Index;
			int distance = newIndex.GetManhattanDistance(participantIndex);
			if (distance == 0)
			{
				pool.Clear();
				break;
			}
			if (distance < minDistance)
			{
				minDistance = distance;
			}
			if (distance == minDistance)
			{
				pool.Add(participantIndex);
			}
		}
		while (pool.Count > 0)
		{
			int targetIndex = random.Next(pool.Count);
			AdventureBlockIndex target = pool[targetIndex];
			if (DoMoveAStar(adventure, target, moveTimes))
			{
				break;
			}
			CollectionUtils.SwapAndRemove(pool, targetIndex);
		}
		ObjectPool<List<AdventureBlockIndex>>.Instance.Return(pool);
	}

	/// <summary>
	/// 向指定参与者远离若干次
	/// </summary>
	/// <param name="random"></param>
	/// <param name="adventure"></param>
	/// <param name="moveTimes"></param>
	/// <param name="participants"></param>
	private void DoMoveAway(IRandomSource random, AdventureRuntime adventure, int moveTimes, IReadOnlyList<IAdventureParticipant> participants)
	{
		List<AdventureBlockIndex> pool = ObjectPool<List<AdventureBlockIndex>>.Instance.Get();
		AdventureBlockIndex newIndex = Index;
		for (int i = 0; i < moveTimes; i++)
		{
			int minDistance = 0;
			foreach (IAdventureParticipant participant in participants)
			{
				minDistance += newIndex.GetManhattanDistance(participant.Index);
			}
			pool.Clear();
			foreach (EAdventureDirection direction in AdventureBlockIndex.Directions)
			{
				AdventureBlockIndex movedIndex = newIndex.Move(direction);
				if (!adventure.IsPassable(movedIndex))
				{
					continue;
				}
				int calculatingDistance = 0;
				foreach (IAdventureParticipant participant2 in participants)
				{
					calculatingDistance += movedIndex.GetManhattanDistance(participant2.Index);
				}
				if (calculatingDistance >= minDistance)
				{
					if (calculatingDistance > minDistance)
					{
						pool.Clear();
					}
					minDistance = calculatingDistance;
					pool.Add(movedIndex);
				}
			}
			if (pool.Count <= 0)
			{
				break;
			}
			newIndex = pool.GetRandom(random);
		}
		if (newIndex != Index)
		{
			SetIndex(newIndex);
		}
		ObjectPool<List<AdventureBlockIndex>>.Instance.Return(pool);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureElement()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureElement(AdventureElement other)
	{
		Id = other.Id;
		CoreId = other.CoreId;
		_internalIndex = other._internalIndex;
		CharacterId = other.CharacterId;
		_movingIndex = other._movingIndex;
		_movingTimer = other._movingTimer;
		_patrolledIndexes = ((other._patrolledIndexes == null) ? null : new List<AdventureBlockIndex>(other._patrolledIndexes));
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
		VisibleIndex = other.VisibleIndex;
		_resetTarget = other._resetTarget;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureElement other)
	{
		Id = other.Id;
		CoreId = other.CoreId;
		_internalIndex = other._internalIndex;
		CharacterId = other.CharacterId;
		_movingIndex = other._movingIndex;
		_movingTimer = other._movingTimer;
		_patrolledIndexes = ((other._patrolledIndexes == null) ? null : new List<AdventureBlockIndex>(other._patrolledIndexes));
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
		VisibleIndex = other.VisibleIndex;
		_resetTarget = other._resetTarget;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 26;
		totalSize += ((AdventureBlockIndexForSerialize)_internalIndex).GetSerializedSize();
		if (_patrolledIndexes != null)
		{
			totalSize += 2;
			int elementsCount = _patrolledIndexes.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += ((AdventureBlockIndexForSerialize)_patrolledIndexes[i]).GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(_parameterValues);
		totalSize += ((AdventureBlockIndexForSerialize)_resetTarget).GetSerializedSize();
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
		*(int*)pCurrData = CoreId;
		pCurrData += 4;
		int fieldSize = ((AdventureBlockIndexForSerialize)_internalIndex).Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(int*)pCurrData = _movingIndex;
		pCurrData += 4;
		*(int*)pCurrData = _movingTimer;
		pCurrData += 4;
		if (_patrolledIndexes != null)
		{
			int elementsCount = _patrolledIndexes.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = ((AdventureBlockIndexForSerialize)_patrolledIndexes[i]).Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref _parameterValues);
		*(int*)pCurrData = VisibleIndex;
		pCurrData += 4;
		int fieldSize2 = ((AdventureBlockIndexForSerialize)_resetTarget).Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
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
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			CoreId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			AdventureBlockIndexForSerialize field = _internalIndex;
			pCurrData += field.Deserialize(pCurrData);
			_internalIndex = field;
		}
		if (fieldCount > 3)
		{
			CharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			_movingIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			_movingTimer = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_patrolledIndexes == null)
				{
					_patrolledIndexes = new List<AdventureBlockIndex>(elementsCount);
				}
				else
				{
					_patrolledIndexes.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					AdventureBlockIndexForSerialize element = default(AdventureBlockIndexForSerialize);
					pCurrData += element.Deserialize(pCurrData);
					_patrolledIndexes.Add(element);
				}
			}
			else
			{
				_patrolledIndexes?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref _parameterValues);
		}
		if (fieldCount > 8)
		{
			VisibleIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			AdventureBlockIndexForSerialize field2 = _resetTarget;
			pCurrData += field2.Deserialize(pCurrData);
			_resetTarget = field2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
