using System;
using UnityEngine;

namespace Kalkatos.DottedArrow {
    public class Arrow : MonoBehaviour {
        [SerializeField] private float maxDragDistance = 3.5f;
        [SerializeField] private SpriteRenderer throwBoundariesCircle;
        private float dragDistance = 0f;

        public Transform Origin {
            get { return origin; }
            set { origin = value; }
        }

        [SerializeField] private float baseHeight;
        [SerializeField] private RectTransform baseRect;
        [SerializeField] private Transform origin;
        [SerializeField] private bool startsActive;

        Vector2 originPosOnScreen;
        Vector2 differenceToMouse;

        Vector3 endDragPoint = Vector3.zero;
        private RectTransform myRect;
        private Canvas canvas;
        private Camera mainCamera;
        private bool isActive;

        private void Awake() {
            myRect = (RectTransform)transform;
            canvas = GetComponentInParent<Canvas>();
            mainCamera = Camera.main;
            SetActive(startsActive);

            GameManager.OnGameStateChange += SetVisibleArrowOnState;
        }

        private void OnDestroy() {
            GameManager.OnGameStateChange -= SetVisibleArrowOnState;
        }

        private void SetVisibleArrowOnState(GameManager.GameState state) {
            gameObject.SetActive(state is GameManager.GameState.InGame);
            throwBoundariesCircle.gameObject.SetActive(state is GameManager.GameState.InGame);
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0))
                SetupAndActivate(origin);
            else if (Input.GetMouseButtonUp(0))
                Deactivate();

            if (!isActive)
                return;
            Setup();
        }

        private void Setup() {
            if (origin == null)
                return;
            originPosOnScreen = mainCamera.WorldToScreenPoint(origin.GetComponent<Collider2D>().bounds.center);
            myRect.anchoredPosition =
                new Vector2(originPosOnScreen.x - Screen.width / 2, originPosOnScreen.y - Screen.height / 2) /
                canvas.scaleFactor;
            endDragPoint = Input.mousePosition;
            // -----------------------------------------
            // Debug.Log("End drag Vector " + endDragPoint);
            differenceToMouse = (endDragPoint - (Vector3)originPosOnScreen);
            // Debug.Log("Diff Vector + " + differenceToMouse);


            dragDistance = Mathf.Min(Vector3.Distance(endDragPoint, originPosOnScreen), maxDragDistance);
            var color = throwBoundariesCircle.color;
            color = new Color(color.r, color.g, color.b, dragDistance / (maxDragDistance * 16));
            throwBoundariesCircle.color = color;

            // Debug.Log("The Drag Distance is => " + dragDistance);
            differenceToMouse = differenceToMouse.normalized * dragDistance;

            // ----------------------------------------------
            differenceToMouse.Scale(new Vector2(1f / myRect.localScale.x, 1f / myRect.localScale.y));
            transform.up = differenceToMouse;
            baseRect.anchorMax = new Vector2(baseRect.anchorMax.x,
                differenceToMouse.magnitude / canvas.scaleFactor / baseHeight);
        }

        private void SetActive(bool b) {
            isActive = b;
            if (b)
                Setup();
            baseRect.gameObject.SetActive(b);
        }

        public void Activate() => SetActive(true);

        public void Deactivate() {
            SetActive(false);
            var color = throwBoundariesCircle.color;
            throwBoundariesCircle.color = new Color(color.r, color.g, color.b, 0f);
        }

        public void SetupAndActivate(Transform origin) {
            Origin = origin;
            Activate();
        }
    }
}