package com.example.newmagyarszotar;

import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity
{
    //----------test-------------------------
    private Button conn_test_button;
    private TextView conn_text_view_test;
    private boolean once_conn = true;
    private DataBase db = new DataBase();
    //---------------------------------------

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //----------------test----------------------
        conn_text_view_test = (TextView)findViewById(R.id.textView);
        conn_test_button = (Button)findViewById(R.id.testbtn);

        conn_test_button.setOnClickListener(testButtonClickListener);
        //------------------------------------------
    }

    //-------------------------test-------------------------------
    View.OnClickListener testButtonClickListener = new View.OnClickListener()
    {
        public void onClick(View v)
        {
            if(once_conn)
            {

                conn_text_view_test.setText(db.getStr());
                once_conn = false;
            }
        }
    };
    //------------------------------------------------------------
}