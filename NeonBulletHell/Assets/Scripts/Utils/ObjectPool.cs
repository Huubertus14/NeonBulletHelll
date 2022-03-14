using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
	private Queue<T> _pool;

	public ObjectPool(GameObject monoBehaviour, int poolSize, HideFlags hideFlag = HideFlags.None)
	{
		_pool = new Queue<T>();

		for(int i = 0; i < poolSize; i++)
		{
			GameObject g = Object.Instantiate(monoBehaviour.gameObject);
			g.hideFlags = hideFlag;
			_pool.Enqueue(g.GetComponent<T>());
			g.SetActive(false);
		}
	}

	public T GetPoolObject()
	{
		if(_pool.Count > 0)
		{
			T poolObject = _pool.Dequeue();
			poolObject.gameObject.SetActive(false);
			poolObject.gameObject.SetActive(true);
			_pool.Enqueue(poolObject);
			return poolObject;
		}
		return null;
	}

	public void Dispose()
	{
		foreach(T item in _pool)
		{
			Object.Destroy(item);
		}

		/*T obj = _pool.Dequeue();
		while(obj != null)
		{
			Object.Destroy(obj);
			obj = _pool.Dequeue();
		}*/
	}
}
