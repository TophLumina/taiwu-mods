using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class DaGuangMingShanYiYuanZhi : PowerUpOnCast
{
	private static readonly CValuePercent AddPower = 60;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public DaGuangMingShanYiYuanZhi()
	{
	}

	public DaGuangMingShanYiYuanZhi(CombatSkillKey skillKey)
		: base(skillKey, 2206)
	{
	}

	public override void OnEnable(DataContext context)
	{
		PowerUpValue = (base.IsDirect ? (CharObj.GetFame() * AddPower) : (-CharObj.GetFame() * AddPower));
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		base.OnDisable(context);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			sbyte selfFame = CharObj.GetFame();
			sbyte enemyFame = base.CurrEnemyChar.GetCharacter().GetFame();
			if (base.IsDirect ? (selfFame >= enemyFame) : (selfFame <= enemyFame))
			{
				AppendAffectedData(context, base.CharacterId, 251, EDataModifyType.Custom, base.SkillTemplateId);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 251)
		{
			return true;
		}
		return dataValue;
	}
}
