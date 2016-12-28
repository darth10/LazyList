using System;
using System.Collections;
using System.Collections.Generic;

namespace LazyList
{
	class LazyList<T> : IEnumerable<T>, IEnumerable
	{
		T _first;
		Lazy<LazyList<T>> _rest;

		public LazyList(T first, Lazy<LazyList<T>> rest)
		{
			_first = first;
			_rest = rest;
		}

		public T First { get { return _first; } }

		public LazyList<T> Rest { get { return _rest.Value; } }

		public static LazyList<U> Iterate<U>(U x, Func<U, U> f)
		{
//			return new LazyList<U>(x, new Lazy<LazyList<U>>(delegate
//					{
//						return Iterate(f, f(x));
//					}));

			return new LazyList<U>(x,
				new Lazy<LazyList<U>>(
					() => Iterate(f(x), f)));
		}

		public static LazyList<U> Repeat<U>(U x)
		{
//			return new LazyList<U>(x, new Lazy<LazyList<U>>(delegate
//					{
//						return Repeat(x);
//					}));

			return new LazyList<U>(x,
				new Lazy<LazyList<U>>(
					() => Repeat(x)));
		}

		#region IEnumerable[T] implementation

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new LazyListEnumerator<T>(this);
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new LazyListEnumerator<T>(this);
		}

		#endregion
	}
}
