using UnityEngine;
using System.Collections;

public class FunctionScript : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void SpawnItem(GameObject item)
    {
        Instantiate(item);
    }

    public void SpawnItem(GameObject item,GameObject parrent)
    {
        Instantiate(item, parrent.transform);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
