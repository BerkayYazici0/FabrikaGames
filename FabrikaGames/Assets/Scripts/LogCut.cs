using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool Cut(Transform victim, Vector3 _pos){
        Vector3 pos = new Vector3(victim.position.x,_pos.y,victim.position.z);
        Vector3 victimScale = victim.localScale;
        float distance = Vector3.Distance(victim.position,pos);
        if(distance >= victimScale.y/2) return false;

        Vector3 leftPoint = victim.position - Vector3.right * victimScale.y/2;
        Vector3 rightPoint = victim.position + Vector3.right * victimScale.y/2;
        Material mat = victim.GetComponent<MeshRenderer>().material;
        Destroy(victim.gameObject);
        Debug.Log("Kütük Kesildi.");

        GameObject rightSideObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject leftSideObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //rightSideObj.GetComponent<CapsuleCollider>().enabled = false;
        rightSideObj.transform.position = (rightPoint+pos)/2;
        float rightWidth = Vector3.Distance(pos,rightPoint);
        rightSideObj.transform.localScale = new Vector3(victimScale.x,rightWidth,victimScale.z);
        rightSideObj.AddComponent<Rigidbody>().mass = 1f;
        rightSideObj.GetComponent<MeshRenderer>().material = mat;        
        

        
        rightSideObj.transform.rotation = Quaternion.Euler(rightSideObj.transform.rotation.x,rightSideObj.transform.rotation.y,90);
        Destroy(rightSideObj,4);
        

        
        //leftSideObj.GetComponent<CapsuleCollider>().enabled = false;
        leftSideObj.transform.position = (leftPoint + pos)/2;
        float leftWidth = Vector3.Distance(pos,leftPoint);
        leftSideObj.transform.localScale = new Vector3( victimScale.x,leftWidth, victimScale.z);
        leftSideObj.AddComponent<Rigidbody>().mass = 1f;
        leftSideObj.GetComponent<MeshRenderer>().material = mat;
        

        
        leftSideObj.transform.rotation = Quaternion.Euler(leftSideObj.transform.rotation.x,leftSideObj.transform.rotation.y,90);
        Destroy(leftSideObj,4);
        
        

        return true; 
    }
    
}
