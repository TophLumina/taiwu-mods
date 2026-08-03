using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ShengJieSiXian : CombatSkillEffectBase
{
	private const int AffectRequireTrickCount = 7;

	private const int AddMakeDamage = 1000;

	private const int SilenceFrame = 3600;

	private bool _affecting;

	public ShengJieSiXian()
	{
	}

	public ShengJieSiXian(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AutoMonitor(ParseCombatCharacterDataUid(28), UpdateAffecting);
		CreateAffectedData(145, EDataModifyType.Add, -1);
		CreateAffectedData(146, EDataModifyType.Add, -1);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		base.OnDisable(context);
	}

	private void UpdateAffecting(DataContext context, DataUid dataUid)
	{
		byte trickCount = base.CombatChar.GetTrickCount(21);
		bool affecting = trickCount >= 7;
		if (affecting != _affecting)
		{
			_affecting = affecting;
			InvalidateAllAffectDataCache(context);
			if (_affecting)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightBack, bool isMind)
	{
		if (attacker.GetId() == base.CharacterId && hit && pursueIndex <= 0 && _affecting)
		{
			short skillId = defender.GetRandomBanableSkillId(context.Random, null, -1);
			if (skillId >= 0)
			{
				DomainManager.Combat.SilenceSkill(context, defender, skillId, 3600);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result;
		switch (fieldId)
		{
		case 69:
			result = 1000;
			break;
		case 145:
		case 146:
			result = 10000;
			break;
		default:
			result = base.GetModifyValue(dataKey, currModifyValue);
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}
}
