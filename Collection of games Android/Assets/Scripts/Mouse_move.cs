using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_move : MonoBehaviour
{
    private bool I_in_mouse = false;
    private int Speed_rotation = 500;
    private Vector3 End_mouse_pos;
    private Vector3 Start_position;
    private GameObject Table;
    public GameObject Connection;
    public GameObject Circle;
    public GameObject Arrow_Right, Arrow_Up, Arrow_Left, Arrow_Down;
    private GameObject[] My_Child = {null, null, null, null, null};
    private GameObject Bufer_object;
    private Vector4 Count_connection;
    private bool Rotate;
    private int Global_scale;
    private float Delta_z;
    private float Start_z;
    private Color My_ability;
    private GameObject[] Tiles;
    private float Delay_click = 0;

    private void Start()
    {
        Table = GameObject.Find("Table");
    }
    private void Generate_1_connection(int way)
    {
        Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
        Bufer_object.transform.SetParent(transform);
        if (way == 1 || way == 3)
        {
            if (way == 1) Bufer_object.transform.localPosition = new Vector3(1.15f, 0, -1);
            else Bufer_object.transform.localPosition = new Vector3(-1.15f, 0, -2);
            Bufer_object.transform.localScale = new Vector3(0.2f, 0.12f, 0);
        }
        if (way == 2 || way == 4)
        {
            if (way == 2) Bufer_object.transform.localPosition = new Vector3(0, 1.15f, -1);
            else Bufer_object.transform.localPosition = new Vector3(0, -1.15f, -2);
            Bufer_object.transform.localScale = new Vector3(0.12f, 0.2f, 0);
        }
    }
    private void Generate_2_connection(int way)
    {
        if (way == 1 || way == 3)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 1) Bufer_object.transform.localPosition = new Vector3(1.15f, 0.2f * i, -1);
                else Bufer_object.transform.localPosition = new Vector3(-1.15f, 0.2f * i, -1);
                Bufer_object.transform.localScale = new Vector3(0.2f, 0.12f, 0);
            }
        }

        if (way == 2 || way == 4)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 2) Bufer_object.transform.localPosition = new Vector3(0.2f * i, 1.15f, -1);
                else Bufer_object.transform.localPosition = new Vector3(0.2f * i, -1.15f, -1);
                Bufer_object.transform.localScale = new Vector3(0.12f, 0.2f, 0);
            }
        }
    }
    private void Generate_3_connection(int way)
    {
        if (way == 1 || way == 3)
        {
            for (int i = -1; i <= 1; i++)
            {
                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 1) Bufer_object.transform.localPosition = new Vector3(1.15f, 0.3f*i, -1);
                else Bufer_object.transform.localPosition = new Vector3(-1.15f, 0.3f*i, -1);
                Bufer_object.transform.localScale = new Vector3(0.2f, 0.12f, 0);
            }
        }

        if (way == 2 || way == 4)
        {
            for (int i = -1; i <= 1; i++)
            {
                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 2) Bufer_object.transform.localPosition = new Vector3(0.3f*i, 1.15f, -1);
                else Bufer_object.transform.localPosition = new Vector3(0.3f*i, -1.15f, -1);
                Bufer_object.transform.localScale = new Vector3(0.12f, 0.2f, 0);
            }
        }
    }
    private void Generate_4_connection(int way)
    {
        if (way == 1 || way == 3)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 1) Bufer_object.transform.localPosition = new Vector3(1.15f, 0.2f * i, -1);
                else Bufer_object.transform.localPosition = new Vector3(-1.15f, 0.2f * i, -1);
                Bufer_object.transform.localScale = new Vector3(0.2f, 0.12f, 0);
            }

            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 1) Bufer_object.transform.localPosition = new Vector3(1.15f, 0.55f * i, -1);
                else Bufer_object.transform.localPosition = new Vector3(-1.15f, 0.55f * i, -1);
                Bufer_object.transform.localScale = new Vector3(0.2f, 0.12f, 0);
            }
        }

        if (way == 2 || way == 4)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 2) Bufer_object.transform.localPosition = new Vector3(0.2f * i, 1.15f, -1);
                else Bufer_object.transform.localPosition = new Vector3(0.2f * i, -1.15f, -1);
                Bufer_object.transform.localScale = new Vector3(0.12f, 0.2f, 0);
            }

            for (int i = -1; i <= 1; i++)
            {
                if (i == 0) continue;

                Bufer_object = Instantiate(Connection, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
                Bufer_object.transform.SetParent(transform);
                if (way == 2) Bufer_object.transform.localPosition = new Vector3(0.55f * i, 1.15f, -1);
                else Bufer_object.transform.localPosition = new Vector3(0.55f * i, -1.15f, -1);
                Bufer_object.transform.localScale = new Vector3(0.12f, 0.2f, 0);
            }
        }
    }
    public void Set_count_connection(int x, int y, int z, int w)
    {
        if (x >= 0) Count_connection.x = x;
        if (y >= 0) Count_connection.y = y;
        if (z >= 0) Count_connection.z = z;
        if (w >= 0) Count_connection.w = w;
    }
    public void Generate_connection()
    {
        if (Count_connection.x != 0)
        {
            if (Count_connection.x == 1) Generate_1_connection(1);
            if (Count_connection.x == 2) Generate_2_connection(1);
            if (Count_connection.x == 3) Generate_3_connection(1);
            if (Count_connection.x == 4) Generate_4_connection(1);
        }
        if (Count_connection.y != 0)
        {
            if (Count_connection.y == 1) Generate_1_connection(2);
            if (Count_connection.y == 2) Generate_2_connection(2);
            if (Count_connection.y == 3) Generate_3_connection(2);
            if (Count_connection.y == 4) Generate_4_connection(2);
        }
        if (Count_connection.z != 0)
        {
            if (Count_connection.z == 1) Generate_1_connection(3);
            if (Count_connection.z == 2) Generate_2_connection(3);
            if (Count_connection.z == 3) Generate_3_connection(3);
            if (Count_connection.z == 4) Generate_4_connection(3);
        }
        if (Count_connection.w != 0)
        {
            if (Count_connection.w == 1) Generate_1_connection(4);
            if (Count_connection.w == 2) Generate_2_connection(4);
            if (Count_connection.w == 3) Generate_3_connection(4);
            if (Count_connection.w == 4) Generate_4_connection(4);
        }
    }
    private void I_win()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        bool win = true;

        for (int j = 0; j < Tiles.Length; j++)
        {
            if (win == false) break;

            Vector4 Check_connection = new Vector4(0, 0, 0, 0);

            if (Tiles[j].GetComponent<Mouse_move>().Get_connection().x == 0) Check_connection.x = 1;
            if (Tiles[j].GetComponent<Mouse_move>().Get_connection().y == 0) Check_connection.y = 1;
            if (Tiles[j].GetComponent<Mouse_move>().Get_connection().z == 0) Check_connection.z = 1;
            if (Tiles[j].GetComponent<Mouse_move>().Get_connection().w == 0) Check_connection.w = 1;

            for (int i = 0; i < Tiles.Length; i++)
            {
                if (Tiles[i].transform.position.x == Tiles[j].transform.position.x - 1 && Tiles[i].transform.position.y == Tiles[j].transform.position.y)
                {
                    Check_connection.z = 1;
                    if (Tiles[i].GetComponent<Mouse_move>().Get_connection().x != Tiles[j].GetComponent<Mouse_move>().Get_connection().z)
                    {
                        win = false;
                        break;
                    }
                }

                if (Tiles[i].transform.position.x == Tiles[j].transform.position.x + 1 && Tiles[i].transform.position.y == Tiles[j].transform.position.y)
                {
                    Check_connection.x = 1;
                    if (Tiles[i].GetComponent<Mouse_move>().Get_connection().z != Tiles[j].GetComponent<Mouse_move>().Get_connection().x)
                    {
                        win = false;
                        break;
                    }
                }

                if (Tiles[i].transform.position.x == Tiles[j].transform.position.x && Tiles[i].transform.position.y == Tiles[j].transform.position.y - 1)
                {
                    Check_connection.w = 1;
                    if (Tiles[i].GetComponent<Mouse_move>().Get_connection().y != Tiles[j].GetComponent<Mouse_move>().Get_connection().w)
                    {
                        win = false;
                        break;
                    }
                }

                if (Tiles[i].transform.position.x == Tiles[j].transform.position.x && Tiles[i].transform.position.y == Tiles[j].transform.position.y + 1)
                {
                    Check_connection.y = 1;
                    if (Tiles[i].GetComponent<Mouse_move>().Get_connection().w != Tiles[j].GetComponent<Mouse_move>().Get_connection().y)
                    {
                        win = false;
                        break;
                    }
                }
            }

            if (Check_connection.x * Check_connection.y * Check_connection.z * Check_connection.w == 0)
            {
                win = false;
                break;
            }
        }

        if (win)
        {
            Table.GetComponent<Start_connecting_game>().Game_win();
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i].GetComponent<Animator>().SetBool("Win_Game", true);
            }
        }
    }
    public void Open_win_menu()
    {
        Bufer_object = GameObject.Find("Canvas").transform.Find("Win_menu").gameObject;
        Bufer_object.SetActive(true);

        Bufer_object.transform.Find("End_count_acts").gameObject.GetComponent<Text>().text = "You use " + Table.GetComponent<Start_connecting_game>().Get_count_acts().ToString() + " acts for win";

        Bufer_object.transform.Find("Time_game_text").gameObject.GetComponent<Text>().text = "Time: " + Table.GetComponent<Start_connecting_game>().Get_time_game();

        Bufer_object.transform.Find("Seed_end").gameObject.GetComponent<InputField>().text = Table.GetComponent<Start_connecting_game>().Get_seed().ToString();
    }
    public void Set_Global_scale(int value)
    {
        Global_scale = value;
    }
    public void Start_rotate(int value)
    {
        for (int i = 0; i < My_Child.Length; i++)
        {
            if (My_Child[i] != null) My_Child[i].transform.SetParent(null);
        }

        transform.Rotate(0, 0, 90 * value);

        for (int i = 0; i < value; i++)
        {
            float w = Count_connection.w;
            Count_connection.w = Count_connection.z;
            Count_connection.z = Count_connection.y;
            Count_connection.y = Count_connection.x;
            Count_connection.x = w;
        }

        for (int i = 0; i < My_Child.Length; i++)
        {
            if (My_Child[i] != null) My_Child[i].transform.SetParent(transform);
        }
    }
    private void Set_arrows()
    {
        if (My_ability == Color.yellow || My_ability == Color.blue || My_ability == new Color(1, 0.3f, 0) || My_ability == Color.magenta) 
        {
            Bufer_object = Instantiate(Circle, new Vector3(0, 0, -2), Quaternion.identity);
            Bufer_object.transform.SetParent(transform);
            Bufer_object.transform.localPosition = new Vector3(0, 0, -2);
            Bufer_object.transform.localScale = new Vector3(0.325f, 0.325f, 0);
            My_Child[0] = Bufer_object;
        }
        if (My_ability == Color.yellow || My_ability == new Color(1, 0.3f, 0) || My_ability == Color.green || My_ability == Color.grey)
        {
            Bufer_object = Instantiate(Arrow_Right, new Vector3(0.6f, 0, -2), Quaternion.identity);
            Bufer_object.transform.SetParent(transform);
            Bufer_object.transform.localPosition = new Vector3(0.6f, 0, -2);
            Bufer_object.transform.localScale = new Vector3(0.325f, 0.325f, 0);
            My_Child[1] = Bufer_object;

            Bufer_object = Instantiate(Arrow_Left, new Vector3(-0.6f, 0, -2), Quaternion.identity);
            Bufer_object.transform.SetParent(transform);
            Bufer_object.transform.localPosition = new Vector3(-0.6f, 0, -2);
            Bufer_object.transform.localScale = new Vector3(0.325f, 0.325f, 0);
            My_Child[2] = Bufer_object;
        }
        if (My_ability == Color.white || My_ability == new Color(1, 0.3f, 0) || My_ability == Color.green || My_ability == Color.magenta)
        {
            Bufer_object = Instantiate(Arrow_Up, new Vector3(0, 0.6f, -2), Quaternion.identity);
            Bufer_object.transform.SetParent(transform);
            Bufer_object.transform.localPosition = new Vector3(0, 0.6f, -2);
            Bufer_object.transform.localScale = new Vector3(0.325f, 0.325f, 0);
            My_Child[3] = Bufer_object;

            Bufer_object = Instantiate(Arrow_Down, new Vector3(0, -0.6f, -2), Quaternion.identity);
            Bufer_object.transform.SetParent(transform);
            Bufer_object.transform.localPosition = new Vector3(0, -0.6f, -2);
            Bufer_object.transform.localScale = new Vector3(0.325f, 0.325f, 0);
            My_Child[4] = Bufer_object;
        }
    }
    public void Set_ability(Color color)
    {
        My_ability = color;
        GetComponent<SpriteRenderer>().color = color;
        Set_arrows();
    }
    public bool Can_I_move(float start_x, float start_y, float end_x, float end_y)
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < Tiles.Length; i++)
        {
            if (Tiles[i].transform.position == new Vector3(end_x, end_y, Tiles[i].transform.position.z)) return false;
        }
        if (My_ability == Color.red || My_ability == Color.blue) return false;
        if ((My_ability == Color.yellow || My_ability == Color.grey) && end_y != start_y) return false;
        if ((My_ability == Color.magenta || My_ability == Color.white) && end_x != start_x) return false;
        return true;
    }
    public bool Can_I_rotate()
    {
        if (My_ability == Color.red || My_ability == Color.green || My_ability == Color.white || My_ability == Color.grey) return false;
        return true;
    }
    public Vector4 Get_connection()
    {
        return Count_connection;
    }
    public Color Get_My_ability() 
    {
        return My_ability;
    }
    public void OnMouseOver()
    {
        if (Table.GetComponent<Start_connecting_game>().I_in_game() && Rotate == false)
        {

            End_mouse_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            float new_x = Mathf.Floor(End_mouse_pos.x + 0.5f * (Global_scale % 2)) + 0.5f * ((Global_scale + 1) % 2);
            float new_y = Mathf.Floor(End_mouse_pos.y + 0.5f * (Global_scale % 2)) + 0.5f * ((Global_scale + 1) % 2);

            if (Input.GetMouseButtonUp(0) && I_in_mouse)
            {
                transform.position = Start_position;

                if (Delay_click < 0.15f && Can_I_rotate())
                {
                    if (Rotate == false)
                    {
                        Rotate = true;
                        Delta_z = 0;
                        Start_z = transform.rotation.eulerAngles.z;

                        for (int i = 0; i < My_Child.Length; i++)
                        {
                            if (My_Child[i] != null) My_Child[i].transform.SetParent(null);
                        }
                    }
                }

                else
                {
                    if (Mathf.Abs(new_x) < (float)Global_scale / 2 && Mathf.Abs(new_y) < (float)Global_scale / 2 && Can_I_move(Start_position.x, Start_position.y, new_x, new_y))
                    {
                        transform.position = new Vector3(new_x, new_y, -1);

                        for (int i = 0; i < My_Child.Length; i++)
                        {
                            if (My_Child[i] != null) My_Child[i].transform.SetParent(transform);
                        }

                        Table.GetComponent<Start_connecting_game>().Add_act();
                        I_win();
                    }

                    else transform.position = Start_position;

                    Table.GetComponent<Start_connecting_game>().Set_mouse_busy(false);
                }

                I_in_mouse = false;
            }

            if (Input.GetMouseButtonDown(0) && I_in_mouse == false)
            {
                I_in_mouse = true;
                Delay_click = 0;
                Table.GetComponent<Start_connecting_game>().Set_mouse_busy(true);
                Start_position = transform.position;
            }

        }
    }
    public void Update()
    {
        if (I_in_mouse)
        {
            if (Delay_click > 0.15f)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, -4);
            }

            Delay_click += Time.deltaTime;

            if (Rotate)
            {
                for (int i = 0; i < My_Child.Length; i++)
                {
                    if (My_Child[i] != null)
                    {
                        if (i == 0) My_Child[i].transform.localPosition = new Vector3(0, 0, 5) + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        if (i == 1) My_Child[i].transform.localPosition = new Vector3(0.24f, 0, 5) + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        if (i == 2) My_Child[i].transform.localPosition = new Vector3(-0.24f, 0, 5) + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        if (i == 3) My_Child[i].transform.localPosition = new Vector3(0, 0.24f, 5) + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        if (i == 4) My_Child[i].transform.localPosition = new Vector3(0, -0.24f, 5) + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                    }
                }
            }
        }

        if (Rotate)
        {
            transform.Rotate(0, 0, Speed_rotation * Time.deltaTime);
            Delta_z += Speed_rotation * Time.deltaTime;

            if (Delta_z >= 90)
            {
                Rotate = false;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, (Start_z + 90) % 360));

                float w = Count_connection.w;
                Count_connection.w = Count_connection.z;
                Count_connection.z = Count_connection.y;
                Count_connection.y = Count_connection.x;
                Count_connection.x = w;

                for (int i = 0; i < My_Child.Length; i++)
                {
                    if (My_Child[i] != null) My_Child[i].transform.SetParent(transform);
                }

                Table.GetComponent<Start_connecting_game>().Add_act();
                I_win();
            }
        }
    }
}
