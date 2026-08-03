using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class QingPingDiao : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private const int ExtraCount = 3;

	private bool _prevMatchAffect;

	public QingPingDiao()
	{
	}

	public QingPingDiao(CombatSkillKey skillKey)
		: base(skillKey, 8301, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_prevMatchAffect = (base.IsDirect ? base.CurrEnemyChar.GetTrickCount(20) : base.CurrEnemyChar.GetDefeatMarkCollection().MindMarkList.Count) == 0;
		if (_prevMatchAffect)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (SkillKey != context.SkillKey || index != 3)
		{
			return;
		}
		if (CombatCharPowerMatchAffectRequire())
		{
			int addCount = ((!_prevMatchAffect) ? 1 : 4);
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, base.CurrEnemyChar, 20, addCount, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, base.CurrEnemyChar, addCount);
			}
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 40;
		}
		return 0;
	}
}
