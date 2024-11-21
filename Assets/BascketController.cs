using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BascketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("Apple！");
            this.aud.PlayOneShot(this.appleSE);

        }
        if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("Bomb！");
            this.aud.PlayOneShot(this.bombSE);

        }
        //Debug.Log("キャッチ！");
        Destroy(other.gameObject);
    }
}
