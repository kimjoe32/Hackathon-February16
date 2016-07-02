using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ModifyParticleEmission : MonoBehaviour {
    ParticleSystem[] ps;
    string[] s;
    
    public List<float> nums = new List<float>();
    int j=0;
    void Load()
    {
        StreamReader r = new StreamReader(@"Assets\nums.txt");
        s = r.ReadToEnd().Split(' ');
        for (int i = 0; i < s.Length; i++) nums.Add(float.Parse(s[i]));
    }

    void Start () {
        Load();
        ps = FindObjectsOfType(typeof(ParticleSystem)) as ParticleSystem[];
    }

    void Update () {
        foreach (ParticleSystem p in ps)
            p.Emit((int)nums[j]);
        j++;
        if (j >= s.Length) j = 0;
	}
}