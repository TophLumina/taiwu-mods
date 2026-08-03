using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Story.MainStory;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class FengYuanHuanSuGong : TwelveImmortalsBase
{
	private const int AddHitAvoidUnit = 10;

	private const int AddCriticalOdds = 200;

	private int _directCharCount;

	private bool _lastAffecting;

	public FengYuanHuanSuGong()
	{
	}

	public FengYuanHuanSuGong(CombatSkillKey skillKey)
		: base(skillKey, 18004)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		AutoMonitor(ParseCombatCharacterDataUid(62), UpdateAffect);
		if (base.IsDirect)
		{
			_directCharCount = base.TwelveImmortalsConfig.GetImpactRangeCharacters(CharObj).Count();
		}
		CreateAffectedData(341, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(342, EDataModifyType.TotalPercent, -1);
		for (int i = 0; i < 4; i++)
		{
			CreateAffectedData((ushort)(32 + i), EDataModifyType.TotalPercent, -1);
			CreateAffectedData((ushort)(38 + i), EDataModifyType.TotalPercent, -1);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (_directCharCount > 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void UpdateAffect(DataContext context, DataUid dataUid)
	{
		bool currAffecting = base.CombatChar.GetAffectingMoveSkillId() >= 0;
		if (currAffecting != _lastAffecting)
		{
			if (currAffecting)
			{
				ShowSpecialEffectTips(0);
			}
			_lastAffecting = currAffecting;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 341) <= 1u)
		{
			return (base.IsDirect || base.CombatChar.GetAffectingMoveSkillId() < 0) ? base.GetModifyValue(dataKey, currModifyValue) : 200;
		}
		return base.IsDirect ? (_directCharCount * 10) : base.GetModifyValue(dataKey, currModifyValue);
	}
}
