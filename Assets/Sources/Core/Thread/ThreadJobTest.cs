using System;
using System.Collections;
using UnityEngine;
namespace AssemblyCSharp
{
	public class ThreadJobTest:MonoBehaviour
	{
		
		ThreadJob job;
		bool stop;
		void Start(){

			job= new ThreadJob (
				() => {
					//heavy job
					for(int i=0;i<12345;i++){

						Debug.Log(i);
					}
				},
			
				() => {
					Debug.Log("结束了");
				});
			job.Start ();

//			for(int i=0;i<12345;i++){
//
//				Debug.Log(i);
//			}
//
			StartCoroutine (Wait());
		}

		IEnumerator Wait(){

			yield return StartCoroutine (job.WaitFor());

			stop = true;

		}

		void Update()
		{
			
			if (!stop) {
				// rotate cube to see if main thread has been blocked;
				transform.Rotate(Vector3.up, Time.deltaTime * 180);
			}
		}
	}
}

