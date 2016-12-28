using System;
using System.Numerics; 			// used for BigInteger
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LazyList
{
	class MainClass
	{
		#pragma warning disable 219

		static void FibonacciSeq()
		{
			var fibonacciFirst = Tuple.Create(new BigInteger(0), new BigInteger(1));
			var fibonacciSeq = LazyList<Tuple<BigInteger, BigInteger>>
				.Iterate(
					fibonacciFirst,
					f => Tuple.Create(f.Item2, f.Item1 + f.Item2))
				.Select(pair => pair.Item1);

			var fibo50 = fibonacciSeq.Take(50).Last();
			var fibo1000 = fibonacciSeq.Take(1000).Last();
			var fibo2000 = fibonacciSeq.Take(2000).Last();
		}

		static void NaturalSeq()
		{
			var naturalSeq = LazyList<Tuple<int, int>>
				.Iterate(1, n => n + 1);

			var natural5 = naturalSeq.ElementAt(4);
			var natural10 = naturalSeq.ElementAt(9);
		}

		#pragma warning restore 219

		public static void Main (string[] args)
		{
			FibonacciSeq();
			NaturalSeq();
		}
	}
}
