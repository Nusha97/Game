package com.example.game;

import android.os.Handler;
/**
 * Created by Nusha on 20/07/2016.
 */
public class Utils {

        // Delay mechanism

        public interface DelayCallback{
            void afterDelay();
        }

        public static void delay(int secs, final DelayCallback delayCallback){
            Handler handler = new Handler();
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    delayCallback.afterDelay();
                }
            }, secs * 1000); // afterDelay will be executed after (secs*1000) milliseconds.
        }
    }

