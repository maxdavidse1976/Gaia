using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator instance;

    [Header("Settings")]
    [Tooltip("The player controller script where we can find our state information")]
    [SerializeField] private Player player;

    [Tooltip("The animator controller for this player")]
    [SerializeField] private Animator playerAnimator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GetPlayerStateAndAnimate();
    }

    void Update()
    {
        GetPlayerStateAndAnimate();
    }

    private void GetPlayerStateAndAnimate()
    {
        if (playerAnimator == null)
        {
            return;
        }

        switch (player.state)
        {
            case Player.PlayerState.Idle:
                playerAnimator.Play("player_idle");
                break;
        }
    }
}
