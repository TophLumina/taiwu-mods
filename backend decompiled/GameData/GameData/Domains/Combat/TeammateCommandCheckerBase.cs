using System.Collections.Generic;

namespace GameData.Domains.Combat;

public abstract class TeammateCommandCheckerBase : ITeammateCommandChecker
{
	protected virtual bool CheckTeammateBoth => false;

	protected virtual bool CheckTeammateBefore => CheckTeammateBoth;

	protected virtual bool CheckTeammateAfter => CheckTeammateBoth;

	public virtual IEnumerable<ETeammateCommandBanReason> Check(int index, TeammateCommandCheckerContext context)
	{
		if (context.CdData[index].On)
		{
			yield return ETeammateCommandBanReason.CommonCd;
		}
		if (!DomainManager.Combat.IsMainCharacter(context.CurrChar))
		{
			yield return ETeammateCommandBanReason.CommonNotMain;
		}
		if (DomainManager.Combat.IsCharacterFallen(context.TeammateChar))
		{
			yield return ETeammateCommandBanReason.CommonFallen;
		}
		if (context.TeammateChar.StopCommandEffectCount != 0)
		{
			yield return ETeammateCommandBanReason.CommonStop;
		}
		else if (!DomainManager.SpecialEffect.ModifyData(context.TeammateChar.GetId(), -1, 270, dataValue: true))
		{
			yield return ETeammateCommandBanReason.CommonStop;
		}
		if (context.CurrChar.ChangeCharId >= 0)
		{
			yield return ETeammateCommandBanReason.CommonConflict;
		}
		else if (context.TeammateChar.GetExecutingTeammateCommand() >= 0)
		{
			yield return ETeammateCommandBanReason.CommonConflict;
		}
		else if (CheckTeammateBefore && context.HasTeammateBefore)
		{
			yield return ETeammateCommandBanReason.CommonConflict;
		}
		else if (CheckTeammateAfter && context.HasTeammateAfter)
		{
			yield return ETeammateCommandBanReason.CommonConflict;
		}
		foreach (ETeammateCommandBanReason item in Extra(context))
		{
			yield return item;
		}
	}

	protected abstract IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context);
}
