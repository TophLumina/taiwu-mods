using GameData.Domains.Character.Ai;
using GameData.Domains.Item;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthSelfImprovementModification
{
	public readonly Character Character;

	public (short combatSkillTemplateId, short neili, short qiDisorder) LoopingNeigong;

	public bool ConsummateLevelChanged;

	public int ConsummateLevelProgress;

	public bool ResourcesChanged;

	public bool ExtraNeiliChanged;

	public (sbyte skillType, bool isCombatSkill, EQualificationImproveSources sources, int mentor)? ImprovedSkillQualification;

	public (SkillBook readingBook, int learnedSkillIndex, byte page, sbyte succeedPageCount) ReadingResult;

	public int[] ExtraNeiliAllocationProgress;

	public bool IsChanged => LoopingNeigong.combatSkillTemplateId >= 0 || ConsummateLevelChanged || ConsummateLevelProgress >= 0 || ResourcesChanged || ExtraNeiliChanged || ReadingResult.readingBook != null || ImprovedSkillQualification.HasValue;

	public PeriAdvanceMonthSelfImprovementModification(Character character)
	{
		Character = character;
		ConsummateLevelProgress = -1;
		LoopingNeigong = (combatSkillTemplateId: -1, neili: 0, qiDisorder: 0);
		ReadingResult = (readingBook: null, learnedSkillIndex: -1, page: 0, succeedPageCount: 0);
		ExtraNeiliAllocationProgress = new int[4];
	}
}
