using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class YuZhiShou : CombatSkillEffectBase
{
	private const sbyte ChangeDamagePercent = 30;

	private bool _affected;

	public YuZhiShou()
	{
	}

	public YuZhiShou(CombatSkillKey skillKey)
		: base(skillKey, 8101, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				if (PowerMatchAffectRequire(power))
				{
					IsSrcSkillPerformed = true;
					AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, -1);
					AppendAffectedAllEnemyData(context, 69, EDataModifyType.AddPercent, -1);
					AddMaxEffectCount();
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		else if (Config.CombatSkill.Instance[skillId].EquipType == 1 && _affected)
		{
			_affected = false;
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

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId < 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (!_affected)
			{
				_affected = true;
				ShowSpecialEffectTips(0);
			}
			return base.IsDirect ? 30 : (-30);
		}
		return 0;
	}
}
