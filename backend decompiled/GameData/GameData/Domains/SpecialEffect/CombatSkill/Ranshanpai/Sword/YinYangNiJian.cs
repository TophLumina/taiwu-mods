using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class YinYangNiJian : CombatSkillEffectBase
{
	private const sbyte AddPenetrate = 80;

	private const sbyte AddDamage = 80;

	public YinYangNiJian()
	{
	}

	public YinYangNiJian(CombatSkillKey skillKey)
		: base(skillKey, 7206, -1)
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && DomainManager.Combat.InAttackRange(base.CombatChar) && base.SkillInstance.GetCurrInnerRatio() != ((!base.IsDirect) ? 100 : 0))
		{
			OuterAndInnerInts selfPenetrate = CharObj.GetPenetrations();
			OuterAndInnerInts enemyPenetrateResist = base.CurrEnemyChar.GetCharacter().GetPenetrationResists();
			if (base.IsDirect ? (selfPenetrate.Inner < enemyPenetrateResist.Inner) : (selfPenetrate.Outer < enemyPenetrateResist.Outer))
			{
				AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 44 : 45), EDataModifyType.AddPercent, -1);
				AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, base.SkillTemplateId);
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
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 44 : 45))
		{
			return 80;
		}
		if (dataKey.FieldId == 69 && dataKey.CombatSkillId == base.SkillTemplateId && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			return 80;
		}
		return 0;
	}
}
