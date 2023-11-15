using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Move_Speed = 6;
    public float Left_Right_Speed = 4;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Move_Speed, Space.World);

        if( Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow) ) )
        {
            if (this.gameObject.transform.position.x > Level_Boundary.Left_Side)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Left_Right_Speed, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            if (this.gameObject.transform.position.x < Level_Boundary.Right_Side)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Left_Right_Speed, Space.World);
            }
        }
    }
}
