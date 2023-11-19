using System;
namespace GroundWork.Core.Tests
{
	[TestClass]
	public class StringExtensionTest
	{
		public StringExtensionTest()
		{
		}

		[TestMethod]
		public void tesT()
		{
			var s = "loRum IPsuM Lorum iPSUM";

            var t = s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();

			var a = 0;
        }
	}
}

