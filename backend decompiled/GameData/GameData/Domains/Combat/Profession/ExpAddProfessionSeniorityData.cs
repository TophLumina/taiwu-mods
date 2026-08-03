using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Taiwu.Profession;

namespace GameData.Domains.Combat.Profession;

public struct ExpAddProfessionSeniorityData(int professionId, int formulaId, sbyte requireCombatType = -1, bool requireIntelligent = false, sbyte requireOrganization = -1)
{
	public static readonly List<ExpAddProfessionSeniorityData> AllData = new List<ExpAddProfessionSeniorityData>
	{
		new ExpAddProfessionSeniorityData(3, 23, 0, requireIntelligent: true, -1),
		new ExpAddProfessionSeniorityData(3, 24, 1, requireIntelligent: true, -1),
		new ExpAddProfessionSeniorityData(3, 25, -1, requireIntelligent: false, 17),
		new ExpAddProfessionSeniorityData(3, 25, -1, requireIntelligent: false, 18),
		new ExpAddProfessionSeniorityData(5, 41, -1, requireIntelligent: false, 19)
	};

	public int ProfessionId = professionId;

	public int FormulaId = formulaId;

	public sbyte RequireCombatType = requireCombatType;

	public bool RequireIntelligent = requireIntelligent;

	public sbyte RequireOrganization = requireOrganization;

	public void DoAddSeniority(DataContext context, int exp)
	{
		int addSeniority = ProfessionFormulaImpl.Calculate(FormulaId, exp);
		DomainManager.Extra.ChangeProfessionSeniority(context, ProfessionId, addSeniority);
	}
}
