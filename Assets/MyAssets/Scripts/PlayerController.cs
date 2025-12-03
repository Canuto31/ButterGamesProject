using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform myTransform;

    public float speed;
    private bool _isPressedMove = false;

    private float _positionX;
    private float _positionY;

    public GameObject projectile;
    public Transform objetive;

    public float health = 100f;

    private void Update()
    {
        if (_isPressedMove)
        {
            myTransform.position += new Vector3(_positionX, _positionY, 0) * (speed * Time.deltaTime);
        }

        objetive.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        myTransform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), objetive.position - myTransform.position);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _positionX = context.ReadValue<Vector2>().x;
            _positionY = context.ReadValue<Vector2>().y;
            _isPressedMove = true;
        }
        else if (context.canceled)
        {
            _isPressedMove = false;
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(projectile, myTransform.position, myTransform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.tag);
            health -= 10;
        }
        else if (collision.gameObject.CompareTag("Potion"))
        {
            Debug.Log(collision.gameObject.tag);
            health += 10;
            Destroy(collision.gameObject);
        }
    }
}