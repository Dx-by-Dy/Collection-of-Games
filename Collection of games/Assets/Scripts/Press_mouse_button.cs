using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_mouse_button : MonoBehaviour
{
    private int speed = 1;
    public int cnt_cristal = 1;
    public int My_turn = 1;
    public GameObject Team_chip;
    public GameObject Cristal;
    private GameObject Bufer_object;
    private Animator Anim;
    private int Bufer_cnt_cristal;
    private Vector3 Bufer_vector;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void Set_My_turn(int turn)
    {
        My_turn = turn;
    }
    public int Get_My_turn()
    {
        return My_turn;
    }
    private void Set_end_position()
    {
        transform.position = Bufer_vector;
    }
    public void My_end_position(Vector3 End_vector)
    {
        Bufer_vector = End_vector;
    }
    public void Animation_destroy_end()
    {
        Anim.SetBool("Bool_destroy", false);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Free_stack_animation();
        Destroy_cristal();
        Destroy(gameObject);
    }
    public void Animation_up_end()
    {
        Set_end_position();
        Anim.SetBool("Bool_up", false);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Free_stack_animation();
    }
    public void Animation_down_end()
    {
        Set_end_position();
        Anim.SetBool("Bool_down", false);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Free_stack_animation();
    }
    public void Animation_left_end()
    {
        Set_end_position();
        Anim.SetBool("Bool_left", false);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Free_stack_animation();
    }
    public void Animation_right_end()
    {
        Set_end_position();
        Anim.SetBool("Bool_right", false);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Free_stack_animation();
    }
    private void Destroy_and_create_chip_around()
    {

        Bufer_cnt_cristal = 0;
        Bufer_object = GameObject.Find("Chip" + (transform.localPosition.x + 1).ToString() + transform.localPosition.y.ToString());
        if (Bufer_object != null)
        {
            Bufer_cnt_cristal = Bufer_object.GetComponent<Press_mouse_button>().Get_count_cristal();
            Bufer_object.GetComponent<Press_mouse_button>().Destroy_me();
        }
        if (transform.localPosition.x + 1 < 4)
        {
            Bufer_object = Instantiate(Team_chip, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(Bufer_cnt_cristal + 1);
            Bufer_object.name = "Chip" + (Bufer_object.transform.position.x + 1).ToString() + Bufer_object.transform.position.y.ToString();
            Bufer_object.GetComponent<Press_mouse_button>().My_end_position(new Vector3(transform.localPosition.x + 1, transform.localPosition.y, transform.localPosition.z));
            Bufer_object.GetComponent<Animator>().SetBool("Bool_right", true);
            Bufer_object = GameObject.Find("Total_checker_script");
            Bufer_object.GetComponent<Total_checker>().Add_stack_animation();
        }

        Bufer_cnt_cristal = 0;
        Bufer_object = GameObject.Find("Chip" + (transform.localPosition.x - 1).ToString() + transform.localPosition.y.ToString());
        if (Bufer_object != null)
        {
            Bufer_cnt_cristal = Bufer_object.GetComponent<Press_mouse_button>().Get_count_cristal();
            Bufer_object.GetComponent<Press_mouse_button>().Destroy_me();
        }
        if (transform.localPosition.x - 1 > -4)
        {
            Bufer_object = Instantiate(Team_chip, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(Bufer_cnt_cristal + 1);
            Bufer_object.name = "Chip" + (Bufer_object.transform.position.x - 1).ToString() + Bufer_object.transform.position.y.ToString();
            Bufer_object.GetComponent<Press_mouse_button>().My_end_position(new Vector3(transform.localPosition.x - 1, transform.localPosition.y, transform.localPosition.z));
            Bufer_object.GetComponent<Animator>().SetBool("Bool_left", true);
            Bufer_object = GameObject.Find("Total_checker_script");
            Bufer_object.GetComponent<Total_checker>().Add_stack_animation();
        }

        Bufer_cnt_cristal = 0;
        Bufer_object = GameObject.Find("Chip" + transform.localPosition.x.ToString() + (transform.localPosition.y - 1).ToString());
        if (Bufer_object != null)
        {
            Bufer_cnt_cristal = Bufer_object.GetComponent<Press_mouse_button>().Get_count_cristal();
            Bufer_object.GetComponent<Press_mouse_button>().Destroy_me();
        }
        if (transform.localPosition.y - 1 > -4)
        {
            Bufer_object = Instantiate(Team_chip, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(Bufer_cnt_cristal + 1);
            Bufer_object.name = "Chip" + Bufer_object.transform.position.x.ToString() + (Bufer_object.transform.position.y - 1).ToString();
            Bufer_object.GetComponent<Press_mouse_button>().My_end_position(new Vector3(transform.localPosition.x, transform.localPosition.y - 1, transform.localPosition.z));
            Bufer_object.GetComponent<Animator>().SetBool("Bool_down", true);
            Bufer_object = GameObject.Find("Total_checker_script");
            Bufer_object.GetComponent<Total_checker>().Add_stack_animation();
        }

        Bufer_cnt_cristal = 0;
        Bufer_object = GameObject.Find("Chip" + transform.localPosition.x.ToString() + (transform.localPosition.y + 1).ToString());
        if (Bufer_object != null)
        {
            Bufer_cnt_cristal = Bufer_object.GetComponent<Press_mouse_button>().Get_count_cristal();
            Bufer_object.GetComponent<Press_mouse_button>().Destroy_me();
        }

        if (transform.localPosition.y + 1 < 4)
        {
            Bufer_object = Instantiate(Team_chip, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(Bufer_cnt_cristal + 1);
            Bufer_object.name = "Chip" + Bufer_object.transform.position.x.ToString() + (Bufer_object.transform.position.y + 1).ToString();
            Bufer_object.GetComponent<Press_mouse_button>().My_end_position(new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z));
            Bufer_object.GetComponent<Animator>().SetBool("Bool_up", true);
            Bufer_object = GameObject.Find("Total_checker_script");
            Bufer_object.GetComponent<Total_checker>().Add_stack_animation();
        }
    }
    public int Get_count_cristal()
    {
        return cnt_cristal;
    }
    public void Set_count_cristal(int number)
    {
        cnt_cristal = number;
    }
    public void Draw_cristal_1()
    {
        Bufer_object = GameObject.Find("Cristal" + transform.localPosition.x.ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
    }
    public void Draw_cristal_3()
    {
        Bufer_object = GameObject.Find("Cristal" + transform.localPosition.x.ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x - 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x - 0.15f, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x + 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x + 0.15f, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
    }
    public void Draw_cristal_2()
    {
        Bufer_object = GameObject.Find("Cristal" + transform.localPosition.x.ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Destroy(Bufer_object);

        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x - 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x - 0.15f, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x + 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object == null)
        {
            Bufer_object = Instantiate(Cristal, new Vector3(transform.localPosition.x + 0.15f, transform.localPosition.y + 0.05f, -3), Quaternion.identity);
            Bufer_object.name = "Cristal" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
        }
    }
    private void Destroy_cristal()
    {
        Bufer_object = GameObject.Find("Cristal" + transform.localPosition.x.ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Destroy(Bufer_object);
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x - 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Destroy(Bufer_object);
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x + 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Destroy(Bufer_object);
    }
    public void Destroy_me()
    {
        Bufer_object = GameObject.Find("Cristal" + transform.localPosition.x.ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Bufer_object.GetComponent<Animator>().SetBool("Bool_cristal_destroy", true);
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x - 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Bufer_object.GetComponent<Animator>().SetBool("Bool_cristal_destroy", true);
        Bufer_object = GameObject.Find("Cristal" + (transform.localPosition.x + 0.15f).ToString() + (transform.localPosition.y + 0.05f).ToString());
        if (Bufer_object != null) Bufer_object.GetComponent<Animator>().SetBool("Bool_cristal_destroy", true);
        Anim.SetBool("Bool_destroy", true);
        Bufer_object = GameObject.Find("Total_checker_script");
        Bufer_object.GetComponent<Total_checker>().Add_stack_animation();
    }
    public bool Now_my_turn()
    {
        Bufer_object = GameObject.Find("Total_checker_script");
        return Bufer_object.GetComponent<Total_checker>().Get_Global_turn() == My_turn;
    }
    public void Disclosure(int overflow_cristal)
    {
        Destroy_and_create_chip_around();
        if (overflow_cristal == 0)
        {
            Destroy_cristal();
            Destroy(gameObject);
        }
        else cnt_cristal = overflow_cristal;
    }
    public void OnMouseDown()
    {
        Bufer_object = GameObject.Find("Total_checker_script");
        if (Input.GetMouseButtonDown(0) && Bufer_object.GetComponent<Total_checker>().Get_Global_turn() == My_turn && Bufer_object.GetComponent<Total_checker>().Can_move())
        {
            Bufer_object.GetComponent<Total_checker>().Next_Global_turn();
            //Bufer_object.GetComponent<Total_checker>().Bot();
            cnt_cristal += 1;
        }
    }
    public void Update()
    {
        if (Anim.GetBool("Bool_up") == true) transform.position += Vector3.up * speed * Time.deltaTime;
        if (Anim.GetBool("Bool_down") == true) transform.position += Vector3.down * speed * Time.deltaTime;
        if (Anim.GetBool("Bool_left") == true) transform.position += Vector3.left * speed * Time.deltaTime;
        if (Anim.GetBool("Bool_right") == true) transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
