using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class AddPowerAndRepeat : CombatSkillEffectBase
{
	private sbyte AddPowerUnit = 20;

	private sbyte RepeatTimes = 2;

	private const sbyte PrepareProgressPercent = 50;

	protected sbyte AutoCastReducePower;

	private int _autoCastIndex;

	protected AddPowerAndRepeat()
	{
	}

	protected AddPowerAndRepeat(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_autoCastIndex = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.TotalPercent);
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _autoCastIndex > 0)
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
		if (!interrupted)
		{
			DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), AddPowerUnit);
			ShowSpecialEffectTips(0);
			if (_autoCastIndex < RepeatTimes)
			{
				_autoCastIndex++;
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			else
			{
				_autoCastIndex = 0;
			}
		}
		else
		{
			_autoCastIndex = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || _autoCastIndex <= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return AutoCastReducePower;
		}
		return 0;
	}
}
