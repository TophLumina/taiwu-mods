using System;

namespace GameData.Combat.Math;

public record struct CValueModify
{
	public static CValueModify Zero => default(CValueModify);

	public bool IsZero
	{
		get
		{
			if (_add == 0 && _addPercent == 0 && _totalPercentAdd == 0)
			{
				return _totalPercentReduce == 0;
			}
			return false;
		}
	}

	private int _add;

	private CValuePercentBonus _addPercent;

	private CValuePercentBonus _totalPercentAdd;

	private CValuePercentBonus _totalPercentReduce;

	public CValueModify(int add = 0, CValuePercentBonus addPercent = default(CValuePercentBonus), CValuePercentBonus totalPercentAdd = default(CValuePercentBonus), CValuePercentBonus totalPercentReduce = default(CValuePercentBonus))
	{
		_add = add;
		_addPercent = addPercent;
		_totalPercentAdd = CombatMath.Max(0, totalPercentAdd);
		_totalPercentReduce = CombatMath.Min(0, totalPercentReduce);
	}

	private CValueModify(CValueModify other)
	{
		_add = other._add;
		_addPercent = other._addPercent;
		_totalPercentAdd = other._totalPercentAdd;
		_totalPercentReduce = other._totalPercentReduce;
	}

	public CValueModify ChangeA(CValueModify delta)
	{
		CValueModify result = new CValueModify(this);
		result._add = _add * delta;
		return result;
	}

	public CValueModify ChangeA(int deltaAdd)
	{
		CValueModify result = new CValueModify(this);
		result._add = _add + deltaAdd;
		return result;
	}

	public CValueModify ChangeB(int deltaAddPercent)
	{
		CValueModify result = new CValueModify(this);
		result._addPercent = _addPercent + deltaAddPercent;
		return result;
	}

	public CValueModify ChangeC(int deltaTotalPercent)
	{
		CValueModify result = new CValueModify(this);
		result._totalPercentAdd = CombatMath.Max(_totalPercentAdd, deltaTotalPercent);
		result._totalPercentReduce = CombatMath.Min(_totalPercentReduce, deltaTotalPercent);
		return result;
	}

	public CValueModify MaxA(int value, int minModifiedValue)
	{
		CValueModify result = new CValueModify(this);
		result._add = CombatMath.Max(_add, minModifiedValue - value);
		return result;
	}

	public CValueModify MaxB(CValuePercent minPercent)
	{
		CValueModify result = new CValueModify(this);
		result._addPercent = CombatMath.Max(_addPercent, (CValuePercentBonus)minPercent);
		return result;
	}

	public CValueModify StaySymbol(int value = 0)
	{
		return new CValueModify
		{
			_add = ((value == 0) ? _add : ((value < 0) ? CombatMath.Min(_add, -value) : CombatMath.Max(_add, -value))),
			_addPercent = _addPercent.StaySymbol(),
			_totalPercentAdd = _totalPercentAdd.StaySymbol(),
			_totalPercentReduce = _totalPercentReduce.StaySymbol()
		};
	}

	public CValueModify ReverseByValue(int value)
	{
		int tempValue = value + _add;
		if (tempValue <= 0)
		{
			if (tempValue == 0)
			{
				return Zero;
			}
			CValueModify result = new CValueModify(this);
			result._addPercent = -_addPercent;
			result._totalPercentAdd = -_totalPercentReduce;
			result._totalPercentReduce = -_totalPercentAdd;
			return result;
		}
		return this;
	}

	public int ModifyA(int value)
	{
		return value + _add;
	}

	public int ModifyB(int value)
	{
		return value * _addPercent;
	}

	public int ModifyC(int value)
	{
		return value * (_totalPercentAdd + _totalPercentReduce);
	}

	public int ModifyValue(int value)
	{
		return value * this;
	}

	public long ModifyValue(long value)
	{
		return value * this;
	}

	public static CValueModify operator +(CValueModify a, CValueModify b)
	{
		return new CValueModify
		{
			_add = a._add + b._add,
			_addPercent = a._addPercent + b._addPercent,
			_totalPercentAdd = CombatMath.Max(a._totalPercentAdd, b._totalPercentAdd),
			_totalPercentReduce = CombatMath.Min(a._totalPercentReduce, b._totalPercentReduce)
		};
	}

	public static CValueModify operator +(CValueModify modify, CValueModifyDelta delta)
	{
		return delta.Type switch
		{
			EDataModifyType.Add => modify.ChangeA(delta.Value), 
			EDataModifyType.AddPercent => modify.ChangeB(delta.Value), 
			EDataModifyType.TotalPercent => modify.ChangeC(delta.Value), 
			_ => throw new ArgumentOutOfRangeException("delta", delta, null), 
		};
	}

	public static CValueModify operator *(CValueModify modify, EDataReverseType reverseType)
	{
		var (addC, reduceC) = reverseType.Apply((int)modify._totalPercentAdd, (int)modify._totalPercentReduce);
		return new CValueModify
		{
			_add = reverseType.Apply(modify._add),
			_addPercent = reverseType.Apply((int)modify._addPercent),
			_totalPercentAdd = addC,
			_totalPercentReduce = reduceC
		};
	}

	[Obsolete("Ambiguity between 'CValueMultiplier' and 'CValuePercentBonus'", true)]
	public static CValueModify operator *(CValueModify modify, int multiplier)
	{
		return modify * (CValueMultiplier)multiplier;
	}

	public static CValueModify operator *(CValueModify modify, CValueMultiplier multiplier)
	{
		return new CValueModify(modify._add * (int)multiplier, modify._addPercent * multiplier, modify._totalPercentAdd * multiplier, modify._totalPercentReduce * multiplier);
	}

	public static CValueModify operator *(CValueModify modify, CValuePercentBonus bonus)
	{
		return new CValueModify(modify._add * bonus, modify._addPercent ^ bonus, modify._totalPercentAdd ^ bonus, modify._totalPercentReduce ^ bonus);
	}

	public static int operator *(int valueInt, CValueModify modify)
	{
		return (int)CombatMath.Clamp((long)valueInt * modify, -2147483648L, 2147483647L);
	}

	public static long operator *(long value, CValueModify modify)
	{
		value += modify._add;
		value *= modify._addPercent;
		value *= modify._totalPercentAdd + modify._totalPercentReduce;
		return value;
	}
}
