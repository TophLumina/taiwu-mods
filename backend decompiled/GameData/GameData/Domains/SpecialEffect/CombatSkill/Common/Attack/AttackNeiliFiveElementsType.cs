using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AttackNeiliFiveElementsType : CombatSkillEffectBase
{
	private const sbyte DirectClearEffect = 3;

	private const sbyte ReverseAddDamagePercent = 90;

	protected sbyte AffectFiveElementsType;

	private bool _reverseTipsShowed;

	protected AttackNeiliFiveElementsType()
	{
	}

	protected AttackNeiliFiveElementsType(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private bool NeiliTypeMismatchAffectType(sbyte neiliType)
	{
		byte neiliFiveElements = NeiliType.Instance[neiliType].FiveElements;
		return neiliFiveElements != AffectFiveElementsType && neiliFiveElements != FiveElementsType.Countering[AffectFiveElementsType];
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (!SkillKey.IsMatch(charId, skillId))
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
		if (NeiliTypeMismatchAffectType(enemyChar.GetNeiliType()) || !DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			RemoveSelf(context);
		}
		else if (base.IsDirect)
		{
			Dictionary<SkillEffectKey, short> skillEffectDict = enemyChar.GetSkillEffectCollection().EffectDict;
			if (skillEffectDict != null && skillEffectDict.Count > 0)
			{
				List<SkillEffectKey> effectKeys = new List<SkillEffectKey>();
				int removeCount = Math.Min(skillEffectDict.Count, 3);
				effectKeys.AddRange(skillEffectDict.Keys);
				for (int i = 0; i < removeCount; i++)
				{
					SkillEffectKey key = effectKeys[context.Random.Next(0, effectKeys.Count)];
					effectKeys.Remove(key);
					DomainManager.Combat.ChangeSkillEffectCount(context, enemyChar, key, (short)(-skillEffectDict[key]));
				}
			}
			ClearAffectingAgileSkill(context, enemyChar);
			DomainManager.Combat.ClearAffectingDefenseSkill(context, enemyChar);
			ShowSpecialEffectTips(0);
		}
		else
		{
			AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 69 && dataKey.CombatSkillId == base.SkillTemplateId && CombatCharPowerMatchAffectRequire())
		{
			if (!_reverseTipsShowed)
			{
				ShowSpecialEffectTips(0);
				_reverseTipsShowed = true;
			}
			return 90;
		}
		return 0;
	}
}
