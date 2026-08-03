using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class BaiXieTiDaFa : CombatSkillEffectBase
{
	private const sbyte PowerChangePerFeature = 3;

	private int _selfAddPower;

	private DataUid _selfNeiliAllocationUid;

	private Dictionary<int, int> _enemyReducePowers;

	private List<DataUid> _enemyNeiliAllocationUids;

	private bool _affected;

	public BaiXieTiDaFa()
	{
	}

	public BaiXieTiDaFa(CombatSkillKey skillKey)
		: base(skillKey, 12006, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			_affected = true;
			_selfAddPower = CalcChangePower(base.CharacterId);
			_selfNeiliAllocationUid = ParseCharDataUid(17);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey, OnFeaturesChange);
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
		}
		else
		{
			Events.RegisterHandler_CombatBegin(OnCombatBegin);
			Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
			Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (base.IsDirect)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey);
			return;
		}
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			return;
		}
		_affected = base.IsDirect || base.IsCurrent;
		_enemyReducePowers = new Dictionary<int, int>();
		_enemyNeiliAllocationUids = new List<DataUid>();
		int[] enemyIdList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		foreach (int enemyId in enemyIdList)
		{
			if (enemyId >= 0)
			{
				_enemyReducePowers.Add(enemyId, CalcChangePower(enemyId));
				DataUid enemyFeaturesUid = new DataUid(4, 0, (ulong)enemyId, 17u);
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(enemyFeaturesUid, base.DataHandlerKey, OnFeaturesChange);
				_enemyNeiliAllocationUids.Add(enemyFeaturesUid);
				AppendAffectedData(context, enemyId, 199, EDataModifyType.AddPercent, -1);
			}
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			bool affected = base.IsDirect || base.IsCurrent;
			if (affected != _affected)
			{
				_affected = affected;
				InvalidateAllEnemyCache(context, 199);
			}
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (_enemyReducePowers != null)
		{
			for (int i = 0; i < _enemyNeiliAllocationUids.Count; i++)
			{
				GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUids[i], base.DataHandlerKey);
			}
			_enemyReducePowers = null;
			_enemyNeiliAllocationUids = null;
			ClearAffectedData(context);
		}
	}

	private void OnFeaturesChange(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		int changePower = CalcChangePower(charId);
		if (base.IsDirect)
		{
			_selfAddPower = changePower;
		}
		else
		{
			_enemyReducePowers[charId] = changePower;
		}
		DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
	}

	private int CalcChangePower(int charId)
	{
		List<short> featureIds = DomainManager.Character.GetElement_Objects(charId).GetFeatureIds();
		int changePower = 0;
		for (int i = 0; i < featureIds.Count; i++)
		{
			CharacterFeatureItem featureConfig = CharacterFeature.Instance[featureIds[i]];
			if (base.IsDirect ? featureConfig.IsBad() : featureConfig.IsGood())
			{
				changePower += (base.IsDirect ? 3 : (-3));
			}
		}
		return changePower;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 199 && _affected)
		{
			return base.IsDirect ? _selfAddPower : _enemyReducePowers[dataKey.CharId];
		}
		return 0;
	}
}
