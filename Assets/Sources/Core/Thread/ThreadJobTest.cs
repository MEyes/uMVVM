using System;
using System.Collections;
using System.Threading;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class ThreadJobTest:MonoBehaviour
	{

	    public Image greenRect;
	    public Image pinkRect;

        ThreadJob job;

	    void Awake()
	    {
            job = new ThreadJob(
            () => {
                Debug.Log("Work Thread :" + Thread.CurrentThread.ManagedThreadId + " work!");
                //heavy job
                for (int i = 0; i < 12345; i++)
                {
                    for (int j = 0; j < 12345; j++)
                    {
                        var z = i + j;
                    }
                }
            },

            () => {
                Debug.Log("Down");
            });
        }
	
		void Start(){

            Debug.Log("Main Thread :"+Thread.CurrentThread.ManagedThreadId+" work!");
            StartCoroutine (Move());
		}

		IEnumerator Move()
		{

		    pinkRect.transform.DOLocalMoveX(250, 1.0f);
            yield return new WaitForSeconds(1);
		    pinkRect.transform.DOLocalMoveY(-150, 2);
            yield return new WaitForSeconds(2);
            //AI操作，陷入深思，在异步线程执行,GreenRect不会卡顿
            job.Start();
            yield return StartCoroutine (job.WaitFor());
            pinkRect.transform.DOLocalMoveY(150, 2);

        }

		void Update()
		{
           greenRect.transform.Rotate(Vector3.left, Time.deltaTime * 180);
		}
	}
}

