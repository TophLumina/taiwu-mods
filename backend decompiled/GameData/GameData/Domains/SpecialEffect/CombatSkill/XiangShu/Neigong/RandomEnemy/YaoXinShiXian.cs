using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class YaoXinShiXian : MinionBase
{
	private static readonly sbyte[] AddPenetrate = new sbyte[4] { 0, 25, 50, 100 };

	private DataUid _enemyHappinessUid;

	private int _addPercent;

	public YaoXinShiXian()
	{
	}

	public YaoXinShiXian(CombatSkillKey skillKey)
		: base(skillKey, 16003)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 44, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 45, -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyHappinessUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateEnemyDataUid(context);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyHappinessUid, base.DataHandlerKey);
			UpdateEnemyDataUid(context);
		}
	}

	private void UpdateEnemyDataUid(DataContext context)
	{
		_enemyHappinessUid = ParseCombatCharacterDataUid(base.EnemyChar.GetId(), 139);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyHappinessUid, base.DataHandlerKey, UpdateAddPercent);
		UpdateAddPercent(context, default(DataUid));
	}

	private void UpdateAddPercent(DataContext context, DataUid dataUid)
	{
		sbyte happinessType = HappinessType.GetHappinessType(base.EnemyChar.GetHappiness());
		_addPercent = AddPenetrate[Math.Abs(happinessType - 3)];
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 44);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 45);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !MinionBase.CanAffect)
		{
			return 0;
		}
		return _addPercent;
	}
}
