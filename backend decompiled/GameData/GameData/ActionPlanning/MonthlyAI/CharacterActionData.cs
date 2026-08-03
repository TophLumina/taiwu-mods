using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class CharacterActionData : ISerializableGameData
{
	public enum EActionState : sbyte
	{
		Created,
		Started,
		Arrived,
		Finished
	}

	private static class FieldIds
	{
		public const ushort ActionTemplateId = 0;

		public const ushort CurrPhase = 1;

		public const ushort Succeed = 2;

		public const ushort TargetCharIds = 3;

		public const ushort TargetLocation = 4;

		public const ushort Implementation = 5;

		public const ushort State = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "ActionTemplateId", "CurrPhase", "Succeed", "TargetCharIds", "TargetLocation", "Implementation", "State" };
	}

	[SerializableGameDataField]
	public int ActionTemplateId;

	[SerializableGameDataField]
	public int CurrPhase;

	[SerializableGameDataField]
	public bool Succeed;

	[SerializableGameDataField]
	private int[] _targetCharIds;

	[SerializableGameDataField]
	public Location TargetLocation = Location.Invalid;

	[SerializableGameDataField(SerializationHandler = "this")]
	public ICharacterActionImpl Implementation;

	[SerializableGameDataField]
	private sbyte _state;

	public GameData.Domains.Character.Character Character;

	public int[] TargetCharIds
	{
		get
		{
			return _targetCharIds ?? Array.Empty<int>();
		}
		set
		{
			_targetCharIds = value ?? Array.Empty<int>();
		}
	}

	public int TargetCharId
	{
		get
		{
			int[] targetCharIds = _targetCharIds;
			return (targetCharIds != null && targetCharIds.Length == 1) ? _targetCharIds[0] : (-1);
		}
		set
		{
			int[] targetCharIds = _targetCharIds;
			if (targetCharIds != null && targetCharIds.Length == 1)
			{
				_targetCharIds[0] = value;
				return;
			}
			_targetCharIds = new int[1] { value };
		}
	}

	public bool TargetIsTaiwu
	{
		get
		{
			int[] targetCharIds = _targetCharIds;
			return targetCharIds != null && targetCharIds.Length == 1 && _targetCharIds[0] == DomainManager.Taiwu.GetTaiwuCharId();
		}
	}

	public bool TargetIsTaiwuGroupMember
	{
		get
		{
			int[] targetCharIds = _targetCharIds;
			return targetCharIds != null && targetCharIds.Length == 1 && DomainManager.Taiwu.IsInGroup(_targetCharIds[0]);
		}
	}

	public GameData.Domains.Character.Character TargetChar
	{
		get
		{
			int[] targetCharIds = _targetCharIds;
			GameData.Domains.Character.Character character;
			return (targetCharIds != null && targetCharIds.Length == 1 && DomainManager.Character.TryGetElement_Objects(_targetCharIds[0], out character)) ? character : null;
		}
	}

	public PlanningActionItem Template => PlanningAction.Instance[ActionTemplateId];

	public PlanningActionNode ActionNode => CharacterActionPlanner.Instance.GetActionNode(ActionTemplateId);

	public bool IsValid => CheckTargetsValid() && Implementation != null && Implementation.CheckValid(Character, this);

	public EActionState State
	{
		get
		{
			return (EActionState)_state;
		}
		set
		{
			_state = (sbyte)value;
		}
	}

	public bool HasStarted => State >= EActionState.Started;

	public bool HasArrived => State >= EActionState.Arrived;

	public bool InProgress
	{
		get
		{
			EActionState state = State;
			return state > EActionState.Created && state < EActionState.Finished;
		}
	}

	public CharacterActionData(GameData.Domains.Character.Character character, int actionTemplateId, ICharacterActionImpl implementation)
	{
		Character = character;
		ActionTemplateId = actionTemplateId;
		Implementation = implementation;
	}

	public IEnumerable<GameData.Domains.Character.Character> GetTargetCharacters()
	{
		int[] targetCharIds = _targetCharIds;
		if (targetCharIds == null || targetCharIds.Length <= 0)
		{
			yield break;
		}
		int[] targetCharIds2 = _targetCharIds;
		foreach (int targetCharId in targetCharIds2)
		{
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				yield return targetChar;
			}
			targetChar = null;
		}
	}

	public Location GetActualTargetLocation()
	{
		if (TargetLocation.IsValid())
		{
			return TargetLocation;
		}
		int[] targetCharIds = _targetCharIds;
		if (targetCharIds == null || targetCharIds.Length != 1)
		{
			return Character.GetValidLocation();
		}
		int targetCharId = _targetCharIds[0];
		if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
		{
			return targetChar.GetValidLocation();
		}
		if (DomainManager.Character.TryGetElement_Graves(targetCharId, out var grave))
		{
			return grave.GetLocation();
		}
		return Location.Invalid;
	}

	public bool CheckTargetsValid()
	{
		PlanningActionItem template = Template;
		switch (template.CharacterSelectCountType)
		{
		case EPlanningActionCharacterSelectCountType.RequiredSingle:
		case EPlanningActionCharacterSelectCountType.RequiredMultiple:
		{
			int[] targetCharIds = _targetCharIds;
			return targetCharIds != null && targetCharIds.Length > 0 && CheckAllTargetsValid();
		}
		case EPlanningActionCharacterSelectCountType.None:
		{
			int[] targetCharIds = _targetCharIds;
			return targetCharIds == null || targetCharIds.Length <= 0 || CheckAllTargetsValid();
		}
		default:
			return true;
		}
	}

	private bool CheckAllTargetsValid()
	{
		PlanningActionItem template = Template;
		int[] targetCharIds = _targetCharIds;
		foreach (int targetCharId in targetCharIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				return false;
			}
			if (template.TargetMatcher >= 0 && !CharacterMatcher.Instance[template.TargetMatcher].Match(targetChar))
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		return $"{PlanningAction.Instance.GetRefName(ActionTemplateId)}({ActionTemplateId})";
	}

	public CharacterActionData()
	{
	}

	private int GetSerializedSize(ICharacterActionImpl target)
	{
		return (4 + target?.GetSerializedSize()).GetValueOrDefault();
	}

	private unsafe int Serialize(byte* pData, ICharacterActionImpl target)
	{
		byte* pCurrData = pData;
		if (target != null)
		{
			byte* pFieldSize = pCurrData;
			pCurrData += 4;
			int fieldSize = target.Serialize(pCurrData);
			pCurrData += fieldSize;
			*(int*)pFieldSize = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	private unsafe int Deserialize(byte* pData, ref ICharacterActionImpl target)
	{
		byte* pCurrData = pData;
		uint fieldSize = *(uint*)pCurrData;
		pCurrData += 4;
		if (fieldSize != 0)
		{
			Tester.Assert(target == null);
			target = ActionNode.CreateImplementation();
			pCurrData += target.Deserialize(pCurrData);
		}
		else
		{
			target = null;
		}
		return (int)(pCurrData - pData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		totalSize = ((_targetCharIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _targetCharIds.Length)));
		totalSize += GetSerializedSize(Implementation);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		*(int*)pCurrData = ActionTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = CurrPhase;
		pCurrData += 4;
		*pCurrData = (Succeed ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (_targetCharIds != null)
		{
			int elementsCount = _targetCharIds.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _targetCharIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += TargetLocation.Serialize(pCurrData);
		pCurrData += Serialize(pCurrData, Implementation);
		*pCurrData = (byte)_state;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ActionTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			CurrPhase = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_targetCharIds == null || _targetCharIds.Length != elementsCount)
				{
					_targetCharIds = new int[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_targetCharIds[i] = ((int*)pCurrData)[i];
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_targetCharIds = null;
			}
		}
		if (fieldCount > 4)
		{
			pCurrData += TargetLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 5)
		{
			pCurrData += Deserialize(pCurrData, ref Implementation);
		}
		if (fieldCount > 6)
		{
			_state = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
