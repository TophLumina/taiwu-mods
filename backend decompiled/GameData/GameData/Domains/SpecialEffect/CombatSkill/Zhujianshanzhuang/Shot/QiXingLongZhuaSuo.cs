using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class QiXingLongZhuaSuo : CombatSkillEffectBase
{
	private const sbyte AddAttackRange = 30;

	private sbyte ChangeDistance = 60;

	private int AddDamageUnit = 5;

	private int _addDamage;

	public QiXingLongZhuaSuo()
	{
	}

	public QiXingLongZhuaSuo(CombatSkillKey skillKey)
		: base(skillKey, 9403, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 145 : 146), base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && index == 2 && CombatCharPowerMatchAffectRequire())
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			short originDist = DomainManager.Combat.GetCurrentDistance();
			DomainManager.Combat.ChangeDistance(context, enemyChar, base.IsDirect ? ChangeDistance : (-ChangeDistance), isForced: true);
			ShowSpecialEffectTips(0);
			DomainManager.Combat.SetDisplayPosition(context, !base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(!base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
			if (originDist != DomainManager.Combat.GetCurrentDistance() && base.CombatChar.GetTrickCount(12) > 0)
			{
				_addDamage = (base.IsDirect ? (120 - originDist) : (originDist - 20)) * AddDamageUnit / 10;
				DomainManager.Combat.RemoveTrick(context, base.CombatChar, 12, 1);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return 30;
		}
		if (dataKey.FieldId == 69)
		{
			return _addDamage;
		}
		return 0;
	}
}
