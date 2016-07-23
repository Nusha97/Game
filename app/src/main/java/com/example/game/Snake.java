import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.drawable.BitmapDrawable;
import android.view.View;
import android.widget.LinearLayout;

import com.example.game.R;

/*package com.example.game;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.drawable.BitmapDrawable;
import android.view.View;
import android.widget.LinearLayout;

/**
 * Created by Nusha on 21/07/2016.
 */
/*public class Snake extends View {

    private int[][] snake_pos = new int[100][2];
    private int sx = 150,sy = 300;

    int i;


    public Snake(Context context) {
        super(context);
    }

    public void initializeArray(final int[][] arr, final int x, int y) {
        for(int i = 0; i < 5; i++) {

                arr[i][0] = x + i*20;
                arr[i][1] = y;
            }
            //x += 10;
        }


    @Override
    protected void onDraw(Canvas canvas) {
        Paint paint = new Paint();
        paint.setColor(Color.parseColor("#CD5C5C"));
        Bitmap bg = Bitmap.createBitmap(480, 800, Bitmap.Config.ARGB_8888);
        //Canvas canvas = new Canvas(bg);
        initializeArray(snake_pos, sx, sy);
        for (i = 0; i < 5; i++) {
            canvas.drawCircle(snake_pos[i][0], snake_pos[i][1], 10, paint);
            LinearLayout ll = (LinearLayout) findViewById(R.id.rect);
            ll.setBackgroundDrawable(new BitmapDrawable(bg));

        }

        invalidate();
    }
}
*/