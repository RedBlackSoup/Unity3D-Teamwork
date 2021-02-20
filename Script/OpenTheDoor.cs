using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{

// 	private GameObject CurrentRoom;
// 	private GameObject wall;
//     // Start is called before the first frame update
//     void Start()
//     {
//     	wall = this.transform.parent.gameObject; //获取当前对象的父对象
//         CurrentRoom = wall.transform.parent.gameObject;// 获取指定对象的父对象
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

	void OnTriggerEnter(Collider other)
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {
        Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(Time.time + "离开触发器的对象是：" + other.gameObject.name);
    }
//     void OnTriggerExit(Collider other){
//     	if(other.tag == "Player"){
//     		Room roomController=CurrentRoom.GetComponent<Room>();
//     		roomController.MoveToNextRoom(wall.name);
//     	}
//     }
}
