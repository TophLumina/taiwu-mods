using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class JieQingAnShouKuaiJian : CombatSkillEffectBase
{
	private const int AddShaCount = 4;

	private const sbyte NeedTrickCountPerGrade = 2;

	private const sbyte MaxSkillGrade = 2;

	private static readonly CValuePercent ProgressPercent = 50;

	private bool _canCastFree;

	private bool _castFree;

	private short _autoCastSkillId;

	public JieQingAnShouKuaiJian()
	{
	}

	public JieQingAnShouKuaiJian(CombatSkillKey skillKey)
		: base(skillKey, 13203, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_canCastFree = true;
		_autoCastSkillId = -1;
		CreateAffectedData(154, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId) && _canCastFree)
		{
			_castFree = true;
		}
		if (charId == base.CharacterId && CombatSkillEquipType.IsAttack(skillId) && _canCastFree)
		{
			DisableCanCastFree(context);
		}
		if (charId == base.CharacterId && skillId == _autoCastSkillId)
		{
			_autoCastSkillId = -1;
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * ProgressPercent);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			TryAutoCast(context, power);
			if (_castFree)
			{
				_castFree = false;
				DomainManager.Combat.AddTrick(context, base.IsDirect ? base.CombatChar : base.EnemyChar, 19, 4, base.IsDirect);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void TryAutoCast(DataContext context, sbyte power)
	{
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter trickChar = (base.IsDirect ? base.CombatChar : base.EnemyChar);
			int trickCount = trickChar.GetTrickCount(19);
			int maxSkillGrade = Math.Min(trickCount / 2, 2);
			_autoCastSkillId = DomainManager.Combat.GetRandomAttackSkill(base.CombatChar, 7, (sbyte)maxSkillGrade, context.Random, descSearch: true, -1);
			if (_autoCastSkillId >= 0)
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, _autoCastSkillId);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void DisableCanCastFree(DataContext context)
	{
		_canCastFree = false;
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 154)
		{
			return !_canCastFree && dataValue;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
