using System.Collections;
using UnityEngine;

public class Script : MonoBehaviour
{
    public float time = 1f;
    public GameObject otherGameObject;
    public GameObject otherGameObject2;
    private Animator otherAnimator;
    private Animator otherAnimator2;
    bool check = true;

    void Start()
    {
        otherAnimator = otherGameObject.GetComponent<Animator>();
        otherAnimator2 = otherGameObject2.GetComponent<Animator>();
    }

    void Update()
    {
        if (check)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        StartCoroutine(StartAnimationCoroutine());
                    }
                }
            }
        }
    }

    IEnumerator StartAnimationCoroutine()
    {
        Debug.LogWarning("Clicked on the object!");
        check = false;
        otherAnimator.SetBool("Anim2", true);
        otherAnimator2.SetBool("Anim2", true);

        yield return new WaitForSeconds(time);

        otherAnimator.SetBool("Anim2", false);
        otherAnimator2.SetBool("Anim2", false);
        check = true;
    }
}
