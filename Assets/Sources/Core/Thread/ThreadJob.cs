using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadJob 
{
	private volatile bool _isDown;
	private Thread _thread;

	private Action _onBeginHandler;
	private Action _onFinishHandler;

	public ThreadJob(Action onBeginHandler,Action onFinishedHandler)
	{
		this._onBeginHandler = onBeginHandler;
		this._onFinishHandler = onFinishedHandler;
	}

	public virtual void Start(){
		_thread = new Thread (Run);
		_thread.Start ();
	}

	public virtual void Abort(){
		_thread.Abort ();
	}

	public void ThreadHandler(){
		if(this._onBeginHandler!=null){
			this._onBeginHandler ();
		}
	}

	public void OnFinished(){
		if(this._onFinishHandler!=null){
			this._onFinishHandler ();
		}
	}

	public virtual bool Update(){
		if(_isDown){
			OnFinished ();
			return true;

		}
		return false;
	}
	public IEnumerator WaitFor(){
		while(!Update()){
			//暂停协同程序，下一帧再继续往下执行
			yield return null;
		}
	}
	private void Run(){
		ThreadHandler ();
		_isDown = true;
	}
}
