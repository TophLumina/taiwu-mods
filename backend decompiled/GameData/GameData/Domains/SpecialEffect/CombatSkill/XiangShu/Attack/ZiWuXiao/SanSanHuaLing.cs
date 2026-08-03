using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ZiWuXiao;

public class SanSanHuaLing : CombatSkillEffectBase
{
	private DataUid _selfNeiliAllocationUid;

	private NeiliAllocation _selfLastNeiliAllocation;

	private DataUid _enemyNeiliAllocationUid;

	private NeiliAllocation _enemyLastNeiliAllocation;

	public SanSanHuaLing()
	{
	}

	public SanSanHuaLing(CombatSkillKey skillKey)
		: base(skillKey, 17110, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_selfLastNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		_selfNeiliAllocationUid = new DataUid(8, 10, (ulong)base.CharacterId, 3u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey, OnSelfNeiliAllocationChanged);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateEnemyUid(init: true);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.EffectCount <= 0)
		{
			AddMaxEffectCount();
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			UpdateEnemyUid(init: false);
		}
	}

	private unsafe void OnSelfNeiliAllocationChanged(DataContext context, DataUid dataUid)
	{
		NeiliAllocation newNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		for (byte type = 0; type < 4; type++)
		{
			if (newNeiliAllocation.Items[(int)type] < _selfLastNeiliAllocation.Items[(int)type])
			{
				ReduceEffectCount();
				break;
			}
		}
		_selfLastNeiliAllocation = newNeiliAllocation;
	}

	private void OnEnemyNeiliAllocationChanged(DataContext context, DataUid dataUid)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		NeiliAllocation newNeiliAllocation = currEnemy.GetNeiliAllocation();
		if (base.EffectCount > 0)
		{
			bool affected = false;
			for (byte type = 0; type < 4; type++)
			{
				int changeValue = Math.Abs(newNeiliAllocation[type] - _enemyLastNeiliAllocation[type]);
				if (changeValue != 0)
				{
					base.CombatChar.ChangeNeiliAllocation(context, type, changeValue * 2);
					affected = true;
				}
			}
			if (affected)
			{
				ShowSpecialEffectTips(0);
			}
		}
		_enemyLastNeiliAllocation = newNeiliAllocation;
	}

	private void UpdateEnemyUid(bool init)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		_enemyLastNeiliAllocation = currEnemy.GetNeiliAllocation();
		if (!init)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		}
		_enemyNeiliAllocationUid = new DataUid(8, 10, (ulong)currEnemy.GetId(), 3u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey, OnEnemyNeiliAllocationChanged);
	}
}
