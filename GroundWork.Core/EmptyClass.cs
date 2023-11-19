using System;
using GroundWork.Core.Extensions;

namespace GroundWork.Core
{
	public class EmptyClass
	{
		public EmptyClass()
		{
			var list = new List<int>();

			list.ToJSON();


			var arr = new int[10];

			arr.ToJSON();

		}
	}
}

