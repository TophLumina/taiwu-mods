using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class FenHuaFuLiuShi : CombatSkillEffectBase
{
	private static readonly CValuePercent HitChangeToAvoidPercent = 150;

	private bool _affected;

	public FenHuaFuLiuShi()
	{
	}

	public FenHuaFuLiuShi(CombatSkillKey skillKey)
		: base(skillKey, 2203, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 280, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affected)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId && !IsSrcSkillPerformed && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId != base.CharacterId || skillId != base.SkillTemplateId)
			{
				return;
			}
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				if (base.IsDirect)
				{
					AppendAffectedData(context, base.CharacterId, 158, EDataModifyType.Custom, -1);
				}
				else
				{
					AppendAffectedCurrEnemyData(context, 158, EDataModifyType.Custom, -1);
				}
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		else if (_affected && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 280)
		{
			return dataValue;
		}
		return true;
	}

	public unsafe override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (IsSrcSkillPerformed && dataKey.FieldId == 158 && dataKey.CustomParam0 != 3)
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId);
			if (DomainManager.Combat.InAttackRange(combatChar))
			{
				HitOrAvoidInts avoidValues = combatChar.GetCharacter().GetAvoidValues();
				int avoid = avoidValues.Items[dataKey.CustomParam0];
				if (base.IsDirect ? (dataValue <= avoid) : (dataValue > avoid))
				{
					if (!_affected)
					{
						_affected = true;
						ShowSpecialEffectTips(1);
					}
					return avoid * HitChangeToAvoidPercent;
				}
			}
		}
		return dataValue;
	}
}
