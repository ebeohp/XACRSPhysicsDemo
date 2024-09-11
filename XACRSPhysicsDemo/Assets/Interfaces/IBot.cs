using UnityEngine;

public interface IBot // Interface that all robot controllers use to operate based off of player input.
{
    void TurnClockwise();
    void TurnCounterClockwise();
    void MoveForward();
    void MoveBackward();
    void SpinUpWeapon();
    void SpinDownWeapon();

    void StopMove();
}