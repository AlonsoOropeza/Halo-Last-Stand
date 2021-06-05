using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;
    private static bool _isShuttingDown;
    private static object _lockObject = new object();

    public static T Instance {
        get {
            if(!_isShuttingDown){
                lock(_lockObject) {
                    if(_instance == null) {
                        var singletonGameObject = new GameObject();
                        _instance = singletonGameObject.AddComponent<T>();
                        DontDestroyOnLoad(singletonGameObject);
                    } else {
                        return _instance;
                    }
                }
            } 
            return null;
        }
    }

    private void OnApplicationQuit() {
        _isShuttingDown = true;
    }
    private void OnDestroy() {
        _isShuttingDown = true;
    }
}