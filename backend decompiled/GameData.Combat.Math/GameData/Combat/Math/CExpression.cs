using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameData.Combat.Math;

public class CExpression
{
	private static readonly IExpressionConverter SampleZeroConverter = new ExpressionConverterSampleZero();

	private readonly IReadOnlyList<CExpressionPart> _parts;

	private readonly Stack<int> _cache = new Stack<int>();

	public CExpression(IEnumerable<CExpressionPart> parts)
	{
		_parts = new List<CExpressionPart>(parts);
	}

	public static CExpression FromBase64(string base64)
	{
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64));
		using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);
		int count = reader.ReadInt32();
		List<CExpressionPart> parts = new List<CExpressionPart>(count);
		for (int i = 0; i < count; i++)
		{
			EExpressionPartType type = (EExpressionPartType)reader.ReadInt32();
			int value = reader.ReadInt32();
			parts.Add(new CExpressionPart
			{
				Type = type,
				Value = value
			});
		}
		return new CExpression(parts);
	}

	public static string ToBase64(CExpression expression)
	{
		using MemoryStream stream = new MemoryStream();
		using BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
		writer.Write(expression._parts.Count);
		foreach (CExpressionPart part in expression._parts)
		{
			writer.Write((int)part.Type);
			writer.Write(part.Value);
		}
		return Convert.ToBase64String(stream.ToArray());
	}

	public int Calc(IExpressionConverter converter)
	{
		if (converter == null)
		{
			converter = SampleZeroConverter;
		}
		_cache.Clear();
		foreach (CExpressionPart part in _parts)
		{
			if (part.IsNumber)
			{
				_cache.Push(part.ToNumber(converter));
				continue;
			}
			int val2 = _cache.Pop();
			int val3 = _cache.Pop();
			EExpressionOperatorType op = (EExpressionOperatorType)part.Value;
			int result = op switch
			{
				EExpressionOperatorType.Add => val3 + val2, 
				EExpressionOperatorType.Sub => val3 - val2, 
				EExpressionOperatorType.Mul => val3 * val2, 
				EExpressionOperatorType.Div => val3 / val2, 
				_ => throw new Exception($"Not support operator type {op}"), 
			};
			_cache.Push(result);
		}
		return _cache.Pop();
	}

	public int SampleZero()
	{
		return Calc(SampleZeroConverter);
	}
}
