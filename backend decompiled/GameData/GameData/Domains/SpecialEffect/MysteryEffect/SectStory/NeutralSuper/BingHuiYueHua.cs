using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

public class BingHuiYueHua : MysteryEffectBase
{
	private const int ReduceCostMobility = -50;

	private static CValuePercent AddProgress => 50;

	protected override short SpecialEffectId => 1775;

	public BingHuiYueHua()
	{
	}

	public BingHuiYueHua(int charId, int itemId)
		: base(charId, itemId, 50107)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(207, EDataModifyType.TotalPercent, -1);
		AutoMonitor(ParseCharDataUid(17), Update);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && CharObj.HasVirginity())
		{
			ShowSpecialEffect(0);
		}
	}

	private void Update(DataContext context, DataUid uid)
	{
		InvalidateCache(context, 207);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsAgile(skillId) && CharObj.HasVirginity() && !base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * AddProgress);
			ShowSpecialEffect(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 207 && CombatSkillEquipType.IsAgile(dataKey.CombatSkillId) && CharObj.HasVirginity())
		{
			return -50;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
