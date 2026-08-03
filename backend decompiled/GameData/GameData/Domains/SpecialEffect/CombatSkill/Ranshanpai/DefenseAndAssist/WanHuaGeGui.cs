using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class WanHuaGeGui : DefenseSkillBase
{
	private static readonly CValuePercent ChangeNeiliAllocationPercent = 10;

	private const int SilenceFrame = 3000;

	public WanHuaGeGui()
	{
	}

	public WanHuaGeGui(CombatSkillKey skillKey)
		: base(skillKey, 7507)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(290, EDataModifyType.Custom, -1);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		DomainManager.Combat.SilenceSkill(context, base.CombatChar, base.SkillTemplateId, 3000, -1);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!isFightBack || !hit || attacker != base.CombatChar || !base.CanAffect)
		{
			return;
		}
		CombatCharacter affectChar = (base.IsDirect ? attacker : defender);
		NeiliAllocation neiliAllocation = affectChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = affectChar.GetOriginNeiliAllocation();
		List<byte> pool = ObjectPool<List<byte>>.Instance.Get();
		pool.Clear();
		for (byte i = 0; i < 4; i++)
		{
			if (!(base.IsDirect ? (neiliAllocation[i] >= originNeiliAllocation[i]) : (neiliAllocation[i] <= originNeiliAllocation[i])))
			{
				pool.Add(i);
			}
		}
		if (pool.Count > 0)
		{
			byte type = pool.GetRandom(context.Random);
			int value = Math.Max(Math.Abs(originNeiliAllocation[type] - neiliAllocation[type]) * ChangeNeiliAllocationPercent, 1) * (base.IsDirect ? 1 : (-1));
			affectChar.ChangeNeiliAllocation(context, type, value);
			ShowSpecialEffectTipsOnceInFrame(1);
		}
		ObjectPool<List<byte>>.Instance.Return(pool);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 290 || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.CustomParam0 == 1)
		{
			return dataValue;
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return true;
	}
}
