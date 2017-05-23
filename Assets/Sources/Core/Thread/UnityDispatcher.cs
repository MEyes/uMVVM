using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

namespace AssemblyCSharp
{
	public class UnityDispatcher:MonoBehaviour
	{
		//Singletion
		private UnityDispatcher _current;
		public static UnityDispatcher Current {
			get;
			private set;
		}

		private int _lock;
		private bool _run;
		private Queue<Action> _wait;

		public void BeginInvoke(Action action){
			while (true) {
				//以原子操作的形式，将 32 位有符号整数设置为指定的值并返回原始值。
				if (0 == Interlocked.Exchange (ref _lock, 1)) {
					//acquire lock
					_wait.Enqueue(action);
					_run = true;
					//exist
					Interlocked.Exchange (ref _lock,0);
					break;
				}
					
			}
				
		}

		 void Awake(){

			if (Current != null) {
				Destroy (Current);
			}

			Current = this;
			_wait = new Queue<Action> ();
		}

		 void Update(){
		
			if (_run) {
				Queue<Action> execute = null;
				//主线程不推荐使用lock关键字，防止block 线程，以至于deadlock
				if (0 == Interlocked.Exchange (ref _lock, 1)) {
				
					execute = new Queue<Action>(_wait.Count);

					while(_wait.Count!=0){

						Action action = _wait.Dequeue ();
						execute.Enqueue (action);

					}
					//finished
					_run=false;
					//release
					Interlocked.Exchange (ref _lock,0);
				}
				//not block
				if (execute != null) {
				
					while (execute.Count != 0) {
					
						Action action = execute.Dequeue ();
						action ();
					}
				}
			
			}
		}
	}
}

