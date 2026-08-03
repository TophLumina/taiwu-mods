using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;

public class ShaWuShe : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 75;

	private OuterAndInnerInts _injuriesBeforeAttack;

	private bool _affected;

	private bool _autoCasting;

	public ShaWuShe()
	{
	}

	public ShaWuShe(CombatSkillKey skillKey)
		: base(skillKey, 17073, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		_autoCasting = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 77, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _autoCasting)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 75 / 100);
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			(sbyte, sbyte) injuries = base.CurrEnemyChar.GetInjuries().Get(base.CombatChar.SkillAttackBodyPart);
			_injuriesBeforeAttack.Outer = injuries.Item1;
			_injuriesBeforeAttack.Inner = injuries.Item2;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted))
		{
			if (_affected)
			{
				ShowSpecialEffectTips(0);
				_affected = false;
			}
			_autoCasting = false;
			(sbyte, sbyte) currInjuries = base.CurrEnemyChar.GetInjuries().Get(base.CombatChar.SkillAttackBodyPart);
			if ((_injuriesBeforeAttack.Outer < 6 && currInjuries.Item1 >= 6) || (_injuriesBeforeAttack.Inner < 6 && currInjuries.Item2 >= 6))
			{
				_autoCasting = true;
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 77)
		{
			_affected = true;
			return true;
		}
		return dataValue;
	}
}
