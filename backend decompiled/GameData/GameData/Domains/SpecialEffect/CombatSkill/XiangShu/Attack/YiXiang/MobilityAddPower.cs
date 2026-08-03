using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class MobilityAddPower : CombatSkillEffectBase
{
	protected sbyte AddPowerUnit;

	private int _addPower;

	protected MobilityAddPower()
	{
	}

	protected MobilityAddPower(CombatSkillKey skillKey, int type)
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

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_addPower = AddPowerUnit * base.CombatChar.GetMobilityValue() * 100 / MoveSpecialConstants.MaxMobility;
			if (_addPower > 0)
			{
				AppendAffectedData(context, 199, EDataModifyType.AddPercent, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				ChangeMobilityValue(context, base.CombatChar, MoveSpecialConstants.MaxMobility);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
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
