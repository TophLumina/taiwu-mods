using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public abstract class LegacyPower : CombatStateEffectBase
{
	private const int AddPower = 220;

	protected abstract sbyte OrgTemplateId { get; }

	private bool IsOrgSkill(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].SectId == OrgTemplateId;
	}

	protected LegacyPower(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedData(context, 199, EDataModifyType.Add, -1);
		AppendAffectedAllEnemyData(context, 199, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 199 || !IsOrgSkill(dataKey.CombatSkillId))
		{
			return 0;
		}
		return (dataKey.CharId == base.CharacterId) ? 220 : (-220);
	}
}
