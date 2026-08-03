using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class ZhuanYuanFa : CombatSkillEffectBase
{
	private const sbyte EvenAddPower = 10;

	private const sbyte EnemyAddPower = 10;

	private int _currAddPower;

	private DataUid _enemyBehaviorUid;

	public ZhuanYuanFa()
	{
	}

	public ZhuanYuanFa(CombatSkillKey skillKey)
		: base(skillKey, 7001, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(199, EDataModifyType.Add, -1);
		AutoMonitor(ParseCharDataUid(77), UpdateAddPower);
		UpdateAddPower(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatEnd(OnCombatEnd);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatEnd(OnCombatEnd);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			_enemyBehaviorUid = ParseCharDataUid(base.CurrEnemyChar.GetId(), 77);
			AutoMonitor(_enemyBehaviorUid, UpdateAddPower);
			UpdateAddPower(context);
		}
	}

	private void OnCombatEnd(DataContext context)
	{
		if (IsMonitored(_enemyBehaviorUid))
		{
			InterruptMonitor(_enemyBehaviorUid);
			UpdateAddPower(context);
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && base.CombatChar.IsAlly != isAlly)
		{
			InterruptMonitor(_enemyBehaviorUid);
			_enemyBehaviorUid = ParseCharDataUid(base.CurrEnemyChar.GetId(), 77);
			AutoMonitor(_enemyBehaviorUid, UpdateAddPower);
			UpdateAddPower(context);
		}
	}

	private void UpdateAddPower(DataContext context, DataUid dataUid = default(DataUid))
	{
		int addPower = 0;
		sbyte self = CharObj.GetBehaviorType();
		if (self == 2)
		{
			addPower += 10;
		}
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			sbyte enemy = base.CurrEnemyChar.GetCharacter().GetBehaviorType();
			if (base.IsDirect ? BehaviorType.IsHarmonious(self, enemy) : BehaviorType.IsConflicting(self, enemy))
			{
				addPower += 10;
			}
		}
		if (addPower != _currAddPower)
		{
			_currAddPower = addPower;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _currAddPower;
		}
		return 0;
	}
}
