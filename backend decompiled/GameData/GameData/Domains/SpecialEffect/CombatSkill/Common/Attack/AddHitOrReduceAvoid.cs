using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddHitOrReduceAvoid : CombatSkillEffectBase
{
	private const sbyte UnitValue = 3;

	protected sbyte AffectHitType;

	private ushort _fieldId;

	protected AddHitOrReduceAvoid()
	{
	}

	protected AddHitOrReduceAvoid(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_fieldId = (ushort)((base.IsDirect ? 56 : 90) + AffectHitType);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, _fieldId, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (CharacterIdMatch(attacker.GetId()) && IsSrcSkillPerformed && pursueIndex <= 0 && attacker.NormalAttackHitType == AffectHitType && DomainManager.Combat.InAttackRange(base.IsDirect ? base.CombatChar : base.CurrEnemyChar))
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (IsSrcSkillPerformed && CharacterIdMatch(attacker.GetId()))
		{
			ReduceEffectCount();
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (CharacterIdMatch(attacker.GetId()) && IsSrcSkillPerformed && base.CombatChar.SkillHitType.Exist(AffectHitType) && DomainManager.Combat.InAttackRange(base.IsDirect ? base.CombatChar : base.CurrEnemyChar))
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (skillId == base.SkillTemplateId && charId == base.CharacterId)
			{
				if (PowerMatchAffectRequire(power))
				{
					IsSrcSkillPerformed = true;
					AddMaxEffectCount();
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else
		{
			if (Config.CombatSkill.Instance[skillId].EquipType == 1 && CharacterIdMatch(charId))
			{
				ReduceEffectCount();
			}
			if (skillId == base.SkillTemplateId && PowerMatchAffectRequire(power) && charId == base.CharacterId)
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private bool CharacterIdMatch(int charId)
	{
		return charId == (base.IsDirect ? base.CharacterId : base.CurrEnemyChar.GetId());
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsSrcSkillPerformed)
		{
			return 0;
		}
		if (dataKey.FieldId == _fieldId)
		{
			return 3 * (base.MaxEffectCount + 1 - base.EffectCount) * (base.IsDirect ? 1 : (-1));
		}
		return 0;
	}
}
