using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Config;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Common.Binary;
using GameData.Common.SingleValueCollection;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.Global;
using GameData.Domains.Information.Collection;
using GameData.Domains.Information.Secret;
using GameData.Domains.Information.Secret.Attachment;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Information;
using NLog;

namespace GameData.Domains.Information;

[GameDataDomain(18)]
public class InformationDomain : BaseGameDataDomain
{
	public static class NormalInformationUseResultType
	{
		public const sbyte Effective = 0;

		public const sbyte Normal = 1;

		public const sbyte Ineffective = 2;

		public const sbyte SwordTomb = 3;
	}

	private readonly struct SecretBroadcastPostProcessContext(byte informationActorBroadcastType, IReadOnlyDictionary<int, List<short>> allActorFameList, IReadOnlyList<SecretInformationHappinessChangeItem> allHappinessChange, IReadOnlyList<SecretInformationFavorChangeItem> allFavorabilityChangeWithSource, IReadOnlyList<SecretInformationStartEnemyRelationItem> allSecretInformationStartEnemyRelationItems, IReadOnlyDictionary<int, GameData.Domains.Character.Character> actorListWithActorIndex, IReadOnlyList<int> argList)
	{
		public readonly byte InformationActorBroadcastType = informationActorBroadcastType;

		public readonly IReadOnlyDictionary<int, List<short>> AllActorFameList = allActorFameList;

		public readonly IReadOnlyList<SecretInformationHappinessChangeItem> AllHappinessChange = allHappinessChange;

		public readonly IReadOnlyList<SecretInformationFavorChangeItem> AllFavorabilityChangeWithSource = allFavorabilityChangeWithSource;

		public readonly IReadOnlyList<SecretInformationStartEnemyRelationItem> AllSecretInformationStartEnemyRelationItems = allSecretInformationStartEnemyRelationItems;

		public readonly IReadOnlyDictionary<int, GameData.Domains.Character.Character> ActorListWithActorIndex = actorListWithActorIndex;

		public readonly IReadOnlyList<int> ArgList = argList;
	}

	private struct SecretInformationDisseminateIndex(int characterIdA, int characterIdB, SecretInformationId secretInformationId) : IEquatable<SecretInformationDisseminateIndex>
	{
		private IntPair _characterIdPair = ((characterIdA < characterIdB) ? new IntPair(characterIdA, characterIdB) : new IntPair(characterIdB, characterIdA));

		private readonly SecretInformationId _secretInformationId = secretInformationId;

		public bool Equals(SecretInformationDisseminateIndex other)
		{
			return _characterIdPair.Equals(other._characterIdPair) && _secretInformationId == other._secretInformationId;
		}

		public override bool Equals(object obj)
		{
			return obj is SecretInformationDisseminateIndex other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_characterIdPair, _secretInformationId);
		}
	}

	public struct SecretInformationFavorChangeItem(int characterId, int targetId, int deltaFavor, sbyte priority = 0)
	{
		public int CharacterId = characterId;

		public int TargetId = targetId;

		public int DeltaFavor = deltaFavor;

		public sbyte Priority = priority;
	}

	public struct SecretInformationHappinessChangeItem(int characterId, int deltaHappiness, sbyte priority = 0)
	{
		public int CharacterId = characterId;

		public int DeltaHappiness = deltaHappiness;

		public sbyte Priority = priority;
	}

	public struct SecretInformationStartEnemyRelationItem(short secretInformationTemplateId, int characterId, int targetId, byte odds)
	{
		public short SecretInformationTemplateId = secretInformationTemplateId;

		public int CharacterId = characterId;

		public int TargetId = targetId;

		public byte Odds = odds;
	}

	public struct SecretInformationAlertnessChangeItem(short templateId, int characterId, int deltaAlertness)
	{
		public short TemplateId = templateId;

		public int CharacterId = characterId;

		public int DeltaAlertness = deltaAlertness;
	}

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, NormalInformationCollection> _information;

	[Obsolete]
	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<NormalInformation> _taiwuReceivedNormalInformationInMonth;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<int> _taiwuReceivedInformation;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<NormalInformation> _taiwuTmpInformation;

	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 4)]
	private int[] _secretInformationLevelFactors;

	private readonly List<CharacterDisplayDataWithInfo> _characterDisplayDataWithInfoList = new List<CharacterDisplayDataWithInfo>(128);

	private EventArgBox _eventArgBox = new EventArgBox();

	public readonly LocalObjectPool<SecretInformationProcessor> SecretInformationProcessorPool = new LocalObjectPool<SecretInformationProcessor>(2, 16);

	public static readonly int[] FameTypeForDiscoveryRates = new int[7] { -100, -75, -25, 0, 25, 75, 100 };

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<SecretInformationId, GameData.Domains.Information.Secret.SecretInformation> _secretInformation;

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<SecretOccurenceId, SecretOccurence> _secretOccurence;

	private SecretInformationId _nextSecretId = SecretInformationId.Invalid;

	private SecretOccurenceId _nextSecretOccurenceId = SecretOccurenceId.Invalid;

	private Dictionary<SecretOccurenceId, HashSet<SecretInformationId>> _secretOccurenceToInformationCache;

	private Dictionary<SecretInformationId, HashSet<int>> _secretInformationHoldersCache;

	private static readonly HashSet<int> EmptyIntHashSet = new HashSet<int>();

	private static readonly HashSet<SecretInformationId> EmptyInfoIdHashSet = new HashSet<SecretInformationId>();

	private static readonly Logger SecretLogger = LogManager.GetLogger("SecretInformation");

	[DomainData(DomainDataType.SingleValueCollection, true, false, false, false)]
	private readonly Dictionary<int, CharacterKnownSecret> _characterKnownSecrets;

	private readonly HashSet<SecretInformationDisseminateIndex> _completedNpcDisseminateIndices = new HashSet<SecretInformationDisseminateIndex>();

	[DomainData(DomainDataType.Binary, true, false, true, false)]
	private readonly SecretInformationCollection _secretInformationCollection;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[9][];

	private SingleValueCollectionModificationCollection<int> _modificationsInformation = SingleValueCollectionModificationCollection<int>.Create();

	private BinaryModificationCollection _modificationsSecretInformationCollection = BinaryModificationCollection.Create();

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		_secretInformationHoldersCache = new Dictionary<SecretInformationId, HashSet<int>>();
		_secretOccurenceToInformationCache = new Dictionary<SecretOccurenceId, HashSet<SecretInformationId>>();
	}

	private void OnLoadedArchiveData()
	{
		SecretArchiveSetup();
		InitializeSecretInformationHoldersCaches();
		InitializeOccurenceToInformationCache();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal NormalInformationCollection EnsureCharacterNormalInformationCollection(DataContext context, int characterId)
	{
		if (!TryGetElement_Information(characterId, out var collection))
		{
			AddElement_Information(characterId, collection = new NormalInformationCollection(), context);
		}
		return collection;
	}

	public void RemoveCharacterAllInformation(DataContext context, int characterId)
	{
		RemoveElement_Information(characterId, context);
		RemoveElement_CharacterKnownSecrets(characterId, context);
	}

	[DomainMethod]
	public int[] GetSecretInformationLevelFactor()
	{
		return _secretInformationLevelFactors;
	}

	[DomainMethod]
	public void SetSecretInformationLevelFactor(DataContext context, int[] value)
	{
		SetSecretInformationLevelFactors(value, context);
	}

	[DomainMethod]
	public NormalInformationCollection GetCharacterNormalInformation(int characterId)
	{
		if (TryGetElement_Information(characterId, out var collection))
		{
			return collection;
		}
		return new NormalInformationCollection();
	}

	public int GetCharacterNormalInformationAmount(int characterId)
	{
		if (TryGetElement_Information(characterId, out var collection))
		{
			return collection.GetList().Count;
		}
		return 0;
	}

	[DomainMethod]
	public List<NormalInformationDisplayData> GetCharacterNormalInformationDisplayData(int characterId)
	{
		if (TryGetElement_Information(characterId, out var collection))
		{
			return collection.GetList().Select(delegate(NormalInformation information)
			{
				var (usedCount, maxCount) = (IntPair)(ref GetNormalInformationUsedCountAndMax(characterId, information));
				return new NormalInformationDisplayData
				{
					NormalInformation = information,
					UsedCount = usedCount,
					MaxCount = maxCount
				};
			}).ToList();
		}
		return new List<NormalInformationDisplayData>();
	}

	[DomainMethod]
	public void AddNormalInformationToCharacter(DataContext context, int characterId, NormalInformation information)
	{
		CheckAddNormalInformationToCharacter(context, characterId, information);
	}

	public bool CheckAddNormalInformationToCharacter(DataContext context, int characterId, NormalInformation information)
	{
		NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, characterId);
		IList<NormalInformation> list = collection.GetList();
		foreach (NormalInformation element in list)
		{
			if (element.TemplateId == information.TemplateId && element.Level == information.Level)
			{
				return false;
			}
		}
		list.Add(information);
		if (characterId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Taiwu.AddLegacyPoint(context, 34);
			DomainManager.Global.InvokeGuidingTrigger(context, 298);
			InformationItem config = Config.Information.Instance[information.TemplateId];
			switch (config.Type)
			{
			case 0:
			{
				ProfessionFormulaItem formula3 = ProfessionFormula.Instance[78];
				int addSeniority3 = formula3.Calculate(information.Level);
				DomainManager.Extra.ChangeProfessionSeniority(context, 12, addSeniority3);
				DomainManager.Global.InvokeGuidingTrigger(context, 301);
				break;
			}
			case 1:
			{
				ProfessionFormulaItem formula2 = ProfessionFormula.Instance[78];
				int addSeniority2 = formula2.Calculate(information.Level);
				DomainManager.Extra.ChangeProfessionSeniority(context, 12, addSeniority2);
				DomainManager.Global.InvokeGuidingTrigger(context, 295);
				break;
			}
			case 2:
				DomainManager.Global.InvokeGuidingTrigger(context, 299);
				break;
			case 3:
			{
				ProfessionFormulaItem formula = ProfessionFormula.Instance[79];
				int addSeniority = formula.Calculate(information.Level);
				DomainManager.Extra.ChangeProfessionSeniority(context, 12, addSeniority);
				DomainManager.Global.InvokeGuidingTrigger(context, 293);
				break;
			}
			case 5:
				DomainManager.Global.InvokeGuidingTrigger(context, 297);
				break;
			case 6:
				DomainManager.Global.InvokeGuidingTrigger(context, 291);
				break;
			}
		}
		SetElement_Information(characterId, collection, context);
		return true;
	}

	[DomainMethod]
	public void DeleteTmpInformation(DataContext context)
	{
		_taiwuReceivedInformation.Clear();
		_taiwuTmpInformation.Clear();
	}

	public void DiscardNormalInformation(DataContext context, int characterId, NormalInformation information)
	{
		if (TryGetElement_Information(characterId, out var normalInformationCollection))
		{
			normalInformationCollection.GetList().Remove(information);
			normalInformationCollection.ClearUsedCountData(information);
			SetElement_Information(characterId, normalInformationCollection, context);
		}
	}

	[DomainMethod]
	public int GetNormalInformationUsedCount(int characterId, NormalInformation information)
	{
		if (TryGetElement_Information(characterId, out var normalInformationCollection))
		{
			return normalInformationCollection.GetUsedCount(information);
		}
		return 0;
	}

	[DomainMethod]
	public IntPair GetNormalInformationUsedCountAndMax(int characterId, NormalInformation information)
	{
		if (TryGetElement_Information(characterId, out var normalInformationCollection))
		{
			return new IntPair(normalInformationCollection.GetUsedCount(information), normalInformationCollection.GetUsedCountMax(information));
		}
		return new IntPair(0, 0);
	}

	public void TransformNormalInformation(DataContext context, int charId, NormalInformation normalInformation)
	{
		short informationId = Config.Information.Instance[normalInformation.TemplateId].TransformId;
		NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, charId);
		sbyte usedCount = collection.GetUsedCount(normalInformation);
		DiscardNormalInformation(context, charId, normalInformation);
		if (informationId < 0)
		{
			return;
		}
		NormalInformation newInformation = new NormalInformation(informationId, normalInformation.Level);
		AddNormalInformationToCharacter(context, charId, newInformation);
		collection.SetUsedCount(newInformation, usedCount);
		SetElement_Information(charId, collection, context);
		List<int> allCharIds = _information.Keys.ToList();
		foreach (int targetCharId in allCharIds)
		{
			if (TryGetElement_Information(targetCharId, out var targetCollection) && targetCollection.ReceivedCounts.Remove(normalInformation.TemplateId, out var receivedCount))
			{
				targetCollection.ReceivedCounts.TryAdd(informationId, receivedCount);
				SetElement_Information(targetCharId, targetCollection, context);
			}
		}
	}

	public NormalInformation CalcSwordTombInformation(EInformationInfoSwordInformationType type, int xiangshuAvatarId)
	{
		if (1 == 0)
		{
		}
		short num = type switch
		{
			EInformationInfoSwordInformationType.SwordTombHeaven => (short)(xiangshuAvatarId + 89), 
			EInformationInfoSwordInformationType.SwordTombEarth => (short)(xiangshuAvatarId + 111), 
			EInformationInfoSwordInformationType.SwordTombHuman => (short)(xiangshuAvatarId + 98), 
			EInformationInfoSwordInformationType.SwordTombNormal => (short)(xiangshuAvatarId + 111), 
			_ => throw new Exception($"unsupported information type: {type}"), 
		};
		if (1 == 0)
		{
		}
		short templateId = num;
		return new NormalInformation(templateId, (sbyte)Config.Information.Instance[templateId].GainLevel);
	}

	public void RegisterInformation(int charId, DataContext context)
	{
		CharacterDomain characterDomain = DomainManager.Character;
		GameData.Domains.Character.Character character = characterDomain.GetElement_Objects(charId);
		foreach (GameData.Domains.Character.LifeSkillItem lifeSkillItem in character.GetLearnedLifeSkills())
		{
			if (lifeSkillItem.IsAllPagesRead())
			{
				GainLifeSkillInformationToCharacter(context, charId, LifeSkill.Instance[lifeSkillItem.SkillTemplateId].Type);
			}
		}
		Location location = character.GetLocation();
		if (location.IsValid())
		{
			MapBlockData block = DomainManager.Map.GetBlock(location);
			short templateId = block.GetConfig().InformationTemplateId;
			if (templateId >= 0)
			{
				OrganizationInfo orgInfo = character.GetOrganizationInfo();
				if (orgInfo.Grade > 0)
				{
					AddNormalInformationToCharacter(context, charId, new NormalInformation(templateId, orgInfo.Grade));
				}
			}
		}
		MapDomain mapDomain = DomainManager.Map;
		OrganizationDomain orgDomain = DomainManager.Organization;
		OrganizationInfo orgInfo2 = character.GetOrganizationInfo();
		if (orgInfo2.SettlementId >= 0)
		{
			Location location2 = orgDomain.GetSettlement(orgInfo2.SettlementId).GetLocation();
			if (location2.IsValid())
			{
				short templateId2 = mapDomain.GetBlock(location2).GetConfig().InformationTemplateId;
				if (templateId2 >= 0)
				{
					AddNormalInformationToCharacter(context, charId, new NormalInformation(templateId2, orgInfo2.Grade));
				}
			}
		}
		EnsureCharacterKnownSecret(context, charId);
	}

	public void TransferInformation(int sourceCharId, int targetCharId, DataContext context)
	{
		RemoveCharacterAllInformation(context, targetCharId);
		if (TryGetElement_Information(sourceCharId, out var normalInformationCollection))
		{
			AddElement_Information(targetCharId, normalInformationCollection, context);
			RemoveElement_Information(sourceCharId, context);
		}
		EditCharacterKnownSecret(context, targetCharId, delegate(CharacterKnownSecret targetKnown)
		{
			CharacterKnownSecret src = EnsureCharacterKnownSecret(context, sourceCharId);
			GameData.Serializer.Serializer.CopyTo(ref src, ref targetKnown);
		});
		RemoveElement_CharacterKnownSecrets(targetCharId, context);
	}

	public void ProcessAdvanceMonth(DataContext context)
	{
		ProcessSecretInformationAdvanceMonth(context);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (_information.TryGetValue(taiwuCharId, out var normalInformationCollection))
		{
			crossArchiveGameData.NormalInformation = normalInformationCollection;
		}
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
	}

	public void UnpackCrossArchiveGameData_NormalInformation(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		if (crossArchiveGameData.NormalInformation == null)
		{
			return;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (NormalInformation information in crossArchiveGameData.NormalInformation.GetList())
		{
			InformationItem config = Config.Information.Instance[information.TemplateId];
			if (config.Type == 2)
			{
				if (!config.InfoIds.CheckIndex(information.Level))
				{
					continue;
				}
				InformationInfoItem info = InformationInfo.Instance.GetItem(config.InfoIds[information.Level]);
				if (info != null)
				{
					for (int level = 0; level < information.Level + 1; level++)
					{
						GainLifeSkillInformationToCharacter(context, taiwuCharId, info.LifeSkillType);
					}
				}
			}
			else if (config.Type != 5)
			{
				AddNormalInformationToCharacter(context, taiwuCharId, information);
			}
		}
	}

	public void MakeSettlementsInformation(DataContext context)
	{
		MapDomain mapDomain = DomainManager.Map;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		HashSet<int> taiwuGroups = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		for (short areaId = 0; areaId < 45; areaId++)
		{
			short settlementMainBlockId = mapDomain.GetMainSettlementMainBlockId(areaId);
			if (settlementMainBlockId >= 0)
			{
				MapBlockData settlementMainBlock = mapDomain.GetBlock(areaId, settlementMainBlockId);
				ProcessMapBlock(settlementMainBlock);
			}
		}
		void ProcessCharacter(int characterId, MapBlockItem blockConfig)
		{
			if (blockConfig.InformationTemplateId >= 0)
			{
				NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, characterId);
				IList<NormalInformation> list = collection.GetList();
				InformationItem configData = Config.Information.Instance[blockConfig.InformationTemplateId];
				int i = 0;
				for (int len = list.Count; i < len; i++)
				{
					NormalInformation current = list[i];
					if (current.TemplateId == configData.TemplateId)
					{
						if (current.Level < 8 && context.Random.Next(0, 100) < configData.ExtraGainRate[current.Level])
						{
							AddNormalInformationToCharacter(context, characterId, new NormalInformation(current.TemplateId, current.Level));
						}
						break;
					}
				}
				int j = 0;
				for (int len2 = configData.BaseGainRate.Length; j < len2; j++)
				{
					int gainRate = configData.BaseGainRate[j] * 2;
					if (context.Random.Next(0, 100) < gainRate)
					{
						AddNormalInformationToCharacter(context, characterId, new NormalInformation(configData.TemplateId, (sbyte)j));
						break;
					}
				}
			}
		}
		void ProcessCharacterSet(HashSet<int> characterSet, MapBlockItem blockConfig)
		{
			if (characterSet == null || blockConfig.InformationTemplateId < 0)
			{
				return;
			}
			foreach (int characterId in characterSet)
			{
				ProcessCharacter(characterId, blockConfig);
			}
		}
		void ProcessMapBlock(MapBlockData block)
		{
			MapBlockItem blockConfig = block.GetConfig();
			if (blockConfig.InformationTemplateId >= 0)
			{
				ProcessCharacterSet(block.CharacterSet, blockConfig);
				if (block.BlockId == taiwuLocation.BlockId && block.AreaId == taiwuLocation.AreaId)
				{
					ProcessCharacterSet(taiwuGroups, blockConfig);
				}
				if (block.GroupBlockList != null)
				{
					foreach (MapBlockData groupBlock in block.GroupBlockList)
					{
						ProcessCharacterSet(groupBlock.CharacterSet, blockConfig);
						if (groupBlock.BlockId == taiwuLocation.BlockId && groupBlock.AreaId == taiwuLocation.AreaId)
						{
							ProcessCharacterSet(taiwuGroups, blockConfig);
						}
					}
				}
			}
		}
	}

	internal void GiveOrUpgradeWesternRegionInformation(DataContext context, int charId, short westernRegionId)
	{
		NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, charId);
		IList<NormalInformation> list = collection.GetList();
		for (int i = 0; i < list.Count; i++)
		{
			NormalInformation information = list[i];
			InformationItem config = Config.Information.Instance.GetItem(information.TemplateId);
			InformationInfoItem info = InformationInfo.Instance.GetItem(config.InfoIds[information.Level]);
			sbyte upgradedLevel = (sbyte)(information.Level + 1);
			if (info.WesternRegionId == westernRegionId && upgradedLevel <= 8 && config.InfoIds.CheckIndex(upgradedLevel) && config.InfoIds[upgradedLevel] >= 0)
			{
				AddNormalInformationToCharacter(context, charId, new NormalInformation(config.TemplateId, upgradedLevel));
				return;
			}
		}
		foreach (InformationItem config2 in (IEnumerable<InformationItem>)Config.Information.Instance)
		{
			for (sbyte level = 0; level <= 8; level++)
			{
				InformationInfoItem info2 = InformationInfo.Instance.GetItem(config2.InfoIds[level]);
				if (info2 != null && info2.WesternRegionId == westernRegionId)
				{
					AddNormalInformationToCharacter(context, charId, new NormalInformation(config2.TemplateId, level));
					return;
				}
			}
		}
	}

	internal void GiveProfessionInformation(DataContext context, int charId, int professionId)
	{
		if (CalcProfessionInformation(professionId, out var information) && !CheckAddNormalInformationToCharacter(context, charId, information))
		{
			NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, charId);
			collection.SetRemainUsableCount(information, (sbyte)(collection.GetRemainUsableCount(information) + GlobalConfig.Instance.NormalInformationDefaultCostableMaxUseCount));
			DomainManager.Information.SetNormalInformationCharacterDataModified(context, charId);
		}
	}

	internal void FixOldProfessionInformation(DataContext context, ProfessionData professionData, int charId)
	{
		ProfessionItem professionCfg = professionData.GetConfig();
		for (int i = 0; i <= professionCfg.ProfessionSkills.Length; i++)
		{
			if (professionData.IsSkillUnlocked(i))
			{
				GiveProfessionInformation(context, charId, professionData.TemplateId);
			}
		}
	}

	internal void GiveRemainUsedCountInformation(DataContext context, int charId, NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance[normalInformation.TemplateId];
		Tester.Assert(!config.UsedCountWithMax);
		NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, charId);
		if (CheckAddNormalInformationToCharacter(context, charId, normalInformation))
		{
			collection.SetRemainUsableCount(normalInformation, (sbyte)config.GainCount);
		}
		else
		{
			collection.SetRemainUsableCount(normalInformation, (sbyte)(collection.GetRemainUsableCount(normalInformation) + config.GainCount));
		}
		DomainManager.Information.SetNormalInformationCharacterDataModified(context, charId);
	}

	internal void GiveProfessionInformationRemainUsableCount(DataContext context, int charId, int professionId, int oldExtraSeniority, int nowExtraSeniority)
	{
		ProfessionItem professionConfig = Profession.Instance.GetItem(professionId);
		for (int i = 0; i < professionConfig.ProfessionSkills.Length + 1; i++)
		{
			int professionSkillId = (professionConfig.ProfessionSkills.CheckIndex(i) ? professionConfig.ProfessionSkills[i] : professionConfig.ExtraProfessionSkill);
			ProfessionSkillItem professionSkillConfig = ProfessionSkill.Instance.GetItem(professionSkillId);
			if (professionSkillConfig != null)
			{
				int line = GlobalConfig.Instance.GiveProfessionInformationFactorWithExtraSeniority * GameData.Domains.Taiwu.Profession.SharedMethods.GetSkillUnlockSeniority(professionSkillId) / 100;
				bool checkPointNormal = oldExtraSeniority < line && nowExtraSeniority >= line;
				bool checkPointOverline = line == 1500000 && nowExtraSeniority < oldExtraSeniority;
				if ((checkPointNormal || checkPointOverline) && DomainManager.Information.CalcProfessionInformation(professionId, out var information))
				{
					GiveRemainUsedCountInformation(context, charId, information);
				}
			}
		}
	}

	internal bool CalcProfessionInformation(int professionId, out NormalInformation information)
	{
		foreach (InformationItem config in (IEnumerable<InformationItem>)Config.Information.Instance)
		{
			for (sbyte level = 0; level <= 8; level++)
			{
				InformationInfoItem info = InformationInfo.Instance.GetItem(config.InfoIds[level]);
				if (info != null && info.Profession == professionId)
				{
					information = new NormalInformation(config.TemplateId, level);
					return true;
				}
			}
		}
		information = default(NormalInformation);
		return false;
	}

	public bool GainRandomSettlementInformationByStateIdToCharacter(DataContext context, sbyte grade, int characterId, sbyte stateId)
	{
		List<short> areaIds = new List<short>();
		DomainManager.Map.GetAllAreaInState(stateId, areaIds);
		List<short> randomPool = new List<short>();
		foreach (short areaId in areaIds)
		{
			MapAreaData area = DomainManager.Map.GetElement_Areas(areaId);
			SettlementInfo[] settlementInfos = area.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				randomPool.AddRange(from informationItem in Config.Information.Instance
					where informationItem.IsGeneral && informationItem.InfoIds.Any((short infoId) => InformationInfo.Instance[infoId]?.Oraganization == settlementInfo.OrgTemplateId && settlementInfo.OrgTemplateId >= 0)
					select informationItem.TemplateId);
			}
		}
		if (randomPool.Count <= 0)
		{
			return false;
		}
		return CheckAddNormalInformationToCharacter(context, characterId, new NormalInformation(randomPool.GetRandom(context.Random), grade));
	}

	public void GainLifeSkillInformationToCharacter(DataContext context, int characterId, sbyte lifeSkillType)
	{
		NormalInformationCollection collection = EnsureCharacterNormalInformationCollection(context, characterId);
		IList<NormalInformation> list = collection.GetList();
		short informationTemplateId = Config.LifeSkillType.Instance[lifeSkillType].InformationTemplateId;
		if (informationTemplateId < 0)
		{
			return;
		}
		int i = 0;
		for (int count = list.Count; i < count; i++)
		{
			NormalInformation element = list[i];
			if (element.TemplateId == informationTemplateId)
			{
				element.UpdateLevel((sbyte)(element.Level + 1));
				list[i] = element;
				SetElement_Information(characterId, collection, context);
				return;
			}
		}
		AddNormalInformationToCharacter(context, characterId, new NormalInformation(informationTemplateId, 0));
	}

	[DomainMethod]
	public unsafe SecretInformationId GmCmd_CreateSecretInformationByCharacterIds(DataContext context, string templateDefKeyName, List<int> charIds)
	{
		short templateId = (short)typeof(Config.SecretInformation.DefKey).GetField(templateDefKeyName, BindingFlags.Static | BindingFlags.Public).GetValue(null);
		SecretInformationItem config = Config.SecretInformation.Instance.GetItem(templateId);
		if (config == null)
		{
			return SecretInformationId.Invalid;
		}
		byte* pRawData = stackalloc byte[128];
		byte* pCurrData = pRawData;
		sbyte[] parameters = config.Parameters;
		for (int i = 0; i < parameters.Length; i++)
		{
			switch (parameters[i])
			{
			case 0:
				if (charIds.Count > 0)
				{
					*(int*)pCurrData = charIds[0];
					pCurrData += 4;
					charIds.RemoveAt(0);
					break;
				}
				return SecretInformationId.Invalid;
			case 1:
			{
				List<Settlement> settlements = new List<Settlement>();
				DomainManager.Organization.GetAllCivilianSettlements(settlements);
				Location location = settlements.GetRandom(context.Random).GetLocation();
				*(short*)pCurrData = location.AreaId;
				pCurrData += 2;
				*(short*)pCurrData = location.BlockId;
				pCurrData += 2;
				break;
			}
			case 2:
				*pCurrData = (byte)(sbyte)context.Random.Next(8);
				pCurrData++;
				break;
			case 3:
				*pCurrData = 10;
				pCurrData++;
				*(short*)pCurrData = (short)context.Random.Next(Config.SkillBook.Instance.Count);
				pCurrData += 2;
				break;
			case 4:
				*(short*)pCurrData = (short)context.Random.Next(Config.CombatSkill.Instance.Count);
				pCurrData += 2;
				break;
			case 5:
				*(short*)pCurrData = (short)context.Random.Next(LifeSkill.Instance.Count);
				pCurrData += 2;
				break;
			case 6:
				*(int*)pCurrData = context.Random.Next();
				pCurrData += 4;
				break;
			}
		}
		return AddSecretInformation(context, AddSecretOccurence(context, DomainManager.World.GetCurrDate(), templateId, new Span<byte>(pRawData, (int)(pCurrData - pRawData)).ToArray()), withInitialDistribute: true, necessarily: true, delegate
		{
		});
	}

	[DomainMethod]
	public bool GmCmd_MakeCharacterReceiveSecretInformation(DataContext context, int characterId, SecretInformationId secretId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		if (secret != null)
		{
			return ReceiveSecretInformation(context, secret, characterId, secret.SourceCharacterId);
		}
		return false;
	}

	[DomainMethod]
	public void GmCmd_MakeSecretInformationBroadcast(DataContext context, SecretInformationId secretId, int sourceCharId = -1)
	{
		MakeSecretBroadcast(context, secretId, sourceCharId);
	}

	[DomainMethod]
	public int GmCmd_DisseminationSecretInformationToRandomCharacters(DataContext context, SecretInformationId secretId, int sourceCharId, int amount)
	{
		CharacterDomain domainCharacter = DomainManager.Character;
		InformationDomain domainInformation = DomainManager.Information;
		List<GameData.Domains.Character.Character> characters = new List<GameData.Domains.Character.Character>();
		int originAmount = amount;
		domainCharacter.FindIntelligentCharacters((GameData.Domains.Character.Character _) => true, characters);
		CollectionUtils.Shuffle(context.Random, characters);
		foreach (GameData.Domains.Character.Character character in characters)
		{
			if (amount <= 0)
			{
				break;
			}
			if (domainInformation.ReceiveSecretInformation(context, secretId, character.GetId(), sourceCharId))
			{
				amount--;
			}
		}
		return originAmount - amount;
	}

	[DomainMethod]
	public List<CharacterDisplayDataWithInfo> GetCharacterDisplayDataWithInfoList(List<int> charList)
	{
		_characterDisplayDataWithInfoList.Clear();
		foreach (int characterId in charList)
		{
			if (DomainManager.Character.TryGetElement_Objects(characterId, out var _))
			{
				CharacterInfoCountData characterInfoCountData = GetCharacterInfoCountData(characterId);
				if (characterInfoCountData != null)
				{
					CharacterDisplayDataWithInfo characterDisplayDataWithInfo = new CharacterDisplayDataWithInfo
					{
						CharacterDisplayData = DomainManager.Character.GetCharacterDisplayData(characterId),
						CharacterInfoCountData = characterInfoCountData
					};
					_characterDisplayDataWithInfoList.Add(characterDisplayDataWithInfo);
				}
			}
		}
		return _characterDisplayDataWithInfoList;
	}

	private CharacterInfoCountData GetCharacterInfoCountData(int characterId)
	{
		CharacterInfoCountData characterInfoDisplayData = null;
		IReadOnlyCollection<SecretInformationId> collection = QueryCharacterKnownSecretInformationIds(characterId);
		if (collection.Count == 0)
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			int holdInfoCount = collection.Count;
			int holdInfoTaiwuRelatedCount = collection.Count((SecretInformationId secretId) => CheckSecretIsRelated(QuerySecretInformation(secretId), taiwuCharId));
			if (holdInfoCount > 0 || holdInfoTaiwuRelatedCount > 0)
			{
				characterInfoDisplayData = new CharacterInfoCountData
				{
					HoldInfoCount = holdInfoCount,
					HoldInfoTaiwuRelatedCount = holdInfoTaiwuRelatedCount
				};
			}
		}
		return characterInfoDisplayData;
	}

	private bool CheckSecretIsRelated(GameData.Domains.Information.Secret.SecretInformation secret, int charId)
	{
		bool result = false;
		secret.QueryParameters(out var occurence).ExtractSecretParameters(Config.SecretInformation.Instance[occurence.TemplateId], delegate(int index, int argCharId)
		{
			bool flag = argCharId == charId;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = (uint)index <= 1u;
				flag2 = flag3;
			}
			if (flag2)
			{
				result = true;
			}
		});
		return result;
	}

	[DomainMethod]
	public void PerformProfessionLiteratiSkill2(DataContext ctx, int secretInformationId)
	{
		ProfessionSkillHandle.LiteratiSkill_BroadcastModifiedSecretInformation(ctx, secretInformationId);
	}

	[DomainMethod]
	public void PerformProfessionLiteratiSkill3(DataContext ctx, NormalInformation normalInformation)
	{
		ProfessionSkillHandle.LiteratiSkill_AreaBroadcastNormalInformation(ctx, normalInformation);
	}

	public SecretInformationItem CalcSecretInformationConfig(SecretInformationId secretId)
	{
		QuerySecretInformation(secretId).QueryParameters(out var occurence);
		return Config.SecretInformation.Instance.GetItem(occurence.TemplateId);
	}

	private bool IsSecretInformationRelatedWithCharacter(SecretInformationId secretId, int characterId)
	{
		bool result = false;
		QuerySecretInformation(secretId).QueryParameters(out var occurence).ExtractSecretParameters(Config.SecretInformation.Instance[occurence.TemplateId], delegate(int _, int charId)
		{
			if (charId == characterId)
			{
				result = true;
			}
		});
		return result;
	}

	public void SetNormalInformationCharacterDataModified(DataContext context, int characterId)
	{
		if (TryGetElement_Information(characterId, out var element))
		{
			SetElement_Information(characterId, element, context);
		}
	}

	public int CalcSecretInformationAuthorityCostWhenDisseminating(short secretInformationTemplateId, int disseminationCountOfBranch)
	{
		SecretInformationItem config = Config.SecretInformation.Instance[secretInformationTemplateId];
		return config.CostAuthority * Math.Max(0, 100 - Math.Max(disseminationCountOfBranch - 1, 0) / 10) / 100;
	}

	public int CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(short secretInformationTemplateId, sbyte characterFameType, int disseminationCountOfBranch)
	{
		if (characterFameType == -2)
		{
			characterFameType = 3;
		}
		int baseValue = CalcSecretInformationAuthorityCostWhenDisseminating(secretInformationTemplateId, disseminationCountOfBranch);
		SecretInformationItem config = Config.SecretInformation.Instance[secretInformationTemplateId];
		int fameDiff = config.FameThreshold - characterFameType;
		if (fameDiff > 0)
		{
			return baseValue * (1 + fameDiff * 2);
		}
		return baseValue;
	}

	[DomainMethod]
	public void DiscardSecretInformation(DataContext context, int charId, SecretInformationId secretId)
	{
		EditCharacterKnownSecret(context, charId, delegate(CharacterKnownSecret known)
		{
			known.KnownSecrets.Remove(secretId);
			known.UsedCounts.Remove(secretId);
		});
		UnregisterSecretHolderCache(charId, secretId);
	}

	public ICollection<int> RequestShopSecretInformationIdList(DataContext dataContext, int charId)
	{
		return DomainManager.Extra.AddOrGetSecretInformationShopCharacterData(dataContext, charId).CollectedSecretInformationIds.DistinctBy((int secretId) => QuerySecretInformation((SecretInformationId)secretId).OccurenceId).ToList();
	}

	[DomainMethod]
	public void SettleSecretInformationShopTrade(DataContext context, List<IntPair> secretList, int shopCharId)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.Character.Character shopChar = DomainManager.Character.GetElement_Objects(shopCharId);
		SecretInformationShopCharacterData shopCharacterData = DomainManager.Extra.AddOrGetSecretInformationShopCharacterData(context, shopCharId);
		bool anyBought = false;
		foreach (IntPair secretPair in secretList)
		{
			int secretId = secretPair.First;
			int money = secretPair.Second;
			ReceiveSecretInformation(context, (SecretInformationId)secretId, taiwu.GetId(), taiwu.GetId());
			anyBought = true;
			shopCharacterData.CollectedSecretInformationIds.Remove(secretId);
			taiwu.ChangeResource(context, 6, -money);
			shopChar.ChangeResource(context, 6, money);
		}
		if (anyBought)
		{
			DomainManager.TaiwuEvent.SetListenerEventActionBoolArg("ShopActionComplete", "ConchShip_PresetKey_ShopHasAnyTrade", value: true);
		}
		if (shopCharacterData.CollectedSecretInformationIds.Count == 0)
		{
			shopCharacterData.CollectedSecretInformationIds.Add(-1);
		}
		DomainManager.Extra.SetSecretInformationShopCharacterData(context, shopCharId, shopCharacterData);
	}

	private void SecretArchiveSetup()
	{
		_nextSecretId = ((_secretInformation.Count <= 0) ? ((SecretInformationId)1) : ((SecretInformationId)(_secretInformation.Keys.Max((SecretInformationId id) => (int)id) + 1)));
		_nextSecretOccurenceId = ((_secretOccurence.Count <= 0) ? ((SecretOccurenceId)1) : ((SecretOccurenceId)(_secretOccurence.Keys.Max((SecretOccurenceId id) => (int)id) + 1)));
	}

	private void FixSecretInformation(DataContext context)
	{
		int[] array = _characterKnownSecrets.Keys.ToArray();
		foreach (int charId in array)
		{
			CharacterKnownSecret known = GetElement_CharacterKnownSecrets(charId);
			if (known.ConfidentialOccurenceIds.RemoveAll((SecretOccurenceId id) => !_secretOccurence.ContainsKey(id)) <= 0 && known.KnownSecrets.RemoveAll((SecretInformationId id) => !_secretInformation.ContainsKey(id)) <= 0)
			{
				continue;
			}
			SecretInformationId[] array2 = known.UsedCounts.Keys.ToArray();
			foreach (SecretInformationId secretId in array2)
			{
				if (!known.KnownSecrets.Contains(secretId))
				{
					known.UsedCounts.Remove(secretId);
				}
			}
			SetElement_CharacterKnownSecrets(charId, known, context);
		}
		if (CheckNeedFixLackOfJingangInformation())
		{
			FixLackOfJingangInformation(context);
		}
	}

	private void RecordSecretInformationAdd(DataContext context, GameData.Domains.Information.Secret.SecretInformation secret)
	{
		secret.Id = _nextSecretId;
		_nextSecretId = (SecretInformationId)(1 + (int)_nextSecretId);
		AddElement_SecretInformation(secret.Id, secret, context);
		RegisterOccurenceToInformationCache(secret.OccurenceId, secret.Id);
	}

	private void RecordSecretOccurenceUpdate(DataContext context, SecretOccurence occurence)
	{
		SetElement_SecretOccurence(occurence.Id, occurence, context);
	}

	private void RecordSecretOccurenceAdd(DataContext context, SecretOccurence occurence)
	{
		occurence.Id = _nextSecretOccurenceId;
		_nextSecretOccurenceId = (SecretOccurenceId)(1 + (int)_nextSecretOccurenceId);
		AddElement_SecretOccurence(occurence.Id, occurence, context);
	}

	private void RecordSecretInformationRemove(DataContext context, IEnumerable<SecretInformationId> idsToRemove)
	{
		foreach (SecretInformationId id in idsToRemove)
		{
			if (_secretInformation.TryGetValue(id, out var secret))
			{
				UnregisterOccurenceToInformationCache(secret.OccurenceId, secret.Id);
				RemoveElement_SecretInformation(id, context);
			}
		}
	}

	private void RecordSecretOccurenceRemove(DataContext context, IEnumerable<SecretOccurenceId> idsToRemove)
	{
		foreach (SecretOccurenceId id in idsToRemove)
		{
			if (_secretOccurence.TryGetValue(id, out var occurence))
			{
				UnregisterOccurenceToInformationCache(occurence.Id);
				RemoveElement_SecretOccurence(id, context);
			}
		}
	}

	private void InitializeSecretInformationHoldersCaches()
	{
		if (_secretInformationHoldersCache == null)
		{
			_secretInformationHoldersCache = new Dictionary<SecretInformationId, HashSet<int>>();
		}
		_secretInformationHoldersCache.Clear();
		foreach (KeyValuePair<int, CharacterKnownSecret> charKnownSecretPair in _characterKnownSecrets)
		{
			foreach (SecretInformationId id in charKnownSecretPair.Value.KnownSecrets)
			{
				RegisterSecretHolderCache(charKnownSecretPair.Key, id);
			}
		}
	}

	private IReadOnlySet<int> GetSecretInformationHolders(SecretInformationId id)
	{
		return _secretInformationHoldersCache.GetValueOrDefault(id, EmptyIntHashSet);
	}

	private void RegisterSecretHolderCache(int charId, SecretInformationId id)
	{
		if (!_secretInformationHoldersCache.TryGetValue(id, out var knownSecretCharIds))
		{
			knownSecretCharIds = new HashSet<int>();
			_secretInformationHoldersCache.Add(id, knownSecretCharIds);
		}
		knownSecretCharIds.Add(charId);
	}

	private void UnregisterSecretHolderCache(int charId, SecretInformationId id)
	{
		if (_secretInformationHoldersCache.TryGetValue(id, out var knownSecretCharIds))
		{
			knownSecretCharIds.Remove(charId);
		}
	}

	private void InitializeOccurenceToInformationCache()
	{
		if (_secretOccurenceToInformationCache == null)
		{
			_secretOccurenceToInformationCache = new Dictionary<SecretOccurenceId, HashSet<SecretInformationId>>();
		}
		_secretOccurenceToInformationCache.Clear();
		foreach (KeyValuePair<SecretInformationId, GameData.Domains.Information.Secret.SecretInformation> secretInfoPair in _secretInformation)
		{
			RegisterOccurenceToInformationCache(secretInfoPair.Value.OccurenceId, secretInfoPair.Key);
		}
	}

	private IReadOnlySet<SecretInformationId> GetOccurenceToSecretInformation(SecretOccurenceId occurenceId)
	{
		return _secretOccurenceToInformationCache.GetValueOrDefault(occurenceId, EmptyInfoIdHashSet);
	}

	private void RegisterOccurenceToInformationCache(SecretOccurenceId occurenceId, SecretInformationId informationId)
	{
		if (!_secretOccurenceToInformationCache.TryGetValue(occurenceId, out var set))
		{
			set = new HashSet<SecretInformationId>();
			_secretOccurenceToInformationCache.Add(occurenceId, set);
		}
		set.Add(informationId);
	}

	private void UnregisterOccurenceToInformationCache(SecretOccurenceId occurenceId, SecretInformationId informationId)
	{
		if (_secretOccurenceToInformationCache.TryGetValue(occurenceId, out var set))
		{
			set.Remove(informationId);
		}
	}

	private void UnregisterOccurenceToInformationCache(SecretOccurenceId occurenceId)
	{
		_secretOccurenceToInformationCache.Remove(occurenceId);
	}

	public static int CalcSecretOccurenceRemainingLifeTime(SecretOccurence occurence)
	{
		short duration = Config.SecretInformation.Instance[occurence.TemplateId].Duration;
		return (duration < 0) ? 1 : (duration - (DomainManager.World.GetCurrDate() - occurence.Date));
	}

	private bool IsSecretInformationDiffusible(SecretInformationId secretId, SecretOccurence occurence, sbyte fameType, int charId, int authority)
	{
		int authorityCost = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(occurence.TemplateId, fameType, CalcSecretOccurenceHolderCount(occurence.Id));
		int usedCountMax = (occurence.InBroadcast ? GlobalConfig.Instance.SecretInformationInBroadcastMaxUseCount : GlobalConfig.Instance.SecretInformationInPrivateMaxUseCount);
		bool confidential = false;
		int usedCount = 0;
		if (TryGetElement_CharacterKnownSecrets(charId, out var known))
		{
			confidential = known.ConfidentialOccurenceIds.Contains(occurence.Id);
			known.UsedCounts.TryGetValue(secretId, out usedCount);
		}
		return CalcSecretOccurenceRemainingLifeTime(occurence) > 0 && !confidential && usedCount < usedCountMax && authorityCost < authority;
	}

	private static int CalcSecretInformationShopValue(byte[] parameters, SecretInformationItem secretTemplate)
	{
		int characterLevelSum = 0;
		parameters.ExtractSecretParameters(secretTemplate, delegate(int i, int charId)
		{
			int num = 0;
			DeadCharacter character;
			if (DomainManager.Character.TryGetElement_Objects(charId, out var element))
			{
				num = element.GetOrganizationInfo().Grade + 1;
			}
			else if (DomainManager.Character.TryGetDeadCharacter(charId, out character))
			{
				num = character.OrganizationInfo.Grade + 1;
			}
			characterLevelSum += num;
			if ((uint)(i - 1) <= 1u)
			{
				characterLevelSum += num;
			}
		});
		return secretTemplate.SortValue * characterLevelSum * CalcSecretInformationDisplaySize(parameters, secretTemplate, new sbyte[5] { 0, 1, 1, 1, 1 }) * 100;
	}

	internal HashSet<SecretInformationRelationshipType> CheckSecretInformationRelationship(int characterId, SecretOccurenceId selfOccurenceIdForSnapshot, int targetCharacterId, SecretOccurenceId targetOccurenceIdForSnapshot)
	{
		return CheckSecretInformationRelationship(characterId, selfOccurenceIdForSnapshot, targetCharacterId, targetOccurenceIdForSnapshot, new HashSet<SecretInformationRelationshipType>());
	}

	internal HashSet<SecretInformationRelationshipType> CheckSecretInformationRelationship(int characterId, SecretOccurenceId selfOccurenceIdForSnapshot, int targetCharacterId, SecretOccurenceId targetOccurenceIdForSnapshot, HashSet<SecretInformationRelationshipType> container)
	{
		CharacterDomain characterDomain = DomainManager.Character;
		RelatedCharacters related = (selfOccurenceIdForSnapshot.Valid ? GetSecretInformationCharacterRelationSnapshot(QuerySecretOccurence(selfOccurenceIdForSnapshot), characterId) : characterDomain.GetRelatedCharacters(characterId));
		RelatedCharacters targetRelated = (targetOccurenceIdForSnapshot.Valid ? GetSecretInformationCharacterRelationSnapshot(QuerySecretOccurence(targetOccurenceIdForSnapshot), targetCharacterId) : characterDomain.GetRelatedCharacters(targetCharacterId));
		if (related != null && (related.BloodParents.Contains(targetCharacterId) || related.StepParents.Contains(targetCharacterId) || related.AdoptiveParents.Contains(targetCharacterId) || related.BloodChildren.Contains(targetCharacterId) || related.StepChildren.Contains(targetCharacterId) || related.AdoptiveChildren.Contains(targetCharacterId) || related.BloodBrothersAndSisters.Contains(targetCharacterId) || related.StepBrothersAndSisters.Contains(targetCharacterId) || related.AdoptiveBrothersAndSisters.Contains(targetCharacterId)))
		{
			container.Add(SecretInformationRelationshipType.Relative);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		if ((related != null && related.Friends.Contains(targetCharacterId)) || (targetRelated != null && targetRelated.Friends.Contains(characterId)))
		{
			container.Add(SecretInformationRelationshipType.Friend);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		if ((related != null && related.SwornBrothersAndSisters.Contains(targetCharacterId)) || (targetRelated != null && targetRelated.SwornBrothersAndSisters.Contains(characterId)))
		{
			container.Add(SecretInformationRelationshipType.SwornBrotherOrSister);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		if ((related != null && related.HusbandsAndWives.Contains(targetCharacterId)) || (targetRelated != null && targetRelated.HusbandsAndWives.Contains(characterId)))
		{
			container.Add(SecretInformationRelationshipType.HusbandOrWife);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		if (targetRelated != null && targetRelated.Adored.Contains(characterId))
		{
			if (related != null && related.Adored.Contains(targetCharacterId))
			{
				container.Add(SecretInformationRelationshipType.Lover);
			}
			container.Add(SecretInformationRelationshipType.Adorer);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		if (targetRelated != null && targetRelated.Enemies.Contains(characterId))
		{
			container.Add(SecretInformationRelationshipType.Enemy);
		}
		OrganizationInfo selfOrgInfo = new OrganizationInfo(-1, -1, principal: true, -1);
		OrganizationInfo targetOrgInfo = new OrganizationInfo(-1, -1, principal: true, -1);
		DeadCharacter deadCharacter;
		if (characterDomain.TryGetElement_Objects(characterId, out var character))
		{
			selfOrgInfo = character.GetOrganizationInfo();
		}
		else if ((deadCharacter = characterDomain.TryGetDeadCharacter(characterId)) != null)
		{
			selfOrgInfo = deadCharacter.OrganizationInfo;
		}
		if (characterDomain.TryGetElement_Objects(targetCharacterId, out character))
		{
			targetOrgInfo = character.GetOrganizationInfo();
		}
		else if ((deadCharacter = characterDomain.TryGetDeadCharacter(targetCharacterId)) != null)
		{
			targetOrgInfo = deadCharacter.OrganizationInfo;
		}
		if (selfOrgInfo.OrgTemplateId >= 0 && Config.Organization.Instance[selfOrgInfo.OrgTemplateId].IsSect && selfOrgInfo.OrgTemplateId == targetOrgInfo.OrgTemplateId)
		{
			container.Add(SecretInformationRelationshipType.Comrade);
		}
		if ((related != null && (related.Mentors.Contains(targetCharacterId) || related.Mentees.Contains(targetCharacterId))) || (targetRelated != null && (targetRelated.Mentors.Contains(characterId) || targetRelated.Mentees.Contains(characterId))))
		{
			container.Add(SecretInformationRelationshipType.MentorAndMentee);
			container.Add(SecretInformationRelationshipType.Allied);
		}
		int bloodParent = characterDomain.GetBloodParent(characterId, 1);
		if (bloodParent >= 0)
		{
			if (!characterDomain.TryGetActualBloodParent(bloodParent, characterId, out var actualBloodParentId))
			{
				actualBloodParentId = bloodParent;
			}
			if (actualBloodParentId == targetCharacterId)
			{
				container.Add(SecretInformationRelationshipType.ActualBloodFather);
			}
		}
		return container;
	}

	private RelatedCharacters GetSecretInformationCharacterRelationSnapshot(SecretOccurence occurence, int characterId)
	{
		CharacterRelationshipSnapshot snapshot;
		return occurence.CharacterRelationshipSnapshotCollection.TryGetValue(characterId, out snapshot) ? snapshot.RelatedCharacters : null;
	}

	internal int CalcSecretOccurenceHolderCount(SecretOccurenceId occurenceId)
	{
		IReadOnlySet<SecretInformationId> infoIds = GetOccurenceToSecretInformation(occurenceId);
		HashSet<int> charSet = ObjectPool<HashSet<int>>.Instance.Get();
		foreach (SecretInformationId info in infoIds)
		{
			charSet.UnionWith(GetSecretInformationHolders(info));
		}
		int count = charSet.Count;
		ObjectPool<HashSet<int>>.Instance.Return(charSet);
		return count;
	}

	private static IReadOnlyList<sbyte> GetSecretInformationSettings()
	{
		return GlobalConfig.Instance.SecretInformationDefaultDisplaySettings;
	}

	internal bool RequestShopSecretInformationIdShouldExclude(SecretInformationId secretId, EventArgBox argBox, int charId)
	{
		if (!secretId.Valid)
		{
			return true;
		}
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		SecretOccurence occurence;
		byte[] secretParams = secret.QueryParameters(out occurence);
		if (occurence.InBroadcast)
		{
			return true;
		}
		if (QueryCharacterKnownSecretInformationIds(DomainManager.Taiwu.GetTaiwuCharId()).Contains(secretId))
		{
			return true;
		}
		bool result = false;
		SecretInformationItem config = Config.SecretInformation.Instance.GetItem(occurence.TemplateId);
		secretParams.ExtractSecretParameters(config, delegate(int idx, int argCharId)
		{
			if ((idx == 0 && argCharId == charId) || (idx == 1 && argCharId == charId))
			{
				result = true;
			}
		});
		return result;
	}

	internal EventArgBox FillSecretArgBox(GameData.Domains.Information.Secret.SecretInformation secretInformation, EventArgBox target)
	{
		secretInformation.QueryParameters(out var occurence).ExtractSecretParameters(Config.SecretInformation.Instance[occurence.TemplateId], delegate(int idx, int charId)
		{
			target.Set($"arg{idx}", charId);
		}, delegate(int idx, Location location)
		{
			target.Set($"arg{idx}", location);
		}, delegate(int idx, sbyte itemKey)
		{
			target.Set($"arg{idx}", itemKey);
		}, delegate(int idx, ItemKey resourceType)
		{
			target.Set($"arg{idx}", resourceType);
		}, delegate(int idx, short templateId)
		{
			target.Set($"arg{idx}", templateId);
		}, delegate(int idx, short templateId)
		{
			target.Set($"arg{idx}", templateId);
		}, delegate(int idx, int integerValue)
		{
			target.Set($"arg{idx}", integerValue);
		});
		target.Set("templateId", occurence.TemplateId);
		target.Set("metaDataId", secretInformation.Id);
		return target;
	}

	public short GetHighestScoreRelation(int charId)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (charId == taiwuId)
		{
			return short.MaxValue;
		}
		short relation = -1;
		int highest = 0;
		(ushort, ushort) relationBetweenCharacters = DomainManager.Character.GetRelationBetweenCharacters(charId, taiwuId);
		ushort relationToTaiwu = relationBetweenCharacters.Item1;
		ushort relationFromTaiwu = relationBetweenCharacters.Item2;
		GameData.Domains.Character.Character character;
		DeadCharacter dead;
		OrganizationInfo orgInfo = (DomainManager.Character.TryGetElement_Objects(charId, out character) ? character.GetOrganizationInfo() : (DomainManager.Character.TryGetDeadCharacter(charId, out dead) ? dead.OrganizationInfo : OrganizationInfo.None));
		for (short type = 0; type <= 9; type++)
		{
			if (type == 4)
			{
				if (orgInfo.OrgTemplateId == 16 && highest < GlobalConfig.Instance.SecretRelationFactor[type])
				{
					highest = GlobalConfig.Instance.SecretRelationFactor[type];
					relation = type;
				}
			}
			else
			{
				sbyte[] relationTypeIds = RelationDisplayType.Instance[type].RelationTypeIds;
				foreach (sbyte typeId in relationTypeIds)
				{
					ushort relationType = RelationType.GetRelationType(typeId);
					if (((relationToTaiwu != ushort.MaxValue && RelationType.HasRelation(relationToTaiwu, relationType)) || (relationFromTaiwu != ushort.MaxValue && RelationType.HasRelation(relationFromTaiwu, relationType))) && highest < GlobalConfig.Instance.SecretRelationFactor[type])
					{
						highest = GlobalConfig.Instance.SecretRelationFactor[type];
						relation = type;
					}
				}
			}
		}
		return relation;
	}

	public bool TryGetSecretInformationSnapshot(SecretInformationId secretId, CharacterKnownSecret known, out SecretInformationSnapshot snapshot)
	{
		snapshot = null;
		GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation(secretId);
		if (secret != null)
		{
			SecretOccurence secretOccurence = DomainManager.Information.QuerySecretOccurence(secret.Id);
			if (secretOccurence != null && secretOccurence.PackedParameters != null)
			{
				int knownCount = DomainManager.Information.CalcSecretInformationKnownCharacterCount(secretId);
				snapshot = new SecretInformationSnapshot
				{
					SecretInformationId = (int)secretId,
					SecretInformationTemplateId = secretOccurence.TemplateId,
					HolderCount = knownCount,
					SourceCharacterId = secret.SourceCharacterId,
					AuthorityCost = DomainManager.Information.CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(secretOccurence.TemplateId, DomainManager.Taiwu.GetTaiwu().GetFameType(), knownCount),
					IsInBroadcast = secretOccurence.InBroadcast,
					UsedCount = 0,
					Location = secretOccurence.Location,
					OccurenceDate = secretOccurence.Date,
					ParametersPack = secretOccurence.PackedParameters.ToArray()
				};
				if (known.UsedCounts.TryGetValue(secretId, out var usedCount))
				{
					snapshot.UsedCount = usedCount;
				}
				return true;
			}
		}
		return false;
	}

	[Conditional("SECRETINFORMATION_VERBOSE")]
	private static void LogSecretInformation(string tag, string message)
	{
		SecretLogger.Info("[" + tag + "]: " + message);
	}

	[Conditional("SECRETINFORMATION_VERBOSE")]
	private static void LogWarningSecretInformation(string tag, string message)
	{
		SecretLogger.Warn("[" + tag + "]: " + message);
	}

	[Conditional("SECRETINFORMATION_VERBOSE")]
	private static void LogErrorSecretInformation(string tag, string message)
	{
		SecretLogger.Error("[" + tag + "]: " + message);
	}

	public void ProcessSecretInformationAdvanceMonth(DataContext context)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		long elapsed = Extensions.TimedInvoke(delegate
		{
			MakeSettlementsInformation(context);
		});
		_completedNpcDisseminateIndices.Clear();
		elapsed = Extensions.TimedInvoke(delegate
		{
			List<int> list = new List<int>();
			list.Clear();
			list.AddRange(_characterKnownSecrets.Keys);
			list.Remove(taiwuCharId);
			foreach (int current in list)
			{
				PlanDisseminateSecretInformation(context, current);
			}
		});
		elapsed = Extensions.TimedInvoke(delegate
		{
			foreach (int current in DomainManager.Extra.GetSecretInformationShopCharacterKeys())
			{
				SecretInformationShopCharacterData secretInformationShopCharacterData = DomainManager.Extra.AddOrGetSecretInformationShopCharacterData(context, current);
				secretInformationShopCharacterData.CollectedSecretInformationIds.Clear();
				DomainManager.Extra.SetSecretInformationShopCharacterData(context, current, secretInformationShopCharacterData);
			}
		});
		elapsed = Extensions.TimedInvoke(delegate
		{
			MetabolismSecretInformation(context);
		});
	}

	private void MetabolismSecretInformation(DataContext context)
	{
		Dictionary<SecretInformationId, int> refCount = new Dictionary<SecretInformationId, int>();
		List<SecretInformationId> secretIds = _secretInformation.Keys.ToList();
		foreach (SecretInformationId secretId in secretIds)
		{
			if (!_secretInformation.TryGetValue(secretId, out var secret))
			{
				continue;
			}
			SecretOccurence occurence;
			byte[] secretParams = secret.QueryParameters(out occurence);
			IReadOnlySet<int> tempKnownIds = GetSecretInformationHolders(secretId);
			int lifeTime = CalcSecretOccurenceRemainingLifeTime(occurence);
			SecretInformationItem config = Config.SecretInformation.Instance[occurence.TemplateId];
			if (tempKnownIds.Count >= config.MaxPersonAmount)
			{
				MakeSecretBroadcast(context, secretId, occurence, secretParams, secret.SourceCharacterId, delegate(SecretBroadcastPostProcessContext bCtx)
				{
					SecretBroadcastPostProcess(context, bCtx, secret.Id, occurence, secret.SourceCharacterId);
				});
			}
			if (lifeTime <= 0 || occurence.InBroadcast)
			{
				foreach (int charId in tempKnownIds)
				{
					DiscardSecretInformation(context, charId, secret.Id);
				}
			}
			refCount[secret.Id] = (occurence.InBroadcast ? 1 : tempKnownIds.Count);
		}
		HashSet<SecretInformationId> secretsToRemoveIds = new HashSet<SecretInformationId>();
		foreach (KeyValuePair<SecretInformationId, int> refPair in refCount)
		{
			if (refPair.Value < 1)
			{
				secretsToRemoveIds.Add(refPair.Key);
			}
		}
		HashSet<SecretOccurenceId> occurenceToRemoveIds = new HashSet<SecretOccurenceId>();
		foreach (SecretOccurence occurence2 in QueryAllSecretOccurence((SecretOccurence _) => true))
		{
			bool shouldDelete = false;
			int lifeTime2 = CalcSecretOccurenceRemainingLifeTime(occurence2);
			if (lifeTime2 <= 0)
			{
				shouldDelete = true;
			}
			if (shouldDelete)
			{
				SecretOccurenceId occurenceId = occurence2.Id;
				occurenceToRemoveIds.Add(occurenceId);
				IReadOnlySet<SecretInformationId> mappedSet = GetOccurenceToSecretInformation(occurenceId);
				secretsToRemoveIds.UnionWith(mappedSet);
			}
		}
		RecordSecretInformationRemove(context, secretsToRemoveIds);
		RecordSecretOccurenceRemove(context, occurenceToRemoveIds);
	}

	private void SecretReleaseFromBroadcast(DataContext context, SecretOccurence secretOccurence)
	{
		secretOccurence.InBroadcast = false;
		RecordSecretOccurenceUpdate(context, secretOccurence);
	}

	private void MakeSecretBroadcast(DataContext context, SecretInformationId secretInformationId, SecretOccurence secretOccurence, byte[] secretParams, int sourceCharacterId, Action<SecretBroadcastPostProcessContext> onPostProcess)
	{
		if (secretOccurence.InBroadcast)
		{
			return;
		}
		short occurenceTemplateId = secretOccurence.TemplateId;
		HashSet<SecretInformationId> sameOccurenceSecrets = (from secret in QueryAllSecretInformation((GameData.Domains.Information.Secret.SecretInformation secret) => secret.OccurenceId == secretOccurence.Id)
			select secret.Id).ToHashSet();
		int[] array = _characterKnownSecrets.Keys.ToArray();
		foreach (int charId in array)
		{
			CharacterKnownSecret known = _characterKnownSecrets[charId];
			bool modified = false;
			foreach (SecretInformationId secretId in sameOccurenceSecrets)
			{
				if (known.KnownSecrets.Remove(secretId))
				{
					modified = true;
					known.UsedCounts.Remove(secretId);
					UnregisterSecretHolderCache(charId, secretId);
				}
			}
			if (modified)
			{
				SetElement_CharacterKnownSecrets(charId, known, context);
			}
		}
		foreach (SecretInformationId id in sameOccurenceSecrets)
		{
			if (id != secretInformationId)
			{
				RemoveElement_SecretInformation(id, context);
				UnregisterOccurenceToInformationCache(secretOccurence.Id, id);
			}
		}
		SecretInformationProcessor processor = DomainManager.Information.SecretInformationProcessorPool.Get();
		if (!processor.Initialize(secretOccurence, secretParams))
		{
			DomainManager.Information.SecretInformationProcessorPool.Return(processor);
			return;
		}
		processor.Initialize_ForBroadcastEffect(context.Random);
		List<SecretInformationHappinessChangeItem> happinessList = processor.GetAllSecretInformationHappinessChange();
		foreach (SecretInformationHappinessChangeItem item in happinessList)
		{
			ChangeRoleHappiness(item.CharacterId, item.DeltaHappiness);
		}
		List<SecretInformationFavorChangeItem> favorList = processor.GetAllSecretInformationFavorabilityChangeWithSource(sourceCharacterId);
		foreach (SecretInformationFavorChangeItem item2 in favorList)
		{
			ChangeFavorability(item2.CharacterId, item2.TargetId, item2.DeltaFavor);
		}
		List<SecretInformationStartEnemyRelationItem> startEnemyRelationItem = processor.GetAllSecretInformationStartEnemyRelationItems(sourceCharacterId);
		if (occurenceTemplateId >= 0)
		{
			for (int i = startEnemyRelationItem.Count - 1; i >= 0; i--)
			{
				if (context.Random.CheckPercentProb(startEnemyRelationItem[i].Odds))
				{
					if (DomainManager.Character.TryGetElement_Objects(startEnemyRelationItem[i].CharacterId, out var character) && DomainManager.Character.TryGetElement_Objects(startEnemyRelationItem[i].TargetId, out var targetChar) && Config.Character.Instance[character.GetTemplateId()].CreatingType == 1 && Config.Character.Instance[targetChar.GetTemplateId()].CreatingType == 1)
					{
						GameData.Domains.Character.Character.ApplyAddRelation_Enemy(context, character, targetChar, startEnemyRelationItem[i].CharacterId == DomainManager.Taiwu.GetTaiwuCharId(), 5, new CharacterBecomeEnemyInfo(character)
						{
							SecretInformationTemplateId = occurenceTemplateId,
							Location = targetChar.GetValidLocation()
						});
					}
				}
				else
				{
					startEnemyRelationItem.RemoveAt(i);
				}
			}
		}
		Dictionary<int, GameData.Domains.Character.Character> activeActorList = processor.GetActiveActorList_WithActorIndex();
		Dictionary<int, List<short>> allActorFameList = new Dictionary<int, List<short>>();
		Dictionary<short, short> collectedFameWithLevel = new Dictionary<short, short>();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (KeyValuePair<int, GameData.Domains.Character.Character> item3 in activeActorList)
		{
			int charId2 = item3.Value.GetId();
			List<short> fameList = processor.GetActorFameRecord_WithActorIndex(item3.Key);
			collectedFameWithLevel.Clear();
			foreach (short fameKey in fameList)
			{
				collectedFameWithLevel.TryGetValue(fameKey, out var level);
				collectedFameWithLevel[fameKey] = (short)(level + 1);
			}
			foreach (KeyValuePair<short, short> famePair in collectedFameWithLevel)
			{
				item3.Value.RecordFameAction(context, famePair.Key, -1, famePair.Value);
				if (item3.Value.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
				{
					InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
					sbyte changeValue = FameAction.Instance[famePair.Key].Fame;
					if (changeValue > 0)
					{
						collection.AddFameIncreased(charId2);
					}
					else if (changeValue < 0)
					{
						collection.AddFameDecreased(charId2);
					}
				}
			}
			allActorFameList.Add(item3.Key, fameList);
			if (!DomainManager.World.GetWorldFunctionsStatus(4) || EventHelper.DukeSkill_CheckCharacterHasTitle(charId2))
			{
				continue;
			}
			OrganizationInfo orgInfo;
			sbyte stateTemplateId;
			if (item3.Value != null && item3.Value.GetId() == taiwuCharId)
			{
				short reasonKey;
				sbyte punishLevel = processor.CalcTaiwuPunishLevel(taiwuCharId, out reasonKey, out orgInfo);
				if (punishLevel >= 0)
				{
					GetBountyHome()?.AddBounty(context, item3.Value, punishLevel, reasonKey);
				}
			}
			else if (item3.Value != null && item3.Value.GetOrganizationInfo().SettlementId == DomainManager.Taiwu.GetTaiwuVillageSettlementId())
			{
				stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId);
				Sect home = GetBountyHome2();
				if (home != null)
				{
					OrganizationInfo orgInfo2 = item3.Value.GetOrganizationInfo();
					orgInfo2.OrgTemplateId = EventHelper.GetStateMainCityOrgTemplateId(stateTemplateId);
					short reasonKey2;
					sbyte punishLevel2 = processor.CalcSectPunishLevelWithSpecificOrganization(item3.Key, out reasonKey2, orgInfo2);
					if (punishLevel2 >= 0)
					{
						home.AddBounty(context, item3.Value, punishLevel2, reasonKey2);
					}
				}
			}
			else
			{
				short reasonKey3;
				sbyte punishLevel3 = processor.CalSectPunishLevel_WithActorIndex(item3.Key, out reasonKey3);
				OrganizationInfo orgInfo3 = processor.GetSectInfoSafe(charId2);
				DomainManager.Organization.OnSectMemberCrimeMadePublic(context, item3.Value, orgInfo3, punishLevel3, reasonKey3);
			}
			Sect GetBountyHome()
			{
				if (!DomainManager.Organization.TryGetElement_Sects(orgInfo.SettlementId, out var sect))
				{
					if (orgInfo.SettlementId < 0)
					{
						return null;
					}
					Location settlementLocation = DomainManager.Organization.GetSettlement(orgInfo.SettlementId).GetLocation();
					if (!settlementLocation.IsValid())
					{
						return null;
					}
					sbyte stateTemplateId2 = DomainManager.Map.GetStateTemplateIdByAreaId(settlementLocation.AreaId);
					MapStateItem stateCfg = MapState.Instance[stateTemplateId2];
					if (stateCfg.SectID < 0)
					{
						return null;
					}
					sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(stateCfg.SectID);
				}
				return sect;
			}
			Sect GetBountyHome2()
			{
				MapStateItem stateCfg = MapState.Instance[stateTemplateId];
				if (stateCfg.SectID < 0)
				{
					return null;
				}
				return (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(stateCfg.SectID);
			}
		}
		onPostProcess?.Invoke(new SecretBroadcastPostProcessContext(processor.GetSecretInformationActorBroadcastType(), allActorFameList, happinessList, favorList, startEnemyRelationItem, activeActorList, processor.GetSecretInformationArgList()));
		DomainManager.Information.SecretInformationProcessorPool.Return(processor);
		secretOccurence.InBroadcast = true;
		RecordSecretOccurenceUpdate(context, secretOccurence);
		static void ChangeFavorability(int charAId, int charBId, int deltaFavor)
		{
			if (charAId != charBId && DomainManager.Character.TryGetElement_Objects(charAId, out var characterA) && DomainManager.Character.TryGetElement_Objects(charBId, out var characterB))
			{
				int totalDelta = deltaFavor;
				while (totalDelta != 0)
				{
					int curDelta = Math.Clamp(totalDelta, -30000, 30000);
					EventHelper.ChangeFavorabilityOptional(characterA, characterB, (short)curDelta, 3);
					totalDelta -= curDelta;
				}
			}
		}
		void ChangeRoleHappiness(int characterId, int deltaValue)
		{
			if (DomainManager.Character.TryGetElement_Objects(characterId, out var character2))
			{
				character2.ChangeHappiness(context, deltaValue);
				if (DomainManager.Taiwu.IsInGroup(characterId))
				{
					InstantNotificationCollection collection2 = DomainManager.World.GetInstantNotificationCollection();
					if (deltaValue > 0)
					{
						collection2.AddHappinessIncreased(character2.GetId());
					}
					else if (deltaValue < 0)
					{
						collection2.AddHappinessDecreased(character2.GetId());
					}
				}
			}
		}
	}

	internal void MakeSecretBroadcast(DataContext context, SecretInformationId secretInformationId, int sourceCharacterId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretInformationId);
		SecretOccurence occurence;
		byte[] secretParams = secret.QueryParameters(out occurence);
		MakeSecretBroadcast(context, secretInformationId, occurence, secretParams, sourceCharacterId, delegate(SecretBroadcastPostProcessContext bCtx)
		{
			SecretBroadcastPostProcess(context, bCtx, secret.Id, occurence, sourceCharacterId);
		});
	}

	private void SecretBroadcastPostProcess(DataContext context, SecretBroadcastPostProcessContext bCtx, SecretInformationId secretId, SecretOccurence occurence, int sourceCharacterId)
	{
		SecretInformationItem config = Config.SecretInformation.Instance[occurence.TemplateId];
		if (DomainManager.Taiwu.GetTaiwuCharId() == sourceCharacterId)
		{
			int cost = DomainManager.Information.CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(occurence.TemplateId, DomainManager.Taiwu.GetTaiwu().GetFameType(), DomainManager.Information.CalcSecretInformationKnownCharacterCount(secretId));
			ProfessionFormulaItem formula = ProfessionFormula.Instance[35];
			int addSeniority = formula.Calculate(cost, config.SortValue);
			DomainManager.Extra.ChangeProfessionSeniority(context, 4, addSeniority);
		}
		byte broadcastType = bCtx.InformationActorBroadcastType;
		if (broadcastType == 2)
		{
			return;
		}
		SecretInformationBroadcastTipsData data = new SecretInformationBroadcastTipsData
		{
			MetaDataId = (int)secretId,
			BroadcastType = broadcastType
		};
		if (!bCtx.AllActorFameList.TryGetValue(0, out var fameActionsOfMain))
		{
			fameActionsOfMain = new List<short>();
		}
		if (!bCtx.AllActorFameList.TryGetValue(1, out var fameActionsOfTarget1))
		{
			fameActionsOfTarget1 = new List<short>();
		}
		if (!bCtx.AllActorFameList.TryGetValue(2, out var fameActionsOfTarget2))
		{
			fameActionsOfTarget2 = new List<short>();
		}
		data.FameActionsOfMain = new List<int>();
		foreach (short fameKey in fameActionsOfMain)
		{
			FameActionItem fameConfig = FameAction.Instance.GetItem(fameKey);
			if (fameConfig != null)
			{
				data.FameActionsOfMain.Add(fameKey);
				data.FameActionsOfMain.Add(fameConfig.Fame);
				data.FameActionsOfMain.Add(fameConfig.Duration);
			}
		}
		data.FameActionsOfTarget1 = new List<int>();
		foreach (short fameKey2 in fameActionsOfTarget1)
		{
			FameActionItem fameConfig2 = FameAction.Instance.GetItem(fameKey2);
			if (fameConfig2 != null)
			{
				data.FameActionsOfTarget1.Add(fameKey2);
				data.FameActionsOfTarget1.Add(fameConfig2.Fame);
				data.FameActionsOfTarget1.Add(fameConfig2.Duration);
			}
		}
		data.FameActionsOfTarget2 = new List<int>();
		foreach (short fameKey3 in fameActionsOfTarget2)
		{
			FameActionItem fameConfig3 = FameAction.Instance.GetItem(fameKey3);
			if (fameConfig3 != null)
			{
				data.FameActionsOfTarget2.Add(fameKey3);
				data.FameActionsOfTarget2.Add(fameConfig3.Fame);
				data.FameActionsOfTarget2.Add(fameConfig3.Duration);
			}
		}
		data.HappinessUpCharacters = (from x in bCtx.AllHappinessChange
			where x.DeltaHappiness > 0
			select x.CharacterId).Take(4).ToList();
		data.HappinessDownCharacters = (from x in bCtx.AllHappinessChange
			where x.DeltaHappiness < 0
			select x.CharacterId).Take(4).ToList();
		IReadOnlyList<int> actorList = bCtx.ArgList;
		data.FavorToMainUpCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(0, out var value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[0] && x.DeltaFavor > 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		data.FavorToMainDownCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(0, out value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[0] && x.DeltaFavor < 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		data.FavorToTarget1UpCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(1, out value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[1] && x.DeltaFavor > 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		data.FavorToTarget1DownCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(1, out value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[1] && x.DeltaFavor < 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		data.FavorToTarget2UpCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(2, out value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[2] && x.DeltaFavor > 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		data.FavorToTarget2DownCharacters = (bCtx.ActorListWithActorIndex.TryGetValue(2, out value) ? new List<int>() : (from x in bCtx.AllFavorabilityChangeWithSource
			where x.TargetId == actorList[2] && x.DeltaFavor < 0
			orderby x.Priority
			select x.CharacterId).Take(4).ToList());
		SecretInformationBroadcastTipsExtraData extraData = new SecretInformationBroadcastTipsExtraData
		{
			MetaDataId = (int)secretId,
			StartEnemyRelationCharactersToActor = (from x in bCtx.AllSecretInformationStartEnemyRelationItems
				where x.TargetId == actorList[0]
				select x.CharacterId).Take(4).ToList(),
			StartEnemyRelationCharactersToReactor = (from x in bCtx.AllSecretInformationStartEnemyRelationItems
				where x.TargetId == actorList[1]
				select x.CharacterId).Take(4).ToList(),
			StartEnemyRelationCharactersToSecactor = (from x in bCtx.AllSecretInformationStartEnemyRelationItems
				where x.TargetId == actorList[2]
				select x.CharacterId).Take(4).ToList()
		};
		if (sourceCharacterId != -1)
		{
			extraData.StartEnemyRelationCharactersToSource = (from x in bCtx.AllSecretInformationStartEnemyRelationItems
				where x.TargetId == sourceCharacterId
				select x.CharacterId).Take(4).ToList();
			extraData.StartEnemyRelationCharactersToSource.Insert(0, sourceCharacterId);
		}
		DomainManager.Extra.AddSecretInformationBroadcastNotify(data, context);
		DomainManager.Extra.AddSecretInformationBroadcastNotifyExtra(extraData, context);
	}

	public unsafe SecretInformationId AddSecretInformation(DataContext context, SecretOccurence secretOccurence, bool withInitialDistribute, bool necessarily, Action<ICollection<int>> distributeCallback)
	{
		bool isTaiwuKeyCharacter = false;
		bool isKeyCharacterRelatedByTaiwu = false;
		SecretInformationItem secretTemplate = Config.SecretInformation.Instance[secretOccurence.TemplateId];
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int discoveryRate = secretTemplate.DiscoveryRate;
		int argGradeSum = 0;
		int argGradeCount = 0;
		int argCharFameSum = 0;
		int argCharCount = 0;
		GameData.Domains.Information.Secret.SecretInformation secret = new GameData.Domains.Information.Secret.SecretInformation();
		ObjectPool<HashSet<int>> pool = ObjectPool<HashSet<int>>.Instance;
		HashSet<int> set = pool.Get();
		Dictionary<int, CharacterRelationshipSnapshot> characterRelationshipSnapshot = new Dictionary<int, CharacterRelationshipSnapshot>();
		Dictionary<int, CharacterExtraInfo> characterExtraInfo = new Dictionary<int, CharacterExtraInfo>();
		byte[] parameters = secretOccurence.PackedParameters;
		if (parameters != null)
		{
			sbyte resourceType = -1;
			parameters.ExtractSecretParameters(secretTemplate, delegate(int index, int charId)
			{
				int num = -1;
				DeadCharacter deadCharacter = DomainManager.Character.TryGetDeadCharacter(charId);
				if (DomainManager.Character.TryGetElement_Objects(charId, out var element))
				{
					num = element.GetFameType();
					argGradeSum += element.GetOrganizationInfo().Grade;
				}
				else if (deadCharacter != null)
				{
					num = deadCharacter.FameType;
					argGradeSum += deadCharacter.OrganizationInfo.Grade;
				}
				argCharCount++;
				argGradeCount++;
				if (num == -2)
				{
					argCharFameSum = argCharFameSum;
				}
				else if (FameTypeForDiscoveryRates.CheckIndex(num))
				{
					argCharFameSum += Math.Abs(FameTypeForDiscoveryRates[num]);
				}
				RelatedCharacter relation;
				if (charId == taiwuCharId)
				{
					isTaiwuKeyCharacter = true;
				}
				else if (DomainManager.Character.TryGetRelation(taiwuCharId, charId, out relation))
				{
					isKeyCharacterRelatedByTaiwu = true;
				}
				if (DomainManager.Character.TryGetElement_Objects(charId, out var element2) && index == 0)
				{
					secretOccurence.Location = element2.GetLocation();
				}
				if (secretTemplate.RelationshipSnapshotParameterIndices != null && Enumerable.Contains(secretTemplate.RelationshipSnapshotParameterIndices, index))
				{
					RelatedCharacters relatedCharacters = DomainManager.Character.GetRelatedCharacters(charId);
					if (relatedCharacters != null)
					{
						relatedCharacters = GameData.Serializer.Serializer.CreateCopy(relatedCharacters);
						relatedCharacters.General.Clear();
						HashSet<int> collection = DomainManager.Character.GetReversedRelatedCharIds(charId, 16384).GetCollection();
						if (collection != null)
						{
							foreach (int current in collection)
							{
								if (!characterRelationshipSnapshot.ContainsKey(current))
								{
									RelatedCharacters relatedCharacters2 = DomainManager.Character.GetRelatedCharacters(current);
									relatedCharacters2 = GameData.Serializer.Serializer.CreateCopy(relatedCharacters2);
									relatedCharacters2.Friends.Clear();
									relatedCharacters2.General.Clear();
									relatedCharacters2.Mentees.Clear();
									relatedCharacters2.Mentors.Clear();
									relatedCharacters2.AdoptiveChildren.Clear();
									relatedCharacters2.AdoptiveParents.Clear();
									relatedCharacters2.BloodChildren.Clear();
									relatedCharacters2.BloodParents.Clear();
									relatedCharacters2.StepChildren.Clear();
									relatedCharacters2.StepParents.Clear();
									relatedCharacters2.HusbandsAndWives.Clear();
									relatedCharacters2.AdoptiveBrothersAndSisters.Clear();
									relatedCharacters2.BloodBrothersAndSisters.Clear();
									relatedCharacters2.StepBrothersAndSisters.Clear();
									relatedCharacters2.SwornBrothersAndSisters.Clear();
									characterRelationshipSnapshot[current] = new CharacterRelationshipSnapshot
									{
										RelatedCharacters = relatedCharacters2
									};
								}
							}
						}
						HashSet<int> collection2 = DomainManager.Character.GetReversedRelatedCharIds(charId, 32768).GetCollection();
						if (collection2 != null)
						{
							foreach (int current2 in collection2)
							{
								if (!characterRelationshipSnapshot.ContainsKey(current2))
								{
									RelatedCharacters relatedCharacters3 = DomainManager.Character.GetRelatedCharacters(current2);
									relatedCharacters3 = GameData.Serializer.Serializer.CreateCopy(relatedCharacters3);
									relatedCharacters3.Friends.Clear();
									relatedCharacters3.General.Clear();
									relatedCharacters3.Mentees.Clear();
									relatedCharacters3.Mentors.Clear();
									relatedCharacters3.AdoptiveChildren.Clear();
									relatedCharacters3.AdoptiveParents.Clear();
									relatedCharacters3.BloodChildren.Clear();
									relatedCharacters3.BloodParents.Clear();
									relatedCharacters3.StepChildren.Clear();
									relatedCharacters3.StepParents.Clear();
									relatedCharacters3.HusbandsAndWives.Clear();
									relatedCharacters3.AdoptiveBrothersAndSisters.Clear();
									relatedCharacters3.BloodBrothersAndSisters.Clear();
									relatedCharacters3.StepBrothersAndSisters.Clear();
									relatedCharacters3.SwornBrothersAndSisters.Clear();
									characterRelationshipSnapshot[current2] = new CharacterRelationshipSnapshot
									{
										RelatedCharacters = relatedCharacters3
									};
								}
							}
						}
						set.Clear();
						relatedCharacters.GetAllRelatedCharIds(set, secretTemplate.IsGeneralRelationCharactersNeedSnapshot);
						foreach (int current3 in set)
						{
							characterExtraInfo.TryGetValue(current3, out var value);
							value.AliveState = ((!DomainManager.Character.TryGetElement_Objects(charId, out var _)) ? ((sbyte)1) : ((sbyte)0));
							characterExtraInfo[current3] = value;
						}
						characterRelationshipSnapshot[charId] = new CharacterRelationshipSnapshot
						{
							RelatedCharacters = relatedCharacters
						};
					}
				}
				if (secretTemplate.IsRelationCharactersAliveStateNeedSnapshot || (secretTemplate.ExtraSnapshotParameterIndices != null && Enumerable.Contains(secretTemplate.ExtraSnapshotParameterIndices, index)))
				{
					characterExtraInfo.TryGetValue(charId, out var value2);
					if (deadCharacter != null)
					{
						value2.FameType = deadCharacter.FameType;
						value2.MonkType = deadCharacter.MonkType;
						value2.OrgInfo = deadCharacter.OrganizationInfo;
					}
					else if (element != null)
					{
						value2.FameType = element.GetFameType();
						value2.MonkType = element.GetMonkType();
						value2.OrgInfo = element.GetOrganizationInfo();
					}
					characterExtraInfo[charId] = value2;
				}
			}, delegate
			{
			}, delegate(int _, sbyte r)
			{
				resourceType = r;
			}, delegate(int _, ItemKey itemKey)
			{
				if (itemKey.IsValid())
				{
					argGradeSum += ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
					argGradeCount++;
				}
			}, delegate(int _, short combatSkillId)
			{
				argGradeSum += Config.CombatSkill.Instance[combatSkillId].Grade;
				argGradeCount++;
			}, delegate(int _, short lifeSkillId)
			{
				argGradeSum += LifeSkill.Instance[lifeSkillId].Grade;
				argGradeCount++;
			}, delegate(int _, int value)
			{
				if (resourceType != -1)
				{
					sbyte b2 = ResourceTypeHelper.ResourceAmountToGrade(resourceType, value);
					if (b2 >= 0)
					{
						argGradeSum += b2;
						argGradeCount++;
					}
				}
			});
		}
		secretOccurence.CharacterRelationshipSnapshotCollection = characterRelationshipSnapshot;
		secretOccurence.CharacterExtraInfoCollection = characterExtraInfo;
		RecordSecretOccurenceUpdate(context, secretOccurence);
		secret.OccurenceId = secretOccurence.Id;
		RecordSecretInformationAdd(context, secret);
		string discoveryRateLog = $"[{secret.Id}] create by [{secret.OccurenceId}] templateId[{secretTemplate.TemplateId}]({secretTemplate.Name}) ";
		if (isTaiwuKeyCharacter)
		{
			discoveryRate = secretTemplate.DiscoveryRateTaiwu;
		}
		else
		{
			int a = ((argCharCount > 0) ? (argCharFameSum / argCharCount) : 0);
			a = Math.Max(a * secretTemplate.DiscoveryRateFactorA, 0);
			int b = ((argGradeCount > 0) ? (argGradeSum / argGradeCount) : 0);
			b = Math.Max(b * secretTemplate.DiscoveryRateFactorB, 0);
			int c = (isKeyCharacterRelatedByTaiwu ? secretTemplate.DiscoveryRateFactorC : 0);
			discoveryRate = discoveryRate * Math.Max(100 + a + b, 100) / 100;
			discoveryRate = Math.Max(c, discoveryRate);
			discoveryRateLog += $"discoveryRate = {{A: {a} B: {b} C: {c}}} ";
		}
		discoveryRateLog += $"= {(double)discoveryRate / 100.0:#0.00}% (necessarily={necessarily}) ";
		if (context.Random.CheckProb(discoveryRate, 10000) || necessarily)
		{
			if (secretTemplate.AutoBroadCast)
			{
				MakeSecretBroadcast(context, secret.Id, secretOccurence, secretOccurence.PackedParameters, -1, delegate(SecretBroadcastPostProcessContext bCtx)
				{
					SecretBroadcastPostProcess(context, bCtx, secret.Id, secretOccurence, -1);
				});
			}
			else if (withInitialDistribute)
			{
				secretOccurence.PackedParameters?.ExtractSecretParameters(secretTemplate, delegate(int index, int charId)
				{
					if (Enumerable.Contains(secretTemplate.InitialTargetParameterIndices, index))
					{
						set.Clear();
						if (DomainManager.Character.TryGetElement_Objects(charId, out var element) && element != null)
						{
							Personalities personalities = element.GetPersonalities();
							sbyte b2 = personalities.Items[2];
							if (element.GetLocation().IsValid())
							{
								switch (secretTemplate.InitialTarget)
								{
								case ESecretInformationInitialTarget.Area:
									DomainManager.Character.GetAreaPeople(context.Random, element, set, (sbyte)Math.Clamp((15 + b2 / 2) / 5, 0, 100));
									break;
								case ESecretInformationInitialTarget.Nearest:
									DomainManager.Character.GetClosePeople(context.Random, element, set, (sbyte)Math.Clamp((30 + b2) / 5, 0, 100));
									break;
								case ESecretInformationInitialTarget.Local:
									DomainManager.Character.GetSameBlockPeople(context.Random, element, set, (sbyte)Math.Clamp((60 + b2 * 2) / 5, 0, 100));
									break;
								}
							}
							else
							{
								set.Add(charId);
							}
							foreach (int current in set)
							{
								ReceiveSecretInformation(context, secret.Id, current);
							}
							if (distributeCallback != null)
							{
								distributeCallback(set);
							}
						}
					}
				});
			}
		}
		pool.Return(set);
		return secret.Id;
	}

	private SecretOccurence AddSecretOccurence(DataContext dataContext, int date, short templateId, byte[] packedParameters)
	{
		SecretOccurence occurence = new SecretOccurence
		{
			Date = date,
			TemplateId = templateId,
			PackedParameters = packedParameters
		};
		RecordSecretOccurenceAdd(dataContext, occurence);
		return occurence;
	}

	private unsafe SecretOccurence AddSecretOccurence(DataContext dataContext, SecretInformationCollection oldCollection, int dataOffset)
	{
		byte[] rawData = oldCollection.RawData;
		fixed (byte* pRawData = rawData)
		{
			byte* pOrigin = pRawData + dataOffset;
			byte* pCurrData = pOrigin;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short templateId = *(short*)pCurrData;
			pCurrData += 2;
			return AddSecretOccurence(dataContext, date, templateId, rawData[(int)(pCurrData - pOrigin)..]);
		}
	}

	public SecretInformationId AddSecretInformation(DataContext context, int dataOffset, bool withInitialDistribute = true)
	{
		return AddSecretInformationWithNecessity(context, dataOffset, withInitialDistribute, necessarily: false, null);
	}

	internal SecretInformationId AddSecretInformationWithNecessity(DataContext context, int dataOffset, bool withInitialDistribute, bool necessarily, Action<ICollection<int>> distributeCallback)
	{
		SecretInformationCollection collection = GetSecretInformationCollection();
		SecretOccurence occurence = AddSecretOccurence(context, collection, dataOffset);
		collection.Clear();
		return AddSecretInformation(context, occurence, withInitialDistribute, necessarily, distributeCallback);
	}

	[DomainMethod]
	public SecretInformationDisplayPackage GetSecretInformationDisplayPackage(List<int> secretIds)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwuChar.GetId();
		TryGetElement_CharacterKnownSecrets(taiwuCharId, out var taiwuKnown);
		if (secretIds == null)
		{
			secretIds = new List<int>();
		}
		foreach (SecretInformationDisplayData record in secretIds.Select((int secretId) => GetSecretInformationDisplayData((SecretInformationId)secretId, characterSet)))
		{
			if (record != null)
			{
				taiwuKnown?.UsedCounts?.TryGetValue(record.SecretInformationId, out record.UsedCount);
				record.AuthorityCostWhenDisseminating = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(record.SecretInformationTemplateId, taiwuChar.GetFameType(), CalcSecretInformationKnownCharacterCount(record.SecretInformationId));
				result.SecretInformationDisplayDataList.Add(record);
				if (record.SourceCharacterId > 0)
				{
					characterSet.Add(record.SourceCharacterId);
				}
			}
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
	}

	[DomainMethod]
	public SecretInformationDisplayPackage GetSecretInformationDisplayPackageForSelections(int characterId)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		if (TryGetElement_CharacterKnownSecrets(characterId, out var known) && DomainManager.Character.TryGetElement_Objects(characterId, out var character))
		{
			foreach (SecretInformationId secretId in known.KnownSecrets)
			{
				SecretInformationDisplayData record = GetSecretInformationDisplayData(secretId, characterSet);
				known.UsedCounts.TryGetValue(secretId, out record.UsedCount);
				record.AuthorityCostWhenDisseminating = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(record.SecretInformationTemplateId, character.GetFameType(), CalcSecretInformationKnownCharacterCount(secretId));
				result.SecretInformationDisplayDataList.Add(record);
				if (record.SourceCharacterId > 0)
				{
					characterSet.Add(record.SourceCharacterId);
				}
			}
		}
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			SecretInformationDisplayData record2 = GetSecretInformationDisplayData(secret.Id, characterSet);
			known?.UsedCounts?.TryGetValue(record2.SecretInformationId, out record2.UsedCount);
			result.SecretInformationDisplayDataList.Add(record2);
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
	}

	[DomainMethod]
	public SecretInformationDisplayPackage GetSecretInformationDisplayPackageFromBroadcast(int characterId)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		TryGetElement_CharacterKnownSecrets(characterId, out var known);
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			SecretInformationDisplayData record = GetSecretInformationDisplayData(secret.Id, characterSet);
			known?.UsedCounts?.TryGetValue(record.SecretInformationId, out record.UsedCount);
			result.SecretInformationDisplayDataList.Add(record);
			if (record.SourceCharacterId > 0)
			{
				characterSet.Add(record.SourceCharacterId);
			}
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
	}

	[DomainMethod]
	public SecretInformationDisplayPackage GetSecretInformationDisplayPackageFromCharacter(int characterId)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		if (TryGetElement_CharacterKnownSecrets(characterId, out var known) && DomainManager.Character.TryGetElement_Objects(characterId, out var character))
		{
			foreach (SecretInformationId secretId in known.KnownSecrets)
			{
				SecretInformationDisplayData record = GetSecretInformationDisplayData(secretId, characterSet, character);
				known.UsedCounts.TryGetValue(secretId, out record.UsedCount);
				record.AuthorityCostWhenDisseminating = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(record.SecretInformationTemplateId, character.GetFameType(), CalcSecretInformationKnownCharacterCount(secretId));
				result.SecretInformationDisplayDataList.Add(record);
				if (record.SourceCharacterId > 0)
				{
					characterSet.Add(record.SourceCharacterId);
				}
			}
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
	}

	[DomainMethod]
	public int GetSecretInformationAmountFromCharacter(int characterId)
	{
		if (TryGetElement_CharacterKnownSecrets(characterId, out var known))
		{
			return known.KnownSecrets.Count;
		}
		return 0;
	}

	[DomainMethod]
	public List<SecretInformationEffectData> GetSecretInformationDetailedData(DataContext context, SecretInformationId secretId, int sourceCharId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		SecretOccurence occurence;
		byte[] secretParams = secret.QueryParameters(out occurence);
		if (occurence.InBroadcast)
		{
			return null;
		}
		SecretInformationProcessor processor = DomainManager.Information.SecretInformationProcessorPool.Get();
		if (!processor.Initialize(occurence, secretParams))
		{
			DomainManager.Information.SecretInformationProcessorPool.Return(processor);
			return null;
		}
		Dictionary<int, SecretInformationEffectData> res = new Dictionary<int, SecretInformationEffectData>();
		processor.Initialize_ForBroadcastEffect(context.Random);
		Dictionary<int, GameData.Domains.Character.Character> activeActorList = processor.GetActiveActorList_WithActorIndex();
		res[sourceCharId] = new SecretInformationEffectData(sourceCharId, -1);
		foreach (var (key, character2) in activeActorList)
		{
			res[character2.GetId()] = new SecretInformationEffectData(character2.GetId(), (key == 0) ? ((short)1) : ((short)0));
		}
		List<SecretInformationHappinessChangeItem> happinessList = processor.GetAllSecretInformationHappinessChange();
		foreach (SecretInformationHappinessChangeItem item in happinessList)
		{
			if (item.DeltaHappiness != 0 && res.TryGetValue(item.CharacterId, out var data))
			{
				data.HappinessDelta = item.DeltaHappiness;
			}
		}
		List<SecretInformationFavorChangeItem> favorList = processor.GetAllSecretInformationFavorabilityChangeWithSource(sourceCharId);
		foreach (SecretInformationFavorChangeItem item2 in favorList)
		{
			if (item2.DeltaFavor != 0 && res.TryGetValue(item2.TargetId, out var data2))
			{
				data2.FavorDelta += item2.DeltaFavor;
				data2.FavorCount++;
			}
		}
		List<SecretInformationStartEnemyRelationItem> startEnemyRelationItem = processor.GetAllSecretInformationStartEnemyRelationItems(sourceCharId);
		foreach (SecretInformationStartEnemyRelationItem item3 in startEnemyRelationItem)
		{
			if (item3.Odds > 0 && res.TryGetValue(item3.TargetId, out var data3))
			{
				data3.HasEnemy = true;
			}
		}
		Dictionary<short, short> collectedFameWithLevel = new Dictionary<short, short>();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (KeyValuePair<int, GameData.Domains.Character.Character> item4 in activeActorList)
		{
			List<short> fameList = processor.GetActorFameRecord_WithActorIndex(item4.Key);
			collectedFameWithLevel.Clear();
			foreach (short fameKey in fameList)
			{
				collectedFameWithLevel.TryGetValue(fameKey, out var level);
				collectedFameWithLevel[fameKey] = (short)(level + 1);
			}
			foreach (KeyValuePair<short, short> famePair in collectedFameWithLevel)
			{
				if (res.TryGetValue(item4.Value.GetId(), out var data4))
				{
					data4.Fame.Add(famePair.Key);
				}
			}
			if (item4.Value == null)
			{
				continue;
			}
			int id = item4.Value.GetId();
			if (!res.TryGetValue(id, out var data5))
			{
				continue;
			}
			if (id == taiwuCharId)
			{
				short reasonKey;
				OrganizationInfo organizationInfo;
				sbyte punishLevel = processor.CalcTaiwuPunishLevel(taiwuCharId, out reasonKey, out organizationInfo);
				if (punishLevel >= 0)
				{
					data5.Punish.Add(new ShortPair(reasonKey, punishLevel));
				}
			}
			else if (item4.Value.GetOrganizationInfo().SettlementId == DomainManager.Taiwu.GetTaiwuVillageSettlementId())
			{
				sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId);
				MapStateItem stateCfg = MapState.Instance[stateTemplateId];
				if (stateCfg.SectID >= 0 && DomainManager.Organization.GetSettlementByOrgTemplateId(stateCfg.SectID) is Sect)
				{
					OrganizationInfo orgInfo = item4.Value.GetOrganizationInfo();
					orgInfo.OrgTemplateId = EventHelper.GetStateMainCityOrgTemplateId(stateTemplateId);
					short reasonKey2;
					sbyte punishLevel2 = processor.CalcSectPunishLevelWithSpecificOrganization(item4.Key, out reasonKey2, orgInfo);
					if (punishLevel2 >= 0)
					{
						data5.Punish.Add(new ShortPair(reasonKey2, punishLevel2));
					}
				}
			}
			else
			{
				short reasonKey3;
				sbyte punishLevel3 = processor.CalSectPunishLevel_WithActorIndex(item4.Key, out reasonKey3);
				if (punishLevel3 >= 0)
				{
					data5.Punish.Add(new ShortPair(reasonKey3, punishLevel3));
				}
			}
		}
		DomainManager.Information.SecretInformationProcessorPool.Return(processor);
		return res.Values.ToList();
	}

	internal SecretInformationDisplayPackage GetRelateBSecretInformationDisplayPackageForSelections(int charA, int charB, ESecretInformationValueType valueType = ESecretInformationValueType.Count)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		if (TryGetElement_CharacterKnownSecrets(charA, out var knownA) && DomainManager.Character.TryGetElement_Objects(charA, out var character))
		{
			foreach (SecretInformationId secretId in knownA.KnownSecrets)
			{
				if (!IsSecretInformationRelatedWithCharacter(secretId, charB))
				{
					continue;
				}
				SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
				if (valueType == ESecretInformationValueType.Count || config.ValueType == valueType)
				{
					SecretInformationDisplayData record = GetSecretInformationDisplayData(secretId, characterSet);
					knownA.UsedCounts.TryGetValue(secretId, out record.UsedCount);
					record.AuthorityCostWhenDisseminating = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(record.SecretInformationTemplateId, character.GetFameType(), CalcSecretInformationKnownCharacterCount(secretId));
					result.SecretInformationDisplayDataList.Add(record);
					if (record.SourceCharacterId > 0)
					{
						characterSet.Add(record.SourceCharacterId);
					}
				}
			}
		}
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			if (IsSecretInformationRelatedWithCharacter(secret.Id, charB))
			{
				SecretInformationDisplayData record2 = GetSecretInformationDisplayData(secret.Id, characterSet);
				knownA?.UsedCounts?.TryGetValue(record2.SecretInformationId, out record2.UsedCount);
				result.SecretInformationDisplayDataList.Add(record2);
			}
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
	}

	internal SecretInformationDisplayPackage GetCheatOnSecretInformationDisplayPackageForSelections(int charA, int charB)
	{
		SecretInformationDisplayPackage result = new SecretInformationDisplayPackage();
		HashSet<int> characterSet = new HashSet<int>();
		if (TryGetElement_CharacterKnownSecrets(charA, out var knownA) && DomainManager.Character.TryGetElement_Objects(charA, out var character))
		{
			foreach (SecretInformationId secretId in knownA.KnownSecrets)
			{
				if (IsCheat(secretId))
				{
					SecretInformationDisplayData record = GetSecretInformationDisplayData(secretId, characterSet);
					knownA.UsedCounts.TryGetValue(secretId, out record.UsedCount);
					record.AuthorityCostWhenDisseminating = CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(record.SecretInformationTemplateId, character.GetFameType(), CalcSecretInformationKnownCharacterCount(secretId));
					result.SecretInformationDisplayDataList.Add(record);
					if (record.SourceCharacterId > 0)
					{
						characterSet.Add(record.SourceCharacterId);
					}
				}
			}
		}
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast))
		{
			if (IsCheat(secret.Id))
			{
				SecretInformationDisplayData record2 = GetSecretInformationDisplayData(secret.Id, characterSet);
				knownA?.UsedCounts?.TryGetValue(record2.SecretInformationId, out record2.UsedCount);
				result.SecretInformationDisplayDataList.Add(record2);
			}
		}
		foreach (int charId in characterSet)
		{
			result.CharacterData.Add(charId, DomainManager.Character.GetCharacterDisplayData(charId));
		}
		return result;
		bool IsCheat(SecretInformationId secretId2)
		{
			SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId2);
			if (config.TemplateId != 21 && config.TemplateId != 22 && config.TemplateId != 34 && config.TemplateId != 105 && config.TemplateId != 106)
			{
				return false;
			}
			if (!IsSecretInformationRelatedWithCharacter(secretId2, charB) && !IsSecretInformationRelatedWithCharacter(secretId2, charA))
			{
				return false;
			}
			CharacterRelationshipSnapshot aRelatedCharacters = GetSecretInformationRelatedCharacters(secretId2, charA);
			CharacterRelationshipSnapshot bRelatedCharacters = GetSecretInformationRelatedCharacters(secretId2, charB);
			return (aRelatedCharacters != null && aRelatedCharacters.RelatedCharacters.HusbandsAndWives.Contains(charB)) || (bRelatedCharacters?.RelatedCharacters.HusbandsAndWives.Contains(charA) ?? false);
		}
	}

	private CharacterRelationshipSnapshot GetSecretInformationRelatedCharacters(SecretInformationId secretId, int characterId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation(secretId);
		if (secret != null)
		{
			secret.QueryParameters(out var occurence);
			if (occurence.CharacterRelationshipSnapshotCollection.TryGetValue(characterId, out var characterRelationshipSnapshot))
			{
				return characterRelationshipSnapshot;
			}
		}
		return null;
	}

	public SecretInformationDisplayData GetSecretInformationDisplayData(SecretInformationId secretId, ISet<int> characterSet, GameData.Domains.Character.Character character = null)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		byte[] parameters;
		if (secret != null && (parameters = secret.QueryParameters(out var occurence)) != null)
		{
			int taiwuCharacterId = DomainManager.Taiwu.GetTaiwuCharId();
			SecretInformationItem secretTemplate = Config.SecretInformation.Instance[occurence.TemplateId];
			SecretInformationDisplayData displayData = new SecretInformationDisplayData();
			parameters.ExtractSecretParameters(secretTemplate, delegate(int _, int charId)
			{
				characterSet.Add(charId);
			});
			displayData.HolderCount = CalcSecretInformationKnownCharacterCount(secretId);
			displayData.UsedCount = 0;
			displayData.AuthorityCostWhenDisseminating = 0;
			displayData.Location = DomainManager.Map.GetBlockFullName(occurence.Location);
			displayData.IsInBroadcast = occurence.InBroadcast;
			displayData.OccurenceId = occurence.Id;
			displayData.OccurenceDate = occurence.Date;
			displayData.DisseminationRate = ((character == null || character.GetId() == taiwuCharacterId) ? (-1) : CalcSecretReceivedDisseminateOdds(parameters, secretTemplate, SecretInformationEffect.Instance.GetItem(secretTemplate.DefaultEffectId), SecretInformationReception.Instance.GetItem(secretTemplate.ReceptionId), character));
			displayData.SecretInformationId = secretId;
			displayData.SourceCharacterId = secret.SourceCharacterId;
			displayData.SecretInformationTemplateId = occurence.TemplateId;
			displayData.ParametersPack = parameters.ToArray();
			displayData.ShopValue = CalcSecretInformationShopValue(parameters, secretTemplate);
			return displayData;
		}
		return null;
	}

	private static sbyte CalcSecretInformationDisplaySize(byte[] parameters, SecretInformationItem secretTemplate, IReadOnlyList<sbyte> informationSettings)
	{
		int score = 0;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		parameters.ExtractSecretParameters(secretTemplate, delegate(int characterIndex, int charId)
		{
			bool isSect = false;
			sbyte b = 0;
			if (DomainManager.Character.TryGetElement_Objects(charId, out var element))
			{
				sbyte orgTemplateId = element.GetOrganizationInfo().OrgTemplateId;
				isSect = orgTemplateId >= 0 && Config.Organization.Instance[orgTemplateId].IsSect;
				b = element.GetOrganizationInfo().Grade;
			}
			else
			{
				DeadCharacter deadCharacter = DomainManager.Character.TryGetDeadCharacter(charId);
				if (deadCharacter != null)
				{
					sbyte orgTemplateId2 = deadCharacter.OrganizationInfo.OrgTemplateId;
					isSect = orgTemplateId2 >= 0 && Config.Organization.Instance[orgTemplateId2].IsSect;
					b = deadCharacter.OrganizationInfo.Grade;
				}
			}
			short[] array = CharRelationTypeToValue(characterIndex, isSect);
			sbyte b2 = RelationType.GetTypeId(0);
			RelatedCharacter relation;
			if (charId == taiwuCharId)
			{
				b2 = (sbyte)(array.Length - 1);
			}
			else if (DomainManager.Character.TryGetRelation(taiwuCharId, charId, out relation) && relation.RelationType != ushort.MaxValue)
			{
				for (ushort num = relation.RelationType; num < 17; num++)
				{
					ushort num2 = (ushort)(1 << (int)num);
					if ((num2 & relation.RelationType) != 0)
					{
						b2 = RelationType.GetTypeId(num2);
						break;
					}
				}
			}
			score += CharGradeToValue(characterIndex, isSect)[b] * secretTemplate.BlockSizeArgs[4 + informationSettings[2]];
			score += array[b2] * secretTemplate.BlockSizeArgs[7 + informationSettings[3]];
		}, delegate
		{
		}, delegate
		{
		}, delegate(int _, ItemKey itemKey)
		{
			if (itemKey.ItemType >= 0 && itemKey.TemplateId >= 0)
			{
				score += GlobalConfig.SecretInformationDisplay_ItemGradeToValue[ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId)] * secretTemplate.BlockSizeArgs[10 + informationSettings[4]];
			}
		}, delegate
		{
		}, delegate
		{
		}, delegate
		{
		});
		for (int i = 0; i < GlobalConfig.SecretInformationDisplay_SizeThresholds.Length; i++)
		{
			if (score < GlobalConfig.SecretInformationDisplay_SizeThresholds[i])
			{
				return (sbyte)i;
			}
		}
		return (sbyte)GlobalConfig.SecretInformationDisplay_SizeThresholds.Length;
		static short[] CharGradeToValue(int characterIndex, bool isSect)
		{
			if (1 == 0)
			{
			}
			short[] result = characterIndex switch
			{
				0 => isSect ? GlobalConfig.SecretInformationDisplay_PosASectCharGradeToValue : GlobalConfig.SecretInformationDisplay_PosANotSectCharGradeToValue, 
				1 => isSect ? GlobalConfig.SecretInformationDisplay_PosBSectCharGradeToValue : GlobalConfig.SecretInformationDisplay_PosBNotSectCharGradeToValue, 
				2 => isSect ? GlobalConfig.SecretInformationDisplay_PosCSectCharGradeToValue : GlobalConfig.SecretInformationDisplay_PosCNotSectCharGradeToValue, 
				_ => throw new IndexOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		static short[] CharRelationTypeToValue(int characterIndex, bool isSect)
		{
			if (1 == 0)
			{
			}
			short[] result = characterIndex switch
			{
				0 => isSect ? GlobalConfig.SecretInformationDisplay_PosASectCharRelationTypeToValue : GlobalConfig.SecretInformationDisplay_PosANotSectCharRelationTypeToValue, 
				1 => isSect ? GlobalConfig.SecretInformationDisplay_PosBSectCharRelationTypeToValue : GlobalConfig.SecretInformationDisplay_PosBNotSectCharRelationTypeToValue, 
				2 => isSect ? GlobalConfig.SecretInformationDisplay_PosCSectCharRelationTypeToValue : GlobalConfig.SecretInformationDisplay_PosCNotSectCharRelationTypeToValue, 
				_ => throw new IndexOutOfRangeException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	[DomainMethod]
	public bool DisseminateSecretInformation(DataContext context, SecretInformationId secretId, int sourceCharId, int targetCharId)
	{
		GameData.Domains.Character.Character sourceChar = DomainManager.Character.GetElement_Objects(sourceCharId);
		InformationDomain informationDomain = DomainManager.Information;
		GameData.Domains.Information.Secret.SecretInformation secret = informationDomain.QuerySecretInformation(secretId);
		secret.QueryParameters(out var occurence);
		int cost = DomainManager.Information.CalcSecretInformationAuthorityCostWhenDisseminatingByCharacter(occurence.TemplateId, sourceChar.GetFameType(), informationDomain.CalcSecretInformationKnownCharacterCount(secretId));
		EditCharacterKnownSecret(context, sourceCharId, delegate(CharacterKnownSecret known)
		{
			known.UsedCounts.TryGetValue(secretId, out var value);
			known.UsedCounts[secretId] = value + 1;
		});
		if (DistributeSecretInformationToCharacter(context, secretId, targetCharId, sourceCharId))
		{
			sourceChar.ChangeResource(context, 7, -Math.Min(sourceChar.GetResource(7), cost));
			return true;
		}
		return false;
	}

	internal bool ReceiveSecretInformation(DataContext context, SecretInformationId secretId, int charId, int sourceCharId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		if (secret == null)
		{
			return false;
		}
		return ReceiveSecretInformation(context, secret, charId, sourceCharId);
	}

	internal bool ReceiveSecretInformation(DataContext context, SecretInformationId secretId, int charId)
	{
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(secretId);
		if (secret == null)
		{
			return false;
		}
		return ReceiveSecretInformation(context, secret, charId, secret.SourceCharacterId);
	}

	private bool ReceiveSecretInformation(DataContext context, GameData.Domains.Information.Secret.SecretInformation secret, int charId, int sourceCharId)
	{
		SecretInformationId realReceivedSecretId;
		return ReceiveSecretInformation(context, secret, charId, sourceCharId, out realReceivedSecretId);
	}

	private bool ReceiveSecretInformation(DataContext context, GameData.Domains.Information.Secret.SecretInformation secret, int charId, int sourceCharId, out SecretInformationId realReceivedSecretId)
	{
		realReceivedSecretId = SecretInformationId.Invalid;
		SecretOccurence occurence = QuerySecretOccurence(secret.OccurenceId);
		if (occurence != null && occurence.InBroadcast)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || character.GetAgeGroup() == 0)
		{
			return false;
		}
		bool success = false;
		SecretInformationId resultId = SecretInformationId.Invalid;
		EditCharacterKnownSecret(context, charId, delegate(CharacterKnownSecret charKnown)
		{
			if (!charKnown.KnownSecrets.Contains(secret.Id))
			{
				if (charKnown.KnownSecrets.Any(delegate(SecretInformationId id2)
				{
					GameData.Domains.Information.Secret.SecretInformation secretInformation = QuerySecretInformation(id2);
					return secretInformation != null && secretInformation.OccurenceId == secret.OccurenceId;
				}))
				{
					success = false;
				}
				else
				{
					if (sourceCharId < 0 || sourceCharId != secret.SourceCharacterId)
					{
						SecretInformationId id = secret.Id;
						secret = new GameData.Domains.Information.Secret.SecretInformation(secret)
						{
							SourceCharacterId = charId
						};
						RecordSecretInformationAdd(context, secret);
					}
					if (secret.SourceCharacterId != charId && DomainManager.Character.TryGetElement_Objects(secret.SourceCharacterId, out var element))
					{
						SecretInformationItem secretInformationItem = Config.SecretInformation.Instance[occurence.TemplateId];
						int delta = secretInformationItem.CostAuthority * GlobalConfig.Instance.SecretInformationSourceCharacterAuthorityGainToCostConfigRate / 100;
						element.ChangeResource(context, 7, delta);
					}
					charKnown.UsedCounts.Remove(secret.Id);
					charKnown.KnownSecrets.Add(secret.Id);
					RegisterSecretHolderCache(charId, secret.Id);
					success = true;
					resultId = secret.Id;
					if (charId == DomainManager.Taiwu.GetTaiwuCharId())
					{
						AchievementManager.RequestSetStat(context, 4, 1);
					}
				}
			}
		});
		realReceivedSecretId = resultId;
		return success;
	}

	internal bool DistributeSecretInformationToCharacter(DataContext context, SecretInformationId secretId, int charId, int sourceCharId = -1)
	{
		SecretOccurence secretOccurence = QuerySecretOccurence(secretId);
		if (secretOccurence != null && secretOccurence.InBroadcast)
		{
			return true;
		}
		return ReceiveSecretInformation(context, secretId, charId, sourceCharId);
	}

	private unsafe void PlanDisseminateSecretInformation(DataContext context, int charId)
	{
		CharacterDomain characterDomain = DomainManager.Character;
		if (!characterDomain.TryGetElement_Objects(charId, out var character))
		{
			return;
		}
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<GameData.Domains.Information.Secret.SecretInformation> secrets = new List<GameData.Domains.Information.Secret.SecretInformation>();
		Dictionary<SecretInformationId, int> secretNextStageDisseminateOddLevelMap = new Dictionary<SecretInformationId, int>();
		secrets.AddRange(QueryCharacterKnownSecretInformationIds(charId).Select(QuerySecretInformation));
		int authority = character.GetResource(7);
		secrets.RemoveAll(delegate(GameData.Domains.Information.Secret.SecretInformation secretInformation)
		{
			SecretOccurence secretOccurence = QuerySecretOccurence(secretInformation.OccurenceId);
			if (!IsSecretInformationDiffusible(secretInformation.Id, secretOccurence, character.GetFameType(), charId, authority))
			{
				return true;
			}
			SecretInformationItem secretInformationItem = Config.SecretInformation.Instance[secretOccurence.TemplateId];
			return !secretInformationItem.AutoDissemination;
		});
		int nextStageDisseminateOddMinLine = Math.Max(5, 30 - character.GetPersonality(2) / 2);
		nextStageDisseminateOddMinLine = context.Random.Next(Math.Min(30, nextStageDisseminateOddMinLine), 31);
		for (int j = secrets.Count - 1; j >= 0; j--)
		{
			GameData.Domains.Information.Secret.SecretInformation secret = secrets[j];
			SecretOccurence occurence = QuerySecretOccurence(secret.OccurenceId);
			SecretInformationItem config = Config.SecretInformation.Instance[occurence.TemplateId];
			int odd = CalcSecretReceivedDisseminateOdds(occurence.PackedParameters, config, SecretInformationEffect.Instance.GetItem(config.DefaultEffectId), SecretInformationReception.Instance.GetItem(config.ReceptionId), character);
			if (odd < nextStageDisseminateOddMinLine)
			{
				secrets.RemoveAt(j);
			}
			else
			{
				int level = 0;
				for (int k = 0; k < GlobalConfig.Instance.SecretInformationReceivedDisseminateLevels.Length; k++)
				{
					if (odd >= GlobalConfig.Instance.SecretInformationReceivedDisseminateLevels[k])
					{
						level = k;
					}
				}
				secretNextStageDisseminateOddLevelMap[secret.Id] = level;
			}
		}
		CollectionUtils.Shuffle(context.Random, secrets);
		CollectionUtils.Sort(secrets, delegate(GameData.Domains.Information.Secret.SecretInformation secretInformation, GameData.Domains.Information.Secret.SecretInformation secretInformation2)
		{
			SecretInformationItem secretInformationItem = Config.SecretInformation.Instance[QuerySecretOccurence(secretInformation.OccurenceId).TemplateId];
			SecretInformationItem secretInformationItem2 = Config.SecretInformation.Instance[QuerySecretOccurence(secretInformation2.OccurenceId).TemplateId];
			if (secretNextStageDisseminateOddLevelMap.TryGetValue(secretInformation.Id, out var value) && secretNextStageDisseminateOddLevelMap.TryGetValue(secretInformation2.Id, out var value2) && value != value2)
			{
				return value2.CompareTo(value);
			}
			if (secretInformationItem.SortValue != secretInformationItem2.SortValue)
			{
				return secretInformationItem2.SortValue.CompareTo(secretInformationItem.SortValue);
			}
			if (secretInformationItem.DiffusionSpeed != secretInformationItem2.DiffusionSpeed)
			{
				return secretInformationItem2.DiffusionSpeed.CompareTo(secretInformationItem.DiffusionSpeed);
			}
			if (secretInformation.OccurenceId == secretInformation2.OccurenceId)
			{
				if (secretInformation.SourceCharacterId == charId)
				{
					return 1;
				}
				if (secretInformation2.SourceCharacterId == charId)
				{
					return -1;
				}
				if (characterDomain.TryGetElement_Objects(secretInformation.SourceCharacterId, out var element) && characterDomain.TryGetElement_Objects(secretInformation2.SourceCharacterId, out var element2))
				{
					return element2.GetOrganizationInfo().Grade.CompareTo(element.GetOrganizationInfo().Grade);
				}
			}
			return 0;
		});
		if (secrets.Count > 0)
		{
			Personalities personalities = character.GetPersonalities();
			MapBlockData block = DomainManager.Map.GetBlock(location);
			bool hasValidTarget = false;
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			List<SecretOccurenceId> processedOccurIds = new List<SecretOccurenceId>();
			int processedCount = 0;
			int amount = Math.Min((authority < GlobalConfig.Instance.SecretInformationNpcPlanDisseminateAmountFactor) ? 1 : 2, secrets.Count);
			processedOccurIds.Clear();
			if (block.CharacterSet != null)
			{
				for (int ai = 0; ai < amount; ai++)
				{
					bool hasValidTargetCurrent = false;
					GameData.Domains.Information.Secret.SecretInformation secret2 = secrets[ai];
					if (processedOccurIds.Contains(secret2.OccurenceId))
					{
						continue;
					}
					OrganizationInfo sourceCharacterOrgInfo = new OrganizationInfo
					{
						OrgTemplateId = -1
					};
					DeadCharacter sourceDeadCharacter;
					if (DomainManager.Character.TryGetElement_Objects(secret2.SourceCharacterId, out var sourceCharacter))
					{
						sourceCharacterOrgInfo = sourceCharacter.GetOrganizationInfo();
					}
					else if (DomainManager.Character.TryGetDeadCharacter(secret2.SourceCharacterId, out sourceDeadCharacter))
					{
						sourceCharacterOrgInfo = sourceDeadCharacter.OrganizationInfo;
					}
					SecretOccurence occurence2;
					byte[] secretParams = secret2.QueryParameters(out occurence2);
					SecretInformationItem config2 = Config.SecretInformation.Instance[occurence2.TemplateId];
					SecretInformationEffectItem effect = SecretInformationEffect.Instance.GetItem(config2.DefaultEffectId);
					SecretInformationDisseminationItem dissemination = SecretInformationDissemination.Instance.GetItem(config2.DisseminationId);
					bool isSelfIntroduction = false;
					int actorId = -1;
					int reactorId = -1;
					int secActorId = -1;
					secretParams?.ExtractSecretParameters(config2, delegate(int index, int argCharId)
					{
						if (argCharId == charId)
						{
							isSelfIntroduction = true;
						}
						if (effect.ActorIndex == index)
						{
							actorId = argCharId;
						}
						if (effect.ReactorIndex == index)
						{
							reactorId = argCharId;
						}
						if (effect.SecactorIndex == index)
						{
							secActorId = argCharId;
						}
					});
					HashSet<SecretInformationRelationshipType> r = new HashSet<SecretInformationRelationshipType>();
					int rateBase = 0;
					if (isSelfIntroduction)
					{
						rateBase += dissemination.SfBehaviorTypeDiff[character.GetBehaviorType()];
						for (int i = 0; i < 5; i++)
						{
							rateBase += dissemination.SfPersonalityDiff[i] * personalities.Items[i] / 100;
						}
					}
					else
					{
						rateBase += dissemination.TfBehaviorTypeDiff[character.GetBehaviorType()];
						for (int i2 = 0; i2 < 5; i2++)
						{
							rateBase += dissemination.TfPersonalityDiff[i2] * personalities.Items[i2] / 100;
						}
						if (GameData.Domains.Character.Character.IsCharacterIdValid(actorId))
						{
							r.Clear();
							CheckSecretInformationRelationship(charId, SecretOccurenceId.Invalid, actorId, SecretOccurenceId.Invalid, r);
							if (r.Contains(SecretInformationRelationshipType.Relative) || r.Contains(SecretInformationRelationshipType.Friend))
							{
								rateBase += dissemination.TfRateDiffWhenActFri;
							}
							else if (r.Contains(SecretInformationRelationshipType.Enemy))
							{
								rateBase += dissemination.TfRateDiffWhenActEnm;
							}
						}
						if (GameData.Domains.Character.Character.IsCharacterIdValid(reactorId))
						{
							r.Clear();
							CheckSecretInformationRelationship(charId, SecretOccurenceId.Invalid, reactorId, SecretOccurenceId.Invalid, r);
							if (r.Contains(SecretInformationRelationshipType.Relative) || r.Contains(SecretInformationRelationshipType.Friend))
							{
								rateBase += dissemination.TfRateDiffWhenUnaFri;
							}
							else if (r.Contains(SecretInformationRelationshipType.Enemy))
							{
								rateBase += dissemination.TfRateDiffWhenUnaEnm;
							}
						}
					}
					bool interrupt = false;
					EditCharacterKnownSecret(context, charId, delegate(CharacterKnownSecret known)
					{
						known.UsedCounts.TryGetValue(secret2.Id, out var value);
						int num = (occurence2.InBroadcast ? GlobalConfig.Instance.SecretInformationInBroadcastMaxUseCount : GlobalConfig.Instance.SecretInformationInPrivateMaxUseCount);
						foreach (int current in block.CharacterSet)
						{
							SecretInformationDisseminateIndex item = new SecretInformationDisseminateIndex(charId, current, secret2.Id);
							if (_completedNpcDisseminateIndices.Add(item) && current != charId && (!GameData.Domains.Character.Character.IsCharacterIdValid(current) || (current != actorId && current != reactorId && current != secActorId && current != secret2.SourceCharacterId)))
							{
								int num2 = GetRateByRelation(current) + rateBase;
								if (!hasValidTargetCurrent)
								{
								}
								hasValidTarget = true;
								hasValidTargetCurrent = true;
								if (DomainManager.Character.TryGetElement_Objects(current, out var element))
								{
									int currDate = DomainManager.World.GetCurrDate();
									Location validLocation = element.GetValidLocation();
									if (context.Random.CheckPercentProb(num2))
									{
										SecretInformationReceptionItem item2 = SecretInformationReception.Instance.GetItem(config2.ReceptionId);
										short[] array;
										if (secret2.SourceCharacterId == taiwuCharId)
										{
											array = item2.SourceTaiwu;
										}
										else
										{
											OrganizationItem item3 = Config.Organization.Instance.GetItem(sourceCharacterOrgInfo.OrgTemplateId);
											if (item3 == null)
											{
												continue;
											}
											if (item3.IsSect)
											{
												sbyte grade = sourceCharacterOrgInfo.Grade;
												if (1 == 0)
												{
												}
												short[] array2 = grade switch
												{
													8 => item2.SourceOrg8, 
													7 => item2.SourceOrg7, 
													6 => item2.SourceOrg6, 
													5 => item2.SourceOrg5, 
													4 => item2.SourceOrg4, 
													3 => item2.SourceOrg3, 
													2 => item2.SourceOrgLow2, 
													1 => item2.SourceOrgLow1, 
													_ => item2.SourceOrgLow0, 
												};
												if (1 == 0)
												{
												}
												array = array2;
											}
											else
											{
												sbyte grade2 = sourceCharacterOrgInfo.Grade;
												if (1 == 0)
												{
												}
												short[] array2 = grade2 switch
												{
													8 => item2.SourceCity8, 
													7 => item2.SourceCity7, 
													6 => item2.SourceCity6, 
													5 => item2.SourceCity5, 
													4 => item2.SourceCity4, 
													3 => item2.SourceCity3, 
													2 => item2.SourceCityLow2, 
													1 => item2.SourceCityLow1, 
													_ => item2.SourceCityLow0, 
												};
												if (1 == 0)
												{
												}
												array = array2;
											}
										}
										RelatedCharacter relation;
										short num3 = (DomainManager.Character.IsCharacterRelationFriendly(current, charId) ? item2.RateItsFriRt : (DomainManager.Character.IsCharacterRelationUnfriendly(current, charId) ? item2.RateItsEnmRt : ((!DomainManager.Character.TryGetRelation(current, charId, out relation)) ? item2.NoRateRt : item2.RateRt)));
										int num4 = 0;
										for (sbyte b = 0; b < 5; b++)
										{
											num4 += item2.PersonalityTypeRt[b] * element.GetPersonality(b);
										}
										int num5 = array[element.GetBehaviorType()] + num3 + num4;
										if (current == taiwuCharId)
										{
											num5 = 100;
										}
										value++;
										known.UsedCounts[secret2.Id] = value;
										if (!context.Random.CheckPercentProb(num5))
										{
											LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
											lifeRecordCollection.AddSpreadSecretFail(charId, currDate, current, validLocation, occurence2.TemplateId, (int)secret2.Id);
											LogReceptionChecked(element, secret2, num2, num5, "failed by reception check");
										}
										else
										{
											SecretInformationId realReceivedSecretId;
											bool flag = ReceiveSecretInformation(context, secret2, current, secret2.SourceCharacterId, out realReceivedSecretId);
											LogReceptionChecked(element, secret2, num2, num5, flag ? "success" : "failed by already known");
											if (flag)
											{
												int num6 = CalcSecretReceivedDisseminateOdds(occurence2.PackedParameters, config2, effect, item2, element);
												LifeRecordCollection lifeRecordCollection2 = DomainManager.LifeRecord.GetLifeRecordCollection();
												if (current != DomainManager.Taiwu.GetTaiwuCharId())
												{
													if (num6 >= GlobalConfig.Instance.SecretInformationReceivedDisseminateLevels[3])
													{
														lifeRecordCollection2.AddHeardSecretSpreadInVeryHighProbability(current, currDate, charId, validLocation, occurence2.TemplateId, (int)realReceivedSecretId);
													}
													else if (num6 >= GlobalConfig.Instance.SecretInformationReceivedDisseminateLevels[2])
													{
														lifeRecordCollection2.AddHeardSecretSpreadInHighProbability(current, currDate, charId, validLocation, occurence2.TemplateId, (int)realReceivedSecretId);
													}
													else if (num6 >= GlobalConfig.Instance.SecretInformationReceivedDisseminateLevels[1])
													{
														lifeRecordCollection2.AddHeardSecretSpreadInLowProbability(current, currDate, charId, validLocation, occurence2.TemplateId, (int)realReceivedSecretId);
													}
													else
													{
														lifeRecordCollection2.AddHeardSecretSpreadInVeryLowProbability(current, currDate, charId, validLocation, occurence2.TemplateId, (int)realReceivedSecretId);
													}
												}
												lifeRecordCollection2.AddSpreadSecretSuccess(charId, currDate, current, validLocation, occurence2.TemplateId, (int)secret2.Id);
											}
											else
											{
												LifeRecordCollection lifeRecordCollection3 = DomainManager.LifeRecord.GetLifeRecordCollection();
												if (TryGetElement_CharacterKnownSecrets(current, out var value2) && value2.KnownSecrets.Any((SecretInformationId id) => QuerySecretInformation(id).OccurenceId == occurence2.Id))
												{
													lifeRecordCollection3.AddSpreadSecretKnown(charId, currDate, current, validLocation, occurence2.TemplateId, (int)secret2.Id);
												}
											}
											if (value >= num)
											{
												break;
											}
										}
									}
								}
							}
						}
						if (value >= num)
						{
							interrupt = true;
						}
					});
					if (interrupt)
					{
						break;
					}
					processedOccurIds.Add(occurence2.Id);
					processedCount++;
					if (processedCount >= amount)
					{
						break;
					}
					int GetRateByRelation(int targetCharId)
					{
						int rate = 0;
						if (GameData.Domains.Character.Character.IsCharacterIdValid(actorId) && GameData.Domains.Character.Character.IsCharacterIdValid(reactorId))
						{
							if (!isSelfIntroduction)
							{
								r.Clear();
								CheckSecretInformationRelationship(charId, SecretOccurenceId.Invalid, targetCharId, SecretOccurenceId.Invalid, r);
								if (r.Contains(SecretInformationRelationshipType.Relative) || r.Contains(SecretInformationRelationshipType.Friend))
								{
									rate += dissemination.TfRateItsFri;
								}
								else if (r.Contains(SecretInformationRelationshipType.Enemy))
								{
									rate += dissemination.TfRateItsEnm;
								}
							}
							if (rate == 0)
							{
								r.Clear();
								CheckSecretInformationRelationship(actorId, SecretOccurenceId.Invalid, targetCharId, SecretOccurenceId.Invalid, r);
								if (r.Contains(SecretInformationRelationshipType.Relative) || r.Contains(SecretInformationRelationshipType.Friend))
								{
									rate += (isSelfIntroduction ? dissemination.SfRateActFri : dissemination.TfRateActFri);
								}
								else if (r.Contains(SecretInformationRelationshipType.Enemy))
								{
									rate += (isSelfIntroduction ? dissemination.SfRateActEnm : dissemination.TfRateActEnm);
								}
								else
								{
									r.Clear();
									CheckSecretInformationRelationship(reactorId, SecretOccurenceId.Invalid, targetCharId, SecretOccurenceId.Invalid, r);
									rate = ((r.Contains(SecretInformationRelationshipType.Relative) || r.Contains(SecretInformationRelationshipType.Friend)) ? (rate + (isSelfIntroduction ? dissemination.SfRateUnaFri : dissemination.TfRateUnaFri)) : (r.Contains(SecretInformationRelationshipType.Enemy) ? (rate + (isSelfIntroduction ? dissemination.SfRateUnaEnm : dissemination.TfRateUnaEnm)) : ((!DomainManager.Character.TryGetRelation(charId, targetCharId, out var _)) ? (rate + (isSelfIntroduction ? dissemination.SfRateNStr : dissemination.TfRateNStr)) : (rate + (isSelfIntroduction ? dissemination.SfRateStr : dissemination.TfRateStr)))));
								}
							}
							return rate;
						}
						return -10000;
					}
				}
			}
			if (!hasValidTarget)
			{
				LogRejected("no valid receiver");
			}
		}
		else
		{
			LogRejected("no usable instance");
		}
		static void LogReceptionChecked(GameData.Domains.Character.Character targetChar, GameData.Domains.Information.Secret.SecretInformation secretInformation, int rateA, int rateB, string result)
		{
		}
		static void LogRejected(string reason)
		{
		}
	}

	private static int CalcSecretReceivedDisseminateOdds(byte[] parameters, SecretInformationItem secretTemplate, SecretInformationEffectItem effect, SecretInformationReceptionItem reception, GameData.Domains.Character.Character targetCharacter)
	{
		int targetCharacterId = targetCharacter.GetId();
		int nextStageDisseminateOdds = 0;
		bool usePersonalityTypeDisForRelation = false;
		int actorId = -1;
		int reactorId = -1;
		parameters.ExtractSecretParameters(secretTemplate, delegate(int index, int charId)
		{
			if (GameData.Domains.Character.Character.IsCharacterIdValid(charId))
			{
				if (effect.ActorIndex == index)
				{
					actorId = charId;
				}
				if (effect.ReactorIndex == index)
				{
					reactorId = charId;
				}
			}
		});
		bool hasActor = GameData.Domains.Character.Character.IsCharacterIdValid(actorId);
		bool hasReactor = GameData.Domains.Character.Character.IsCharacterIdValid(reactorId);
		if (hasActor && actorId == targetCharacterId)
		{
			nextStageDisseminateOdds += reception.DisRateAct;
			usePersonalityTypeDisForRelation = true;
		}
		else if (hasReactor && reactorId == targetCharacterId)
		{
			nextStageDisseminateOdds += reception.DisRateUna;
			usePersonalityTypeDisForRelation = true;
		}
		else
		{
			bool isAnyRelationExist = false;
			if (hasActor && DomainManager.Character.IsCharacterRelationFriendly(actorId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateActFri;
				isAnyRelationExist = true;
			}
			if (hasActor && DomainManager.Character.IsCharacterRelationUnfriendly(actorId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateActEn;
				isAnyRelationExist = true;
			}
			if (hasActor && DomainManager.Character.HasRelation(actorId, targetCharacterId, 16384))
			{
				nextStageDisseminateOdds += (DomainManager.Character.HasRelation(targetCharacterId, actorId, 16384) ? reception.DisRateActLo : reception.DisRateActAd);
				isAnyRelationExist = true;
			}
			if (hasActor && IsCharIdIsOrgLeader(DomainManager.Character.GetAliveOrgDeadCharacterOrgInfo(actorId).SettlementId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateActLe;
				isAnyRelationExist = true;
			}
			if (hasReactor && DomainManager.Character.IsCharacterRelationFriendly(reactorId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateUnaFri;
				isAnyRelationExist = true;
			}
			if (hasReactor && DomainManager.Character.IsCharacterRelationUnfriendly(reactorId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateUnaEn;
				isAnyRelationExist = true;
			}
			if (hasReactor && DomainManager.Character.HasRelation(reactorId, targetCharacterId, 16384))
			{
				nextStageDisseminateOdds += (DomainManager.Character.HasRelation(targetCharacterId, reactorId, 16384) ? reception.DisRateUnaLo : reception.DisRateActAd);
				isAnyRelationExist = true;
			}
			if (hasReactor && IsCharIdIsOrgLeader(DomainManager.Character.GetAliveOrgDeadCharacterOrgInfo(reactorId).SettlementId, targetCharacterId))
			{
				nextStageDisseminateOdds += reception.DisRateUnaLe;
				isAnyRelationExist = true;
			}
			if (!isAnyRelationExist)
			{
				nextStageDisseminateOdds += reception.DisNoRate;
			}
		}
		nextStageDisseminateOdds += (usePersonalityTypeDisForRelation ? reception.BehaviorTypeDisForRelationForEffective : reception.BehaviorTypeDisForNonRelation)[targetCharacter.GetBehaviorType()];
		for (sbyte pi = 0; pi < 5; pi++)
		{
			nextStageDisseminateOdds += (usePersonalityTypeDisForRelation ? reception.PersonalityTypeDisForRelationForEffective : reception.PersonalityTypeDisForNonRelation)[pi] * targetCharacter.GetPersonality(pi);
		}
		return nextStageDisseminateOdds;
		static bool IsCharIdIsOrgLeader(short settlementId, int checkCharId)
		{
			if (settlementId < 0)
			{
				return false;
			}
			Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
			int result;
			if (Config.Organization.Instance.GetItem(settlement.GetOrgTemplateId()).IsSect)
			{
				GameData.Domains.Character.Character leader = settlement.GetLeader();
				result = ((leader != null && leader.GetId() == checkCharId) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	private CharacterKnownSecret EnsureCharacterKnownSecret(DataContext context, int characterId)
	{
		if (TryGetElement_CharacterKnownSecrets(characterId, out var knownSecret))
		{
			return knownSecret;
		}
		AddElement_CharacterKnownSecrets(characterId, knownSecret = new CharacterKnownSecret(), context);
		return knownSecret;
	}

	internal void EditCharacterKnownSecret(DataContext context, int characterId, Action<CharacterKnownSecret> editAction)
	{
		if (TryGetElement_CharacterKnownSecrets(characterId, out var knownSecret))
		{
			editAction(knownSecret);
			SetElement_CharacterKnownSecrets(characterId, knownSecret, context);
		}
		else
		{
			knownSecret = new CharacterKnownSecret();
			editAction(knownSecret);
			AddElement_CharacterKnownSecrets(characterId, knownSecret, context);
		}
	}

	internal bool TryGetCharacterKnownSecret(int characterId, out CharacterKnownSecret knownSecret)
	{
		return TryGetElement_CharacterKnownSecrets(characterId, out knownSecret);
	}

	internal void FixLackOfJingangInformation(DataContext ctx)
	{
		SecretInformationId secretId = QueryAllSecretInformation(delegate(SecretOccurence occurence)
		{
			short templateId = occurence.TemplateId;
			return (uint)(templateId - 112) <= 3u;
		}).FirstOrDefault()?.Id ?? SecretInformationId.Invalid;
		if (secretId == SecretInformationId.Invalid && DomainManager.Character.TryGetFixedCharacterByTemplateId(777, out var westernBuddhistMonk))
		{
			secretId = AddSecretInformation(ctx, GetSecretInformationCollection().AddSolveScripture1(westernBuddhistMonk.GetId()), withInitialDistribute: false);
		}
		ReceiveSecretInformation(ctx, secretId, DomainManager.Taiwu.GetTaiwuCharId());
	}

	internal int FixOrGetLackOfJingangInformation(DataContext context)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		int secretId = 0;
		argBox.Get(SectMainStoryEventArgKey.DefValue.JingangSecInfoMetaDataId, ref secretId);
		GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation((SecretInformationId)secretId);
		if (secret != null)
		{
			SecretOccurence secretOccurence = DomainManager.Information.QuerySecretOccurence(secret.Id);
			if (secretOccurence != null && !DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwuId, secretOccurence.TemplateId))
			{
				DomainManager.Information.ReceiveSecretInformation(context, (SecretInformationId)secretId, DomainManager.Taiwu.GetTaiwuCharId());
			}
		}
		else
		{
			int occurence = 0;
			argBox.Get(SectMainStoryEventArgKey.DefValue.JingangSecInfoOccurenceId, ref occurence);
			SecretOccurence secretOccurence2 = DomainManager.Information.QuerySecretOccurence((SecretOccurenceId)occurence);
			if (secretOccurence2 != null && !DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwuId, secretOccurence2.TemplateId))
			{
				SecretInformationId newId = DomainManager.Information.AddSecretInformation(context, secretOccurence2, withInitialDistribute: false, necessarily: false, null);
				DomainManager.Information.ReceiveSecretInformation(context, newId, taiwuId);
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangSecInfoMetaDataId, (int)newId);
			}
		}
		return secretId;
	}

	private bool CheckNeedFixLackOfJingangInformation()
	{
		WorldDomain worldDomain = DomainManager.World;
		int jingangTaskInProgress = worldDomain.GetExtraTaskChainCurrentTask(32);
		if (205 == jingangTaskInProgress)
		{
			int stage = DomainManager.Story.JingangSpreadSecInfoStage();
			if (stage < 0)
			{
				return true;
			}
		}
		return false;
	}

	internal void ReleaseAllJingangInformation(DataContext ctx)
	{
		List<SecretInformationId> ids = new List<SecretInformationId>();
		int[] array = _characterKnownSecrets.Keys.ToArray();
		foreach (int handlerId in array)
		{
			ids.Clear();
			foreach (SecretInformationId secretId in QueryCharacterKnownSecretInformationIds(handlerId))
			{
				if (EventHelper.JingangSecretInformationIsSolveScripture((int)secretId))
				{
					ids.Add(secretId);
				}
			}
			foreach (SecretInformationId id in ids)
			{
				DiscardSecretInformation(ctx, handlerId, id);
			}
		}
		GameData.Domains.Information.Secret.SecretInformation[] array2 = QueryAllSecretInformation((SecretOccurence occurence) => occurence.InBroadcast).ToArray();
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in array2)
		{
			if (EventHelper.JingangSecretInformationIsSolveScripture((int)secret.Id))
			{
				SecretReleaseFromBroadcast(ctx, QuerySecretOccurence(secret.OccurenceId));
			}
		}
	}

	internal GameData.Domains.Information.Secret.SecretInformation QuerySecretInformation(SecretInformationId id)
	{
		return _secretInformation.GetValueOrDefault(id);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal IEnumerable<GameData.Domains.Information.Secret.SecretInformation> QueryAllSecretInformation(Func<GameData.Domains.Information.Secret.SecretInformation, bool> predicate)
	{
		return _secretInformation.Values.Where(predicate);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal IEnumerable<GameData.Domains.Information.Secret.SecretInformation> QueryAllSecretInformation(Predicate<SecretOccurence> predicate)
	{
		Dictionary<SecretOccurenceId, bool> cache = new Dictionary<SecretOccurenceId, bool>();
		foreach (GameData.Domains.Information.Secret.SecretInformation secret in _secretInformation.Values)
		{
			if (!cache.TryGetValue(secret.OccurenceId, out var hit))
			{
				SecretOccurenceId occurenceId = secret.OccurenceId;
				bool value;
				hit = (value = predicate(QuerySecretOccurence(secret.OccurenceId)));
				cache[occurenceId] = value;
			}
			if (hit)
			{
				yield return secret;
			}
		}
	}

	internal SecretOccurence QuerySecretOccurence(SecretOccurenceId id)
	{
		return _secretOccurence.GetValueOrDefault(id);
	}

	internal SecretOccurence QuerySecretOccurence(SecretInformationId id)
	{
		SecretOccurence result = null;
		GameData.Domains.Information.Secret.SecretInformation secret = QuerySecretInformation(id);
		if (secret != null)
		{
			result = QuerySecretOccurence(secret.OccurenceId);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal IEnumerable<SecretOccurence> QueryAllSecretOccurence(Func<SecretOccurence, bool> predicate)
	{
		return _secretOccurence.Values.Where(predicate);
	}

	internal IReadOnlyCollection<int> SecretInformationAllHandledCharacterIds()
	{
		return _characterKnownSecrets.Keys;
	}

	internal IReadOnlyCollection<SecretInformationId> QueryCharacterKnownSecretInformationIds(int characterId)
	{
		IReadOnlyCollection<SecretInformationId> result;
		if (!TryGetElement_CharacterKnownSecrets(characterId, out var knownSecret))
		{
			IReadOnlyCollection<SecretInformationId> readOnlyCollection = Array.Empty<SecretInformationId>();
			result = readOnlyCollection;
		}
		else
		{
			IReadOnlyCollection<SecretInformationId> readOnlyCollection = knownSecret.KnownSecrets;
			result = readOnlyCollection;
		}
		return result;
	}

	public bool CharacterHasSecretInformationByTemplateId(int charId, short templateId)
	{
		if (QueryCharacterKnownSecretInformationIds(charId).Any((SecretInformationId secretId) => QuerySecretOccurence(secretId).TemplateId == templateId))
		{
			return true;
		}
		return QueryAllSecretOccurence((SecretOccurence item) => item.TemplateId == templateId && item.InBroadcast).Any();
	}

	internal bool CharacterHasSecretInformation(int characterId, SecretInformationId secretInformationId)
	{
		return QueryCharacterKnownSecretInformationIds(characterId).Contains(secretInformationId);
	}

	internal int CalcSecretInformationKnownCharacterCount(SecretInformationId secretId)
	{
		HashSet<int> result;
		return _secretInformationHoldersCache.TryGetValue(secretId, out result) ? result.Count : 0;
	}

	public InformationDomain()
		: base(9)
	{
		_information = new Dictionary<int, NormalInformationCollection>(0);
		_secretInformationCollection = new SecretInformationCollection();
		_taiwuReceivedNormalInformationInMonth = new List<NormalInformation>();
		_taiwuReceivedInformation = new List<int>();
		_taiwuTmpInformation = new List<NormalInformation>();
		_characterKnownSecrets = new Dictionary<int, CharacterKnownSecret>(0);
		_secretInformation = new Dictionary<SecretInformationId, GameData.Domains.Information.Secret.SecretInformation>(0);
		_secretOccurence = new Dictionary<SecretOccurenceId, SecretOccurence>(0);
		_secretInformationLevelFactors = new int[4];
		OnInitializedDomainData();
	}

	public NormalInformationCollection GetElement_Information(int elementId)
	{
		return _information[elementId];
	}

	public bool TryGetElement_Information(int elementId, out NormalInformationCollection value)
	{
		return _information.TryGetValue(elementId, out value);
	}

	private void AddElement_Information(int elementId, NormalInformationCollection value, DataContext context)
	{
		_information.Add(elementId, value);
		_modificationsInformation.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void SetElement_Information(int elementId, NormalInformationCollection value, DataContext context)
	{
		_information[elementId] = value;
		_modificationsInformation.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_Information(int elementId, DataContext context)
	{
		_information.Remove(elementId);
		_modificationsInformation.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	private void ClearInformation(DataContext context)
	{
		_information.Clear();
		_modificationsInformation.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public SecretInformationCollection GetSecretInformationCollection()
	{
		return _secretInformationCollection;
	}

	private void CommitInsert_SecretInformationCollection(DataContext context, int offset, int size)
	{
		_modificationsSecretInformationCollection.RecordInserting(offset, size);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void CommitWrite_SecretInformationCollection(DataContext context, int offset, int size)
	{
		_modificationsSecretInformationCollection.RecordWriting(offset, size);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void CommitRemove_SecretInformationCollection(DataContext context, int offset, int size)
	{
		_modificationsSecretInformationCollection.RecordRemoving(offset, size);
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	private void CommitSetMetadata_SecretInformationCollection(DataContext context)
	{
		_modificationsSecretInformationCollection.RecordSettingMetadata();
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _taiwuReceivedNormalInformationInMonth is no longer in use.")]
	public List<NormalInformation> GetTaiwuReceivedNormalInformationInMonth()
	{
		return _taiwuReceivedNormalInformationInMonth;
	}

	[Obsolete("DomainData _taiwuReceivedNormalInformationInMonth is no longer in use.")]
	public void SetTaiwuReceivedNormalInformationInMonth(List<NormalInformation> value, DataContext context)
	{
		_taiwuReceivedNormalInformationInMonth = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public List<int> GetTaiwuReceivedInformation()
	{
		return _taiwuReceivedInformation;
	}

	public void SetTaiwuReceivedInformation(List<int> value, DataContext context)
	{
		_taiwuReceivedInformation = value;
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public List<NormalInformation> GetTaiwuTmpInformation()
	{
		return _taiwuTmpInformation;
	}

	public void SetTaiwuTmpInformation(List<NormalInformation> value, DataContext context)
	{
		_taiwuTmpInformation = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private CharacterKnownSecret GetElement_CharacterKnownSecrets(int elementId)
	{
		return _characterKnownSecrets[elementId];
	}

	private bool TryGetElement_CharacterKnownSecrets(int elementId, out CharacterKnownSecret value)
	{
		return _characterKnownSecrets.TryGetValue(elementId, out value);
	}

	private void AddElement_CharacterKnownSecrets(int elementId, CharacterKnownSecret value, DataContext context)
	{
		_characterKnownSecrets.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void SetElement_CharacterKnownSecrets(int elementId, CharacterKnownSecret value, DataContext context)
	{
		_characterKnownSecrets[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_CharacterKnownSecrets(int elementId, DataContext context)
	{
		_characterKnownSecrets.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private void ClearCharacterKnownSecrets(DataContext context)
	{
		_characterKnownSecrets.Clear();
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	private GameData.Domains.Information.Secret.SecretInformation GetElement_SecretInformation(SecretInformationId elementId)
	{
		return _secretInformation[elementId];
	}

	private bool TryGetElement_SecretInformation(SecretInformationId elementId, out GameData.Domains.Information.Secret.SecretInformation value)
	{
		return _secretInformation.TryGetValue(elementId, out value);
	}

	private void AddElement_SecretInformation(SecretInformationId elementId, GameData.Domains.Information.Secret.SecretInformation value, DataContext context)
	{
		_secretInformation.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void SetElement_SecretInformation(SecretInformationId elementId, GameData.Domains.Information.Secret.SecretInformation value, DataContext context)
	{
		_secretInformation[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SecretInformation(SecretInformationId elementId, DataContext context)
	{
		_secretInformation.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void ClearSecretInformation(DataContext context)
	{
		_secretInformation.Clear();
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private SecretOccurence GetElement_SecretOccurence(SecretOccurenceId elementId)
	{
		return _secretOccurence[elementId];
	}

	private bool TryGetElement_SecretOccurence(SecretOccurenceId elementId, out SecretOccurence value)
	{
		return _secretOccurence.TryGetValue(elementId, out value);
	}

	private void AddElement_SecretOccurence(SecretOccurenceId elementId, SecretOccurence value, DataContext context)
	{
		_secretOccurence.Add(elementId, value);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_SecretOccurence(SecretOccurenceId elementId, SecretOccurence value, DataContext context)
	{
		_secretOccurence[elementId] = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SecretOccurence(SecretOccurenceId elementId, DataContext context)
	{
		_secretOccurence.Remove(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearSecretOccurence(DataContext context)
	{
		_secretOccurence.Clear();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public int[] GetSecretInformationLevelFactors()
	{
		return _secretInformationLevelFactors;
	}

	public void SetSecretInformationLevelFactors(int[] value, DataContext context)
	{
		_secretInformationLevelFactors = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)6);
		archive.WriteDomainDataMeta(0);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_information);
		archive.WriteDomainDataMeta(1);
		archive.WriteBinary(_secretInformationCollection);
		archive.WriteDomainDataMeta(5);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_characterKnownSecrets);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueCollectionCustomKeyValue(_secretInformation);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueCollectionCustomKeyValue(_secretOccurence);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueUnmanagedArray(_secretInformationLevelFactors);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			switch (domainDataMeta.DataId)
			{
			case 0:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_information);
				break;
			case 1:
				archive.ReadBinary(_secretInformationCollection);
				break;
			case 2:
				archive.ReadSingleValueCustomList(ref _taiwuReceivedNormalInformationInMonth);
				break;
			case 5:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_characterKnownSecrets);
				break;
			case 6:
				archive.ReadSingleValueCollectionCustomKeyValue(_secretInformation);
				break;
			case 7:
				archive.ReadSingleValueCollectionCustomKeyValue(_secretOccurence);
				break;
			case 8:
				archive.ReadSingleValueUnmanagedArray(ref _secretInformationLevelFactors);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(18);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
				_modificationsInformation.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_information, dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
				_modificationsSecretInformationCollection.Reset(_secretInformationCollection.GetSize());
			}
			return GameData.Serializer.Serializer.SerializeModifications(_secretInformationCollection, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuReceivedNormalInformationInMonth, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuReceivedInformation, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuTmpInformation, dataPool);
		case 5:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 6:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 7:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			return GameData.Serializer.Serializer.Serialize(_secretInformationLevelFactors, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 2:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuReceivedNormalInformationInMonth);
			SetTaiwuReceivedNormalInformationInMonth(_taiwuReceivedNormalInformationInMonth, context);
			break;
		case 3:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuReceivedInformation);
			SetTaiwuReceivedInformation(_taiwuReceivedInformation, context);
			break;
		case 4:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuTmpInformation);
			SetTaiwuTmpInformation(_taiwuTmpInformation, context);
			break;
		case 5:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _secretInformationLevelFactors);
			SetSecretInformationLevelFactors(_secretInformationLevelFactors, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				int characterId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId2);
				NormalInformationCollection returnValue4 = GetCharacterNormalInformation(characterId2);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 2)
			{
				int characterId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId7);
				NormalInformation information2 = default(NormalInformation);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref information2);
				AddNormalInformationToCharacter(context, characterId7, information2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
			if (operation.ArgsCount == 0)
			{
				DeleteTmpInformation(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 3:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				int characterId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId5);
				NormalInformation information = default(NormalInformation);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref information);
				int returnValue9 = GetNormalInformationUsedCount(characterId5, information);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				List<int> secretIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretIds);
				SecretInformationDisplayPackage returnValue15 = GetSecretInformationDisplayPackage(secretIds);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 1)
			{
				int characterId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId4);
				SecretInformationDisplayPackage returnValue8 = GetSecretInformationDisplayPackageFromCharacter(characterId4);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 1)
			{
				int characterId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId10);
				SecretInformationDisplayPackage returnValue16 = GetSecretInformationDisplayPackageFromBroadcast(characterId10);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 7:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 1)
			{
				int characterId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId6);
				SecretInformationDisplayPackage returnValue12 = GetSecretInformationDisplayPackageForSelections(characterId6);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 2)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				SecretInformationId secretId2 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId2);
				DiscardSecretInformation(context, charId, secretId2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 2)
			{
				string templateDefKeyName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateDefKeyName);
				List<int> charIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charIds);
				SecretInformationId returnValue2 = GmCmd_CreateSecretInformationByCharacterIds(context, templateDefKeyName, charIds);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 2)
			{
				int characterId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId8);
				SecretInformationId secretId7 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId7);
				bool returnValue13 = GmCmd_MakeCharacterReceiveSecretInformation(context, characterId8, secretId7);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 11:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 3)
			{
				SecretInformationId secretId6 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId6);
				int sourceCharId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceCharId4);
				int targetCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId);
				bool returnValue11 = DisseminateSecretInformation(context, secretId6, sourceCharId4, targetCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				List<int> charList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charList);
				List<CharacterDisplayDataWithInfo> returnValue6 = GetCharacterDisplayDataWithInfoList(charList);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				SecretInformationId secretId4 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId4);
				GmCmd_MakeSecretInformationBroadcast(context, secretId4);
				return -1;
			}
			case 2:
			{
				SecretInformationId secretId3 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId3);
				int sourceCharId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceCharId2);
				GmCmd_MakeSecretInformationBroadcast(context, secretId3, sourceCharId2);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 14:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				NormalInformation normalInformation = default(NormalInformation);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref normalInformation);
				PerformProfessionLiteratiSkill3(context, normalInformation);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				int secretInformationId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretInformationId);
				PerformProfessionLiteratiSkill2(context, secretInformationId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 2)
			{
				int characterId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId9);
				NormalInformation information3 = default(NormalInformation);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref information3);
				IntPair returnValue14 = GetNormalInformationUsedCountAndMax(characterId9, information3);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 2)
			{
				List<IntPair> secretList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretList);
				int shopCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref shopCharId);
				SettleSecretInformationShopTrade(context, secretList, shopCharId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 3)
			{
				SecretInformationId secretId5 = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId5);
				int sourceCharId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceCharId3);
				int amount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref amount);
				int returnValue10 = GmCmd_DisseminationSecretInformationToRandomCharacters(context, secretId5, sourceCharId3, amount);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				int characterId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId3);
				List<NormalInformationDisplayData> returnValue7 = GetCharacterNormalInformationDisplayData(characterId3);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				int[] value = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref value);
				SetSecretInformationLevelFactor(context, value);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
			if (operation.ArgsCount == 0)
			{
				int[] returnValue5 = GetSecretInformationLevelFactor();
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 22:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 2)
			{
				SecretInformationId secretId = default(SecretInformationId);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref secretId);
				int sourceCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref sourceCharId);
				List<SecretInformationEffectData> returnValue3 = GetSecretInformationDetailedData(context, secretId, sourceCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int characterId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId);
				int returnValue = GetSecretInformationAmountFromCharacter(characterId);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		switch (dataId)
		{
		case 0:
			_modificationsInformation.ChangeRecording(monitoring);
			break;
		case 1:
			_modificationsSecretInformationCollection.ChangeRecording(monitoring, _secretInformationCollection.GetSize());
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 0);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_information, dataPool, _modificationsInformation);
			_modificationsInformation.Reset();
			return offset2;
		}
		case 1:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_secretInformationCollection, dataPool, _modificationsSecretInformationCollection);
			_modificationsSecretInformationCollection.Reset(_secretInformationCollection.GetSize());
			return offset;
		}
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_taiwuReceivedNormalInformationInMonth, dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			return GameData.Serializer.Serializer.Serialize(_taiwuReceivedInformation, dataPool);
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_taiwuTmpInformation, dataPool);
		case 5:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 8:
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			return GameData.Serializer.Serializer.Serialize(_secretInformationLevelFactors, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			if (BaseGameDataDomain.IsModified(DataStates, 0))
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
				_modificationsInformation.Reset();
			}
			break;
		case 1:
			if (BaseGameDataDomain.IsModified(DataStates, 1))
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			break;
		case 2:
			if (BaseGameDataDomain.IsModified(DataStates, 2))
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			break;
		case 5:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 6:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => BaseGameDataDomain.IsModified(DataStates, 0), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			6 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			7 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}

	public static bool CheckTuringTest(GameData.Domains.Character.Character character)
	{
		if (character == null)
		{
			return false;
		}
		return character.GetCreatingType() == 1 && character.GetAgeGroup() > 0;
	}

	public static bool CheckTuringTest(int charId, out GameData.Domains.Character.Character character)
	{
		return DomainManager.Character.TryGetElement_Objects(charId, out character) && CheckTuringTest(character);
	}

	public static List<GameData.Domains.Character.Character> GetTuringTestPassedCharacters(IEnumerable collection)
	{
		List<GameData.Domains.Character.Character> result = new List<GameData.Domains.Character.Character>();
		foreach (int charId in collection)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && CheckTuringTest(character))
			{
				result.Add(character);
			}
		}
		return result;
	}
}
