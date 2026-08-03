using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat;

public class TeammateCommandInvokerAutoDefend : TeammateCommandInvokerBase
{
	public TeammateCommandInvokerAutoDefend(int charId, int index)
		: base(charId, index)
	{
	}

	public override void Setup()
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void Close()
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (isAlly != CombatChar.IsAlly && CombatSkillEquipType.IsAttack(skillId))
		{
			IntoCombat();
		}
	}
}
