using System;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 轴对称坐标系下突破盘索引（Axial Coordinates）
/// https://www.redblobgames.com/grids/hexagons
/// </summary>
public struct SkillBreakPlateAxial : IEquatable<SkillBreakPlateAxial>
{
	/// <summary>
	/// Q 轴坐标
	/// </summary>
	public int Q { get; private set; }

	/// <summary>
	/// R 轴坐标
	/// </summary>
	public int R { get; private set; }

	/// <summary>
	/// S 轴坐标
	/// </summary>
	public int S => -Q - R;

	/// <summary>
	/// 计算两点之间的坐标
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static int Distance(SkillBreakPlateAxial a, SkillBreakPlateAxial b)
	{
		return (MathUtils.Abs(a.Q - b.Q) + MathUtils.Abs(a.R - b.R) + MathUtils.Abs(a.S - b.S)) / 2;
	}

	/// <summary>
	/// 显式转换
	/// </summary>
	/// <param name="axial"></param>
	/// <returns></returns>
	public static explicit operator SkillBreakPlateIndex(SkillBreakPlateAxial axial)
	{
		SkillBreakPlateAxial skillBreakPlateAxial = axial;
		skillBreakPlateAxial.Deconstruct(out var q, out var r);
		int num = q;
		int r2 = r;
		int item = num + (r2 + (r2 & 1)) / 2;
		int row = -r2;
		return (x: item, y: row);
	}

	/// <summary>
	/// 隐式转换
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public static implicit operator SkillBreakPlateAxial(SkillBreakPlateIndex index)
	{
		SkillBreakPlateIndex skillBreakPlateIndex = index;
		skillBreakPlateIndex.Deconstruct(out var x, out var y);
		int num = x;
		int row = y;
		row = -row;
		int item = num - (row + (row & 1)) / 2;
		int r = row;
		return (q: item, r: r);
	}

	public static implicit operator SkillBreakPlateAxial((int q, int r) tup)
	{
		SkillBreakPlateAxial result = default(SkillBreakPlateAxial);
		(result.Q, result.R) = tup;
		return result;
	}

	/// <summary>
	/// 加法
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static SkillBreakPlateAxial operator +(SkillBreakPlateAxial left, SkillBreakPlateAxial right)
	{
		return new SkillBreakPlateAxial
		{
			Q = left.Q + right.Q,
			R = left.R + right.R
		};
	}

	/// <summary>
	/// 乘法
	/// </summary>
	/// <param name="axial"></param>
	/// <param name="multiplier"></param>
	/// <returns></returns>
	public static SkillBreakPlateAxial operator *(SkillBreakPlateAxial axial, int multiplier)
	{
		return new SkillBreakPlateAxial
		{
			Q = axial.Q * multiplier,
			R = axial.R * multiplier
		};
	}

	/// <summary>
	/// 反构造
	/// </summary>
	/// <param name="q"></param>
	/// <param name="r"></param>
	public void Deconstruct(out int q, out int r)
	{
		int q2 = Q;
		int r2 = R;
		q = q2;
		r = r2;
	}

	/// <summary>
	/// 反构造
	/// </summary>
	/// <param name="q"></param>
	/// <param name="r"></param>
	/// <param name="s"></param>
	public void Deconstruct(out int q, out int r, out int s)
	{
		int q2 = Q;
		int r2 = R;
		int s2 = S;
		q = q2;
		r = r2;
		s = s2;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"Axial({Q},{R},{S})";
	}

	/// <inheritdoc />
	public bool Equals(SkillBreakPlateAxial other)
	{
		if (Q == other.Q)
		{
			return R == other.R;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is SkillBreakPlateAxial other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (Q * 397) ^ R;
	}

	/// <summary>
	/// 等于
	/// </summary>
	public static bool operator ==(SkillBreakPlateAxial left, SkillBreakPlateAxial right)
	{
		return left.Equals(right);
	}

	/// <summary>
	/// 不等
	/// </summary>
	public static bool operator !=(SkillBreakPlateAxial left, SkillBreakPlateAxial right)
	{
		return !left.Equals(right);
	}
}
