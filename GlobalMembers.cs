public static class GlobalMembers
{
	public static int strt_x = 19;
	public static int strt_y = 15;
	public static int end_x = 613;
	public static int end_y = 459;
/* Displays Game Name */

	public static void first_page()
	{
		int x;
		int y;
		int i;

		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");

		cleardevice();
		x = getmaxx() / 2;
		y = getmaxy() / 2;
		setbkcolor(RandomNumbers.NextNumber());
		setcolor(LIGHTRED);
		settextstyle(TRIPLEX_FONT,0,7);
		outtextxy(10,30,"SNAKE");
		setcolor(YELLOW);
		settextstyle(SMALL_FONT,0,5);
		outtextxy(425,400, "Press any key to begin");
		while (!kbhit())
		{
			setcolor(RandomNumbers.NextNumber());
			for (int i = 0; i < 30; i++)
			{
				circle(x,y,i);
			}
			setcolor(RandomNumbers.NextNumber());
			for (int j = 30; j < 70; j++)
			{
				circle(x,y,j);
			}
			setcolor(RandomNumbers.NextNumber());
			for (int k = 70;j < 110;j++)
			{
				circle(x,y,k);
			}
			setcolor(RandomNumbers.NextNumber());
			for (int l = 110; l < 150; l++)
			{
				circle(x,y,l);
			}
			System.Threading.Thread.Sleep(200);
		}
		closegraph();
		Console.ReadKey(true).KeyChar;
		menu();
	}
/* To initialis the game by creating playarea object */
	public static void start_game()
	{
		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");
		cleardevice();
		play_area p = new play_area();
		p.create_food();
		p.init_snake();
		p.move();
	}
/* To initialise movement of snake */
/* Provides options to the user */
	public static void menu()
	{
		int value = 0;
		int x;
		int y;
		int startcoordx = 14;
		int startcoordy = 10;

		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");

		int midx = getmaxx() / 2;

		setcolor(12);
		settextjustify(CENTER_TEXT, CENTER_TEXT);
		settextstyle(4, HORIZ_DIR, 8);
		outtextxy(midx, 100, "MENU");

		setfillstyle(SOLID_FILL,YELLOW);
		bar(440,200,200,240);
		setcolor(BLUE);
		settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
		outtextxy(315,215,"New Game");

		setfillstyle(SOLID_FILL,BLACK);
		bar(440,270,200,310);
		setcolor(RED);
		settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
		outtextxy(323,283,"Instructions");

		setfillstyle(SOLID_FILL,BLACK);
		bar(440,340,200,380);
		setcolor(GREEN);
		settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
		outtextxy(320,360,"Exit ");

		x = 12, y = 6;
		for (int i = 0; i <= 35 ; i++)
		{
				setcolor(YELLOW);
				ellipse(startcoordx, startcoordy, 0, 360, x, y);
				setfillstyle(SOLID_FILL, RED);
				fillellipse(startcoordx, startcoordy, x, y);
				startcoordx += 17;
				System.Threading.Thread.Sleep(18);
		}
		x = 6, y = 12;
		for (int j = 0; j <= 26 ; j++)
		{
				setcolor(GREEN);
				ellipse(startcoordx, startcoordy, 0, 360, x, y);
				setfillstyle(SOLID_FILL, BLUE);
				fillellipse(startcoordx, startcoordy, x, y);
				startcoordy += 17;
				System.Threading.Thread.Sleep(18);
		}
		x = 12, y = 6;
		for (int k = 0; k <= 35 ; k++)
		{
				setcolor(RED);
				ellipse(startcoordx, startcoordy, 0, 360, x, y);
				setfillstyle(SOLID_FILL, YELLOW);
				fillellipse(startcoordx, startcoordy, x, y);
				startcoordx -= 17;
				System.Threading.Thread.Sleep(18);
		}
		x = 6, y = 12;
		for (int l = 0; l <= 26 ; l++)
		{
				setcolor(BLUE);
				ellipse(startcoordx, startcoordy, 0, 360, x, y);
				setfillstyle(SOLID_FILL, GREEN);
				fillellipse(startcoordx, startcoordy, x, y);
				startcoordy -= 17;
				System.Threading.Thread.Sleep(18);
		}
		setcolor(WHITE);
		settextstyle(DEFAULT_FONT,HORIZ_DIR,0);
		outtextxy(325,400,"PRESS ENTER WHEN OPTION IS HIGHLIGHTED ");

		do
		{
			int start1 = 200;
			int start2 = 240;
			if (kbhit())
			{
				value = 1;
				break;
			}
			setfillstyle(SOLID_FILL,BLACK);
			bar(440,200,200,240);
			setcolor(BLUE);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(315,215,"New Game");

			setfillstyle(SOLID_FILL,YELLOW);
			bar(440,start1 + 70,200,start2 + 70);
			setcolor(RED);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(323,283,"Instructions");
			System.Threading.Thread.Sleep(800);
			if (kbhit())
			{
				value = 2;
				break;
			}
			setfillstyle(SOLID_FILL,BLACK);
			bar(440,start1 + 70,200,start2 + 70);
			setcolor(RED);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(323,283,"Instructions");

			setfillstyle(SOLID_FILL,YELLOW);
			bar(440,start1 + 140,200,start2 + 140);
			setcolor(GREEN);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(320,360,"Exit");
			System.Threading.Thread.Sleep(800);
			if (kbhit())
			{
				value = 3;
				break;
			}
			setfillstyle(SOLID_FILL,BLACK);
			bar(440,start1 + 140,200,start2 + 140);
			setcolor(GREEN);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(320,360,"Exit");

			setfillstyle(SOLID_FILL,YELLOW);
			bar(440,start1,200,start2);
			setcolor(BLUE);
			settextstyle(TRIPLEX_FONT, HORIZ_DIR,4);
			outtextxy(315,215,"New Game");
			System.Threading.Thread.Sleep(800);

		}while (value == 0);
		closegraph();

		switch (value)
		{
			case 1 :
			{
				start_game();
				break;
			}
			case 2 :
			{
				instructions();
				break;
			}
			case 3 :
			{
				Environment.Exit(0);
			}
		break;
		}
	}
/* To display instructions on how to play the game */
	public static void instructions()
	{

		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");
		cleardevice();
		System.Threading.Thread.Sleep(200);
		Console.ReadKey(true).KeyChar;
		setbkcolor(BLUE);
		setcolor(GREEN);
		outtextxy(100,100,"HOW TO PLAY THE GAME ? ");
		setcolor(YELLOW);
		settextstyle(DEFAULT_FONT,HORIZ_DIR,1);
		System.Threading.Thread.Sleep(300);
		outtextxy(100,120,"Use the arrow keys to navigate the snake as you please. ");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,140,"The snake moves out of the screen and comes in like a marquee");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,160,"on reaching the end of screen.");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,180,"The game ends if the snake bites itself. ");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,200,"Read instructions carefully. ");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,280,"Enjoy the game ! ");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,320,"PRESS ENTER TO START THE GAME ");
		System.Threading.Thread.Sleep(300);
		outtextxy(100,340,"PRESS 'M' TO GO BACK TO MAIN MENU ");
		int a = Console.ReadKey(true).KeyChar;
		closegraph();
		if (a == 13)
		{
		  start_game();
		}
		else
		{
		  menu();
		}
	}
/* To display when game ends */
	public static int game_over()
	{
		cleardevice();
		setcolor(LIGHTRED);
		settextjustify(CENTER_TEXT,CENTER_TEXT);
		settextstyle(GOTHIC_FONT, HORIZ_DIR, 4);
		outtextxy(getmaxx() / 2,getmaxy() / 2,"Game Over");
		System.Threading.Thread.Sleep(1000);
		closegraph();
		return 1;
	}
/* To update score when a food is encountered */
	public static void score_update(int score)
	{
		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");
		cleardevice();
		settextjustify(CENTER_TEXT,CENTER_TEXT);
		settextstyle(TRIPLEX_FONT, HORIZ_DIR, 4);
		outtextxy(getmaxx() / 2 - 35,getmaxy() / 2,"SCORE :    ");
		string string = new string(new char[25]);
		itoa(score,string,10);
		setcolor(YELLOW);
		settextstyle(TRIPLEX_FONT, HORIZ_DIR, 4);
		outtextxy(getmaxx() / 2,getmaxy() / 2,string);
		System.Threading.Thread.Sleep(1000);
		Console.ReadKey(true).KeyChar;
		closegraph();
		Environment.Exit(0);
	}
/* To delete a food unit */

	/* Display Project Authors' Names */
	public static void credits()
	{
		int gdriver = DETECT;
		int gmode;
		int errorcode;

		initgraph(gdriver, gmode, "C:\\TC\\BGI");
		setbkcolor(LIGHTGRAY);
		settextjustify(CENTER_TEXT, CENTER_TEXT);
		setcolor(4);
		settextstyle(TRIPLEX_FONT, 0, 3);
		outtextxy(getmaxx() / 2,100, "COMPUTER SCIENCE PROJECT");
		setcolor(BLUE);
		settextstyle(DEFAULT_FONT,0, 5);
		outtextxy(getmaxx() / 2,200, "PROJECT SNAKE ");
		setcolor(MAGENTA);
		settextstyle(GOTHIC_FONT,0,5);
		outtextxy(312, 350, "BY: ");
		setcolor(GREEN);
		settextstyle(TRIPLEX_FONT, 0, 2);
		outtextxy(320, 400, "Anusha.S and Sriya.M.V");
		Console.ReadKey(true).KeyChar;
		closegraph();
	}
	/* To execute the program */
	static int Main()
	{
		credits();
		first_page();
		Console.ReadKey(true).KeyChar;
		return 0;
	}
}