# Unity impelmentation of third person view by [Brackeys](https://www.youtube.com/watch?v=4HpC--2iowE&list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6&index=63)


## 1. Movement [script](Assets/Scripts/Player/Player_ThirdPerson_Script.cs)
```cs
using UnityEngine;

public class Player_ThirdPerson_Script : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        }
    }
}
```

## 2. Сamera collision detection:

![alt text](https://github.com/Chu-4hun/SecondJournal/blob/8c28f04dfd13c6fa2150b16a50cb6818edcb4fd3/transition.gif)
