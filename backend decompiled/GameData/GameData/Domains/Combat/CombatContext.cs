using System.Diagnostics.CodeAnalysis;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

public readonly struct CombatContext
{
	public DataContext Context { get; private init; }

	public CombatCharacter Attacker { get; private init; }

	public CombatCharacter Defender { get; private init; }

	public int BounceSourceId { get; init; }

	private bool IsBounce { get; init; }

	private sbyte SpecifyBodyPart { get; init; }

	private short SpecifySkillId { get; init; }

	private int SpecifyWeaponIndex { get; init; }

	private CombatProperty? SpecifyProperty { get; init; }

	private ECombatCriticalType CriticalType { get; init; }

	public IRandomSource Random => Context.Random;

	public int AttackerId => Attacker.GetId();

	public int DefenderId => Defender.GetId();

	public sbyte BodyPart => (SpecifyBodyPart >= 0) ? SpecifyBodyPart : (IsNormalAttack ? Attacker.NormalAttackBodyPart : Attacker.SkillAttackBodyPart);

	public sbyte InnerRatio => IsNormalAttack ? WeaponData.GetInnerRatio() : Skill.GetCurrInnerRatio();

	public sbyte OuterRatio => (sbyte)(100 - InnerRatio);

	public bool IsNormalAttack => SkillTemplateId < 0;

	public bool IsFightBack => IsNormalAttack && Attacker.GetIsFightBack();

	private static ItemDomain ItemDomain => DomainManager.Item;

	private static CombatDomain CombatDomain => DomainManager.Combat;

	private static CombatSkillDomain CombatSkillDomain => DomainManager.CombatSkill;

	public short SkillTemplateId => (SpecifySkillId >= 0) ? SpecifySkillId : Attacker.GetPerformingSkillId();

	public CombatSkillKey SkillKey => new CombatSkillKey(Attacker.GetId(), SkillTemplateId);

	public GameData.Domains.CombatSkill.CombatSkill Skill
	{
		get
		{
			GameData.Domains.CombatSkill.CombatSkill skill;
			return CombatSkillDomain.TryGetElement_CombatSkills(SkillKey, out skill) ? skill : null;
		}
	}

	public CombatSkillData SkillData
	{
		get
		{
			CombatSkillData data;
			return CombatDomain.TryGetCombatSkillData(Attacker.GetId(), SkillTemplateId, out data) ? data : null;
		}
	}

	public CombatSkillItem SkillConfig => Config.CombatSkill.Instance[SkillTemplateId];

	public ItemKey WeaponKey => (SpecifyWeaponIndex >= 0) ? Attacker.GetWeapons()[SpecifyWeaponIndex] : CombatDomain.GetUsingWeaponKey(Attacker);

	public GameData.Domains.Item.Weapon Weapon => ItemDomain.GetElement_Weapons(WeaponKey.Id);

	public CombatWeaponData WeaponData => CombatDomain.GetElement_WeaponDataDict(WeaponKey.Id);

	public WeaponItem WeaponConfig => Config.Weapon.Instance[WeaponKey.TemplateId];

	public sbyte WeaponPointCost => WeaponConfig.AttackPreparePointCost;

	public int WeaponAttack => SpecifyProperty?.WeaponAttack ?? CombatDomain.CalcWeaponAttack(Attacker, Weapon, SkillTemplateId);

	public int WeaponDefend => SpecifyProperty?.WeaponDefend ?? CombatDomain.CalcWeaponDefend(Attacker, Weapon, SkillTemplateId);

	public ItemKey ArmorKey => (BodyPart >= 0) ? Defender.Armors[BodyPart] : ItemKey.Invalid;

	public GameData.Domains.Item.Armor Armor => ArmorKey.IsValid() ? ItemDomain.GetElement_Armors(ArmorKey.Id) : null;

	public int ArmorAttack => SpecifyProperty?.ArmorAttack ?? CombatDomain.CalcArmorAttack(Defender, Armor);

	public int ArmorDefend => SpecifyProperty?.ArmorDefend ?? CombatDomain.CalcArmorDefend(Defender, Armor);

	public ItemKey WeaponOrShoesKey => Attacker.SkillUseLegAsWeapon(SkillTemplateId) ? Attacker.Armors[5] : WeaponKey;

	public EquipmentBase WeaponOrShoes => ItemDomain.TryGetBaseEquipment(WeaponOrShoesKey);

	public int OuterStep => (BodyPart < 0) ? (-1) : DamageStepCollection.OuterDamageSteps[BodyPart];

	public int InnerStep => (BodyPart < 0) ? (-1) : DamageStepCollection.InnerDamageSteps[BodyPart];

	public int OuterOrigin => (BodyPart >= 0) ? Defender.GetOuterDamageValue()[BodyPart] : 0;

	public int InnerOrigin => (BodyPart >= 0) ? Defender.GetInnerDamageValue()[BodyPart] : 0;

	public EDataSumType OuterSumType => DataSumTypeHelper.CalcSumType(CalcDamageCanAdd(inner: false), CalcDamageCanReduce(inner: false));

	public EDataSumType InnerSumType => DataSumTypeHelper.CalcSumType(CalcDamageCanAdd(inner: true), CalcDamageCanReduce(inner: true));

	public int ExtraFlawCount => DomainManager.SpecialEffect.GetModifyValue(Attacker.GetId(), SkillTemplateId, 84, EDataModifyType.Add, BodyPart);

	public EDamageType OuterDamageType => (EDamageType)DomainManager.SpecialEffect.ModifyData(Attacker.GetId(), SkillTemplateId, 79, (int)DamageType, 0);

	public EDamageType InnerDamageType => (EDamageType)DomainManager.SpecialEffect.ModifyData(Attacker.GetId(), SkillTemplateId, 79, (int)DamageType, 1);

	private bool AllChangeToOld => Attacker.IsUnlockAttack && Attacker.UnlockEffect.ChangeToOld;

	public bool OuterInjuryChangeToOld => DomainManager.SpecialEffect.ModifyData(AttackerId, SkillTemplateId, 77, dataValue: false, 0, BodyPart) || AllChangeToOld;

	public bool InnerInjuryChangeToOld => DomainManager.SpecialEffect.ModifyData(AttackerId, SkillTemplateId, 77, dataValue: false, 1, BodyPart) || AllChangeToOld;

	public bool IsGodWeapon => DomainManager.SpecialEffect.ModifyData(Attacker.GetId(), -1, 181, dataValue: false, WeaponOrShoesKey.Id);

	public bool IsGodArmor => DomainManager.SpecialEffect.ModifyData(Defender.GetId(), -1, 182, dataValue: false, ArmorKey.Id);

	public DamageStepCollection DamageStepCollection => Defender.GetDamageStepCollection();

	public EDamageType DamageType => IsBounce ? EDamageType.Bounce : ((!IsFightBack) ? EDamageType.Direct : EDamageType.FightBack);

	public bool UseSkillAttackOdds => !IsNormalAttack || Attacker.IsAnimal;

	public CFormula.EAttackType AttackType
	{
		get
		{
			if (Attacker.IsUnlockAttack)
			{
				return CFormula.EAttackType.Unlock;
			}
			if (Attacker.IsAutoNormalAttackingSpecial)
			{
				return CFormula.EAttackType.Spirit;
			}
			if (UseSkillAttackOdds)
			{
				return (BodyPart < 0) ? CFormula.EAttackType.MindSkill : CFormula.EAttackType.Skill;
			}
			return CFormula.EAttackType.Normal;
		}
	}

	public int BaseDamage => CFormula.CalcBaseDamageValue(AttackType, WeaponPointCost);

	public int AttackOdds
	{
		get
		{
			int odds = CFormula.CalcBaseAttackOdds(AttackType);
			if (IsNormalAttack)
			{
				return odds;
			}
			if (Attacker.GetCharacter().GetFeatureIds().Contains(906))
			{
				odds /= 2;
			}
			return odds;
		}
	}

	public CValuePercentBonus FlawBonus
	{
		get
		{
			int bonus = (int)CFormula.CalcFlawDamageBonus(Defender.GetFlawCount()[BodyPart], ExtraFlawCount);
			if (bonus > 0)
			{
				bonus *= DomainManager.SpecialEffect.GetModify(AttackerId, SkillTemplateId, 316, BodyPart);
			}
			return bonus;
		}
	}

	public CValuePercentBonus ConsummateBonus => CFormulaHelper.CalcConsummateChangeDamagePercent(Attacker, Defender);

	public static CombatContext Create([DisallowNull] CombatCharacter attacker, [AllowNull] CombatCharacter defender = null, sbyte specifyBodyPart = -1, short specifySkillId = -1, int specifyWeaponIndex = -1, CombatProperty? combatProperty = null)
	{
		return new CombatContext
		{
			Context = attacker.GetDataContext(),
			Attacker = attacker,
			Defender = (defender ?? CombatDomain.GetCombatCharacter(!attacker.IsAlly, tryGetCoverCharacter: true)),
			BounceSourceId = -1,
			SpecifyProperty = combatProperty,
			SpecifyBodyPart = specifyBodyPart,
			SpecifySkillId = specifySkillId,
			SpecifyWeaponIndex = specifyWeaponIndex,
			IsBounce = false,
			CriticalType = ECombatCriticalType.Uncheck
		};
	}

	public CombatContext(CombatContext context)
	{
		Context = context.Context;
		Attacker = context.Attacker;
		Defender = context.Defender;
		BounceSourceId = context.BounceSourceId;
		SpecifyProperty = context.SpecifyProperty;
		SpecifyBodyPart = context.SpecifyBodyPart;
		SpecifySkillId = context.SpecifySkillId;
		SpecifyWeaponIndex = context.SpecifyWeaponIndex;
		IsBounce = context.IsBounce;
		CriticalType = context.CriticalType;
	}

	public CombatContext Bounce()
	{
		if (IsBounce)
		{
			PredefinedLog.Show(8, "Unable to bounce a bounce");
		}
		return new CombatContext(this)
		{
			Defender = Attacker,
			IsBounce = true,
			BounceSourceId = DefenderId,
			SpecifyProperty = null,
			CriticalType = ECombatCriticalType.Uncheck
		};
	}

	public CombatContext Property(CombatProperty property)
	{
		return new CombatContext(this)
		{
			SpecifyProperty = property
		};
	}

	public CombatContext Critical(bool critical)
	{
		return new CombatContext(this)
		{
			CriticalType = (critical ? ECombatCriticalType.Critical : ECombatCriticalType.NoCritical)
		};
	}

	public static implicit operator DataContext(CombatContext context)
	{
		return context.Context;
	}

	private bool CalcDamageCanAdd(bool inner)
	{
		if (IsGodArmor && !IsGodWeapon)
		{
			return false;
		}
		return DomainManager.SpecialEffect.ModifyData(DefenderId, SkillTemplateId, 324, dataValue: true, inner ? 1 : 0, BodyPart, (int)DamageType);
	}

	private bool CalcDamageCanReduce(bool inner)
	{
		if (IsGodWeapon && !IsGodArmor)
		{
			return false;
		}
		return DomainManager.SpecialEffect.ModifyData(AttackerId, SkillTemplateId, 325, dataValue: true, inner ? 1 : 0, BodyPart, (int)DamageType);
	}

	public CombatProperty CalcProperty(sbyte hitType = -1)
	{
		if (SpecifyProperty.HasValue)
		{
			return SpecifyProperty.Value;
		}
		Tester.Assert(hitType >= 0);
		return CombatProperty.Create(this, hitType);
	}

	public OuterAndInnerInts CalcMixedDamage(sbyte hitType, CValuePercent power)
	{
		int damage = BaseDamage * FlawBonus * power;
		CombatProperty property = CalcProperty(hitType);
		return CFormula.FormulaCalcMixedDamageValue(damage, AttackOdds, InnerRatio, property.AttackValue, property.DefendValue);
	}

	public bool CheckCritical(sbyte hitType)
	{
		if (CriticalType != ECombatCriticalType.Uncheck)
		{
			return CriticalType == ECombatCriticalType.Critical;
		}
		if (BodyPart < 0)
		{
			return false;
		}
		int hitOdds = CalcProperty(hitType).HitOdds;
		if (!DomainManager.SpecialEffect.ModifyData(DefenderId, SkillTemplateId, 234, dataValue: true, BodyPart, hitType, AttackerId))
		{
			return false;
		}
		if (Attacker.IsBreakAttacking || DomainManager.SpecialEffect.ModifyData(AttackerId, SkillTemplateId, 248, dataValue: false, hitType))
		{
			return true;
		}
		int criticalOdds = CFormula.FormulaCalcCriticalOdds(hitOdds);
		CValueModify modify = CValueModify.Zero;
		modify += DomainManager.SpecialEffect.GetModify(AttackerId, 341);
		modify += DomainManager.SpecialEffect.GetModify(DefenderId, 342);
		criticalOdds *= modify;
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(AttackerId, out var combatChar) && combatChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.Attack)
		{
			criticalOdds *= (CValuePercentBonus)combatChar.ExecutingTeammateCommandConfig.IntArg;
		}
		return Random.CheckPercentProb(criticalOdds);
	}

	public CValuePercentBonus CalcCriticalBonus(sbyte hitType)
	{
		int bonus = CFormula.FormulaCalcCriticalPercent(CalcProperty(hitType).HitOdds);
		return DomainManager.SpecialEffect.ModifyValue(AttackerId, 339, bonus);
	}

	public void ApplyWeaponAndArmorPoison(int valueMultiplier = 1, bool ignorePositiveResist = false)
	{
		sbyte bodyPart = BodyPart;
		if ((bodyPart >= 0 && bodyPart < 7) || 1 == 0)
		{
			DomainManager.Combat.ApplyEquipmentPoison(this, Attacker, Defender, WeaponOrShoesKey, valueMultiplier, ignorePositiveResist);
			DomainManager.Combat.ApplyEquipmentPoison(this, Defender, Attacker, ArmorKey, valueMultiplier, ignorePositiveResist);
		}
	}

	public void CheckReduceDurability(sbyte breakOdds)
	{
		bool ignoreArmor = DomainManager.SpecialEffect.ModifyData(AttackerId, SkillTemplateId, 280, dataValue: false);
		if (BodyPart < 0 || breakOdds == 0 || ignoreArmor)
		{
			Attacker.NeedReduceWeaponDurability = 0;
			Defender.NeedReduceArmorDurability = 0;
		}
		else
		{
			CheckReduceWeaponDurability(breakOdds);
			CheckReduceArmorDurability(breakOdds);
		}
	}

	public void CheckReduceWeaponDurability(sbyte breakOdds)
	{
		if (breakOdds <= 0)
		{
			return;
		}
		short currDurability = WeaponOrShoes?.GetCurrDurability() ?? 0;
		if (currDurability > 0 && (!IsGodWeapon || !IsNormalAttack) && CombatDomain.IsWeaponCanBreak(Weapon.GetItemSubType()))
		{
			int reduceDurability = 0;
			if (ArmorAttack > WeaponDefend)
			{
				reduceDurability += (Random.CheckPercentProb(breakOdds) ? 1 : 0);
			}
			Attacker.NeedReduceWeaponDurability = DomainManager.SpecialEffect.ModifyValue(DefenderId, SkillTemplateId, 337, reduceDurability, ArmorKey.Id);
		}
	}

	public void CheckReduceArmorDurability(sbyte breakOdds)
	{
		if (breakOdds <= 0)
		{
			return;
		}
		short currDurability = Armor?.GetCurrDurability() ?? 0;
		if (currDurability > 0 && (!IsGodArmor || !IsNormalAttack))
		{
			int reduceDurability = 0;
			if (WeaponAttack > ArmorDefend)
			{
				reduceDurability += (Random.CheckPercentProb(breakOdds) ? 1 : 0);
			}
			Defender.NeedReduceArmorDurability = DomainManager.SpecialEffect.ModifyValue(AttackerId, SkillTemplateId, 337, reduceDurability, WeaponOrShoesKey.Id);
		}
	}

	public void ApplyReduceDurabilityByHit()
	{
		if (Attacker.NeedReduceWeaponDurability > 0)
		{
			DomainManager.Combat.ChangeDurability(this, Attacker, WeaponOrShoesKey, -Attacker.NeedReduceWeaponDurability, EChangeDurabilitySourceType.Hit);
			Attacker.NeedReduceWeaponDurability = 0;
		}
		if (Defender.NeedReduceArmorDurability > 0)
		{
			DomainManager.Combat.ChangeDurability(this, Defender, ArmorKey, -Defender.NeedReduceArmorDurability, EChangeDurabilitySourceType.Hit);
			Defender.NeedReduceArmorDurability = 0;
		}
	}

	public void ApplyInjury(bool inner, int count)
	{
		if (inner ? InnerInjuryChangeToOld : OuterInjuryChangeToOld)
		{
			Defender.AddInjury(this, BodyPart, inner, count, updateDefeatMark: false, changeToOld: true);
			return;
		}
		int changeToOldOdds = DomainManager.SpecialEffect.ModifyValue(AttackerId, (ushort)335, 0, inner ? 1 : 0, -1, -1, 0, 0, 0, 0);
		for (int i = 0; i < count; i++)
		{
			bool changeToOld = Random.CheckPercentProb(changeToOldOdds);
			Defender.AddInjury(this, BodyPart, inner, 1, updateDefeatMark: false, changeToOld);
		}
	}

	public void ApplyMind(int count)
	{
		int changeToInfiniteOdds = DomainManager.SpecialEffect.ModifyValue(AttackerId, 336, 0);
		for (int i = 0; i < count; i++)
		{
			bool changeToInfinite = Random.CheckPercentProb(changeToInfiniteOdds);
			Defender.AddMindMark(this, 1, SkillTemplateId, changeToInfinite);
		}
	}
}
