using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class TaiYiYunFuGong : CombatSkillEffectBase
{
	private readonly sbyte[] _addAcupointCountList = new sbyte[5] { 2, 1, 1, 0, 0 };

	private readonly sbyte[] _addAcupointLevelList = new sbyte[5] { 1, 1, 0, 0, 0 };

	private int _addAcupointCount;

	private int _addAcupointLevel;

	public TaiYiYunFuGong()
	{
	}

	public TaiYiYunFuGong(CombatSkillKey skillKey)
		: base(skillKey, 4305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && index == 2 && CombatCharPowerMatchAffectRequire())
		{
			int disorderLevel = DisorderLevelOfQi.GetDisorderLevelOfQi((base.IsDirect ? CharObj : base.CurrEnemyChar.GetCharacter()).GetDisorderOfQi());
			_addAcupointCount = _addAcupointCountList[base.IsDirect ? disorderLevel : (5 - disorderLevel - 1)];
			_addAcupointLevel = _addAcupointLevelList[base.IsDirect ? disorderLevel : (5 - disorderLevel - 1)];
			if (_addAcupointCount > 0)
			{
				AppendAffectedCurrEnemyData(context, 134, EDataModifyType.Add, base.SkillTemplateId);
			}
			if (_addAcupointLevel > 0)
			{
				AppendAffectedCurrEnemyData(context, 132, EDataModifyType.Add, base.SkillTemplateId);
			}
			if (_addAcupointCount > 0 || _addAcupointLevel > 0)
			{
				ShowSpecialEffectTips(0);
			}
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
		if (dataKey.CharId != base.CurrEnemyChar.GetId() || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 134)
		{
			return _addAcupointCount;
		}
		if (dataKey.FieldId == 132)
		{
			return _addAcupointLevel;
		}
		return 0;
	}
}
