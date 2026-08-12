using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class ShangYuGe : AgileSkillBase
{
	private const sbyte AddMindPercent = 30;

	public ShangYuGe()
	{
	}

	public ShangYuGe(CombatSkillKey skillKey)
		: base(skillKey, 8401)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		for (sbyte hitType = 0; hitType < 3; hitType++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)((base.IsDirect ? 56 : 94) + hitType), -1), EDataModifyType.Add);
		}
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender) && pursueIndex <= 0 && attacker.NormalAttackHitType != 3 && DomainManager.Combat.InAttackRange(base.CombatChar) && base.CanAffect)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender) && !CombatSkillEquipType.IsMindHitSkill(skillId) && DomainManager.Combat.InAttackRange(base.CombatChar) && base.CanAffect)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public unsafe override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (base.IsDirect)
		{
			HitOrAvoidInts hitValues = CharObj.GetHitValues();
			return hitValues.Items[3] * 30 / 100;
		}
		HitOrAvoidInts avoidValues = CharObj.GetAvoidValues();
		return avoidValues.Items[3] * 30 / 100;
	}
}
