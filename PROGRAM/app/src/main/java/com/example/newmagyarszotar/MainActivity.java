package com.example.newmagyarszotar;

import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity
{
    //----------test-------------------------
    private Button test_button;
    private TextView text_view_test;
    private int altern = 0;
    //---------------------------------------

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //----------------test----------------------
        text_view_test = (TextView)findViewById(R.id.textView);
        test_button = (Button)findViewById(R.id.testbtn);

        test_button.setOnClickListener(testButtonClickListener);

        //------------------------------------------
    }

    //-------------------------test-------------------------------
    View.OnClickListener testButtonClickListener = new View.OnClickListener()
    {
        public void onClick(View v)
        {
            if(altern == 0)
            {
                text_view_test.setText("HosszuIdoNemTenger++");
                altern = 1;
            }
            else
            {
                text_view_test.setText("HosszuIdoNemTenger--");
                altern = 0;
            }
        }
    };
    //------------------------------------------------------------
}