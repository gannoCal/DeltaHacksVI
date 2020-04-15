//Script placed on bus

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class busMovement : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public Sprite greyUpArrow;
    public Sprite greyDownArrow;
    public Sprite greyRightArrow;
    public Sprite greyLeftArrow;
    public Sprite blackUpArrow;
    public Sprite blackDownArrow;
    public Sprite blackRightArrow;
    public Sprite blackLeftArrow;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            Vector2 touchPositionCam = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition = new Vector2(touchPositionCam.x, touchPositionCam.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);

            if (hitInformation.collider.name == upArrow.GetComponent<PolygonCollider2D>().name)//Increase upwards velocity
            {
                upArrow.GetComponent<SpriteRenderer>().sprite = greyUpArrow;
                downArrow.GetComponent<SpriteRenderer>().sprite = blackDownArrow;
                leftArrow.GetComponent<SpriteRenderer>().sprite = blackLeftArrow;
                rightArrow.GetComponent<SpriteRenderer>().sprite = blackRightArrow;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x + 0.5f*Mathf.Sin(-transform.eulerAngles.z*Mathf.PI/180), ((float)(gameObject.GetComponent<Rigidbody2D>().velocity.y) + 0.5f*Mathf.Cos(-transform.eulerAngles.z * Mathf.PI / 180)));
            }
            else if (hitInformation.collider.name == downArrow.GetComponent<PolygonCollider2D>().name)//Increase downwards velocity
            {
                downArrow.GetComponent<SpriteRenderer>().sprite = greyDownArrow;
                upArrow.GetComponent<SpriteRenderer>().sprite = blackUpArrow;
                leftArrow.GetComponent<SpriteRenderer>().sprite = blackLeftArrow;
                rightArrow.GetComponent<SpriteRenderer>().sprite = blackRightArrow;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x - 0.5f * Mathf.Sin(-transform.eulerAngles.z * Mathf.PI / 180), ((float)(gameObject.GetComponent<Rigidbody2D>().velocity.y) - 0.5f * Mathf.Cos(-transform.eulerAngles.z * Mathf.PI / 180)));
            }
            else if (hitInformation.collider.name == rightArrow.GetComponent<PolygonCollider2D>().name)//Rotate right
            {
                //gameObject.GetComponent<Transform>().rotation.x = gameObject.GetComponent<Transform>().rotation.x + 1;
                //gameObject.GetComponent<Transform>().eulerAngles = new Vector3(gameObject.GetComponent<Transform>().rotation.x, gameObject.GetComponent<Transform>().rotation.y, gameObject.GetComponent<Transform>().rotation.z - 1);
                /*var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = gameObject.GetComponent<Transform>().rotation.z-100;
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(rotationVector);*/
                rightArrow.GetComponent<SpriteRenderer>().sprite = greyRightArrow;
                upArrow.GetComponent<SpriteRenderer>().sprite = blackUpArrow;
                leftArrow.GetComponent<SpriteRenderer>().sprite = blackLeftArrow;
                downArrow.GetComponent<SpriteRenderer>().sprite = blackDownArrow;
                float z_rotate = transform.eulerAngles.z - 1;

                transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, z_rotate);
                
                var x = gameObject.GetComponent<Rigidbody2D>().velocity.x;
                var y = gameObject.GetComponent<Rigidbody2D>().velocity.y;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((x * Mathf.Cos(-Mathf.PI/180)) - (y * Mathf.Sin(-Mathf.PI / 180)), (x * Mathf.Sin(-Mathf.PI / 180)) + (y * Mathf.Cos(-Mathf.PI / 180)));
                //gameObject.GetComponent<Rigidbody2D>().velocity
            }
            else if (hitInformation.collider.name == leftArrow.GetComponent<PolygonCollider2D>().name)//Rotate left
            {
                //gameObject.GetComponent<Transform>().eulerAngles = new Vector3(gameObject.GetComponent<Transform>().rotation.x, gameObject.GetComponent<Transform>().rotation.y, gameObject.GetComponent<Transform>().rotation.z + 1);
                /*var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z = gameObject.GetComponent<Transform>().rotation.z + 100;
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(rotationVector);*/
                leftArrow.GetComponent<SpriteRenderer>().sprite = greyLeftArrow;
                upArrow.GetComponent<SpriteRenderer>().sprite = blackUpArrow;
                rightArrow.GetComponent<SpriteRenderer>().sprite = blackRightArrow;
                downArrow.GetComponent<SpriteRenderer>().sprite = blackDownArrow;
                float z_rotate = transform.eulerAngles.z + 1;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z_rotate);
                
                var x = gameObject.GetComponent<Rigidbody2D>().velocity.x;
                var y = gameObject.GetComponent<Rigidbody2D>().velocity.y;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((x * Mathf.Cos(Mathf.PI / 180)) - (y * Mathf.Sin(Mathf.PI / 180)), (x * Mathf.Sin(Mathf.PI / 180)) + (y * Mathf.Cos(Mathf.PI / 180)));
            }

            Debug.Log(hitInformation.collider.name);
        }
        else
        {
            leftArrow.GetComponent<SpriteRenderer>().sprite = blackLeftArrow;
            upArrow.GetComponent<SpriteRenderer>().sprite = blackUpArrow;
            rightArrow.GetComponent<SpriteRenderer>().sprite = blackRightArrow;
            downArrow.GetComponent<SpriteRenderer>().sprite = blackDownArrow;
        }
    }
}
