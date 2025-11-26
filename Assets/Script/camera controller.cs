using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] players;
    public Vector3 offset;
    public float speed;

    private Rigidbody[] playerRbs;

    void Start()
    {
        playerRbs = new Rigidbody[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playerRbs[i] = players[i].GetComponent<Rigidbody>();
        }
    }

    void LateUpdate()
    {
        Transform player = players[0];
        Rigidbody playerrb = playerRbs[0];

        Vector3 playerForward = (playerrb.velocity + player.transform.forward).normalized;
        transform.position = Vector3.Lerp(
            transform.position,
            player.position + player.transform.TransformVector(offset) + playerForward * (-5f),
            speed * Time.deltaTime
        );
        transform.LookAt(player);
    }
}
