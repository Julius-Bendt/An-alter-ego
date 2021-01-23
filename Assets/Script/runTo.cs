using UnityEngine;
using System.Collections;

public class runTo : MonoBehaviour {

    public GameObject finish;
    public float speed;

    public bool camera;

    bool includeY;

    void Start()
    {

        if(!camera)
            GetComponent<Animator>().SetFloat("speed", 1);
    }


	void Update () {
        Vector3 pos;

        if (includeY)
            pos = new Vector3(finish.transform.position.x, finish.transform.position.y, transform.position.z);
        else
            pos = new Vector3(finish.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

	}

    public void setY(bool y)
    {
        includeY = y;
    }

    public void toggleY()
    {
        includeY = !includeY;
    }

    public void ChangePoint(Transform point)
    {
        finish = point.gameObject;
    }
}
