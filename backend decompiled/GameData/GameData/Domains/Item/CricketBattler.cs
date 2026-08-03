using System;
using Config;
using GameData.Domains.Item.Display;

namespace GameData.Domains.Item;

public class CricketBattler
{
	public ItemKey Key;

	private CricketPartsItem _colorConfig;

	private CricketPartsItem _partConfig;

	private bool _isCombineCricket;

	public CricketData CricketData;

	public int HP;

	public int SP;

	public int Durability;

	public bool IsTrash => _colorConfig.TemplateId == 0;

	public int Level => _isCombineCricket ? ((int)MathF.Max(_colorConfig.Level, _partConfig.Level)) : _colorConfig.Level;

	public int Vigor => _colorConfig.Vigor + (_isCombineCricket ? _partConfig.Vigor : 0) - (CricketData?.InjuryVigor ?? 0);

	public int Strength => _colorConfig.Strength + (_isCombineCricket ? _partConfig.Strength : 0) - (CricketData?.InjuryStrength ?? 0);

	public int Bite => _colorConfig.Bite + (_isCombineCricket ? _partConfig.Bite : 0) - (CricketData?.InjuryBite ?? 0);

	public int Deadliness => _isCombineCricket ? (_colorConfig.Deadliness + _partConfig.Deadliness) : _colorConfig.Deadliness;

	public int Damage => _isCombineCricket ? (_colorConfig.Damage + _partConfig.Damage) : _colorConfig.Damage;

	public int Cripple => _isCombineCricket ? (_colorConfig.Cripple + _partConfig.Cripple) : _colorConfig.Cripple;

	public int Defence => _isCombineCricket ? (_colorConfig.Defence + _partConfig.Defence) : _colorConfig.Defence;

	public int DamageReduce => _isCombineCricket ? (_colorConfig.DamageReduce + _partConfig.DamageReduce) : _colorConfig.DamageReduce;

	public int Counter => _isCombineCricket ? (_colorConfig.Counter + _partConfig.Counter) : _colorConfig.Counter;

	public int MaxHP => _colorConfig.HP + (_isCombineCricket ? _partConfig.HP : 0) - (CricketData?.InjuryHp ?? 0);

	public int MaxSP => _colorConfig.SP + (_isCombineCricket ? _partConfig.SP : 0) - (CricketData?.InjurySp ?? 0);

	public bool IsFail => HP <= 0 || SP <= 0 || Durability <= 0;

	public CricketBattler(ItemKey itemKey)
	{
		Key = itemKey;
		CricketData = DomainManager.Item.GetCricketData(itemKey.Id);
		ItemDisplayData itemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey);
		_colorConfig = CricketParts.Instance.GetItem(itemDisplayData.CricketColorId);
		_partConfig = CricketParts.Instance.GetItem(itemDisplayData.CricketPartId);
		_isCombineCricket = _partConfig != null;
		HP = MaxHP;
		SP = MaxSP;
		Durability = itemDisplayData.Durability;
	}
}
