using System.Linq;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

public class FeiShiZhanZhen : MysteryEffectBase
{
	private const int RequireTeammateCount = 3;

	protected override short SpecialEffectId => 1773;

	public FeiShiZhanZhen()
	{
	}

	public FeiShiZhanZhen(int charId, int itemId)
		: base(charId, itemId, 50105)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_TeammateCommandExecuted(OnTeammateCommandExecuted);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_TeammateCommandExecuted(OnTeammateCommandExecuted);
		base.OnDisable(context);
	}

	private void OnTeammateCommandExecuted(DataContext context, int mainCharId, int teammateId, sbyte cmdType)
	{
		if (mainCharId != base.CharacterId)
		{
			return;
		}
		int teammateCount = DomainManager.Combat.GetTeammateCharacters(base.CharacterId).Count();
		if (teammateCount < 3)
		{
			return;
		}
		TeammateCommandItem cmdConfig = TeammateCommand.Instance[cmdType];
		if (cmdConfig.Type != ETeammateCommandType.Negative)
		{
			int flawOrAcupointLevel = ((cmdConfig.Type == ETeammateCommandType.Advance) ? 1 : 0);
			if (cmdConfig.MedalType == 0)
			{
				DomainManager.Combat.AddFlaw(context, base.EnemyChar, (sbyte)flawOrAcupointLevel, CombatSkillKey.Invalid, -1);
				ShowSpecialEffect(0);
			}
			else if (cmdConfig.MedalType == 1)
			{
				DomainManager.Combat.AddAcupoint(context, base.EnemyChar, (sbyte)flawOrAcupointLevel, CombatSkillKey.Invalid, -1);
				ShowSpecialEffect(1);
			}
			else if (cmdConfig.MedalType == 2)
			{
				base.EnemyChar.AddMindMark(context, 1, -1);
				ShowSpecialEffect(2);
			}
		}
	}
}
