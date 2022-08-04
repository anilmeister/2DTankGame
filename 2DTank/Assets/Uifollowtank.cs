using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uifollowtank : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Transform playerTank;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTank != null)
            rectTransform.anchoredPosition = playerTank.position;//playerTank.localPosition;
    }
}
