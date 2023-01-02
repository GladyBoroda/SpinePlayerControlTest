using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove = 5;
    [SerializeField] private Rigidbody _rigidbody;
    public Transform Body;
    public bool Grounded;
    public SkeletonAnimation skeletonAnimation;
    #region Inspector
    // [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.
    [SpineAnimation]
    public string runAnimationName;

    [SpineAnimation]
    public string idleAnimationName;

    [SpineAnimation]
    public string walkAnimationName;

    [SpineAnimation]
    public string hoverboardAnimationName;

    [Header("Transitions")]
    [SpineAnimation]
    public string idleTurnAnimationName;

    [SpineAnimation]
    public string runToIdleAnimationName;

    public float runWalkDuration = 1.5f;
    #endregion

    private void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal") * _speedMove, 0);
        var input = Mathf.Abs(Input.GetAxis("Horizontal"));

        if (Grounded && input>0)
        {
            _rigidbody.velocity = new Vector2(inputVector.x, _rigidbody.velocity.y);
            Body.rotation = _rigidbody.velocity.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
            skeletonAnimation.AnimationName = walkAnimationName;
        }

        if (Grounded == false)
        {
            skeletonAnimation.AnimationName = hoverboardAnimationName;
        }

        if (input == 0 && Grounded)
        {
            skeletonAnimation.AnimationName = idleAnimationName;
        }
        Debug.Log(inputVector);
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Mathf.Abs(Vector3.Angle(collision.contacts[0].normal, Vector3.up));
        Grounded = angle > 30 ? false : true;
    }
}
