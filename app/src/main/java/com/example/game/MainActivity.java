package com.example.game;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.Rect;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.telecom.Call;
import android.util.Log;
import android.view.Display;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;

import java.util.Random;
import java.util.Timer;
import java.util.TimerTask;

public class MainActivity extends AppCompatActivity {

    private Snake SnakeView;

    private Button button1, button2, button3, button4;

    private int[][] snake_pos = new int[100][2];
    private int MIN_DISTANCE = 600;
    private String TAG = "HELLO";
    float x1 = 0, y1 = 0, x2 = 0, y2 = 0;
    private int[] sx = new int[100];
    private int[] sy = new int[100];
    /**
     * ATTENTION: This was auto-generated to implement the App Indexing API.
     * See https://g.co/AppIndexing/AndroidStudio for more information.
     */
    private GoogleApiClient client;

    //Display mdisp = getWindowManager().getDefaultDisplay();
    //int maxX= mdisp.getWidth();
    //int maxY= mdisp.getHeight();


    //int i;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(new Snake(this));

        //setContentView(R.layout.activity_main);
        //SnakeView = (Snake)findViewById(R.id.custom_view);
        //button1 = (Button) findViewById(R.id.up);

        //SnakeView.initializeArray(snake_pos, sx, sy);

        //Bitmap bg = Bitmap.createBitmap(480, 800, Bitmap.Config.ARGB_8888);
        //Canvas canvas = new Canvas(bg);
        //Snake snake;
        //snake = new Snake(getApplicationContext());
        //snake.initializeArray(snake_pos, sx, sy);

        // ATTENTION: This was auto-generated to implement the App Indexing API.
        // See https://g.co/AppIndexing/AndroidStudio for more information.
        client = new GoogleApiClient.Builder(this).addApi(AppIndex.API).build();
    }

    @Override
    public void onStart() {
        super.onStart();

        // ATTENTION: This was auto-generated to implement the App Indexing API.
        // See https://g.co/AppIndexing/AndroidStudio for more information.
        client.connect();
        Action viewAction = Action.newAction(
                Action.TYPE_VIEW, // TODO: choose an action type.
                "Main Page", // TODO: Define a title for the content shown.
                // TODO: If you have web page content that matches this app activity's content,
                // make sure this auto-generated web page URL is correct.
                // Otherwise, set the URL to null.
                Uri.parse("http://host/path"),
                // TODO: Make sure this auto-generated app deep link URI is correct.
                Uri.parse("android-app://com.example.game/http/host/path")
        );
        AppIndex.AppIndexApi.start(client, viewAction);
    }

    @Override
    public void onStop() {
        super.onStop();

        // ATTENTION: This was auto-generated to implement the App Indexing API.
        // See https://g.co/AppIndexing/AndroidStudio for more information.
        Action viewAction = Action.newAction(
                Action.TYPE_VIEW, // TODO: choose an action type.
                "Main Page", // TODO: Define a title for the content shown.
                // TODO: If you have web page content that matches this app activity's content,
                // make sure this auto-generated web page URL is correct.
                // Otherwise, set the URL to null.
                Uri.parse("http://host/path"),
                // TODO: Make sure this auto-generated app deep link URI is correct.
                Uri.parse("android-app://com.example.game/http/host/path")
        );
        AppIndex.AppIndexApi.end(client, viewAction);
        client.disconnect();
    }

    public static class Snake extends View {

        private int[][] snake_pos = new int[100][2];

        private static int cur_dirn = 1; // 1 - right, 2 - left, 3 - up, 4 - down
        private int[] sx = new int[100];
        private int[] sy = new int[100];
        private int fx, fy;
        private static int no_of_units = 5;
        private int MIN_DISTANCE = 600;
        private String TAG = "HELLO";
        float initialX, initialY, finalX, finalY;
        float x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        //Rect button = new Rect(); // Define the dimensions of the button here

        private int i;
        static int count = 0;
        static int move = 10;


        public Snake(Context context) {
            super(context);
            for (i = 0; i < no_of_units; i++) {
                sx[i] = (no_of_units - i) * 20;
                sy[i] = 600;

            }
            fx = 400;
            fy = 400;
        }

        static void endofscreen(int[][] snake_pos, int[] sx, int[] sy) {
            if (cur_dirn == 1) {
                for (int i = 0; i < no_of_units; i++) {
                    sx[i] = (no_of_units - i) * 20;
                }
                initializePos(snake_pos, sx, sy);
            } else if (cur_dirn == 2) {
                for (int i = 0; i < no_of_units; i++) {
                    sx[i] = 1440 - (no_of_units - i) * 20;
                }
                initializePos(snake_pos, sx, sy);
            } else if (cur_dirn == 3) {
                for (int i = 0; i < no_of_units; i++) {
                    sy[i] = 2000 - (no_of_units - i) * 20;
                }
                initializePos(snake_pos, sx, sy);
            } else if (cur_dirn == 4) {
                for (int i = 0; i < no_of_units; i++) {
                    sy[i] = (no_of_units - i) * 20;
                }
                initializePos(snake_pos, sx, sy);
            }
        }

        public void create_food(int p, int q) {

            do {

                Random rand = new Random(); // rand.nextInt
                fx = rand.nextInt(p);
                fy = rand.nextInt(q);

            } while (check());
        }

        public boolean check() {
            for (i = 0; i < no_of_units; i++) {
                if (fx == sx[i] && fy == sy[i]) {
                    return false;
                } else
                    return true;
            }
            return true;
        }

        public void test() {

            if (fx == snake_pos[0][0] && fy == snake_pos[0][1]) {
                create_food(1200, 2000);
                no_of_units++;
            }

        }

        static void initializeArray(final int[][] snake_pos, final int[] sx, int[] sy) {

            initializePos(snake_pos, sx, sy);
            if (cur_dirn == 1) {

                    /*for(int i = 1; i < no_of_units; i++) {

                        sx[i] = sx[i - 1];
                        sy[i] = sy[i - 1];
                    }*/
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    //sy[i] = sy[0];
                    sx[i] += move;
                }
                snake_pos[0][0] = sx[0];
                snake_pos[0][1] = sy[0];
                if (sx[no_of_units - 1] == 1440)
                    endofscreen(snake_pos, sx, sy);

            } else if (cur_dirn == 2) {

                    /*for(int i = 1; i < no_of_units; i++) {

                        sx[i] = sx[i - 1];
                        sy[i] = sy[i - 1];
                    }*/
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    //sy[i] = sy[0];
                    sx[i] -= move;
                }
                snake_pos[0][0] = sx[0];
                snake_pos[0][1] = sy[0];
                if (sx[no_of_units - 1] == 0)
                    endofscreen(snake_pos, sx, sy);
            } else if (cur_dirn == 3) {

                    /*for(int i = 1; i < no_of_units; i++) {

                        sx[i] = sx[i - 1];
                        sy[i] = sy[i - 1];
                    }*/
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    //sx[i] = sx[0];
                    sy[i] -= move;
                }
                snake_pos[0][0] = sx[0];
                snake_pos[0][1] = sy[0];
                if (sy[no_of_units - 1] == 0)
                    endofscreen(snake_pos, sx, sy);
            } else if (cur_dirn == 4) {

                    /*for(int i = 1; i < no_of_units; i++) {

                        sx[i] = sx[i - 1];
                        sy[i] = sy[i - 1];
                    }*/
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    //sx[i] = sx[0];
                    sy[i] += move;
                }
                snake_pos[0][0] = sx[0];
                snake_pos[0][1] = sy[0];
                if (sy[no_of_units - 1] == 2000)
                    endofscreen(snake_pos, sx, sy);
            }
            initializePos(snake_pos, sx, sy);
            //}
            //x += 10;
        }

        static void initializePos(final int[][] snake_pos, final int[] sx, int sy[]) {
            for (int i = 1; i < no_of_units; i++) {

                snake_pos[i][0] = sx[i];
                snake_pos[i][1] = sy[i];

            }
            //x += 10;
        }

        public void transition() {
            if (cur_dirn == 4) {
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    sx[i] = sx[0];
                    sy[i] += 20 * (no_of_units - i);
                }
            } else if (cur_dirn == 3) {
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    sx[i] = sx[0];
                    sy[i] -= 20 * (no_of_units - i);
                }
            } else if (cur_dirn == 2) {
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    sy[i] = sy[0];
                    sx[i] -= 20 * (no_of_units - i);
                }
            } else if (cur_dirn == 1) {
                for (int i = 0; i < no_of_units; i++) {

                    //for(int j = 0; j < no_of_units; j++)
                    sy[i] = sy[0];
                    sx[i] += 20 * (no_of_units - i);
                }
            }
        }

        @Override
        protected void onDraw(Canvas canvas) {

            super.onDraw(canvas);
            Paint paint = new Paint();
            paint.setColor(Color.parseColor("#CD5C5C"));

            Bitmap bg = Bitmap.createBitmap(480, 800, Bitmap.Config.ARGB_8888);
            //Canvas canvas = new Canvas(bg);
            canvas.drawCircle(fx, fy, 20, paint);
            initializeArray(snake_pos, sx, sy);
            //initializePos(snake_pos, sx, sy);
            for (i = 0; i < no_of_units; i++) {
                canvas.drawCircle(snake_pos[i][0], snake_pos[i][1], 10, paint);
                //LinearLayout ll = (LinearLayout) findViewById(R.id.rect);
                //ll.setBackgroundDrawable(new BitmapDrawable(bg));

                /*if (cur_dirn == 1) {
                    sx += 5;
                    if (sx == 1440)
                        sx = 0;
                }
                if (cur_dirn == 2) {
                    sx = 1440;
                    sx -= 5;
                    if (sx == 0)
                        sx = 1440;
                }
                if (cur_dirn == 3) {
                    sy -= 5;
                    if (sy == 0)
                        sy = 1000;
                }
                if (cur_dirn == 4) {
                    sy += 5;
                    if (sy == 1000)
                        sy = 0;
                }
            }*/
                //count++;

                if (count != 0) {
                    cur_dirn = count;
                    transition();
                    count = 0;
                }
                //canvas.drawText(String.valueOf(this.count), 30, 80, paint);
                //test();
                if (fx == snake_pos[0][0] && fy == snake_pos[0][1]) {
                    create_food(1200, 2000);
                    no_of_units++;
                }

            }
            invalidate();
        }



       /* @Override
        public boolean onTouchEvent(MotionEvent event)
        {
            switch (event.getAction()) {
                case MotionEvent.ACTION_DOWN:
                    x1 = event.getX();
                    y1 = event.getY();
                    Log.d(TAG, "Action was UP");
                    break;

                case MotionEvent.ACTION_UP:
                    x2 = event.getX();
                    y2 = event.getY();
                    float Y = y2 - y1;
                    float X = x2 - x1;
                    if (Math.abs(X) > MIN_DISTANCE) {
                        if (x2 > x1) {

                            cur_dirn = 1;
                            Toast.makeText(getContext(), "right swipe", Toast.LENGTH_SHORT).show();
                            //swipe=1;
                        } else {
                            cur_dirn = 2;
                            Toast.makeText(getContext(), "left swipe", Toast.LENGTH_SHORT).show();
                            //swipe=2;
                        }
                    }

                    if (Math.abs(Y) > MIN_DISTANCE) {
                        if (y2 > y1) {
                            cur_dirn = 4;
                            Toast.makeText(getContext(), "top to bottom", Toast.LENGTH_SHORT).show();
                            //swipe=3;
                        } else {
                            cur_dirn = 3;
                            Toast.makeText(getContext(), "bottom to top", Toast.LENGTH_SHORT).show();
                            //swipe=4;
                        }
                    }

                    break;
            }

            return super.onTouchEvent(event);
        }*/
        /*public boolean onTouchEvent(MotionEvent event) {
            //mGestureDetector.onTouchEvent(event);

            int action = event.getActionMasked();

            switch (action) {

                case MotionEvent.ACTION_DOWN:
                    initialX = event.getX();
                    initialY = event.getY();

                    Log.d(TAG, "Action was DOWN");
                    break;

                //case MotionEvent.ACTION_MOVE:
                    //Log.d(TAG, "Action was MOVE");
                    //break;

                case MotionEvent.ACTION_UP:
                    finalX = event.getX();
                    finalY = event.getY();

                    Log.d(TAG, "Action was UP");

                    if (initialX < finalX) {
                        Log.d(TAG, "Left to Right swipe performed");
                        cur_dirn = 1;
                    }

                    if (initialX > finalX) {
                        Log.d(TAG, "Right to Left swipe performed");
                        cur_dirn = 2;
                    }

                    if (initialY < finalY) {
                        Log.d(TAG, "Up to Down swipe performed");
                        cur_dirn = 4;
                    }

                    if (initialY > finalY) {
                        Log.d(TAG, "Down to Up swipe performed");
                        cur_dirn = 3;
                    }

                    break;

                case MotionEvent.ACTION_CANCEL:
                    Log.d(TAG,"Action was CANCEL");
                    break;

                case MotionEvent.ACTION_OUTSIDE:
                    Log.d(TAG, "Movement occurred outside bounds of current screen element");
                    break;
            }

            return super.onTouchEvent(event);
        }*/

    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        switch (event.getAction()) {
            case MotionEvent.ACTION_DOWN:
                x1 = event.getX();
                y1 = event.getY();
                Log.d(TAG, "Action was UP");
                break;

            case MotionEvent.ACTION_UP:
                x2 = event.getX();
                y2 = event.getY();
                float Y = y2 - y1;
                float X = x2 - x1;
                if (Math.abs(X) > MIN_DISTANCE) {
                    if (x2 > x1) {

                        //SnakeView.cur_dirn = 1;
                        SnakeView.count = 1;
                        //SnakeView.transition();
                        //Toast.makeText(getContext(), "right swipe", Toast.LENGTH_SHORT).show();
                        //swipe=1;
                    } else {
                        //SnakeView.cur_dirn = 2;
                        SnakeView.count = 2;
                        //SnakeView.transition();
                        //Toast.makeText(getContext(), "left swipe", Toast.LENGTH_SHORT).show();
                        //swipe=2;
                    }
                }

                else if (Math.abs(Y) > MIN_DISTANCE) {
                    if (y2 > y1) {
                        //SnakeView.cur_dirn = 4;
                        SnakeView.count = 4;
                        //SnakeView.transition();
                        //Toast.makeText(getContext(), "top to bottom", Toast.LENGTH_SHORT).show();
                        //swipe=3;
                    } else {
                        //SnakeView.cur_dirn = 3;
                        SnakeView.count = 3;
                        //SnakeView.transition();
                        //Toast.makeText(getContext(), "bottom to top", Toast.LENGTH_SHORT).show();
                        //swipe=4;
                    }
                }

                break;
        }

        return super.onTouchEvent(event);
    }


}

   /* public  class  time extends Thread{

        public void Run() throws InterruptedException {

            long millis = 5000;
            int nanos = 1000000;
            Thread.sleep(millis,nanos);

        }
    }*/



