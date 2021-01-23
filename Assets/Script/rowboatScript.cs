using UnityEngine;
using System.Collections;

public class rowboatScript : MonoBehaviour {

    public float speed;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.rotation.z > 10 )
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, 9.5f, transform.rotation.w), Time.deltaTime * 2);
        }

        if (transform.rotation.z < -10)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, -9.5f, transform.rotation.w),Time.deltaTime * 2);
        }

        transform.position = new Vector3(transform.position.x, -4, transform.position.z);
    }

    public void changeDir(int dir)
    {
        if (dir == -1)
            transform.eulerAngles = new Vector2(0, 180);

        if (dir == 1)
            transform.eulerAngles = new Vector2(0, 0);
    }

    public void changeSpeed(float _speed)
    {
        this.speed = _speed;
    }
}
