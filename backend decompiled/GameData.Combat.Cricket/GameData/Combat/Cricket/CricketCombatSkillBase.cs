using GameData.Combat.Math;

namespace GameData.Combat.Cricket;

public abstract class CricketCombatSkillBase
{
	public readonly CricketCombatData Owner;

	public abstract ECricketCombatSkillType Type { get; }

	protected CricketCombatSkillBase(CricketCombatData owner)
	{
		Owner = owner;
	}

	public virtual ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.Normal;
	}

	public abstract bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context);

	public abstract void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context);

	protected void ShowEffectTips(CricketCombatSkillContext context)
	{
		context.TopContext?.Logs?.Enqueue(new CricketCombatLogSkill(this));
	}

	private void AddModifyInternal(CricketCombatSkillContext context, ECricketCombatPropertyModifyLifeCycle lifeCycle, CricketCombatData target, ECricketCombatPropertyType propertyType, int modifyValue, EDataModifyType modifyType)
	{
		CricketCombatSkillPropertyModify modify = new CricketCombatSkillPropertyModify(lifeCycle, propertyType, modifyType, modifyValue);
		target.AddSkillPropertyModify(modify);
		context.TopContext?.Logs?.Enqueue(new CricketCombatLogSkillPropertyModify(this, target, modify));
	}

	protected void AddModify(CricketCombatSkillContext context, ECricketCombatPropertyModifyLifeCycle lifeCycle, ECricketCombatPropertyType propertyType, int modifyValue)
	{
		AddModifyInternal(context, lifeCycle, Owner, propertyType, modifyValue, EDataModifyType.Add);
	}

	protected void AddModifyPercent(CricketCombatSkillContext context, ECricketCombatPropertyModifyLifeCycle lifeCycle, ECricketCombatPropertyType propertyType, int modifyValue)
	{
		AddModifyInternal(context, lifeCycle, Owner, propertyType, modifyValue, EDataModifyType.AddPercent);
	}

	protected void AddModifyZero(CricketCombatSkillContext context, ECricketCombatPropertyModifyLifeCycle lifeCycle, CricketCombatData target, ECricketCombatPropertyType propertyType)
	{
		AddModifyInternal(context, lifeCycle, target, propertyType, -100, EDataModifyType.TotalPercent);
	}

	public override string ToString()
	{
		return $"Skill({Owner.RuntimeId}.{Type.ToString()})";
	}
}
