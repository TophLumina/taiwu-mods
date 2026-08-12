using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class JiuXingJinGuangZhou : CombatSkillEffectBase
{
	private const sbyte InfectedReduceHealth = -36;

	private const int DirectSilenceFrameAddPercent = 80;

	private const int ReverseSilenceFrameAddPercent = -40;

	private short _performingSkillId = -1;

	private int _performingSkillPower;

	private static bool IsCurse(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].SubType == ECombatSkillSubType.Curse;
	}

	public JiuXingJinGuangZhou()
	{
	}

	public JiuXingJinGuangZhou(CombatSkillKey skillKey)
		: base(skillKey, 7307, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedAllEnemyData(288, EDataModifyType.Custom, -1);
		if (base.IsDirect)
		{
			CreateAffectedAllEnemyData(264, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedData(264, EDataModifyType.AddPercent, -1);
		}
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if ((base.IsDirect ? (dataKey.CharId == base.CharacterId) : (!IsCurse(dataKey.CombatSkillId))) || _performingSkillId < 0 || !PowerMatchAffectRequire(_performingSkillPower, 1) || dataKey.FieldId != 264)
		{
			return 0;
		}
		ShowSpecialEffectTipsOnceInFrame(2);
		return base.IsDirect ? 80 : (-40);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (_performingSkillId < 0 || dataKey.CombatSkillId != _performingSkillId || dataKey.FieldId != 288)
		{
			return dataValue;
		}
		ShowSpecialEffectTipsOnceInFrame(1);
		return true;
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && _performingSkillId < 0 && base.EffectCount > 0 && IsCurse(skillId))
		{
			_performingSkillId = skillId;
			ReduceEffectCount();
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.AttackerId == base.CharacterId && context.SkillTemplateId == _performingSkillId && index >= 3)
		{
			_performingSkillPower = context.Attacker.GetAttackSkillPower();
		}
	}

	private void OnCastSkillAllEnd(DataContext context, int charId, short skillId)
	{
		if (charId == base.CharacterId && skillId == _performingSkillId)
		{
			_performingSkillId = -1;
			_performingSkillPower = 0;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			DoReduceHealth(context);
			AddMaxEffectCount();
		}
	}

	private void DoReduceHealth(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		if (!enemyChar.HasInfectedFeature(ECharacterFeatureInfectedType.NotInfected) && !enemyChar.CheckHealthImmunity(context))
		{
			enemyChar.GetCharacter().ChangeHealth(context, -36);
			ShowSpecialEffectTips(0);
		}
	}
}
