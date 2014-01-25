﻿using UnityEngine;
using System.Collections;

public class TestGridSpawn : MonoBehaviour {

	public GameObject OneDoor, TwoDoors, ThreeDoors, FourDoors;
    public int roughRoomCount = 30, roomSize = 30;

    private Vector3 zVec = new Vector3(0, 0, 1);
    private GameObject[] rooms;
    private int[] root = { 0, 0 };
    

	void Start () {
        rooms = new GameObject[] {OneDoor, TwoDoors, ThreeDoors, FourDoors};

        int rn = random(0, 4);
        Instantiate(rooms[1], 
            new Vector3(root[0], root[1], 0),
            Quaternion.AngleAxis(rn * 90, zVec));

        int[] coords = getXY(rn + 1);
        visited.Add("0 0");

        print("Exit init OK at 0, 0");
        spawnRooms(coords[0], coords[1], rn + 1);
        

        print("Actual number of rooms: " + roomCounter);
	}

    private int roomCounter = 1;
    private ArrayList visited = new ArrayList();
    //doorNum = Door you are coming out of; South, East, North, West
    void spawnRooms(int x, int y, int doorNum)
    {
        if (visited.Contains(x + " " + y))
        {
            print("Room already exists at " + x + " " + y);
            return;
        }
        visited.Add(x + " " + y);
        Vector3 spawn = new Vector3(x * roomSize, y * roomSize, 0);
        if(++roomCounter >= roughRoomCount){
            Instantiate(rooms[0], spawn, Quaternion.AngleAxis(((doorNum + 1) % 4) * 90, zVec));
            print("Instantiating dead room #" + roomCounter + " at coord " + x + " " + y + " Out: " + doorNum);
            return;
        }

        int numDoors = randomIndex();
        int r; int[] c;
        print("Instantiating room #" + roomCounter + " at coord " + x + " " + y + " Type: " + numDoors + " Out: " + doorNum);
        switch (numDoors)
        {
            case 0 :
                Instantiate(rooms[0], spawn, Quaternion.AngleAxis(((doorNum + 1) % 4) * 90, zVec));
                return;
            case 1 :
                r = (doorNum + (int)(Random.value * (doorNum - 2 < 0 ? 0 : doorNum - 2))) % 4;
                Instantiate(rooms[1], spawn, Quaternion.AngleAxis(r * 90, zVec));

                c = getXY(r + 1);
                spawnRooms(x + c[0], y + c[1], r + 1);

                c = getXY(r + 2);
                spawnRooms(x + c[0], y + c[1], r + 2);
                return;
            case 2 :
                r = (doorNum + (int)(Random.value * (4 - doorNum))) % 4;
                Instantiate(rooms[1], spawn, Quaternion.AngleAxis(r * 90, zVec));

                c = getXY(r + 1);
                spawnRooms(x + c[0], y + c[1], r + 1);

                c = getXY(r + 2);
                spawnRooms(x + c[0], y + c[1], r + 2);

                c = getXY(r + 3);
                spawnRooms(x + c[0], y + c[1], r + 3);
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
    int[] getXY(int dir)
    {
        switch (dir % 4)
        {
            case 0 :
                return new int[] { -1, 0};
            case 1 :
                return new int[] { 0, -1};
            case 2 :
                return new int[] { 1, 0};
            case 3 :
                return new int[] { 0, 1};
        }
        return new int[] { 0, 0 };
    }
    
}
