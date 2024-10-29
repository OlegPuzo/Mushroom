using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    private bool _isGround; // ���������� ��������� �� �� �� �����
    private Vector3 _verticalVelocity; // ������ ��� ����������� ������� ��� ������

    public bool isGround => _isGround;

    public event UnityAction<string> UsedJumpAnimation; // �������� �������, ��� �� �����������

    // ����� �������� ����������, ���� �� ��������� �����
    public void OnTouchedGround(bool isGround) => _isGround = isGround;

    // ����� �������� ������������ ������, � ����� ��������� �� �� �� �����
    public void TryUseJump(KeyCode jumpKeyBoard, CharacterController controller, float gravity, float jumpForce)
    {
        TryFall(gravity);
        TryJump(jumpForce, jumpKeyBoard);

        controller.Move(_verticalVelocity * Time.deltaTime);
    }

    // �����, ����������� ����� �� �� ������
    private void TryFall(float gravity)
    {
        if (_isGround)
            _verticalVelocity.y = -gravity * Time.deltaTime;
        else
            _verticalVelocity.y -= gravity * Time.deltaTime;
    }

    // �����, ����������� ����� �� �� ��������
    private void TryJump(float jumpForce, KeyCode jumpKeyBoard)
    {
        if (_isGround && Input.GetKey(jumpKeyBoard))
        {
            _verticalVelocity.y = jumpForce;
            _isGround = false;

            UsedJumpAnimation?.Invoke(PlayerAnimation.NameJump);
        }
    }
}