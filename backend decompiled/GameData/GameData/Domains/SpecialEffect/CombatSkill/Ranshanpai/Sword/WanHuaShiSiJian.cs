using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class WanHuaShiSiJian : CombatSkillEffectBase
{
	private const int AddPower = 20;

	private static readonly sbyte[] RequireTricks = new sbyte[3] { 3, 4, 5 };

	private CombatSkillKey _copyNotLearnSkillKey;

	private short _castingCopySkill;

	private bool _castingCopySkillNoEffect;

	public WanHuaShiSiJian()
	{
	}

	public WanHuaShiSiJian(CombatSkillKey skillKey)
		: base(skillKey, 7208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_copyNotLearnSkillKey.SkillTemplateId = -1;
		_castingCopySkill = -1;
		CreateAffectedData(209, EDataModifyType.Custom, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 279 : 283), EDataModifyType.Custom, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		ClearCopySkillData(context);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (base.CombatChar.IsAlly == isAlly || base.EffectCount <= 0 || !base.CombatChar.GetWeaponTricks().Exist((sbyte trick) => RequireTricks.Exist(trick)) || base.CombatChar.GetPreparingSkillId() >= 0 || base.CombatChar.NeedUseSkillId >= 0)
		{
			return;
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		if (skillConfig.EquipType != 1 || !skillConfig.TrickCost.Exists((NeedTrick needTrick) => RequireTricks.Exist(needTrick.TrickType)))
		{
			return;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(base.CharacterId, skillId), out var _))
		{
			List<short> learnedSkills = base.CombatChar.GetCharacter().GetLearnedCombatSkills();
			_copyNotLearnSkillKey = DomainManager.CombatSkill.CreateCombatSkill(base.CharacterId, skillId, 0).GetId();
			learnedSkills.Add(skillId);
			base.CombatChar.GetCharacter().SetLearnedCombatSkills(learnedSkills, context);
		}
		if (!DomainManager.Combat.CanCastSkill(base.CombatChar, skillId, costFree: true))
		{
			ClearCopySkillData(context);
			return;
		}
		_castingCopySkill = skillId;
		_castingCopySkillNoEffect = !CharObj.IsCombatSkillEquipped(skillId);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
		if (skillId != base.SkillTemplateId)
		{
			DomainManager.Combat.SetSkillPowerReplaceInCombat(context, new CombatSkillKey(base.CharacterId, skillId), SkillKey);
		}
		DomainManager.Combat.CastSkillFree(context, base.CombatChar, skillId);
		ShowSpecialEffectTips(1);
		ReduceEffectCount();
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.Attacker == base.CombatChar && _castingCopySkill >= 0 && index >= 3 && context.Attacker.GetAttackSkillPower() > 0 && base.CurrEnemyChar.GetPreparingSkillId() == _castingCopySkill && DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar))
		{
			base.CurrEnemyChar.SetAnimationToPlayOnce(base.CurrEnemyChar.GetBeHitAni(2), context);
			DomainManager.Combat.SetProperLoopAniAndParticle(context, base.CurrEnemyChar);
			DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, base.EffectKey, 20);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId)
		{
			bool repeatCheck = _castingCopySkill == base.SkillTemplateId;
			ClearCopySkillData(context);
			if (!repeatCheck && skillId == base.SkillTemplateId && !base.CombatChar.GetAutoCastingSkill() && PowerMatchAffectRequire(power))
			{
				AddMaxEffectCount();
			}
		}
	}

	private void ClearCopySkillData(DataContext context)
	{
		if (_copyNotLearnSkillKey.SkillTemplateId >= 0)
		{
			List<short> learnedSkills = base.CombatChar.GetCharacter().GetLearnedCombatSkills();
			learnedSkills.Remove(_copyNotLearnSkillKey.SkillTemplateId);
			base.CombatChar.GetCharacter().SetLearnedCombatSkills(learnedSkills, context);
			DomainManager.CombatSkill.RemoveCombatSkill(_copyNotLearnSkillKey.CharId, _copyNotLearnSkillKey.SkillTemplateId);
			_copyNotLearnSkillKey.SkillTemplateId = -1;
		}
		if (_castingCopySkill > 0)
		{
			if (_castingCopySkill != base.SkillTemplateId)
			{
				DomainManager.Combat.RemoveSkillPowerReplaceInCombat(context, new CombatSkillKey(base.CharacterId, _castingCopySkill));
			}
			_castingCopySkill = -1;
			_castingCopySkillNoEffect = false;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || _castingCopySkill != dataKey.CombatSkillId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209 && _castingCopySkillNoEffect)
		{
			return -1;
		}
		return dataValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		bool flag = dataKey.SkillKey != SkillKey;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 279 || fieldId == 283) ? true : false);
			flag2 = !flag3;
		}
		if (flag2)
		{
			return dataValue;
		}
		if (dataKey.CustomParam0 == 1)
		{
			ShowSpecialEffectTips(0);
		}
		return true;
	}
}
