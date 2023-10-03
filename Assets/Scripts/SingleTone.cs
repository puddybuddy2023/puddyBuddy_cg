using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제네릭 클래스로 구현한 싱글톤 
public class Singleton<T> where T : new()
{
    protected static T instance;

    protected static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}
