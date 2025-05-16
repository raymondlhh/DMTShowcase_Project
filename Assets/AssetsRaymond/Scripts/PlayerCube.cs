using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCube : MonoBehaviourPun
{
    public float moveSpeed = 0.5f;

    public void Move(Vector3 dir)
    {
        if (!photonView.IsMine) return; // Only allow movement by the owning player
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void MoveUp() => Move(Vector3.up);
    public void MoveDown() => Move(Vector3.down);
    public void MoveForward() => Move(Vector3.forward);
    public void MoveBackward() => Move(Vector3.back);
    public void MoveLeft() => Move(Vector3.left);
    public void MoveRight() => Move(Vector3.right);
}

