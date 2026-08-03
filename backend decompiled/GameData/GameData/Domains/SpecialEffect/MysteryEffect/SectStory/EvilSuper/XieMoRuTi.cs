using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;

public class XieMoRuTi : MysteryEffectBase
{
	private const int RequireQiDisorder = 5000;

	private const int AddCriticalOdds = 50;

	private short _affectingSkillId;

	private static CValuePercent AddProgress => 50;

	protected override short SpecialEffectId => 1782;

	private bool CanAffect => CharObj.GetDisorderOfQi() >= 5000;

	public XieMoRuTi()
	{
	}

	public XieMoRuTi(int charId, int itemId)
		: base(charId, itemId, 50114)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(341, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsAttack(skillId) && CanAffect && !base.CombatChar.GetAutoCastingSkill())
		{
			_affectingSkillId = skillId;
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * AddProgress);
			ShowSpecialEffect(0);
			ShowSpecialEffect(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == _affectingSkillId)
		{
			_affectingSkillId = -1;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 341 && _affectingSkillId >= 0 && CanAffect)
		{
			return 50;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
