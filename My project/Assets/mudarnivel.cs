using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class mudarnivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string proxnivel = null;
    
    void Start()
    {
        
        
        //wait por alguns segs
        SceneManager.LoadScene(proxnivel);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
