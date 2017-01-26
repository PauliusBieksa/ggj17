using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{


    [SerializeField]
    GameObject dot;

    List<GameObject> dots = new List<GameObject>();

    [SerializeField]
    GameObject up;
    [SerializeField]
    GameObject down;
    [SerializeField]
    GameObject left;
    [SerializeField]
    GameObject right;

    DialTurn dial;

    [SerializeField]
    GameObject parent;

    private float height;
    private float yzero;
    public float screenSpeed;

    float old;

    private float amplitude = 0.6f;
    public float frequency = 2.0f;
    public int frqc = 0;

    private float offset = 0.0f;
    private float lastPies;
    private float lastFrq;

    private float ir = 2f;
    private float v = 3.5f;
    private float uv = 5.2f;



    // Use this for initialization
    void Start()
    {
        height = (up.transform.position.y - down.transform.position.y) / 2;
        yzero = up.transform.position.y - height;
        old = Time.fixedTime;
        screenSpeed = (right.transform.position.x - left.transform.position.x) / 80.0f;

        lastFrq = frequency;


        dial = GameObject.Find("Dial left").GetComponent<DialTurn>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - old > 0.01f)
        {
            float sinPos = 0;

            dial.GoalIndex = frqc;

            switch (frqc)
            {
                case 0:
                    sinPos = 0;
                    frequency = 0;
                    offset = 0;
                    break;
                case 1:
                    // offset has to be calculated when frequency is known
                    frequency = ir;
                    if (lastFrq != frequency)
                    {
                        offset = lastPies - Mathf.PI * Time.fixedTime * frequency;
                    }
                    sinPos = Mathf.Sin(Mathf.PI * Time.fixedTime * frequency + offset);
                    break;
                case 2:
                    // offset has to be calculated when frequency is known
                    frequency = v;
                    if (lastFrq != frequency)
                    {
                        offset = lastPies - Mathf.PI * Time.fixedTime * frequency;
                    }
                    sinPos = Mathf.Sin(Mathf.PI * Time.fixedTime * frequency + offset);
                    break;
                case 3:
                    // offset has to be calculated when frequency is known
                    frequency = uv;
                    if (lastFrq != frequency)
                    {
                        offset = lastPies - Mathf.PI * Time.fixedTime * frequency;
                    }
                    sinPos = Mathf.Sin(Mathf.PI * Time.fixedTime * frequency + offset);
                    break;
                case 4:
                    frequency = ir + v;
                    sinPos = (Mathf.Sin(Mathf.PI * Time.fixedTime * ir) + Mathf.Sin(Mathf.PI * Time.fixedTime * v)) * 0.7f;
                    break;
                case 5:
                    frequency = ir + uv;
                    sinPos = (Mathf.Sin(Mathf.PI * Time.fixedTime * ir) + Mathf.Sin(Mathf.PI * Time.fixedTime * uv)) * 0.7f;
                    break;
                case 6:
                    frequency = v + uv;
                    sinPos = (Mathf.Sin(Mathf.PI * Time.fixedTime * v) + Mathf.Sin(Mathf.PI * Time.fixedTime * uv)) * 0.7f;
                    break;
                case 7:
                    sinPos = (Mathf.Sin(Mathf.PI * Time.fixedTime * ir) + Mathf.Sin(Mathf.PI * Time.fixedTime * v) + Mathf.Sin(Mathf.PI * Time.fixedTime * uv)) * 0.6f;
                    frequency = ir + v +uv;
                    break;
            }

            dots.Add(Instantiate(dot, new Vector3(right.transform.position.x, yzero + sinPos * height * amplitude, 0.0f), new Quaternion()));
            dots[dots.Count - 1].transform.SetParent(parent.transform);
            moveDots();
            old = Time.fixedTime;

            lastFrq = frequency;
            lastPies = Mathf.PI * Time.fixedTime * frequency + offset;
            while (lastPies > Mathf.PI * 2)
                lastPies -= Mathf.PI * 2;
        }
    }
    

    private void moveDots()
    {
        for (int i = 0; i < dots.Count; ++i)
        {
            dots[i].transform.position -= new Vector3(screenSpeed, 0.0f, 0.0f);
        }
        if (dots[0].transform.position.x < left.transform.position.x)
        {
            Destroy(dots[0]);
            dots.Remove(dots[0]);
        }
    }
    
}
