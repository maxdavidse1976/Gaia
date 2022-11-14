using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The layers that are considered to be \"Ground\".")]
    [SerializeField] private LayerMask groundLayers = new LayerMask();
    [Tooltip("The collider to check with. (Defaults to the collider set on this game object.")]
    [SerializeField] private Collider2D groundCheckCollider = null;

    [Header("Effect Settings")]
    [Tooltip("The effect to create when landing on the ground")]
    private GameObject landingEffect;

    private bool groundedLastCheck = false;

    void Start()
    {
        GetCollider();
    }

    public void GetCollider()
    {
        if (groundCheckCollider == null)
        {
            groundCheckCollider = gameObject.GetComponent<Collider2D>();
        }
    }

    public bool CheckGrounded()
    {
        if (groundCheckCollider == null)
        {
            GetCollider();
        }

        // Find the colliders that overlap with this one
        Collider2D[] overlaps = new Collider2D[5];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.layerMask = groundLayers;
        groundCheckCollider.OverlapCollider(contactFilter, overlaps);

        // Check if one of the overlapping colliders is on the "ground" layer
        foreach(Collider2D overlapCollider in overlaps)
        {
            if (overlapCollider != null)
            {
                // This line determines if the collider found is on a layer in the ground layer mask
                int match = contactFilter.layerMask.value & (int)Mathf.Pow(2, overlapCollider.gameObject.layer);
                if (match > 0) 
                { 
                    if (landingEffect && !groundedLastCheck)
                    {
                        Instantiate(landingEffect, transform.position, Quaternion.identity, null);
                    }
                    groundedLastCheck = true;
                    return true;
                }
            }
        }
        groundedLastCheck = false;
        return false;
    }
}
