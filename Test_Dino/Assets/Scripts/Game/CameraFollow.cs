using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Camera follows the player
/// </summary>
public class CameraFollow : MonoBehaviour
{
    #region Constants

    private const float yOffset = 2.91f;
    private const float xOffset = 0;
    private const float zOffset = 2.533f;

    #endregion

    [SerializeField] private Player player;

    private float smoothness = 10;
    

    private void Update()
    {
        Vector3 targetVec = new Vector3(player.transform.position.x - xOffset, player.transform.position.y + yOffset,
            player.transform.position.z - zOffset);
        if (transform.position != targetVec)
        {
            transform.position = Vector3.Lerp(transform.position, targetVec, smoothness * Time.deltaTime);
        }
    }
}
