using System;
using System.Collections.Generic;
using Redzen.Random;

namespace GameData.Utilities;

public class WeightTable<T>
{
	private readonly List<T> _values;

	private readonly List<int> _weights;

	public int TotalWeight { get; private set; }

	public int Count => _weights.Count;

	public WeightTable()
	{
		_values = new List<T>();
		_weights = new List<int>();
	}

	public WeightTable(IEnumerable<T> values, IEnumerable<int> weights)
	{
		_values = new List<T>(values);
		_weights = new List<int>(weights);
	}

	public void Add(T val, int weight)
	{
		_values.Add(val);
		_weights.Add(weight);
		TotalWeight += weight;
	}

	public (T val, int weight) Get(int index)
	{
		return (val: _values[index], weight: _weights[index]);
	}

	public void RemoveAt(int index)
	{
		if (index >= _weights.Count || index < 0)
		{
			throw new ArgumentOutOfRangeException($"index {index} should be in range [0, {_weights.Count}).");
		}
		TotalWeight -= _weights[index];
		_values.RemoveAt(index);
		_weights.RemoveAt(index);
	}

	public (T val, int weight) GetMaxWeightElement()
	{
		int index = GetMaxWeightIndex();
		return (val: _values[index], weight: _weights[index]);
	}

	public int GetMaxWeightIndex()
	{
		int maxWeight = _weights[0];
		int maxWeightIndex = 0;
		for (int i = 1; i < _weights.Count; i++)
		{
			int weight = _weights[i];
			if (weight > maxWeight)
			{
				maxWeight = weight;
				maxWeightIndex = i;
			}
		}
		return maxWeightIndex;
	}

	public T GetRandom(IRandomSource random)
	{
		int randomNum = random.Next(TotalWeight);
		for (int i = 0; i < _weights.Count; i++)
		{
			int weight = _weights[i];
			if (randomNum < weight)
			{
				return _values[i];
			}
			randomNum -= weight;
		}
		return _values[_values.Count - 1];
	}

	public int GetRandomIndex(IRandomSource random)
	{
		int randomNum = random.Next(TotalWeight);
		for (int i = 0; i < _weights.Count; i++)
		{
			int weight = _weights[i];
			if (randomNum < weight)
			{
				return i;
			}
			randomNum -= weight;
		}
		return _weights.Count - 1;
	}

	public void ChangeWeight(int index, int delta)
	{
		_weights[index] += delta;
		TotalWeight += delta;
	}

	public void SetWeight(int index, int weight)
	{
		TotalWeight += weight - _weights[index];
		_weights[index] = weight;
	}

	public bool Remove(T val)
	{
		int index = _values.IndexOf(val);
		if (index >= 0)
		{
			TotalWeight -= _weights[index];
			_values.RemoveAt(index);
			_weights.RemoveAt(index);
			return true;
		}
		return false;
	}

	public void Clear()
	{
		_values.Clear();
		_weights.Clear();
		TotalWeight = 0;
	}
}
