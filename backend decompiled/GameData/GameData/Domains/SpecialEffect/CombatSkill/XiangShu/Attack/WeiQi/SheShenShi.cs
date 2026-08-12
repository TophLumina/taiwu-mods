using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.WeiQi;

public class SheShenShi : CombatSkillEffectBase
{
	private const sbyte NeiliAllocationValue = 18;

	private DataUid _enemyInjuriesUid;

	public SheShenShi()
	{
	}

	public SheShenShi(CombatSkillKey skillKey)
		: base(skillKey, 17053, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (IsSrcSkillPerformed)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey);
		}
	}

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted)
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
		List<byte> typeRandomPool = ObjectPool<List<byte>>.Instance.Get();
		typeRandomPool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (neiliAllocation.Items[(int)type] >= 18)
			{
				typeRandomPool.Add(type);
			}
		}
		if (!IsSrcSkillPerformed)
		{
			if (typeRandomPool.Count > 0)
			{
				byte type2 = typeRandomPool[context.Random.Next(typeRandomPool.Count)];
				base.CombatChar.ChangeNeiliAllocation(context, type2, -18);
				if (CheckAndAddNeiliAllocation(context))
				{
					RemoveSelf(context);
				}
				else
				{
					IsSrcSkillPerformed = true;
					AddMaxEffectCount();
					UpdateEnemyUid(init: true);
				}
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (typeRandomPool.Count > 0)
		{
			RemoveSelf(context);
		}
		ObjectPool<List<byte>>.Instance.Return(typeRandomPool);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (IsSrcSkillPerformed && isAlly != base.CombatChar.IsAlly)
		{
			UpdateEnemyUid(init: false);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnEnemyInjuriesChanged(DataContext context, DataUid dataUid)
	{
		if (CheckAndAddNeiliAllocation(context))
		{
			ReduceEffectCount();
		}
	}

	private void UpdateEnemyUid(bool init)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (!init)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey);
		}
		_enemyInjuriesUid = new DataUid(8, 10, (ulong)currEnemy.GetId(), 29u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyInjuriesUid, base.DataHandlerKey, OnEnemyInjuriesChanged);
	}

	private bool CheckAndAddNeiliAllocation(DataContext context)
	{
		Injuries enemyInjuries = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetInjuries();
		bool affected = false;
		for (sbyte part = 0; part < 7; part++)
		{
			(sbyte, sbyte) injury = enemyInjuries.Get(part);
			if (injury.Item1 >= 6 || injury.Item2 >= 6)
			{
				affected = true;
				break;
			}
		}
		if (affected)
		{
			for (byte type = 0; type < 4; type++)
			{
				base.CombatChar.ChangeNeiliAllocation(context, type, 18);
			}
			ShowSpecialEffectTips(0);
		}
		return affected;
	}
}
