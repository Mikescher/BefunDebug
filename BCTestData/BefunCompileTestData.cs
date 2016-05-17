using BefunGen.Properties;

namespace BefunGen.BCTestData
{
	public static class BefunCompileTestData
	{
		public class BCData
		{
			public readonly string Name;
			public readonly string Code;
			public readonly string Result;

			public BCData(string n, string c, string r)
			{
				Name = n;
				Code = c;
				Result = r;
			}
		}

		public static readonly BCData[] Data =
		{
			new BCData("data_001", Resources.testdata_001, "233168"),
			new BCData("data_002", Resources.testdata_002, "4613732"),
			new BCData("data_003", Resources.testdata_003, "6857"),
			new BCData("data_005", Resources.testdata_005, "232792560"),
			new BCData("data_006", Resources.testdata_006, "25164150"),
			new BCData("data_007", Resources.testdata_007, "104743"),
			new BCData("data_008", Resources.testdata_008, "5576689664895=23514624000"),
			new BCData("data_010", Resources.testdata_010, "142913828922"),
			new BCData("data_011", Resources.testdata_011, "70600674"),
			new BCData("data_012", Resources.testdata_012, "76576500"),
			new BCData("data_013", Resources.testdata_013, "5537376230"),
			new BCData("data_015", Resources.testdata_015, "137846528820"),
			new BCData("data_016", Resources.testdata_016, "1366"),
			new BCData("data_017", Resources.testdata_017, "21124"),
			new BCData("data_018", Resources.testdata_018, "1074"),
			new BCData("data_019", Resources.testdata_019, "171"),
			new BCData("data_020", Resources.testdata_020, "648"),
			new BCData("data_024", Resources.testdata_024, "2783915460"),
			new BCData("data_026", Resources.testdata_026, "983"),
			new BCData("data_027", Resources.testdata_027, "-59231"),
			new BCData("data_028", Resources.testdata_028, "669171001"),
			new BCData("data_030", Resources.testdata_030, "443839"),
			new BCData("data_031", Resources.testdata_031, "73682"),
			new BCData("data_032", Resources.testdata_032, "45228"),
			new BCData("data_033", Resources.testdata_033, "100"),
			new BCData("data_035", Resources.testdata_035, @"2\n3\n5\n7\n11\n13\n17\n31\n37\n71\n73\n79\n97\n113\n131\n197\n199\n311\n337\n373\n719\n733\n919\n971\n991\n1193\n1931\n3119\n3779\n7793\n7937\n9311\n9377\n11939\n19391\n19937\n37199\n39119\n71993\n91193\n93719\n93911\n99371\n193939\n199933\n319993\n331999\n391939\n393919\n919393\n933199\n939193\n939391\n993319\n999331\n =55"),
			new BCData("data_036", Resources.testdata_036, @"585585\n9009\n7447\n99\n33\n73737\n53835\n53235\n39993\n32223\n15351\n717\n585\n313\n9\n7\n5\n3\n1\n =872187"),
			new BCData("data_037", Resources.testdata_037, @"73\n739397\n797\n53\n37\n317\n313\n3137\n373\n3797\n23\n =748317"),
			new BCData("data_038", Resources.testdata_038, "932718654"),
			new BCData("data_039", Resources.testdata_039, "840"),
			new BCData("data_040", Resources.testdata_040, "210"),
			new BCData("data_041", Resources.testdata_041, "7652413"),
			new BCData("data_042", Resources.testdata_042, "162"),
			new BCData("data_043", Resources.testdata_043, @"4130952867\n1430952867\n4160357289\n1460357289\n4106357289\n1406357289\n\n= 16695334890"),
			new BCData("data_045", Resources.testdata_045, "1533776805"),
			new BCData("data_046", Resources.testdata_046, "5777"),
			new BCData("data_048", Resources.testdata_048, "9110846700"),
			new BCData("data_049", Resources.testdata_049, "2969 6299 9629"),
			new BCData("data_050", Resources.testdata_050, "997651"),
			new BCData("data_052", Resources.testdata_052, "142857"),
			new BCData("data_053", Resources.testdata_053, "4075"),
			new BCData("data_054", Resources.testdata_054, "376"),
			new BCData("data_055", Resources.testdata_055, "249"),
			new BCData("data_056", Resources.testdata_056, "972"),
			new BCData("data_057", Resources.testdata_057, "153"),
			new BCData("data_058", Resources.testdata_058, "26241"),
			new BCData("data_059", Resources.testdata_059, "107359"),
			new BCData("data_061", Resources.testdata_061, @"1281\n8128\n2882\n8256\n5625\n2512\n  = 28684"),
			new BCData("data_063", Resources.testdata_063, "49"),
			new BCData("data_064", Resources.testdata_064, "1322"),
			new BCData("data_065", Resources.testdata_065, "272"),
			new BCData("data_067", Resources.testdata_067, "7273"),
			new BCData("data_068", Resources.testdata_068, "6531031914842725"),
			new BCData("data_069", Resources.testdata_069, "510510"),
			new BCData("data_070", Resources.testdata_070, "8319823"),
			new BCData("data_071", Resources.testdata_071, @"428570 /\n999997"),
			new BCData("data_076", Resources.testdata_076, "190569291"),
			new BCData("data_077", Resources.testdata_077, "71"),
			new BCData("data_079", Resources.testdata_079, "73162890"),
		};
	}
}
