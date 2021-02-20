using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public static string curName="";
    public bool isCom=false;
    private GameController gameController;
	public List<GameObject> doors = new List<GameObject>();
    //public List<GameObject> items = new List<GameObject>();

    public int MonsterRemain;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controlObj = GameObject.FindWithTag("GameController");
        if(controlObj != null){
        	gameController = controlObj.GetComponent<GameController>();
        }
        if(controlObj == null){
        	Debug.Log("Cannot find 'GameController' script");
        }

        if(MonsterRemain==0){
            this.passRoom();
        }
        // this.passRoom();
        // MonsterRemain=length
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void passRoom(){
        this.isCom=true;
        openDoors();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player"){
            if (this.isCom==false){
                closeDoors();
            }else{
                openDoors();
            }
            curName=gameObject.name;
            this.gameController.ChangeRoom(gameObject);
        }
            // Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
            // Debug.Log(Time.time + ":当前房间名称：" + curName+ " 房间状态为："+this.isCom);
    }
    // void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    // {
    //     Debug.Log(Time.time + "留在触发器的对象是：" + other.gameObject.name);
    // }
    void OnTriggerExit(Collider other)
    {
        // Debug.Log(Time.time + "离开触发器的对象是：" + other.gameObject.name);
    }

//门相关操作
    // 添加门
    public void addDoor(string name){
        GameObject door=GameObject.Find(name);
        this.doors.Add(door);
    }

    public void openDoors(){
        foreach(GameObject door in doors){
            //BoxCollider m_Collider = door.GetComponent<BoxCollider>();
            //m_Collider.enabled=false;
            if(door != null){
                door.GetComponent<DoorControl>().openDoor();
            }
            
                // Debug.Log("door open!");
                // Debug.Log(isCom);
        }
    }

    public void closeDoors(){
        foreach(GameObject door in doors){
            //BoxCollider m_Collider = door.GetComponent<BoxCollider>();
            //m_Collider.enabled=true;
            if(door != null){
                door.GetComponent<DoorControl>().closeDoor();
            }
        }
    }

    public void MonsterReduce(){
        this.MonsterRemain--;
        if(MonsterRemain<=0){
            this.passRoom();
        }
    }
    // public void MoveToNextRoom(string name){
    // 	switch(name)
    // 	{
    // 		case("front"):  
    //         	gameController.ChangeRoom(gameObject, frontRoom);
    //         	break;
    //         case("right"):  
    //         	gameController.ChangeRoom(gameObject, rightRoom); 
    //         	break;
    //         case("left"):  
    //         	gameController.ChangeRoom(gameObject, leftRoom); 
    //         	break;
    //         case("behind"):  
    //         	gameController.ChangeRoom(gameObject, behindRoom);
    //         	break;
    //         default:
    //         	break;
    // 	}
    // }


}
