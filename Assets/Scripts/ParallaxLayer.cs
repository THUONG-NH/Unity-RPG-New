using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform background;
    [SerializeField] private float parallaxMultiplier;

    public void Move(float moveDistance)
    {
        background.position += Vector3.right * (moveDistance * parallaxMultiplier);
    }
}
