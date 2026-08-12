using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class HuangZhuGe : CombatSkillEffectBase
{
	private sbyte AddPower = 20;

	private int _addPower = 0;

	private short _autoCastSkillId;

	public HuangZhuGe()
	{
	}

	public HuangZhuGe(CombatSkillKey skillKey)
		: base(skillKey, 8303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_autoCastSkillId = -1;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (_addPower == 0)
		{
			if (!PowerMatchAffectRequire(power))
			{
				return;
			}
			int maxSkillGrade = (base.IsDirect ? base.CurrEnemyChar.GetTrickCount(20) : (base.CurrEnemyChar.GetDefeatMarkCollection().MindMarkList.Count / 2));
			_autoCastSkillId = DomainManager.Combat.GetRandomAttackSkill(base.CombatChar, 13, (sbyte)maxSkillGrade, context.Random, descSearch: true, -1);
			if (_autoCastSkillId >= 0)
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, _autoCastSkillId);
				ShowSpecialEffectTips(0);
				if (_autoCastSkillId == base.SkillTemplateId)
				{
					_addPower = AddPower;
					DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
					ShowSpecialEffectTips(1);
				}
			}
		}
		else
		{
			_addPower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
