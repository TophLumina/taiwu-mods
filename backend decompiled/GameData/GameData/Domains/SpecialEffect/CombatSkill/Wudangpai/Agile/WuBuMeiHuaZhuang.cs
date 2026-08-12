using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class WuBuMeiHuaZhuang : AgileSkillBase
{
	private const sbyte ChangeHitOdds = 80;

	private bool _affected;

	public WuBuMeiHuaZhuang()
	{
	}

	public WuBuMeiHuaZhuang(CombatSkillKey skillKey)
		: base(skillKey, 4400)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 74 : 107), -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && base.CombatChar == (base.IsDirect ? attacker : defender))
		{
			_affected = false;
			if (pursueIndex == 0)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && base.CombatChar == (base.IsDirect ? context.Attacker : context.Defender))
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		DamageCompareData damageCompareData = DomainManager.Combat.GetDamageCompareData();
		int index = damageCompareData.HitType.IndexOf((sbyte)dataKey.CustomParam0);
		if (index < 0)
		{
			return 0;
		}
		if (damageCompareData.HitValue[index] >= damageCompareData.AvoidValue[index])
		{
			return 0;
		}
		if (dataKey.FieldId == 74)
		{
			_affected = true;
			return 80;
		}
		if (dataKey.FieldId == 107)
		{
			_affected = true;
			return -80;
		}
		return 0;
	}
}
