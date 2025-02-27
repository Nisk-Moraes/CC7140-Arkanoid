using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class mudarnivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string proxnivel = null;
    public int espera = 20;
    void Start()
    {
        
        
        //wait por alguns segs
        StartCoroutine(Teleporte());
        
        
    }
    // Update is called once per frame
    IEnumerator Teleporte(){
        yield return new WaitForSeconds(espera);
        SceneManager.LoadScene(proxnivel);
    }
}
