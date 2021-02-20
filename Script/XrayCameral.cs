using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayCameral : MonoBehaviour {

    public Transform tar;
    public List<Renderer> listLastRend = new List<Renderer>();
    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {

        for (int i = 0; i < listLastRend.Count; i++)
        {
        	if(listLastRend[i]!=null){
        		TransparencySet(listLastRend[i], 1.0f);
        	}
        }
        listLastRend.Clear();
        Vector3 tarDir = (tar.position - transform.position).normalized;
        Debug.DrawLine(tar.position, transform.position, Color.red);

        float tarDis = Vector3.Distance(tar.position, transform.position);
        RaycastHit[] listHitObj = Physics.RaycastAll(transform.position, tarDir, tarDis);
        // Debug.Log(listHitObj.Length);
        for (int i = 0; i < listHitObj.Length; i++)
        {
            RaycastHit hit = listHitObj[i];
            if (hit.transform == tar.transform)
            {
                continue;
            }
            if (hit.collider.tag == "Room" || hit.collider.tag == "Fog" || hit.collider.tag=="StartPosition"){
            	continue;
            }
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer)
            {
                listLastRend.Add(renderer);
                TransparencySet(renderer,0.3f);
                // Debug.Log(hit.collider.name);
            }
            foreach (Transform child in hit.transform)
			{
				if(child.gameObject.tag=="Door" || child.gameObject.tag == "Fog"){
					continue;
				}
			    Renderer renderer_child = child.gameObject.GetComponent<Renderer>();
			    if (renderer_child){
	                listLastRend.Add(renderer_child);
	                TransparencySet(renderer_child,0.15f);
	                // Debug.Log(hit.collider.name);
	            }
			}	
        }

    }

    void TransparencySet(Renderer renderer,float a)
    {
        renderer.material.shader = Shader.Find("Transparent/Diffuse");
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, a);
    }
}