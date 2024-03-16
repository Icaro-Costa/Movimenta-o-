using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
	public Transform cam;
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
	Vector3 Pos_input;
	public Transform player_Mesh;

    [SerializeField] private float velocidade = 2f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Pos_input = (cam.transform.forward * inputs.z + cam.transform.right * inputs.x).normalized;
        character.Move((Pos_input * Time.deltaTime * velocidade));
        character.Move((Vector3.down * Time.deltaTime));

        if (inputs != Vector3.zero)
        {
			Quaternion LookRotation = Quaternion.LookRotation (Pos_input, Vector3.up);
			player_Mesh.rotation = Quaternion.Lerp (player_Mesh.transform.rotation, LookRotation, Time.deltaTime * 8f);
			
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }
    }
}