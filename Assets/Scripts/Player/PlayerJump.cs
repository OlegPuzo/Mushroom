using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    private bool _isGround; // Определяет находимся ли мы на земле
    private Vector3 _verticalVelocity; // Вектор для определения позиции при прыжке

    public bool isGround => _isGround;

    public event UnityAction<string> UsedJumpAnimation; // Передает событие, что мы подпрыгнули

    // Метод получает информацию, если мы каснулись земли
    public void OnTouchedGround(bool isGround) => _isGround = isGround;

    // Метод проверок относительно прыжка, а также находимся ли мы на земле
    public void TryUseJump(KeyCode jumpKeyBoard, CharacterController controller, float gravity, float jumpForce)
    {
        TryFall(gravity);
        TryJump(jumpForce, jumpKeyBoard);

        controller.Move(_verticalVelocity * Time.deltaTime);
    }

    // Метод, проверяющий можем ли мы упасть
    private void TryFall(float gravity)
    {
        if (_isGround)
            _verticalVelocity.y = -gravity * Time.deltaTime;
        else
            _verticalVelocity.y -= gravity * Time.deltaTime;
    }

    // Метод, проверяющий можем ли мы прыгнуть
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