using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class ShenDuanHuFa : MinionBase
{
	private const sbyte MaxReducePercent = 50;

	private bool _isCurrCombatChar;

	private DataUid _infectionUid;

	private int _reducePercent;

	public ShenDuanHuFa()
	{
	}

	public ShenDuanHuFa(CombatSkillKey skillKey)
		: base(skillKey, 16007)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_infectionUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		_isCurrCombatChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
		UpdateEnemyData(context);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			bool isCurrChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
			if (_isCurrCombatChar != isCurrChar)
			{
				_isCurrCombatChar = isCurrChar;
				InvalidateAffectDataCache(context);
			}
		}
		else if (base.IsDirect)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_infectionUid, base.DataHandlerKey);
			UpdateEnemyData(context);
		}
	}

	private void UpdateEnemyData(DataContext context)
	{
		int enemyCharId = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetId();
		ClearAffectedData(context);
		AppendAffectedData(context, enemyCharId, 44, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, enemyCharId, 45, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, enemyCharId, 46, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, enemyCharId, 47, EDataModifyType.TotalPercent, -1);
		_infectionUid = ParseCharDataUid(enemyCharId, 64);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_infectionUid, base.DataHandlerKey, UpdateEffect);
		UpdateEffect(context, default(DataUid));
	}

	private void UpdateEffect(DataContext context, DataUid dataUid)
	{
		int infection = base.EnemyChar.GetCharacter().GetXiangshuInfection();
		_reducePercent = -Math.Min(infection * 100 / 200, 50);
		if (_isCurrCombatChar)
		{
			InvalidateAffectDataCache(context);
		}
	}

	private void InvalidateAffectDataCache(DataContext context)
	{
		int enemyCharId = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetId();
		DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 44);
		DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 45);
		DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 46);
		DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 47);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_isCurrCombatChar || !MinionBase.CanAffect)
		{
			return 0;
		}
		return _reducePercent;
	}
}
