using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{	
	private CameraController CameraController;
	private GameObject[] rooms;
	private GameObject currentRoom;
    private GameObject currentRoomObj;
    public GameObject bat;
    // public Hashtable ht = new Hashtable(); //创建一个Hashtable实例

    // Start is called before the first frame update
    void Start()
    {
    	GameObject CameraObj = GameObject.FindWithTag("MainCamera");
    	if(CameraObj != null){
       		CameraController = CameraObj.GetComponent<CameraController>();
        }
        if(CameraObj == null){
       		Debug.Log("Cannot find 'CameraController' script");
        }
    //    rooms=GameObject.FindGameObjectsWithTag("Room"); 
    //    for (int i=0; i<rooms.Length; i++)
    //    {
    //        rooms[i].SetActive(false); //隐藏对象
    //    }
        bat = GameObject.FindWithTag("BatPBR");
        currentRoom=GameObject.FindWithTag("StartPosition");
    }

    // Update is called once per frame
    void Update()
    {
        // currentRoomObj = GameObject.Find(Room.curName);
        // if (Input.GetKeyDown (KeyCode.A))
        // {
        //     Debug.Log("A按下一次");

        //     Room roomScript;
        //     if(currentRoomObj != null){
        //         roomScript = currentRoomObj.GetComponent<Room>();
        //         roomScript.passRoom();
        //     }else{
        //         Debug.Log("Cannot find "+Room.curName+"script");
        //     }
        // }
        // if(currentRoomObj != null){
        //     CameraController.roomCenter=currentRoomObj;
        // }
    }

    public void ChangeRoom(GameObject next){
    	GameObject bat = GameObject.FindWithTag("BatPBR");
    	if(bat!=null){ 
            Vector3 offset=new Vector3(0,-2.5f,0);
    		iTween.MoveTo(bat,next.transform.position+offset,1.5f);
    	}
    	CameraController.ChangeCenter(next);
    	currentRoom=next;

    	// this.Invoke("closeRoom",0.8f); //invoke 延迟触发
    }





    //  没用的部分
    private void closeRoom(){
    	currentRoom.SetActive(false);
    	Debug.Log("执行延时方法：关闭当前房间");
    }
}



