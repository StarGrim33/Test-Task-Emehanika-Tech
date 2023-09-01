using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public bool Tap { get; private set; }

    public bool SwipeLeft { get; private set; }

    public bool SwipeRight { get; private set; }

    public bool SwipeUp { get; private set; }

    public bool SwipeDown { get; private set; }

    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        if (GameStateHandler.Instance.CurrentGameState == GameState.Pause)
            return;

        Tap = SwipeDown = SwipeUp = SwipeLeft = SwipeRight = false;

        ProcessInput();
        CalculateSwipe();

        if (swipeDelta.magnitude > 100)
        {
            DetermineSwipeDirection();
            ResetSwipeData();
        }
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            ResetSwipeData();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                ResetSwipeData();
            }
        }
    }

    private void CalculateSwipe()
    {
        swipeDelta = Vector2.zero;

        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
    }

    private void DetermineSwipeDirection()
    {
        float x = swipeDelta.x;
        float y = swipeDelta.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
                SwipeLeft = true;
            else
                SwipeRight = true;
        }
        else
        {
            if (y < 0)
                SwipeDown = true;
            else
                SwipeUp = true;
        }
    }

    private void ResetSwipeData()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
