using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInteract : MonoBehaviour
{
    public List<int> _usedKeys = new List<int>();

    private PlayerInteractionsController _player = null;
    private string _letterTagComponent;

    public GameObject scriptGhostRay;

    [SerializeField]
    public float maxInteractDistance = 10.0f;

    private int layerMask = ~(1 << 1);

    private void Start()
    {
        _player = FindObjectOfType<PlayerInteractionsController>();
        _letterTagComponent = "GhostTag";
    }

    void Update()
    {
        RaycastHit hit;
        bool cast = Physics.Raycast(_player.playerHead.position, _player.playerHead.forward, out hit, maxInteractDistance, layerMask);

        if (Input.GetKeyDown(KeyCode.F) && cast && hit.collider.gameObject.GetComponent(_letterTagComponent))
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;

            StartCoroutine(PlaySubtitle());

            IEnumerator PlaySubtitle()
            {
                yield return new WaitForSeconds(1);
                scriptGhostRay.SetActive(true);
            }
        }
    }
}
