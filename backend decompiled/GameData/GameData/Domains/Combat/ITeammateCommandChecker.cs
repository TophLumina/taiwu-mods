using System.Collections.Generic;

namespace GameData.Domains.Combat;

public interface ITeammateCommandChecker
{
	IEnumerable<ETeammateCommandBanReason> Check(int index, TeammateCommandCheckerContext context);
}
