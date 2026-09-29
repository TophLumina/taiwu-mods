using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DLC;
using GameData.Domains.Taiwu.Profession;

namespace GameData.Domains.Combat.Profession;

public struct ExpAddProfessionSeniorityData
{
	public static readonly List<ExpAddProfessionSeniorityData> AllData = new List<ExpAddProfessionSeniorityData>
	{
		new ExpAddProfessionSeniorityData(3, 23, 0, requireIntelligent: true, -1),
		new ExpAddProfessionSeniorityData(3, 24, 1, requireIntelligent: true, -1),
		new ExpAddProfessionSeniorityData(3, 25, -1, requireIntelligent: false, 17),
		new ExpAddProfessionSeniorityData(3, 25, -1, requireIntelligent: false, 18),
		new ExpAddProfessionSeniorityData(5, 41, -1, requireIntelligent: false, 19),
		new ExpAddProfessionSeniorityData(18, 114, -1, requireIntelligent: false, 19, requireConsummateLevel: false, CheckAddSeniorityXiangshu1)
	};

	public int ProfessionId;

	public int FormulaId;

	public sbyte RequireCombatType;

	public bool RequireIntelligent;

	public sbyte RequireOrganization;

	public bool RequireConsummateLevel;

	public Func<bool> ExtraChecker;

	private static bool CheckAddSeniorityXiangshu1()
	{
		bool xiangshuEntered = DomainManager.Story.GetTaiwuAsXiangshuEntered();
		return DlcManager.IsDlcInstalled(5093790uL) && xiangshuEntered;
	}

	public ExpAddProfessionSeniorityData(int professionId, int formulaId, sbyte requireCombatType = -1, bool requireIntelligent = false, sbyte requireOrganization = -1, bool requireConsummateLevel = true, Func<bool> extraChecker = null)
	{
		ProfessionId = professionId;
		FormulaId = formulaId;
		RequireCombatType = requireCombatType;
		RequireIntelligent = requireIntelligent;
		RequireOrganization = requireOrganization;
		RequireConsummateLevel = requireConsummateLevel;
		ExtraChecker = extraChecker;
	}

	public void DoAddSeniority(DataContext context, int exp)
	{
		int addSeniority = ProfessionFormulaImpl.Calculate(FormulaId, exp);
		DomainManager.Extra.ChangeProfessionSeniority(context, ProfessionId, addSeniority);
	}
}
