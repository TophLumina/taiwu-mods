using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class FeiXingShu : CombatSkillEffectBase
{
	private const int ShaAddFlawFactor = 10;

	public FeiXingShu()
	{
	}

	public FeiXingShu(CombatSkillKey skillKey)
		: base(skillKey, 13303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(316, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillEffectNotYetCreated(OnPrepareSkillEffectNotYetCreated);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEffectNotYetCreated(OnPrepareSkillEffectNotYetCreated);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillEffectNotYetCreated(DataContext context, CombatCharacter character, short skillId)
	{
		if (character.GetId() == base.CharacterId && CombatSkillEquipType.IsAttack(skillId))
		{
			DoRearrangeTrick(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void DoRearrangeTrick(DataContext context)
	{
		CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		if (affectChar.GetTrickCount(19) > 0 && base.EffectCount > 0)
		{
			TrickCollection tricks = affectChar.GetTricks();
			tricks.RearrangeTrick(19);
			affectChar.SetTricks(tricks, context);
			Events.RaiseRearrangeTrick(context, affectChar.GetId(), affectChar.IsAlly);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.IsNormalAttack || dataKey.FieldId != 316)
		{
			return 0;
		}
		byte shaTrickCount = (base.IsDirect ? base.CombatChar : base.EnemyChar).GetTrickCount(19);
		if (shaTrickCount <= 0)
		{
			return 0;
		}
		ShowSpecialEffectTipsOnceInFrame(1);
		return shaTrickCount * 10;
	}
}
