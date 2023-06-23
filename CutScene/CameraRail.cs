using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class CameraRail : MonoBehaviour
{
    GameObject this_Camera;
    [SerializeField] Transform[] rail_Station;
    int rail_StationIndex=0;
    float camera_move_Speed=10;
    float camera_roll_Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        this_Camera = this.gameObject;
        this_Camera.transform.position = rail_Station[rail_StationIndex].position;
        this_Camera.transform.rotation = rail_Station[rail_StationIndex].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rail_Station_Line(rail_Station);
        camera_Move_and_Roll();
    }

    void camera_Move_and_Roll()
    {
        if (rail_StationIndex < rail_Station.Length)
        {
            check_Station(rail_StationIndex);
            if (this_Camera.transform.position == rail_Station[rail_StationIndex].position && this_Camera.transform.rotation == rail_Station[rail_StationIndex].rotation)
            {

                rail_StationIndex += 1;
            }
            else
            {
            this_Camera.transform.position = Vector3.MoveTowards(this_Camera.transform.position, rail_Station[rail_StationIndex].position, camera_move_Speed * Time.deltaTime);
            this_Camera.transform.rotation = Quaternion.Lerp(this_Camera.transform.rotation, rail_Station[rail_StationIndex].rotation, camera_roll_Speed * Time.deltaTime);
            }
        }
    }
    void check_Station(int station)
    {
        //0-1
        if(station==1)
        {
            camera_move_Speed = 10;
            camera_roll_Speed = camera_move_Speed/10;
        }
        //1-2:
        else if (station == 2)
        {
            camera_move_Speed = 20;
            camera_roll_Speed = camera_move_Speed / 20;
        }
        else if (station == 3)
        {
            camera_move_Speed = 50;
            camera_roll_Speed = camera_move_Speed / 5;
        }
        else if (station == 4)
        {
            camera_move_Speed = 30;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 5)
        {
            camera_move_Speed = 6;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 6)
        {
            camera_move_Speed = 100;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 7)
        {
            camera_move_Speed = 5;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 8)
        {
            camera_move_Speed = 2;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 9)
        {
            camera_move_Speed = 20;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 10)
        {
            camera_move_Speed = 0.5f;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else if (station == 11)
        {
            camera_move_Speed = 200;
            camera_roll_Speed = camera_move_Speed / 10;
        }
        else
        {
            camera_move_Speed = 10;
            camera_roll_Speed = camera_move_Speed / 10;
        }
    }

    void rail_Station_Line(Transform[] rail_Station)
    {
        for(int i=0;i<rail_Station.Length-1;i++)
        {
            Debug.DrawLine(rail_Station[i].position, rail_Station[i+1].position,Color.green);
        }
    }




}
