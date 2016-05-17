using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CatwomanCharacter))]
public class CatwomanController : MonoBehaviour
{
    private CatwomanCharacter m_Character;
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    private bool m_Jump;
    public bool m_manual = false;
    public bool m_folow_main_character = true;
    public NavMeshAgent agent;
    public Transform target;
    Animator m_Animator;

    [SerializeField]
    public bool navEnabled = true; // added By piter -- delte later

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");

        }

        m_Character = GetComponent<CatwomanCharacter>();
    }


    private void Update()
    {
        if (m_manual)
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (m_manual)
        {
            agent.enabled = false;
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
        else
        {
            if (m_folow_main_character) {
                //bot folow main character

                agent.enabled = true;
                agent.SetDestination(target.position);
                float distance = Vector3.Distance(target.transform.position, this.transform.position);
                if (distance > 4f)
                {
                    m_Animator.SetFloat("Forward", 0.7f, 0.1f, Time.deltaTime);
                    //m_Animator.SetFloat("Turn", 0.7f, 0.1f, Time.deltaTime);
                }
                if (distance <= 3.5f)
                {
                    m_Animator.SetFloat("Forward", 0, 0, Time.deltaTime);
                }
            }
            else
            {
                agent.enabled = false;
            }
        }
    }
}
