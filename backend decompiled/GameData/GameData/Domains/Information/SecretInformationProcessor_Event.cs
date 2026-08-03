using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.EventConfig;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.Information.Secret;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.TaiwuEvent.EventOption;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Information;

public sealed class SecretInformationProcessor_Event
{
	private class CombatData
	{
		public sbyte CombatType;

		public bool NoGuard;

		public List<short> CombatResult;

		public short CantFightResult;

		public short CombatConfigId => GetCombatConfigId();

		public CombatData(sbyte combatType, bool noGuard, List<short> combatResult, short cantFightResult = -1)
		{
			CombatType = combatType;
			NoGuard = noGuard;
			CombatResult = combatResult;
			CantFightResult = cantFightResult;
		}

		public CombatData(SecretInformationAppliedResultItem combatConfig, bool hasGuard)
		{
			CombatType = CombatConfig.Instance.GetItem(combatConfig.CombatConfigId).CombatType;
			NoGuard = combatConfig.NoGuard || !NoGuard;
			CombatResult = GetDataListFromConditionResult(combatConfig.SpecialConditionResultIds, 0);
			CantFightResult = GetDataFromConditionResult(combatConfig.SpecialConditionResultIds, 1, 0);
		}

		private short GetCombatConfigId()
		{
			return CombatType switch
			{
				2 => (short)(NoGuard ? 2 : 122), 
				1 => (short)(NoGuard ? 1 : 121), 
				_ => -1, 
			};
		}
	}

	private class ActionData
	{
		public sbyte ActionKey;

		public sbyte Phase;

		public List<short> CombatResult;

		public int SaviorId;

		public int KidnaperId;

		public int PrisonerId;

		public ActionData(sbyte actionKey, sbyte phase, List<short> combatResult, int savorId, int kidnaperId, int prisonerId)
		{
			ActionKey = actionKey;
			Phase = phase;
			CombatResult = combatResult;
			SaviorId = savorId;
			KidnaperId = kidnaperId;
			PrisonerId = prisonerId;
		}
	}

	private class RelationChangeData
	{
		public int SelfCharId;

		public int TargetCharId;

		public ushort RelationType;

		public bool IsServe;

		public bool IsSuccess;

		public RelationChangeData(int selfCharId, int targetCharId, ushort relationType, bool isServe, bool isSuccess)
		{
			SelfCharId = selfCharId;
			TargetCharId = targetCharId;
			RelationType = relationType;
			IsServe = isServe;
			IsSuccess = isSuccess;
		}
	}

	public enum EventAction
	{
		ShowEvent,
		EndEvent,
		StartCombat,
		StartLifeSkillCombat,
		ChooseRope,
		ShowFristContent,
		JumpToOtherEvent
	}

	public static class EventArgKeys_Infomation
	{
		public const string CombatResult = "CombatResult";

		public const string LifeSikllCombatResult = "WinState";

		public const string ResultEventGuid = "resultEventGuid";

		public const string ResultEventGuid_Part2 = "conditionEventGuid";

		public const string BreakCharacterId = "breakTargetCharacterId";

		public const string ActorId = "actorId";

		public const string ReactorId = "reactorId";

		public const string SecactorId = "secactorId";
	}

	private static class LoveRelationValue
	{
		public static int[] MakeEnemyWhenDivorce = new int[5] { 20, 10, 30, 50, 40 };

		public static int[] MakeEnemyWhenNotAdore = new int[5] { 0, 0, 10, 30, 20 };

		public static int[] FavorOfDivorce = new int[5] { -3, -5, -4, -5, -3 };

		public static int[] FavorOfBreakUp = new int[5] { 0, -2, -1, -2, 0 };

		public static int[] FavorOfNotAdore = new int[5] { 1, 0, -1, 0, 1 };

		public const int Adore = 0;

		public const int Lover = 1;

		public const int Spouse = 2;

		public const int BaseFavorChangeOfForgive = -3000;

		public const int BaseHappinessChangeOfForgive = -5;

		public const int BasseFavorChangeOfAskBreak = -3000;

		public const int FavorMultipleChangeOfAskBreak = -1500;

		public const int FavorChangeOfRefuseBreak = -6000;
	}

	public static readonly SecretInformationProcessor_Event Instance = new SecretInformationProcessor_Event();

	private SecretInformationProcessor _processor = new SecretInformationProcessor();

	private short ResultIndex = -1;

	private short LastResultIndex = -1;

	private SecretInformationAppliedResultItem _resultConfig;

	private GameData.Domains.Character.Character _taiwu;

	private int _taiwuId;

	private GameData.Domains.Character.Character _character;

	private int _characterId;

	private List<int> _argList = new List<int>();

	private HashSet<(int killerId, int victimId, bool isPublic)> _toKillCharIdTupleHashSet = new HashSet<(int, int, bool)>();

	private HashSet<int> _toEscapeCharIdList = new HashSet<int>();

	private HashSet<(int charId, SecretInformationId SecretId)> _toDiscardCharIdList = new HashSet<(int, SecretInformationId)>();

	private Dictionary<int, int> _toChangeInfectionCharIdList = new Dictionary<int, int>();

	private Dictionary<int, int> _toChangeHappinessCharIdList = new Dictionary<int, int>();

	private Dictionary<int, Dictionary<int, int>> _toChangeCharacterFavorList = new Dictionary<int, Dictionary<int, int>>();

	private CombatData _savedCombatData = null;

	private ActionData _savedActionData = null;

	private RelationChangeData _savedRelationChangeData = null;

	private short _secretInformationContentId = -1;

	private short _secretInformationStructId = -1;

	private static readonly List<int> AskCharReleaseFavorLimits = new List<int> { 5, 4, 4, 5, 6 };

	private static readonly List<int> AskCharKeepFavorLimits = new List<int> { 6, 5, 4, 5, 6 };

	private short _secretInformationContentIndex = -1;

	private List<short> _savedContentSelections = new List<short>();

	private string _savedContentText = string.Empty;

	private EventAction _eventAction = EventAction.ShowEvent;

	private SecretInformationId _secretInformationId;

	private SecretInformationProcessor_Event()
	{
	}

	public bool Initialize(GameData.Domains.Character.Character character, GameData.Domains.Character.Character taiwu, int secretId, EventArgBox argBox)
	{
		Reset();
		if (taiwu == null || character == null)
		{
			return false;
		}
		GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation(_secretInformationId = (SecretInformationId)secretId);
		SecretOccurence occurence;
		byte[] secretParams = secret.QueryParameters(out occurence);
		if (!_processor.Initialize(occurence, secretParams))
		{
			return false;
		}
		_taiwu = taiwu;
		_character = character;
		_taiwuId = taiwu.GetId();
		_characterId = character.GetId();
		_argList = new List<int>(_processor.GetSecretInformationArgList())
		{
			[3] = character.GetId(),
			[5] = taiwu.GetId()
		};
		ResultIndex = -1;
		LastResultIndex = -1;
		List<string> keys = new List<string> { "actorId", "reactorId", "secactorId" };
		for (int i = 0; i < 3; i++)
		{
			argBox.Set(keys[i], _argList[i]);
		}
		return true;
	}

	public void Reset()
	{
		ResultIndex = -1;
		LastResultIndex = -1;
		_resultConfig = null;
		_argList.Clear();
		_taiwu = null;
		_character = null;
		_taiwuId = -1;
		_characterId = -1;
		_toKillCharIdTupleHashSet.Clear();
		_toEscapeCharIdList.Clear();
		_toDiscardCharIdList.Clear();
		_toChangeHappinessCharIdList.Clear();
		_toChangeInfectionCharIdList.Clear();
		_toChangeCharacterFavorList.Clear();
		_savedCombatData = null;
		_savedActionData = null;
		_savedRelationChangeData = null;
		_savedContentSelections.Clear();
		_secretInformationContentId = -1;
		_secretInformationStructId = -1;
		_secretInformationContentIndex = -1;
		_eventAction = EventAction.ShowEvent;
		_secretInformationId = SecretInformationId.Invalid;
		_processor.Reset();
	}

	public bool SetEventGuid(string part1, string part2, EventArgBox argbox)
	{
		if (DomainManager.TaiwuEvent.GetEvent(part1) == null || DomainManager.TaiwuEvent.GetEvent(part2) == null)
		{
			return false;
		}
		argbox.Set("resultEventGuid", part1);
		argbox.Set("conditionEventGuid", part2);
		return true;
	}

	public string GetEventGuid(EventArgBox argbox, bool isPart2 = false)
	{
		string key = (isPart2 ? "conditionEventGuid" : "resultEventGuid");
		string guid = string.Empty;
		argbox.Get(key, ref guid);
		return guid;
	}

	public void SetResultIndex(short resultId)
	{
		ResultIndex = resultId;
		LastResultIndex = -1;
	}

	public List<short> GetEventShowData_SelectionKey()
	{
		SecretInformationAppliedResultItem resultConfig = SecretInformationAppliedResult.Instance.GetItem(LastResultIndex);
		if (resultConfig == null || resultConfig.SelectionIds == null)
		{
			return new List<short>();
		}
		return _processor.GetVisibleSelection(resultConfig.SelectionIds, _character, _taiwu);
	}

	public TaiwuEventOption[] GetEventShowData_Selection(EventArgBox argBox, GameData.Domains.TaiwuEvent.TaiwuEvent eventData)
	{
		List<short> selectionKeys = GetEventShowData_SelectionKey();
		TaiwuEventOption[] result = MakeSecretInformationSelections(selectionKeys, argBox, eventData);
		bool addOtherOption = true;
		TaiwuEventOption[] array = result;
		foreach (TaiwuEventOption item in array)
		{
			if (CheckInformationSelectionAvailable(item))
			{
				addOtherOption = false;
				break;
			}
		}
		if (addOtherOption)
		{
			selectionKeys.Add(0);
			result = MakeSecretInformationSelections(selectionKeys, argBox, eventData);
		}
		return result;
	}

	public string GetEventShowData_Content()
	{
		SecretInformationAppliedResultItem resultConfig = SecretInformationAppliedResult.Instance.GetItem(LastResultIndex);
		if (resultConfig == null)
		{
			return $"null Config：{LastResultIndex}";
		}
		if (resultConfig.Texts == null)
		{
			return $"null Texts：{LastResultIndex}";
		}
		return string.IsNullOrEmpty(resultConfig.Texts[1]) ? resultConfig.Texts[0] : resultConfig.Texts[_character.GetBehaviorType()];
	}

	public bool GetEventShowData_RevealCharacters()
	{
		SecretInformationAppliedResultItem resultConfig = SecretInformationAppliedResult.Instance.GetItem(LastResultIndex);
		if (resultConfig == null || resultConfig.SelectionIds == null)
		{
			return false;
		}
		return resultConfig.RevealCharacters && _taiwu != null && _character != null;
	}

	public int GetEventAction(EventArgBox argBox, out string eventGuid)
	{
		eventGuid = string.Empty;
		if (ResultIndex == -1)
		{
			ApplyEventEnd(argBox);
			return 1;
		}
		while (ResultIndex != -1)
		{
			LastResultIndex = ResultIndex;
			if (!RefreshResultIndex())
			{
				ApplyEventEnd(argBox);
				return 1;
			}
			if (TryGetOutsideJumpEventGuid(argBox, out eventGuid))
			{
				if (_resultConfig.EndEventAfterJump)
				{
					ApplyEventEnd(argBox);
				}
				return 6;
			}
			SaveResultCharacterStateChanges();
			SecretInformationMaker_Entrance(argBox);
			ResultIndex = ApplyEventCondition(argBox);
		}
		switch (_eventAction)
		{
		case EventAction.ChooseRope:
			eventGuid = GetEventGuid(argBox, isPart2: true);
			return 6;
		case EventAction.StartCombat:
			if (_savedCombatData != null)
			{
				EventHelper.StartCombat(_characterId, _savedCombatData.CombatConfigId, GetEventGuid(argBox, isPart2: true), argBox, _savedCombatData.NoGuard);
				break;
			}
			ApplyEventEnd(argBox);
			return 1;
		case EventAction.StartLifeSkillCombat:
			EventHelper.StartLifeSkillCombat(_characterId, 16, GetEventGuid(argBox, isPart2: true), argBox);
			break;
		case EventAction.ShowEvent:
			if (LastResultIndex == -1 || GetEventShowData_SelectionKey().Count == 0)
			{
				ApplyEventEnd(argBox);
				return 1;
			}
			break;
		}
		return (int)_eventAction;
	}

	public void ApplyEventEnd(EventArgBox argBox)
	{
		foreach (KeyValuePair<int, Dictionary<int, int>> item in _toChangeCharacterFavorList)
		{
			foreach (KeyValuePair<int, int> item2 in item.Value)
			{
				ChangeFavorability(item.Key, item2.Key, item2.Value);
			}
		}
		foreach (KeyValuePair<int, int> item3 in _toChangeHappinessCharIdList)
		{
			if (InformationDomain.CheckTuringTest(item3.Key, out var character))
			{
				EventHelper.ChangeRoleHappiness(character, item3.Value);
			}
		}
		foreach (KeyValuePair<int, int> item4 in _toChangeInfectionCharIdList)
		{
			if (InformationDomain.CheckTuringTest(item4.Key, out var character2))
			{
				EventHelper.ChangeRoleInfectedValue(character2, item4.Value);
			}
		}
		EventHelper.DisseminateSecretInformationFromTaiwu((int)_secretInformationId, _characterId);
		foreach (var item5 in _toDiscardCharIdList)
		{
			DomainManager.Information.DiscardSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, item5.charId, item5.SecretId);
		}
		bool taiwuDie = false;
		foreach (var valueTuple in _toKillCharIdTupleHashSet)
		{
			GameData.Domains.Character.Character character3;
			if (valueTuple.victimId == _taiwuId)
			{
				taiwuDie = true;
			}
			else if (DomainManager.Character.TryGetElement_Objects(valueTuple.victimId, out character3))
			{
				short deathType = (short)(valueTuple.isPublic ? 4 : 3);
				DomainManager.Character.MakeCharacterDead(DomainManager.TaiwuEvent.MainThreadDataContext, character3, deathType);
			}
		}
		HashSet<int> victimHashSet = new HashSet<int>(_toKillCharIdTupleHashSet.Select(((int killerId, int victimId, bool isPublic) tuple) => tuple.victimId));
		foreach (int item6 in _toEscapeCharIdList)
		{
			if (!victimHashSet.Contains(item6) && DomainManager.Character.TryGetElement_Objects(item6, out var character4))
			{
				EventHelper.CharacterEscapeToNearbyBlock(argBox, character4, 1);
			}
		}
		if (taiwuDie)
		{
			EventHelper.TriggerLegacyPassingEvent(isTaiwuDying: true);
		}
		Reset();
	}

	private bool RefreshResultIndex()
	{
		_eventAction = EventAction.ShowEvent;
		_resultConfig = SecretInformationAppliedResult.Instance.GetItem(ResultIndex);
		if (_resultConfig == null)
		{
			return false;
		}
		short curResult = ResultIndex;
		while (true)
		{
			short curResult2 = SecretInformationAppliedResult.Instance.GetItem(curResult).InnerResultEvent;
			if (curResult2 != -1)
			{
				curResult = curResult2;
				continue;
			}
			break;
		}
		if (curResult != ResultIndex)
		{
			ResultIndex = curResult;
		}
		_resultConfig = SecretInformationAppliedResult.Instance.GetItem(ResultIndex);
		if (_resultConfig == null)
		{
			return false;
		}
		return true;
	}

	private bool TryGetOutsideJumpEventGuid(EventArgBox argBox, out string eventGuid)
	{
		eventGuid = _resultConfig.ResultEventGuid;
		if (!string.IsNullOrEmpty(_resultConfig.ResultEventGuidKey))
		{
			string headEvent = argBox.GetString(_resultConfig.ResultEventGuidKey);
			if (!string.IsNullOrEmpty(headEvent))
			{
				eventGuid = headEvent;
			}
		}
		if (string.IsNullOrEmpty(eventGuid))
		{
			return false;
		}
		if (DomainManager.TaiwuEvent.GetEvent(eventGuid) == null)
		{
			return false;
		}
		return true;
	}

	private void SaveResultCharacterStateChanges()
	{
		if (_resultConfig.SelfHappinessDiff != 0)
		{
			if (!_toChangeHappinessCharIdList.ContainsKey(_taiwuId))
			{
				_toChangeHappinessCharIdList.Add(_taiwuId, 0);
			}
			_toChangeHappinessCharIdList[_taiwuId] += _resultConfig.SelfHappinessDiff;
		}
		if (_resultConfig.SelfInfectionDiff != 0)
		{
			if (!_toChangeInfectionCharIdList.ContainsKey(_taiwuId))
			{
				_toChangeInfectionCharIdList.Add(_taiwuId, 0);
			}
			_toChangeInfectionCharIdList[_taiwuId] += _resultConfig.SelfInfectionDiff;
		}
		if (_resultConfig.OppositeHappinessDiff != 0)
		{
			if (!_toChangeHappinessCharIdList.ContainsKey(_characterId))
			{
				_toChangeHappinessCharIdList.Add(_characterId, 0);
			}
			_toChangeHappinessCharIdList[_characterId] += _resultConfig.OppositeHappinessDiff;
		}
		if (_resultConfig.OppositeInfectionDiff != 0)
		{
			if (!_toChangeInfectionCharIdList.ContainsKey(_characterId))
			{
				_toChangeInfectionCharIdList.Add(_characterId, 0);
			}
			_toChangeInfectionCharIdList[_characterId] += _resultConfig.OppositeInfectionDiff;
		}
		if (_resultConfig.SelfFavorabilityDiff != 0)
		{
			if (!_toChangeCharacterFavorList.ContainsKey(_taiwuId))
			{
				_toChangeCharacterFavorList.Add(_taiwuId, new Dictionary<int, int>());
			}
			if (!_toChangeCharacterFavorList[_taiwuId].ContainsKey(_characterId))
			{
				_toChangeCharacterFavorList[_taiwuId].Add(_characterId, 0);
			}
			_toChangeCharacterFavorList[_taiwuId][_characterId] += _resultConfig.SelfFavorabilityDiff;
		}
		if (_resultConfig.OppositeFavorabilityDiff != 0)
		{
			if (!_toChangeCharacterFavorList.ContainsKey(_characterId))
			{
				_toChangeCharacterFavorList.Add(_characterId, new Dictionary<int, int>());
			}
			if (!_toChangeCharacterFavorList[_characterId].ContainsKey(_taiwuId))
			{
				_toChangeCharacterFavorList[_characterId].Add(_taiwuId, 0);
			}
			_toChangeCharacterFavorList[_characterId][_taiwuId] += _resultConfig.OppositeFavorabilityDiff;
		}
	}

	public bool GetSecretInformationEventShowData(EventArgBox argBox, GameData.Domains.TaiwuEvent.TaiwuEvent eventData, out TaiwuEventOption[] options)
	{
		options = null;
		IRandomSource radom = DomainManager.TaiwuEvent.MainThreadDataContext.Random;
		short structId = _processor.GetSecretInformationAppliedStructs(radom, _character, _taiwu);
		if (structId == -1)
		{
			return false;
		}
		_secretInformationStructId = structId;
		List<short> selectionKeys;
		short contentIndex;
		short contentId = _processor.GetContentIdAndSelections(radom, structId, _character, _taiwu, out selectionKeys, out contentIndex);
		if (contentId == -1)
		{
			return false;
		}
		_secretInformationContentId = contentId;
		_secretInformationContentIndex = contentIndex;
		SecretInformationAppliedContentItem contenConfig = SecretInformationAppliedContent.Instance.GetItem(contentId);
		if (contenConfig.LinkedResult != -1)
		{
			SetResultIndex(contenConfig.LinkedResult);
			return true;
		}
		string content = contenConfig.Texts[_character.GetBehaviorType()];
		_savedContentText = content;
		List<short> visibleSelectionKeys = _processor.GetVisibleSelection(selectionKeys, _character, _taiwu);
		options = MakeSecretInformationSelections(visibleSelectionKeys, argBox, eventData);
		bool addOtherOption = true;
		TaiwuEventOption[] array = options;
		foreach (TaiwuEventOption item in array)
		{
			if (CheckInformationSelectionAvailable(item))
			{
				addOtherOption = false;
				break;
			}
		}
		if (addOtherOption)
		{
			visibleSelectionKeys.Add(0);
			options = MakeSecretInformationSelections(visibleSelectionKeys, argBox, eventData);
		}
		_savedContentSelections = visibleSelectionKeys;
		return true;
	}

	public TaiwuEventOption[] GetSavedContentSelection(EventArgBox argBox, GameData.Domains.TaiwuEvent.TaiwuEvent eventData)
	{
		return MakeSecretInformationSelections(_savedContentSelections, argBox, eventData);
	}

	public string GetSavedContentTexs()
	{
		return _savedContentText;
	}

	public short GetFristContentId()
	{
		return _secretInformationContentId;
	}

	public short GetFristStructId()
	{
		return _secretInformationStructId;
	}

	public bool IsContentAskKeepContent()
	{
		return _secretInformationContentIndex == 2;
	}

	private void SecretInformationMaker_Entrance(EventArgBox argBox)
	{
		foreach (Config.ShortList item in _resultConfig.SecretInformation)
		{
			List<short> configItem = new List<short>(item.DataList);
			if (configItem.Count >= 2)
			{
				short infoKey = configItem[0];
				if (infoKey >= 0)
				{
					SecretInformationMaker_Box(argBox, infoKey, _argList[configItem[1]], (configItem.Count > 2) ? _argList[configItem[2]] : (-1), (configItem.Count > 3) ? _argList[configItem[3]] : (-1));
				}
			}
		}
	}

	private void SecretInformationMaker_Box(EventArgBox argBox, short infoKey, int actorId, int reactorId, int secactorId)
	{
		switch (infoKey)
		{
		case 1:
			MakeNewInfo_KillInPublic(actorId, reactorId);
			break;
		case 95:
			MakeNewInfo_KillInPrivate(actorId, reactorId);
			break;
		case 3:
			MakeNewInfo_KillForPunishment(actorId, reactorId);
			break;
		case 2:
			MakeNewInfo_KidnapInPublic(argBox, actorId, reactorId);
			break;
		case 96:
			MakeNewInfo_KidnapInPrivate(argBox, actorId, reactorId);
			break;
		case 4:
			MakeNewInfo_KidnapForPunishment(argBox, actorId, reactorId);
			break;
		case 25:
			MakeNewInfo_RescueKidnappedCharacter(actorId, reactorId, secactorId);
			break;
		case 24:
			MakeNewInfo_ReleaseKidnappedCharacter(actorId, reactorId);
			break;
		case 37:
		{
			bool result7 = MakeNewInfo_BecomeSwornBrothersAndSisters(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 512, isServe: false, result7);
			break;
		}
		case 38:
		{
			bool result6 = MakeNewInfo_SeverSwornBrothersAndSisters(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 512, isServe: true, result6);
			break;
		}
		case 35:
		{
			bool result5 = MakeNewInfo_BreakupWithLover(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 16384, isServe: true, result5);
			break;
		}
		case 32:
		{
			bool result4 = MakeNewInfo_BecomeFriend(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 8192, isServe: false, result4);
			break;
		}
		case 33:
		{
			bool result3 = MakeNewInfo_SeverFriend(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 8192, isServe: true, result3);
			break;
		}
		case 31:
		{
			bool result2 = MakeNewInfo_BecomeEnemy(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 32768, isServe: false, result2);
			break;
		}
		case 30:
		{
			bool result = MakeNewInfo_SeverEnemy(actorId, reactorId);
			_savedRelationChangeData = new RelationChangeData(actorId, reactorId, 32768, isServe: true, result);
			break;
		}
		}
	}

	private bool MakeNewInfo_KillInPublic(int killerId, int victimId)
	{
		if (MakeNewInfo_ApplyKill(killerId, victimId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKillInPublic(killerId, victimId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_KillInPrivate(int killerId, int victimId)
	{
		if (MakeNewInfo_ApplyKill(killerId, victimId, inPublic: false))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKillInPrivate(killerId, victimId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_KillForPunishment(int killerId, int victimId)
	{
		if (MakeNewInfo_ApplyKill(killerId, victimId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKillForPunishment(killerId, victimId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_ApplyKill(int killerId, int victimId, bool inPublic = true)
	{
		if (!DomainManager.Character.TryGetElement_Objects(killerId, out var killerChar) || !DomainManager.Character.TryGetElement_Objects(victimId, out var _))
		{
			return false;
		}
		Location location = killerChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (inPublic)
		{
			lifeRecordCollection.AddKillInPublic(killerId, currDate, victimId, location);
		}
		else
		{
			lifeRecordCollection.AddKillInPrivate(killerId, currDate, victimId, location);
		}
		_toKillCharIdTupleHashSet.Add((killerId, victimId, inPublic));
		return true;
	}

	private bool MakeNewInfo_KidnapInPublic(EventArgBox argBox, int kidnapperId, int prisonerId)
	{
		if (MakeNewInfo_ApplyKidnap(argBox, kidnapperId, prisonerId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKidnapInPublic(kidnapperId, prisonerId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_KidnapInPrivate(EventArgBox argBox, int kidnapperId, int prisonerId)
	{
		if (MakeNewInfo_ApplyKidnap(argBox, kidnapperId, prisonerId, inPublic: false))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKidnapInPrivate(kidnapperId, prisonerId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_KidnapForPunishment(EventArgBox argBox, int kidnapperId, int prisonerId)
	{
		if (MakeNewInfo_ApplyKidnap(argBox, kidnapperId, prisonerId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddKidnapForPunishment(kidnapperId, prisonerId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_ApplyKidnap(EventArgBox argBox, int kidnaperId, int prisonerId, bool inPublic = true)
	{
		if (prisonerId == _argList[5] || prisonerId == kidnaperId)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(kidnaperId, out var kidnaperChar) || !DomainManager.Character.TryGetElement_Objects(prisonerId, out var prisonerChar))
		{
			return false;
		}
		int oriKidnaperId = prisonerChar.GetKidnapperId();
		if (oriKidnaperId == prisonerId)
		{
			return false;
		}
		short ropeId = 82;
		ItemKey oriRope = default(ItemKey);
		bool isTanselate = false;
		if (oriKidnaperId > 0)
		{
			KidnappedCharacterList kidnapList = DomainManager.Character.GetSomeoneKidnapCharacters(oriKidnaperId);
			if (kidnapList != null)
			{
				KidnappedCharacter kidnapCharData = kidnapList.GetCollection().Find((KidnappedCharacter x) => x.CharId == prisonerId);
				if (kidnapCharData != null)
				{
					oriRope = kidnapCharData.RopeItemKey;
					ropeId = oriRope.ItemType;
					isTanselate = true;
				}
			}
			DomainManager.Character.RemoveKidnappedCharacter(DomainManager.TaiwuEvent.MainThreadDataContext, prisonerId, oriKidnaperId, isEscaped: false);
		}
		if (argBox.Get("ItemKeySeizeCharacterInCombat", out ItemKey curRope) && kidnaperId == _argList[5])
		{
			argBox.Remove<ItemKey>("ItemKeySeizeCharacterInCombat");
			ropeId = curRope.TemplateId;
			oriRope = curRope;
		}
		else
		{
			if (kidnaperId != _taiwuId)
			{
				DomainManager.Character.CombatResultHandle_KidnapEnemy(DomainManager.TaiwuEvent.MainThreadDataContext, kidnaperChar, prisonerChar, inPublic);
				return false;
			}
			if (!isTanselate)
			{
				oriRope = DomainManager.Item.CreateItem(DomainManager.TaiwuEvent.MainThreadDataContext, 12, ropeId);
				kidnaperChar.AddInventoryItem(DomainManager.TaiwuEvent.MainThreadDataContext, oriRope, 1);
			}
		}
		int useRopeCharId = -1;
		if (argBox.Get("UseItemKeySeizeCharacterId", ref useRopeCharId) && useRopeCharId >= 0 && useRopeCharId != kidnaperId)
		{
			GameData.Domains.Character.Character useRopeCharacter = DomainManager.Character.GetElement_Objects(useRopeCharId);
			GameData.Domains.Character.Character kidnapper = DomainManager.Character.GetElement_Objects(kidnaperId);
			useRopeCharacter.RemoveInventoryItem(DomainManager.TaiwuEvent.MainThreadDataContext, oriRope, 1, deleteItem: false);
			kidnapper.AddInventoryItem(DomainManager.TaiwuEvent.MainThreadDataContext, oriRope, 1);
		}
		DomainManager.Character.AddKidnappedCharacter(DomainManager.TaiwuEvent.MainThreadDataContext, kidnaperId, prisonerId, oriRope);
		Location location = kidnaperChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (inPublic)
		{
			lifeRecordCollection.AddKidnapInPublic(kidnaperId, currDate, prisonerId, location, 12, ropeId);
		}
		else
		{
			lifeRecordCollection.AddKidnapInPrivate(kidnaperId, currDate, prisonerId, location, 12, ropeId);
		}
		return true;
	}

	private bool MakeNewInfo_RescueKidnappedCharacter(int saviorId, int prisonerId, int kidnaperId)
	{
		if (MakeNewInfo_ApplyRescue(saviorId, prisonerId, kidnaperId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddRescueKidnappedCharacter(saviorId, prisonerId, kidnaperId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_ApplyRescue(int saviorId, int prisonerId, int kidnaperId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(saviorId, out var _) || !DomainManager.Character.TryGetElement_Objects(kidnaperId, out var _) || !DomainManager.Character.TryGetElement_Objects(prisonerId, out var prisonerChar))
		{
			return false;
		}
		if (prisonerChar.GetKidnapperId() != kidnaperId)
		{
			return false;
		}
		DomainManager.Character.RemoveKidnappedCharacter(DomainManager.TaiwuEvent.MainThreadDataContext, prisonerId, kidnaperId, isEscaped: false);
		return true;
	}

	private bool MakeNewInfo_ReleaseKidnappedCharacter(int kidnaperId, int prisonerId)
	{
		if (MakeNewInfo_ApplyRelease(kidnaperId, prisonerId))
		{
			DomainManager.Information.AddSecretInformation(DomainManager.TaiwuEvent.MainThreadDataContext, DomainManager.Information.GetSecretInformationCollection().AddReleaseKidnappedCharacter(kidnaperId, prisonerId));
			return true;
		}
		return false;
	}

	private bool MakeNewInfo_ApplyRelease(int kidnaperId, int prisonerId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(kidnaperId, out var kidnaperChar) || !DomainManager.Character.TryGetElement_Objects(prisonerId, out var prisonerChar))
		{
			return false;
		}
		if (prisonerChar.GetKidnapperId() != kidnaperId)
		{
			return false;
		}
		DomainManager.Character.RemoveKidnappedCharacter(DomainManager.TaiwuEvent.MainThreadDataContext, prisonerId, kidnaperId, isEscaped: false);
		Location location = kidnaperChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddReleaseKidnappedCharacter(kidnaperId, currDate, prisonerId, location);
		return true;
	}

	private bool MakeNewInfo_BecomeSwornBrothersAndSisters(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!RelationTypeHelper.AllowAddingSwornBrotherOrSisterRelation(targetId, selfId))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplyBecomeSwornBrotherOrSister(context, selfChar, targetChar, selfBehaviorType, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	private bool MakeNewInfo_SeverSwornBrothersAndSisters(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(targetId, selfId, 512))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplySeverSwornBrotherOrSister(context, selfChar, targetChar, selfBehaviorType, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	private bool MakeNewInfo_BreakupWithLover(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(targetId, selfId, 16384))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplyBreakupWithBoyOrGirlFriend(context, selfChar, targetChar, selfBehaviorType, targetStillLoveSelf: false, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	private bool MakeNewInfo_BecomeFriend(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!RelationTypeHelper.AllowAddingFriendRelation(targetId, selfId))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplyBecomeFriend(context, selfChar, targetChar, selfBehaviorType, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	private bool MakeNewInfo_SeverFriend(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(targetId, selfId, 8192))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplySeverFriend(context, selfChar, targetChar, selfBehaviorType, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	private bool MakeNewInfo_BecomeEnemy(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!RelationTypeHelper.AllowAddingEnemyRelation(selfId, targetId))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, selfChar, targetChar, selfIsTaiwuPeople, 0);
		return true;
	}

	private bool MakeNewInfo_SeverEnemy(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(selfId, targetId, 32768))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		GameData.Domains.Character.Character.ApplySeverEnemy(context, selfChar, targetChar, selfBehaviorType, selfIsTaiwuPeople);
		return true;
	}

	private void AddStealLifeRecord(int saviorId, int kidnaperId, int prisonerId, sbyte phase)
	{
		if (DomainManager.Character.TryGetElement_Objects(saviorId, out var saviorChar) && DomainManager.Character.TryGetElement_Objects(kidnaperId, out var _) && DomainManager.Character.TryGetElement_Objects(prisonerId, out var _))
		{
			Location location = saviorChar.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			switch (phase)
			{
			case 0:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail1(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 1:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail2(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 2:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail3(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 3:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlyFail4(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 4:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlySucceed(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 5:
				lifeRecordCollection.AddRescueKidnappedCharacterSecretlySucceedAndEscaped(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			}
		}
	}

	private void AddScamLifeRecord(int saviorId, int kidnaperId, int prisonerId, sbyte phase)
	{
		if (DomainManager.Character.TryGetElement_Objects(saviorId, out var saviorChar) && DomainManager.Character.TryGetElement_Objects(kidnaperId, out var _) && DomainManager.Character.TryGetElement_Objects(prisonerId, out var _) && phase < 3)
		{
			Location location = saviorChar.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			switch (phase)
			{
			case 0:
				lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail1(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 1:
				lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail2(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 2:
				lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail3(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			}
		}
	}

	private void AddRobLifeRecord(int saviorId, int kidnaperId, int prisonerId, sbyte phase)
	{
		if (DomainManager.Character.TryGetElement_Objects(saviorId, out var saviorChar) && DomainManager.Character.TryGetElement_Objects(kidnaperId, out var _) && DomainManager.Character.TryGetElement_Objects(prisonerId, out var _) && phase < 4)
		{
			Location location = saviorChar.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			switch (phase)
			{
			case 0:
				lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail1(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 1:
				lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail2(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 2:
				lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail3(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			case 3:
				lifeRecordCollection.AddRescueKidnappedCharacterWithForceFail4(saviorId, currDate, kidnaperId, location, prisonerId);
				break;
			}
		}
	}

	private static short GetDataFromConditionResult(List<Config.ShortList> conditionResultIds, int listIndex, int dataIndex)
	{
		short result = -1;
		if (listIndex < 0 || dataIndex < 0)
		{
			return result;
		}
		if (conditionResultIds.Count() <= listIndex)
		{
			return result;
		}
		List<short> item = conditionResultIds[listIndex].DataList;
		if (item.Count() <= dataIndex)
		{
			return result;
		}
		return item[dataIndex];
	}

	private static List<short> GetDataListFromConditionResult(List<Config.ShortList> conditionResultIds, int listIndex)
	{
		List<short> result = new List<short>();
		if (listIndex < 0)
		{
			return result;
		}
		if (conditionResultIds.Count() <= listIndex)
		{
			return result;
		}
		return new List<short>(conditionResultIds[listIndex].DataList);
	}

	private bool Chech_PercentProb(int prob)
	{
		return DomainManager.TaiwuEvent.MainThreadDataContext.Random.Next(0, 100) < prob;
	}

	private bool Check_IfCanFight(GameData.Domains.Character.Character character, sbyte combatType)
	{
		return CombatDomain.GetDefeatMarksCountOutOfCombat(character) <= GlobalConfig.NeedDefeatMarkCount[combatType];
	}

	private bool Check_IfCanPanish(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		sbyte selfFame = selfChar.GetFameType();
		sbyte targetFame = targetChar.GetFameType();
		if (selfFame == -2)
		{
			selfFame = 3;
		}
		if (targetFame == -2)
		{
			targetFame = 3;
		}
		return targetFame < 3 && selfFame > 3;
	}

	private bool Check_CharKillTaiwuBecauseOfRefuseKeep(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, short[] probList)
	{
		sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(selfChar.GetId(), targetChar.GetId()));
		short prob = probList[selfChar.GetBehaviorType()];
		int prob_Final = prob * (100 - (favorLevel - 2) * 20);
		return Chech_PercentProb(prob_Final);
	}

	private bool Check_IsRescure(short lastResult)
	{
		if (lastResult == -1)
		{
			return false;
		}
		SecretInformationAppliedResultItem config = SecretInformationAppliedResult.Instance.GetItem(lastResult);
		return GetDataFromConditionResult(config.SecretInformation, 0, 0) != -1;
	}

	private short ApplyEventCondition(EventArgBox argBox)
	{
		SecretInformationSpecialConditionItem condition = SecretInformationSpecialCondition.Instance.GetItem(_resultConfig.SpecialConditionId);
		if (condition == null)
		{
			return -1;
		}
		ESecretInformationSpecialConditionCalculate calculate = condition.Calculate;
		if (1 == 0)
		{
		}
		short result = calculate switch
		{
			ESecretInformationSpecialConditionCalculate.AskCharKeep => ApplyCondition_AskCharKeep(), 
			ESecretInformationSpecialConditionCalculate.AskCharRelease => ApplyCondition_AskCharRelease(), 
			ESecretInformationSpecialConditionCalculate.TaiwuFight => ApplyCondition_TaiwuFight(), 
			ESecretInformationSpecialConditionCalculate.CharFight => ApplyCondition_ChatFight(), 
			ESecretInformationSpecialConditionCalculate.RefuseKeep => ApplyCondition_RefuseKeep(), 
			ESecretInformationSpecialConditionCalculate.TaiwuEscape => ApplyCondition_TaiwuEscape(), 
			ESecretInformationSpecialConditionCalculate.CharEscape => ApplyCondition_CharEscape(), 
			ESecretInformationSpecialConditionCalculate.TaiwuSteal => ApplyCondition_TaiwuSteal(), 
			ESecretInformationSpecialConditionCalculate.TaiwuScam => ApplyCondition_TaiwuScam(), 
			ESecretInformationSpecialConditionCalculate.TaiwuRob => ApplyCondition_TaiwuRob(), 
			ESecretInformationSpecialConditionCalculate.TaiwuRescueEscape => ApplyCondition_TaiwuRescueEscape(), 
			ESecretInformationSpecialConditionCalculate.CharRescue => ApplyCondition_CharRescue(), 
			ESecretInformationSpecialConditionCalculate.CharRescueEscape => ApplyCondition_CharRescueEscape(), 
			ESecretInformationSpecialConditionCalculate.StartFight => ApplyCondition_StartFight(), 
			ESecretInformationSpecialConditionCalculate.StartLifeSkillCombat => ApplyCondition_StartLifeSkillCombat(), 
			ESecretInformationSpecialConditionCalculate.ChooseRope => ApplyCondition_ChooseRope(), 
			ESecretInformationSpecialConditionCalculate.KidnapWithRope => ApplyCondition_KidnapWithRope(argBox), 
			ESecretInformationSpecialConditionCalculate.CharWin => ApplyCondition_CharWin(argBox), 
			ESecretInformationSpecialConditionCalculate.CharJudge => ApplyCondition_CharJudge(argBox), 
			ESecretInformationSpecialConditionCalculate.CharKidnap => ApplyCondition_CharKidnap(argBox), 
			ESecretInformationSpecialConditionCalculate.TaiwuDeleteInfomation => ApplyCondition_TaiwuDeleteInfomation(), 
			ESecretInformationSpecialConditionCalculate.CharDeleteInfomation => ApplyCondition_CharDeleteInfomation(), 
			ESecretInformationSpecialConditionCalculate.TaiwuAdore => ApplyCondition_TaiwuAdore(), 
			ESecretInformationSpecialConditionCalculate.CharAdore => ApplyCondition_CharAdore(), 
			ESecretInformationSpecialConditionCalculate.Forgive => ApplyCondition_Forgive(argBox), 
			ESecretInformationSpecialConditionCalculate.NotForgiveRape => ApplyCondition_NotForgiveRape(), 
			ESecretInformationSpecialConditionCalculate.AskCharBreakup => ApplyCondition_AskCharBreakup(argBox), 
			ESecretInformationSpecialConditionCalculate.ShowFristContent => ApplyCondition_ShowFristContent(), 
			ESecretInformationSpecialConditionCalculate.BreakupWithChar => ApplyCondition_BreakupWithChar(), 
			ESecretInformationSpecialConditionCalculate.ForceBreakupWithChar => ApplyCondition_ForceBreakupWithChar(), 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private short ApplyCondition_ShowFristContent()
	{
		_eventAction = EventAction.ShowFristContent;
		return -1;
	}

	private short ApplyCondition_AskCharKeep()
	{
		int favorLimit = AskCharKeepFavorLimits[_character.GetBehaviorType()];
		sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(_characterId, _taiwuId));
		int index = 0;
		if (favorLevel >= favorLimit)
		{
			index = 1;
			short change = _processor.GetSecretInformationEffectConfig().OppositeFavorabilityDiffsWhenResult[_character.GetBehaviorType()];
			EventHelper.ChangeFavorabilityOptional(_character, _taiwu, change, 3);
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, index);
	}

	private short ApplyCondition_AskCharRelease()
	{
		int favorLimit = AskCharReleaseFavorLimits[_character.GetBehaviorType()];
		sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(_characterId, _taiwuId));
		int index = ((favorLevel >= favorLimit) ? 1 : 0);
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, index);
	}

	private short ApplyCondition_TaiwuFight()
	{
		if (_savedCombatData == null)
		{
			if (_resultConfig.CombatConfigId == -1)
			{
				return -1;
			}
			_savedCombatData = new CombatData(_resultConfig, DomainManager.Character.HasGuard(_characterId, _character));
		}
		if (!Check_IfCanFight(_character, _savedCombatData.CombatType) && _savedCombatData.NoGuard)
		{
			return _savedCombatData.CantFightResult;
		}
		_eventAction = EventAction.StartCombat;
		return -1;
	}

	private short ApplyCondition_ChatFight()
	{
		SecretInformationEffectItem effectConfig = _processor.GetSecretInformationEffectConfig();
		if (effectConfig.CombatType != -1)
		{
			sbyte combatType = CombatConfig.Instance.GetItem(effectConfig.CombatType).CombatType;
			int index = 0;
			if (combatType == 2)
			{
				index = (Check_IfCanPanish(_character, _taiwu) ? 1 : 2);
			}
			SecretInformationAppliedResultItem combatConfig = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, index));
			_savedCombatData = new CombatData(combatConfig, DomainManager.Character.HasGuard(_characterId, _character));
			return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 0);
		}
		return -1;
	}

	private short ApplyCondition_RefuseKeep()
	{
		SecretInformationEffectItem effectConfig = _processor.GetSecretInformationEffectConfig();
		if (Check_CharKillTaiwuBecauseOfRefuseKeep(_character, _taiwu, effectConfig.KillingProbOfRefuseKeepSecret) && effectConfig.CombatType != -1)
		{
			sbyte combatType = CombatConfig.Instance.GetItem(effectConfig.CombatType).CombatType;
			int index = 0;
			if (combatType == 2)
			{
				index = 1;
			}
			SecretInformationAppliedResultItem combatConfig = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, index));
			_savedCombatData = new CombatData(combatConfig, DomainManager.Character.HasGuard(_characterId, _character));
			return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 0);
		}
		return -1;
	}

	private short ApplyCondition_RefuseKeep_Ori()
	{
		SecretInformationEffectItem effectConfig = _processor.GetSecretInformationEffectConfig();
		if (Check_CharKillTaiwuBecauseOfRefuseKeep(_character, _taiwu, effectConfig.KillingProbOfRefuseKeepSecret) && _resultConfig.CombatConfigId != -1)
		{
			_savedCombatData = new CombatData(_resultConfig, DomainManager.Character.HasGuard(_characterId, _character));
			return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 0);
		}
		return -1;
	}

	private short ApplyCondition_TaiwuEscape()
	{
		_toEscapeCharIdList.Add(_taiwuId);
		return -1;
	}

	private short ApplyCondition_CharEscape()
	{
		_toEscapeCharIdList.Add(_characterId);
		return -1;
	}

	private short ApplyCondition_TaiwuSteal()
	{
		sbyte phase = EventHelper.GetStealActionPhase(_taiwu, _character);
		short nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, (phase > 4) ? 4 : phase);
		short lastResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 4);
		if (Check_IsRescure(lastResult))
		{
			AddStealLifeRecord(_taiwuId, _characterId, _argList[1], phase);
		}
		_savedActionData = new ActionData(1, phase, new List<short>(), _taiwuId, _characterId, _argList[1]);
		return nextResult;
	}

	private short ApplyCondition_TaiwuScam()
	{
		sbyte phase = EventHelper.GetScamActionPhase(_taiwu, _character);
		short nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, (phase > 3) ? 3 : phase);
		short lastResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 0);
		if (Check_IsRescure(lastResult))
		{
			AddScamLifeRecord(_taiwuId, _characterId, _argList[1], phase);
		}
		_savedActionData = new ActionData(2, phase, GetDataListFromConditionResult(_resultConfig.SpecialConditionResultIds, 1), _taiwuId, _characterId, _argList[1]);
		return nextResult;
	}

	private short ApplyCondition_TaiwuRob()
	{
		sbyte phase = EventHelper.GetRobActionPhase(_taiwu, _character);
		short nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, (phase > 4) ? 4 : phase);
		short lastResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 0);
		if (Check_IsRescure(lastResult))
		{
			AddRobLifeRecord(_taiwuId, _characterId, _argList[1], phase);
		}
		if (_resultConfig.CombatConfigId != -1)
		{
			_savedCombatData = new CombatData(_resultConfig, DomainManager.Character.HasGuard(_characterId, _character));
		}
		_savedActionData = new ActionData(3, phase, new List<short>(), _taiwuId, _characterId, _argList[1]);
		return nextResult;
	}

	private short ApplyCondition_TaiwuRescueEscape()
	{
		short nextResult = -1;
		if (_savedActionData != null)
		{
			if (_savedActionData.Phase == 5)
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, _savedActionData.ActionKey, 1);
			}
			else
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, _savedActionData.ActionKey, 0);
				if (_resultConfig.CombatConfigId != -1)
				{
					_savedCombatData = new CombatData(_resultConfig, DomainManager.Character.HasGuard(_characterId, _character));
				}
			}
		}
		_savedActionData = null;
		return nextResult;
	}

	private short ApplyCondition_CharRescue()
	{
		sbyte actionType = GetCharRescueAction(_characterId, _taiwuId, _argList[1]);
		short nextResult = -1;
		switch (actionType)
		{
		case 1:
		{
			sbyte phase2 = EventHelper.GetStealActionPhase(_character, _taiwu);
			short lastResult2 = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 1);
			if (Check_IsRescure(lastResult2))
			{
				AddStealLifeRecord(_characterId, _taiwuId, _argList[1], phase2);
			}
			switch (phase2)
			{
			case 5:
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 1);
				_savedActionData = new ActionData(1, phase2, new List<short>(), _characterId, _taiwuId, _argList[1]);
				break;
			case 4:
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 1, 0);
				SecretInformationAppliedResultItem combatConfig = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 0));
				if (combatConfig != null && combatConfig.CombatConfigId != -1)
				{
					_savedCombatData = new CombatData(combatConfig, hasGuard: false);
				}
				_savedActionData = new ActionData(1, phase2, new List<short>(), _characterId, _taiwuId, _argList[1]);
				break;
			}
			default:
				return -1;
			}
			break;
		}
		case 2:
		{
			sbyte phase3 = EventHelper.GetStealActionPhase(_character, _taiwu);
			SecretInformationAppliedResultItem nextResultTin2 = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 1));
			short lastResult3 = GetDataFromConditionResult(nextResultTin2.SpecialConditionResultIds, 0, 1);
			if (Check_IsRescure(lastResult3))
			{
				AddScamLifeRecord(_characterId, _taiwuId, _argList[1], phase3);
			}
			if (phase3 >= 3)
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 2, 0);
				_savedActionData = new ActionData(2, phase3, GetDataListFromConditionResult(nextResultTin2.SpecialConditionResultIds, 0), _characterId, _taiwuId, _argList[1]);
				break;
			}
			return -1;
		}
		case 3:
		{
			sbyte phase = EventHelper.GetRobActionPhase(_character, _taiwu);
			SecretInformationAppliedResultItem nextResultTin = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 2));
			short lastResult = GetDataFromConditionResult(nextResultTin.SpecialConditionResultIds, 0, 1);
			if (Check_IsRescure(lastResult))
			{
				AddRobLifeRecord(_characterId, _taiwuId, _argList[1], phase);
			}
			if (phase >= 4)
			{
				_savedCombatData = new CombatData(nextResultTin, hasGuard: false);
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 3, 0);
				_savedActionData = new ActionData(3, phase, new List<short>(), _characterId, _taiwuId, _argList[1]);
				break;
			}
			return -1;
		}
		default:
			return -1;
		}
		return nextResult;
	}

	private sbyte GetCharRescueAction(int saviorId, int kidnaperId, int prisonerId)
	{
		sbyte selectedDemandActionType = -1;
		if (!DomainManager.Character.TryGetElement_Objects(saviorId, out var saviorChar) || !DomainManager.Character.TryGetElement_Objects(kidnaperId, out var _) || !DomainManager.Character.TryGetElement_Objects(prisonerId, out var _))
		{
			return selectedDemandActionType;
		}
		sbyte favorType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(saviorId, prisonerId));
		if (favorType <= 1)
		{
			return selectedDemandActionType;
		}
		if (!Chech_PercentProb(favorType * 20 - 40))
		{
			return selectedDemandActionType;
		}
		sbyte behaviorType = saviorChar.GetBehaviorType();
		sbyte[] priorityList = AiHelper.PrioritizedActionConstants.RescueFriendOrFamilyActionPriorities[behaviorType];
		sbyte[] array = priorityList;
		foreach (sbyte actionType in array)
		{
			int chance = 60 + AiHelper.DemandActionType.ToPersonalityType[actionType];
			if (Chech_PercentProb(chance))
			{
				selectedDemandActionType = actionType;
				break;
			}
		}
		if (selectedDemandActionType == 3 && !Check_IfCanFight(saviorChar, 1))
		{
			selectedDemandActionType = 0;
		}
		return selectedDemandActionType;
	}

	private short ApplyCondition_CharRescueEscape()
	{
		short nextResult = -1;
		if (_savedActionData != null)
		{
			if (_savedActionData.Phase == 5)
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, _savedActionData.ActionKey, 1);
			}
			else
			{
				nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, _savedActionData.ActionKey, 0);
				if (_resultConfig.CombatConfigId != -1)
				{
					_savedCombatData = new CombatData(_resultConfig, hasGuard: false);
				}
			}
			_savedActionData = null;
			return nextResult;
		}
		return -1;
	}

	private short ApplyCondition_StartFight()
	{
		_eventAction = EventAction.StartCombat;
		return -1;
	}

	private short ApplyCondition_StartLifeSkillCombat()
	{
		_eventAction = EventAction.StartLifeSkillCombat;
		return -1;
	}

	private short ApplyCondition_ChooseRope()
	{
		_eventAction = EventAction.ChooseRope;
		return -1;
	}

	private short ApplyCondition_CharWin(EventArgBox argBox)
	{
		sbyte combatType = _savedCombatData.CombatType;
		_savedCombatData = null;
		if (GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 2, 0) == -1)
		{
			short infoKey = (short)(GetCharAction_CharWin_InPublic(_character) ? 1 : 95);
			SecretInformationMaker_Box(argBox, infoKey, _characterId, _taiwuId, -1);
			return -1;
		}
		int endindex = GetCharAction_CharWin(_character, _taiwu, combatType);
		int endindex2 = ((!GetCharAction_CharWin_InPublic(_character)) ? 1 : 0);
		short nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, endindex, endindex2);
		if (nextResult == -1)
		{
			nextResult = GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, endindex, 0);
		}
		return nextResult;
	}

	private short ApplyCondition_CharJudge(EventArgBox argBox)
	{
		sbyte combatType = _savedCombatData.CombatType;
		_savedCombatData = null;
		if (GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 2, 0) == -1)
		{
			SecretInformationMaker_Box(argBox, 1, _characterId, _taiwuId, -1);
			return -1;
		}
		int endindex = GetCharAction_CharWin(_character, _taiwu, combatType);
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, endindex, 0);
	}

	private short ApplyCondition_CharKidnap(EventArgBox argBox)
	{
		short infoKey = (short)(GetCharAction_CharWin_InPublic(_character) ? 2 : 96);
		SecretInformationMaker_Box(argBox, infoKey, _characterId, _argList[1], -1);
		return -1;
	}

	private int GetCharAction_CharWin(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, sbyte combatType, bool enableKidnap = false)
	{
		sbyte killBaseChance = 60;
		sbyte kidnapBaseChance = 60;
		sbyte releaseBaseChance = 60;
		if (combatType == 1)
		{
			killBaseChance = -100;
			kidnapBaseChance = -100;
			releaseBaseChance = 100;
		}
		sbyte behaviorType = selfChar.GetBehaviorType();
		AiHelper.CombatResultHandleType[] priorities = AiHelper.NpcCombat.ResultHandleTypePriorities[behaviorType];
		int action = 0;
		for (int i = 0; i < 3; i++)
		{
			switch (priorities[i])
			{
			case AiHelper.CombatResultHandleType.Kill:
				if (Chech_PercentProb(killBaseChance + EventHelper.GetRolePersonality(selfChar, 3)))
				{
					action = 1;
				}
				break;
			case AiHelper.CombatResultHandleType.Kidnap:
				if (Chech_PercentProb(kidnapBaseChance + EventHelper.GetRolePersonality(selfChar, 1)))
				{
					action = ((!enableKidnap) ? 1 : 2);
				}
				break;
			case AiHelper.CombatResultHandleType.Release:
				if (Chech_PercentProb(releaseBaseChance + EventHelper.GetRolePersonality(selfChar, 0)))
				{
					action = 0;
				}
				break;
			}
		}
		return action;
	}

	private bool GetCharAction_CharWin_InPublic(GameData.Domains.Character.Character character)
	{
		sbyte behaviorType = character.GetBehaviorType();
		int prob = AiHelper.NpcCombat.HandleEnemyInPublicChance[behaviorType];
		return Chech_PercentProb(prob);
	}

	private short ApplyCondition_KidnapWithRope(EventArgBox argBox)
	{
		short nextResult = -1;
		sbyte combatType = 1;
		if (_savedActionData != null)
		{
			combatType = _savedCombatData.CombatType;
			_savedCombatData = null;
		}
		if (argBox.Get("ItemKeySeizeCharacterInCombat", out ItemKey ropeKey) && CombatDomain.CheckRopeHitOutOfCombat(DomainManager.TaiwuEvent.MainThreadDataContext.Random, _taiwu, _character, combatType, useMaxMarkCount: true, ItemTemplateHelper.GetGrade(ropeKey.ItemType, ropeKey.TemplateId)))
		{
			return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 1);
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, 0);
	}

	private short ApplyCondition_TaiwuDeleteInfomation()
	{
		_toDiscardCharIdList.Add((_taiwuId, _secretInformationId));
		return -1;
	}

	private short ApplyCondition_CharDeleteInfomation()
	{
		_toDiscardCharIdList.Add((_characterId, _secretInformationId));
		return -1;
	}

	private short ApplyCondition_TaiwuAdore()
	{
		bool result = ApplyRelation_Adore(_taiwuId, _characterId);
		_savedRelationChangeData = new RelationChangeData(_characterId, _taiwuId, 16384, isServe: false, result);
		return -1;
	}

	private short ApplyCondition_CharAdore()
	{
		bool result = ApplyRelation_Adore(_characterId, _taiwuId);
		_savedRelationChangeData = new RelationChangeData(_characterId, _taiwuId, 16384, isServe: false, result);
		return -1;
	}

	private bool ApplyRelation_Adore(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var _))
		{
			return false;
		}
		if (!RelationTypeHelper.AllowAddingAdoredRelation(selfId, targetId))
		{
			return false;
		}
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplyAddRelation_Adore(DomainManager.TaiwuEvent.MainThreadDataContext, selfChar, selfChar, selfChar.GetBehaviorType(), targetLovesBack: false, selfIsTaiwuPeople, targetIsTaiwuPeople);
		return true;
	}

	public bool ApplyRelation_SeverAdore(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(selfId, targetId, 16384))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte charBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		GameData.Domains.Character.Character.ApplySeverAdore(context, selfChar, targetChar, charBehaviorType, selfIsTaiwuPeople);
		if (DomainManager.Taiwu.GetTaiwuCharId() != selfId && Chech_PercentProb(LoveRelationValue.MakeEnemyWhenNotAdore[charBehaviorType]))
		{
			GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, targetChar, selfChar, selfIsTaiwuPeople, 3);
		}
		return true;
	}

	public bool ApplyRelation_SeverSpouse(int selfId, int targetId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar))
		{
			return false;
		}
		if (!DomainManager.Character.HasRelation(selfId, targetId, 1024))
		{
			return false;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		sbyte charBehaviorType = selfChar.GetBehaviorType();
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfId);
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetId);
		GameData.Domains.Character.Character.ApplySeverHusbandOrWife(context, selfChar, targetChar, charBehaviorType, selfIsTaiwuPeople, targetIsTaiwuPeople);
		if (DomainManager.Taiwu.GetTaiwuCharId() != selfId && Chech_PercentProb(LoveRelationValue.MakeEnemyWhenDivorce[charBehaviorType]))
		{
			GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, targetChar, selfChar, selfIsTaiwuPeople, 3);
		}
		return true;
	}

	private short ApplyCondition_Forgive(EventArgBox argBox)
	{
		List<int> relation = _processor.GetAllSecretInformationRelationsOfCharacter(_characterId, includeLoveRelation: true, includeLeadership: false);
		List<int> breakList = new List<int>();
		List<int> forgiveList = new List<int>();
		List<int> endAdoreList = new List<int>();
		List<int> stillAdoreList = new List<int>();
		Dictionary<int, GameData.Domains.Character.Character> actorList = _processor.GetActiveActorList_WithActorIndex();
		List<int> loveRelation = new List<int> { 10, 11, 15 };
		List<int> AdoredRelation = new List<int> { 13, 14, 15 };
		for (int i = 0; i < 3; i++)
		{
			if (!actorList.TryGetValue(i, out var actor))
			{
				continue;
			}
			if (relation.Contains(loveRelation[i]))
			{
				if (DomainManager.Character.HasRelation(actor.GetId(), _characterId, 1024))
				{
					if (!Check_IfForgive(_characterId, actor.GetId(), 2) && ApplyRelation_SeverSpouse(_characterId, actor.GetId()))
					{
						breakList.Add(actor.GetId());
						continue;
					}
					forgiveList.Add(actor.GetId());
					ApplyEffect_Forgive(_character, actor, 2);
				}
				else if (DomainManager.Character.HasRelation(_characterId, actor.GetId(), 16384))
				{
					if (!Check_IfForgive(_characterId, actor.GetId(), 1) && MakeNewInfo_BreakupWithLover(_characterId, actor.GetId()))
					{
						breakList.Add(actor.GetId());
						continue;
					}
					forgiveList.Add(actor.GetId());
					ApplyEffect_Forgive(_character, actor, 1);
				}
			}
			else if (relation.Contains(AdoredRelation[i]) && DomainManager.Character.HasRelation(_characterId, actor.GetId(), 16384))
			{
				if (!Check_IfForgive(_characterId, actor.GetId(), 0) && ApplyRelation_SeverAdore(_characterId, actor.GetId()))
				{
					endAdoreList.Add(actor.GetId());
					continue;
				}
				stillAdoreList.Add(actor.GetId());
				ApplyEffect_Forgive(_character, actor, 0);
			}
		}
		int indexLove = 0;
		int index0 = 2;
		int index1 = 2;
		if (breakList.Contains(_taiwuId))
		{
			index0 = 0;
			index1 = 0;
		}
		else if (forgiveList.Contains(_taiwuId))
		{
			index0 = 0;
			index1 = 1;
		}
		else if (endAdoreList.Contains(_taiwuId))
		{
			indexLove = 1;
			index0 = 0;
			index1 = 0;
		}
		else if (stillAdoreList.Contains(_taiwuId))
		{
			indexLove = 1;
			index0 = 0;
			index1 = 1;
		}
		else if (breakList.Count != 0)
		{
			index1 = 0;
			argBox.Set("breakTargetCharacterId", breakList[0]);
		}
		else if (forgiveList.Count != 0)
		{
			index1 = 1;
		}
		else if (endAdoreList.Count != 0)
		{
			indexLove = 1;
			index1 = 0;
			argBox.Set("breakTargetCharacterId", endAdoreList[0]);
		}
		else if (stillAdoreList.Count != 0)
		{
			indexLove = 1;
			index1 = 1;
		}
		else if (_processor.IsTaiwuSecretInformationActor())
		{
			index0 = 0;
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, index0 + indexLove, index1);
	}

	private short ApplyCondition_NotForgiveRape()
	{
		int index0 = ((_taiwuId != _argList[0]) ? 1 : 0);
		int index1 = 2;
		if (DomainManager.Character.HasRelation(_characterId, _argList[0], 1024))
		{
			if (ApplyRelation_SeverSpouse(_characterId, _argList[0]))
			{
				index1 = 0;
			}
		}
		else if (DomainManager.Character.HasRelation(_characterId, _argList[0], 16384))
		{
			if (DomainManager.Character.HasRelation(_argList[0], _characterId, 16384))
			{
				if (MakeNewInfo_BreakupWithLover(_characterId, _argList[0]))
				{
					index1 = 0;
				}
			}
			else if (ApplyRelation_SeverAdore(_characterId, _argList[0]))
			{
				index1 = 1;
			}
		}
		if (index1 == 2 && _taiwuId == _argList[0] && _processor.ConditionBox(23, _characterId, _taiwuId))
		{
			int combatIndex = 0;
			if (Check_IfCanPanish(_character, _taiwu))
			{
				combatIndex = 1;
			}
			SecretInformationAppliedResultItem combatConfig = SecretInformationAppliedResult.Instance.GetItem(GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 2, combatIndex));
			if (combatConfig != null)
			{
				_savedCombatData = new CombatData(combatConfig, hasGuard: false);
				index1 = 3;
			}
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, index0, index1);
	}

	private void ApplyEffect_Forgive(GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, int loveRelationType)
	{
		EventHelper.ChangeRoleHappiness(selfChar, -5);
		short change = (short)(-3000 * (loveRelationType + 1));
		EventHelper.ChangeFavorabilityOptional(selfChar, targetChar, change, 3);
	}

	private short ApplyCondition_AskCharBreakup(EventArgBox argBox)
	{
		int index = 0;
		List<int> actors = _processor.GetActiveActorIdList(new List<int> { _taiwuId, _characterId });
		if (actors.Count == 0)
		{
			index = 2;
		}
		foreach (int actorId in actors)
		{
			GameData.Domains.Character.Character actor = DomainManager.Character.GetElement_Objects(actorId);
			if (DomainManager.Character.HasRelation(actorId, _characterId, 1024))
			{
				argBox.Set("breakTargetCharacterId", actorId);
				bool secsess = Check_IfBreak(_taiwuId, _characterId, actorId, 2) && ApplyRelation_SeverSpouse(_characterId, actorId);
				if (secsess)
				{
					index = 1;
				}
				ApplyFavorChange_Break(_taiwuId, _characterId, actorId, secsess);
				break;
			}
			if (DomainManager.Character.HasRelation(actorId, _characterId, 16384) && DomainManager.Character.HasRelation(_characterId, actorId, 16384))
			{
				argBox.Set("breakTargetCharacterId", actorId);
				bool secsess2 = Check_IfBreak(_taiwuId, _characterId, actorId, 1) && MakeNewInfo_BreakupWithLover(_characterId, actorId);
				if (secsess2)
				{
					index = 1;
				}
				ApplyFavorChange_Break(_taiwuId, _characterId, actorId, secsess2);
				break;
			}
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, 0, index);
	}

	private short ApplyCondition_BreakupWithChar()
	{
		int index0 = 3;
		int index1 = 0;
		if (DomainManager.Character.HasRelation(_taiwuId, _characterId, 1024))
		{
			if (Check_IfForgive(_characterId, _taiwuId, 2))
			{
				index0 = 0;
			}
			else
			{
				index0 = 1;
				ApplyRelation_SeverSpouse(_taiwuId, _characterId);
			}
		}
		else if (DomainManager.Character.HasRelation(_taiwuId, _characterId, 16384))
		{
			if (DomainManager.Character.HasRelation(_characterId, _taiwuId, 16384))
			{
				if (Check_IfForgive(_characterId, _taiwuId, 1))
				{
					index0 = 0;
				}
				else
				{
					index0 = 1;
					MakeNewInfo_BreakupWithLover(_taiwuId, _characterId);
				}
			}
			else
			{
				index0 = 2;
				ApplyRelation_SeverAdore(_taiwuId, _characterId);
			}
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, index0, index1);
	}

	private short ApplyCondition_ForceBreakupWithChar()
	{
		int index0 = 2;
		int index1 = 0;
		if (DomainManager.Character.HasRelation(_taiwuId, _characterId, 1024))
		{
			EventHelper.ChangeFavorabilityOptional(_character, _taiwu, -6000, 3);
			EventHelper.ChangeFavorabilityOptional(_taiwu, _character, -6000, 3);
			if (Check_IfForgive(_characterId, _taiwuId, 2))
			{
				index0 = 0;
				ApplyRelation_SeverAdore(_taiwuId, _characterId);
				EventHelper.ChangeFavorabilityOptional(_character, _taiwu, -6000, 3);
				EventHelper.ChangeFavorabilityOptional(_taiwu, _character, -6000, 3);
			}
			else
			{
				index0 = 1;
				ApplyRelation_SeverSpouse(_taiwuId, _characterId);
			}
		}
		else if (DomainManager.Character.HasRelation(_taiwuId, _characterId, 16384) && DomainManager.Character.HasRelation(_characterId, _taiwuId, 16384))
		{
			EventHelper.ChangeFavorabilityOptional(_character, _taiwu, -6000, 3);
			EventHelper.ChangeFavorabilityOptional(_taiwu, _character, -6000, 3);
			if (Check_IfForgive(_characterId, _taiwuId, 2))
			{
				index0 = 0;
				ApplyRelation_SeverAdore(_taiwuId, _characterId);
				EventHelper.ChangeFavorabilityOptional(_character, _taiwu, -6000, 3);
				EventHelper.ChangeFavorabilityOptional(_taiwu, _character, -6000, 3);
			}
			else
			{
				index0 = 1;
				MakeNewInfo_BreakupWithLover(_taiwuId, _characterId);
			}
		}
		return GetDataFromConditionResult(_resultConfig.SpecialConditionResultIds, index0, index1);
	}

	private bool Check_IfForgive(int selfId, int targetId, int relationIndex)
	{
		if (!DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) || !DomainManager.Character.TryGetElement_Objects(targetId, out var _))
		{
			return false;
		}
		sbyte selfBehaviorType = selfChar.GetBehaviorType();
		int minSelfFavorabilityReq = 0;
		switch (relationIndex)
		{
		case 0:
			minSelfFavorabilityReq = LoveRelationValue.FavorOfNotAdore[selfBehaviorType];
			break;
		case 1:
			minSelfFavorabilityReq = LoveRelationValue.FavorOfBreakUp[selfBehaviorType];
			break;
		case 2:
			minSelfFavorabilityReq = LoveRelationValue.FavorOfDivorce[selfBehaviorType];
			break;
		}
		sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(selfId, targetId));
		return favorLevel > minSelfFavorabilityReq;
	}

	private bool Check_IfBreak(int selfId, int targetId, int secTargetId, int loveRelationType)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(targetId);
		sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetId, selfId));
		if (favorLevel > 0)
		{
			return !Check_IfForgive(targetId, secTargetId, loveRelationType);
		}
		sbyte calmValue = EventHelper.GetRolePersonality(character, 0);
		return Chech_PercentProb(30 + calmValue * 3);
	}

	private void ApplyFavorChange_Break(int selfId, int targetId, int secTargetId, bool IfBreak)
	{
		if (DomainManager.Character.TryGetElement_Objects(selfId, out var selfChar) && DomainManager.Character.TryGetElement_Objects(targetId, out var targetChar) && DomainManager.Character.TryGetElement_Objects(secTargetId, out var _))
		{
			sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetId, secTargetId));
			sbyte level = Math.Max(favorLevel, 0);
			int favor = (-3000 + level * -1500) / 2;
			EventHelper.ChangeFavorabilityOptional(targetChar, selfChar, (short)favor, 3);
			if (IfBreak)
			{
				EventHelper.ChangeRoleHappiness(targetChar, -(level + 3));
			}
		}
	}

	public static void ChangeFavorability(int charAId, int charBId, int deltaFavor)
	{
		if (charAId != charBId && InformationDomain.CheckTuringTest(charAId, out var characterA) && InformationDomain.CheckTuringTest(charBId, out var characterB))
		{
			int curDelta = Math.Clamp(deltaFavor, -30000, 30000);
			EventHelper.ChangeFavorabilityOptional(characterA, characterB, (short)curDelta, 3);
		}
	}

	public bool GetEventAction_After(EventArgBox argBox)
	{
		short nextResultId = -1;
		bool result = false;
		switch (_eventAction)
		{
		case EventAction.StartCombat:
			nextResultId = DoAfterAction_Combat(argBox);
			break;
		case EventAction.StartLifeSkillCombat:
			nextResultId = DoAfterAction_LifeSkillCombat(argBox);
			break;
		case EventAction.ChooseRope:
			result = true;
			break;
		}
		ResultIndex = nextResultId;
		return result;
	}

	private short DoAfterAction_Combat(EventArgBox argBox)
	{
		if (_savedCombatData == null)
		{
			return -1;
		}
		sbyte combatResult = -1;
		if (!argBox.Get("CombatResult", ref combatResult))
		{
			return -1;
		}
		AddLifeRecord_After(CombatResultType.IsPlayerWin(combatResult));
		if (!_savedCombatData.NoGuard && (combatResult == 0 || combatResult == 5))
		{
			combatResult = 3;
		}
		int avoidDeathId = DomainManager.Character.GetAvoidDeathCharId();
		if (_taiwuId == avoidDeathId && (combatResult == 4 || combatResult == 1))
		{
			combatResult = 7;
		}
		if (_characterId == avoidDeathId && (combatResult == 5 || combatResult == 0))
		{
			combatResult = 8;
		}
		int prisonerId = -1;
		if (_savedCombatData.NoGuard && argBox.Get("ItemKeySeizeCharacterInCombat", out ItemKey _) && argBox.Get("CharIdSeizedInCombat", ref prisonerId) && prisonerId == _characterId)
		{
			combatResult = 6;
		}
		argBox.Remove<int>("CharIdSeizedInCombat");
		argBox.Remove<int>("CombatResult");
		return _savedCombatData.CombatResult[combatResult];
	}

	private short DoAfterAction_LifeSkillCombat(EventArgBox argBox)
	{
		if (_savedActionData == null)
		{
			return -1;
		}
		bool winLifeSkill = false;
		if (!argBox.Get("WinState", ref winLifeSkill))
		{
			return -1;
		}
		AddLifeRecord_After(winLifeSkill);
		argBox.Remove<int>("WinState");
		int index = ((!winLifeSkill) ? 1 : 0);
		return _savedActionData.CombatResult[index];
	}

	private void AddLifeRecord_After(bool taiwuWin, bool isCombat = false)
	{
		if (_savedActionData == null)
		{
			return;
		}
		if (_savedActionData.ActionKey == 2 && !isCombat)
		{
			if (_savedActionData.Phase < 3)
			{
				return;
			}
			Location location = _taiwu.GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			if ((_taiwuId == _savedActionData.SaviorId) ? taiwuWin : (!taiwuWin))
			{
				if (_savedActionData.Phase == 5)
				{
					lifeRecordCollection.AddRescueKidnappedCharacterWithWitSucceedAndEscaped(_savedActionData.SaviorId, currDate, _savedActionData.KidnaperId, location, _savedActionData.PrisonerId);
				}
				else
				{
					lifeRecordCollection.AddRescueKidnappedCharacterWithWitSucceed(_savedActionData.SaviorId, currDate, _savedActionData.KidnaperId, location, _savedActionData.PrisonerId);
				}
			}
			else
			{
				lifeRecordCollection.AddRescueKidnappedCharacterWithWitFail4(_savedActionData.SaviorId, currDate, _savedActionData.KidnaperId, location, _savedActionData.PrisonerId);
			}
		}
		else if (_savedActionData.ActionKey == 3 && isCombat && _savedActionData.Phase >= 4)
		{
			Location location2 = _taiwu.GetLocation();
			int currDate2 = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection2 = DomainManager.LifeRecord.GetLifeRecordCollection();
			if ((_taiwuId == _savedActionData.SaviorId) ? taiwuWin : (!taiwuWin))
			{
				lifeRecordCollection2.AddRescueKidnappedCharacterWithForceSucceed(_savedActionData.SaviorId, currDate2, _savedActionData.KidnaperId, location2, _savedActionData.PrisonerId);
			}
			else
			{
				lifeRecordCollection2.AddRescueKidnappedCharacterWithForceFail4(_savedActionData.SaviorId, currDate2, _savedActionData.KidnaperId, location2, _savedActionData.PrisonerId);
			}
		}
	}

	public unsafe TaiwuEventOption[] MakeSecretInformationSelections(List<short> TemplateIdList, EventArgBox argBox, GameData.Domains.TaiwuEvent.TaiwuEvent eventData, string extraKey = "")
	{
		List<TaiwuEventOption> result = new List<TaiwuEventOption>();
		eventData.EventConfig.EscOptionKey = string.Empty;
		foreach (short id in TemplateIdList)
		{
			SecretInformationAppliedSelectionItem selectionConfig = SecretInformationAppliedSelection.Instance.GetItem(id);
			if (selectionConfig == null)
			{
				continue;
			}
			TaiwuEventOption selection = new TaiwuEventOption();
			selection.GetExtraFormatLanguageKeys = () => (List<string>)null;
			selection.OptionAvailableConditions = new List<TaiwuEventOptionConditionBase>();
			selection.OptionConsumeInfos = new List<OptionConsumeInfo>();
			selection.SetContent("BlankSlection");
			string content = ((selectionConfig.Text != null) ? selectionConfig.Text : string.Empty);
			string extraContent = string.Empty;
			selection.ArgBox = argBox;
			short[] behaviorRequire = selectionConfig.PlayerBehaviorTypeIds;
			if (DomainManager.World.GetRestrictOptionsBehaviorType() && behaviorRequire != null && behaviorRequire.Length != 0)
			{
				selection.OptionAvailableConditions.Add(new OptionConditionBehaviorTypes(15, (sbyte)behaviorRequire[0], (sbyte)((behaviorRequire.Length > 1) ? ((sbyte)behaviorRequire[1]) : (-1)), (sbyte)((behaviorRequire.Length > 2) ? ((sbyte)behaviorRequire[2]) : (-1)), (sbyte)((behaviorRequire.Length > 3) ? ((sbyte)behaviorRequire[3]) : (-1)), (sbyte)((behaviorRequire.Length > 4) ? ((sbyte)behaviorRequire[4]) : (-1)), OptionConditionMatcher.TaiwuIsBehaviorType));
			}
			if (selectionConfig.TimeCost > 0)
			{
				selection.OptionAvailableConditions.Add(new OptionConditionSbyte(2, selectionConfig.TimeCost, OptionConditionMatcher.MovePointMore));
				selection.OptionConsumeInfos.Add(new OptionConsumeInfo(8, selectionConfig.TimeCost, auto: true));
			}
			if (selectionConfig.FavorabilityCondition > -6)
			{
				selection.OptionAvailableConditions.Add(new OptionConditionFavor(5, selectionConfig.FavorabilityCondition, OptionConditionMatcher.FavorAtLeast));
			}
			bool isMainAttributeCost = false;
			short propertyId = selectionConfig.MainAttributeCost.PropertyId;
			short value = selectionConfig.MainAttributeCost.Value;
			if (value > 0 && propertyId >= 0 && propertyId < 6)
			{
				isMainAttributeCost = true;
				List<string> attributeKeyList = new List<string> { "LK_Main_Attribute_Strength", "LK_Main_Attribute_Dexterity", "LK_Main_Attribute_Concentration", "LK_Main_Attribute_Vitality", "LK_Main_Attribute_Energy", "LK_Main_Attribute_Intelligence" };
				extraContent = $"<color=#darkgrey>[<Language Key=Event_ForSecretInformationAppliedSelection_Cost/><Language Key={attributeKeyList[propertyId]}/>：{value}]</color>";
			}
			bool isTaiwuFight = false;
			short resultId = selectionConfig.ResultId1;
			if (resultId != -1 && SecretInformationAppliedResult.Instance[resultId].SpecialConditionId == 17)
			{
				isTaiwuFight = true;
			}
			if (isTaiwuFight)
			{
				short combatId = SecretInformationAppliedResult.Instance[resultId].CombatConfigId;
				if (combatId == -1)
				{
					combatId = 1;
				}
				int markLimit = GlobalConfig.NeedDefeatMarkCount[CombatConfig.Instance[combatId].CombatType];
				if (isMainAttributeCost)
				{
					selection.OnOptionAvailableCheck = delegate
					{
						GameData.Domains.Character.Character character = selection.ArgBox.GetCharacter("RoleTaiwu");
						MainAttributes currMainAttributes = character.GetCurrMainAttributes();
						bool flag = currMainAttributes.Items[propertyId] >= value;
						bool flag2 = CombatDomain.GetDefeatMarksCountOutOfCombat(character) < markLimit;
						return flag && flag2;
					};
				}
				else
				{
					selection.OnOptionAvailableCheck = delegate
					{
						GameData.Domains.Character.Character character = selection.ArgBox.GetCharacter("RoleTaiwu");
						return CombatDomain.GetDefeatMarksCountOutOfCombat(character) < markLimit;
					};
				}
			}
			else if (isMainAttributeCost)
			{
				selection.OnOptionAvailableCheck = delegate
				{
					GameData.Domains.Character.Character character = selection.ArgBox.GetCharacter("RoleTaiwu");
					MainAttributes currMainAttributes = character.GetCurrMainAttributes();
					return currMainAttributes.Items[propertyId] >= value;
				};
			}
			if (isMainAttributeCost)
			{
				selection.OnOptionSelect = delegate
				{
					GameData.Domains.Character.Character character = selection.ArgBox.GetCharacter("RoleTaiwu");
					EventHelper.ChangeRoleMainAttribute(character, (sbyte)propertyId, -value);
					if (resultId < 0)
					{
						ApplyEventEnd(selection.ArgBox);
						return string.Empty;
					}
					SetResultIndex(resultId);
					return GetEventGuid(selection.ArgBox);
				};
			}
			else
			{
				selection.OnOptionSelect = delegate
				{
					if (resultId < 0)
					{
						ApplyEventEnd(selection.ArgBox);
						return string.Empty;
					}
					SetResultIndex(resultId);
					return GetEventGuid(selection.ArgBox);
				};
			}
			if (!string.IsNullOrEmpty(content) || selectionConfig.SelectionTexts == null || selectionConfig.SelectionTexts.Length < 5)
			{
				if (!string.IsNullOrEmpty(extraContent))
				{
					content += extraContent;
				}
				if (isTaiwuFight)
				{
					short combatId2 = SecretInformationAppliedResult.Instance[resultId].CombatConfigId;
					if (combatId2 == -1)
					{
						combatId2 = 1;
					}
					int markLimit2 = GlobalConfig.NeedDefeatMarkCount[CombatConfig.Instance[combatId2].CombatType];
					selection.GetReplacedContent = delegate
					{
						string text = content;
						GameData.Domains.Character.Character character = selection.ArgBox.GetCharacter("RoleTaiwu");
						if (CombatDomain.GetDefeatMarksCountOutOfCombat(character) >= markLimit2)
						{
							text += "<Language Key=Event_ForSecretInformationAppliedSelection_CanNotFight/>";
						}
						return EventHelper.HandleStringTag(text, selection.ArgBox, eventData);
					};
				}
				else
				{
					selection.GetReplacedContent = () => EventHelper.HandleStringTag(content, selection.ArgBox, eventData);
				}
				selection.OptionKey = $"{extraKey}SecretInformationStandaSelection{id}{result.Count}";
				result.Add(selection);
			}
			else
			{
				int curkey = result.Count;
				selection.OptionKey = $"{extraKey}SecretInformationStandaSelection{id}{result.Count}";
				for (int i = 0; i < 5; i++)
				{
					TaiwuEventOption clone = CloneSecretInformationSelection(selection, $"{i}");
					clone.Behavior = (sbyte)(i + 1);
					string content2 = selectionConfig.SelectionTexts[i];
					if (!string.IsNullOrEmpty(extraContent))
					{
						content2 += extraContent;
					}
					clone.GetReplacedContent = () => EventHelper.HandleStringTag(content2, clone.ArgBox, eventData);
					result.Add(clone);
				}
			}
			if (selectionConfig.HotKey == ESecretInformationAppliedSelectionHotKey.Esc)
			{
				if (string.IsNullOrEmpty(eventData.EventConfig.EscOptionKey))
				{
					eventData.EventConfig.EscOptionKey = selection.OptionKey;
				}
				else
				{
					AdaptableLog.Warning("multiple esc selection in secret");
				}
			}
		}
		return result.ToArray();
	}

	public TaiwuEventOption CloneSecretInformationSelection(TaiwuEventOption origin, string extraKey)
	{
		TaiwuEventOption selection = new TaiwuEventOption();
		selection.ArgBox = origin.ArgBox;
		selection.Behavior = origin.Behavior;
		selection.DefaultState = origin.DefaultState;
		selection.GetExtraFormatLanguageKeys = origin.GetExtraFormatLanguageKeys;
		selection.GetReplacedContent = origin.GetReplacedContent;
		selection.OnOptionAvailableCheck = origin.OnOptionAvailableCheck;
		selection.OnOptionSelect = origin.OnOptionSelect;
		selection.OnOptionVisibleCheck = origin.OnOptionVisibleCheck;
		selection.OptionAvailableConditions = origin.OptionAvailableConditions;
		selection.OptionConsumeInfos = origin.OptionConsumeInfos;
		selection.SetContent(origin.OptionContent);
		selection.OptionKey = origin.OptionKey + extraKey;
		return selection;
	}

	public bool CheckInformationSelectionAvailable(TaiwuEventOption selection)
	{
		if (!selection.IsVisible)
		{
			return false;
		}
		if (!selection.IsAvailable)
		{
			return false;
		}
		if (selection.OptionAvailableConditions != null)
		{
			foreach (TaiwuEventOptionConditionBase item in selection.OptionAvailableConditions)
			{
				if (!item.CheckCondition(selection.ArgBox))
				{
					return false;
				}
			}
		}
		if (selection.OptionConsumeInfos != null)
		{
			int charAId = -1;
			int charBId = -1;
			selection.ArgBox.Get("RoleTaiwu", ref charAId);
			selection.ArgBox.Get(EventTriggerParameter.DefValue.CharacterId, ref charBId);
			foreach (OptionConsumeInfo item2 in selection.OptionConsumeInfos)
			{
				if (!item2.HasConsumeResource(charAId, charBId))
				{
					return false;
				}
			}
		}
		return true;
	}
}
