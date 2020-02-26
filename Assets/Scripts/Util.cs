using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    private static bool gameOver = false;

    public static Vector3 forward()
    {
        return Vector3.Normalize(Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up));
    }

    public static Vector3 backward()
    {
        return -forward();
    }

    public static Vector3 right()
    {
        return Vector3.Normalize(Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up));
    }

    public static Vector3 left()
    {
        return -right();
    }

    public static bool isGameOver()
    {
        return gameOver;
    }

    public static void setGameOver(bool val)
    {
        gameOver = val;
    }
}
