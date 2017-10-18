using BefunDebug.Properties;

namespace BefunDebug.BCTestData
{
	public static class BefunCompileTestData
	{
		public class BCData
		{
			public readonly bool Active;
			public readonly string Name;
			public readonly string Code;
			public readonly string Result;

			public BCData(byte a, string n, string c, string r)
			{
				Active = (a != 0);
				Name = n;
				Code = c;
				Result = r;
			}
		}

		public static readonly BCData[] Data =
		{
			new BCData(1, "Euler_Problem-001", Resources.Euler_Problem_001, "233168 "),
			new BCData(1, "Euler_Problem-002", Resources.Euler_Problem_002, "4613732 "),
			new BCData(1, "Euler_Problem-003", Resources.Euler_Problem_003, "6857 "),
			new BCData(0, "Euler_Problem-004", Resources.Euler_Problem_004, "906609 "),
			new BCData(1, "Euler_Problem-005", Resources.Euler_Problem_005, "232792560 "),
			new BCData(1, "Euler_Problem-006", Resources.Euler_Problem_006, "25164150 "),
			new BCData(1, "Euler_Problem-007", Resources.Euler_Problem_007, "104743 "),
			new BCData(1, "Euler_Problem-008", Resources.Euler_Problem_008, "5576689664895=23514624000 "),
			new BCData(0, "Euler_Problem-009", Resources.Euler_Problem_009, "31875000 "),
			new BCData(1, "Euler_Problem-010", Resources.Euler_Problem_010, "142913828922 "),
			new BCData(1, "Euler_Problem-011", Resources.Euler_Problem_011, "70600674 "),
			new BCData(1, "Euler_Problem-012", Resources.Euler_Problem_012, "76576500 "),
			new BCData(1, "Euler_Problem-013", Resources.Euler_Problem_013, "5537376230"),
			new BCData(0, "Euler_Problem-014", Resources.Euler_Problem_014, "837799 "),
			new BCData(1, "Euler_Problem-015", Resources.Euler_Problem_015, "137846528820 "),
			new BCData(1, "Euler_Problem-016", Resources.Euler_Problem_016, "1366 "),
			new BCData(1, "Euler_Problem-017", Resources.Euler_Problem_017, "21124 "),
			new BCData(1, "Euler_Problem-018", Resources.Euler_Problem_018, "1074 "),
			new BCData(1, "Euler_Problem-019", Resources.Euler_Problem_019, "171 "),
			new BCData(1, "Euler_Problem-020", Resources.Euler_Problem_020, "648 "),
			new BCData(0, "Euler_Problem-021", Resources.Euler_Problem_021, "31626 "),
			new BCData(0, "Euler_Problem-022", Resources.Euler_Problem_022, "871198282 "),
			new BCData(0, "Euler_Problem-023", Resources.Euler_Problem_023, "4179871 "),
			new BCData(1, "Euler_Problem-024", Resources.Euler_Problem_024, "2783915460"),
			new BCData(0, "Euler_Problem-025", Resources.Euler_Problem_025, "4782 "),
			new BCData(1, "Euler_Problem-026", Resources.Euler_Problem_026, "983 "),
			new BCData(1, "Euler_Problem-027", Resources.Euler_Problem_027, "-59231 "),
			new BCData(1, "Euler_Problem-028", Resources.Euler_Problem_028, "669171001 "),
			new BCData(1, "Euler_Problem-030", Resources.Euler_Problem_030, "443839 "),
			new BCData(1, "Euler_Problem-031", Resources.Euler_Problem_031, "73682 "),
			new BCData(1, "Euler_Problem-032", Resources.Euler_Problem_032, "45228 "),
			new BCData(1, "Euler_Problem-033", Resources.Euler_Problem_033, "100 "),
			new BCData(0, "Euler_Problem-034", Resources.Euler_Problem_034, "40730 "),
			new BCData(1, "Euler_Problem-035", Resources.Euler_Problem_035, @"2 \n3 \n5 \n7 \n11 \n13 \n17 \n31 \n37 \n71 \n73 \n79 \n97 \n113 \n131 \n197 \n199 \n311 \n337 \n373 \n719 \n733 \n919 \n971 \n991 \n1193 \n1931 \n3119 \n3779 \n7793 \n7937 \n9311 \n9377 \n11939 \n19391 \n19937 \n37199 \n39119 \n71993 \n91193 \n93719 \n93911 \n99371 \n193939 \n199933 \n319993 \n331999 \n391939 \n393919 \n919393 \n933199 \n939193 \n939391 \n993319 \n999331 \n =55 "),
			new BCData(1, "Euler_Problem-036", Resources.Euler_Problem_036, @"585585 \n9009 \n7447 \n99 \n33 \n73737 \n53835 \n53235 \n39993 \n32223 \n15351 \n717 \n585 \n313 \n9 \n7 \n5 \n3 \n1 \n =872187 "),
			new BCData(1, "Euler_Problem-037", Resources.Euler_Problem_037, @"73 \n739397 \n797 \n53 \n37 \n317 \n313 \n3137 \n373 \n3797 \n23 \n =748317 "),
			new BCData(1, "Euler_Problem-038", Resources.Euler_Problem_038, "932718654 "),
			new BCData(1, "Euler_Problem-039", Resources.Euler_Problem_039, "840 "),
			new BCData(1, "Euler_Problem-040", Resources.Euler_Problem_040, "210 "),
			new BCData(1, "Euler_Problem-041", Resources.Euler_Problem_041, "7652413 "),
			new BCData(1, "Euler_Problem-042", Resources.Euler_Problem_042, "162 "),
			new BCData(1, "Euler_Problem-043", Resources.Euler_Problem_043, @"4130952867 \n1430952867 \n4160357289 \n1460357289 \n4106357289 \n1406357289 \n\n= 16695334890 "),
			new BCData(0, "Euler_Problem-044", Resources.Euler_Problem_044, "5482660 "),
			new BCData(1, "Euler_Problem-045", Resources.Euler_Problem_045, "1533776805 "),
			new BCData(1, "Euler_Problem-046", Resources.Euler_Problem_046, "5777 "),
			new BCData(0, "Euler_Problem-047", Resources.Euler_Problem_047, "134043 "),
			new BCData(1, "Euler_Problem-048", Resources.Euler_Problem_048, "9110846700 "),
			new BCData(1, "Euler_Problem-049", Resources.Euler_Problem_049, "2969  6299  9629 "),
			new BCData(1, "Euler_Problem-050", Resources.Euler_Problem_050, "997651 "),
			new BCData(0, "Euler_Problem-051", Resources.Euler_Problem_051, "121313 "),
			new BCData(1, "Euler_Problem-052", Resources.Euler_Problem_052, "142857 "),
			new BCData(1, "Euler_Problem-053", Resources.Euler_Problem_053, "4075 "),
			new BCData(1, "Euler_Problem-054", Resources.Euler_Problem_054, "376 "),
			new BCData(1, "Euler_Problem-055", Resources.Euler_Problem_055, "249 "),
			new BCData(1, "Euler_Problem-056", Resources.Euler_Problem_056, "972 "),
			new BCData(1, "Euler_Problem-057", Resources.Euler_Problem_057, "153 "),
			new BCData(1, "Euler_Problem-058", Resources.Euler_Problem_058, "26241 "),
			new BCData(1, "Euler_Problem-059", Resources.Euler_Problem_059, "107359 "),
			new BCData(0, "Euler_Problem-060", Resources.Euler_Problem_060, "26033 "),
			new BCData(1, "Euler_Problem-061", Resources.Euler_Problem_061, @"1281 \n8128 \n2882 \n8256 \n5625 \n2512 \n  = 28684 "),
			new BCData(0, "Euler_Problem-062", Resources.Euler_Problem_062, "127035954683 "),
			new BCData(1, "Euler_Problem-063", Resources.Euler_Problem_063, "49 "),
			new BCData(1, "Euler_Problem-064", Resources.Euler_Problem_064, "1322 "),
			new BCData(1, "Euler_Problem-065", Resources.Euler_Problem_065, "272 "),
			new BCData(0, "Euler_Problem-066", Resources.Euler_Problem_066, "661 "),
			new BCData(1, "Euler_Problem-067", Resources.Euler_Problem_067, "7273 "),
			new BCData(1, "Euler_Problem-068", Resources.Euler_Problem_068, "6 5 3 10 3 1 9 1 4 8 4 2 7 2 5 "),
			new BCData(1, "Euler_Problem-069", Resources.Euler_Problem_069, "510510 "),
			new BCData(1, "Euler_Problem-070", Resources.Euler_Problem_070, "8319823 "),
			new BCData(1, "Euler_Problem-071", Resources.Euler_Problem_071, @"428570  /\n999997 "),
			new BCData(0, "Euler_Problem-072", Resources.Euler_Problem_072, "303963552391 "),
			new BCData(0, "Euler_Problem-073", Resources.Euler_Problem_073, "7295372 "),
			new BCData(0, "Euler_Problem-074", Resources.Euler_Problem_074, "402 "),
			new BCData(0, "Euler_Problem-075", Resources.Euler_Problem_075, "161667 "),
			new BCData(1, "Euler_Problem-076", Resources.Euler_Problem_076, "190569291 "),
			new BCData(1, "Euler_Problem-077", Resources.Euler_Problem_077, "71 "),
			new BCData(0, "Euler_Problem-078", Resources.Euler_Problem_078, "55374 "),
			new BCData(1, "Euler_Problem-079", Resources.Euler_Problem_079, "73162890"),
			new BCData(0, "Euler_Problem-080", Resources.Euler_Problem_080, "40886 "),
			new BCData(1, "Euler_Problem-081", Resources.Euler_Problem_081, "427337 "),
			new BCData(1, "Euler_Problem-082", Resources.Euler_Problem_082, "260324 "),
			new BCData(1, "Euler_Problem-083", Resources.Euler_Problem_083, "425185 "),
			new BCData(0, "Euler_Problem-084", Resources.Euler_Problem_084, "101524 "),
			new BCData(1, "Euler_Problem-085", Resources.Euler_Problem_085, "2772 "),
			new BCData(0, "Euler_Problem-086", Resources.Euler_Problem_086, "1818 "),
			new BCData(0, "Euler_Problem-087", Resources.Euler_Problem_087, "1097343 "),
			new BCData(0, "Euler_Problem-088", Resources.Euler_Problem_088, "7587457 "),
			new BCData(1, "Euler_Problem-089", Resources.Euler_Problem_089, "743 "),
			new BCData(0, "Euler_Problem-090", Resources.Euler_Problem_090, "1217 "),
			new BCData(1, "Euler_Problem-091", Resources.Euler_Problem_091, "14234 "),
			new BCData(0, "Euler_Problem-092", Resources.Euler_Problem_092, "8581146 "),
			new BCData(0, "Euler_Problem-093", Resources.Euler_Problem_093, "1258 "),
			new BCData(1, "Euler_Problem-094", Resources.Euler_Problem_094, "518408346 "),
			new BCData(0, "Euler_Problem-095", Resources.Euler_Problem_095, "14316 "),
			new BCData(0, "Euler_Problem-096", Resources.Euler_Problem_096, "24702 "),
			new BCData(0, "Euler_Problem-097", Resources.Euler_Problem_097, "8739992577 "),
			new BCData(0, "Euler_Problem-098", Resources.Euler_Problem_098, "18769 "),
			new BCData(1, "Euler_Problem-099", Resources.Euler_Problem_099, "709 "),
			new BCData(1, "Euler_Problem-100", Resources.Euler_Problem_100, "756872327473 "),
		};
	}
}
