using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.Profession.Savage;

public class TaoHuaYuan : ProfessionEffectBase
{
	private int _originNeili;

	protected override short CombatStateId => 141;

	public TaoHuaYuan()
	{
	}

	public TaoHuaYuan(int charId)
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
		_originNeili = CharObj.GetCurrNeili();
	}

	protected override void BeforeRemove(DataContext context)
	{
		base.BeforeRemove(context);
		int currNeili = CharObj.GetCurrNeili();
		if (currNeili < _originNeili)
		{
			CharObj.ChangeCurrNeili(context, _originNeili - currNeili);
		}
	}
}
