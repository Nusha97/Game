using System;


/* To store the co-ordinates of play_area and their value */
public class point
{
	public int co_ordx;
	public int co_ordy;
	public int value;
}
/* A class to store attributes of snake object */
public class snake
{
	public int[,] pos_snake = new int[100, 2];
	public int no_of_units;
	public int cur_dirn; // 1 - right, 2 - left, 3 - up, 4 - down
	/* Constructor of snake to initialise snake units and direction */
	public snake()
	{
		no_of_units = 5;
		cur_dirn = 2;
	}
	/* Function to initialise snake positions */
	public void snake_create(point[,] p)
	{
		  for (int i = 4; i >= 0; i--)
		  {
			pos_snake[i, 0] = p[GlobalMembers.strt_x + i, GlobalMembers.strt_y].co_ordx;
			pos_snake[i, 1] = p[GlobalMembers.strt_x + i, GlobalMembers.strt_y].co_ordy;
		  }
	}
	public void Dispose()
	{
	}

}
/* Class to score attributes of scores */
public class score
{
	public int score_update;
	public score()
	{
		GlobalMembers.score_update = 0;
	}
	public void Dispose()
	{
	}
}
/* Class to store attributes of food */
public class food
{
	public int food_co_ordx;
	public int food_co_ordy;
	public int fx;
	public int fy;
	public food()
	{
		food_co_ordx = 0;
		food_co_ordy = 0;
		fx = 0;
		fy = 0;
	}
	public void Dispose()
	{
	}
}
/* Class to initialise a playing arena and the objects to be present in it.
   Initialises food, snake and score. Snake moves within this arena */
public class play_area
{
	public int dly;
	public point[,] p = new point[100, 75];
	public snake s = new snake();
	public food f = new food();
	public score scr = new score();
	public int x1; //Co-ordinates of head and tail of snake respectively
	public int y1;
	public int x2;
	public int y2;
	/* Constructor to initialise playarea */
	public play_area()
	{
		int x = 0;
		int y;
		for (int i = 0; i < 100; i++)
		{
			y = 0;
			for (int j = 0; j < 75; j++)
			{
				p[i, j].value = 0;
				p[i, j].co_ordx = GlobalMembers.strt_x + x;
				p[i, j].co_ordy = GlobalMembers.strt_y + y;
				y += 6;
			}
			x += 6;
		}
		int ax = 6;
		int by = 3;
		int startcoordx = 3;
		int startcoordy = 3;
		for (i = 0; i <= 62 ; i++)
		{
			setcolor(BLUE);
			ellipse(startcoordx, startcoordy, 0, 360, ax, by);
			setfillstyle(SOLID_FILL, GREEN);
			fillellipse(startcoordx, startcoordy, ax, by);
			startcoordx += 10;
			if (startcoordx == 715)
			{
				break;
			}

		}
		ax = 3, by = 6;
		for (int j = 0; j <= 46 ; j++)
		{
			setcolor(BLUE);
			ellipse(startcoordx, startcoordy, 0, 360, ax, by);
			setfillstyle(SOLID_FILL, GREEN);
			fillellipse(startcoordx, startcoordy, ax, by);
			startcoordy += 10;
			if (startcoordy == 470)
			{
				break;
			}
		}
		ax = 6, by = 3;
		for (int k = 0; k <= 62 ; k++)
		{
			setcolor(BLUE);
			ellipse(startcoordx, startcoordy, 0, 360, ax, by);
			setfillstyle(SOLID_FILL, GREEN);
			fillellipse(startcoordx, startcoordy, ax, by);
			startcoordx -= 10;
			if (startcoordx == 715)
			{
				break;
			}
		}
		ax = 3, by = 6;
		for (int l = 0; l <= 46 ; l++)
		{
			setcolor(BLUE);
			ellipse(startcoordx, startcoordy, 0, 360, ax, by);
			setfillstyle(SOLID_FILL, GREEN);
			fillellipse(startcoordx, startcoordy, ax, by);
			startcoordy -= 10;
			if (startcoordy == 470)
			{
				break;
			}
		}
		dly = 150;

//C++ TO C# CONVERTER WARNING: The following line was determined to be a copy constructor call - this should be verified and a copy constructor should be created if it does not yet exist:
//ORIGINAL LINE: s.snake_create(p);
		s.snake_create(new point(p));
	}
	/* Creates the snake using graphics */
	public void init_snake()
	{
		time_t tm = new time_t();
		RandomNumbers.Seed(time(tm));
		x1 = (s.pos_snake[0, 0] - GlobalMembers.strt_x) / 6;
		y1 = (s.pos_snake[0, 1] - GlobalMembers.strt_y) / 6;
		x2 = (s.pos_snake[s.no_of_units - 1, 0] - GlobalMembers.strt_x) / 6;
		y2 = (s.pos_snake[s.no_of_units - 1, 1] - GlobalMembers.strt_y) / 6;
		for (int i = s.no_of_units - 1; i >= 0; i--)
		{
			setcolor(5);
			circle(s.pos_snake[i, 0],s.pos_snake[i, 1],3);
			setfillstyle(SOLID_FILL,YELLOW);
			floodfill(s.pos_snake[i, 0],s.pos_snake[i, 1],MAGENTA);
			p[GlobalMembers.strt_x + i, GlobalMembers.strt_y].value = 1;
		}
	}
	/* Stores the current direction change when a key is hit */
	public int chng_dirn()
	{
		int a;
		a = bioskey(0);
		if (a == 19200 && s.cur_dirn != 1 && s.cur_dirn != 2)
		{
			s.cur_dirn = 2;
			return 1;
		}
		if (a == 18432 && s.cur_dirn != 3 && s.cur_dirn != 4)
		{
			s.cur_dirn = 3;
			return 1;
		}
		if (a == 20480 && s.cur_dirn != 4 && s.cur_dirn != 3)
		{
			s.cur_dirn = 4;
			return 1;
		}
		if (a == 19712 && s.cur_dirn != 2 && s.cur_dirn != 1)
		{
			s.cur_dirn = 1;
			return 1;
		}
		else
		{
			return 0;
		}
	}
	/* To move the snake by one unit right */
	public int move_one_step_right()
	{
			for (int i = 1; i < s.no_of_units; i++)
			{
				if (s.pos_snake[0, 0] == s.pos_snake[i, 0] && s.pos_snake[0, 1] == s.pos_snake[i, 1])
				{
					return 1;
				}
			}
		System.Threading.Thread.Sleep(dly);
		delete_unit();
		x2++;
		x1++;
		draw_unit();
		if (s.pos_snake[s.no_of_units - 1, 0] == f.food_co_ordx && s.pos_snake[s.no_of_units - 1, 1] == f.food_co_ordy)
		{
			return 2;
		}
		else
		{
			return 0;
		}
	}
	/* To move the snake by one unit left */
	public int move_one_step_left()
	{
			for (int i = 1; i < s.no_of_units; i++)
			{
				if (s.pos_snake[0, 0] == s.pos_snake[i, 0] && s.pos_snake[0, 1] == s.pos_snake[i, 1])
				{
					return 1;
				}
			}
		System.Threading.Thread.Sleep(dly);
		delete_unit();
		x2--;
		x1--;
		draw_unit();
		if (s.pos_snake[s.no_of_units - 1, 0] == f.food_co_ordx && s.pos_snake[s.no_of_units - 1, 1] == f.food_co_ordy)
		{
			return 2;
		}
		else
		{
			return 0;
		}
	}
	/* To move the snake by one unit up */
	public int move_one_step_up()
	{
			for (int i = 1; i < s.no_of_units; i++)
			{
				if (s.pos_snake[0, 0] == s.pos_snake[i, 0] && s.pos_snake[0, 1] == s.pos_snake[i, 1])
				{
					return 1;
				}
			}
		System.Threading.Thread.Sleep(dly);
		delete_unit();
		y2--;
		y1--;
		draw_unit();
		if (s.pos_snake[s.no_of_units - 1, 0] == f.food_co_ordx && s.pos_snake[s.no_of_units - 1, 1] == f.food_co_ordy)
		{
			return 2;
		}
		else
		{
			return 0;
		}
	}
	/* To move the snake by one unit down */
	public int move_one_step_down()
	{
		   for (int i = 1; i < s.no_of_units; i++)
		   {
			   if (s.pos_snake[0, 0] == s.pos_snake[i, 0] && s.pos_snake[0, 1] == s.pos_snake[i, 1])
			   {
				   return 1;
			   }
		   }
	   System.Threading.Thread.Sleep(dly);
	   delete_unit();
	   y2++;
	   y1++;
	   draw_unit();
	   if (s.pos_snake[s.no_of_units - 1, 0] == f.food_co_ordx && s.pos_snake[s.no_of_units - 1, 1] == f.food_co_ordy)
	   {
		   return 2;
	   }
	   else
	   {
		   return 0;
	   }
	}
	/* Draws unit of snake */
	public void draw_unit()
	{
		s.pos_snake[0, 0] = p[x1, y1].co_ordx;
		s.pos_snake[0, 1] = p[x1, y1].co_ordy;
		setcolor(5);
		circle(s.pos_snake[0, 0],s.pos_snake[0, 1],3);
		setfillstyle(SOLID_FILL,YELLOW);
		floodfill(s.pos_snake[0, 0],s.pos_snake[0, 1],MAGENTA);
		p[x1, y1].value = 1;
	}
	/* Deletes unit of snake */
	public void delete_unit()
	{
		setcolor(BLACK);
		circle(s.pos_snake[s.no_of_units - 1, 0],s.pos_snake[s.no_of_units - 1, 1],3);
		setfillstyle(SOLID_FILL,BLACK);
		floodfill(s.pos_snake[s.no_of_units - 1, 0],s.pos_snake[s.no_of_units - 1, 1],BLACK);
		p[x2, y2].value = 0;
		for (int i = s.no_of_units - 1; i >= 1; i--)
		{
			s.pos_snake[i, 0] = s.pos_snake[i - 1, 0];
			s.pos_snake[i, 1] = s.pos_snake[i - 1, 1];
		}
	}
	public void move()
	{
	   int game = 0;
	   do
	   {
		   if (kbhit())
		   {
			   int r = chng_dirn();
		   }
		   if (s.cur_dirn != 2 && s.cur_dirn != 3)
		   {
			   x1 = x1 % 100;
			   y1 = y1 % 75;
			   x2 = x2 % 100;
			   y2 = y2 % 75;
		   }
		   if (s.cur_dirn == 1)
		   {
			   int @object = move_one_step_right();
			   if (@object == 1)
			   {
				   game = game_over();
			   }
			   if (@object == 2)
			   {
				   foodhit();
			   }
		   }
		   if (s.cur_dirn == 2)
		   {
			   if (x1 == 0)
			   {
				   x1 = 100;
				   x2 = 100 - s.no_of_units;
			   }
			   int @object = move_one_step_left();
			   if (@object == 1)
			   {
				   game = game_over();
			   }
			   if (@object == 2)
			   {
				   foodhit();
			   }
		   }
		   if (s.cur_dirn == 3)
		   {
			   if (y1 == 0)
			   {
				   y1 = 75;
				   y2 = 75 - s.no_of_units;
			   }
			   int @object = move_one_step_up();
			   if (@object == 1)
			   {
				   game = game_over();
			   }
			   if (@object == 2)
			   {
				   foodhit();
			   }
		   }
		   if (s.cur_dirn == 4)
		   {
			   int @object = move_one_step_down();
			   if (@object == 1)
			   {
				   game = game_over();
			   }
			   if (@object == 2)
			   {
				   foodhit();
			   }
		   }
	   }while (game == 0);
	   score_update(scr.score_update);
	}
	/* To check if food co-ordinate coincides with snake co-ordinate */
	public int test()
	{
		for (int i = 0; i < 5; i++)
		{
			if (f.food_co_ordx == s.pos_snake[i, 0] && f.food_co_ordy == s.pos_snake[i, 1])
			{
				return 1;
			}
		}
		if (f.food_co_ordx < 19 || f.food_co_ordx > 613)
		{
			return 1;
		}

		else if (f.food_co_ordy < 15 || f.food_co_ordy > 459)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
	/* To create a food unit */
	public void create_food()
	{
		do
		{
			f.food_co_ordx = (RandomNumbers.NextNumber() % 100) * 6 + GlobalMembers.strt_x;
			f.fx = (f.food_co_ordx - GlobalMembers.strt_x) / 6;
			f.food_co_ordy = (RandomNumbers.NextNumber() % 100) * 6 + GlobalMembers.strt_y;
			f.fy = (f.food_co_ordx - GlobalMembers.strt_y) / 6;
			p[f.fx, f.fy].value = 2;
		}while (test() != 0);
		setcolor(7);
		setfillstyle(1,RandomNumbers.NextNumber(15) + 1);
		fillellipse(f.food_co_ordx,f.food_co_ordy,3,3);
	}
	public void delete_food()
	{
		setcolor(BLACK);
		setfillstyle(1,BLACK);
		fillellipse(f.food_co_ordx,f.food_co_ordy,3,3);
		p[f.fx][f.fy].value = 0;
		create_food();
	}
	/* To check if snake has encountered a food unit */
	public void foodhit()
	{
			if (dly > 50)
			{
				dly -= 20;
			}
			else if (dly > 20)
			{
				dly -= 5;
			}
			s.no_of_units += 2;
			scr.score_update += 100;
			delete_food();
			move();
	}
	public void Dispose()
	{
	}
}





