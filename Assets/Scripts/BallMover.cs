using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static Util;

public class BallMover : MonoBehaviour
{
    public float force = 64f;
    public float jumpForce = 640f;
    public Text countCoins;

    private Rigidbody rb;
    private int coins = 8;
    private bool canJump = true;
    private float imp = 1;

    public int numCoins()
    {
        return coins;
    }

    private void addCoin(int n)
    {
        coins += n;
        if (coins < 0) { coins = 0; }
        if (!isGameOver())
        {
            countCoins.text = "Player " + playerNum() + ": " + coins.ToString();
        }
    }

    private int playerNum()
    {
        return gameObject.name[gameObject.name.Length - 1] - '0';
    }

    private float getAxis(string axis)
    {
        return Input.GetAxis(axis + playerNum());
    }

    private void addForce(float impedance)
    {
        if (impedance > 0)
        {
            Vector3 push = getAxis("Vertical") * forward() + getAxis("Horizontal") * right();
            float boost = coins < 1024 ? Mathf.Sqrt(coins + 64) / 8f : 4f;
            rb.AddForce(push * force * impedance * boost);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addCoin(0);
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            addForce(imp);
        }
        else
        {
            addForce(0.2f);
        }

        if (Mathf.Abs(transform.position.x) > 24.75f || Mathf.Abs(15 - transform.position.z) > 25)
        {
            foreach (GameObject gObj in GameObject.FindGameObjectsWithTag("Wall"))
            {
                Destroy(gObj);
            }
            foreach (GameObject gObj in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (gObj != gameObject)
                {
                    Destroy(gObj);
                }
            }
            Camera.main.GetComponent<Follow>().setTarget(gameObject);
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Terrain"))
        {
            canJump = false;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Terrain") || collisionInfo.gameObject.CompareTag("Player"))
        {
            canJump = true;
            rb.AddForce(getAxis("Jump") * (jumpForce + coins) * collisionInfo.contacts[0].normal);
        }

        if (collisionInfo.gameObject.CompareTag("Terrain"))
        {
            Vector3 push = getAxis("Vertical") * forward() + getAxis("Horizontal") * right();
            imp = 0.8f + Vector3.Dot(push.normalized, collisionInfo.contacts[0].normal);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Wall"))
        {
            addCoin(-1);
        }
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            float diff = transform.position.y - collisionInfo.gameObject.transform.position.y;
            if (diff > 0.2f)
            {
                addCoin(4);
            }
            else if (diff < -0.2f)
            {
                addCoin(-4);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            addCoin(1);
        }
    }
}
