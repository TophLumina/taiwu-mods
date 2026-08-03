using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.DefenseAndAssist;

public class MuJiaHuShenFa : DefenseSkillBase
{
	private const sbyte ArmorExtraGrade = 2;

	private const sbyte ReduceDamagePercent = -15;

	private const sbyte ArmorAddValue = 50;

	private bool _reduceInjuryAffected;

	private bool _armorBuffAffecting;

	public MuJiaHuShenFa()
	{
	}

	public MuJiaHuShenFa(CombatSkillKey skillKey)
		: base(skillKey, 9701)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 144 : 143), EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (defender == base.CombatChar && pursueIndex <= 0 && DomainManager.Combat.InAttackRange(attacker) && base.CanAffect)
		{
			UpdateAffecting(attacker.NormalAttackBodyPart);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_reduceInjuryAffected && defender == base.CombatChar)
		{
			_reduceInjuryAffected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_armorBuffAffecting && defender == base.CombatChar)
		{
			_armorBuffAffecting = false;
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (isAlly != base.CombatChar.IsAlly && base.CanAffect && Config.CombatSkill.Instance[skillId].EquipType == 1 && DomainManager.Combat.InAttackRange(DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly)) && DomainManager.Combat.GetCombatCharacter(base.CombatChar.IsAlly, tryGetCoverCharacter: true) == base.CombatChar)
		{
			UpdateAffecting(DomainManager.Combat.GetElement_CombatCharacterDict(charId).SkillAttackBodyPart);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_reduceInjuryAffected && context.Defender == base.CombatChar)
		{
			_reduceInjuryAffected = false;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_armorBuffAffecting && isAlly != base.CombatChar.IsAlly && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			_armorBuffAffecting = false;
		}
	}

	private void UpdateAffecting(sbyte attackBodyPart)
	{
		_armorBuffAffecting = CheckCanAffect(attackBodyPart);
		if (_armorBuffAffecting)
		{
			ShowSpecialEffectTips(1);
		}
	}

	private bool CheckCanAffect(sbyte attackBodyPart)
	{
		if (attackBodyPart < 0)
		{
			return false;
		}
		if (base.CurrEnemyChar.GetCharacter().GetConsummateLevel() <= CharObj.GetConsummateLevel())
		{
			return true;
		}
		sbyte weaponGrade = DomainManager.Combat.GetUsingWeapon(base.CurrEnemyChar).GetGrade();
		int armorGrade = -1;
		ItemKey armorKey = base.CombatChar.Armors[attackBodyPart];
		if (armorKey.IsValid())
		{
			GameData.Domains.Item.Armor armor = DomainManager.Item.GetElement_Armors(armorKey.Id);
			if (armor.GetCurrDurability() > 0)
			{
				armorGrade = armor.GetGrade();
			}
		}
		return armorGrade >= 0 && armorGrade + 2 > weaponGrade;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && base.CanAffect)
		{
			_reduceInjuryAffected = true;
			return -15;
		}
		if (dataKey.FieldId == (base.IsDirect ? 144 : 143) && _armorBuffAffecting)
		{
			return 50;
		}
		return 0;
	}
}
