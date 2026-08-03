using System.Linq;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class MuGongZhou : CurseSilenceCombatSkill
{
	private const sbyte InterruptPreparePercent = 90;

	private const sbyte InterruptOdds = 50;

	protected override sbyte TargetEquipType => 2;

	public MuGongZhou()
	{
	}

	public MuGongZhou(CombatSkillKey skillKey)
		: base(skillKey, 7305)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
		base.OnDisable(context);
	}

	private void OnPrepareSkillProgressChange(DataContext context, int charId, bool isAlly, short skillId, sbyte preparePercent)
	{
		if (Config.CombatSkill.Instance[skillId].EquipType == 2 && preparePercent == 90 && !base.SilencingSkills.All((CombatSkillKey x) => x.CharId != charId) && context.Random.CheckPercentProb(50))
		{
			DomainManager.Combat.InterruptSkill(context, DomainManager.Combat.GetElement_CombatCharacterDict(charId));
			ShowSpecialEffectTips(2);
		}
	}

	protected override void OnSilenceBegin(DataContext context, CombatSkillKey skillKey)
	{
	}

	protected override void OnSilenceEnd(DataContext context, CombatSkillKey skillKey)
	{
	}
}
