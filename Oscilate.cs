using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Oscilate : MonoBehaviour 
{
    public float MoveSpeed = 5.0f;
    public List<float> nums = new List<float>();
    public float frequency;  // Speed 
    float prev=0;
    private Vector3 axis, pos;
    public int j = 0;
    string[] s;

    private bool Load()
    {
        StreamReader r = new StreamReader(@"Assets\nums.txt");
        s = r.ReadToEnd().Split(' ');
        for (int i = 0; i < s.Length; i++) nums.Add(float.Parse(s[i]));
        return true;
    }
            
    void Start()
    {
        Load();
        pos = transform.position;
        axis = transform.right;  // May or may not be the axis you want
    }

    void Update()
    {
        if (j >= s.Length-1) j = 0;
        if ((Mathf.Sin(Time.time * frequency) * prev) < 0) j++;
        
        prev = Mathf.Sin(Time.time * frequency);
        pos += transform.up * Time.deltaTime * MoveSpeed;
        transform.position =pos + axis * Mathf.Sin(Time.time * frequency) * nums[j];
    }
}
