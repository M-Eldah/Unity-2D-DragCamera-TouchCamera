using UnityEngine;
public class CameraControl : MonoBehaviour
{

    //How large the drag area is 

    [Tooltip("how fast to move while an object is grabbed")]
    public float grabSpeed;
    [Tooltip("How Large the Grab Margin is in Pixels")]
    public float screenMargin;

    [Tooltip("How Responsive do you want it to be")]
    public float sensitivity;
    [Tooltip("Allows to select which movement the axis will be locked or allowed to move, set them to either 0 or one")]
    public Vector2 movementAxis;

    private Vector3 start,current;

    public Vector2 Min, Max;
    public static bool grab;
    // allows you to lock the movment while in menus
    public static bool locked;

    // Update is called once per frame
    void LateUpdate()
    {
      
        //getting the initial position of the mouse and the object
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
            current= transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            if (!locked)
            {
                //if in dragmode
                if(grab)
                {
                    current = transform.position;
                    //if you want only movement in one axis feel free to delete the other one
                    //Horizontal axis
                    if (Input.mousePosition.x<screenMargin)
                    {
                        transform.position -= new Vector3(grabSpeed * movementAxis.x, 0, 0);
                    }
                    if (Input.mousePosition.x > Screen.width-screenMargin)
                    {
                        transform.position += new Vector3(grabSpeed * movementAxis.x, 0, 0);
                    }
                    //vertical axis
                    if (Input.mousePosition.y < screenMargin)
                    {
                        transform.position -= new Vector3(0, grabSpeed * movementAxis.y, 0);
                    }
                    if (Input.mousePosition.y > Screen.height - screenMargin)
                    {
                        transform.position += new Vector3(0, grabSpeed * movementAxis.y, 0);
                    }
                }
                else
                {
                    Vector3 diffrence = Input.mousePosition - start;
                    Vector3 controlled = new Vector3(diffrence.x * movementAxis.x, diffrence.y * movementAxis.y);
                    //sensitivity is how much the camera object move per mouse mouse movement 
                    Vector3 newPos= current + controlled * sensitivity * -1;
                    transform.position = inLimits(newPos);

                }
               
            }
            
           
        }
        
    }
    private Vector3 inLimits(Vector3 location)
    {
        float x = location.x;
        float y = location.y;
        if(Min.x>location.x)
        {
            x = Min.x;
        }
        if (Min.y > location.y)
        {
            y = Min.y;
        }
        if (Max.x < location.x)
        {
            x = Max.x;
        }
        if (Max.y < location.y)
        {
            y = Max.y;
        }
        return new Vector3(x,y,location.z);
    }

}

            
           
        }
        
    }

}
