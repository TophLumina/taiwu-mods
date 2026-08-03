using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class DaShouYin : AssistSkillBase
{
	private const int AddNeiliAllocationCount = 5;

	private const int MaxUsableTrickCount = 5;

	private DataUid _selfNeiliAllocationUid;

	private DataUid _enemyNeiliAllocationUid;

	private DataUid _enemyTrickUid;

	private bool _affecting;

	private int _enemyUselessTrickCount;

	private int EnemyMaxTrickCount => _enemyUselessTrickCount + 5;

	public DaShouYin()
	{
	}

	public DaShouYin(CombatSkillKey skillKey)
		: base(skillKey, 11706)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_selfNeiliAllocationUid = ParseNeiliAllocationDataUid();
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey, UpdateCanAffect);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_OverflowTrickRemoved(OnOverflowTrickRemoved);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey);
		RemoveEnemyUid();
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_OverflowTrickRemoved(OnOverflowTrickRemoved);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedCurrEnemyData(context, 170, EDataModifyType.Custom, -1);
		AppendEnemyUid();
		_affecting = false;
		_enemyUselessTrickCount = 0;
		UpdateCanAffect(context, default(DataUid));
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			ClearAffectedData(context);
			AppendAffectedCurrEnemyData(context, 170, EDataModifyType.Custom, -1);
			RemoveEnemyUid();
			AppendEnemyUid();
		}
		UpdateCanAffect(context, default(DataUid));
	}

	private void AppendEnemyUid()
	{
		int enemyCharId = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetId();
		_enemyNeiliAllocationUid = ParseNeiliAllocationDataUid(enemyCharId);
		_enemyTrickUid = ParseCombatCharacterDataUid(enemyCharId, 28);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey, UpdateCanAffect);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyTrickUid, base.DataHandlerKey, OnTrickChanged);
	}

	private void RemoveEnemyUid()
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyTrickUid, base.DataHandlerKey);
	}

	private void OnOverflowTrickRemoved(DataContext context, int charId, bool isAlly, int removedCount)
	{
		if (_affecting && isAlly != base.CombatChar.IsAlly && removedCount > 0 && EnemyMaxTrickCount < 9)
		{
			CombatCharacter affectChar = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly) : base.CombatChar);
			if (affectChar.ChangeNeiliAllocationRandom(context, 5, removedCount))
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnTrickChanged(DataContext context, DataUid dataUid)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		_enemyUselessTrickCount = enemyChar.UselessTrickCount;
		int trickCount = enemyChar.GetTricks().Tricks.Count;
		bool removeTrick = trickCount > EnemyMaxTrickCount;
		if (_affecting && removeTrick)
		{
			DomainManager.Combat.RemoveOverflowTrick(context, enemyChar, updateFieldAndSkill: true);
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect;
		if (DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && base.CanAffect)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			int selfTotalValue = base.CombatChar.GetNeiliAllocation().GetTotal();
			int enemyTotalValue = enemyChar.GetNeiliAllocation().GetTotal();
			canAffect = (base.IsDirect ? (selfTotalValue > enemyTotalValue) : (selfTotalValue < enemyTotalValue));
		}
		else
		{
			canAffect = false;
		}
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			SetConstAffecting(context, canAffect);
			InvalidateAllEnemyCache(context, 170);
			if (canAffect)
			{
				DomainManager.Combat.RemoveOverflowTrick(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly), updateFieldAndSkill: true);
			}
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (!_affecting)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 170)
		{
			return Math.Min(EnemyMaxTrickCount, dataValue);
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
