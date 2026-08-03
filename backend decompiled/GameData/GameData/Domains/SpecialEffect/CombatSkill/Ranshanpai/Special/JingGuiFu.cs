using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class JingGuiFu : CombatSkillEffectBase
{
	private const int ReduceFleeSpeedPercent = -67;

	private readonly sbyte[] _personalityTypes = new sbyte[5] { 0, 1, 2, 3, 4 };

	private bool _affecting;

	private int _reduceFleeSpeedCharId = -1;

	private int PersonalitiesSum => _personalityTypes.Sum((sbyte x) => CharObj.GetPersonalities()[x]);

	private int FleeOdds => 50 + PersonalitiesSum / 10;

	private int TrickOrMarkCount => 3 + PersonalitiesSum / 75;

	public JingGuiFu()
	{
	}

	public JingGuiFu(CombatSkillKey skillKey)
		: base(skillKey, 7302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedAllEnemyData(124, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_InterruptOtherAction(OnInterruptOtherAction);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_InterruptOtherAction(OnInterruptOtherAction);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			_affecting = !enemyChar.AiController.Memory.EnemyRecordDict[base.CharacterId].SkillRecord.ContainsKey(base.SkillTemplateId);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (enemyChar.AiController.CanFlee())
			{
				DoFlee(context, enemyChar);
			}
			else
			{
				DoTrickOrMark(context);
			}
		}
	}

	private void OnInterruptOtherAction(DataContext context, CombatCharacter combatChar, sbyte otherActionType)
	{
		if (combatChar.GetId() == _reduceFleeSpeedCharId && otherActionType == 2)
		{
			_reduceFleeSpeedCharId = -1;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 124 && dataKey.CharId == _reduceFleeSpeedCharId)
		{
			return -67;
		}
		return 0;
	}

	private void DoFlee(DataContext context, CombatCharacter enemyChar)
	{
		if (context.Random.CheckPercentProb(FleeOdds))
		{
			enemyChar.NeedForceFlee = true;
			_reduceFleeSpeedCharId = enemyChar.GetId();
			ShowSpecialEffectTips(0);
		}
	}

	private void DoTrickOrMark(DataContext context)
	{
		if (_affecting)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, base.CurrEnemyChar, 20, TrickOrMarkCount, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, base.CurrEnemyChar, TrickOrMarkCount);
			}
			ShowSpecialEffectTips(1);
		}
	}
}
