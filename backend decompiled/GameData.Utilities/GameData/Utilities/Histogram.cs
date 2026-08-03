using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Utilities;

public class Histogram
{
	private readonly double _min;

	private readonly double _max;

	private readonly int _bins;

	private readonly double[] _nodes;

	private readonly int[] _amounts;

	private bool _isIntegers;

	public Histogram(int min, int max, int bins = 10)
	{
		if (min >= max)
		{
			throw new Exception("min must less than max.");
		}
		if (bins <= 0)
		{
			throw new Exception("bins must greater than zero.");
		}
		if ((max - min) % bins != 0)
		{
			throw new Exception("cannot calculate bin width as integer.");
		}
		_isIntegers = true;
		_min = min;
		_max = max;
		_bins = bins;
		double binWidth = (_max - _min) / (double)_bins;
		int nodesCount = _bins + 1;
		_nodes = new double[nodesCount];
		for (int i = 0; i < nodesCount; i++)
		{
			_nodes[i] = _min + binWidth * (double)i;
		}
		_nodes[0] = _min;
		_nodes[nodesCount - 1] = _max;
		_amounts = new int[_bins + 2];
	}

	public Histogram(double min, double max, int bins = 10)
	{
		if (min >= max)
		{
			throw new Exception("min must less than max.");
		}
		if (bins <= 0)
		{
			throw new Exception("bins must greater than zero.");
		}
		_isIntegers = false;
		_min = min;
		_max = max;
		_bins = bins;
		double binWidth = (_max - _min) / (double)_bins;
		int nodesCount = _bins + 1;
		_nodes = new double[nodesCount];
		for (int i = 0; i < nodesCount; i++)
		{
			_nodes[i] = _min + binWidth * (double)i;
		}
		_nodes[0] = _min;
		_nodes[nodesCount - 1] = _max;
		_amounts = new int[_bins + 2];
	}

	public void Record(double value)
	{
		int amountsCount = _amounts.Length;
		for (int i = 0; i < amountsCount; i++)
		{
			if (i == 0)
			{
				if (value < _min)
				{
					_amounts[i]++;
					break;
				}
			}
			else if (i == amountsCount - 1)
			{
				if (value > _max)
				{
					_amounts[i]++;
					break;
				}
			}
			else if (i == amountsCount - 2)
			{
				double currMin = _nodes[i - 1];
				double currMax = _nodes[i];
				if (value >= currMin && value <= currMax)
				{
					_amounts[i]++;
					break;
				}
			}
			else
			{
				double currMin2 = _nodes[i - 1];
				double currMax2 = _nodes[i];
				if (value >= currMin2 && value < currMax2)
				{
					_amounts[i]++;
					break;
				}
			}
		}
	}

	public void Record(IEnumerable<int> values)
	{
		foreach (int value in values)
		{
			Record(value);
		}
	}

	public void Record(IEnumerable<double> values)
	{
		foreach (double value in values)
		{
			Record(value);
		}
	}

	public string GetTextGraph(int maxBlocks = 100)
	{
		long totalAmount = 0L;
		int[] amounts = _amounts;
		foreach (int amount in amounts)
		{
			totalAmount += amount;
		}
		StringBuilder text = new StringBuilder();
		int amountsCount = _amounts.Length;
		for (int j = 0; j < amountsCount; j++)
		{
			if (j == 0)
			{
				text.AppendFormat("{0,20} ({1,10}): ", _isIntegers ? $" - {_min:N0}" : $" - {_min:N3}", _amounts[j]);
				AppendBlocks(text, _amounts[j], totalAmount, maxBlocks);
				continue;
			}
			if (j == amountsCount - 1)
			{
				text.AppendFormat("{0,20} ({1,10}): ", _isIntegers ? $"{_max:N0} - " : $"{_max:N3} - ", _amounts[j]);
				AppendBlocks(text, _amounts[j], totalAmount, maxBlocks);
				continue;
			}
			double currMin = _nodes[j - 1];
			double currMax = _nodes[j];
			text.AppendFormat("{0,20} ({1,10}): ", _isIntegers ? $"{currMin:N0} - {currMax:N0}" : $"{currMin:N3} - {currMax:N3}", _amounts[j]);
			AppendBlocks(text, _amounts[j], totalAmount, maxBlocks);
		}
		return text.ToString();
	}

	private static void AppendBlocks(StringBuilder sb, int amount, long totalAmount, int maxBlocks)
	{
		int scaledAmount = (int)Math.Round((double)amount / (double)totalAmount * (double)maxBlocks);
		for (int i = 0; i < scaledAmount; i++)
		{
			sb.Append('█');
		}
		for (int j = 0; j < maxBlocks - scaledAmount; j++)
		{
			sb.Append('░');
		}
		sb.AppendLine();
	}
}
