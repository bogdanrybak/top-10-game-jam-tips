using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
	public static T Instance
	{
		get { return _instance; }
	}
	
	static T _instance;
	
	protected virtual void Awake ()
	{
        _instance = (T)this;
    }
}