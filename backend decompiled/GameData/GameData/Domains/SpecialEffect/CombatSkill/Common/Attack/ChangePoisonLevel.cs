using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class ChangePoisonLevel : CombatSkillEffectBase
{
	protected CombatSkillKey AffectingSkillKey;

	protected abstract sbyte AffectPoisonType { get; }

	protected bool IsMatchOwnAffect(CombatSkillKey skillKey)
	{
		return skillKey.CharId == base.CharacterId && skillKey.SkillTemplateId >= 0 && skillKey.SkillTemplateId == AffectingSkillKey.SkillTemplateId;
	}

	protected bool IsMatchPoison(short skillId)
	{
		if (skillId < 0 || !CombatSkillEquipType.IsAttack(skillId))
		{
			return false;
		}
		return DomainManager.Combat.CheckSkillPoison(skillId, AffectPoisonType);
	}

	protected ChangePoisonLevel()
	{
	}

	protected ChangePoisonLevel(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData((ushort)(base.IsDirect ? 72 : 105), EDataModifyType.Add, -1);
		AffectingSkillKey = new CombatSkillKey(-1, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
		Events.RegisterHandler_PrepareSkillBegin(PrepareSkillBegin);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(PrepareSkillBegin);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnCastSkillAllEnd(DataContext context, int charId, short skillId)
	{
		if (AffectingSkillKey.IsMatch(charId, skillId))
		{
			AffectingSkillKey = new CombatSkillKey(-1, -1);
		}
	}

	private void PrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (IsMatchPoison(skillId) && AffectingSkillKey.CharId < 0 && !(base.IsDirect ? (isAlly != base.CombatChar.IsAlly) : (isAlly == base.CombatChar.IsAlly)) && base.EffectCount > 0)
		{
			AffectingSkillKey = new CombatSkillKey(charId, skillId);
			OnAffecting(context);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (SkillKey.IsMatch(charId, key.SkillId) && key.IsDirect == base.IsDirect)
		{
			OnEffectCountChanged(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId < 0 || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 1)
		{
			return 0;
		}
		bool flag = dataKey.CustomParam0 == AffectPoisonType;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 72 || fieldId == 105) ? true : false);
			flag2 = flag3;
		}
		if (flag2 && IsMatchOwnAffect(dataKey.SkillKey))
		{
			return (dataKey.FieldId == 72) ? 1 : (-1);
		}
		if (dataKey.SkillKey == AffectingSkillKey)
		{
			return AffectingGetModifyValue(dataKey, currModifyValue);
		}
		return 0;
	}

	protected virtual void OnAffecting(DataContext context)
	{
	}

	protected virtual void OnEffectCountChanged(DataContext context)
	{
	}

	protected virtual int AffectingGetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return 0;
	}
}
