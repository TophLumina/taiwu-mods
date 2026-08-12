using System;

namespace GameData.Utilities;

public class VersionUtils
{
	private const int MajorPos = 0;

	private const int MinorPos = 16;

	private const int BuildPos = 32;

	private const int RevisionPos = 48;

	public static ulong DateTimeStringToUlong(string dateTimeStr)
	{
		DateTime time;
		return ulong.Parse((DateTime.TryParse(dateTimeStr, out time) ? time : DateTime.MinValue).ToString("yyyyMMddHHmmssffff"));
	}

	public static ulong VersionStringToUlong(string versionStr)
	{
		Version version = ParseGameVersion(versionStr);
		if (version == null)
		{
			return 0uL;
		}
		return BitOperation.SetSubUlong(BitOperation.SetSubUlong(BitOperation.SetSubUlong(BitOperation.SetSubUlong(0uL, 0, 16, ParseVersionNumber(version.Major)), 16, 16, ParseVersionNumber(version.Minor)), 32, 16, ParseVersionNumber(version.Build)), 48, 16, ParseVersionNumber(version.Revision));
	}

	public static string VersionUlongToString(ulong versionUlong)
	{
		ulong subUlong = BitOperation.GetSubUlong(versionUlong, 0, 16);
		ulong minor = BitOperation.GetSubUlong(versionUlong, 16, 16);
		ulong build = BitOperation.GetSubUlong(versionUlong, 32, 16);
		ulong revision = BitOperation.GetSubUlong(versionUlong, 48, 16);
		return new Version((ushort)subUlong, (ushort)minor, (ushort)build, (ushort)revision).ToString();
	}

	public static int CompareVersion(ulong versionA, ulong versionB)
	{
		int compareMajor = CompareSubVersion(versionA, versionB, 0);
		if (compareMajor != 0)
		{
			return compareMajor;
		}
		int compareMinor = CompareSubVersion(versionA, versionB, 16);
		if (compareMinor != 0)
		{
			return compareMinor;
		}
		int compareBuild = CompareSubVersion(versionA, versionB, 32);
		if (compareBuild != 0)
		{
			return compareBuild;
		}
		int compareRevision = CompareSubVersion(versionA, versionB, 48);
		if (compareRevision != 0)
		{
			return compareRevision;
		}
		return 0;
	}

	private static int CompareSubVersion(ulong versionA, ulong versionB, int pos)
	{
		ulong subVersionA = BitOperation.GetSubUlong(versionA, pos, 16);
		ulong subVersionB = BitOperation.GetSubUlong(versionB, pos, 16);
		return subVersionA.CompareTo(subVersionB);
	}

	private static ushort ParseVersionNumber(int versionNumber)
	{
		if (versionNumber < 0 || versionNumber > 65535)
		{
			return 0;
		}
		return (ushort)versionNumber;
	}

	public static Version ParseGameVersion(string gameVersion)
	{
		if (string.IsNullOrEmpty(gameVersion))
		{
			return null;
		}
		if (gameVersion[0] == 'V')
		{
			gameVersion = gameVersion.Substring(1);
		}
		if (Version.TryParse(gameVersion, out Version version))
		{
			if (version.Major > 1)
			{
				return null;
			}
			return version;
		}
		int versionLength = gameVersion.IndexOf('-');
		if (versionLength < 0)
		{
			return null;
		}
		if (!Version.TryParse(gameVersion.Substring(0, versionLength), out version))
		{
			return null;
		}
		if (version.Major > 1)
		{
			return null;
		}
		return version;
	}
}
