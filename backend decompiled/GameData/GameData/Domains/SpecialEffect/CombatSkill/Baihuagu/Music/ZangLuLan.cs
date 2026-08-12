using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class ZangLuLan : CombatSkillEffectBase
{
	private int _addPower;

	private int AddPowerUnit => base.IsDirect ? 10 : 5;

	private int CostBase => base.IsDirect ? 12 : 6;

	private int CostUnit => base.IsDirect ? 4 : 2;

	private int CurrentUnitCount => base.IsDirect ? (base.CombatChar.GetTrickCount(20) + base.EnemyChar.GetTrickCount(20)) : (base.CombatChar.GetDefeatMarkCollection().MindMarkList.Count + base.EnemyChar.GetDefeatMarkCollection().MindMarkList.Count);

	public ZangLuLan()
	{
	}

	public ZangLuLan(CombatSkillKey skillKey)
		: base(skillKey, 3305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = AddPowerUnit * CurrentUnitCount;
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				DoAffect(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		int costValue = CostBase + CostUnit * CurrentUnitCount;
		CValuePercent costPercent = costValue;
		CombatCharacter enemyChar = base.EnemyChar;
		ChangeBreathValue(context, enemyChar, -enemyChar.GetMaxBreathValue() * costPercent);
		ChangeStanceValue(context, enemyChar, -enemyChar.GetMaxStanceValue() * costPercent);
		ChangeMobilityValue(context, enemyChar, -enemyChar.GetMaxMobility() * costPercent);
		for (byte i = 0; i < 4; i++)
		{
			enemyChar.ChangeNeiliAllocation(context, i, -costValue);
		}
		ShowSpecialEffectTips(1);
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
