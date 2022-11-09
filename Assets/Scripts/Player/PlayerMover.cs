using UnityEngine;

public class PlayerMover : PhysicsObject
{
    public static PlayerMover instance;

    private void Awake()
    {
        instance = this;
    }
}
