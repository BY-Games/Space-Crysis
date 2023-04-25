using UnityEngine;

namespace Kalkatos.DottedArrow
{
	public class Arrow : MonoBehaviour
    {
		public Transform Origin { get { return origin; } set { origin = value; } }

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

		private void Awake ()
		{
			myRect = (RectTransform)transform;
			canvas = GetComponentInParent<Canvas>();
			mainCamera = Camera.main;
			SetActive(startsActive);
		}

		private void Update ()
		{
			if (Input.GetMouseButtonDown(0))
SetupAndActivate(origin);
else if (Input.GetMouseButtonUp(0))
Deactivate();

			if (!isActive)
				return;
			Setup();
		}

		private void Setup ()
		{
			if (origin == null)
				return;
			originPosOnScreen = mainCamera.WorldToScreenPoint(origin.GetComponent<Collider2D>().bounds.center);
			myRect.anchoredPosition = new Vector2(originPosOnScreen.x - Screen.width / 2, originPosOnScreen.y - Screen.height / 2) / canvas.scaleFactor;
			endDragPoint = Input.mousePosition;
			differenceToMouse = endDragPoint - (Vector3)originPosOnScreen;
			differenceToMouse.Scale(new Vector2(1f / myRect.localScale.x, 1f / myRect.localScale.y));
			transform.up = differenceToMouse;
			baseRect.anchorMax = new Vector2(baseRect.anchorMax.x, differenceToMouse.magnitude / canvas.scaleFactor / baseHeight);
		}

		private void SetActive (bool b)
		{
			isActive = b;
			if (b)
				Setup();
			baseRect.gameObject.SetActive(b);
		}

		public void Activate () => SetActive(true);
		public void Deactivate () { 
			SetActive(false);
			// Debug.Log("Happened");
			// AstronautController originController = origin.gameObject.GetComponent<AstronautController>();
			// Rigidbody2D rb = origin.gameObject.GetComponent<Rigidbody2D>();

			// GameObject throwObj = Instantiate(originController.throwObject, origin.position, Quaternion.identity);
            // Rigidbody2D throwRb = throwObj.GetComponent<Rigidbody2D>();
            // Vector3 throwDirection = differenceToMouse.normalized;
			// float dragDistance = Vector3.Distance(endDragPoint, (Vector3)originPosOnScreen);
            // throwRb.AddForce(throwDirection * dragDistance * 5, ForceMode2D.Impulse);
            // rb.AddForce(-throwDirection * dragDistance * 5, ForceMode2D.Impulse);
			}
		public void SetupAndActivate (Transform origin)
		{
			Origin = origin;
			Activate();
		}
	}
}