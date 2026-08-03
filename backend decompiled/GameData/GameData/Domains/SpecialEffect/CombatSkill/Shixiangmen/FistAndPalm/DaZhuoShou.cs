using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class DaZhuoShou : CombatSkillEffectBase
{
	private const sbyte HitAvoidChangePercent = 30;

	private const sbyte PrepareProgressPercent = 50;

	private int _hitAvoidChangeAccumulator;

	public DaZhuoShou()
	{
	}

	public DaZhuoShou(CombatSkillKey skillKey)
		: base(skillKey, 6108, -1)
	{
		_hitAvoidChangeAccumulator = 0;
	}

	public override void OnEnable(DataContext context)
	{
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _hitAvoidChangeAccumulator != 0)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!interrupted && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
		{
			ushort fieldId = (ushort)(base.IsDirect ? 56 : 60);
			if (_hitAvoidChangeAccumulator == 0 && (AffectDatas == null || !AffectDatas.ContainsKey(new AffectedDataKey(base.CharacterId, fieldId, -1))))
			{
				AppendAffectedData(context, base.CharacterId, fieldId, EDataModifyType.AddPercent, -1);
			}
			if (base.IsDirect)
			{
				_hitAvoidChangeAccumulator += 30;
			}
			else
			{
				_hitAvoidChangeAccumulator -= 30;
			}
			DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		else
		{
			_hitAvoidChangeAccumulator = 0;
			ClearAffectedData(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam0 != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 56 || dataKey.FieldId == 60)
		{
			return _hitAvoidChangeAccumulator;
		}
		return 0;
	}
}
