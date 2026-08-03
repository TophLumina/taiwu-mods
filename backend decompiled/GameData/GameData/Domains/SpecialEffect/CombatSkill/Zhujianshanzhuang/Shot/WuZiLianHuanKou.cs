using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class WuZiLianHuanKou : CombatSkillEffectBase
{
	private const sbyte ChangePowerUnit = 10;

	private CombatSkillKey _affectingSkill;

	public WuZiLianHuanKou()
	{
	}

	public WuZiLianHuanKou(CombatSkillKey skillKey)
		: base(skillKey, 9402, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (IsSrcSkillPerformed && Config.CombatSkill.Instance[skillId].EquipType == 1 && (base.IsDirect ? (charId == base.CharacterId) : (base.CombatChar.IsAlly != isAlly)))
		{
			_affectingSkill = new CombatSkillKey(charId, skillId);
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
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
				AddMaxEffectCount();
				if (base.IsDirect)
				{
					AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, -1);
				}
				else
				{
					AppendAffectedAllEnemyData(context, 199, EDataModifyType.AddPercent, -1);
				}
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
		else if (charId == _affectingSkill.CharId && skillId == _affectingSkill.SkillTemplateId)
		{
			ReduceEffectCount();
			_affectingSkill.CharId = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!IsSrcSkillPerformed || dataKey.CharId != _affectingSkill.CharId || dataKey.CombatSkillId != _affectingSkill.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 10 * (base.MaxEffectCount - base.EffectCount + 1) * (base.IsDirect ? 1 : (-1));
		}
		return 0;
	}
}
