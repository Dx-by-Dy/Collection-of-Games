using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Total_checker : MonoBehaviour
{
    private int Global_turn = 0;
    private int Count_players = 2;
    private int Turn;
    private bool End_game = false;
    private bool Can_go = true;
    private GameObject[] objects_with_tag_chip;
    private GameObject Bufer_object;
    public GameObject Chip_3;
    public GameObject Chip_4;
    public GameObject End_Scene;
    public GameObject Chip_win;
    public GameObject Square_on_floor;
    private int cnt_cristal_chip;
    private int Stack_animation = 0;
    private int Max_depth = 3;
    private int[,] Vurtual_table = new int[8, 8];
    private int[,,] Note_table = new int[3, 8, 8];

    public void Bot()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Vurtual_table[i, j] = 0;
            }
        }

        for (int k = 0; k < Max_depth; k++) 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Note_table[k, i, j] = 0;
                }
            }
        }

        objects_with_tag_chip = GameObject.FindGameObjectsWithTag("Chip");
        for (int i = 0; i < objects_with_tag_chip.Length; i++)
        {
            float coor_x = objects_with_tag_chip[i].transform.position.x;
            float coor_y = objects_with_tag_chip[i].transform.position.y;
            int index_x = (int)(-coor_y + 3.5f);
            int index_y = (int)(coor_x + 3.5f);
            if (objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_My_turn() == Global_turn) Vurtual_table[index_x, index_y] = objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_count_cristal();
            else Vurtual_table[index_x, index_y] = -objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_count_cristal();
        }

        /*
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Vurtual_table[i, j] > 0)
                {
                    int min_dist = 100;
                    for (int i1 = 0; i1 < 8; i1++)
                    {
                        for (int j1 = 0; j1 < 8; j1++)
                        {
                            if (Vurtual_table[i1, j1] * Vurtual_table[i, j] < 0 && (int)Mathf.Pow((i1 - i) * (i1 - i) + (j1 - j) * (j1 - j), 0.5f) < min_dist) min_dist = (int)Mathf.Pow((i1 - i) * (i1 - i) + (j1 - j) * (j1 - j), 0.5f);
                        }
                    }
                    Note_table[0, i, j] = min_dist;
                }
            }
        }

        */

        Bot_move(Vurtual_table, 0, false);

    }
    public void Start_game()
    {
        if (Count_players >= 3) 
        {
            Bufer_object = Instantiate(Chip_3, new Vector3(2.5f, 2.5f, -1.5f), Quaternion.identity);
            Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(3);
            Bufer_object.GetComponent<Press_mouse_button>().Set_My_turn(2);
            Bufer_object.name = "Chip" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
            if (Count_players == 4)
            {
                Bufer_object = Instantiate(Chip_4, new Vector3(-2.5f, -2.5f, -1.5f), Quaternion.identity);
                Bufer_object.GetComponent<Press_mouse_button>().Set_count_cristal(3);
                Bufer_object.GetComponent<Press_mouse_button>().Set_My_turn(3);
                Bufer_object.name = "Chip" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
            }
        }
    }
    public void Set_count_players()
    {
        Count_players = GameObject.Find("Player_count").GetComponent<Dropdown>().value + 2;
    }
    public int Get_Global_turn()
    {
        return Global_turn;
    }
    public void Next_Global_turn()
    {
        Global_turn = (Global_turn + 1) % Count_players;
    }
    public bool Can_move()
    {
        return Stack_animation == 0;
    }
    public void Add_stack_animation()
    {
        Stack_animation += 1;
    }
    public void Free_stack_animation()
    {
        Stack_animation -= 1;
    }
    public void Go_to_menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Chips_game");
    }
    private int[,] Ñhange_sign(int[,] Table)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Table[i, j] *= -1;
            }
        }

        return Table;
    }
    private int Sum_array(int[,] Table)
    {
        int Sum = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Sum += Table[i, j];
            }
        }

        return Sum;
    }
    private int[,] Virtual_disclosure(int[,] Table)
    {
        while (true)
        {
            bool z = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Table[i, j] >= 4)
                    {
                        z = false;
                        if (i > 0) Table[i - 1, j] = Mathf.Abs(Table[i - 1, j]) + 1;
                        if (i < 7) Table[i + 1, j] = Mathf.Abs(Table[i + 1, j]) + 1;
                        if (j < 7) Table[i, j + 1] = Mathf.Abs(Table[i, j + 1]) + 1;
                        if (j > 0) Table[i, j - 1] = Mathf.Abs(Table[i, j - 1]) + 1;
                        Table[i, j] -= 4;
                    }
                }
            }
            if (z) break;
        }

        return Table;
    }
    private int Minimum_value(int[,] Table)
    {
        int MIN = 1000;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                MIN = Mathf.Min(MIN, Table[i, j]);
            }
        }
        return MIN;
    }
    private int Maximum_value(int[,] Table)
    {
        int MAX = 1000;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                MAX = Mathf.Max(MAX, Table[i, j]);
            }
        }
        return MAX;
    }
    public int Bot_move(int[,] Bot_table, int depth, bool Enemy)
    {
        int[,] Start_table = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Start_table[i, j] = Bot_table[i, j];
            }
        }

        if (depth == Max_depth)
        {

            int Local_maxx = -1000;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int i1 = 0; i1 < 8; i1++)
                    {
                        for (int j1 = 0; j1 < 8; j1++)
                        {
                            Bot_table[i1, j1] = Start_table[i1, j1];
                        }
                    }

                    Bot_table[i, j] += 1;
                    Bot_table = Virtual_disclosure(Bot_table);
                    Local_maxx = Mathf.Max(Local_maxx, Sum_array(Bot_table));
                    //Note_table[depth, i, j] += Sum_array(Bot_table);
                }
            }

            return Local_maxx;
        }

        int Local_max = -1000;
        int Local_min = 1000;
        int Best_x = -1, Best_y = -1;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i1 = 0; i1< 8; i1++)
                {
                    for (int j1 = 0; j1 < 8; j1++)
                    {
                        Bot_table[i1, j1] = Start_table[i1, j1];
                    }
                }
                if (Bot_table[i, j] <= 0) continue;

                Bot_table[i, j] += 1;
                Bot_table = Virtual_disclosure(Bot_table);

                if (Enemy == false)
                {
                    Local_max = Mathf.Max(Local_max, Bot_move(Ñhange_sign(Bot_table), depth, true));
                    if (depth == 0)
                    {
                        Best_x = i;
                        Best_y = j;
                    }
                }
                else Local_min = Mathf.Min(Local_min, Bot_move(Ñhange_sign(Bot_table), depth + 1, false));
            }
        }

        if (depth == 0 && Best_x != -1 && Best_y != -1) Debug.Log(Best_x.ToString() + " " + Best_y.ToString());
        if (Enemy == false) return Local_max;
        return Local_min;
    }
    void Update()
    {
        objects_with_tag_chip = GameObject.FindGameObjectsWithTag("Chip");

        Turn = objects_with_tag_chip[0].GetComponent<Press_mouse_button>().Get_My_turn();
        End_game = true;
        Can_go = false;

        for (int i = 0; i < objects_with_tag_chip.Length; i++)
        {
            if (objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_My_turn() != Turn) End_game = false;
            if (objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_My_turn() == Global_turn) Can_go = true;
        }

        if (End_game) 
        {
            End_Scene.SetActive(true);
            Chip_win.GetComponent<Image>().sprite = objects_with_tag_chip[0].GetComponent<SpriteRenderer>().sprite;
        }

        if (Can_go == false) Next_Global_turn();

        for (int i = 0; i < objects_with_tag_chip.Length; i++)
        {
            if (Stack_animation != 0)
            {
                Bufer_object = GameObject.Find("Square" + objects_with_tag_chip[i].transform.position.x.ToString() + objects_with_tag_chip[i].transform.position.y.ToString());
                Destroy(Bufer_object);
                continue;
            }

            cnt_cristal_chip = objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Get_count_cristal();

            if (cnt_cristal_chip == 1 && GameObject.Find("Cristal" + objects_with_tag_chip[i].transform.position.x.ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null)
            {
                objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Draw_cristal_1();
            }

            if (cnt_cristal_chip == 2 && 
                (GameObject.Find("Cristal" + (objects_with_tag_chip[i].transform.position.x - 0.15f).ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null || 
                GameObject.Find("Cristal" + (objects_with_tag_chip[i].transform.position.x + 0.15f).ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null))
            {
                objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Draw_cristal_2();
            }

            if (cnt_cristal_chip == 3 && 
                (GameObject.Find("Cristal" + (objects_with_tag_chip[i].transform.position.x - 0.15f).ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null || 
                GameObject.Find("Cristal" + (objects_with_tag_chip[i].transform.position.x + 0.15f).ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null ||
                GameObject.Find("Cristal" + objects_with_tag_chip[i].transform.position.x.ToString() + (objects_with_tag_chip[i].transform.position.y + 0.05f).ToString()) == null))
            {
                objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Draw_cristal_3();
            }

            if (objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Now_my_turn() && 
                GameObject.Find("Square" + objects_with_tag_chip[i].transform.position.x.ToString() + objects_with_tag_chip[i].transform.position.y.ToString()) == null)
            {
                Bufer_object = Instantiate(Square_on_floor, new Vector3(objects_with_tag_chip[i].transform.localPosition.x, objects_with_tag_chip[i].transform.localPosition.y, -1), Quaternion.identity);
                Bufer_object.name = "Square" + Bufer_object.transform.position.x.ToString() + Bufer_object.transform.position.y.ToString();
            }

            Bufer_object = GameObject.Find("Square" + objects_with_tag_chip[i].transform.position.x.ToString() + objects_with_tag_chip[i].transform.position.y.ToString());
            if (objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Now_my_turn() == false &&
                Bufer_object != null)
            {
                Destroy(Bufer_object);
            }

            if (cnt_cristal_chip >= 4)
            {
                objects_with_tag_chip[i].GetComponent<Press_mouse_button>().Disclosure(cnt_cristal_chip - 4);
                break;
            }
        }
    }
}