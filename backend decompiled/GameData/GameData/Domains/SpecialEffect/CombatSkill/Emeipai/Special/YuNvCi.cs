using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class YuNvCi : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private bool _addingPower;

	public YuNvCi()
	{
	}

	public YuNvCi(CombatSkillKey skillKey)
		: base(skillKey, 2406, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_addingPower = false;
			InvalidateCache(context, 199);
			if (PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
			{
				AddMaxEffectCount();
			}
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && base.EffectCount > 0 && base.CombatChar.GetPreparingSkillId() < 0 && (base.IsDirect ? attacker : defender) == base.CombatChar)
		{
			sbyte[] weaponTricks = base.CombatChar.GetWeaponTricks();
			DomainManager.Combat.AddTrick(context, base.CombatChar, weaponTricks[context.Random.Next(0, weaponTricks.Length)]);
			ShowSpecialEffectTips(0);
			if ((base.IsDirect ? hit : (!hit)) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				_addingPower = true;
				InvalidateCache(context, 199);
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			ReduceEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && _addingPower)
		{
			return 40;
		}
		return 0;
	}
}
