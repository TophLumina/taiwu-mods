using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information.Secret;
using GameData.Domains.Information.Secret.Attachment;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;
using GameData.Utilities.Information;
using Redzen.Random;

namespace GameData.Domains.Information;

public class SecretInformationProcessor
{
	public static class RelationIndex
	{
		public static readonly List<SecretInformationRelationshipType> Allied = new List<SecretInformationRelationshipType> { SecretInformationRelationshipType.Allied };

		public static readonly List<SecretInformationRelationshipType> Enemy = new List<SecretInformationRelationshipType> { SecretInformationRelationshipType.Enemy };

		public static readonly List<SecretInformationRelationshipType> Adorer = new List<SecretInformationRelationshipType> { SecretInformationRelationshipType.Adorer };

		public static readonly List<SecretInformationRelationshipType> Revel = new List<SecretInformationRelationshipType>
		{
			SecretInformationRelationshipType.Relative,
			SecretInformationRelationshipType.MentorAndMentee,
			SecretInformationRelationshipType.SwornBrotherOrSister
		};

		public static readonly List<SecretInformationRelationshipType> Love = new List<SecretInformationRelationshipType>
		{
			SecretInformationRelationshipType.HusbandOrWife,
			SecretInformationRelationshipType.Lover
		};

		public static readonly List<SecretInformationRelationshipType> Spouse = new List<SecretInformationRelationshipType> { SecretInformationRelationshipType.HusbandOrWife };

		public static readonly List<SecretInformationRelationshipType> Single = new List<SecretInformationRelationshipType>
		{
			SecretInformationRelationshipType.Adorer,
			SecretInformationRelationshipType.Enemy
		};
	}

	private readonly List<int> _argList = new List<int>();

	private readonly List<int> _actorIdList = new List<int>();

	private readonly Dictionary<int, GameData.Domains.Character.Character> _activeActorList = new Dictionary<int, GameData.Domains.Character.Character>();

	private short _templateId = -1;

	private int _baseFavorOdds = -1;

	private Dictionary<GameData.Domains.Character.Character, int> _relatedCharacterIndexList;

	private SecretInformationItem _infoConfig;

	private SecretInformationEffectItem _effectConfig;

	private SecretInformationSectPunishItem _sectPunishConfig;

	private Dictionary<int, CharacterExtraInfo> _characterExtraInfo = new Dictionary<int, CharacterExtraInfo>();

	private Dictionary<int, CharacterRelationshipSnapshot> _characterRelationshipSnapshots = new Dictionary<int, CharacterRelationshipSnapshot>();

	private SecretOccurenceId _occurenceId = SecretOccurenceId.Invalid;

	private SecretOccurenceId _relevanceOccurenceId = SecretOccurenceId.Invalid;

	public bool Initialize(SecretOccurence occurence, byte[] secretParams)
	{
		Reset();
		int actorId = -1;
		int reactorId = -1;
		int secActorId = -1;
		int itemType = -1;
		_infoConfig = Config.SecretInformation.Instance.GetItem(_templateId = occurence.TemplateId);
		if (_infoConfig == null)
		{
			LogInfo($"Invalid templateID {occurence.TemplateId}");
			return false;
		}
		_effectConfig = SecretInformationEffect.Instance.GetItem(_infoConfig.DefaultEffectId);
		if (_effectConfig == null)
		{
			LogInfo($"Invalid effectConfigId {_infoConfig.DefaultEffectId}");
			return false;
		}
		_sectPunishConfig = SecretInformationSectPunish.Instance.GetItem(_templateId);
		if (_sectPunishConfig == null)
		{
			return false;
		}
		secretParams.ExtractSecretParameters(_infoConfig, delegate(int idx, int charId)
		{
			if (idx == _effectConfig.ActorIndex)
			{
				actorId = charId;
			}
			else if (idx == _effectConfig.ReactorIndex)
			{
				reactorId = charId;
			}
			else if (idx == _effectConfig.SecactorIndex)
			{
				secActorId = charId;
			}
		}, delegate
		{
		}, delegate
		{
		}, delegate(int idx, ItemKey itemKey)
		{
			if (idx == _effectConfig.Item)
			{
				itemType = itemKey.ItemType;
			}
		}, delegate
		{
		}, delegate
		{
		}, delegate
		{
		});
		_argList.Add(actorId);
		_argList.Add(reactorId);
		_argList.Add(secActorId);
		for (int i = 0; i < _argList.Count; i++)
		{
			int id = _argList[i];
			if (id != -1)
			{
				_actorIdList.Add(id);
				if (InformationDomain.CheckTuringTest(id, out var character))
				{
					_activeActorList.Add(i, character);
				}
			}
		}
		_argList.Add(-1);
		_argList.Add(itemType);
		_argList.Add(DomainManager.Taiwu.GetTaiwuCharId());
		_characterExtraInfo = new Dictionary<int, CharacterExtraInfo>(occurence.CharacterExtraInfoCollection);
		_characterRelationshipSnapshots = new Dictionary<int, CharacterRelationshipSnapshot>(occurence.CharacterRelationshipSnapshotCollection);
		_occurenceId = occurence.Id;
		_relevanceOccurenceId = occurence.RelevanceOccurenceId;
		return true;
	}

	public void Reset()
	{
		_argList.Clear();
		_actorIdList.Clear();
		_activeActorList.Clear();
		_templateId = -1;
		_infoConfig = null;
		_effectConfig = null;
		_sectPunishConfig = null;
		_baseFavorOdds = -1;
		_relatedCharacterIndexList = null;
		_characterExtraInfo.Clear();
		_characterRelationshipSnapshots.Clear();
		_occurenceId = SecretOccurenceId.Invalid;
		_relevanceOccurenceId = SecretOccurenceId.Invalid;
	}

	public void Initialize_ForBroadcastEffect(IRandomSource random)
	{
		CalBaseFavorabilityConditionOdds();
		CalAllActiveRelatedCharactorRelationIndex(random);
	}

	public short GetSecretInformationTemplateId()
	{
		return _templateId;
	}

	public SecretInformationEffectItem GetSecretInformationEffectConfig()
	{
		return _effectConfig;
	}

	public List<int> GetSecretInformationArgList()
	{
		return _argList;
	}

	public bool IsCharacterSecretInformationActor(int charId, bool includeDead = true)
	{
		IEnumerable<int> enumerable;
		if (!includeDead)
		{
			IEnumerable<int> actorIdList = _actorIdList;
			enumerable = actorIdList;
		}
		else
		{
			enumerable = _activeActorList.Values.Select((GameData.Domains.Character.Character x) => x.GetId());
		}
		IEnumerable<int> list = enumerable;
		return list.Contains(charId);
	}

	public List<int> GetActiveActorIdList(IEnumerable<int> excludeId = null)
	{
		HashSet<int> result = new HashSet<int>(_activeActorList.Values.Select((GameData.Domains.Character.Character x) => x.GetId()));
		if (excludeId != null)
		{
			result.ExceptWith(excludeId);
		}
		return result.ToList();
	}

	public List<int> GetActorIdList(IEnumerable<int> excludeId = null)
	{
		HashSet<int> result = new HashSet<int>(_actorIdList);
		if (excludeId != null)
		{
			result.ExceptWith(excludeId);
		}
		return result.ToList();
	}

	public int GetCharacterActorIndex(int charId)
	{
		int result = _argList.FindIndex((int x) => x == charId);
		if (result > 2)
		{
			result = -1;
		}
		return result;
	}

	public bool CheckIfActorExist_WithActorIndex(int charIndex)
	{
		if (charIndex < 0 || charIndex > 2)
		{
			return false;
		}
		GameData.Domains.Character.Character element;
		return DomainManager.Character.TryGetElement_Objects(_argList[charIndex], out element);
	}

	public Dictionary<int, GameData.Domains.Character.Character> GetActiveActorList_WithActorIndex()
	{
		return _activeActorList;
	}

	public Dictionary<int, GameData.Domains.Character.Character> GetActiveActorList_WithRelationIndex()
	{
		List<int> relationIndex = new List<int> { 1, 4, 7 };
		Dictionary<int, GameData.Domains.Character.Character> result = new Dictionary<int, GameData.Domains.Character.Character>();
		foreach (KeyValuePair<int, GameData.Domains.Character.Character> item in _activeActorList)
		{
			result.Add(relationIndex[item.Key], item.Value);
		}
		return result;
	}

	public byte GetSecretInformationActorBroadcastType()
	{
		byte result = 2;
		if (IsTaiwuSecretInformationActor())
		{
			result = 0;
		}
		else if (IsTaiwuSecretInformationDissemination())
		{
			result = 1;
		}
		return result;
	}

	public bool IsTaiwuSecretInformationActor()
	{
		return _actorIdList.Contains(_argList[5]);
	}

	private bool IsTaiwuSecretInformationDissemination()
	{
		return GetSecretInformationDisseminationBranchCharacterIds().Contains(_argList[5]);
	}

	public sbyte GetFameTypeSafe(int charId)
	{
		int index = _argList.FindIndex((int x) => x == charId);
		sbyte fameType = -1;
		if (_infoConfig.ExtraSnapshotParameterIndices == null || !Enumerable.Contains(_infoConfig.ExtraSnapshotParameterIndices, index))
		{
			return fameType;
		}
		if (_characterExtraInfo.TryGetValue(charId, out var extraInfo))
		{
			fameType = extraInfo.FameType;
		}
		if (fameType == -2)
		{
			fameType = 3;
		}
		return fameType;
	}

	public OrganizationInfo GetSectInfoSafe(int charId)
	{
		int index = _argList.FindIndex((int x) => x == charId);
		OrganizationInfo orgInfo = new OrganizationInfo(-1, 0, principal: true, -1);
		if (_infoConfig.ExtraSnapshotParameterIndices == null || !Enumerable.Contains(_infoConfig.ExtraSnapshotParameterIndices, index))
		{
			return orgInfo;
		}
		if (_characterExtraInfo.TryGetValue(charId, out var extraInfo))
		{
			orgInfo = extraInfo.OrgInfo;
		}
		return orgInfo;
	}

	public byte GetMonkTypeSafe(int charId)
	{
		byte monkType = 0;
		int index = _argList.FindIndex((int x) => x == charId);
		if (_infoConfig.ExtraSnapshotParameterIndices == null || !Enumerable.Contains(_infoConfig.ExtraSnapshotParameterIndices, index))
		{
			return monkType;
		}
		if (_characterExtraInfo.TryGetValue(charId, out var extraInfo))
		{
			monkType = extraInfo.MonkType;
		}
		return monkType;
	}

	public HashSet<int> GetSecretInformationRelatedCharactersOfSpecialRelation(int characterId, IEnumerable<SecretInformationRelationshipType> relations, bool includeAlive = true, bool includeDead = true, bool includeActors = false)
	{
		HashSet<int> result = new HashSet<int>();
		SecretInformationRelationshipType[] relationArray = (relations as SecretInformationRelationshipType[]) ?? relations.ToArray();
		if (!relationArray.Any())
		{
			return result;
		}
		if (_characterRelationshipSnapshots.TryGetValue(characterId, out var relationshipSnapshot))
		{
			SecretInformationRelationshipType[] array = relationArray;
			for (int i = 0; i < array.Length; i++)
			{
				switch (array[i])
				{
				case SecretInformationRelationshipType.Relative:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveBrothersAndSisters.GetCollection());
					break;
				case SecretInformationRelationshipType.SwornBrotherOrSister:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.SwornBrothersAndSisters.GetCollection());
					break;
				case SecretInformationRelationshipType.HusbandOrWife:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.HusbandsAndWives.GetCollection());
					break;
				case SecretInformationRelationshipType.Adorer:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Adored.GetCollection());
					break;
				case SecretInformationRelationshipType.MentorAndMentee:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Mentors.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Mentees.GetCollection());
					break;
				case SecretInformationRelationshipType.Friend:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Friends.GetCollection());
					break;
				case SecretInformationRelationshipType.Enemy:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Enemies.GetCollection());
					break;
				case SecretInformationRelationshipType.Lover:
				{
					HashSet<int> temptResult = new HashSet<int>();
					foreach (int charId in relationshipSnapshot.RelatedCharacters.Adored.GetCollection())
					{
						if (_characterRelationshipSnapshots.TryGetValue(characterId, out var targetRelationshipSnapshot) && targetRelationshipSnapshot.RelatedCharacters.Adored.Contains(characterId))
						{
							temptResult.Add(charId);
						}
					}
					result.UnionWith(temptResult);
					break;
				}
				case SecretInformationRelationshipType.Allied:
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.BloodBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.StepBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveParents.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveChildren.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.AdoptiveBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.SwornBrothersAndSisters.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.HusbandsAndWives.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Adored.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Mentors.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Mentees.GetCollection());
					result.UnionWith(relationshipSnapshot.RelatedCharacters.Friends.GetCollection());
					break;
				}
			}
			if (!includeAlive)
			{
				result.RemoveWhere((int key) => _characterExtraInfo.TryGetValue(key, out var value) && value.AliveState == 0);
			}
			if (!includeDead)
			{
				result.RemoveWhere((int key) => _characterExtraInfo.TryGetValue(key, out var value) && value.AliveState != 0);
			}
			if (!includeActors)
			{
				result.ExceptWith(_actorIdList);
			}
		}
		return result;
	}

	public HashSet<int> GetSecretInformationRelatedCharactersOfSpecialRelation_ForNoneActor(int characterId, IEnumerable<SecretInformationRelationshipType> relations, bool includeAlive = true, bool includeDead = true)
	{
		SecretInformationRelationshipType[] relationArray = (relations as SecretInformationRelationshipType[]) ?? relations.ToArray();
		SecretInformationRelationshipType[] single = relationArray.Intersect(RelationIndex.Single).ToArray();
		SecretInformationRelationshipType[] twoway = relationArray.Except(RelationIndex.Single).ToArray();
		HashSet<int> result = new HashSet<int>();
		foreach (int actorId in _actorIdList)
		{
			if (GetSecretInformationRelatedCharactersOfSpecialRelation(actorId, twoway).Contains(characterId) || GetSecretInformationRelatedCharactersOfSpecialRelation(characterId, single).Contains(actorId))
			{
				result.Add(actorId);
			}
		}
		if (!includeAlive)
		{
			result.RemoveWhere((int charId) => _characterExtraInfo.TryGetValue(charId, out var value) && value.AliveState == 0);
		}
		if (!includeDead)
		{
			result.RemoveWhere((int charId) => _characterExtraInfo.TryGetValue(charId, out var value) && value.AliveState != 0);
		}
		return result;
	}

	public bool Check_HasSpecialRelations(int charId, int targetId, IEnumerable<SecretInformationRelationshipType> relations)
	{
		SecretInformationRelationshipType[] relationArray = (relations as SecretInformationRelationshipType[]) ?? relations.ToArray();
		IEnumerable<SecretInformationRelationshipType> single = relationArray.Intersect(RelationIndex.Single);
		SecretInformationRelationshipType[] twoway = relationArray.Except(RelationIndex.Single).ToArray();
		return GetSecretInformationRelatedCharactersOfSpecialRelation(charId, single, includeAlive: true, includeDead: true, includeActors: true).Contains(targetId) || GetSecretInformationRelatedCharactersOfSpecialRelation(charId, twoway, includeAlive: true, includeDead: true, includeActors: true).Contains(targetId) || GetSecretInformationRelatedCharactersOfSpecialRelation(targetId, twoway, includeAlive: true, includeDead: true, includeActors: true).Contains(charId);
	}

	public bool Check_IsSectLeaderOfCharacter(int charId, int targetId)
	{
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(targetId);
		if (oriActorOrgInfo.OrgTemplateId < 1 || oriActorOrgInfo.OrgTemplateId > 15)
		{
			return false;
		}
		if (!InformationDomain.CheckTuringTest(charId, out var character))
		{
			return false;
		}
		OrganizationInfo curActorOrgInfo = character.GetOrganizationInfo();
		if (curActorOrgInfo.OrgTemplateId < 0)
		{
			return false;
		}
		if (curActorOrgInfo.OrgTemplateId != oriActorOrgInfo.OrgTemplateId)
		{
			return false;
		}
		return curActorOrgInfo.Grade == 8;
	}

	public List<int> GetAllSecretInformationRelationsOfCharacter(int charId, bool includeLoveRelation, bool includeLeadership)
	{
		List<int> result = new List<int>();
		if (charId == -1)
		{
			return new List<int> { 0 };
		}
		int actorId = _argList[0];
		int reactorId = _argList[1];
		int secactorId = _argList[2];
		if (actorId != -1)
		{
			if (actorId == charId)
			{
				result.Add(1);
			}
			if (Check_HasSpecialRelations(charId, actorId, RelationIndex.Allied))
			{
				result.Add(2);
			}
			if (Check_HasSpecialRelations(charId, actorId, RelationIndex.Enemy))
			{
				result.Add(3);
			}
			if (includeLoveRelation && !_actorIdList.Contains(charId))
			{
				if (Check_HasSpecialRelations(charId, actorId, RelationIndex.Love))
				{
					result.Add(10);
				}
				else if (Check_HasSpecialRelations(charId, actorId, RelationIndex.Adorer))
				{
					result.Add(13);
				}
			}
			if (includeLeadership && Check_IsSectLeaderOfCharacter(charId, actorId))
			{
				result.Add(16);
			}
		}
		if (reactorId != -1)
		{
			if (reactorId == charId)
			{
				result.Add(4);
			}
			if (Check_HasSpecialRelations(charId, reactorId, RelationIndex.Allied))
			{
				result.Add(5);
			}
			if (Check_HasSpecialRelations(charId, reactorId, RelationIndex.Enemy))
			{
				result.Add(6);
			}
			if (includeLoveRelation && !_actorIdList.Contains(charId))
			{
				if (Check_HasSpecialRelations(charId, reactorId, RelationIndex.Love))
				{
					result.Add(11);
				}
				else if (Check_HasSpecialRelations(charId, reactorId, RelationIndex.Adorer))
				{
					result.Add(14);
				}
			}
			if (includeLeadership && Check_IsSectLeaderOfCharacter(charId, reactorId))
			{
				result.Add(17);
			}
		}
		if (secactorId != -1)
		{
			if (secactorId == charId)
			{
				result.Add(7);
			}
			if (Check_HasSpecialRelations(charId, secactorId, RelationIndex.Allied))
			{
				result.Add(8);
			}
			if (Check_HasSpecialRelations(charId, secactorId, RelationIndex.Enemy))
			{
				result.Add(9);
			}
			if (includeLoveRelation && !_actorIdList.Contains(charId))
			{
				if (Check_HasSpecialRelations(charId, secactorId, RelationIndex.Love))
				{
					result.Add(12);
				}
				else if (Check_HasSpecialRelations(charId, secactorId, RelationIndex.Adorer))
				{
					result.Add(15);
				}
			}
			if (includeLeadership && Check_IsSectLeaderOfCharacter(charId, secactorId))
			{
				result.Add(18);
			}
		}
		if (result.Count == 0)
		{
			result.Add(0);
		}
		return result;
	}

	public HashSet<int> GetAllSecretInformationRelatedCharacters(bool includeGeneral = true, bool includeAlive = true, bool includeDead = true, bool includeActors = false)
	{
		HashSet<int> result = new HashSet<int>();
		foreach (KeyValuePair<int, CharacterRelationshipSnapshot> characterRelationshipSnapshot in _characterRelationshipSnapshots)
		{
			CharacterRelationshipSnapshot relationshipSnapshot = characterRelationshipSnapshot.Value;
			relationshipSnapshot.RelatedCharacters.GetAllRelatedCharIds(result, includeGeneral);
		}
		if (!includeAlive)
		{
			result.RemoveWhere((int charId) => _characterExtraInfo.TryGetValue(charId, out var value) && value.AliveState == 0);
		}
		if (!includeDead)
		{
			result.RemoveWhere((int charId) => _characterExtraInfo.TryGetValue(charId, out var value) && value.AliveState != 0);
		}
		if (!includeActors)
		{
			result.ExceptWith(_actorIdList);
		}
		return result;
	}

	public List<GameData.Domains.Character.Character> GetAllSecretInformationRelatedCharacters_WithTuringTest(bool includeActors = false)
	{
		if (_relatedCharacterIndexList != null)
		{
			Dictionary<GameData.Domains.Character.Character, int>.KeyCollection related = _relatedCharacterIndexList.Keys;
			return includeActors ? related.ToList() : related.Except(_activeActorList.Values).ToList();
		}
		return InformationDomain.GetTuringTestPassedCharacters(GetAllSecretInformationRelatedCharacters(includeGeneral: true, includeAlive: true, includeDead: true, includeActors));
	}

	public Dictionary<GameData.Domains.Character.Character, int> GetAllSecretInformationRelatedCharacters_WithTuringTestAndRelationIndex(bool includeActors = false)
	{
		if (_relatedCharacterIndexList == null)
		{
			return new Dictionary<GameData.Domains.Character.Character, int>();
		}
		Dictionary<GameData.Domains.Character.Character, int> result = new Dictionary<GameData.Domains.Character.Character, int>(_relatedCharacterIndexList);
		if (!includeActors)
		{
			foreach (GameData.Domains.Character.Character character in _activeActorList.Values)
			{
				if (result.ContainsKey(character))
				{
					result.Remove(character);
				}
			}
		}
		return result;
	}

	public HashSet<int> GetSecretInformationDisseminationBranchCharacterIds()
	{
		InformationDomain domain = DomainManager.Information;
		return domain.QueryAllSecretInformation((GameData.Domains.Information.Secret.SecretInformation secret) => secret.OccurenceId == _occurenceId)?.Select((GameData.Domains.Information.Secret.SecretInformation secret) => secret.SourceCharacterId).ToHashSet() ?? new HashSet<int>();
	}

	public List<GameData.Domains.Character.Character> GetSecretInformationDisseminationBranchCharacterIds_WithTuringTest()
	{
		return InformationDomain.GetTuringTestPassedCharacters(GetSecretInformationDisseminationBranchCharacterIds());
	}

	private int GetRandonRelationIndex(IRandomSource random, int charId, bool includeLoveRelation = false, bool includeLeadership = false)
	{
		List<int> relation = GetAllSecretInformationRelationsOfCharacter(charId, includeLoveRelation, includeLeadership);
		return relation.ElementAt(random.Next(0, relation.Count));
	}

	private void CalAllActiveRelatedCharactorRelationIndex(IRandomSource random)
	{
		_relatedCharacterIndexList = GetAllSecretInformationRelatedCharacters_WithTuringTest(includeActors: true).ToDictionary((GameData.Domains.Character.Character x) => x, (GameData.Domains.Character.Character x) => GetRandonRelationIndex(random, x.GetId()));
	}

	private int CalBaseFavorabilityConditionOdds()
	{
		int result = 0;
		_baseFavorOdds = 0;
		List<Config.ShortList> conditionItemList = _effectConfig.SpecialConditionFavorabilities;
		if (conditionItemList.Count == 0)
		{
			return result;
		}
		for (int i = 0; i < conditionItemList.Count; i++)
		{
			List<short> conditionItem = conditionItemList[i].DataList;
			if (conditionItem.Count == 2)
			{
				if (_effectConfig.SpecialConditionIndices.Count <= i)
				{
					LogInfo($"TemplateId:{_templateId} Error in EffectConfig.SpecialConditionIndices ! Must None Less Than Count of EffectConfig.SpecialConditionFavorabilities");
					_baseFavorOdds = result;
					return result;
				}
				List<short> indicesItem = _effectConfig.SpecialConditionIndices[i].DataList;
				if (!indicesItem.Contains(3) && ConditionBox_FavorabilityConditionOddsEntrance(conditionItem[0], indicesItem))
				{
					result += conditionItem[1];
				}
			}
		}
		_baseFavorOdds = result;
		return result;
	}

	private int CalPersonalFavorabilityConditionOdds(int charId)
	{
		int result = 0;
		List<Config.ShortList> conditionItemList = _effectConfig.SpecialConditionFavorabilities;
		if (conditionItemList.Count == 0)
		{
			return result;
		}
		for (int i = 0; i < conditionItemList.Count; i++)
		{
			List<short> conditionItem = conditionItemList[i].DataList;
			if (conditionItem.Count == 2)
			{
				if (_effectConfig.SpecialConditionIndices.Count <= i)
				{
					LogInfo($"TemplateId:{_templateId} Error in EffectConfig.SpecialConditionIndices ! Must None Less Than Count of EffectConfig.SpecialConditionFavorabilities");
					return result;
				}
				List<short> indicesItem = _effectConfig.SpecialConditionIndices[i].DataList;
				if (indicesItem.Contains(3) && ConditionBox_FavorabilityConditionOddsEntrance(conditionItem[0], indicesItem, charId))
				{
					result += conditionItem[1];
				}
			}
		}
		return result;
	}

	private bool ConditionBox_FavorabilityConditionOddsEntrance(short conditionKey, List<short> argIndexList, int extraId = -1)
	{
		if (conditionKey == 0)
		{
			return true;
		}
		List<int> curList = new List<int>(_argList);
		if (curList.Count > 3)
		{
			curList[3] = extraId;
		}
		argIndexList = ((argIndexList == null) ? new List<short>() : argIndexList.Select((short t) => (short)Math.Clamp((t < 0 || t >= curList.Count()) ? t : curList[t], -32768, 32767)).ToList());
		return ConditionBox((sbyte)conditionKey, (argIndexList.Count > 0) ? argIndexList[0] : (-1), (argIndexList.Count > 1) ? argIndexList[1] : (-1), (argIndexList.Count > 2) ? argIndexList[2] : (-1), (argIndexList.Count > 3) ? argIndexList[3] : (-1));
	}

	private List<int> CalFinalDeltaFavorabilityOfRelatedCharacters_WithRelationIndex(GameData.Domains.Character.Character character, int relationIndex)
	{
		List<int> result = new List<int> { 0, 0, 0, 0 };
		if (_actorIdList.Contains(character.GetId()))
		{
			return result;
		}
		sbyte behaviorType = character.GetBehaviorType();
		int conditionOdds = _baseFavorOdds + CalPersonalFavorabilityConditionOdds(character.GetId());
		bool isSpecial = conditionOdds != 0;
		IReadOnlyList<Config.ShortList> favorabilityDiffs;
		switch (relationIndex)
		{
		case 0:
		case 16:
		case 17:
		case 18:
			favorabilityDiffs = (isSpecial ? _effectConfig.OtherFavorabilityDiffsWhenSpecial : _effectConfig.OtherFavorabilityDiffs);
			break;
		case 2:
		case 10:
		case 13:
			favorabilityDiffs = (isSpecial ? _effectConfig.ActorFriendFavorabilityDiffsWhenSpecial : _effectConfig.ActorFriendFavorabilityDiffs);
			break;
		case 3:
			favorabilityDiffs = (isSpecial ? _effectConfig.ActorEnemyFavorabilityDiffsWhenSpecial : _effectConfig.ActorEnemyFavorabilityDiffs);
			break;
		case 5:
		case 11:
		case 14:
			favorabilityDiffs = (isSpecial ? _effectConfig.ReactorFriendFavorabilityDiffsWhenSpecial : _effectConfig.ReactorFriendFavorabilityDiffs);
			break;
		case 6:
			favorabilityDiffs = (isSpecial ? _effectConfig.ReactorEnemyFavorabilityDiffsWhenSpecial : _effectConfig.ReactorEnemyFavorabilityDiffs);
			break;
		case 8:
		case 12:
		case 15:
			favorabilityDiffs = (isSpecial ? _effectConfig.SecactorFriendFavorabilityDiffsWhenSpecial : _effectConfig.SecactorFriendFavorabilityDiffs);
			break;
		case 9:
			favorabilityDiffs = (isSpecial ? _effectConfig.SecactorEnemyFavorabilityDiffsWhenSpecial : _effectConfig.SecactorEnemyFavorabilityDiffs);
			break;
		default:
			return result;
		}
		result = new List<int>();
		for (int i = 0; i < 4; i++)
		{
			int favor = favorabilityDiffs[i].DataList[behaviorType];
			if (isSpecial)
			{
				favor = favor * conditionOdds / 100;
			}
			result.Add(favor);
		}
		return result;
	}

	private List<int> CalFinalDeltaFavorabilityOfActors_WithActorIndex(int actorIndex)
	{
		List<int> result = new List<int> { 0, 0, 0, 0 };
		if (!_activeActorList.TryGetValue(actorIndex, out var character))
		{
			return result;
		}
		sbyte behaviorType = character.GetBehaviorType();
		bool isSpecial = _baseFavorOdds != 0;
		IReadOnlyList<Config.ShortList> favorabilityDiffs;
		switch (actorIndex)
		{
		case 0:
			favorabilityDiffs = (isSpecial ? _effectConfig.ActorFavorabilityDiffsWhenSpecial : _effectConfig.ActorFavorabilityDiffs);
			break;
		case 1:
			favorabilityDiffs = (isSpecial ? _effectConfig.ReactorFavorabilityDiffsWhenSpecial : _effectConfig.ReactorFavorabilityDiffs);
			break;
		case 2:
			favorabilityDiffs = (isSpecial ? _effectConfig.SecactorFavorabilityDiffsWhenSpecial : _effectConfig.SecactorFavorabilityDiffs);
			break;
		default:
			return result;
		}
		result = new List<int>();
		int curIndex = 0;
		for (int i = 0; i < 4; i++)
		{
			if (i == actorIndex)
			{
				result.Add(0);
				continue;
			}
			int favor = favorabilityDiffs[curIndex].DataList[behaviorType];
			if (isSpecial)
			{
				favor = favor * _baseFavorOdds / 100;
			}
			result.Add(favor);
			curIndex++;
		}
		return result;
	}

	public List<InformationDomain.SecretInformationFavorChangeItem> GetAllSecretInformationFavorabilityChangeWithSource(int sourceCharId)
	{
		Dictionary<int, Dictionary<int, int>> result = new Dictionary<int, Dictionary<int, int>>();
		Dictionary<GameData.Domains.Character.Character, int> relatedCharList = GetAllSecretInformationRelatedCharacters_WithTuringTestAndRelationIndex();
		List<GameData.Domains.Character.Character> disseminationCharList = GetSecretInformationDisseminationBranchCharacterIds_WithTuringTest();
		foreach (KeyValuePair<int, GameData.Domains.Character.Character> actor in _activeActorList)
		{
			int charId = actor.Value.GetId();
			List<int> deltaFavorList = CalFinalDeltaFavorabilityOfActors_WithActorIndex(actor.Key);
			foreach (KeyValuePair<int, GameData.Domains.Character.Character> targetActor in _activeActorList)
			{
				if (targetActor.Key == actor.Key || deltaFavorList[targetActor.Key] == 0)
				{
					continue;
				}
				int targetId = targetActor.Value.GetId();
				if (charId != targetId)
				{
					if (!result.ContainsKey(charId))
					{
						result.Add(charId, new Dictionary<int, int>());
					}
					if (!result[charId].ContainsKey(targetId))
					{
						result[charId].Add(targetId, 0);
					}
					result[charId][targetId] += deltaFavorList[3];
				}
			}
			if (deltaFavorList[3] != 0 && charId != sourceCharId && sourceCharId != -1)
			{
				if (!result.ContainsKey(charId))
				{
					result.Add(charId, new Dictionary<int, int>());
				}
				if (!result[charId].ContainsKey(sourceCharId))
				{
					result[charId].Add(sourceCharId, 0);
				}
				result[charId][sourceCharId] += deltaFavorList[3];
			}
		}
		foreach (KeyValuePair<GameData.Domains.Character.Character, int> item in relatedCharList)
		{
			int charId2 = item.Key.GetId();
			List<int> deltaFavorList2 = CalFinalDeltaFavorabilityOfRelatedCharacters_WithRelationIndex(item.Key, item.Value);
			foreach (KeyValuePair<int, GameData.Domains.Character.Character> actor2 in _activeActorList)
			{
				int targerId = actor2.Value.GetId();
				if (charId2 == targerId)
				{
					continue;
				}
				int deltaFavor = deltaFavorList2[actor2.Key];
				if (deltaFavor != 0)
				{
					if (!result.ContainsKey(charId2))
					{
						result.Add(charId2, new Dictionary<int, int>());
					}
					if (!result[charId2].ContainsKey(targerId))
					{
						result[charId2].Add(targerId, 0);
					}
					result[charId2][targerId] += deltaFavor;
				}
			}
			if (deltaFavorList2[3] != 0 && charId2 != sourceCharId && sourceCharId != -1)
			{
				if (!result.ContainsKey(charId2))
				{
					result.Add(charId2, new Dictionary<int, int>());
				}
				if (!result[charId2].ContainsKey(sourceCharId))
				{
					result[charId2].Add(sourceCharId, 0);
				}
				result[charId2][sourceCharId] += deltaFavorList2[3];
			}
		}
		List<InformationDomain.SecretInformationFavorChangeItem> finalResult = new List<InformationDomain.SecretInformationFavorChangeItem>();
		Dictionary<int, int> relatedIdList = relatedCharList.ToDictionary((KeyValuePair<GameData.Domains.Character.Character, int> x) => x.Key.GetId(), (KeyValuePair<GameData.Domains.Character.Character, int> x) => x.Value);
		foreach (KeyValuePair<int, Dictionary<int, int>> item2 in result)
		{
			sbyte basePriority = 0;
			if (_actorIdList.Contains(item2.Key))
			{
				basePriority += 10;
			}
			if (item2.Key == _argList[5])
			{
				basePriority += 10;
			}
			if (DomainManager.Taiwu.IsInGroup(item2.Key))
			{
				basePriority += 5;
			}
			if (relatedIdList.TryGetValue(item2.Key, out var value) && value != 0)
			{
				basePriority += 4;
			}
			foreach (KeyValuePair<int, int> item3 in item2.Value)
			{
				sbyte priority = 0;
				if (item3.Key == _argList[5])
				{
					priority += 15;
				}
				finalResult.Add(new InformationDomain.SecretInformationFavorChangeItem(item2.Key, item3.Key, item3.Value, (sbyte)(basePriority + priority)));
			}
		}
		return finalResult;
	}

	public List<InformationDomain.SecretInformationStartEnemyRelationItem> GetAllSecretInformationStartEnemyRelationItems(int sourceCharId)
	{
		Dictionary<GameData.Domains.Character.Character, int> relatedCharList = GetAllSecretInformationRelatedCharacters_WithTuringTestAndRelationIndex(includeActors: true);
		List<InformationDomain.SecretInformationStartEnemyRelationItem> result = new List<InformationDomain.SecretInformationStartEnemyRelationItem>();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (KeyValuePair<GameData.Domains.Character.Character, int> related in relatedCharList)
		{
			int charId = related.Key.GetId();
			foreach (KeyValuePair<int, GameData.Domains.Character.Character> actor in _activeActorList)
			{
				int targetId = actor.Value.GetId();
				if (charId != targetId && charId != taiwuId)
				{
					byte odds = GetStartEnemyRelationOdds(actor.Key, related.Value);
					InformationDomain.SecretInformationStartEnemyRelationItem item = new InformationDomain.SecretInformationStartEnemyRelationItem(GetSecretInformationTemplateId(), charId, targetId, odds);
					result.Add(item);
				}
			}
			if (charId != sourceCharId && sourceCharId != -1 && charId != taiwuId)
			{
				byte odds2 = GetStartEnemyRelationOdds(3, related.Value);
				InformationDomain.SecretInformationStartEnemyRelationItem item2 = new InformationDomain.SecretInformationStartEnemyRelationItem(GetSecretInformationTemplateId(), charId, sourceCharId, odds2);
				result.Add(item2);
			}
		}
		return result;
	}

	private byte GetStartEnemyRelationOdds(int actorKey, int relatedValue)
	{
		List<byte> odds;
		switch (actorKey)
		{
		case 0:
			odds = _effectConfig.StartEnemyRelationOddsToActor;
			break;
		case 1:
			odds = _effectConfig.StartEnemyRelationOddsToReactor;
			break;
		case 2:
			odds = _effectConfig.StartEnemyRelationOddsToSecactor;
			break;
		case 3:
			odds = _effectConfig.StartEnemyRelationOddsToSource;
			break;
		default:
			odds = new List<byte>();
			LogInfo($"wrong actorKey: {actorKey}");
			break;
		}
		if ((uint)(relatedValue - 1) <= 8u)
		{
			return odds[relatedValue - 1];
		}
		return 0;
	}

	public List<InformationDomain.SecretInformationHappinessChangeItem> GetAllSecretInformationHappinessChange()
	{
		Dictionary<int, int> result = new Dictionary<int, int>();
		Dictionary<GameData.Domains.Character.Character, int> relatedCharList = GetAllSecretInformationRelatedCharacters_WithTuringTestAndRelationIndex();
		if (relatedCharList == null)
		{
			return new List<InformationDomain.SecretInformationHappinessChangeItem>();
		}
		Dictionary<int, GameData.Domains.Character.Character> actorList = GetActiveActorList_WithRelationIndex();
		foreach (KeyValuePair<int, GameData.Domains.Character.Character> actor in actorList)
		{
			sbyte deltaHappiness = CalDeltaHappinessOfRelatedCharacters_WithRelationIndex(actor.Key);
			if (deltaHappiness != 0)
			{
				int charId = actor.Value.GetId();
				if (!result.ContainsKey(charId))
				{
					result.Add(charId, 0);
				}
				result[charId] += deltaHappiness;
			}
		}
		foreach (KeyValuePair<GameData.Domains.Character.Character, int> actor2 in relatedCharList)
		{
			sbyte deltaHappiness2 = CalDeltaHappinessOfRelatedCharacters_WithRelationIndex(actor2.Value);
			if (deltaHappiness2 != 0)
			{
				int charId2 = actor2.Key.GetId();
				if (!result.ContainsKey(charId2))
				{
					result.Add(charId2, 0);
				}
				result[charId2] += deltaHappiness2;
			}
		}
		List<InformationDomain.SecretInformationHappinessChangeItem> finalResult = new List<InformationDomain.SecretInformationHappinessChangeItem>();
		Dictionary<int, int> relatedIdList = relatedCharList.ToDictionary((KeyValuePair<GameData.Domains.Character.Character, int> x) => x.Key.GetId(), (KeyValuePair<GameData.Domains.Character.Character, int> x) => x.Value);
		foreach (KeyValuePair<int, int> item in result)
		{
			sbyte basePriority = 0;
			if (_actorIdList.Contains(item.Key))
			{
				basePriority += 10;
			}
			if (DomainManager.Taiwu.IsInGroup(item.Key))
			{
				basePriority += 5;
			}
			if (item.Key == _argList[5])
			{
				basePriority += 10;
			}
			if (relatedIdList.TryGetValue(item.Key, out var value) && value != 0)
			{
				basePriority += 4;
			}
			finalResult.Add(new InformationDomain.SecretInformationHappinessChangeItem(item.Key, item.Value, basePriority));
		}
		return finalResult;
	}

	public sbyte CalDeltaHappinessOfRelatedCharacters_WithRelationIndex(int relationIndex)
	{
		switch (relationIndex)
		{
		case 1:
			return _effectConfig.ActorHappinessDiffs[0];
		case 2:
		case 10:
		case 13:
			return _effectConfig.ActorHappinessDiffs[1];
		case 3:
			return _effectConfig.ActorHappinessDiffs[2];
		case 4:
			return _effectConfig.ReactorHappinessDiffs[0];
		case 5:
		case 11:
		case 14:
			return _effectConfig.ReactorHappinessDiffs[1];
		case 6:
			return _effectConfig.ReactorHappinessDiffs[2];
		case 7:
			return _effectConfig.SecactorHappinessDiffs[0];
		case 8:
		case 12:
		case 15:
			return _effectConfig.SecactorHappinessDiffs[1];
		case 9:
			return _effectConfig.SecactorHappinessDiffs[2];
		default:
			return 0;
		}
	}

	public List<InformationDomain.SecretInformationAlertnessChangeItem> GetAllSecretInformationAlertnessChangeItems(int sourceCharId)
	{
		Dictionary<GameData.Domains.Character.Character, int> relatedCharList = GetAllSecretInformationRelatedCharacters_WithTuringTestAndRelationIndex(includeActors: true);
		List<InformationDomain.SecretInformationAlertnessChangeItem> result = new List<InformationDomain.SecretInformationAlertnessChangeItem>();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		short templateId = GetSecretInformationTemplateId();
		foreach (KeyValuePair<GameData.Domains.Character.Character, int> related in relatedCharList)
		{
			int relatedCharId = related.Key.GetId();
			if (relatedCharId == taiwuId)
			{
				continue;
			}
			if (sourceCharId == taiwuId)
			{
				int alertnessEffect = GetAlertnessEffect(3, related.Value);
				if (alertnessEffect != 0)
				{
					InformationDomain.SecretInformationAlertnessChangeItem item = new InformationDomain.SecretInformationAlertnessChangeItem(templateId, relatedCharId, alertnessEffect);
					result.Add(item);
				}
				continue;
			}
			foreach (KeyValuePair<int, GameData.Domains.Character.Character> actor in _activeActorList)
			{
				int actorId = actor.Value.GetId();
				if (relatedCharId != actorId && relatedCharId != taiwuId && actorId == taiwuId)
				{
					int alertnessEffect2 = GetAlertnessEffect(actor.Key, related.Value);
					if (alertnessEffect2 != 0)
					{
						InformationDomain.SecretInformationAlertnessChangeItem item2 = new InformationDomain.SecretInformationAlertnessChangeItem(templateId, relatedCharId, alertnessEffect2);
						result.Add(item2);
					}
				}
			}
		}
		return result;
	}

	private int GetAlertnessEffect(int actorKey, int relatedValue)
	{
		List<Config.ShortList> odds;
		if (actorKey == 0)
		{
			odds = _effectConfig.AlertnessEffectToActor;
		}
		else if (actorKey == 1 || actorKey == 2)
		{
			odds = _effectConfig.AlertnessEffectToReactor;
		}
		else if (actorKey == 3)
		{
			odds = _effectConfig.AlertnessEffectToSource;
		}
		else
		{
			odds = new List<Config.ShortList>();
			AdaptableLog.Info($"wrong actorKey: {actorKey}");
		}
		if ((uint)(relatedValue - 1) <= 8u)
		{
			return odds.GetOrDefault(0)?.DataList[relatedValue - 1] ?? 0;
		}
		return 0;
	}

	public List<short> GetActorFameRecord_WithActorIndex(int actorIndex, bool includeDeath = false)
	{
		if ((actorIndex < 0 || actorIndex > 2) ? true : false)
		{
			return new List<short>();
		}
		if (!includeDeath && !_activeActorList.TryGetValue(actorIndex, out var _))
		{
			return new List<short>();
		}
		List<(short, sbyte)> result = new List<(short, sbyte)>();
		if (1 == 0)
		{
		}
		List<Config.ShortList> list = actorIndex switch
		{
			0 => _effectConfig.ActorFameApplyCondition, 
			1 => _effectConfig.ReactorFameApplyCondition, 
			2 => _effectConfig.SeactorFameApplyCondition, 
			_ => throw new Exception($"actorIndex impossible to other case {actorIndex}"), 
		};
		if (1 == 0)
		{
		}
		IReadOnlyList<Config.ShortList> fameItemCondition = list;
		if (1 == 0)
		{
		}
		list = actorIndex switch
		{
			0 => _effectConfig.ActorFameApplyContent, 
			1 => _effectConfig.ReactorFameApplyContent, 
			2 => _effectConfig.SecactorFameApplyContent, 
			_ => throw new Exception($"actorIndex impossible to other case {actorIndex}"), 
		};
		if (1 == 0)
		{
		}
		IReadOnlyList<Config.ShortList> fameItemContent = list;
		foreach (List<short> conditionItem in fameItemCondition.Select((Config.ShortList shortList) => shortList.DataList))
		{
			if (conditionItem.Count < 2)
			{
				continue;
			}
			short fameKey = conditionItem[0];
			if (fameKey < 0)
			{
				continue;
			}
			bool conditionMet;
			short reasonKey;
			if (conditionItem[1] == 54)
			{
				int checkTargetIndex = GetArgIndexByRelationConfigDefKey(conditionItem[2]);
				conditionMet = CalSectPunishLevel_WithActorIndex(checkTargetIndex, out reasonKey) >= 0;
			}
			else
			{
				conditionMet = ConditionBoxEntrance(conditionItem, 1, -1, convertRelationDefKeyToArgIndex: true);
			}
			if (!conditionMet)
			{
				continue;
			}
			sbyte fameType = -1;
			int fameLevel = 1;
			foreach (List<short> contentItem in fameItemContent.Select((Config.ShortList shortList) => shortList.DataList))
			{
				if (fameKey != contentItem[0])
				{
					continue;
				}
				if (contentItem.Count > 2)
				{
					fameLevel = contentItem[2];
					if (fameKey == 82)
					{
						PunishmentSeverityItem punishmentSeverity = PunishmentSeverity.Instance.GetItem(CalSectPunishLevel_WithActorIndex(actorIndex, out reasonKey));
						if (punishmentSeverity != null)
						{
							fameLevel *= punishmentSeverity.FameActionFactorInPunish;
						}
					}
				}
				int index = GetArgIndexByRelationConfigDefKey(contentItem[1]);
				if (index > 0 && index < _argList.Count)
				{
					fameType = GetFameTypeSafe(_argList[index]);
				}
			}
			for (int c = 0; c < fameLevel; c++)
			{
				result.Add((fameKey, fameType));
			}
		}
		List<short> finalResult = new List<short>();
		foreach (var item in result)
		{
			short fameKey2 = item.Item1;
			FameActionItem fameConfig = FameAction.Instance.GetItem(fameKey2);
			if (fameConfig == null)
			{
				continue;
			}
			if (fameConfig.HasJump && item.Item2 != -1)
			{
				fameKey2 = ((item.Item2 == 3 || item.Item2 == -2) ? fameConfig.NormalJumpId : ((item.Item2 >= 3) ? fameConfig.GoodJumpId : fameConfig.BadJumpId));
				fameConfig = FameAction.Instance.GetItem(fameKey2);
				if (fameConfig == null)
				{
					continue;
				}
			}
			finalResult.Add(fameKey2);
		}
		return finalResult;
	}

	public List<short> GetActorFameRecord_WithCharId(int charId, bool includeDeath = false)
	{
		if (!_actorIdList.Contains(charId))
		{
			return new List<short>();
		}
		int index = _argList.FindIndex((int x) => x == charId);
		return GetActorFameRecord_WithActorIndex(index, includeDeath);
	}

	public int IsActorFameRecordPositive_WithActorIndex(int actorIndex)
	{
		List<short> fameKeyList = GetActorFameRecord_WithActorIndex(actorIndex, includeDeath: true);
		short totalFame = 0;
		foreach (short fameKey in fameKeyList)
		{
			FameActionItem fameConfig = FameAction.Instance.GetItem(fameKey);
			if (fameConfig != null)
			{
				totalFame += fameConfig.Fame;
			}
		}
		return totalFame;
	}

	public int IsActorFameRecordPositive_WithCharId(int charId)
	{
		if (!_actorIdList.Contains(charId))
		{
			return 0;
		}
		int index = _argList.FindIndex((int x) => x == charId);
		return IsActorFameRecordPositive_WithActorIndex(index);
	}

	public short GetSecretInformationAppliedStructs(IRandomSource random, GameData.Domains.Character.Character character, GameData.Domains.Character.Character taiwu)
	{
		short structId = -1;
		if (_infoConfig.StructGroupId == -1)
		{
			return structId;
		}
		List<int> taiwuIndexList = GetAllSecretInformationRelationsOfCharacter(taiwu.GetId(), includeLoveRelation: true, includeLeadership: false);
		List<int> charIndexList = GetAllSecretInformationRelationsOfCharacter(character.GetId(), includeLoveRelation: true, includeLeadership: false);
		List<(short, short, short[])> structIdList = (from s in SecretInformationAppliedStruct.Instance
			where s != null && s.GroupTemplateId == _infoConfig.StructGroupId && taiwuIndexList.Contains(s.TaiwuIndex) && charIndexList.Contains(s.CharIndex)
			select (TemplateId: s.TemplateId, RelationValue: s.RelationValue, BehaviorTypeValue: s.BehaviorTypeValue)).ToList();
		sbyte behaviorType = character.GetBehaviorType();
		if (structIdList.Count != 0)
		{
			if (structIdList.Count == 1)
			{
				return structIdList[0].Item1;
			}
			structId = structIdList.ElementAt(random.Next(0, structIdList.Count)).Item1;
			Dictionary<short, List<(short, short, short[])>> weightGroup = new Dictionary<short, List<(short, short, short[])>>();
			foreach (var item in structIdList)
			{
				if (!weightGroup.ContainsKey(item.Item2))
				{
					weightGroup.Add(item.Item2, new List<(short, short, short[])>());
				}
				weightGroup[item.Item2].Add(item);
			}
			short maxWeightId = weightGroup.Keys.Max();
			if (weightGroup[maxWeightId].Count != 0)
			{
				if (weightGroup[maxWeightId].Count == 1)
				{
					return weightGroup[maxWeightId][0].Item1;
				}
				structId = weightGroup[maxWeightId].ElementAt(random.Next(0, weightGroup[maxWeightId].Count)).Item1;
				List<short> structPool = new List<short>();
				short defaultWeight = (short)(100 / weightGroup[maxWeightId].Count);
				foreach (var item2 in weightGroup[maxWeightId])
				{
					short weight = item2.Item3[behaviorType];
					if (weight == -1)
					{
						weight = defaultWeight;
					}
					for (int i = 0; i < weight; i++)
					{
						structPool.Add(item2.Item1);
					}
				}
				if (structPool.Count != 0)
				{
					structId = structPool.ElementAt(EventHelper.GetRandom(0, structPool.Count));
				}
				else
				{
					LogInfo($"No Available Structs In BehaviorTypeValue Check! {_occurenceId} TemplateId:{_templateId}");
				}
			}
			else
			{
				LogInfo($"No Available Structs In RelationValue Check! {_occurenceId} TemplateId:{_templateId}");
			}
		}
		else
		{
			LogInfo($"No Available SecretInformationAppliedStructs! {_occurenceId} TemplateId:{_templateId}");
		}
		return structId;
	}

	public short GetContentIdAndSelections(IRandomSource random, short structId, GameData.Domains.Character.Character character, GameData.Domains.Character.Character taiwu, out List<short> selectionList, out short contentIndex)
	{
		short contentId = -1;
		contentIndex = -1;
		selectionList = new List<short>();
		SecretInformationAppliedStructItem structConfig = SecretInformationAppliedStruct.Instance.GetItem(structId);
		if (structConfig == null)
		{
			return contentId;
		}
		List<Config.ShortList> extraContentIds = structConfig.ExtraContentIds;
		List<Config.ShortList> keepCondition = structConfig.ActorSectPunishSpecialCondition;
		if (structConfig.ContentId2 != -1 && !ConditionIsPublished() && !DomainManager.Information.QuerySecretOccurence(_occurenceId).InBroadcast)
		{
			sbyte behaviorType = character.GetBehaviorType();
			short keepRateBase = CalBaseKeepRateBase(character.GetId(), behaviorType, keepCondition);
			sbyte favorLevel = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(character.GetId(), taiwu.GetId()));
			int keepRate = keepRateBase * (100 - (favorLevel - 20) * 20) / 100;
			if (random.Next(0, 100) < keepRate)
			{
				contentIndex = 2;
				contentId = structConfig.ContentId2;
			}
		}
		if (contentIndex == -1 && extraContentIds.Count > 0)
		{
			for (int i = 0; i < extraContentIds.Count; i++)
			{
				List<short> conditionItem = extraContentIds[i].DataList;
				if (conditionItem.Count >= 2 && ConditionBoxEntrance(conditionItem, 1, character.GetId()))
				{
					contentIndex = (short)(i + 3);
					contentId = conditionItem[0];
				}
			}
		}
		if (contentIndex == -1)
		{
			contentIndex = 1;
			contentId = structConfig.ContentId1;
		}
		List<short> selectionIdList = new List<short>();
		if (contentIndex > 2)
		{
			if (structConfig.ExtraSelections.Count() > contentIndex - 3)
			{
				selectionIdList = structConfig.ExtraSelections[contentIndex - 3].DataList;
			}
			else
			{
				LogInfo($"No Available ExtraSelections ! {_occurenceId} TemplateId:{_templateId} StructId:{structId}");
			}
		}
		else if (contentIndex == 2)
		{
			if (structConfig.Selection2 != null)
			{
				selectionIdList = structConfig.Selection2.ToList();
			}
			else
			{
				LogInfo($"No Available Selection For Keep ! {_occurenceId} TemplateId:{_templateId} StructId:{structId}");
			}
		}
		else if (structConfig.Selection1 != null)
		{
			selectionIdList = structConfig.Selection1.ToList();
		}
		else
		{
			LogInfo($"No Available Selection For Default! {_occurenceId} TemplateId:{_templateId} StructId:{structId}");
		}
		if (selectionIdList == null)
		{
			selectionIdList = new List<short>();
			LogInfo($"Fail To Get Selection! {_occurenceId} TemplateId:{_templateId} StructId:{structId}");
		}
		selectionIdList.RemoveAll((short x) => x < 0);
		selectionList = selectionIdList;
		return contentId;
	}

	private short CalBaseKeepRateBase(int charId, sbyte behaviorType, List<Config.ShortList> keepCondition)
	{
		short keepRate = 0;
		foreach (Config.ShortList item in keepCondition)
		{
			List<short> conditionItem = item.DataList;
			if (conditionItem.Count != 0)
			{
				short conditionKey = conditionItem[0];
				if (conditionKey == 0)
				{
					keepRate += SecretInformationEffect.Instance[_templateId].BaseSecretRate[behaviorType];
				}
				else if (ConditionBoxEntrance(conditionItem, 0, charId))
				{
					keepRate += SecretInformationSpecialCondition.Instance[conditionKey].RequestKeepSecretRate[behaviorType];
				}
			}
		}
		return keepRate;
	}

	public List<short> GetVisibleSelection(IEnumerable<short> selectionKeys, GameData.Domains.Character.Character character, GameData.Domains.Character.Character taiwu)
	{
		List<(short, short)> result = new List<(short, short)>();
		foreach (short id in selectionKeys)
		{
			if (id < 0)
			{
				continue;
			}
			SecretInformationAppliedSelectionItem selectionConfig = SecretInformationAppliedSelection.Instance.GetItem(id);
			if (selectionConfig == null)
			{
				continue;
			}
			if (selectionConfig.SpecialConditionId != null)
			{
				bool conditionCheck = true;
				foreach (Config.ShortList item in selectionConfig.SpecialConditionId)
				{
					List<short> conditionItem = item.DataList;
					if (conditionItem.Count != 0)
					{
						short conditionKey = conditionItem[0];
						if (conditionKey > 0 && !ConditionBoxEntrance(conditionItem, 0, character.GetId()))
						{
							conditionCheck = false;
							break;
						}
					}
				}
				if (!conditionCheck)
				{
					continue;
				}
			}
			if (selectionConfig.SpecialConditionId2 != null && selectionConfig.SpecialConditionId2.Count != 0)
			{
				bool conditionCheck2 = false;
				foreach (Config.ShortList item2 in selectionConfig.SpecialConditionId2)
				{
					List<short> conditionItem2 = item2.DataList;
					if (conditionItem2.Count == 0)
					{
						conditionCheck2 = true;
						break;
					}
					short conditionKey2 = conditionItem2[0];
					if (conditionKey2 <= 0)
					{
						conditionCheck2 = true;
						break;
					}
					if (ConditionBoxEntrance(conditionItem2, 0, character.GetId()))
					{
						conditionCheck2 = true;
						break;
					}
				}
				if (!conditionCheck2)
				{
					continue;
				}
			}
			sbyte taiwuFame = taiwu.GetFameType();
			sbyte charFame = character.GetFameType();
			sbyte[] fameConditions = selectionConfig.FameConditions;
			if (fameConditions == null || SelectionFameCheck(new List<sbyte>
			{
				taiwuFame,
				charFame,
				(sbyte)((fameConditions[2] == -1) ? (-1) : GetFameTypeSafe(_argList[1])),
				(sbyte)((fameConditions[3] == -1) ? (-1) : GetFameTypeSafe(_argList[3]))
			}, fameConditions))
			{
				short priority = selectionConfig.Priority;
				if (priority < 0)
				{
					priority = short.MaxValue;
				}
				result.Add((id, priority));
			}
		}
		return (from x in result
			orderby x.Priority, x.templateId
			select x.templateId).ToList();
	}

	private bool SelectionFameCheck(List<sbyte> fameTypes, sbyte[] fameCondition)
	{
		for (int i = 0; i < fameCondition.Length; i++)
		{
			if (fameCondition[i] == -1)
			{
				continue;
			}
			if (fameTypes[i] == -1)
			{
				return false;
			}
			switch (fameCondition[i])
			{
			case 0:
				if (!FameType.IsNonNegative(fameTypes[i]))
				{
					break;
				}
				return false;
			case 1:
				if (FameType.IsNonNegative(fameTypes[i]))
				{
					break;
				}
				return false;
			}
		}
		return true;
	}

	private short GetResultIdOfSelection(short selectionId, GameData.Domains.Character.Character character, GameData.Domains.Character.Character taiwu)
	{
		SecretInformationAppliedSelectionItem selectionConfig = SecretInformationAppliedSelection.Instance.GetItem(selectionId);
		sbyte behaviorType = EventHelper.GetRoleBehavior(character);
		sbyte requiredFavor = selectionConfig.Result2FavorabilityTypeCondition[behaviorType];
		if (EventHelper.GetFavorabilityType(character, taiwu) < requiredFavor)
		{
			return selectionConfig.ResultId2;
		}
		return selectionConfig.ResultId1;
	}

	public sbyte CalSectPunishLevel_WithCharId(int charId, bool calRealLevel = false)
	{
		if (!_actorIdList.Contains(charId))
		{
			return -1;
		}
		int charIndex = _argList.FindIndex((int a) => a == charId);
		short reasonKey;
		return CalSectPunishLevel_WithActorIndex(charIndex, out reasonKey, calRealLevel);
	}

	internal sbyte CalcSectPunishLevelWithSpecificOrganization(int charIndex, out short reasonKey, OrganizationInfo organizationInfo)
	{
		reasonKey = -1;
		OrganizationItem orgConfig = Config.Organization.Instance.GetItem(organizationInfo.OrgTemplateId);
		if (orgConfig == null)
		{
			return -1;
		}
		bool orgIsSect = orgConfig.IsSect;
		List<Config.ShortList> freeCondition;
		List<Config.ShortList> baseLevel;
		List<Config.ShortList> baseCondition;
		List<Config.ShortList> specialCondition;
		List<Config.ShortList> specialLevel;
		switch (charIndex)
		{
		case 0:
			freeCondition = (orgIsSect ? _sectPunishConfig.ActorSectPunishFreeCondition : _sectPunishConfig.ActorCityPunishFreeCondition);
			baseLevel = (orgIsSect ? _sectPunishConfig.ActorSectPunishBase : _sectPunishConfig.ActorCityPunishBase);
			baseCondition = (orgIsSect ? _sectPunishConfig.ActorSectPunishCondition : _sectPunishConfig.ActorCityPunishCondition);
			specialCondition = (orgIsSect ? _sectPunishConfig.ActorSectPunishSpecialCondition : _sectPunishConfig.ActorCityPunishSpecialCondition);
			specialLevel = (orgIsSect ? _sectPunishConfig.ActorSectPunishSpecial : _sectPunishConfig.ActorCityPunishSpecial);
			break;
		case 1:
			freeCondition = (orgIsSect ? _sectPunishConfig.ReactorSectPunishFreeCondition : _sectPunishConfig.ReactorCityPunishFreeCondition);
			baseLevel = (orgIsSect ? _sectPunishConfig.ReactorSectPunishBase : _sectPunishConfig.ReactorCityPunishBase);
			baseCondition = (orgIsSect ? _sectPunishConfig.ReactorSectPunishCondition : _sectPunishConfig.ReactorCityPunishCondition);
			specialCondition = (orgIsSect ? _sectPunishConfig.ReactorSectPunishSpecialCondition : _sectPunishConfig.ReactorCityPunishSpecialCondition);
			specialLevel = (orgIsSect ? _sectPunishConfig.ReactorSectPunishSpecial : _sectPunishConfig.ReactorCityPunishSpecial);
			break;
		case 2:
			freeCondition = (orgIsSect ? _sectPunishConfig.SecactorSectPunishFreeCondition : _sectPunishConfig.SecactorCityPunishFreeCondition);
			baseLevel = (orgIsSect ? _sectPunishConfig.SecactorSectPunishBase : _sectPunishConfig.SecactorCityPunishBase);
			baseCondition = (orgIsSect ? _sectPunishConfig.SecactorSectPunishCondition : _sectPunishConfig.SecactorCityPunishCondition);
			specialCondition = (orgIsSect ? _sectPunishConfig.SecactorSectPunishSpecialCondition : _sectPunishConfig.SecactorCityPunishSpecialCondition);
			specialLevel = (orgIsSect ? _sectPunishConfig.SecactorSectPunishSpecial : _sectPunishConfig.SecactorCityPunishSpecial);
			break;
		default:
			return -1;
		}
		foreach (Config.ShortList freeItem in freeCondition)
		{
			List<short> condition = freeItem.DataList;
			if (condition.Count < 1 || !ConditionBoxEntrance(condition))
			{
				continue;
			}
			return -1;
		}
		if (specialCondition != null && specialCondition.Count > 0)
		{
			for (int i = 0; i < specialCondition.Count; i++)
			{
				List<short> condition2 = specialCondition[i].DataList;
				if (condition2.Count < 1 || !ConditionBoxEntrance(condition2))
				{
					continue;
				}
				if (specialLevel.Count > i)
				{
					List<short> punish = specialLevel[i].DataList;
					if (!punish.CheckIndex(0))
					{
						LogWarning("Error in Punish SpecialLevel!");
						return -1;
					}
					sbyte curLevel = CalcPunishLevelByPunishmentType(punish[0], organizationInfo.SettlementId);
					if (curLevel >= 0)
					{
						reasonKey = specialLevel[i].DataList[0];
						return GetCustomizedPunishmentSeverity(reasonKey, curLevel, organizationInfo.OrgTemplateId);
					}
				}
				else
				{
					LogWarning("Error in Punish SpecialLevel Count!");
				}
			}
		}
		if (baseCondition != null && baseCondition.Count > 0 && baseLevel != null)
		{
			for (int j = 0; j < baseCondition.Count; j++)
			{
				List<short> condition3 = baseCondition[j].DataList;
				if (condition3.Count < 1 || !ConditionBoxEntrance(condition3))
				{
					continue;
				}
				if (baseLevel.Count > j)
				{
					List<short> punish2 = baseLevel[j].DataList;
					if (!punish2.CheckIndex(0))
					{
						LogWarning("Error in Punish BaseLevel!");
						return -1;
					}
					sbyte curLevel2 = CalcPunishLevelByPunishmentType(punish2[0], organizationInfo.SettlementId);
					if (curLevel2 < 0)
					{
						return curLevel2;
					}
					if (baseLevel.CheckIndex(j))
					{
						reasonKey = baseLevel[j].DataList[0];
					}
					return GetCustomizedPunishmentSeverity(reasonKey, curLevel2, organizationInfo.OrgTemplateId);
				}
				LogWarning("Error in Base SpecialLevel Count!");
			}
		}
		return -1;
	}

	internal sbyte GetCustomizedPunishmentSeverity(short punishmentTypeTemplateId, sbyte punishmentSeverity, sbyte orgTemplateId)
	{
		if (punishmentTypeTemplateId < 0)
		{
			return punishmentSeverity;
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		if (settlement != null)
		{
			PunishmentTypeItem punishmentTypeCfg = PunishmentType.Instance[punishmentTypeTemplateId];
			punishmentSeverity = settlement.GetPunishmentTypeSeverity(punishmentTypeCfg);
		}
		return punishmentSeverity;
	}

	internal sbyte CalcPunishLevelByPunishmentType(short punishmentTypeTemplateId, short settlementId)
	{
		PunishmentTypeItem punishment = PunishmentType.Instance.GetItem(punishmentTypeTemplateId);
		if (punishment != null && settlementId >= 0)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			OrganizationItem orgConfig = Config.Organization.Instance.GetItem(settlement.GetOrgTemplateId());
			return punishment.GetSeverity(DomainManager.Map.GetStateTemplateIdByAreaId(settlement.GetLocation().AreaId), orgConfig?.IsSect ?? false);
		}
		return -1;
	}

	public sbyte CalSectPunishLevel_WithActorIndex(int charIndex, out short reasonKey, bool calRealLevel = false)
	{
		reasonKey = -1;
		if (charIndex < 0 || charIndex > 2 || charIndex >= _argList.Count)
		{
			return -1;
		}
		int actorId = _argList[charIndex];
		if (actorId == -1)
		{
			return -1;
		}
		OrganizationInfo organization = GetSectInfoSafe(actorId);
		if (!calRealLevel)
		{
			int orgIndex = -1;
			if (!CheckCanBePunished(actorId, ref orgIndex, out var _))
			{
				return -1;
			}
		}
		return CalcSectPunishLevelWithSpecificOrganization(charIndex, out reasonKey, organization);
	}

	public sbyte CalcTaiwuPunishLevel(int taiwuCharId, out short reasonKey, out OrganizationInfo organizationInfo)
	{
		reasonKey = -1;
		organizationInfo = OrganizationInfo.None;
		int taiwuCharIndex = -1;
		for (int i = 0; i <= 2; i++)
		{
			if (_argList.CheckIndex(i))
			{
				int charId = _argList[i];
				if (taiwuCharId == charId)
				{
					taiwuCharIndex = i;
				}
			}
		}
		if (taiwuCharIndex < 0)
		{
			return -1;
		}
		List<Config.ShortList> freeCondition;
		List<Config.ShortList> baseLevel;
		List<Config.ShortList> baseCondition;
		List<Config.ShortList> specialCondition;
		List<Config.ShortList> specialLevel;
		switch (taiwuCharIndex)
		{
		case 0:
			freeCondition = _sectPunishConfig.ActorTaiwuPunishFreeCondition;
			baseLevel = _sectPunishConfig.ActorTaiwuPunishBase;
			baseCondition = _sectPunishConfig.ActorTaiwuPunishCondition;
			specialCondition = _sectPunishConfig.ActorTaiwuPunishSpecialCondition;
			specialLevel = _sectPunishConfig.ActorTaiwuPunishSpecial;
			break;
		case 1:
			freeCondition = _sectPunishConfig.ReactorTaiwuPunishFreeCondition;
			baseLevel = _sectPunishConfig.ReactorTaiwuPunishBase;
			baseCondition = _sectPunishConfig.ReactorTaiwuPunishCondition;
			specialCondition = _sectPunishConfig.ReactorTaiwuPunishSpecialCondition;
			specialLevel = _sectPunishConfig.ReactorTaiwuPunishSpecial;
			break;
		case 2:
			freeCondition = _sectPunishConfig.SecactorTaiwuPunishFreeCondition;
			baseLevel = _sectPunishConfig.SecactorTaiwuPunishBase;
			baseCondition = _sectPunishConfig.SecactorTaiwuPunishCondition;
			specialCondition = _sectPunishConfig.SecactorTaiwuPunishSpecialCondition;
			specialLevel = _sectPunishConfig.SecactorTaiwuPunishSpecial;
			break;
		default:
			return -1;
		}
		for (int charIndex = 0; charIndex < _argList.Count; charIndex++)
		{
			int charId2 = _argList[charIndex];
			if (charId2 == taiwuCharId)
			{
				continue;
			}
			organizationInfo = GetSectInfoSafe(charId2);
			if (organizationInfo.OrgTemplateId < 0)
			{
				GameData.Domains.Character.Character character;
				if (DomainManager.Character.TryGetDeadCharacter(charId2, out var deadCharacter))
				{
					organizationInfo = deadCharacter.OrganizationInfo;
				}
				else if (DomainManager.Character.TryGetElement_Objects(charId2, out character))
				{
					organizationInfo = character.GetOrganizationInfo();
				}
			}
			OrganizationItem orgConfig = Config.Organization.Instance.GetItem(organizationInfo.OrgTemplateId);
			if (orgConfig == null)
			{
				continue;
			}
			if (orgConfig.IsSect)
			{
				Location settlementLocation = DomainManager.Organization.GetSettlement(organizationInfo.SettlementId).GetLocation();
				if (settlementLocation.IsValid())
				{
					sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlementLocation.AreaId);
					MapStateItem stateCfg = MapState.Instance[stateTemplateId];
					MapAreaItem mainAreaCfg = MapArea.Instance.GetItem(stateCfg.MainAreaID);
					Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(mainAreaCfg.OrganizationId[0]);
					if (settlement != null)
					{
						orgConfig = Config.Organization.Instance.GetItem(settlement.GetOrgTemplateId());
					}
				}
			}
			bool orgIsSect = orgConfig.IsSect;
			foreach (Config.ShortList freeItem in freeCondition)
			{
				List<short> condition = freeItem.DataList;
				if (condition.Count < 1 || !ConditionBoxEntrance(condition))
				{
					continue;
				}
				return -1;
			}
			if (orgIsSect && specialCondition.Count > 0)
			{
				for (int j = 0; j < specialCondition.Count; j++)
				{
					List<short> condition2 = specialCondition[j].DataList;
					if (condition2.Count < 1 || !ConditionBoxEntrance(condition2))
					{
						continue;
					}
					if (specialLevel.Count > j)
					{
						List<short> punish = specialLevel[j].DataList;
						if (!punish.CheckIndex(0))
						{
							LogWarning("Error in Punish SpecialLevel!");
							return -1;
						}
						sbyte curLevel = CalcPunishLevelByPunishmentType(punish[0], organizationInfo.SettlementId);
						if (curLevel < 0)
						{
							return curLevel;
						}
						reasonKey = specialLevel[j].DataList[0];
						return GetCustomizedPunishmentSeverity(reasonKey, curLevel, organizationInfo.OrgTemplateId);
					}
					LogWarning("Error in Punish SpecialLevel Count!");
				}
			}
			if (baseCondition == null || baseCondition.Count <= 0)
			{
				continue;
			}
			for (int k = 0; k < baseCondition.Count; k++)
			{
				List<short> condition3 = baseCondition[k].DataList;
				if (condition3.Count >= 1 && ConditionBoxEntrance(condition3) && baseLevel.Count > k)
				{
					List<short> punish2 = baseLevel[k].DataList;
					if (!punish2.CheckIndex(0))
					{
						LogWarning("Error in Punish BaseLevel!");
						return -1;
					}
					sbyte curLevel2 = CalcPunishLevelByPunishmentType(punish2[0], organizationInfo.SettlementId);
					if (curLevel2 < 0)
					{
						return curLevel2;
					}
					if (baseLevel.CheckIndex(k))
					{
						reasonKey = baseLevel[k].DataList[0];
					}
					return GetCustomizedPunishmentSeverity(reasonKey, curLevel2, organizationInfo.OrgTemplateId);
				}
			}
		}
		return -1;
	}

	public bool CheckCanBePunished(int actorId, ref int orgIndex, out bool isSect)
	{
		isSect = false;
		if (!DomainManager.Character.TryGetElement_Objects(actorId, out var actorChar))
		{
			return false;
		}
		if (!InformationDomain.CheckTuringTest(actorChar))
		{
			return false;
		}
		OrganizationInfo curActorOrgInfo = actorChar.GetOrganizationInfo();
		if (curActorOrgInfo.OrgTemplateId < 0)
		{
			return false;
		}
		OrganizationItem curActorOrgConfig = Config.Organization.Instance[curActorOrgInfo.OrgTemplateId];
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(actorId);
		if (oriActorOrgInfo.OrgTemplateId == -1)
		{
			return false;
		}
		if (curActorOrgConfig.IsSect)
		{
			isSect = true;
			orgIndex = oriActorOrgInfo.OrgTemplateId - 1;
		}
		else
		{
			orgIndex = oriActorOrgInfo.OrgTemplateId - 21;
		}
		if (curActorOrgInfo.OrgTemplateId == oriActorOrgInfo.OrgTemplateId)
		{
			return true;
		}
		return false;
	}

	internal int GetArgIndexByRelationConfigDefKey(short relationDefKey)
	{
		if (1 == 0)
		{
		}
		int result = relationDefKey switch
		{
			0 => -1, 
			1 => 0, 
			4 => 1, 
			7 => 2, 
			19 => 4, 
			-1 => -1, 
			_ => throw new Exception($"unsupported relation reference in secret fame condition: {relationDefKey}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public bool ConditionBoxEntrance(List<short> conditionItem, int conditionKeyIndex = 0, int extraId = -1, bool convertRelationDefKeyToArgIndex = false)
	{
		if (conditionItem.Count <= conditionKeyIndex)
		{
			return false;
		}
		short conditionKey = conditionItem[conditionKeyIndex];
		short num = conditionKey;
		short num2 = num;
		if (num2 >= 0)
		{
			if (num2 == 0)
			{
				return true;
			}
			List<int> charIdList = new List<int>();
			List<int> curArgList = new List<int>(_argList);
			if (curArgList.Count > 3)
			{
				curArgList[3] = extraId;
			}
			for (int i = conditionKeyIndex + 1; i < conditionItem.Count; i++)
			{
				int currentCharIndex = conditionItem[i];
				if (convertRelationDefKeyToArgIndex)
				{
					currentCharIndex = GetArgIndexByRelationConfigDefKey((short)currentCharIndex);
				}
				charIdList.Add((currentCharIndex >= 0 && currentCharIndex < curArgList.Count) ? curArgList[currentCharIndex] : currentCharIndex);
			}
			return ConditionBox(conditionKey, (charIdList.Count > 0) ? charIdList[0] : (-1), (charIdList.Count > 1) ? charIdList[1] : (-1), (charIdList.Count > 2) ? charIdList[2] : (-1), (charIdList.Count > 3) ? charIdList[3] : (-1));
		}
		return false;
	}

	public bool ConditionBox(short conditionKey, int actorId = -1, int reactorId = -1, int secactorId = -1, int extraId = -1)
	{
		SecretInformationSpecialConditionItem condition = SecretInformationSpecialCondition.Instance.GetItem(conditionKey);
		if (condition == null)
		{
			return false;
		}
		ESecretInformationSpecialConditionCalculate calculate = condition.Calculate;
		if (1 == 0)
		{
		}
		bool result = calculate switch
		{
			ESecretInformationSpecialConditionCalculate.SameSect => ConditionSameSect(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.SectJustice => ConditionSectJustice(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.SectBecomeEnemy => ConditionSectBecomeEnemy(actorId, reactorId, secactorId), 
			ESecretInformationSpecialConditionCalculate.ForbidMarriage => ConditionForbidMarriage(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.IsPublished => ConditionIsPublished(), 
			ESecretInformationSpecialConditionCalculate.IsRevealed => ConditionIsRevealed(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.IsRevealedSingle => ConditionIsRevealedSingle(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.HasCouple => ConditionHasCouple(actorId), 
			ESecretInformationSpecialConditionCalculate.NotFame => ConditionNotFame(actorId), 
			ESecretInformationSpecialConditionCalculate.IsMonk => ConditionIsMonk(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.ForbidWine => ConditionForbidWine(actorId), 
			ESecretInformationSpecialConditionCalculate.ForbidPoison => ConditionForbidPoison(actorId), 
			ESecretInformationSpecialConditionCalculate.ForbidItem => ConditionForbidItem(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.HasLove => ConditionHasLove(actorId, reactorId, secactorId), 
			ESecretInformationSpecialConditionCalculate.IsKidnapped => ConditionIsKidnapped(actorId, reactorId, secactorId), 
			ESecretInformationSpecialConditionCalculate.CompareCombatPoint => ConditionCompareCombatPoint(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.HasRelation => ConditionHasRelation(actorId, reactorId, secactorId, extraId), 
			ESecretInformationSpecialConditionCalculate.ActorAlive => ConditionActorAlive(actorId, reactorId), 
			ESecretInformationSpecialConditionCalculate.CasualtyInSect => ConditionCasualtyInSect(actorId), 
			ESecretInformationSpecialConditionCalculate.KillFameLine => ConditionKillFameLine(actorId, condition.CalcFameLine), 
			ESecretInformationSpecialConditionCalculate.KidnapFameLine => ConditionKidnapFameLine(actorId, condition.CalcFameLine), 
			ESecretInformationSpecialConditionCalculate.AlliedSectMember => ConditionAlliedSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.BeLoverSectMember => ConditionBeLoverSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.BeKyodaiSectMember => ConditionBeKyodaiSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.GainParentSectMember => ConditionGainParentSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.GainChildSectMember => ConditionGainChildSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.DateSectMember => ConditionDateSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.ReFoundChildSectMember => ConditionReFoundChildSectMember(actorId, condition.CalcOrganization), 
			ESecretInformationSpecialConditionCalculate.BanSexualMate => ConditionBanSexualMate(actorId, condition.CalcSexualMateCase, condition.CalcSexualMateRule, condition.CalcSectRule), 
			ESecretInformationSpecialConditionCalculate.BanEating => ConditionBanEating(condition.CalcSectRule), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private bool ConditionSameSect(int actorId, int reactorId)
	{
		if (actorId == -1 || reactorId == -1)
		{
			return false;
		}
		OrganizationInfo actorSectInfo = GetSectInfoSafe(actorId);
		if (actorSectInfo.OrgTemplateId == -1)
		{
			return false;
		}
		OrganizationItem actorOrgConfig = Config.Organization.Instance[actorSectInfo.OrgTemplateId];
		if (!actorOrgConfig.IsSect)
		{
			return false;
		}
		return GetSectInfoSafe(reactorId).OrgTemplateId == actorSectInfo.OrgTemplateId;
	}

	private bool ConditionSectJustice(int actorId, int reactorId)
	{
		if (actorId == -1 || reactorId == -1)
		{
			return false;
		}
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(actorId);
		if (oriActorOrgInfo.OrgTemplateId == -1)
		{
			return false;
		}
		if (GetSectInfoSafe(reactorId).SettlementId == oriActorOrgInfo.SettlementId)
		{
			return false;
		}
		OrganizationItem oriActorOrgConfig = Config.Organization.Instance[oriActorOrgInfo.OrgTemplateId];
		if (!oriActorOrgConfig.IsSect)
		{
			return false;
		}
		sbyte fameTypeOfReactor = GetFameTypeSafe(reactorId);
		sbyte goodness = oriActorOrgConfig.Goodness;
		bool flag = (goodness == -1 && fameTypeOfReactor > 3) || (goodness == 1 && fameTypeOfReactor < 3 && fameTypeOfReactor >= 0);
		bool flag2 = flag;
		if (!flag2)
		{
			bool flag3 = goodness == 0;
			bool flag4 = flag3;
			if (flag4)
			{
				bool flag5 = ((fameTypeOfReactor == -2 || fameTypeOfReactor == 3) ? true : false);
				flag4 = flag5;
			}
			flag2 = flag4;
		}
		return flag2;
	}

	private bool ConditionSectBecomeEnemy(int actorId, int reactorId, int seactorId)
	{
		bool actorResult = false;
		bool reactorResult = false;
		if (actorId != -1 && reactorId != -1)
		{
			OrganizationInfo actorSectInfo = GetSectInfoSafe(actorId);
			OrganizationInfo reactorSectInfo = GetSectInfoSafe(reactorId);
			actorResult = actorSectInfo.OrgTemplateId != -1 && reactorSectInfo.OrgTemplateId != -1 && DomainManager.Organization.GetSectFavorability(actorSectInfo.OrgTemplateId, reactorSectInfo.OrgTemplateId) == -1;
		}
		if (seactorId != -1 && reactorId != -1)
		{
			OrganizationInfo secactorSectInfo = GetSectInfoSafe(seactorId);
			OrganizationInfo reactorSectInfo2 = GetSectInfoSafe(reactorId);
			reactorResult = secactorSectInfo.OrgTemplateId != -1 && reactorSectInfo2.OrgTemplateId != -1 && DomainManager.Organization.GetSectFavorability(reactorSectInfo2.OrgTemplateId, secactorSectInfo.OrgTemplateId) == -1;
		}
		return actorResult || reactorResult;
	}

	private bool ConditionForbidMarriage(int actorId, int reactorId = -1)
	{
		bool actorResult = false;
		bool reactorResult = false;
		int num;
		if (actorId != -1)
		{
			OrganizationInfo actorSectInfo = GetSectInfoSafe(actorId);
			if (actorSectInfo.OrgTemplateId != -1)
			{
				OrganizationMemberItem organizationMemberItem = OrganizationMember.Instance[Config.Organization.Instance[actorSectInfo.OrgTemplateId].Members[actorSectInfo.Grade]];
				if (organizationMemberItem != null)
				{
					sbyte[] childGrade = organizationMemberItem.ChildGrade;
					if (childGrade != null && childGrade.Length > 0)
					{
						num = (ConditionIsMonk(actorId) ? 1 : 0);
						goto IL_0076;
					}
				}
				num = 1;
				goto IL_0076;
			}
		}
		goto IL_0078;
		IL_0076:
		actorResult = (byte)num != 0;
		goto IL_0078;
		IL_00f8:
		return actorResult || reactorResult;
		IL_0078:
		int num2;
		if (reactorId != -1 && reactorId != actorId)
		{
			OrganizationInfo reactorSectInfo = GetSectInfoSafe(reactorId);
			if (reactorSectInfo.OrgTemplateId != -1)
			{
				OrganizationMemberItem organizationMemberItem = OrganizationMember.Instance[Config.Organization.Instance[reactorSectInfo.OrgTemplateId].Members[reactorSectInfo.Grade]];
				if (organizationMemberItem != null)
				{
					sbyte[] childGrade = organizationMemberItem.ChildGrade;
					if (childGrade != null && childGrade.Length > 0)
					{
						num2 = (ConditionIsMonk(reactorId) ? 1 : 0);
						goto IL_00f6;
					}
				}
				num2 = 1;
				goto IL_00f6;
			}
		}
		goto IL_00f8;
		IL_00f6:
		reactorResult = (byte)num2 != 0;
		goto IL_00f8;
	}

	private bool ConditionIsPublished()
	{
		return _relevanceOccurenceId.Valid && DomainManager.Information.QuerySecretOccurence(_relevanceOccurenceId).InBroadcast;
	}

	private bool ConditionIsRevealed(int actorId, int reactorId = -1)
	{
		if (actorId == -1)
		{
			return false;
		}
		if (reactorId == -1)
		{
			return !HasAnySpouse(actorId, includeLover: false, includeActors: true);
		}
		sbyte actorGender = -1;
		sbyte reactorGender = -1;
		if (DomainManager.Character.TryGetElement_Objects(actorId, out var actorChar))
		{
			actorGender = actorChar.GetGender();
		}
		else
		{
			DeadCharacter actorCharDead = DomainManager.Character.TryGetDeadCharacter(actorId);
			if (actorCharDead != null)
			{
				actorGender = actorCharDead.Gender;
			}
		}
		if (DomainManager.Character.TryGetElement_Objects(reactorId, out var reactorChar))
		{
			reactorGender = reactorChar.GetGender();
		}
		else
		{
			DeadCharacter reactorCharDead = DomainManager.Character.TryGetDeadCharacter(reactorId);
			if (reactorCharDead != null)
			{
				actorGender = reactorCharDead.Gender;
			}
		}
		HashSet<int> relation = GetSecretInformationRelatedCharactersOfSpecialRelation(actorId, RelationIndex.Revel, includeAlive: true, includeDead: true, includeActors: true);
		HashSet<int> relation2 = GetSecretInformationRelatedCharactersOfSpecialRelation(reactorId, RelationIndex.Revel, includeAlive: true, includeDead: true, includeActors: true);
		return actorGender == reactorGender || relation.Contains(reactorId) || relation2.Contains(actorId);
	}

	private bool ConditionIsRevealedSingle(int actorId, int reactorId = -1)
	{
		return !HasAnySpouse(actorId, includeLover: false, includeActors: true) || !HasAnySpouse(reactorId, includeLover: false, includeActors: true);
	}

	private bool ConditionHasCouple(int actorId)
	{
		return HasAnySpouse(actorId, includeLover: true);
	}

	private bool ConditionHasLove(int actorId, int reactorId, int secactorId = -1)
	{
		if (actorId == -1)
		{
			return false;
		}
		HashSet<int> relation = GetSecretInformationRelatedCharactersOfSpecialRelation(actorId, RelationIndex.Love, includeAlive: true, includeDead: true, includeActors: true);
		bool reactorResult = relation.Contains(reactorId);
		bool secactorResult = relation.Contains(secactorId);
		return reactorResult || secactorResult;
	}

	private bool HasAnySpouse(int actorId, bool includeLover = false, bool includeActors = false)
	{
		if (actorId == -1)
		{
			return false;
		}
		List<SecretInformationRelationshipType> relation = (includeLover ? RelationIndex.Love : RelationIndex.Spouse);
		if (_actorIdList.Contains(actorId))
		{
			HashSet<int> relatedCharId = GetSecretInformationRelatedCharactersOfSpecialRelation(actorId, relation, includeAlive: true, includeDead: false, includeActors);
			return relatedCharId.Count != 0;
		}
		if (!includeActors)
		{
			return false;
		}
		foreach (int character in _actorIdList)
		{
			if (Check_HasSpecialRelations(character, actorId, relation))
			{
				return true;
			}
		}
		return false;
	}

	private bool ConditionNotFame(int actorId)
	{
		if (actorId == -1)
		{
			return false;
		}
		sbyte fameType = GetFameTypeSafe(actorId);
		if (fameType == -1)
		{
			return false;
		}
		return fameType < 3 && fameType >= 0;
	}

	private bool ConditionIsMonk(int actorId, int reactorId = -1)
	{
		bool actorResult = false;
		bool reactorResult = false;
		if (actorId != -1)
		{
			actorResult = GetMonkTypeSafe(actorId) != 0;
		}
		if (reactorId != -1)
		{
			reactorResult = GetMonkTypeSafe(reactorId) != 0;
		}
		return actorResult || reactorResult;
	}

	private bool ConditionForbidWine(int actorId)
	{
		if (actorId == -1)
		{
			return false;
		}
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(actorId);
		if (oriActorOrgInfo.OrgTemplateId == -1)
		{
			return false;
		}
		OrganizationItem oriActorOrgConfig = Config.Organization.Instance[oriActorOrgInfo.OrgTemplateId];
		return oriActorOrgConfig.NoDrinking;
	}

	private bool ConditionForbidPoison(int actorId)
	{
		if (actorId == -1)
		{
			return false;
		}
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(actorId);
		if (oriActorOrgInfo.OrgTemplateId == -1)
		{
			return false;
		}
		OrganizationItem oriActorOrgConfig = Config.Organization.Instance[oriActorOrgInfo.OrgTemplateId];
		return !oriActorOrgConfig.AllowPoisoning;
	}

	private bool ConditionForbidItem(int actorId, int itemType)
	{
		if (actorId == -1)
		{
			return false;
		}
		OrganizationInfo oriActorOrgInfo = GetSectInfoSafe(actorId);
		if (oriActorOrgInfo.OrgTemplateId == -1)
		{
			return false;
		}
		OrganizationItem oriActorOrgConfig = Config.Organization.Instance[oriActorOrgInfo.OrgTemplateId];
		return itemType switch
		{
			9 => oriActorOrgConfig.NoDrinking, 
			7 => oriActorOrgConfig.NoMeatEating, 
			_ => false, 
		};
	}

	private bool ConditionIsKidnapped(int actorId, int reactorId, int extra = -1)
	{
		if (actorId == -1 || reactorId == -1)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(actorId, out var actor) || !DomainManager.Character.TryGetElement_Objects(reactorId, out var _))
		{
			return extra != -1;
		}
		bool result = actor.GetKidnapperId() == reactorId;
		return (extra == -1) ? result : (!result);
	}

	private bool ConditionCompareCombatPoint(int actorId, int reactorId)
	{
		if (actorId == -1 || reactorId == -1)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(actorId, out var actor) || !DomainManager.Character.TryGetElement_Objects(reactorId, out var reactor))
		{
			return false;
		}
		return actor.GetCombatPower() >= reactor.GetCombatPower();
	}

	private bool ConditionActorAlive(int actorId, int extraId = -1)
	{
		if (actorId == extraId)
		{
			return false;
		}
		GameData.Domains.Character.Character element;
		return DomainManager.Character.TryGetElement_Objects(actorId, out element);
	}

	private bool ConditionCasualtyInSect(int charId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			OrganizationInfo orgInfo = character.GetOrganizationInfo();
			return Config.Organization.Instance.GetItem(orgInfo.OrgTemplateId).IsSect;
		}
		return false;
	}

	private bool ConditionHasRelation(int actorId, int reactorId, int relationType, int extra = -1)
	{
		if (actorId == -1 || reactorId == -1)
		{
			return false;
		}
		HashSet<SecretInformationRelationshipType> relation = DomainManager.Information.CheckSecretInformationRelationship(reactorId, SecretOccurenceId.Invalid, actorId, SecretOccurenceId.Invalid);
		SecretInformationRelationshipType type;
		switch (relationType)
		{
		case -19:
			return (extra == -1) ? (relation.Count != 0) : (relation.Count == 0);
		case -18:
			type = SecretInformationRelationshipType.Allied;
			break;
		case -17:
			type = SecretInformationRelationshipType.Comrade;
			break;
		case -16:
			type = SecretInformationRelationshipType.Enemy;
			break;
		case -15:
			type = SecretInformationRelationshipType.Adorer;
			break;
		case -14:
			type = SecretInformationRelationshipType.Friend;
			break;
		case -13:
			type = SecretInformationRelationshipType.MentorAndMentee;
			break;
		case -12:
			type = SecretInformationRelationshipType.Lover;
			break;
		case -11:
			type = SecretInformationRelationshipType.HusbandOrWife;
			break;
		case -10:
		{
			bool result0 = relation.Contains(SecretInformationRelationshipType.HusbandOrWife) || relation.Contains(SecretInformationRelationshipType.Lover) || relation.Contains(SecretInformationRelationshipType.Adorer);
			return (extra == -1) ? result0 : (!result0);
		}
		case -9:
			type = SecretInformationRelationshipType.SwornBrotherOrSister;
			break;
		case -8:
			type = SecretInformationRelationshipType.Relative;
			break;
		case -7:
			type = SecretInformationRelationshipType.ActualBloodFather;
			break;
		case -6:
			type = SecretInformationRelationshipType.RevealedIncest;
			break;
		default:
			return extra != -1;
		}
		bool result1 = relation.Contains(type);
		return (extra == -1) ? result1 : (!result1);
	}

	private ESecretInformationSpecialConditionCalcFameLine CalcFameLineByFame(sbyte fameType)
	{
		if (1 == 0)
		{
		}
		ESecretInformationSpecialConditionCalcFameLine result;
		if (fameType < 3)
		{
			if (fameType < 0)
			{
				goto IL_001d;
			}
			result = ESecretInformationSpecialConditionCalcFameLine.Badboy;
		}
		else
		{
			if (fameType <= 3)
			{
				goto IL_001d;
			}
			result = ESecretInformationSpecialConditionCalcFameLine.SuperStar;
		}
		goto IL_0021;
		IL_0021:
		if (1 == 0)
		{
		}
		return result;
		IL_001d:
		result = ESecretInformationSpecialConditionCalcFameLine.Renowned;
		goto IL_0021;
	}

	private bool ConditionKillFameLine(int actorId, ESecretInformationSpecialConditionCalcFameLine conditionCalcFameLine)
	{
		return CalcFameLineByFame(GetFameTypeSafe(actorId)) == conditionCalcFameLine;
	}

	private bool ConditionKidnapFameLine(int actorId, ESecretInformationSpecialConditionCalcFameLine conditionCalcFameLine)
	{
		return CalcFameLineByFame(GetFameTypeSafe(actorId)) == conditionCalcFameLine;
	}

	private bool ConditionAlliedSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionBeLoverSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionBeKyodaiSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionGainParentSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionGainChildSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionDateSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionReFoundChildSectMember(int actorId, short conditionCalcOrganization)
	{
		return GetSectInfoSafe(actorId).OrgTemplateId == conditionCalcOrganization;
	}

	private bool ConditionBanSexualMate(int actorId, ESecretInformationSpecialConditionCalcSexualMateCase conditionCalcSexualMateCase, ESecretInformationSpecialConditionCalcSexualMateRule conditionCalcSexualMateRule, short conditionCalcSectRule)
	{
		short templateId = _templateId;
		if (1 == 0)
		{
		}
		ESecretInformationSpecialConditionCalcSexualMateCase eSecretInformationSpecialConditionCalcSexualMateCase;
		switch (templateId)
		{
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 107:
		case 108:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.GainChild;
			break;
		case 36:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.BeHusband;
			break;
		case 109:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.Date;
			break;
		case 34:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.BeLover;
			break;
		case 105:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.SexInvalid;
			break;
		case 106:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.SexNotAllow;
			break;
		default:
			eSecretInformationSpecialConditionCalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.Invalid;
			break;
		}
		if (1 == 0)
		{
		}
		if (conditionCalcSexualMateCase != eSecretInformationSpecialConditionCalcSexualMateCase)
		{
			return false;
		}
		OrganizationInfo orgInfo = GetSectInfoSafe(actorId);
		if (1 == 0)
		{
		}
		bool flag = conditionCalcSexualMateRule switch
		{
			ESecretInformationSpecialConditionCalcSexualMateRule.AllMember => true, 
			ESecretInformationSpecialConditionCalcSexualMateRule.NoCommonHuman => ConditionIsMonk(actorId), 
			ESecretInformationSpecialConditionCalcSexualMateRule.GradeHigh => orgInfo.Grade >= 6, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		if (!flag)
		{
			return false;
		}
		Settlement org = DomainManager.Organization.GetSettlementByOrgTemplateId(orgInfo.OrgTemplateId);
		return org != null && PunishmentType.Instance[conditionCalcSectRule].GetSeverity(DomainManager.Map.GetStateTemplateIdByAreaId(org.GetLocation().AreaId), Config.Organization.Instance[orgInfo.OrgTemplateId].IsSect) >= 0;
	}

	private bool ConditionBanEating(short conditionCalcSectRule)
	{
		int actorId = (_argList.CheckIndex(0) ? _argList[0] : (-1));
		int itemType = (_argList.CheckIndex(4) ? _argList[4] : (-1));
		if (!ConditionForbidItem(actorId, itemType))
		{
			return false;
		}
		OrganizationInfo orgInfo = GetSectInfoSafe(actorId);
		Settlement org = DomainManager.Organization.GetSettlementByOrgTemplateId(orgInfo.OrgTemplateId);
		return org != null && PunishmentType.Instance[conditionCalcSectRule].GetSeverity(DomainManager.Map.GetStateTemplateIdByAreaId(org.GetLocation().AreaId), Config.Organization.Instance[orgInfo.OrgTemplateId].IsSect) >= 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void LogInfo(string message)
	{
		AdaptableLog.TagInfo("SecretInformationProcessor", message);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void LogWarning(string message)
	{
		AdaptableLog.TagWarning("SecretInformationProcessor", message);
	}
}
