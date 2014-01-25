using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject OneDoor, TwoDoors, ThreeDoors, FourDoors;
    public int exitX = 0, exitY = 0, roughRoomCount = 30, roomSize = 30;

    private const Vector3 zVec = new Vector3(0, 0, 1);
    private GameObject[] rooms;
    private int[] root = { 0, 0 };
    

	void Start () {
        rooms = new GameObject[] {OneDoor, TwoDoors, ThreeDoors, FourDoors};

        int rn = random(0, 4);
        Instantiate(rooms[1], 
            new Vector3(root[0], root[1], 0),
            Quaternion.AngleAxis(rn * 90, zVec));

        spawnRooms(
            rn == 1 ? -1 : (rn == 3 ? 1 : 0), 
            rn == 0 ? -1 : (rn == 2 ? 1 : 0), 
            rn + (int)(Random.value * 2));

        print("Actual number of rooms: " + roomCounter);
	}

    private int roomCounter = 0;
    //doorNum = Door you are coming out of; South, East, North, West
    void spawnRooms(int x, int y, int doorNum)
    {

        Vector3 spawn = new Vector3(x * roomSize, y * roomSize, 0);
        if(roomCounter++ >= roughRoomCount){
            Instantiate(rooms[0], spawn, Quaternion.AngleAxis((doorNum + 1) % 4 * 90, zVec));
            return;
        }

        int numDoors = randomIndex();
        switch (numDoors)
        {
            case 0 :
                Instantiate(rooms[0], spawn, Quaternion.AngleAxis((doorNum + 1) % 4 * 90, zVec));
                return;
            case 1 :
                int r = (doorNum + (int)(Random.value * 2)) % 4;
                Instantiate(rooms[1], spawn, Quaternion.AngleAxis(r * 90, zVec));
                int x = (r == 0 ? 0
                spawnRooms(
                    x + (r == 0 ),
                    , 
                    r + 1);
                spawnRooms(
                    ,
                    ,
                    r + 2);
                return;
            case 2 :

                
                return;
            case 3 :
                Instantiate(rooms[3], spawn, Quaternion.identity);
                spawnRooms(x, y - 1, 1);
                spawnRooms(x + 1, y, 2);
                spawnRooms(x, y + 1, 3);
                spawnRooms(x - 1, y, 4);
                return;
        }
    }
    int randomIndex()
    {
        return (int)(Random.value * rooms.Length);
    }
    int random(int start, int end)
    {
        return ((int)(Random.value * (end - start)) + start);
    }
    
}
