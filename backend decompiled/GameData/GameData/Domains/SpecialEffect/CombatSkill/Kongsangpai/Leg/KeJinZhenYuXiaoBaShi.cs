using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class KeJinZhenYuXiaoBaShi : CombatSkillEffectBase
{
	private bool _canAffect;

	public KeJinZhenYuXiaoBaShi()
	{
	}

	public KeJinZhenYuXiaoBaShi(CombatSkillKey skillKey)
		: base(skillKey, 10303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 85, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId)
		{
			OuterAndInnerInts penetrations = base.CombatChar.GetCharacter().GetPenetrations();
			OuterAndInnerInts penetrationResists = base.CurrEnemyChar.GetCharacter().GetPenetrationResists();
			_canAffect = DomainManager.Combat.InAttackRange(base.CombatChar) && (base.IsDirect ? (penetrationResists.Outer > penetrations.Outer) : (penetrationResists.Inner > penetrations.Inner));
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (_canAffect)
			{
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 47 : 49));
				DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, (short)(base.IsDirect ? 48 : 50));
				ShowSpecialEffectTips(0);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 85)
		{
			return false;
		}
		return dataValue;
	}
}
