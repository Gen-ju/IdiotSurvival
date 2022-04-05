using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private ConfigurableJoint hipJoint;
    [SerializeField] private Rigidbody hip;

    [SerializeField] private Animator targetAnimator;

    private float stunTime = 0f;

    private bool walk = false;
    private bool stun = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharactorMovement();
        StunCheck();
    }
    void CharactorMovement()
    {
        if (stun) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            this.hipJoint.targetRotation = Quaternion.Euler(0f, 0f, -targetAngle + 90f);

            this.hip.AddForce(direction * this.speed);

            this.walk = true;
        }
        else
        {
            this.walk = false;
        }

        this.targetAnimator.SetBool("Walk", this.walk);

    }

    void StunCheck()
    {
        if (stunTime >= 0)
        {
            stunTime -= Time.deltaTime;
            stun = true;
        }
        else
        {
            stunTime = 0;
            stun = false;
        }

        float E = hip.mass * Mathf.Pow(hip.velocity.magnitude, 2) * 0.5f;
        if (E > 200)
        {
            Stun(E);
        }
        Debug.Log(E);
    }
    void Stun(float E)
    {
        hip.AddForce(hip.velocity);
        stunTime = (E / 200);
    }
}