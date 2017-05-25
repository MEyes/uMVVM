using System;
using System.Collections;
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
                //heavy job
                for (int i = 0; i < 12345; i++)
                {

                }
            },

            () => {
                Debug.Log("结束了");
            });
        }
	
		void Start(){

			StartCoroutine (Go());
		}

		IEnumerator Go()
		{

		    pinkRect.transform.DOLocalMoveX(250, 1.0f);
            yield return new WaitForSeconds(1);
		    pinkRect.transform.DOLocalMoveY(-150, 2);
            yield return new WaitForSeconds(2);

            //yield return StartCoroutine (job.WaitFor());

		}

		void Update()
		{
           greenRect.transform.Rotate(Vector3.left, Time.deltaTime * 180);
		}
	}
}

