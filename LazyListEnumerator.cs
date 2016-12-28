using System;
using System.Collections;
using System.Collections.Generic;

namespace LazyList
{
	class LazyListEnumerator<T> : IEnumerator<T>, IEnumerator
	{
		LazyList<T> _next, _curr = null;

		public LazyListEnumerator(LazyList<T> parent)
		{
			_next = parent;
		}

		T Current
		{
			get
			{
				if (_curr == null)
					throw new InvalidOperationException();

				return _curr.First;
			}
		}

		#region IEnumerator<T> implementation

		T IEnumerator<T>.Current { get { return Current; } }

		#endregion

		#region IEnumerator implementation

		bool IEnumerator.MoveNext()
		{
			_curr = _next;
			_next = _next.Rest;

			return _curr != null;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException("Cannot reset a LazyList");
		}

		object IEnumerator.Current { get { return Current; } }

		#endregion

		#region IDisposable implementation

		void System.IDisposable.Dispose()
		{
		}

		#endregion
	}
}

